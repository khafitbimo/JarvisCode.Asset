Public Class dlgDepresiasiNew

    'Private assetDSN As String
    Private frmDSN As String
    'Private startDSN As String
    Private channel_id As String
    Private channel_number As String
    Private username As String
    Private tbl_MstPeriode As DataTable = clsDataset.CreateTblMstPeriode
    Private tbl_MstKategoriAssetDepre As DataTable = clsDataset.CreateTblMstKategoriassetdepre()
    Private jurnal_id As String

    Sub New(ByVal channel_id As String, ByVal username As String, ByVal frmDSN As String)
        Me.InitializeComponent()
        ' Me.assetDSN = assetDSN
        Me.frmDSN = frmDSN
        'Me.startDSN = startDSN
        Me.channel_id = channel_id
        Me.username = username
    End Sub

    Public Function GetJurnalID() As String
        Return Me.jurnal_id
    End Function

    Private Sub dlgDepresiasiNew_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.obj_periode_id.Properties.DataSource = Me.tbl_MstPeriode
            Me.obj_periode_id.Properties.ValueMember = "periode_id"
            Me.obj_periode_id.Properties.DisplayMember = "periode_id"

            Me.obj_kategoriasset_depre.Properties.DataSource = Me.tbl_MstKategoriAssetDepre
            Me.obj_kategoriasset_depre.Properties.DisplayMember = "kategoriassetdepre_descr"
            Me.obj_kategoriasset_depre.Properties.ValueMember = "kategoriassetdepre_id"

            Me.Periode_Load()
            Me.KategoriDepre_Load()

            'Dim lastPeriode As Object = New clsTrnJurnal(Me.frmDSN).GetLastPeriodeDepre(Me.channel_id)

            'If lastPeriode IsNot DBNull.Value Then
            '    Dim currentDate As Date
            '    Dim tahun As Integer = Integer.Parse("20" & lastPeriode.Substring(2, 2))
            '    Dim bulan As Integer = Integer.Parse(lastPeriode.Substring(4, 2))
            '    Dim lastPeriodeDate As Date = New Date(tahun, bulan, 1)
            '    Dim currentPeriode As String

            '    channel_number = New clsMstChannel(Me.startDSN).Select(Me.channel_id).Item("channel_number")
            '    currentPeriode = Me.channel_number + lastPeriodeDate.AddMonths(1).ToString("yyMM")

            '    Me.obj_periode_id.EditValue = currentPeriode

            '    currentDate = New Date(tahun, bulan, 1).AddMonths(1)
            '    currentDate = New Date(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month))
            '    Me.obj_bookdate.DateTime = currentDate
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Periode_Load()
        Dim criteria As String

        Me.tbl_MstPeriode.Clear()

        criteria = String.Format("channel_id = '{0}' order by periode_id desc", Me.channel_id)

        Try
            Using period As New clsMstPeriod(Me.frmDSN)
                period.Retrieve(Me.tbl_MstPeriode, criteria)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub KategoriDepre_Load()
        Dim criteria As String

        Me.tbl_MstKategoriAssetDepre.Clear()

        criteria = ""

        Try
            Using receive As New clsTrnPenerimaanBarang(Me.frmDSN)
                receive.RetriveKategoriAssetDepre(Me.tbl_MstKategoriAssetDepre, criteria)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub obj_periode_id_EditValueChanged(sender As Object, e As EventArgs) Handles obj_periode_id.EditValueChanged
        Dim periode_id As String

        If obj_periode_id.EditValue IsNot DBNull.Value Then
            Dim jumlahBulan As Integer
            Dim year, month As Integer

            Try
                periode_id = obj_periode_id.Text

                If periode_id.Trim <> "" Then
                    year = Integer.Parse("20" + periode_id.Substring(2, 2))
                    month = Integer.Parse(periode_id.Substring(4, 2))

                    jumlahBulan = Date.DaysInMonth(year, month)

                    Me.obj_start.Text = 1
                    Me.obj_end.Text = jumlahBulan
                Else
                    Me.obj_start.Text = ""
                    Me.obj_end.Text = ""
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            Me.obj_start.Text = ""
            Me.obj_end.Text = ""
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Me.obj_periode_id.Text.Trim = "" Then
            MsgBox("Error")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            Using jurnal As New clsTrnJurnal()
                Me.jurnal_id = jurnal.CreateNewDepre(Me.channel_id,
                                                     Me.obj_periode_id.EditValue,
                                                     Me.obj_bookdate.DateTime.Date,
                                                     Me.username,
                                                     Me.obj_kategoriasset_depre.EditValue,
                                                     frmDSN)
            End Using

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
