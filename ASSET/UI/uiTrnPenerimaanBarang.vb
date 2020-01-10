Imports Microsoft.Win32
Imports System.Threading
Imports System.ComponentModel
Imports System
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList

Public Class uiTrnPenerimaanBarang
    Implements ILocking

    Private Const mUiName As String = "Transaksi Penerimaan Barang"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Event FormBeforeOpenRow(ByRef id As Object, ByRef CancelOpenRow As Boolean)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)
    Private Event FormBindingStartDetil()
    Private Event FormBindingStopDetil()

    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_TrnPenerimaanbarang As DataTable = clsDataset.CreateTblTrnPenerimaanbarang()
    Private tbl_TrnPenerimaanbarang_Temp As DataTable = clsDataset.CreateTblTrnPenerimaanbarang()
    Private tbl_TrnPenerimaanbarangdetil As DataTable = clsDataset.CreateTblViewTrnTerimabarangDetil()

    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_MstRekananDetil As DataTable = clsDataset.CreateTblMstrekananCombo()

    'Search
    Private tbl_MstChannel_search As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstRekanan_search As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_MstStrukturunit_search As DataTable = clsDataset.CreateTblStrukturunitPemilik

    Private tbl_MstAccGrid As DataTable = clsDataset.CreateTblMstAccountCombo()
    Private tbl_MstAccGridDetil As DataTable = clsDataset.CreateTblMstAccountCombo()

    Private Tbl_Mstemployee As DataTable = clsDataset.CreateTblemployeepemilik()

    Private tbl_MstCurrency As DataTable = clsDataset.CreateTblMstCurrency
    Private tbl_MstCurrencyDetil As DataTable = clsDataset.CreateTblMstCurrency
    Private tbl_MstCurrencyGrid As DataTable = clsDataset.CreateTblMstCurrencyJurnal
    Private tbl_MstCurrencyDataDetil As DataTable = clsDataset.CreateTblMstCurrency

    Private tbl_TrnBudget As DataTable = clsDataset.CreateTblMstBudgetCombo()
    Private tbl_TrnBudgetHome As DataTable = clsDataset.CreateTblMstBudgetCombo()
    Private tbl_TrnBudgetDetil As DataTable = clsDataset.CreateTblMstBudgetdetilCombo()
    Private tbl_MstPeriode As DataTable = clsDataset.CreateTblMstPeriodeCombo()
    Private tbl_MstPeriodeCombo As DataTable = clsDataset.CreateTblMstPeriodeCombo()

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

    '-- Untuk Jurnal
    Private tbl_TrnJurnal As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_TrnJurnaldetil_kredit As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_TrnJurnaldetil_debet As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_JurnalReference As DataTable = clsDataset.CreateTblTrnJurnalreference()
    Private tbl_JurnalResponse As DataTable = clsDataset.CreateTblJurnalResponseRV()
    Private tbl_MstStrukturunitGrid As DataTable = clsDataset.CreateTblStrukturunitPemilik()

    Private tbl_MstKategoriAssetDepre As DataTable = clsDataset.CreateTblMstKategoriassetdepre()
    'add On BgWorker
    Private _LOADCOMBOSEARCH As Boolean = False
    Private label_thread As String
    Private isBackGroundWorker_isWork As Boolean = False
    Private isBackgroundWorker As Boolean = False

    'untuk copy anakan
    Private motherTbl As DataTable = clsDataset.CreateTblTrnPenerimaanbarangdetil
    Private childTbl As DataTable = clsDataset.CreateTblTrnPenerimaanbarangdetil

    'add On Button
    Friend WithEvents btnApproved As ToolStripButton = New ToolStripButton
    Friend WithEvents btnUnApproved As ToolStripButton = New ToolStripButton
    Friend WithEvents btnHome As ToolStripButton = New ToolStripButton

    'Untuk print barcode
    Private file_path As String
    Private shell_path As String

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnPenerimaanbarang
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnPenerimaanbarangdetil

    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptPenerimaanBarang
    Private objDatalistDetil As ArrayList
    Private objPrintHeaderJurnal As DataSource.clsRptJurnal_Header
    Private objPrintDetilJurnal As DataSource.clsRptJurnal_Detil
    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptTerimaBarang_ID As String
    Private sptDomain As String

    Private parJurnal_id As String
    Private parJurnalType_id As String
    Private parJurnal_Source As String
    Private parJurnal_BookDate As String
    Private parPeriode_Name As String
    Private parCurrency_Name As String
    Private parJurnal_AmountForeign As String
    Private parRekanan_Name As String
    Private parJurnal_Desc As String

    Private stringCollection As New AutoCompleteStringCollection

    Private btnNewClick As Boolean = False

    Private currency_id As Decimal
    Private foreign_rate As Decimal

    Private channel_number As String

    'Tambahan Array Image
    Private photoChanged As New Specialized.ListDictionary
    Private UtilPhoto As New clsTrnPenerimaanBarang()
    '-------------------------------------------------------

    Private sptSumTotal As String
    Private sptSumDiscount As String
    Private sptSumPPn As String
    Private sptSumPPh As String
    Private sptSumGrandTotal As String

    Private locking As clsLockingTransaction

    Private e_Button As New MouseButtons()

    Enum ModuleType
        PURCHASE
        MANUAL
        LISTPV
        LISTGQ
    End Enum

    Enum StatusApp
        Approved
        UnApproved
    End Enum

    Enum StrukturUnit
        TSV = 5554
        Wardrobe = 5556
        Transmisi = 3130
        Project = 5548
        Accounting = 5522
    End Enum
    '===
#Region " Window Parameter "
    Private _CHANNEL As String = "TAS"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
    Private _STRUKTUR_UNIT As StrukturUnit = StrukturUnit.TSV
    Private _USERTYPE As String = "user" '"spv" '"acc"'"user"
    Private _MODULE_TYPE As ModuleType = ModuleType.LISTGQ
#End Region

#Region " Additional Overrides "
    Private Sub btnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproved.Click
        If Me.DgvTrnPenerimaanbarang.Rows.Count > 0 Then
            If Me._USERTYPE = "user" Or Me._USERTYPE = "spv" Then
                'Cek jika itemnya adalah consumable maka wajib ngisi serial
                '============================================================
                Dim receive As New clsTrnPenerimaanBarang()
                Dim sn As String

                For Each row As DataRow In Me.tbl_TrnPenerimaanbarangdetil.Rows
                    If receive.GetAssetTypeDetail(row) = clsTrnPenerimaanBarang.AssetTypeDetail.Consumable Then
                        sn = row.Item("terimabarangdetil_serial_no").ToString().Trim()

                        If sn = "" Then
                            MsgBox("Serial number harus diisi.", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    End If
                Next
                '=============================================================

                'Cek rekanan wajib di isi
                If Me._MODULE_TYPE <> ModuleType.MANUAL Then
                    If Me.ftabMain.SelectedIndex = 0 Then
                        Dim currentRow As DataRow = CType(Me.DgvTrnPenerimaanbarang.CurrentRow.DataBoundItem, DataRowView).Row
                        Dim rekanan_id As Object = currentRow.Item("rekanan_id")

                        If rekanan_id Is DBNull.Value OrElse rekanan_id = 0 Then
                            MsgBox("Rekanan harus di isi", MsgBoxStyle.Exclamation)

                            Exit Sub
                        End If
                    Else
                        If Me.obj_Rekanan_id.SelectedValue = 0 Then
                            Me.objFormError.SetError(Me.obj_Rekanan_id, "Rekanan harus di isi")
                            Exit Sub
                        Else
                            Me.objFormError.SetError(Me.obj_Rekanan_id, "")
                        End If
                    End If
                End If
            End If

            If Me._USERTYPE = "user" Then

                Dim terimabarang_id As String = Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
                Me.locking.TryLocking(terimabarang_id)

                If Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appuser").Value = False Then
                    '==== Check lockingan untuk approval / unapproval user ====
                    If Me.locking.Status = clsLockingTransaction.LockStatus.Locked Then
                        MessageBox.Show("" & terimabarang_id & " is being used by another user", "DATA CAN'T APPROVED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.btnApproved.Enabled = True
                        Exit Sub
                    Else
                        Me.uiTrnPenerimaanBarang_Purchase_AppUser("approved")
                        Me.locking.Clear()
                    End If

                End If
            ElseIf Me._USERTYPE = "spv" Then
                If Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appuser").Value = False Then
                    MsgBox("Need User Approved", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appspv").Value = False Then
                    Me.uiTrnPenerimaanBarang_Purchase_AppSpv("approved")
                End If
            ElseIf Me._USERTYPE = "acc" Then
                If obj_Terimabarang_nosuratjalan.Text.Trim = "" Then
                    MsgBox("Delivery Order Number Should Not Be Empty")
                    obj_Terimabarang_nosuratjalan.Focus()
                    Exit Sub
                End If

                If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appuser").Value, False) = False Then
                    MsgBox("Need User Approved", MsgBoxStyle.Information)
                ElseIf clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appspv").Value, False) = False Then
                    MsgBox("Need Spv Approved", MsgBoxStyle.Information)
                ElseIf clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appacc").Value, False) = False Then
                    Me.uiTrnPenerimaanBarang_Purchase_AppAcc(StatusApp.Approved)
                End If
            End If
        End If
    End Sub

    Private Sub btnUnApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnApproved.Click
        If Me.DgvTrnPenerimaanbarang.Rows.Count > 0 Then
            If Me._USERTYPE = "user" Then

                If Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appacc").Value = True Then
                    MsgBox("Need Accounting UnApproved", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appspv").Value = True Then
                    MsgBox("Need Spv / Section Head UnApproved", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appuser").Value = True Then
                    Dim terimabarang_id As String = Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
                    Me.locking.TryLocking(terimabarang_id)

                    '==== Check lockingan untuk approval / unapproval user ====
                    If Me.locking.Status = clsLockingTransaction.LockStatus.Locked Then
                        MessageBox.Show("" & terimabarang_id & " is being used by another user", "DATA CAN'T UNAPPROVED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.btnUnApproved.Enabled = True
                        Exit Sub
                    Else
                        Me.uiTrnPenerimaanBarang_Purchase_AppUser("unapproved")
                        Me.locking.Clear()
                    End If
                End If
            ElseIf Me._USERTYPE = "spv" Then
                If Me.DgvTrnPenerimaanbarang.Item("terimabarang_appacc", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = True Then
                    MsgBox("Need Accounting UnApproved", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appspv").Value = True Then
                    Me.uiTrnPenerimaanBarang_Purchase_AppSpv("unapproved")
                End If
            ElseIf Me._USERTYPE = "acc" Then
                If Me.DgvTrnJurnalresponse.Rows.Count > 0 Then
                    Dim s As Integer
                    Dim message As String = String.Empty

                    For s = 0 To Me.DgvTrnJurnalresponse.Rows.Count - 1
                        If message = String.Empty Then
                            message = " UnApproved dan delete dulu jurnal " & DgvTrnJurnalresponse.Rows(s).Cells("ref").Value
                        Else
                            message &= ", " & DgvTrnJurnalresponse.Rows(s).Cells("ref").Value
                        End If
                    Next
                    MsgBox(message)
                Else
                    Dim tbl_periode As DataTable = clsDataset.CreateTblMstPeriodeCombo()

                    Me.DataFill(tbl_periode, "ms_MstPeriode_Select", String.Format("periode_id = '{0}' and channel_id = '{1}'", Me.cbo_periode.SelectedValue, Me._CHANNEL))

                    If tbl_periode.Rows(0).Item("periode_isclosed") = True Then
                        MsgBox("Periode is closed")

                        Exit Sub
                    Else
                        Me.uiTrnPenerimaanBarang_Purchase_AppAcc(StatusApp.UnApproved)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHome.Click
        Me.pnlDetil.Visible = False
        Me.btnHome.Visible = False
        If Me.locking.Status = clsLockingTransaction.LockStatus.Locked Then
            Me.tbtnSave.Enabled = False
        Else
            Me.tbtnSave.Enabled = True
        End If

        BindingContext(Me.tbl_TrnPenerimaanbarangdetil).EndCurrentEdit()
    End Sub

    Private Sub uiTrnPenerimaanBarang_Purchase_AppUser(ByVal status As String)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Dim terimabarang_id As String = Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
        Dim channel_id As String = Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
        Dim dbConn As New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbTrans As OleDb.OleDbTransaction = Nothing
        Dim cookie As Byte() = Nothing

       
        Try
            If status = "approved" Then
                Dim tbl_Temp As New DataTable

                Using receive As New clsTrnPenerimaanBarang(Me.DSNFrm)
                    receive.RetrieveDetail(tbl_Temp, String.Format("terimabarang_id = '{0}'", terimabarang_id))
                End Using

                If tbl_Temp.Rows.Count = 0 Then
                    Throw New Exception("Item detil can't be empty.")
                Else
                    tbl_Temp.Clear()
                End If
            End If

            dbConn.Open()
            dbTrans = dbConn.BeginTransaction()
            clsApplicationRole.SetAppRole(dbConn, dbTrans, cookie)

            Using receive As New clsTrnPenerimaanBarang()
                If status = "approved" Then
                    receive.UserApproved(channel_id, terimabarang_id, Me.UserName, dbConn, dbTrans)
                Else
                    receive.UserUnapproved(channel_id, terimabarang_id, Me.UserName, dbConn, dbTrans)
                End If
            End Using

            dbTrans.Commit()

            If status = "approved" Then
                'Me.obj_Terimabarang_appuser.Checked = True
                Me.DgvTrnPenerimaanbarang.Item("terimabarang_appuser", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 1
                Me.btnApproved.Enabled = False
                Me.btnUnApproved.Enabled = True
                MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'Me.obj_Terimabarang_appuser.Checked = False
                Me.DgvTrnPenerimaanbarang.Item("terimabarang_appuser", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0

                Me.btnApproved.Enabled = True
                Me.btnUnApproved.Enabled = False

                MessageBox.Show("Data Has Been UnApproved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As System.Data.OleDb.OleDbException
            dbTrans.Rollback()
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, dbTrans, cookie)
            dbConn.Close()
        End Try

        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub Isi_CurrencyBermasalah(ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        '==========PTS 20130913 currency gk masuk====
        '========== Modife by kokoh==================

        Try
            Dim cmd As New OleDb.OleDbCommand("as_TrnPenerimaanBarang_IsiCurrencyKosong", dbConn, dbTrans)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = terimabarang_id
            cmd.Parameters.Add("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5).Value = currency_id
            cmd.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me._CHANNEL

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub uiTrnPenerimaanBarang_Purchase_AppSpv(ByVal status_approved As String)
        Dim dlg As New dlgStatusTerimaJasa()
        Dim status As String = String.Empty
        Dim dbConnFrm As OleDb.OleDbConnection
        'Dim dbConnAsset As OleDb.OleDbConnection
        Dim dbTransFrm As OleDb.OleDbTransaction
        'Dim dbTransAsset As OleDb.OleDbTransaction
        Dim cookie As Byte() = Nothing
        'Dim cookie1 As Byte() = Nothing

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If status_approved = "approved" Then
            status = dlg.OpenDialog(Me)

            If status IsNot Nothing Then
                If status = "-- Pilih --" Then
                    MsgBox("Please choose COMPLETE or INCOMPLETE")
                    Exit Sub
                Else
                    If Me.uiTrnPenerimaanbarang_FormChanges() Then
                        Exit Sub
                    End If

                    If Me.uiTrnPenerimaanBarang_FormErrorValidasi() Then
                        Exit Sub
                    End If

                    dbConnFrm = New OleDb.OleDbConnection(Me.DSNFrm)
                    'dbConnAsset = New OleDb.OleDbConnection(Me.DSNAsset)

                    dbConnFrm.Open()
                    ' dbConnAsset.Open()

                    dbTransFrm = dbConnFrm.BeginTransaction()
                    'dbTransAsset = dbConnAsset.BeginTransaction()
                    clsApplicationRole.SetAppRole(dbConnFrm, dbTransFrm, cookie)
                    'clsApplicationRole.SetAppRole(dbConnAsset, dbTransAsset, cookie1)

                    Try
                        If Me.obj_Terimabarang_type.Text = "PURCHASE" Then
                            '==============ADD PTS 20130913urrency bermasalah=============
                            Dim cur_id As Decimal = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("currency_id")
                            If cur_id = 0 Then
                                Me.Isi_CurrencyBermasalah(Me.obj_Terimabarang_id.Text, dbConnFrm, dbTransFrm)
                            End If
                            '===============================================================
                        ElseIf Me.obj_Terimabarang_type.Text = "LISTPV" Or Me.obj_Terimabarang_type.Text = "MANUAL" Then
                        End If

                        Dim order_id As String = Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("order_id").Value
                        Using receive As New clsTrnPenerimaanBarang()
                            receive.SpvApproved(Me._CHANNEL, Me.obj_Terimabarang_id.Text, Me.UserName, status, dbConnFrm, dbTransFrm)
                            receive.CreateBarcode(Me.obj_Terimabarang_id.Text, dbConnFrm, dbTransFrm)

                            If Me._MODULE_TYPE = ModuleType.LISTGQ OrElse Me._MODULE_TYPE = ModuleType.MANUAL Then
                                If Me._STRUKTUR_UNIT = 5556 Then
                                    receive.CopyBarcodeToMasterAsset(Me.obj_Terimabarang_id.Text, dbConnFrm, dbTransFrm)
                                End If
                            End If

                            receive.BuildJurnal(Me.obj_Terimabarang_id.Text, dbConnFrm, dbTransFrm)
                        End Using

                        dbTransFrm.Commit()
                        ' dbTransAsset.Commit()

                        Me.DgvTrnPenerimaanbarang.Item("terimabarang_status", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = status
                        Me.DgvTrnPenerimaanbarang.Item("terimabarang_appspv", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 1

                        Me.uiTrnPenerimaanBarang_RefreshPosition()
                        MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As System.Data.OleDb.OleDbException
                        dbTransFrm.Rollback()
                        ' dbTransAsset.Rollback()

                        '-------------------------------------------------------------------
                        For Each row As DataRow In Me.tbl_TrnJurnal.Rows
                            row.CancelEdit()
                        Next

                        For Each row As DataRow In Me.tbl_TrnJurnaldetil_debet.Rows
                            row.CancelEdit()
                        Next

                        For Each row As DataRow In Me.tbl_TrnJurnaldetil_kredit.Rows
                            row.CancelEdit()
                        Next

                        For Each row As DataRow In Me.tbl_TrnPenerimaanbarang_Temp.Rows
                            row.CancelEdit()
                        Next
                        '-------------------------------------------------------------------

                        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        clsApplicationRole.UnsetAppRole(dbConnFrm, dbTransFrm, cookie)
                        '  clsApplicationRole.UnsetAppRole(dbConnAsset, dbTransAsset, cookie1)
                        dbConnFrm.Close()
                        ' dbConnAsset.Close()
                    End Try
                End If
            End If
        Else
            dbConnFrm = New OleDb.OleDbConnection(Me.DSNFrm)
            dbConnFrm.Open()
            dbTransFrm = dbConnFrm.BeginTransaction()
            clsApplicationRole.SetAppRole(dbConnFrm, dbTransFrm, cookie)
            Try
                Dim order_id As String = Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("order_id").Value

                Using receive As New clsTrnPenerimaanBarang()
                    receive.SpvUnapproved(Me._CHANNEL, Me.obj_Terimabarang_id.Text, Me.UserName, status, dbConnFrm, dbTransFrm)

                    If Me._MODULE_TYPE = ModuleType.LISTGQ OrElse Me._MODULE_TYPE = ModuleType.MANUAL Then
                        If Me._STRUKTUR_UNIT = 5556 Then
                            receive.DeleteBarcodeFromMasterAsset(Me.obj_Terimabarang_id.Text, dbConnFrm, dbTransFrm)
                        End If
                    End If

                    If Me._MODULE_TYPE = ModuleType.MANUAL OrElse Me._MODULE_TYPE = ModuleType.PURCHASE Then
                        If Me._STRUKTUR_UNIT <> 5556 Then
                            receive.ClearBarcode(Me.obj_Terimabarang_id.Text, dbConnFrm, dbTransFrm)
                        End If
                    End If
                End Using

                dbTransFrm.Commit()

                Me.DgvTrnPenerimaanbarang.Item("terimabarang_status", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = status
                Me.DgvTrnPenerimaanbarang.Item("terimabarang_appspv", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0

                Me.uiTrnPenerimaanBarang_RefreshPosition()
            Catch ex As System.Data.OleDb.OleDbException
                dbTransFrm.Rollback()

                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConnFrm.State = ConnectionState.Open Then
                    clsApplicationRole.UnsetAppRole(dbConnFrm, dbTransFrm, cookie)
                    dbConnFrm.Close()
                End If
            End Try
        End If

        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub uiTrnPenerimaanBarang_UpdateList()
        Dim listRow As DataRow = CType(Me.DgvTrnPenerimaanbarang.CurrentRow.DataBoundItem, DataRowView).Row
        Dim terimabarang_id As String = Me.obj_Terimabarang_id.Text

        listRow.ItemArray = New clsTrnPenerimaanBarang(Me.DSNFrm).SelectHeader(terimabarang_id, Me._CHANNEL).ItemArray

        listRow.AcceptChanges()
    End Sub

    Private Sub uiTrnPenerimaanBarang_Purchase_AppAcc(ByVal status As StatusApp)
        Cursor = Cursors.WaitCursor

        If status = StatusApp.Approved Then
            If Me.uiTrnPenerimaanbarang_FormChanges() Then
                Cursor = Cursors.Default

                Exit Sub
            End If

            If Me.uiTrnPenerimaanBarang_FormError() Then
                Cursor = Cursors.Default

                Exit Sub
            End If
        ElseIf status = StatusApp.UnApproved Then
            If Me.UserName <> Me.tbl_TrnJurnal.Rows(0).Item("jurnal_ispostedby") Then
                Cursor = Cursors.Default

                MsgBox("Access denied", MsgBoxStyle.Critical)

                Exit Sub
            End If
        End If

        Dim receive As New clsTrnPenerimaanBarang()
        Dim assetLog As New clsMstAssetConsumableLog(Me._CHANNEL)
        Dim assetConsumable As New clsMstAssetConsumable(Me._CHANNEL, Me.DSNFrm)
        Dim assetClosing As New clsMstAssetConsumableClosing(Me._CHANNEL, Me.DSNFrm)
        Dim terimabarang_id As String
        Dim line As Integer
        Dim barcode As String
        Dim asset_serial As String
        Dim asset_qty As Integer
        Dim asset_qtydetail As Integer
        Dim asset_qtytotal As Integer
        Dim asset_description As String
        Dim category_id As String
        Dim brand_id As Integer
        Dim tipeitem_id As String
        Dim strukturunit_id As Decimal
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbTrans As OleDb.OleDbTransaction = Nothing
        Dim cookie As Byte() = Nothing

        terimabarang_id = Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value

        Try
            dbConn.Open()

            dbTrans = dbConn.BeginTransaction()
            clsApplicationRole.SetAppRole(dbConn, dbTrans, cookie)

            If status = StatusApp.Approved Then
                receive.AccApproved(Me._CHANNEL, terimabarang_id, Me.UserName, dbConn, dbTrans)

                If Me.obj_Terimabarang_type.Text.ToUpper() <> "LISTGQ" Then
                    receive.CopyBarcodeToMasterAsset(terimabarang_id, dbConn, dbTrans)
                End If
            ElseIf status = StatusApp.UnApproved Then
                receive.AccUnapproved(Me._CHANNEL, terimabarang_id, Me.UserName, dbConn, dbTrans)

                If Me.obj_Terimabarang_type.Text.ToUpper() <> "LISTGQ" Then
                    receive.DeleteBarcodeFromMasterAsset(terimabarang_id, dbConn, dbTrans)
                End If
            End If

            For Each row As DataRow In Me.tbl_TrnPenerimaanbarangdetil.Rows
                If receive.GetAssetTypeDetail(row) = clsTrnPenerimaanBarang.AssetTypeDetail.Consumable Then
                    line = row.Item("terimabarangdetil_line")
                    barcode = row.Item("terimabarang_barcode").ToString()
                    asset_serial = row.Item("terimabarangdetil_serial_no").ToString()
                    asset_qty = row.Item("terimabarangdetil_qty")
                    asset_qtydetail = row.Item("terimabarangdetil_qtydetail")
                    asset_qtytotal = row.Item("terimabarangdetil_qtytotal")
                    asset_description = row.Item("terimabarangdetil_desc").ToString()
                    category_id = row.Item("itemcategory_id").ToString()
                    brand_id = clsUtil.IsDbNull(row.Item("brand_id"), 0)
                    tipeitem_id = row.Item("itemtype_id").ToString()
                    strukturunit_id = row.Item("strukturunit_id")

                    If status = StatusApp.Approved Then
                        assetLog.Insert(terimabarang_id, line, barcode, asset_serial, asset_qty, asset_qtydetail, _
                                                                               asset_qtytotal, strukturunit_id, dbConn, dbTrans)

                        If assetConsumable.Exists(asset_serial, strukturunit_id, dbConn, dbTrans) Then
                            assetConsumable.UpdateQty(asset_serial, asset_qtytotal, strukturunit_id, dbConn, dbTrans)
                        Else
                            assetConsumable.Insert(asset_serial, asset_description, strukturunit_id, _
                                                    category_id, brand_id, tipeitem_id, asset_qtytotal, 0, dbConn, dbTrans)
                            assetClosing.Insert(asset_serial, strukturunit_id, 0, 0, dbConn, dbTrans)
                        End If
                    Else
                        assetLog.Delete(terimabarang_id, line, dbConn, dbTrans)
                        assetConsumable.UpdateQty(asset_serial, -asset_qtytotal, strukturunit_id, dbConn, dbTrans)
                    End If
                End If
            Next

            dbTrans.Commit()

            If status = StatusApp.Approved Then
                Me.DgvTrnPenerimaanbarang.Item("terimabarang_appacc", Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 1
                Me.uiTrnPenerimaanBarang_RefreshPosition()

                MessageBox.Show("Data Has Been Post", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.DgvTrnPenerimaanbarang.Item("terimabarang_appacc", Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0
                Me.uiTrnPenerimaanBarang_RefreshPosition()

                MessageBox.Show("Data Has Been UnPost", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As System.Data.OleDb.OleDbException
            dbTrans.Rollback()

            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, dbTrans, cookie)
                dbConn.Close()
            End If
        End Try

        Cursor = Cursors.Default
    End Sub
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
        Me.Cursor = Cursors.WaitCursor
        Me.btnNewClick = True

        If Me.ftabMain.SelectedIndex = 0 Then
            Me.ftabMain.SelectedIndex = 1
        End If

        Me.uiTrnPenerimaanBarang_NewData()

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

    Public Overrides Function btnSave_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        If Me._MODULE_TYPE = ModuleType.LISTGQ Then
            If Me.obj_Order_id.Text = String.Empty Then
                MsgBox("Pilih GQ terlebih dahulu.")
                Exit Function
            End If
        End If

        If Me.uiTrnPenerimaanBarang_FormError() Then
            Cursor = Cursors.Arrow
            Exit Function
        End If

        If Me._USERTYPE = "acc" Then
            Me.uiTrnPenerimaanBarang_Purchase_JurnalSave()
        End If

        Me.uiTrnPenerimaanBarang_Save()

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPenerimaanBarang_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If Me._USERTYPE = "acc" Then
            Me.uiTrnPenerimaanBarang_PrintJurnal()
        Else
            Me.uiTrnPenerimaanBarang_Print()
        End If
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPenerimaanBarang_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPenerimaanBarang_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPenerimaanBarang_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPenerimaanBarang_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPenerimaanBarang_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnPenerimaanbarang(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnPenerimaanbarang Columns 
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_owner As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_qtyitem As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_qtyrealization As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_statusrealization As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_location As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_notes As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_nosuratjalan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_isdisabled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_createby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_createdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_modifiedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_modifieddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appuser As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_appuser_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appuser_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appspv As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_appspv_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appspv_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appacc As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_appacc_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appacc_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_idrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_disc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_cetakbpb As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        'view
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "Receive No."
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 100
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = False

        cTerimabarang_date.Name = "terimabarang_date"
        cTerimabarang_date.HeaderText = "Date"
        cTerimabarang_date.DataPropertyName = "terimabarang_date"
        cTerimabarang_date.Width = 80
        cTerimabarang_date.Visible = True
        cTerimabarang_date.ReadOnly = False

        cTerimabarang_type.Name = "terimabarang_type"
        cTerimabarang_type.HeaderText = "Type"
        cTerimabarang_type.DataPropertyName = "terimabarang_type"
        cTerimabarang_type.Width = 100
        cTerimabarang_type.Visible = False
        cTerimabarang_type.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "budget_id"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "rekanan_id"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = False

        cEmployee_id_owner.Name = "employee_id_owner"
        cEmployee_id_owner.HeaderText = "employee_id_owner"
        cEmployee_id_owner.DataPropertyName = "employee_id_owner"
        cEmployee_id_owner.Width = 100
        cEmployee_id_owner.Visible = False
        cEmployee_id_owner.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cTerimabarang_qtyitem.Name = "terimabarang_qtyitem"
        cTerimabarang_qtyitem.HeaderText = "terimabarang_qtyitem"
        cTerimabarang_qtyitem.DataPropertyName = "terimabarang_qtyitem"
        cTerimabarang_qtyitem.Width = 100
        cTerimabarang_qtyitem.Visible = False
        cTerimabarang_qtyitem.ReadOnly = False

        cTerimabarang_qtyrealization.Name = "terimabarang_qtyrealization"
        cTerimabarang_qtyrealization.HeaderText = "terimabarang_qtyrealization"
        cTerimabarang_qtyrealization.DataPropertyName = "terimabarang_qtyrealization"
        cTerimabarang_qtyrealization.Width = 100
        cTerimabarang_qtyrealization.Visible = False
        cTerimabarang_qtyrealization.ReadOnly = False

        cOrder_qty.Name = "order_qty"
        cOrder_qty.HeaderText = "order_qty"
        cOrder_qty.DataPropertyName = "order_qty"
        cOrder_qty.Width = 100
        cOrder_qty.Visible = False
        cOrder_qty.ReadOnly = False

        cTerimabarang_status.Name = "terimabarang_status"
        cTerimabarang_status.HeaderText = "Status"
        cTerimabarang_status.DataPropertyName = "terimabarang_status"
        cTerimabarang_status.Width = 120
        cTerimabarang_status.Visible = True
        cTerimabarang_status.ReadOnly = False

        cTerimabarang_statusrealization.Name = "terimabarang_statusrealization"
        cTerimabarang_statusrealization.HeaderText = "terimabarang_statusrealization"
        cTerimabarang_statusrealization.DataPropertyName = "terimabarang_statusrealization"
        cTerimabarang_statusrealization.Width = 100
        cTerimabarang_statusrealization.Visible = False
        cTerimabarang_statusrealization.ReadOnly = False

        cTerimabarang_location.Name = "terimabarang_location"
        cTerimabarang_location.HeaderText = "terimabarang_location"
        cTerimabarang_location.DataPropertyName = "terimabarang_location"
        cTerimabarang_location.Width = 100
        cTerimabarang_location.Visible = False
        cTerimabarang_location.ReadOnly = False

        cTerimabarang_notes.Name = "terimabarang_notes"
        cTerimabarang_notes.HeaderText = "Notes"
        cTerimabarang_notes.DataPropertyName = "terimabarang_notes"
        cTerimabarang_notes.Width = 200
        cTerimabarang_notes.Visible = True
        cTerimabarang_notes.ReadOnly = False

        cTerimabarang_nosuratjalan.Name = "terimabarang_nosuratjalan"
        cTerimabarang_nosuratjalan.HeaderText = "terimabarang_nosuratjalan"
        cTerimabarang_nosuratjalan.DataPropertyName = "terimabarang_nosuratjalan"
        cTerimabarang_nosuratjalan.Width = 100
        cTerimabarang_nosuratjalan.Visible = False
        cTerimabarang_nosuratjalan.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cTerimabarang_isdisabled.Name = "terimabarang_isdisabled"
        cTerimabarang_isdisabled.HeaderText = "terimabarang_isdisabled"
        cTerimabarang_isdisabled.DataPropertyName = "terimabarang_isdisabled"
        cTerimabarang_isdisabled.Width = 100
        cTerimabarang_isdisabled.Visible = False
        cTerimabarang_isdisabled.ReadOnly = False

        cTerimabarang_createby.Name = "terimabarang_createby"
        cTerimabarang_createby.HeaderText = "terimabarang_createby"
        cTerimabarang_createby.DataPropertyName = "terimabarang_createby"
        cTerimabarang_createby.Width = 100
        cTerimabarang_createby.Visible = False
        cTerimabarang_createby.ReadOnly = False

        cTerimabarang_createdt.Name = "terimabarang_createdt"
        cTerimabarang_createdt.HeaderText = "terimabarang_createdt"
        cTerimabarang_createdt.DataPropertyName = "terimabarang_createdt"
        cTerimabarang_createdt.Width = 100
        cTerimabarang_createdt.Visible = False
        cTerimabarang_createdt.ReadOnly = False

        cTerimabarang_modifiedby.Name = "terimabarang_modifiedby"
        cTerimabarang_modifiedby.HeaderText = "terimabarang_modifiedby"
        cTerimabarang_modifiedby.DataPropertyName = "terimabarang_modifiedby"
        cTerimabarang_modifiedby.Width = 100
        cTerimabarang_modifiedby.Visible = False
        cTerimabarang_modifiedby.ReadOnly = False

        cTerimabarang_modifieddt.Name = "terimabarang_modifieddt"
        cTerimabarang_modifieddt.HeaderText = "terimabarang_modifieddt"
        cTerimabarang_modifieddt.DataPropertyName = "terimabarang_modifieddt"
        cTerimabarang_modifieddt.Width = 100
        cTerimabarang_modifieddt.Visible = False
        cTerimabarang_modifieddt.ReadOnly = False

        cTerimabarang_appuser.Name = "terimabarang_appuser"
        cTerimabarang_appuser.HeaderText = "User"
        cTerimabarang_appuser.DataPropertyName = "terimabarang_appuser"
        cTerimabarang_appuser.Width = 40
        cTerimabarang_appuser.Visible = True
        cTerimabarang_appuser.ReadOnly = False

        cTerimabarang_appuser_by.Name = "terimabarang_appuser_by"
        cTerimabarang_appuser_by.HeaderText = "terimabarang_appuser_by"
        cTerimabarang_appuser_by.DataPropertyName = "terimabarang_appuser_by"
        cTerimabarang_appuser_by.Width = 100
        cTerimabarang_appuser_by.Visible = False
        cTerimabarang_appuser_by.ReadOnly = False

        cTerimabarang_appuser_dt.Name = "terimabarang_appuser_dt"
        cTerimabarang_appuser_dt.HeaderText = "terimabarang_appuser_dt"
        cTerimabarang_appuser_dt.DataPropertyName = "terimabarang_appuser_dt"
        cTerimabarang_appuser_dt.Width = 100
        cTerimabarang_appuser_dt.Visible = False
        cTerimabarang_appuser_dt.ReadOnly = False

        cTerimabarang_appspv.Name = "terimabarang_appspv"
        cTerimabarang_appspv.HeaderText = "SPV"
        cTerimabarang_appspv.DataPropertyName = "terimabarang_appspv"
        cTerimabarang_appspv.Width = 40
        cTerimabarang_appspv.Visible = True
        cTerimabarang_appspv.ReadOnly = False

        cTerimabarang_appspv_by.Name = "terimabarang_appspv_by"
        cTerimabarang_appspv_by.HeaderText = "terimabarang_appspv_by"
        cTerimabarang_appspv_by.DataPropertyName = "terimabarang_appspv_by"
        cTerimabarang_appspv_by.Width = 100
        cTerimabarang_appspv_by.Visible = False
        cTerimabarang_appspv_by.ReadOnly = False

        cTerimabarang_appspv_dt.Name = "terimabarang_appspv_dt"
        cTerimabarang_appspv_dt.HeaderText = "terimabarang_appspv_dt"
        cTerimabarang_appspv_dt.DataPropertyName = "terimabarang_appspv_dt"
        cTerimabarang_appspv_dt.Width = 100
        cTerimabarang_appspv_dt.Visible = False
        cTerimabarang_appspv_dt.ReadOnly = False

        cTerimabarang_appacc.Name = "terimabarang_appacc"
        cTerimabarang_appacc.HeaderText = "ACC"
        cTerimabarang_appacc.DataPropertyName = "terimabarang_appacc"
        cTerimabarang_appacc.Width = 40

        If Me._MODULE_TYPE = ModuleType.MANUAL Then
            cTerimabarang_appacc.Visible = False
        ElseIf Me._MODULE_TYPE = ModuleType.LISTPV Then
            cTerimabarang_appacc.Visible = True
        End If

        cTerimabarang_appacc.ReadOnly = False

        cTerimabarang_appacc_by.Name = "terimabarang_appacc_by"
        cTerimabarang_appacc_by.HeaderText = "terimabarang_appacc_by"
        cTerimabarang_appacc_by.DataPropertyName = "terimabarang_appacc_by"
        cTerimabarang_appacc_by.Width = 100
        cTerimabarang_appacc_by.Visible = False
        cTerimabarang_appacc_by.ReadOnly = False

        cTerimabarang_appacc_dt.Name = "terimabarang_appacc_dt"
        cTerimabarang_appacc_dt.HeaderText = "terimabarang_appacc_dt"
        cTerimabarang_appacc_dt.DataPropertyName = "terimabarang_appacc_dt"
        cTerimabarang_appacc_dt.Width = 100
        cTerimabarang_appacc_dt.Visible = False
        cTerimabarang_appacc_dt.ReadOnly = False

        cTerimabarang_foreign.Name = "terimabarang_foreign"
        cTerimabarang_foreign.HeaderText = "terimabarang_foreign"
        cTerimabarang_foreign.DataPropertyName = "terimabarang_foreign"
        cTerimabarang_foreign.Width = 100
        cTerimabarang_foreign.Visible = False
        cTerimabarang_foreign.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cTerimabarang_foreignrate.Name = "terimabarang_foreignrate"
        cTerimabarang_foreignrate.HeaderText = "terimabarang_foreignrate"
        cTerimabarang_foreignrate.DataPropertyName = "terimabarang_foreignrate"
        cTerimabarang_foreignrate.Width = 100
        cTerimabarang_foreignrate.Visible = False
        cTerimabarang_foreignrate.ReadOnly = False

        cTerimabarang_idrreal.Name = "terimabarang_idrreal"
        cTerimabarang_idrreal.HeaderText = "terimabarang_idrreal"
        cTerimabarang_idrreal.DataPropertyName = "terimabarang_idrreal"
        cTerimabarang_idrreal.Width = 100
        cTerimabarang_idrreal.Visible = False
        cTerimabarang_idrreal.ReadOnly = False

        cTerimabarang_pph.Name = "terimabarang_pph"
        cTerimabarang_pph.HeaderText = "terimabarang_pph"
        cTerimabarang_pph.DataPropertyName = "terimabarang_pph"
        cTerimabarang_pph.Width = 100
        cTerimabarang_pph.Visible = False
        cTerimabarang_pph.ReadOnly = False

        cTerimabarang_ppn.Name = "terimabarang_ppn"
        cTerimabarang_ppn.HeaderText = "terimabarang_ppn"
        cTerimabarang_ppn.DataPropertyName = "terimabarang_ppn"
        cTerimabarang_ppn.Width = 100
        cTerimabarang_ppn.Visible = False
        cTerimabarang_ppn.ReadOnly = False

        cTerimabarang_disc.Name = "terimabarang_disc"
        cTerimabarang_disc.HeaderText = "terimabarang_disc"
        cTerimabarang_disc.DataPropertyName = "terimabarang_disc"
        cTerimabarang_disc.Width = 100
        cTerimabarang_disc.Visible = False
        cTerimabarang_disc.ReadOnly = False

        cTerimabarang_cetakbpb.Name = "terimabarang_cetakbpb"
        cTerimabarang_cetakbpb.HeaderText = "terimabarang_cetakbpb"
        cTerimabarang_cetakbpb.DataPropertyName = "terimabarang_cetakbpb"
        cTerimabarang_cetakbpb.Width = 100
        cTerimabarang_cetakbpb.Visible = False
        cTerimabarang_cetakbpb.ReadOnly = False

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Partner"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 200
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = False

        cEmployee_name.Name = "employee_name"
        cEmployee_name.HeaderText = "Employee"
        cEmployee_name.DataPropertyName = "employee_name"
        cEmployee_name.Width = 200
        cEmployee_name.Visible = True
        cEmployee_name.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimabarang_appuser, cTerimabarang_appspv, cTerimabarang_appacc, _
        cTerimabarang_id, cTerimabarang_date, cTerimabarang_type, cOrder_id, cBudget_id, _
        cRekanan_id, cEmployee_id_owner, cStrukturunit_id, cTerimabarang_qtyitem, _
        cTerimabarang_qtyrealization, cOrder_qty, cTerimabarang_status, cTerimabarang_statusrealization, _
        cTerimabarang_location, cTerimabarang_notes, cRekanan_name, cEmployee_name, _
        cTerimabarang_nosuratjalan, cChannel_id, _
        cTerimabarang_isdisabled, cTerimabarang_createby, cTerimabarang_createdt, _
        cTerimabarang_modifiedby, cTerimabarang_modifieddt, _
        cTerimabarang_appuser_by, cTerimabarang_appuser_dt, _
        cTerimabarang_appspv_by, cTerimabarang_appspv_dt, _
        cTerimabarang_appacc_by, cTerimabarang_appacc_dt, cTerimabarang_foreign, cCurrency_id, _
        cTerimabarang_foreignrate, cTerimabarang_idrreal, cTerimabarang_pph, cTerimabarang_ppn, _
        cTerimabarang_disc, cTerimabarang_cetakbpb})

        ' DgvTrnPenerimaanbarang Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.AutoGenerateColumns = False
        'objDgv.MultiSelect = False
    End Function

    Private Function FormatDgvTrnPenerimaanbarangdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnPenerimaanbarangdetil
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_parentline As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_desc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAssetcategory_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cAssettype_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cTerimabarang_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButtonTerimabarangdetil_printbarcode As New System.Windows.Forms.DataGridViewButtonColumn
        Dim cButtonTerimabarangdetil_printbarcodekain As New System.Windows.Forms.DataGridViewButtonColumn
        Dim cTerimabarang_parentbarcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButtonTerimabarang_parentbarcode As New System.Windows.Forms.DataGridViewButtonColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cItemcategory_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cItemtype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBrand_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cTerimabarangdetil_serial_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_product_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_model As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaterial_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cColour_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cSize_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cSex_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cRoom_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cTerimabarangdetil_rack As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cTerimabarangdetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_idrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_pphpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_ppnpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_disc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_pphforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_pphidrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_ppnforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_ppnidrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_totalforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_totalidrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_nonfixasset As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cButtonTerimabarangdetil_nonfixasset As New System.Windows.Forms.DataGridViewButtonColumn
        Dim cTerimabarangdetil_golfiskal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_depre_enddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cShow_id_cont As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cTerimabarangdetil_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButtonTerimabarangdetil_Detail As New System.Windows.Forms.DataGridViewButtonColumn

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "terimabarang_id"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 100
        cTerimabarang_id.Visible = False
        cTerimabarang_id.ReadOnly = False

        cTerimabarangdetil_line.Name = "terimabarangdetil_line"
        cTerimabarangdetil_line.HeaderText = "Line"
        cTerimabarangdetil_line.DataPropertyName = "terimabarangdetil_line"
        cTerimabarangdetil_line.Width = 40
        cTerimabarangdetil_line.Visible = True
        cTerimabarangdetil_line.ReadOnly = True
        cTerimabarangdetil_line.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimabarangdetil_parentline.Name = "terimabarangdetil_parentline"
        cTerimabarangdetil_parentline.HeaderText = "Line(Parent)"
        cTerimabarangdetil_parentline.DataPropertyName = "terimabarangdetil_parentline"
        cTerimabarangdetil_parentline.Width = 80
        cTerimabarangdetil_parentline.Visible = True
        cTerimabarangdetil_parentline.ReadOnly = True
        cTerimabarangdetil_parentline.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimabarangdetil_desc.Name = "terimabarangdetil_desc"
        cTerimabarangdetil_desc.HeaderText = "Description"
        cTerimabarangdetil_desc.DataPropertyName = "terimabarangdetil_desc"
        cTerimabarangdetil_desc.Width = 150
        cTerimabarangdetil_desc.Visible = True
        cTerimabarangdetil_desc.ReadOnly = False

        cTerimabarangdetil_date.Name = "terimabarangdetil_date"
        cTerimabarangdetil_date.HeaderText = "Date"
        cTerimabarangdetil_date.DataPropertyName = "terimabarangdetil_date"
        cTerimabarangdetil_date.Width = 100
        cTerimabarangdetil_date.Visible = False
        cTerimabarangdetil_date.ReadOnly = True
        cTerimabarangdetil_date.DefaultCellStyle.Format = "dd/MM/yyyy"
        cTerimabarangdetil_date.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimabarangdetil_type.Name = "terimabarangdetil_type"
        cTerimabarangdetil_type.HeaderText = "terimabarangdetil_type"
        cTerimabarangdetil_type.DataPropertyName = "terimabarangdetil_type"
        cTerimabarangdetil_type.Width = 100
        cTerimabarangdetil_type.Visible = False
        cTerimabarangdetil_type.ReadOnly = False

        cAssetcategory_id.Name = "assetcategory_id"
        cAssetcategory_id.HeaderText = "Asset Category"
        cAssetcategory_id.DataPropertyName = "assetcategory_id"
        cAssetcategory_id.Width = 200
        cAssetcategory_id.Visible = True
        cAssetcategory_id.ReadOnly = False
        cAssetcategory_id.DataSource = Me.tbl_mstKategoriAsset
        cAssetcategory_id.DisplayMember = "kategoriasset_id"
        cAssetcategory_id.ValueMember = "kategoriasset_id"
        cAssetcategory_id.DisplayStyleForCurrentCellOnly = True

        cAssettype_id.Name = "assettype_id"
        cAssettype_id.HeaderText = "Asset Type"
        cAssettype_id.DataPropertyName = "assettype_id"
        cAssettype_id.Width = 200
        cAssettype_id.Visible = True
        cAssettype_id.ReadOnly = False
        cAssettype_id.DataSource = Me.tbl_MstTipeAsset
        cAssettype_id.DisplayMember = "tipeasset_id"
        cAssettype_id.ValueMember = "tipeasset_id"
        cAssettype_id.DisplayStyleForCurrentCellOnly = True

        cTerimabarang_barcode.Name = "terimabarang_barcode"
        cTerimabarang_barcode.HeaderText = "Barcode"
        cTerimabarang_barcode.DataPropertyName = "terimabarang_barcode"
        cTerimabarang_barcode.Width = 100
        cTerimabarang_barcode.Visible = True
        cTerimabarang_barcode.ReadOnly = True
        cTerimabarang_barcode.DefaultCellStyle.BackColor = Color.Gainsboro

        cButtonTerimabarangdetil_printbarcode.Name = "print_barcode"
        cButtonTerimabarangdetil_printbarcode.HeaderText = "Print"
        cButtonTerimabarangdetil_printbarcode.Text = "Print"
        cButtonTerimabarangdetil_printbarcode.UseColumnTextForButtonValue = True
        cButtonTerimabarangdetil_printbarcode.CellTemplate.Style.BackColor = Color.LightGray
        cButtonTerimabarangdetil_printbarcode.Width = 41
        cButtonTerimabarangdetil_printbarcode.DividerWidth = 3
        cButtonTerimabarangdetil_printbarcode.Visible = True
        cButtonTerimabarangdetil_printbarcode.ReadOnly = False

        cButtonTerimabarangdetil_printbarcodekain.Name = "print_barcodekain"
        cButtonTerimabarangdetil_printbarcodekain.HeaderText = "Cloth"
        cButtonTerimabarangdetil_printbarcodekain.Text = "Print"
        cButtonTerimabarangdetil_printbarcodekain.UseColumnTextForButtonValue = True
        cButtonTerimabarangdetil_printbarcodekain.CellTemplate.Style.BackColor = Color.LightGray
        cButtonTerimabarangdetil_printbarcodekain.Width = 41
        cButtonTerimabarangdetil_printbarcodekain.DividerWidth = 3
        cButtonTerimabarangdetil_printbarcodekain.Visible = False
        cButtonTerimabarangdetil_printbarcodekain.ReadOnly = False

        cTerimabarang_parentbarcode.Name = "terimabarang_parentbarcode"
        cTerimabarang_parentbarcode.HeaderText = "Barcode(Parent)"
        cTerimabarang_parentbarcode.DataPropertyName = "terimabarang_parentbarcode"
        cTerimabarang_parentbarcode.Width = 100
        cTerimabarang_parentbarcode.Visible = True
        cTerimabarang_parentbarcode.ReadOnly = True
        cTerimabarang_parentbarcode.DefaultCellStyle.BackColor = Color.Gainsboro

        cButtonTerimabarang_parentbarcode.Name = "select_parent_barcode"
        cButtonTerimabarang_parentbarcode.HeaderText = ""
        cButtonTerimabarang_parentbarcode.Text = "..."
        cButtonTerimabarang_parentbarcode.UseColumnTextForButtonValue = True
        cButtonTerimabarang_parentbarcode.CellTemplate.Style.BackColor = Color.LightGray
        cButtonTerimabarang_parentbarcode.Width = 30
        cButtonTerimabarang_parentbarcode.DividerWidth = 3
        cButtonTerimabarang_parentbarcode.Visible = True
        cButtonTerimabarang_parentbarcode.ReadOnly = False

        cItem_id.Name = "item_id"
        cItem_id.HeaderText = "Item"
        cItem_id.DataPropertyName = "item_id"
        cItem_id.Width = 150
        cItem_id.Visible = True
        cItem_id.ReadOnly = False
        cItem_id.DataSource = Me.tbl_MstItem
        cItem_id.ValueMember = "item_id"
        cItem_id.DisplayMember = "item_name"
        cItem_id.DisplayStyleForCurrentCellOnly = True

        cItemcategory_id.Name = "itemcategory_id"
        cItemcategory_id.HeaderText = "Category"
        cItemcategory_id.DataPropertyName = "itemcategory_id"
        cItemcategory_id.Width = 130
        cItemcategory_id.Visible = True
        cItemcategory_id.ReadOnly = False
        cItemcategory_id.DataSource = Me.tbl_MstItemCategory
        cItemcategory_id.ValueMember = "category_id"
        cItemcategory_id.DisplayMember = "category_name"
        cItemcategory_id.DisplayStyleForCurrentCellOnly = True

        cItemtype_id.Name = "itemtype_id"
        cItemtype_id.HeaderText = "Type"
        cItemtype_id.DataPropertyName = "itemtype_id"
        cItemtype_id.Width = 130
        cItemtype_id.Visible = True
        cItemtype_id.ReadOnly = False

        cBrand_id.Name = "brand_id"
        cBrand_id.HeaderText = "Brand"
        cBrand_id.DataPropertyName = "brand_id"
        cBrand_id.Width = 130
        cBrand_id.Visible = True
        cBrand_id.ReadOnly = False
        cBrand_id.DataSource = Me.tbl_MstBrand
        cBrand_id.ValueMember = "merk_id"
        cBrand_id.DisplayMember = "merk_name"
        cBrand_id.DisplayStyleForCurrentCellOnly = True

        cTerimabarangdetil_serial_no.Name = "terimabarangdetil_serial_no"
        cTerimabarangdetil_serial_no.HeaderText = "Serial No."
        cTerimabarangdetil_serial_no.DataPropertyName = "terimabarangdetil_serial_no"
        cTerimabarangdetil_serial_no.Width = 100
        cTerimabarangdetil_serial_no.Visible = True
        cTerimabarangdetil_serial_no.ReadOnly = False

        cTerimabarangdetil_product_no.Name = "terimabarangdetil_product_no"
        cTerimabarangdetil_product_no.HeaderText = "Barcode Type"
        cTerimabarangdetil_product_no.DataPropertyName = "terimabarangdetil_product_no"
        cTerimabarangdetil_product_no.Width = 100
        cTerimabarangdetil_product_no.Visible = True
        cTerimabarangdetil_product_no.ReadOnly = True

        cTerimabarangdetil_model.Name = "terimabarangdetil_model"
        cTerimabarangdetil_model.HeaderText = "Model No."
        cTerimabarangdetil_model.DataPropertyName = "terimabarangdetil_model"
        cTerimabarangdetil_model.Width = 100
        cTerimabarangdetil_model.Visible = False
        cTerimabarangdetil_model.ReadOnly = False

        cMaterial_id.Name = "material_id"
        cMaterial_id.HeaderText = "Material"
        cMaterial_id.DataPropertyName = "material_id"
        cMaterial_id.Width = 100
        cMaterial_id.Visible = False
        cMaterial_id.ReadOnly = False
        cMaterial_id.DataSource = Me.tbl_MstMaterial
        cMaterial_id.ValueMember = "Material_id"
        cMaterial_id.DisplayMember = "Material_id"
        cMaterial_id.DisplayStyleForCurrentCellOnly = True

        cColour_id.Name = "colour_id"
        cColour_id.HeaderText = "Colour"
        cColour_id.DataPropertyName = "colour_id"
        cColour_id.Width = 100
        cColour_id.Visible = False
        cColour_id.ReadOnly = False
        cColour_id.DataSource = Me.tbl_MstWarna
        cColour_id.ValueMember = "warna_id"
        cColour_id.DisplayMember = "warna_id"
        cColour_id.DisplayStyleForCurrentCellOnly = True

        cSize_id.Name = "size_id"
        cSize_id.HeaderText = "Size"
        cSize_id.DataPropertyName = "size_id"
        cSize_id.Width = 100
        cSize_id.Visible = False
        cSize_id.ReadOnly = False
        cSize_id.DataSource = Me.tbl_MstUkuran
        cSize_id.ValueMember = "ukuran_id"
        cSize_id.DisplayMember = "ukuran_id"
        cSize_id.DisplayStyleForCurrentCellOnly = True

        cSex_id.Name = "sex_id"
        cSex_id.HeaderText = "Sex"
        cSex_id.DataPropertyName = "sex_id"
        cSex_id.Width = 100
        cSex_id.Visible = False
        cSex_id.ReadOnly = False
        cSex_id.DataSource = Me.tbl_Mstsex
        cSex_id.ValueMember = "Pilihan"
        cSex_id.DisplayMember = "Pilihan"
        cSex_id.DisplayStyleForCurrentCellOnly = True

        cRoom_id.Name = "room_id"
        cRoom_id.HeaderText = "Room"
        cRoom_id.DataPropertyName = "room_id"
        cRoom_id.Width = 100
        cRoom_id.Visible = False
        cRoom_id.ReadOnly = False
        cRoom_id.DataSource = Me.tbl_MstAssetruang
        cRoom_id.ValueMember = "ruang_id"
        cRoom_id.DisplayMember = "keterangan"
        cRoom_id.DisplayStyleForCurrentCellOnly = True

        cTerimabarangdetil_rack.Name = "terimabarangdetil_rack"
        cTerimabarangdetil_rack.HeaderText = "Rack"
        cTerimabarangdetil_rack.DataPropertyName = "terimabarangdetil_rack"
        cTerimabarangdetil_rack.Width = 100
        cTerimabarangdetil_rack.Visible = False
        cTerimabarangdetil_rack.ReadOnly = False

        cTerimabarangdetil_qty.Name = "terimabarangdetil_qty"
        cTerimabarangdetil_qty.HeaderText = "Qty"
        cTerimabarangdetil_qty.DataPropertyName = "terimabarangdetil_qty"
        cTerimabarangdetil_qty.Width = 80
        cTerimabarangdetil_qty.Visible = True
        cTerimabarangdetil_qty.ReadOnly = True
        cTerimabarangdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "Unit"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 60
        cUnit_id.Visible = True
        cUnit_id.ReadOnly = True
        cUnit_id.DataSource = Me.tbl_MstUnit
        cUnit_id.ValueMember = "unit_id"
        cUnit_id.DisplayMember = "unit_shortname"
        cUnit_id.DisplayStyleForCurrentCellOnly = True
        cUnit_id.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 60
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True
        cCurrency_id.DataSource = Me.tbl_MstCurrencyDetil
        cCurrency_id.ValueMember = "Currency_id"
        cCurrency_id.DisplayMember = "Currency_shortname"
        cCurrency_id.DisplayStyleForCurrentCellOnly = True
        cCurrency_id.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        cTerimabarangdetil_foreign.Name = "terimabarangdetil_foreign"
        cTerimabarangdetil_foreign.HeaderText = "Amount"
        cTerimabarangdetil_foreign.DataPropertyName = "terimabarangdetil_foreign"
        cTerimabarangdetil_foreign.Width = 100
        cTerimabarangdetil_foreign.Visible = True
        cTerimabarangdetil_foreign.ReadOnly = False
        cTerimabarangdetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_foreignrate.Name = "terimabarangdetil_foreignrate"
        cTerimabarangdetil_foreignrate.HeaderText = "Rate"
        cTerimabarangdetil_foreignrate.DataPropertyName = "terimabarangdetil_foreignrate"
        cTerimabarangdetil_foreignrate.Width = 100
        cTerimabarangdetil_foreignrate.Visible = True
        cTerimabarangdetil_foreignrate.ReadOnly = True
        cTerimabarangdetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        cTerimabarangdetil_idrreal.Name = "terimabarangdetil_idrreal"
        cTerimabarangdetil_idrreal.HeaderText = "Amount (IDR)"
        cTerimabarangdetil_idrreal.DataPropertyName = "terimabarangdetil_idrreal"
        cTerimabarangdetil_idrreal.Width = 100
        cTerimabarangdetil_idrreal.Visible = True
        cTerimabarangdetil_idrreal.ReadOnly = False
        cTerimabarangdetil_idrreal.DefaultCellStyle.Format = "#,##0"
        cTerimabarangdetil_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_pphpercent.Name = "terimabarangdetil_pphpercent"
        cTerimabarangdetil_pphpercent.HeaderText = "Pph %"
        cTerimabarangdetil_pphpercent.DataPropertyName = "terimabarangdetil_pphpercent"
        cTerimabarangdetil_pphpercent.Width = 100
        cTerimabarangdetil_pphpercent.Visible = True
        cTerimabarangdetil_pphpercent.ReadOnly = False
        cTerimabarangdetil_pphpercent.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_pphpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_ppnpercent.Name = "terimabarangdetil_ppnpercent"
        cTerimabarangdetil_ppnpercent.HeaderText = "PPN %"
        cTerimabarangdetil_ppnpercent.DataPropertyName = "terimabarangdetil_ppnpercent"
        cTerimabarangdetil_ppnpercent.Width = 100
        cTerimabarangdetil_ppnpercent.Visible = True
        cTerimabarangdetil_ppnpercent.ReadOnly = False
        cTerimabarangdetil_ppnpercent.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_ppnpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        cTerimabarangdetil_disc.Name = "terimabarangdetil_disc"
        cTerimabarangdetil_disc.HeaderText = "Disc"
        cTerimabarangdetil_disc.DataPropertyName = "terimabarangdetil_disc"
        cTerimabarangdetil_disc.Width = 100
        cTerimabarangdetil_disc.Visible = True
        cTerimabarangdetil_disc.ReadOnly = False
        cTerimabarangdetil_disc.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_disc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_pphforeign.Name = "terimabarangdetil_pphforeign"
        cTerimabarangdetil_pphforeign.HeaderText = "Pph Amount"
        cTerimabarangdetil_pphforeign.DataPropertyName = "terimabarangdetil_pphforeign"
        cTerimabarangdetil_pphforeign.Width = 100
        cTerimabarangdetil_pphforeign.Visible = False
        cTerimabarangdetil_pphforeign.ReadOnly = True
        cTerimabarangdetil_pphforeign.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_pphforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_pphidrreal.Name = "terimabarangdetil_pphidrreal"
        cTerimabarangdetil_pphidrreal.HeaderText = "Pph Amount (IDR)"
        cTerimabarangdetil_pphidrreal.DataPropertyName = "terimabarangdetil_pphidrreal"
        cTerimabarangdetil_pphidrreal.Width = 130
        cTerimabarangdetil_pphidrreal.Visible = False
        cTerimabarangdetil_pphidrreal.ReadOnly = True
        cTerimabarangdetil_pphidrreal.DefaultCellStyle.Format = "#,##0"
        cTerimabarangdetil_pphidrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_ppnforeign.Name = "terimabarangdetil_ppnforeign"
        cTerimabarangdetil_ppnforeign.HeaderText = "PPN Amount"
        cTerimabarangdetil_ppnforeign.DataPropertyName = "terimabarangdetil_ppnforeign"
        cTerimabarangdetil_ppnforeign.Width = 100
        cTerimabarangdetil_ppnforeign.Visible = False
        cTerimabarangdetil_ppnforeign.ReadOnly = False
        cTerimabarangdetil_ppnforeign.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_ppnforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_ppnidrreal.Name = "terimabarangdetil_ppnidrreal"
        cTerimabarangdetil_ppnidrreal.HeaderText = "PPN Amount(IDR)"
        cTerimabarangdetil_ppnidrreal.DataPropertyName = "terimabarangdetil_ppnidrreal"
        cTerimabarangdetil_ppnidrreal.Width = 130
        cTerimabarangdetil_ppnidrreal.Visible = False
        cTerimabarangdetil_ppnidrreal.ReadOnly = False
        cTerimabarangdetil_ppnidrreal.DefaultCellStyle.Format = "#,##0"
        cTerimabarangdetil_ppnidrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_totalforeign.Name = "terimabarangdetil_totalforeign"
        cTerimabarangdetil_totalforeign.HeaderText = "Total Amount"
        cTerimabarangdetil_totalforeign.DataPropertyName = "terimabarangdetil_totalforeign"
        cTerimabarangdetil_totalforeign.Width = 100
        cTerimabarangdetil_totalforeign.Visible = True
        cTerimabarangdetil_totalforeign.ReadOnly = True
        cTerimabarangdetil_totalforeign.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_totalforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_totalidrreal.Name = "terimabarangdetil_totalidrreal"
        cTerimabarangdetil_totalidrreal.HeaderText = "Total Amount(IDR)"
        cTerimabarangdetil_totalidrreal.DataPropertyName = "terimabarangdetil_totalidrreal"
        cTerimabarangdetil_totalidrreal.Width = 130
        cTerimabarangdetil_totalidrreal.Visible = True
        cTerimabarangdetil_totalidrreal.ReadOnly = True
        cTerimabarangdetil_totalidrreal.DefaultCellStyle.Format = "#,##0"
        cTerimabarangdetil_totalidrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_nonfixasset.Name = "terimabarangdetil_nonfixasset"
        cTerimabarangdetil_nonfixasset.HeaderText = "Not Printed"
        cTerimabarangdetil_nonfixasset.DataPropertyName = "terimabarangdetil_nonfixasset"
        cTerimabarangdetil_nonfixasset.Width = 100
        cTerimabarangdetil_nonfixasset.Visible = True
        cTerimabarangdetil_nonfixasset.ReadOnly = True

        cButtonTerimabarangdetil_nonfixasset.Name = "select_nonfix"
        cButtonTerimabarangdetil_nonfixasset.HeaderText = ""
        cButtonTerimabarangdetil_nonfixasset.Text = "..."
        cButtonTerimabarangdetil_nonfixasset.UseColumnTextForButtonValue = True
        cButtonTerimabarangdetil_nonfixasset.CellTemplate.Style.BackColor = Color.LightGray
        cButtonTerimabarangdetil_nonfixasset.Width = 30
        cButtonTerimabarangdetil_nonfixasset.DividerWidth = 3
        cButtonTerimabarangdetil_nonfixasset.Visible = True
        cButtonTerimabarangdetil_nonfixasset.ReadOnly = False

        cTerimabarangdetil_golfiskal.Name = "terimabarangdetil_golfiskal"
        cTerimabarangdetil_golfiskal.HeaderText = "Fiscal Asset"
        cTerimabarangdetil_golfiskal.DataPropertyName = "terimabarangdetil_golfiskal"
        cTerimabarangdetil_golfiskal.Width = 100
        cTerimabarangdetil_golfiskal.Visible = False
        cTerimabarangdetil_golfiskal.ReadOnly = False

        cTerimabarangdetil_depre_enddt.Name = "terimabarangdetil_depre_enddt"
        cTerimabarangdetil_depre_enddt.HeaderText = "terimabarangdetil_depre_enddt"
        cTerimabarangdetil_depre_enddt.DataPropertyName = "terimabarangdetil_depre_enddt"
        cTerimabarangdetil_depre_enddt.Width = 100
        cTerimabarangdetil_depre_enddt.Visible = False
        cTerimabarangdetil_depre_enddt.ReadOnly = False

        cEmployee_id.Name = "employee_id"
        cEmployee_id.HeaderText = "employee_id"
        cEmployee_id.DataPropertyName = "employee_id"
        cEmployee_id.Width = 100
        cEmployee_id.Visible = False
        cEmployee_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cShow_id.Name = "show_id"
        cShow_id.HeaderText = "Show ID"
        cShow_id.DataPropertyName = "show_id"
        cShow_id.Width = 150
        cShow_id.Visible = False
        cShow_id.ReadOnly = False
        cShow_id.DataSource = Me.tbl_MstShow
        cShow_id.ValueMember = "show_id"
        cShow_id.DisplayMember = "show_title"

        cShow_id_cont.Name = "show_id_cont"
        cShow_id_cont.HeaderText = "Show ID Cont"
        cShow_id_cont.DataPropertyName = "show_id_cont"
        cShow_id_cont.Width = 150
        cShow_id_cont.Visible = False
        cShow_id_cont.ReadOnly = False
        cShow_id_cont.DataSource = Me.tbl_MstShowcont
        cShow_id_cont.ValueMember = "show_id"
        cShow_id_cont.DisplayMember = "show_title"

        cTerimabarangdetil_eps.Name = "terimabarangdetil_eps"
        cTerimabarangdetil_eps.HeaderText = "Eps"
        cTerimabarangdetil_eps.DataPropertyName = "terimabarangdetil_eps"
        cTerimabarangdetil_eps.Width = 50
        cTerimabarangdetil_eps.Visible = True
        cTerimabarangdetil_eps.ReadOnly = False

        cWriteoff_id.Name = "writeoff_id"
        cWriteoff_id.HeaderText = "Writeoff ID"
        cWriteoff_id.DataPropertyName = "writeoff_id"
        cWriteoff_id.Width = 100
        cWriteoff_id.Visible = False
        cWriteoff_id.ReadOnly = True
        cWriteoff_id.DefaultCellStyle.BackColor = Color.Gainsboro

        cWriteoff_dt.Name = "writeoff_dt"
        cWriteoff_dt.HeaderText = "Writeoff Date"
        cWriteoff_dt.DataPropertyName = "writeoff_dt"
        cWriteoff_dt.Width = 100
        cWriteoff_dt.Visible = False
        cWriteoff_dt.ReadOnly = True
        cWriteoff_dt.DefaultCellStyle.BackColor = Color.Gainsboro

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order_id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = False

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "orderdetil_line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.Visible = False
        cOrderdetil_line.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "budget_id"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = False

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "budgetdetil_id"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 100
        cBudgetdetil_id.Visible = False
        cBudgetdetil_id.ReadOnly = False

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "acc_id"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 100
        cAcc_id.Visible = False
        cAcc_id.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cCreate_by.Name = "create_by"
        cCreate_by.HeaderText = "create_by"
        cCreate_by.DataPropertyName = "create_by"
        cCreate_by.Width = 100
        cCreate_by.Visible = False
        cCreate_by.ReadOnly = False

        cCreate_dt.Name = "create_dt"
        cCreate_dt.HeaderText = "create_dt"
        cCreate_dt.DataPropertyName = "create_dt"
        cCreate_dt.Width = 100
        cCreate_dt.Visible = False
        cCreate_dt.ReadOnly = False

        cModified_by.Name = "modified_by"
        cModified_by.HeaderText = "modified_by"
        cModified_by.DataPropertyName = "modified_by"
        cModified_by.Width = 100
        cModified_by.Visible = False
        cModified_by.ReadOnly = False

        cModified_dt.Name = "modified_dt"
        cModified_dt.HeaderText = "modified_dt"
        cModified_dt.DataPropertyName = "modified_dt"
        cModified_dt.Width = 100
        cModified_dt.Visible = False
        cModified_dt.ReadOnly = False

        cButtonTerimabarangdetil_Detail.Name = "select_detail"
        cButtonTerimabarangdetil_Detail.HeaderText = ""
        cButtonTerimabarangdetil_Detail.Text = "..."
        cButtonTerimabarangdetil_Detail.UseColumnTextForButtonValue = True
        cButtonTerimabarangdetil_Detail.CellTemplate.Style.BackColor = Color.LightGray
        cButtonTerimabarangdetil_Detail.Width = 30
        cButtonTerimabarangdetil_Detail.DividerWidth = 3
        cButtonTerimabarangdetil_Detail.Visible = True
        cButtonTerimabarangdetil_Detail.ReadOnly = False
        cButtonTerimabarangdetil_Detail.Frozen = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cButtonTerimabarangdetil_Detail, cTerimabarang_id, cTerimabarangdetil_line, cTerimabarang_barcode, cButtonTerimabarangdetil_printbarcode, _
        cButtonTerimabarangdetil_printbarcodekain, cTerimabarangdetil_desc, _
         cTerimabarangdetil_type, cTerimabarangdetil_parentline, cTerimabarang_parentbarcode, _
        cTerimabarangdetil_nonfixasset, cTerimabarangdetil_date, cAssettype_id, cAssetcategory_id, cItem_id, cItemcategory_id, cItemtype_id, cBrand_id, _
        cTerimabarangdetil_serial_no, cTerimabarangdetil_product_no, cTerimabarangdetil_model, _
        cMaterial_id, cColour_id, cSize_id, cSex_id, cRoom_id, cTerimabarangdetil_rack, _
        cShow_id, cShow_id_cont, cTerimabarangdetil_eps, _
        cTerimabarangdetil_qty, cUnit_id, cCurrency_id, cTerimabarangdetil_foreign, _
        cTerimabarangdetil_foreignrate, cTerimabarangdetil_idrreal, cTerimabarangdetil_pphpercent, _
        cTerimabarangdetil_ppnpercent, cTerimabarangdetil_disc, cTerimabarangdetil_pphforeign, _
        cTerimabarangdetil_pphidrreal, cTerimabarangdetil_ppnforeign, cTerimabarangdetil_ppnidrreal, _
        cTerimabarangdetil_totalforeign, cTerimabarangdetil_totalidrreal, _
 _
        cTerimabarangdetil_golfiskal, cTerimabarangdetil_depre_enddt, cEmployee_id, cStrukturunit_id, _
        cWriteoff_id, cWriteoff_dt, cOrder_id, _
        cOrderdetil_line, cBudget_id, cBudgetdetil_id, cAcc_id, cChannel_id, cCreate_by, cCreate_dt, _
        cModified_by, cModified_dt})

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = True
        objDgv.AutoGenerateColumns = False
    End Function

    Private Function FormatDgvTrnJurnaldetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnJurnaldetil
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_dk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cAcc_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cJurnaldetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cRef_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_budgetline As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRegion_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBranch_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "jurnal_id"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = False
        cJurnal_id.ReadOnly = False

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "Line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 35
        cJurnaldetil_line.Visible = True
        cJurnaldetil_line.ReadOnly = True
        cJurnaldetil_line.DefaultCellStyle.BackColor = Color.LightYellow

        cJurnaldetil_dk.Name = "jurnaldetil_dk"
        cJurnaldetil_dk.HeaderText = "jurnaldetil_dk"
        cJurnaldetil_dk.DataPropertyName = "jurnaldetil_dk"
        cJurnaldetil_dk.Width = 100
        cJurnaldetil_dk.Visible = False
        cJurnaldetil_dk.ReadOnly = False

        cJurnaldetil_descr.Name = "jurnaldetil_descr"
        cJurnaldetil_descr.HeaderText = "Description"
        cJurnaldetil_descr.DataPropertyName = "jurnaldetil_descr"
        cJurnaldetil_descr.Width = 200
        cJurnaldetil_descr.Visible = True
        cJurnaldetil_descr.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Vendor ID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 85
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = True
        cRekanan_id.DefaultCellStyle.BackColor = Color.LightYellow

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Vendor Name"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 150
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True
        cRekanan_name.DefaultCellStyle.BackColor = Color.LightYellow

        cRekanan_button.Name = "select_rekanan"
        cRekanan_button.HeaderText = ""
        cRekanan_button.Text = "..."
        cRekanan_button.UseColumnTextForButtonValue = True
        cRekanan_button.CellTemplate.Style.BackColor = Color.LightGray
        cRekanan_button.Width = 30
        cRekanan_button.DividerWidth = 3
        cRekanan_button.Visible = True
        cRekanan_button.ReadOnly = False

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "Account"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 200
        cAcc_id.Visible = True
        cAcc_id.ReadOnly = True
        cAcc_id.DataSource = Me.tbl_MstAccGrid
        cAcc_id.DisplayMember = "acc_name"
        cAcc_id.ValueMember = "acc_id"
        cAcc_id.DisplayStyleForCurrentCellOnly = True

        cAcc_no.Name = "acc_id"
        cAcc_no.HeaderText = "COA"
        cAcc_no.DataPropertyName = "acc_id"
        cAcc_no.Width = 60
        cAcc_no.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAcc_no.Visible = True
        cAcc_no.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 55
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True
        cCurrency_id.DefaultCellStyle.BackColor = Color.LightYellow
        cCurrency_id.DataSource = Me.tbl_MstCurrencyGrid
        cCurrency_id.DisplayMember = "currency_shortname"
        cCurrency_id.ValueMember = "currency_id"
        cCurrency_id.DisplayStyleForCurrentCellOnly = True

        cJurnaldetil_foreign.Name = "jurnaldetil_foreign"
        cJurnaldetil_foreign.HeaderText = "Amount"
        cJurnaldetil_foreign.DataPropertyName = "jurnaldetil_foreign"
        cJurnaldetil_foreign.Width = 125
        cJurnaldetil_foreign.Visible = True
        cJurnaldetil_foreign.ReadOnly = False
        cJurnaldetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        cJurnaldetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnaldetil_foreignrate.Name = "jurnaldetil_foreignrate"
        cJurnaldetil_foreignrate.HeaderText = "Rate"
        cJurnaldetil_foreignrate.DataPropertyName = "jurnaldetil_foreignrate"
        cJurnaldetil_foreignrate.Width = 70
        cJurnaldetil_foreignrate.Visible = True
        cJurnaldetil_foreignrate.ReadOnly = False
        cJurnaldetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cJurnaldetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnaldetil_idr.Name = "jurnaldetil_idr"
        cJurnaldetil_idr.HeaderText = "Amount (IDR)"
        cJurnaldetil_idr.DataPropertyName = "jurnaldetil_idr"
        cJurnaldetil_idr.Width = 125
        cJurnaldetil_idr.Visible = True
        cJurnaldetil_idr.ReadOnly = True
        cJurnaldetil_idr.DefaultCellStyle.Format = "#,##0"
        cJurnaldetil_idr.DefaultCellStyle.BackColor = Color.LightYellow
        cJurnaldetil_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Department"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 150
        cStrukturunit_id.Visible = True
        cStrukturunit_id.ReadOnly = True
        cStrukturunit_id.DataSource = Me.tbl_MstStrukturunitGrid
        cStrukturunit_id.DisplayMember = "strukturunit_name"
        cStrukturunit_id.ValueMember = "strukturunit_id"
        cStrukturunit_id.DisplayStyleForCurrentCellOnly = True
        cStrukturunit_id.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_id.Name = "ref_id"
        cRef_id.HeaderText = "Ref ID"
        cRef_id.DataPropertyName = "ref_id"
        cRef_id.Width = 100
        cRef_id.Visible = True
        cRef_id.ReadOnly = True
        cRef_id.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_line.Name = "ref_line"
        cRef_line.HeaderText = "Ref.Ln"
        cRef_line.DataPropertyName = "ref_line"
        cRef_line.Width = 50
        cRef_line.Visible = True
        cRef_line.ReadOnly = True
        cRef_line.DefaultCellStyle.BackColor = Color.LightYellow

        cRef_budgetline.Name = "ref_budgetline"
        cRef_budgetline.HeaderText = "Ref.BudgetLn"
        cRef_budgetline.DataPropertyName = "ref_budgetline"
        cRef_budgetline.Width = 80
        cRef_budgetline.Visible = True
        cRef_budgetline.ReadOnly = True
        cRef_budgetline.DefaultCellStyle.BackColor = Color.LightYellow

        cRegion_id.Name = "region_id"
        cRegion_id.HeaderText = "region_id"
        cRegion_id.DataPropertyName = "region_id"
        cRegion_id.Width = 100
        cRegion_id.Visible = False
        cRegion_id.ReadOnly = False

        cBranch_id.Name = "branch_id"
        cBranch_id.HeaderText = "branch_id"
        cBranch_id.DataPropertyName = "branch_id"
        cBranch_id.Width = 100
        cBranch_id.Visible = False
        cBranch_id.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Budget ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 85
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = True
        cBudget_id.DefaultCellStyle.BackColor = Color.LightYellow

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 150
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True
        cBudget_name.DefaultCellStyle.BackColor = Color.LightYellow

        cBudget_button.Name = "select_budget"
        cBudget_button.HeaderText = ""
        cBudget_button.Text = "..."
        cBudget_button.UseColumnTextForButtonValue = True
        cBudget_button.CellTemplate.Style.BackColor = Color.LightGray
        cBudget_button.Width = 30
        cBudget_button.DividerWidth = 3
        cBudget_button.Visible = True
        cBudget_button.ReadOnly = False

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "Budget Detil ID"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 110
        cBudgetdetil_id.Visible = True
        cBudgetdetil_id.ReadOnly = True
        cBudgetdetil_id.DefaultCellStyle.BackColor = Color.LightYellow

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budget Detil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Width = 150
        cBudgetdetil_name.Visible = True
        cBudgetdetil_name.ReadOnly = True
        cBudgetdetil_name.DefaultCellStyle.BackColor = Color.LightYellow

        cBudgetdetil_button.Name = "select_budget_detil"
        cBudgetdetil_button.HeaderText = ""
        cBudgetdetil_button.Text = "..."
        cBudgetdetil_button.UseColumnTextForButtonValue = True
        cBudgetdetil_button.CellTemplate.Style.BackColor = Color.LightGray
        cBudgetdetil_button.Width = 30
        cBudgetdetil_button.DividerWidth = 3
        cBudgetdetil_button.Visible = True
        cBudgetdetil_button.ReadOnly = False


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnaldetil_line, cAcc_id, cAcc_no, cJurnaldetil_descr, _
         cCurrency_id, cJurnaldetil_foreign, cJurnaldetil_foreignrate, cJurnaldetil_idr, _
         cRekanan_id, cRekanan_name, cRekanan_button, cJurnal_id, cJurnaldetil_dk, _
         cChannel_id, _
          cRef_id, cRef_line, cRef_budgetline, cRegion_id, cBranch_id, _
         cBudget_id, cBudget_name, cBudget_button, _
         cBudgetdetil_id, cBudgetdetil_name, cBudgetdetil_button, cStrukturunit_id})

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = True
        objDgv.ReadOnly = False
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
        objDgv.ReadOnly = True
    End Function

    Private Function FormatDgvTrnJurnalresponse(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBook_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnal_id.Name = "ref"
        cJurnal_id.HeaderText = "Ref"
        cJurnal_id.DataPropertyName = "ref"
        cJurnal_id.Width = 100
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = True

        cJurnal_line.Name = "line"
        cJurnal_line.HeaderText = "Line"
        cJurnal_line.DataPropertyName = "line"
        cJurnal_line.Width = 50
        cJurnal_line.Visible = True
        cJurnal_line.ReadOnly = True

        cJurnal_descr.Name = "descr"
        cJurnal_descr.HeaderText = "Descr"
        cJurnal_descr.DataPropertyName = "descr"
        cJurnal_descr.Width = 100
        cJurnal_descr.MaxInputLength = 255
        cJurnal_descr.Visible = True
        cJurnal_descr.ReadOnly = True

        cCurrency_name.Name = "currency_name"
        cCurrency_name.HeaderText = "Curr."
        cCurrency_name.DataPropertyName = "currency_name"
        cCurrency_name.Width = 75
        cCurrency_name.MaxInputLength = 255
        cCurrency_name.Visible = True
        cCurrency_name.ReadOnly = True

        cJurnal_foreignrate.Name = "jurnaldetil_foreignrate"
        cJurnal_foreignrate.HeaderText = "Rate"
        cJurnal_foreignrate.DataPropertyName = "jurnaldetil_foreignrate"
        cJurnal_foreignrate.Width = 75
        cJurnal_foreignrate.Visible = True
        cJurnal_foreignrate.ReadOnly = True
        cJurnal_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cJurnal_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnal_idr.Name = "jurnaldetil_idr"
        cJurnal_idr.HeaderText = "Amount"
        cJurnal_idr.DataPropertyName = "jurnaldetil_idr"
        cJurnal_idr.Width = 100
        cJurnal_idr.Visible = True
        cJurnal_idr.ReadOnly = True
        cJurnal_idr.DefaultCellStyle.Format = "#,##0"
        cJurnal_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cJurnal_foreign.Name = "jurnaldetil_foreign"
        cJurnal_foreign.HeaderText = "Foreign"
        cJurnal_foreign.DataPropertyName = "jurnaldetil_foreign"
        cJurnal_foreign.Width = 100
        cJurnal_foreign.Visible = True
        cJurnal_foreign.ReadOnly = True
        cJurnal_foreign.DefaultCellStyle.Format = "#,##0"
        cJurnal_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        cStrukturunit_name.Name = "strukturunit_name"
        cStrukturunit_name.HeaderText = "Department"
        cStrukturunit_name.DataPropertyName = "strukturunit_name"
        cStrukturunit_name.Width = 150
        cStrukturunit_name.Visible = False
        cStrukturunit_name.ReadOnly = True

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Partner"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 200
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Company"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = True

        cBook_date.Name = "book_dt"
        cBook_date.HeaderText = "Book Date"
        cBook_date.DataPropertyName = "book_dt"
        cBook_date.Width = 100
        cBook_date.Visible = False
        cBook_date.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnal_id, cJurnal_line, cBook_date, cJurnal_descr, cCurrency_name, cJurnal_foreignrate, cJurnal_idr, _
        cJurnal_foreign, cRekanan_name, cStrukturunit_name, cChannel_id})


        ' DgvTrnJurnal Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
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
        Me.DgvTrnPenerimaanbarang.Dock = DockStyle.Fill
        Me.obj_photo.Dock = DockStyle.Fill
        Me.VideoCapture.Dock = DockStyle.Fill

        Select Case Me._MODULE_TYPE
            Case ModuleType.PURCHASE
                Me.lbl_Order_id.Text = "Order No."
                Me.btn_order.Visible = True
                Me.btn_order.Text = "PO"
                Me.Btn_Add.Text = "[+] Item Order"
                Me.obj_Rekanan_id.Enabled = False
                Me.Btn_Add.Visible = True
                Me.obj_Assettype_id.Enabled = True
                Me.obj_Terimabarangdetil_qty.ReadOnly = False
            Case ModuleType.MANUAL
                Me.lbl_Order_id.Text = "Order No."
                Me.btn_order.Visible = False
                Me.obj_Rekanan_id.Enabled = True
                Me.Btn_Add.Text = "[+] Item"
                Me.Btn_Add.Visible = True
                Me.obj_Assettype_id.Enabled = True
                Me.obj_Terimabarangdetil_qty.ReadOnly = False
            Case ModuleType.LISTPV
                Me.lbl_Order_id.Text = "PV No."
                Me.btn_order.Text = "PV"
                Me.btn_order.Visible = True
                Me.Btn_Add.Visible = True
                Me.obj_Assettype_id.Enabled = True
                Me.obj_Terimabarangdetil_qty.ReadOnly = False
            Case ModuleType.LISTGQ
                Me.lbl_Order_id.Text = "GQ No."
                Me.btn_order.Text = "GQ"
                Me.Btn_Add.Text = "[+] Item Request"
                Me.btn_order.Visible = True
                Me.Btn_Add.Visible = True
                Me.obj_Assettype_id.Enabled = False
                Me.obj_Terimabarangdetil_qty.ReadOnly = True
        End Select

        If Me._USERTYPE = "acc" Then
            Me.btnCapture.Visible = False
        End If

        Me.FormatDgvTrnPenerimaanbarang(Me.DgvTrnPenerimaanbarang)
        Me.DgvTrnPenerimaanbarang.DataSource = Me.tbl_TrnPenerimaanbarang
        Me.DgvTrnPenerimaanbarang.Sort(Me.DgvTrnPenerimaanbarang.Columns("terimabarang_id"), ListSortDirection.Descending)

        'Me.FormatDgvTrnPenerimaanbarangdetil(Me.DgvTrnPenerimaanbarangdetil)
        Me.FormatDgvTrnJurnalreference(Me.DgvTrnJurnalreference)
        Me.FormatDgvTrnJurnalresponse(Me.DgvTrnJurnalresponse)

        'suroso
        FillDSTreelist_cbodevexpress()
    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Terimabarang_id.DataBindings.Clear()
        Me.obj_Terimabarang_date.DataBindings.Clear()
        Me.obj_Terimabarang_type.DataBindings.Clear()
        Me.obj_Order_id.DataBindings.Clear()
        Me.obj_Budget_id.DataBindings.Clear()
        Me.obj_Rekanan_id.DataBindings.Clear()
        Me.obj_Employee_id_owner.DataBindings.Clear()
        Me.obj_Strukturunit_id.DataBindings.Clear()
        Me.obj_Terimabarang_qtyitem.DataBindings.Clear()
        Me.obj_Terimabarang_qtyrealization.DataBindings.Clear()
        Me.obj_Order_qty.DataBindings.Clear()
        Me.obj_Terimabarang_status.DataBindings.Clear()
        Me.obj_Terimabarang_statusrealization.DataBindings.Clear()
        Me.obj_Terimabarang_location.DataBindings.Clear()
        Me.obj_Terimabarang_notes.DataBindings.Clear()
        Me.obj_Terimabarang_nosuratjalan.DataBindings.Clear()
        Me.obj_terimabarang_tglsuratjalan.DataBindings.Clear()
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Terimabarang_isdisabled.DataBindings.Clear()
        Me.obj_Terimabarang_createby.DataBindings.Clear()
        Me.obj_Terimabarang_createdt.DataBindings.Clear()
        Me.obj_Terimabarang_modifiedby.DataBindings.Clear()
        Me.obj_Terimabarang_modifieddt.DataBindings.Clear()
        Me.obj_Terimabarang_appuser.DataBindings.Clear()
        Me.obj_Terimabarang_appuser_by.DataBindings.Clear()
        Me.obj_Terimabarang_appuser_dt.DataBindings.Clear()
        Me.obj_Terimabarang_appspv.DataBindings.Clear()
        Me.obj_Terimabarang_appspv_by.DataBindings.Clear()
        Me.obj_Terimabarang_appspv_dt.DataBindings.Clear()
        Me.obj_Terimabarang_appacc.DataBindings.Clear()
        Me.obj_Terimabarang_appacc_by.DataBindings.Clear()
        Me.obj_Terimabarang_appacc_dt.DataBindings.Clear()
        Me.obj_Terimabarang_foreign.DataBindings.Clear()
        Me.obj_Currency_id.DataBindings.Clear()
        Me.obj_Terimabarang_foreignrate.DataBindings.Clear()
        Me.obj_Terimabarang_idrreal.DataBindings.Clear()
        Me.obj_Terimabarang_pph.DataBindings.Clear()
        Me.obj_Terimabarang_ppn.DataBindings.Clear()
        Me.obj_Terimabarang_disc.DataBindings.Clear()
        Me.obj_Terimabarang_cetakbpb.DataBindings.Clear()
        Me.obj_strukturunit_name.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStopDetil() As Boolean
        Me.obj_asset_terimabarangdetil_id.DataBindings.Clear()
        Me.obj_Terimabarangdetil_line.DataBindings.Clear()
        Me.obj_Terimabarangdetil_parentline.DataBindings.Clear()
        Me.obj_Terimabarangdetil_desc.DataBindings.Clear()
        'Me.obj_terimabarangdetil_date.DataBindings.Clear()
        Me.obj_Assetcategory_id.DataBindings.Clear()
        Me.obj_Assettype_id.DataBindings.Clear()
        Me.obj_Terimabarang_barcode.DataBindings.Clear()
        Me.obj_Terimabarang_parentbarcode.DataBindings.Clear()
        Me.obj_Item_id.DataBindings.Clear()
        Me.obj_Itemcategory_id.DataBindings.Clear()
        Me.obj_Itemtype_id.DataBindings.Clear()
        Me.obj_Brand_id.DataBindings.Clear()
        Me.obj_Terimabarangdetil_serial_no.DataBindings.Clear()
        Me.obj_Terimabarangdetil_product_no.DataBindings.Clear()
        Me.obj_Terimabarangdetil_model.DataBindings.Clear()
        Me.obj_Material_id.DataBindings.Clear()
        Me.obj_Colour_id.DataBindings.Clear()
        Me.obj_Size_id.DataBindings.Clear()
        Me.obj_Sex_id.DataBindings.Clear()
        Me.obj_Room_id.DataBindings.Clear()
        Me.obj_Terimabarangdetil_rack.DataBindings.Clear()
        Me.obj_Terimabarangdetil_qty.DataBindings.Clear()
        Me.obj_Terimabarangdetil_qtydetail.DataBindings.Clear()
        Me.obj_Terimabarangdetil_qtytotal.DataBindings.Clear()
        Me.obj_Unit_id.DataBindings.Clear()
        Me.obj_Currency_iddetil.DataBindings.Clear()
        Me.obj_Terimabarangdetil_foreign.DataBindings.Clear()
        Me.obj_Terimabarangdetil_foreignrate.DataBindings.Clear()
        Me.obj_Terimabarangdetil_idrreal.DataBindings.Clear()
        Me.obj_Terimabarangdetil_pphpercent.DataBindings.Clear()
        Me.obj_Terimabarangdetil_ppnpercent.DataBindings.Clear()
        Me.obj_Terimabarangdetil_disc.DataBindings.Clear()
        Me.obj_Terimabarangdetil_pphforeign.DataBindings.Clear()
        Me.obj_Terimabarangdetil_pphidrreal.DataBindings.Clear()
        Me.obj_Terimabarangdetil_ppnforeign.DataBindings.Clear()
        Me.obj_Terimabarangdetil_ppnidrreal.DataBindings.Clear()
        Me.obj_Terimabarangdetil_totalforeign.DataBindings.Clear()
        Me.obj_Terimabarangdetil_totalidrreal.DataBindings.Clear()
        Me.obj_Terimabarangdetil_nonfixasset.DataBindings.Clear()

        Me.obj_Terimabarangdetil_golfiskal.DataBindings.Clear()

        Me.obj_Terimabarangdetil_depre_enddt.DataBindings.Clear()
        Me.obj_Show_id.DataBindings.Clear()
        Me.obj_Show_id_cont.DataBindings.Clear()
        Me.obj_Terimabarangdetil_eps.DataBindings.Clear()
        Me.obj_Orderdetil_id.DataBindings.Clear()
        Me.obj_Orderdetil_line.DataBindings.Clear()
        Me.obj_Acc_id.DataBindings.Clear()
        Me.obj_budget_name.DataBindings.Clear()
        Me.obj_budgetdetil_name.DataBindings.Clear()

        RaiseEvent FormBindingStopDetil()

        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Terimabarang_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_id"))
        Me.obj_Terimabarang_date.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_date"))
        Me.obj_Terimabarang_type.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_type"))
        Me.obj_Order_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "order_id"))
        Me.obj_Budget_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarang_Temp, "budget_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Rekanan_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarang_Temp, "rekanan_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Employee_id_owner.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarang_Temp, "employee_id_owner"))
        Me.obj_Strukturunit_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "strukturunit_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_qtyitem.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_qtyitem"))
        Me.obj_Terimabarang_qtyrealization.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_qtyrealization"))
        Me.obj_Order_qty.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "order_qty"))
        Me.obj_Terimabarang_status.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_status"))
        Me.obj_Terimabarang_statusrealization.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_statusrealization"))
        Me.obj_Terimabarang_location.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_location"))
        Me.obj_Terimabarang_notes.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_notes"))
        Me.obj_Terimabarang_nosuratjalan.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_nosuratjalan"))
        Me.obj_terimabarang_tglsuratjalan.DataBindings.Add(New Binding("EditValue", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_tglsuratjalan", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy"))
        Me.obj_Channel_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "channel_id"))
        Me.obj_Terimabarang_isdisabled.DataBindings.Add(New Binding("Checked", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_isdisabled"))
        Me.obj_Terimabarang_createby.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_createby"))
        Me.obj_Terimabarang_createdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_createdt"))
        Me.obj_Terimabarang_modifiedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_modifiedby"))
        Me.obj_Terimabarang_modifieddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_modifieddt"))
        Me.obj_Terimabarang_appuser.DataBindings.Add(New Binding("Checked", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appuser"))
        Me.obj_Terimabarang_appuser_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appuser_by"))
        Me.obj_Terimabarang_appuser_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appuser_dt"))
        Me.obj_Terimabarang_appspv.DataBindings.Add(New Binding("Checked", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appspv"))
        Me.obj_Terimabarang_appspv_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appspv_by"))
        Me.obj_Terimabarang_appspv_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appspv_dt"))
        Me.obj_Terimabarang_appacc.DataBindings.Add(New Binding("Checked", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appacc"))
        Me.obj_Terimabarang_appacc_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appacc_by"))
        Me.obj_Terimabarang_appacc_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appacc_dt"))
        Me.obj_Terimabarang_foreign.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_foreign", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Currency_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarang_Temp, "currency_id", True, DataSourceUpdateMode.OnPropertyChanged, 0))
        Me.obj_Terimabarang_foreignrate.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_foreignrate", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_idrreal.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_idrreal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_pph.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_pph", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_ppn.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_ppn", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_disc.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_disc", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_cetakbpb.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_cetakbpb"))
        Me.obj_strukturunit_name.DataBindings.Add("Text", Me.tbl_TrnPenerimaanbarang_Temp, "strukturunit_name")

        Return True
    End Function

    Private Function BindingStartdetil() As Boolean
        Me.obj_asset_terimabarangdetil_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarang_id"))
        Me.obj_Terimabarangdetil_line.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_line"))
        Me.obj_Terimabarangdetil_parentline.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_parentline"))
        Me.obj_Terimabarangdetil_desc.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_desc"))
        ' Me.obj_terimabarangdetil_date.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_date", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy"))
        Me.obj_Assetcategory_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "assetcategory_id"))
        Me.obj_Assettype_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "assettype_id"))
        Me.obj_Terimabarang_barcode.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarang_barcode"))
        Me.obj_Terimabarang_parentbarcode.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarang_parentbarcode"))
        Me.obj_Item_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "item_id"))
        Me.obj_Itemcategory_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "itemcategory_id"))
        Me.obj_Itemtype_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "itemtype_id"))
        Me.obj_Brand_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "brand_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_serial_no.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_serial_no"))
        Me.obj_Terimabarangdetil_product_no.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_product_no"))
        Me.obj_Terimabarangdetil_model.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_model"))
        Me.obj_Material_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "material_id"))
        Me.obj_Colour_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "colour_id"))
        Me.obj_Size_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "size_id"))
        Me.obj_Sex_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "sex_id"))
        Me.obj_Room_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "room_id"))
        Me.obj_Terimabarangdetil_rack.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_rack"))
        Me.obj_Terimabarangdetil_qty.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_qty", True, DataSourceUpdateMode.OnPropertyChanged, 1))
        Me.obj_Terimabarangdetil_qtydetail.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_qtydetail", True, DataSourceUpdateMode.OnPropertyChanged, 1))
        Me.obj_Terimabarangdetil_qtytotal.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_qtytotal", True, DataSourceUpdateMode.OnPropertyChanged, 1))
        Me.obj_Unit_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "unit_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Currency_iddetil.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "currency_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_foreign.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_foreign", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_foreignrate.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_foreignrate", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_idrreal.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_idrreal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_pphpercent.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_pphpercent", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_ppnpercent.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_ppnpercent", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_disc.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_disc", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_pphforeign.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_pphforeign", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_pphidrreal.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_pphidrreal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_ppnforeign.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_ppnforeign", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_ppnidrreal.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_ppnidrreal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_totalforeign.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_totalforeign", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_totalidrreal.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_totalidrreal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarangdetil_nonfixasset.DataBindings.Add(New Binding("Checked", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_nonfixasset"))

        Me.obj_Terimabarangdetil_golfiskal.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_golfiskal"))

        Me.obj_Terimabarangdetil_depre_enddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_depre_enddt"))
        'Me.obj_Employee_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "employee_id"))
        'Me.obj_Strukturunitdetil_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "strukturunit_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Show_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "show_id"))
        Me.obj_Show_id_cont.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "show_id_cont"))
        Me.obj_Terimabarangdetil_eps.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_eps"))
        'Me.obj_Writeoff_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "writeoff_id"))
        'Me.obj_Writeoff_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "writeoff_dt"))
        Me.obj_Orderdetil_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "order_id"))
        Me.obj_Orderdetil_line.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "orderdetil_line"))
        'Me.obj_Budget_iddetil.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "budget_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        'Me.obj_Budgetdetil_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "budgetdetil_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Acc_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "acc_id"))
        'Me.obj_Channel_iddetil.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "channel_id"))
        Me.obj_budget_name.DataBindings.Add("Text", Me.tbl_TrnPenerimaanbarangdetil, "budget_name")
        Me.obj_budgetdetil_name.DataBindings.Add("Text", Me.tbl_TrnPenerimaanbarangdetil, "budgetdetil_name")

        RaiseEvent FormBindingStartDetil()

        Return True
    End Function

    Private Function BindingStopJurnal() As Boolean
        Me.obj_Jurnal_bookdate.DataBindings.Clear()
        Me.cbo_periode.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStartJurnal() As Boolean
        Me.obj_Jurnal_bookdate.DataBindings.Add(New Binding("Value", Me.tbl_TrnJurnal, "jurnal_bookdate", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy"))
        Me.cbo_periode.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnJurnal, "periode_id"))

        Return True
    End Function
#End Region

#Region " Dialoged Control "
#End Region

#Region " User Defined Function "

    Private Function uiTrnPenerimaanBarang_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnPenerimaanbarang_Temp
        Me.tbl_TrnPenerimaanbarang_Temp.Clear()
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("strukturunit_id").DefaultValue = Me._STRUKTUR_UNIT

        Select Case Me._MODULE_TYPE
            Case ModuleType.PURCHASE
                Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_type").DefaultValue = "PURCHASE"
            Case ModuleType.MANUAL
                Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_type").DefaultValue = "MANUAL"
                Me.tbl_TrnPenerimaanbarang_Temp.Columns("order_id").DefaultValue = "-"
                Me.tbl_TrnPenerimaanbarang_Temp.Columns("currency_id").DefaultValue = 1
            Case ModuleType.LISTPV
                Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_type").DefaultValue = "LISTPV"
            Case ModuleType.LISTGQ
                Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_type").DefaultValue = "LISTGQ"
        End Select

        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_status").DefaultValue = "-- Pilih --"
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_statusrealization").DefaultValue = "-- Pilih --"
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_date").DefaultValue = Now.Date
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_location").DefaultValue = ""

        ' TODO: Set Default Value for tbl_TrnPenerimaanbarangdetil
        Me.tbl_TrnPenerimaanbarangdetil.Clear()
        Me.tbl_TrnPenerimaanbarangdetil = clsDataset.CreateTblViewTrnTerimabarangDetil()
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarang_id").DefaultValue = 0
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrement = True
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrementStep = 10
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_date").DefaultValue = Now.Date

        Select Case Me._MODULE_TYPE
            Case ModuleType.PURCHASE
                Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_type").DefaultValue = "PURCHASE"
            Case ModuleType.MANUAL
                Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_type").DefaultValue = "MANUAL"
                Me.tbl_TrnPenerimaanbarangdetil.Columns("currency_id").DefaultValue = 1
        End Select

        Me.tbl_TrnPenerimaanbarangdetil.Columns("strukturunit_id").DefaultValue = Me._STRUKTUR_UNIT
        Me.tbl_TrnPenerimaanbarangdetil.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnPenerimaanbarangdetil.Columns("item_id").DefaultValue = "0"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("itemcategory_id").DefaultValue = "0"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("brand_id").DefaultValue = 0
        'suroso Me.DgvTrnPenerimaanbarangdetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil
        Me.TLTrnPenerimaanBarangDetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil
        '=======================
        Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try
    End Function

    Private Function uiTrnPenerimaanBarang_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()
        criteria = " AND terimabarang_isdisabled = 0 "

        If Me._USERTYPE = "acc" Then
            criteria = " AND terimabarang_appspv = 1 "
        End If

        If chk_Strukturunit_id_pemilik_search.Checked = True Then
            criteria = criteria & " AND strukturunit_id = " & obj_Strukturunit_id_pemilik_search.SelectedValue
        End If

        If chk_Rekanan_id_search.Checked = True Then
            criteria = criteria & " AND rekanan_id = " & CStr(obj_Rekanan_id_search.Text)
        End If

        If chk_User_search.Checked = True Then
            If Me._USERTYPE = "acc" Then
                If Me.cmb_appuser.SelectedValue = 1 Then
                    criteria &= " AND terimabarang_appuser = 1"
                ElseIf Me.cmb_appuser.SelectedValue = 2 Then
                    criteria &= " AND terimabarang_appspv = 1"
                ElseIf Me.cmb_appuser.SelectedValue = 3 Then
                    criteria &= " AND terimabarang_appacc = 1"
                End If
            ElseIf Me._USERTYPE = "spv" Then
                If Me.cmb_appuser.SelectedValue = 0 Then
                    criteria &= " AND terimabarang_appspv = 1"
                Else
                    criteria &= " AND terimabarang_appspv = 0"
                End If
            Else
                If Me.cmb_appuser.SelectedValue = 0 Then
                    criteria &= " AND terimabarang_appuser = 1"
                Else
                    criteria &= " AND terimabarang_appuser = 0"
                End If
            End If
        End If

        If chk_orderID_search.Checked = True Then
            criteria &= criteria & String.Format(" AND order_id = '{0}'", Me.obj_orderID_search.Text)
        End If

        If chk_RvID_search.Checked = True Then
            Dim ids As String = clsUtil.RefParser("terimabarang_id", Me.obj_RvID_search)

            If ids <> "" Then
                criteria = criteria + " and (" + ids + ")"
            End If
            '            criteria &= criteria & String.Format(" AND terimabarang_id = '{0}'", Me.obj_RvID_search.Text)
        End If

        If Me._USERTYPE = "user" OrElse Me._USERTYPE = "spv" Then
            Select Case Me._MODULE_TYPE
                Case ModuleType.PURCHASE
                    criteria &= " AND terimabarang_type = 'PURCHASE'"
                Case ModuleType.MANUAL
                    criteria &= " AND terimabarang_type = 'MANUAL'"
                Case ModuleType.LISTPV
                    criteria &= " AND terimabarang_type = 'LISTPV'"
                Case ModuleType.LISTGQ
                    criteria &= " AND terimabarang_type = 'LISTGQ'"
            End Select
        End If

        Me.tbl_TrnPenerimaanbarang.Clear()

        Try
            Using receive As New clsTrnPenerimaanBarang(Me.DSNFrm)
                receive.RetrieveHeader(Me.tbl_TrnPenerimaanbarang, criteria, Me._CHANNEL, Me.obj_top.Value)
            End Using

            If Me.tbl_TrnPenerimaanbarang.Rows.Count > 0 Then
                If Me._USERTYPE = "user" Then
                    Me.btnApproved.Visible = True
                    Me.btnUnApproved.Visible = True

                    If clsUtil.IsDbNull(DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_appuser").Value, False) = True Then
                        Me.btnApproved.Enabled = False
                        Me.btnUnApproved.Enabled = True
                    Else
                        Me.btnApproved.Enabled = True
                        Me.btnUnApproved.Enabled = False
                    End If
                Else
                    Me.btnApproved.Visible = False
                    Me.btnUnApproved.Visible = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

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
        RaiseEvent FormBeforeSave(terimabarang_id)

        Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).EndCurrentEdit()
        tbl_TrnPenerimaanbarang_Temp_Changes = Me.tbl_TrnPenerimaanbarang_Temp.GetChanges()

        'suroso 
        'Me.DgvTrnPenerimaanbarangdetil.EndEdit()
        Me.TLTrnPenerimaanBarangDetil.EndUpdate()
        '==========================================
        Me.BindingContext(Me.tbl_TrnPenerimaanbarangdetil).EndCurrentEdit()
        tbl_TrnPenerimaanbarangdetil_Changes = Me.tbl_TrnPenerimaanbarangdetil.GetChanges()

        If tbl_TrnPenerimaanbarang_Temp_Changes IsNot Nothing Or tbl_TrnPenerimaanbarangdetil_Changes IsNot Nothing Or Me.photoChanged.Count <> 0 Then
            Try

                MasterDataState = tbl_TrnPenerimaanbarang_Temp.Rows(0).RowState
                terimabarang_id = tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_id")

                If tbl_TrnPenerimaanbarang_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnPenerimaanBarang_SaveMaster(terimabarang_id, tbl_TrnPenerimaanbarang_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnPenerimaanBarang_SaveMaster(tbl_TrnPenerimaanbarang_Temp_Changes)")
                    Me.tbl_TrnPenerimaanbarang_Temp.AcceptChanges()
                End If

                If tbl_TrnPenerimaanbarangdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
                        If Me.tbl_TrnPenerimaanbarangdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnPenerimaanbarangdetil.Rows(i).Item("terimabarang_id") = terimabarang_id
                        End If
                    Next
                    success = Me.uiTrnPenerimaanBarang_SaveDetil(terimabarang_id, tbl_TrnPenerimaanbarangdetil_Changes)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnPenerimaanBarang_SaveDetil(tbl_TrnPenerimaanbarangdetil_Changes)")
                    Me.tbl_TrnPenerimaanbarangdetil.AcceptChanges()
                End If

                '----------------------------------------------------------------------------------------------------------
                'Tambahan save photo
                '----------------------------------------------------------------------------------------------------------
                If Me.photoChanged.Count <> 0 Then
                    For Each a As DictionaryEntry In Me.photoChanged
                        Dim cfilename As String = New IO.FileInfo(a.Value).Name
                        Dim arrStr As String() = cfilename.Split(CChar("_"))
                        Dim cNumber As String = arrStr(0)
                        Dim nLine As String = New IO.FileInfo(arrStr(1)).Name.Split(".")(0)

                        'UtilPhoto.SaveImage(clsUtil.GetBytes(a.Value), cNumber, CInt(nLine), Me.ImageServer)
                        UtilPhoto.SaveImageToDB(clsUtil.GetBytes(a.Value), cNumber, CInt(nLine), Me.DSNFiles)
                    Next
                End If
                '----------------------------------------------------------------------------------------------------------


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

        RaiseEvent FormAfterSave(terimabarang_id, result)
        Me.Cursor = Cursors.Arrow
    End Function

    Private Function uiTrnPenerimaanBarang_SaveMaster(ByRef terimabarang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        ' Save data: transaksi_penerimaanbarang
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_Insert", dbConn)
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

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_Update", dbConn)
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
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)

            terimabarang_id = objTbl.Rows(0).Item("terimabarang_id")
            Me.tbl_TrnPenerimaanbarang_Temp.Clear()
            Me.tbl_TrnPenerimaanbarang_Temp.Merge(objTbl)

        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        If MasterDataState = DataRowState.Added Then
            Me.locking.TryLocking(terimabarang_id)
            Me.tbl_TrnPenerimaanbarang.Merge(objTbl)

            For Each row As DataGridViewRow In Me.DgvTrnPenerimaanbarang.Rows
                If row.Cells("terimabarang_id").Value = terimabarang_id Then
                    Me.DgvTrnPenerimaanbarang.CurrentCell = row.Cells("terimabarang_id")
                    Exit For
                End If
            Next
        ElseIf MasterDataState = DataRowState.Modified Then
            Me.uiTrnPenerimaanBarang_UpdateList()
        End If

        Return True
    End Function

    Private Function uiTrnPenerimaanBarang_SaveDetil(ByRef terimabarang_id As Object, ByVal objTbl As DataTable) As Boolean
        Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbTrans As OleDb.OleDbTransaction
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbConnAsset.Open()
        dbTrans = dbConnAsset.BeginTransaction()
        clsApplicationRole.SetAppRole(dbConnAsset, dbTrans, cookie)

        ' Save data: transaksi_penerimaanbarangdetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Insert", dbConnAsset, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_parentline", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_parentline"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_desc", System.Data.OleDb.OleDbType.VarWChar, 510, "terimabarangdetil_desc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarangdetil_date"))
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

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Update", dbConnAsset, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_parentline", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_parentline"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_desc", System.Data.OleDb.OleDbType.VarWChar, 510, "terimabarangdetil_desc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarangdetil_date"))
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

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Delete", dbConnAsset, dbTrans)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_line"))
        dbCmdDelete.Parameters("@terimabarang_id").Value = terimabarang_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete

        Dim tbl As DataTable = objTbl.GetChanges(DataRowState.Deleted)
        Dim cTerimabarang_id As String = String.Empty
        Dim nline As Integer = 0
        Dim cNmPhoto As String
        If tbl IsNot Nothing Then
            For Each row As DataRow In tbl.Rows
                cTerimabarang_id = row.Item("terimabarang_id", DataRowVersion.Original)
                nline = row.Item("terimabarangdetil_line", DataRowVersion.Original)
                cNmPhoto = String.Format("{0}_{1}", cTerimabarang_id, nline)
                'UtilPhoto.DeleteImage(cTerimabarang_id, CInt(nline), Me.ImageServer)
                UtilPhoto.DeleteImage(cTerimabarang_id, CInt(nline), Me.ImageServer)
                Me.photoChanged.Remove(cNmPhoto)
            Next
        End If

        Try
            dbDA.Update(objTbl)

            ' Khusus untuk narik GQ
            '-----------------------------------------------------------------------------------------------------------
            'If Me._MODULE_TYPE = ModuleType.LISTGQ Then
            '    Dim request_id As String
            '    Dim request_line As Integer
            '    Dim tblDeleted As DataTable = Me.tbl_TrnPenerimaanbarangdetil.GetChanges(DataRowState.Deleted)
            '    Dim tblAdded As DataTable = Me.tbl_TrnPenerimaanbarangdetil.GetChanges(DataRowState.Added)

            '    If tblDeleted IsNot Nothing Then
            '        For Each row As DataRow In tblDeleted.Rows
            '            request_id = row.Item("order_id", DataRowVersion.Original)
            '            request_line = row.Item("orderdetil_line", DataRowVersion.Original)

            '            Using receive As New clsTrnPenerimaanBarang(Me.DSNAsset)
            '                receive.ClearRefRequest(request_id, request_line, dbConnAsset, dbTrans)
            '            End Using
            '        Next
            '    End If

            '    If tblAdded IsNot Nothing Then
            '        For Each row As DataRow In tblAdded.Rows
            '            request_id = row.Item("order_id")
            '            request_line = row.Item("orderdetil_line")

            '            Using receive As New clsTrnPenerimaanBarang(Me.DSNAsset)
            '                receive.UpdateRefRequest(request_id, request_line, terimabarang_id, dbConnAsset, dbTrans)
            '            End Using
            '        Next
            '    End If

            'End If
            '-----------------------------------------------------------------------------------------------------------

            dbTrans.Commit()
        Catch ex As System.Data.OleDb.OleDbException
            dbTrans.Rollback()

            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConnAsset, dbTrans, cookie)
            dbConnAsset.Close()
        End Try

        Return True
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
        RaiseEvent FormBeforeSave(jurnal_id)

        Me.BindingContext(Me.tbl_TrnJurnal).EndCurrentEdit()

        Me.DgvTrnJurnaldetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnJurnaldetil_kredit).EndCurrentEdit()
        tbl_TrnJurnaldetil_kredit_Changes = Me.tbl_TrnJurnaldetil_kredit.GetChanges()

        Me.DgvTrnJurnaldetil_Pembayaran.EndEdit()
        Me.BindingContext(Me.tbl_TrnJurnaldetil_debet).EndCurrentEdit()
        tbl_TrnJurnaldetil_debet_Changes = Me.tbl_TrnJurnaldetil_debet.GetChanges()

        Me.BindingContext(Me.tbl_TrnJurnal).EndCurrentEdit()
        tbl_TrnJurnal_Changes = Me.tbl_TrnJurnal.GetChanges()

        Me.BindingContext(Me.tbl_JurnalReference).EndCurrentEdit()
        tbl_JurnalReference_Changes = Me.tbl_JurnalReference.GetChanges()

        If tbl_TrnJurnal_Changes IsNot Nothing Or tbl_JurnalReference_Changes IsNot Nothing Or tbl_TrnJurnaldetil_kredit_Changes IsNot Nothing Or tbl_TrnJurnaldetil_debet_Changes IsNot Nothing Then
            Try
                MasterDataState = tbl_TrnJurnal.Rows(0).RowState
                jurnal_id = Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id")
                channel_id = Me.tbl_TrnJurnal.Rows(0).Item("channel_id")

                If tbl_TrnJurnal_Changes IsNot Nothing Then
                    tbl_TrnJurnal_Changes.Rows(0).Item("modified_by") = Me.UserName
                    tbl_TrnJurnal_Changes.Rows(0).Item("modified_dt") = Now()

                    success = Me.uiTrnPenerimaanBarang_Purchase_JurnalSaveMaster(tbl_TrnJurnal_Changes)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnJurnal_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
                    Me.tbl_TrnJurnal.AcceptChanges()
                End If

                If tbl_TrnJurnaldetil_kredit_Changes IsNot Nothing Then
                    Dim nrow1_DgvTrnJurnaldetil = Me.DgvTrnJurnaldetil.Rows.Count

                    For i = 0 To Me.tbl_TrnJurnaldetil_kredit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_kredit.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnJurnaldetil_kredit.Rows(i).Item("jurnal_id") = jurnal_id
                            Me.tbl_TrnJurnaldetil_kredit.Rows(i).Item("channel_id") = channel_id
                        End If
                    Next

                    Me.uiTrnJurnal_TblDetilInverse(tbl_TrnJurnaldetil_kredit_Changes)
                    success = Me.uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilKredit(jurnal_id, tbl_TrnJurnaldetil_kredit_Changes)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_SaveDetil(tbl_TrnJurnaldetil_Changes)")
                    Me.tbl_TrnJurnaldetil_kredit.AcceptChanges()

                    Dim nrow2_DgvTrnJurnaldetil = Me.DgvTrnJurnaldetil.Rows.Count
                    Dim nrow As Integer
                    Dim dgvrow As DataGridViewRow

                    For nrow = nrow1_DgvTrnJurnaldetil To nrow2_DgvTrnJurnaldetil - 1
                        dgvrow = Me.DgvTrnJurnaldetil.Rows(nrow - 1)
                        Me.DgvTrnJurnaldetil.Rows.Remove(dgvrow)
                    Next
                End If

                If tbl_JurnalReference_Changes IsNot Nothing Then
                    success = Me.uiTrnPenerimaanBarang_Purchase_JurnalSaveReference(jurnal_id, tbl_JurnalReference_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Reference Data at Me.uiTrnPenerimaanBarang_Purchase_JurnalSaveReference(jurnal_id, tbl_JurnalReference_Changes, MasterDataState)")
                    Me.tbl_JurnalReference.AcceptChanges()
                End If

                If tbl_TrnJurnaldetil_debet_Changes IsNot Nothing Then

                    Dim nrow1_DgvTrnJurnaldetil_Pembayaran = Me.DgvTrnJurnaldetil_Pembayaran.Rows.Count

                    For i = 0 To Me.tbl_TrnJurnaldetil_debet.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_debet.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnJurnaldetil_debet.Rows(i).Item("jurnal_id") = jurnal_id
                            Me.tbl_TrnJurnaldetil_debet.Rows(i).Item("channel_id") = channel_id
                        End If
                    Next
                    success = Me.uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilDebet(jurnal_id, tbl_TrnJurnaldetil_debet_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save DetilJadwalPembayaran Data at Me.uiTrnJurnal_SaveDetil(tbl_TrnJurnaldetil_Changes)")
                    Me.tbl_TrnJurnaldetil_debet.AcceptChanges()

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
                    ' ''MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveMaster(ByVal objTbl As DataTable) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing
        ' ''Dim curpos As Integer

        ' Save data: transaksi_jurnal
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnalTerimaOrder_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_bookdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_bookdate"))
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

        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnJurnal_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_bookdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_bookdate"))
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
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)
        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilKredit(ByRef jurnal_id As Object, ByVal objTbl As DataTable) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDAUpdateDetil As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        ' Save data: Transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnaldetil_Insert", dbConn)
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


        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnJurnaldetil_Update", dbConn)
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


        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnaldetil_Delete", dbConn)
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
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDAUpdateDetil.Update(objTbl)

        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilDebet(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDAUpdateDetil As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        ' Save data: Transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnaldetil_Insert", dbConn)
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


        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnJurnaldetil_Update", dbConn)
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

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnaldetil_Delete", dbConn)
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
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDAUpdateDetil.Update(objTbl)

        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveReference(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        ' Save data: transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnalreference_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_ref", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id_ref"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_refline", System.Data.OleDb.OleDbType.Integer, 4, "jurnal_id_refline"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "jurnal_id_budgetline"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@referencetype", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@referencetype").Value = "jurnal BPB"

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnalreference_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_ref", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id_ref"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_refline", System.Data.OleDb.OleDbType.Integer, 4, "jurnal_id_refline"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "jurnal_id_budgetline"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@referencetype", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdDelete.Parameters("@referencetype").Value = "jurnal BPB"

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)
        Catch ex As OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTrnPenerimaanBarang_Delete() As Boolean
        Dim res As String = ""
        Dim terimabarang_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(terimabarang_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnPenerimaanbarang.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnPenerimaanBarang_DeleteRow(Me.DgvTrnPenerimaanbarang.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(terimabarang_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnPenerimaanBarang_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbTrans As OleDb.OleDbTransaction
        Dim terimabarang_id As String
        Dim NewRowIndex As Integer
        Dim cookie As Byte() = Nothing

        terimabarang_id = Me.DgvTrnPenerimaanbarang.Rows(rowIndex).Cells("terimabarang_id").Value

        Try
            dbConnAsset.Open()
            dbTrans = dbConnAsset.BeginTransaction()
            clsApplicationRole.SetAppRole(dbConnAsset, dbTrans, cookie)

            Using receive As New clsTrnPenerimaanBarang(Me.DSNFrm)
                receive.DeleteHeader(terimabarang_id, dbConnAsset, dbTrans)

                If Me._MODULE_TYPE = ModuleType.LISTGQ Then
                    receive.ClearRefRequestAll(terimabarang_id, dbConnAsset, dbTrans)
                End If
            End Using

            dbTrans.Commit()

            If Me.DgvTrnPenerimaanbarang.Rows.Count > 1 Then
                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnPenerimaanBarang_OpenRow(NewRowIndex)
                    Me.tbl_TrnPenerimaanbarang.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnPenerimaanbarang.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnPenerimaanBarang_OpenRow(NewRowIndex)
                    Me.tbl_TrnPenerimaanbarang.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnPenerimaanbarang.Rows.RemoveAt(rowIndex)
                    Me.uiTrnPenerimaanBarang_OpenRow(rowIndex)
                End If
            Else
                Me.tbl_TrnPenerimaanbarang_Temp.Clear()
                Me.tbl_TrnPenerimaanbarang.Rows.RemoveAt(rowIndex)
            End If

        Catch ex As System.Data.OleDb.OleDbException
            dbTrans.Rollback()
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            clsApplicationRole.UnsetAppRole(dbConnAsset, dbTrans, cookie)
            dbConnAsset.Close()
            Me.locking.Clear()
        End Try
    End Function

    Private Function uiTrnPenerimaanBarang_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        'Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim terimabarang_id As String
        Dim channel_id As String
        Dim CancelOpenRow As Boolean = False
        Dim cookie As Byte() = Nothing
        'Dim cookie1 As Byte() = Nothing
        terimabarang_id = Me.DgvTrnPenerimaanbarang.Rows(rowIndex).Cells("terimabarang_id").Value
        channel_id = Me.DgvTrnPenerimaanbarang.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor

        RaiseEvent FormBeforeOpenRow(terimabarang_id, CancelOpenRow)

        Try
            If CancelOpenRow = True Then
                Exit Function
            End If

            dbConn.Open()
            'dbConnAsset.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            'clsApplicationRole.SetAppRole(dbConnAsset, cookie1)

            Me.uiTrnPenerimaanBarang_OpenRowMaster(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_OpenRowDetil(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_OpenRowJurnal(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_kredit(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_Debet(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalReference(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_Purchase_OpenRowResponse(channel_id, terimabarang_id, dbConn)
            ''tambahan
            'Me.uiTrnPenerimaanBarang_OpenRowDetil2(channel_id, terimabarang_id, dbConn)

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnPenerimaanBarang_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            'clsApplicationRole.UnsetAppRole(dbConnAsset, cookie1)
            dbConn.Close()
            'dbConnAsset.Close()
        End Try

        RaiseEvent FormAfterOpenRow(terimabarang_id)

        Me.Cursor = Cursors.Arrow

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

            'dbDA.Fill(Me.tbl_TrnPenerimaanbarang_Temp)
            '=====ADD PTS 20130913--"Cegah Currency Kosong"
            If Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_type") = "PURCHASE" Then
                tbl_strukturunitRV.Clear()
                Me.DataFill(tbl_strukturunitRV, "tr_StrukturunitOrderAllBPB_select", "terimabarang_id = '" & terimabarang_id & "'")
                Me.currency_id = tbl_strukturunitRV.Rows(0).Item("currency_id")
            End If
            '==================================================================

            Me.BindingStart()

        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPenerimaanBarang_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function uiTrnPenerimaanBarang_OpenRowDetil(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_ViewTrnPenerimaanbarangdetil_Select", dbConn)

        dbCmd.Parameters.Add("@Criteria", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("terimabarang_id='{0}'", terimabarang_id)
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
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_type").DefaultValue = "PURCHASE"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnPenerimaanbarangdetil.Columns("item_id").DefaultValue = "0"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("itemcategory_id").DefaultValue = "0"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("brand_id").DefaultValue = 0

        Try
            Me.BindingStopDetil()
            dbDA.Fill(Me.tbl_TrnPenerimaanbarangdetil)
            'suroso
            TLTrnPenerimaanBarangDetil.KeyFieldName = "terimabarangdetil_line"
            TLTrnPenerimaanBarangDetil.ParentFieldName = "terimabarangdetil_parentline"
            TLTrnPenerimaanBarangDetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil
            TLTrnPenerimaanBarangDetil.ExpandAll()
            Me.BindingStartdetil()
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
            Me.DgvTrnJurnaldetil.DataSource = Me.tbl_TrnJurnaldetil_kredit
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
            Me.DgvTrnJurnaldetil_Pembayaran.DataSource = Me.tbl_TrnJurnaldetil_debet
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnPenerimaanBarang_Purchase_OpenRowJurnalReference(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnalReference_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@jurnal_id", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@jurnal_id").Value = jurnal_id
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

    Private Function uiTrnPenerimaanBarang_Purchase_OpenRowResponse(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnalResponse_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@jurnal_id", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@jurnal_id").Value = jurnal_id
        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 0
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_JurnalResponse.Clear()

        Try
            dbDA.Fill(Me.tbl_JurnalResponse)
            Me.DgvTrnJurnalresponse.DataSource = Me.tbl_JurnalResponse
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowResponse()" & vbCrLf & ex.Message)
        End Try

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

    Private Function uiTrnPenerimaanBarang_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnPenerimaanBarang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If DgvTrnPenerimaanbarang.RowCount <= 0 Then
                Exit Function
            End If
            Me.DgvTrnPenerimaanbarang.CurrentCell = Me.DgvTrnPenerimaanbarang(1, 0)
            Me.uiTrnPenerimaanBarang_RefreshPosition()
        End If
    End Function

    Private Function uiTrnPenerimaanBarang_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnPenerimaanBarang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If DgvTrnPenerimaanbarang.RowCount <= 0 Then
                Exit Function
            End If
            If Me.DgvTrnPenerimaanbarang.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnPenerimaanbarang.CurrentCell = Me.DgvTrnPenerimaanbarang(1, DgvTrnPenerimaanbarang.CurrentCell.RowIndex - 1)
                Me.uiTrnPenerimaanBarang_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnPenerimaanBarang_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnPenerimaanBarang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If DgvTrnPenerimaanbarang.RowCount <= 0 Then
                Exit Function
            End If
            If Me.DgvTrnPenerimaanbarang.CurrentCell.RowIndex < Me.DgvTrnPenerimaanbarang.Rows.Count - 1 Then
                Me.DgvTrnPenerimaanbarang.CurrentCell = Me.DgvTrnPenerimaanbarang(1, DgvTrnPenerimaanbarang.CurrentCell.RowIndex + 1)
                Me.uiTrnPenerimaanBarang_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnPenerimaanBarang_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnPenerimaanBarang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If DgvTrnPenerimaanbarang.RowCount <= 0 Then
                Exit Function
            End If
            Me.DgvTrnPenerimaanbarang.CurrentCell = Me.DgvTrnPenerimaanbarang(1, Me.DgvTrnPenerimaanbarang.Rows.Count - 1)
            Me.uiTrnPenerimaanBarang_RefreshPosition()
        End If
    End Function

    Private Function uiTrnPenerimaanBarang_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnPenerimaanBarang_OpenRow(Me.DgvTrnPenerimaanbarang.CurrentRow.Index)
    End Function

    Private Function uiTrnPenerimaanBarang_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        'edited
        Dim dbConAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbTransAsset As OleDb.OleDbTransaction = Nothing
        Dim tbl_TrnPenerimaanbarang_Temp_Changes As DataTable
        Dim tbl_TrnPenerimaanbarangdetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim terimabarang_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult
        Dim cookie As Byte() = Nothing

        If Me.DgvTrnPenerimaanbarang.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).EndCurrentEdit()
            tbl_TrnPenerimaanbarang_Temp_Changes = Me.tbl_TrnPenerimaanbarang_Temp.GetChanges()

            'suroso ================================
            'Me.DgvTrnPenerimaanbarangdetil.EndEdit()
            Me.TLTrnPenerimaanBarangDetil.EndUpdate()
            '======================================
            Me.BindingContext(Me.tbl_TrnPenerimaanbarangdetil).EndCurrentEdit()
            tbl_TrnPenerimaanbarangdetil_Changes = Me.tbl_TrnPenerimaanbarangdetil.GetChanges()

            If tbl_TrnPenerimaanbarang_Temp_Changes IsNot Nothing Or tbl_TrnPenerimaanbarangdetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(terimabarang_id)

                        Try
                            dbConAsset.Open()
                            dbTransAsset = dbConAsset.BeginTransaction()
                            clsApplicationRole.SetAppRole(dbConAsset, dbTransAsset, cookie)

                            If tbl_TrnPenerimaanbarang_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnPenerimaanBarang_SaveMaster(terimabarang_id, tbl_TrnPenerimaanbarang_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_TrnPenerimaanbarang_Temp.AcceptChanges()
                            End If

                            If tbl_TrnPenerimaanbarangdetil_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
                                    If Me.tbl_TrnPenerimaanbarangdetil.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnPenerimaanbarangdetil.Rows(i).Item("terimabarang_id") = terimabarang_id
                                    End If
                                Next
                                success = Me.uiTrnPenerimaanBarang_SaveDetil(terimabarang_id, tbl_TrnPenerimaanbarangdetil_Changes)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnPenerimaanbarangdetil.AcceptChanges()
                            End If
                            dbTransAsset.Commit()
                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Catch ex As System.Data.OleDb.OleDbException
                            dbTransAsset.Rollback()
                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            If dbConAsset.State = ConnectionState.Open Then
                                clsApplicationRole.UnsetAppRole(dbConAsset, dbTransAsset, cookie)
                                dbConAsset.Close()
                            End If
                        End Try

                        RaiseEvent FormAfterSave(terimabarang_id, result)

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

    Private Function uiTrnPenerimaanbarang_FormChanges() As Boolean
        Dim tbl_TrnPenerimaanbarangTemp_Changes As DataTable
        Dim tbl_TrnPenerimaanbarangdetil_Changes As DataTable
        Dim tbl_TrnJurnal_Changes As DataTable
        Dim tbl_JurnalReference_Changes As DataTable
        Dim tbl_TrnJurnaldetil_kredit_Changes As DataTable
        Dim tbl_TrnJurnaldetil_debet_Changes As DataTable

        Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).EndCurrentEdit()
        tbl_TrnPenerimaanbarangTemp_Changes = Me.tbl_TrnPenerimaanbarang_Temp.GetChanges()

        'suroso ===============================
        'Me.DgvTrnPenerimaanbarangdetil.EndEdit()
        Me.TLTrnPenerimaanBarangDetil.EndUpdate()
        '======================================
        Me.BindingContext(Me.tbl_TrnPenerimaanbarangdetil).EndCurrentEdit()
        tbl_TrnPenerimaanbarangdetil_Changes = Me.tbl_TrnPenerimaanbarangdetil.GetChanges()

        Me.BindingContext(Me.tbl_TrnJurnal).EndCurrentEdit()

        Me.DgvTrnJurnaldetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnJurnaldetil_kredit).EndCurrentEdit()
        tbl_TrnJurnaldetil_kredit_Changes = Me.tbl_TrnJurnaldetil_kredit.GetChanges()

        Me.DgvTrnJurnaldetil_Pembayaran.EndEdit()
        Me.BindingContext(Me.tbl_TrnJurnaldetil_debet).EndCurrentEdit()
        tbl_TrnJurnaldetil_debet_Changes = Me.tbl_TrnJurnaldetil_debet.GetChanges()

        Me.BindingContext(Me.tbl_TrnJurnal).EndCurrentEdit()
        tbl_TrnJurnal_Changes = Me.tbl_TrnJurnal.GetChanges()

        Me.BindingContext(Me.tbl_JurnalReference).EndCurrentEdit()
        tbl_JurnalReference_Changes = Me.tbl_JurnalReference.GetChanges()

        Try
            If tbl_TrnPenerimaanbarangTemp_Changes IsNot Nothing Then
                Throw New Exception()
            End If

            If tbl_TrnPenerimaanbarangdetil_Changes IsNot Nothing Then
                Throw New Exception()
            End If

            If tbl_TrnJurnal_Changes IsNot Nothing Then
                Throw New Exception()
            End If

            If tbl_TrnJurnaldetil_debet_Changes IsNot Nothing Then
                Throw New Exception()
            End If

            If tbl_TrnJurnaldetil_kredit_Changes IsNot Nothing Then
                Throw New Exception()
            End If

            If tbl_JurnalReference_Changes IsNot Nothing Then
                Throw New Exception()
            End If

            If Me.photoChanged.Count <> 0 Then
                Throw New Exception()
            End If
        Catch ex As Exception
            Dim res As MsgBoxResult

            res = MsgBox("Data has been changed. Are you sure to save data ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation)

            If res = MsgBoxResult.Ok Then
                Me.Cursor = Cursors.WaitCursor

                Me.tbtnSave.PerformClick()

                Me.Cursor = Cursors.Default
            Else
                Return True
            End If
        End Try
    End Function

    Private Function uiTrnPenerimaanBarang_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        Dim message As String = ""

        Me.Validate()

        Try
            If Me._USERTYPE = "acc" Then
                'cek book date dan tanggal periode
                Dim dr() As DataRow = Me.tbl_MstPeriodeCombo.Select(String.Format("periode_id='{0}'", Me.cbo_periode.SelectedValue))
                Dim tgl_start As Date = dr(0).Item("periode_datestart")
                Dim tgl_end As Date = dr(0).Item("periode_dateend")
                Dim tgl As Date = CDate(Me.obj_Jurnal_bookdate.Value).Date

                If dr(0).Item("periode_isclosed") = True Then
                    Me.objFormError.SetError(Me.cbo_periode, "Period has closed! Please contact your administrator for open this period")
                    Throw New Exception("Period has closed!! Please contact your administrator for open this period")
                Else
                    Me.objFormError.SetError(Me.cbo_periode, "")
                End If

                If tgl >= tgl_start And tgl <= tgl_end Then
                    Me.objFormError.SetError(Me.cbo_periode, "")
                    Me.objFormError.SetError(Me.obj_Jurnal_bookdate, "")
                Else
                    message = "Bookdate does not match with the Period!!"
                    Me.objFormError.SetError(Me.cbo_periode, message)
                    Me.objFormError.SetError(Me.obj_Jurnal_bookdate, message)

                    Throw New Exception(message)
                End If
            End If

            If Me.obj_Rekanan_id.SelectedValue = 0 Then
                ErrorMessage = "Rekanan cannot be empty"
                Me.objFormError.SetError(Me.obj_Rekanan_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Rekanan_id, "")
            End If

            If Me._USERTYPE = "acc" Then
                'cek isi cell di detil Kredit
                Dim i As Integer
                Dim cell_acc_id, cell_rekanan_id As DataGridViewCell
                Dim dgv_error, row_error As Boolean
                Me.DgvTrnJurnaldetil.AllowUserToAddRows = False
                Dim table_account As DataTable = New DataTable
                table_account = Me.tbl_MstAccGrid.Copy

                For i = 0 To Me.DgvTrnJurnaldetil.Rows.Count - 1
                    row_error = False
                    message = "Account belum diisi"
                    cell_acc_id = Me.DgvTrnJurnaldetil.Rows(i).Cells("acc_id")
                    If cell_acc_id.Value IsNot DBNull.Value Then
                        table_account.DefaultView.RowFilter = String.Format(" acc_id = {0} ", cell_acc_id.Value)

                        If table_account.DefaultView.Count > 0 Then
                            If cell_acc_id.Value = "0" Then
                                cell_acc_id.ErrorText = message
                                row_error = True
                            Else
                                cell_acc_id.ErrorText = ""
                            End If
                        Else
                            cell_acc_id.ErrorText = message
                            row_error = True
                        End If
                    Else
                        cell_acc_id.ErrorText = message
                        row_error = True
                    End If

                    message = "Rekanan belum diisi"
                    cell_rekanan_id = Me.DgvTrnJurnaldetil.Rows(i).Cells("rekanan_id")
                    If cell_rekanan_id.Value IsNot DBNull.Value Then
                        If cell_rekanan_id.Value = "0" Then
                            cell_rekanan_id.ErrorText = message
                            row_error = True
                        Else
                            cell_rekanan_id.ErrorText = ""
                        End If
                    Else
                        cell_rekanan_id.ErrorText = message
                        row_error = True
                    End If

                    If row_error Then
                        dgv_error = True
                        Me.DgvTrnJurnaldetil.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                    Else
                        Me.DgvTrnJurnaldetil.Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If
                Next

                'cek isi cell di detil Debit
                Dim j As Integer
                Dim cell_acc_id1, cell_rekanan_id1 As DataGridViewCell
                Dim row_error1 As Boolean
                Me.DgvTrnJurnaldetil_Pembayaran.AllowUserToAddRows = False

                For j = 0 To Me.DgvTrnJurnaldetil_Pembayaran.Rows.Count - 1
                    row_error1 = False
                    message = "Account belum diisi"
                    cell_acc_id1 = Me.DgvTrnJurnaldetil_Pembayaran.Rows(j).Cells("acc_id")
                    If cell_acc_id1.Value IsNot DBNull.Value Then
                        If cell_acc_id1.Value = "0" Then
                            cell_acc_id1.ErrorText = message
                            row_error1 = True
                        Else
                            cell_acc_id1.ErrorText = ""
                        End If
                    Else
                        cell_acc_id1.ErrorText = message
                        row_error1 = True
                    End If

                    message = "Rekanan belum diisi"
                    cell_rekanan_id1 = Me.DgvTrnJurnaldetil_Pembayaran.Rows(j).Cells("rekanan_id")
                    If cell_rekanan_id1.Value IsNot DBNull.Value Then
                        If cell_rekanan_id1.Value = "0" Then
                            cell_rekanan_id1.ErrorText = message
                            row_error1 = True
                        Else
                            cell_rekanan_id1.ErrorText = ""
                        End If
                    Else
                        cell_rekanan_id1.ErrorText = message
                        row_error1 = True
                    End If

                    If row_error1 Then
                        dgv_error = True
                        Me.DgvTrnJurnaldetil_Pembayaran.Rows(j).DefaultCellStyle.BackColor = Color.Coral
                    Else
                        Me.DgvTrnJurnaldetil_Pembayaran.Rows(j).DefaultCellStyle.BackColor = Color.White
                    End If
                Next

                If dgv_error Then
                    Throw New Exception("Data ada yang belum diisi!")
                End If
            End If

            If Me.obj_Terimabarang_type.Text.ToLower() = "ListPV".ToLower() Then
                If Me.obj_Terimabarang_id.Text.Trim = "" Then
                    Exit Function
                End If

                If Me.obj_Order_id.Text.Trim = "" Then
                    MsgBox("Nomor PV tidak boleh kosong.")
                    Return True
                End If

                Dim pv_id As String = Me.obj_Order_id.Text
                Dim receive_number As String = Me.obj_Terimabarang_id.Text
                Dim listPV As New clsRVListPV(Me.DSNFrm)
                Dim totalAmount As Decimal = 0
                Dim amount As Decimal = 0

                For Each row As DataRow In Me.tbl_TrnPenerimaanbarangdetil.Rows
                    amount = row.Item("terimabarangdetil_foreign")
                    totalAmount += amount
                Next

                If receive_number.Trim = "" Then
                    If listPV.GetPVForeignFromJurnal(pv_id) < totalAmount Then
                        MsgBox("Total amount lebih besar dari PV")
                        Return True
                    End If
                Else
                    If listPV.GetPVForeignFromJurnal(pv_id) < (listPV.GetPVForeignFromReceive(pv_id, receive_number) + totalAmount) Then
                        MsgBox("Total amount lebih besar dari PV")
                        Return True
                    End If
                End If
            End If

            ' ARI MDP2 20160616
            '=====================================================================================================================================================================
            If _MODULE_TYPE = ModuleType.PURCHASE And Me._USERTYPE <> "acc" Then
                Dim clsTerimaBarang As New clsTrnPenerimaanBarang(Me.DSNFrm)
                Dim objTblChecking As New DataTable
                Dim AmountNEW As Decimal
                Dim objTblTemp1 As New DataTable
                Dim objTblTemp2 As New DataTable

                Dim vw As DataView = New DataView(Me.tbl_TrnPenerimaanbarangdetil)
                Dim check() As DataRow = vw.ToTable(True, "terimabarang_id", "order_id", "orderdetil_line").Select(" order_id <> ''")

                If check.Length > 0 Then
                    objTblTemp1 = check.CopyToDataTable

                    For Each dtRow As DataRow In objTblTemp1.Rows
                        AmountNEW = 0
                        objTblTemp2.Clear()
                        check = Me.tbl_TrnPenerimaanbarangdetil.Select(String.Format(" order_id = '{0}' AND orderdetil_line = {1}", dtRow("order_id").ToString, dtRow("orderdetil_line")))

                        If check.Length > 0 Then
                            objTblTemp2 = check.CopyToDataTable 'Me.tbl_TrnPenerimaanbarangdetil.Select(String.Format(" order_id = '{0}' AND orderdetil_line = {1}", dtRow("order_id").ToString, dtRow("orderdetil_line"))).CopyToDataTable

                            For Each dtRow2 As DataRow In objTblTemp2.Rows
                                AmountNEW = AmountNEW + ((dtRow2("terimabarangdetil_foreign") - dtRow2("terimabarangdetil_disc")) * dtRow2("terimabarangdetil_qty"))
                            Next

                            AmountNEW = Math.Floor(AmountNEW * 100) / 100

                            clsTerimaBarang.CheckingBPBAmountWithDiscPerLine(objTblChecking, dtRow("terimabarang_id"), dtRow("order_id"), dtRow("orderdetil_line"), AmountNEW)

                            If objTblChecking.Rows.Count > 0 Then
                                If objTblChecking.Rows(0).Item("terimabarang_totalsisa") < 0 Then
                                    Throw New Exception("Amount melebihi PO.")
                                    'MsgBox("Amount melebihi PO.")
                                    'Exit For

                                End If
                            End If
                        End If
                    Next
                End If
            End If
            '=====================================================================================================================================================================
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function
#End Region

    Private Sub uiTrnPenerimaanBarang_FormAfterDelete(ByRef id As Object) Handles Me.FormAfterDelete

    End Sub

    Private Sub uiTrnPenerimaanBarang_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Dim currentRow As DataRow = CType(Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).Current, DataRowView).Row
        Dim approved As Boolean
        'Dim approveduser As Boolean
        Dim approvedspv As Boolean
        Dim approvedacc As Boolean

        'appro
        approvedspv = currentRow.Item("terimabarang_appspv")
        approvedacc = currentRow.Item("terimabarang_appacc")

        If Me._USERTYPE = "user" Then
            approved = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appuser", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = True, False)
            'approvedspv = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appspv", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = True, False)

            Me.btnApproved.Visible = False
            Me.btnUnApproved.Visible = False

            If approved Then
                Me.tbtnDel.Enabled = False
                Me.tbtnSave.Enabled = False
            Else
                Me.tbtnDel.Enabled = True
                Me.tbtnSave.Enabled = True
            End If

            If approvedspv = False Then
                Me.locking.TryLocking(id)
            End If


        ElseIf Me._USERTYPE = "spv" Then
            approved = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appspv", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = True, False)
            'approvedacc = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appacc", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = True, False)

            Me.btnApproved.Visible = True
            Me.btnUnApproved.Visible = True

            If approved Then
                Me.tbtnDel.Enabled = False
                Me.tbtnSave.Enabled = False
                Me.btnApproved.Enabled = False
                Me.btnUnApproved.Enabled = True
            Else
                Me.tbtnDel.Enabled = True
                Me.tbtnSave.Enabled = True
                Me.btnApproved.Enabled = True
                Me.btnUnApproved.Enabled = False
            End If

            If approvedacc = False Then
                Me.locking.TryLocking(id)
            End If

        ElseIf Me._USERTYPE = "acc" Then
            approved = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appacc", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = True, False)

            Me.btnApproved.Visible = True
            Me.btnUnApproved.Visible = True

            If approved Then
                Me.tbtnDel.Enabled = False
                Me.tbtnSave.Enabled = False
                Me.btnApproved.Enabled = False
                Me.btnUnApproved.Enabled = True
                'tambahan
                Me.PnlDataMaster.Enabled = False
            Else
                Me.tbtnDel.Enabled = True
                Me.tbtnSave.Enabled = True
                Me.btnApproved.Enabled = True
                Me.btnUnApproved.Enabled = False
                'tambahan
                Me.PnlDataMaster.Enabled = True
                For Each ctr As Control In Me.PnlDataMaster.Controls
                    Select Case ctr.GetType().Name
                        Case GetType(Label).Name
                        Case GetType(TextBox).Name
                            Dim t As TextBox = ctr
                            If t.Name = "obj_Terimabarang_nosuratjalan" Then
                                t.Enabled = True
                            Else
                                t.Enabled = False
                            End If

                        Case GetType(ComboBox).Name
                            Dim c As ComboBox = ctr

                            c.Enabled = False
                        Case GetType(Button).Name
                            Dim c As Button = ctr

                            c.Enabled = Not True
                        Case GetType(DateTimePicker).Name
                            Dim d As DateTimePicker = ctr
                            ' If d.Name <> "obj_terimabarang_tglsuratjalan" Then
                            d.Enabled = False
                            'Else
                            '    d.Enabled = True
                            'End If

                    End Select
                Next
            End If

            If approvedacc = False Then
                Me.locking.TryLocking(id)
            End If

        End If

        'Me.obj_Jurnal_bookdate.Dispose()

    End Sub

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        Dim tbl_Approved As New DataTable
        Dim row_type As DataRow

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
            End Select
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.locking = New clsLockingTransaction(Me._CHANNEL, Me.UserName, Me, Me.ftabMain)
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            Me.uiTrnTerimaBarang_isBackgroudWorker()
            Me.uiTrnTerimaBarang_LoadCombo()
            Me.uiTrnTerimaBarang_LoadStringCollection()

            Me.obj_Itemtype_id.AutoCompleteMode = AutoCompleteMode.Suggest
            Me.obj_Itemtype_id.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.obj_Itemtype_id.AutoCompleteCustomSource = Me.stringCollection

            AddHandler obj_Itemtype_id.Validated, AddressOf obj_itemtype_id_Validated

            Me.InitLayoutUI()

            Me.BindingStop()
            Me.BindingStart()

            Me.uiTrnPenerimaanBarang_NewData()

            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = False
            Me.tbtnQuery.Enabled = False
            Me.tbtnNew.Enabled = False
            Me.tbtnPrint.Enabled = False
            Me.tbtnPrintPreview.Enabled = False

            Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
            Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.cboSearchChannel.SelectedValue = Me._CHANNEL

            ' Tambahan Button di toolstrip
            Me.btnApproved.ToolTipText = "Approved Transaction"
            Me.ToolStrip1.Items.Add(Me.btnApproved)
            Me.btnApproved.Image = Me.ImageList1.Images(0)
            Me.btnApproved.Visible = False

            Me.btnUnApproved.ToolTipText = "UnApproved Transaction"
            Me.ToolStrip1.Items.Add(Me.btnUnApproved)
            Me.btnUnApproved.Image = Me.ImageList1.Images(1)
            Me.btnUnApproved.Visible = False

            Me.btnHome.ToolTipText = "Close"
            Me.ToolStrip1.Items.Add(Me.btnHome)
            Me.btnHome.Image = Me.ImageList1.Images(2)
            Me.btnHome.Visible = False

            Me.ftabMain.Dock = DockStyle.Fill

            If Me._USERTYPE = "acc" Or Me._USERTYPE = "spv" Then
                Me.tbtnNew.Visible = False
            End If

            If Me._USERTYPE = "acc" Then
                Me.pnlClose2.Visible = False
                Me.pnlclose3.Visible = False
                'aji
                'Me.PnlDataMaster.Enabled = False
                Me.chk_Strukturunit_id_pemilik_search.Checked = False
                Me.chk_Strukturunit_id_pemilik_search.Enabled = True
                Me.obj_Strukturunit_id_pemilik_search.SelectedValue = 0
                Me.obj_Strukturunit_id_pemilik_search.Enabled = True
                'suroso ======================================
                'Me.DgvTrnPenerimaanbarangdetil.ReadOnly = True
                'Me.TLTrnPenerimaanBarangDetil.OptionsBehavior.Editable = False
                '==============================================


                'Function: fill data for combo in table temporary
                tbl_Approved.Columns.Add(New DataColumn("value_type", GetType(System.Decimal)))
                tbl_Approved.Columns.Add(New DataColumn("display_type", GetType(System.String)))

                If tbl_Approved.Columns("display_type") IsNot Nothing Then
                    row_type = tbl_Approved.NewRow
                    row_type.Item("value_type") = 0
                    row_type.Item("display_type") = "Not Approved"
                    tbl_Approved.Rows.InsertAt(row_type, 0)
                    row_type = tbl_Approved.NewRow
                    row_type.Item("value_type") = 1
                    row_type.Item("display_type") = "User"
                    tbl_Approved.Rows.InsertAt(row_type, 1)
                    row_type = tbl_Approved.NewRow
                    row_type.Item("value_type") = 2
                    row_type.Item("display_type") = "Spv"
                    tbl_Approved.Rows.InsertAt(row_type, 2)
                    row_type = tbl_Approved.NewRow
                    row_type.Item("value_type") = 3
                    row_type.Item("display_type") = "Acc"
                    tbl_Approved.Rows.InsertAt(row_type, 3)
                End If
                Me.cmb_appuser.DataSource = tbl_Approved
                Me.cmb_appuser.ValueMember = "value_type"
                Me.cmb_appuser.DisplayMember = "display_type"

                Me.cmb_appuser.SelectedValue = 2
                Me.chk_User_search.Checked = True
                Me.chk_User_search.Enabled = False

                'suroso ================
                'Me.DgvTrnPenerimaanbarangdetil.ContextMenuStrip = ContextMenuStrip2
                '=======================
            ElseIf Me._USERTYPE = "spv" Then
                Me.pnlClose2.Visible = True
                Me.pnlClose2.Dock = DockStyle.Fill
                Me.pnlclose3.Visible = True
                Me.pnlclose3.Dock = DockStyle.Fill

                Me.chk_Strukturunit_id_pemilik_search.Checked = True
                Me.chk_Strukturunit_id_pemilik_search.Enabled = False
                Me.obj_Strukturunit_id_pemilik_search.SelectedValue = Me._STRUKTUR_UNIT
                Me.obj_Strukturunit_id_pemilik_search.Enabled = False

                'Function: fill data for combo in table temporary
                tbl_Approved.Columns.Add(New DataColumn("value_type", GetType(System.Decimal)))
                tbl_Approved.Columns.Add(New DataColumn("display_type", GetType(System.String)))

                If tbl_Approved.Columns("display_type") IsNot Nothing Then
                    row_type = tbl_Approved.NewRow
                    row_type.Item("value_type") = 0
                    row_type.Item("display_type") = "Yes"
                    tbl_Approved.Rows.InsertAt(row_type, 0)

                    row_type = tbl_Approved.NewRow
                    row_type.Item("value_type") = 1
                    row_type.Item("display_type") = "No"
                    tbl_Approved.Rows.InsertAt(row_type, 1)
                End If

                Me.cmb_appuser.DataSource = tbl_Approved
                Me.cmb_appuser.ValueMember = "value_type"
                Me.cmb_appuser.DisplayMember = "display_type"

                Me.tbtnNew.Visible = False
                Me.tbtnSave.Visible = False
                Me.tbtnDel.Visible = False
                Me.tbtnRefresh.Visible = False

                'suroso ======================
                'Me.DgvTrnPenerimaanbarangdetil.ContextMenuStrip = ContextMenuStrip1
                '=============================
            Else
                Me.pnlClose2.Visible = True
                Me.pnlClose2.Dock = DockStyle.Fill
                Me.pnlclose3.Visible = True
                Me.pnlclose3.Dock = DockStyle.Fill

                Me.chk_Strukturunit_id_pemilik_search.Checked = True
                Me.chk_Strukturunit_id_pemilik_search.Enabled = False
                Me.obj_Strukturunit_id_pemilik_search.SelectedValue = Me._STRUKTUR_UNIT
                Me.obj_Strukturunit_id_pemilik_search.Enabled = False

                'Function: fill data for combo in table temporary
                tbl_Approved.Columns.Add(New DataColumn("value_type", GetType(System.Decimal)))
                tbl_Approved.Columns.Add(New DataColumn("display_type", GetType(System.String)))

                If tbl_Approved.Columns("display_type") IsNot Nothing Then
                    row_type = tbl_Approved.NewRow
                    row_type.Item("value_type") = 0
                    row_type.Item("display_type") = "Yes"
                    tbl_Approved.Rows.InsertAt(row_type, 0)

                    row_type = tbl_Approved.NewRow
                    row_type.Item("value_type") = 1
                    row_type.Item("display_type") = "No"
                    tbl_Approved.Rows.InsertAt(row_type, 1)
                End If

                Me.cmb_appuser.DataSource = tbl_Approved
                Me.cmb_appuser.ValueMember = "value_type"
                Me.cmb_appuser.DisplayMember = "display_type"

                'suroso ======================
                'Me.DgvTrnPenerimaanbarangdetil.ContextMenuStrip = ContextMenuStrip1
                '=============================
            End If
        End If

    End Sub

    Private Sub uiTrnPenerimaanBarang_FormBeforeOpenRow(ByRef id As Object, ByRef CancelOpenRow As Boolean) Handles Me.FormBeforeOpenRow
        If Me._USERTYPE = "acc" Then
            If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appuser", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0, 0) Or _
                            clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appspv", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0, 0) Then
                MsgBox("You do not have the authority to open this data")
                Me.ftabMain.SelectedIndex = 0
                Me.Cursor = Cursors.Arrow

                CancelOpenRow = True
            End If
        End If
    End Sub

    Private Sub uiTrnPenerimaanBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged
        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.btnNewClick = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

                If Me._USERTYPE = "user" Then
                    If Me.DgvTrnPenerimaanbarang.CurrentRow IsNot Nothing Then
                        If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_appuser").Value, False) = True Then
                            Me.btnApproved.Enabled = False
                            Me.btnUnApproved.Enabled = True
                        Else
                            Me.btnApproved.Enabled = True
                            Me.btnUnApproved.Enabled = False
                        End If

                        Me.btnApproved.Visible = True
                        Me.btnUnApproved.Visible = True
                    Else
                        Me.btnApproved.Visible = False
                        Me.btnUnApproved.Visible = False
                    End If
                ElseIf Me._USERTYPE = "spv" Or Me._USERTYPE = "acc" Then
                    Me.btnApproved.Visible = False
                    Me.btnUnApproved.Visible = False
                End If
            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White
                Me.objFormError.Clear()

                If Me.btnNewClick = False Then
                    If Me.DgvTrnPenerimaanbarang.CurrentRow IsNot Nothing Then
                        Me.uiTrnPenerimaanBarang_OpenRow(Me.DgvTrnPenerimaanbarang.CurrentRow.Index)
                    Else
                        Me.uiTrnPenerimaanBarang_NewData()
                    End If

                    Me.ftabDataDetil.SelectedIndex = 2

                    Me.ftabDataDetil.SelectedIndex = 0
                End If
        End Select
    End Sub

    Private Sub DgvTrnPenerimaanbarang_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnPenerimaanbarang.CellDoubleClick
        If Me.DgvTrnPenerimaanbarang.CurrentRow IsNot Nothing Then
            If Me._USERTYPE = "acc" Then
                If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appuser", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0, 0) Or _
                                clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appspv", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0, 0) Then
                    MsgBox("You do not have the authority to open this data")
                    Me.ftabMain.SelectedIndex = 0
                    Exit Sub
                End If
            End If
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub uiTrnTerimaBarang_LoadStringCollection()
        Dim tipeitem_id As String

        For Each row As DataRow In Me.tbl_MstTipeitem.Rows
            tipeitem_id = row.Item("tipeitem_id")

            Me.stringCollection.Add(tipeitem_id)
        Next
    End Sub

    Private Sub uiTrnTerimaBarang_LoadCombo()
        Dim oDataFiller As New clsDataFiller(Me.DSNFrm)

        If Me._LOADCOMBOSEARCH = False Then
            '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", tbl_MstChannel_search, "as_MstChannel_select", " channel_id = '" & Me._CHANNEL & "' ", "")

            Me.ComboFill(Me.obj_Currency_id, "currency_id", "currency_shortname", tbl_MstCurrency, "ms_MstCurrency_Select", "Currency_active = 1", "")
            Dim CurrDetil As Boolean
            Me.tbl_MstCurrencyDataDetil = Me.tbl_MstCurrency.Copy
            CurrDetil = ComboFillFromDataTable(Me.obj_Currency_iddetil, "currency_id", "currency_shortname", tbl_MstCurrencyDataDetil)
            Me.tbl_MstCurrencyDataDetil.DefaultView.Sort = "currency_shortname"
            Me.tbl_MstCurrencyDetil = Me.tbl_MstCurrency.Copy

            oDataFiller.DataFillForCombo("currency_id", "currency_shortname", Me.tbl_MstCurrencyGrid, "ms_MstCurrency_Select", " Currency_active = 1 ")

            Me.ComboFill(Me.obj_Strukturunit_id_pemilik_search, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunit_search, "ms_MstStrukturUnit_Select", "", "")
            Me.tbl_MstStrukturunitGrid = tbl_MstStrukturunit_search.Copy
            'tambahan
            'Me.ComboFillAsset(Me.obj_Assetcategory_id, "kategoriasset_id", "kategoriasset_id", Me.tbl_mstKategoriAssetDetil, "as_MstTipeAssetKategori_Select", " ")

            Me.ComboFillAsset(Me.obj_Assettype_id, "tipeasset_id", "tipeasset_id", Me.tbl_MstTipeAssetDetil, "as_MstTipeasset_Select", " ")
            Me.tbl_MstTipeAsset = Me.tbl_MstTipeAssetDetil.Copy

            Me.ComboFill(Me.obj_Item_id, "item_id", "item_name", Me.tbl_MstItemDetil, "ms_MstItem_Select", " ")
            Me.tbl_MstItem = Me.tbl_MstItemDetil.Copy

            Me.ComboFill(Me.obj_Itemcategory_id, "category_id", "category_name", Me.tbl_MstItemCategoryDetil, "ms_MstItemCategory_Select", " ")
            Me.tbl_MstItemCategory = Me.tbl_MstItemCategoryDetil.Copy

            Me.ComboFillAngka(Me.DSNFrm, Me.obj_Brand_id, "merk_id", "merk_name", Me.tbl_MstBrandDetil, "as_MstMerk_Select", " merk_active = 1 ")
            Me.tbl_MstBrand = Me.tbl_MstBrandDetil.Copy

            Using filler As New clsDataFiller(Me.DSNFrm)
                filler.DataFill(tbl_MstTipeitem, "as_MstTipeitem_Select", "")
                'TAMBAHAN
                filler.DataFillForCombo("kategoriasset_id", "kategoriasset_id", Me.tbl_mstKategoriAsset, "as_MstKategoriasset_Select", "")
                filler.DataFill(Me.tbl_MstKategoriAssetDepre, "as_MstKategoriassetdepre_Select", "")
            End Using

            Me.obj_Terimabarangdetil_golfiskal.DataSource = Me.tbl_MstKategoriAssetDepre
            Me.obj_Terimabarangdetil_golfiskal.ValueMember = "kategoriassetdepre_id"
            Me.obj_Terimabarangdetil_golfiskal.DisplayMember = "kategoriassetdepre_descr"

            Me.ComboFillAsset(Me.obj_Material_id, "Material_id", "Material_id", Me.tbl_MstMaterialDetil, "as_MstMaterial_Select", " ")
            Me.tbl_MstMaterial = Me.tbl_MstMaterialDetil.Copy

            Me.ComboFillAsset(Me.obj_Colour_id, "warna_id", "warna_id", Me.tbl_MstWarnaDetil, "as_MstWarna_Select", " ")
            Me.tbl_MstWarna = Me.tbl_MstWarnaDetil.Copy

            Me.ComboFillAsset(Me.obj_Size_id, "ukuran_id", "ukuran_id", Me.tbl_MstUkuranDetil, "AS_MstUkuran_Select", " ")
            Me.tbl_MstUkuran = Me.tbl_MstUkuranDetil.Copy

            Me.ComboFillAsset(Me.obj_Sex_id, "Pilihan", "Pilihan", Me.tbl_MstsexDetil, "as_MstPilihan_Select", " Kategori = 'MstsexAsset' and is_disable = 0 ")
            Me.tbl_Mstsex = Me.tbl_MstsexDetil.Copy

            oDataFiller.ComboFillCharASSET(Me.DSNFrm, Me.obj_Room_id, "ruang_id", "keterangan", Me.tbl_MstAssetruangDetil, "as_MstRuangAsset_Select", " ", Me._CHANNEL)
            Me.tbl_MstAssetruang = Me.tbl_MstAssetruangDetil.Copy

            Me.ComboFillAngka(Me.DSNFrm, Me.obj_Unit_id, "unit_id", "unit_shortname", Me.tbl_MstUnitDetil, "AS_MstUnit_Select", " unit_active = 1 ")
            Me.tbl_MstUnit = Me.tbl_MstUnitDetil.Copy

            oDataFiller.ComboFillChar(Me.obj_Show_id, "show_id", "show_title", Me.tbl_MstShowDetil, "ms_MstShow_Select", " channel_id = '" & Me._CHANNEL & "' ")
            Dim ShowDetil As Boolean
            Me.tbl_MstShowcontDetil = Me.tbl_MstShowDetil.Copy
            ShowDetil = ComboFillFromDataTable(Me.obj_Show_id_cont, "show_id", "show_title", tbl_MstShowcontDetil)
            Me.tbl_MstShowcontDetil.DefaultView.Sort = "show_title"
            Me.tbl_MstShow = Me.tbl_MstShowDetil.Copy

            Me.ComboFill(Me.obj_Acc_id, "acc_id", "acc_nameshort", Me.tbl_MstAccGridDetil, "ms_MstAccountCombo_Select", " ")
            oDataFiller.DataFillForCombo("acc_id", "acc_nameshort", Me.tbl_MstAccGrid, "ms_MstAccountCombo_Select", "") '"acc_isdisabled = 0")

            Me.ComboFill(Me.cbo_periode, "periode_id", "periode_name", Me.tbl_MstPeriodeCombo, "ms_MstPeriodeCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
            Me.tbl_MstPeriodeCombo.DefaultView.Sort = "periode_name"

            Me.tbl_MstShowcont = Me.tbl_MstShowDetil.Copy

            Me.tbl_MstCurrency.DefaultView.Sort = "Currency_shortname"
            Me.tbl_MstCurrencyDetil.DefaultView.Sort = "Currency_shortname"
            Me.tbl_MstCurrencyGrid.DefaultView.Sort = "Currency_shortname"
            Me.tbl_MstAccGrid.DefaultView.Sort = "acc_nameshort"
            Me.tbl_MstStrukturunit_search.DefaultView.Sort = "strukturunit_name"

            Me.tbl_mstKategoriAsset.DefaultView.Sort = "kategoriasset_id"
            Me.tbl_MstTipeAsset.DefaultView.Sort = "tipeasset_id"
            Me.tbl_MstItem.DefaultView.Sort = "item_name"
            Me.tbl_MstItemDetil.DefaultView.Sort = "item_name"
            Me.tbl_MstItemCategory.DefaultView.Sort = "category_name"
            Me.tbl_MstItemCategoryDetil.DefaultView.Sort = "category_name"
            Me.tbl_MstBrand.DefaultView.Sort = "merk_name"
            Me.tbl_MstBrandDetil.DefaultView.Sort = "merk_name"
            Me.tbl_msttipeitem.DefaultView.Sort = "tipeitem_id"
            Me.tbl_Mstmaterial.DefaultView.Sort = "Material_id"

            Me.tbl_Mstwarna.DefaultView.Sort = "warna_id"
            Me.tbl_MstUkuran.DefaultView.Sort = "ukuran_id"
            Me.tbl_Mstsex.DefaultView.Sort = "Pilihan"
            Me.tbl_MstAssetruang.DefaultView.Sort = "keterangan"
            Me.tbl_MstUnit.DefaultView.Sort = "unit_shortname"
            Me.tbl_MstUnitDetil.DefaultView.Sort = "unit_shortname"
            Me.tbl_MstShow.DefaultView.Sort = "show_title"
            Me.tbl_MstShowcont.DefaultView.Sort = "show_title"

            Me._LOADCOMBOSEARCH = True
        End If
    End Sub

#Region "mencoba tuning (yanuar)"

#Region " Untuk BackgroundWorker"
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim BG_Worker As BackgroundWorker = CType(sender, BackgroundWorker)
        ' ''Dim AddToComboSearch As System.Delegate = New delegate_UpdateUI(AddressOf uiTrnSalesOrder_CollectionData_with_BackgroundWorker)
        If BG_Worker.CancellationPending Then
            e.Cancel = True
        Else
            Me.uiTrnTerimabarang_CollectionData_with_BackgroundWorker(BG_Worker)
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Me.obj_ProgressBar_backGroundWorker.Value = e.ProgressPercentage
        Me.lblLoading.Text = "Please Wait... Loading data " & Me.label_thread & "..."
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'Untuk Finishing BackgroundWorker
        Me.obj_ProgressBar_backGroundWorker.Visible = False
        Me.lblLoading.Visible = False
        Me.Panel1.Visible = False

        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Or (tsItem.Name = "tbtnSave") Or (tsItem.Name = "tbtnDel") Then
                tsItem.Enabled = False
            Else
                tsItem.Enabled = True
            End If
        Next

        Me.FormatDgvTrnJurnaldetil(Me.DgvTrnJurnaldetil)
        Me.FormatDgvTrnJurnaldetil(Me.DgvTrnJurnaldetil_Pembayaran)

        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub uiTrnTerimabarang_newBackgroundWorker()
        Me.BackgroundWorker1 = New BackgroundWorker
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub uiTrnTerimabarang_CollectionData_with_BackgroundWorker(ByVal worker As BackgroundWorker)
        Dim oDataFiller As New clsDataFiller(Me.DSNFrm)
        worker.WorkerReportsProgress = True

        Me.label_thread = "Partner"
        worker.ReportProgress(0)
        Me.ComboFill(Me.obj_Rekanan_id, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "ms_MstRekanan_Select2", Me._CHANNEL) '"ms_MstRekananCombo_Select", "")
        Me.tbl_MstRekananGrid = Me.tbl_MstRekanan.Copy
        Me.tbl_MstRekanan_search = Me.tbl_MstRekanan.Copy
        Me.tbl_MstRekananGrid.DefaultView.Sort = "rekanan_name"
        Me.tbl_MstRekanan_search.DefaultView.Sort = "rekanan_name"

        worker.ReportProgress(30)
        Me.label_thread = "Employee"
        oDataFiller.ComboFillCharASSET(Me.DSNFrm, Me.obj_Employee_id_owner, "employee_id", "employee_namalengkap", Me.Tbl_Mstemployee, "ms_MstEmployee_Select", " ")
        Me.Tbl_Mstemployee.DefaultView.Sort = "employee_namalengkap"

        worker.ReportProgress(60)
        Me.label_thread = "Budget"
        ComboFill(obj_Budget_id, "budget_id", "budget_nameshort", tbl_TrnBudget, "ms_MstBudgetCombo_Select", "budget_isactive = 1  and channel_id = '" & Me._CHANNEL & "' ")
        Me.tbl_TrnBudget.DefaultView.Sort = "budget_nameshort"


        '====================tambahan PTS 20140103======================
        Me.label_thread = "Channel Number"
        worker.ReportProgress(85)
        Dim tbl_MstChannelnumber As New DataTable
        tbl_MstChannelnumber.Clear()
        Me.DataFill(tbl_MstChannelnumber, "ms_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "' ")

        Me.channel_number = tbl_MstChannelnumber.Rows(0).Item("channel_number").ToString
        '==================================================================

        worker.ReportProgress(100)
    End Sub

    Private Sub uiTrnTerimaBarang_isBackgroudWorker()
        Me.Cursor = Cursors.WaitCursor
        If Me.isBackGroundWorker_isWork = False Then
            Me.isBackGroundWorker_isWork = True
            If Me.isBackgroundWorker = False Then

                Me.Panel1.Visible = True
                Me.obj_ProgressBar_backGroundWorker.Value = 0
                Me.obj_ProgressBar_backGroundWorker.Visible = True
                Me.lblLoading.Visible = True

                If Me.BackgroundWorker1.IsBusy Then
                    Me.BackgroundWorker1.Dispose()
                    Me.uiTrnTerimabarang_newBackgroundWorker()
                Else
                    Me.BackgroundWorker1.RunWorkerAsync()
                End If
                Me.isBackgroundWorker = True
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

#End Region

    Private Sub btn_Rekanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Rekanan.Click
        Dim rekanan_id As String
        Dim dlg As dlgSearch = New dlgSearch()
        Dim retData As String
        retData = dlg.OpenDialog(Me, Me.tbl_MstRekanan.Copy, "rekanan")
        rekanan_id = retData

        If rekanan_id IsNot Nothing Then
            Me.obj_Rekanan_id_search.Text = rekanan_id
        End If
    End Sub

    Private Sub btn_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_order.Click
        If Me.tbl_TrnPenerimaanbarangdetil.Rows.Count = 0 Then
            If Me._MODULE_TYPE = ModuleType.PURCHASE Then
                Dim dlg As dlgTrnPenerimaanBarang_Select_Purchase = New dlgTrnPenerimaanBarang_Select_Purchase(Me.DSNFrm, Me.obj_Rekanan_id.SelectedValue, Me.tbl_MstRekanan.Copy, Me._STRUKTUR_UNIT)

                Dim retObj As Object
                Dim retData As Collection
                Dim tblH As DataTable

                retObj = dlg.OpenDialog(Me, Me.obj_Channel_id.Text, "Purchase")

                If retObj IsNot Nothing Then
                    '======= ADD PTS 20130906 ==============
                    Dim row As DataRow = CType(dlg.DgvRentalOrder.CurrentRow.DataBoundItem, DataRowView).Row
                    '=======================================
                    Dim tempRow As DataRow = CType(Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).Current, DataRowView).Row

                    retData = CType(retObj, Collection)
                    tblH = CType(retData.Item("tblH"), DataTable)

                    Me.obj_Budget_id.SelectedValue = clsUtil.IsDbNull(tblH.Rows(0).Item("budget_id"), 0)
                    Me.obj_Rekanan_id.SelectedValue = clsUtil.IsDbNull(tblH.Rows(0).Item("rekanan_id"), 0)
                    Me.obj_Order_id.Text = clsUtil.IsDbNull(tblH.Rows(0).Item("order_id"), String.Empty)
                    Me.obj_Terimabarang_notes.Text = clsUtil.IsDbNull(tblH.Rows(0).Item("order_descr"), String.Empty)

                    '====== Add 20130906 =============
                    Dim filltable As clsDataFiller = New clsDataFiller(Me.DSNFrm)
                    Dim tbl_currency_orderGhost As DataTable = New DataTable
                    tbl_currency_orderGhost.Clear()
                    filltable.DataFill(tbl_currency_orderGhost, "as_TrnOrder_Select", "order_id = '" & row.Item("order_id").ToString & "'")
                    tempRow.Item("currency_id") = tbl_currency_orderGhost.Rows(0).Item("currency_id")
                    Me.obj_Currency_id.SelectedValue = tbl_currency_orderGhost.Rows(0).Item("currency_id")
                    '=====================================

                    '== Mendapatkan rate ==================
                    Dim rate As Object = New clsMstRate(Me.DSNFrm).GetRate(Me.obj_Terimabarang_date.Text, Me.obj_Currency_id.Text)

                    If rate Is Nothing OrElse rate Is DBNull.Value Then
                        rate = New clsTrnOrder(Me.DSNFrm).GetRateFromDetail(Me.obj_Order_id.Text)
                    End If

                    tempRow.Item("terimabarang_foreignrate") = rate

                    '======================================
                End If
            ElseIf Me._MODULE_TYPE = ModuleType.LISTPV Then
                Dim dlg As New dlgTrnPenerimaanBarang_Select_PV(Me.obj_Order_id.Text, Me.DSNFrm)

                If dlg.ShowDialog() = DialogResult.OK Then
                    Dim row As DataRow = CType(dlg.DgvPV.CurrentRow.DataBoundItem, DataRowView).Row
                    Dim tempRow As DataRow = CType(Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).Current, DataRowView).Row

                    Me.obj_Order_id.Text = row.Item("jurnal_id").ToString()
                    tempRow.Item("currency_id") = row.Item("currency_id")
                End If
            ElseIf Me._MODULE_TYPE = ModuleType.LISTGQ Then
                Me.Cursor = Cursors.WaitCursor

                Dim dlg As dlgTrnPenerimaanBarang_Select_Header_GQ = New dlgTrnPenerimaanBarang_Select_Header_GQ(Me.DSNFrm,
                                                                                Me._CHANNEL, Me._STRUKTUR_UNIT, clsTrnRequest.Objective.Wardrobe)

                If dlg.ShowDialog() = DialogResult.OK Then
                    Dim tempRow As DataRow = CType(Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).Current, DataRowView).Row
                    Dim rowResult As DataRow = CType(dlg.DgvTrnRequest.CurrentRow.DataBoundItem, DataRowView).Row

                    Me.obj_Budget_id.SelectedValue = clsUtil.IsDbNull(rowResult.Item("budget_id"), 0)
                    Me.obj_Order_id.Text = rowResult.Item("request_id")
                    tempRow.Item("currency_id") = 1
                    tempRow.Item("terimabarang_foreignrate") = 1
                End If

                Cursor = Cursors.Default
            End If
        Else
            MsgBox("Maaf, sudah ada satu atau lebih item dari " & Me.obj_Order_id.Text & " yang sudah ditarik", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub uiTrnPenerimaanBarang_AddItemOrder()
        Dim dlg As dlgTrnPenerimaanBarangDetil_Select_Purchase = New dlgTrnPenerimaanBarangDetil_Select_Purchase()

        Dim retObj As Object
        Dim retData As Collection
        Dim tblDetil As DataTable
        Dim row_index As Integer
        Dim qty_order As Integer
        Dim order_line As String = String.Empty
        Dim i, j, k As Integer
        Dim line As String = String.Empty
        Dim tbl_order As DataTable = New DataTable

        For i = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
            If order_line = String.Empty Then
                order_line = Me.tbl_TrnPenerimaanbarangdetil.Rows(i).Item("orderdetil_line")
            Else
                order_line &= ", " & Me.tbl_TrnPenerimaanbarangdetil.Rows(i).Item("orderdetil_line")
            End If
        Next

        If order_line <> String.Empty Then
            order_line = "(" & order_line & ")"
        End If

        retObj = dlg.OpenDialog(Me, Me.obj_Channel_id.Text, Me.DSNFrm, Me.obj_Order_id.Text, order_line)

        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            tblDetil = CType(retData.Item("tblDetil"), DataTable)

            Dim row As DataRow
            Dim tempRow As DataRow = CType(Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).Current, DataRowView).Row

            For row_index = 0 To tblDetil.Rows.Count - 1
                Dim ppnAmount As Decimal
                Dim ppnAmountIDR As Decimal
                Dim pphAmount As Decimal
                Dim pphAmountIDR As Decimal
                Dim totalAmount As Decimal
                Dim totalAmountIDR As Decimal

                row = Me.tbl_TrnPenerimaanbarangdetil.NewRow
                row.Item("terimabarangdetil_desc") = tblDetil.Rows(row_index).Item("orderdetil_descr")
                ' row.Item("terimabarangdetil_date") = Now.Date
                row.Item("terimabarangdetil_qty") = tblDetil.Rows(row_index).Item("po_outstanding")
                row.Item("terimabarangdetil_qtytotal") = tblDetil.Rows(row_index).Item("po_outstanding") * row.Item("terimabarangdetil_qty")
                row.Item("order_id") = tblDetil.Rows(row_index).Item("order_id")
                row.Item("orderdetil_line") = tblDetil.Rows(row_index).Item("orderdetil_line")
                row.Item("item_id") = tblDetil.Rows(row_index).Item("item_id")
                row.Item("itemcategory_id") = tblDetil.Rows(row_index).Item("category_id")
                row.Item("brand_id") = 0
                row.Item("budget_id") = tblDetil.Rows(row_index).Item("budget_id")
                row.Item("budgetdetil_id") = tblDetil.Rows(row_index).Item("budgetdetil_id")
                row.Item("terimabarangdetil_foreign") = tblDetil.Rows(row_index).Item("orderdetil_foreign")
                row.Item("currency_id") = tblDetil.Rows(row_index).Item("currency_id")

                If row.Item("currency_id") > 1 Then
                    If tempRow.Item("terimabarang_foreignrate") = 0 Then
                        row.Item("terimabarangdetil_foreignrate") = tblDetil.Rows(row_index).Item("orderdetil_foreignrate")
                    Else
                        row.Item("terimabarangdetil_foreignrate") = tempRow.Item("terimabarang_foreignrate")
                    End If
                Else
                    row.Item("terimabarangdetil_foreignrate") = 1
                End If

                row.Item("terimabarangdetil_idrreal") = row.Item("terimabarangdetil_foreignrate") * tblDetil.Rows(row_index).Item("orderdetil_foreign")
                row.Item("terimabarangdetil_pphpercent") = tblDetil.Rows(row_index).Item("orderdetil_pphpercent")
                row.Item("terimabarangdetil_ppnpercent") = tblDetil.Rows(row_index).Item("orderdetil_ppnpercent")
                row.Item("terimabarangdetil_disc") = tblDetil.Rows(row_index).Item("orderdetil_discount")

                pphAmount = ((clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0)) _
                                                   * (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_pphpercent"), 0) / 100)

                pphAmountIDR = ((clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0)) _
                                                   * (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_pphpercent"), 0) / 100) * (clsUtil.IsDbNull(row.Item("terimabarangdetil_foreignrate"), 0))

                ppnAmount = ((clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0)) _
                                                   * (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_ppnpercent"), 0) / 100)

                ppnAmountIDR = ((clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0)) _
                                                   * (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_ppnpercent"), 0) / 100) * (clsUtil.IsDbNull(row.Item("terimabarangdetil_foreignrate"), 0))

                totalAmount = ((clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0)) _
                            - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                totalAmountIDR = (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(row.Item("terimabarangdetil_foreignrate"), 0) * _
                                  clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0) - _
                                clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                If tblDetil.Rows(row_index).Item("currency_id") = 1 Then
                    row.Item("terimabarangdetil_pphforeign") = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                    row.Item("terimabarangdetil_ppnforeign") = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                    row.Item("terimabarangdetil_totalforeign") = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
                Else
                    row.Item("terimabarangdetil_pphforeign") = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                    row.Item("terimabarangdetil_ppnforeign") = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                    row.Item("terimabarangdetil_totalforeign") = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)
                End If

                row.Item("terimabarangdetil_pphidrreal") = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                row.Item("terimabarangdetil_ppnidrreal") = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                row.Item("terimabarangdetil_totalidrreal") = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)
                row.Item("show_id") = ""
                row.Item("show_id_cont") = ""
                row.Item("room_id") = ""
                row.Item("unit_id") = clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("unit_id"), 0)
                row.Item("terimabarangdetil_product_no") = "Label"

                Me.tbl_TrnPenerimaanbarangdetil.Rows.Add(row)

                qty_order += clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_qty"), 0)
            Next

            For k = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
                If line = String.Empty Then
                    line = Me.tbl_TrnPenerimaanbarangdetil.Rows(k).Item("orderdetil_line")
                Else
                    line &= ", " & Me.tbl_TrnPenerimaanbarangdetil.Rows(k).Item("orderdetil_line")
                End If
            Next

            tbl_order.Clear()
            qty_order = 0

            Me.DataFill(tbl_order, "pr_TrnOrderdetil_Select", String.Format(" order_id = '{0}'", Me.obj_Order_id.Text))


            Dim orderLine() As DataRow = tbl_order.Select(String.Format("orderdetil_line in({0})", line))

            For j = 0 To orderLine.Length - 1
                qty_order += clsUtil.IsDbNull(orderLine(j).Item("orderdetil_qty"), 0) * clsUtil.IsDbNull(orderLine(j).Item("orderdetil_days"), 0)
            Next

            Me.obj_Terimabarang_qtyitem.Text = Me.tbl_TrnPenerimaanbarangdetil.Rows.Count
            Me.obj_Order_qty.Text = qty_order

            Me.obj_Terimabarang_foreignrate.Text = ""
        End If
    End Sub

    Private Sub uiTrnPenerimaanBarang_AddItemOrderPV()
        Dim pv_id As String = Me.obj_Order_id.Text
        Dim jurnal As New clsTrnJurnal()
        Dim tblPV As DataTable = clsDataset.CreateTblTrnJurnaldetil()
        Dim rowPV As DataRow
        Dim currency_id As Decimal
        Dim foreign_rate As Decimal
        Dim budget_id As Decimal
        Dim budgetdetil_id As Decimal
        Dim criteria As String
        Dim row As DataRow
        Dim index As Integer
        Dim line As Integer

        Try
            criteria = String.Format(" jurnal_id = '{0}' and acc_id like '{1}%' and jurnaldetil_dk = 'D'", Me.obj_Order_id.Text, 1161)
            jurnal.RetrieveDetail(tblPV, criteria, Me._CHANNEL, Me.DSNFrm)

            If tblPV.Rows.Count > 0 Then
                rowPV = tblPV.Rows(0)

                currency_id = rowPV.Item("currency_id")
                foreign_rate = rowPV.Item("jurnaldetil_foreignrate")
                budget_id = rowPV.Item("budget_id")
                budgetdetil_id = rowPV.Item("budgetdetil_id")

                row = Me.tbl_TrnPenerimaanbarangdetil.NewRow()
                row.Item("item_id") = ""
                row.Item("itemcategory_id") = ""
                row.Item("currency_id") = 1
                row.Item("terimabarangdetil_product_no") = "Label"
                row.Item("currency_id") = currency_id
                row.Item("terimabarangdetil_foreignrate") = foreign_rate
                row.Item("budget_id") = budget_id
                row.Item("budgetdetil_id") = budgetdetil_id
                row.Item("acc_id") = rowPV.Item("acc_id")
                row.Item("order_id") = rowPV.Item("jurnal_id")
                row.Item("orderdetil_line") = rowPV.Item("jurnaldetil_line")

                Me.tbl_TrnPenerimaanbarangdetil.Rows.Add(row)

                line = row.Item("terimabarangdetil_line")

                For Each viewNode As TreeListNode In Me.TLTrnPenerimaanBarangDetil.Nodes
                    If viewNode.Item("terimabarangdetil_line") = line Then
                        index = TLTrnPenerimaanBarangDetil.Nodes.IndexOf(viewNode)
                    End If
                Next

                Me.BindingContext(Me.tbl_TrnPenerimaanbarangdetil).Position = index
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub uiTrnPenerimaanBarang_AddItemOrderManual()
        Dim row As DataRow = Me.tbl_TrnPenerimaanbarangdetil.NewRow()
        Dim index As Integer
        Dim line As Integer

        row.Item("item_id") = ""
        row.Item("itemcategory_id") = ""
        row.Item("currency_id") = 1
        row.Item("terimabarangdetil_foreignrate") = 1
        row.Item("terimabarangdetil_product_no") = "Label"

        Me.tbl_TrnPenerimaanbarangdetil.Rows.Add(row)

        line = row.Item("terimabarangdetil_line")

        For Each viewNode As TreeListNode In Me.TLTrnPenerimaanBarangDetil.Nodes
            If viewNode.Item("terimabarangdetil_line") = line Then
                index = TLTrnPenerimaanBarangDetil.Nodes.IndexOf(viewNode)
            End If
        Next

        Me.BindingContext(Me.tbl_TrnPenerimaanbarangdetil).Position = index
    End Sub

    Private Sub uiTrnPenerimaanBarang_AddItemOrderGQ()
        Dim dlg As dlgTrnPenerimaanBarang_Select_Detil_GQ = New dlgTrnPenerimaanBarang_Select_Detil_GQ(Me.DSNFrm,
                                                                    Me.obj_Order_id.Text, clsTrnRequest.Objective.Wardrobe)

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim dataSelected As DataRow() = CType(dlg.DgvTrnRequest.DataSource, DataTable).Select("col_pilih = 'True'", "")
            Dim qty As Integer
            Dim assetType As String
            Dim newRow As DataRow

            For Each rowSelected As DataRow In dataSelected
                qty = rowSelected.Item("qty")
                assetType = rowSelected.Item("asset_type")

                If assetType.Trim = "Consumable" Then
                    newRow = Me.tbl_TrnPenerimaanbarangdetil.NewRow

                    newRow.Item("terimabarangdetil_desc") = rowSelected.Item("requestdetil_descr")
                    newRow.Item("terimabarangdetil_date") = Now.Date
                    newRow.Item("order_id") = rowSelected.Item("request_id")
                    newRow.Item("orderdetil_line") = rowSelected.Item("requestdetil_line")
                    newRow.Item("terimabarangdetil_type") = Me._MODULE_TYPE.ToString()
                    newRow.Item("item_id") = rowSelected.Item("item_id")
                    newRow.Item("itemcategory_id") = rowSelected.Item("category_id")
                    newRow.Item("currency_id") = 1
                    newRow.Item("terimabarangdetil_foreignrate") = 1
                    newRow.Item("terimabarangdetil_product_no") = "Label"
                    newRow.Item("terimabarangdetil_qty") = rowSelected.Item("qty")
                    newRow.Item("terimabarangdetil_qtydetail") = 1
                    newRow.Item("terimabarangdetil_qtytotal") = newRow.Item("terimabarangdetil_qty") * newRow.Item("terimabarangdetil_qtydetail")
                    newRow.Item("unit_id") = 1
                    newRow.Item("assettype_id") = rowSelected.Item("asset_type")
                    newRow.Item("budget_id") = rowSelected.Item("budget_id")
                    newRow.Item("budgetdetil_id") = rowSelected.Item("budgetdetil_id")
                    newRow.Item("show_id") = rowSelected.Item("request_acara")
                    newRow.Item("acc_id") = "1152431"

                    Me.tbl_TrnPenerimaanbarangdetil.Rows.Add(newRow)
                Else
                    For i As Integer = 1 To qty
                        newRow = Me.tbl_TrnPenerimaanbarangdetil.NewRow

                        newRow.Item("terimabarangdetil_desc") = rowSelected.Item("requestdetil_descr")
                        newRow.Item("terimabarangdetil_date") = Now.Date
                        newRow.Item("order_id") = rowSelected.Item("request_id")
                        newRow.Item("orderdetil_line") = rowSelected.Item("requestdetil_line")
                        newRow.Item("terimabarangdetil_type") = Me._MODULE_TYPE.ToString()
                        newRow.Item("item_id") = rowSelected.Item("item_id")
                        newRow.Item("itemcategory_id") = rowSelected.Item("category_id")
                        newRow.Item("currency_id") = 1
                        newRow.Item("terimabarangdetil_foreignrate") = 1
                        newRow.Item("terimabarangdetil_product_no") = "Label"
                        newRow.Item("terimabarangdetil_qty") = 1
                        newRow.Item("terimabarangdetil_qtydetail") = 1
                        newRow.Item("terimabarangdetil_qtytotal") = 1
                        newRow.Item("unit_id") = 1
                        newRow.Item("assettype_id") = rowSelected.Item("asset_type")
                        newRow.Item("budget_id") = rowSelected.Item("budget_id")
                        newRow.Item("budgetdetil_id") = rowSelected.Item("budgetdetil_id")
                        newRow.Item("show_id") = rowSelected.Item("request_acara")
                        newRow.Item("acc_id") = "1152431"

                        Me.tbl_TrnPenerimaanbarangdetil.Rows.Add(newRow)
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub Btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Add.Click
        Select Case Me._MODULE_TYPE
            Case ModuleType.PURCHASE
                Me.uiTrnPenerimaanBarang_AddItemOrder()
            Case ModuleType.MANUAL
                If Me.obj_Terimabarang_id.Text = "" Then
                    If Me._USERTYPE = "acc" Then
                        Me.uiTrnPenerimaanBarang_Purchase_JurnalSave()
                    End If

                    Me.uiTrnPenerimaanBarang_Save()
                End If

                Me.uiTrnPenerimaanBarang_AddItemOrderManual()
            Case ModuleType.LISTPV
                If Me.obj_Order_id.Text.Trim = "" Then
                    MsgBox("PV Number tidak boleh kosong.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                Me.uiTrnPenerimaanBarang_AddItemOrderPV()
            Case ModuleType.LISTGQ
                If Me.uiTrnPenerimaanbarang_FormChanges() Then
                    Exit Sub
                End If

                Me.uiTrnPenerimaanBarang_AddItemOrderGQ()
        End Select
    End Sub

    Private Function uiTrnPenerimaanBarang_FormErrorValidasi() As Boolean
        Dim message As String = ""

        Try
            Dim i As Integer
            Dim cell_typeasset_id, cell_categoryasset_id As Object
            Dim dgv_error, row_error As Boolean

            
            row_error = False

            For i = 0 To Me.TLTrnPenerimaanBarangDetil.Nodes.Count - 1
                cell_typeasset_id = Me.TLTrnPenerimaanBarangDetil.Nodes(i).Item("assettype_id")
                cell_categoryasset_id = Me.TLTrnPenerimaanBarangDetil.Nodes(i).Item("assetcategory_id")

                message = "Asset type can't be empty"
                If cell_typeasset_id = "-- PILIH --" Or cell_typeasset_id = String.Empty Then
                    Me.tbl_TrnPenerimaanbarangdetil.Rows(i).SetColumnError("assettype_id", message)
                    row_error = True
                End If

                message = "Asset category can't be empty"
                If cell_categoryasset_id = "-- PILIH --" Or cell_categoryasset_id = String.Empty Then
                    Me.tbl_TrnPenerimaanbarangdetil.Rows(i).SetColumnError("assetcategory_id", message)
                    row_error = True
                End If
            Next

            If row_error = True Then
                dgv_error = True
                Throw New Exception("Ada kesalahan pada pengentrian data!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

    Private Sub SetReadOnlyDetil(ByVal val As Boolean)
        Me.obj_Terimabarangdetil_product_no.Enabled = Not val

        Me.obj_Assettype_id.Enabled = Not val

        'PTS20150909
        Me.obj_Terimabarangdetil_golfiskal.Enabled = Not val
        '=========

        Me.btnCategory.Enabled = Not val
        Me.obj_Terimabarangdetil_parentline.ReadOnly = val
        Me.obj_Terimabarangdetil_parentline.TabStop = Not val
        Me.obj_Terimabarangdetil_nonfixasset.AutoCheck = Not val
        Me.obj_Terimabarangdetil_desc.ReadOnly = val
        Me.obj_Terimabarangdetil_desc.TabStop = Not val

        For Each ctr As Control In Me.Panel_bawah.Controls
            Select Case ctr.GetType().Name
                Case GetType(Label).Name
                Case GetType(TextBox).Name
                    Dim t As TextBox = ctr

                    t.ReadOnly = val
                    t.TabStop = Not val
                Case GetType(ComboBox).Name
                    Dim c As ComboBox = ctr

                    c.Enabled = Not val
                Case GetType(Button).Name
                    Dim c As Button = ctr

                    c.Enabled = Not val
                Case GetType(DateTimePicker).Name
                    Dim d As DateTimePicker = ctr

                    d.Enabled = Not val
            End Select
        Next
    End Sub

    Private Sub CopyItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.tbtnSave.Enabled = True Then
            Me.copy_induk_child(0)
        Else
            MsgBox("Data has been lock")
        End If
    End Sub

    Private Sub CopyWihChildToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.tbtnSave.Enabled = True Then
            Me.copy_induk_child(1)
        Else
            MsgBox("Data has been lock")
        End If
    End Sub

    Private Sub copy_induk_child(ByVal isChild As Byte)

    End Sub

    Private Sub DgvTrnPenerimaanbarangdetil_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        Dim dgv As DataGridView = sender

        If dgv.Columns(dgv.CurrentCell.ColumnIndex).Name = "itemtype_id" Then
            Dim obj As TextBox = CType(e.Control, TextBox)

            obj.AutoCompleteMode = AutoCompleteMode.Suggest
            obj.AutoCompleteSource = AutoCompleteSource.CustomSource
            obj.AutoCompleteCustomSource = Me.stringCollection

            RemoveHandler obj.Validated, AddressOf obj_itemtype_id_Validated
            AddHandler obj.Validated, AddressOf obj_itemtype_id_Validated
        End If
    End Sub

    Private Sub obj_itemtype_id_Validated(sender As Object, e As EventArgs)
        Dim obj As TextBox = sender
        Dim itemtipe_id As String = obj.Text

        If Not Me.stringCollection.Contains(itemtipe_id) Then
            Me.stringCollection.Add(itemtipe_id)

            Try
                Using tipeItem As New clsMstTipeItem(Me.DSNFrm)
                    tipeItem.Insert(itemtipe_id, Me.UserName)
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub filePath_shellPath(ByVal jenis_barcode As String)
        Dim criteria As String = String.Empty
        Dim tbl_setting_path As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
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

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        Dim odatafiller As clsDataFiller = New clsDataFiller(Me.DSNFrm)

        objPrintHeader = New DataSource.clsRptPenerimaanBarang(Me.DSNFrm)
        odatafiller.DataFillAsset(Me.DSNFrm, tbl_Print, "as_RptPenerimaanBarang_Select", "terimabarang_id = '" & DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.SelectedCells.Item(0).RowIndex).Value & "'", Me._CHANNEL)
        odatafiller.DataFillAsset(Me.DSNFrm, tbl_PrintDetil, "as_RptPenerimaanBarangDetil_Select", "terimabarang_id = '" & DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.SelectedCells.Item(0).RowIndex).Value & "'", Me._CHANNEL)

        '=========ADD PTS 20140226==========
        Dim Total, Discount, SumPPN, SumPPH, SumGrandTotal, SumTotal, SumDiscount As Decimal
        SumTotal = 0
        SumDiscount = 0

        For a As Integer = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            Total = Me.tbl_PrintDetil.Rows(a).Item("terimabarangdetil_idrreal") * Me.tbl_PrintDetil.Rows(a).Item("terimabarangdetil_qty")
            SumTotal = SumTotal + Total
        Next

        For w As Integer = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            Discount = Me.tbl_PrintDetil.Rows(w).Item("terimabarangdetil_disc") * Me.tbl_PrintDetil.Rows(w).Item("terimabarangdetil_qty") * Me.tbl_PrintDetil.Rows(w).Item("terimabarangdetil_foreignrate")
            SumDiscount = SumDiscount + Discount
        Next

        SumPPN = Me.tbl_PrintDetil.Compute("sum(terimabarangdetil_ppnidrreal)", "")
        SumPPH = Me.tbl_PrintDetil.Compute("sum(terimabarangdetil_pphidrreal)", "")
        SumGrandTotal = Me.tbl_PrintDetil.Compute("sum(terimabarangdetil_totalidrreal)", "")

        Me.sptSumTotal = SumTotal
        Me.sptSumDiscount = SumDiscount
        Me.sptSumPPn = SumPPN
        Me.sptSumPPh = SumPPH
        Me.sptSumGrandTotal = SumGrandTotal
        '=========================================================

        With objPrintHeader
            .terimabarang_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_id").ToString, String.Empty)
            .terimabarang_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_date"), Now())
            ' ''.terimabarang_type = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_type").ToString, String.Empty)
            .order_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_id").ToString, String.Empty)
            .budget_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_id"), 0)
            .budget_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_name"), String.Empty)
            .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_id"), 0)
            .rekanan_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_name"), String.Empty)
            .employee_id_owner = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_name_owner").ToString, String.Empty)
            .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), 0)
            .department = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("department"), String.Empty)

            ' ''.terimabarang_qtyitem = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_qtyitem"), 0)
            ' ''.terimabarang_qtyrealization = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_qtyrealization"), 0)
            ' ''.order_qty = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_qty"), 0)
            .terimabarang_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_status").ToString, String.Empty)
            .terimabarang_statusrealization = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_statusrealization").ToString, String.Empty)
            .terimabarang_location = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_location").ToString, String.Empty)
            .terimabarang_notes = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_notes").ToString, String.Empty)
            ' ''.terimabarang_nosuratjalan = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_nosuratjalan").ToString, String.Empty)
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
            ' ''.terimabarang_isdisabled = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_isdisabled"), 0)
            ' ''.terimabarang_createby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_createby").ToString, String.Empty)
            ' ''.terimabarang_createdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_createdt"), Now())
            ' ''.terimabarang_modifiedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_modifiedby").ToString, String.Empty)
            ' ''.terimabarang_modifieddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_modifieddt"), Now())
            ' ''.terimabarang_appuser = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appuser"), 0)
            ' ''.terimabarang_appuser_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appuser_by").ToString, String.Empty)
            ' ''.terimabarang_appuser_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appuser_dt"), Now())
            ' ''.terimabarang_appspv = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appspv"), 0)
            .terimabarang_appspv_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appspv_name").ToString, String.Empty)
            ' ''.terimabarang_appspv_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appspv_dt"), Now())
            ' ''.terimabarang_appacc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appacc"), 0)
            ' ''.terimabarang_appacc_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appacc_by").ToString, String.Empty)
            ' ''.terimabarang_appacc_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appacc_dt"), Now())
            ' ''.terimabarang_foreign = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_foreign"), 0)
            ' ''.currency_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_id"), 0)
            ' ''.terimabarang_foreignrate = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_foreignrate"), 0)
            ' ''.terimabarang_idrreal = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_idrreal"), 0)
            ' ''.terimabarang_pph = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_pph"), 0)
            ' ''.terimabarang_ppn = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_ppn"), 0)
            ' ''.terimabarang_disc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_disc"), 0)
            ' ''.terimabarang_cetakbpb = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_cetakbpb"), 0)

            Me.sptChannel_ID = .channel_id
            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.sptTerimaBarang_ID = .terimabarang_id
            Me.sptDomain = .domain_name

            'odatafiller.DataFillAsset(Me.ASSET_DSN, tbl_PrintDetil, "as_RptPenerimaanBarangDetil_Select", "terimabarang_id = '" & .terimabarang_id & "'", Me._CHANNEL)
            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptPenerimaanBarangDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptPenerimaanBarangDetil(Me.DSNFrm, Me.DSNFrm)
            With objDetil
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .terimabarangdetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_line"), 0)
                ' ''.terimabarangdetil_parentline = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_parentline"), 0)
                .terimabarangdetil_desc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_desc").ToString, String.Empty)
                ' ''.terimabarangdetil_date = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_date"), Now())
                ' ''.terimabarangdetil_type = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_type").ToString, String.Empty)
                ' ''.assetcategory_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("assetcategory_id").ToString, String.Empty)
                ' ''.assettype_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("assettype_id").ToString, String.Empty)
                .terimabarang_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarang_barcode").ToString, String.Empty)
                ' ''.terimabarang_parentbarcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarang_parentbarcode").ToString, String.Empty)
                ' ''.item_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("item_id").ToString, String.Empty)
                ' ''.itemcategory_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("itemcategory_id").ToString, String.Empty)
                .itemtype_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("itemtype_id").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand_id"), 0)
                .brand_name = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand_name"), String.Empty)
                .terimabarangdetil_serial_no = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_serial_no").ToString, String.Empty)
                ' ''.terimabarangdetil_product_no = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_product_no").ToString, String.Empty)
                ' ''.terimabarangdetil_model = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_model").ToString, String.Empty)
                ' ''.material_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("material_id").ToString, String.Empty)
                ' ''.colour_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("colour_id").ToString, String.Empty)
                ' ''.size_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("size_id").ToString, String.Empty)
                ' ''.sex_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("sex_id").ToString, String.Empty)
                .room_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("room_id").ToString, String.Empty)
                .room_name = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("room_name").ToString, String.Empty)
                ' ''.terimabarangdetil_rack = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_rack").ToString, String.Empty)
                .terimabarangdetil_qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_qty"), 0)
                ' ''.unit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("unit_id"), 0)
                ' ''.currency_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id"), 0)
                .terimabarangdetil_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_foreign"), 0)
                .terimabarangdetil_foreignrate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_foreignrate"), 0)
                .terimabarangdetil_idrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_idrreal"), 0)
                .terimabarangdetil_pphpercent = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_pphpercent"), 0)
                .terimabarangdetil_ppnpercent = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_ppnpercent"), 0)
                .terimabarangdetil_disc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_disc"), 0)
                .terimabarangdetil_pphforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_pphforeign"), 0)
                .terimabarangdetil_pphidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_pphidrreal"), 0)
                .terimabarangdetil_ppnforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_ppnforeign"), 0)
                .terimabarangdetil_ppnidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_ppnidrreal"), 0)
                .terimabarangdetil_totalforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_totalforeign"), 0)
                .terimabarangdetil_totalidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_totalidrreal"), 0)
                ' ''.terimabarangdetil_nonfixasset = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_nonfixasset"), 0)
                ' ''.terimabarangdetil_golfiskal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_golfiskal").ToString, String.Empty)
                ' ''.terimabarangdetil_depre_enddt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_depre_enddt"), Now())
                ' ''.employee_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id").ToString, String.Empty)
                ' ''.strukturunit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_id"), 0)
                ' ''.show_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("show_id").ToString, String.Empty)
                ' ''.show_id_cont = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("show_id_cont").ToString, String.Empty)
                ' ''.terimabarangdetil_eps = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_eps").ToString, String.Empty)
                ' ''.writeoff_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_id").ToString, String.Empty)
                ' ''.writeoff_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_dt"), Now())
                ' ''.order_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("order_id").ToString, String.Empty)
                ' ''.orderdetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("orderdetil_line"), 0)
                ' ''.budget_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("budget_id"), 0)
                ' ''.budgetdetil_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("budgetdetil_id"), 0)
                ' ''.acc_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_id").ToString, String.Empty)
                ' ''.channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                ' ''.create_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("create_by").ToString, String.Empty)
                ' ''.create_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("create_dt"), Now())
                ' ''.modified_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("modified_by").ToString, String.Empty)
                ' ''.modified_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("modified_dt"), Now())
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        If Me._USERTYPE = "acc" Then
            e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("NEWACT_DataSource_clsRptJurnal_Detil", objDatalistDetil))
        Else
            e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptPenerimaanBarangDetil", objDatalistDetil))
        End If
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

    Private Function uiTrnPenerimaanBarang_Print() As Boolean
        If Me.DgvTrnPenerimaanbarang.SelectedRows.Count <= 0 Then
            MsgBox("No data selected")
            Exit Function
        End If

        If CBool(Me.DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_appspv").Value) = False Then
            MsgBox("SPV / Sect. Head approval is required to print this document")
            Exit Function
        End If

        Dim dlg As dlgPilihanPrint = New dlgPilihanPrint()
        Dim ket As String = String.Empty

        dlg.ShowDialog()

        If dlg.DialogResult = DialogResult.OK Then
            ket = "Internal"
        ElseIf dlg.DialogResult = DialogResult.Ignore Then
            ket = "Eksternal"
        Else
            Exit Function
        End If

        Using terimabarang As New clsTrnPenerimaanBarang(Me.DSNFrm)
            For i As Integer = 0 To Me.DgvTrnPenerimaanbarang.SelectedRows.Count - 1
                Dim terimabarang_id As String = Me.DgvTrnPenerimaanbarang.SelectedRows.Item(i).Cells("terimabarang_id").Value

                terimabarang.Print(terimabarang_id, Me.SptServer, Me._CHANNEL, ket, False)
            Next
        End Using
    End Function

    Private Function uiTrnPenerimaanBarang_PrintJurnal() As Boolean

        If Me.DgvTrnPenerimaanbarang.SelectedRows.Count <= 0 Then
            MsgBox("No data selected")
            Exit Function
        End If

        If CBool(Me.DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_appspv").Value) = False Then
            MsgBox("SPV / Sect. Head approval is required to print this document")
            Exit Function
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            Using jurnal As New clsTrnJurnal()

                For i As Integer = 0 To Me.DgvTrnPenerimaanbarang.SelectedRows.Count - 1
                    'Dim jurnal_id As String = Me.DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_id").Value
                    Dim jurnal_id As String = Me.DgvTrnPenerimaanbarang.SelectedRows.Item(i).Cells("terimabarang_id").Value
                    If CBool(Me.DgvTrnPenerimaanbarang.SelectedRows.Item(i).Cells("terimabarang_appacc").Value) = True Then
                        jurnal.PrintJurnalRV(jurnal_id, False, Me.DSNFrm)
                    End If
                Next
                
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function uiTrnPenerimaanBarang_PrintPreview() As Boolean
        If Me.DgvTrnPenerimaanbarang.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim terimabarang_id As String

        If Me._USERTYPE <> "acc" Then
            Dim dlg As dlgPilihanPrint = New dlgPilihanPrint()
            Dim ket As String = String.Empty

            dlg.ShowDialog()

            If dlg.DialogResult = DialogResult.OK Then
                ket = "Internal"
            ElseIf dlg.DialogResult = DialogResult.Ignore Then
                ket = "Eksternal"
            Else
                Exit Function
            End If

            Using terimabarang As New clsTrnPenerimaanBarang(Me.DSNFrm)
                For i As Integer = 0 To Me.DgvTrnPenerimaanbarang.SelectedRows.Count - 1
                    terimabarang_id = DgvTrnPenerimaanbarang.SelectedRows.Item(i).Cells("terimabarang_id").Value
                    terimabarang.Print(terimabarang_id, Me.SptServer, Me._CHANNEL, ket, True)
                Next
            End Using
        Else
            Try
                Me.Cursor = Cursors.WaitCursor

                Using jurnal As New clsTrnJurnal()
                    For i As Integer = 0 To Me.DgvTrnPenerimaanbarang.SelectedRows.Count - 1

                        Dim jurnal_id As String = Me.DgvTrnPenerimaanbarang.SelectedRows.Item(i).Cells("terimabarang_id").Value
                        If CBool(Me.DgvTrnPenerimaanbarang.SelectedRows.Item(i).Cells("terimabarang_appacc").Value) = True Then
                            jurnal.PrintJurnalRV(jurnal_id, True, Me.DSNFrm)
                        End If
                    Next
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Function

    Private Sub btn_Parent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Parent.Click
        If TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarangdetil_nonfixasset") = True Then
            Dim param As Integer = 1
            Dim listbarcode As String
            'Dim dlg As New dlgListBarangNonFix(Me.DSNFrm, _CHANNEL, param, Me._STRUKTUR_UNIT, DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_parentbarcode").Value)
            Dim dlg As New dlgListBarangNonFix(Me.DSNFrm, _CHANNEL, param, Me._STRUKTUR_UNIT, TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarang_parentbarcode"))

            listbarcode = dlg.OpenDialog(Me)
            If listbarcode IsNot Nothing Then
                'Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_barcode").Value = listbarcode
                Me.TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarang_barcode").Value = listbarcode
            End If
        Else
            Dim param As Integer = 2
            Dim listbarcodeInduk As String
            'Dim dlg As New dlgListBarangNonFix(Me.DSNFrm, _CHANNEL, param, Me._STRUKTUR_UNIT, DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_parentbarcode").Value)
            Dim dlg As New dlgListBarangNonFix(Me.DSNFrm, _CHANNEL, param, Me._STRUKTUR_UNIT, TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarang_parentbarcode"))

            listbarcodeInduk = dlg.OpenDialog(Me)

            If listbarcodeInduk IsNot Nothing Then
                TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarang_parentbarcode") = listbarcodeInduk
                TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarangdetil_parentline") = 0
                'TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarangdetil_parentline") = True
            End If
        End If
    End Sub

    Private Sub DgvTrnPenerimaanbarang_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnPenerimaanbarang.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        Try
            If objrow.Cells("terimabarang_appuser").Value = True And objrow.Cells("terimabarang_appspv").Value = True And objrow.Cells("terimabarang_appacc").Value = True Then
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            ElseIf objrow.Cells("terimabarang_appuser").Value = True And objrow.Cells("terimabarang_appspv").Value = True Then
                objrow.DefaultCellStyle.BackColor = Color.Aquamarine
            ElseIf objrow.Cells("terimabarang_appuser").Value = True Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            Else
                objrow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgvTrnJurnaldetil_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DgvTrnJurnaldetil.UserDeletingRow
        Dim obj As DataGridView = sender

        If e.Row.Index < 0 Then Exit Sub

        '=======================================================================================
        Dim refId As String = DgvTrnJurnaldetil.Item("ref_id", DgvTrnJurnaldetil.CurrentCell.RowIndex).Value
        Dim refLine As String = DgvTrnJurnaldetil.Item("ref_line", DgvTrnJurnaldetil.CurrentCell.RowIndex).Value

        Dim ref As String = String.Empty
        Dim line As Integer = 0

        Dim jml As Integer = 0
        For i As Integer = 0 To DgvTrnJurnaldetil.Rows.Count - 1
            If DgvTrnJurnaldetil.Item("ref_id", i).Value = refId And DgvTrnJurnaldetil.Item("ref_line", i).Value = refLine Then
                jml = jml + 1
            End If
        Next

        If jml = 1 Then
ulang:
            For i As Integer = 0 To DgvTrnJurnalreference.Rows.Count - 1
                ref = DgvTrnJurnalreference.Item("jurnal_id_ref", i).Value
                line = DgvTrnJurnalreference.Item("jurnal_id_refline", i).Value

                If refId = ref And refLine = line Then
                    DgvTrnJurnalreference.Rows.RemoveAt(i)
                    GoTo ulang
                End If
            Next
ulang2:
            For i As Integer = 0 To DgvTrnJurnaldetil_Pembayaran.Rows.Count - 1
                ref = DgvTrnJurnaldetil_Pembayaran.Item("ref_id", i).Value
                line = DgvTrnJurnaldetil_Pembayaran.Item("ref_line", i).Value

                If refId = ref And refLine = line Then
                    DgvTrnJurnaldetil_Pembayaran.Rows.RemoveAt(i)
                    GoTo ulang2
                End If
            Next
        End If
        '====================================================================================
    End Sub

    Private Sub DgvTrnJurnaldetil_Pembayaran_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DgvTrnJurnaldetil_Pembayaran.UserDeletingRow
        Dim obj As DataGridView = sender

        If e.Row.Index < 0 Then Exit Sub

        '=======================================================================================
        Dim refId As String = DgvTrnJurnaldetil_Pembayaran.Item("ref_id", DgvTrnJurnaldetil_Pembayaran.CurrentCell.RowIndex).Value
        Dim refLine As String = DgvTrnJurnaldetil_Pembayaran.Item("ref_line", DgvTrnJurnaldetil_Pembayaran.CurrentCell.RowIndex).Value
        Dim ref As String = String.Empty
        Dim line As Integer = 0

        Dim jml As Integer = 0
        For i As Integer = 0 To DgvTrnJurnaldetil_Pembayaran.Rows.Count - 1
            If DgvTrnJurnaldetil_Pembayaran.Item("ref_id", i).Value = refId And DgvTrnJurnaldetil_Pembayaran.Item("ref_line", i).Value = refLine Then
                jml = jml + 1
            End If
        Next

        If jml = 1 Then
ulang:
            For i As Integer = 0 To DgvTrnJurnalreference.Rows.Count - 1
                ref = DgvTrnJurnalreference.Item("jurnal_id_ref", i).Value
                line = DgvTrnJurnalreference.Item("jurnal_id_refline", i).Value
                If refId = ref And refLine = line Then
                    DgvTrnJurnalreference.Rows.RemoveAt(i)
                    GoTo ulang
                End If
            Next
ulang2:
            For i As Integer = 0 To DgvTrnJurnaldetil.Rows.Count - 1
                ref = DgvTrnJurnaldetil.Item("ref_id", i).Value
                line = DgvTrnJurnaldetil.Item("ref_line", i).Value
                If refId = ref And refLine = line Then
                    DgvTrnJurnaldetil.Rows.RemoveAt(i)
                    GoTo ulang2
                End If
            Next
        End If
        '====================================================================================
    End Sub

    Private Sub obj_Terimabarangdetil_qty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Terimabarangdetil_qty.Validated, _
        obj_Terimabarangdetil_qtydetail.Validated

        Dim obj As TextBox = sender

        If obj Is Me.obj_Terimabarangdetil_qty Then
            Dim ppnAmount As Decimal
            Dim ppnAmountIDR As Decimal
            Dim pphAmount As Decimal
            Dim pphAmountIDR As Decimal
            Dim totalAmount As Decimal
            Dim totalAmountIDR As Decimal

            Dim h As Integer
            
            For h = 0 To Me.TLTrnPenerimaanBarangDetil.Nodes.Count - 1
                If Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_line") = Me.obj_Terimabarangdetil_line.Text Then

                    pphAmount = ((clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_foreign"), 0) - clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_disc"), 0)) * Me.obj_Terimabarangdetil_qty.Text) * (clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_pphpercent"), 0) / 100)

                    pphAmountIDR = ((clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_foreign"), 0) - clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_disc"), 0)) * Me.obj_Terimabarangdetil_qty.Text) _
                                        * (clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_pphpercent"), 0) / 100) * (clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_foreignrate"), 0))

                    ppnAmount = ((clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_foreign"), 0) - clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_disc"), 0)) * Me.obj_Terimabarangdetil_qty.Text) _
                                                           * (clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_ppnpercent"), 0) / 100)

                    ppnAmountIDR = ((clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_foreign"), 0) - clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_disc"), 0)) * Me.obj_Terimabarangdetil_qty.Text) _
                                        * (clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_ppnpercent"), 0) / 100) * (clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_foreignrate"), 0))

                    totalAmount = ((clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_foreign"), 0) - clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_disc"), 0)) * Me.obj_Terimabarangdetil_qty.Text) _
                                        - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                    totalAmountIDR = (clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_foreign"), 0) - clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_disc"), 0)) * clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_foreignrate"), 0) * _
                                              Me.obj_Terimabarangdetil_qty.Text - _
                                              clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                    If Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("currency_id") = 1 Then
                        Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_pphforeign") = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                        Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_ppnforeign") = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                        Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_totalforeign") = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
                    Else
                        Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_pphforeign") = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                        Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_ppnforeign") = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                        Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_totalforeign") = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)
                    End If

                    Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_pphidrreal") = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                    Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_ppnidrreal") = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                    Me.TLTrnPenerimaanBarangDetil.Nodes(h).Item("terimabarangdetil_totalidrreal") = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)
                End If
            Next
        End If

        Dim qty_detil As Integer = Me.obj_Terimabarangdetil_qtydetail.Text
        Dim qty As Integer = CInt(Me.obj_Terimabarangdetil_qty.Text)
        Dim qtyTotal As Integer = 0

        If qty_detil <= 0 Then
            Exit Sub
        End If

        If qty_detil > 0 Then
            qtyTotal = qty * qty_detil

            Me.obj_Terimabarangdetil_qtytotal.Text = qtyTotal.ToString()
        End If
    End Sub

    Private Sub btnPrintAllBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintAllBarcode.Click
        Dim nm_perusahaan As String = Me.getNamaPerusahaan()

        Me.PrintBarcode(nm_perusahaan, Me.tbl_TrnPenerimaanbarangdetil.Select())
    End Sub

    Private Function getNamaPerusahaan() As String
        Dim dbConn As New OleDb.OleDbConnection(Me.DSNFrm)
        Dim cmd As OleDb.OleDbCommand
        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            cmd = New OleDb.OleDbCommand("ms_MstChannel_GetNameReport", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@channel_id", OleDb.OleDbType.VarWChar, 20).Value = Me._CHANNEL
            cmd.Parameters.Add("@channel_namereport", OleDb.OleDbType.VarWChar, 100).Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()

            Return cmd.Parameters("@channel_namereport").Value.ToString()
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Function

    Private Sub PrintBarcode(ByVal nm_perusahan As String, ByVal barcodeRow As DataRow())
        Dim barcode As String = ""
        Dim tipe As String
        Dim result As String = ""
        Dim byteRst() As Byte
        Dim fileName As String = clsUtil.GetPathOfFolderExtra & "Barcode\netbarcode.txt"
        Dim pathexe As String = clsUtil.GetPathOfFolderExtra & "Barcode\Label.exe"
        Dim NotPrint As Boolean
        Dim acc_approve As Object
        Dim rowCount As Integer


        'Cek accounting approve
        rowCount = Me.tbl_TrnPenerimaanbarang_Temp.Rows.Count
        If rowCount > 0 Then
            If Me._MODULE_TYPE = ModuleType.PURCHASE OrElse Me._MODULE_TYPE = ModuleType.LISTPV Then
                acc_approve = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc")
                If acc_approve = False Then
                    MsgBox("Can't print barcode before approved by accounting.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
        Else
            Exit Sub
        End If
        '====================================

        For Each row As DataRow In barcodeRow
            barcode = row.Item("terimabarang_barcode").ToString()

            If barcode.Trim <> "" Then
                NotPrint = row.Item("terimabarangdetil_nonfixasset")
                tipe = row.Item("terimabarangdetil_product_no").ToString()

                If NotPrint = True Then
                Else
                    If tipe.ToLower() = "label" Then
                        tipe = "1"
                    ElseIf tipe.ToLower() = "taffeta" Then
                        tipe = "2"
                    End If

                    result = result & nm_perusahan & vbTab & barcode & vbTab & tipe & vbCrLf
                End If
            End If
        Next

        ReDim byteRst(result.Length - 1)

        For i As Integer = 0 To byteRst.Length - 1
            byteRst(i) = Asc(result.Chars(i))
        Next

        If byteRst.Length = 0 Then
            Return
        End If

        My.Computer.FileSystem.WriteAllBytes(fileName, byteRst, False)
        Shell(pathexe, AppWinStyle.NormalFocus)
    End Sub

    Private Sub btnSerial_Click(sender As Object, e As EventArgs) Handles btnSerial.Click
        Dim dlg As New DlgMstAssetConsumable(Me._CHANNEL, Me.DSNFrm)

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim row As DataRow = CType(dlg.DgvAssetConsumable.CurrentRow.DataBoundItem, DataRowView).Row

            Me.obj_Terimabarangdetil_serial_no.Text = row.Item("asset_serial").ToString()
            Me.obj_Itemcategory_id.SelectedValue = row.Item("category_id").ToString()
            Me.obj_Itemtype_id.Text = row.Item("tipeitem_id").ToString()
            Me.obj_Brand_id.SelectedValue = row.Item("brand_id")

            Me.obj_Terimabarangdetil_serial_no.DataBindings("Text").WriteValue()
        End If
    End Sub

    Private Sub obj_Terimabarangdetil_qtytotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles obj_Terimabarangdetil_qtytotal.KeyPress
        Dim qty_detil As Integer = Me.obj_Terimabarangdetil_qtydetail.Text

        If qty_detil > 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub obj_Assettype_id_GotFocus(sender As Object, e As EventArgs) Handles obj_Assettype_id.GotFocus
        AddHandler Me.obj_Assettype_id.SelectedIndexChanged, AddressOf Me.obj_Assettype_id_SelectedIndexChanged
    End Sub

    Private Sub obj_Assettype_id_LostFocus(sender As Object, e As EventArgs) Handles obj_Assettype_id.LostFocus
        RemoveHandler Me.obj_Assettype_id.SelectedIndexChanged, AddressOf Me.obj_Assettype_id_SelectedIndexChanged
    End Sub

    Private Sub obj_Assettype_id_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim bindingTemp As Binding
        Dim acc_id As String

        If obj_Assettype_id.Text.Trim = "Consumable" Then
            Me.btnSerial.Enabled = True
            Me.lblQtyDetail.Visible = True
            Me.lblQtyTotal.Visible = True
            Me.obj_Terimabarangdetil_qtydetail.Visible = True
            Me.obj_Terimabarangdetil_qtytotal.Visible = True
            Me.obj_Terimabarangdetil_qtydetail.Text = 1
            Me.obj_Terimabarangdetil_qtytotal.Text = Me.obj_Terimabarangdetil_qty.Text
        Else
            Me.btnSerial.Enabled = False
            Me.lblQtyDetail.Visible = False
            Me.lblQtyTotal.Visible = False
            Me.obj_Terimabarangdetil_qtydetail.Text = 0
            Me.obj_Terimabarangdetil_qtytotal.Text = 0
            Me.obj_Terimabarangdetil_qtydetail.Visible = False
            Me.obj_Terimabarangdetil_qtytotal.Visible = False
        End If

        If obj_Assettype_id.Text.Trim = "Asset Program" Or obj_Assettype_id.Text.Trim = "Asset Non Program" Then
            obj_Acc_id.Enabled = False
        Else
            obj_Acc_id.Enabled = True
        End If

        Me.obj_Acc_id.SelectedIndex = 0
        Me.obj_Acc_id_SelectedIndexChanged(Nothing, Nothing)

        bindingTemp = obj_Acc_id.DataBindings("SelectedValue")

        If bindingTemp IsNot Nothing Then
            bindingTemp.WriteValue()
        End If

        If obj_Assettype_id.Text.Trim = "Non Asset Program" Then
            'Remark BY Kokoh
            'If Me._STRUKTUR_UNIT = 5556 Then 'Khusus untuk wardrobe
            If Me.obj_Terimabarang_type.Text.ToUpper() = "LISTGQ" Then
                'If Me._MODULE_TYPE = ModuleType.LISTGQ Then
                acc_id = "1152431"
                obj_Acc_id.SelectedValue = acc_id
                Me.obj_Acc_id_SelectedIndexChanged(Nothing, Nothing)

                bindingTemp = obj_Acc_id.DataBindings("SelectedValue")

                If bindingTemp IsNot Nothing Then
                    bindingTemp.WriteValue()
                End If
            Else
                obj_Acc_id.Enabled = True

                Using receive As New clsTrnPenerimaanBarang(Me.DSNFrm)
                    acc_id = receive.GetAccountOth(TLTrnPenerimaanBarangDetil.FocusedNode.Item("budget_id"), TLTrnPenerimaanBarangDetil.FocusedNode.Item("budgetdetil_id"))
                    'suroso =========
                    'acc_id = receive.GetAccountOth(DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("budget_id").Value, DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("budgetdetil_id").Value)
                End Using

                If acc_id = "0" Then
                    obj_Acc_id.SelectedIndex = 0
                    Me.obj_Acc_id_SelectedIndexChanged(Nothing, Nothing)

                    bindingTemp = obj_Acc_id.DataBindings("SelectedValue")

                    If bindingTemp IsNot Nothing Then
                        bindingTemp.WriteValue()
                    End If
                Else
                    obj_Acc_id.SelectedValue = acc_id
                    Me.obj_Acc_id_SelectedIndexChanged(Nothing, Nothing)

                    bindingTemp = obj_Acc_id.DataBindings("SelectedValue")

                    If bindingTemp IsNot Nothing Then
                        bindingTemp.WriteValue()
                    End If
                End If
            End If
        End If

            Me.obj_Assetcategory_id.Text = ""
    End Sub

    Private Sub obj_Assettype_id_Validating(sender As Object, e As CancelEventArgs) Handles obj_Assettype_id.Validating
        Dim obj As ComboBox = sender

        If obj.Text.Trim = "Consumable" Then
            If Me._USERTYPE = "acc" Then
                MsgBox("You can't changes to consumable item.", MsgBoxStyle.Critical)

                obj.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub uiTrnPenerimaanBarang_FormBindingStartDetil() Handles Me.FormBindingStartDetil
        Dim fileName As String = String.Format("{0}_{1}", Me.obj_Terimabarang_id.Text, Me.obj_Terimabarangdetil_line.Text)

        If Me.photoChanged.Count <> 0 Then
            For Each a As DictionaryEntry In Me.photoChanged
                If a.Key = fileName Then
                    If IO.File.Exists(a.Value) = True Then
                        Me.obj_photo.BackgroundImage = Image.FromStream(New IO.MemoryStream(clsUtil.GetBytes(a.Value)))
                        Me.obj_photo.BackgroundImageLayout = ImageLayout.Stretch
                    Else
                        Dim filedefault As String = String.Format("{0}\{1}\{2}", Me.ImageServer, "master_asset", "default.jpg")
                        Me.obj_photo.BackgroundImage = Image.FromStream(New IO.MemoryStream(clsUtil.GetBytes(filedefault)))
                        Me.obj_photo.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    Exit Sub
                End If
            Next
        End If

        Try
            Me.obj_photo.BackgroundImage = Image.FromStream(New IO.MemoryStream(UtilPhoto.GetImageFromDB(Me.obj_Terimabarang_id.Text, Me.obj_Terimabarangdetil_line.Text, Me.DSNFiles)))
            Me.obj_photo.BackgroundImageLayout = ImageLayout.Stretch
        Catch ex As Exception
            Dim filedefault As String = String.Format("{0}\{1}\{2}", Me.ImageServer, "master_asset", "default.jpg")

            Me.obj_photo.BackgroundImage = Image.FromStream(New IO.MemoryStream(clsUtil.GetBytes(filedefault)))
            Me.obj_photo.BackgroundImageLayout = ImageLayout.Stretch
        End Try
    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        If Me.btnCapture.Text = "Start Preview" Then
            Me.VideoCapture.VideoDevice = 0

            VideoCapture.UseNearestVideoSize(640, 480, True)

            If Me.VideoCapture.StartPreview() = True Then
                Me.obj_photo.Visible = False
                Me.VideoCapture.Visible = True
                Me.btnCaptureCancel.Visible = True
                Me.btnCapture.Text = "Capture"
            End If

        ElseIf Me.btnCapture.Text = "Capture" Then
            Dim fileName As String = String.Format("{0}\{1}_{2}.jpg", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, _
                                                   Me.obj_Terimabarang_id.Text, Me.obj_Terimabarangdetil_line.Text)

            Dim cNmPhoto As String = String.Format("{0}_{1}", Me.obj_Terimabarang_id.Text, Me.obj_Terimabarangdetil_line.Text)

            If Me.VideoCapture.CaptureFrameTo(VidGrab.TFrameCaptureDest.fc_JpegFile, fileName) = True Then
                Me.VideoCapture.StopPreview()

                Me.obj_photo.Visible = True
                Me.VideoCapture.Visible = True
                Me.btnCapture.Text = "Start Preview"
                Me.btnCaptureCancel.Visible = False
                Me.obj_photo.BackgroundImage = Image.FromStream(New IO.MemoryStream(clsUtil.GetBytes(fileName)))
                Me.obj_photo.BackgroundImageLayout = ImageLayout.Stretch

                Me.photoChanged.Remove(cNmPhoto)
                Me.photoChanged.Add(cNmPhoto, fileName)
            End If
        End If
    End Sub

    Private Sub btnCaptureCancel_Click(sender As Object, e As EventArgs) Handles btnCaptureCancel.Click
        Me.VideoCapture.StopPreview()
        Me.obj_photo.Visible = True
        Me.VideoCapture.Visible = True
        Me.btnCapture.Text = "Start Preview"
        Me.btnCaptureCancel.Visible = False
    End Sub

    Private Sub uiTrnPenerimaanBarang_FormBeforeNew() Handles Me.FormBeforeNew

        Me.locking.Clear()


        Me.btnApproved.Visible = False
        Me.btnUnApproved.Visible = False
        Me.btnApproved.Enabled = True
        Me.btnUnApproved.Enabled = False
        Me.objFormError.Clear()
    End Sub

    Private Sub DgvTrnPenerimaanbarang_SelectionChanged(sender As Object, e As EventArgs) Handles DgvTrnPenerimaanbarang.SelectionChanged
        If Me.tbl_TrnPenerimaanbarang.Rows.Count > 0 Then
            Dim viewRow As DataGridViewRow = Me.DgvTrnPenerimaanbarang.CurrentRow

            If viewRow Is Nothing Then
                Exit Sub
            End If

            If Me._USERTYPE = "user" Then
                If clsUtil.IsDbNull(viewRow.Cells("terimabarang_appuser").Value, False) = True Then
                    Me.btnApproved.Enabled = False
                    Me.btnUnApproved.Enabled = True
                Else
                    Me.btnApproved.Enabled = True
                    Me.btnUnApproved.Enabled = False
                End If
            Else
                Me.btnApproved.Visible = False
                Me.btnUnApproved.Visible = False
            End If
        End If
    End Sub

    'tambahan
    Private Function getKategoriAssetAccount(ByVal kategoriAsset_id As String) As String
        Dim dbConn As New OleDb.OleDbConnection(Me.DSNFrm)
        Dim cmd As OleDb.OleDbCommand
        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            cmd = New OleDb.OleDbCommand("as_mstKategoriAssetAccount_GetAccId", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@kategoriasset_id", OleDb.OleDbType.VarWChar, 100).Value = kategoriAsset_id
            cmd.Parameters.Add("@debit_acc_id", OleDb.OleDbType.VarWChar, 50).Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()

            Return cmd.Parameters("@debit_acc_id").Value.ToString()
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Function

    Private Sub obj_Acc_id_GotFocus(sender As Object, e As EventArgs) Handles obj_Acc_id.GotFocus
        AddHandler obj_Acc_id.SelectedIndexChanged, AddressOf obj_Acc_id_SelectedIndexChanged
    End Sub

    Private Sub obj_Acc_id_LostFocus(sender As Object, e As EventArgs) Handles obj_Acc_id.LostFocus
        RemoveHandler obj_Acc_id.SelectedIndexChanged, AddressOf obj_Acc_id_SelectedIndexChanged
    End Sub

    Private Sub obj_Acc_id_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Me.tbl_TrnJurnaldetil_debet.Rows.Count > 0 Then
            For Each row As DataRow In Me.tbl_TrnJurnaldetil_debet.Rows
                If row.Item("jurnaldetil_line") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarangdetil_line") Then
                    row.Item("acc_id") = obj_Acc_id.SelectedValue
                End If
            Next
        End If
    End Sub

    Private Sub ftabDataDetil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        If Me.tbl_TrnPenerimaanbarang_Temp.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim approved As Object = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc")

        If Me.ftabDataDetil.SelectedIndex = 2 Then
            If approved = True Then
                Me.obj_Jurnal_bookdate.Enabled = False
                Me.obj_Terimabarang_foreignrate.ReadOnly = True
                Me.cbo_periode.Enabled = False
            Else
                Me.obj_Jurnal_bookdate.Enabled = True
                Me.obj_Terimabarang_foreignrate.ReadOnly = False
                Me.cbo_periode.Enabled = True
            End If
        Else
            Me.obj_Jurnal_bookdate.Enabled = False
            Me.obj_Terimabarang_foreignrate.ReadOnly = True
            Me.cbo_periode.Enabled = False
        End If
    End Sub

    Private Sub btnCategory_Click(sender As Object, e As EventArgs) Handles btnCategory.Click
        Dim dlg As New dlgAssetCategory_select(Me._CHANNEL, Me.DSNFrm, obj_Assettype_id.SelectedValue)
        Dim acc_id As String
        Dim bindingTemp As Binding

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim row As DataRow = CType(dlg.DgvAssetConsumable.CurrentRow.DataBoundItem, DataRowView).Row

            Me.obj_Assetcategory_id.Text = row.Item("kategoriasset_id").ToString()
            Me.obj_Assetcategory_id.DataBindings("Text").WriteValue()

            If Me.obj_Assetcategory_id.Text.Trim.ToLower() = "tanah" Then
                Me.obj_Acc_id.Enabled = True
            Else
                Me.obj_Acc_id.Enabled = False
            End If

            acc_id = getKategoriAssetAccount(obj_Assetcategory_id.Text.Trim)

            ' Mengisi acc_id otomatis
            '---------------------------------------------------------------------------------------------------
            If acc_id = "" Then
                Dim assetCategory As String = Me.obj_Assetcategory_id.Text.Trim

                If assetCategory = "Asset Program" Or assetCategory = "Asset Non Program" Then
                    obj_Acc_id.SelectedIndex = 0
                    obj_Acc_id_SelectedIndexChanged(Nothing, Nothing)
                End If

                bindingTemp = obj_Acc_id.DataBindings("SelectedValue")

                If bindingTemp IsNot Nothing Then
                    bindingTemp.WriteValue()
                End If
            Else
                obj_Acc_id.SelectedValue = acc_id
                obj_Acc_id_SelectedIndexChanged(Nothing, Nothing)

                bindingTemp = obj_Acc_id.DataBindings("SelectedValue")

                If bindingTemp IsNot Nothing Then
                    bindingTemp.WriteValue()
                End If
            End If
            '---------------------------------------------------------------------------------------------------

            'Mengisi kategori depre secara otomatis
            '---------------------------------------------------------------------------------------------------
            Dim db As New DataClassesFRMDataContext(Me.DSNLinq)
            Dim depreLink As master_kategoriassetdeprelink

            db.OpenConnectionWithRole()

            depreLink = db.master_kategoriassetdeprelinks.Where(Function(p) p.kategoriasset_id = Me.obj_Assetcategory_id.Text.Trim).FirstOrDefault()

            If depreLink IsNot Nothing Then
                Me.obj_Terimabarangdetil_golfiskal.SelectedValue = depreLink.kategoriassetdepre_id
            End If

            db.CloseConnectionWithRole()
            '---------------------------------------------------------------------------------------------------
        End If
    End Sub

    Private Sub btnItemCategorySelect_Click(sender As Object, e As EventArgs) Handles btnItemCategorySelect.Click
        Dim tbl As DataTable = clsDataset.CreateTblMstItemcategory
        Me.DataFill(tbl, "ms_MstItemCategory_Select", "")

        Dim dlg As New dlgAssetItemCategory_select(tbl)

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim row As DataRow = CType(dlg.DgvAssetConsumable.CurrentRow.DataBoundItem, DataRowView).Row

            Me.obj_Itemcategory_id.SelectedValue = row.Item("category_id").ToString()
        End If
    End Sub

    Private Sub btnItemSelect_Click(sender As Object, e As EventArgs) Handles btnItemSelect.Click
        Dim tbl As DataTable = clsDataset.CreateTblMstItem
        Me.DataFill(tbl, "ms_MstItemWithCategory_Select", "")
        Dim dlg As New dlgAssetItem_select(tbl)

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim row As DataRow = CType(dlg.DgvAssetConsumable.CurrentRow.DataBoundItem, DataRowView).Row

            Me.obj_Item_id.SelectedValue = row.Item("item_id").ToString()
            Me.obj_Itemcategory_id.SelectedValue = row.Item("category_id").ToString
        End If
    End Sub

    Private rateGotFocus As String

    Private Sub obj_Terimabarang_foreignrate_GotFocus(sender As Object, e As EventArgs) Handles obj_Terimabarang_foreignrate.GotFocus
        rateGotFocus = Me.obj_Terimabarang_foreignrate.Text
    End Sub

    Private Function calAmountTaxIdr(foreign As Decimal, discount As Decimal, qty As Integer, percent As Integer, rate As Decimal) As Decimal
        Dim result As Decimal

        result = (((foreign - discount) * (percent / 100)) * rate) * qty

        Return result
    End Function

    Private Function calAmountTotalIdrReal(ByVal foreign As Decimal, ByVal discount As Decimal, ByVal qty As Integer, ByVal rate As Decimal, _
                                           ByVal pph As Decimal, ByVal ppn As Decimal) As Decimal
        Dim result As Decimal

        result = (((foreign - discount) * rate) * qty) - pph + ppn

        Return result
    End Function

    Private Sub obj_Terimabarang_foreignrate_LostFocus(sender As Object, e As EventArgs) Handles obj_Terimabarang_foreignrate.LostFocus
        If rateGotFocus <> Me.obj_Terimabarang_foreignrate.Text Then
            Dim pphAmountIDR As Decimal
            Dim ppnAmountIDR As Decimal
            Dim totalAmountIDR As Decimal
            Dim jurnalDetilIDR As Decimal

            '=== Ganti rate bpb detil ==
            For Each row As DataRow In Me.tbl_TrnPenerimaanbarangdetil.Rows
                row.Item("terimabarangdetil_foreignrate") = Me.obj_Terimabarang_foreignrate.Text

                pphAmountIDR = Me.calAmountTaxIdr(row.Item("terimabarangdetil_foreign"), _
                                                  row.Item("terimabarangdetil_disc"), row.Item("terimabarangdetil_qty"),
                                                  row.Item("terimabarangdetil_pphpercent"), row.Item("terimabarangdetil_foreignrate"))

                ppnAmountIDR = Me.calAmountTaxIdr(row.Item("terimabarangdetil_foreign"), row.Item("terimabarangdetil_disc"), _
                                                  row.Item("terimabarangdetil_qty"), row.Item("terimabarangdetil_ppnpercent"), _
                                                  row.Item("terimabarangdetil_foreignrate"))

                totalAmountIDR = Me.calAmountTotalIdrReal(row.Item("terimabarangdetil_foreign"), row.Item("terimabarangdetil_disc"), _
                                                           row.Item("terimabarangdetil_qty"), row.Item("terimabarangdetil_foreignrate"), pphAmountIDR, ppnAmountIDR)

                row.Item("terimabarangdetil_idrreal") = row.Item("terimabarangdetil_foreignrate") * row.Item("terimabarangdetil_foreign")
                row.Item("terimabarangdetil_pphidrreal") = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                row.Item("terimabarangdetil_ppnidrreal") = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                row.Item("terimabarangdetil_totalidrreal") = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)
            Next
            '===============================

            '=== Ganti rate bpb header ===
            With Me.tbl_TrnPenerimaanbarang_Temp.Rows(0)
                Me.obj_Terimabarang_idrreal.Text = Format(.Item("terimabarang_foreign") * .Item("terimabarang_foreignrate"), "###,##0.00")
                Me.obj_Terimabarang_pph.Text = Format(Me.tbl_TrnPenerimaanbarangdetil.Compute("Sum(terimabarangdetil_pphidrreal)", ""), "###,##0.00")
                Me.obj_Terimabarang_ppn.Text = Format(Me.tbl_TrnPenerimaanbarangdetil.Compute("Sum(terimabarangdetil_ppnidrreal)", ""), "###,##0.00")
            End With
            '=============================

            '=== Ganti rate jurnal bpb ============

            Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = Me.obj_Terimabarang_foreignrate.Text

            For Each row As DataRow In Me.tbl_TrnJurnaldetil_debet.Rows
                jurnalDetilIDR = row.Item("jurnaldetil_foreign") * row.Item("jurnaldetil_foreignrate")

                row.Item("jurnaldetil_foreignrate") = Me.obj_Terimabarang_foreignrate.Text
                row.Item("jurnaldetil_idr") = Math.Round(jurnalDetilIDR, 0, MidpointRounding.AwayFromZero)
            Next

            For Each row As DataRow In Me.tbl_TrnJurnaldetil_kredit.Rows
                jurnalDetilIDR = row.Item("jurnaldetil_foreign") * row.Item("jurnaldetil_foreignrate")

                row.Item("jurnaldetil_foreignrate") = Me.obj_Terimabarang_foreignrate.Text
                row.Item("jurnaldetil_idr") = Math.Round(jurnalDetilIDR, 0, MidpointRounding.AwayFromZero)
            Next
            '=======================================
        End If
    End Sub

    Private Function uiTrnPenerimaanBarang_OpenRowDetil2(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Try
            Me.BindingStopDetil()
            TLTrnPenerimaanBarangDetil.KeyFieldName = "terimabarangdetil_line"
            TLTrnPenerimaanBarangDetil.ParentFieldName = "terimabarangdetil_parentline"
            TLTrnPenerimaanBarangDetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil
            TLTrnPenerimaanBarangDetil.ExpandAll()
            Me.BindingStartdetil()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPenerimaanBarang_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub TLTrnPenerimaanBarangDetil_CellValueChanged(sender As Object, e As DevExpress.XtraTreeList.CellValueChangedEventArgs) Handles TLTrnPenerimaanBarangDetil.CellValueChanged
        Dim amountIdr As Decimal
        Dim ppnAmount As Decimal
        Dim ppnAmountIDR As Decimal
        Dim pphAmount As Decimal
        Dim pphAmountIDR As Decimal
        Dim totalAmount As Decimal
        Dim totalAmountIDR As Decimal

        If e.Node.Item("terimabarangdetil_foreign") Or _
            e.Node.Item("terimabarangdetil_qty") Or _
           e.Node.Item("terimabarangdetil_disc") Or _
            e.Node.Item("terimabarangdetil_pphpercent") Or _
            e.Node.Item("terimabarangdetil_ppnpercent") Or _
            e.Node.Item("terimabarangdetil_foreignrate") Then


            amountIdr = clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreign), Decimal), 0) * clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreignrate), Decimal), 0)

            pphAmount = ((clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreign), Decimal), 0) - clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_disc), Decimal), 0)) * clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_qty), Decimal), 0)) _
                                               * (clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_pphpercent), Decimal), 0) / 100)

            pphAmountIDR = ((clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreign), Decimal), 0) - clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_disc), Decimal), 0)) * clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_qty), Decimal), 0)) _
                        * (clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_pphpercent), Decimal), 0) / 100) * (clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreignrate), Decimal), 0))

            ppnAmount = ((clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreign), Decimal), 0) - clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_disc), Decimal), 0)) * clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_qty), Decimal), 0)) _
                                           * (clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_ppnpercent), Decimal), 0) / 100)

            ppnAmountIDR = ((clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreign), Decimal), 0) - clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_disc), Decimal), 0)) * clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_qty), Decimal), 0)) _
                        * (clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_ppnpercent), Decimal), 0) / 100) * (clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreignrate), Decimal), 0))

            totalAmount = ((clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreign), Decimal), 0) - clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_disc), Decimal), 0)) * clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_qty), Decimal), 0)) _
                        - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

            totalAmountIDR = (clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreign), Decimal), 0) - clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_disc), Decimal), 0)) * clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_foreignrate), Decimal), 0) * _
                              clsUtil.IsDbNull(CType(e.Node(cterimabarangdetil_qty), Decimal), 0) - _
                              clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

            e.Node(cterimabarangdetil_pphforeign) = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
            e.Node(cterimabarangdetil_ppnforeign) = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
            e.Node(cterimabarangdetil_totalforeign) = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)

            e.Node(cterimabarangdetil_idrreal) = Math.Round(amountIdr, 0, MidpointRounding.AwayFromZero)
            e.Node(cterimabarangdetil_pphidrreal) = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
            e.Node(cterimabarangdetil_ppnidrreal) = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
            e.Node(cterimabarangdetil_totalidrreal) = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)
        End If
    End Sub

    Private Sub TLTrnPenerimaanBarangDetil_KeyDown(sender As Object, e As KeyEventArgs) Handles TLTrnPenerimaanBarangDetil.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim criteriaMother As String = String.Format(" terimabarang_id = '{0}' AND terimabarangdetil_parentline= {1}", TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarang_id"), _
                            TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarangdetil_line"))
            Dim rowMother As DataRow() = tbl_TrnPenerimaanbarangdetil.Select(criteriaMother)

            If rowMother.Length > 0 Then
                MsgBox("Cant't Delete Parent Row", MsgBoxStyle.Critical)
            Else
                TLTrnPenerimaanBarangDetil.DeleteNode(TLTrnPenerimaanBarangDetil.FocusedNode)
            End If
        End If
    End Sub

    Private Sub TLTrnPenerimaanBarangDetil_ShowTreeListMenu(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.PopupMenuShowingEventArgs) Handles TLTrnPenerimaanBarangDetil.PopupMenuShowing
        Dim tree As TreeList = CType(sender, TreeList)
        Dim pt As Point = tree.PointToClient(MousePosition)
        Dim info As TreeListHitInfo = tree.CalcHitInfo(pt)

        If info.HitInfoType = HitInfoType.Cell Then
            tree.FocusedNode = info.Node
        End If

        If Me._USERTYPE = "acc" Then
            If Me.locking.Status = clsLockingTransaction.LockStatus.Locked Then
                Exit Sub
            Else
                e.Menu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Build Jurnal", AddressOf build_jurnal))

                Dim statusAppACC As Boolean = Me.tbl_TrnPenerimaanbarang_Temp(0).Item("terimabarang_appacc")

                If statusAppACC = True Then
                    e.Menu.Items.Item(0).Enabled = False
                Else
                    e.Menu.Items.Item(0).Enabled = True
                End If
            End If
        Else
            If Me.locking.Status = clsLockingTransaction.LockStatus.Locked Then
                Exit Sub
            Else
                e.Menu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Add Child", AddressOf add_item))
                e.Menu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Copy Item", AddressOf copy_item))
                e.Menu.Items.Add(New DevExpress.Utils.Menu.DXMenuItem("Copy With Child", AddressOf copy_ItemWithChild))

                If Me._MODULE_TYPE = ModuleType.LISTGQ Then
                    Dim move As New DevExpress.Utils.Menu.DXMenuItem("Move To New RV", AddressOf MoveToNewRV)

                    move.BeginGroup = True

                    e.Menu.Items.Add(move)
                End If

                If TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarangdetil_parentline") <> 0 Then
                    e.Menu.Items(0).Enabled = False
                    e.Menu.Items(1).Enabled = False
                End If
            End If

        End If
    End Sub

    Private Function add_item() As Boolean
        If Me.tbtnSave.Enabled Then
            TLTrnPenerimaanBarangDetil.BeginUnboundLoad()
            Dim row As DataRow = Me.tbl_TrnPenerimaanbarangdetil.NewRow
            row.Item("terimabarangdetil_parentline") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarangdetil_line")
            row.Item("terimabarangdetil_desc") = ""
            row.Item("terimabarang_parentbarcode") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarang_barcode")
            row.Item("assettype_id") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("assettype_id")
            row.Item("assetcategory_id") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("assetcategory_id")
            row.Item("item_id") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("item_id")
            row.Item("itemcategory_id") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("itemcategory_id")
            row.Item("itemtype_id") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("itemtype_id")
            row.Item("brand_id") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("brand_id")
            row.Item("terimabarangdetil_product_no") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarangdetil_product_no")
            row.Item("unit_id") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("unit_id")
            row.Item("currency_id") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("currency_id")
            row.Item("acc_id") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("acc_id")
            row.Item("budget_id") = TLTrnPenerimaanBarangDetil.FocusedNode.Item("budget_id")
            tbl_TrnPenerimaanbarangdetil.Rows.Add(row)
            tbl_TrnPenerimaanbarangdetil.GetChanges()
            TLTrnPenerimaanBarangDetil.EndUnboundLoad()
            TLTrnPenerimaanBarangDetil.ExpandAll()
        Else
            MsgBox("Data has been lock")
        End If

    End Function

    Private Sub copy_item()
        Me.copyItemWithChild(False)
    End Sub

    Private Sub copy_ItemWithChild()
        Me.copyItemWithChild(True)
    End Sub

    Private Sub copyItemWithChild(ByVal withChild As Boolean)
        If Me.tbtnSave.Enabled Then
            TLTrnPenerimaanBarangDetil.BeginUnboundLoad()

            Dim criteriaMother As String = String.Format(" terimabarang_id = '{0}' AND terimabarangdetil_line = {1}", TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarang_id"), _
                            TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarangdetil_line"))
            Dim rowMother As DataRow() = tbl_TrnPenerimaanbarangdetil.Select(criteriaMother)
            Dim criteriaChild As String = String.Format(" terimabarang_id = '{0}' AND terimabarangdetil_parentline = {1}", TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarang_id"), _
                            TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarangdetil_line"))
            Dim rowChild As DataRow() = tbl_TrnPenerimaanbarangdetil.Select(criteriaChild)
            Dim tbl_mother As DataTable
            Dim tbl_child As DataTable
            Dim newRow As DataRow
            Dim parentline As Int64

            If rowMother.Length > 0 Then
                tbl_mother = rowMother.CopyToDataTable()

                'Copy bagian parent
                '====================================================================
                For Each row As DataRow In tbl_mother.Rows
                    newRow = tbl_TrnPenerimaanbarangdetil.NewRow

                    For Each col As DataColumn In tbl_mother.Columns
                        If col.ColumnName <> "terimabarangdetil_line" And col.ColumnName <> "terimabarang_barcode" Then
                            newRow.Item(col.ColumnName) = row.Item(col.ColumnName)
                        End If
                    Next
                    tbl_TrnPenerimaanbarangdetil.Rows.Add(newRow)

                    parentline = newRow.Item("terimabarangdetil_line")
                Next
                '====================================================================

                'Copy bagian child
                '====================================================================
                If withChild = True Then
                    If rowChild.Length > 0 Then
                        tbl_child = rowChild.CopyToDataTable()

                        For Each row As DataRow In tbl_child.Rows
                            newRow = tbl_TrnPenerimaanbarangdetil.NewRow

                            For Each col As DataColumn In tbl_child.Columns
                                If col.ColumnName <> "terimabarangdetil_line" Then
                                    If col.ColumnName = "terimabarangdetil_parentline" Then
                                        newRow.Item(col.ColumnName) = parentline
                                    Else
                                        If col.ColumnName <> "terimabarang_barcode" Then
                                            newRow.Item(col.ColumnName) = row.Item(col.ColumnName)
                                        End If
                                    End If
                                End If
                            Next

                            tbl_TrnPenerimaanbarangdetil.Rows.Add(newRow)
                        Next
                    End If
                End If
                '====================================================================
            End If

            TLTrnPenerimaanBarangDetil.EndUnboundLoad()
        Else
            MsgBox("Data has been lock")
        End If
    End Sub

    Private Function build_jurnal() As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbTrans As OleDb.OleDbTransaction = Nothing
        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            dbTrans = dbConn.BeginTransaction()
            clsApplicationRole.SetAppRole(dbConn, dbTrans, cookie)

            Using receive As New clsTrnPenerimaanBarang(Me.DSNFrm)
                receive.BuildJurnal(Me.obj_Terimabarang_id.Text, dbConn, dbTrans)
            End Using

            dbTrans.Commit()

            Me.uiTrnPenerimaanBarang_RefreshPosition()
        Catch ex As OleDb.OleDbException
            dbTrans.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, dbTrans, cookie)
                dbConn.Close()
            End If
        End Try
    End Function

    Private Function FillDSTreelist_cbodevexpress() As Boolean
        RepositoryItemCategoryId.DataSource = Me.tbl_MstItemCategory
        RepositoryItemCategoryId.DisplayMember = "category_name"
        RepositoryItemCategoryId.ValueMember = "category_id"

        RepositoryAssetCategory.DataSource = Me.tbl_mstKategoriAsset
        RepositoryAssetCategory.DisplayMember = "kategoriasset_id"
        RepositoryAssetCategory.ValueMember = "kategoriasset_id"

        RepositoryCatDepre.DataSource = Me.tbl_MstKategoriAssetDepre
        RepositoryCatDepre.DisplayMember = "kategoriassetdepre_descr"
        RepositoryCatDepre.ValueMember = "kategoriassetdepre_id"

        RepositoryAssetType.DataSource = Me.tbl_MstTipeAsset
        RepositoryAssetType.DisplayMember = "tipeasset_id"
        RepositoryAssetType.ValueMember = "tipeasset_id"

        RepositoryItemId.DataSource = Me.tbl_MstItem
        RepositoryItemId.ValueMember = "item_id"
        RepositoryItemId.DisplayMember = "item_name"

        RepositoryBrandId.DataSource = Me.tbl_MstBrand
        RepositoryBrandId.ValueMember = "merk_id"
        RepositoryBrandId.DisplayMember = "merk_name"

        RepositoryMaterialId.DataSource = Me.tbl_MstMaterial
        RepositoryMaterialId.ValueMember = "Material_id"
        RepositoryMaterialId.DisplayMember = "Material_id"

        RepositoryColourId.DataSource = Me.tbl_MstWarna
        RepositoryColourId.ValueMember = "warna_id"
        RepositoryColourId.DisplayMember = "warna_id"
        '
        RepositorySizeId.DataSource = Me.tbl_MstUkuran
        RepositorySizeId.ValueMember = "ukuran_id"
        RepositorySizeId.DisplayMember = "ukuran_id"

        RepositorySexId.DataSource = Me.tbl_Mstsex
        RepositorySexId.ValueMember = "Pilihan"
        RepositorySexId.DisplayMember = "Pilihan"

        RepositoryRoomId.DataSource = Me.tbl_MstAssetruang
        RepositoryRoomId.ValueMember = "ruang_id"
        RepositoryRoomId.DisplayMember = "keterangan"

        RepositoryUnitId.DataSource = Me.tbl_MstUnit
        RepositoryUnitId.ValueMember = "unit_id"
        RepositoryUnitId.DisplayMember = "unit_shortname"

        RepositoryCurrency.DataSource = Me.tbl_MstCurrencyDetil
        RepositoryCurrency.ValueMember = "Currency_id"
        RepositoryCurrency.DisplayMember = "Currency_shortname"

        RepositoryShowId.DataSource = Me.tbl_MstShow
        RepositoryShowId.ValueMember = "show_id"
        RepositoryShowId.DisplayMember = "show_title"

        RepositoryShowIdCont.DataSource = Me.tbl_MstShowcont
        RepositoryShowIdCont.ValueMember = "show_id"
        RepositoryShowIdCont.DisplayMember = "show_title"
    End Function

    Private Sub RepositoryItemButtonPrint_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonPrint.ButtonClick
        If clsUtil.IsDbNull(Me.TLTrnPenerimaanBarangDetil.FocusedNode.Item("terimabarang_barcode"), String.Empty) <> String.Empty Then
            Dim nm_perusahaan As String = Me.getNamaPerusahaan()
            Me.PrintBarcodeTreeList(nm_perusahaan, Me.TLTrnPenerimaanBarangDetil.FocusedNode)
        End If
    End Sub

    Private Sub PrintBarcodeTreeList(ByVal nm_perusahan As String, ByVal barcodeRow As TreeListNode)
        Dim barcode As String = ""
        Dim tipe As String
        Dim result As String = ""
        Dim byteRst() As Byte
        Dim fileName As String = clsUtil.GetPathOfFolderExtra() & "Barcode\netbarcode.txt"
        Dim pathexe As String = clsUtil.GetPathOfFolderExtra() & "Barcode\Label.exe"
        Dim NotPrint As Boolean
        Dim acc_approve As Object
        Dim rowCount As Integer

        'Cek accounting approve
        rowCount = Me.tbl_TrnPenerimaanbarang_Temp.Rows.Count
        If rowCount > 0 Then
            If Me._MODULE_TYPE = ModuleType.PURCHASE OrElse Me._MODULE_TYPE = ModuleType.LISTPV Then
                acc_approve = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc")
                If acc_approve = False Then
                    MsgBox("Can't print barcode before approved by accounting.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
        Else
            Exit Sub
        End If
        '====================================

        barcode = barcodeRow.Item("terimabarang_barcode").ToString()
        If barcode.Trim <> "" Then
            NotPrint = barcodeRow.Item("terimabarangdetil_nonfixasset")
            tipe = barcodeRow.Item("terimabarangdetil_product_no").ToString()

            If NotPrint = True Then
            Else
                If tipe.ToLower() = "label" Then
                    tipe = "1"
                ElseIf tipe.ToLower() = "taffeta" Then
                    tipe = "2"
                End If

                result = result & nm_perusahan & vbTab & barcode & vbTab & tipe & vbCrLf
            End If
        End If

        ReDim byteRst(result.Length - 1)

        For i As Integer = 0 To byteRst.Length - 1
            byteRst(i) = Asc(result.Chars(i))
        Next

        If byteRst.Length = 0 Then
            Return
        End If

        My.Computer.FileSystem.WriteAllBytes(fileName, byteRst, False)
        Shell(pathexe, AppWinStyle.NormalFocus)
    End Sub

    Private Sub btnBrowseDetil_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles btnBrowseDetil.ButtonClick
        Dim approved As Object

        Me.pnlDetil.Visible = True
        Me.pnlDetil.Dock = DockStyle.Fill
        Me.tbtnSave.Enabled = False

        Me.btnHome.Visible = True

        Me.BindingStopDetil()
        Me.BindingStartdetil()

        If Me.obj_Assettype_id.Text.Trim = "Consumable" Then
            Me.lblQtyDetail.Visible = True
            Me.lblQtyTotal.Visible = True
            Me.obj_Terimabarangdetil_qtydetail.Visible = True
            Me.obj_Terimabarangdetil_qtytotal.Visible = True
        Else
            Me.lblQtyDetail.Visible = False
            Me.lblQtyTotal.Visible = False
            Me.obj_Terimabarangdetil_qtydetail.Visible = False
            Me.obj_Terimabarangdetil_qtytotal.Visible = False
        End If

        Select Case Me._USERTYPE
            Case "user"
                If Me.tbl_TrnPenerimaanbarang_Temp.Rows.Count = 0 Then
                    approved = False
                Else
                    approved = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appuser")
                    approved = clsUtil.IsDbNull(approved, False)
                End If

                Me.SetReadOnlyDetil(approved)
            Case "spv"
                If Me.tbl_TrnPenerimaanbarang_Temp.Rows.Count = 0 Then
                    approved = False
                Else
                    approved = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appspv")
                    approved = clsUtil.IsDbNull(approved, False)
                End If

                Me.SetReadOnlyDetil(approved)
            Case "acc"
                If Me.tbl_TrnPenerimaanbarang_Temp.Rows.Count = 0 Then
                    approved = False
                Else
                    approved = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc")
                    approved = clsUtil.IsDbNull(approved, False)
                End If

                If approved = True Then
                    Me.SetReadOnlyDetil(True)
                ElseIf approved = False Then
                    If Me.obj_Assettype_id.Text.Trim <> "Consumable" Then
                        Me.SetReadOnlyDetil(True)

                        Me.obj_Assettype_id.Enabled = True
                        'PTS20150909
                        Me.obj_Terimabarangdetil_golfiskal.Enabled = True
                        '=========
                    Else
                        Me.SetReadOnlyDetil(True)
                    End If

                    Me.btnCategory.Enabled = True
                    Me.obj_Terimabarangdetil_nonfixasset.AutoCheck = True
                End If
        End Select

        If obj_Assettype_id.Text.Trim = "Asset Program" Or obj_Assettype_id.Text.Trim = "Asset Non Program" Then
            If Me.obj_Assetcategory_id.Text.Trim.ToLower() = "tanah" Then
                Me.obj_Acc_id.Enabled = True
            Else
                Me.obj_Acc_id.Enabled = False
            End If
        Else
            Me.obj_Acc_id.Enabled = True
        End If

        Me.obj_Terimabarangdetil_foreign.ReadOnly = True
        Me.obj_Terimabarangdetil_foreignrate.ReadOnly = True
        Me.obj_Terimabarangdetil_idrreal.ReadOnly = True
        Me.obj_Terimabarangdetil_pphpercent.ReadOnly = True
        Me.obj_Terimabarangdetil_ppnpercent.ReadOnly = True
        Me.obj_Terimabarangdetil_disc.ReadOnly = True
        Me.obj_Terimabarangdetil_pphforeign.ReadOnly = True
        Me.obj_Terimabarangdetil_ppnforeign.ReadOnly = True
        Me.obj_Terimabarangdetil_totalforeign.ReadOnly = True
        Me.obj_Terimabarangdetil_pphidrreal.ReadOnly = True
        Me.obj_Terimabarangdetil_ppnidrreal.ReadOnly = True
        Me.obj_Terimabarangdetil_totalidrreal.ReadOnly = True
        Me.obj_Currency_iddetil.Enabled = False
    End Sub

    Private Sub TLTrnPenerimaanBarangDetil_ShowingEditor(sender As Object, e As CancelEventArgs) Handles TLTrnPenerimaanBarangDetil.ShowingEditor
        Dim tree As TreeList = CType(sender, TreeList)
        If _USERTYPE = "acc" Then
            Select Case tree.FocusedColumn.FieldName
                Case select_detail.FieldName
                Case cprint_barcode.FieldName
                Case Else
                    e.Cancel = True
            End Select
        Else
            If (tree.FocusedNode.Item("terimabarangdetil_parentline") <> "0" And tree.FocusedNode.Item("order_id") = "") _
                And (tree.FocusedColumn.FieldName = "terimabarangdetil_foreign" Or tree.FocusedColumn.FieldName = "terimabarangdetil_foreignrate" Or _
                     tree.FocusedColumn.FieldName = "terimabarangdetil_pphpercent" Or tree.FocusedColumn.FieldName = "terimabarangdetil_ppnpercent" Or _
                     tree.FocusedColumn.FieldName = "terimabarangdetil_disc") Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub TLTrnPenerimaanBarangDetil_ValidateNode(sender As Object, e As DevExpress.XtraTreeList.ValidateNodeEventArgs) Handles TLTrnPenerimaanBarangDetil.ValidateNode

    End Sub

    Private Sub MoveToNewRV()
        Dim dlg As New dlgRVSelect(Me.DSNFrm, Me._CHANNEL)
        Dim newRv As String
        Dim NewLine As String
        Dim barcode As String = TLTrnPenerimaanBarangDetil.FocusedNode(cterimabarang_barcode)
        Dim currRv As String = TLTrnPenerimaanBarangDetil.FocusedNode(cterimabarang_id)
        Dim currLine As String = TLTrnPenerimaanBarangDetil.FocusedNode(cterimabarangdetil_line)

        If Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appuser") <> 0 Or Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appspv") <> 0 _
            Or Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc") <> 0 Then
            MsgBox("Please Unapprove this RV")
            Exit Sub
        End If

        If Me.uiTrnPenerimaanbarang_FormChanges() Then
            Exit Sub
        End If

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim row As DataRow = CType(dlg.DgvTrnPenerimaanbarangdetil.CurrentRow.DataBoundItem, DataRowView).Row
            Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
            Dim dbTrans As OleDb.OleDbTransaction
            Dim dbCmdDelete As OleDb.OleDbCommand
            Dim dbCmdUpdate As OleDb.OleDbCommand
            Dim cookie As Byte() = Nothing

            newRv = row.Item("terimabarang_id").ToString()
            NewLine = row.Item("terimabarangdetil_line").ToString()

            Dim filephoto_lama As String = Me.ImageServer & "\master_asset\" & currRv & "_" & currLine & ".jpg"
            Dim filephoto_lama_k As String = Me.ImageServer & "\master_asset\images_kecil\" & currRv & "_" & currLine & "K.jpg"
            Dim filephoto_baru As String = Me.ImageServer & "\master_asset\" & newRv & "_" & NewLine & ".jpg"
            Dim filephoto_baru_k As String = Me.ImageServer & "\master_asset\images_kecil\" & newRv & "_" & NewLine & "K.jpg"

            dbConnAsset.Open()
            dbTrans = dbConnAsset.BeginTransaction()
            clsApplicationRole.SetAppRole(dbConnAsset, dbTrans, cookie)
            Try
                'update barcode
                dbCmdUpdate = New OleDb.OleDbCommand("as_PenerimaanBarangUpdateBarcode", dbConnAsset, dbTrans)
                dbCmdUpdate.CommandType = CommandType.StoredProcedure
                dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24))
                dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4))
                dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_barcode", System.Data.OleDb.OleDbType.VarWChar, 24))
                dbCmdUpdate.Parameters("@terimabarang_id").Value = newRv
                dbCmdUpdate.Parameters("@terimabarangdetil_line").Value = NewLine
                dbCmdUpdate.Parameters("@terimabarang_barcode").Value = barcode

                dbCmdDelete = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Delete", dbConnAsset, dbTrans)
                dbCmdDelete.CommandType = CommandType.StoredProcedure
                dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24))
                dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4))
                dbCmdDelete.Parameters("@terimabarang_id").Value = currRv
                dbCmdDelete.Parameters("@terimabarangdetil_line").Value = currLine

                dbCmdUpdate.ExecuteReader()
                dbCmdDelete.ExecuteReader()

                dbTrans.Commit()

                '' Pindahkan gambar asset
                ''===============================================
                'If IO.File.Exists(filephoto_baru) = True Then
                '    IO.File.Delete(filephoto_baru)

                '    If IO.File.Exists(filephoto_lama) = True Then
                '        IO.File.Copy(filephoto_lama, filephoto_baru)
                '        IO.File.Delete(filephoto_lama)
                '    End If
                'Else
                '    If IO.File.Exists(filephoto_lama) = True Then
                '        IO.File.Copy(filephoto_lama, filephoto_baru)
                '        IO.File.Delete(filephoto_lama)
                '    End If
                'End If
                ''================================================

                '' Pindahkan gambar asset kecil
                ''================================================
                'If IO.File.Exists(filephoto_baru_k) = True Then
                '    IO.File.Delete(filephoto_baru_k)

                '    If IO.File.Exists(filephoto_lama_k) = True Then
                '        IO.File.Copy(filephoto_lama_k, filephoto_baru_k)
                '        IO.File.Delete(filephoto_lama_k)
                '    End If
                'Else
                '    If IO.File.Exists(filephoto_lama_k) = True Then
                '        IO.File.Copy(filephoto_lama_k, filephoto_baru_k)
                '        IO.File.Delete(filephoto_lama_k)
                '    End If
                'End If
                ''================================================

                uiTrnPenerimaanBarang_OpenRow(DgvTrnPenerimaanbarang.CurrentRow.Index)
                'Catch ex As OleDb.OleDbException
                '    dbTrans.Rollback()

                '    MsgBox(ex.Message, MsgBoxStyle.Critical)
            Catch ex As Exception
                dbTrans.Rollback()

                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                clsApplicationRole.UnsetAppRole(dbConnAsset, dbTrans, cookie)
                dbConnAsset.Close()
            End Try

            Dim db As New DataClassesFILESDataContext(Me.DSNFiles)

            Try
                'Pindahkan gambar asset database mode
                '--------------------------------------------------------
                db.OpenConnectionWithRole()

                db.as_PenerimaanBarangDetilPicture_Rename(currRv, currLine, newRv, NewLine)
                '--------------------------------------------------------
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                db.CloseConnectionWithRole()
            End Try
        End If
    End Sub

    Public Sub SetControls_LockingTransactionTryLocking() Implements ILocking.SetControls_LockingTransactionTryLocking
        Dim currentRow As DataRow = CType(Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).Current, DataRowView).Row
        Dim user_approved As Boolean = currentRow.Item("terimabarang_appuser")
        Dim spv_approved As Boolean = currentRow.Item("terimabarang_appspv")
        Dim acc_approved As Boolean = currentRow.Item("terimabarang_appacc")

        Dim status As clsLockingTransaction.LockStatus
        status = locking.Status 'locking.Status 'clsLockingTransaction.LockStatus.LockedByMe

        Select Case status
            Case clsLockingTransaction.LockStatus.LockedByMe
                If _USERTYPE = "user" Then

                    Me.tbtnSave.Enabled = True
                    Me.tbtnDel.Enabled = True
                    Me.Btn_Add.Enabled = True
                ElseIf _USERTYPE = "spv" Then
                    Me.tbtnSave.Enabled = True
                    Me.tbtnDel.Enabled = True
                    Me.Btn_Add.Enabled = True
                ElseIf _USERTYPE = "acc" Then
                    Me.tbtnSave.Enabled = True
                    Me.tbtnDel.Enabled = True
                    Me.Btn_Add.Enabled = True
                End If

                Me.tbtnPrint.Enabled = True
                Me.tbtnPrintPreview.Enabled = True
            Case clsLockingTransaction.LockStatus.Locked
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnPrint.Enabled = True
                Me.tbtnPrintPreview.Enabled = True
                Me.Btn_Add.Enabled = False
                Me.btnApproved.Enabled = False
                Me.btnUnApproved.Enabled = False
        End Select
    End Sub

    Private Sub obj_Jurnal_bookdate_ValueChanged(sender As Object, e As EventArgs) Handles obj_Jurnal_bookdate.ValueChanged
        If TLTrnPenerimaanBarangDetil.Nodes.Count > 0 Then
            For Each row As TreeListNode In TLTrnPenerimaanBarangDetil.Nodes
                If Not obj_Jurnal_bookdate.Text <> "" Then
                    row.Item("terimabarangdetil_date") = obj_Jurnal_bookdate.Value
                End If
            Next
        End If

        Dim periodebookdate As String = String.Empty
        Dim tbl_periode As DataTable = New DataTable
        tbl_periode.Clear()
        Me.DataFill(tbl_periode, "ms_MstPeriodeCombo_Select", String.Format("channel_id = '{0}' AND MONTH(periode_datestart) = MONTH('{1}')AND YEAR(periode_datestart) = YEAR('{1}')", Me._CHANNEL, Format(Me.obj_Jurnal_bookdate.Value, "yyyy/MM/dd").ToString))
        If tbl_periode.Rows.Count <> 0 Then
            periodebookdate = tbl_periode.Rows(0).Item("periode_id")
            Me.cbo_periode.SelectedValue = periodebookdate
        End If
    End Sub
End Class