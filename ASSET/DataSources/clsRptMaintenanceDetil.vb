Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptMaintenanceDetil
        Private DSN As String
        Private mMaintenance_id As String
        Private mMaintenancedetil_line As Int32
        Private mChannel_id As String
        Private mMaintenancedetil_barcode As String
        Private mMaintenancedetil_outdate As DateTime
        Private mMaintenancedetil_statusout As String
        Private mMaintenance_incdate As DateTime
        Private mMaintenancedetil_statusinc As String

        Public Property maintenance_id() As String
            Get
                Return mMaintenance_id
            End Get
            Set(ByVal value As String)
                mMaintenance_id = value
            End Set
        End Property

        Public Property maintenancedetil_line() As Int32
            Get
                Return mMaintenancedetil_line
            End Get
            Set(ByVal value As Int32)
                mMaintenancedetil_line = value
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

        Public Property maintenancedetil_barcode() As String
            Get
                Return mMaintenancedetil_barcode
            End Get
            Set(ByVal value As String)
                mMaintenancedetil_barcode = value
            End Set
        End Property

        Public Property maintenancedetil_outdate() As DateTime
            Get
                Return mMaintenancedetil_outdate
            End Get
            Set(ByVal value As DateTime)
                mMaintenancedetil_outdate = value
            End Set
        End Property

        Public Property maintenancedetil_statusout() As String
            Get
                Return mMaintenancedetil_statusout
            End Get
            Set(ByVal value As String)
                mMaintenancedetil_statusout = value
            End Set
        End Property

        Public Property maintenance_incdate() As DateTime
            Get
                Return mMaintenance_incdate
            End Get
            Set(ByVal value As DateTime)
                mMaintenance_incdate = value
            End Set
        End Property

        Public Property maintenancedetil_statusinc() As String
            Get
                Return mMaintenancedetil_statusinc
            End Get
            Set(ByVal value As String)
                mMaintenancedetil_statusinc = value
            End Set
        End Property

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace