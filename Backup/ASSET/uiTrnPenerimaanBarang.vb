'================================================== 
' Yanuar Andriyana Putra
' TransTV

' Created Date: 6/18/2010 2:20 PM
' 


Imports Microsoft.Win32
Imports System.Threading
Imports System.ComponentModel

Public Class uiTrnPenerimaanBarang
    Private Const mUiName As String = "Transaksi Penerimaan Barang"
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

    Private tbl_TrnPenerimaanbarang As DataTable = clsDataset.CreateTblTrnPenerimaanbarang()
    Private tbl_TrnPenerimaanbarang_Temp As DataTable = clsDataset.CreateTblTrnPenerimaanbarang()
    Private tbl_TrnPenerimaanbarangdetil As DataTable = clsDataset.CreateTblTrnPenerimaanbarangdetil()

    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_MstRekananDetil As DataTable = clsDataset.CreateTblMstrekananCombo()

    'Search
    Private tbl_MstChannel_search As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstRekanan_search As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_MstStrukturunit_search As DataTable = clsDataset.CreateTblStrukturunitPemilik
    Private tbl_MstStrukturunitDetil As DataTable = clsDataset.CreateTblStrukturunitPemilik

    Private tbl_MstAccGrid As DataTable = clsDataset.CreateTblMstAccountCombo()
    Private tbl_MstAccGridDetil As DataTable = clsDataset.CreateTblMstAccountCombo()

    Private Tbl_Mstemployee As DataTable = clsDataset.CreateTblemployeepemilik()
    Private Tbl_MstemployeeDetil As DataTable = clsDataset.CreateTblemployeepemilik()

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
    Private tbl_mstKategoriAssetDetil As DataTable = clsDataset.CreateTblMstKategoriasset
    Private tbl_MstTipeAssetDetil As DataTable = clsDataset.CreateTblMstTipeasset
    Private tbl_MstItemDetil As DataTable = clsDataset.CreateTblMstItem
    Private tbl_MstItemCategoryDetil As DataTable = clsDataset.CreateTblMstItemcategory
    Private tbl_MstBrandDetil As DataTable = clsDataset.CreateTblMstMerk
    Private tbl_MstTipeitemDetil As DataTable = clsDataset.CreateTblMstTipeitem
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


#Region " Window Parameter "
    Private _CHANNEL As String = "NTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
    Private _STRUKTUR_UNIT As Decimal = 5522 '5554 ' 5517 '3130 '5517 '2610 '2360 '3501
    Private _USERTYPE As String = "user" 'spv 'acc
    ' TODO: Buat variabel untuk menampung parameter window 

#End Region

#Region " Additional Overrides "
    Private Sub btnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproved.Click
        If Me._USERTYPE = "acc" Then
            Me.uiTrnPenerimaanBarang_Purchase_JurnalSave()
        Else
            'Me.uiTrnPenerimaanBarang_Save()
        End If

        If Me.DgvTrnPenerimaanbarang.Rows.Count > 0 Then
            If Me._USERTYPE = "user" Then
                If Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appuser").Value = False Then
                    Me.uiTrnPenerimaanBarang_Purchase_AppUser("approved")
                    Me.btnApproved.Enabled = False
                    Me.btnUnApproved.Enabled = True
                End If
            ElseIf Me._USERTYPE = "spv" Then
                If Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appuser").Value = False Then
                    MsgBox("Need User Approved", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appspv").Value = False Then
                    Me.uiTrnPenerimaanBarang_Purchase_AppSpv("approved")
                End If
            ElseIf Me._USERTYPE = "acc" Then
                If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appuser").Value, False) = False Then
                    MsgBox("Need User Approved", MsgBoxStyle.Information)
                ElseIf clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appspv").Value, False) = False Then
                    MsgBox("Need Spv Approved", MsgBoxStyle.Information)
                ElseIf clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_appacc").Value, False) = False Then
                    Me.uiTrnPenerimaanBarang_Purchase_AppAcc("approved")
                End If
            End If

            Dim dbconnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)

            Me.uiTrnPenerimaanBarang_OpenRowDetil(Me._CHANNEL, Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value, dbconnAsset)

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
                    'unapproved user
                    Me.uiTrnPenerimaanBarang_Purchase_AppUser("unapproved")
                    Me.btnApproved.Enabled = True
                    Me.btnUnApproved.Enabled = False
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

                    Me.DataFill(tbl_periode, "ms_MstPeriode_Select", String.Format("periode_id = {0}", Me.cbo_periode.SelectedValue))

                    If tbl_periode.Rows(0).Item("periode_isclosed") = True Then
                        MsgBox("Periode is closed")
                        Exit Sub
                    Else
                        Me.uiTrnPenerimaanBarang_Purchase_AppAcc("unapproved")
                    End If

                End If
            End If

            Dim dbconnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)

            Me.uiTrnPenerimaanBarang_OpenRowDetil(Me._CHANNEL, Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value, dbconnAsset)

        End If

    End Sub
    Private Sub btnHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHome.Click
        Me.pnlDetil.Visible = False
        Me.btnHome.Visible = False
    End Sub

    Private Sub uiTrnPenerimaanBarang_Purchase_AppUser(ByVal status As String)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Try
            dbConnAsset.Open()
            Dim oCm As New OleDb.OleDbCommand("as_TrnPerimaanBarang_UserApproved", dbConnAsset)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24).Value = Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
            oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
            oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status
            oCm.ExecuteNonQuery()
            oCm.Dispose()

            If status = "approved" Then
                Me.obj_Terimabarang_appuser.Checked = True
                Me.DgvTrnPenerimaanbarang.Item("terimabarang_appuser", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 1
                MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.obj_Terimabarang_appuser.Checked = False
                Me.DgvTrnPenerimaanbarang.Item("terimabarang_appuser", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0
                MessageBox.Show("Data Has Been UnApproved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConnAsset.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub uiTrnPenerimaanBarang_Purchase_AppSpv(ByVal status_approved As String)
        Dim dlg As New dlgStatusTerimaJasa()
        Dim status As String = String.Empty
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbConnStart As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.START_DSN)

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If status_approved = "approved" Then

            status = dlg.OpenDialog(Me)

            If status IsNot Nothing Then
                If status = "-- Pilih --" Then
                    MsgBox("Please choose COMPLETE or INCOMPLETE")
                    Exit Sub
                Else
                    Dim success As Boolean

                    If Me.uiTrnPenerimaanBarang_FormErrorValidasi() Then
                        Exit Sub
                    End If

                    success = Me.uiTrnPenerimaanBarang_ValidasiAsset(Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value, Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value)
                    If success = False Then
                        Throw New Exception("Error: Barcoding Item  ")
                        Exit Sub
                    End If

                    ' ''Me.UpdateBarcodeAfterLockData()


                    Try

                        Me.uiTrnPenerimaanBarang_Purchase_BuiltJurnal()
                        dbConn.Open()
                        dbConnStart.Open()
                        Dim oCm As New OleDb.OleDbCommand("as_TrnPenerimaanBarang_SpvApproved", dbConnStart)
                        oCm.CommandType = CommandType.StoredProcedure
                        oCm.Parameters.Add("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.obj_Terimabarang_id.Text
                        oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
                        oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
                        oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 40).Value = status
                        oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("order_id").Value
                        oCm.Parameters.Add("@status_approved", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status_approved
                        oCm.ExecuteNonQuery()
                        oCm.Dispose()
                        Me.obj_Terimabarang_appspv.Checked = True
                        Me.DgvTrnPenerimaanbarang.Item("terimabarang_appspv", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 1
                        Me.btnApproved.Enabled = False
                        Me.btnUnApproved.Enabled = True
                        Me.tbtnDel.Enabled = False
                        Me.tbtnSave.Enabled = False
                        MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Data.OleDb.OleDbException
                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Catch ex As Exception
                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        dbConn.Close()
                        dbConnStart.Close()
                    End Try
                End If
            End If
        Else
            Try
                'dbConn.Open()
                dbConnStart.Open()
                Dim oCm As New OleDb.OleDbCommand("as_TrnPenerimaanBarang_SpvApproved", dbConnStart)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
                oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
                oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
                oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 40).Value = status
                oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("order_id").Value
                oCm.Parameters.Add("@status_approved", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status_approved
                oCm.ExecuteNonQuery()
                oCm.Dispose()
                Me.obj_Terimabarang_appspv.Checked = False
                Me.DgvTrnPenerimaanbarang.Item("terimabarang_appspv", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0
                MessageBox.Show("Data Has Been UnApproved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnApproved.Enabled = True
                Me.btnUnApproved.Enabled = False
                Me.tbtnDel.Enabled = True
                Me.tbtnSave.Enabled = True
                Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_kredit(Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value, Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value, dbConn)
                Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_Debet(Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value, Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value, dbConn)
                Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalReference(Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value, Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value, dbConn)
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                'dbConn.Close()
                dbConnStart.Close()
            End Try
        End If

        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub uiTrnPenerimaanBarang_Purchase_AppAcc(ByVal status As String)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.uiTrnPenerimaanBarang_FormError() Then
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Exit Sub
        End If
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Try
            dbConn.Open()
            'dbConnAsset.Open()
            Dim oCm As New OleDb.OleDbCommand("as_TrnPenerimaanBarang_AccApproved", dbConn)

            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
            oCm.Parameters.Add("@acc_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
            oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status

            oCm.ExecuteNonQuery()
            oCm.Dispose()

            Try
                'dbConn.Open()
                dbConnAsset.Open()
                Dim oCmAsset As New OleDb.OleDbCommand("as_TrnPenerimaanBarang_AccApproved", dbConnAsset)

                oCmAsset.CommandType = CommandType.StoredProcedure
                oCmAsset.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
                oCmAsset.Parameters.Add("@acc_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
                oCmAsset.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
                oCmAsset.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status

                oCmAsset.ExecuteNonQuery()
                oCmAsset.Dispose()
            Catch ex As Exception
                dbConnAsset.Close()
            End Try

            If status = "approved" Then
                Me.obj_Terimabarang_appacc.Checked = True
                MessageBox.Show("Data Has Been Post", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DgvTrnPenerimaanbarang.Item("terimabarang_appacc", Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 1

                'If Me.tbl_TrnJurnal.Rows.Count > 0 Then
                '    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 1
                '    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_ispostedby") = Me.UserName
                '    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposteddate") = Now()
                'End If

                Me.btnApproved.Enabled = False
                Me.btnUnApproved.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnSave.Enabled = False
            Else
                Me.obj_Terimabarang_appacc.Checked = False
                MessageBox.Show("Data Has Been UnPost", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DgvTrnPenerimaanbarang.Item("terimabarang_appacc", Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0

                'If Me.tbl_TrnJurnal.Rows.Count > 0 Then
                '    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 0
                '    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_ispostedby") = String.Empty
                '    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposteddate") = DBNull.Value
                'End If

                Me.btnApproved.Enabled = True
                Me.btnUnApproved.Enabled = False
                Me.tbtnDel.Enabled = True
                Me.tbtnSave.Enabled = True
            End If
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
            'dbConnAsset.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub uiTrnPenerimaanBarang_Purchase_BuiltJurnal()
        Dim rows_debet, rows_kredit, rows_reference As Integer
        Dim order_id As String
        Dim tbl_orderTemp As DataTable = New DataTable
        Dim tbl_debetTemp As DataTable = New DataTable
        Dim tblUsage As DataTable = New DataTable
        Dim total_usage As Integer = 0
        Dim q As Integer = 0
        Dim criteria As String = String.Empty

        Dim pphAmount As Decimal
        Dim ppnAmount As Decimal
        Dim amountForeign As Decimal
        Dim amountIdrreal As Decimal
        Dim amountDiscount As Decimal
        Dim rate As Decimal

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Me.tbl_TrnJurnal.Clear()
        Me.tbl_TrnJurnaldetil_debet.Clear()
        Me.tbl_TrnJurnaldetil_kredit.Clear()
        Me.tbl_JurnalReference.Clear()

        If Me.tbl_TrnPenerimaanbarangdetil.Rows.Count > 0 Then
            order_id = Me.obj_Order_id.Text

            tbl_debetTemp.Clear()
            tbl_TrnJurnal.Clear()

            Me.DataFill(tbl_debetTemp, "ms_MstAcc_SelectBySource", String.Format("B.source_id = 'RV-ListBpj' AND B.dk = 'K' WHERE B.source_id = 'RV-ListBpj' AND B.dk = 'K'"))

            '============ Mulai masukkan data ke tab bagian Debet Na =======
            For rows_debet = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
                Dim budget_name() As DataRow
                Dim budgetdetil_name() As DataRow
                budget_name = Me.tbl_TrnBudget.Select(String.Format("budget_id = {0}", Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("budget_id")))
                budgetdetil_name = Me.tbl_TrnBudgetDetil.Select(String.Format("budget_id = {0} AND budgetdetil_id = {1}", Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("budget_id"), Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("budgetdetil_id")))

                Me.tbl_TrnJurnaldetil_debet.Rows.Add()
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnal_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarang_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("acc_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("acc_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_foreignrate") = (String.Format("{0:#,##0.00}", CDec(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_foreignrate"))))

                If clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_qty"), 0) = 0 Then
                    Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_foreign") = 0
                    Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_idr") = 0

                Else
                    Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_foreign") = Math.Round((clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_foreign"), 0) - clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_disc"), 0)) * clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_qty"), 0), 2, MidpointRounding.AwayFromZero)
                    Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_foreign"), 0) - clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_disc"), 0)) * clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_foreignrate"), 0)) * clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_qty"), 0), 0, MidpointRounding.AwayFromZero)

                End If
                
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_desc")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("ref_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("order_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("ref_line") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("orderdetil_line")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("currency_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("currency_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("strukturunit_id") = Me._STRUKTUR_UNIT 'Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("strukturunit_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("budget_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("budget_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("budget_name") = Trim(budget_name(0).Item(2))
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("budgetdetil_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("budgetdetil_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("budgetdetil_name") = Trim(budgetdetil_name(0).Item(2))

                'baru
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_line") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_line")
 
                pphAmount += clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_pphidrreal"), 0)
                ppnAmount += clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_ppnidrreal"), 0)
                amountForeign += clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_foreign"), 0) * clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_qty"), 0)
                amountIdrreal += clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_qty"), 0)
                'amountDiscount += clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_disc"), 0) 
                amountDiscount += clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_disc"), 0) * clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_qty"), 0)
                rate = clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_debet).Item("terimabarangdetil_foreignrate"), 0)
 
            Next
            '============ Akhir dari masukkan data ke tab bagian Debet ===========

            '============ Mulai masukkan data ke tab bagian Kredit Na =======
            For rows_kredit = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
                Dim budget_name() As DataRow
                Dim budgetdetil_name() As DataRow
                budget_name = Me.tbl_TrnBudget.Select(String.Format("budget_id = {0}", Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("budget_id")))
                budgetdetil_name = Me.tbl_TrnBudgetDetil.Select(String.Format("budget_id = {0} AND budgetdetil_id = {1}", Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("budget_id"), Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("budgetdetil_id")))

                Me.tbl_TrnJurnaldetil_kredit.Rows.Add()
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnal_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarang_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_foreignrate") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_foreignrate")

                If clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_qty"), 0) = 0 Then
                    Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_foreign") = 0
                    Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_idr") = 0

                Else
                    Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_foreign") = Math.Round((clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_foreign"), 0) - clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_disc"), 0)) * clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_qty"), 0), 2, MidpointRounding.AwayFromZero)
                    Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_foreign"), 0) - clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_disc"), 0)) * clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_foreignrate"), 0)) * clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_qty"), 0), 0, MidpointRounding.AwayFromZero)

                End If
                
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_descr") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_desc")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("ref_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("order_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("ref_line") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("orderdetil_line")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("currency_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("currency_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("strukturunit_id") = Me._STRUKTUR_UNIT 'Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("strukturunit_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("budget_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("budget_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("budget_name") = Trim(budget_name(0).Item(2))
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("budgetdetil_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("budgetdetil_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("budgetdetil_name") = Trim(budgetdetil_name(0).Item(2))

                'tambahan
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_line") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_kredit).Item("terimabarangdetil_line") - 5

            Next
            '============ Akhir dari masukkan data ke tab bagian Kredit ===========

            '============ Mulai masukkan data ke tab bagian Reference Na =======
            For rows_reference = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
                Me.tbl_JurnalReference.Rows.Add()
                Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_reference).Item("terimabarang_id")
                Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_ref") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_reference).Item("order_id")
                Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_refline") = Me.tbl_TrnPenerimaanbarangdetil.Rows(rows_reference).Item("orderdetil_line")
            Next
            '============ Akhir dari masukkan data ke tab Reference Kredit ===========

            '============ Mulai masukkan data ke tabel bagian Header Na =======
            If Me.tbl_TrnPenerimaanbarangdetil.Rows.Count > 0 Then
                Me.tbl_TrnJurnal.Rows.Add()
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_id").Value
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_duedate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_notes").Value
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_invoice_id") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_invoice_descr") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBPB"
                Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = String.Format("{0:yyMM}", Now)
                Me.tbl_TrnJurnal.Rows(0).Item("channel_id") = Me._CHANNEL
                Me.tbl_TrnJurnal.Rows(0).Item("budget_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("currency_id").Value
                Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = rate
                Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = Me._STRUKTUR_UNIT
                Me.tbl_TrnJurnal.Rows(0).Item("acc_ca_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("region_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("branch_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("advertiser_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("brand_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("ae_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_iscreated") = 1
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_iscreatedby") = "SYSTEM"
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_iscreatedate") = Now()
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_ispostedby") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposteddate") = DBNull.Value
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisabled") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisabledby") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisableddt") = DBNull.Value
                Me.tbl_TrnJurnal.Rows(0).Item("created_by") = Me.UserName
                Me.tbl_TrnJurnal.Rows(0).Item("created_dt") = Now()
                Me.tbl_TrnJurnal.Rows(0).Item("modified_by") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("modified_dt") = DBNull.Value

                Me.obj_Terimabarang_foreign.Text = amountForeign
                Me.obj_Terimabarang_idrreal.Text = amountIdrreal
                Me.obj_Terimabarang_pph.Text = pphAmount
                Me.obj_Terimabarang_ppn.Text = ppnAmount
                Me.obj_Terimabarang_disc.Text = amountDiscount
                Me.obj_Terimabarang_foreignrate.Text = rate
            End If
            '============ Akhir dari masukkan data ke tabel Header ===========
            Dim x As Integer
            Dim isAcc_ok As String
            For x = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
                If clsUtil.IsDbNull(Me.tbl_TrnPenerimaanbarangdetil.Rows(x).Item("acc_id"), "") = "" Then
                    isAcc_ok = "not"
                    Exit For
                Else
                    isAcc_ok = "ok"
                End If
            Next
            If isAcc_ok = "ok" Then
                Me.uiTrnPenerimaanBarang_Purchase_JurnalSave()
                Me.uiTrnPenerimaanBarang_Save()
            End If
        End If
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
        If Me.uiTrnPenerimaanBarang_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        If Me._USERTYPE = "acc" Then
            Me.uiTrnPenerimaanBarang_Purchase_JurnalSave()
            Me.uiTrnPenerimaanBarang_Save()
        Else
            Me.uiTrnPenerimaanBarang_Save()
        End If 
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
        cTerimabarang_appacc.Visible = True
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
        cRekanan_name.HeaderText = "Rekanan"
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
        objDgv.MultiSelect = False
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
        Dim cItemtype_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
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
        cTerimabarangdetil_date.Visible = True
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
        cItemtype_id.DataSource = Me.tbl_MstTipeitem
        cItemtype_id.ValueMember = "tipeitem_id"
        cItemtype_id.DisplayMember = "tipeitem_id"
        cItemtype_id.DisplayStyleForCurrentCellOnly = True

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
        cTerimabarangdetil_product_no.HeaderText = "Product No."
        cTerimabarangdetil_product_no.DataPropertyName = "terimabarangdetil_product_no"
        cTerimabarangdetil_product_no.Width = 100
        cTerimabarangdetil_product_no.Visible = True
        cTerimabarangdetil_product_no.ReadOnly = False

        cTerimabarangdetil_model.Name = "terimabarangdetil_model"
        cTerimabarangdetil_model.HeaderText = "Model No."
        cTerimabarangdetil_model.DataPropertyName = "terimabarangdetil_model"
        cTerimabarangdetil_model.Width = 100
        cTerimabarangdetil_model.Visible = True
        cTerimabarangdetil_model.ReadOnly = False

        cMaterial_id.Name = "material_id"
        cMaterial_id.HeaderText = "Material"
        cMaterial_id.DataPropertyName = "material_id"
        cMaterial_id.Width = 100
        cMaterial_id.Visible = True
        cMaterial_id.ReadOnly = False
        cMaterial_id.DataSource = Me.tbl_MstMaterial
        cMaterial_id.ValueMember = "Material_id"
        cMaterial_id.DisplayMember = "Material_id"
        cMaterial_id.DisplayStyleForCurrentCellOnly = True

        cColour_id.Name = "colour_id"
        cColour_id.HeaderText = "Colour"
        cColour_id.DataPropertyName = "colour_id"
        cColour_id.Width = 100
        cColour_id.Visible = True
        cColour_id.ReadOnly = False
        cColour_id.DataSource = Me.tbl_MstWarna
        cColour_id.ValueMember = "warna_id"
        cColour_id.DisplayMember = "warna_id"
        cColour_id.DisplayStyleForCurrentCellOnly = True

        cSize_id.Name = "size_id"
        cSize_id.HeaderText = "Size"
        cSize_id.DataPropertyName = "size_id"
        cSize_id.Width = 100
        cSize_id.Visible = True
        cSize_id.ReadOnly = False
        cSize_id.DataSource = Me.tbl_MstUkuran
        cSize_id.ValueMember = "ukuran_id"
        cSize_id.DisplayMember = "ukuran_id"
        cSize_id.DisplayStyleForCurrentCellOnly = True

        cSex_id.Name = "sex_id"
        cSex_id.HeaderText = "Sex"
        cSex_id.DataPropertyName = "sex_id"
        cSex_id.Width = 100
        cSex_id.Visible = True
        cSex_id.ReadOnly = False
        cSex_id.DataSource = Me.tbl_Mstsex
        cSex_id.ValueMember = "Pilihan"
        cSex_id.DisplayMember = "Pilihan"
        cSex_id.DisplayStyleForCurrentCellOnly = True

        cRoom_id.Name = "room_id"
        cRoom_id.HeaderText = "Room"
        cRoom_id.DataPropertyName = "room_id"
        cRoom_id.Width = 100
        cRoom_id.Visible = True
        cRoom_id.ReadOnly = False
        cRoom_id.DataSource = Me.tbl_MstAssetruang
        cRoom_id.ValueMember = "ruang_id"
        cRoom_id.DisplayMember = "keterangan"
        cRoom_id.DisplayStyleForCurrentCellOnly = True

        cTerimabarangdetil_rack.Name = "terimabarangdetil_rack"
        cTerimabarangdetil_rack.HeaderText = "Rack"
        cTerimabarangdetil_rack.DataPropertyName = "terimabarangdetil_rack"
        cTerimabarangdetil_rack.Width = 100
        cTerimabarangdetil_rack.Visible = True
        cTerimabarangdetil_rack.ReadOnly = False

        cTerimabarangdetil_qty.Name = "terimabarangdetil_qty"
        cTerimabarangdetil_qty.HeaderText = "Qty"
        cTerimabarangdetil_qty.DataPropertyName = "terimabarangdetil_qty"
        cTerimabarangdetil_qty.Width = 60
        cTerimabarangdetil_qty.Visible = True
        cTerimabarangdetil_qty.ReadOnly = False

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "Unit"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 60
        cUnit_id.Visible = True
        cUnit_id.ReadOnly = False
        cUnit_id.DataSource = Me.tbl_MstUnit
        cUnit_id.ValueMember = "unit_id"
        cUnit_id.DisplayMember = "unit_shortname"
        cUnit_id.DisplayStyleForCurrentCellOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 60
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = False
        cCurrency_id.DataSource = Me.tbl_MstCurrencyDetil
        cCurrency_id.ValueMember = "Currency_id"
        cCurrency_id.DisplayMember = "Currency_shortname"
        cCurrency_id.DisplayStyleForCurrentCellOnly = True

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
        cTerimabarangdetil_foreignrate.ReadOnly = False
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
        cTerimabarangdetil_pphforeign.Visible = True
        cTerimabarangdetil_pphforeign.ReadOnly = False
        cTerimabarangdetil_pphforeign.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_pphforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_pphidrreal.Name = "terimabarangdetil_pphidrreal"
        cTerimabarangdetil_pphidrreal.HeaderText = "Pph Amount (IDR)"
        cTerimabarangdetil_pphidrreal.DataPropertyName = "terimabarangdetil_pphidrreal"
        cTerimabarangdetil_pphidrreal.Width = 130
        cTerimabarangdetil_pphidrreal.Visible = True
        cTerimabarangdetil_pphidrreal.ReadOnly = False
        cTerimabarangdetil_pphidrreal.DefaultCellStyle.Format = "#,##0"
        cTerimabarangdetil_pphidrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_ppnforeign.Name = "terimabarangdetil_ppnforeign"
        cTerimabarangdetil_ppnforeign.HeaderText = "PPN Amount"
        cTerimabarangdetil_ppnforeign.DataPropertyName = "terimabarangdetil_ppnforeign"
        cTerimabarangdetil_ppnforeign.Width = 100
        cTerimabarangdetil_ppnforeign.Visible = True
        cTerimabarangdetil_ppnforeign.ReadOnly = False
        cTerimabarangdetil_ppnforeign.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_ppnforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_ppnidrreal.Name = "terimabarangdetil_ppnidrreal"
        cTerimabarangdetil_ppnidrreal.HeaderText = "PPN Amount(IDR)"
        cTerimabarangdetil_ppnidrreal.DataPropertyName = "terimabarangdetil_ppnidrreal"
        cTerimabarangdetil_ppnidrreal.Width = 130
        cTerimabarangdetil_ppnidrreal.Visible = True
        cTerimabarangdetil_ppnidrreal.ReadOnly = False
        cTerimabarangdetil_ppnidrreal.DefaultCellStyle.Format = "#,##0"
        cTerimabarangdetil_ppnidrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_totalforeign.Name = "terimabarangdetil_totalforeign"
        cTerimabarangdetil_totalforeign.HeaderText = "Total Amount"
        cTerimabarangdetil_totalforeign.DataPropertyName = "terimabarangdetil_totalforeign"
        cTerimabarangdetil_totalforeign.Width = 100
        cTerimabarangdetil_totalforeign.Visible = True
        cTerimabarangdetil_totalforeign.ReadOnly = False
        cTerimabarangdetil_totalforeign.DefaultCellStyle.Format = "#,##0.00"
        cTerimabarangdetil_totalforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_totalidrreal.Name = "terimabarangdetil_totalidrreal"
        cTerimabarangdetil_totalidrreal.HeaderText = "Total Amount(IDR)"
        cTerimabarangdetil_totalidrreal.DataPropertyName = "terimabarangdetil_totalidrreal"
        cTerimabarangdetil_totalidrreal.Width = 130
        cTerimabarangdetil_totalidrreal.Visible = True
        cTerimabarangdetil_totalidrreal.ReadOnly = False
        cTerimabarangdetil_totalidrreal.DefaultCellStyle.Format = "#,##0"
        cTerimabarangdetil_totalidrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimabarangdetil_nonfixasset.Name = "terimabarangdetil_nonfixasset"
        cTerimabarangdetil_nonfixasset.HeaderText = "Non Fix"
        cTerimabarangdetil_nonfixasset.DataPropertyName = "terimabarangdetil_nonfixasset"
        cTerimabarangdetil_nonfixasset.Width = 60
        cTerimabarangdetil_nonfixasset.Visible = True
        cTerimabarangdetil_nonfixasset.ReadOnly = False

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
        cTerimabarangdetil_golfiskal.Visible = True
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
        cShow_id.Visible = True
        cShow_id.ReadOnly = False
        cShow_id.DataSource = Me.tbl_MstShow
        cShow_id.ValueMember = "show_id"
        cShow_id.DisplayMember = "show_title"

        cShow_id_cont.Name = "show_id_cont"
        cShow_id_cont.HeaderText = "Show ID Cont"
        cShow_id_cont.DataPropertyName = "show_id_cont"
        cShow_id_cont.Width = 150
        cShow_id_cont.Visible = True
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
        cWriteoff_id.Visible = True
        cWriteoff_id.ReadOnly = True
        cWriteoff_id.DefaultCellStyle.BackColor = Color.Gainsboro

        cWriteoff_dt.Name = "writeoff_dt"
        cWriteoff_dt.HeaderText = "Writeoff Date"
        cWriteoff_dt.DataPropertyName = "writeoff_dt"
        cWriteoff_dt.Width = 100
        cWriteoff_dt.Visible = True
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
        cButtonTerimabarangdetil_Detail.HeaderText = "Detil"
        cButtonTerimabarangdetil_Detail.Text = "..."
        cButtonTerimabarangdetil_Detail.UseColumnTextForButtonValue = True
        cButtonTerimabarangdetil_Detail.CellTemplate.Style.BackColor = Color.LightGray
        cButtonTerimabarangdetil_Detail.Width = 30
        cButtonTerimabarangdetil_Detail.DividerWidth = 3
        cButtonTerimabarangdetil_Detail.Visible = True
        cButtonTerimabarangdetil_Detail.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cButtonTerimabarangdetil_Detail, cTerimabarang_id, cTerimabarangdetil_line, cTerimabarang_barcode, cButtonTerimabarangdetil_printbarcode, _
        cButtonTerimabarangdetil_printbarcodekain, cTerimabarangdetil_desc, _
        cTerimabarangdetil_date, cTerimabarangdetil_type, _
        cTerimabarangdetil_parentline, cTerimabarang_parentbarcode, cButtonTerimabarang_parentbarcode, _
        cTerimabarangdetil_nonfixasset, cButtonTerimabarangdetil_nonfixasset, cItem_id, cItemcategory_id, cItemtype_id, cBrand_id, _
        cTerimabarangdetil_serial_no, cTerimabarangdetil_product_no, cTerimabarangdetil_model, _
        cMaterial_id, cColour_id, cSize_id, cSex_id, cRoom_id, cTerimabarangdetil_rack, _
          cShow_id, cShow_id_cont, cTerimabarangdetil_eps, _
        cTerimabarangdetil_qty, cUnit_id, cCurrency_id, cTerimabarangdetil_foreign, _
        cTerimabarangdetil_foreignrate, cTerimabarangdetil_idrreal, cTerimabarangdetil_pphpercent, _
        cTerimabarangdetil_ppnpercent, cTerimabarangdetil_disc, cTerimabarangdetil_pphforeign, _
        cTerimabarangdetil_pphidrreal, cTerimabarangdetil_ppnforeign, cTerimabarangdetil_ppnidrreal, _
        cTerimabarangdetil_totalforeign, cTerimabarangdetil_totalidrreal, _
        cAssetcategory_id, cAssettype_id, _
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
        cAcc_id.ReadOnly = False
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
        cRekanan_name.HeaderText = "Rekanan"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 200
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = True

        cBook_date.Name = "book_dt"
        cBook_date.HeaderText = "Book Date"
        cBook_date.DataPropertyName = "book_dt"
        cBook_date.Width = 100
        cBook_date.Visible = True
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

        Me.FormatDgvTrnPenerimaanbarang(Me.DgvTrnPenerimaanbarang)
        Me.FormatDgvTrnPenerimaanbarangdetil(Me.DgvTrnPenerimaanbarangdetil)
        Me.FormatDgvTrnJurnalreference(Me.DgvTrnJurnalreference)
        Me.FormatDgvTrnJurnalresponse(Me.DgvTrnJurnalresponse)
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
        Return True
    End Function
    Private Function BindingStopDetil() As Boolean

        Me.obj_asset_terimabarangdetil_id.DataBindings.Clear()
        Me.obj_Terimabarangdetil_line.DataBindings.Clear()
        Me.obj_Terimabarangdetil_parentline.DataBindings.Clear()
        Me.obj_Terimabarangdetil_desc.DataBindings.Clear()
        Me.obj_Terimabarangdetil_date.DataBindings.Clear()
        Me.obj_Terimabarangdetil_type.DataBindings.Clear()
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
        Me.obj_Employee_id.DataBindings.Clear()
        Me.obj_Strukturunitdetil_id.DataBindings.Clear()
        Me.obj_Show_id.DataBindings.Clear()
        Me.obj_Show_id_cont.DataBindings.Clear()
        Me.obj_Terimabarangdetil_eps.DataBindings.Clear()
        Me.obj_Writeoff_id.DataBindings.Clear()
        Me.obj_Writeoff_dt.DataBindings.Clear()
        Me.obj_Orderdetil_id.DataBindings.Clear()
        Me.obj_Orderdetil_line.DataBindings.Clear()
        Me.obj_Budget_iddetil.DataBindings.Clear()
        Me.obj_Budgetdetil_id.DataBindings.Clear()
        Me.obj_Acc_id.DataBindings.Clear()
        Me.obj_Channel_iddetil.DataBindings.Clear()

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
        Me.obj_Terimabarang_status.DataBindings.Add(New Binding("SelectedItem", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_status"))
        Me.obj_Terimabarang_statusrealization.DataBindings.Add(New Binding("SelectedItem", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_statusrealization"))
        Me.obj_Terimabarang_location.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_location"))
        Me.obj_Terimabarang_notes.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_notes"))
        Me.obj_Terimabarang_nosuratjalan.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_nosuratjalan"))
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
        Me.obj_Currency_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarang_Temp, "currency_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_foreignrate.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_foreignrate", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_idrreal.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_idrreal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_pph.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_pph", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_ppn.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_ppn", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_disc.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_disc", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimabarang_cetakbpb.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_cetakbpb"))
        Return True
    End Function
    Private Function BindingStartdetil() As Boolean

        Me.obj_asset_terimabarangdetil_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarang_id"))
        Me.obj_Terimabarangdetil_line.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_line"))
        Me.obj_Terimabarangdetil_parentline.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_parentline"))
        Me.obj_Terimabarangdetil_desc.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_desc"))
        Me.obj_Terimabarangdetil_date.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_date"))
        Me.obj_Terimabarangdetil_type.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_type"))
        Me.obj_Assetcategory_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "assetcategory_id"))
        Me.obj_Assettype_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "assettype_id"))
        Me.obj_Terimabarang_barcode.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarang_barcode"))
        Me.obj_Terimabarang_parentbarcode.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarang_parentbarcode"))
        Me.obj_Item_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "item_id"))
        Me.obj_Itemcategory_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "itemcategory_id"))
        Me.obj_Itemtype_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "itemtype_id"))
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
        Me.obj_Terimabarangdetil_qty.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_qty"))
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
        Me.obj_Terimabarangdetil_golfiskal.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_golfiskal"))
        Me.obj_Terimabarangdetil_depre_enddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_depre_enddt"))
        Me.obj_Employee_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "employee_id"))
        Me.obj_Strukturunitdetil_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "strukturunit_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Show_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "show_id"))
        Me.obj_Show_id_cont.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "show_id_cont"))
        Me.obj_Terimabarangdetil_eps.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "terimabarangdetil_eps"))
        Me.obj_Writeoff_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "writeoff_id"))
        Me.obj_Writeoff_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "writeoff_dt"))
        Me.obj_Orderdetil_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "order_id"))
        Me.obj_Orderdetil_line.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "orderdetil_line"))
        Me.obj_Budget_iddetil.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "budget_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Budgetdetil_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "budgetdetil_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Acc_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnPenerimaanbarangdetil, "acc_id"))
        Me.obj_Channel_iddetil.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarangdetil, "channel_id"))
        Return True
    End Function

    Private Function BindingStopJurnal() As Boolean
        'stop binding
        Me.obj_Jurnal_bookdate.DataBindings.Clear()
        Me.cbo_periode.DataBindings.Clear()
        Return True
    End Function
    Private Function BindingStartJurnal() As Boolean
        'start binding
        Me.obj_Jurnal_bookdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal, "jurnal_bookdate"))
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
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_type").DefaultValue = "PURCHASE"
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_status").DefaultValue = "-- Pilih --"
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_statusrealization").DefaultValue = "-- Pilih --"
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_date").DefaultValue = Now.Date
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_location").DefaultValue = ""

        ' TODO: Set Default Value for tbl_TrnPenerimaanbarangdetil
        Me.tbl_TrnPenerimaanbarangdetil.Clear()
        Me.tbl_TrnPenerimaanbarangdetil = clsDataset.CreateTblTrnPenerimaanbarangdetil()
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarang_id").DefaultValue = 0
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrement = True
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrementStep = 10
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_date").DefaultValue = Now.Date
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_type").DefaultValue = "PURCHASE"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("strukturunit_id").DefaultValue = Me._STRUKTUR_UNIT
        Me.tbl_TrnPenerimaanbarangdetil.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnPenerimaanbarangdetil.Columns("item_id").DefaultValue = "0"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("itemcategory_id").DefaultValue = "0"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("brand_id").DefaultValue = 0
        Me.DgvTrnPenerimaanbarangdetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil


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
            criteria &= criteria & String.Format(" AND terimabarang_id = '{0}'", Me.obj_RvID_search.Text)
        End If

        criteria &= " AND terimabarang_type = 'PURCHASE'"

        Me.tbl_TrnPenerimaanbarang.Clear()
        Try
            Dim odatafiller As clsDataFiller = New clsDataFiller(Me.ASSET_DSN)

            odatafiller.DataFillAsset(Me.ASSET_DSN, Me.tbl_TrnPenerimaanbarang, "as_TrnPenerimaanbarang_Select", criteria, Me._CHANNEL, Me.obj_top.Value)
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

        Me.DgvTrnPenerimaanbarangdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnPenerimaanbarangdetil).EndCurrentEdit()
        tbl_TrnPenerimaanbarangdetil_Changes = Me.tbl_TrnPenerimaanbarangdetil.GetChanges()

        If tbl_TrnPenerimaanbarang_Temp_Changes IsNot Nothing Or tbl_TrnPenerimaanbarangdetil_Changes IsNot Nothing Then

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
                    success = Me.uiTrnPenerimaanBarang_SaveDetil(terimabarang_id, tbl_TrnPenerimaanbarangdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnPenerimaanBarang_SaveDetil(tbl_TrnPenerimaanbarangdetil_Changes)")
                    Me.tbl_TrnPenerimaanbarangdetil.AcceptChanges()
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

        RaiseEvent FormAfterSave(terimabarang_id, result)
        Me.Cursor = Cursors.Arrow

    End Function


    Private Function uiTrnPenerimaanBarang_SaveMaster(ByRef terimabarang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: transaksi_penerimaanbarang
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_Insert", dbConnAsset)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimabarang_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyitem", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_qtyitem"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyrealization", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_qtyrealization"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_qty", System.Data.OleDb.OleDbType.Integer, 4, "order_qty"))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyitem", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyitem", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyrealization", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyrealization", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_qty", System.Data.DataRowVersion.Current, Nothing))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_statusrealization", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarang_statusrealization"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_location", System.Data.OleDb.OleDbType.VarWChar, 200, "terimabarang_location"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "terimabarang_notes"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_nosuratjalan", System.Data.OleDb.OleDbType.VarWChar, 70, "terimabarang_nosuratjalan"))
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


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_Update", dbConnAsset)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimabarang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyitem", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_qtyitem"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyrealization", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_qtyrealization"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_qty", System.Data.OleDb.OleDbType.Integer, 4, "order_qty"))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyitem", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyitem", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyrealization", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyrealization", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_qty", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_statusrealization", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarang_statusrealization"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_location", System.Data.OleDb.OleDbType.VarWChar, 200, "terimabarang_location"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "terimabarang_notes"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_nosuratjalan", System.Data.OleDb.OleDbType.VarWChar, 70, "terimabarang_nosuratjalan"))
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
            dbConnAsset.Open()
            dbDA.Update(objTbl)

            terimabarang_id = objTbl.Rows(0).Item("terimabarang_id")
            Me.tbl_TrnPenerimaanbarang_Temp.Clear()
            Me.tbl_TrnPenerimaanbarang_Temp.Merge(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConnAsset.Close()
        End Try


        If MasterDataState = DataRowState.Added Then
            Me.tbl_TrnPenerimaanbarang.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnPenerimaanbarang).Position
            Me.tbl_TrnPenerimaanbarang.Rows.RemoveAt(curpos)
            Me.tbl_TrnPenerimaanbarang.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnPenerimaanbarang).Position = Me.BindingContext(Me.tbl_TrnPenerimaanbarang).Count

        Return True
    End Function

    Private Function uiTrnPenerimaanBarang_SaveDetil(ByRef terimabarang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_penerimaanbarangdetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Insert", dbConnAsset)
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
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qty", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_qty"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_qty", System.Data.DataRowVersion.Current, Nothing))

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


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Update", dbConnAsset)
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
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qty", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_qty"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_qty", System.Data.DataRowVersion.Current, Nothing))

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
        dbCmdUpdate.Parameters("@modified_by").Value = String.Empty
        dbCmdUpdate.Parameters("@modified_dt").Value = DBNull.Value


        dbCmdDelete = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Delete", dbConnAsset)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_line"))
        dbCmdDelete.Parameters("@terimabarang_id").Value = terimabarang_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


        Try
            dbConnAsset.Open()
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
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
                    success = Me.uiTrnPenerimaanBarang_Purchase_JurnalSaveMaster(jurnal_id, tbl_TrnJurnal_Changes, MasterDataState)
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
                    success = Me.uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilKredit(jurnal_id, tbl_TrnJurnaldetil_kredit_Changes, MasterDataState)
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
                    If Not success Then Throw New Exception("Error: Saving Reference Data at Me.uiTrnJurnal_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
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

    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveMaster(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
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
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
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
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
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
    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilKredit(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDAUpdateDetil As OleDb.OleDbDataAdapter

        ' Save data: Transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnaldetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnaldetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
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
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
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
    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilDebet(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDAUpdateDetil As OleDb.OleDbDataAdapter

        ' Save data: Transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnaldetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnaldetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
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
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
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
    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveReference(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

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
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim terimabarang_id As String
        Dim NewRowIndex As Integer

        terimabarang_id = Me.DgvTrnPenerimaanbarang.Rows(rowIndex).Cells("terimabarang_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_Delete", dbConnAsset)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@terimabarang_id").Value = terimabarang_id
        Try
            dbConnAsset.Open()
            dbCmdDelete.ExecuteNonQuery()

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

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            dbConnAsset.Close()
        End Try
    End Function

    Private Function uiTrnPenerimaanBarang_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim terimabarang_id As String
        Dim channel_id As String

        terimabarang_id = Me.DgvTrnPenerimaanbarang.Rows(rowIndex).Cells("terimabarang_id").Value
        channel_id = Me.DgvTrnPenerimaanbarang.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(terimabarang_id)

        Try
            If Me._USERTYPE = "acc" Then
                If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appuser", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0, 0) Or _
                                clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appspv", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = 0, 0) Then
                    MsgBox("You do not have the authority to open this data")
                    Me.ftabMain.SelectedIndex = 0
                    Me.Cursor = Cursors.Arrow
                    Exit Function
                End If
            End If
            dbConn.Open()
            dbConnAsset.Open()
            Me.uiTrnPenerimaanBarang_OpenRowMaster(channel_id, terimabarang_id, dbConnAsset)
            Me.uiTrnPenerimaanBarang_OpenRowDetil(channel_id, terimabarang_id, dbConnAsset)
            Me.uiTrnPenerimaanBarang_OpenRowJurnal(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_kredit(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_Debet(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalReference(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_Purchase_OpenRowResponse(channel_id, terimabarang_id, dbConn)

            If Me._USERTYPE = "user" Then
                Me.btnApproved.Visible = False
                Me.btnUnApproved.Visible = False
                If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appuser", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = True, False) Then
                    Me.tbtnDel.Enabled = False
                    Me.tbtnSave.Enabled = False
                Else
                    Me.tbtnDel.Enabled = True
                    Me.tbtnSave.Enabled = True
                End If
            ElseIf Me._USERTYPE = "spv" Then
                Me.btnApproved.Visible = True
                Me.btnUnApproved.Visible = True
                If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appspv", DgvTrnPenerimaanbarang.CurrentRow.Index).Value = True, False) Then
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
            ElseIf Me._USERTYPE = "acc" Then
                Me.btnApproved.Visible = True
                Me.btnUnApproved.Visible = True
                If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.Item("terimabarang_appacc", DgvTrnPenerimaanbarang.CurrentRow.Index).Value, False) = True Then
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnPenerimaanBarang_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
            dbConnAsset.Close()
        End Try

        RaiseEvent FormAfterOpenRow(terimabarang_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiTrnPenerimaanBarang_OpenRowMaster(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_Select_OpenRow", dbConn)
        ' ''dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        ' ''dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("terimabarang_id='{0}'", terimabarang_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnPenerimaanbarang_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnPenerimaanbarang_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPenerimaanBarang_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnPenerimaanBarang_OpenRowDetil(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Select", dbConn)
        ' ''dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        ' ''dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("terimabarang_id='{0}'", terimabarang_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnPenerimaanbarangdetil.Clear()

        Me.tbl_TrnPenerimaanbarangdetil = clsDataset.CreateTblTrnPenerimaanbarangdetil()
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
            Me.DgvTrnPenerimaanbarangdetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil
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
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
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
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
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
            Me.DgvTrnJurnaldetil.DataSource = Me.tbl_TrnJurnaldetil_kredit
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowDetil_JdwPembayaran()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_Debet(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnaldetil_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
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
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarChar)
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
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarChar)
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
        Dim tbl_TrnPenerimaanbarang_Temp_Changes As DataTable
        Dim tbl_TrnPenerimaanbarangdetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim terimabarang_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvTrnPenerimaanbarang.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).EndCurrentEdit()
            tbl_TrnPenerimaanbarang_Temp_Changes = Me.tbl_TrnPenerimaanbarang_Temp.GetChanges()

            Me.DgvTrnPenerimaanbarangdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnPenerimaanbarangdetil).EndCurrentEdit()
            tbl_TrnPenerimaanbarangdetil_Changes = Me.tbl_TrnPenerimaanbarangdetil.GetChanges()

            If tbl_TrnPenerimaanbarang_Temp_Changes IsNot Nothing Or tbl_TrnPenerimaanbarangdetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(terimabarang_id)

                        Try

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
                                success = Me.uiTrnPenerimaanBarang_SaveDetil(terimabarang_id, tbl_TrnPenerimaanbarangdetil_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnPenerimaanbarangdetil.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Function uiTrnPenerimaanBarang_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        Dim message As String = ""

        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")
            If Me._USERTYPE = "acc" Then
                'cek book date dan tanggal periode
                Dim dr() As DataRow = Me.tbl_MstPeriodeCombo.Select(String.Format("periode_id='{0}'", Me.cbo_periode.SelectedValue))
                Dim tgl_start As Date = dr(0).Item("periode_datestart")
                Dim tgl_end As Date = dr(0).Item("periode_dateend")
                Dim tgl As Date = CDate(Me.obj_Jurnal_bookdate.Value).Date

                If dr(0).Item("periode_isclosed") = True Then
                    Me.objFormError.SetError(Me.cbo_periode, "period has closed! Please contact your administrator for open this period")
                    Throw New Exception("period has closed!! Please contact your administrator for open this period")
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

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

    Private Sub uiTrnPenerimaanBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        Dim objParameters As Collection = New Collection
        Dim tbl_Approved As New DataTable
        Dim row_type As DataRow

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
            Me._USERTYPE = (Me.GetValueFromParameter(objParameters, "USER_TYPE"))
        End If

        Me.DgvTrnPenerimaanbarang.DataSource = Me.tbl_TrnPenerimaanbarang

        If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            Me.uiTrnTerimaBarang_isBackgroudWorker()
            Me.uiTrnTerimaBarang_LoadCombo()

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

            If Me._USERTYPE = "user" Or Me._USERTYPE = "spv" Then
                Me.Panel_tutup.Visible = True
                Me.Panel_tutup.Dock = DockStyle.Bottom
                Me.Panel_tutup.Width = 747
                Me.Panel_tutup.Height = 136

            ElseIf Me._USERTYPE = "acc" Then
                Me.Panel_tutup.Visible = False
            End If

            If Me._USERTYPE = "acc" Then
                Me.pnlClose2.Visible = False
                Me.pnlclose3.Visible = False

                Me.PnlDataMaster.Enabled = False
                Me.DgvTrnPenerimaanbarangdetil.ReadOnly = True
                Me.chk_Strukturunit_id_pemilik_search.Checked = False
                Me.chk_Strukturunit_id_pemilik_search.Enabled = True
                Me.obj_Strukturunit_id_pemilik_search.SelectedValue = 0
                Me.obj_Strukturunit_id_pemilik_search.Enabled = True

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

                Me.DgvTrnPenerimaanbarangdetil.ContextMenuStrip = ContextMenuStrip2
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

                Me.DgvTrnPenerimaanbarangdetil.ContextMenuStrip = ContextMenuStrip1
            End If
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
                If Me._USERTYPE = "user" Then
                    Me.btnApproved.Visible = True
                    Me.btnUnApproved.Visible = True
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

                If Me.DgvTrnPenerimaanbarang.CurrentRow IsNot Nothing Then
                    Me.uiTrnPenerimaanBarang_OpenRow(Me.DgvTrnPenerimaanbarang.CurrentRow.Index)
                Else
                    Me.uiTrnPenerimaanBarang_NewData()
                End If

                Me.ftabDataDetil.SelectedIndex = 2
                Me.ftabDataDetil.SelectedIndex = 0
        End Select
    End Sub

    Private Sub DgvTrnPenerimaanbarang_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnPenerimaanbarang.CellClick
        If Me.tbl_TrnPenerimaanbarang.Rows.Count > 0 Then
            If Me._USERTYPE = "user" Then
                If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_appuser").Value, False) = True Then
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

    Private Sub uiTrnTerimaBarang_LoadCombo()
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        If Me._LOADCOMBOSEARCH = False Then
            '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", tbl_MstChannel_search, "as_MstChannel_select", "", "")

            Me.ComboFill(Me.obj_Currency_id, "currency_id", "currency_shortname", tbl_MstCurrency, "ms_MstCurrency_Select", "Currency_active = 1", "")
            Dim CurrDetil As Boolean
            Me.tbl_MstCurrencyDataDetil = Me.tbl_MstCurrency.Copy
            CurrDetil = ComboFillFromDataTable(Me.obj_Currency_iddetil, "currency_id", "currency_shortname", tbl_MstCurrencyDataDetil)
            Me.tbl_MstCurrencyDataDetil.DefaultView.Sort = "currency_shortname"
            Me.tbl_MstCurrencyDetil = Me.tbl_MstCurrency.Copy

            oDataFiller.DataFillForCombo("currency_id", "currency_shortname", Me.tbl_MstCurrencyGrid, "ms_MstCurrency_Select", " Currency_active = 1 ")

            Me.ComboFill(Me.obj_Strukturunit_id_pemilik_search, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunit_search, "ms_MstStrukturUnit_Select", "", "")
            Dim StrukturunitDetil As Boolean
            Me.tbl_MstStrukturunitDetil = Me.tbl_MstStrukturunit_search.Copy
            StrukturunitDetil = ComboFillFromDataTable(Me.obj_Strukturunitdetil_id, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunitDetil)
            Me.tbl_MstStrukturunitDetil.DefaultView.Sort = "strukturunit_name"
            Me.tbl_MstStrukturunitGrid = tbl_MstStrukturunit_search.Copy

            Me.ComboFillAsset(Me.obj_Assetcategory_id, "kategoriasset_id", "kategoriasset_id", Me.tbl_mstKategoriAssetDetil, "as_MstKategoriasset_Select", " ")
            Me.tbl_mstKategoriAsset = Me.tbl_mstKategoriAssetDetil.Copy

            Me.ComboFillAsset(Me.obj_Assettype_id, "tipeasset_id", "tipeasset_id", Me.tbl_MstTipeAssetDetil, "as_MstTipeasset_Select", " ")
            Me.tbl_MstTipeAsset = Me.tbl_MstTipeAssetDetil.Copy

            Me.ComboFill(Me.obj_Item_id, "item_id", "item_name", Me.tbl_MstItemDetil, "ms_MstItem_Select", " ")
            Me.tbl_MstItem = Me.tbl_MstItemDetil.Copy

            Me.ComboFill(Me.obj_Itemcategory_id, "category_id", "category_name", Me.tbl_MstItemCategoryDetil, "ms_MstItemCategory_Select", " ")
            Me.tbl_MstItemCategory = Me.tbl_MstItemCategoryDetil.Copy

            Me.ComboFillAngka(Me.ASSET_DSN, Me.obj_Brand_id, "merk_id", "merk_name", Me.tbl_MstBrandDetil, "as_MstMerk_Select", " merk_active = 1 ")
            Me.tbl_MstBrand = Me.tbl_MstBrandDetil.Copy

            Me.ComboFillAsset(Me.obj_Itemtype_id, "tipeitem_id", "tipeitem_id", Me.tbl_MstTipeitemDetil, "as_MstTipeitem_Select", " ")
            Me.tbl_MstTipeitem = Me.tbl_MstTipeitemDetil.Copy

            Me.ComboFillAsset(Me.obj_Material_id, "Material_id", "Material_id", Me.tbl_MstMaterialDetil, "as_MstMaterial_Select", " ")
            Me.tbl_MstMaterial = Me.tbl_MstMaterialDetil.Copy

            Me.ComboFillAsset(Me.obj_Colour_id, "warna_id", "warna_id", Me.tbl_MstWarnaDetil, "as_MstWarna_Select", " ")
            Me.tbl_MstWarna = Me.tbl_MstWarnaDetil.Copy

            Me.ComboFillAsset(Me.obj_Size_id, "ukuran_id", "ukuran_id", Me.tbl_MstUkuranDetil, "AS_MstUkuran_Select", " ")
            Me.tbl_MstUkuran = Me.tbl_MstUkuranDetil.Copy

            Me.ComboFillAsset(Me.obj_Sex_id, "Pilihan", "Pilihan", Me.tbl_MstsexDetil, "as_MstPilihan_Select", " Kategori = 'MstsexAsset' and is_disable = 0 ")
            Me.tbl_Mstsex = Me.tbl_MstsexDetil.Copy

            oDataFiller.ComboFillCharASSET(Me.ASSET_DSN, Me.obj_Room_id, "ruang_id", "keterangan", Me.tbl_MstAssetruangDetil, "as_MstRuangAsset_Select", " ", Me._CHANNEL)
            Me.tbl_MstAssetruang = Me.tbl_MstAssetruangDetil.Copy

            Me.ComboFillAngka(Me.ASSET_DSN, Me.obj_Unit_id, "unit_id", "unit_shortname", Me.tbl_MstUnitDetil, "AS_MstUnit_Select", " unit_active = 1 ")
            Me.tbl_MstUnit = Me.tbl_MstUnitDetil.Copy

            oDataFiller.ComboFillChar(Me.obj_Show_id, "show_id", "show_title", Me.tbl_MstShowDetil, "ms_MstShow_Select", " ")
            Dim ShowDetil As Boolean
            Me.tbl_MstShowcontDetil = Me.tbl_MstShowDetil.Copy
            ShowDetil = ComboFillFromDataTable(Me.obj_Show_id_cont, "show_id", "show_title", tbl_MstShowcontDetil)
            Me.tbl_MstShowcontDetil.DefaultView.Sort = "show_title"
            Me.tbl_MstShow = Me.tbl_MstShowDetil.Copy

            Me.ComboFill(Me.obj_Acc_id, "acc_id", "acc_nameshort", Me.tbl_MstAccGridDetil, "ms_MstAccountCombo_Select", " ")
            oDataFiller.DataFillForCombo("acc_id", "acc_nameshort", Me.tbl_MstAccGrid, "ms_MstAccountCombo_Select", "") '"acc_isdisabled = 0")

            Me.ComboFill(Me.cbo_periode, "periode_id", "periode_name", Me.tbl_MstPeriodeCombo, "ms_MstPeriodeCombo_Select", " ")
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
            ' ''Invoke(AddToComboSearch, BG_Worker) 
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
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        worker.WorkerReportsProgress = True

        Me.label_thread = "Rekanan"
        worker.ReportProgress(0)
        Me.ComboFill(Me.obj_Rekanan_id, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "ms_MstRekananCombo_Select", "")
        Me.tbl_MstRekananGrid = Me.tbl_MstRekanan.Copy
        Me.tbl_MstRekanan_search = Me.tbl_MstRekanan.Copy
        Me.tbl_MstRekananGrid.DefaultView.Sort = "rekanan_name"
        Me.tbl_MstRekanan_search.DefaultView.Sort = "rekanan_name"

        worker.ReportProgress(30)
        Me.label_thread = "Employee"
        oDataFiller.ComboFillCharASSET(Me.ASSET_DSN, Me.obj_Employee_id_owner, "employee_id", "employee_namalengkap", Me.Tbl_Mstemployee, "ms_MstEmployee_Select", " ")
        Me.Tbl_Mstemployee.DefaultView.Sort = "employee_namalengkap"
        Dim empDetil As Boolean
        Me.Tbl_MstemployeeDetil = Me.Tbl_Mstemployee.Copy
        empDetil = ComboFillFromDataTable(Me.obj_Employee_id, "employee_id", "employee_namalengkap", Me.Tbl_MstemployeeDetil)
        Me.Tbl_MstemployeeDetil.DefaultView.Sort = "employee_namalengkap"


        worker.ReportProgress(60)
        Me.label_thread = "Budget"
        ComboFill(obj_Budget_id, "budget_id", "budget_nameshort", tbl_TrnBudget, "ms_MstBudgetCombo_Select", "budget_isactive = 1 ")
        Me.tbl_TrnBudget.DefaultView.Sort = "budget_nameshort"

        Me.label_thread = "Budget Detil"
        worker.ReportProgress(80)
        Me.ComboFill(Me.obj_Budget_iddetil, "budget_id", "budget_nameshort", Me.tbl_TrnBudgetHome, "ms_MstBudgetCombo_Select", "budget_isactive = 1 ")
        Me.tbl_TrnBudgetHome.DefaultView.Sort = "budget_nameshort"

        worker.ReportProgress(85)
        Me.ComboFill(Me.obj_Budgetdetil_id, "budgetdetil_id", "budgetdetil_desc", Me.tbl_TrnBudgetDetil, "ms_MstBudgetdetilCombo_Select", "")
        Me.tbl_TrnBudgetDetil.DefaultView.Sort = "budgetdetil_desc"

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
        If Me.DgvTrnPenerimaanbarangdetil.Rows.Count = 0 Then
            Dim dlg As dlgTrnPenerimaanBarang_Select_Purchase = New dlgTrnPenerimaanBarang_Select_Purchase(Me.DSN, Me.ASSET_DSN, Me.obj_Rekanan_id.SelectedValue, Me.tbl_MstRekanan.Copy, Me._STRUKTUR_UNIT)

            Dim retObj As Object
            Dim retData As Collection
            Dim tblH As DataTable

            retObj = dlg.OpenDialog(Me, Me.obj_Channel_id.Text, "Purchase")

            If retObj IsNot Nothing Then
                retData = CType(retObj, Collection)
                tblH = CType(retData.Item("tblH"), DataTable)

                Me.obj_Budget_id.SelectedValue = clsUtil.IsDbNull(tblH.Rows(0).Item("budget_id"), 0)
                Me.obj_Rekanan_id.SelectedValue = clsUtil.IsDbNull(tblH.Rows(0).Item("rekanan_id"), 0)
                Me.obj_Order_id.Text = clsUtil.IsDbNull(tblH.Rows(0).Item("order_id"), String.Empty)
                Me.obj_Terimabarang_notes.Text = clsUtil.IsDbNull(tblH.Rows(0).Item("order_descr"), String.Empty)
            End If
        Else
            MsgBox("Maaf, sudah ada satu atau lebih item dari " & Me.obj_Order_id.Text & " yang sudah ditarik", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub Btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Add.Click
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

        For i = 0 To Me.DgvTrnPenerimaanbarangdetil.Rows.Count - 1
            If order_line = String.Empty Then
                order_line = Me.DgvTrnPenerimaanbarangdetil.Rows(i).Cells("orderdetil_line").Value
            Else
                order_line &= ", " & Me.DgvTrnPenerimaanbarangdetil.Rows(i).Cells("orderdetil_line").Value
            End If
        Next

        If order_line <> String.Empty Then
            order_line = "(" & order_line & ")"
        End If

        retObj = dlg.OpenDialog(Me, Me.obj_Channel_id.Text, Me.DSN, Me.obj_Order_id.Text, order_line)

        If retObj IsNot Nothing Then

            retData = CType(retObj, Collection)
            tblDetil = CType(retData.Item("tblDetil"), DataTable)

            Dim row As DataRow

            For row_index = 0 To tblDetil.Rows.Count - 1
                Dim ppnAmount As Decimal
                Dim ppnAmountIDR As Decimal
                Dim pphAmount As Decimal
                Dim pphAmountIDR As Decimal
                Dim totalAmount As Decimal
                Dim totalAmountIDR As Decimal

                row = Me.tbl_TrnPenerimaanbarangdetil.NewRow
                row.Item("terimabarangdetil_desc") = tblDetil.Rows(row_index).Item("orderdetil_descr")
                row.Item("terimabarangdetil_date") = Now.Date
                row.Item("terimabarangdetil_qty") = tblDetil.Rows(row_index).Item("po_outstanding")
                row.Item("order_id") = tblDetil.Rows(row_index).Item("order_id")
                row.Item("orderdetil_line") = tblDetil.Rows(row_index).Item("orderdetil_line")
                row.Item("item_id") = tblDetil.Rows(row_index).Item("item_id")
                row.Item("itemcategory_id") = tblDetil.Rows(row_index).Item("category_id")
                row.Item("brand_id") = 0
                row.Item("budget_id") = tblDetil.Rows(row_index).Item("budget_id")
                row.Item("budgetdetil_id") = tblDetil.Rows(row_index).Item("budgetdetil_id")
                row.Item("acc_id") = tblDetil.Rows(row_index).Item("acc_id")

                row.Item("terimabarangdetil_foreign") = tblDetil.Rows(row_index).Item("orderdetil_foreign")
                row.Item("currency_id") = tblDetil.Rows(row_index).Item("currency_id")
                row.Item("terimabarangdetil_foreignrate") = tblDetil.Rows(row_index).Item("orderdetil_foreignrate")
                row.Item("terimabarangdetil_idrreal") = tblDetil.Rows(row_index).Item("orderdetil_foreignrate") * tblDetil.Rows(row_index).Item("orderdetil_foreign")
                row.Item("terimabarangdetil_pphpercent") = tblDetil.Rows(row_index).Item("orderdetil_pphpercent")
                row.Item("terimabarangdetil_ppnpercent") = tblDetil.Rows(row_index).Item("orderdetil_ppnpercent")
                row.Item("terimabarangdetil_disc") = tblDetil.Rows(row_index).Item("orderdetil_discount")

                pphAmount = ((clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0)) _
                                                   * (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_pphpercent"), 0) / 100)

                pphAmountIDR = ((clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0)) _
                                                   * (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_pphpercent"), 0) / 100) * (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreignrate"), 0))

                ppnAmount = ((clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0)) _
                                                   * (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_ppnpercent"), 0) / 100)

                ppnAmountIDR = ((clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0)) _
                                                   * (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_ppnpercent"), 0) / 100) * (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreignrate"), 0))

                totalAmount = ((clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("po_outstanding"), 0)) _
                            - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                totalAmountIDR = (clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreign"), 0) - clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_discount"), 0)) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_foreignrate"), 0) * _
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
                row.Item("unit_id") = 0
                row.Item("terimabarangdetil_product_no") = "Label"

                Me.tbl_TrnPenerimaanbarangdetil.Rows.Add(row)

                qty_order += clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_qty"), 0)

                Me.obj_Currency_id.SelectedValue = tblDetil.Rows(row_index).Item("currency_id")
                Me.obj_Terimabarang_foreignrate.Text = tblDetil.Rows(row_index).Item("orderdetil_foreignrate")
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
            Me.DataFill(tbl_order, "pr_TrnOrderdetil_Select", String.Format(" order_id = '{0}' and orderdetil_line in ({1})", Me.obj_Order_id.Text, line))

            For j = 0 To tbl_order.Rows.Count - 1
                qty_order += clsUtil.IsDbNull(tbl_order.Rows(j).Item("orderdetil_qty"), 0) * clsUtil.IsDbNull(tbl_order.Rows(j).Item("orderdetil_days"), 0)
            Next

            Me.obj_Terimabarang_qtyitem.Text = Me.tbl_TrnPenerimaanbarangdetil.Rows.Count
            Me.obj_Order_qty.Text = qty_order

        End If
    End Sub

    Private Function uiTrnPenerimaanBarang_FormErrorValidasi() As Boolean
        Dim message As String = ""

        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            'cek isi cell di detil
            Dim i As Integer
            Dim cell_typeasset_id, cell_categoryasset_id As DataGridViewCell
            Dim dgv_error, row_error As Boolean
            Me.DgvTrnPenerimaanbarangdetil.AllowUserToAddRows = False
            For i = 0 To Me.DgvTrnPenerimaanbarangdetil.Rows.Count - 1
                row_error = False

                cell_typeasset_id = Me.DgvTrnPenerimaanbarangdetil.Rows(i).Cells("assettype_id")
                cell_categoryasset_id = Me.DgvTrnPenerimaanbarangdetil.Rows(i).Cells("assetcategory_id")

                message = "Asset type can't be empty"
                If cell_typeasset_id.Value = "-- PILIH --" Or cell_typeasset_id.Value = String.Empty Then
                    cell_typeasset_id.ErrorText = message
                    row_error = True
                Else
                    cell_typeasset_id.ErrorText = ""
                End If

                message = "Asset category can't be empty"
                If cell_categoryasset_id.Value = "-- PILIH --" Or cell_categoryasset_id.Value = String.Empty Then
                    cell_categoryasset_id.ErrorText = message
                    row_error = True
                Else
                    cell_categoryasset_id.ErrorText = ""
                End If


                If row_error Then
                    dgv_error = True
                    Me.DgvTrnPenerimaanbarangdetil.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                Else
                    Me.DgvTrnPenerimaanbarangdetil.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If

            Next
 

            If dgv_error Then
                Throw New Exception("Ada kesalahan pada pengentrian data!")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

    Private Function uiTrnPenerimaanBarang_ValidasiAsset(ByRef terimabarang_id As Object, ByRef channel_id As Object) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Try
            dbConnAsset.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_TrnPenerimaanBarangDetil_ValidasiTsv", dbConnAsset)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@channel_id", OleDb.OleDbType.VarWChar, 20).Value = Trim(Me._CHANNEL)
            dbCmdInsert.Parameters.Add("@terimabarang_id", OleDb.OleDbType.VarWChar, 40).Value = CStr(terimabarang_id)
            dbCmdInsert.ExecuteNonQuery()
            dbCmdInsert.Dispose()

            Me.uiTrnPenerimaanBarang_OpenRowDetil(channel_id, terimabarang_id, dbConnAsset)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConnAsset.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default

        Return True
    End Function

    Private Sub DgvTrnPenerimaanbarangdetil_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnPenerimaanbarangdetil.CellClick
        Select Case e.ColumnIndex
            Case Me.DgvTrnPenerimaanbarangdetil.Columns("select_nonfix").Index
                If DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_nonfixasset").Value = True Then
                    Dim param As Integer = 1
                    Dim listbarcode As String
                    Dim dlg As New dlgListBarangNonFix(Me.DSN, _CHANNEL, param, Me._STRUKTUR_UNIT, DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_parentbarcode").Value)

                    listbarcode = dlg.OpenDialog(Me)
                    If listBarcode IsNot Nothing Then
                        Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_barcode").Value = listbarcode
                    End If
                Else
                    MsgBox("Access Denied")
                    Exit Sub
                End If

            Case Me.DgvTrnPenerimaanbarangdetil.Columns("select_parent_barcode").Index
                If DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_nonfixasset").Value = False Then
                    Dim param As Integer = 2
                    Dim listbarcodeInduk As String
                    Dim dlg As New dlgListBarangNonFix(Me.DSN, _CHANNEL, param, Me._STRUKTUR_UNIT, DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_parentbarcode").Value)
                    listbarcodeInduk = dlg.OpenDialog(Me)
                    If listbarcodeInduk IsNot Nothing Then
                        Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_parentbarcode").Value = listbarcodeInduk
                        Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_parentline").Value = 0
                        Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_parentline").ReadOnly = True
                    End If
                End If
            Case Me.DgvTrnPenerimaanbarangdetil.Columns("terimabarangdetil_nonfixasset").Index
                If DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_nonfixasset").Value = True Then
                    Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_parentbarcode").Value = String.Empty
                Else
                    Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_barcode").Value = String.Empty
                End If
            Case Me.DgvTrnPenerimaanbarangdetil.Columns("print_barcode").Index
                If clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_barcode").Value, String.Empty) <> String.Empty Then
                    'Me.LoadDetilbarcode()
                    Dim nm_perusahaan As String = Me.getNamaPerusahaan()
                    Dim row(0) As DataRow

                    row(0) = CType(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.DataBoundItem, DataRowView).Row

                    Me.PrintBarcode(nm_perusahaan, row)
                End If
            Case Me.DgvTrnPenerimaanbarangdetil.Columns("print_barcodekain").Index
                If clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_barcode").Value, String.Empty) <> String.Empty Then
                    Me.LoadDetilbarcodekain()
                End If

            Case Me.DgvTrnPenerimaanbarangdetil.Columns("select_detail").Index
                Me.pnlDetil.Visible = True
                Me.pnlDetil.Dock = DockStyle.Fill
                Me.btnHome.Visible = True
                Me.BindingStopDetil()
                Me.BindingStartdetil()

                If _USERTYPE = "acc" Then
                    Me.ReadOnlyPaneldetil(True)
                Else
                    Me.ReadOnlyPaneldetil(False)
                End If
        End Select
    End Sub

    Private Sub ReadOnlyPaneldetil(ByVal val As Boolean)

        For Each ctr As Control In Me.Panel3.Controls
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
                    Dim b As Button = ctr

                    b.Enabled = Not val
            End Select
        Next

        For Each ctr As Control In Me.Panel6.Controls
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
            End Select
        Next

        For Each ctr As Control In Me.Panel7.Controls
            Select Case ctr.GetType().Name
                Case GetType(Label).Name
                Case GetType(TextBox).Name
                    Dim t As TextBox = ctr

                    t.ReadOnly = val
                    t.TabStop = Not val
                Case GetType(ComboBox).Name
                    Dim c As ComboBox = ctr

                    If c.Name <> "obj_Assettype_id" And c.Name <> "obj_Assetcategory_id" Then
                        c.Enabled = Not val
                    End If

                Case GetType(Button).Name
                    Dim c As Button = ctr

                    c.Enabled = Not val
                Case GetType(DateTimePicker).Name
                    Dim d As DateTimePicker = ctr

                    d.Enabled = Not val
            End Select
        Next

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


    ' ''Private Sub UpdateBarcodeAfterLockData()
    ' ''    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
    ' ''    Try
    ' ''        dbConn.Open()
    ' ''        Dim oDm As New OleDb.OleDbCommand("as_TrnTerimabarangdetil_update_Barcode", dbConn)
    ' ''        oDm.CommandType = CommandType.StoredProcedure
    ' ''        oDm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
    ' ''        oDm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnPenerimaanbarang.Item("channel_id", DgvTrnPenerimaanbarang.CurrentRow.Index).Value
    ' ''        oDm.ExecuteNonQuery()
    ' ''        oDm.Dispose()
    ' ''    Catch ex As Data.OleDb.OleDbException
    ' ''        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    ' ''    Catch ex As Exception
    ' ''        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    ' ''    Finally
    ' ''        dbConn.Close()
    ' ''    End Try

    ' ''    System.Windows.Forms.Cursor.Current = Cursors.Default
    ' ''End Sub

    Private Sub DgvTrnPenerimaanbarangdetil_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnPenerimaanbarangdetil.CellValidated
        Dim obj As DataGridView = sender

        Dim amountIdr As Decimal
        Dim ppnAmount As Decimal
        Dim ppnAmountIDR As Decimal
        Dim pphAmount As Decimal
        Dim pphAmountIDR As Decimal
        Dim totalAmount As Decimal
        Dim totalAmountIDR As Decimal

        If obj.Columns(e.ColumnIndex).Name = "terimabarangdetil_foreign" Or _
            obj.Columns(e.ColumnIndex).Name = "terimabarangdetil_qty" Or _
            obj.Columns(e.ColumnIndex).Name = "terimabarangdetil_disc" Or _
            obj.Columns(e.ColumnIndex).Name = "terimabarangdetil_pphpercent" Or _
            obj.Columns(e.ColumnIndex).Name = "terimabarangdetil_ppnpercent" Or _
            obj.Columns(e.ColumnIndex).Name = "terimabarangdetil_foreignrate" Then


            amountIdr = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0)

            pphAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                               * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100)

            pphAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                        * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

            ppnAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                           * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100)

            ppnAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                        * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

            totalAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                        - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

            totalAmountIDR = (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0) * _
                              clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0) - _
                              clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

            If Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
            Else
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)

            End If
            Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_idrreal").Value = Math.Round(amountIdr, 0, MidpointRounding.AwayFromZero)
            Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphidrreal").Value = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
            Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnidrreal").Value = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
            Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalidrreal").Value = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)
        End If
    End Sub

    Private Sub DgvTrnPenerimaanbarangdetil_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnPenerimaanbarangdetil.CellValueChanged

        Dim ppnAmount As Decimal
        Dim ppnAmountIDR As Decimal
        Dim pphAmount As Decimal
        Dim pphAmountIDR As Decimal
        Dim totalAmount As Decimal
        Dim totalAmountIDR As Decimal

        Dim amountIdr As Decimal

        Select Case e.ColumnIndex
            Case Me.DgvTrnPenerimaanbarangdetil.Columns("terimabarangdetil_qty").Index

                pphAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                               * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100)

                pphAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                ppnAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                               * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100)

                ppnAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                totalAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                totalAmountIDR = (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0) * _
                                  clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0) - _
                                  clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                If Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
                Else
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)
                End If
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphidrreal").Value = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnidrreal").Value = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalidrreal").Value = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)

            Case Me.DgvTrnPenerimaanbarangdetil.Columns("terimabarangdetil_foreign").Index
                amountIdr = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0)

                pphAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                                   * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100)

                pphAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                ppnAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                               * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100)

                ppnAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                totalAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                totalAmountIDR = (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0) * _
                                  clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0) - _
                                  clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                If Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
                Else
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)

                End If
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_idrreal").Value = Math.Round(amountIdr, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphidrreal").Value = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnidrreal").Value = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalidrreal").Value = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)

            Case Me.DgvTrnPenerimaanbarangdetil.Columns("terimabarangdetil_disc").Index
                amountIdr = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0)

                pphAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                                   * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100)

                pphAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                ppnAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                               * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100)

                ppnAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                totalAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                totalAmountIDR = (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0) * _
                                  clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0) - _
                                  clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                If Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
                Else
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)

                End If
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_idrreal").Value = Math.Round(amountIdr, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphidrreal").Value = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnidrreal").Value = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalidrreal").Value = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)

            Case Me.DgvTrnPenerimaanbarangdetil.Columns("terimabarangdetil_pphpercent").Index
                amountIdr = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0)

                pphAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                                   * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100)

                pphAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                ppnAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                               * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100)

                ppnAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                totalAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                totalAmountIDR = (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0) * _
                                  clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0) - _
                                  clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                If Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
                Else
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)

                End If
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_idrreal").Value = Math.Round(amountIdr, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphidrreal").Value = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnidrreal").Value = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalidrreal").Value = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)

            Case Me.DgvTrnPenerimaanbarangdetil.Columns("terimabarangdetil_ppnpercent").Index
                amountIdr = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0)

                pphAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                                   * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100)

                pphAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                ppnAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                               * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100)

                ppnAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                totalAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                totalAmountIDR = (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0) * _
                                  clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0) - _
                                  clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                If Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
                Else
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)

                End If
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_idrreal").Value = Math.Round(amountIdr, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphidrreal").Value = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnidrreal").Value = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalidrreal").Value = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)

            Case Me.DgvTrnPenerimaanbarangdetil.Columns("terimabarangdetil_foreignrate").Index
                amountIdr = clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0)

                pphAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                                   * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100)

                pphAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                ppnAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                                               * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100)

                ppnAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0))

                totalAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0)) _
                            - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                totalAmountIDR = (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_foreignrate").Value, 0) * _
                                  clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_qty").Value, 0) - _
                                  clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                If Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
                Else
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)

                End If
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_idrreal").Value = Math.Round(amountIdr, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_pphidrreal").Value = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_ppnidrreal").Value = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Index).Cells("terimabarangdetil_totalidrreal").Value = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)

        End Select

    
    End Sub

    Private Sub CopyItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyItemToolStripMenuItem.Click
        If Me.tbtnSave.Enabled = True Then
            Me.copy_induk_child(0)
        Else
            MsgBox("Data has been lock")
        End If
    End Sub

    Private Sub CopyWihChildToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyWihChildToolStripMenuItem.Click
        If Me.tbtnSave.Enabled = True Then
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
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.ASSET_DSN)

        'Untuk ngecek ini data dari tabel atau dataset
        Dim criterias As String = String.Empty
        Dim tabel_temps As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        criterias = String.Format(" terimabarang_id = '{0}' AND terimabarangdetil_line = {1}", Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_id").Value, _
                        Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_line").Value)
        Try
            tabel_temps.Clear()
            oDataFiller.DataFillAsset(Me.ASSET_DSN, tabel_temps, "as_Trnpenerimaanbarangdetil_Select", criterias)

        Catch ex As Exception
        End Try

        Dim tbl_temporaryInduk As DataTable = New DataTable
        Dim tbl_temporaryChild As DataTable = New DataTable

        tbl_trnTerimabarangdetil_temps.Clear()
        tbl_trnTerimabarangdetil_temps = Me.tbl_TrnPenerimaanbarangdetil.GetChanges()

        tbl_temporaryInduk.Clear()
        If tabel_temps.Rows.Count > 0 Then
            tbl_temporaryInduk = Me.tbl_TrnPenerimaanbarangdetil
        ElseIf tbl_trnTerimabarangdetil_temps IsNot Nothing Then
            tbl_temporaryInduk = tbl_trnTerimabarangdetil_temps
        Else
            Exit Sub
        End If

        'Buat masukkin data Mother(induk na)
        If tbl_temporaryInduk.Rows.Count > 0 Then
            criteria = String.Format("terimabarangdetil_line = {0}", Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_line").Value)
            row_Array = tbl_temporaryInduk.Select(criteria)

            motherTbl.Clear()

            For rowIndex = 0 To row_Array.Length - 1
                row_temps = motherTbl.NewRow
                For colIndex = 0 To tbl_temporaryInduk.Columns.Count - 1
                    Try
                        columnName = tbl_temporaryInduk.Columns(colIndex).ColumnName
                        If columnName = "terimabarangdetil_line" Then
                            row_temps(columnName) = tbl_temporaryInduk.Rows(tbl_temporaryInduk.Rows.Count - 1).Item("terimabarangdetil_line") + 10
                            'ElseIf columnName = "terimabarangdetil_serial_no" Or columnName = "terimabarangdetil_product_no" Or columnName = "terimabarangdetil_model" Or columnName = "terimabarang_barcode" Then
                        ElseIf columnName = "terimabarangdetil_serial_no" Or columnName = "terimabarangdetil_model" Or columnName = "terimabarang_barcode" Then
                            row_temps(columnName) = ""
                        Else
                            row_temps(columnName) = row_Array(rowIndex).Item(colIndex)
                        End If
                    Catch ex As Exception
                    End Try
                Next
                motherTbl.Rows.Add(row_temps)
            Next
            Me.tbl_TrnPenerimaanbarangdetil.Merge(motherTbl, False)

        End If


        'Buat Masukkan data semua anak-anak na dari induk yang dicopy
        If isChild = 1 Then
            tbl_temporaryChild.Clear()
            If tabel_temps.Rows.Count > 0 Then
                tbl_temporaryChild = Me.tbl_TrnPenerimaanbarangdetil
            ElseIf tbl_trnTerimabarangdetil_temps IsNot Nothing Then
                tbl_temporaryChild = tbl_trnTerimabarangdetil_temps
            Else
                Exit Sub
            End If

            If tbl_temporaryChild.Rows.Count > 0 Then
                criteria = String.Format(" terimabarangdetil_parentline = {0}", Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_line").Value)
                row_Array = tbl_temporaryChild.Select(criteria)

                'childTbl.Clear()
                For rowIndex = 0 To row_Array.Length - 1
                    childTbl.Clear()
                    row_temps = childTbl.NewRow
                    For colIndex = 0 To tbl_temporaryChild.Columns.Count - 1
                        Try
                            columnName = tbl_temporaryChild.Columns(colIndex).ColumnName
                            If columnName = "terimabarangdetil_line" Then
                                row_temps(columnName) = tbl_temporaryChild.Rows(tbl_temporaryChild.Rows.Count - 1).Item("terimabarangdetil_line") + 10
                            ElseIf columnName = "terimabarangdetil_parentline" Then
                                row_temps(columnName) = Me.motherTbl.Rows(0).Item("terimabarangdetil_line")
                                'ElseIf columnName = "terimabarangdetil_serial_no" Or columnName = "terimabarangdetil_product_no" Or columnName = "terimabarangdetil_model" Then
                            ElseIf columnName = "terimabarangdetil_serial_no" Or columnName = "terimabarangdetil_model" Then
                                row_temps(columnName) = ""
                            Else
                                row_temps(columnName) = row_Array(rowIndex).Item(colIndex)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    childTbl.Rows.Add(row_temps)
                    Me.tbl_TrnPenerimaanbarangdetil.Merge(childTbl)
                Next
                'Me.tbl_TrnTerimabarangdetil.Merge(childTbl)
            End If
        End If

    End Sub

    Private Sub DgvTrnPenerimaanbarangdetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnPenerimaanbarangdetil.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnPenerimaanbarangdetil.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnPenerimaanbarangdetil.CurrentCell = Me.DgvTrnPenerimaanbarangdetil.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
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
        If Me.DgvTrnPenerimaanbarang.CurrentRow IsNot Nothing Then
            Me.uiTrnPenerimaanBarang_OpenRow(Me.DgvTrnPenerimaanbarang.CurrentRow.Index)
            Dim drNews As DataRow
            For Each drNews In tbl_TrnPenerimaanbarangdetil.Rows
                objWriter.WriteLine(drNews.Item("terimabarang_barcode").ToString)
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
        If Me.DgvTrnPenerimaanbarang.CurrentRow IsNot Nothing Then
            Me.uiTrnPenerimaanBarang_OpenRow(Me.DgvTrnPenerimaanbarang.CurrentRow.Index)
            Dim drNews As DataRow
            For Each drNews In tbl_TrnPenerimaanbarangdetil.Rows
                objWriter.WriteLine(drNews.Item("terimabarang_barcode").ToString)
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


    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        Dim odatafiller As clsDataFiller = New clsDataFiller(Me.ASSET_DSN)

        objPrintHeader = New DataSource.clsRptPenerimaanBarang(Me.DSN)
        odatafiller.DataFillAsset(Me.ASSET_DSN, tbl_Print, "as_RptPenerimaanBarang_Select", "terimabarang_id = '" & DgvTrnPenerimaanbarang.Item("terimabarang_id", DgvTrnPenerimaanbarang.SelectedCells.Item(0).RowIndex).Value & "'", Me._CHANNEL)
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

            odatafiller.DataFillAsset(Me.ASSET_DSN, tbl_PrintDetil, "as_RptPenerimaanBarangDetil_Select", "terimabarang_id = '" & .terimabarang_id & "'", Me._CHANNEL)
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
            objDetil = New DataSource.clsRptPenerimaanBarangDetil(Me.DSN, Me.ASSET_DSN)
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

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        Dim stream As System.IO.Stream
        Dim deviceInfo As String = _
        "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.27in</PageWidth>" & _
        "  <PageHeight>11.69in</PageHeight>" & _
        "  <MarginTop>0.2in</MarginTop>" & _
        "  <MarginLeft>0.01in</MarginLeft>" & _
        "  <MarginRight>0.01in</MarginRight>" & _
        "  <MarginBottom>0.2in</MarginBottom>" & _
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
        Dim stream As System.IO.Stream = New System.IO.FileStream("C:\TransBrowser\Temp" & Name & "." & fileNameExtension, System.IO.FileMode.Create)

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
        ' ''Const printerName As String = "Microsoft Office Document Image Writer"
        Dim printerName As String = printSet.PrinterName

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

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)

        objDatalistHeader = Me.GenerateDataHeader()


        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.sptChannel_ID)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptTerimaBarang_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("terimabarang_id", Me.sptTerimaBarang_ID)
        Dim parRptDomain As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", Me.sptDomain)

        objRdsH.Name = "ASSET_DataSource_clsRptPenerimaanBarang"
        objRdsH.Value = objDatalistHeader

        If ket = "Internal" Then
            objReportH.ReportEmbeddedResource = "ASSET.rptPenerimaanBarang.rdlc"
        Else
            objReportH.ReportEmbeddedResource = "ASSET.rptPenerimaanBarangX.rdlc"
        End If

        objReportH.DataSources.Add(objRdsH)
        objReportH.EnableExternalImages = True
        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptTerimaBarang_ID, parRptDomain})

        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()
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
 
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        Me.tbl_Print.Clear()
        Me.DataFill(Me.tbl_Print, "cp_RptJurnal_SelectHeader", String.Format("jurnal_id = '{0}' AND channel_id = '{1}'", Me.DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_id").Value, Me._CHANNEL))

        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer & "/Solutions/images/" & Me._CHANNEL & ".jpg")
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_name", CStr(Me.tbl_Print.Rows(0).Item("channel_name")))
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_address", CStr(Me.tbl_Print.Rows(0).Item("channel_address")))

        objDatalistHeader = Me.GenerateDataHeaderJurnal(Me.DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_id").Value, Me._CHANNEL)

        Dim parRptJurnalID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_id", parJurnal_id)
        Dim parRptJurnalTypeID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnaltype_id", Me.parJurnalType_id)
        Dim parRptJurnal_Source As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_source", Me.parJurnal_Source)
        Dim parRptJurnal_BookDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_bookdate", Me.parJurnal_BookDate)
        Dim parRptPeriodeName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("periode_name", Me.parPeriode_Name)
        Dim parRptCurrencyName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("currency_name", Me.parCurrency_Name)
        Dim parRptJurnal_AmountForeign As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_amountforeign", Me.parJurnal_AmountForeign)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekanan_name", Me.parRekanan_Name)
        Dim parRptJurnal_Desc As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_descr", Me.parJurnal_Desc)

        objRdsH.Name = "NEWACT_DataSource_clsRptJurnal_Header"
        objRdsH.Value = objDatalistHeader

        If Me.tbl_Print.Rows(0).Item("jurnal_source") = "RV-ListBPB" Then
            objReportH.ReportEmbeddedResource = "ASSET.rptJurnal_Penerimaanbarang_Header.rdlc"
        End If

        objReportH.DataSources.Add(objRdsH)
        objReportH.EnableExternalImages = True

        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannel_namereport, parRptChannel_address, parRptJurnalID, _
        parRptJurnalTypeID, parRptJurnal_Source, parRptJurnal_BookDate, parRptPeriodeName, _
        parRptCurrencyName, parRptCurrencyName, parRptJurnal_AmountForeign, parRptRekananName, _
        parRptJurnal_Desc})

        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()

    End Function
    Private Function GenerateDataHeaderJurnal(ByVal jurnal_id_temp As String, ByVal channel_id_temp As String) As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        objPrintHeaderJurnal = New DataSource.clsRptJurnal_Header()
        With objPrintHeaderJurnal
            .jurnal_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_id"), String.Empty)
            Me.parJurnal_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_id"), String.Empty)
            Me.parJurnalType_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnaltype_id"), String.Empty)
            Me.parJurnal_Source = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_source"), String.Empty)
            Me.parJurnal_BookDate = clsUtil.IsDbNull(Format(Me.tbl_Print.Rows(0).Item("jurnal_bookdate"), "dd/MMM/yyyy"), Now.Date)
            Me.parPeriode_Name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("periode_name"), String.Empty)
            Me.parJurnal_Desc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_descr"), String.Empty)
            Me.parRekanan_Name = clsUtil.IsDbNull(Trim(Me.tbl_Print.Rows(0).Item("rekanan_name")), String.Empty)
            Me.parCurrency_Name = clsUtil.IsDbNull(Trim(Me.tbl_Print.Rows(0).Item("currency_name")), String.Empty)
            Me.parJurnal_AmountForeign = clsUtil.IsDbNull(Format(Me.tbl_Print.Rows(0).Item("jurnal_amountforeign"), "#,##0"), 0)
            .jurnal_createby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("created_by_name"), String.Empty)
            .jurnal_createdate = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("jurnal_createdate"), Now.Date)
            .jurnal_postby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("post_by_name"), String.Empty)

            Me.tbl_PrintDetil.Clear()
            Me.DataFill(Me.tbl_PrintDetil, "cp_RptJurnal_SelectDetil", String.Format("jurnal_id='{0}' AND channel_id = '{1}'", jurnal_id_temp, channel_id_temp))
            Me.GenerateDataDetailJurnal()
        End With
        objDatalistHeader.Add(objPrintHeaderJurnal)

        Return objDatalistHeader
    End Function
    Private Function GenerateDataDetailJurnal() As ArrayList
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objPrintDetilJurnal = New DataSource.clsRptJurnal_Detil(Me.DSN)
            With objPrintDetilJurnal
                .jurnal_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnal_id"), String.Empty)
                .acc_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_id"), String.Empty)
                .acc_name = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_name"), String.Empty)
                .rekanan_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("rekanan_id"), String.Empty)
                .rekanan_name = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("rekanan_name"), String.Empty)
                .jurnaldetil_descr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_descr"), String.Empty)
                .ref_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ref_id"), String.Empty)
                .jurnaldetil_foreignrate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_foreignrate"), 0)
                .jurnaldetil_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_foreign"), 0)
                .jurnaldetil_idr = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jurnaldetil_idr"), 0)

            End With
            objDatalistDetil.Add(objPrintDetilJurnal)
        Next
        Return objDatalistDetil
    End Function

    Private Function uiTrnPenerimaanBarang_PrintPreview() As Boolean
        If Me.DgvTrnPenerimaanbarang.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        If CBool(Me.DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_appspv").Value) = True Then

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

                terimabarang_id = DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_id").Value
                Dim frmPrint As dlgRptPenerimaanBarang = New dlgRptPenerimaanBarang(Me.DSN, Me.ASSET_DSN, Me.SptServer, Me._CHANNEL, ket)
                Dim criteria As String = String.Empty

                frmPrint.ShowInTaskbar = False
                frmPrint.StartPosition = FormStartPosition.CenterParent

                criteria = " terimabarang_id = '" & terimabarang_id & "'"

                frmPrint.SetIDCriteria(criteria)
                frmPrint.ShowDialog(Me)
            Else
                Dim frmPrint As dlgRptJurnal = New dlgRptJurnal(Me.DSN, Me.SptServer, DgvTrnPenerimaanbarang.CurrentRow.Cells("terimabarang_id").Value, Me._CHANNEL)

                frmPrint.ShowInTaskbar = False
                frmPrint.StartPosition = FormStartPosition.CenterParent
                frmPrint.ShowDialog(Me)
            End If
        Else
            MsgBox("SPV / Sect. Head approval is required to print this document")
            Exit Function
        End If

    End Function

    Private Sub btn_Parent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Parent.Click
        If DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_nonfixasset").Value = True Then
            Dim param As Integer = 1
            Dim listbarcode As String
            Dim dlg As New dlgListBarangNonFix(Me.DSN, _CHANNEL, param, Me._STRUKTUR_UNIT, DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_parentbarcode").Value)

            listbarcode = dlg.OpenDialog(Me)
            If listbarcode IsNot Nothing Then
                Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_barcode").Value = listbarcode
            End If
        Else
            Dim param As Integer = 2
            Dim listbarcodeInduk As String
            Dim dlg As New dlgListBarangNonFix(Me.DSN, _CHANNEL, param, Me._STRUKTUR_UNIT, DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_parentbarcode").Value)
            listbarcodeInduk = dlg.OpenDialog(Me)
            If listbarcodeInduk IsNot Nothing Then
                Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_parentbarcode").Value = listbarcodeInduk
                Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_parentline").Value = 0
                Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_parentline").ReadOnly = True
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

    Private Sub btn_BuiltJurnal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_BuiltJurnal.Click
        Dim row As DataRow
        Dim tbl_debetTemp As DataTable = New DataTable
        Dim i As Integer
        Dim isOk As Boolean = True

        If Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc") = True Then
            MsgBox("transactions has been posted. please un-posted this transaction")
            Exit Sub
        End If

        For i = 0 To Me.tbl_TrnJurnaldetil_debet.Rows.Count - 1
            If Me.tbl_TrnJurnaldetil_debet.Rows(i).RowState <> DataRowState.Deleted Then
                If Me.tbl_TrnJurnaldetil_debet.Rows(i).Item("ref_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("order_id").Value And _
                    Me.tbl_TrnJurnaldetil_debet.Rows(i).Item("ref_line") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("orderdetil_line").Value And _
                    Me.tbl_TrnJurnaldetil_debet.Rows(i).Item("jurnaldetil_line") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_line").Value Then
                    MsgBox("This line already exists journal")
                    isOk = False
                    Exit For
                Else
                    isOk = True
                End If
            End If
        Next

        If isOk = True Then
            Dim budget_name() As DataRow
            Dim budgetdetil_name() As DataRow
            budget_name = Me.tbl_TrnBudget.Select(String.Format("budget_id = {0}", Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("budget_id").Value))
            budgetdetil_name = Me.tbl_TrnBudgetDetil.Select(String.Format("budget_id = {0} AND budgetdetil_id = {1}", Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("budget_id").Value, Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("budgetdetil_id").Value))

            tbl_debetTemp.Clear()

            Me.DataFill(tbl_debetTemp, "ms_MstAcc_SelectBySource", String.Format("B.source_id = 'RV-ListBpj' AND B.dk = 'K' WHERE B.source_id = 'RV-ListBpj' AND B.dk = 'K'"))

            '============ Mulai masukkan data ke tab bagian Debet Na =======
            row = Me.tbl_TrnJurnaldetil_debet.NewRow
            row.Item("jurnal_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_id").Value
            row.Item("acc_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("acc_id").Value '0
            row.Item("jurnaldetil_foreignrate") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_foreignrate").Value

            If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_qty").Value, 0) = 0 Then

                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_idr") = 0

            Else
                row.Item("jurnaldetil_foreign") = Math.Round((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_qty").Value, 0), 2, MidpointRounding.AwayFromZero)
                row.Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_foreignrate").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_qty").Value, 0), 0, MidpointRounding.AwayFromZero)

            End If

            row.Item("jurnaldetil_descr") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_desc").Value
            row.Item("ref_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("order_id").Value
            row.Item("ref_line") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("orderdetil_line").Value
            row.Item("currency_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("currency_id").Value
            row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
            row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
            row.Item("strukturunit_id") = Me._STRUKTUR_UNIT
            row.Item("budget_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("budget_id").Value
            row.Item("budget_name") = Trim(budget_name(0).Item(2))
            row.Item("budgetdetil_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("budgetdetil_id").Value
            row.Item("budgetdetil_name") = Trim(budgetdetil_name(0).Item(2))
            row.Item("jurnaldetil_line") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_line").Value
            Me.tbl_TrnJurnaldetil_debet.Rows.Add(row)

            '============ Akhir dari masukkan data ke tab bagian Debet ===========

            '============ Mulai masukkan data ke tab bagian Kredit Na =======
            row = Me.tbl_TrnJurnaldetil_kredit.NewRow

            row.Item("jurnal_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_id").Value
            row.Item("acc_id") = 1706000
            row.Item("jurnaldetil_foreignrate") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_foreignrate").Value

            If clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_qty").Value, 0) = 0 Then

                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_idr") = 0

            Else
                row.Item("jurnaldetil_foreign") = Math.Round((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_qty").Value, 0), 2, MidpointRounding.AwayFromZero)
                row.Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_foreignrate").Value, 0)) * clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_qty").Value, 0), 0, MidpointRounding.AwayFromZero)
            End If

            row.Item("jurnaldetil_descr") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_desc").Value
            row.Item("ref_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("order_id").Value
            row.Item("ref_line") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("orderdetil_line").Value
            row.Item("currency_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("currency_id").Value
            row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
            row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
            row.Item("strukturunit_id") = Me._STRUKTUR_UNIT
            row.Item("budget_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("budget_id").Value
            row.Item("budget_name") = Trim(budget_name(0).Item(2))
            row.Item("budgetdetil_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("budgetdetil_id").Value
            row.Item("budgetdetil_name") = Trim(budgetdetil_name(0).Item(2))
            row.Item("jurnaldetil_line") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarangdetil_line").Value - 5
            Me.tbl_TrnJurnaldetil_kredit.Rows.Add(row)

            '============ Akhir dari masukkan data ke tab bagian Kredit ===========

            '============ Mulai masukkan data ke tab bagian Reference Na =======
            row = Me.tbl_JurnalReference.NewRow
            row.Item("jurnal_id") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("terimabarang_id").Value
            row.Item("jurnal_id_ref") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("order_id").Value
            row.Item("jurnal_id_refline") = Me.DgvTrnPenerimaanbarangdetil.CurrentRow.Cells("orderdetil_line").Value
            Me.tbl_JurnalReference.Rows.Add(row)
            '============ Akhir dari masukkan data ke tab Reference Kredit ===========

            '============ Mulai masukkan data ke tabel bagian Header Na =======
            If Me.tbl_TrnJurnal.Rows.Count = 0 Then
                Me.tbl_TrnJurnal.Rows.Add()
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Me.obj_Terimabarang_id.Text
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_duedate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_notes").Value
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_invoice_id") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_invoice_descr") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBPJ"
                Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = String.Format("{0:yyMM}", Now)
                Me.tbl_TrnJurnal.Rows(0).Item("channel_id") = Me._CHANNEL
                Me.tbl_TrnJurnal.Rows(0).Item("budget_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("currency_id").Value
                Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = Me.DgvTrnPenerimaanbarang.Rows(Me.DgvTrnPenerimaanbarang.CurrentRow.Index).Cells("terimabarang_foreignrate").Value
                Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = Me._STRUKTUR_UNIT
                Me.tbl_TrnJurnal.Rows(0).Item("acc_ca_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("region_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("branch_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("advertiser_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("brand_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("ae_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_iscreated") = 1
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_iscreatedby") = "SYSTEM"
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_iscreatedate") = Now()
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_ispostedby") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposteddate") = DBNull.Value
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisabled") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisabledby") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisableddt") = DBNull.Value
                Me.tbl_TrnJurnal.Rows(0).Item("created_by") = Me.UserName
                Me.tbl_TrnJurnal.Rows(0).Item("created_dt") = Now()
                Me.tbl_TrnJurnal.Rows(0).Item("modified_by") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("modified_dt") = DBNull.Value
            End If
            '============ Akhir dari masukkan data ke tabel Header ===========
        End If
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

    Private Sub obj_Terimabarangdetil_qty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Terimabarangdetil_qty.Validated
        Dim ppnAmount As Decimal
        Dim ppnAmountIDR As Decimal
        Dim pphAmount As Decimal
        Dim pphAmountIDR As Decimal
        Dim totalAmount As Decimal
        Dim totalAmountIDR As Decimal

        Dim h As Integer

        For h = 0 To Me.DgvTrnPenerimaanbarangdetil.Rows.Count - 1
            If Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_line").Value = Me.obj_Terimabarangdetil_line.Text Then

                pphAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_disc").Value, 0)) * Me.obj_Terimabarangdetil_qty.Text) * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_pphpercent").Value, 0) / 100)

                pphAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_disc").Value, 0)) * Me.obj_Terimabarangdetil_qty.Text) _
                                    * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_pphpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_foreignrate").Value, 0))

                ppnAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_disc").Value, 0)) * Me.obj_Terimabarangdetil_qty.Text) _
                                                       * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100)

                ppnAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_disc").Value, 0)) * Me.obj_Terimabarangdetil_qty.Text) _
                                    * (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_ppnpercent").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_foreignrate").Value, 0))

                totalAmount = ((clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_disc").Value, 0)) * Me.obj_Terimabarangdetil_qty.Text) _
                                    - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                totalAmountIDR = (clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_foreign").Value, 0) - clsUtil.IsDbNull(Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_disc").Value, 0)) * clsUtil.IsDbNull(DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_foreignrate").Value, 0) * _
                                          Me.obj_Terimabarangdetil_qty.Text - _
                                          clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                If Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("currency_id").Value = 1 Then
                    Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
                Else
                    Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_pphforeign").Value = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_ppnforeign").Value = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                    Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_totalforeign").Value = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)
                End If
                Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_pphidrreal").Value = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_ppnidrreal").Value = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                Me.DgvTrnPenerimaanbarangdetil.Rows(h).Cells("terimabarangdetil_totalidrreal").Value = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)
            End If
        Next
    End Sub

    Private Sub btnPrintAllBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintAllBarcode.Click
        Dim nm_perusahaan As String = Me.getNamaPerusahaan()

        Me.PrintBarcode(nm_perusahaan, Me.tbl_TrnPenerimaanbarangdetil.Select())
    End Sub

    Private Function getNamaPerusahaan() As String
        Dim dbConn As New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim cmd As OleDb.OleDbCommand

        Try
            dbConn.Open()

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
                dbConn.Close()
            End If
        End Try
    End Function

    Private Sub PrintBarcode(ByVal nm_perusahan As String, ByVal barcodeRow As DataRow())
        Dim barcode As String = ""
        Dim tipe As String
        Dim result As String = ""
        Dim byteRst() As Byte
        Dim fileName As String = "C:\Transbrowser\Barcode\netbarcode.txt"
        Dim pathexe As String = "C:\Transbrowser\Barcode\Label.exe"
        Dim nonfix As Boolean
        Dim acc_approve As Object
        Dim rowCount As Integer

        'Cek accounting approve
        rowCount = Me.tbl_TrnPenerimaanbarang_Temp.Rows.Count
        If rowCount > 0 Then
            acc_approve = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc")
            If acc_approve = False Then
                MsgBox("Can't print barcode before approved by accounting.", MsgBoxStyle.Information)
                Exit Sub
            End If
        Else
            Exit Sub
        End If
        '====================================

        For Each row As DataRow In barcodeRow
            barcode = row.Item("terimabarang_barcode").ToString()
            
            If barcode.Trim <> "" Then
                nonfix = row.Item("terimabarangdetil_nonfixasset")
                tipe = row.Item("terimabarangdetil_product_no").ToString()

                If nonfix = True Then
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

End Class