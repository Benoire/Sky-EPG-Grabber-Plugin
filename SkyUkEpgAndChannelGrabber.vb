Imports Custom_Data_Grabber
Imports System.Threading
Imports System.Linq
Imports System.Drawing
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports My
Imports TvDatabase
Imports TvLibrary.Channels
Imports TvLibrary.Epg
Imports TvLibrary.Interfaces
Imports TvEngine
Imports TvControl
Imports TvLibrary.Log
Imports System
Imports System.Text
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices
Imports System.Net
Imports Microsoft.VisualBasic.CompilerServices
Imports DirectShowLib.BDA
Imports Microsoft.VisualBasic
Imports System.Environment
Imports TvLibrary.Interfaces.TvConstants
Imports TvService
Imports MediaPortal.Common.Utils

<Assembly: CompatibleVersion("1.1.6.27796")> 

Public Class SkyUkEpgAndChannelGrabber

    Implements ITvServerPlugin
    Dim settings As Settings
    Dim WithEvents skygrabber As SkyGrabber
    Dim WithEvents timer As Timers.Timer

    'Private Sub Elapsed(ByVal sender As Object, ByVal e As ElapsedEventArgs)
    'OnTick()
    'End Sub

    Sub OnTick() Handles timer.Elapsed

        If (Not settings.IsGrabbing AndAlso settings.AutoUpdate) Then
            If settings.EveryHour Then
                If settings.LastUpdate.AddHours(settings.UpdateInterval) < Now Then
                    skygrabber.Grab()
                End If
            ElseIf (((Now.Hour = settings.UpdateTime.Hour) And (DateTime.Compare(settings.LastUpdate.Date, Now.Date) <> 0)) AndAlso ((Now.Minute >= settings.UpdateTime.Minute) And (Now.Minute <= (settings.UpdateTime.Minute + 10)))) Then
                Select Case Now.DayOfWeek
                    Case DayOfWeek.Sunday
                        If settings.Sun Then
                            skygrabber.Grab()
                        End If
                        Exit Select
                    Case DayOfWeek.Monday
                        If settings.Mon Then
                            skygrabber.Grab()
                        End If
                        Exit Select
                    Case DayOfWeek.Tuesday
                        If settings.Tue Then
                            skygrabber.Grab()
                        End If
                        Exit Select
                    Case DayOfWeek.Wednesday
                        If settings.Wed Then
                            skygrabber.Grab()
                        End If
                        Exit Select
                    Case DayOfWeek.Thursday
                        If settings.Thu Then
                            skygrabber.Grab()
                        End If
                        Exit Select
                    Case DayOfWeek.Friday
                        If settings.Fri Then
                            skygrabber.Grab()
                        End If
                        Exit Select
                    Case DayOfWeek.Saturday
                        If settings.Sat Then
                            skygrabber.Grab()
                        End If
                        Exit Select
                End Select
            End If
        End If
    End Sub

    Private Sub skygrabber_OnMessage(ByVal [Text] As String, ByVal UpdateLast As Boolean) Handles skygrabber.OnMessage
        If Not UpdateLast Then
            Log.Write("Sky Plugin : " & [Text])
        End If
    End Sub

    Public Sub Start(ByVal controller As IController) Implements ITvServerPlugin.Start
        skygrabber = New SkyGrabber
        settings = New Settings
        settings.IsGrabbing = False
        timer = New Timers.Timer
        timer.Interval = 1800000
        timer.Start()
    End Sub

    Public Sub Stopit() Implements ITvServerPlugin.Stop
        timer.Start()
        settings = Nothing
        skygrabber = Nothing
    End Sub

    Public ReadOnly Property Author As String Implements ITvServerPlugin.Author
        Get
            Return "DJBlu"
        End Get
    End Property

    Public ReadOnly Property MasterOnly As Boolean Implements ITvServerPlugin.MasterOnly
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property Name As String Implements ITvServerPlugin.Name
        Get
            Return "Sky UK Channel and EPG Grabber"
        End Get
    End Property

    Public ReadOnly Property Setup As SetupTv.SectionSettings Implements ITvServerPlugin.Setup
        Get
            Return New Setup()
        End Get
    End Property

    'Private Overridable Property skygrabber As SkyGrabber
    '    Get
    '        Return _skygrabber
    '    End Get
    '    <MethodImpl(MethodImplOptions.Synchronized)> _
    '    Set(ByVal WithEventsValue As SkyGrabber)
    '        Dim handler As SkyGrabber.OnMessageEventHandler = New SkyGrabber.OnMessageEventHandler(AddressOf skygrabber_OnMessage)
    '        If (Not _skygrabber Is Nothing) Then
    '            RemoveHandler _skygrabber.OnMessage, handler
    '        End If
    '        _skygrabber = WithEventsValue
    '        If (Not _skygrabber Is Nothing) Then
    '            AddHandler _skygrabber.OnMessage, handler
    '        End If
    '    End Set
    'End Property

    'Public Property timer As Threading.Timer
    '    Get
    '        Return _timer
    '    End Get
    '    <MethodImpl(MethodImplOptions.Synchronized)> _
    '    Set(ByVal WithEventsValue As Threading.Timer)
    '        Dim handler As ElapsedEventHandler = New ElapsedEventHandler(AddressOf OnTick)
    '        If (Not _timer Is Nothing) Then
    '            RemoveHandler _timer.Elapsed, handler
    '        End If
    '        _timer = WithEventsValue
    '        If (Not _timer Is Nothing) Then
    '            AddHandler _timer.Elapsed, handler
    '        End If
    '    End Set
    'End Property

    Public ReadOnly Property Version As String Implements ITvServerPlugin.Version
        Get
            Return "1.4.0.6"
        End Get
    End Property
End Class

Public Class Settings
    ' Fields
    Private Shared _autoupdate As Boolean
    Private Shared _bouquetid As Integer
    Private Shared _cardtouseindex As Integer
    Private Shared _deleteoldchannels As Boolean
    Private Shared _diseqc As Integer
    Private Shared _everyhour As Boolean
    Private Shared _frequency As Integer
    Private Shared _fri As Boolean
    Private Shared _grabtime As Integer
    Private Shared _ignorescrambled As Boolean
    Private Shared _isgrabbing As Boolean
    Private Shared _isloading As Boolean
    Private Shared _lastupdate As DateTime
    Private Shared _logodirectory As String
    Private Shared _modulation As Integer
    Private Shared _mon As Boolean
    Private Shared _MyVar As String
    Private Shared _nid As Integer
    Private Shared _oldchannelfolder As String
    Private Shared _ondaysat As Boolean
    Private Shared _polarisation As Integer
    Private Shared _regionid As Integer
    Private Shared _regionindex As Integer
    Private Shared _replacesdwithhd As Boolean
    Private Shared _sat As Boolean
    Private Shared _serviceid As Integer
    Private Shared _settingsloaded As Boolean
    Private Shared _sun As Boolean
    Private Shared _switchingfrequency As Integer
    Private Shared _symbolrate As Integer
    Private ReadOnly _syncObj As Object = RuntimeHelpers.GetObjectValue(New Object)
    Private Shared _thu As Boolean
    Private Shared _transportid As Integer
    Private Shared _tue As Boolean
    Private Shared _updatechannels As Boolean
    Private Shared _updateepg As Boolean
    Private Shared _updateinterval As Integer
    Private Shared _updatelogos As Boolean
    Private Shared _updatetime As DateTime
    Private Shared _useextrainfo As Boolean
    Private Shared _usenotsetmodhd As Boolean
    Private Shared _usenotsetmodsd As Boolean
    Private Shared _useskycategories As Boolean
    Private Shared _useskynumbers As Boolean
    Private Shared _useskyregions As Boolean
    Private Shared _usethrottle As Boolean
    Private Shared _wed As Boolean
    Private ReadOnly cats As Dictionary(Of Byte, String) = New Dictionary(Of Byte, String)
    Private ReadOnly layer As TvBusinessLayer = New TvBusinessLayer
    Private ReadOnly returnlist As List(Of Integer) = New List(Of Integer)
    Private ReadOnly Themes As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)

    'Methods
    Public Function GetSkySetting(ByVal _Setting As String, ByVal defaultvalue As Object) As String
        Return layer.GetSetting(("SKYUKPLUG_" & _Setting), defaultvalue.ToString).Value
    End Function

    Public Sub UpdateSetting(ByVal _Setting As String, ByVal value As String)
        Dim setting As Setting = layer.GetSetting(("SKYUKPLUG_" & _Setting), "0")
        setting.Value = value.ToString
        setting.Persist()
    End Sub

    Public Function GetCategoryByTextBoxNum(ByVal TextBoxNum As Integer) As String
        Dim expression As Object = _syncObj
        ObjectFlowControl.CheckForSyncLockOnValueType(expression)
        SyncLock expression
            Return GetSkySetting(("Cat" & Conversions.ToString(TextBoxNum)), "-1,., ")
        End SyncLock
    End Function

    'Properties

    Public Property modulation As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _modulation
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _modulation) Then
                    _modulation = value
                    UpdateSetting("modulation", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property GrabTime As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _grabtime
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _grabtime) Then
                    _grabtime = value
                    UpdateSetting("GrabTime", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property frequency As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _frequency
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _frequency) Then
                    _frequency = value
                    UpdateSetting("frequency", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property SymbolRate As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _symbolrate
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _symbolrate) Then
                    _symbolrate = value
                    UpdateSetting("SymbolRate", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property NID As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _nid
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _nid) Then
                    _nid = value
                    UpdateSetting("NID", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property polarisation As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _polarisation
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _polarisation) Then
                    _polarisation = value
                    UpdateSetting("polarisation", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property ServiceID As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _serviceid
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _serviceid) Then
                    _serviceid = value
                    UpdateSetting("ServiceID", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property TransportID As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _transportid
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _transportid) Then
                    _transportid = value
                    UpdateSetting("TransportID", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property AutoUpdate As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _autoupdate
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _autoupdate) Then
                    _autoupdate = value
                    UpdateSetting("AutoUpdate", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property useExtraInfo As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _useextrainfo
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _useextrainfo) Then
                    _useextrainfo = value
                    UpdateSetting("useExtraInfo", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property UpdateChannels As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _updatechannels
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _updatechannels) Then
                    _updatechannels = value
                    UpdateSetting("UpdateChannels", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property EveryHour As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _everyhour
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _everyhour) Then
                    _everyhour = value
                    UpdateSetting("EveryHour", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property OnDaysAt As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _ondaysat
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _ondaysat) Then
                    _ondaysat = value
                    UpdateSetting("OnDaysAt", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    'Days

    Public Property Mon As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _mon
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _mon) Then
                    _mon = value
                    UpdateSetting("Mon", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property Tue As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _tue
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _tue) Then
                    _tue = value
                    UpdateSetting("Tue", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property Wed As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _wed
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _wed) Then
                    _wed = value
                    UpdateSetting("Wed", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property Thu As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _thu
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _thu) Then
                    _thu = value
                    UpdateSetting("Thu", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property Fri As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _fri
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _fri) Then
                    _fri = value
                    UpdateSetting("Fri", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property Sat As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _sat
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _sat) Then
                    _sat = value
                    UpdateSetting("Sat", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property Sun As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _sun
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _sun) Then
                    _sun = value
                    UpdateSetting("Sun", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property UpdateTime As DateTime
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _updatetime
            End SyncLock
        End Get
        Set(ByVal value As DateTime)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (DateTime.Compare(value, _updatetime) <> 0) Then
                    _updatetime = value
                    UpdateSetting("UpdateTime", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    'Functions

    Public Property ReplaceSDwithHD As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _replacesdwithhd
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _replacesdwithhd) Then
                    _replacesdwithhd = value
                    UpdateSetting("ReplaceSDwithHD", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property IgnoreScrambled As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _ignorescrambled
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _ignorescrambled) Then
                    _ignorescrambled = value
                    UpdateSetting("IgnoreScrambled", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property UseNotSetModSD As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _usenotsetmodsd
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _usenotsetmodsd) Then
                    _usenotsetmodsd = value
                    UpdateSetting("UseNotSetModSD", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property UseNotSetModHD As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _usenotsetmodhd
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _usenotsetmodhd) Then
                    _usenotsetmodhd = value
                    UpdateSetting("UseNotSetModHD", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property UpdateEPG As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _updateepg
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _updateepg) Then
                    _updateepg = value
                    UpdateSetting("UpdateEPG", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property UpdateInterval As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _updateinterval
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _updateinterval) Then
                    _updateinterval = value
                    UpdateSetting("UpdateInterval", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property RegionID As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _regionid
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _regionid) Then
                    _regionid = value
                    UpdateSetting("RegionID", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property BouquetID As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If _replacesdwithhd Then
                    Return (_bouquetid + 4)
                End If
                Return _bouquetid
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _bouquetid) Then
                    _bouquetid = value
                    UpdateSetting("BouquetID", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property IsLoading As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _isloading
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _isloading) Then
                    _isloading = value
                    UpdateSetting("IsLoading", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property CardMap As List(Of Integer)
        Get
            Dim returnlist As New List(Of Integer)
            Dim Stringtouse As String = GetSkySetting("CardMap", "")
            If Stringtouse.Length > 0 Then
                If Stringtouse.Length = 1 Then
                    returnlist.Add(Convert.ToInt32(Stringtouse))
                Else
                    Dim Array1() As String = Stringtouse.Split(",")
                    If Array1.Count > 0 Then
                        For Each Str As String In Array1
                            returnlist.Add(Convert.ToInt32(Str))
                        Next
                    End If
                End If
            End If
            Return returnlist
        End Get
        Set(ByVal value As List(Of Integer))
            Dim str As New StringBuilder
            If value.Count > 0 Then
                For Each Num As Integer In value
                    str.Append("," & Num.ToString)
                Next
                str.Remove(0, 1)
            End If
            UpdateSetting("CardMap", str.ToString)
        End Set
    End Property
    'Public Property CardMap As List(Of Integer)
    '    Get
    '        Dim expression As Object = _syncObj
    '        ObjectFlowControl.CheckForSyncLockOnValueType(expression)
    '        SyncLock expression
    '            Return returnlist
    '        End SyncLock
    '    End Get
    '    Set(ByVal value As List(Of Integer))
    '        Dim expression As Object = _syncObj
    '        ObjectFlowControl.CheckForSyncLockOnValueType(expression)
    '        SyncLock expression
    '            Dim builder As New StringBuilder
    '            returnlist.Clear()
    '            If (value.Count > 0) Then
    '                Dim num As Integer
    '                For Each num In value
    '                    If Not returnlist.Contains(num) Then
    '                        returnlist.Add(num)
    '                        builder.Append(("," & num.ToString))
    '                    End If
    '                Next
    '                builder.Remove(0, 1)
    '            End If
    '            UpdateSetting("CardMap", builder.ToString)
    '        End SyncLock
    '    End Set
    'End Property

    Public Property LastUpdate As DateTime
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _lastupdate
            End SyncLock
        End Get
        Set(ByVal value As DateTime)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (DateTime.Compare(value, _lastupdate) <> 0) Then
                    _lastupdate = value
                    UpdateSetting("LastUpdate", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property UseSkyNumbers As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _useskynumbers
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _useskynumbers) Then
                    _useskynumbers = value
                    UpdateSetting("UseSkyNumbers", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property UseSkyCategories As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _useskycategories
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _useskycategories) Then
                    _useskycategories = value
                    UpdateSetting("UseSkyCategories", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property UseSkyRegions As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _useskyregions
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _useskyregions) Then
                    _useskyregions = value
                    UpdateSetting("UseSkyRegions", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property DeleteOldChannels As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _deleteoldchannels
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _deleteoldchannels) Then
                    _deleteoldchannels = value
                    UpdateSetting("DeleteOldChannels", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property OldChannelFolder As String
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _oldchannelfolder
            End SyncLock
        End Get
        Set(ByVal value As String)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _oldchannelfolder) Then
                    _oldchannelfolder = value
                    UpdateSetting("OldChannelFolder", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property LogoDirectory As String
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _logodirectory
            End SyncLock
        End Get
        Set(ByVal value As String)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _logodirectory) Then
                    _logodirectory = value
                    UpdateSetting("LogoDirectory", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property RegionIndex As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _regionindex
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _regionindex) Then
                    _regionindex = value
                    UpdateSetting("RegionIndex", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property CardToUseIndex As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _cardtouseindex
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _cardtouseindex) Then
                    _cardtouseindex = value
                    UpdateSetting("CardToUseIndex", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property DiseqC As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _diseqc
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _diseqc) Then
                    _diseqc = value
                    UpdateSetting("DiseqC", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property SwitchingFrequency As Integer
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _switchingfrequency
            End SyncLock
        End Get
        Set(ByVal value As Integer)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _switchingfrequency) Then
                    _switchingfrequency = value
                    UpdateSetting("SwitchingFrequency", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property IsGrabbing As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _isgrabbing
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _isgrabbing) Then
                    _isgrabbing = value
                    UpdateSetting("IsGrabbing", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Function GetCategory(ByVal CatByte As Byte) As String
        Dim expression As Object = _syncObj
        ObjectFlowControl.CheckForSyncLockOnValueType(expression)
        SyncLock expression
            If cats.ContainsKey(CatByte) Then
                Return cats.Item(CatByte)
            End If
            Return ""
        End SyncLock
    End Function

    Public Sub SetCategory(ByVal TextBox As Integer, ByVal CatByteText As String, ByVal Name As String)
        Dim expression As Object = _syncObj
        ObjectFlowControl.CheckForSyncLockOnValueType(expression)
        SyncLock expression
            Dim num As Double
            If CatByteText.StartsWith("-") Then
                GoTo Label_00B0
            End If
            If Double.TryParse(CatByteText, num) Then
                If cats.ContainsKey(CByte(Math.Round(num))) Then
                    Dim str As String = cats.Item(CByte(Math.Round(num)))
                    If (str <> Name) Then
                        cats.Item(CByte(Math.Round(num))) = Name
                        GoTo Label_0086
                    End If
                    GoTo Label_00B0
                End If
                cats.Add(CByte(Math.Round(num)), Name)
            End If
Label_0086:
            UpdateSetting(("Cat" & TextBox), (CatByteText & ",.," & Name))
Label_00B0:
        End SyncLock
    End Sub

    Public Function GetTheme(ByVal Id As Integer) As String
        If Themes.ContainsKey(Id) Then
            Return Themes.Item(Id)
        End If
        Return ""
    End Function

    Public Sub New()
        If Not Themes.ContainsKey(0) Then
            Themes.Add(&H0, "No Category")
            Themes.Add(&H1, "")
            Themes.Add(&H2, "")
            Themes.Add(&H3, "")
            Themes.Add(&H4, "")
            Themes.Add(&H5, "")
            Themes.Add(&H6, "")
            Themes.Add(&H7, "")
            Themes.Add(&H8, "")
            Themes.Add(&H9, "")
            Themes.Add(&HA, "")
            Themes.Add(&HB, "")
            Themes.Add(&HC, "")
            Themes.Add(&HD, "")
            Themes.Add(&HE, "")
            Themes.Add(&HF, "")
            Themes.Add(&H10, "")
            Themes.Add(&H11, "")
            Themes.Add(&H12, "")
            Themes.Add(&H13, "")
            Themes.Add(&H14, "")
            Themes.Add(&H15, "")
            Themes.Add(&H16, "")
            Themes.Add(&H17, "")
            Themes.Add(&H18, "")
            Themes.Add(&H19, "")
            Themes.Add(&H1A, "")
            Themes.Add(&H1B, "")
            Themes.Add(&H1C, "")
            Themes.Add(&H1D, "")
            Themes.Add(&H1E, "")
            Themes.Add(&H1F, "")
            Themes.Add(&H20, "Specialist - Undefined")
            Themes.Add(&H21, "Specialist - Adult")
            Themes.Add(&H22, "Specialist - Events")
            Themes.Add(&H23, "Specialist - Shopping")
            Themes.Add(&H24, "Specialist - Gaming")
            Themes.Add(&H25, "")
            Themes.Add(&H26, "")
            Themes.Add(&H27, "")
            Themes.Add(&H28, "")
            Themes.Add(&H29, "")
            Themes.Add(&H2A, "")
            Themes.Add(&H2B, "")
            Themes.Add(&H2C, "")
            Themes.Add(&H2D, "")
            Themes.Add(&H2E, "")
            Themes.Add(&H2F, "")
            Themes.Add(&H30, "")
            Themes.Add(&H31, "")
            Themes.Add(&H32, "")
            Themes.Add(&H33, "")
            Themes.Add(&H34, "")
            Themes.Add(&H35, "")
            Themes.Add(&H36, "")
            Themes.Add(&H37, "")
            Themes.Add(&H38, "")
            Themes.Add(&H39, "")
            Themes.Add(&H3A, "")
            Themes.Add(&H3B, "")
            Themes.Add(&H3C, "")
            Themes.Add(&H3D, "")
            Themes.Add(&H3E, "")
            Themes.Add(&H3F, "")
            Themes.Add(&H40, "Children - Undefined")
            Themes.Add(&H41, "Children - Cartoons")
            Themes.Add(&H42, "Children - Comedy")
            Themes.Add(&H43, "Children - Drama")
            Themes.Add(&H44, "Children - Educational")
            Themes.Add(&H45, "Children - Under 5")
            Themes.Add(&H46, "Children - Factual")
            Themes.Add(&H47, "Children - Magazine")
            Themes.Add(&H48, "Children - Games Shows")
            Themes.Add(&H49, "Children - Games")
            Themes.Add(&H4A, "")
            Themes.Add(&H4B, "")
            Themes.Add(&H4C, "")
            Themes.Add(&H4D, "")
            Themes.Add(&H4E, "")
            Themes.Add(&H4F, "")
            Themes.Add(&H50, "")
            Themes.Add(&H51, "")
            Themes.Add(&H52, "")
            Themes.Add(&H53, "")
            Themes.Add(&H54, "")
            Themes.Add(&H55, "")
            Themes.Add(&H56, "")
            Themes.Add(&H57, "")
            Themes.Add(&H58, "")
            Themes.Add(&H59, "")
            Themes.Add(&H5A, "")
            Themes.Add(&H5B, "")
            Themes.Add(&H5C, "")
            Themes.Add(&H5D, "")
            Themes.Add(&H5E, "")
            Themes.Add(&H5F, "")
            Themes.Add(&H60, "Entertainment - Undefined")
            Themes.Add(&H61, "Entertainment - Action")
            Themes.Add(&H62, "Entertainment - Comedy")
            Themes.Add(&H63, "Entertainment - Detective")
            Themes.Add(&H64, "Entertainment - Drama")
            Themes.Add(&H65, "Entertainment - Game Show")
            Themes.Add(&H66, "Entertainment - Sci-FI")
            Themes.Add(&H67, "Entertainment - Soap")
            Themes.Add(&H68, "Entertainment - Animation")
            Themes.Add(&H69, "Entertainment - Chat Show")
            Themes.Add(&H6A, "Entertainment - Cooking")
            Themes.Add(&H6B, "Entertainment - Factual")
            Themes.Add(&H6C, "Entertainment - Fashion")
            Themes.Add(&H6D, "Entertainment - Gardening")
            Themes.Add(&H6E, "Entertainment - Travel")
            Themes.Add(&H6F, "Entertainment - Technology")
            Themes.Add(&H70, "Entertainment - Arts")
            Themes.Add(&H71, "Entertainment - Lifestyle")
            Themes.Add(&H72, "Entertainment - Home")
            Themes.Add(&H73, "Entertainment - Magazine")
            Themes.Add(&H74, "Entertainment - Medical")
            Themes.Add(&H75, "Entertainment - Review")
            Themes.Add(&H76, "Entertainment - Antiques")
            Themes.Add(&H77, "Entertainment - Motors")
            Themes.Add(&H78, "Entertainment - Art&Lit")
            Themes.Add(&H79, "Entertainment - Ballet")
            Themes.Add(&H7A, "Entertainment - Opera")
            Themes.Add(&H7B, "")
            Themes.Add(&H7C, "")
            Themes.Add(&H7D, "")
            Themes.Add(&H7E, "")
            Themes.Add(&H7F, "")
            Themes.Add(&H80, "Music & Radio - Undefined")
            Themes.Add(&H81, "Music & Radio - Classical")
            Themes.Add(&H82, "Music & Radio - Folk and Country")
            Themes.Add(&H83, "Music & Radio - National Music")
            Themes.Add(&H84, "Music & Radio - Jazz")
            Themes.Add(&H85, "Music & Radio - Opera")
            Themes.Add(&H86, "Music & Radio - Rock&Pop")
            Themes.Add(&H87, "Music & Radio - Alternative Music")
            Themes.Add(&H88, "Music & Radio - Events")
            Themes.Add(&H89, "Music & Radio - Club and Dance")
            Themes.Add(&H8A, "Music & Radio - Hip Hop")
            Themes.Add(&H8B, "Music & Radio - Soul/R&B")
            Themes.Add(&H8C, "Music & Radio - Dance")
            Themes.Add(&H8D, "Music & Radio - Ballet")
            Themes.Add(&H8E, "")
            Themes.Add(&H8F, "Music & Radio - Current Affairs")
            Themes.Add(&H90, "Music & Radio - Features")
            Themes.Add(&H91, "Music & Radio - Arts & Lit.")
            Themes.Add(&H92, "Music & Radio - Factual")
            Themes.Add(&H93, "")
            Themes.Add(&H94, "")
            Themes.Add(&H95, "Music & Radio - Lifestyle")
            Themes.Add(&H96, "Music & Radio - News and Weather")
            Themes.Add(&H97, "Music & Radio - Easy Listening")
            Themes.Add(&H98, "Music & Radio - Discussion")
            Themes.Add(&H99, "Music & Radio - Entertainment")
            Themes.Add(&H9A, "Music & Radio - Religious")
            Themes.Add(&H9B, "")
            Themes.Add(&H9C, "")
            Themes.Add(&H9D, "")
            Themes.Add(&H9E, "")
            Themes.Add(&H9F, "")
            Themes.Add(&HA0, "News & Documentaries - Undefined")
            Themes.Add(&HA1, "News & Documentaries - Business")
            Themes.Add(&HA2, "News & Documentaries - World Cultures")
            Themes.Add(&HA3, "News & Documentaries - Adventure")
            Themes.Add(&HA4, "News & Documentaries - Biography")
            Themes.Add(&HA5, "News & Documentaries - Educational")
            Themes.Add(&HA6, "News & Documentaries - Feature")
            Themes.Add(&HA7, "News & Documentaries - Politics")
            Themes.Add(&HA8, "News & Documentaries - News")
            Themes.Add(&HA9, "News & Documentaries - Nature")
            Themes.Add(&HAA, "News & Documentaries - Religious")
            Themes.Add(&HAB, "News & Documentaries - Science")
            Themes.Add(&HAC, "News & Documentaries - Showbiz")
            Themes.Add(&HAD, "News & Documentaries - War Documentary")
            Themes.Add(&HAE, "News & Documentaries - Historical")
            Themes.Add(&HAF, "News & Documentaries - Ancient")
            Themes.Add(&HB0, "News & Documentaries - Transport")
            Themes.Add(&HB1, "News & Documentaries - Docudrama")
            Themes.Add(&HB2, "News & Documentaries - World Affairs")
            Themes.Add(&HB3, "News & Documentaries - Features")
            Themes.Add(&HB4, "News & Documentaries - Showbiz")
            Themes.Add(&HB5, "News & Documentaries - Politics")
            Themes.Add(&HB6, "News & Documentaries - Transport")
            Themes.Add(&HB7, "News & Documentaries - World Affairs")
            Themes.Add(&HB8, "")
            Themes.Add(&HB9, "")
            Themes.Add(&HBA, "")
            Themes.Add(&HBB, "")
            Themes.Add(&HBC, "")
            Themes.Add(&HBD, "")
            Themes.Add(&HBE, "")
            Themes.Add(&HBF, "")
            Themes.Add(&HC0, "Movie")
            Themes.Add(&HC1, "Movie - Action")
            Themes.Add(&HC2, "Movie - Animation")
            Themes.Add(&HC3, "")
            Themes.Add(&HC4, "Movie - Comedy")
            Themes.Add(&HC5, "Movie - Family")
            Themes.Add(&HC6, "Movie - Drama")
            Themes.Add(&HC7, "")
            Themes.Add(&HC8, "Movie - Sci-Fi")
            Themes.Add(&HC9, "Movie - Thriller")
            Themes.Add(&HCA, "Movie - Horror")
            Themes.Add(&HCB, "Movie - Romance")
            Themes.Add(&HCC, "Movie - Musical")
            Themes.Add(&HCD, "Movie - Mystery")
            Themes.Add(&HCE, "Movie - Western")
            Themes.Add(&HCF, "Movie - Factual")
            Themes.Add(&HD0, "Movie - Fantasy")
            Themes.Add(&HD1, "Movie - Erotic")
            Themes.Add(&HD2, "Movie - Adventure")
            Themes.Add(&HD3, "Movies - War")
            Themes.Add(&HD4, "")
            Themes.Add(&HD5, "")
            Themes.Add(&HD6, "")
            Themes.Add(&HD7, "")
            Themes.Add(&HD8, "")
            Themes.Add(&HD9, "")
            Themes.Add(&HDA, "")
            Themes.Add(&HDB, "")
            Themes.Add(&HDC, "")
            Themes.Add(&HDD, "")
            Themes.Add(&HDE, "")
            Themes.Add(&HDF, "")
            Themes.Add(&HE0, "Sports - Undefined")
            Themes.Add(&HE1, "Sports - American Football")
            Themes.Add(&HE2, "Sports - Athletics")
            Themes.Add(&HE3, "Sports - Baseball")
            Themes.Add(&HE4, "Sports - Basketball")
            Themes.Add(&HE5, "Sports - Boxing")
            Themes.Add(&HE6, "Sports - Cricket")
            Themes.Add(&HE7, "Sports - Fishing")
            Themes.Add(&HE8, "Sports - Football")
            Themes.Add(&HE9, "Sports - Golf")
            Themes.Add(&HEA, "Sports - Ice Hockey")
            Themes.Add(&HEB, "Sports - Motor Sport")
            Themes.Add(&HEC, "Sports - Racing")
            Themes.Add(&HED, "Sports - Rugby")
            Themes.Add(&HEE, "Sports - Equestrian")
            Themes.Add(&HEF, "Sports - Winter Sports")
            Themes.Add(&HF0, "Sports - Snooker / Pool")
            Themes.Add(&HF1, "Sports - Tennis")
            Themes.Add(&HF2, "Sports - Wrestling")
            Themes.Add(&HF3, "Sports - Darts")
            Themes.Add(&HF4, "Sports - Watersports")
            Themes.Add(&HF5, "Sports - Extreme")
            Themes.Add(&HF6, "Sports - Other")
            Themes.Add(&HF7, "")
            Themes.Add(&HF8, "")
            Themes.Add(&HF9, "")
            Themes.Add(&HFA, "")
            Themes.Add(&HFB, "")
            Themes.Add(&HFC, "")
            Themes.Add(&HFD, "")
            Themes.Add(&HFE, "")
            Themes.Add(&HFF, "")
        End If
    End Sub

    Public Sub LoadSettings()
        Dim expression As Object = _syncObj
        ObjectFlowControl.CheckForSyncLockOnValueType(expression)
        SyncLock expression
            Dim str As String
            Dim time As DateTime
            Dim num2 As Double
            _isloading = True
            Dim strArray As String() = New String(&H15 - 1) {}
            strArray(0) = "112,.,Entertainment"
            strArray(1) = "31,.,LifeStyle & Culture"
            strArray(2) = "208,.,Movies"
            strArray(3) = "240,.,Sports"
            strArray(4) = "176,.,News"
            strArray(5) = "127,.,Documents"
            strArray(6) = "80,.,Kids"
            strArray(7) = "159,.,Music"
            strArray(8) = "48,.,Shopping"
            strArray(9) = "191,.,Religion"
            strArray(10) = "223,.,International"
            strArray(11) = "95,.,Gaming & Dating"
            strArray(12) = "255,.,Specialist"
            strArray(13) = "63,.,Adult"
            strArray(14) = "16,.,Sky Help"
            strArray(15) = "-1,., "
            strArray(&H10) = "-1,., "
            strArray(&H11) = "-1,., "
            strArray(&H12) = "-1,., "
            strArray(&H13) = "-1,., "
            Dim separator As String() = New String() {",.,"}
            Dim num As Integer = 1
Label_00E5:
            str = GetSkySetting(("Cat" & Conversions.ToString(num)), strArray((num - 1)))
            Dim strArray3 As String() = New String(3 - 1) {}
            strArray3 = str.Split(separator, StringSplitOptions.None)
            Try
                If Not Double.TryParse(strArray3(0), num2) Then
                    GoTo Label_0185
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                ProjectData.ClearProjectError()
                GoTo Label_0185
            End Try
            Dim str3 As String = strArray3(1)
            If (((num2 > -1) And (str3 <> "")) AndAlso Not cats.ContainsKey(CByte(Math.Round(num2)))) Then
                cats.Add(CByte(Math.Round(num2)), str3)
            End If
Label_0185:
            num += 1
            If (num <= 20) Then
                GoTo Label_00E5
            End If
            _modulation = Convert.ToInt32(GetSkySetting("modulation", -1))
            _grabtime = Convert.ToInt32(GetSkySetting("GrabTime", 60))
            _frequency = Convert.ToInt32(GetSkySetting("frequency", &HB3B7D0))
            _symbolrate = Convert.ToInt32(GetSkySetting("SymbolRate", &H6B6C))
            _nid = Convert.ToInt32(GetSkySetting("NID", 2))
            _polarisation = Convert.ToInt32(GetSkySetting("polarisation", 3))
            _serviceid = Convert.ToInt32(GetSkySetting("ServiceID", &H1038))
            _transportid = Convert.ToInt32(GetSkySetting("TransportID", &H7D4))
            _autoupdate = Convert.ToBoolean(GetSkySetting("AutoUpdate", True))
            _useextrainfo = Convert.ToBoolean(GetSkySetting("useExtraInfo", True))
            _updatechannels = Convert.ToBoolean(GetSkySetting("UpdateChannels", True))
            _everyhour = Convert.ToBoolean(GetSkySetting("EveryHour", True))
            _ondaysat = Convert.ToBoolean(GetSkySetting("OnDaysAt", False))
            _updatelogos = Convert.ToBoolean(GetSkySetting("UpdateLogos", False))
            _mon = Convert.ToBoolean(GetSkySetting("Mon", True))
            _tue = Convert.ToBoolean(GetSkySetting("Tue", True))
            _wed = Convert.ToBoolean(GetSkySetting("Wed", True))
            _thu = Convert.ToBoolean(GetSkySetting("Thu", True))
            _fri = Convert.ToBoolean(GetSkySetting("Fri", True))
            _sat = Convert.ToBoolean(GetSkySetting("Sat", True))
            _sun = Convert.ToBoolean(GetSkySetting("Sun", True))
            If DateTime.TryParse(GetSkySetting("UpdateTime", DateAndTime.Now.ToString), time) Then
                _updatetime = time
            End If
            _replacesdwithhd = Convert.ToBoolean(GetSkySetting("ReplaceSDwithHD", True))
            _ignorescrambled = Convert.ToBoolean(GetSkySetting("IgnoreScrambled", False))
            _usenotsetmodsd = Convert.ToBoolean(GetSkySetting("UseNotSetModSD", False))
            _usenotsetmodhd = Convert.ToBoolean(GetSkySetting("UseNotSetModHD", False))
            _updateepg = Convert.ToBoolean(GetSkySetting("UpdateEPG", True))
            _updateinterval = Convert.ToInt32(GetSkySetting("UpdateInterval", 3))
            _regionid = Convert.ToInt32(GetSkySetting("RegionID", 0))
            _bouquetid = Convert.ToInt32(GetSkySetting("BouquetID", 0))
            _isloading = Convert.ToBoolean(GetSkySetting("IsLoading", True))
            Dim skySetting As String = GetSkySetting("CardMap", "")
            returnlist.Clear()
            If (skySetting.Length > 0) Then
                If (skySetting.Length = 1) Then
                    If Not returnlist.Contains(Convert.ToInt32(skySetting)) Then
                        returnlist.Add(Convert.ToInt32(skySetting))
                    End If
                Else
                    Dim source As String() = skySetting.Split(New Char() {","c})
                    If (Enumerable.Count(Of String)(source) > 0) Then
                        Dim str4 As String
                        For Each str4 In source
                            If Not returnlist.Contains(Convert.ToInt32(str4)) Then
                                returnlist.Add(Convert.ToInt32(str4))
                            End If
                        Next
                    End If
                End If
            End If
            If DateTime.TryParse(GetSkySetting("LastUpdate", DateTime.Now.ToString), time) Then
                _lastupdate = time
            End If
            If DateTime.TryParse(GetSkySetting("UpdateTime", DateTime.Now.ToString), time) Then
                _updatetime = time
            End If
            _usethrottle = Convert.ToBoolean(GetSkySetting("UseThrottle", True))
            _logodirectory = GetSkySetting("LogoDirectory", (Environment.GetFolderPath(SpecialFolder.CommonApplicationData) & "\Team MediaPortal\MediaPortal\Thumbs\tv\logos"))
            _useskynumbers = Convert.ToBoolean(GetSkySetting("UseSkyNumbers", True))
            _useskycategories = Convert.ToBoolean(GetSkySetting("UseSkyCategories", True))
            _useskyregions = Convert.ToBoolean(GetSkySetting("UseSkyRegions", True))
            _deleteoldchannels = Convert.ToBoolean(GetSkySetting("DeleteOldChannels", True))
            _oldchannelfolder = GetSkySetting("OldChannelFolder", "Old Sky Channels")
            _regionindex = Convert.ToInt32(GetSkySetting("RegionIndex", 0))
            _cardtouseindex = Convert.ToInt32(GetSkySetting("CardToUseIndex", 0))
            _diseqc = Convert.ToInt32(GetSkySetting("DiseqC", -1))
            _switchingfrequency = Convert.ToInt32(GetSkySetting("SwitchingFrequency", &HB28720))
            _isgrabbing = Convert.ToBoolean(GetSkySetting("IsGrabbing", False))
            _isloading = False
            _settingsloaded = True
        End SyncLock
    End Sub

    Public ReadOnly Property SettingsLoaded As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _settingsloaded
            End SyncLock
        End Get
    End Property

    Public Property UpdateLogos As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _updatelogos
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _updatelogos) Then
                    _updatelogos = value
                    UpdateSetting("UpdateLogos", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

    Public Property UseThrottle As Boolean
        Get
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                Return _usethrottle
            End SyncLock
        End Get
        Set(ByVal value As Boolean)
            Dim expression As Object = _syncObj
            ObjectFlowControl.CheckForSyncLockOnValueType(expression)
            SyncLock expression
                If (value <> _usethrottle) Then
                    _usethrottle = value
                    UpdateSetting("UseThrottle", value.ToString)
                End If
            End SyncLock
        End Set
    End Property

End Class

Public Class SkyGrabber
    'Events
    Public Event OnActivateControls As OnActivateControlsEventHandler
    Public Event OnMessage As OnMessageEventHandler

    'Fields
    Private ReadOnly _layer As TvBusinessLayer = New TvBusinessLayer
    <AccessedThroughProperty("Sky")> _
    Private _Sky As CustomDataGRabber
    Public BouquetIDtoUse As Integer
    Public Bouquets As Dictionary(Of Integer, SkyBouquet) = New Dictionary(Of Integer, SkyBouquet)
    Private ReadOnly CardstoMap As List(Of Card) = New List(Of Card)
    Public CatsDesc As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public Channels As Dictionary(Of Integer, Sky_Channel) = New Dictionary(Of Integer, Sky_Channel)
    Public completedSummaryDataCarousels As List(Of Integer) = New List(Of Integer)
    Public completedTitleDataCarousels As List(Of Integer) = New List(Of Integer)
    Private CPUHog As Integer = 0
    Private DVBSChannel As DVBSChannel
    Public firstask As Boolean = True
    Private FirstLCN As LCNHolder
    Private GotAllSDT As Boolean = False
    Private GotAllTID As Boolean = False
    Public GrabEPG As Boolean
    Public lasttime As DateTime
    Public LogosToGet As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private MapCards As List(Of Integer)
    Private MaxThisCanDo As Integer = 0
    Private nH As HuffmanTreeNode
    Public NITGot As Boolean = False
    Public NITInfo As Dictionary(Of Integer, NITSatDescriptor) = New Dictionary(Of Integer, NITSatDescriptor)
    Private numberBouquetsPopulated As Integer = 0
    Private numberSDTPopulated As String = ""
    Private numberTIDPopulated As Integer = 0
    Private ReadOnly orignH As HuffmanTreeNode = New HuffmanTreeNode
    Public PacketCount As Integer = 0
    Public RegionIDtoUse As Integer
    Public Regions As List(Of String) = New List(Of String)
    Private SDTCount As Integer = 0
    Public SDTInfo As Dictionary(Of String, SDTInfo) = New Dictionary(Of String, SDTInfo)
    Private ReadOnly Settings As Settings = New Settings
    Private start As DateTime
    Private summariesDecoded As Integer = 0
    Public summaryDataCarouselStartLookup As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Public titleDataCarouselStartLookup As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Public titlesDecoded As Integer = 0
    Public UseThrottle As Boolean = Settings.UseThrottle

    Public Sub Reset()
        Channels.Clear()
        Bouquets.Clear()
        SDTInfo.Clear()
        NITInfo.Clear()
        numberBouquetsPopulated = 0
        titlesDecoded = 0
        summariesDecoded = 0
        titleDataCarouselStartLookup.Clear()
        completedTitleDataCarousels.Clear()
        summaryDataCarouselStartLookup.Clear()
        completedSummaryDataCarousels.Clear()
        CatsDesc.Clear()
        orignH.Clear()
        CPUHog = 0
        MaxThisCanDo = 0
        start = Now
        NITGot = False
        BouquetIDtoUse = Settings.BouquetID
        RegionIDtoUse = Settings.RegionID
        numberSDTPopulated = ""
        GotAllSDT = False
        numberTIDPopulated = 0
        GotAllTID = False
    End Sub

    'Nested Types
    Public Delegate Sub OnActivateControlsEventHandler()
    Public Delegate Sub OnMessageEventHandler(ByVal [Text] As String, ByVal UpdateLast As Boolean)

    'Methods
    Public Function AreAllTitlesPopulated() As Object
        Return (completedTitleDataCarousels.Count = 8)
    End Function

    Public Function DoesTidCarryEpgTitleData(ByVal TableID As Integer) As Boolean
        Return ((((TableID = &HA0) Or (TableID = &HA1)) Or (TableID = &HA2)) Or (TableID = &HA3))
    End Function

    Public Function IsTitleDataCarouselOnPidComplete(ByVal pid As Integer) As Boolean
        Dim num As Integer
        For Each num In completedTitleDataCarousels
            If (num = pid) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub OnTitleReceived(ByVal pid As Integer, ByVal titleChannelEventUnionId As String)
        If titleDataCarouselStartLookup.ContainsKey(pid) Then
            If (titleDataCarouselStartLookup.Item(pid) = titleChannelEventUnionId) Then
                completedTitleDataCarousels.Add(pid)
            End If
        Else
            titleDataCarouselStartLookup.Add(pid, titleChannelEventUnionId)
        End If
    End Sub

    Public Function AreAllSummariesPopulated() As Object
        Return (completedSummaryDataCarousels.Count = 8)
    End Function

    Private Sub OnSummaryReceived(ByVal pid As Integer, ByVal summaryChannelEventUnionId As String)
        If summaryDataCarouselStartLookup.ContainsKey(pid) Then
            If (summaryDataCarouselStartLookup.Item(pid) = summaryChannelEventUnionId) Then
                completedSummaryDataCarousels.Add(pid)
                If Not Conversions.ToBoolean(AreAllSummariesPopulated) Then
                End If
            End If
        Else
            summaryDataCarouselStartLookup.Add(pid, summaryChannelEventUnionId)
        End If
    End Sub

    Public Function IsSummaryDataCarouselOnPidComplete(ByVal pid As Integer) As Boolean
        Dim num As Integer
        For Each num In completedSummaryDataCarousels
            If (num = pid) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub UpdateEPGEvent(ByRef channelId As Integer, ByVal eventId As Integer, ByVal SkyEvent As SkyEvent)
        If (Channels.ContainsKey(channelId) AndAlso Channels.Item(channelId).Events.ContainsKey(eventId)) Then
            Channels.Item(channelId).Events.Item(eventId) = SkyEvent
        End If
    End Sub

    Public Sub UpdateChannel(ByVal ChannelId As Integer, ByVal Channel As Sky_Channel)
        If Channels.ContainsKey(ChannelId) Then
            Channels.Item(ChannelId) = Channel
        End If
    End Sub

    Public Function GetEpgEvent(ByVal channelId As Long, ByVal eventId As Integer) As SkyEvent
        Dim channel As Sky_Channel = GetChannel(CInt(channelId))
        If Not channel.Events.ContainsKey(eventId) Then
            channel.Events.Add(eventId, New SkyEvent)
        End If
        Return channel.Events.Item(eventId)
    End Function

    Private Sub OnTitleSectionReceived(ByVal pid As Integer, ByVal section As Custom_Data_Grabber.Section)
        Try
            If (Not IsTitleDataCarouselOnPidComplete(pid) AndAlso DoesTidCarryEpgTitleData(section.table_id)) Then
                Dim data As Byte() = section.Data
                Dim num5 As Integer = ((((data(1) And 15) * &H100) + data(2)) - 2)
                If (section.section_length >= 20) Then
                    Dim channelId As Long = CLng(Math.Round(CDbl(((data(3) * 256) + data(4)))))
                    Dim num4 As Long = CLng(Math.Round(CDbl(((data(8) * 256) + data(9)))))
                    If Not ((channelId = 0) Or (num4 = 0)) Then
                        Dim num2 As Integer = 10
                        Dim num3 As Integer = 0
                        Do While (num2 < num5)
                            If (num3 > &H200) Then
                                Return
                            End If
                            num3 += 1
                            Dim eventId As Integer = CInt(Math.Round(CDbl(((data((num2 + 0)) * 256) + data((num2 + 1))))))
                            Dim num11 As Double = ((data((num2 + 2)) And 240) >> 4)
                            Dim num6 As Integer = CInt(Math.Round(CDbl((((data((num2 + 2)) And 15) * 256) + data((num2 + 3))))))
                            Dim titleChannelEventUnionId As String = (channelId.ToString & ":" & eventId.ToString)
                            OnTitleReceived(pid, titleChannelEventUnionId)
                            If IsTitleDataCarouselOnPidComplete(pid) Then
                                Return
                            End If
                            Dim epgEvent As SkyEvent = Me.GetEpgEvent(channelId, eventId)
                            If (epgEvent Is Nothing) Then
                                Return
                            End If
                            epgEvent.mjdStart = num4
                            epgEvent.EventID = eventId
                            Dim num10 As Integer = 4
                            Dim num7 As Integer = (num2 + num10)
                            Dim num12 As Integer = data((num7 + 0))
                            Dim length As Integer = (data((num7 + 1)) - 7)
                            If (num12 = &HB5) Then
                                epgEvent.StartTime = CInt((CLng(Math.Round(CDbl((data((num7 + 2)) * 512)))) Or CLng(Math.Round(CDbl((data((num7 + 3)) * 2))))))
                                epgEvent.Duration = CInt((CLng(Math.Round(CDbl((data((num7 + 4)) * 512)))) Or CLng(Math.Round(CDbl((data((num7 + 5)) * 2))))))
                                Dim num13 As Byte = data((num7 + 6))
                                epgEvent.Category = Conversions.ToString(num13)
                                epgEvent.SetFlags(data((num7 + 7)))
                                epgEvent.SetCategory(data((num7 + 8)))
                                epgEvent.seriesTermination = (((data((num7 + 8)) And &H40) >> 6) Xor 1)
                                If (length <= 0) Then
                                    num2 = (num2 + (num10 + num6))
                                End If
                                If (epgEvent.Title <> "") Then
                                    Return
                                End If
                                Dim destinationArray As Byte() = New Byte(&H1001 - 1) {}
                                If (((num7 + 9) + length) > data.Length) Then
                                    Return
                                End If
                                Array.Copy(data, (num7 + 9), destinationArray, 0, length)
                                epgEvent.Title = NewHuffman(destinationArray, length)
                                If (epgEvent.Title <> "") Then
                                    OnTitleDecoded()
                                End If
                                Dim num14 As Integer = CInt(channelId)
                                UpdateEPGEvent(num14, epgEvent.EventID, epgEvent)
                                channelId = num14
                            End If
                            num2 = (num2 + (num6 + num10))
                        Loop
                        If (num2 <> (num5 + 1)) Then
                        End If
                    End If
                End If
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            If (Not OnMessageEvent Is Nothing) Then
                OnMessageEvent.Invoke(("Error decoding title, " & exception.Message), False)
            End If
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Sub ParseNIT(ByVal data As Custom_Data_Grabber.Section, ByVal Length As Integer)
        Try
            If Not NITGot Then
                Dim buf As Byte() = data.Data
                Dim num9 As Integer = (buf(1) And &H80)
                Dim num7 As Integer = (((buf(1) And 15) * &H100) Or buf(2))
                Dim num5 As Integer = ((buf(3) * &H100) Or buf(4))
                Dim num11 As Integer = (CByte((buf(5) >> 1)) And &H1F)
                Dim num As Integer = (buf(5) And 1)
                Dim num8 As Integer = buf(6)
                Dim num3 As Integer = buf(7)
                Dim num4 As Integer = (((buf(8) And 15) * &H100) Or buf(9))
                Dim num2 As Integer = num4
                Dim index As Integer = 10
                Dim maxLen As Integer = 0
                Do While (num2 > 0)
                    Dim num13 As Integer = buf(index)
                    maxLen = (buf((index + 1)) + 2)
                    If (num13 = &H40) Then
                        Dim str As String = Encoding.GetEncoding("iso-8859-1").GetString(buf, (index + 2), (maxLen - 2))
                    End If
                    num2 = (num2 - maxLen)
                    index = (index + maxLen)
                Loop
                index = (10 + num4)
                If (index <= num7) Then
                    num2 = (((buf(index) And 15) * &H100) + buf((index + 1)))
                    index = (index + 2)
                    Do While (num2 > 0)
                        If ((index + 2) > num7) Then
                            Return
                        End If
                        Dim transportID As Integer = ((buf(index) * &H100) + buf((index + 1)))
                        Dim networkID As Integer = ((buf((index + 2)) * &H100) + buf((index + 3)))
                        Dim num16 As Integer = (((buf((index + 4)) And 15) * &H100) + buf((index + 5)))
                        index = (index + 6)
                        num2 = (num2 - 6)
                        Dim num14 As Integer = num16
                        Do While (num14 > 0)
                            If ((index + 2) > num7) Then
                                Return
                            End If
                            Dim num18 As Integer = buf(index)
                            maxLen = (buf((index + 1)) + 2)
                            If (num18 = &H43) Then
                                DVB_GetSatDelivSys(buf, index, maxLen, networkID, transportID)
                            End If
                            index = (index + maxLen)
                            num14 = (num14 - maxLen)
                            num2 = (num2 - maxLen)
                        Loop
                    Loop
                End If
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            If (Not OnMessageEvent Is Nothing) Then
                OnMessageEvent.Invoke("Error Parsing NIT", False)
            End If
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Sub DVB_GetSatDelivSys(ByVal b As Byte(), ByVal pointer As Integer, ByVal maxLen As Integer, ByVal NetworkID As Integer, ByVal TransportID As Integer)
        If ((b((pointer + 0)) = &H43) And (maxLen >= 13)) Then
            Dim num2 As Byte = b((pointer + 0))
            Dim num As Byte = b((pointer + 1))
            If (num <= 13) Then
                Dim descriptor As New NITSatDescriptor With { _
                    .TID = TransportID, _
                    .Frequency = (&H5F5E100 * (CByte((b((pointer + 2)) >> 4)) And 15)) _
                }
                Dim descriptor2 As NITSatDescriptor = descriptor
                descriptor2.Frequency = (descriptor2.Frequency + (100000000 * (b((pointer + 2)) And 15)))
                descriptor2 = descriptor
                descriptor2.Frequency = (descriptor2.Frequency + (1000000 * (CByte((b((pointer + 3)) >> 4)) And 15)))
                descriptor2 = descriptor
                descriptor2.Frequency = (descriptor2.Frequency + (100000 * (b((pointer + 3)) And 15)))
                descriptor2 = descriptor
                descriptor2.Frequency = (descriptor2.Frequency + (10000 * (CByte((b((pointer + 4)) >> 4)) And 15)))
                descriptor2 = descriptor
                descriptor2.Frequency = (descriptor2.Frequency + (1000 * (b((pointer + 4)) And 15)))
                descriptor2 = descriptor
                descriptor2.Frequency = (descriptor2.Frequency + (100 * (CByte((b((pointer + 5)) >> 4)) And 15)))
                descriptor2 = descriptor
                descriptor2.Frequency = (descriptor2.Frequency + (10 * (b((pointer + 5)) And 15)))
                descriptor2 = descriptor
                descriptor2.OrbitalPosition = (descriptor2.OrbitalPosition + (1000 * (CByte((b((pointer + 6)) >> 4)) And 15)))
                descriptor2 = descriptor
                descriptor2.OrbitalPosition = (descriptor2.OrbitalPosition + (100 * (b((pointer + 6)) And 15)))
                descriptor2 = descriptor
                descriptor2.OrbitalPosition = (descriptor2.OrbitalPosition + (10 * (CByte((b((pointer + 7)) >> 4)) And 15)))
                descriptor2 = descriptor
                descriptor2.OrbitalPosition = (descriptor2.OrbitalPosition + (b((pointer + 7)) And 15))

                descriptor.WestEastFlag = ((b((pointer + 8)) And &H80) >> 7)

                Dim num4 As Integer = ((b((pointer + 8)) And &H60) >> 5)
                descriptor.Polarisation = (num4 + 1)
                descriptor.isS2 = ((b((pointer + 8)) And 4) >> 2)
                If (descriptor.isS2 > 0) Then
                    Select Case ((b((pointer + 8)) And &H18) >> 3)
                        Case 0
                            descriptor.RollOff = 3
                            Exit Select
                        Case 1
                            descriptor.RollOff = 2
                            Exit Select
                        Case 2
                            descriptor.RollOff = 1
                            Exit Select
                    End Select
                Else
                    descriptor.RollOff = -1
                End If

                descriptor.Modulation = (b((pointer + 8)) And 3)

                descriptor.Symbolrate = (100000 * (CByte((b((pointer + 9)) >> 4)) And 15))
                descriptor2 = descriptor
                descriptor2.Symbolrate = (descriptor2.Symbolrate + (10000 * (b((pointer + 9)) And 15)))
                descriptor2 = descriptor
                descriptor2.Symbolrate = (descriptor2.Symbolrate + (1000 * (CByte((b((pointer + 10)) >> 4)) And 15)))
                descriptor2 = descriptor
                descriptor2.Symbolrate = (descriptor2.Symbolrate + (100 * (b((pointer + 10)) And 15)))
                descriptor2 = descriptor
                descriptor2.Symbolrate = (descriptor2.Symbolrate + (10 * (CByte((b((pointer + 11)) >> 4)) And 15)))
                descriptor2 = descriptor
                descriptor2.Symbolrate = (descriptor2.Symbolrate + (1 * (b((pointer + 11)) And 15)))

                Dim num3 As Integer = (b((pointer + 12)) And 15)

                Select Case num3
                    Case 0
                        num3 = 0
                        Exit Select
                    Case 1
                        num3 = 1
                        Exit Select
                    Case 2
                        num3 = 2
                        Exit Select
                    Case 3
                        num3 = 3
                        Exit Select
                    Case 4
                        num3 = 6
                        Exit Select
                    Case 5
                        num3 = 8
                        Exit Select
                    Case 6
                        num3 = 13
                        Exit Select
                    Case 7
                        num3 = 4
                        Exit Select
                    Case 8
                        num3 = 5
                        Exit Select
                    Case 9
                        num3 = 14
                        Exit Select
                    Case Else
                        num3 = 0
                        Exit Select
                End Select

                descriptor.FECInner = num3
                If Not NITInfo.ContainsKey(TransportID) Then
                    NITInfo.Add(TransportID, descriptor)
                Else
                    If Not GotAllTID Then
                        If (Not OnMessageEvent Is Nothing) Then
                            RaiseEvent OnMessage(("Got Network Information, " & Conversions.ToString(Me.NITInfo.Count) & " transponders"), False)
                        End If
                    End If
                    GotAllTID = True
                End If
            End If
        End If
    End Sub

    Public Sub OnTSPacket(ByVal Pid As Integer, ByVal Length As Integer, ByVal Data As Custom_Data_Grabber.Section)
        If (PacketCount > 500) Then
            If Settings.UseThrottle Then
                Thread.Sleep(200)
            End If
            PacketCount = 0
        End If
        PacketCount += 1
        Select Case Pid
            Case &H10
                If Not GotAllTID Then
                    ParseNIT(Data, Length)
                End If
                Exit Select
            Case &H11
                ParseChannels(Data, Length)
                Exit Select
            Case &H30, &H31, 50, &H33, &H34, &H35, &H36, &H37
                OnTitleSectionReceived(Pid, Data)
                Exit Select
            Case &H40, &H41, &H42, &H43, &H44, &H45, 70, &H47
                OnSummarySectionReceived(Pid, Data)
                Exit Select
        End Select
        If IsEverythingGrabbed() Then
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage("Everything Grabbed", False)
            End If
            Sky.SendComplete(0)
        End If
    End Sub

    Public Sub CreateGroups()
        If Settings.UseSkyCategories Then
            Dim list As New List(Of String)
            Dim separator As String() = New String() {",.,"}
            Dim textBoxNum As Integer = 1
            Do
                Dim categoryByTextBoxNum As String = Settings.GetCategoryByTextBoxNum(textBoxNum)
                If Not categoryByTextBoxNum.StartsWith("-1") Then
                    Dim strArray2 As String() = New String(3 - 1) {}
                    strArray2 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
                    If Not list.Contains(strArray2(1)) Then
                        list.Add(strArray2(1))
                    End If
                End If
                textBoxNum += 1
            Loop While (textBoxNum <= 20)
            Dim num As Integer = 1
            Dim str2 As String
            For Each str2 In list
                _layer.CreateGroup(str2)
                Dim groupByName As ChannelGroup = _layer.GetGroupByName(str2)
                groupByName.SortOrder = num
                groupByName.Persist()
                num += 1
            Next
        End If
        'Original Sky code.
        'If Settings.UseSkyCategories Then
        '    Dim groups As New List(Of String)
        '    If Settings.GetSkySetting("CatByte20", "-1") <> "-1" And Settings.GetSkySetting("CatText20", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText20", ""))
        '    If Settings.GetSkySetting("CatByte19", "-1") <> "-1" And Settings.GetSkySetting("CatText19", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText19", ""))
        '    If Settings.GetSkySetting("CatByte18", "-1") <> "-1" And Settings.GetSkySetting("CatText18", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText18", ""))
        '    If Settings.GetSkySetting("CatByte17", "-1") <> "-1" And Settings.GetSkySetting("CatText17", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText17", ""))
        '    If Settings.GetSkySetting("CatByte16", "-1") <> "-1" And Settings.GetSkySetting("CatText16", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText16", ""))
        '    If Settings.GetSkySetting("CatByte15", "-1") <> "-1" And Settings.GetSkySetting("CatText15", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText15", ""))
        '    If Settings.GetSkySetting("CatByte14", "-1") <> "-1" And Settings.GetSkySetting("CatText14", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText14", ""))
        '    If Settings.GetSkySetting("CatByte13", "-1") <> "-1" And Settings.GetSkySetting("CatText13", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText13", ""))
        '    If Settings.GetSkySetting("CatByte12", "-1") <> "-1" And Settings.GetSkySetting("CatText12", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText12", ""))
        '    If Settings.GetSkySetting("CatByte11", "-1") <> "-1" And Settings.GetSkySetting("CatText11", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText11", ""))
        '    If Settings.GetSkySetting("CatByte10", "-1") <> "-1" And Settings.GetSkySetting("CatText10", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText10", ""))
        '    If Settings.GetSkySetting("CatByte9", "-1") <> "-1" And Settings.GetSkySetting("CatText9", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText9", ""))
        '    If Settings.GetSkySetting("CatByte8", "-1") <> "-1" And Settings.GetSkySetting("CatText8", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText8", ""))
        '    If Settings.GetSkySetting("CatByte7", "-1") <> "-1" And Settings.GetSkySetting("CatText7", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText7", ""))
        '    If Settings.GetSkySetting("CatByte6", "-1") <> "-1" And Settings.GetSkySetting("CatText6", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText6", ""))
        '    If Settings.GetSkySetting("CatByte5", "-1") <> "-1" And Settings.GetSkySetting("CatText5", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText5", ""))
        '    If Settings.GetSkySetting("CatByte4", "-1") <> "-1" And Settings.GetSkySetting("CatText4", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText4", ""))
        '    If Settings.GetSkySetting("CatByte3", "-1") <> "-1" And Settings.GetSkySetting("CatText3", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText3", ""))
        '    If Settings.GetSkySetting("CatByte2", "-1") <> "-1" And Settings.GetSkySetting("CatText2", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText2", ""))
        '    If Settings.GetSkySetting("CatByte1", "-1") <> "-1" And Settings.GetSkySetting("CatText1", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText1", ""))
        '    Dim a As Integer = groups.Count
        '    For Each Name As String In groups
        '        _layer.CreateGroup(Name)
        '        Dim group1 As ChannelGroup
        '        group1 = _layer.GetGroupByName(Name)
        '        group1.SortOrder = a
        '        group1.Persist()
        '        a -= 1
        '    Next
        'End If

    End Sub

    Public Sub UpdateAddChannels()
        Try
            Dim diseqC As Integer = Settings.DiseqC
            Dim useSkyNumbers As Boolean = Settings.UseSkyNumbers
            Dim switchingFrequency As Integer = Settings.SwitchingFrequency
            Dim useSkyRegions As Boolean = Settings.UseSkyRegions
            Dim useSkyCategories As Boolean = Settings.UseSkyCategories
            Dim ChannelsAdded As Integer = 0
            Dim useNotSetModSD As Boolean = Settings.UseNotSetModSD
            Dim useNotSetModHD As Boolean = Settings.UseNotSetModHD
            Dim ignoreScrambled As Boolean = Settings.IgnoreScrambled
            Dim str As String = (Settings.LogoDirectory & "\")
            Dim updateLogos As Boolean = Settings.UpdateLogos
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage("", False)
            End If
            Dim pair As KeyValuePair(Of Integer, Sky_Channel)
            For Each pair In Channels
                Dim detail As TuningDetail
                ChannelsAdded += 1
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage("(" & ChannelsAdded & "/" & Channels.Count & ") Channels sorted", True)
                End If
                If Settings.UseThrottle Then
                    Thread.Sleep(200)
                End If
                Dim scannedchannel As Sky_Channel = pair.Value
                Dim key As Integer = pair.Key
                If (key < 1) Then
                    Continue For
                End If
                Dim channel As New DVBSChannel
                If (((scannedchannel.NID = 0) Or (scannedchannel.TID = 0)) Or (scannedchannel.SID = 0)) Then
                    Continue For
                End If
                Dim channelbySID As SDTInfo = GetChannelbySID(scannedchannel.NID & "-" & scannedchannel.TID & "-" & scannedchannel.SID)
                If (channelbySID Is Nothing) Then
                    Continue For
                End If
                If (channelbySID.SID < 1) Then
                    channelbySID.SID = scannedchannel.SID
                End If
                If (channelbySID.ChannelName = "") Then
                    channelbySID.ChannelName = channelbySID.SID
                End If
                If (channelbySID.Provider = "") Then
                    channelbySID.Provider = "BSkyB"
                End If
                If (ignoreScrambled And channelbySID.isFTA) Then
                    Continue For
                End If
                Dim channelbyExternalID As Channel = _layer.GetChannelbyExternalID(("SKYUK:" & scannedchannel.ChannelID.ToString))
                If (Not channelbyExternalID Is Nothing) Then
                    Dim list As List(Of TuningDetail) = DirectCast(channelbyExternalID.ReferringTuningDetail, List(Of TuningDetail))
                    Dim detail2 As TuningDetail
                    For Each detail2 In list
                        If ((detail2.ChannelType = 3) And (detail2.NetworkId = 2)) Then
                            detail = detail2
                            Exit For
                        End If
                    Next
                End If
                If Not detail Is Nothing Then
                    GoTo Label_072B
                End If
Label_0299:
                If Not NITInfo.ContainsKey(scannedchannel.TID) Then
                    'OnMessageEvent = OnMessageEvent
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage("No NIT found for : " & scannedchannel.SID, False)
                    End If

                    If (Not OnMessageEvent Is Nothing) Then
                        'OnMessageEvent.Invoke("", False)
                        RaiseEvent OnMessage("", False)
                    End If
                    Continue For
                End If
                Dim channelNumber As Integer = &H2710
                Dim flag8 As Boolean = True
                If (useSkyNumbers AndAlso Operators.ConditionalCompareObjectGreater(scannedchannel.LCNCount, 0, False)) Then
                    If scannedchannel.ContainsLCN(BouquetIDtoUse, RegionIDtoUse) Then
                        channelNumber = scannedchannel.GetLCN(BouquetIDtoUse, RegionIDtoUse).SkyNum
                    ElseIf scannedchannel.ContainsLCN(BouquetIDtoUse, &HFF) Then
                        channelNumber = scannedchannel.GetLCN(BouquetIDtoUse, &HFF).SkyNum
                    End If
                    If (channelNumber = &H2710) Then
                        flag8 = False
                    End If
                End If
                Dim DBChannel As Channel = _layer.AddNewChannel(channelbySID.ChannelName, channelNumber)
                Dim descriptor As NITSatDescriptor = NITInfo.Item(scannedchannel.TID)
                DVBSChannel.BandType = BandType.Universal
                DVBSChannel.DisEqc = DirectCast(diseqC, DisEqcType)
                DVBSChannel.FreeToAir = True
                DVBSChannel.Frequency = descriptor.Frequency
                DVBSChannel.SymbolRate = descriptor.Symbolrate
                DVBSChannel.InnerFecRate = DirectCast(descriptor.FECInner, BinaryConvolutionCodeRate)
                DVBSChannel.IsRadio = channelbySID.isRadio
                DVBSChannel.IsTv = channelbySID.isTV
                DVBSChannel.FreeToAir = Not channelbySID.isFTA
                DBChannel.ChannelNumber = channelNumber
                DBChannel.SortOrder = channelNumber
                DVBSChannel.LogicalChannelNumber = channelNumber
                DBChannel.VisibleInGuide = flag8
                If (((descriptor.isS2 And -(useNotSetModHD > False)) Or -(((descriptor.isS2 = 0) And useNotSetModSD) > False)) > 0) Then
                    DVBSChannel.ModulationType = ModulationType.ModNotSet
                Else
                    Select Case descriptor.Modulation
                        Case 1
                            If (descriptor.isS2 <= 0) Then
                                Exit Select
                            End If
                            DVBSChannel.ModulationType = ModulationType.ModNbcQpsk
                            GoTo Label_0520
                        Case 2
                            If (descriptor.isS2 <= 0) Then
                                GoTo Label_0506
                            End If
                            DVBSChannel.ModulationType = ModulationType.ModNbc8Psk
                            GoTo Label_0520
                        Case Else
                            DVBSChannel.ModulationType = ModulationType.ModNotDefined
                            GoTo Label_0520
                    End Select
                    DVBSChannel.ModulationType = ModulationType.ModQpsk
                End If
                GoTo Label_0520
Label_0506:
                DVBSChannel.ModulationType = ModulationType.ModNotDefined
Label_0520:
                DVBSChannel.Name = channelbySID.ChannelName
                DVBSChannel.NetworkId = scannedchannel.NID
                DVBSChannel.Pilot = Pilot.NotSet
                DVBSChannel.Rolloff = RollOff.NotSet
                If (descriptor.isS2 = 1) Then
                    DVBSChannel.Rolloff = DirectCast(descriptor.RollOff, RollOff)
                End If
                DVBSChannel.PmtPid = 0
                DVBSChannel.Polarisation = DirectCast(descriptor.Polarisation, Polarisation)
                DVBSChannel.Provider = channelbySID.Provider
                DVBSChannel.ServiceId = scannedchannel.SID
                DVBSChannel.TransportId = scannedchannel.TID
                DVBSChannel.SwitchingFrequency = switchingFrequency
                DBChannel.IsRadio = channelbySID.isRadio
                DBChannel.IsTv = channelbySID.isTV
                DBChannel.ExternalId = ("SKYUK:" & scannedchannel.ChannelID.ToString)
                DBChannel.Persist()
                _layer.AddTuningDetails(DBChannel, DVBSChannel)
                MapChannelToCards(DBChannel)
                AddChannelToGroups(DBChannel, channelbySID, DVBSChannel, useSkyCategories)
                Dim str3 As String = channelbySID.ChannelName.Replace("\", "_").Replace("/", "_").Replace("|", "_").Replace(":", "_").Replace("*", "_").Replace("?", "_").Replace("<", "_").Replace(">", "_")
                Dim str2 As String = (str & str3 & ".png")
                If Not LogosToGet.ContainsKey(scannedchannel.ChannelID) Then
                    LogosToGet.Add(scannedchannel.ChannelID, str2)
                End If
                Continue For
Label_072B:
                DBChannel = detail.ReferencedChannel
                If (DBChannel.ExternalId <> ("SKYUK:" & key.ToString)) Then
                    GoTo Label_0299
                End If
                Dim tuningChannel As DVBSChannel = DirectCast(_layer.GetTuningChannel(detail), DVBSChannel)
                If tuningChannel Is Nothing OrElse DBChannel Is Nothing OrElse Not SDTInfo.ContainsKey(scannedchannel.NID & "-" & scannedchannel.TID & "-" & scannedchannel.SID) Then
                    Continue For
                End If
                Dim flag10 As Boolean = False
                Dim flag9 As Boolean = False
                Dim sDT As SDTInfo = SDTInfo.Item(scannedchannel.NID & "-" & scannedchannel.TID & "-" & scannedchannel.SID)
                If ((DBChannel.DisplayName <> sDT.ChannelName) Or (detail.Name <> sDT.ChannelName)) Then

                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage(("Channel " & DBChannel.DisplayName & " name changed to " & sDT.ChannelName), False)
                    End If
                    DBChannel.DisplayName = sDT.ChannelName
                    tuningChannel.Name = sDT.ChannelName
                    If Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(scannedchannel.LCNCount, 0, False), Not DBChannel.VisibleInGuide)) Then
                        DBChannel.VisibleInGuide = True
                        If (Not OnMessageEvent Is Nothing) Then
                            RaiseEvent OnMessage(String.Concat(New String() {"Channel ", DBChannel.DisplayName, " is now part of the EPG making visible ", sDT.ChannelName, "."}), False)
                        End If
                    End If
                    flag10 = True
                End If
                If (tuningChannel.Provider <> sDT.Provider) Then
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage(String.Concat(New String() {"Channel ", DBChannel.DisplayName, " Provider name changed to ", sDT.Provider, "."}), False)
                    End If
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage("", False)
                    End If
                    tuningChannel.Provider = sDT.Provider
                    flag10 = True
                End If
                If (detail.TransportId = scannedchannel.TID) Then
                    GoTo Label_0BD2
                End If
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage(("Channel : " & DBChannel.DisplayName & " tuning details changed."), False)
                End If
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage("", False)
                End If
                If Not NITInfo.ContainsKey(scannedchannel.TID) Then
                    Continue For
                End If
                Dim descriptor2 As NITSatDescriptor = NITInfo.Item(scannedchannel.TID)
                tuningChannel.BandType = BandType.Universal
                tuningChannel.Frequency = descriptor2.Frequency
                tuningChannel.SymbolRate = descriptor2.Symbolrate
                tuningChannel.InnerFecRate = DirectCast(descriptor2.FECInner, BinaryConvolutionCodeRate)
                If (((descriptor2.isS2 And -(useNotSetModHD > False)) Or -(((descriptor2.isS2 = 0) And useNotSetModSD) > False)) > 0) Then
                    tuningChannel.ModulationType = ModulationType.ModNotSet
                Else
                    Select Case descriptor2.Modulation
                        Case 1
                            If (descriptor2.isS2 <= 0) Then
                                Exit Select
                            End If
                            tuningChannel.ModulationType = ModulationType.ModNbcQpsk
                            GoTo Label_0B34
                        Case 2
                            If (descriptor2.isS2 <= 0) Then
                                GoTo Label_0B22
                            End If
                            tuningChannel.ModulationType = ModulationType.ModNbc8Psk
                            GoTo Label_0B34
                        Case Else
                            tuningChannel.ModulationType = ModulationType.ModNotDefined
                            GoTo Label_0B34
                    End Select
                    tuningChannel.ModulationType = ModulationType.ModQpsk
                End If
                GoTo Label_0B34
Label_0B22:
                tuningChannel.ModulationType = ModulationType.ModNotDefined
Label_0B34:
                tuningChannel.Pilot = Pilot.NotSet
                tuningChannel.Rolloff = RollOff.NotSet
                If (descriptor2.isS2 = 1) Then
                    tuningChannel.Rolloff = DirectCast(descriptor2.RollOff, RollOff)
                End If
                tuningChannel.PmtPid = 0
                tuningChannel.Polarisation = DirectCast(descriptor2.Polarisation, Polarisation)
                tuningChannel.TransportId = scannedchannel.TID
                tuningChannel.SwitchingFrequency = switchingFrequency
                flag10 = True
                flag9 = True
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage(("Channel : " & DBChannel.DisplayName & " tuning details changed."), False)
                End If
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage("", False)
                End If
Label_0BD2:
                If (detail.ServiceId <> scannedchannel.SID) Then
                    tuningChannel.ServiceId = scannedchannel.SID
                    tuningChannel.PmtPid = 0
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage(("Channel : " & DBChannel.DisplayName & " serviceID changed."), False)
                    End If
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage("", False)
                    End If
                    flag10 = True
                    flag9 = True
                End If
                If useSkyRegions Then
                    Dim skyNum As Integer = &H2710
                    If (useSkyNumbers AndAlso Operators.ConditionalCompareObjectGreater(scannedchannel.LCNCount, 0, False)) Then
                        If scannedchannel.ContainsLCN(BouquetIDtoUse, RegionIDtoUse) Then
                            skyNum = scannedchannel.GetLCN(BouquetIDtoUse, RegionIDtoUse).SkyNum
                        ElseIf scannedchannel.ContainsLCN(BouquetIDtoUse, &HFF) Then
                            skyNum = scannedchannel.GetLCN(BouquetIDtoUse, &HFF).SkyNum
                        End If
                        If (((detail.ChannelNumber <> skyNum) And (skyNum < &H3E8)) Or ((skyNum = &H2710) And (DBChannel.ChannelNumber <> &H2710))) Then
                            If (Not OnMessageEvent Is Nothing) Then
                                RaiseEvent OnMessage(String.Concat(New String() {"Channel : ", DBChannel.DisplayName, " number has changed from : ", Conversions.ToString(tuningChannel.LogicalChannelNumber), " to : ", Conversions.ToString(skyNum), "."}), False)
                            End If
                            If (Not OnMessageEvent Is Nothing) Then
                                RaiseEvent OnMessage("", False)
                            End If
                            DBChannel.RemoveFromAllGroups()
                            detail.ChannelNumber = skyNum
                            DBChannel.ChannelNumber = skyNum
                            tuningChannel.LogicalChannelNumber = skyNum
                            DBChannel.SortOrder = skyNum
                            DBChannel.VisibleInGuide = True
                            flag10 = True
                            AddChannelToGroups(DBChannel, sDT, tuningChannel, useSkyCategories)
                        End If
                    End If
                End If
                If flag10 Then
                    If (updateLogos AndAlso ((DBChannel.DisplayName <> sDT.ChannelName) Or (detail.Name <> sDT.ChannelName))) Then
                        Dim str5 As String = sDT.ChannelName.Replace("\", "_").Replace("/", "_").Replace("|", "_").Replace(":", "_").Replace("*", "_").Replace("?", "_").Replace("<", "_").Replace(">", "_")
                        Dim str4 As String = (str & str5 & ".png")
                        If Not LogosToGet.ContainsKey(key) Then
                            LogosToGet.Add(key, str4)
                        End If
                    End If
                    DBChannel.Persist()
                    _layer.UpdateTuningDetails(DBChannel, tuningChannel, detail).Persist()
                    MapChannelToCards(DBChannel)
                    If flag9 Then
                        _layer.RemoveAllPrograms(DBChannel.IdChannel)
                    End If
                ElseIf updateLogos Then
                    Dim str7 As String = sDT.ChannelName.Replace("\", "_").Replace("/", "_").Replace("|", "_").Replace(":", "_").Replace("*", "_").Replace("?", "_").Replace("<", "_").Replace(">", "_")
                    Dim path As String = (str & str7 & ".png")
                    If (Not File.Exists(path) AndAlso Not LogosToGet.ContainsKey(key)) Then
                        LogosToGet.Add(key, path)
                    End If
                End If
            Next
            If updateLogos Then
                Dim enumerator As Collections.Generic.Dictionary(Of Integer, String).Enumerator
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage("Grabbing/Updating Logos", False)
                End If
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage("", False)
                End If
                Dim num7 As Integer = 1
                Try
                    enumerator = LogosToGet.GetEnumerator
                    Do While enumerator.MoveNext
                        Dim current As KeyValuePair(Of Integer, String) = enumerator.Current
                        If (Not OnMessageEvent Is Nothing) Then
                            RaiseEvent OnMessage((Conversions.ToString(num7) & "/" & Conversions.ToString(LogosToGet.Count) & " completed"), True)
                        End If
                        If Settings.UseThrottle Then
                            Thread.Sleep(200)
                        End If
                        UpdateCheckLogo(current.Key, current.Value)
                        num7 += 1
                    Loop
                Finally
                    enumerator.Dispose()
                End Try
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage(String.Concat(New String() {exception.Message, "-", exception.Source, "-", exception.StackTrace}), False)
            End If
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Sub UpdateAddChannelsNew()
        Dim enumerator As IEnumerator(Of Channel)
        Dim enumerator2 As Collections.Generic.Dictionary(Of Integer, Sky_Channel).Enumerator
        enumerator = Nothing
        enumerator2 = Nothing
        Dim diseqC As Integer = Settings.DiseqC
        Dim useSkyNumbers As Boolean = Settings.UseSkyNumbers
        Dim switchingFrequency As Integer = Settings.SwitchingFrequency
        Dim useSkyRegions As Boolean = Settings.UseSkyRegions
        Dim useSkyCategories As Boolean = Settings.UseSkyCategories
        Dim useNotSetModSD As Boolean = Settings.UseNotSetModSD
        Dim useNotSetModHD As Boolean = Settings.UseNotSetModHD
        Dim ignoreScrambled As Boolean = Settings.IgnoreScrambled
        Dim str As String = (Settings.LogoDirectory & "\")
        Dim updateLogos As Boolean = Settings.UpdateLogos
        If (Not OnMessageEvent Is Nothing) Then
            RaiseEvent OnMessage("", False)
        End If
        Dim list As IList(Of Channel) = Channel.ListAll
        Dim dictionary As New Dictionary(Of Integer, Channel)
        Try
            enumerator = list.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As Channel = enumerator.Current
                If current.ExternalId.StartsWith("SKYUK:") Then
                    Dim key As Integer = Convert.ToInt32(current.ExternalId.Replace("SKYUK:", ""))
                    If ((key <> 0) AndAlso Not dictionary.ContainsKey(key)) Then
                        If (current.ReferringTuningDetail.Count < 1) Then
                            current.Delete()
                            current.Persist()
                        End If
                        dictionary.Add(key, current)
                    End If
                End If
            Loop
        Finally
            If (Not enumerator Is Nothing) Then
                enumerator.Dispose()
            End If
        End Try
        Try
            enumerator2 = Channels.GetEnumerator
            Do While enumerator2.MoveNext
                Dim channel2 As Channel
                Dim pair As KeyValuePair(Of Integer, Sky_Channel) = enumerator2.Current
                'enumerator2.Current = pair
                Dim channel3 As Sky_Channel = pair.Value
                Dim num5 As Integer = pair.Key
                If (num5 < 1) Then
                    Continue Do
                End If
                If dictionary.ContainsKey(num5) Then
                    channel2 = dictionary.Item(num5)
                    GoTo Label_059B
                End If
                If Not NITInfo.ContainsKey(channel3.TID) Then
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage(("No NIT found for : " & Conversions.ToString(channel3.SID)), False)
                    End If
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage("", False)
                    End If
                    Continue Do
                End If
                If (((channel3.NID = 0) Or (channel3.TID = 0)) Or (channel3.SID = 0)) Then
                    Continue Do
                End If
                Dim channelbySID As SDTInfo = GetChannelbySID(String.Concat(New String() {Conversions.ToString(channel3.NID), "-", Conversions.ToString(channel3.TID), "-", Conversions.ToString(channel3.SID)}))
                If ((channelbySID Is Nothing) OrElse (ignoreScrambled And channelbySID.isFTA)) Then
                    Continue Do
                End If
                Dim channelNumber As Integer = &H2710
                Dim flag8 As Boolean = True
                If (useSkyNumbers AndAlso Operators.ConditionalCompareObjectGreater(channel3.LCNCount, 0, False)) Then
                    If channel3.ContainsLCN(BouquetIDtoUse, RegionIDtoUse) Then
                        channelNumber = channel3.GetLCN(BouquetIDtoUse, RegionIDtoUse).SkyNum
                    ElseIf channel3.ContainsLCN(BouquetIDtoUse, &HFF) Then
                        channelNumber = channel3.GetLCN(BouquetIDtoUse, &HFF).SkyNum
                    End If
                    If (channelNumber = &H2710) Then
                        flag8 = False
                    End If
                End If
                channel2 = _layer.AddNewChannel(channel3.Channel_Name, channelNumber)
                Dim descriptor As NITSatDescriptor = NITInfo.Item(channel3.TID)
                DVBSChannel.BandType = BandType.Universal
                DVBSChannel.DisEqc = DirectCast(diseqC, DisEqcType)
                DVBSChannel.FreeToAir = True
                DVBSChannel.Frequency = descriptor.Frequency
                DVBSChannel.SymbolRate = descriptor.Symbolrate
                DVBSChannel.InnerFecRate = DirectCast(descriptor.FECInner, BinaryConvolutionCodeRate)
                DVBSChannel.IsRadio = channelbySID.isRadio
                DVBSChannel.IsTv = channelbySID.isTV
                DVBSChannel.FreeToAir = Not channelbySID.isFTA
                channel2.SortOrder = channelNumber
                DVBSChannel.LogicalChannelNumber = channelNumber
                channel2.VisibleInGuide = flag8
                If (((descriptor.isS2 And -(useNotSetModHD > False)) Or -(((descriptor.isS2 = 0) And useNotSetModSD) > False)) > 0) Then
                    DVBSChannel.ModulationType = ModulationType.ModNotSet
                Else
                    Select Case descriptor.Modulation
                        Case 1
                            If (descriptor.isS2 <= 0) Then
                                Exit Select
                            End If
                            DVBSChannel.ModulationType = ModulationType.ModNbcQpsk
                            GoTo Label_0470
                        Case 2
                            If (descriptor.isS2 <= 0) Then
                                GoTo Label_0456
                            End If
                            DVBSChannel.ModulationType = ModulationType.ModNbc8Psk
                            GoTo Label_0470
                        Case Else
                            DVBSChannel.ModulationType = ModulationType.ModNotDefined
                            GoTo Label_0470
                    End Select
                    DVBSChannel.ModulationType = ModulationType.ModQpsk
                End If
                GoTo Label_0470
Label_0456:
                DVBSChannel.ModulationType = ModulationType.ModNotDefined
Label_0470:
                DVBSChannel.Name = channelbySID.ChannelName
                DVBSChannel.NetworkId = channel3.NID
                DVBSChannel.Pilot = Pilot.NotSet
                DVBSChannel.Rolloff = RollOff.NotSet
                If (descriptor.isS2 = 1) Then
                    DVBSChannel.Rolloff = DirectCast(descriptor.RollOff, RollOff)
                End If
                DVBSChannel.PmtPid = 0
                DVBSChannel.Polarisation = DirectCast(descriptor.Polarisation, Polarisation)
                DVBSChannel.Provider = channelbySID.Provider
                DVBSChannel.ServiceId = channel3.SID
                DVBSChannel.TransportId = channel3.TID
                DVBSChannel.SwitchingFrequency = switchingFrequency
                channel2.IsRadio = channelbySID.isRadio
                channel2.IsTv = channelbySID.isTV
                channel2.ExternalId = ("SKYUK:" & channel3.ChannelID.ToString)
                channel2.Persist()
                MapChannelToCards(channel2)
                AddChannelToGroups(channel2, channelbySID, DVBSChannel, useSkyCategories)
                _layer.AddTuningDetails(channel2, DVBSChannel)
Label_059B:
                If (channel2 Is Nothing) Then
                    If (OnMessageEvent Is Nothing) Then
                        Continue Do
                    End If
                    RaiseEvent OnMessage("Error Adding Channel to database, continuing", False)
                End If
            Loop
        Finally
            enumerator2.Dispose()
        End Try
    End Sub

    Private Sub MapChannelToCards(ByVal DBChannel As Channel)
        Dim enumerator As IEnumerator(Of Card)
        enumerator = Nothing
        Try
            enumerator = CardstoMap.GetEnumerator
            Do While enumerator.MoveNext
                Dim current As Card = enumerator.Current
                _layer.MapChannelToCard(current, DBChannel, False)
            Loop
        Finally
            enumerator.Dispose()
        End Try
    End Sub

    Private Sub AddChannelToGroups(ByVal DBChannel As Channel, ByVal SDT As SDTInfo, ByVal DVBSChannel As DVBSChannel, ByVal UseSkyCategories As Boolean)
        If DBChannel.IsTv Then
            _layer.AddChannelToGroup(DBChannel, TvGroupNames.AllChannels)
            If ((DVBSChannel.LogicalChannelNumber < 1000) AndAlso UseSkyCategories) Then
                If (Settings.GetCategory(CByte(SDT.Category)) <> SDT.Category.ToString) Then
                    _layer.AddChannelToGroup(DBChannel, Settings.GetCategory(CByte(SDT.Category)))
                End If
                If SDT.isHD Then
                    _layer.AddChannelToGroup(DBChannel, "HD Channels")
                End If
                If SDT.is3D Then
                    _layer.AddChannelToGroup(DBChannel, "3D Channels")
                End If
            End If
        ElseIf DBChannel.IsRadio Then
            _layer.AddChannelToRadioGroup(DBChannel, RadioGroupNames.AllChannels)
        Else
            _layer.AddChannelToGroup(DBChannel, TvGroupNames.AllChannels)
        End If
    End Sub

    Public Sub UpdateEPG()
        Dim time8 As DateTime
        Dim epgEvents As New TVController
        Dim updater As New EpgDBUpdater(epgEvents, "Sky TV EPG Updater", False)
        Dim list As New List(Of EpgChannel)
        Dim useExtraInfo As Boolean = Settings.useExtraInfo
        Dim now As DateTime = DateAndTime.Now
        If (_layer.GetPrograms(DateAndTime.Now, now.AddDays(1)).Count < 1) Then
            Dim aProgramList As New ProgramList
            Dim pair As KeyValuePair(Of Integer, Sky_Channel)
            For Each pair In Channels
                Dim channel2 As Sky_Channel = pair.Value
                Dim channel As Channel = _layer.GetChannelByTuningDetail(channel2.NID, channel2.TID, channel2.SID)
                If (Not channel Is Nothing) Then
                    Dim enumerator As Collections.Generic.Dictionary(Of Integer, SkyEvent).Enumerator
                    Try
                        enumerator = channel2.Events.GetEnumerator
                        Do While enumerator.MoveNext
                            Dim current As KeyValuePair(Of Integer, SkyEvent) = enumerator.Current
                            Dim event2 As SkyEvent = current.Value
                            If ((current.Value.EventID <> 0) And (current.Value.Title <> "")) Then
                                Dim summary As String
                                now = New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                                time8 = now
                                Dim startTime As DateTime = time8.AddSeconds((((event2.mjdStart + 2400000.5) - 2440587.5) * 86400)).AddSeconds(CDbl(event2.StartTime)).ToLocalTime
                                Dim endTime As DateTime = startTime.AddSeconds(CDbl(event2.Duration))
                                If useExtraInfo Then
                                    summary = (event2.Summary & " " & event2.DescriptionFlag)
                                Else
                                    summary = event2.Summary
                                End If
                                time8 = New DateTime(&H76C, 1, 1)
                                Dim item As New Program(channel.IdChannel, startTime, endTime, event2.Title, summary, Settings.GetTheme(Convert.ToInt32(event2.Category)), Program.ProgramState.None, time8, "", "", "", "", 0, event2.ParentalCategory, 0, event2.SeriesID.ToString, event2.seriesTermination)
                                aProgramList.Add(item)
                            End If
                        Loop
                    Finally
                        enumerator.Dispose()
                    End Try
                End If
            Next
            _layer.InsertPrograms(aProgramList, ThreadPriority.Highest)
        Else
            Dim num2 As Integer = 1
            RaiseEvent OnMessage("", False)
            Dim num As Integer = 0
            Dim pair3 As KeyValuePair(Of Integer, Sky_Channel)
            For Each pair3 In Me.Channels
                If Settings.UseThrottle Then
                    Thread.Sleep(200)
                End If
                num += 1
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage(String.Concat(New String() {"(", Conversions.ToString(num), "/", Conversions.ToString(Me.Channels.Count), ") Channels Updated"}), True)
                End If
                Dim channel5 As Sky_Channel = pair3.Value
                Dim epgChannel As New EpgChannel
                Dim channel3 As DVBBaseChannel = New DVBSChannel With { _
                    .NetworkId = channel5.NID, _
                    .TransportId = channel5.TID, _
                    .ServiceId = channel5.SID, _
                    .Name = String.Empty _
                }
                epgChannel.Channel = channel3
                Dim pair4 As KeyValuePair(Of Integer, SkyEvent)
                For Each pair4 In channel5.Events
                    Dim event3 As SkyEvent = pair4.Value
                    If ((pair4.Value.EventID <> 0) And (pair4.Value.Title <> "")) Then
                        Dim text As EpgLanguageText
                        time8 = New DateTime(&H7B2, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                        now = time8
                        Dim time6 As DateTime = now.AddSeconds((((event3.mjdStart + 2400000.5) - 2440587.5) * 86400)).AddSeconds(CDbl(event3.StartTime)).ToLocalTime
                        Dim time4 As DateTime = time6.AddSeconds(CDbl(event3.Duration))
                        If useExtraInfo Then
                            [text] = New EpgLanguageText("ALL", event3.Title, (event3.Summary & " " & event3.DescriptionFlag), Settings.GetTheme(Convert.ToInt32(event3.Category)), 0, event3.ParentalCategory, -1)
                        Else
                            [text] = New EpgLanguageText("ALL", event3.Title, event3.Summary, Settings.GetTheme(Convert.ToInt32(event3.Category)), 0, event3.ParentalCategory, -1)
                        End If
                        Dim program2 As New EpgProgram(time6, time4)
                        program2.Text.Add([text])
                        program2.SeriesId = event3.SeriesID.ToString
                        program2.SeriesTermination = event3.seriesTermination
                        epgChannel.Programs.Add(program2)
                    End If
                Next
                If (epgChannel.Programs.Count > 0) Then
                    updater.UpdateEpgForChannel(epgChannel)
                    If Settings.UseThrottle Then
                        Thread.Sleep(200)
                    End If
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage(("(" & Conversions.ToString(num2) & " Channels Updated"), True)
                    End If
                    num2 += 1
                End If
            Next
        End If
        epgEvents = Nothing
        updater = Nothing
        If (Not OnMessageEvent Is Nothing) Then
            RaiseEvent OnMessage("EPG Update Complete", False)
        End If
    End Sub

    Public Sub UpdateDataBase(ByVal err As Boolean, ByVal errormessage As String)
        If Not err Then
            If (Channels.Count < 100) Then
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage(("Error : Less than 100 channels found, Grabber found : " & Conversions.ToString(Me.Channels.Count)), False)
                End If
            Else
                CreateGroups()
                If Settings.UpdateChannels Then
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage("Moving/Deleting Old Channels", False)
                    End If
                    DeleteOldChannels()
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage("Moving/Deleting Old Channels Complete", False)
                    End If
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage("Updating/Adding New Channels", False)
                    End If
                    UpdateAddChannels()
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage("Updating/Adding New Channels Complete", False)
                    End If
                End If
                If Settings.UpdateEPG Then
                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage("Updating EPG, please wait ... This can take upto 15 mins", False)
                    End If
                    UpdateEPG()
                End If
                Settings.LastUpdate = Now
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage(("Database Update Complete, took " & Conversions.ToString(Conversion.Int(DateAndTime.Now.Subtract(Me.start).TotalSeconds)) & " Seconds"), False)
                End If
            End If
        Else
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage(("Error Occured:- " & errormessage), False)
            End If
        End If
        If (Not OnActivateControlsEvent Is Nothing) Then
            RaiseEvent OnActivateControls()
        End If
        Settings.IsGrabbing = False
    End Sub

    Private Sub DeleteOldChannels() 'This is the old code from the original plugin until the new code works.
        Dim UseRegions As Boolean = Settings.UseSkyRegions
        Dim DeleteOld As Boolean = Settings.DeleteOldChannels
        Dim OldFolder As String = Settings.OldChannelFolder
        RegionIDtoUse = Settings.RegionID

        Dim ChannelstoCheck As List(Of Channel) = _layer.Channels

        For Each Channelto As Channel In ChannelstoCheck
            If Channelto.ExternalId.Count > 1 Then
                'Delete channels that are no longer transmitted
                Dim ExternalID() As String = Channelto.ExternalId.Split(":") ' Get NID and ChannelID
                Dim NetworkID As Integer
                Dim ChannelID As Integer
                Try
                    NetworkID = Convert.ToInt32(ExternalID(0))
                    ChannelID = Convert.ToInt32(ExternalID(1))
                Catch
                    Continue For
                End Try
                If NetworkID <> 169 Then Continue For 'Not a Sky NZ channel, original code uses 2 for NetworkID.
                If Channels.ContainsKey(ChannelID) = False Then
                    removechannel(Channelto, DeleteOld, OldFolder)
                    Continue For
                End If

                If UseRegions Then
                    'Move Channels that are not in this Bouquet
                    Dim ScannedChannel As Sky_Channel = Channels(ChannelID)
                    If ScannedChannel.ContainsLCN(BouquetIDtoUse, RegionIDtoUse) Or ScannedChannel.ContainsLCN(BouquetIDtoUse, 255) Then
                        Continue For
                    End If
                    If (Channelto.IsTv And Channelto.VisibleInGuide = True) Then
                        Channelto.RemoveFromAllGroups()
                        Channelto.VisibleInGuide = False
                        Channelto.Persist()
                        _layer.AddChannelToGroup(Channelto, TvConstants.TvGroupNames.AllChannels)
                        RaiseEvent OnMessage("Channel " & Channelto.DisplayName & " isn't used in this region, moved to all channels.", False)
                    End If
                End If
            End If
        Next
    End Sub

    'Private Sub DeleteOldChannels() - New style code
    '    Dim enumerator As Collections.Generic.Dictionary(Of Integer, Channel).Enumerator
    '    Dim useSkyRegions As Boolean = Settings.UseSkyRegions
    '    Dim deleteOldChannels As Boolean = Settings.DeleteOldChannels
    '    Dim oldChannelFolder As String = Settings.OldChannelFolder
    '    RegionIDtoUse = Settings.RegionID
    '    Try
    '        enumerator = Channels.GetEnumerator
    '        Do While enumerator.MoveNext
    '            Dim current As Channel = enumerator.Current
    '            If (Enumerable.Count(Of Char)(current.ExternalId) > 1) Then
    '                Dim num As Integer
    '                Dim str2 As String
    '                Dim strArray As String() = current.ExternalId.Split(New Char() {":"c})
    '                Try
    '                    str2 = strArray(0)
    '                    num = Convert.ToInt32(strArray(1))
    '                Catch exception1 As Exception
    '                    ProjectData.SetProjectError(exception1)
    '                    ProjectData.ClearProjectError()
    '                    Continue Do
    '                End Try
    '                If (str2 = "SKYUK") Then
    '                    If Not Channels.ContainsKey(num) Then
    '                        removechannel(current, deleteOldChannels, oldChannelFolder)
    '                    ElseIf useSkyRegions Then
    '                        Dim channel2 As Sky_Channel = Channels.Item(num)
    '                        If (Not (channel2.ContainsLCN(BouquetIDtoUse, RegionIDtoUse) Or channel2.ContainsLCN(BouquetIDtoUse, &HFF)) AndAlso (current.IsTv And current.VisibleInGuide)) Then
    '                            current.RemoveFromAllGroups()
    '                            current.VisibleInGuide = False
    '                            current.Persist()
    '                            _layer.AddChannelToGroup(current, TvGroupNames.AllChannels)
    '                            If (Not OnMessageEvent Is Nothing) Then
    '                                RaiseEvent OnMessage(("Channel " & current.DisplayName & " isn't used in this region, moved to all channels."), False)
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        Loop
    '    Finally
    '        enumerator.Dispose()
    '    End Try
    'End Sub

    Public Sub removechannel(ByVal DBchannel As Channel, ByVal DeleteOld As Boolean, ByVal OldChannelFolder As String)
        If DeleteOld Then
            DBchannel.Delete()
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage(("Channel " & DBchannel.DisplayName & " no longer exists in the EPG, Deleted."), False)
            End If
        Else
            DBchannel.RemoveFromAllGroups()
            DBchannel.Persist()
            _layer.AddChannelToGroup(DBchannel, OldChannelFolder)
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage(String.Concat(New String() {"Channel ", DBchannel.DisplayName, " no longer exists in the EPG, moved to ", OldChannelFolder, "."}), False)
            End If
        End If
    End Sub

    Private Sub Grabit()
        Sky = New CustomDataGRabber
        MapCards = Settings.CardMap
        If ((MapCards Is Nothing) Or (MapCards.Count = 0)) Then
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage("No cards are selected for use, please correct this before continuing", False)
            End If
            Settings.IsGrabbing = False
            If (Not OnActivateControlsEvent Is Nothing) Then
                RaiseEvent OnActivateControls()
            End If
        Else
            Dim channel As Channel
            Dim str As String
            For Each str In My.Settings.UKCats.Split(New Char() {ChrW(13)})
                Dim strArray2 As String() = str.Split(New Char() {"="c})
                If (Strings.Asc(strArray2(0).Substring(0, 1)) = 10) Then
                    strArray2(0) = strArray2(0).Replace(ChrW(10), "")
                End If
                If Not CatsDesc.ContainsKey(strArray2(0)) Then
                    CatsDesc.Add(strArray2(0), strArray2(1))
                End If
            Next
            LoadHuffman(0)
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage("Huffman Loaded", False)
            End If
            Dim pids As New List(Of Integer) From {&H10, &H11}
            If Settings.UpdateEPG Then
                Dim num As Integer = 0
                Do
                    pids.Add((&H30 + num))
                    pids.Add((&H40 + num))
                    num += 1
                Loop While (num <= 7)
            End If
            GrabEPG = Settings.UpdateEPG
            DVBSChannel = New DVBSChannel
            Dim channelsByName As List(Of Channel) = DirectCast(_layer.GetChannelsByName("Sky UK Grabber"), List(Of Channel))
            If (channelsByName.Count = 0) Then
                channel = _layer.AddNewChannel("Sky UK Grabber", &H2710)
                channel.VisibleInGuide = False
                channel.IsRadio = True
                channel.IsTv = False
                DVBSChannel.BandType = BandType.Universal
                DVBSChannel.DisEqc = DirectCast(Settings.DiseqC, DisEqcType)
                DVBSChannel.FreeToAir = True
                DVBSChannel.Frequency = Settings.frequency
                DVBSChannel.SymbolRate = Settings.SymbolRate
                DVBSChannel.InnerFecRate = BinaryConvolutionCodeRate.RateNotSet
                DVBSChannel.IsRadio = True
                DVBSChannel.IsTv = False
                DVBSChannel.LogicalChannelNumber = &H2710
                DVBSChannel.ModulationType = DirectCast((Settings.modulation - 1), ModulationType)
                DVBSChannel.Name = "Sky UK Grabber"
                DVBSChannel.NetworkId = Settings.NID
                DVBSChannel.Pilot = Pilot.NotSet
                DVBSChannel.PmtPid = 0
                DVBSChannel.Polarisation = DirectCast((Settings.polarisation - 1), Polarisation)
                DVBSChannel.Provider = "DJBlu"
                DVBSChannel.Rolloff = RollOff.NotSet
                DVBSChannel.ServiceId = Settings.ServiceID
                DVBSChannel.TransportId = Settings.TransportID
                DVBSChannel.SatelliteIndex = &H10
                DVBSChannel.SwitchingFrequency = Settings.SwitchingFrequency
                channel.Persist()
                _layer.AddTuningDetails(channel, DVBSChannel)
                Dim item As Integer = -1
                Dim card As Card
                For Each card In card.ListAll
                    If (RemoteControl.Instance.Type(card.IdCard) = CardType.DvbS) Then
                        item += 1
                        If MapCards.Contains(item) Then
                            CardstoMap.Add(card)
                            _layer.MapChannelToCard(card, channel, False)
                        End If
                    End If
                Next
                _layer.AddChannelToRadioGroup(channel, RadioGroupNames.AllChannels)
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage("Sky UK Grabber channel added to database", False)
                End If
            Else
                channel = channelsByName.Item(0)
                Dim num3 As Integer = -1
                Dim card2 As Card
                For Each card2 In Card.ListAll
                    If (RemoteControl.Instance.Type(card2.IdCard) = CardType.DvbS) Then
                        num3 += 1
                        If MapCards.Contains(num3) Then
                            CardstoMap.Add(card2)
                        End If
                    End If
                Next
            End If
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage("Grabbing Data", False)
            End If
            If (channel Is Nothing) Then
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage("Channel was lost somewhere, try clicking on Grab data again", False)
                End If
            Else
                Dim grabTime As Integer = Settings.GrabTime
                If Settings.UseThrottle Then
                    grabTime = (grabTime * 3)

                    If (Not OnMessageEvent Is Nothing) Then
                        RaiseEvent OnMessage("Throttler enabled tripling grab time to ensure all data is collected", False)
                    End If
                End If
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage(("Grabber set to grab " & Conversions.ToString(grabTime) & " seconds of data"), False)
                End If
                Sky.GrabData(channel.IdChannel, grabTime, pids)
            End If
        End If
    End Sub

    Public Sub Grab()
        If (Not OnMessageEvent Is Nothing) Then
            RaiseEvent OnMessage("Sky Channel and EPG Grabber initialised", False)
        End If
        If Not Settings.IsGrabbing Then
            Settings.IsGrabbing = True
            Reset()
            Dim back As Thread = New Thread(AddressOf Grabit)
            back.Start()
        End If
    End Sub

    Public Shared Sub ManualGrab()
    End Sub

    Public Function IsGrabbing() As Boolean
        Return Settings.IsGrabbing
    End Function

    Private Sub LoadHuffman(ByVal type As Integer)
        Dim str2 As String
        Dim str3 As String
        Dim uKDict As String = My.Resources.UKDict
        If (Not nH Is Nothing) Then
            nH.Clear()
            orignH.Clear()
        End If
        Dim strArray As String() = uKDict.Split(New Char() {ChrW(13)})
        Dim upperBound As Integer = strArray.GetUpperBound(0)
        Dim i As Integer = 0
        Do While (i <= upperBound)
            strArray(i) = strArray(i).Replace(ChrW(10), "")
            str3 = strArray(i).Substring((strArray(i).LastIndexOf("=") + 1), ((strArray(i).Length - strArray(i).LastIndexOf("=")) - 1))
            str2 = strArray(i).Substring(0, strArray(i).LastIndexOf("="))
            nH = orignH
            Dim num4 As Integer = (str3.Length - 1)
            Dim j As Integer = 0
            Do While (j <= num4)
                If (Conversions.ToString(str3.Chars(j)) = "1") Then
                    If (nH.P1 Is Nothing) Then
                        nH.P1 = New HuffmanTreeNode
                        nH = nH.P1
                    Else
                        nH = nH.P1
                    End If
                ElseIf (nH.P0 Is Nothing) Then
                    nH.P0 = New HuffmanTreeNode
                    nH = nH.P0
                Else
                    nH = nH.P0
                End If
                j += 1
            Loop
            nH.Value = str2
            i += 1
        Loop
        nH = orignH
        strArray = Nothing
        str2 = ""
        str3 = ""
    End Sub

    Public Function NewHuffman(ByVal Data As Byte(), ByVal Length As Integer) As String
        Dim num As Byte
        Dim obj2 As Object
        Dim obj7 As Object
        Dim builder2 As New StringBuilder
        Dim builder As New StringBuilder
        Dim flag3 As Boolean = False
        nH = orignH
        Dim left As Object = 0
        Dim obj4 As Object = 0
        builder2.Length = 0
        builder.Length = 0
        Dim flag As Boolean = False
        Dim flag2 As Boolean = False
        Dim index As Byte = 0
        Dim num3 As Byte = 0
        nH = orignH
        If Not ObjectFlowControl.ForLoopControl.ForLoopInitObj(obj2, 0, (Length - 1), 1, obj7, obj2) Then
            GoTo Label_02BC
        End If
Label_0074:
        num = Data(Conversions.ToInteger(obj2))
        Dim num4 As Byte = &H80
        If Operators.ConditionalCompareObjectEqual(obj2, 0, False) Then
            If ((num And &H20) = 1) Then
                flag3 = True
            End If
            num4 = &H20
            index = Conversions.ToByte(obj2)
            num3 = num4
        End If
Label_00B0:
        If flag2 Then
            index = Conversions.ToByte(obj2)
            num3 = num4
            flag2 = False
        End If
        If ((num And num4) = 0) Then
            If flag Then
                builder.Append("0x30")
                obj4 = Operators.AddObject(obj4, 1)
                GoTo Label_029D
            End If
            If (Not nH.P0 Is Nothing) Then
                nH = nH.P0
                If (nH.Value <> "") Then
                    If (nH.Value <> "!!!") Then
                        builder2.Append(nH.Value)
                    End If
                    left = Operators.AddObject(left, Len(nH.Value))
                    nH = orignH
                    flag2 = True
                End If
                GoTo Label_029D
            End If
            left = Operators.AddObject(left, 9)
            obj2 = index
            num = Data(index)
            num4 = num3
            flag = True
            GoTo Label_00B0
        End If
        If flag Then
            builder.Append("0x31")
            obj4 = Operators.AddObject(obj4, 1)
        ElseIf (Not nH.P1 Is Nothing) Then
            nH = nH.P1
            If (nH.Value <> "") Then
                If (nH.Value <> "!!!") Then
                    builder2.Append(nH.Value)
                End If
                left = Operators.AddObject(left, Len(nH.Value))
                nH = orignH
                flag2 = True
            End If
        Else
            left = Operators.AddObject(left, 9)
            obj2 = index
            num = Data(index)
            num4 = num3
            flag = True
            GoTo Label_00B0
        End If
Label_029D:
        num4 = CByte((num4 >> 1))
        If (num4 > 0) Then
            GoTo Label_00B0
        End If
        If ObjectFlowControl.ForLoopControl.ForNextCheckObj(obj2, obj7, obj2) Then
            GoTo Label_0074
        End If
Label_02BC:
        Return builder2.ToString
    End Function

    Private Sub OnTitleDecoded()
        titlesDecoded += 1
    End Sub

    Private Sub OnSummaryDecoded()
        summariesDecoded += 1
    End Sub

    Private Sub ParseSDT(ByVal Data As Custom_Data_Grabber.Section, ByVal Length As Integer)
        Try
            If Not GotAllSDT Then
                Dim section As Byte() = Data.Data
                Dim num11 As Integer = ((section(3) * &H100) + section(4))
                Dim num7 As Long = ((section(8) * &H100) + section(9))
                Dim num5 As Integer = ((Length - 11) - 4)
                Dim index As Integer = 11
                Dim num12 As Integer = 0
                Do While (num5 > 0)
                    Dim num10 As Long = ((section(index) * &H100) + section((index + 1)))
                    Dim num3 As Integer = (CByte((section((index + 2)) >> 1)) And 1)
                    Dim num2 As Integer = (section((index + 2)) And 1)
                    Dim num9 As Integer = (CByte((section((index + 3)) >> 5)) And 7)
                    Dim num4 As Integer = (CByte((section((index + 3)) >> 4)) And 1)
                    Dim num As Integer = (((section((index + 3)) And 15) * &H100) + section((index + 4)))
                    index = (index + 5)
                    num5 = (num5 - 5)
                    Dim num6 As Integer = num
                    Dim info As New SDTInfo
                    Do While (num6 > 0)
                        Dim num13 As Integer = section(index)
                        num12 = 0
                        num12 = (section((index + 1)) + 2)
                        Select Case num13
                            Case &H48
                                DVB_GetServiceNew(section, index, info)
                                If (info.ChannelName = "") Then
                                    info.ChannelName = ("SID " & num10.ToString)
                                End If
                                info.SID = CInt(num10)
                                info.isFTA = (num4 > 0)
                                Exit Select
                            Case &HB2
                                If ((section((index + 4)) And 1) = 1) Then
                                    info.Category = section((index + 5))
                                Else
                                    info.Category = section((index + 4))
                                End If
                                Exit Select
                        End Select
                        num6 = (num6 - num12)
                        index = (index + num12)
                        num5 = (num5 - num12)
                        If Not SDTInfo.ContainsKey(String.Concat(New String() {Conversions.ToString(num7), "-", Conversions.ToString(num11), "-", Conversions.ToString(num10)})) Then
                            SDTInfo.Add(String.Concat(New String() {Conversions.ToString(num7), "-", Conversions.ToString(num11), "-", Conversions.ToString(num10)}), info)
                            SDTCount += 1
                        End If
                        If ((AreAllBouquetsPopulated() AndAlso (SDTCount >= Channels.Count)) AndAlso Not GotAllSDT) Then
                            GotAllSDT = True
                            If (Not OnMessageEvent Is Nothing) Then
                                RaiseEvent OnMessage(("Got All SDT Info, " & Conversions.ToString(SDTInfo.Count) & " Channels found"), False)
                            End If
                        End If
                    Loop
                Loop
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage("Error Parsing SDT", False)
            End If
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Sub DVB_GetServiceNew(ByVal b As Byte(), ByVal x As Integer, ByRef info As SDTInfo)
        Dim num3 As Integer = 0
        Dim num2 As Integer = b((x + 0))
        Dim num As Integer = b((x + 1))
        If (b((x + 2)) = 2) Then
            info.isRadio = True
            info.isTV = False
            info.isHD = False
            info.is3D = False
        Else
            info.isRadio = False
            info.isTV = True
            info.isHD = False
            info.is3D = False
            If ((b((x + 2)) = &H19) Or (b((x + 2)) = &H11)) Then
                info.isHD = True
            End If
            If ((b((x + 2)) >= &H80) And (b((x + 2)) <= &H84)) Then
                info.is3D = True
            End If
        End If
        Dim length As Integer = b((x + 3))
        num3 = 4
        info.Provider = GetString(b, (num3 + x), length, False)
        num3 = (num3 + length)
        Dim num4 As Integer = b((x + num3))
        num3 += 1
        info.ChannelName = GetString(b, (num3 + x), num4, False)
    End Sub

    Public Function GetString(ByVal byteData As Byte(), ByVal offset As Integer, ByVal length As Integer, ByVal replace As Boolean) As String
        Dim buffer As Byte()
        Dim str As String
        If (length = 0) Then
            Return ""
        End If
        Dim name As String = Nothing
        Dim num2 As Integer = 0
        If (byteData(offset) >= &H20) Then
            name = "iso-8859-1"
        Else
            Select Case byteData(offset)
                Case 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
                    Dim num5 As Integer = (byteData(offset) + 4)
                    name = ("iso-8859-" & num5.ToString)
                    num2 = 1
                    GoTo Label_016E
                Case &H10
                    If (byteData((offset + 1)) <> 0) Then
                        OnMessageEvent = Nothing
                        If (Not OnMessageEvent Is Nothing) Then
                            RaiseEvent OnMessage("Invalid DVB text string: byte 2 is not a valid value", replace)
                        End If
                    ElseIf ((byteData((offset + 2)) = 0) OrElse (byteData((offset + 2)) = 12)) Then
                        OnMessageEvent = Nothing
                        If (Not OnMessageEvent Is Nothing) Then
                            RaiseEvent OnMessage("Invalid DVB text string: byte 3 is not a valid value", replace)
                        End If
                    Else
                        name = ("iso-8859-" & CInt(byteData((offset + 2))).ToString)
                        num2 = 3
                    End If
                    GoTo Label_016E
                Case &H1F
                    If ((byteData((offset + 1)) <> 1) AndAlso (byteData((offset + 1)) <> 2)) Then
                        OnMessageEvent = Nothing
                        If (Not OnMessageEvent Is Nothing) Then
                            RaiseEvent OnMessage("Invalid DVB text string: Custom text specifier is not recognized", replace)
                        End If
                    End If
                    GoTo Label_016E
            End Select
            Return "Invalid DVB text string: byte 1 is not a valid value"
        End If
Label_016E:
        buffer = New Byte(((length - 1) + 1) - 1) {}
        Dim index As Integer = 0
        Dim num6 As Integer = (length - 1)
        Dim i As Integer = num2
        Do While (i <= num6)
            If (byteData((offset + i)) > &H1F) Then
                If ((byteData((offset + i)) < &H80) OrElse (byteData((offset + i)) > &H9F)) Then
                    buffer(index) = byteData((offset + i))
                    index += 1
                End If
            ElseIf replace Then
                buffer(index) = &H20
                index += 1
            End If
            i += 1
        Loop
        If (index = 0) Then
            Return String.Empty
        End If
        Try
            Dim encoding As Encoding = encoding.GetEncoding(name)
            If (encoding Is Nothing) Then
                encoding = encoding.GetEncoding("iso-8859-1")
            End If
            str = encoding.GetString(buffer, 0, index)
        Catch exception1 As ArgumentException
            ProjectData.SetProjectError(exception1)
            Dim exception As ArgumentException = exception1
            OnMessageEvent = Nothing
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage("** ERROR DECODING STRING - SEE COLLECTION LOG **", replace)
            End If
            ProjectData.ClearProjectError()
        End Try
        Return str
    End Function

    Private Sub ParseChannels(ByVal Data As Custom_Data_Grabber.Section, ByVal Length As Integer)
        Try
            If (Data.table_id <> &H4A) Then
                If (((Data.table_id = &H42) Or (Data.table_id = 70)) AndAlso Not Me.GotAllSDT) Then
                    ParseSDT(Data, Length)
                End If
            ElseIf Not AreAllBouquetsPopulated() Then
                Dim buffer As Byte() = Data.Data
                Dim bouquetId As Integer = ((buffer(3) * 256) + buffer(4))
                Dim num2 As Integer = (((buffer(8) And 15) * 256) + buffer(9))
                Dim bouquet As SkyBouquet = GetBouquet(bouquetId)
                If Not bouquet.isPopulated Then
                    Dim num10 As Integer
                    If Not bouquet.isInitialized Then
                        bouquet.firstReceivedSectionNumber = CByte(Data.section_number)
                        bouquet.isInitialized = True
                    ElseIf (Data.section_number = bouquet.firstReceivedSectionNumber) Then
                        bouquet.isPopulated = True
                        NotifyBouquetPopulated()
                        Return
                    End If
                    Dim num As Integer = (10 + num2)
                    Dim num4 As Integer = (((buffer((num + 0)) And 15) * &H100) + buffer((num + 1)))
                    Dim num6 As Integer = ((num + num4) + 2)
                    Dim i As Integer = (num + 2)
                    Do While (i < num6)
                        Dim num11 As Integer = ((buffer((i + 0)) * &H100) + buffer((i + 1)))
                        Dim num9 As Integer = ((buffer((i + 2)) * &H100) + buffer((i + 3)))
                        num10 = (((buffer((i + 4)) And 15) * &H100) + buffer((i + 5)))
                        Dim index As Integer = (i + 6)
                        Dim num8 As Integer = (index + num10)
                        Do While (index < num8)
                            Dim num14 As Byte = buffer(index)
                            Dim num13 As Integer = buffer((index + 1))
                            Dim num12 As Integer = (index + 2)
                            Dim num15 As Integer = ((num12 + num13) - 2)
                            If (num14 = &HB1) Then
                                Dim rID As Integer = buffer((index + 3))
                                Do While (num12 < num15)
                                    Dim num18 As Integer = ((buffer((num12 + 2)) * &H100) + buffer((num12 + 3)))
                                    Dim channelID As Integer = ((buffer((num12 + 5)) * &H100) + buffer((num12 + 6)))
                                    Dim skyLCN As Integer = ((buffer((num12 + 7)) * &H100) + buffer((num12 + 8)))
                                    Dim channel As Sky_Channel = GetChannel(channelID)
                                    Dim lCNHold As New LCNHolder(bouquetId, rID, skyLCN)
                                    If Not channel.isPopulated Then
                                        channel.NID = num9
                                        channel.TID = num11
                                        channel.SID = num18
                                        channel.ChannelID = channelID
                                        If channel.AddSkyLCN(lCNHold) Then
                                            channel.isPopulated = True
                                        End If
                                        UpdateChannel(channel.ChannelID, channel)
                                    Else
                                        channel.AddSkyLCN(lCNHold)
                                        UpdateChannel(channel.ChannelID, channel)
                                    End If
                                    num12 = (num12 + 9)
                                Loop
                            End If
                            index = (index + (num13 + 2))
                        Loop
                        i = (i + (num10 + 6))
                    Loop
                End If
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage("Error Parsing BAT", False)
            End If
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Function GetBouquet(ByVal bouquetId As Integer) As SkyBouquet
        If Not Bouquets.ContainsKey(bouquetId) Then
            Bouquets.Add(bouquetId, New SkyBouquet)
        End If
        Return Bouquets.Item(bouquetId)
    End Function

    Public Function GetChannel(ByVal ChannelID As Integer) As Sky_Channel
        If Channels.ContainsKey(ChannelID) Then
            Return Channels.Item(ChannelID)
        End If
        Channels.Add(ChannelID, New Sky_Channel)
        Dim channel2 As Sky_Channel = Channels.Item(ChannelID)
        channel2.ChannelID = ChannelID
        Return channel2
    End Function

    Public Function GetChannelbySID(ByVal SID As String) As SDTInfo
        If SDTInfo.ContainsKey(SID) Then
            Return SDTInfo.Item(SID)
        End If
        Return Nothing
    End Function

    Public Function AreAllBouquetsPopulated() As Boolean
        Return ((Bouquets.Count > 0) And (Bouquets.Count = numberBouquetsPopulated))
    End Function

    Public Function IsEverythingGrabbed() As Boolean
        If GrabEPG Then
            If Not (AreAllBouquetsPopulated() And GotAllSDT) Then
                Return False
            End If
            If (Not AreAllSummariesPopulated() And AreAllTitlesPopulated() And GotAllTID) Then
                Return False
            End If
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage(String.Concat(New String() {"Everything grabbed:- Titles(", Conversions.ToString(titlesDecoded), ") : Summaries(", Conversions.ToString(summariesDecoded), ")"}), False)
            End If
            Return True
        End If
        If Not ((Bouquets.Count = numberBouquetsPopulated) And GotAllSDT) Then
            Return False
        End If
        Return GotAllTID
    End Function

    Public Sub NotifyBouquetPopulated()
        numberBouquetsPopulated += 1
        If (Bouquets.Count = numberBouquetsPopulated) Then
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage("Bouquet scan complete.  ", False)
            End If
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage(String.Concat(New String() {"Found ", Conversions.ToString(Channels.Count), " channels in ", Conversions.ToString(Bouquets.Count), " bouquets, searching SDT Information"}), False)
            End If
        End If
    End Sub

    Private Sub NotifySkyChannelPopulated(ByVal TID As Integer, ByVal NID As Integer, ByVal SID As Integer)
        If Not GotAllSDT Then
            If (numberSDTPopulated = "") Then
                numberSDTPopulated = String.Concat(New String() {NID.ToString, "-", TID.ToString, "-", SID.ToString})
            ElseIf (String.Concat(New String() {NID.ToString, "-", TID.ToString, "-", SID.ToString}) = numberSDTPopulated) Then
                GotAllSDT = True
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage(("Got all SDT Info, count: " & Conversions.ToString(SDTInfo.Count)), False)
                End If
            End If
        End If
    End Sub

    Private Sub NotifyTIDPopulated(ByVal TID As Integer)
        If Not GotAllTID Then
            If (numberTIDPopulated = 0) Then
                numberTIDPopulated = TID
            ElseIf (TID = Me.numberTIDPopulated) Then
                GotAllTID = True
                If (Not OnMessageEvent Is Nothing) Then
                    RaiseEvent OnMessage("Got all Network Information", False)
                End If
            End If
        End If
    End Sub

    Public Function DoesTidCarryEpgSummaryData(ByVal TableID As Integer) As Boolean
        Return ((((TableID = &HA8) Or (TableID = &HA9)) Or (TableID = 170)) Or (TableID = &HAB))
    End Function

    Public Sub OnSummarySectionReceived(ByVal pid As Integer, ByVal section As Custom_Data_Grabber.Section)
        Try
            If (Not IsSummaryDataCarouselOnPidComplete(pid) AndAlso DoesTidCarryEpgSummaryData(section.table_id)) Then
                Dim buffer As Byte() = section.Data
                Dim num5 As Integer = ((((buffer(1) And 15) * &H100) + buffer(2)) - 2)
                If (section.section_length >= 14) Then
                    Dim channelId As Long = ((buffer(3) * &H100) + buffer(4))
                    Dim num4 As Long = ((buffer(8) * &H100) + buffer(9))
                    If Not ((channelId = 0) Or (num4 = 0)) Then
                        Dim num2 As Integer = 10
                        Dim num3 As Integer = 0
                        Do While (num2 < num5)
                            Dim num6 As Integer
                            Dim epgEvent As SkyEvent
                            Dim num11 As Integer
                            If (num3 <= &H200) Then
                                num3 += 1
                                Dim eventId As Integer = ((buffer((num2 + 0)) * &H100) Or buffer((num2 + 1)))
                                Dim num12 As Byte = CByte(((buffer((num2 + 2)) And 240) >> 4))
                                num6 = (((buffer((num2 + 2)) And 15) * &H100) Or buffer((num2 + 3)))
                                Dim summaryChannelEventUnionId As String = (channelId.ToString & ":" & eventId.ToString)
                                OnSummaryReceived(pid, summaryChannelEventUnionId)
                                If Not IsSummaryDataCarouselOnPidComplete(pid) Then
                                    epgEvent = GetEpgEvent(channelId, eventId)
                                    If (Not epgEvent Is Nothing) Then
                                        Select Case num12
                                            Case 15
                                                num11 = 7
                                                GoTo Label_0132
                                            Case 11
                                                num11 = 4
                                                GoTo Label_0132
                                        End Select
                                    End If
                                End If
                            End If
                            Return
Label_0132:
                            If (num6 < 3) Then
                                num2 = (num2 + (num11 + num6))
                            End If
                            Dim num7 As Integer = (num2 + num11)
                            Dim num13 As Integer = buffer((num7 + 0))
                            Dim length As Integer = buffer((num7 + 1))
                            If (num13 = &HB9) Then
                                If (epgEvent.Summary = "") Then
                                    Dim destinationArray As Byte() = New Byte(&H1001 - 1) {}
                                    If (((num7 + 2) + length) > buffer.Length) Then
                                        Return
                                    End If
                                    Array.Copy(buffer, (num7 + 2), destinationArray, 0, length)
                                    epgEvent.Summary = NewHuffman(destinationArray, length)
                                    OnSummaryDecoded()
                                    Dim num16 As Integer = CInt(channelId)
                                    UpdateEPGEvent(num16, epgEvent.EventID, epgEvent)
                                    channelId = num16
                                End If
                            ElseIf (num13 <> &HBB) Then
                                Return
                            End If
                            Dim num10 As Integer = ((num6 - length) - 2)
                            If (num10 >= 4) Then
                                Dim num15 As Integer = ((num7 + 2) + length)
                                Dim num14 As Integer = buffer((num15 + 0))
                                If (num14 = &HC1) Then
                                    epgEvent.SeriesID = ((buffer((num15 + 2)) * &H100) + buffer((num15 + 3)))
                                End If
                            End If
                            num2 = (num2 + (num6 + num11))
                        Loop
                        If (num2 <> (num5 + 1)) Then
                        End If
                    End If
                End If
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage(("Error decoding Summary, " & exception.Message), False)
            End If
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Function GetPicture(ByVal URL As String) As Image
        Dim image2 As Image
        image2 = Nothing
        Try
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create(URL), HttpWebRequest)
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.12) Gecko/20101026 Firefox/3"
            request.Accept = "Accept: text/html,application/xhtml+xml,application/xml"
            Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)
            If (request.HaveResponse And (response.StatusCode = HttpStatusCode.OK)) Then
                image2 = Image.FromStream(response.GetResponseStream)
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            image2 = Nothing
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage(("Error downloading channel icon, " & exception.Message), False)
            End If
            ProjectData.ClearProjectError()
        End Try
        Return image2
    End Function

    Public Sub UpdateCheckLogo(ByVal ChannelID As Integer, ByVal Filename As String)
        Try
            Dim num As Integer = 200
            Dim picture As Image = GetPicture(("http://tv.sky.com/logo/200/200/skychb" & ChannelID.ToString & ".png"))
            If (picture Is Nothing) Then
                num = 100
                picture = GetPicture(("http://tv.sky.com/logo/100/100/skychb" & ChannelID.ToString & ".png"))
            End If
            If (Not picture Is Nothing) Then
                Dim image As New Bitmap(picture)
                Dim y As Integer = 0
                Dim x As Integer = 0
                If (image.Height < num) Then
                    y = CInt(Math.Round(CDbl((CDbl((num - image.Height)) / 2))))
                End If
                If (image.Width < num) Then
                    x = CInt(Math.Round(CDbl((CDbl((num - image.Width)) / 2))))
                End If
                Dim bitmap2 As New Bitmap((num + 2), (num + 2), PixelFormat.Format32bppArgb)
                Dim graphics As Graphics = graphics.FromImage(bitmap2)
                graphics.CompositingMode = CompositingMode.SourceOver
                graphics.DrawImage(image, x, y, image.Width, image.Height)
                If File.Exists(Filename) Then
                    Drawing.Image.FromFile(Filename).Dispose()
                    File.Delete(Filename)
                    bitmap2.Save(Filename, ImageFormat.Png)
                Else
                    bitmap2.Save(Filename)
                End If
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            If (Not OnMessageEvent Is Nothing) Then
                RaiseEvent OnMessage(("Error grabbing logo - " & exception.Message), False)
            End If
            ProjectData.ClearProjectError()
        End Try
    End Sub

    ' Properties
    Public Overridable Property Sky As CustomDataGRabber
        Get
            Return _Sky
        End Get
        <MethodImpl(MethodImplOptions.Synchronized)> _
        Set(ByVal WithEventsValue As CustomDataGRabber)
            Dim handler As CustomDataGRabber.OnCompleteEventHandler = New CustomDataGRabber.OnCompleteEventHandler(AddressOf UpdateDataBase)
            Dim handler2 As CustomDataGRabber.OnPacketEventHandler = New CustomDataGRabber.OnPacketEventHandler(AddressOf OnTSPacket)
            If (Not _Sky Is Nothing) Then
                RemoveHandler _Sky.OnComplete, handler
                RemoveHandler _Sky.OnPacket, handler2
            End If
            _Sky = WithEventsValue
            If (Not _Sky Is Nothing) Then
                AddHandler _Sky.OnComplete, handler
                AddHandler _Sky.OnPacket, handler2
            End If
        End Set
    End Property

End Class

Public Class LCNHolder
    ' Fields
    Private _BID As Integer
    Private _RID As Integer
    Private _SkyNum As Integer

    ' Methods
    Public Sub New(ByVal BID As Integer, ByVal RID As Integer, ByVal SkyLCN As Integer)
        _BID = BID
        _RID = RID
        _SkyNum = SkyLCN
    End Sub

    ' Properties
    Public Property BID As Integer
        Get
            Return _BID
        End Get
        Set(ByVal value As Integer)
            _BID = value
        End Set
    End Property

    Public Property RID As Integer
        Get
            Return _RID
        End Get
        Set(ByVal value As Integer)
            _RID = value
        End Set
    End Property

    Public Property SkyNum As Integer
        Get
            Return _SkyNum
        End Get
        Set(ByVal value As Integer)
            _SkyNum = value
        End Set
    End Property
End Class

Public Class Sky_Channel
    ' Fields
    Private _Channel_Name As String
    Private _ChannelId As Integer
    Private _encrypted As Boolean
    Private ReadOnly _epgChannelNumber As Dictionary(Of String, LCNHolder) = New Dictionary(Of String, LCNHolder)
    Private _HasChanged As Boolean
    Private _isPopulated As Boolean
    Private _Name As String
    Private _NewChannelRequired As Boolean
    Private _NID As Integer
    Private _SID As Integer
    Private _TID As Integer
    Public Events As Dictionary(Of Integer, SkyEvent) = New Dictionary(Of Integer, SkyEvent)

    ' Methods
    Public Function AddSkyLCN(ByVal LCNHold As LCNHolder) As Boolean
        If Not _epgChannelNumber.ContainsKey((Conversions.ToString(LCNHold.BID) & "-" & Conversions.ToString(LCNHold.RID))) Then
            _epgChannelNumber.Add((Conversions.ToString(LCNHold.BID) & "-" & Conversions.ToString(LCNHold.RID)), LCNHold)
            Return False
        End If
        Return True
    End Function

    Public Function ContainsLCN(ByVal BouquetID As Integer, ByVal RegionId As Integer) As Boolean
        Return _epgChannelNumber.ContainsKey((BouquetID.ToString & "-" & RegionId.ToString))
    End Function

    Public Function GetLCN(ByVal BouquetID As Integer, ByVal RegionId As Integer) As LCNHolder
        If _epgChannelNumber.ContainsKey((BouquetID.ToString & "-" & RegionId.ToString)) Then
            Return _epgChannelNumber.Item((BouquetID.ToString & "-" & RegionId.ToString))
        End If
        Return Nothing
    End Function

    ' Properties
    Public Property AddChannelRequired As Boolean
        Get
            Return _NewChannelRequired
        End Get
        Set(ByVal value As Boolean)
            _NewChannelRequired = value
        End Set
    End Property

    Public Property Channel_Name As String
        Get
            Return _Channel_Name
        End Get
        Set(ByVal value As String)
            _Channel_Name = value
        End Set
    End Property

    Public Property ChannelID As Integer
        Get
            Return _ChannelId
        End Get
        Set(ByVal value As Integer)
            _ChannelId = value
        End Set
    End Property

    Public Property HasChanged As Boolean
        Get
            Return _HasChanged
        End Get
        Set(ByVal value As Boolean)
            _HasChanged = value
        End Set
    End Property

    Public Property isPopulated As Boolean
        Get
            Return _isPopulated
        End Get
        Set(ByVal value As Boolean)
            _isPopulated = value
        End Set
    End Property

    Public ReadOnly Property LCNCount As Object
        Get
            Return _epgChannelNumber.Count
        End Get
    End Property

    Public ReadOnly Property LCNS As Object
        Get
            Return _epgChannelNumber.Values
        End Get
    End Property

    Public Property NID As Integer
        Get
            Return _NID
        End Get
        Set(ByVal value As Integer)
            _NID = value
        End Set
    End Property

    Public Property SID As Integer
        Get
            Return _SID
        End Get
        Set(ByVal value As Integer)
            _SID = value
        End Set
    End Property

    Public Property TID As Integer
        Get
            Return _TID
        End Get
        Set(ByVal value As Integer)
            _TID = value
        End Set
    End Property

End Class

Public Class SkyEvent
    ' Fields
    Private _AD As Boolean = False
    Private _Category As String = ""
    Private _ChannelID As Integer = -1
    Private _CP As Boolean = False
    Private _duration As Integer = -1
    Private _EventID As Integer = -1
    Private _HD As Boolean = False
    Private _mjdStart As Long = 0
    Private _ParentalCategory As String = ""
    Private _SeriesID As Integer = 0
    Private _seriesTermination As Integer = 0
    Private _SoundType As Integer = -1
    Private _StartTime As Integer = -1
    Private _Subs As Boolean = False
    Private _Summary As String = ""
    Private _Title As String = ""
    Private _WS As Boolean = False
    Private Flags As String = ""

    ' Methods
    Public Sub SetFlags(ByVal IntegerNumber As Integer)
        _AD = ((IntegerNumber And 1) > 0)
        _CP = ((IntegerNumber And 2) > 0)
        _HD = ((IntegerNumber And 4) > 0)
        _WS = ((IntegerNumber And 8) > 0)
        _Subs = ((IntegerNumber And &H10) > 0)
        _SoundType = (IntegerNumber >> 6)
    End Sub

    Public Sub SetCategory(ByVal Category As Integer)
        Select Case (Category And 15)
            Case 1
                _ParentalCategory = "U"
                Exit Select
            Case 2
                _ParentalCategory = "PG"
                Exit Select
            Case 3
                _ParentalCategory = "12"
                Exit Select
            Case 4
                _ParentalCategory = "15"
                Exit Select
            Case 5
                _ParentalCategory = "18"
                Exit Select
            Case Else
                _ParentalCategory = ""
                Exit Select
        End Select
    End Sub

    ' Properties
    Public ReadOnly Property ParentalCategory As String
        Get
            Return _ParentalCategory
        End Get
    End Property

    Public ReadOnly Property DescriptionFlag As String
        Get
            Flags = ""
            If _AD Then
                Flags = (Flags & "[AD]")
            End If
            If _CP Then
                If (Flags <> "") Then
                    Flags = (Flags & ",")
                End If
                Flags = (Flags & "[CP]")
            End If
            If _HD Then
                If (Flags <> "") Then
                    Flags = (Flags & ",")
                End If
                Flags = (Flags & "[HD]")
            End If
            If _WS Then
                If (Flags <> "") Then
                    Flags = (Flags & ",")
                End If
                Flags = (Flags & "[W]")
            End If
            If _Subs Then
                If (Flags <> "") Then
                    Flags = (Flags & ",")
                End If
                Flags = (Flags & "[SUB]")
            End If

            Select Case _SoundType
                Case 1
                    If (Flags <> "") Then
                        Flags = (Flags & ",")
                    End If
                    Flags = (Flags & "[S]")
                    Exit Select
                Case 2
                    If (Flags <> "") Then
                        Flags = (Flags & ",")
                    End If
                    Flags = (Flags & "[DS]")
                    Exit Select
                Case 3
                    If (Flags <> "") Then
                        Flags = (Flags & ",")
                    End If
                    Flags = (Flags & "[DD]")
                    Exit Select
            End Select
            Return Flags
        End Get
    End Property

    Public Property Summary As String
        Get
            Return _Summary
        End Get
        Set(ByVal value As String)
            _Summary = value
        End Set
    End Property

    Public Property EventID As Integer
        Get
            Return _EventID
        End Get
        Set(ByVal value As Integer)
            _EventID = value
        End Set
    End Property

    Public Property StartTime As Integer
        Get
            Return _StartTime
        End Get
        Set(ByVal value As Integer)
            _StartTime = value
        End Set
    End Property

    Public Property Duration As Integer
        Get
            Return _duration
        End Get
        Set(ByVal value As Integer)
            _duration = value
        End Set
    End Property

    Public Property ChannelID As Integer
        Get
            Return _ChannelID
        End Get
        Set(ByVal value As Integer)
            _ChannelID = value
        End Set
    End Property

    Public Property Title As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property

    Public Property Category As String
        Get
            Return _Category
        End Get
        Set(ByVal value As String)
            _Category = value
        End Set
    End Property

    Public Property SeriesID As Integer
        Get
            Return _SeriesID
        End Get
        Set(ByVal value As Integer)
            _SeriesID = value
        End Set
    End Property

    Public Property mjdStart As Long
        Get
            Return _mjdStart
        End Get
        Set(ByVal value As Long)
            _mjdStart = value
        End Set
    End Property

    Public Property seriesTermination As Integer
        Get
            Return _seriesTermination
        End Get
        Set(ByVal value As Integer)
            _seriesTermination = value
        End Set
    End Property

End Class

Public Class SkyBouquet
    'Fields
    Private _firstReceivedSectionNumber As Byte
    Private _isInitialized As Boolean = False
    Private _isPopulated As Boolean = False

    'Properties
    Public Property firstReceivedSectionNumber As Byte
        Get
            Return _firstReceivedSectionNumber
        End Get
        Set(ByVal value As Byte)
            _firstReceivedSectionNumber = value
        End Set
    End Property

    Public Property isInitialized As Boolean
        Get
            Return _isInitialized
        End Get
        Set(ByVal value As Boolean)
            _isInitialized = value
        End Set
    End Property

    Public Property isPopulated As Boolean
        Get
            Return _isPopulated
        End Get
        Set(ByVal value As Boolean)
            _isPopulated = value
        End Set
    End Property



End Class

Public Class HuffHolder
    ' Fields
    Private _buff As Byte()
    Private _Length As Integer
    Private _NextID As String

    ' Properties
    Public Property NextID As String
        Get
            Return _NextID
        End Get
        Set(ByVal value As String)
            _NextID = value
        End Set
    End Property

    Public Property Buff As Byte()
        Get
            Return _buff
        End Get
        Set(ByVal value As Byte())
            _buff = value
        End Set
    End Property

    Public Property Length As Integer
        Get
            Return _Length
        End Get
        Set(ByVal value As Integer)
            _Length = value
        End Set
    End Property

End Class

Public Class HuffmanTreeNode
    ' Fields
    Public P0 As HuffmanTreeNode
    Public P1 As HuffmanTreeNode
    Public Parent As HuffmanTreeNode
    Public Value As String
    Dim strPath As String

    ' Methods
    Public Function Clear() As Boolean
        If (Not P1 Is Nothing) Then
            P1 = Nothing
            If (Not P0 Is Nothing) Then
                P0 = Nothing
            End If
        End If
        Return True
    End Function

    Private Overloads Function Equals() As Boolean
        Return False
    End Function

    Private Overloads Function ReferenceEquals() As Boolean
        Return False
    End Function

    ' Properties
    Public ReadOnly Property Path As String
        Get
            If strPath Is Nothing Then
                If Not (Parent Is Nothing) Then
                    If (Parent.P0 Is Me) Then strPath = "0"
                    If (Parent.P1 Is Me) Then strPath = "1"
                    strPath = Parent.Path & strPath
                End If
            End If
            Return strPath
        End Get
    End Property

End Class

Public Class SDTInfo
    ' Fields
    Private _Cat As Byte
    Private _ChannelName As String
    Private _is3d As Boolean
    Private _isFTA As Boolean
    Private _isHD As Boolean
    Private _isRadio As Boolean
    Private _isTV As Boolean
    Private _Provider As String
    Private _sid As Integer

    ' Properties
    Public Property SID As Integer
        Get
            Return _sid
        End Get
        Set(ByVal value As Integer)
            _sid = value
        End Set
    End Property

    Public Property ChannelName As String
        Get
            Return _ChannelName
        End Get
        Set(ByVal value As String)
            _ChannelName = value
        End Set
    End Property

    Public Property Provider As String
        Get
            Return _Provider
        End Get
        Set(ByVal value As String)
            _Provider = value
        End Set
    End Property

    Public Property Category As Integer
        Get
            Return _Cat
        End Get
        Set(ByVal value As Integer)
            _Cat = CByte(value)
        End Set
    End Property

    Public Property isFTA As Boolean
        Get
            Return _isFTA
        End Get
        Set(ByVal value As Boolean)
            _isFTA = value
        End Set
    End Property

    Public Property isRadio As Boolean
        Get
            Return _isRadio
        End Get
        Set(ByVal value As Boolean)
            _isRadio = value
        End Set
    End Property

    Public Property isTV As Boolean
        Get
            Return _isTV
        End Get
        Set(ByVal value As Boolean)
            _isTV = value
        End Set
    End Property

    Public Property isHD As Boolean
        Get
            Return _isHD
        End Get
        Set(ByVal value As Boolean)
            _isHD = value
        End Set
    End Property

    Public Property is3D As Boolean
        Get
            Return Me._is3d
        End Get
        Set(ByVal value As Boolean)
            Me._isHD = value
        End Set
    End Property

End Class

Public Class NITSatDescriptor
    ' Fields
    Private _FECInner As Integer
    Private _Frequency As Single
    Private _isS2 As Integer
    Private _Modulation As Integer
    Private _NetworkName As String
    Private _OrbitalPosition As Integer
    Private _Polarisation As Integer
    Private _RollOff As Integer
    Private _Symbolrate As Integer
    Private _TransportID As Integer
    Private _WestEastFlag As Integer

    ' Properties
    Public Property TID As Integer
        Get
            Return _TransportID
        End Get
        Set(ByVal value As Integer)
            _TransportID = value
        End Set
    End Property

    Public Property Frequency As Integer
        Get
            Return CInt(Math.Round(CDbl(_Frequency)))
        End Get
        Set(ByVal value As Integer)
            _Frequency = value
        End Set
    End Property

    Public Property OrbitalPosition As Integer
        Get
            Return _OrbitalPosition
        End Get
        Set(ByVal value As Integer)
            _OrbitalPosition = value
        End Set
    End Property

    Public Property WestEastFlag As Integer
        Get
            Return _WestEastFlag
        End Get
        Set(ByVal value As Integer)
            _WestEastFlag = value
        End Set
    End Property

    Public Property Polarisation As Integer
        Get
            Return _Polarisation
        End Get
        Set(ByVal value As Integer)
            _Polarisation = value
        End Set
    End Property

    Public Property Modulation As Integer
        Get
            Return _Modulation
        End Get
        Set(ByVal value As Integer)
            _Modulation = value
        End Set
    End Property

    Public Property Symbolrate As Integer
        Get
            Return _Symbolrate
        End Get
        Set(ByVal value As Integer)
            _Symbolrate = value
        End Set
    End Property

    Public Property FECInner As Integer
        Get
            Return _FECInner
        End Get
        Set(ByVal value As Integer)
            _FECInner = value
        End Set
    End Property

    Public Property RollOff As Integer
        Get
            Return _RollOff
        End Get
        Set(ByVal value As Integer)
            _RollOff = value
        End Set
    End Property

    Public Property isS2 As Integer
        Get
            Return _isS2
        End Get
        Set(ByVal value As Integer)
            _isS2 = value
        End Set
    End Property

    Public Property NetworkName As String
        Get
            Return _NetworkName
        End Get
        Set(ByVal value As String)
            _NetworkName = value
        End Set
    End Property

End Class

Public Class [Region]
    ' Fields
    Private _BouquetID As Integer
    Private _RegionID As Integer

    ' Properties
    Public Property BouquetID As Integer
        Get
            Return _BouquetID
        End Get
        Set(ByVal value As Integer)
            _BouquetID = value
        End Set
    End Property

    Public Property RegionID As Integer
        Get
            Return _RegionID
        End Get
        Set(ByVal value As Integer)
            _RegionID = value
        End Set
    End Property

End Class

