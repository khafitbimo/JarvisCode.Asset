﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="E_FILES")>  _
Partial Public Class DataClassesFILESDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub Inserttransaksi_receivestatusattachment(instance As transaksi_receivestatusattachment)
    End Sub
  Partial Private Sub Updatetransaksi_receivestatusattachment(instance As transaksi_receivestatusattachment)
    End Sub
  Partial Private Sub Deletetransaksi_receivestatusattachment(instance As transaksi_receivestatusattachment)
    End Sub
  Partial Private Sub Inserttransaksi_penerimabarangdetilpicture(instance As transaksi_penerimabarangdetilpicture)
    End Sub
  Partial Private Sub Updatetransaksi_penerimabarangdetilpicture(instance As transaksi_penerimabarangdetilpicture)
    End Sub
  Partial Private Sub Deletetransaksi_penerimabarangdetilpicture(instance As transaksi_penerimabarangdetilpicture)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.ASSET.My.MySettings.Default.E_FILESConnectionString2, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property transaksi_receivestatusattachments() As System.Data.Linq.Table(Of transaksi_receivestatusattachment)
		Get
			Return Me.GetTable(Of transaksi_receivestatusattachment)
		End Get
	End Property
	
	Public ReadOnly Property transaksi_penerimabarangdetilpictures() As System.Data.Linq.Table(Of transaksi_penerimabarangdetilpicture)
		Get
			Return Me.GetTable(Of transaksi_penerimabarangdetilpicture)
		End Get
	End Property
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.as_PenerimaanBarangDetilPicture_Insert")>  _
	Public Function as_PenerimaanBarangDetilPicture_Insert(<Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="NVarChar(12)")> ByVal terimabarang_id As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal terimabrangdetil_line As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="VarBinary(MAX)")> ByVal filedata As System.Data.Linq.Binary) As Integer
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), terimabarang_id, terimabrangdetil_line, filedata)
		Return CType(result.ReturnValue,Integer)
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.as_PenerimaanBarangDetilPicture_Rename")>  _
	Public Function as_PenerimaanBarangDetilPicture_Rename(<Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="NVarChar(MAX)")> ByVal terimabarang_id As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal terimabarangdetil_line As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="NVarChar(MAX)")> ByVal terimabarang_idnew As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="Int")> ByVal terimabarangdetil_linenew As System.Nullable(Of Integer)) As Integer
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), terimabarang_id, terimabarangdetil_line, terimabarang_idnew, terimabarangdetil_linenew)
		Return CType(result.ReturnValue,Integer)
	End Function
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.transaksi_receivestatusattachment")>  _
Partial Public Class transaksi_receivestatusattachment
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _receivestatus_id As String
	
	Private _line As Integer
	
	Private _filedata As System.Data.Linq.Binary
	
	Private _extension As String
	
	Private _create_dt As System.Nullable(Of Date)
	
	Private _modify_dt As System.Nullable(Of Date)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub Onreceivestatus_idChanging(value As String)
    End Sub
    Partial Private Sub Onreceivestatus_idChanged()
    End Sub
    Partial Private Sub OnlineChanging(value As Integer)
    End Sub
    Partial Private Sub OnlineChanged()
    End Sub
    Partial Private Sub OnfiledataChanging(value As System.Data.Linq.Binary)
    End Sub
    Partial Private Sub OnfiledataChanged()
    End Sub
    Partial Private Sub OnextensionChanging(value As String)
    End Sub
    Partial Private Sub OnextensionChanged()
    End Sub
    Partial Private Sub Oncreate_dtChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub Oncreate_dtChanged()
    End Sub
    Partial Private Sub Onmodify_dtChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub Onmodify_dtChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_receivestatus_id", DbType:="NVarChar(12) NOT NULL", CanBeNull:=false, IsPrimaryKey:=true)>  _
	Public Property receivestatus_id() As String
		Get
			Return Me._receivestatus_id
		End Get
		Set
			If (String.Equals(Me._receivestatus_id, value) = false) Then
				Me.Onreceivestatus_idChanging(value)
				Me.SendPropertyChanging
				Me._receivestatus_id = value
				Me.SendPropertyChanged("receivestatus_id")
				Me.Onreceivestatus_idChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_line", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
	Public Property line() As Integer
		Get
			Return Me._line
		End Get
		Set
			If ((Me._line = value)  _
						= false) Then
				Me.OnlineChanging(value)
				Me.SendPropertyChanging
				Me._line = value
				Me.SendPropertyChanged("line")
				Me.OnlineChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_filedata", DbType:="VarBinary(MAX)", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property filedata() As System.Data.Linq.Binary
		Get
			Return Me._filedata
		End Get
		Set
			If (Object.Equals(Me._filedata, value) = false) Then
				Me.OnfiledataChanging(value)
				Me.SendPropertyChanging
				Me._filedata = value
				Me.SendPropertyChanged("filedata")
				Me.OnfiledataChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_extension", DbType:="NVarChar(10)")>  _
	Public Property extension() As String
		Get
			Return Me._extension
		End Get
		Set
			If (String.Equals(Me._extension, value) = false) Then
				Me.OnextensionChanging(value)
				Me.SendPropertyChanging
				Me._extension = value
				Me.SendPropertyChanged("extension")
				Me.OnextensionChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_create_dt", DbType:="DateTime")>  _
	Public Property create_dt() As System.Nullable(Of Date)
		Get
			Return Me._create_dt
		End Get
		Set
			If (Me._create_dt.Equals(value) = false) Then
				Me.Oncreate_dtChanging(value)
				Me.SendPropertyChanging
				Me._create_dt = value
				Me.SendPropertyChanged("create_dt")
				Me.Oncreate_dtChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_modify_dt", DbType:="DateTime")>  _
	Public Property modify_dt() As System.Nullable(Of Date)
		Get
			Return Me._modify_dt
		End Get
		Set
			If (Me._modify_dt.Equals(value) = false) Then
				Me.Onmodify_dtChanging(value)
				Me.SendPropertyChanging
				Me._modify_dt = value
				Me.SendPropertyChanged("modify_dt")
				Me.Onmodify_dtChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.transaksi_penerimabarangdetilpicture")>  _
Partial Public Class transaksi_penerimabarangdetilpicture
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _terimabarang_id As String
	
	Private _terimabarangdetil_line As Integer
	
	Private _filedata As System.Data.Linq.Binary
	
	Private _create_dt As System.Nullable(Of Date)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub Onterimabarang_idChanging(value As String)
    End Sub
    Partial Private Sub Onterimabarang_idChanged()
    End Sub
    Partial Private Sub Onterimabarangdetil_lineChanging(value As Integer)
    End Sub
    Partial Private Sub Onterimabarangdetil_lineChanged()
    End Sub
    Partial Private Sub OnfiledataChanging(value As System.Data.Linq.Binary)
    End Sub
    Partial Private Sub OnfiledataChanged()
    End Sub
    Partial Private Sub Oncreate_dtChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub Oncreate_dtChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_terimabarang_id", DbType:="NVarChar(12) NOT NULL", CanBeNull:=false, IsPrimaryKey:=true)>  _
	Public Property terimabarang_id() As String
		Get
			Return Me._terimabarang_id
		End Get
		Set
			If (String.Equals(Me._terimabarang_id, value) = false) Then
				Me.Onterimabarang_idChanging(value)
				Me.SendPropertyChanging
				Me._terimabarang_id = value
				Me.SendPropertyChanged("terimabarang_id")
				Me.Onterimabarang_idChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_terimabarangdetil_line", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
	Public Property terimabarangdetil_line() As Integer
		Get
			Return Me._terimabarangdetil_line
		End Get
		Set
			If ((Me._terimabarangdetil_line = value)  _
						= false) Then
				Me.Onterimabarangdetil_lineChanging(value)
				Me.SendPropertyChanging
				Me._terimabarangdetil_line = value
				Me.SendPropertyChanged("terimabarangdetil_line")
				Me.Onterimabarangdetil_lineChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_filedata", DbType:="VarBinary(MAX)", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property filedata() As System.Data.Linq.Binary
		Get
			Return Me._filedata
		End Get
		Set
			If (Object.Equals(Me._filedata, value) = false) Then
				Me.OnfiledataChanging(value)
				Me.SendPropertyChanging
				Me._filedata = value
				Me.SendPropertyChanged("filedata")
				Me.OnfiledataChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_create_dt", DbType:="SmallDateTime")>  _
	Public Property create_dt() As System.Nullable(Of Date)
		Get
			Return Me._create_dt
		End Get
		Set
			If (Me._create_dt.Equals(value) = false) Then
				Me.Oncreate_dtChanging(value)
				Me.SendPropertyChanging
				Me._create_dt = value
				Me.SendPropertyChanged("create_dt")
				Me.Oncreate_dtChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class
