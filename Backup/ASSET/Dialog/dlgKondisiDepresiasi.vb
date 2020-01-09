
Public Class dlgKondisiDepresiasi
    Private DSN As String
    Private strCriteria As String
    Private tbl_mstKategoriAsset As DataTable = clsDataset.CreateTblMstKategoriasset
    Private tbl_mstRuang As DataTable = clsDataset.CreateTblMstRuang
    Private CloseButtonIsPressed As Boolean
    Private retCriteria As String
    Private criteria As String = ""
    Private txtSearchCriteria As String = ""
    Private txtCondition As String = ""
    Private txtConditionRekap As String = String.Empty

    Public Sub New(ByVal sDSN As String)

        ' This call is required by the Windows Form Designer.
        Me.DSN = sDSN
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim obj As Button = sender

        If obj.Name = "OK_Button" Then
            If chkSearchBulan.Checked = False And chkSearchTahun.Checked = False And chkSearchCategory.Checked = False Then
                MsgBox("Minimal 1 cek list untuk melakukan print preview", MsgBoxStyle.Critical, "ERRORs")
                Exit Sub
            End If
            Me.cek_kondisi()
            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cek_kondisi()
        
        Try

            '-- Bulan
            If Me.chkSearchBulan.Checked Then
                txtSearchCriteria = String.Format(" depresiasi_bln = {0} ", Me.cboSearchbulan.Value)
                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                    txtConditionRekap = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                    txtConditionRekap = txtConditionRekap & " AND " & " (" & txtSearchCriteria & ") "
                End If
            End If

            '-- Tahun
            If Me.chkSearchTahun.Checked Then
                txtSearchCriteria = String.Format(" depresiasi_thn = {0} ", Me.cboSearchtahun.Value)
                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                    txtConditionRekap = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                    txtConditionRekap = txtConditionRekap & " AND " & " (" & txtSearchCriteria & ") "
                End If
            End If

            '-- Per Kategori
            If Me.chkSearchCategory.Checked Then
                txtSearchCriteria = String.Format(" kategoriasset_id = '{0}' ", Me.cboSearchkategori.SelectedValue)
                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition = txtCondition & " AND " & " (" & txtSearchCriteria & ") "
                End If
            End If

            '-- per Location
            If Me.chkSearchLocation.Checked = True Then
                txtSearchCriteria = String.Format(" location = '{0}' ", Me.cboSearchLocation.SelectedValue)
                If txtCondition = "" Then
                    txtCondition = " (" & txtSearchCriteria & ") "
                Else
                    txtCondition &= " AND (" & txtSearchCriteria & ") "
                End If
            End If

            If chkPrint_Rekapitulasi.Checked = True Then
                retCriteria = String.Empty
            ElseIf chkPrint_RekapitulasiMonth.Checked = True Then
                retCriteria = txtConditionRekap
            Else
                retCriteria = txtCondition
            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As String
        Dim mDtFiller As clsDataFiller
        Dim mDFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        Try
            mDtFiller = New clsDataFiller(Me.DSN)
            mDtFiller.ComboFill(Me.cboSearchkategori, "kategoriasset_id", "kategoriasset_id", Me.tbl_mstKategoriAsset, "as_MstKategoriasset_Select", "  ")
            Me.tbl_mstKategoriAsset.DefaultView.Sort = "kategoriasset_id"

            mDtFiller.ComboFill(Me.cboSearchLocation, "wilayah_name", "wilayah_name", Me.tbl_mstRuang, "as_MstRuang_SelectLocation", "TTV")
            Me.tbl_mstRuang.DefaultView.Sort = "wilayah_name"

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            mDtFiller = Nothing
        End Try

        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.retCriteria
        Else
            Return Nothing
        End If
    End Function

    Private Sub chkPrint_Rekapitulasi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrint_Rekapitulasi.CheckedChanged
        If Me.chkPrint_Rekapitulasi.Checked = True Then
            Me.chkPrint_RekapitulasiMonth.Checked = False
        End If
    End Sub

    Private Sub chkPrint_RekapitulasiMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrint_RekapitulasiMonth.CheckedChanged
        If Me.chkPrint_RekapitulasiMonth.Checked = True Then
            Me.chkPrint_Rekapitulasi.Checked = False
        End If
    End Sub

    Private Sub chkSearchCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchCategory.CheckedChanged
        If Me.chkSearchCategory.Checked = True Then
            Me.chkSearchLocation.Checked = False
        End If
    End Sub

    Private Sub chkSearchLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchLocation.CheckedChanged
        If Me.chkSearchLocation.Checked = True Then
            Me.chkSearchCategory.Checked = False
        End If
    End Sub
End Class
