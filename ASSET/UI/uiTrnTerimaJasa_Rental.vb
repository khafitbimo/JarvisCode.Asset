Imports Microsoft.Win32
Imports System.Threading
Imports System.ComponentModel
Public Class uiTrnTerimaJasa_Rental
    Implements ILocking

    Private Const mUiName As String = "Transaksi Terima Jasa Rental"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object) 'test + baru

    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_TrnTerimajasa As DataTable = clsDataset.CreateTblTrnTerimajasa()
    Private tbl_TrnTerimajasa_Temp As DataTable = clsDataset.CreateTblTrnTerimajasa()
    Private tbl_TrnTerimajasadetil As DataTable = clsDataset.CreateTblTrnTerimajasadetil()
    Private tbl_TrnTerimajasaUsed As DataTable = clsDataset.CreateTblTrnTerimajasaused()

    '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
    Private tbl_MstChannel_channel_id_search As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstRekanan_rekanan_id_search As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_MstStrukturunit_id_search As DataTable = clsDataset.CreateTblStrukturunitPemilik
    '-----End Bikin Tabel untuk combo Data Search-------------------------

    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private Tbl_Mstemployee As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_TrnBudget As DataTable = clsDataset.CreateTblMstBudgetCombo()
    Private tbl_TrnBudgetDetil As DataTable = clsDataset.CreateTblMstBudgetdetilCombo()

    Private tbl_MstItem As DataTable = clsDataset.CreateTblMstItem()
    Private tbl_MstItemCategory As DataTable = clsDataset.CreateTblMstItemcategory()
    Private tbl_MstBrand As DataTable = clsDataset.CreateTblMstMerk
    Private tbl_MstCurrency As DataTable = clsDataset.CreateTblMstCurrency
    Private tbl_MstCurrencyDetil As DataTable = clsDataset.CreateTblMstCurrency
    Private tbl_MstCurrencyGrid As DataTable = clsDataset.CreateTblMstCurrencyJurnal
    Private tbl_MstAccGrid As DataTable = clsDataset.CreateTblMstAccountCombo()

    Private tbl_TrnOrderdetil As DataTable = clsDataset.CreateTblTrnOrderdetil()
    '-- Untuk Jurnal
    Private tbl_TrnJurnal As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_TrnJurnaldetil_kredit As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_TrnJurnaldetil_debet As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_JurnalReference As DataTable = clsDataset.CreateTblTrnJurnalreference()
    Private tbl_JurnalResponse As DataTable = clsDataset.CreateTblJurnalResponseRV()
    Private tbl_MstStrukturunitGrid As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_MstPeriodeCombo As DataTable = clsDataset.CreateTblMstPeriodeCombo()

    Private tbl_MstPeriode As DataTable = clsDataset.CreateTblMstPeriodeCombo()
    '--- ADDITIONAL BUTTON
    Friend WithEvents btnApproved As ToolStripButton = New ToolStripButton
    Friend WithEvents btnUnApproved As ToolStripButton = New ToolStripButton

    Private _LOADCOMBOSEARCH As Boolean = False
    Private label_thread As String
    Private isBackGroundWorker_isWork As Boolean = False
    Private isBackgroundWorker As Boolean = False

    Private isLock As Byte
    Private total_days As Integer

    'TO DO PRINT
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnTerimajasa
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnTerimajasadetil
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptTerimaJasaRental
    Private objDatalistDetil As ArrayList
    '===
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptTerimaJasa_id As String
    Private sptDomain As String

    Private strukturunit As Decimal
    Private currency_id As Decimal
    Private foreign_rate As Decimal

    Private channel_number As String

    Private sptSumTotal As String
    Private sptSumDiscount As String
    Private sptSumPPn As String
    Private sptSumPPh As String
    Private sptSumGrandTotal As String

    Private locking As clsLockingTransaction

#Region " Window Parameter "
    Private _CHANNEL As String = "TAS"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    ' TODO: Buat variabel untuk menampung parameter window 
    Private _STRUKTUR_UNIT As Decimal = 5554 '5559 '4310 '5555 '3130 '2610 '2610 '2360 '3501

    ' ''Private _BM As Boolean = False
    ' ''Private _PC As Boolean = False
    ' ''Private _US As Boolean = True

    Private _USERTYPE As String = "spv" 'user 'spv 'bma

#End Region

#Region " Additional Overrides "
    Private Sub btnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproved.Click
        If Me.DgvTrnTerimajasa.Rows.Count > 0 Then
            If Me._USERTYPE = "user" Then
                Dim terimajasa_id As String = Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value
                Me.locking.TryLocking(terimajasa_id)

                If Me.locking.Status = clsLockingTransaction.LockStatus.Locked Then
                    MessageBox.Show("" & terimajasa_id & " is being used by another user", "DATA CAN'T APPROVED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.btnApproved.Enabled = True
                    Exit Sub
                Else
                    If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appuser").Value = 0 Then
                        Me.uiTrnTerimaJasa_Rental_AppUser("approved")
                        Me.btnApproved.Enabled = False
                        Me.btnUnApproved.Enabled = True
                    End If
                End If
                Me.locking.Clear()
            ElseIf Me._USERTYPE = "spv" Then
                If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appuser").Value = 0 Then
                    MsgBox("Need User Approved", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appspv").Value = 0 Then
                    Me.uiTrnTerimaJasa_Rental_AppSpv("approved")
                End If
            ElseIf Me._USERTYPE = "bma" Then
                If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appuser").Value = 0 Then
                    MsgBox("Need User Approved", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appspv").Value = 0 Then
                    MsgBox("Need Spv Approved", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appbma").Value = 0 Then
                    Me.uiTrnTerimaJasa_Rental_AppBma("approved")
                End If
            End If
        End If
    End Sub

    Private Sub btnUnApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnApproved.Click
        If Me.DgvTrnTerimajasa.Rows.Count > 0 Then
            If Me._USERTYPE = "user" Then
                Dim terimajasa_id As String = Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value
                Me.locking.TryLocking(terimajasa_id)

                If Me.locking.Status = clsLockingTransaction.LockStatus.Locked Then
                    MessageBox.Show("" & terimajasa_id & " is being used by another user", "DATA CAN'T UNAPPROVED", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.btnUnApproved.Enabled = True
                    Exit Sub
                Else
                    If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appbma").Value = 1 Then
                        MsgBox("Need BMA UnApproved", MsgBoxStyle.Information)
                    ElseIf Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appspv").Value = 1 Then
                        MsgBox("Need Spv / Section Head UnApproved", MsgBoxStyle.Information)
                    ElseIf Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appuser").Value = 1 Then
                        'unapproved user
                        Me.uiTrnTerimaJasa_Rental_AppUser("unapproved")
                        Me.btnApproved.Enabled = True
                        Me.btnUnApproved.Enabled = False
                    End If
                End If

                Me.locking.Clear()
            ElseIf Me._USERTYPE = "spv" Then
                If Me.DgvTrnTerimajasa.Item("terimajasa_appbma", DgvTrnTerimajasa.CurrentRow.Index).Value = 1 Then
                    MsgBox("Need BMA UnApproved", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appspv").Value = 1 Then
                    Me.uiTrnTerimaJasa_Rental_AppSpv("unapproved")
                End If
            ElseIf Me._USERTYPE = "bma" Then
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
                    Dim terimajasa_appbma_by As String = Me.tbl_TrnTerimajasa_Temp.Rows(0).Item("terimajasa_appbma_by")

                    Me.DataFill(tbl_periode, "ms_MstPeriode_Select", String.Format("periode_id = '{0}' and channel_id = '{1}'", Me.cbo_periode.SelectedValue, Me._CHANNEL))

                    If tbl_periode.Rows(0).Item("periode_isclosed") = True Then
                        MsgBox("Periode is closed")
                        Exit Sub
                    Else
                        If Me.UserName <> terimajasa_appbma_by Then
                            MsgBox("Access Denied")
                        Else
                            Me.uiTrnTerimaJasa_Rental_AppBma("unapproved")
                        End If

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub uiTrnTerimaJasa_Rental_AppUser(ByVal status As String)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        ' Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNAsset)
        Dim tbl_strukturunitRV As DataTable = New DataTable
        Dim cookie As Byte() = Nothing
        '   Dim cookie1 As Byte() = Nothing

        '=====ADD PTS 20130704--"Cegah Currency Kosong"
        tbl_strukturunitRV.Clear()
        Me.DataFill(tbl_strukturunitRV, "tr_StrukturunitOrderAll_select", "terimajasa_id = '" & Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value & "'")
        Me.strukturunit = tbl_strukturunitRV.Rows(0).Item("strukturunit_id")
        Me.currency_id = tbl_strukturunitRV.Rows(0).Item("currency_id")
        Me.foreign_rate = tbl_strukturunitRV.Rows(0).Item("order_foreignrate")
        '==================================================================

        '==============ADD PTS 20130704 currency bermasalah=============
        Dim cur_id As Decimal = Me.DgvTrnTerimajasa.Item("currency_id", DgvTrnTerimajasa.CurrentRow.Index).Value
        If cur_id = 0 Then
            Me.Isi_CurrencyBermasalah(Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value)
        End If
        '===============================================================

        Try
            dbConn.Open()
            'dbConnAsset.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            ' clsApplicationRole.SetAppRole(dbConnAsset, cookie1)
            Dim oCm As New OleDb.OleDbCommand("as_TrnTerimaJasa_UserApproved", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 24).Value = Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status
            oCm.ExecuteNonQuery()
            oCm.Dispose()

            If status = "approved" Then
                Me.obj_Terimajasa_appuser.Checked = True
                Me.DgvTrnTerimajasa.Item("terimajasa_appuser", DgvTrnTerimajasa.CurrentRow.Index).Value = 1
                MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.obj_Terimajasa_appuser.Checked = False
                Me.DgvTrnTerimajasa.Item("terimajasa_appuser", DgvTrnTerimajasa.CurrentRow.Index).Value = 0
                MessageBox.Show("Data Has Been UnApproved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            ' clsApplicationRole.UnsetAppRole(dbConnAsset, cookie1)
            dbConn.Close()
            ' dbConnAsset.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub


    Private Sub Isi_CurrencyBermasalah(terimajasa_id)
        '==========PTS 20130704 currency gk masuk====
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Dim oCm As New OleDb.OleDbCommand("as_TrnTerimajasa_IsiCurrencyKosong", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = terimajasa_id 'Me.obj_Terimajasa_id.Text
            oCm.Parameters.Add("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5).Value = currency_id
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            oCm.Parameters.Add("@terimajasa_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9).Value = foreign_rate
            oCm.ExecuteNonQuery()
            oCm.Dispose()
        Catch ex As Exception

        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Sub


    Private Sub uiTrnTerimaJasa_Rental_AppSpv(ByVal status_approved As String)
        Dim dlg As New dlgStatusTerimaJasa()
        Dim status As String = String.Empty
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        'Dim dbConnStart As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNStart)
        Dim cookie As Byte() = Nothing
        'Dim cookie2 As Byte() = Nothing

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If status_approved = "approved" Then
            'KS --
            'Tambahan handle rv sudah complete atau belum
            '-------------------------------------------------------------------------
            Dim db As New DataClassesFRMDataContext(Me.DSNLinq)
            Dim isComplete As Boolean

            db.OpenConnectionWithRole()

            isComplete = db.f_Terimajasa_IsComplete(Me.obj_Order_id.Text.Trim)

            db.CloseConnectionWithRole()

            If isComplete = True Then
                MsgBox("Tidak dapat approve karena rv sudah complete.", MsgBoxStyle.Exclamation)

                Exit Sub
            End If
            '-------------------------------------------------------------------------

            status = dlg.OpenDialog(Me)

            If status IsNot Nothing Then
                If status = "-- Pilih --" Then
                    MsgBox("Please choose COMPLETE or INCOMPLETE")
                    Exit Sub
                Else
                    '==============ADD PTS 20130704 currency bermasalah=============
                    Dim cur_id As Decimal = Me.tbl_TrnTerimajasa_Temp.Rows(0).Item("currency_id")
                    If cur_id = 0 Then
                        Me.Isi_CurrencyBermasalah(Me.obj_Terimajasa_id.Text)
                    End If
                    '===============================================================

                    Try
                        Me.uiTrnTerimaJasa_Rental_BuiltJurnal()
                        dbConn.Open()
                        'dbConnStart.Open()
                        clsApplicationRole.SetAppRole(dbConn, cookie)
                        'clsApplicationRole.SetAppRole(dbConnStart, cookie2)
                        Dim oCm As New OleDb.OleDbCommand("as_TrnTerimajasa_SpvApproved", dbConn)
                        oCm.CommandType = CommandType.StoredProcedure
                        oCm.Parameters.Add("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.obj_Terimajasa_id.Text
                        oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
                        oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
                        oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 40).Value = status
                        oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value
                        oCm.Parameters.Add("@status_approved", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status_approved
                        oCm.ExecuteNonQuery()
                        oCm.Dispose()
                        Me.obj_Terimajasa_appspv.Checked = True
                        Me.DgvTrnTerimajasa.Item("terimajasa_appspv", DgvTrnTerimajasa.CurrentRow.Index).Value = 1
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
                        clsApplicationRole.UnsetAppRole(dbConn, cookie)
                        'clsApplicationRole.UnsetAppRole(dbConnStart, cookie2)
                        dbConn.Close()
                        'dbConnStart.Close()
                    End Try
                End If
            End If
        Else
            If Me.obj_Terimajasa_status.Text.ToLower.Trim <> "complete" Then
                'KS --
                'Tambahan handle rv sudah complete atau belum
                '-------------------------------------------------------------------------
                Dim db As New DataClassesFRMDataContext(Me.DSNLinq)
                Dim isComplete As Boolean

                db.OpenConnectionWithRole()

                isComplete = db.f_Terimajasa_IsComplete(Me.obj_Order_id.Text.Trim)

                db.CloseConnectionWithRole()

                If isComplete = True Then
                    MsgBox("Tidak dapat unapprove karena rv sudah complete.", MsgBoxStyle.Exclamation)

                    Exit Sub
                End If
                '-------------------------------------------------------------------------
            End If

            Try
                dbConn.Open()
                'dbConnStart.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)
                'clsApplicationRole.SetAppRole(dbConnStart, cookie2)
                Dim oCm As New OleDb.OleDbCommand("as_TrnTerimajasa_SpvApproved", dbConn)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value
                oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
                oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
                oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 40).Value = status
                oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value
                oCm.Parameters.Add("@status_approved", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status_approved
                oCm.ExecuteNonQuery()
                oCm.Dispose()
                Me.obj_Terimajasa_appspv.Checked = False
                Me.DgvTrnTerimajasa.Item("terimajasa_appspv", DgvTrnTerimajasa.CurrentRow.Index).Value = 0
                MessageBox.Show("Data Has Been UnApproved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnApproved.Enabled = True
                Me.btnUnApproved.Enabled = False
                Me.tbtnDel.Enabled = True
                Me.tbtnSave.Enabled = True
                Me.uiTrnTerimaJasa_Rental_OpenRowJurnalDetil_kredit(Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value, Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value, dbConn)
                Me.uiTrnTerimaJasa_Rental_OpenRowJurnalDetil_Debet(Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value, Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value, dbConn)
                Me.uiTrnTerimajasa_Rental_OpenRowJurnalReference(Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value, Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value, dbConn)
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                ' clsApplicationRole.UnsetAppRole(dbConnStart, cookie2)
                dbConn.Close()
                ' dbConnStart.Close()
            End Try
        End If
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub uiTrnTerimaJasa_Rental_AppBma(ByVal status As String)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.uiTrnTerimaJasa_Rental_FormError() Then
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Exit Sub
        End If

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)

            '============================ REMARK BY PTS 20170814 =================================
            'Dim oCm As New OleDb.OleDbCommand("as_TrnTerimaJasa_bmaApproved", dbConn)
            'oCm.CommandType = CommandType.StoredProcedure
            'oCm.Parameters.Add("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            'oCm.Parameters.Add("@bma_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            'oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            'oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status

            'oCm.ExecuteNonQuery()
            'oCm.Dispose()

            'Dim oCmAsset As New OleDb.OleDbCommand("as_TrnTerimaJasa_bmaApproved2", dbConn)

            'oCmAsset.CommandType = CommandType.StoredProcedure
            'oCmAsset.Parameters.Add("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            'oCmAsset.Parameters.Add("@bma_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            'oCmAsset.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            'oCmAsset.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status

            'oCmAsset.ExecuteNonQuery()
            'oCmAsset.Dispose()

            '========================= MODIFIED PTD 20170814 =========================================
            Dim oCm As New OleDb.OleDbCommand("as_TerimaJasa_Posting", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            oCm.Parameters.Add("@bma_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status

            oCm.ExecuteNonQuery()
            oCm.Dispose()

            If status = "approved" Then
                Me.obj_Terimajasa_appbma.Checked = True
                MessageBox.Show("Data Has Been Post", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DgvTrnTerimajasa.Item("terimajasa_appbma", Me.DgvTrnTerimajasa.CurrentRow.Index).Value = 1

                If Me.tbl_TrnJurnal.Rows.Count > 0 Then
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 1
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_ispostedby") = Me.UserName
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposteddate") = Now()
                End If

                Me.btnApproved.Enabled = False
                Me.btnUnApproved.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnSave.Enabled = False
            Else
                Me.obj_Terimajasa_appbma.Checked = False
                MessageBox.Show("Data Has Been UnPost", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DgvTrnTerimajasa.Item("terimajasa_appbma", Me.DgvTrnTerimajasa.CurrentRow.Index).Value = 0

                If Me.tbl_TrnJurnal.Rows.Count > 0 Then
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 0
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_ispostedby") = String.Empty
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposteddate") = DBNull.Value
                End If

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
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub uiTrnTerimaJasa_Rental_BuiltJurnal()
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
        Dim qty As Decimal

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)

        Me.tbl_TrnJurnal.Clear()
        Me.tbl_TrnJurnaldetil_debet.Clear()
        Me.tbl_TrnJurnaldetil_kredit.Clear()
        Me.tbl_JurnalReference.Clear()

        If Me.tbl_TrnTerimajasadetil.Rows.Count > 0 Then
            order_id = Me.obj_Order_id.Text

            tbl_debetTemp.Clear()
            tbl_TrnJurnal.Clear()

            Me.DataFill(tbl_debetTemp, "ms_MstAcc_SelectBySource", String.Format("B.source_id = 'RV-ListBpj' AND B.dk = 'K' WHERE B.source_id = 'RV-ListBpj' AND B.dk = 'K'"))

            '============ Mulai masukkan data ke tab bagian Debet Na =======
            For rows_debet = 0 To Me.tbl_TrnTerimajasadetil.Rows.Count - 1
                Dim budget_name() As DataRow
                Dim budgetdetil_name() As DataRow
                budget_name = Me.tbl_TrnBudget.Select(String.Format("budget_id = {0}", Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("budget_id")))
                budgetdetil_name = Me.tbl_TrnBudgetDetil.Select(String.Format("budget_id = {0} AND budgetdetil_id = {1}", Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("budget_id"), Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("budgetdetil_id")))

                Me.tbl_TrnJurnaldetil_debet.Rows.Add()
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnal_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasa_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("acc_id") = tbl_TrnTerimajasadetil.Rows(rows_debet).Item("acc_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_foreignrate") = Math.Round(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_foreignrate"), 2, MidpointRounding.AwayFromZero)

                Dim discount As Decimal

                'If Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("currency_id") = 1 Then
                '    discount = Math.Round(clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_disc"), 0), 0, MidpointRounding.AwayFromZero)
                'Else
                discount = Math.Round(clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_disc"), 0), 2, MidpointRounding.AwayFromZero)
                'End If

                'Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_foreign"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0)) - (clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_disc"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0))), 2, MidpointRounding.AwayFromZero)
                'Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0)) - (clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_disc"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0))), 0, MidpointRounding.AwayFromZero)

                If clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0) = 0 Then

                    Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_foreign") = 0
                    Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_idr") = 0

                Else

                    If Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("currency_id") = 1 Then
                        Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_foreign"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0))), 0, MidpointRounding.AwayFromZero)
                    Else
                        Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_foreign"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0))), 2, MidpointRounding.AwayFromZero)
                    End If

                    Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_foreign"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_foreignrate"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0) * Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_foreignrate"))), 0, MidpointRounding.AwayFromZero)

                End If

                'Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0))), 0, MidpointRounding.AwayFromZero)

                'Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0) * Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_foreignrate"))), 0, MidpointRounding.AwayFromZero)

                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_desc")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("ref_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("order_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("ref_line") = Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("orderdetil_line")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("currency_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("currency_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("strukturunit_id") = Me._STRUKTUR_UNIT 'Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("strukturunit_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("budget_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("budget_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("budget_name") = Trim(budget_name(0).Item(2))
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("budgetdetil_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("budgetdetil_id")
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("budgetdetil_name") = Trim(budgetdetil_name(0).Item(2))
                Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_line") = Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_line")


                qty = clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0)

                pphAmount += clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_pphidrreal"), 0)
                ppnAmount += clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_ppnidrreal"), 0)
                amountForeign += clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_foreign"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0)
                amountIdrreal += clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_foreignrate"), 0)
                amountDiscount += (discount * qty) 'discount 'clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_disc"), 0)
            Next

            If obj_Currency_id.SelectedValue = 1 Then
                amountDiscount = Math.Round(amountDiscount, 0, MidpointRounding.AwayFromZero)
            Else
                amountDiscount = Math.Round(amountDiscount, 2, MidpointRounding.AwayFromZero)
            End If

            '============ Akhir dari masukkan data ke tab bagian Debet ===========

            '============ Mulai masukkan data ke tab bagian Kredit Na =======
            For rows_kredit = 0 To Me.tbl_TrnTerimajasadetil.Rows.Count - 1
                Dim budget_name() As DataRow
                Dim budgetdetil_name() As DataRow
                budget_name = Me.tbl_TrnBudget.Select(String.Format("budget_id = {0}", Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("budget_id")))
                budgetdetil_name = Me.tbl_TrnBudgetDetil.Select(String.Format("budget_id = {0} AND budgetdetil_id = {1}", Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("budget_id"), Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("budgetdetil_id")))

                Me.tbl_TrnJurnaldetil_kredit.Rows.Add()
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnal_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasa_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_foreignrate") = Math.Round(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_foreignrate"), 2, MidpointRounding.AwayFromZero)

                Dim discount As Decimal

                'If Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("currency_id") = 1 Then
                '    discount = Math.Round(clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_disc"), 0), 0, MidpointRounding.AwayFromZero)
                'Else
                discount = Math.Round(clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_disc"), 0), 2, MidpointRounding.AwayFromZero)
                'End If

                If clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0) = 0 Then
                    Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_foreign") = 0
                    Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_idr") = 0
                Else
                    If Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("currency_id") = 1 Then
                        Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_foreign"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0))), 0, MidpointRounding.AwayFromZero)
                    Else
                        Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_foreign"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0))), 2, MidpointRounding.AwayFromZero)
                    End If

                    Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_foreign"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_foreignrate"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0) * Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_foreignrate"))), 0, MidpointRounding.AwayFromZero)
                End If

                'Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_foreign"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0)) - (clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_disc"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0))), 2, MidpointRounding.AwayFromZero)
                'Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0)) - (clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_disc"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0))), 0, MidpointRounding.AwayFromZero)


                'Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0))), 0, MidpointRounding.AwayFromZero)

                ''''Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_qty_usage"), 0) * Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_foreignrate"))), 0, MidpointRounding.AwayFromZero)


                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_descr") = Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_desc")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("ref_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("order_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("ref_line") = Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("orderdetil_line")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("currency_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("currency_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("strukturunit_id") = Me._STRUKTUR_UNIT 'Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("strukturunit_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("budget_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("budget_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("budget_name") = Trim(budget_name(0).Item(2))
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("budgetdetil_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("budgetdetil_id")
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("budgetdetil_name") = Trim(budgetdetil_name(0).Item(2))
                Me.tbl_TrnJurnaldetil_kredit.Rows(rows_kredit).Item("jurnaldetil_line") = Me.tbl_TrnTerimajasadetil.Rows(rows_kredit).Item("terimajasadetil_line") - 5
            Next
            '============ Akhir dari masukkan data ke tab bagian Kredit ===========

            '============ Mulai masukkan data ke tab bagian Reference Na =======
            For rows_reference = 0 To tbl_TrnTerimajasadetil.Rows.Count - 1
                Me.tbl_JurnalReference.Rows.Add()
                Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id") = Me.tbl_TrnTerimajasadetil.Rows(rows_reference).Item("terimajasa_id")
                Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_ref") = tbl_TrnTerimajasadetil.Rows(rows_reference).Item("order_id")
                Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_refline") = tbl_TrnTerimajasadetil.Rows(rows_reference).Item("orderdetil_line")
            Next
            '============ Akhir dari masukkan data ke tab Reference Kredit ===========

            '============ Mulai masukkan data ke tabel bagian Header Na =======
            If tbl_TrnTerimajasadetil.Rows.Count > 0 Then
                Me.tbl_TrnJurnal.Rows.Add()
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_id").Value
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_duedate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_notes").Value
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_invoice_id") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_invoice_descr") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBPJ"
                Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue

                '=================REMARK PTS 20140301==================
                'Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = String.Format("{0:yyMM}", Now)
                '=================MODIFIED PTS 20140103==========PERUBAHAN FORMAT PERIODE===========================
                Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = Me.channel_number & String.Format("{0:yyMM}", Now)
                '===================================================================================================

                Me.tbl_TrnJurnal.Rows(0).Item("channel_id") = Me._CHANNEL
                Me.tbl_TrnJurnal.Rows(0).Item("budget_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = currency_id '---REMARK BY PTS 20130704---Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("currency_id").Value
                Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = foreign_rate '---REMARK BY PTS 20130704---Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_foreignrate").Value
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

                Me.obj_Terimajasa_foreign.Text = amountForeign
                Me.obj_Terimajasa_idrreal.Text = amountIdrreal
                Me.obj_Terimajasa_pph.Text = pphAmount
                Me.obj_Terimajasa_ppn.Text = ppnAmount
                Me.obj_Terimajasa_disc.Text = amountDiscount
            End If
            '============ Akhir dari masukkan data ke tabel Header ===========
            Dim x As Integer
            Dim isAcc_ok As String = String.Empty
            For x = 0 To Me.tbl_TrnTerimajasadetil.Rows.Count - 1
                If clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(x).Item("acc_id"), "") = "" Then
                    isAcc_ok = "not"
                    Exit For
                Else
                    isAcc_ok = "ok"
                End If
            Next
            If isAcc_ok = "ok" Then
                Me.uiTrnTerimaJasa_Rental_JurnalSave()
            End If
            Me.uiTrnTerimaJasa_Rental_Save()
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
        Me.uiTrnTerimaJasa_Rental_NewData()
        Me.tbtnDel.Enabled = True
        Me.tbtnSave.Enabled = True
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Rental_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnTerimaJasa_Rental_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        If Me._USERTYPE = "bma" Then
            Me.uiTrnTerimaJasa_Rental_JurnalSave()
        Else
            Me.uiTrnTerimaJasa_Rental_Save()
        End If
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function


    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Rental_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Rental_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If clsUtil.IsDbNull(CInt(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appuser").Value), 0) = 1 _
                Or clsUtil.IsDbNull(CInt(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appspv").Value), 0) = 1 _
                Or clsUtil.IsDbNull(CInt(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appbma").Value), 0) = 1 Then
            MsgBox(" Data sudah di approved!!! Jadi Unapproved dulu ya")
            'ElseIf clsUtil.IsDbNull(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_createby").Value, String.Empty) <> Me.UserName Then
            '    MsgBox("Access Denied")
        Else
            Me.uiTrnTerimaJasa_Rental_Delete()
        End If
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Rental_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Rental_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Rental_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Rental_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnTerimajasa(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnTerimajasa Columns 
        Dim cTerimajasa_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_owner As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_qtyitem As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_qtyrealization As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_statusrealization As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_location As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_notes As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_nosuratjalan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_isdisabled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasa_createby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_createdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_modifiedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_modifieddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appuser As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasa_appuser_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appuser_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appspv As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasa_appspv_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appspv_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appbma As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasa_appbma_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_appbma_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_idrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_disc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_cetakbpj As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        'view

        cTerimajasa_id.Name = "terimajasa_id"
        cTerimajasa_id.HeaderText = "Receive No."
        cTerimajasa_id.DataPropertyName = "terimajasa_id"
        cTerimajasa_id.Width = 100
        cTerimajasa_id.Visible = True
        cTerimajasa_id.ReadOnly = False

        cTerimajasa_date.Name = "terimajasa_date"
        cTerimajasa_date.HeaderText = "Date"
        cTerimajasa_date.DataPropertyName = "terimajasa_date"
        cTerimajasa_date.Width = 80
        cTerimajasa_date.Visible = True
        cTerimajasa_date.ReadOnly = False
        cTerimajasa_date.DefaultCellStyle.Format = "dd/MM/yyyy"

        cTerimajasa_type.Name = "terimajasa_type"
        cTerimajasa_type.HeaderText = "Type"
        cTerimajasa_type.DataPropertyName = "terimajasa_type"
        cTerimajasa_type.Width = 100
        cTerimajasa_type.Visible = False
        cTerimajasa_type.ReadOnly = False

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

        cTerimajasa_qtyitem.Name = "terimajasa_qtyitem"
        cTerimajasa_qtyitem.HeaderText = "terimajasa_qtyitem"
        cTerimajasa_qtyitem.DataPropertyName = "terimajasa_qtyitem"
        cTerimajasa_qtyitem.Width = 100
        cTerimajasa_qtyitem.Visible = False
        cTerimajasa_qtyitem.ReadOnly = False

        cTerimajasa_qtyrealization.Name = "terimajasa_qtyrealization"
        cTerimajasa_qtyrealization.HeaderText = "terimajasa_qtyrealization"
        cTerimajasa_qtyrealization.DataPropertyName = "terimajasa_qtyrealization"
        cTerimajasa_qtyrealization.Width = 100
        cTerimajasa_qtyrealization.Visible = False
        cTerimajasa_qtyrealization.ReadOnly = False

        cOrder_qty.Name = "order_qty"
        cOrder_qty.HeaderText = "order_qty"
        cOrder_qty.DataPropertyName = "order_qty"
        cOrder_qty.Width = 100
        cOrder_qty.Visible = False
        cOrder_qty.ReadOnly = False

        cTerimajasa_status.Name = "terimajasa_status"
        cTerimajasa_status.HeaderText = "Status"
        cTerimajasa_status.DataPropertyName = "terimajasa_status"
        cTerimajasa_status.Width = 120
        cTerimajasa_status.Visible = True
        cTerimajasa_status.ReadOnly = False

        cTerimajasa_statusrealization.Name = "terimajasa_statusrealization"
        cTerimajasa_statusrealization.HeaderText = "terimajasa_statusrealization"
        cTerimajasa_statusrealization.DataPropertyName = "terimajasa_statusrealization"
        cTerimajasa_statusrealization.Width = 100
        cTerimajasa_statusrealization.Visible = False
        cTerimajasa_statusrealization.ReadOnly = False

        cTerimajasa_location.Name = "terimajasa_location"
        cTerimajasa_location.HeaderText = "terimajasa_location"
        cTerimajasa_location.DataPropertyName = "terimajasa_location"
        cTerimajasa_location.Width = 100
        cTerimajasa_location.Visible = False
        cTerimajasa_location.ReadOnly = False

        cTerimajasa_notes.Name = "terimajasa_notes"
        cTerimajasa_notes.HeaderText = "Notes"
        cTerimajasa_notes.DataPropertyName = "terimajasa_notes"
        cTerimajasa_notes.Width = 200
        cTerimajasa_notes.Visible = True
        cTerimajasa_notes.ReadOnly = False

        cTerimajasa_nosuratjalan.Name = "terimajasa_nosuratjalan"
        cTerimajasa_nosuratjalan.HeaderText = "terimajasa_nosuratjalan"
        cTerimajasa_nosuratjalan.DataPropertyName = "terimajasa_nosuratjalan"
        cTerimajasa_nosuratjalan.Width = 100
        cTerimajasa_nosuratjalan.Visible = False
        cTerimajasa_nosuratjalan.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cTerimajasa_isdisabled.Name = "terimajasa_isdisabled"
        cTerimajasa_isdisabled.HeaderText = "terimajasa_isdisabled"
        cTerimajasa_isdisabled.DataPropertyName = "terimajasa_isdisabled"
        cTerimajasa_isdisabled.Width = 100
        cTerimajasa_isdisabled.Visible = False
        cTerimajasa_isdisabled.ReadOnly = False

        cTerimajasa_createby.Name = "terimajasa_createby"
        cTerimajasa_createby.HeaderText = "terimajasa_createby"
        cTerimajasa_createby.DataPropertyName = "terimajasa_createby"
        cTerimajasa_createby.Width = 100
        cTerimajasa_createby.Visible = False
        cTerimajasa_createby.ReadOnly = False

        cTerimajasa_createdt.Name = "terimajasa_createdt"
        cTerimajasa_createdt.HeaderText = "terimajasa_createdt"
        cTerimajasa_createdt.DataPropertyName = "terimajasa_createdt"
        cTerimajasa_createdt.Width = 100
        cTerimajasa_createdt.Visible = False
        cTerimajasa_createdt.ReadOnly = False

        cTerimajasa_modifiedby.Name = "terimajasa_modifiedby"
        cTerimajasa_modifiedby.HeaderText = "terimajasa_modifiedby"
        cTerimajasa_modifiedby.DataPropertyName = "terimajasa_modifiedby"
        cTerimajasa_modifiedby.Width = 100
        cTerimajasa_modifiedby.Visible = False
        cTerimajasa_modifiedby.ReadOnly = False

        cTerimajasa_modifieddt.Name = "terimajasa_modifieddt"
        cTerimajasa_modifieddt.HeaderText = "terimajasa_modifieddt"
        cTerimajasa_modifieddt.DataPropertyName = "terimajasa_modifieddt"
        cTerimajasa_modifieddt.Width = 100
        cTerimajasa_modifieddt.Visible = False
        cTerimajasa_modifieddt.ReadOnly = False

        cTerimajasa_appuser.Name = "terimajasa_appuser"
        cTerimajasa_appuser.HeaderText = "User"
        cTerimajasa_appuser.DataPropertyName = "terimajasa_appuser"
        cTerimajasa_appuser.Width = 40
        cTerimajasa_appuser.Visible = True
        cTerimajasa_appuser.ReadOnly = False

        cTerimajasa_appuser_by.Name = "terimajasa_appuser_by"
        cTerimajasa_appuser_by.HeaderText = "terimajasa_appuser_by"
        cTerimajasa_appuser_by.DataPropertyName = "terimajasa_appuser_by"
        cTerimajasa_appuser_by.Width = 100
        cTerimajasa_appuser_by.Visible = False
        cTerimajasa_appuser_by.ReadOnly = False

        cTerimajasa_appuser_dt.Name = "terimajasa_appuser_dt"
        cTerimajasa_appuser_dt.HeaderText = "terimajasa_appuser_dt"
        cTerimajasa_appuser_dt.DataPropertyName = "terimajasa_appuser_dt"
        cTerimajasa_appuser_dt.Width = 100
        cTerimajasa_appuser_dt.Visible = False
        cTerimajasa_appuser_dt.ReadOnly = False

        cTerimajasa_appspv.Name = "terimajasa_appspv"
        cTerimajasa_appspv.HeaderText = "SPV"
        cTerimajasa_appspv.DataPropertyName = "terimajasa_appspv"
        cTerimajasa_appspv.Width = 40
        cTerimajasa_appspv.Visible = True
        cTerimajasa_appspv.ReadOnly = False

        cTerimajasa_appspv_by.Name = "terimajasa_appspv_by"
        cTerimajasa_appspv_by.HeaderText = "terimajasa_appspv_by"
        cTerimajasa_appspv_by.DataPropertyName = "terimajasa_appspv_by"
        cTerimajasa_appspv_by.Width = 100
        cTerimajasa_appspv_by.Visible = False
        cTerimajasa_appspv_by.ReadOnly = False

        cTerimajasa_appspv_dt.Name = "terimajasa_appspv_dt"
        cTerimajasa_appspv_dt.HeaderText = "terimajasa_appspv_dt"
        cTerimajasa_appspv_dt.DataPropertyName = "terimajasa_appspv_dt"
        cTerimajasa_appspv_dt.Width = 100
        cTerimajasa_appspv_dt.Visible = False
        cTerimajasa_appspv_dt.ReadOnly = False

        cTerimajasa_appbma.Name = "terimajasa_appbma"
        cTerimajasa_appbma.HeaderText = "BMA"
        cTerimajasa_appbma.DataPropertyName = "terimajasa_appbma"
        cTerimajasa_appbma.Width = 40
        cTerimajasa_appbma.Visible = True
        cTerimajasa_appbma.ReadOnly = False

        cTerimajasa_appbma_by.Name = "terimajasa_appbma_by"
        cTerimajasa_appbma_by.HeaderText = "terimajasa_appbma_by"
        cTerimajasa_appbma_by.DataPropertyName = "terimajasa_appbma_by"
        cTerimajasa_appbma_by.Width = 100
        cTerimajasa_appbma_by.Visible = False
        cTerimajasa_appbma_by.ReadOnly = False

        cTerimajasa_appbma_dt.Name = "terimajasa_appbma_dt"
        cTerimajasa_appbma_dt.HeaderText = "terimajasa_appbma_dt"
        cTerimajasa_appbma_dt.DataPropertyName = "terimajasa_appbma_dt"
        cTerimajasa_appbma_dt.Width = 100
        cTerimajasa_appbma_dt.Visible = False
        cTerimajasa_appbma_dt.ReadOnly = False

        cTerimajasa_foreign.Name = "terimajasa_foreign"
        cTerimajasa_foreign.HeaderText = "terimajasa_foreign"
        cTerimajasa_foreign.DataPropertyName = "terimajasa_foreign"
        cTerimajasa_foreign.Width = 100
        cTerimajasa_foreign.Visible = False
        cTerimajasa_foreign.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cTerimajasa_foreignrate.Name = "terimajasa_foreignrate"
        cTerimajasa_foreignrate.HeaderText = "terimajasa_foreignrate"
        cTerimajasa_foreignrate.DataPropertyName = "terimajasa_foreignrate"
        cTerimajasa_foreignrate.Width = 100
        cTerimajasa_foreignrate.Visible = False
        cTerimajasa_foreignrate.ReadOnly = False

        cTerimajasa_idrreal.Name = "terimajasa_idrreal"
        cTerimajasa_idrreal.HeaderText = "terimajasa_idrreal"
        cTerimajasa_idrreal.DataPropertyName = "terimajasa_idrreal"
        cTerimajasa_idrreal.Width = 100
        cTerimajasa_idrreal.Visible = False
        cTerimajasa_idrreal.ReadOnly = False

        cTerimajasa_pph.Name = "terimajasa_pph"
        cTerimajasa_pph.HeaderText = "terimajasa_pph"
        cTerimajasa_pph.DataPropertyName = "terimajasa_pph"
        cTerimajasa_pph.Width = 100
        cTerimajasa_pph.Visible = False
        cTerimajasa_pph.ReadOnly = False

        cTerimajasa_ppn.Name = "terimajasa_ppn"
        cTerimajasa_ppn.HeaderText = "terimajasa_ppn"
        cTerimajasa_ppn.DataPropertyName = "terimajasa_ppn"
        cTerimajasa_ppn.Width = 100
        cTerimajasa_ppn.Visible = False
        cTerimajasa_ppn.ReadOnly = False

        cTerimajasa_disc.Name = "terimajasa_disc"
        cTerimajasa_disc.HeaderText = "terimajasa_disc"
        cTerimajasa_disc.DataPropertyName = "terimajasa_disc"
        cTerimajasa_disc.Width = 100
        cTerimajasa_disc.Visible = False
        cTerimajasa_disc.ReadOnly = False

        cTerimajasa_cetakbpj.Name = "terimajasa_cetakbpj"
        cTerimajasa_cetakbpj.HeaderText = "terimajasa_cetakbpj"
        cTerimajasa_cetakbpj.DataPropertyName = "terimajasa_cetakbpj"
        cTerimajasa_cetakbpj.Width = 100
        cTerimajasa_cetakbpj.Visible = False
        cTerimajasa_cetakbpj.ReadOnly = False

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
        {cTerimajasa_appuser, cTerimajasa_appspv, cTerimajasa_appbma, cTerimajasa_id, cTerimajasa_date, _
        cTerimajasa_type, cOrder_id, cBudget_id, _
        cRekanan_id, cEmployee_id_owner, cStrukturunit_id, cTerimajasa_qtyitem, _
        cTerimajasa_qtyrealization, cOrder_qty, cTerimajasa_status, _
        cTerimajasa_statusrealization, cTerimajasa_location, cTerimajasa_notes, cRekanan_name, cEmployee_name, _
        cTerimajasa_nosuratjalan, cChannel_id, cTerimajasa_isdisabled, cTerimajasa_createby, _
        cTerimajasa_createdt, cTerimajasa_modifiedby, cTerimajasa_modifieddt, _
        cTerimajasa_appuser_by, cTerimajasa_appuser_dt, cTerimajasa_appspv_by, _
        cTerimajasa_appspv_dt, cTerimajasa_appbma_by, cTerimajasa_appbma_dt, _
        cTerimajasa_foreign, cCurrency_id, cTerimajasa_foreignrate, cTerimajasa_idrreal, cTerimajasa_pph, _
        cTerimajasa_ppn, cTerimajasa_disc, cTerimajasa_cetakbpj})


        ' DgvTrnTerimajasa Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        If Me._USERTYPE = "bma" Then
            objDgv.MultiSelect = True
        Else
            objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            objDgv.MultiSelect = False
        End If

    End Function
    Private Function FormatDgvTrnTerimajasadetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnTerimajasadetil
        Dim cTerimajasa_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_desc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_qty_day_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_qty_usage As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_qty_usage_idle As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cKategoriitem_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBrand_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_createby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_createdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_modifiedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_modifieddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cType_pajak As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategori_pajak As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cTerimajasadetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_idrreal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_pphpersen As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_ppnpersen As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_disc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cButton_days As New System.Windows.Forms.DataGridViewButtonColumn

        'View Harga akhir
        Dim cTerimajasadetil_pphAmount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_pphAmountIDR As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_ppnAmount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_ppnAmountIDR As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_totalamount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_totalamountidr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn



        cTerimajasa_id.Name = "terimajasa_id"
        cTerimajasa_id.HeaderText = "terimajasa_id"
        cTerimajasa_id.DataPropertyName = "terimajasa_id"
        cTerimajasa_id.Width = 100
        cTerimajasa_id.Visible = False
        cTerimajasa_id.ReadOnly = False

        cTerimajasadetil_line.Name = "terimajasadetil_line"
        cTerimajasadetil_line.HeaderText = "Line"
        cTerimajasadetil_line.DataPropertyName = "terimajasadetil_line"
        cTerimajasadetil_line.Width = 40
        cTerimajasadetil_line.Visible = True
        cTerimajasadetil_line.ReadOnly = True
        cTerimajasadetil_line.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasadetil_desc.Name = "terimajasadetil_desc"
        cTerimajasadetil_desc.HeaderText = "Description"
        cTerimajasadetil_desc.DataPropertyName = "terimajasadetil_desc"
        cTerimajasadetil_desc.Width = 150
        cTerimajasadetil_desc.Visible = True
        cTerimajasadetil_desc.ReadOnly = False

        cTerimajasadetil_date.Name = "terimajasadetil_date"
        cTerimajasadetil_date.HeaderText = "Date"
        cTerimajasadetil_date.DataPropertyName = "terimajasadetil_date"
        cTerimajasadetil_date.Width = 100
        cTerimajasadetil_date.Visible = True
        cTerimajasadetil_date.ReadOnly = True
        cTerimajasadetil_date.DefaultCellStyle.Format = "dd/MM/yyyy"
        cTerimajasadetil_date.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasadetil_qty.Name = "terimajasadetil_qty"
        cTerimajasadetil_qty.HeaderText = "terimajasadetil_qty"
        cTerimajasadetil_qty.DataPropertyName = "terimajasadetil_qty"
        cTerimajasadetil_qty.Width = 100
        cTerimajasadetil_qty.Visible = False
        cTerimajasadetil_qty.ReadOnly = False

        cTerimajasadetil_qty_day_eps.Name = "terimajasadetil_qty_day_eps"
        cTerimajasadetil_qty_day_eps.HeaderText = "Days"
        cTerimajasadetil_qty_day_eps.DataPropertyName = "terimajasadetil_qty_day_eps"
        cTerimajasadetil_qty_day_eps.Width = 40
        cTerimajasadetil_qty_day_eps.Visible = True
        cTerimajasadetil_qty_day_eps.ReadOnly = True
        cTerimajasadetil_qty_day_eps.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasadetil_qty_usage.Name = "terimajasadetil_qty_usage"
        cTerimajasadetil_qty_usage.HeaderText = "Usage"
        cTerimajasadetil_qty_usage.DataPropertyName = "terimajasadetil_qty_usage"
        cTerimajasadetil_qty_usage.Width = 40
        cTerimajasadetil_qty_usage.Visible = True
        cTerimajasadetil_qty_usage.ReadOnly = True
        cTerimajasadetil_qty_usage.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasadetil_qty_usage_idle.Name = "terimajasadetil_qty_usage_idle"
        cTerimajasadetil_qty_usage_idle.HeaderText = "Usage Idle"
        cTerimajasadetil_qty_usage_idle.DataPropertyName = "terimajasadetil_qty_usage_idle"
        cTerimajasadetil_qty_usage_idle.Width = 40
        cTerimajasadetil_qty_usage_idle.Visible = True
        cTerimajasadetil_qty_usage_idle.ReadOnly = True
        cTerimajasadetil_qty_usage_idle.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasadetil_type.Name = "terimajasadetil_type"
        cTerimajasadetil_type.HeaderText = "terimajasadetil_type"
        cTerimajasadetil_type.DataPropertyName = "terimajasadetil_type"
        cTerimajasadetil_type.Width = 100
        cTerimajasadetil_type.Visible = False
        cTerimajasadetil_type.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Ref. ID "
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = True
        cOrder_id.DefaultCellStyle.BackColor = Color.Gainsboro

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Ref. Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 70
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True
        cOrderdetil_line.DefaultCellStyle.BackColor = Color.Gainsboro

        cItem_id.Name = "item_id"
        cItem_id.HeaderText = "Item"
        cItem_id.DataPropertyName = "item_id"
        cItem_id.Width = 150
        cItem_id.Visible = True
        cItem_id.ReadOnly = False
        cItem_id.DataSource = Me.tbl_MstItem
        cItem_id.ValueMember = "item_id"
        cItem_id.DisplayMember = "item_name"

        cKategoriitem_id.Name = "kategoriitem_id"
        cKategoriitem_id.HeaderText = "Category"
        cKategoriitem_id.DataPropertyName = "kategoriitem_id"
        cKategoriitem_id.Width = 130
        cKategoriitem_id.Visible = True
        cKategoriitem_id.ReadOnly = False
        cKategoriitem_id.DataSource = Me.tbl_MstItemCategory
        cKategoriitem_id.ValueMember = "category_id"
        cKategoriitem_id.DisplayMember = "category_name"

        cBrand_id.Name = "brand_id"
        cBrand_id.HeaderText = "Brand"
        cBrand_id.DataPropertyName = "brand_id"
        cBrand_id.Width = 130
        cBrand_id.Visible = True
        cBrand_id.ReadOnly = False
        cBrand_id.DataSource = Me.tbl_MstBrand
        cBrand_id.ValueMember = "merk_id"
        cBrand_id.DisplayMember = "merk_name"

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

        cTerimajasadetil_createby.Name = "terimajasadetil_createby"
        cTerimajasadetil_createby.HeaderText = "terimajasadetil_createby"
        cTerimajasadetil_createby.DataPropertyName = "terimajasadetil_createby"
        cTerimajasadetil_createby.Width = 100
        cTerimajasadetil_createby.Visible = False
        cTerimajasadetil_createby.ReadOnly = False

        cTerimajasadetil_createdt.Name = "terimajasadetil_createdt"
        cTerimajasadetil_createdt.HeaderText = "terimajasadetil_createdt"
        cTerimajasadetil_createdt.DataPropertyName = "terimajasadetil_createdt"
        cTerimajasadetil_createdt.Width = 100
        cTerimajasadetil_createdt.Visible = False
        cTerimajasadetil_createdt.ReadOnly = False

        cTerimajasadetil_modifiedby.Name = "terimajasadetil_modifiedby"
        cTerimajasadetil_modifiedby.HeaderText = "terimajasadetil_modifiedby"
        cTerimajasadetil_modifiedby.DataPropertyName = "terimajasadetil_modifiedby"
        cTerimajasadetil_modifiedby.Width = 100
        cTerimajasadetil_modifiedby.Visible = False
        cTerimajasadetil_modifiedby.ReadOnly = False

        cTerimajasadetil_modifieddt.Name = "terimajasadetil_modifieddt"
        cTerimajasadetil_modifieddt.HeaderText = "terimajasadetil_modifieddt"
        cTerimajasadetil_modifieddt.DataPropertyName = "terimajasadetil_modifieddt"
        cTerimajasadetil_modifieddt.Width = 100
        cTerimajasadetil_modifieddt.Visible = False
        cTerimajasadetil_modifieddt.ReadOnly = False

        cType_pajak.Name = "type_pajak"
        cType_pajak.HeaderText = "Type Tax"
        cType_pajak.DataPropertyName = "type_pajak"
        cType_pajak.Width = 100
        cType_pajak.Visible = False
        cType_pajak.ReadOnly = True
        cType_pajak.DefaultCellStyle.BackColor = Color.Gainsboro

        cKategori_pajak.Name = "kategori_pajak"
        cKategori_pajak.HeaderText = "Category Tax"
        cKategori_pajak.DataPropertyName = "kategori_pajak"
        cKategori_pajak.Width = 100
        cKategori_pajak.Visible = False
        cKategori_pajak.ReadOnly = False
        cKategori_pajak.DefaultCellStyle.BackColor = Color.Gainsboro


        cTerimajasadetil_foreign.Name = "terimajasadetil_foreign"
        cTerimajasadetil_foreign.HeaderText = "Amount"
        cTerimajasadetil_foreign.DataPropertyName = "terimajasadetil_foreign"
        cTerimajasadetil_foreign.Width = 120
        cTerimajasadetil_foreign.Visible = True
        cTerimajasadetil_foreign.ReadOnly = True
        cTerimajasadetil_foreign.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        cTerimajasadetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 70
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = True
        cCurrency_id.DataSource = Me.tbl_MstCurrencyDetil
        cCurrency_id.ValueMember = "currency_id"
        cCurrency_id.DisplayMember = "currency_shortname"
        cCurrency_id.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasadetil_foreignrate.Name = "terimajasadetil_foreignrate"
        cTerimajasadetil_foreignrate.HeaderText = "Rate"
        cTerimajasadetil_foreignrate.DataPropertyName = "terimajasadetil_foreignrate"
        cTerimajasadetil_foreignrate.Width = 100
        cTerimajasadetil_foreignrate.Visible = True
        cTerimajasadetil_foreignrate.ReadOnly = True
        cTerimajasadetil_foreignrate.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_foreignrate.DefaultCellStyle.Format = "#,##0.00"
        cTerimajasadetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimajasadetil_idrreal.Name = "terimajasadetil_idrreal"
        cTerimajasadetil_idrreal.HeaderText = "Amount (IDR)"
        cTerimajasadetil_idrreal.DataPropertyName = "terimajasadetil_idrreal"
        cTerimajasadetil_idrreal.Width = 120
        cTerimajasadetil_idrreal.Visible = True
        cTerimajasadetil_idrreal.ReadOnly = True
        cTerimajasadetil_idrreal.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_idrreal.DefaultCellStyle.Format = "#,##0"
        cTerimajasadetil_idrreal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimajasadetil_pphpersen.Name = "terimajasadetil_pphpersen"
        cTerimajasadetil_pphpersen.HeaderText = "Pph %"
        cTerimajasadetil_pphpersen.DataPropertyName = "terimajasadetil_pphpersen"
        cTerimajasadetil_pphpersen.Width = 100
        cTerimajasadetil_pphpersen.Visible = True
        cTerimajasadetil_pphpersen.ReadOnly = True
        cTerimajasadetil_pphpersen.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_pphpersen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimajasadetil_ppnpersen.Name = "terimajasadetil_ppnpersen"
        cTerimajasadetil_ppnpersen.HeaderText = "PPN %"
        cTerimajasadetil_ppnpersen.DataPropertyName = "terimajasadetil_ppnpersen"
        cTerimajasadetil_ppnpersen.Width = 100
        cTerimajasadetil_ppnpersen.Visible = True
        cTerimajasadetil_ppnpersen.ReadOnly = True
        cTerimajasadetil_ppnpersen.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_ppnpersen.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimajasadetil_disc.Name = "terimajasadetil_disc"
        cTerimajasadetil_disc.HeaderText = "Disc"
        cTerimajasadetil_disc.DataPropertyName = "terimajasadetil_disc"
        cTerimajasadetil_disc.Width = 120
        cTerimajasadetil_disc.Visible = True
        cTerimajasadetil_disc.ReadOnly = True
        cTerimajasadetil_disc.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_disc.DefaultCellStyle.Format = "#,##0"
        cTerimajasadetil_disc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cButton_days.Name = "select_days"
        cButton_days.HeaderText = ""
        cButton_days.Text = "..."
        cButton_days.UseColumnTextForButtonValue = True
        cButton_days.CellTemplate.Style.BackColor = Color.LightGray
        cButton_days.Width = 30
        cButton_days.DividerWidth = 3
        cButton_days.Visible = True
        cButton_days.ReadOnly = False

        cTerimajasadetil_pphAmount.Name = "terimajasadetil_pphforeign"
        cTerimajasadetil_pphAmount.HeaderText = "Pph Amount"
        cTerimajasadetil_pphAmount.DataPropertyName = "terimajasadetil_pphforeign"
        cTerimajasadetil_pphAmount.Width = 120
        cTerimajasadetil_pphAmount.Visible = True
        cTerimajasadetil_pphAmount.ReadOnly = True
        cTerimajasadetil_pphAmount.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_pphAmount.DefaultCellStyle.Format = "#,##0.00"
        cTerimajasadetil_pphAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimajasadetil_pphAmountIDR.Name = "terimajasadetil_pphidrreal"
        cTerimajasadetil_pphAmountIDR.HeaderText = "Pph Amount (IDR)"
        cTerimajasadetil_pphAmountIDR.DataPropertyName = "terimajasadetil_pphidrreal"
        cTerimajasadetil_pphAmountIDR.Width = 120
        cTerimajasadetil_pphAmountIDR.Visible = True
        cTerimajasadetil_pphAmountIDR.ReadOnly = True
        cTerimajasadetil_pphAmountIDR.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_pphAmountIDR.DefaultCellStyle.Format = "#,##0"
        cTerimajasadetil_pphAmountIDR.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimajasadetil_ppnAmount.Name = "terimajasadetil_ppnforeign"
        cTerimajasadetil_ppnAmount.HeaderText = "PPN Amount"
        cTerimajasadetil_ppnAmount.DataPropertyName = "terimajasadetil_ppnforeign"
        cTerimajasadetil_ppnAmount.Width = 120
        cTerimajasadetil_ppnAmount.Visible = True
        cTerimajasadetil_ppnAmount.ReadOnly = True
        cTerimajasadetil_ppnAmount.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_ppnAmount.DefaultCellStyle.Format = "#,##0.00"
        cTerimajasadetil_ppnAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimajasadetil_ppnAmountIDR.Name = "terimajasadetil_ppnidrreal"
        cTerimajasadetil_ppnAmountIDR.HeaderText = "PPN Amount(IDR)"
        cTerimajasadetil_ppnAmountIDR.DataPropertyName = "terimajasadetil_ppnidrreal"
        cTerimajasadetil_ppnAmountIDR.Width = 120
        cTerimajasadetil_ppnAmountIDR.Visible = True
        cTerimajasadetil_ppnAmountIDR.ReadOnly = True
        cTerimajasadetil_ppnAmountIDR.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_ppnAmountIDR.DefaultCellStyle.Format = "#,##0"
        cTerimajasadetil_ppnAmountIDR.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimajasadetil_totalamount.Name = "terimajasadetil_totalforeign"
        cTerimajasadetil_totalamount.HeaderText = "Total Amount"
        cTerimajasadetil_totalamount.DataPropertyName = "terimajasadetil_totalforeign"
        cTerimajasadetil_totalamount.Width = 120
        cTerimajasadetil_totalamount.Visible = True
        cTerimajasadetil_totalamount.ReadOnly = True
        cTerimajasadetil_totalamount.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_totalamount.DefaultCellStyle.Format = "#,##0.00"
        cTerimajasadetil_totalamount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cTerimajasadetil_totalamountidr.Name = "terimajasadetil_totalidrreal"
        cTerimajasadetil_totalamountidr.HeaderText = "Total Amount(IDR)"
        cTerimajasadetil_totalamountidr.DataPropertyName = "terimajasadetil_totalidrreal"
        cTerimajasadetil_totalamountidr.Width = 120
        cTerimajasadetil_totalamountidr.Visible = True
        cTerimajasadetil_totalamountidr.ReadOnly = True
        cTerimajasadetil_totalamountidr.DefaultCellStyle.BackColor = Color.Gainsboro
        cTerimajasadetil_totalamountidr.DefaultCellStyle.Format = "#,##0"
        cTerimajasadetil_totalamountidr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimajasa_id, cTerimajasadetil_line, cItem_id, cButton_days, cTerimajasadetil_qty_day_eps, _
        cTerimajasadetil_qty_usage, cTerimajasadetil_qty_usage_idle, cTerimajasadetil_desc, cKategoriitem_id, cBrand_id, _
         cTerimajasadetil_date, _
        cTerimajasadetil_qty, _
        cTerimajasadetil_type, cOrder_id, cOrderdetil_line, _
         cBudget_id, cBudgetdetil_id, cAcc_id, cChannel_id, cTerimajasadetil_createby, _
        cTerimajasadetil_createdt, cTerimajasadetil_modifiedby, cTerimajasadetil_modifieddt, _
       cType_pajak, cKategori_pajak, cTerimajasadetil_foreign, cCurrency_id, cTerimajasadetil_foreignrate, _
        cTerimajasadetil_idrreal, cTerimajasadetil_pphpersen, cTerimajasadetil_ppnpersen, _
        cTerimajasadetil_disc, _
        cTerimajasadetil_pphAmount, cTerimajasadetil_pphAmountIDR, cTerimajasadetil_ppnAmount, _
         cTerimajasadetil_ppnAmountIDR, cTerimajasadetil_totalamount, cTerimajasadetil_totalamountidr})

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = True
        objDgv.AutoGenerateColumns = False
    End Function
    Private Function FormatDgvTrnTerimajasaused(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_lineday As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_detilused_note As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasaused_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_qty_idle As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_usagestart As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_usgaeend As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_remark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cTerimajasa_id.Name = "terimajasa_id"
        cTerimajasa_id.HeaderText = "terimajasa_id"
        cTerimajasa_id.DataPropertyName = "terimajasa_id"
        cTerimajasa_id.Width = 100
        cTerimajasa_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_id.Visible = False
        cTerimajasa_id.ReadOnly = False

        cTerimajasa_line.Name = "terimajasa_line"
        cTerimajasa_line.HeaderText = "terimajasa_line"
        cTerimajasa_line.DataPropertyName = "terimajasa_line"
        cTerimajasa_line.Width = 100
        cTerimajasa_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_line.Visible = False
        cTerimajasa_line.ReadOnly = False

        cTerimajasa_lineday.Name = "terimajasa_lineday"
        cTerimajasa_lineday.HeaderText = "terimajasa_lineday"
        cTerimajasa_lineday.DataPropertyName = "terimajasa_lineday"
        cTerimajasa_lineday.Width = 100
        cTerimajasa_lineday.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_lineday.Visible = False
        cTerimajasa_lineday.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order_id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = False

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "orderdetil_line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = False
        cOrderdetil_line.ReadOnly = False

        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "orderdetiluse_line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 100
        cOrderdetiluse_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetiluse_line.Visible = False
        cOrderdetiluse_line.ReadOnly = False

        cTerimajasa_date.Name = "terimajasa_date"
        cTerimajasa_date.HeaderText = "Date"
        cTerimajasa_date.DataPropertyName = "terimajasa_date"
        cTerimajasa_date.Width = 100
        cTerimajasa_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_date.Visible = True
        cTerimajasa_date.ReadOnly = False

        cTerimajasa_detilused_note.Name = "terimajasa_detilused_note"
        cTerimajasa_detilused_note.HeaderText = "terimajasa_detilused_note"
        cTerimajasa_detilused_note.DataPropertyName = "terimajasa_detilused_note"
        cTerimajasa_detilused_note.Width = 100
        cTerimajasa_detilused_note.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_detilused_note.Visible = False
        cTerimajasa_detilused_note.ReadOnly = False

        cTerimajasa_check.Name = "terimajasa_check"
        cTerimajasa_check.HeaderText = "Select"
        cTerimajasa_check.DataPropertyName = "terimajasa_check"
        cTerimajasa_check.Width = 40
        cTerimajasa_check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimajasa_check.Visible = True
        cTerimajasa_check.ReadOnly = False

        cTerimajasaused_qty.Name = "terimajasaused_qty"
        cTerimajasaused_qty.HeaderText = "Qty"
        cTerimajasaused_qty.DataPropertyName = "terimajasaused_qty"
        cTerimajasaused_qty.Width = 100
        cTerimajasaused_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_qty.Visible = True
        cTerimajasaused_qty.ReadOnly = False

        cTerimajasaused_qty_idle.Name = "terimajasaused_qty_idle"
        cTerimajasaused_qty_idle.HeaderText = "Qty Idle"
        cTerimajasaused_qty_idle.DataPropertyName = "terimajasaused_qty_idle"
        cTerimajasaused_qty_idle.Width = 100
        cTerimajasaused_qty_idle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_qty_idle.Visible = True
        cTerimajasaused_qty_idle.ReadOnly = False

        cTerimajasaused_usagestart.Name = "terimajasaused_usagestart"
        cTerimajasaused_usagestart.HeaderText = "Usage Start"
        cTerimajasaused_usagestart.DataPropertyName = "terimajasaused_usagestart"
        cTerimajasaused_usagestart.Width = 100
        cTerimajasaused_usagestart.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usagestart.Visible = True
        cTerimajasaused_usagestart.ReadOnly = False

        cTerimajasaused_usgaeend.Name = "terimajasaused_usgaeend"
        cTerimajasaused_usgaeend.HeaderText = "Usage End"
        cTerimajasaused_usgaeend.DataPropertyName = "terimajasaused_usgaeend"
        cTerimajasaused_usgaeend.Width = 100
        cTerimajasaused_usgaeend.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usgaeend.Visible = True
        cTerimajasaused_usgaeend.ReadOnly = False

        cTerimajasaused_status.Name = "terimajasaused_status"
        cTerimajasaused_status.HeaderText = "Status"
        cTerimajasaused_status.DataPropertyName = "terimajasaused_status"
        cTerimajasaused_status.Width = 100
        cTerimajasaused_status.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_status.Visible = True
        cTerimajasaused_status.ReadOnly = False

        cTerimajasaused_remark.Name = "terimajasaused_remark"
        cTerimajasaused_remark.HeaderText = "Remark"
        cTerimajasaused_remark.DataPropertyName = "terimajasaused_remark"
        cTerimajasaused_remark.Width = 100
        cTerimajasaused_remark.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_remark.Visible = True
        cTerimajasaused_remark.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimajasa_check, cTerimajasa_date, cTerimajasaused_qty, cTerimajasaused_qty_idle, _
        cTerimajasaused_usagestart, cTerimajasaused_usgaeend, _
        cTerimajasaused_status, cTerimajasaused_remark, cChannel_id, cTerimajasa_id, _
        cTerimajasa_line, cTerimajasa_lineday, _
        cOrder_id, cOrderdetil_line, cOrderdetiluse_line, cTerimajasa_detilused_note})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True
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
    Private Function FormatDgvTrnOrderdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        'formating DgvTrnOrderdetil
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim corderdetil_rowtotalforeign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_discount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim corderdetil_rowtotalforeign_incldisc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_pphpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_ppnpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 30
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True
        cOrderdetil_line.Frozen = True

        cRequestdetil_line.Name = "requestdetil_line"
        cRequestdetil_line.HeaderText = "ReqLine"
        cRequestdetil_line.DataPropertyName = "requestdetil_line"
        cRequestdetil_line.Width = 30
        cRequestdetil_line.Visible = True
        cRequestdetil_line.ReadOnly = True
        cRequestdetil_line.Frozen = True

        cItem_name.Name = "item_name"
        cItem_name.HeaderText = "Item"
        cItem_name.DataPropertyName = "item_name"
        cItem_name.Width = 130
        cItem_name.Visible = True
        cItem_name.ReadOnly = True
        cItem_name.Frozen = True

        cUnit_name.Name = "unit_name"
        cUnit_name.HeaderText = "Unit"
        cUnit_name.DataPropertyName = "unit_name"
        cUnit_name.Width = 50
        cUnit_name.Visible = True
        cUnit_name.ReadOnly = True


        cOrderdetil_descr.Name = "orderdetil_descr"
        cOrderdetil_descr.HeaderText = "Description"
        cOrderdetil_descr.DataPropertyName = "orderdetil_descr"
        cOrderdetil_descr.Width = 150
        cOrderdetil_descr.Visible = True
        cOrderdetil_descr.ReadOnly = True

        cOrderdetil_qty.Name = "orderdetil_qty"
        cOrderdetil_qty.HeaderText = "Qty"
        cOrderdetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_qty.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_qty.Width = 35
        cOrderdetil_qty.Visible = True
        cOrderdetil_qty.ReadOnly = True

        cOrderdetil_days.Name = "orderdetil_days"
        cOrderdetil_days.HeaderText = "Days"
        cOrderdetil_days.DataPropertyName = "orderdetil_days"
        cOrderdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_days.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_days.Width = 35
        cOrderdetil_days.Visible = True
        cOrderdetil_days.ReadOnly = True

        cOrderdetil_foreign.Name = "amount"
        cOrderdetil_foreign.HeaderText = "Amount"
        cOrderdetil_foreign.DataPropertyName = "amount"
        cOrderdetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_foreign.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_foreign.Width = 110
        cOrderdetil_foreign.Visible = True
        cOrderdetil_foreign.ReadOnly = True

        corderdetil_rowtotalforeign.Name = "subtotal"
        corderdetil_rowtotalforeign.HeaderText = "SubTotal"
        corderdetil_rowtotalforeign.DataPropertyName = "subtotal"
        corderdetil_rowtotalforeign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        corderdetil_rowtotalforeign.DefaultCellStyle.Format = "#,##0.00"
        corderdetil_rowtotalforeign.Width = 110
        corderdetil_rowtotalforeign.Visible = True
        corderdetil_rowtotalforeign.ReadOnly = True

        cOrderdetil_discount.Name = "orderdetil_discount"
        cOrderdetil_discount.HeaderText = "Disc."
        cOrderdetil_discount.DataPropertyName = "orderdetil_discount"
        cOrderdetil_discount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_discount.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_discount.Width = 85
        cOrderdetil_discount.Visible = True
        cOrderdetil_discount.ReadOnly = True

        corderdetil_rowtotalforeign_incldisc.Name = "subtotal_incldisc"
        corderdetil_rowtotalforeign_incldisc.HeaderText = "SubTotal InclDisc."
        corderdetil_rowtotalforeign_incldisc.DataPropertyName = "subtotal_incldisc"
        corderdetil_rowtotalforeign_incldisc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        corderdetil_rowtotalforeign_incldisc.DefaultCellStyle.Format = "#,##0.00"
        corderdetil_rowtotalforeign_incldisc.Width = 120
        corderdetil_rowtotalforeign_incldisc.Visible = True
        corderdetil_rowtotalforeign_incldisc.ReadOnly = True

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "OrderID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 125
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = False

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 130
        cBudget_name.ReadOnly = True
        cBudget_name.Visible = True

        cBudgetdetil_name.Name = "budgetdetil_name"
        cBudgetdetil_name.HeaderText = "Budget Detil Name"
        cBudgetdetil_name.DataPropertyName = "budgetdetil_name"
        cBudgetdetil_name.Width = 130
        cBudgetdetil_name.Visible = True
        cBudgetdetil_name.ReadOnly = True

        cOrderdetil_pphpercent.Name = "pph_percent"
        cOrderdetil_pphpercent.HeaderText = "PPH(%)"
        cOrderdetil_pphpercent.DataPropertyName = "pph_percent"
        cOrderdetil_pphpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_pphpercent.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_pphpercent.Width = 50
        cOrderdetil_pphpercent.Visible = True
        cOrderdetil_pphpercent.ReadOnly = True

        cOrderdetil_pph.Name = "pph_amount"
        cOrderdetil_pph.HeaderText = "PPH Amount"
        cOrderdetil_pph.DataPropertyName = "pph_amount"
        cOrderdetil_pph.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_pph.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_pph.Width = 100
        cOrderdetil_pph.Visible = True
        cOrderdetil_pph.ReadOnly = True

        cOrderdetil_ppnpercent.Name = "ppn_percent"
        cOrderdetil_ppnpercent.HeaderText = "PPN(%)"
        cOrderdetil_ppnpercent.DataPropertyName = "ppn_percent"
        cOrderdetil_ppnpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_ppnpercent.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_ppnpercent.Width = 50
        cOrderdetil_ppnpercent.Visible = True
        cOrderdetil_ppnpercent.ReadOnly = False

        cOrderdetil_ppn.Name = "ppn_amount"
        cOrderdetil_ppn.HeaderText = "PPN Amount"
        cOrderdetil_ppn.DataPropertyName = "ppn_amount"
        cOrderdetil_ppn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cOrderdetil_ppn.DefaultCellStyle.Format = "#,##0.00"
        cOrderdetil_ppn.DefaultCellStyle.BackColor = Color.LightGray
        cOrderdetil_ppn.Width = 100
        cOrderdetil_ppn.Visible = True
        cOrderdetil_ppn.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Dock = DockStyle.Fill
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { _
            cOrderdetil_line, _
            cRequestdetil_line, _
            cItem_name, _
            cOrderdetil_descr, _
            cOrderdetil_qty, _
            cUnit_name, _
            cOrderdetil_days, _
            cOrderdetil_foreign, _
            corderdetil_rowtotalforeign, _
            cOrderdetil_discount, _
            corderdetil_rowtotalforeign_incldisc, _
            cOrderdetil_pphpercent, _
            cOrderdetil_pph, _
            cOrderdetil_ppnpercent, _
            cOrderdetil_ppn, _
            cBudget_name, _
            cBudgetdetil_name, _
            cOrder_id})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToOrderColumns = False
        objDgv.AllowUserToDeleteRows = False
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
        Me.DgvTrnTerimajasa.Dock = DockStyle.Fill

        Me.FormatDgvTrnTerimajasa(Me.DgvTrnTerimajasa)
        Me.FormatDgvTrnTerimajasadetil(Me.DgvTrnTerimajasadetil)
        Me.FormatDgvTrnTerimajasaused(Me.dgvTerimaJasaUsed)
        Me.FormatDgvTrnJurnalreference(Me.DgvTrnJurnalreference)
        Me.FormatDgvTrnJurnalresponse(Me.DgvTrnJurnalresponse)
        Me.FormatDgvTrnOrderdetil(Me.dgvTrnOrder)


    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Terimajasa_id.DataBindings.Clear()
        Me.obj_Terimajasa_date.DataBindings.Clear()
        Me.obj_Terimajasa_type.DataBindings.Clear()
        Me.obj_Order_id.DataBindings.Clear()
        Me.obj_Budget_id.DataBindings.Clear()
        Me.obj_Rekanan_id.DataBindings.Clear()
        Me.obj_Employee_id_owner.DataBindings.Clear()
        Me.obj_Strukturunit_id.DataBindings.Clear()
        Me.obj_Terimajasa_qtyitem.DataBindings.Clear()
        Me.obj_Terimajasa_qtyrealization.DataBindings.Clear()
        Me.obj_Order_qty.DataBindings.Clear()
        Me.obj_Terimajasa_status.DataBindings.Clear()
        Me.obj_Terimajasa_statusrealization.DataBindings.Clear()
        Me.obj_Terimajasa_location.DataBindings.Clear()
        Me.obj_Terimajasa_notes.DataBindings.Clear()
        Me.obj_Terimajasa_nosuratjalan.DataBindings.Clear()
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Terimajasa_isdisabled.DataBindings.Clear()
        Me.obj_Terimajasa_createby.DataBindings.Clear()
        Me.obj_Terimajasa_createdt.DataBindings.Clear()
        Me.obj_Terimajasa_modifiedby.DataBindings.Clear()
        Me.obj_Terimajasa_modifieddt.DataBindings.Clear()
        Me.obj_Terimajasa_appuser.DataBindings.Clear()
        Me.obj_Terimajasa_appuser_by.DataBindings.Clear()
        Me.obj_Terimajasa_appuser_dt.DataBindings.Clear()
        Me.obj_Terimajasa_appspv.DataBindings.Clear()
        Me.obj_Terimajasa_appspv_by.DataBindings.Clear()
        Me.obj_Terimajasa_appspv_dt.DataBindings.Clear()
        Me.obj_Terimajasa_appbma.DataBindings.Clear()
        Me.obj_Terimajasa_appbma_by.DataBindings.Clear()
        Me.obj_Terimajasa_appbma_dt.DataBindings.Clear()
        Me.obj_Terimajasa_foreign.DataBindings.Clear()
        Me.obj_Currency_id.DataBindings.Clear()
        Me.obj_Terimajasa_foreignrate.DataBindings.Clear()
        Me.obj_Terimajasa_idrreal.DataBindings.Clear()
        Me.obj_Terimajasa_pph.DataBindings.Clear()
        Me.obj_Terimajasa_ppn.DataBindings.Clear()
        Me.obj_Terimajasa_disc.DataBindings.Clear()
        Me.obj_Terimajasa_cetakbpj.DataBindings.Clear()


        Return True
    End Function
    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Terimajasa_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_id"))
        Me.obj_Terimajasa_date.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_date"))
        Me.obj_Terimajasa_type.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_type"))
        Me.obj_Order_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "order_id"))
        Me.obj_Budget_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimajasa_Temp, "budget_id"))
        Me.obj_Rekanan_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimajasa_Temp, "rekanan_id"))
        Me.obj_Employee_id_owner.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimajasa_Temp, "employee_id_owner"))
        Me.obj_Strukturunit_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "strukturunit_id"))
        Me.obj_Terimajasa_qtyitem.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_qtyitem"))
        Me.obj_Terimajasa_qtyrealization.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_qtyrealization"))
        Me.obj_Order_qty.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "order_qty"))
        Me.obj_Terimajasa_status.DataBindings.Add(New Binding("SelectedItem", Me.tbl_TrnTerimajasa_Temp, "terimajasa_status"))
        Me.obj_Terimajasa_statusrealization.DataBindings.Add(New Binding("SelectedItem", Me.tbl_TrnTerimajasa_Temp, "terimajasa_statusrealization"))
        Me.obj_Terimajasa_location.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_location"))
        Me.obj_Terimajasa_notes.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_notes"))
        Me.obj_Terimajasa_nosuratjalan.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_nosuratjalan"))
        Me.obj_Channel_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "channel_id"))
        Me.obj_Terimajasa_isdisabled.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimajasa_Temp, "terimajasa_isdisabled"))
        Me.obj_Terimajasa_createby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_createby"))
        Me.obj_Terimajasa_createdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_createdt"))
        Me.obj_Terimajasa_modifiedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_modifiedby"))
        Me.obj_Terimajasa_modifieddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_modifieddt"))
        Me.obj_Terimajasa_appuser.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimajasa_Temp, "terimajasa_appuser"))
        Me.obj_Terimajasa_appuser_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_appuser_by"))
        Me.obj_Terimajasa_appuser_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_appuser_dt"))
        Me.obj_Terimajasa_appspv.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimajasa_Temp, "terimajasa_appspv"))
        Me.obj_Terimajasa_appspv_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_appspv_by"))
        Me.obj_Terimajasa_appspv_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_appspv_dt"))
        Me.obj_Terimajasa_appbma.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimajasa_Temp, "terimajasa_appbma"))
        Me.obj_Terimajasa_appbma_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_appbma_by"))
        Me.obj_Terimajasa_appbma_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_appbma_dt"))
        Me.obj_Terimajasa_foreign.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_foreign", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Currency_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimajasa_Temp, "currency_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimajasa_foreignrate.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_foreignrate", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimajasa_idrreal.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_idrreal", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimajasa_pph.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_pph", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimajasa_ppn.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_ppn", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimajasa_disc.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_disc", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Terimajasa_cetakbpj.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimajasa_Temp, "terimajasa_cetakbpj"))

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

    Private Function uiTrnTerimaJasa_Rental_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnTerimajasa_Temp
        Me.tbl_TrnTerimajasa_Temp.Clear()
        Me.tbl_TrnTerimajasa_Temp.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnTerimajasa_Temp.Columns("strukturunit_id").DefaultValue = Me._STRUKTUR_UNIT
        Me.tbl_TrnTerimajasa_Temp.Columns("terimajasa_type").DefaultValue = "RENTAL"
        Me.tbl_TrnTerimajasa_Temp.Columns("terimajasa_status").DefaultValue = "-- Pilih --"
        Me.tbl_TrnTerimajasa_Temp.Columns("terimajasa_statusrealization").DefaultValue = "-- Pilih --"
        Me.tbl_TrnTerimajasa_Temp.Columns("terimajasa_date").DefaultValue = Now.Date
        Me.tbl_TrnTerimajasa_Temp.Columns("terimajasa_location").DefaultValue = ""


        ' TODO: Set Default Value for tbl_TrnTerimajasadetil
        Me.tbl_TrnTerimajasadetil.Clear()
        Me.tbl_TrnTerimajasadetil = clsDataset.CreateTblTrnTerimajasadetil()
        Me.tbl_TrnTerimajasadetil.Columns("terimajasa_id").DefaultValue = 0
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").AutoIncrement = True
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").AutoIncrementStep = 10
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_date").DefaultValue = Now.Date
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_type").DefaultValue = "RENTAL"
        Me.tbl_TrnTerimajasadetil.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.DgvTrnTerimajasadetil.DataSource = Me.tbl_TrnTerimajasadetil

        ' TODO: Set Default Value for tbl_TrnTerimajasaused
        Me.tbl_TrnTerimajasaUsed.Clear()
        Me.tbl_TrnTerimajasaUsed = clsDataset.CreateTblTrnTerimajasaused()
        Me.tbl_TrnTerimajasaUsed.Columns("terimajasa_id").DefaultValue = 0
        ' ''Me.tbl_TrnTerimajasaUsed.Columns("terimajasadetil_line").DefaultValue = DBNull.Value
        ' ''Me.tbl_TrnTerimajasaUsed.Columns("terimajasadetil_line").AutoIncrement = True
        ' ''Me.tbl_TrnTerimajasaUsed.Columns("terimajasadetil_line").AutoIncrementSeed = 10
        ' ''Me.tbl_TrnTerimajasaUsed.Columns("terimajasadetil_line").AutoIncrementStep = 10
        ' ''Me.tbl_TrnTerimajasaUsed.Columns("terimajasadetil_date").DefaultValue = Now.Date
        ' ''Me.tbl_TrnTerimajasaUsed.Columns("terimajasadetil_type").DefaultValue = "RENTAL"
        Me.tbl_TrnTerimajasaUsed.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.dgvTerimaJasaUsed.DataSource = Me.tbl_TrnTerimajasaUsed


        ' TODO: Set Default Value for tbl_TrnJurnaldetil_kredit
        Me.tbl_TrnJurnaldetil_kredit.Clear()
        Me.tbl_TrnJurnaldetil_kredit = clsDataset.CreateTblTrnJurnaldetil()
        ' ''Me.tbl_TrnJurnaldetil.Columns("jurnal_id").DefaultValue = jurnal_id
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_kredit.Columns("acc_id").DefaultValue = ""
        Me.DgvTrnJurnaldetil.DataSource = Me.tbl_TrnJurnaldetil_kredit


        ' TODO: Set Default Value for tbl_TrnJurnaldetil_debet
        Me.tbl_TrnJurnaldetil_debet.Clear()
        Me.tbl_TrnJurnaldetil_debet = clsDataset.CreateTblTrnJurnaldetil()
        ' ''Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnal_id").DefaultValue = jurnal_id
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_debet.Columns("acc_id").DefaultValue = ""
        Me.DgvTrnJurnaldetil_Pembayaran.DataSource = Me.tbl_TrnJurnaldetil_debet

        Me.tbl_TrnOrderdetil.Clear()
        Me.tbl_TrnOrderdetil = clsDataset.CreateTblTrnOrderdetil()
        Me.tbl_TrnOrderdetil.Columns("order_id").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrement = True
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementStep = 10
        Me.tbl_TrnOrderdetil.Columns("orderdetil_type").DefaultValue = "Item"



        Me.BindingContext(Me.tbl_TrnTerimajasa_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnTerimajasa_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function uiTrnTerimaJasa_Rental_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()
        criteria = " AND terimajasa_isdisabled = 0 "

        If chk_Strukturunit_id_pemilik_search.Checked = True Then
            criteria = criteria & " AND strukturunit_id = " & obj_Strukturunit_id_pemilik_search.SelectedValue
        End If

        If chk_Rekanan_id_search.Checked = True Then
            criteria = criteria & " AND rekanan_id = " & CStr(obj_Rekanan_id_search.Text)
        End If

        If chk_User_search.Checked = True Then
            If Me._USERTYPE = "bma" Then
                If Me.cmb_appuser.SelectedValue = 1 Then
                    criteria &= " AND terimajasa_appuser = 1"
                ElseIf Me.cmb_appuser.SelectedValue = 2 Then
                    criteria &= " AND terimajasa_appspv = 1"
                ElseIf Me.cmb_appuser.SelectedValue = 3 Then
                    criteria &= " AND terimajasa_appbma = 1"
                End If
            ElseIf Me._USERTYPE = "spv" Then
                If Me.cmb_appuser.SelectedValue = 0 Then
                    criteria &= " AND terimajasa_appspv = 1"
                Else
                    criteria &= " AND terimajasa_appspv = 0"
                End If
            Else
                If Me.cmb_appuser.SelectedValue = 0 Then
                    criteria &= " AND terimajasa_appuser = 1"
                Else
                    criteria &= " AND terimajasa_appuser = 0"
                End If
            End If
        End If

        If chk_orderID_search.Checked = True Then
            criteria &= criteria & String.Format(" AND order_id = '{0}'", Me.obj_orderID_search.Text)
        End If

        If chk_RvID_search.Checked = True Then
            criteria &= criteria & String.Format(" AND terimajasa_id = '{0}'", Me.obj_RvID_search.Text)
        End If

        criteria &= " AND terimajasa_type = 'RENTAL'"

        Me.tbl_TrnTerimajasa.Clear()
        Try
            Dim odatafiller As clsDataFiller = New clsDataFiller(Me.DSNFrm)

            odatafiller.DataFillAsset(Me.DSNFrm, Me.tbl_TrnTerimajasa, "as_TrnTerimajasa_Select", criteria, Me._CHANNEL, Me.obj_top.Value)
            If Me.tbl_TrnTerimajasa.Rows.Count > 0 Then
                If Me._USERTYPE = "user" Then
                    Me.btnApproved.Visible = True
                    Me.btnUnApproved.Visible = True
                    If CType(clsUtil.IsDbNull(DgvTrnTerimajasa.CurrentRow.Cells("terimajasa_appuser").Value, 0), Integer) = 1 Then
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

    Private Function uiTrnTerimaJasa_Rental_Save() As Boolean
        'save data
        Dim tbl_TrnTerimajasa_Temp_Changes As DataTable
        Dim tbl_TrnTerimajasadetil_Changes As DataTable
        Dim tbl_TrnTerimajasaused_Changes As DataTable
        Dim success As Boolean
        Dim terimajasa_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(terimajasa_id)

        Me.BindingContext(Me.tbl_TrnTerimajasa_Temp).EndCurrentEdit()
        tbl_TrnTerimajasa_Temp_Changes = Me.tbl_TrnTerimajasa_Temp.GetChanges()

        Me.DgvTrnTerimajasadetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnTerimajasadetil).EndCurrentEdit()
        tbl_TrnTerimajasadetil_Changes = Me.tbl_TrnTerimajasadetil.GetChanges()

        Me.dgvTerimaJasaUsed.EndEdit()
        Me.BindingContext(Me.tbl_TrnTerimajasaUsed).EndCurrentEdit()
        tbl_TrnTerimajasaused_Changes = Me.tbl_TrnTerimajasaUsed.GetChanges()

        If tbl_TrnTerimajasa_Temp_Changes IsNot Nothing Or tbl_TrnTerimajasadetil_Changes IsNot Nothing Or tbl_TrnTerimajasaused_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnTerimajasa_Temp.Rows(0).RowState
                terimajasa_id = tbl_TrnTerimajasa_Temp.Rows(0).Item("terimajasa_id")

                If tbl_TrnTerimajasa_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnTerimaJasa_Rental_SaveMaster(terimajasa_id, tbl_TrnTerimajasa_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnTerimaJasa_Rental_SaveMaster(tbl_TrnTerimajasa_Temp_Changes)")
                    Me.tbl_TrnTerimajasa_Temp.AcceptChanges()
                End If

                If tbl_TrnTerimajasadetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnTerimajasadetil.Rows.Count - 1
                        If Me.tbl_TrnTerimajasadetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnTerimajasadetil.Rows(i).Item("terimajasa_id") = terimajasa_id
                        End If
                    Next
                    success = Me.uiTrnTerimaJasa_Rental_SaveDetil(terimajasa_id, tbl_TrnTerimajasadetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnTerimaJasa_Rental_SaveDetil(tbl_TrnTerimajasadetil_Changes)")
                    Me.tbl_TrnTerimajasadetil.AcceptChanges()
                End If

                If tbl_TrnTerimajasaused_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnTerimajasaUsed.Rows.Count - 1
                        If Me.tbl_TrnTerimajasaUsed.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnTerimajasaUsed.Rows(i).Item("terimajasa_id") = terimajasa_id
                        End If
                    Next
                    success = Me.uiTrnTerimaJasa_Rental_SaveDetilUsed(terimajasa_id, tbl_TrnTerimajasaused_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnTerimaJasa_Rental_SaveDetilUsed(tbl_TrnTerimajasadetilUsed_Changes)")
                    Me.tbl_TrnTerimajasaUsed.AcceptChanges()
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

        RaiseEvent FormAfterSave(terimajasa_id, result)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnTerimaJasa_Rental_SaveMaster(ByRef terimajasa_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        'Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNAsset)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer
        Dim cookie As Byte() = Nothing
        'Dim cookie1 As Byte() = Nothing

        ' Save data: transaksi_terimajasa
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnTerimajasa_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimajasa_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimajasa_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_qtyitem", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_qtyitem", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_qtyrealization", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_qtyrealization", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_qty", System.Data.DataRowVersion.Current, Nothing))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimajasa_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_statusrealization", System.Data.OleDb.OleDbType.VarWChar, 60, "terimajasa_statusrealization"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_location", System.Data.OleDb.OleDbType.VarWChar, 200, "terimajasa_location"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "terimajasa_notes"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_nosuratjalan", System.Data.OleDb.OleDbType.VarWChar, 70, "terimajasa_nosuratjalan"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_isdisabled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_createby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_createdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_modifiedby", System.Data.OleDb.OleDbType.VarWChar, 32, "terimajasa_modifiedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_modifieddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appuser", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_appuser"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appuser_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimajasa_appuser_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appuser_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_appuser_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appspv", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_appspv"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appspv_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimajasa_appspv_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appspv_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_appspv_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appbma", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_appbma"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appbma_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimajasa_appbma_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appbma_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_appbma_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_cetakbpj", System.Data.OleDb.OleDbType.Integer, 4, "terimajasa_cetakbpj"))
        dbCmdInsert.Parameters("@terimajasa_createby").Value = Me.UserName
        dbCmdInsert.Parameters("@terimajasa_createdt").Value = Now()


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnTerimajasa_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimajasa_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimajasa_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_qtyitem", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_qtyitem", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_qtyrealization", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_qtyrealization", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_qty", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimajasa_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_statusrealization", System.Data.OleDb.OleDbType.VarWChar, 60, "terimajasa_statusrealization"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_location", System.Data.OleDb.OleDbType.VarWChar, 200, "terimajasa_location"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "terimajasa_notes"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_nosuratjalan", System.Data.OleDb.OleDbType.VarWChar, 70, "terimajasa_nosuratjalan"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_isdisabled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_createby", System.Data.OleDb.OleDbType.VarWChar, 32, "terimajasa_createby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_createdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_createdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_modifiedby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appuser", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_appuser"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appuser_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimajasa_appuser_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appuser_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_appuser_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appspv", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_appspv"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appspv_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimajasa_appspv_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appspv_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_appspv_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appbma", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_appbma"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appbma_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimajasa_appbma_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_appbma_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_appbma_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasa_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_cetakbpj", System.Data.OleDb.OleDbType.Integer, 4, "terimajasa_cetakbpj"))
        dbCmdUpdate.Parameters("@terimajasa_modifiedby").Value = Me.UserName
        dbCmdUpdate.Parameters("@terimajasa_modifieddt").Value = Now()


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            'dbConnAsset.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            'clsApplicationRole.SetAppRole(dbConnAsset, cookie1)
            dbDA.Update(objTbl)

            terimajasa_id = objTbl.Rows(0).Item("terimajasa_id")
            Me.tbl_TrnTerimajasa_Temp.Clear()
            Me.tbl_TrnTerimajasa_Temp.Merge(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            'clsApplicationRole.UnsetAppRole(dbConnAsset, cookie1)
            dbConn.Close()
            ' dbConnAsset.Close()
        End Try


        If MasterDataState = DataRowState.Added Then
            Me.locking.TryLocking(terimajasa_id)
            Me.tbl_TrnTerimajasa.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnTerimajasa).Position
            Me.tbl_TrnTerimajasa.Rows.RemoveAt(curpos)
            Me.tbl_TrnTerimajasa.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnTerimajasa).Position = Me.BindingContext(Me.tbl_TrnTerimajasa).Count

        Return True
    End Function
    Private Function uiTrnTerimaJasa_Rental_SaveDetil(ByRef terimajasa_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        ' Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNAsset)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing
        ' Dim cookie1 As Byte() = Nothing

        ' Save data: transaksi_terimajasadetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnTerimajasadetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimajasadetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_desc", System.Data.OleDb.OleDbType.VarWChar, 600, "terimajasadetil_desc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasadetil_date"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty", System.Data.OleDb.OleDbType.Integer, 4, "terimajasadetil_qty"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty_day_eps", System.Data.OleDb.OleDbType.Integer, 4, "terimajasadetil_qty_day_eps"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty_usage", System.Data.OleDb.OleDbType.Integer, 4, "terimajasadetil_qty_usage"))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty_day_eps", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_qty_day_eps", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty_usage", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_qty_usage", System.Data.DataRowVersion.Current, Nothing))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimajasadetil_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriitem_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_createby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_createdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_modifiedby", System.Data.OleDb.OleDbType.VarWChar, 32, "terimajasadetil_modifiedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasadetil_modifieddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@type_pajak", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "type_pajak", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategori_pajak", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "kategori_pajak", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimajasadetil_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_pphpersen", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimajasadetil_pphpersen", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_ppnpersen", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimajasadetil_ppnpersen", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_pphforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_pphforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_pphidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimajasadetil_pphidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_ppnforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_ppnforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_ppnidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimajasadetil_ppnidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_totalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_totalforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_totalidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimajasadetil_totalidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters("@terimajasa_id").Value = terimajasa_id
        dbCmdInsert.Parameters("@terimajasadetil_createby").Value = Me.UserName
        dbCmdInsert.Parameters("@terimajasadetil_createdt").Value = Now()

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnTerimajasadetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimajasadetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_desc", System.Data.OleDb.OleDbType.VarWChar, 600, "terimajasadetil_desc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasadetil_date"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty", System.Data.OleDb.OleDbType.Integer, 4, "terimajasadetil_qty"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty_day_eps", System.Data.OleDb.OleDbType.Integer, 4, "terimajasadetil_qty_day_eps"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty_usage", System.Data.OleDb.OleDbType.Integer, 4, "terimajasadetil_qty_usage"))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty_day_eps", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_qty_day_eps", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_qty_usage", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_qty_usage", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimajasadetil_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriitem_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_createby", System.Data.OleDb.OleDbType.VarWChar, 32, "terimajasadetil_createby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_createdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasadetil_createdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_modifiedby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@type_pajak", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "type_pajak", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategori_pajak", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "kategori_pajak", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimajasadetil_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_pphpersen", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimajasadetil_pphpersen", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_ppnpersen", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimajasadetil_ppnpersen", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_pphforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_pphforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_pphidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimajasadetil_pphidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_ppnforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_ppnforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_ppnidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimajasadetil_ppnidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_totalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasadetil_totalforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_totalidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimajasadetil_totalidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters("@terimajasa_id").Value = terimajasa_id
        dbCmdUpdate.Parameters("@terimajasadetil_modifiedby").Value = Me.UserName
        dbCmdUpdate.Parameters("@terimajasadetil_modifieddt").Value = Now()


        dbCmdDelete = New OleDb.OleDbCommand("as_TrnTerimajasadetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasadetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimajasadetil_line"))
        dbCmdDelete.Parameters("@terimajasa_id").Value = terimajasa_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


        Try
            dbConn.Open()
            '   dbConnAsset.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            ' clsApplicationRole.SetAppRole(dbConnAsset, cookie1)
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            ' clsApplicationRole.UnsetAppRole(dbConnAsset, cookie1)
            dbConn.Close()
            'dbConnAsset.Close()
        End Try

        Return True
    End Function
    Private Function uiTrnTerimaJasa_Rental_SaveDetilUsed(ByRef terimajasa_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        ' Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNAsset)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing
        '   Dim cookie1 As Byte() = Nothing

        dbCmdInsert = New OleDb.OleDbCommand("as_TrnTerimajasaused_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_line", System.Data.OleDb.OleDbType.Integer, 4, "terimajasa_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_lineday", System.Data.OleDb.OleDbType.Integer, 4, "terimajasa_lineday"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_detilused_note", System.Data.OleDb.OleDbType.VarWChar, 200, "terimajasa_detilused_note"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_check", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_check"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_qty", System.Data.OleDb.OleDbType.Integer, 4, "terimajasaused_qty"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_qty_idle", System.Data.OleDb.OleDbType.Integer, 4, "terimajasaused_qty_idle"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasaused_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_qty_idle", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasaused_qty_idle", System.Data.DataRowVersion.Current, Nothing))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_usagestart", System.Data.OleDb.OleDbType.VarWChar, 10, "terimajasaused_usagestart"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_usgaeend", System.Data.OleDb.OleDbType.VarWChar, 10, "terimajasaused_usgaeend"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimajasaused_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_remark", System.Data.OleDb.OleDbType.VarWChar, 100, "terimajasaused_remark"))
        dbCmdInsert.Parameters("@terimajasa_id").Value = terimajasa_id


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnTerimajasaused_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_line", System.Data.OleDb.OleDbType.Integer, 4, "terimajasa_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_lineday", System.Data.OleDb.OleDbType.Integer, 4, "terimajasa_lineday"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_detilused_note", System.Data.OleDb.OleDbType.VarWChar, 200, "terimajasa_detilused_note"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_check", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_check"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_qty", System.Data.OleDb.OleDbType.Integer, 4, "terimajasaused_qty"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_qty_idle", System.Data.OleDb.OleDbType.Integer, 4, "terimajasaused_qty_idle"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasaused_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_qty_idle", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimajasaused_qty_idle", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_usagestart", System.Data.OleDb.OleDbType.VarWChar, 10, "terimajasaused_usagestart"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_usgaeend", System.Data.OleDb.OleDbType.VarWChar, 10, "terimajasaused_usgaeend"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimajasaused_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_remark", System.Data.OleDb.OleDbType.VarWChar, 100, "terimajasaused_remark"))
        dbCmdUpdate.Parameters("@terimajasa_id").Value = terimajasa_id


        dbCmdDelete = New OleDb.OleDbCommand("as_TrnTerimajasaused_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_line", System.Data.OleDb.OleDbType.Integer, 4, "terimajasa_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_lineday", System.Data.OleDb.OleDbType.Integer, 4, "terimajasa_lineday"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimajasa_date"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_detilused_note", System.Data.OleDb.OleDbType.VarWChar, 200, "terimajasa_detilused_note"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_check", System.Data.OleDb.OleDbType.Boolean, 1, "terimajasa_check"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_qty", System.Data.OleDb.OleDbType.Integer, 4, "terimajasaused_qty"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_usagestart", System.Data.OleDb.OleDbType.VarWChar, 10, "terimajasaused_usagestart"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_usgaeend", System.Data.OleDb.OleDbType.VarWChar, 10, "terimajasaused_usgaeend"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimajasaused_status"))
        ' ''dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasaused_remark", System.Data.OleDb.OleDbType.VarWChar, 100, "terimajasaused_remark"))
        dbCmdDelete.Parameters("@terimajasa_id").Value = terimajasa_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


        Try
            dbConn.Open()
            ' dbConnAsset.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            '  clsApplicationRole.SetAppRole(dbConnAsset, cookie1)
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            '  clsApplicationRole.UnsetAppRole(dbConnAsset, cookie1)
            dbConn.Close()
            ' dbConnAsset.Close()
        End Try

        Return True
    End Function

    Private Function uiTrnTerimaJasa_Rental_JurnalSave() As Boolean
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
        'tbl_TrnJurnal_Changes = Me.tbl_TrnJurnal.GetChanges()

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
                    success = Me.uiTrnTerimaJasa_Rental_JurnalSaveMaster(jurnal_id, tbl_TrnJurnal_Changes, MasterDataState)
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
                    success = Me.uiTrnJurnalJasa_Rental_JurnalSaveDetilKredit(jurnal_id, tbl_TrnJurnaldetil_kredit_Changes, MasterDataState)
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
                    success = Me.uiTrnJurnalJasa_Rental_JurnalSaveReference(jurnal_id, tbl_JurnalReference_Changes, MasterDataState)
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
                    success = Me.uiTrnJurnalJasa_Rental_JurnalSaveDetilDebet(jurnal_id, tbl_TrnJurnaldetil_debet_Changes, MasterDataState)
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
    Private Function uiTrnTerimaJasa_Rental_JurnalSaveMaster(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
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
        Catch ex As Data.OleDb.OleDbException
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
    Private Function uiTrnJurnalJasa_Rental_JurnalSaveDetilKredit(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
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

        Catch ex As Data.OleDb.OleDbException
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
    Private Function uiTrnJurnalJasa_Rental_JurnalSaveDetilDebet(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
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

        Catch ex As Data.OleDb.OleDbException
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
    Private Function uiTrnJurnalJasa_Rental_JurnalSaveReference(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
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
        dbCmdInsert.Parameters("@referencetype").Value = "jurnal BPJ"

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnalreference_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_ref", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id_ref"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_refline", System.Data.OleDb.OleDbType.Integer, 4, "jurnal_id_refline"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "jurnal_id_budgetline"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@referencetype", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdDelete.Parameters("@referencetype").Value = "jurnal BPJ"


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)
        Catch ex As Data.OleDb.OleDbException
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

    Private Function uiTrnTerimaJasa_Rental_Delete() As Boolean
        Dim res As String = ""
        Dim terimajasa_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(terimajasa_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnTerimajasa.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnTerimaJasa_Rental_DeleteRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(terimajasa_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnTerimaJasa_Rental_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        ' Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNAsset)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim terimajasa_id As String
        Dim NewRowIndex As Integer
        Dim cookie As Byte() = Nothing
        ' Dim cookie1 As Byte() = Nothing

        terimajasa_id = Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimajasa_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnTerimajasa_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimajasa_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@terimajasa_id").Value = terimajasa_id

        Try
            dbConn.Open()
            ' dbConnAsset.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            'clsApplicationRole.SetAppRole(dbConnAsset, cookie1)
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnTerimajasa.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnTerimaJasa_Rental_OpenRow(NewRowIndex)
                    Me.tbl_TrnTerimajasa.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnTerimajasa.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnTerimaJasa_Rental_OpenRow(NewRowIndex)
                    Me.tbl_TrnTerimajasa.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnTerimajasa.Rows.RemoveAt(rowIndex)
                    Me.uiTrnTerimaJasa_Rental_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_TrnTerimajasa_Temp.Clear()
                Me.tbl_TrnTerimajasa.Rows.RemoveAt(rowIndex)

            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            ' clsApplicationRole.UnsetAppRole(dbConnAsset, cookie1)
            dbConn.Close()
            '  dbConnAsset.Close()
        End Try
    End Function

    Private Function uiTrnTerimaJasa_Rental_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        '   Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNAsset)
        Dim terimajasa_id As String
        Dim channel_id As String
        Dim cookie As Byte() = Nothing
        ' Dim cookie1 As Byte() = Nothing

        terimajasa_id = Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimajasa_id").Value
        channel_id = Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(terimajasa_id)

        Try
            If Me._USERTYPE = "bma" Then
                If clsUtil.IsDbNull(Me.DgvTrnTerimajasa.Item("terimajasa_appuser", DgvTrnTerimajasa.CurrentRow.Index).Value = 0, 0) Or _
                                clsUtil.IsDbNull(Me.DgvTrnTerimajasa.Item("terimajasa_appspv", DgvTrnTerimajasa.CurrentRow.Index).Value = 0, 0) Then
                    MsgBox("You do not have the authority to open this data")
                    Me.ftabMain.SelectedIndex = 0
                    Me.Cursor = Cursors.Arrow
                    Exit Function
                End If
            End If
            dbConn.Open()
            '  dbConnAsset.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            ' clsApplicationRole.SetAppRole(dbConnAsset, cookie1)
            Me.uiTrnTerimaJasa_Rental_OpenRowMaster(channel_id, terimajasa_id, dbConn)
            Me.uiTrnTerimaJasa_Rental_OpenRowDetil(channel_id, terimajasa_id, dbConn)
            Me.uiTrnTerimaJasa_Rental_OpenRowDetilUsed(channel_id, terimajasa_id, dbConn)
            Me.uiTrnTerimaJasa_Rental_OpenRowJurnal(channel_id, terimajasa_id, dbConn)
            Me.uiTrnTerimaJasa_Rental_OpenRowJurnalDetil_kredit(channel_id, terimajasa_id, dbConn)
            Me.uiTrnTerimaJasa_Rental_OpenRowJurnalDetil_Debet(channel_id, terimajasa_id, dbConn)
            Me.uiTrnTerimajasa_Rental_OpenRowJurnalReference(channel_id, terimajasa_id, dbConn)
            Me.uiTrnTerimajasa_Rental_OpenRowResponse(channel_id, terimajasa_id, dbConn)


            If Me._USERTYPE = "user" Then
                Me.btnApproved.Visible = False
                Me.btnUnApproved.Visible = False

                If clsUtil.IsDbNull(Me.DgvTrnTerimajasa.Item("terimajasa_appuser", DgvTrnTerimajasa.CurrentRow.Index).Value = 1, 0) Then
                    Me.tbtnDel.Enabled = False
                    Me.tbtnSave.Enabled = False
                Else
                    Me.tbtnDel.Enabled = True
                    Me.tbtnSave.Enabled = True
                End If
            ElseIf Me._USERTYPE = "spv" Then
                Me.btnApproved.Visible = True
                Me.btnUnApproved.Visible = True
                If clsUtil.IsDbNull(Me.DgvTrnTerimajasa.Item("terimajasa_appspv", DgvTrnTerimajasa.CurrentRow.Index).Value = 1, 0) Then
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
            ElseIf Me._USERTYPE = "bma" Then
                Me.btnApproved.Visible = True
                Me.btnUnApproved.Visible = True
                If clsUtil.IsDbNull(Me.DgvTrnTerimajasa.Item("terimajasa_appbma", DgvTrnTerimajasa.CurrentRow.Index).Value = 1, 0) Then
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
            MessageBox.Show(ex.Message, mUiName & ": uiTrnTerimaJasa_Rental_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            '  clsApplicationRole.UnsetAppRole(dbConnAsset, cookie1)
            dbConn.Close()
            '  dbConnAsset.Close()
        End Try

        RaiseEvent FormAfterOpenRow(terimajasa_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiTrnTerimaJasa_Rental_OpenRowMaster(ByVal channel_id As String, ByVal terimajasa_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_strukturunitRV As DataTable = New DataTable
        'Dim cookie As Byte() = Nothing
        'Dim cookie2 As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand("as_TrnTerimajasa_Select_OpenRow", dbConn)
        ' ''dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        ' ''dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("terimajasa_id='{0}'", terimajasa_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnTerimajasa_Temp.Clear()

        Try
            '=====ADD PTS 20130704--"Cegah Currency Kosong"
            tbl_strukturunitRV.Clear()
            Me.DataFill(tbl_strukturunitRV, "tr_StrukturunitOrderAll_select", "terimajasa_id = '" & terimajasa_id & "'")
            Me.strukturunit = tbl_strukturunitRV.Rows(0).Item("strukturunit_id")
            Me.currency_id = tbl_strukturunitRV.Rows(0).Item("currency_id")
            Me.foreign_rate = tbl_strukturunitRV.Rows(0).Item("order_foreignrate")
            '==================================================================

            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnTerimajasa_Temp)
            Me.BindingStart()
            If Me.tbl_TrnTerimajasa_Temp.Rows.Count > 0 Then
                'Dim dbConnStart As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNStart)
                'dbConnStart.Open()
                'clsApplicationRole.SetAppRole(dbConnStart, cookie2)
                Me.uiTrnRentalOrder2_OpenRowDetil(channel_id, tbl_TrnTerimajasa_Temp.Rows(0).Item("order_id"), dbConn)
                'clsApplicationRole.UnsetAppRole(dbConnStart, cookie2)
                'dbConnStart.Close()
            End If
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnTerimaJasa_Rental_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnTerimaJasa_Rental_OpenRowDetil(ByVal channel_id As String, ByVal terimajasa_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnTerimajasadetilRental_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("terimajasa_id='{0}'", terimajasa_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandTimeout = 0
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnTerimajasadetil.Clear()

        Me.tbl_TrnTerimajasadetil = clsDataset.CreateTblTrnTerimajasadetil()
        Me.tbl_TrnTerimajasadetil.Columns("terimajasa_id").DefaultValue = terimajasa_id
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").AutoIncrement = True
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").AutoIncrementStep = 10
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_date").DefaultValue = Now.Date
        Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_type").DefaultValue = "RENTAL"
        Me.tbl_TrnTerimajasadetil.Columns("channel_id").DefaultValue = Me._CHANNEL

        Try
            dbDA.Fill(Me.tbl_TrnTerimajasadetil)
            Me.DgvTrnTerimajasadetil.DataSource = Me.tbl_TrnTerimajasadetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnTerimaJasa_Rental_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnTerimaJasa_Rental_OpenRowDetilUsed(ByVal channel_id As String, ByVal terimajasa_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnTerimajasaused_Select", dbConn)
        ' ''dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        ' ''dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("terimajasa_id='{0}'", terimajasa_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnTerimajasaUsed.Clear()

        Me.tbl_TrnTerimajasaUsed = clsDataset.CreateTblTrnTerimajasaused()
        Me.tbl_TrnTerimajasaUsed.Columns("terimajasa_id").DefaultValue = terimajasa_id
        ' ''Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").DefaultValue = DBNull.Value
        ' ''Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").AutoIncrement = True
        ' ''Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").AutoIncrementSeed = 10
        ' ''Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_line").AutoIncrementStep = 10
        ' ''Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_date").DefaultValue = Now.Date
        ' ''Me.tbl_TrnTerimajasadetil.Columns("terimajasadetil_type").DefaultValue = "RENTAL"
        Me.tbl_TrnTerimajasaUsed.Columns("channel_id").DefaultValue = Me._CHANNEL

        Try
            dbDA.Fill(Me.tbl_TrnTerimajasaUsed)
            Me.dgvTerimaJasaUsed.DataSource = Me.tbl_TrnTerimajasaUsed
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnTerimaJasa_Rental_OpenRowDetilUsed()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnTerimaJasa_Rental_OpenRowJurnal(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
    Private Function uiTrnTerimaJasa_Rental_OpenRowJurnalDetil_kredit(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
    Private Function uiTrnTerimaJasa_Rental_OpenRowJurnalDetil_Debet(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
    Private Function uiTrnTerimajasa_Rental_OpenRowJurnalReference(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' ''dbCmd = New OleDb.OleDbCommand("cp_TrnJurnalReferenceRVselectOrder_Select", dbConn)
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
    Private Function uiTrnTerimajasa_Rental_OpenRowResponse(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
    Private Function uiTrnRentalOrder2_OpenRowDetil(ByVal channel_id As String, ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnOrderDetilBpj_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id='{0}'", order_id)

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrderdetil.Clear()

        Me.tbl_TrnOrderdetil = clsDataset.CreateTblTrnOrderdetil()
        Me.tbl_TrnOrderdetil.Columns("order_id").DefaultValue = order_id
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrement = True
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnOrderdetil.Columns("orderdetil_line").AutoIncrementStep = 10
        Me.tbl_TrnOrderdetil.Columns("orderdetil_type").DefaultValue = "Item"

        Try
            dbDA.Fill(Me.tbl_TrnOrderdetil)
            Me.dgvTrnOrder.DataSource = Me.tbl_TrnOrderdetil

        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnRentalOrder_OpenRowDetil()" & vbCrLf & ex.Message)
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
    Private Function uiTrnTerimaJasa_Rental_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnTerimaJasa_Rental_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnTerimajasa.CurrentCell = Me.DgvTrnTerimajasa(1, 0)
            Me.uiTrnTerimaJasa_Rental_RefreshPosition()
        End If
    End Function

    Private Function uiTrnTerimaJasa_Rental_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnTerimaJasa_Rental_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnTerimajasa.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnTerimajasa.CurrentCell = Me.DgvTrnTerimajasa(1, DgvTrnTerimajasa.CurrentCell.RowIndex - 1)
                Me.uiTrnTerimaJasa_Rental_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnTerimaJasa_Rental_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnTerimaJasa_Rental_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnTerimajasa.CurrentCell.RowIndex < Me.DgvTrnTerimajasa.Rows.Count - 1 Then
                Me.DgvTrnTerimajasa.CurrentCell = Me.DgvTrnTerimajasa(1, DgvTrnTerimajasa.CurrentCell.RowIndex + 1)
                Me.uiTrnTerimaJasa_Rental_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnTerimaJasa_Rental_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnTerimaJasa_Rental_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnTerimajasa.CurrentCell = Me.DgvTrnTerimajasa(1, Me.DgvTrnTerimajasa.Rows.Count - 1)
            Me.uiTrnTerimaJasa_Rental_RefreshPosition()
        End If
    End Function

    Private Function uiTrnTerimaJasa_Rental_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnTerimaJasa_Rental_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
    End Function

    Private Function uiTrnTerimaJasa_Rental_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnTerimajasa_Temp_Changes As DataTable
        Dim tbl_TrnTerimajasadetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim terimajasa_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvTrnTerimajasa.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnTerimajasa_Temp).EndCurrentEdit()
            tbl_TrnTerimajasa_Temp_Changes = Me.tbl_TrnTerimajasa_Temp.GetChanges()

            Me.DgvTrnTerimajasadetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnTerimajasadetil).EndCurrentEdit()
            tbl_TrnTerimajasadetil_Changes = Me.tbl_TrnTerimajasadetil.GetChanges()

            If tbl_TrnTerimajasa_Temp_Changes IsNot Nothing Or tbl_TrnTerimajasadetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(terimajasa_id)

                        Try

                            If tbl_TrnTerimajasa_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnTerimaJasa_Rental_SaveMaster(terimajasa_id, tbl_TrnTerimajasa_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_TrnTerimajasa_Temp.AcceptChanges()
                            End If

                            If tbl_TrnTerimajasadetil_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnTerimajasadetil.Rows.Count - 1
                                    If Me.tbl_TrnTerimajasadetil.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnTerimajasadetil.Rows(i).Item("terimajasa_id") = terimajasa_id
                                    End If
                                Next
                                success = Me.uiTrnTerimaJasa_Rental_SaveDetil(terimajasa_id, tbl_TrnTerimajasadetil_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnTerimajasadetil.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(terimajasa_id, result)

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

    Private Function uiTrnTerimaJasa_Rental_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        Dim message As String = ""

        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")
            If Me._USERTYPE = "bma" Then
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

            If Me._USERTYPE = "bma" Then
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

    Private Sub uiTrnTerimaJasa_Rental_FormAfterDelete(ByRef id As Object) Handles Me.FormAfterDelete
        Me.locking.Clear()
    End Sub

    Private Sub uiTrnTerimaJasa_Rental_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Dim currentRow As DataRow = CType(Me.BindingContext(Me.tbl_TrnTerimajasa_Temp).Current, DataRowView).Row
        
        Dim approveuser As Boolean
        Dim approvedspv As Boolean
        Dim approvedbma As Boolean

        approveuser = currentRow.Item("terimajasa_appuser")
        approvedspv = currentRow.Item("terimajasa_appspv")
        approvedbma = currentRow.Item("terimajasa_appbma")

        If Me._USERTYPE = "user" Then
            If approvedspv = False Then
                Me.locking.TryLocking(id)
            End If
        ElseIf Me._USERTYPE = "spv" Then
            If approvedbma = False Then
                Me.locking.TryLocking(id)
            End If
        ElseIf Me._USERTYPE = "bma" Then
            If approvedbma = False Then
                Me.locking.TryLocking(id)
            End If
        End If

    End Sub

    Private Sub uiTrnTerimaJasa_Rental_FormBeforeNew() Handles Me.FormBeforeNew
        Me.objFormError.Clear()
        Me.locking.Clear()

    End Sub

    Public Sub Form_Load(ByVal sender As Object)
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



        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            Me.locking = New clsLockingTransaction(Me._CHANNEL, Me.UserName, Me, Me.ftabMain)

            Me.DgvTrnTerimajasa.DataSource = Me.tbl_TrnTerimajasa

            Me.uiTrnTerimaJasa_isBackgroudWorker()
            Me.uiTrnTerimaJasa_LoadComboSearch()

            Me.InitLayoutUI()

            Me.BindingStop()
            Me.BindingStart()

            Me.uiTrnTerimaJasa_Rental_NewData()

            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = False
            Me.tbtnQuery.Enabled = False
            Me.tbtnNew.Enabled = False
            Me.tbtnPrint.Enabled = False
            Me.tbtnPrintPreview.Enabled = False

            Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
            Me.chkSearchChannel.Checked = True
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

            If Me._USERTYPE = "bma" Then
                Me.pnlClose2.Visible = False
                Me.pnlclose3.Visible = False

                Me.PnlDataMaster.Enabled = False
                Me.DgvTrnTerimajasadetil.ReadOnly = True
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
                    row_type.Item("display_type") = "Bma"
                    tbl_Approved.Rows.InsertAt(row_type, 3)
                End If
                Me.cmb_appuser.DataSource = tbl_Approved
                Me.cmb_appuser.ValueMember = "value_type"
                Me.cmb_appuser.DisplayMember = "display_type"

                Me.cmb_appuser.SelectedValue = 2
                Me.chk_User_search.Checked = True
                Me.chk_User_search.Enabled = False

               
                'Me.DgvTrnTerimajasadetil.ContextMenuStrip = ContextMenuStrip1


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
            End If
        End If

    End Sub

    Private Sub uiTrnTerimaJasa_Rental_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
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
                ElseIf Me._USERTYPE = "spv" Or Me._USERTYPE = "bma" Then
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

                If Me.DgvTrnTerimajasa.CurrentRow IsNot Nothing Then
                    Me.uiTrnTerimaJasa_Rental_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
                    Me.ftabDataDetil.SelectedIndex = 2
                    Me.ftabDataDetil.SelectedIndex = 0
                Else
                    Me.uiTrnTerimaJasa_Rental_NewData()
                End If


        End Select
    End Sub

    Private Sub DgvTrnTerimajasa_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnTerimajasa.CellClick
        If Me.tbl_TrnTerimajasa.Rows.Count > 0 Then
            If Me._USERTYPE = "user" Then
                If CType(clsUtil.IsDbNull(DgvTrnTerimajasa.CurrentRow.Cells("terimajasa_appuser").Value, 0), Integer) = 1 Then
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

    Private Sub DgvTrnTerimajasa_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnTerimajasa.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnTerimajasa.CurrentRow IsNot Nothing Then
            If Me._USERTYPE = "bma" Then
                If clsUtil.IsDbNull(Me.DgvTrnTerimajasa.Item("terimajasa_appuser", DgvTrnTerimajasa.CurrentRow.Index).Value = 0, 0) Or _
                                clsUtil.IsDbNull(Me.DgvTrnTerimajasa.Item("terimajasa_appspv", DgvTrnTerimajasa.CurrentRow.Index).Value = 0, 0) Then
                    MsgBox("You do not have the authority to open this data")
                    Me.ftabMain.SelectedIndex = 0
                    Exit Sub
                End If

            End If
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub


    Private Sub uiTrnTerimaJasa_LoadComboSearch()
        Dim oDataFiller As New clsDataFiller(Me.DSNFrm)

        If Me._LOADCOMBOSEARCH = False Then
            '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", tbl_MstChannel_channel_id_search, "as_MstChannel_select", " channel_id = '" & Me._CHANNEL & "' ", "")
            Me.ComboFill(Me.obj_Currency_id, "currency_id", "currency_shortname", tbl_MstCurrency, "ms_MstCurrency_Select", "Currency_active = 1", "")
            Me.ComboFill(Me.obj_Strukturunit_id_pemilik_search, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunit_id_search, "ms_MstStrukturUnit_Select", "", "")
            Me.tbl_MstStrukturunitGrid = tbl_MstStrukturunit_id_search.Copy
            oDataFiller.DataFillForCombo("item_id", "item_name", Me.tbl_MstItem, "ms_MstItem_Select", "")
            oDataFiller.DataFillForCombo("category_id", "category_name", Me.tbl_MstItemCategory, "ms_MstItemCategory_Select", "")
            oDataFiller.DataFillForComboAsset(Me.DSNFrm, "merk_id", "merk_name", Me.tbl_MstBrand, "as_MstMerk_Select", " merk_active = 1 ")

            oDataFiller.DataFillForCombo("acc_id", "acc_nameshort", Me.tbl_MstAccGrid, "ms_MstAccountCombo_Select", "") '"acc_isdisabled = 0")
            oDataFiller.DataFillForCombo("currency_id", "currency_shortname", Me.tbl_MstCurrencyGrid, "ms_MstCurrency_Select", " Currency_active = 1 ")

            Me.ComboFill(Me.cbo_periode, "periode_id", "periode_name", Me.tbl_MstPeriodeCombo, "ms_MstPeriodeCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
            Me.tbl_MstPeriodeCombo.DefaultView.Sort = "periode_name"

            Me.tbl_MstCurrencyDetil = Me.tbl_MstCurrency.Copy

            Me.tbl_MstItem.DefaultView.Sort = "item_name"
            Me.tbl_MstItemCategory.DefaultView.Sort = "category_name"
            Me.tbl_MstBrand.DefaultView.Sort = "merk_name"
            Me.tbl_MstCurrency.DefaultView.Sort = "Currency_shortname"
            Me.tbl_MstCurrencyDetil.DefaultView.Sort = "Currency_shortname"
            Me.tbl_MstCurrencyGrid.DefaultView.Sort = "Currency_shortname"
            Me.tbl_MstAccGrid.DefaultView.Sort = "acc_nameshort"
            Me.tbl_MstStrukturunit_id_search.DefaultView.Sort = "strukturunit_name"


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
            Me.uiTrnTerimajasa_CollectionData_with_BackgroundWorker(BG_Worker)
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
    Public Sub uiTrnTerimaJasa_newBackgroundWorker()
        Me.BackgroundWorker1 = New BackgroundWorker
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub uiTrnTerimajasa_CollectionData_with_BackgroundWorker(ByVal worker As BackgroundWorker)
        worker.WorkerReportsProgress = True

        Me.label_thread = "Partner"
        worker.ReportProgress(0)
        Me.ComboFill(Me.obj_Rekanan_id, "rekanan_id", "rekanan_name", Me.tbl_MstRekanan, "ms_MstRekanan_Select2", Me._CHANNEL) '"ms_MstRekananCombo_Select", "")
        Me.tbl_MstRekananGrid = Me.tbl_MstRekanan.Copy
        Me.tbl_MstRekanan_rekanan_id_search = Me.tbl_MstRekanan.Copy
        Me.tbl_MstRekananGrid.DefaultView.Sort = "rekanan_name"
        Me.tbl_MstRekanan_rekanan_id_search.DefaultView.Sort = "rekanan_name"

        worker.ReportProgress(30)
        Me.label_thread = "Employee"
        Me.ComboFillAsset(Me.obj_Employee_id_owner, "employee_id", "employee_namalengkap", Me.Tbl_Mstemployee, "ms_MstEmployee_Select", " ")
        Me.Tbl_Mstemployee.DefaultView.Sort = "employee_namalengkap"

        worker.ReportProgress(60)
        Me.label_thread = "Budget"
        ComboFill(obj_Budget_id, "budget_id", "budget_nameshort", tbl_TrnBudget, "ms_MstBudgetCombo_Select", "budget_isactive = 1 AND channel_id = '" & Me._CHANNEL & "' ")
        Me.tbl_TrnBudget.DefaultView.Sort = "budget_nameshort"

        Me.label_thread = "Budget Detil"
        worker.ReportProgress(80)
        Me.DataFillForComboDec("budgetdetil_id", "budgetdetil_desc", Me.tbl_TrnBudgetDetil, "ms_MstBudgetdetilCombo_SelectAsset", "")
        Me.tbl_TrnBudgetDetil.DefaultView.Sort = "budgetdetil_desc"

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

    Private Sub uiTrnTerimaJasa_isBackgroudWorker()

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
                    Me.uiTrnTerimaJasa_newBackgroundWorker()
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

    Private Sub btn_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_order.Click
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim cookie As Byte() = Nothing
        If Me.DgvTrnTerimajasadetil.Rows.Count = 0 Then
            Dim dlg As dlgTrnTerimajasa_Select_Rental = New dlgTrnTerimajasa_Select_Rental(Me.DSNFrm, Me.obj_Rekanan_id.SelectedValue, Me.tbl_MstRekanan.Copy, Me._STRUKTUR_UNIT)

            Dim retObj As Object
            Dim retData As Collection
            Dim tblH As DataTable

            retObj = dlg.OpenDialog(Me, Me.obj_Channel_id.Text, "Rental")

            If retObj IsNot Nothing Then

                '====ADD PTS 20130905========
                Dim row As DataRow = CType(dlg.DgvRentalOrder.CurrentRow.DataBoundItem, DataRowView).Row
                Dim tempRow As DataRow = CType(Me.BindingContext(Me.tbl_TrnTerimajasa_Temp).Current, DataRowView).Row
                '============================

                retData = CType(retObj, Collection)
                tblH = CType(retData.Item("tblH"), DataTable)

                Me.obj_Budget_id.SelectedValue = clsUtil.IsDbNull(tblH.Rows(0).Item("budget_id"), 0)
                Me.obj_Rekanan_id.SelectedValue = clsUtil.IsDbNull(tblH.Rows(0).Item("rekanan_id"), 0)
                Me.obj_Order_id.Text = clsUtil.IsDbNull(tblH.Rows(0).Item("order_id"), String.Empty)
                Me.obj_Terimajasa_notes.Text = clsUtil.IsDbNull(tblH.Rows(0).Item("order_descr"), String.Empty)


                '=======ADd PTS 20130905===============
                tempRow.Item("currency_id") = row.Item("currency_id")
                tempRow.Item("terimajasa_foreignrate") = row.Item("order_foreignrate")
                '======================================

                '=====ADD BY PTS=====20130522=========
                'Me.obj_Currency_id.SelectedValue = clsUtil.IsDbNull(tblH.Rows(0).Item("currency_id"), 0)
                'Me.obj_Terimajasa_foreignrate.Text = clsUtil.IsDbNull(tblH.Rows(0).Item("order_foreignrate"), 0)
                '====================================

                Try
                    dbConn.Open()
                    clsApplicationRole.SetAppRole(dbConn, cookie)
                    Me.uiTrnRentalOrder2_OpenRowDetil(Me._CHANNEL, tblH.Rows(0).Item("order_id"), dbConn)
                Catch ex As Exception

                Finally
                    clsApplicationRole.UnsetAppRole(dbConn, cookie)
                    dbConn.Close()
                End Try


            End If
        Else
            MsgBox("Maaf, sudah ada satu atau lebih item dari " & Me.obj_Order_id.Text & " yang sudah ditarik", MsgBoxStyle.Information, "Information")
        End If

    End Sub

    Private Sub Btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Add.Click
        Dim dlg As dlgTrnTerimaJasaDetil_Select_Rental = New dlgTrnTerimaJasaDetil_Select_Rental()

        Dim retObj As Object
        Dim retData As Collection
        Dim tblDetil As DataTable
        Dim row_index As Integer
        Dim row_days As Integer
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_TrnOrderDetilUsed As DataTable = New DataTable
        Dim qty_order As Integer
        Dim cookie As Byte() = Nothing

        Dim order_line As String = String.Empty
        Dim i, j, k As Integer
        Dim line As String = String.Empty
        Dim tbl_order As DataTable = New DataTable

        For i = 0 To Me.DgvTrnTerimajasadetil.Rows.Count - 1
            If order_line = String.Empty Then
                order_line = Me.DgvTrnTerimajasadetil.Rows(i).Cells("orderdetil_line").Value
            Else
                order_line &= ", " & Me.DgvTrnTerimajasadetil.Rows(i).Cells("orderdetil_line").Value
            End If
        Next

        If order_line <> String.Empty Then
            order_line = "(" & order_line & ")"
        End If

        retObj = dlg.OpenDialog(Me, Me.obj_Channel_id.Text, Me.DSNFrm, Me.DSNFrm, Me.obj_Order_id.Text, order_line)

        If retObj IsNot Nothing Then

            retData = CType(retObj, Collection)
            tblDetil = CType(retData.Item("tblDetil"), DataTable)

            Dim row As DataRow

            For row_index = 0 To tblDetil.Rows.Count - 1
                row = Me.tbl_TrnTerimajasadetil.NewRow
                row.Item("terimajasadetil_desc") = tblDetil.Rows(row_index).Item("orderdetil_descr")
                row.Item("terimajasadetil_date") = Now.Date
                row.Item("terimajasadetil_qty") = tblDetil.Rows(row_index).Item("ro_outstanding")
                row.Item("terimajasadetil_qty_day_eps") = 0 'tblDetil.Rows(row_index).Item("orderdetil_days")
                row.Item("terimajasadetil_qty_usage") = 0
                row.Item("order_id") = tblDetil.Rows(row_index).Item("order_id")
                row.Item("orderdetil_line") = tblDetil.Rows(row_index).Item("orderdetil_line")
                row.Item("item_id") = tblDetil.Rows(row_index).Item("item_id")
                row.Item("kategoriitem_id") = tblDetil.Rows(row_index).Item("category_id")
                row.Item("brand_id") = 0
                row.Item("budget_id") = tblDetil.Rows(row_index).Item("budget_id")
                row.Item("budgetdetil_id") = tblDetil.Rows(row_index).Item("budgetdetil_id")
                row.Item("acc_id") = tblDetil.Rows(row_index).Item("acc_id")
                row.Item("type_pajak") = 1
                row.Item("kategori_pajak") = 0

                row.Item("terimajasadetil_foreign") = tblDetil.Rows(row_index).Item("orderdetil_foreign")
                row.Item("currency_id") = tblDetil.Rows(row_index).Item("currency_id")
                row.Item("terimajasadetil_foreignrate") = tblDetil.Rows(row_index).Item("orderdetil_foreignrate")
                row.Item("terimajasadetil_idrreal") = tblDetil.Rows(row_index).Item("orderdetil_foreignrate") * tblDetil.Rows(row_index).Item("orderdetil_foreign")
                row.Item("terimajasadetil_pphpersen") = tblDetil.Rows(row_index).Item("orderdetil_pphpercent")
                row.Item("terimajasadetil_ppnpersen") = tblDetil.Rows(row_index).Item("orderdetil_ppnpercent")
                row.Item("terimajasadetil_disc") = Math.Round(tblDetil.Rows(row_index).Item("orderdetil_discount") / (tblDetil.Rows(row_index).Item("orderdetil_qty") * tblDetil.Rows(row_index).Item("orderdetil_days")), 2, MidpointRounding.AwayFromZero)
                row.Item("terimajasadetil_pphforeign") = 0
                row.Item("terimajasadetil_pphidrreal") = 0
                row.Item("terimajasadetil_ppnforeign") = 0
                row.Item("terimajasadetil_ppnidrreal") = 0
                row.Item("terimajasadetil_totalforeign") = 0
                row.Item("terimajasadetil_totalidrreal") = 0
                Me.tbl_TrnTerimajasadetil.Rows.Add(row)

                qty_order += clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_qty"), 0) * clsUtil.IsDbNull(tblDetil.Rows(row_index).Item("orderdetil_days"), 0)

                '============remark by PTS 20130522===============
                'Me.obj_Currency_id.SelectedValue = tblDetil.Rows(row_index).Item("currency_id")
                'Me.obj_Terimajasa_foreignrate.Text = tblDetil.Rows(row_index).Item("orderdetil_foreignrate")
                '=================================================
                tbl_TrnOrderDetilUsed.Clear()
                dbCmd = New OleDb.OleDbCommand("as_TrnTerimajasadetilUsed_Select_Rental", dbConn)
                dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
                dbCmd.Parameters("@Criteria").Value = " orderdetiluse_checked = 1 "
                dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarWChar)
                dbCmd.Parameters("@order_id").Value = tblDetil.Rows(row_index).Item("order_id")
                dbCmd.Parameters.Add("@orderdetil_line", Data.OleDb.OleDbType.Integer)
                dbCmd.Parameters("@orderdetil_line").Value = tblDetil.Rows(row_index).Item("orderdetil_line")

                dbCmd.CommandType = CommandType.StoredProcedure
                dbDA = New OleDb.OleDbDataAdapter(dbCmd)
                tbl_TrnOrderDetilUsed.Clear()

                Try
                    dbConn.Open()
                    clsApplicationRole.SetAppRole(dbConn, cookie)
                    dbDA.Fill(tbl_TrnOrderDetilUsed)
                    For row_days = 0 To tbl_TrnOrderDetilUsed.Rows.Count - 1
                        row = Me.tbl_TrnTerimajasaUsed.NewRow
                        row.Item("channel_id") = Me._CHANNEL
                        row.Item("terimajasa_line") = tbl_TrnTerimajasadetil.Rows(tbl_TrnTerimajasadetil.Rows.Count - 1).Item("terimajasadetil_line")
                        row.Item("terimajasa_lineday") = tbl_TrnOrderDetilUsed.Rows(row_days).Item("orderdetiluse_line")
                        row.Item("order_id") = tbl_TrnOrderDetilUsed.Rows(row_days).Item("order_id")
                        row.Item("orderdetil_line") = tbl_TrnOrderDetilUsed.Rows(row_days).Item("orderdetil_line")
                        row.Item("orderdetiluse_line") = tbl_TrnOrderDetilUsed.Rows(row_days).Item("orderdetiluse_line")
                        row.Item("terimajasa_date") = tbl_TrnOrderDetilUsed.Rows(row_days).Item("orderdetiluse_date")
                        row.Item("terimajasa_detilused_note") = String.Empty
                        row.Item("terimajasa_check") = 0
                        row.Item("terimajasaused_qty") = tbl_TrnOrderDetilUsed.Rows(row_days).Item("ro_outstanding")
                        row.Item("terimajasaused_qty_idle") = 0
                        row.Item("terimajasaused_usagestart") = tblDetil.Rows(row_index).Item("order_utilizedtimestart")
                        row.Item("terimajasaused_usgaeend") = tblDetil.Rows(row_index).Item("order_utilizedtimeend")
                        row.Item("terimajasaused_status") = "Fair"

                        Me.tbl_TrnTerimajasaUsed.Rows.Add(row)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "dlgTrnJurnalSelect" & ": dlgTrnJurnalDetilSelect_LoadDetil()", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    clsApplicationRole.UnsetAppRole(dbConn, cookie)
                    dbConn.Close()
                End Try
            Next

            For k = 0 To Me.tbl_TrnTerimajasadetil.Rows.Count - 1
                If tbl_TrnTerimajasadetil.Rows(k).RowState <> DataRowState.Deleted Then
                    If line = String.Empty Then
                        line = Me.tbl_TrnTerimajasadetil.Rows(k).Item("orderdetil_line")
                    Else
                        line &= ", " & Me.tbl_TrnTerimajasadetil.Rows(k).Item("orderdetil_line")
                    End If
                End If
            Next


            tbl_order.Clear()
            qty_order = 0
            Me.DataFill(tbl_order, "pr_TrnOrderdetil_Select", String.Format(" order_id = '{0}' and orderdetil_line in ({1})", Me.obj_Order_id.Text, line))

            For j = 0 To tbl_order.Rows.Count - 1
                qty_order += clsUtil.IsDbNull(tbl_order.Rows(j).Item("orderdetil_qty"), 0) * clsUtil.IsDbNull(tbl_order.Rows(j).Item("orderdetil_days"), 0)
            Next

            Me.obj_Terimajasa_qtyitem.Text = Me.tbl_TrnTerimajasadetil.Rows.Count
            Me.obj_Order_qty.Text = qty_order

        End If
    End Sub

    Private Sub DgvTrnTerimajasadetil_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnTerimajasadetil.CellClick
        Select Case e.ColumnIndex
            Case Me.DgvTrnTerimajasadetil.Columns("select_days").Index

                Dim retObj As Object
                Dim retData As Collection
                Dim ListDaysOrder As New dlgTrnTerimaJasaUsed_Rental(Me.DSNFrm, Me._CHANNEL, Me.obj_Terimajasa_id.Text, Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value, Me.obj_Terimajasa_status.SelectedItem, _
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_line").Value, Me._USERTYPE, 0, Me.tbl_TrnTerimajasaUsed.Copy, Me.obj_Order_id.Text) 'Me.isLock)
                Dim total_qty, total_qty_idle As Integer
                Dim total_day As Integer

                Dim tbl_TrnTerimajasaDetilUsed_temps As DataTable = New DataTable
                Dim i, j, k As Integer

                Dim ppnAmount As Decimal
                Dim ppnAmountIDR As Decimal
                Dim pphAmount As Decimal
                Dim pphAmountIDR As Decimal
                Dim totalAmount As Decimal
                Dim totalAmountIDR As Decimal

                retObj = ListDaysOrder.OpenDialog(Me)
                If retObj IsNot Nothing Then
                    retData = CType(retObj, Collection)
                    tbl_TrnTerimajasaDetilUsed_temps = CType(retData.Item("tblUsed"), DataTable)

                    tbl_TrnTerimajasaDetilUsed_temps.DefaultView.RowFilter = String.Format(" order_id = '{0}' AND orderdetil_line = {1}", Me.obj_Order_id.Text, Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value)
                    For i = 0 To tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Count - 1
                        For j = 0 To Me.tbl_TrnTerimajasaUsed.Rows.Count - 1
                            If tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Item(i).Item("order_id") = Me.tbl_TrnTerimajasaUsed.Rows(j).Item("order_id") And _
                                tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Item(i).Item("orderdetil_line") = Me.tbl_TrnTerimajasaUsed.Rows(j).Item("orderdetil_line") And _
                                    tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Item(i).Item("orderdetiluse_line") = Me.tbl_TrnTerimajasaUsed.Rows(j).Item("orderdetiluse_line") Then
                                Me.tbl_TrnTerimajasaUsed.Rows(j).Item("terimajasa_check") = tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Item(i).Item("terimajasa_check")
                                Me.tbl_TrnTerimajasaUsed.Rows(j).Item("terimajasaused_qty") = tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Item(i).Item("terimajasaused_qty")
                                Me.tbl_TrnTerimajasaUsed.Rows(j).Item("terimajasaused_qty_idle") = tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Item(i).Item("terimajasaused_qty_idle")
                                Me.tbl_TrnTerimajasaUsed.Rows(j).Item("terimajasaused_usagestart") = tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Item(i).Item("terimajasaused_usagestart")
                                Me.tbl_TrnTerimajasaUsed.Rows(j).Item("terimajasaused_usgaeend") = tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Item(i).Item("terimajasaused_usgaeend")
                                Me.tbl_TrnTerimajasaUsed.Rows(j).Item("terimajasaused_status") = tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Item(i).Item("terimajasaused_status")
                                Me.tbl_TrnTerimajasaUsed.Rows(j).Item("terimajasaused_remark") = tbl_TrnTerimajasaDetilUsed_temps.DefaultView.Item(i).Item("terimajasaused_remark")

                                If clsUtil.IsDbNull(Me.tbl_TrnTerimajasaUsed.Rows(j).Item("terimajasa_check"), 0) = 1 Then
                                    total_qty += Me.tbl_TrnTerimajasaUsed.Rows(j).Item("terimajasaused_qty")
                                    total_day += 1
                                    total_qty_idle += Me.tbl_TrnTerimajasaUsed.Rows(j).Item("terimajasaused_qty_idle")
                                End If
                            End If
                        Next
                    Next

                    Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_day_eps").Value = total_day
                    Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value = total_qty
                    Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage_idle").Value = total_qty_idle

                    Dim discount As Decimal

                    '' ''If Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                    '' ''    discount = Math.Round(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_disc").Value, 0), 0, MidpointRounding.AwayFromZero)
                    '' ''Else
                    '' ''    discount = Math.Round(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_disc").Value, 0), 2, MidpointRounding.AwayFromZero)
                    '' ''End If

                    'baru tgl 24-05-2011
                    discount = Math.Round(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_disc").Value, 0), 2, MidpointRounding.AwayFromZero)

                    'pphAmount = ((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_disc").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                    '            * (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_pphpersen").Value, 0) / 100)


                    ''''di rubah 24-05-2011
                    'If Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                    '    pphAmount = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                    '                                    * (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_pphpersen").Value, 0) / 100), 0, MidpointRounding.AwayFromZero)

                    'Else
                    pphAmount = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                            * (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_pphpersen").Value, 0) / 100), 2, MidpointRounding.AwayFromZero)

                    'End If


                    'pphAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_disc").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                    '            * (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_pphpersen").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0))

                    pphAmountIDR = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                                * (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_pphpersen").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0)), 0, MidpointRounding.AwayFromZero)


                    'ppnAmount = ((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_disc").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                    '                               * (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_ppnpersen").Value, 0) / 100)

                    'ppnAmountIDR = ((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_disc").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                    '            * (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_ppnpersen").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0))

                    ''''di rubah 24-05-2011

                    'If Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                    '    ppnAmount = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                    '                                                       * (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_ppnpersen").Value, 0) / 100), 0, MidpointRounding.AwayFromZero)
                    'Else
                    ppnAmount = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                                                                       * (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_ppnpersen").Value, 0) / 100), 2, MidpointRounding.AwayFromZero)
                    'End If


                    ppnAmountIDR = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                                * (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_ppnpersen").Value, 0) / 100) * (clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0)), 0, MidpointRounding.AwayFromZero)


                    'totalAmount = ((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_disc").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))) _
                    '            - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))

                    'totalAmountIDR = (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) * Format(clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0), "#,##0.00") - _
                    '                  (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_disc").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) * clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0) - _
                    '                  clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                    '' ''If Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                    '' ''    totalAmount = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - Math.Round((discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)), 0)), 0, MidpointRounding.AwayFromZero) _
                    '' ''                                   - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))
                    '' ''Else
                    '' ''    totalAmount = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))), 2, MidpointRounding.AwayFromZero) _
                    '' ''                                   - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))
                    '' ''End If

                    'baru 24-05-2011

                    If Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                        totalAmount = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))), 0, MidpointRounding.AwayFromZero) _
                            - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))
                    Else
                        totalAmount = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0))), 2, MidpointRounding.AwayFromZero) _
                                                       - (clsUtil.IsDbNull(pphAmount, 0)) + (clsUtil.IsDbNull(ppnAmount, 0))
                    End If

                    'totalAmountIDR = (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) * Format(clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0), "#,##0.00") - _
                    '                  (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) * clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0) - _
                    '                  clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                    '' ''totalAmountIDR = Math.Round((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) * (clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0)) - _
                    '' ''                  Math.Round((discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)), 0) * clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0), 0, MidpointRounding.AwayFromZero) _
                    '' ''                  - clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                    ' baru tgl 24-05-2011

                    totalAmountIDR = Math.Round((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) * (clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0)) _
                                    - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_qty_usage").Value, 0)) * (clsUtil.IsDbNull(DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_foreignrate").Value, 0)), 0, MidpointRounding.AwayFromZero) _
                                    - clsUtil.IsDbNull(pphAmountIDR, 0) + clsUtil.IsDbNull(ppnAmountIDR, 0)

                    If Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("currency_id").Value = 1 Then
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_pphforeign").Value = Math.Round(pphAmount, 0, MidpointRounding.AwayFromZero)
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_ppnforeign").Value = Math.Round(ppnAmount, 0, MidpointRounding.AwayFromZero)
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_totalforeign").Value = Math.Round(totalAmount, 0, MidpointRounding.AwayFromZero)
                    Else
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_pphforeign").Value = Math.Round(pphAmount, 2, MidpointRounding.AwayFromZero)
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_ppnforeign").Value = Math.Round(ppnAmount, 2, MidpointRounding.AwayFromZero)
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_totalforeign").Value = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero)
                    End If

                    Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_pphidrreal").Value = Math.Round(pphAmountIDR, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_ppnidrreal").Value = Math.Round(ppnAmountIDR, 0, MidpointRounding.AwayFromZero)
                    Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimajasadetil_totalidrreal").Value = Math.Round(totalAmountIDR, 0, MidpointRounding.AwayFromZero)

                    Dim qty_realisasi As Integer
                    qty_realisasi = 0
                    For k = 0 To Me.tbl_TrnTerimajasadetil.Rows.Count - 1

                        If Me.tbl_TrnTerimajasadetil.Rows(k).RowState <> DataRowState.Deleted Then
                            qty_realisasi += Me.tbl_TrnTerimajasadetil.Rows(k).Item("terimajasadetil_qty_usage")
                        End If

                    Next
                    Me.obj_Terimajasa_qtyrealization.Text = qty_realisasi
                End If

        End Select
    End Sub

    Private Sub DgvTrnTerimajasadetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnTerimajasadetil.MouseUp

        If e.Button = Windows.Forms.MouseButtons.Right And Me._USERTYPE = "bma" Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnTerimajasadetil.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnTerimajasadetil.CurrentCell = Me.DgvTrnTerimajasadetil.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
        End If
    End Sub

    Private Sub DgvTrnTerimajasadetil_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DgvTrnTerimajasadetil.UserDeletingRow
        Dim obj As DataGridView = sender
        Dim j As Integer
        If e.Row.Index < 0 Then Exit Sub

        ' ''If clsUtil.IsDbNull(e.Row.Cells("order_id").Value, "") <> "" Then
        ' ''    e.Cancel = True
        ' ''End If

        '=======================================================================================
        For j = 0 To Me.DgvTrnTerimajasadetil.SelectedRows.Count - 1
            Dim order_id As String = Me.DgvTrnTerimajasadetil.SelectedRows.Item(j).Cells("order_id").Value
            Dim orderdetil_line As String = Me.DgvTrnTerimajasadetil.SelectedRows.Item(j).Cells("orderdetil_line").Value

            Dim ref As String = String.Empty
            Dim ref_line As Integer = 0
            Dim tbl_order As DataTable = New DataTable

            Dim jml As Integer = 0
            For i As Integer = 0 To DgvTrnTerimajasadetil.Rows.Count - 1
                If DgvTrnTerimajasadetil.Item("order_id", i).Value = order_id And DgvTrnTerimajasadetil.Item("orderdetil_line", i).Value = orderdetil_line Then
                    jml = jml + 1
                End If
            Next

            ' ''For i As Integer = 0 To DgvTrnJurnaldetil_JdwPembayaran.Rows.Count - 1
            ' ''    If DgvTrnJurnaldetil_JdwPembayaran.Item("ref_id", i).Value = refId Then
            ' ''        jml = jml + 1
            ' ''    End If
            ' ''Next

            If jml = 1 Then
                Me.obj_Terimajasa_qtyrealization.Text -= Me.DgvTrnTerimajasadetil.Rows(j).Cells("terimajasadetil_qty_usage").Value
ulang:
                For i As Integer = 0 To dgvTerimaJasaUsed.Rows.Count - 1
                    ref = dgvTerimaJasaUsed.Item("order_id", i).Value
                    ref_line = dgvTerimaJasaUsed.Item("orderdetil_line", i).Value

                    If order_id = ref And orderdetil_line = ref_line Then
                        dgvTerimaJasaUsed.Rows.RemoveAt(i)
                        GoTo ulang
                    End If
                Next

                tbl_order.Clear()
                Me.DataFill(tbl_order, "pr_TrnOrderdetil_Select", String.Format(" order_id = '{0}' and orderdetil_line = {1}", Me.obj_Order_id.Text, orderdetil_line))
                If tbl_order.Rows.Count > 0 Then
                    Me.obj_Order_qty.Text -= clsUtil.IsDbNull(tbl_order.Rows(0).Item("orderdetil_qty"), 0) * clsUtil.IsDbNull(tbl_order.Rows(0).Item("orderdetil_days"), 0)
                End If
            End If
        Next
        '====================================================================================
        If Me.DgvTrnTerimajasadetil.Rows.Count > 0 Then
            Me.obj_Terimajasa_qtyitem.Text -= 1
        End If

    End Sub

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

    Private Sub DgvTrnTerimajasa_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnTerimajasa.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If objrow.Cells("terimajasa_appuser").Value = 1 And objrow.Cells("terimajasa_appspv").Value = 1 And objrow.Cells("terimajasa_appbma").Value = 1 Then
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            ElseIf objrow.Cells("terimajasa_appuser").Value = 1 And objrow.Cells("terimajasa_appspv").Value = 1 Then
                objrow.DefaultCellStyle.BackColor = Color.Aquamarine
            ElseIf objrow.Cells("terimajasa_appuser").Value = 1 Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            Else
                objrow.DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ftabDataDetil_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        Dim i, activetab As Byte

        For i = 0 To (Me.ftabDataDetil.TabCount - 1)
            Me.ftabDataDetil.TabPages.Item(i).BackColor = Color.LavenderBlush
        Next
        activetab = Me.ftabDataDetil.SelectedIndex
        Me.ftabDataDetil.TabPages.Item(activetab).BackColor = Color.White
    End Sub

    Private Sub FtabJurnal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FtabJurnal.SelectedIndexChanged
        Dim i, activetab As Byte

        For i = 0 To (Me.ftabDataDetil.TabCount - 1)
            Me.ftabDataDetil.TabPages.Item(i).BackColor = Color.LavenderBlush
        Next
        activetab = Me.ftabDataDetil.SelectedIndex
        Me.ftabDataDetil.TabPages.Item(activetab).BackColor = Color.White
    End Sub


#Region "PRINT"
    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        objPrintHeader = New DataSource.clsRptTerimaJasaRental(Me.DSNFrm)
        Dim odatafiller As clsDataFiller = New clsDataFiller(Me.DSNFrm)

        odatafiller.DataFillAsset(Me.DSNFrm, tbl_Print, "as_TrnTerimajasa_Select", " AND terimajasa_id = '" & DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.SelectedCells.Item(0).RowIndex).Value & "'", Me._CHANNEL, 1)
        odatafiller.DataFillAsset(Me.DSNFrm, tbl_PrintDetil, "as_TrnTerimajasadetil_Select", " terimajasa_id = '" & DgvTrnTerimajasa.Item("terimajasa_id", DgvTrnTerimajasa.SelectedCells.Item(0).RowIndex).Value & "'")
        '=========ADD PTS 20140226==========
        Dim Total, Discount, SumPPN, SumPPH, SumGrandTotal, SumTotal, SumDiscount As Decimal
        SumTotal = 0
        SumDiscount = 0

        For a As Integer = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            Total = Me.tbl_PrintDetil.Rows(a).Item("terimajasadetil_idrreal") * Me.tbl_PrintDetil.Rows(a).Item("terimajasadetil_qty_usage")
            SumTotal = SumTotal + Total
        Next

        For w As Integer = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            Discount = Me.tbl_PrintDetil.Rows(w).Item("terimajasadetil_disc") * Me.tbl_PrintDetil.Rows(w).Item("terimajasadetil_qty_usage") * Me.tbl_PrintDetil.Rows(w).Item("terimajasadetil_foreignrate")
            SumDiscount = SumDiscount + Discount
        Next

        SumPPN = Me.tbl_PrintDetil.Compute("sum(terimajasadetil_ppnidrreal)", "")
        SumPPH = Me.tbl_PrintDetil.Compute("sum(terimajasadetil_pphidrreal)", "")
        SumGrandTotal = Me.tbl_PrintDetil.Compute("sum(terimajasadetil_totalidrreal)", "")

        Me.sptSumTotal = SumTotal
        Me.sptSumDiscount = SumDiscount
        Me.sptSumPPn = SumPPN
        Me.sptSumPPh = SumPPH
        Me.sptSumGrandTotal = SumGrandTotal
        '=========================================================


        With objPrintHeader
            .terimajasa_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_id").ToString, String.Empty)
            .terimajasa_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_date"), Now())
            .terimajasa_type = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_type").ToString, String.Empty)
            .order_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_id").ToString, String.Empty)
            .budget_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_id"), 0)
            .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_id"), 0)
            .employee_id_owner = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_owner").ToString, String.Empty)
            .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), 0)
            .terimajasa_qtyitem = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_qtyitem"), 0)
            .terimajasa_qtyrealization = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_qtyrealization"), 0)
            .order_qty = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_qty"), 0)
            .terimajasa_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_status").ToString, String.Empty)
            .terimajasa_statusrealization = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_statusrealization").ToString, String.Empty)
            .terimajasa_location = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_location").ToString, String.Empty)
            .terimajasa_notes = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_notes").ToString, String.Empty)
            .terimajasa_nosuratjalan = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_nosuratjalan").ToString, String.Empty)
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
            .terimajasa_isdisabled = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_isdisabled"), 0)
            .terimajasa_createby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_createby").ToString, String.Empty)
            .terimajasa_createdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_createdt"), Now())
            .terimajasa_modifiedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_modifiedby").ToString, String.Empty)
            .terimajasa_modifieddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_modifieddt"), Now())
            .terimajasa_appuser = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appuser"), 0)
            .terimajasa_appuser_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appuser_by").ToString, String.Empty)
            .terimajasa_appuser_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appuser_dt"), Now())
            .terimajasa_appspv = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appspv"), 0)
            .terimajasa_appspv_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appspv_by").ToString, String.Empty)
            .terimajasa_appspv_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appspv_dt"), Now())
            .terimajasa_appbma = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appbma"), 0)
            .terimajasa_appbma_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appbma_by").ToString, String.Empty)
            .terimajasa_appbma_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appbma_dt"), Now())
            .terimajasa_foreign = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_foreign"), 0)
            .currency_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_id"), 0)
            .terimajasa_foreignrate = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_foreignrate"), 0)
            .terimajasa_idrreal = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_idrreal"), 0)
            .terimajasa_pph = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_pph"), 0)
            .terimajasa_ppn = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_ppn"), 0)
            .terimajasa_disc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_disc"), 0)
            .terimajasa_cetakbpj = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_cetakbpj"), 0)
            .rekanan_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_name"), 0)

            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.sptTerimaJasa_id = .terimajasa_id
            Me.sptDomain = .domain_name


            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptTerimaJasaRentalDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptTerimaJasaRentalDetil(Me.DSNFrm)
            With objDetil
                .terimajasa_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasa_id").ToString, String.Empty)
                .terimajasadetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_line"), 0)
                .terimajasadetil_desc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_desc").ToString, String.Empty)
                .terimajasadetil_date = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_date"), Now())
                .terimajasadetil_qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_qty"), 0)
                .terimajasadetil_qty_day_eps = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_qty_day_eps"), 0)
                .terimajasadetil_qty_usage = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_qty_usage"), 0)
                .terimajasadetil_type = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_type").ToString, String.Empty)
                .order_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("order_id").ToString, String.Empty)
                .orderdetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("orderdetil_line"), 0)
                .item_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("item_id").ToString, String.Empty)
                .kategoriitem_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("kategoriitem_id").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand_id"), 0)
                .budget_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("budget_id"), 0)
                .budgetdetil_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("budgetdetil_id"), 0)
                .acc_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_id").ToString, String.Empty)
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                .terimajasadetil_createby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_createby").ToString, String.Empty)
                .terimajasadetil_createdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_createdt"), Now())
                .terimajasadetil_modifiedby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_modifiedby").ToString, String.Empty)
                .terimajasadetil_modifieddt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_modifieddt"), Now())
                .terimajasadetil_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_foreign"), 0)
                .currency_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id"), 0)
                .terimajasadetil_foreignrate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_foreignrate"), 0)
                .terimajasadetil_idrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_idrreal"), 0)
                .terimajasadetil_pphpersen = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphpersen"), 0)
                .terimajasadetil_ppnpersen = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_ppnpersen"), 0)
                '.terimajasadetil_disc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_disc"), 0)

                If .currency_id = 1 Then
                    .terimajasadetil_disc = Math.Round((clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_disc"), 0) * .terimajasadetil_qty_usage), 0, MidpointRounding.AwayFromZero)
                Else
                    .terimajasadetil_disc = Math.Round((clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_disc"), 0) * .terimajasadetil_qty_usage), 2, MidpointRounding.AwayFromZero)
                End If

                .terimajasadetil_pphforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphforeign"), 0)
                .terimajasadetil_pphidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphidrreal"), 0)
                .terimajasadetil_ppnforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_ppnforeign"), 0)
                .terimajasadetil_ppnidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_ppnidrreal"), 0)
                .terimajasadetil_totalforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_totalforeign"), 0)
                .terimajasadetil_totalidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_totalidrreal"), 0)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptTerimaJasaRentalDetil", objDatalistDetil))
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
        'Const printerName As String = "Microsoft Office Document Image Writer"
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

    Private Function uiTrnTerimaJasa_Rental_Print() As Boolean
        If Me.DgvTrnTerimajasa.SelectedRows.Count <= 0 Then
            MsgBox("No data selected")
            Exit Function
        End If
        If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appspv").Value = 1 Then

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

            Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me._CHANNEL)
            Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
            Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
            Dim parRptTerimaJasa_id As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("terimajasa_id", Me.sptTerimaJasa_id)
            Dim parRptDomain As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", Me.sptDomain)
            '===20140226 pts ADD==
            Dim parRptSumTotal As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumtotal", Me.sptSumTotal)
            Dim parRptSumDiscount As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumdiscount", Me.sptSumDiscount)
            Dim parRptSumPPN As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumppn", Me.sptSumPPn)
            Dim parRptSumPPH As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumpph", Me.sptSumPPh)
            Dim parRptSumGrandTotal As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumgrandtotal", Me.sptSumGrandTotal)
            '=====================

            objRdsH.Name = "ASSET_DataSource_clsRptTerimaJasaRental"
            objRdsH.Value = objDatalistHeader

            If ket = "Internal" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasaRental.rdlc"
            Else
                'objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasaRentalxx.rdlc"
                objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasaRentalx1.rdlc"
            End If

            objReportH.DataSources.Add(objRdsH)
            objReportH.EnableExternalImages = True
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptTerimaJasa_id, parRptDomain, parRptSumTotal, parRptSumDiscount, parRptSumPPN, parRptSumPPH, parRptSumGrandTotal})

            AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
            Export(objReportH)

            m_currentPageIndex = 0
            Print()
        Else
            MsgBox("SPV / Sect. Head approval is required to print this document")
            Exit Function
        End If
    End Function

    Private Function uiTrnTerimaJasa_Rental_PrintPreview() As Boolean

        If Me.DgvTrnTerimajasa.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_appspv").Value = 1 Then

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

            Dim terimajasa_id As String
            terimajasa_id = DgvTrnTerimajasa.CurrentRow.Cells("terimajasa_id").Value
            Dim frmPrint As dlgRptTerimaJasaRental = New dlgRptTerimaJasaRental(Me.DSNFrm, Me.SptServer, Me._CHANNEL, ket)
            Dim criteria As String = String.Empty

            frmPrint.ShowInTaskbar = False
            frmPrint.StartPosition = FormStartPosition.CenterParent

            criteria = " terimajasa_id = '" & terimajasa_id & "'"

            frmPrint.SetIDCriteria(criteria)
            frmPrint.ShowDialog(Me)
        Else
            MsgBox("SPV / Sect. Head approval is required to print this document")
            Exit Function
        End If


    End Function
#End Region

    Private Sub btn_BuiltJurnal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_BuiltJurnal.Click
        Dim row As DataRow
        Dim tbl_debetTemp As DataTable = New DataTable
        Dim i As Integer
        Dim isOk As Boolean = True

        If Me.tbl_TrnTerimajasa_Temp.Rows(0).Item("terimajasa_appbma") = 1 Then
            MsgBox("transactions has been posted. please un-posted this transaction")
            Exit Sub
        End If

        For i = 0 To Me.tbl_TrnJurnaldetil_debet.Rows.Count - 1
            If Me.tbl_TrnJurnaldetil_debet.Rows(i).RowState <> DataRowState.Deleted Then
                If Me.tbl_TrnJurnaldetil_debet.Rows(i).Item("ref_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("order_id").Value And _
                    Me.tbl_TrnJurnaldetil_debet.Rows(i).Item("ref_line") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("orderdetil_line").Value Then
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
            budget_name = Me.tbl_TrnBudget.Select(String.Format("budget_id = {0}", Me.DgvTrnTerimajasadetil.CurrentRow.Cells("budget_id").Value))
            budgetdetil_name = Me.tbl_TrnBudgetDetil.Select(String.Format("budget_id = {0} AND budgetdetil_id = {1}", Me.DgvTrnTerimajasadetil.CurrentRow.Cells("budget_id").Value, Me.DgvTrnTerimajasadetil.CurrentRow.Cells("budgetdetil_id").Value))

            tbl_debetTemp.Clear()

            Me.DataFill(tbl_debetTemp, "ms_MstAcc_SelectBySource", String.Format("B.source_id = 'RV-ListBpj' AND B.dk = 'K' WHERE B.source_id = 'RV-ListBpj' AND B.dk = 'K'"))

            '============ Mulai masukkan data ke tab bagian Debet Na =======
            row = Me.tbl_TrnJurnaldetil_debet.NewRow
            row.Item("jurnal_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasa_id").Value
            row.Item("acc_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("acc_id").Value
            row.Item("jurnaldetil_foreignrate") = Math.Round(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreignrate").Value, 2, MidpointRounding.AwayFromZero)
            'row.Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0)) - (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_disc").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0))), 2, MidpointRounding.AwayFromZero)
            'row.Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_idrreal").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0)) - (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_disc").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0))), 0, MidpointRounding.AwayFromZero)

            Dim discount As Decimal

            discount = Math.Round(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_disc").Value, 0), 2, MidpointRounding.AwayFromZero)

            If clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0) = 0 Then

                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_idr") = 0

            Else
                If Me.DgvTrnTerimajasadetil.CurrentRow.Cells("currency_id").Value = 1 Then
                    row.Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0))), 0, MidpointRounding.AwayFromZero)
                Else
                    row.Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0))), 2, MidpointRounding.AwayFromZero)
                End If

                row.Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreignrate").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0) * Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreignrate").Value)), 0, MidpointRounding.AwayFromZero)

            End If


            'Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0))), 0, MidpointRounding.AwayFromZero)

            '' ''row.Item("jurnaldetil_idr") = Math.Round((((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_idrreal").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0) * Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreignrate").Value))), 0, MidpointRounding.AwayFromZero)

            row.Item("jurnaldetil_descr") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_desc").Value
            row.Item("ref_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("order_id").Value
            row.Item("ref_line") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("orderdetil_line").Value
            row.Item("currency_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("currency_id").Value
            row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
            row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
            row.Item("strukturunit_id") = Me._STRUKTUR_UNIT
            row.Item("budget_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("budget_id").Value
            row.Item("budget_name") = Trim(budget_name(0).Item(2))
            row.Item("budgetdetil_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("budgetdetil_id").Value
            row.Item("budgetdetil_name") = Trim(budgetdetil_name(0).Item(2))
            row.Item("jurnaldetil_line") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_line").Value
            Me.tbl_TrnJurnaldetil_debet.Rows.Add(row)

            '============ Akhir dari masukkan data ke tab bagian Debet ===========

            '============ Mulai masukkan data ke tab bagian Kredit Na =======
            row = Me.tbl_TrnJurnaldetil_kredit.NewRow
            row.Item("jurnal_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasa_id").Value
            row.Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
            row.Item("jurnaldetil_foreignrate") = Math.Round(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreignrate").Value, 2, MidpointRounding.AwayFromZero)
            'row.Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0)) - (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_disc").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0))), 2, MidpointRounding.AwayFromZero)
            'row.Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_idrreal").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0)) - (clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_disc").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0))), 0, MidpointRounding.AwayFromZero)

            discount = Math.Round(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_disc").Value, 0), 2, MidpointRounding.AwayFromZero)

            If clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0) = 0 Then
                row.Item("jurnaldetil_foreign") = 0
                row.Item("jurnaldetil_idr") = 0

            Else
                If Me.DgvTrnTerimajasadetil.CurrentRow.Cells("currency_id").Value = 1 Then
                    row.Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0))), 0, MidpointRounding.AwayFromZero)
                Else
                    row.Item("jurnaldetil_foreign") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0))), 2, MidpointRounding.AwayFromZero)
                End If

                row.Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreign").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreignrate").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0) * Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreignrate").Value)), 0, MidpointRounding.AwayFromZero)

            End If

            'Me.tbl_TrnJurnaldetil_debet.Rows(rows_debet).Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0)) - (discount * clsUtil.IsDbNull(Me.tbl_TrnTerimajasadetil.Rows(rows_debet).Item("terimajasadetil_qty_usage"), 0))), 0, MidpointRounding.AwayFromZero)

            '' ''row.Item("jurnaldetil_idr") = Math.Round(((clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_idrreal").Value, 0) * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0)) - (discount * clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_qty_usage").Value, 0) * Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_foreignrate").Value)), 0, MidpointRounding.AwayFromZero)


            row.Item("jurnaldetil_descr") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_desc").Value
            row.Item("ref_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("order_id").Value
            row.Item("ref_line") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("orderdetil_line").Value
            row.Item("currency_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("currency_id").Value
            row.Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
            row.Item("rekanan_name") = Trim(Me.obj_Rekanan_id.Text)
            row.Item("strukturunit_id") = Me._STRUKTUR_UNIT
            row.Item("budget_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("budget_id").Value
            row.Item("budget_name") = Trim(budget_name(0).Item(2))
            row.Item("budgetdetil_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("budgetdetil_id").Value
            row.Item("budgetdetil_name") = Trim(budgetdetil_name(0).Item(2))
            row.Item("jurnaldetil_line") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasadetil_line").Value - 5
            Me.tbl_TrnJurnaldetil_kredit.Rows.Add(row)

            '============ Akhir dari masukkan data ke tab bagian Kredit ===========

            '============ Mulai masukkan data ke tab bagian Reference Na =======
            row = Me.tbl_JurnalReference.NewRow
            row.Item("jurnal_id") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("terimajasa_id").Value
            row.Item("jurnal_id_ref") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("order_id").Value
            row.Item("jurnal_id_refline") = Me.DgvTrnTerimajasadetil.CurrentRow.Cells("orderdetil_line").Value
            Me.tbl_JurnalReference.Rows.Add(row)
            '============ Akhir dari masukkan data ke tab Reference Kredit ===========

            '============ Mulai masukkan data ke tabel bagian Header Na =======
            If Me.tbl_TrnJurnal.Rows.Count = 0 Then
                Me.tbl_TrnJurnal.Rows.Add()
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Me.obj_Terimajasa_id.Text
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_duedate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_notes").Value
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_invoice_id") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_invoice_descr") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBPJ"
                Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = Me.obj_Rekanan_id.SelectedValue
                'Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = String.Format("{0:yyMM}", Now)
                '===================MODIFIED PTS 20140103===================PERUBAHAN FORMAT PERIODE===========
                Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = Me.channel_number & String.Format("{0:yyMM}", Now)
                '==============================================================================================

                Me.tbl_TrnJurnal.Rows(0).Item("channel_id") = Me._CHANNEL
                Me.tbl_TrnJurnal.Rows(0).Item("budget_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("currency_id").Value
                Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimajasa_foreignrate").Value
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

    Public Sub SetControls_LockingTransactionTryLocking() Implements ILocking.SetControls_LockingTransactionTryLocking
        Dim currentRow As DataRow = CType(Me.BindingContext(Me.tbl_TrnTerimajasa_Temp).Current, DataRowView).Row

        Select Case locking.Status
            Case clsLockingTransaction.LockStatus.Locked
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.Btn_Add.Enabled = False
                Me.btn_order.Enabled = False
                Me.btnApproved.Enabled = False
                Me.btnUnApproved.Enabled = False
                Me.DgvTrnTerimajasadetil.ReadOnly = True
                Me.DgvTrnTerimajasadetil.ContextMenuStrip = Nothing

                Me.tbtnPrint.Enabled = True
                Me.tbtnPrintPreview.Enabled = True

            Case clsLockingTransaction.LockStatus.LockedByMe
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.Btn_Add.Enabled = True
                Me.btn_order.Enabled = True
                Me.DgvTrnTerimajasadetil.ContextMenuStrip = ContextMenuStrip1

                Me.tbtnPrint.Enabled = True
                Me.tbtnPrintPreview.Enabled = True

            Case clsLockingTransaction.LockStatus.Open

        End Select
    End Sub

    Private Sub obj_Jurnal_bookdate_ValueChanged(sender As Object, e As EventArgs) Handles obj_Jurnal_bookdate.ValueChanged
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