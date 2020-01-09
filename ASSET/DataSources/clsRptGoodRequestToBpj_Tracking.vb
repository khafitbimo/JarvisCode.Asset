Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptGoodRequestToBpj_Tracking
        Private DSN As String
        Private mGoodsRequest As String
        Private mDepartment As Decimal
        Private mEntryDate1 As DateTime
        Private mPrepareDate1 As DateTime
        Private mUseDateFrom1 As DateTime
        Private mUseDateUntil1 As DateTime
        Private mLine1 As Int32
        Private mItem1 As String
        Private mQuantity1 As Int32
        Private mApprovedDateSpv As DateTime
        Private mApprovedSpvBy As String
        Private mCirculation_GR_by As String
        Private mCirculation_GR_date As DateTime
        Private mPurchaseRentalRequest As String
        Private mAcara As String
        Private mEntryDate2 As DateTime
        Private mPrepareDate2 As DateTime
        Private mUseDateFrom2 As DateTime
        Private mUseDateUntil2 As DateTime
        Private mLine2 As Int32
        Private mItem2 As String
        Private mQuantity2 As Int32
        Private mApprovedDateDept As DateTime
        Private mRequest_approved1by As String
        Private mApprovedDateDiv As DateTime
        Private mRequest_approved2by As String
        Private mApprovedDateProc As DateTime
        Private mRequestdetil_approvedprocby As String
        Private mApprovedDateBMA As DateTime
        Private mRequestdetil_approvedbmaby As String
        Private mPurchaseRentalOrder As String
        Private mEntryDate3 As DateTime
        Private mPrepareDate3 As DateTime
        Private mUseDateFrom3 As DateTime
        Private mUseDateUntil3 As DateTime
        Private mLine3 As Int32
        Private mItem3 As String
        Private mQuantity3 As Int32
        Private mCirculation_id As String
        Private mCirculation_receceived_date1 As DateTime
        Private mOrderDelivery_by As String
        Private mOrderDelivery_date As DateTime

        Private mTerimabarang_id As String
        Private mTerimabarang_tgl As DateTime
        Private mApprovedUser As DateTime
        Private mUser_applogin As String
        Private mApprovedSPV As DateTime
        Private mProcurement_applogin As String

        Private mReq_sht As String
        Private mReq_prcs As String
        Private mUser_dept As String
        Private mDept_prcs As String
        Private mDept_Proc As String
        Private mPro_bma As String
        Private mBma_order As String
        Private mOrder_rec As String
        Private mUser_bpj As String

        Private mApproved_Spv As String
        Private mApproved_kadept_RD As String
        Private mApproved_kadiv_RD As String
        Private mApproved_procurement As String
        Private mApproved_bma As String
        Private mEntryDate_order As String
        Private mRequestReceivedDate As String
        Private mDocReceivedDate As String
        Private mOrderReceivedDate As String
        Private mEntrydate_Bpj As String
        Private mApprovedSpv_Bpj As String

        Public Property GoodsRequest() As String
            Get
                Return mGoodsRequest
            End Get
            Set(ByVal value As String)
                mGoodsRequest = value
            End Set
        End Property

        Public Property Department() As Decimal
            Get
                Return mDepartment
            End Get
            Set(ByVal value As Decimal)
                mDepartment = value
            End Set
        End Property

        Public Property EntryDate1() As DateTime
            Get
                Return mEntryDate1
            End Get
            Set(ByVal value As DateTime)
                mEntryDate1 = value
            End Set
        End Property

        Public Property PrepareDate1() As DateTime
            Get
                Return mPrepareDate1
            End Get
            Set(ByVal value As DateTime)
                mPrepareDate1 = value
            End Set
        End Property

        Public Property UseDateFrom1() As DateTime
            Get
                Return mUseDateFrom1
            End Get
            Set(ByVal value As DateTime)
                mUseDateFrom1 = value
            End Set
        End Property

        Public Property UseDateUntil1() As DateTime
            Get
                Return mUseDateUntil1
            End Get
            Set(ByVal value As DateTime)
                mUseDateUntil1 = value
            End Set
        End Property

        Public Property Line1() As Int32
            Get
                Return mLine1
            End Get
            Set(ByVal value As Int32)
                mLine1 = value
            End Set
        End Property

        Public Property Item1() As String
            Get
                Return mItem1
            End Get
            Set(ByVal value As String)
                mItem1 = value
            End Set
        End Property

        Public Property Quantity1() As Int32
            Get
                Return mQuantity1
            End Get
            Set(ByVal value As Int32)
                mQuantity1 = value
            End Set
        End Property

        Public Property ApprovedDateSpv() As DateTime
            Get
                Return mApprovedDateSpv
            End Get
            Set(ByVal value As DateTime)
                mApprovedDateSpv = value
                'Me.convert_date_to_string()
            End Set
        End Property

        Public Property ApprovedSpvBy() As String
            Get
                Return mApprovedSpvBy
            End Get
            Set(ByVal value As String)
                mApprovedSpvBy = value
            End Set
        End Property

        Public Property circulation_GR_by() As String
            Get
                Return mCirculation_GR_by
            End Get
            Set(ByVal value As String)
                mCirculation_GR_by = value
            End Set
        End Property

        Public Property circulation_GR_date() As DateTime
            Get
                Return mCirculation_GR_date
            End Get
            Set(ByVal value As DateTime)
                mCirculation_GR_date = value
            End Set
        End Property

        Public Property PurchaseRentalRequest() As String
            Get
                Return mPurchaseRentalRequest
            End Get
            Set(ByVal value As String)
                mPurchaseRentalRequest = value
            End Set
        End Property

        Public Property acara() As String
            Get
                Return mAcara
            End Get
            Set(ByVal value As String)
                mAcara = value
            End Set
        End Property

        Public Property EntryDate2() As DateTime
            Get
                Return mEntryDate2
            End Get
            Set(ByVal value As DateTime)
                mEntryDate2 = value
            End Set
        End Property

        Public Property PrepareDate2() As DateTime
            Get
                Return mPrepareDate2
            End Get
            Set(ByVal value As DateTime)
                mPrepareDate2 = value
            End Set
        End Property

        Public Property UseDateFrom2() As DateTime
            Get
                Return mUseDateFrom2
            End Get
            Set(ByVal value As DateTime)
                mUseDateFrom2 = value
            End Set
        End Property

        Public Property UseDateUntil2() As DateTime
            Get
                Return mUseDateUntil2
            End Get
            Set(ByVal value As DateTime)
                mUseDateUntil2 = value
            End Set
        End Property

        Public Property Line2() As Int32
            Get
                Return mLine2
            End Get
            Set(ByVal value As Int32)
                mLine2 = value
            End Set
        End Property

        Public Property Item2() As String
            Get
                Return mItem2
            End Get
            Set(ByVal value As String)
                mItem2 = value
            End Set
        End Property

        Public Property Quantity2() As Int32
            Get
                Return mQuantity2
            End Get
            Set(ByVal value As Int32)
                mQuantity2 = value
            End Set
        End Property

        Public Property ApprovedDateDept() As DateTime
            Get
                Return mApprovedDateDept
            End Get
            Set(ByVal value As DateTime)
                mApprovedDateDept = value
            End Set
        End Property

        Public Property request_approved1by() As String
            Get
                Return mRequest_approved1by
            End Get
            Set(ByVal value As String)
                mRequest_approved1by = value
            End Set
        End Property

        Public Property ApprovedDateDiv() As DateTime
            Get
                Return mApprovedDateDiv
            End Get
            Set(ByVal value As DateTime)
                mApprovedDateDiv = value
            End Set
        End Property

        Public Property request_approved2by() As String
            Get
                Return mRequest_approved2by
            End Get
            Set(ByVal value As String)
                mRequest_approved2by = value
            End Set
        End Property

        Public Property ApprovedDateProc() As DateTime
            Get
                Return mApprovedDateProc
            End Get
            Set(ByVal value As DateTime)
                mApprovedDateProc = value
            End Set
        End Property

        Public Property requestdetil_approvedprocby() As String
            Get
                Return mRequestdetil_approvedprocby
            End Get
            Set(ByVal value As String)
                mRequestdetil_approvedprocby = value
            End Set
        End Property

        Public Property ApprovedDateBMA() As DateTime
            Get
                Return mApprovedDateBMA
            End Get
            Set(ByVal value As DateTime)
                mApprovedDateBMA = value
                'Me.convert_date_to_string()
            End Set
        End Property

        Public Property requestdetil_approvedbmaby() As String
            Get
                Return mRequestdetil_approvedbmaby
            End Get
            Set(ByVal value As String)
                mRequestdetil_approvedbmaby = value
            End Set
        End Property

        Public Property PurchaseRentalOrder() As String
            Get
                Return mPurchaseRentalOrder
            End Get
            Set(ByVal value As String)
                mPurchaseRentalOrder = value
            End Set
        End Property

        Public Property EntryDate3() As DateTime
            Get
                Return mEntryDate3
            End Get
            Set(ByVal value As DateTime)
                mEntryDate3 = value
            End Set
        End Property

        Public Property PrepareDate3() As DateTime
            Get
                Return mPrepareDate3
            End Get
            Set(ByVal value As DateTime)
                mPrepareDate3 = value
            End Set
        End Property

        Public Property UseDateFrom3() As DateTime
            Get
                Return mUseDateFrom3
            End Get
            Set(ByVal value As DateTime)
                mUseDateFrom3 = value
            End Set
        End Property

        Public Property UseDateUntil3() As DateTime
            Get
                Return mUseDateUntil3
            End Get
            Set(ByVal value As DateTime)
                mUseDateUntil3 = value
            End Set
        End Property

        Public Property Line3() As Int32
            Get
                Return mLine3
            End Get
            Set(ByVal value As Int32)
                mLine3 = value
            End Set
        End Property

        Public Property Item3() As String
            Get
                Return mItem3
            End Get
            Set(ByVal value As String)
                mItem3 = value
            End Set
        End Property

        Public Property Quantity3() As Int32
            Get
                Return mQuantity3
            End Get
            Set(ByVal value As Int32)
                mQuantity3 = value
            End Set
        End Property

        Public Property circulation_id() As String
            Get
                Return mCirculation_id
            End Get
            Set(ByVal value As String)
                mCirculation_id = value
            End Set
        End Property

        Public Property circulation_receceived_date1() As DateTime
            Get
                Return mCirculation_receceived_date1
            End Get
            Set(ByVal value As DateTime)
                mCirculation_receceived_date1 = value
            End Set
        End Property

        Public Property orderDelivery_by() As String
            Get
                Return mOrderDelivery_by
            End Get
            Set(ByVal value As String)
                mOrderDelivery_by = value
            End Set
        End Property

        Public Property orderDelivery_date() As DateTime
            Get
                Return mOrderDelivery_date
            End Get
            Set(ByVal value As DateTime)
                mOrderDelivery_date = value
            End Set
        End Property

        Public Property terimabarang_id() As String
            Get
                Return mTerimabarang_id
            End Get
            Set(ByVal value As String)
                mTerimabarang_id = value
            End Set
        End Property

        Public Property terimabarang_tgl() As DateTime
            Get
                Return mTerimabarang_tgl
            End Get
            Set(ByVal value As DateTime)
                mTerimabarang_tgl = value
            End Set
        End Property

        Public Property ApprovedUser() As DateTime
            Get
                Return mApprovedUser
            End Get
            Set(ByVal value As DateTime)
                mApprovedUser = value
            End Set
        End Property

        Public Property user_applogin() As String
            Get
                Return mUser_applogin
            End Get
            Set(ByVal value As String)
                mUser_applogin = value
            End Set
        End Property

        Public Property ApprovedSPV() As DateTime
            Get
                Return mApprovedSPV
            End Get
            Set(ByVal value As DateTime)
                mApprovedSPV = value
            End Set
        End Property

        Public Property procurement_applogin() As String
            Get
                Return mProcurement_applogin
            End Get
            Set(ByVal value As String)
                mProcurement_applogin = value
                Me.jml_req_sht()
                Me.convert_date_to_string()
            End Set
        End Property

        Public Property req_sht() As String
            Get
                Return mReq_sht
            End Get
            Set(ByVal value As String)
                mReq_sht = value
            End Set
        End Property
        Public Property req_prcs() As String
            Get
                Return mReq_prcs
            End Get
            Set(ByVal value As String)
                mReq_prcs = value
            End Set
        End Property

        Public Property user_dept() As String
            Get
                Return mUser_dept
            End Get
            Set(ByVal value As String)
                mUser_dept = value
            End Set
        End Property
        Public Property dept_prcs() As String
            Get
                Return mDept_prcs
            End Get
            Set(ByVal value As String)
                mDept_prcs = value
            End Set
        End Property

        Public Property dept_proc() As String
            Get
                Return mDept_Proc
            End Get
            Set(ByVal value As String)
                mDept_Proc = value
            End Set
        End Property
        Public Property pro_bma() As String
            Get
                Return mPro_bma
            End Get
            Set(ByVal value As String)
                mPro_bma = value
            End Set
        End Property

        Public Property bma_order() As String
            Get
                Return mBma_order
            End Get
            Set(ByVal value As String)
                mBma_order = value
            End Set
        End Property
        Public Property order_rec() As String
            Get
                Return mOrder_rec
            End Get
            Set(ByVal value As String)
                mOrder_rec = value
            End Set
        End Property
        Public Property user_bpj() As String
            Get
                Return mUser_bpj
            End Get
            Set(ByVal value As String)
                mUser_bpj = value
            End Set
        End Property
        Public Property approved_spv() As String
            Get
                Return mApproved_Spv
            End Get
            Set(ByVal value As String)
                mApproved_Spv = value
            End Set
        End Property
        Public Property approved_kadept_rd() As String
            Get
                Return mApproved_kadept_RD
            End Get
            Set(ByVal value As String)
                mApproved_kadept_RD = value
            End Set
        End Property

        Public Property approved_kadiv_rd() As String
            Get
                Return mApproved_kadiv_RD
            End Get
            Set(ByVal value As String)
                mApproved_kadiv_RD = value
            End Set
        End Property

        Public Property approved_procurement() As String
            Get
                Return mApproved_procurement
            End Get
            Set(ByVal value As String)
                mApproved_procurement = value
            End Set
        End Property

        Public Property approved_bma() As String
            Get
                Return mApproved_bma
            End Get
            Set(ByVal value As String)
                mApproved_bma = value
            End Set
        End Property

        Public Property entrydate_order() As String
            Get
                Return mEntryDate_order
            End Get
            Set(ByVal value As String)
                mEntryDate_order = value
            End Set
        End Property

        Public Property requestReceivedDate() As String
            Get
                Return mRequestReceivedDate
            End Get
            Set(ByVal value As String)
                mRequestReceivedDate = value
            End Set
        End Property
        Public Property docreceivedDate() As String
            Get
                Return mDocReceivedDate
            End Get
            Set(ByVal value As String)
                mDocReceivedDate = value
            End Set
        End Property


        Public Property orderReceivedDate() As String
            Get
                Return mOrderReceivedDate
            End Get
            Set(ByVal value As String)
                mOrderReceivedDate = value
            End Set
        End Property
        Public Property entrydate_bpj() As String
            Get
                Return mEntrydate_Bpj
            End Get
            Set(ByVal value As String)
                mEntrydate_Bpj = value
            End Set
        End Property

        Public Property approvedspv_bpj() As String
            Get
                Return mApprovedSpv_Bpj
            End Get
            Set(ByVal value As String)
                mApprovedSpv_Bpj = value
            End Set
        End Property


        Private Sub jml_req_sht()
            Dim a, b, c, d, e, f, g, h, i As Integer
            Try
                If mEntryDate1 <> Nothing And mPrepareDate1 <> Nothing Then
                    a = DateDiff(DateInterval.Day, mEntryDate1, mPrepareDate1)
                    If Format(mPrepareDate1, "ddMMyyy") <> Format(mEntryDate1, "ddMMyyyy") Then
                        If a >= 0 Then
                            a += 1
                        End If
                    End If
                    mReq_sht = a
                Else
                    mReq_sht = "Null"
                End If

                If mEntryDate1 <> Nothing And mApprovedDateSpv <> Nothing Then
                    b = DateDiff(DateInterval.Day, mEntryDate1, mApprovedDateSpv)
                    If Format(mApprovedDateSpv, "ddMMyyy") <> Format(mEntryDate1, "ddMMyyyy") Then
                            b += 1
                    End If
                    mReq_prcs = b
                Else
                    mReq_prcs = "Null"
                End If

                If mApprovedDateSpv <> Nothing And mEntryDate2 <> Nothing Then
                    c = DateDiff(DateInterval.Day, mApprovedDateSpv, mEntryDate2)
                    If Format(mApprovedDateSpv, "ddMMyyy") <> Format(mEntryDate2, "ddMMyyyy") Then
                        c += 1
                    End If
                    mUser_dept = c
                Else
                    mUser_dept = "Null"
                End If

                If mEntryDate2 <> Nothing And mApprovedDateDiv <> Nothing Then
                    d = DateDiff(DateInterval.Day, mEntryDate2, mApprovedDateDiv)
                    If Format(mEntryDate2, "ddMMyyy") <> Format(mApprovedDateDiv, "ddMMyyyy") Then
                        d += 1
                    End If
                    mDept_prcs = d
                Else
                    mDept_prcs = "Null"
                End If

                If mApprovedDateDiv <> Nothing And (mApprovedDateProc <> Nothing Or mApprovedDateProc <> " 12:00:00 AM") Then
                    e = DateDiff(DateInterval.Day, mApprovedDateDiv, mApprovedDateProc)
                    If Format(mApprovedDateDiv, "ddMMyyy") <> Format(mApprovedDateProc, "ddMMyyyy") Then
                        e += 1
                    End If
                    mDept_Proc = e
                Else
                    mDept_Proc = "Null"
                End If

                If mApprovedDateProc <> Nothing And mApprovedDateBMA <> Nothing Then
                    f = DateDiff(DateInterval.Day, mApprovedDateProc, mApprovedDateBMA)
                    If Format(mApprovedDateProc, "ddMMyyy") <> Format(mApprovedDateBMA, "ddMMyyyy") Then
                        f += 1
                    End If
                    mPro_bma = f
                Else
                    mPro_bma = "Null"
                End If

                If mApprovedDateBMA <> Nothing And mEntryDate3 <> Nothing Then
                    g = DateDiff(DateInterval.Day, mApprovedDateBMA, mEntryDate3)
                    If Format(mApprovedDateBMA, "ddMMyyy") <> Format(mEntryDate3, "ddMMyyyy") Then
                        g += 1
                    End If
                    mBma_order = g
                Else
                    mBma_order = "Null"
                End If

                If mEntryDate3 <> Nothing And mCirculation_receceived_date1 <> Nothing Then
                    h = DateDiff(DateInterval.Day, mEntryDate3, mCirculation_receceived_date1)
                    If Format(mEntryDate3, "ddMMyyy") <> Format(mCirculation_receceived_date1, "ddMMyyyy") Then
                        h += 1
                    End If
                    mOrder_rec = h
                Else
                    mOrder_rec = "Null"
                End If

                If mUseDateUntil1 <> Nothing And mTerimabarang_tgl <> Nothing Then
                    i = DateDiff(DateInterval.Day, mUseDateUntil1, mTerimabarang_tgl)
                    If Format(mUseDateUntil1, "ddMMyyy") <> Format(mTerimabarang_tgl, "ddMMyyyy") Then
                        i += 1
                    End If
                    mUser_bpj = i
                Else
                    mUser_bpj = "Null"
                End If

            Catch ex As Exception
                MsgBox("error on retrieving Entry Date Or Prepare Date Good Request.")
            Finally

            End Try

        End Sub
        Private Sub convert_date_to_string()
            Try

                If mApprovedDateBMA <> Nothing Or mApprovedDateBMA <> " 12:00:00 AM" Then
                    mApproved_bma = Format(mApprovedDateBMA, "dd/MM/yyyy")
                Else
                    mApproved_bma = "Not Approved"
                End If

                If mApprovedDateSpv <> Nothing Or mApprovedDateSpv <> " 12:00:00 AM" Then
                    mApproved_Spv = Format(mApprovedDateSpv, "dd/MM/yyyy")
                Else
                    mApproved_Spv = "Not Approved"
                End If

                If mApprovedDateDept <> Nothing Or mApprovedDateDept <> " 12:00:00 AM" Then
                    mApproved_kadept_RD = Format(mApprovedDateDept, "dd/MM/yyyy")
                Else
                    mApproved_kadept_RD = "Not Approved"
                End If

                If mApprovedDateDiv <> Nothing Or mApprovedDateDiv <> " 12:00:00 AM" Then
                    mApproved_kadiv_RD = Format(mApprovedDateDiv, "dd/MM/yyyy")
                Else
                    mApproved_kadiv_RD = "Not Approved"
                End If

                If mApprovedDateProc <> Nothing Or mApprovedDateProc <> " 12:00:00 AM" Then
                    mApproved_procurement = Format(mApprovedDateProc, "dd/MM/yyyy")
                Else
                    mApproved_procurement = "Not Approved"
                End If

                If mEntryDate3 <> Nothing Or mEntryDate3 <> " 12:00:00 AM" Then
                    mEntryDate_order = Format(mEntryDate3, "dd/MM/yyyy")
                Else
                    mEntryDate_order = "Not Entry"
                End If


                If mCirculation_GR_date <> Nothing Or mCirculation_GR_date <> " 12:00:00 AM" Then
                    mRequestReceivedDate = Format(mCirculation_GR_date, "dd/MM/yyyy")
                Else
                    mRequestReceivedDate = "Not Entry"
                End If

                If mCirculation_receceived_date1 <> Nothing Or mCirculation_receceived_date1 <> " 12:00:00 AM" Then
                    mDocReceivedDate = Format(mCirculation_receceived_date1, "dd/MM/yyyy")
                Else
                    mDocReceivedDate = "Not Entry"
                End If

                If mOrderDelivery_date <> Nothing Or mOrderDelivery_date <> " 12:00:00 AM" Then
                    mOrderReceivedDate = Format(mOrderDelivery_date, "dd/MM/yyyy")
                Else
                    mOrderReceivedDate = "Not Entry"
                End If

                If mTerimabarang_tgl <> Nothing Or mTerimabarang_tgl <> " 12:00:00 AM" Then
                    mEntrydate_Bpj = Format(mTerimabarang_tgl, "dd/MM/yyyy")
                Else
                    mEntrydate_Bpj = "Not Entry"
                End If

                If mApprovedSPV <> Nothing Or mApprovedSPV <> " 12:00:00 AM" Then
                    mApprovedSpv_Bpj = Format(mApprovedSPV, "dd/MM/yyyy")
                Else
                    mApprovedSpv_Bpj = "Not Approved"
                End If

            Catch ex As Exception
                MsgBox("error on retrieving Entry Date Or Prepare Date Good Request.")
            Finally

            End Try

        End Sub
        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace