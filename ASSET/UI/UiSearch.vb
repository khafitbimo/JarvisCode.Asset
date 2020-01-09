Public Class UiSearch
    Private tbl_mstKategoriitem As DataTable = clsDataset.CreateTblMstKategoriitem
    Private tbl_msttipeitem As DataTable = clsDataset.CreateTblMstTipeitem

    Private tbl_seacrh As DataTable = New DataTable

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
        End If

        Me.InitLayoutUI()
        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Or (tsItem.Name <> "tbtnLoad") Then
                tsItem.Visible = False
            End If
        Next
        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then

        '    Dim dummyparameter As String = "CHANNEL=TTV;"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
        'End If

        Me.DgvSearch.DataSource = Me.tbl_seacrh
        Me.ComboFill(Me.cboSearchKategori, "kategoriitem_id", "kategoriitem_id", Me.tbl_mstKategoriitem, "as_MstKategoriitem_Select", "  ")
        Me.tbl_mstKategoriitem.DefaultView.Sort = "kategoriitem_id"

        Me.ComboFill(Me.cboSearchType, "tipeitem_id", "tipeitem_id", Me.tbl_msttipeitem, "as_MstTipeitem_Select", "  ")
        Me.tbl_msttipeitem.DefaultView.Sort = "tipeitem_id"

        Me.cboSearchKategori.SelectedValue = 0
        Me.cboSearchType.SelectedValue = 0

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = False
        Me.tbtnNew.Enabled = False
        Me.tbtnFirst.Enabled = False
        Me.tbtnPrev.Enabled = False
        Me.tbtnNext.Enabled = False
        Me.tbtnLast.Enabled = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False
    End Sub



    Private Sub UiSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If

    End Sub

#Region " Layout & Init UI "
    Private Function InitLayoutUI() As Boolean
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfMain.Dock = DockStyle.Fill
        FormatDgvSearch(Me.DgvSearch)
    End Function
#End Region

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiSearch_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Private Function uiSearch_Retrieve() As Boolean
        Dim criteria As String = String.Empty
        Dim awal As Date
        Dim akhir As Date

        If Me.ObjSearchTanggalAwal.Text = "  /  /" Or Me.ObjSearchTanggalAkhir.Text = "  /  /" Then
            Exit Function
        End If

        If chkSearchKategori.Checked = True Then
            If criteria = String.Empty Then
                criteria = String.Format(" kategoriitem_id = '{0}'", Me.cboSearchKategori.SelectedValue)
            Else
                criteria &= String.Format(" and kategoriitem_id = '{0}'", Me.cboSearchKategori.SelectedValue)
            End If
        End If

        If chkSearchType.Checked = True Then
            If criteria = String.Empty Then
                criteria = String.Format(" tipeitem_id = '{0}'", Me.cboSearchType.SelectedValue)
            Else
                criteria &= String.Format(" and tipeitem_id = '{0}'", Me.cboSearchType.SelectedValue)
            End If
        End If

        If chkSearchTanggalAwal.Checked = True Then
            If Len(Me.ObjSearchTanggalAwal.Text) = 10 Then

                Dim stTgl, stBln As Integer
                stTgl = Mid(Me.ObjSearchTanggalAwal.Text, 1, 2)
                stBln = Mid(Me.ObjSearchTanggalAwal.Text, 4, 2)

                If stTgl > 31 Then
                    MsgBox("Wrong date in start date")
                    Exit Function
                ElseIf stBln > 12 Then
                    MsgBox("Wrong month in start date")
                    Exit Function
                Else
                    awal = Me.ObjSearchTanggalAwal.Text
                    If criteria = String.Empty Then
                        criteria = String.Format(" tgl >= '{0}'", Format(awal, "yyyy-MM-dd"))
                    Else
                        criteria &= String.Format(" AND tgl >= '{0}'", Format(awal, "yyyy-MM-dd"))
                    End If
                End If
            Else
                MsgBox("Wrong format start date")
                Exit Function
            End If
        End If

        If chkSearchTanggalAkhir.Checked = True Then

            If Len(Me.ObjSearchTanggalAkhir.Text) = 10 Then

                Dim edTgl, edBln As Integer
                edTgl = Mid(Me.ObjSearchTanggalAkhir.Text, 1, 2)
                edBln = Mid(Me.ObjSearchTanggalAkhir.Text, 4, 2)

                If edTgl > 31 Then
                    MsgBox("Wrong date in end date")
                    Exit Function
                ElseIf edBln > 12 Then
                    MsgBox("Wrong month in end date")
                    Exit Function
                Else
                    akhir = Me.ObjSearchTanggalAkhir.Text
                    If criteria = String.Empty Then
                        criteria = String.Format(" tgl <= '{0}'", Format(akhir, "yyyy-MM-dd"))
                    Else
                        criteria &= String.Format(" AND tgl <= '{0}'", Format(akhir, "yyyy-MM-dd"))
                    End If
                End If
            Else
                MsgBox("Wrong format end date")
                Exit Function
            End If
        End If
        Me.tbl_seacrh.Clear()
        Try
            Me.DataFillKhusus(Me.tbl_seacrh, "as_MstSearch_Select", awal, akhir, criteria)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function FormatDgvSearch(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format FormatDgvSearch Columns 
        Dim cLogasset_Tanggal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_Status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLogasset_Notrans As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_Barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBrand_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTipeitem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_deskripsi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cLogasset_Tanggal.Name = "tgl"
        cLogasset_Tanggal.HeaderText = "Tanggal"
        cLogasset_Tanggal.DataPropertyName = "tgl"
        cLogasset_Tanggal.Width = 80
        cLogasset_Tanggal.Visible = True
        cLogasset_Tanggal.ReadOnly = False

        cAsset_Status.Name = "status"
        cAsset_Status.HeaderText = "Status"
        cAsset_Status.DataPropertyName = "status"
        cAsset_Status.Width = 80
        cAsset_Status.Visible = True
        cAsset_Status.ReadOnly = False

        cLogasset_Notrans.Name = "no_trans"
        cLogasset_Notrans.HeaderText = "No. Transaksi"
        cLogasset_Notrans.DataPropertyName = "no_trans"
        cLogasset_Notrans.Width = 150
        cLogasset_Notrans.Visible = True
        cLogasset_Notrans.ReadOnly = False

        cAsset_Barcode.Name = "asset_Barcode"
        cAsset_Barcode.HeaderText = "Barcode"
        cAsset_Barcode.DataPropertyName = "asset_Barcode"
        cAsset_Barcode.Width = 105
        cAsset_Barcode.Visible = True
        cAsset_Barcode.ReadOnly = False

        cBrand_id_string.Name = "brand_id_string"
        cBrand_id_string.HeaderText = "Brand"
        cBrand_id_string.DataPropertyName = "brand_id_string"
        cBrand_id_string.Width = 150
        cBrand_id_string.Visible = True
        cBrand_id_string.ReadOnly = False

        cTipeitem_id.Name = "tipeitem_id"
        cTipeitem_id.HeaderText = "Type"
        cTipeitem_id.DataPropertyName = "tipeitem_id"
        cTipeitem_id.Width = 150
        cTipeitem_id.Visible = True
        cTipeitem_id.ReadOnly = False

        cAsset_deskripsi.Name = "asset_deskripsi"
        cAsset_deskripsi.HeaderText = "Description"
        cAsset_deskripsi.DataPropertyName = "asset_deskripsi"
        cAsset_deskripsi.Width = 150
        cAsset_deskripsi.Visible = True
        cAsset_deskripsi.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cLogasset_Tanggal, cAsset_Status, cLogasset_Notrans, cAsset_Barcode, _
        cBrand_id_string, cTipeitem_id, cAsset_deskripsi})

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

    Private Sub DgvSearch_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvSearch.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If objrow.Cells("no_trans").Value Is DBNull.Value And objrow.Cells("status").Value = "AVL" Then
                objrow.DefaultCellStyle.BackColor = Color.PapayaWhip
            ElseIf objrow.Cells("no_trans").Value IsNot DBNull.Value And objrow.Cells("status").Value = "AVL" Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            ElseIf objrow.Cells("no_trans").Value IsNot DBNull.Value And objrow.Cells("status").Value = "NVL" Then
                objrow.DefaultCellStyle.BackColor = Color.Aqua
            Else
                objrow.DefaultCellStyle.BackColor = Color.PowderBlue
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkSearchTanggalAwal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchTanggalAwal.CheckedChanged
        If chkSearchTanggalAwal.Checked = True Then
            chkSearchTanggalAkhir.Checked = True
            Me.ObjSearchTanggalAwal.Enabled = True
            Me.ObjSearchTanggalAkhir.Enabled = True
        Else
            chkSearchTanggalAkhir.Checked = False
            Me.ObjSearchTanggalAwal.Enabled = False
            Me.ObjSearchTanggalAkhir.Enabled = False
        End If
    End Sub

    Private Sub chkSearchTanggalAkhir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchTanggalAkhir.CheckedChanged
        If chkSearchTanggalAkhir.Checked = True Then
            chkSearchTanggalAwal.Checked = True
            Me.ObjSearchTanggalAwal.Enabled = True
            Me.ObjSearchTanggalAkhir.Enabled = True
        Else
            chkSearchTanggalAwal.Checked = False
            Me.ObjSearchTanggalAwal.Enabled = False
            Me.ObjSearchTanggalAkhir.Enabled = False
        End If
    End Sub

    Private Sub chkSearchKategori_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchKategori.CheckedChanged
        If chkSearchKategori.Checked = True Then
            Me.cboSearchKategori.Enabled = True
            Me.cboSearchKategori.SelectedValue = 0
        Else
            Me.cboSearchKategori.Enabled = False
        End If
    End Sub

    Private Sub chkSearchType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchType.CheckedChanged
        If chkSearchType.Checked = True Then
            Me.cboSearchType.Enabled = True
            Me.cboSearchType.SelectedValue = 0
        Else
            Me.cboSearchType.Enabled = False
        End If
    End Sub
End Class
