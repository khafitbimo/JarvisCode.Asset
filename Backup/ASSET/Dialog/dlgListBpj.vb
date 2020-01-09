Imports System.Windows.Forms

Public Class dlgListBpj
    Private CloseButtonIsPressed As Boolean
    Private retTblTerimaJasa As DataTable = clsDataset.CreateTblTrnTerimabarang
    Private retTblTerimaJasa_temps As DataTable = clsDataset.CreateTblTrnTerimabarang

    Private dsn As String
    Private channel_id As String
    Private isJasa As String
    Private strukturunit_id As Decimal
    Private tops As Integer = 10000
    Private tbl_trnTerimaJasa As DataTable = clsDataset.CreateTblTrnTerimabarang()

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As DataTable
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = String.Empty
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)

        If Me.isJasa = "JASA" Then
            criteria = String.Format(" AND strukturunit_id_pemilik = {0} AND (terimabarang_status = 'NO RO' or terimabarang_status = 'NO MO')", Me.strukturunit_id)
            Me.Text = "BPJ No RO / No MO"
        Else
            criteria = String.Format(" AND strukturunit_id_pemilik = {0} AND terimabarang_status = 'NO PO'", Me.strukturunit_id)
            Me.Text = "BPB No PO"
        End If

        Me.tbl_trnTerimaJasa.Clear()
        oDataFiller.DataFill(Me.tbl_trnTerimaJasa, "as_TrnTerimabarang_Select", criteria, Me.channel_id, Me.tops)
        Me.DgvListBPJ.DataSource = Me.tbl_trnTerimaJasa
        Me.FormatDgvTrnTerimabarang(Me.DgvListBPJ)
        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.retTblTerimaJasa
        Else
            Return Nothing
        End If
    End Function
    Private Function FormatDgvTrnTerimabarang(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_tgl As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPa_ref As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appacc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_pemilik As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_pemilik As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAccounting_applogin As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAccounting_appdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appprc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProcurement_applogin As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProcurement_appdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_cetakbpb As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_cetakbkb As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_item As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cInputby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cInputdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUsedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUseddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appuser As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUser_applogin As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUser_appdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQty_mother As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStatus As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQty_po As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTipe As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_harga As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_disc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_valas As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_idrprice As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_insurancecost As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_transportationcost As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_operatorcost As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_othercost As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_appbma As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBma_applogin As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBma_appdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_jurnal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_login As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_posting As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPosting_login As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPosting_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLocation As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cNotes As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStatus_kedatangan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cSelect.Name = "select"
        cSelect.HeaderText = "Select"
        cSelect.DataPropertyName = "select"
        cSelect.Width = 50
        cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cSelect.Frozen = True
        cSelect.Visible = True
        cSelect.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = True

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "RV Number"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 130
        cTerimabarang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = True

        cTerimabarang_tgl.Name = "terimabarang_tgl"
        cTerimabarang_tgl.HeaderText = "Date"
        cTerimabarang_tgl.DataPropertyName = "terimabarang_tgl"
        cTerimabarang_tgl.Width = 100
        cTerimabarang_tgl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_tgl.Visible = True
        cTerimabarang_tgl.ReadOnly = True

        cTerimabarang_status.Name = "terimabarang_status"
        cTerimabarang_status.HeaderText = "terimabarang_status"
        cTerimabarang_status.DataPropertyName = "terimabarang_status"
        cTerimabarang_status.Width = 100
        cTerimabarang_status.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_status.Visible = False
        cTerimabarang_status.ReadOnly = True

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order No."
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = True

        cPa_ref.Name = "pa_ref"
        cPa_ref.HeaderText = "RV Ref. No."
        cPa_ref.DataPropertyName = "pa_ref"
        cPa_ref.Width = 100
        cPa_ref.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPa_ref.Visible = True
        cPa_ref.ReadOnly = True

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "rekanan_id"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = True

        cTerimabarang_appacc.Name = "terimabarang_appacc"
        cTerimabarang_appacc.HeaderText = "terimabarang_appacc"
        cTerimabarang_appacc.DataPropertyName = "terimabarang_appacc"
        cTerimabarang_appacc.Width = 100
        cTerimabarang_appacc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_appacc.Visible = False
        cTerimabarang_appacc.ReadOnly = True

        cEmployee_id_pemilik.Name = "employee_id_pemilik"
        cEmployee_id_pemilik.HeaderText = "employee_id_pemilik"
        cEmployee_id_pemilik.DataPropertyName = "employee_id_pemilik"
        cEmployee_id_pemilik.Width = 100
        cEmployee_id_pemilik.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_id_pemilik.Visible = False
        cEmployee_id_pemilik.ReadOnly = True

        cStrukturunit_id_pemilik.Name = "strukturunit_id_pemilik"
        cStrukturunit_id_pemilik.HeaderText = "strukturunit_id_pemilik"
        cStrukturunit_id_pemilik.DataPropertyName = "strukturunit_id_pemilik"
        cStrukturunit_id_pemilik.Width = 100
        cStrukturunit_id_pemilik.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStrukturunit_id_pemilik.Visible = False
        cStrukturunit_id_pemilik.ReadOnly = True

        cAccounting_applogin.Name = "accounting_applogin"
        cAccounting_applogin.HeaderText = "accounting_applogin"
        cAccounting_applogin.DataPropertyName = "accounting_applogin"
        cAccounting_applogin.Width = 100
        cAccounting_applogin.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAccounting_applogin.Visible = False
        cAccounting_applogin.ReadOnly = True

        cAccounting_appdt.Name = "accounting_appdt"
        cAccounting_appdt.HeaderText = "accounting_appdt"
        cAccounting_appdt.DataPropertyName = "accounting_appdt"
        cAccounting_appdt.Width = 100
        cAccounting_appdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAccounting_appdt.Visible = False
        cAccounting_appdt.ReadOnly = True

        cTerimabarang_appprc.Name = "terimabarang_appprc"
        cTerimabarang_appprc.HeaderText = "terimabarang_appprc"
        cTerimabarang_appprc.DataPropertyName = "terimabarang_appprc"
        cTerimabarang_appprc.Width = 100
        cTerimabarang_appprc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_appprc.Visible = False
        cTerimabarang_appprc.ReadOnly = True

        cProcurement_applogin.Name = "procurement_applogin"
        cProcurement_applogin.HeaderText = "procurement_applogin"
        cProcurement_applogin.DataPropertyName = "procurement_applogin"
        cProcurement_applogin.Width = 100
        cProcurement_applogin.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProcurement_applogin.Visible = False
        cProcurement_applogin.ReadOnly = True

        cProcurement_appdt.Name = "procurement_appdt"
        cProcurement_appdt.HeaderText = "procurement_appdt"
        cProcurement_appdt.DataPropertyName = "procurement_appdt"
        cProcurement_appdt.Width = 100
        cProcurement_appdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProcurement_appdt.Visible = False
        cProcurement_appdt.ReadOnly = True

        cTerimabarang_cetakbpb.Name = "terimabarang_cetakbpb"
        cTerimabarang_cetakbpb.HeaderText = "terimabarang_cetakbpb"
        cTerimabarang_cetakbpb.DataPropertyName = "terimabarang_cetakbpb"
        cTerimabarang_cetakbpb.Width = 100
        cTerimabarang_cetakbpb.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_cetakbpb.Visible = False
        cTerimabarang_cetakbpb.ReadOnly = True

        cTerimabarang_cetakbkb.Name = "terimabarang_cetakbkb"
        cTerimabarang_cetakbkb.HeaderText = "terimabarang_cetakbkb"
        cTerimabarang_cetakbkb.DataPropertyName = "terimabarang_cetakbkb"
        cTerimabarang_cetakbkb.Width = 100
        cTerimabarang_cetakbkb.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_cetakbkb.Visible = False
        cTerimabarang_cetakbkb.ReadOnly = True

        cTerimabarang_item.Name = "terimabarang_item"
        cTerimabarang_item.HeaderText = "terimabarang_item"
        cTerimabarang_item.DataPropertyName = "terimabarang_item"
        cTerimabarang_item.Width = 100
        cTerimabarang_item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_item.Visible = False
        cTerimabarang_item.ReadOnly = True

        cInputby.Name = "inputby"
        cInputby.HeaderText = "inputby"
        cInputby.DataPropertyName = "inputby"
        cInputby.Width = 100
        cInputby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cInputby.Visible = False
        cInputby.ReadOnly = True

        cInputdt.Name = "inputdt"
        cInputdt.HeaderText = "inputdt"
        cInputdt.DataPropertyName = "inputdt"
        cInputdt.Width = 100
        cInputdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cInputdt.Visible = False
        cInputdt.ReadOnly = True

        cEditby.Name = "editby"
        cEditby.HeaderText = "editby"
        cEditby.DataPropertyName = "editby"
        cEditby.Width = 100
        cEditby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditby.Visible = False
        cEditby.ReadOnly = True

        cEditdt.Name = "editdt"
        cEditdt.HeaderText = "editdt"
        cEditdt.DataPropertyName = "editdt"
        cEditdt.Width = 100
        cEditdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditdt.Visible = False
        cEditdt.ReadOnly = True

        cUsedby.Name = "usedby"
        cUsedby.HeaderText = "usedby"
        cUsedby.DataPropertyName = "usedby"
        cUsedby.Width = 100
        cUsedby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUsedby.Visible = False
        cUsedby.ReadOnly = True

        cUseddt.Name = "useddt"
        cUseddt.HeaderText = "useddt"
        cUseddt.DataPropertyName = "useddt"
        cUseddt.Width = 100
        cUseddt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUseddt.Visible = False
        cUseddt.ReadOnly = True

        cTerimabarang_appuser.Name = "terimabarang_appuser"
        cTerimabarang_appuser.HeaderText = "terimabarang_appuser"
        cTerimabarang_appuser.DataPropertyName = "terimabarang_appuser"
        cTerimabarang_appuser.Width = 100
        cTerimabarang_appuser.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_appuser.Visible = False
        cTerimabarang_appuser.ReadOnly = True

        cUser_applogin.Name = "user_applogin"
        cUser_applogin.HeaderText = "user_applogin"
        cUser_applogin.DataPropertyName = "user_applogin"
        cUser_applogin.Width = 100
        cUser_applogin.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUser_applogin.Visible = False
        cUser_applogin.ReadOnly = True

        cUser_appdt.Name = "user_appdt"
        cUser_appdt.HeaderText = "user_appdt"
        cUser_appdt.DataPropertyName = "user_appdt"
        cUser_appdt.Width = 100
        cUser_appdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUser_appdt.Visible = False
        cUser_appdt.ReadOnly = False

        cQty_mother.Name = "qty_mother"
        cQty_mother.HeaderText = "qty_mother"
        cQty_mother.DataPropertyName = "qty_mother"
        cQty_mother.Width = 100
        cQty_mother.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cQty_mother.Visible = False
        cQty_mother.ReadOnly = True

        cStatus.Name = "status"
        cStatus.HeaderText = "status"
        cStatus.DataPropertyName = "status"
        cStatus.Width = 100
        cStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStatus.Visible = False
        cStatus.ReadOnly = True

        cQty_po.Name = "qty_po"
        cQty_po.HeaderText = "qty_po"
        cQty_po.DataPropertyName = "qty_po"
        cQty_po.Width = 100
        cQty_po.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cQty_po.Visible = False
        cQty_po.ReadOnly = True

        cTipe.Name = "type"
        cTipe.HeaderText = "type"
        cTipe.DataPropertyName = "type"
        cTipe.Width = 100
        cTipe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTipe.Visible = False
        cTipe.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = True

        cAsset_harga.Name = "asset_harga"
        cAsset_harga.HeaderText = "asset_harga"
        cAsset_harga.DataPropertyName = "asset_harga"
        cAsset_harga.Width = 100
        cAsset_harga.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_harga.Visible = False
        cAsset_harga.ReadOnly = True

        cAsset_ppn.Name = "asset_ppn"
        cAsset_ppn.HeaderText = "asset_ppn"
        cAsset_ppn.DataPropertyName = "asset_ppn"
        cAsset_ppn.Width = 100
        cAsset_ppn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_ppn.Visible = False
        cAsset_ppn.ReadOnly = True

        cAsset_pph.Name = "asset_pph"
        cAsset_pph.HeaderText = "asset_pph"
        cAsset_pph.DataPropertyName = "asset_pph"
        cAsset_pph.Width = 100
        cAsset_pph.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_pph.Visible = False
        cAsset_pph.ReadOnly = True

        cAsset_disc.Name = "asset_disc"
        cAsset_disc.HeaderText = "asset_disc"
        cAsset_disc.DataPropertyName = "asset_disc"
        cAsset_disc.Width = 100
        cAsset_disc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_disc.Visible = False
        cAsset_disc.ReadOnly = True

        cAsset_valas.Name = "asset_valas"
        cAsset_valas.HeaderText = "asset_valas"
        cAsset_valas.DataPropertyName = "asset_valas"
        cAsset_valas.Width = 100
        cAsset_valas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_valas.Visible = False
        cAsset_valas.ReadOnly = True

        cAsset_idrprice.Name = "asset_idrprice"
        cAsset_idrprice.HeaderText = "asset_idrprice"
        cAsset_idrprice.DataPropertyName = "asset_idrprice"
        cAsset_idrprice.Width = 100
        cAsset_idrprice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_idrprice.Visible = False
        cAsset_idrprice.ReadOnly = True

        cOrder_insurancecost.Name = "order_insurancecost"
        cOrder_insurancecost.HeaderText = "order_insurancecost"
        cOrder_insurancecost.DataPropertyName = "order_insurancecost"
        cOrder_insurancecost.Width = 100
        cOrder_insurancecost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_insurancecost.Visible = False
        cOrder_insurancecost.ReadOnly = True

        cOrder_transportationcost.Name = "order_transportationcost"
        cOrder_transportationcost.HeaderText = "order_transportationcost"
        cOrder_transportationcost.DataPropertyName = "order_transportationcost"
        cOrder_transportationcost.Width = 100
        cOrder_transportationcost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_transportationcost.Visible = False
        cOrder_transportationcost.ReadOnly = True

        cOrder_operatorcost.Name = "order_operatorcost"
        cOrder_operatorcost.HeaderText = "order_operatorcost"
        cOrder_operatorcost.DataPropertyName = "order_operatorcost"
        cOrder_operatorcost.Width = 100
        cOrder_operatorcost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_operatorcost.Visible = False
        cOrder_operatorcost.ReadOnly = True

        cOrder_othercost.Name = "order_othercost"
        cOrder_othercost.HeaderText = "order_othercost"
        cOrder_othercost.DataPropertyName = "order_othercost"
        cOrder_othercost.Width = 100
        cOrder_othercost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_othercost.Visible = False
        cOrder_othercost.ReadOnly = True

        cTerimabarang_appbma.Name = "terimabarang_appbma"
        cTerimabarang_appbma.HeaderText = "terimabarang_appbma"
        cTerimabarang_appbma.DataPropertyName = "terimabarang_appbma"
        cTerimabarang_appbma.Width = 100
        cTerimabarang_appbma.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_appbma.Visible = False
        cTerimabarang_appbma.ReadOnly = True

        cBma_applogin.Name = "bma_applogin"
        cBma_applogin.HeaderText = "bma_applogin"
        cBma_applogin.DataPropertyName = "bma_applogin"
        cBma_applogin.Width = 100
        cBma_applogin.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBma_applogin.Visible = False
        cBma_applogin.ReadOnly = True

        cBma_appdt.Name = "bma_appdt"
        cBma_appdt.HeaderText = "bma_appdt"
        cBma_appdt.DataPropertyName = "bma_appdt"
        cBma_appdt.Width = 100
        cBma_appdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBma_appdt.Visible = False
        cBma_appdt.ReadOnly = True

        cTerimabarang_jurnal.Name = "terimabarang_jurnal"
        cTerimabarang_jurnal.HeaderText = "terimabarang_jurnal"
        cTerimabarang_jurnal.DataPropertyName = "terimabarang_jurnal"
        cTerimabarang_jurnal.Width = 100
        cTerimabarang_jurnal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_jurnal.Visible = False
        cTerimabarang_jurnal.ReadOnly = True

        cJurnal_login.Name = "jurnal_login"
        cJurnal_login.HeaderText = "jurnal_login"
        cJurnal_login.DataPropertyName = "jurnal_login"
        cJurnal_login.Width = 100
        cJurnal_login.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_login.Visible = False
        cJurnal_login.ReadOnly = True

        cJurnal_dt.Name = "jurnal_dt"
        cJurnal_dt.HeaderText = "jurnal_dt"
        cJurnal_dt.DataPropertyName = "jurnal_dt"
        cJurnal_dt.Width = 100
        cJurnal_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_dt.Visible = False
        cJurnal_dt.ReadOnly = True

        cTerimabarang_posting.Name = "terimabarang_posting"
        cTerimabarang_posting.HeaderText = "terimabarang_posting"
        cTerimabarang_posting.DataPropertyName = "terimabarang_posting"
        cTerimabarang_posting.Width = 100
        cTerimabarang_posting.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_posting.Visible = False
        cTerimabarang_posting.ReadOnly = True

        cPosting_login.Name = "posting_login"
        cPosting_login.HeaderText = "posting_login"
        cPosting_login.DataPropertyName = "posting_login"
        cPosting_login.Width = 100
        cPosting_login.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPosting_login.Visible = False
        cPosting_login.ReadOnly = True

        cPosting_dt.Name = "posting_dt"
        cPosting_dt.HeaderText = "posting_dt"
        cPosting_dt.DataPropertyName = "posting_dt"
        cPosting_dt.Width = 100
        cPosting_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPosting_dt.Visible = False
        cPosting_dt.ReadOnly = True

        cLocation.Name = "location"
        cLocation.HeaderText = "Location"
        cLocation.DataPropertyName = "location"
        cLocation.Width = 100
        cLocation.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLocation.Visible = True
        cLocation.ReadOnly = True

        cNotes.Name = "notes"
        cNotes.HeaderText = "Notes"
        cNotes.DataPropertyName = "notes"
        cNotes.Width = 100
        cNotes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cNotes.Visible = True
        cNotes.ReadOnly = True

        cStatus_kedatangan.Name = "status_kedatangan"
        cStatus_kedatangan.HeaderText = "status_kedatangan"
        cStatus_kedatangan.DataPropertyName = "status_kedatangan"
        cStatus_kedatangan.Width = 100
        cStatus_kedatangan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStatus_kedatangan.Visible = False
        cStatus_kedatangan.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cSelect, cChannel_id, cTerimabarang_id, cTerimabarang_tgl, cTerimabarang_status, cOrder_id, cPa_ref, cRekanan_id, cTerimabarang_appacc, cEmployee_id_pemilik, cStrukturunit_id_pemilik, cAccounting_applogin, cAccounting_appdt, cTerimabarang_appprc, cProcurement_applogin, cProcurement_appdt, cTerimabarang_cetakbpb, cTerimabarang_cetakbkb, cTerimabarang_item, cInputby, cInputdt, cEditby, cEditdt, cUsedby, cUseddt, cTerimabarang_appuser, cUser_applogin, cUser_appdt, cQty_mother, cStatus, cQty_po, cTipe, cCurrency_id, cAsset_harga, cAsset_ppn, cAsset_pph, cAsset_disc, cAsset_valas, cAsset_idrprice, cOrder_insurancecost, cOrder_transportationcost, cOrder_operatorcost, cOrder_othercost, cTerimabarang_appbma, cBma_applogin, cBma_appdt, cTerimabarang_jurnal, cJurnal_login, cJurnal_dt, cTerimabarang_posting, cPosting_login, cPosting_dt, cLocation, cNotes, cStatus_kedatangan})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim i As Integer
        Dim count_dgv As Integer
        Dim col As Integer
        Dim columnName As String
        Dim row As DataRow

        count_dgv = Me.DgvListBPJ.Rows.Count - 1

        For i = 0 To count_dgv
            If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("select").Value, False) = True Then
                row = retTblTerimaJasa_temps.NewRow
                For col = 0 To tbl_trnTerimaJasa.Columns.Count - 3
                    columnName = tbl_trnTerimaJasa.Columns(col).ColumnName
                    If columnName <> "select" Then
                        row(columnName) = tbl_trnTerimaJasa.Rows(i).Item(columnName)
                    End If
                Next
                Me.retTblTerimaJasa_temps.Rows.Add(row)
            End If
        Next
        retTblTerimaJasa = retTblTerimaJasa_temps

        Me.CloseButtonIsPressed = True
        'desc = Me.TextBox1.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal channel_id As String, ByVal strukturunit_id As Decimal, _
                ByVal isJasa As String)
        Me.dsn = strDSN
        Me.channel_id = channel_id
        Me.strukturunit_id = strukturunit_id
        Me.isJasa = isJasa

        InitializeComponent()
    End Sub

    Private Sub DgvListBPJ_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvListBPJ.CellClick
        Dim i As Integer

        For i = 0 To Me.DgvListBPJ.Rows.Count - 1
            If i <> e.RowIndex Then
                Me.DgvListBPJ.Rows(i).Cells("select").Value = False
            End If
        Next
    End Sub
End Class
