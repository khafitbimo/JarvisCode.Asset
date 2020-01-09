Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptPenerimaanBarangDetil
        Private DSN As String
        Private AssetDSN As String
        Private mTerimabarang_id As String
        Private mTerimabarangdetil_line As Int32
        Private mTerimabarangdetil_parentline As Int32
        Private mTerimabarangdetil_desc As String
        Private mTerimabarangdetil_date As DateTime
        Private mTerimabarangdetil_type As String
        Private mAssetcategory_id As String
        Private mAssettype_id As String
        Private mTerimabarang_barcode As String
        Private mTerimabarang_parentbarcode As String
        Private mItem_id As String
        Private mItemcategory_id As String
        Private mItemtype_id As String
        Private mBrand_id As Decimal
        Private mBrand_name As String
        Private mTerimabarangdetil_serial_no As String
        Private mTerimabarangdetil_product_no As String
        Private mTerimabarangdetil_model As String
        Private mMaterial_id As String
        Private mColour_id As String
        Private mSize_id As String
        Private mSex_id As String
        Private mRoom_id As String
        Private mRoom_name As String
        Private mTerimabarangdetil_rack As String
        'Private mTerimabarangdetil_qty As Int32
        Private mTerimabarangdetil_qty As Decimal
        Private mUnit_id As Decimal
        Private mCurrency_id As Decimal
        Private mTerimabarangdetil_foreign As Decimal
        Private mTerimabarangdetil_foreignrate As Decimal
        Private mTerimabarangdetil_idrreal As Decimal
        Private mTerimabarangdetil_pphpercent As Decimal
        Private mTerimabarangdetil_ppnpercent As Decimal
        Private mTerimabarangdetil_disc As Decimal
        Private mTerimabarangdetil_pphforeign As Decimal
        Private mTerimabarangdetil_pphidrreal As Decimal
        Private mTerimabarangdetil_ppnforeign As Decimal
        Private mTerimabarangdetil_ppnidrreal As Decimal
        Private mTerimabarangdetil_totalforeign As Decimal
        Private mTerimabarangdetil_totalidrreal As Decimal
        Private mTerimabarangdetil_nonfixasset As Byte
        Private mTerimabarangdetil_golfiskal As String
        Private mTerimabarangdetil_depre_enddt As DateTime
        Private mEmployee_id As String
        Private mStrukturunit_id As Decimal
        Private mShow_id As String
        Private mShow_id_cont As String
        Private mTerimabarangdetil_eps As String
        Private mWriteoff_id As String
        Private mWriteoff_dt As DateTime
        Private mOrder_id As String
        Private mOrderdetil_line As Int32
        Private mBudget_id As Decimal
        Private mBudgetdetil_id As Decimal
        Private mAcc_id As String
        Private mChannel_id As String
        Private mCreate_by As String
        Private mCreate_dt As DateTime
        Private mModified_by As String
        Private mModified_dt As DateTime

        Public Property terimabarang_id() As String
            Get
                Return mTerimabarang_id
            End Get
            Set(ByVal value As String)
                mTerimabarang_id = value
            End Set
        End Property

        Public Property terimabarangdetil_line() As Int32
            Get
                Return mTerimabarangdetil_line
            End Get
            Set(ByVal value As Int32)
                mTerimabarangdetil_line = value
            End Set
        End Property

        Public Property terimabarangdetil_parentline() As Int32
            Get
                Return mTerimabarangdetil_parentline
            End Get
            Set(ByVal value As Int32)
                mTerimabarangdetil_parentline = value
            End Set
        End Property

        Public Property terimabarangdetil_desc() As String
            Get
                Return mTerimabarangdetil_desc
            End Get
            Set(ByVal value As String)
                mTerimabarangdetil_desc = value
            End Set
        End Property

        Public Property terimabarangdetil_date() As DateTime
            Get
                Return mTerimabarangdetil_date
            End Get
            Set(ByVal value As DateTime)
                mTerimabarangdetil_date = value
            End Set
        End Property

        Public Property terimabarangdetil_type() As String
            Get
                Return mTerimabarangdetil_type
            End Get
            Set(ByVal value As String)
                mTerimabarangdetil_type = value
            End Set
        End Property

        Public Property assetcategory_id() As String
            Get
                Return mAssetcategory_id
            End Get
            Set(ByVal value As String)
                mAssetcategory_id = value
            End Set
        End Property

        Public Property assettype_id() As String
            Get
                Return mAssettype_id
            End Get
            Set(ByVal value As String)
                mAssettype_id = value
            End Set
        End Property

        Public Property terimabarang_barcode() As String
            Get
                Return mTerimabarang_barcode
            End Get
            Set(ByVal value As String)
                mTerimabarang_barcode = value
            End Set
        End Property

        Public Property terimabarang_parentbarcode() As String
            Get
                Return mTerimabarang_parentbarcode
            End Get
            Set(ByVal value As String)
                mTerimabarang_parentbarcode = value
            End Set
        End Property

        Public Property item_id() As String
            Get
                Return mItem_id
            End Get
            Set(ByVal value As String)
                mItem_id = value
            End Set
        End Property

        Public Property itemcategory_id() As String
            Get
                Return mItemcategory_id
            End Get
            Set(ByVal value As String)
                mItemcategory_id = value
            End Set
        End Property

        Public Property itemtype_id() As String
            Get
                Return mItemtype_id
            End Get
            Set(ByVal value As String)
                mItemtype_id = value
            End Set
        End Property

        Public Property brand_id() As Decimal
            Get
                Return mBrand_id
            End Get
            Set(ByVal value As Decimal)
                mBrand_id = value
            End Set
        End Property
        Public Property brand_name() As String
            Get
                Return mBrand_name
            End Get
            Set(ByVal value As String)
                mBrand_name = value
            End Set
        End Property

        Public Property terimabarangdetil_serial_no() As String
            Get
                Return mTerimabarangdetil_serial_no
            End Get
            Set(ByVal value As String)
                mTerimabarangdetil_serial_no = value
            End Set
        End Property

        Public Property terimabarangdetil_product_no() As String
            Get
                Return mTerimabarangdetil_product_no
            End Get
            Set(ByVal value As String)
                mTerimabarangdetil_product_no = value
            End Set
        End Property

        Public Property terimabarangdetil_model() As String
            Get
                Return mTerimabarangdetil_model
            End Get
            Set(ByVal value As String)
                mTerimabarangdetil_model = value
            End Set
        End Property

        Public Property material_id() As String
            Get
                Return mMaterial_id
            End Get
            Set(ByVal value As String)
                mMaterial_id = value
            End Set
        End Property

        Public Property colour_id() As String
            Get
                Return mColour_id
            End Get
            Set(ByVal value As String)
                mColour_id = value
            End Set
        End Property

        Public Property size_id() As String
            Get
                Return mSize_id
            End Get
            Set(ByVal value As String)
                mSize_id = value
            End Set
        End Property

        Public Property sex_id() As String
            Get
                Return mSex_id
            End Get
            Set(ByVal value As String)
                mSex_id = value
            End Set
        End Property

        Public Property room_id() As String
            Get
                Return mRoom_id
            End Get
            Set(ByVal value As String)
                mRoom_id = value
            End Set
        End Property
        Public Property room_name() As String
            Get
                Return mRoom_name
            End Get
            Set(ByVal value As String)
                mRoom_name = value
            End Set
        End Property

        Public Property terimabarangdetil_rack() As String
            Get
                Return mTerimabarangdetil_rack
            End Get
            Set(ByVal value As String)
                mTerimabarangdetil_rack = value
            End Set
        End Property

        'Public Property terimabarangdetil_qty() As Int32
        '    Get
        '        Return mTerimabarangdetil_qty
        '    End Get
        '    Set(ByVal value As Int32)
        '        mTerimabarangdetil_qty = value
        '    End Set
        'End Property

        Public Property terimabarangdetil_qty() As Decimal
            Get
                Return mTerimabarangdetil_qty
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_qty = value
            End Set
        End Property

        Public Property unit_id() As Decimal
            Get
                Return mUnit_id
            End Get
            Set(ByVal value As Decimal)
                mUnit_id = value
            End Set
        End Property

        Public Property currency_id() As Decimal
            Get
                Return mCurrency_id
            End Get
            Set(ByVal value As Decimal)
                mCurrency_id = value
            End Set
        End Property

        Public Property terimabarangdetil_foreign() As Decimal
            Get
                Return mTerimabarangdetil_foreign
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_foreign = value
            End Set
        End Property

        Public Property terimabarangdetil_foreignrate() As Decimal
            Get
                Return mTerimabarangdetil_foreignrate
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_foreignrate = value
            End Set
        End Property

        Public Property terimabarangdetil_idrreal() As Decimal
            Get
                Return mTerimabarangdetil_idrreal
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_idrreal = value
            End Set
        End Property

        Public Property terimabarangdetil_pphpercent() As Decimal
            Get
                Return mTerimabarangdetil_pphpercent
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_pphpercent = value
            End Set
        End Property

        Public Property terimabarangdetil_ppnpercent() As Decimal
            Get
                Return mTerimabarangdetil_ppnpercent
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_ppnpercent = value
            End Set
        End Property

        Public Property terimabarangdetil_disc() As Decimal
            Get
                Return mTerimabarangdetil_disc
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_disc = value
            End Set
        End Property

        Public Property terimabarangdetil_pphforeign() As Decimal
            Get
                Return mTerimabarangdetil_pphforeign
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_pphforeign = value
            End Set
        End Property

        Public Property terimabarangdetil_pphidrreal() As Decimal
            Get
                Return mTerimabarangdetil_pphidrreal
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_pphidrreal = value
            End Set
        End Property

        Public Property terimabarangdetil_ppnforeign() As Decimal
            Get
                Return mTerimabarangdetil_ppnforeign
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_ppnforeign = value
            End Set
        End Property

        Public Property terimabarangdetil_ppnidrreal() As Decimal
            Get
                Return mTerimabarangdetil_ppnidrreal
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_ppnidrreal = value
            End Set
        End Property

        Public Property terimabarangdetil_totalforeign() As Decimal
            Get
                Return mTerimabarangdetil_totalforeign
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_totalforeign = value
            End Set
        End Property

        Public Property terimabarangdetil_totalidrreal() As Decimal
            Get
                Return mTerimabarangdetil_totalidrreal
            End Get
            Set(ByVal value As Decimal)
                mTerimabarangdetil_totalidrreal = value
            End Set
        End Property

        Public Property terimabarangdetil_nonfixasset() As Byte
            Get
                Return mTerimabarangdetil_nonfixasset
            End Get
            Set(ByVal value As Byte)
                mTerimabarangdetil_nonfixasset = value
            End Set
        End Property

        Public Property terimabarangdetil_golfiskal() As String
            Get
                Return mTerimabarangdetil_golfiskal
            End Get
            Set(ByVal value As String)
                mTerimabarangdetil_golfiskal = value
            End Set
        End Property

        Public Property terimabarangdetil_depre_enddt() As DateTime
            Get
                Return mTerimabarangdetil_depre_enddt
            End Get
            Set(ByVal value As DateTime)
                mTerimabarangdetil_depre_enddt = value
            End Set
        End Property

        Public Property employee_id() As String
            Get
                Return mEmployee_id
            End Get
            Set(ByVal value As String)
                mEmployee_id = value
            End Set
        End Property

        Public Property strukturunit_id() As Decimal
            Get
                Return mStrukturunit_id
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id = value
            End Set
        End Property

        Public Property show_id() As String
            Get
                Return mShow_id
            End Get
            Set(ByVal value As String)
                mShow_id = value
            End Set
        End Property

        Public Property show_id_cont() As String
            Get
                Return mShow_id_cont
            End Get
            Set(ByVal value As String)
                mShow_id_cont = value
            End Set
        End Property

        Public Property terimabarangdetil_eps() As String
            Get
                Return mTerimabarangdetil_eps
            End Get
            Set(ByVal value As String)
                mTerimabarangdetil_eps = value
            End Set
        End Property

        Public Property writeoff_id() As String
            Get
                Return mWriteoff_id
            End Get
            Set(ByVal value As String)
                mWriteoff_id = value
            End Set
        End Property

        Public Property writeoff_dt() As DateTime
            Get
                Return mWriteoff_dt
            End Get
            Set(ByVal value As DateTime)
                mWriteoff_dt = value
            End Set
        End Property

        Public Property order_id() As String
            Get
                Return mOrder_id
            End Get
            Set(ByVal value As String)
                mOrder_id = value
            End Set
        End Property

        Public Property orderdetil_line() As Int32
            Get
                Return mOrderdetil_line
            End Get
            Set(ByVal value As Int32)
                mOrderdetil_line = value
            End Set
        End Property

        Public Property budget_id() As Decimal
            Get
                Return mBudget_id
            End Get
            Set(ByVal value As Decimal)
                mBudget_id = value
            End Set
        End Property

        Public Property budgetdetil_id() As Decimal
            Get
                Return mBudgetdetil_id
            End Get
            Set(ByVal value As Decimal)
                mBudgetdetil_id = value
            End Set
        End Property

        Public Property acc_id() As String
            Get
                Return mAcc_id
            End Get
            Set(ByVal value As String)
                mAcc_id = value
            End Set
        End Property

        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
            End Set
        End Property

        Public Property create_by() As String
            Get
                Return mCreate_by
            End Get
            Set(ByVal value As String)
                mCreate_by = value
            End Set
        End Property

        Public Property create_dt() As DateTime
            Get
                Return mCreate_dt
            End Get
            Set(ByVal value As DateTime)
                mCreate_dt = value
            End Set
        End Property

        Public Property modified_by() As String
            Get
                Return mModified_by
            End Get
            Set(ByVal value As String)
                mModified_by = value
            End Set
        End Property

        Public Property modified_dt() As DateTime
            Get
                Return mModified_dt
            End Get
            Set(ByVal value As DateTime)
                mModified_dt = value
            End Set
        End Property

        Public Sub New(ByVal DSN As String, ByVal AssetDSN As String)
            Me.DSN = DSN
            Me.AssetDSN = AssetDSN
        End Sub
    End Class
End Namespace