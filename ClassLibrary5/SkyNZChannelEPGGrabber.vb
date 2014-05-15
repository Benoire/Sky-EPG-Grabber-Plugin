Imports DirectShowLib.BDA
Imports Microsoft.VisualBasic.CompilerServices
Imports Custom_Data_Grabber
Imports TvDatabase
Imports TvLibrary.Channels
Imports TvLibrary.Epg
Imports TvLibrary.Interfaces
Imports TvEngine

Imports System.Text
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports SetupTv
Imports TvControl
Imports TvLibrary.Log
Public Class Sky_NZGrabber

    Implements ITvServerPlugin
    Dim settings As Settings
    Dim WithEvents skygrabber As SkyGrabber
    Dim WithEvents timer As Timers.Timer


    Sub OnTick() Handles timer.Elapsed

        If settings.IsGrabbing = False Then
            If settings.AutoUpdate = True Then
                If settings.EveryHour = True Then
                    If settings.LastUpdate.AddHours(settings.UpdateInterval) < Now Then
                        skygrabber.Grab()
                    End If
                Else
                    If (Now.Hour = settings.UpdateTime.Hour) And settings.LastUpdate.Date <> Now.Date Then
                        If Now.Minute >= settings.UpdateTime.Minute And Now.Minute <= settings.UpdateTime.Minute + 10 Then
                            Select Case Now.DayOfWeek
                                Case System.DayOfWeek.Monday
                                    If settings.Mon = True Then
                                        skygrabber.Grab()
                                    End If
                                Case System.DayOfWeek.Tuesday
                                    If settings.Tue = True Then
                                        skygrabber.Grab()
                                    End If
                                Case System.DayOfWeek.Wednesday
                                    If settings.Wed = True Then
                                        skygrabber.Grab()
                                    End If
                                Case System.DayOfWeek.Thursday
                                    If settings.Thu = True Then
                                        skygrabber.Grab()
                                    End If
                                Case System.DayOfWeek.Friday
                                    If settings.Fri = True Then
                                        skygrabber.Grab()
                                    End If
                                Case System.DayOfWeek.Saturday
                                    If settings.Sat = True Then
                                        skygrabber.Grab()
                                    End If
                                Case System.DayOfWeek.Sunday
                                    If settings.Sun = True Then
                                        skygrabber.Grab()
                                    End If
                            End Select
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Public ReadOnly Property Author As String Implements TvEngine.ITvServerPlugin.Author
        Get
            Return "DJBlu"
        End Get
    End Property

    Public ReadOnly Property MasterOnly As Boolean Implements TvEngine.ITvServerPlugin.MasterOnly
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property Name As String Implements TvEngine.ITvServerPlugin.Name
        Get
            Return "Sky NZ Grabber"
        End Get
    End Property

    Public ReadOnly Property Setup As SetupTv.SectionSettings Implements TvEngine.ITvServerPlugin.Setup
        Get
            Return New Setup()
        End Get
    End Property

    Public Sub Start(ByVal controller As TvControl.IController) Implements TvEngine.ITvServerPlugin.Start
        skygrabber = New SkyGrabber
        settings = New Settings
        settings.IsGrabbing = False
        timer = New Timers.Timer
        timer.Interval = 10000

        timer.Start()

    End Sub

    Public Sub Stopit() Implements TvEngine.ITvServerPlugin.Stop
        timer.Start()
        settings = Nothing
        skygrabber = Nothing
    End Sub

    Public ReadOnly Property Version As String Implements TvEngine.ITvServerPlugin.Version
        Get
            Return "1.2.0.27"
        End Get
    End Property

    Private Sub skygrabber_OnMessage(ByVal Text As String, ByVal UpdateLast As Boolean) Handles skygrabber.OnMessage
        If UpdateLast = False Then
            Log.Write("Sky Plugin : " & Text)
        End If
    End Sub
End Class

Public Class Settings
    Dim layer As New TvBusinessLayer
    Public Event OnSettingChanged()
    Dim FireEvent As Boolean = True
    Dim Themes As New Dictionary(Of Integer, String)

    Public Sub StopEvents()
        FireEvent = False
    End Sub
    Public Sub StartEvents()
        FireEvent = True
    End Sub
    Function GetSkySetting(ByVal _Setting As String, ByVal defaultvalue As Object) As String
        Return layer.GetSetting("OTVC_" + _Setting, defaultvalue.ToString()).Value
    End Function
    Sub UpdateSetting(ByVal _Setting As String, ByVal value As String)
        Dim setting As Setting = layer.GetSetting("OTVC_" + _Setting, "0")
        setting.Value = value.ToString()
        setting.Persist()
    End Sub
    Sub FireSettingChange()
        If FireEvent = True Then
            RaiseEvent OnSettingChanged()
        End If
    End Sub

    'Properties 
    Public Property modulation() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("modulation", -1))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("modulation", value.ToString)
        End Set
    End Property
    Public Property GrabTime() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("GrabTime", 60))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("GrabTime", value.ToString)
        End Set
    End Property
    Public Property frequency() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("frequency", 12519000))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("frequency", value.ToString)
        End Set
    End Property
    Public Property SymbolRate() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("SymbolRate", 22500))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("SymbolRate", value.ToString)
        End Set
    End Property
    Public Property NID() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("NID", &HA9))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("NID", value.ToString)
        End Set
    End Property
    Public Property polarisation() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("polarisation", 3))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("polarisation", value.ToString)
        End Set
    End Property
    Public Property ServiceID() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("ServiceID", 330))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("ServiceID", value.ToString)
        End Set
    End Property
    Public Property TransportID() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("TransportID", 3))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("TransportID", value.ToString)
        End Set
    End Property
    Public Property AutoUpdate() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("AutoUpdate", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("AutoUpdate", value.ToString)
        End Set
    End Property
    Public Property useExtraInfo() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("useExtraInfo", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("useExtraInfo", value.ToString)
        End Set
    End Property

    Public Property UpdateChannels() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("UpdateChannels", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("UpdateChannels", value.ToString)
        End Set
    End Property
    Public Property EveryHour() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("EveryHour", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("EveryHour", value.ToString)
        End Set
    End Property
    Public Property OnDaysAt() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("OnDaysAt", False))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("OnDaysAt", value.ToString)
        End Set
    End Property

    'Days
    Public Property Mon() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("Mon", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("Mon", value.ToString)
        End Set
    End Property
    Public Property Tue() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("Tue", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("Tue", value.ToString)
        End Set
    End Property
    Public Property Wed() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("Wed", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("Wed", value.ToString)
        End Set
    End Property
    Public Property Thu() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("Thu", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("Thu", value.ToString)
        End Set
    End Property
    Public Property Fri() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("Fri", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("Fri", value.ToString)
        End Set
    End Property
    Public Property Sat() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("Sat", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("Sat", value.ToString)
        End Set
    End Property
    Public Property Sun() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("Sun", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("Sun", value.ToString)
        End Set
    End Property
    Public Property UpdateTime() As DateTime
        Get
            Return Convert.ToDateTime(GetSkySetting("UpdateTime", Now.ToString))
        End Get
        Set(ByVal value As DateTime)
            UpdateSetting("UpdateTime", value.ToString)
        End Set
    End Property
    Public Property ReplaceSDwithHD() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("ReplaceSDwithHD", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("ReplaceSDwithHD", value.ToString)
        End Set
    End Property
    Public Property IgnoreScrambled() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("IgnoreScrambled", False))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("IgnoreScrambled", value.ToString)
        End Set
    End Property
    Public Property UseNotSetModSD() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("UseNotSetModSD", False))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("UseNotSetModSD", value.ToString)
        End Set
    End Property
    Public Property UseNotSetModHD() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("UseNotSetModHD", False))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("UseNotSetModHD", value.ToString)
        End Set
    End Property
    Public Property UpdateEPG() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("UpdateEPG", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("UpdateEPG", value.ToString)
        End Set
    End Property
    Public Property UpdateInterval() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("UpdateInterval", 3))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("UpdateInterval", value.ToString)
        End Set
    End Property
    Public Property RegionID() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("RegionID", 0))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("RegionID", value.ToString)
        End Set
    End Property
    Public Property BouquetID() As Integer
        Get
            If ReplaceSDwithHD Then
                Return Convert.ToInt32(GetSkySetting("BouquetID", 0)) + 4
            Else
                Return Convert.ToInt32(GetSkySetting("BouquetID", 0))
            End If
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("BouquetID", value.ToString)
        End Set
    End Property
    Public Property IsLoading As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("IsLoading", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("IsLoading", value.ToString)
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
    Public Property LastUpdate As DateTime
        Get

            Return DateTime.Parse(GetSkySetting("LastUpdate", Now.ToString))

        End Get
        Set(ByVal value As DateTime)
            UpdateSetting("LastUpdate", value.ToString)
        End Set
    End Property
    Public Property UseSkyNumbers() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("UseSkyNumbers", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("UseSkyNumbers", value.ToString)
        End Set
    End Property
    Public Property UseSkyCategories() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("UseSkyCategories", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("UseSkyCategories", value.ToString)
        End Set
    End Property
    Public Property UseSkyRegions() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("UseSkyRegions", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("UseSkyRegions", value.ToString)
        End Set
    End Property
    Public Property DeleteOldChannels() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("DeleteOldChannels", True))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("DeleteOldChannels", value.ToString)
        End Set
    End Property
    Public Property OldChannelFolder() As String
        Get
            Return GetSkySetting("OldChannelFolder", "Old Sky Channels")
        End Get
        Set(ByVal value As String)
            UpdateSetting("OldChannelFolder", value)
        End Set
    End Property
    Public Property RegionIndex() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("RegionIndex", 0))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("RegionIndex", value.ToString)
        End Set
    End Property
    Public Property CardToUseIndex() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("CardToUseIndex", 0))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("CardToUseIndex", value.ToString)
        End Set
    End Property
    Public Property DiseqC() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("DiseqC", -1))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("DiseqC", value.ToString)
        End Set
    End Property
    Public Property SwitchingFrequency() As Integer
        Get
            Return Convert.ToInt32(GetSkySetting("SwitchingFrequency", 11700000))
        End Get
        Set(ByVal value As Integer)
            UpdateSetting("SwitchingFrequency", value.ToString)
        End Set
    End Property
    Public Property IsGrabbing() As Boolean
        Get
            Return Convert.ToBoolean(GetSkySetting("IsGrabbing", False))
        End Get
        Set(ByVal value As Boolean)
            UpdateSetting("IsGrabbing", value.ToString)
        End Set
    End Property
    Public Function GetCategory(ByVal CatByte As Byte) As String
        Return GetSkySetting("Cat" & CatByte, CatByte)
    End Function
    Public Sub SetCategory(ByVal CatByte As Byte, ByVal Name As String)
        UpdateSetting("Cat" & CatByte, Name)
    End Sub
    Public Function GetTheme(ByVal Id As Integer) As String
        If Themes.ContainsKey(Id) Then
            Return Themes(Id)
        Else
            Return ""
        End If
    End Function


    Public Sub New()
        Me.Themes.Add(0, "No Category")
        Me.Themes.Add(1, "")
        Me.Themes.Add(2, "")
        Me.Themes.Add(3, "")
        Me.Themes.Add(4, "")
        Me.Themes.Add(5, "")
        Me.Themes.Add(6, "")
        Me.Themes.Add(7, "")
        Me.Themes.Add(8, "")
        Me.Themes.Add(9, "")
        Me.Themes.Add(10, "")
        Me.Themes.Add(11, "")
        Me.Themes.Add(12, "")
        Me.Themes.Add(13, "")
        Me.Themes.Add(14, "")
        Me.Themes.Add(15, "")
        Me.Themes.Add(&H10, "")
        Me.Themes.Add(&H11, "")
        Me.Themes.Add(&H12, "")
        Me.Themes.Add(&H13, "")
        Me.Themes.Add(20, "")
        Me.Themes.Add(&H15, "")
        Me.Themes.Add(&H16, "")
        Me.Themes.Add(&H17, "")
        Me.Themes.Add(&H18, "")
        Me.Themes.Add(&H19, "")
        Me.Themes.Add(&H1A, "")
        Me.Themes.Add(&H1B, "")
        Me.Themes.Add(&H1C, "")
        Me.Themes.Add(&H1D, "")
        Me.Themes.Add(30, "")
        Me.Themes.Add(&H1F, "")
        Me.Themes.Add(&H20, "Movie")
        Me.Themes.Add(&H21, "Movie - Thriller")
        Me.Themes.Add(&H22, "Movie - Action")
        Me.Themes.Add(&H23, "Movie - Sci Fi")
        Me.Themes.Add(&H24, "Movie - Comedy")
        Me.Themes.Add(&H25, "Movie - Family")
        Me.Themes.Add(&H26, "Movie - Romance")
        Me.Themes.Add(&H27, "Movie - Historical")
        Me.Themes.Add(40, "Movie - Factual")
        Me.Themes.Add(&H29, "Movie - Animation")
        Me.Themes.Add(&H2A, "Movie - Horror")
        Me.Themes.Add(&H2B, "Movie - Documentary")
        Me.Themes.Add(&H2C, "Movie - Documentary")
        Me.Themes.Add(&H2D, "Movie - Documentary")
        Me.Themes.Add(&H2E, "Movie - Western")
        Me.Themes.Add(&H2F, "Movie - Other")
        Me.Themes.Add(&H30, "")
        Me.Themes.Add(&H31, "")
        Me.Themes.Add(50, "")
        Me.Themes.Add(&H33, "")
        Me.Themes.Add(&H34, "")
        Me.Themes.Add(&H35, "")
        Me.Themes.Add(&H36, "")
        Me.Themes.Add(&H37, "")
        Me.Themes.Add(&H38, "")
        Me.Themes.Add(&H39, "")
        Me.Themes.Add(&H3A, "")
        Me.Themes.Add(&H3B, "")
        Me.Themes.Add(60, "")
        Me.Themes.Add(&H3D, "")
        Me.Themes.Add(&H3E, "")
        Me.Themes.Add(&H3F, "")
        Me.Themes.Add(&H40, "News & Documentaries")
        Me.Themes.Add(&H41, "News & Documentaries - News & Weather")
        Me.Themes.Add(&H42, "News & Documentaries - Magazine")
        Me.Themes.Add(&H43, "News & Documentaries - Documentary")
        Me.Themes.Add(&H44, "News & Documentaries - Discussion")
        Me.Themes.Add(&H45, "News & Documentaries - Educational")
        Me.Themes.Add(70, "News & Documentaries - Feature")
        Me.Themes.Add(&H47, "News & Documentaries - Politics")
        Me.Themes.Add(&H48, "News & Documentaries - News")
        Me.Themes.Add(&H49, "News & Documentaries - Nature")
        Me.Themes.Add(&H4A, "News & Documentaries - Religious")
        Me.Themes.Add(&H4B, "News & Documentaries - Science")
        Me.Themes.Add(&H4C, "News & Documentaries - Showbiz")
        Me.Themes.Add(&H4D, "News & Documentaries - War Documentary")
        Me.Themes.Add(&H4E, "News & Documentaries - Historical")
        Me.Themes.Add(&H4F, "News & Documentaries - Other")
        Me.Themes.Add(80, "")
        Me.Themes.Add(&H51, "")
        Me.Themes.Add(&H52, "")
        Me.Themes.Add(&H53, "")
        Me.Themes.Add(&H54, "")
        Me.Themes.Add(&H55, "")
        Me.Themes.Add(&H56, "")
        Me.Themes.Add(&H57, "")
        Me.Themes.Add(&H58, "")
        Me.Themes.Add(&H59, "")
        Me.Themes.Add(90, "")
        Me.Themes.Add(&H5B, "")
        Me.Themes.Add(&H5C, "")
        Me.Themes.Add(&H5D, "")
        Me.Themes.Add(&H5E, "")
        Me.Themes.Add(&H5F, "")
        Me.Themes.Add(&H60, "Entertainment")
        Me.Themes.Add(&H61, "Entertainment - Contests")
        Me.Themes.Add(&H62, "Entertainment - Magazine")
        Me.Themes.Add(&H63, "Entertainment - Talk Show")
        Me.Themes.Add(100, "Entertainment - Reality")
        Me.Themes.Add(&H65, "Entertainment - Action")
        Me.Themes.Add(&H66, "Entertainment - Drama")
        Me.Themes.Add(&H67, "Entertainment - Comedy")
        Me.Themes.Add(&H68, "Entertainment - Documentary")
        Me.Themes.Add(&H69, "Entertainment - Soap")
        Me.Themes.Add(&H6A, "Entertainment - Sci-Fi")
        Me.Themes.Add(&H6B, "Entertainment - Crime")
        Me.Themes.Add(&H6C, "Entertainment - Game Show")
        Me.Themes.Add(&H6D, "Entertainment - Reality")
        Me.Themes.Add(110, "Entertainment - Talk Show")
        Me.Themes.Add(&H6F, "Entertainment - Other")
        Me.Themes.Add(&H70, "Entertainment - Arts")
        Me.Themes.Add(&H71, "Entertainment - Lifestyle")
        Me.Themes.Add(&H72, "Entertainment - Home")
        Me.Themes.Add(&H73, "Entertainment - Magazine")
        Me.Themes.Add(&H74, "Entertainment - Medical")
        Me.Themes.Add(&H75, "Entertainment - Review")
        Me.Themes.Add(&H76, "Entertainment - Antiques")
        Me.Themes.Add(&H77, "Entertainment - Motors")
        Me.Themes.Add(120, "Entertainment - Art&Lit")
        Me.Themes.Add(&H79, "Entertainment - Ballet")
        Me.Themes.Add(&H7A, "Entertainment - Opera")
        Me.Themes.Add(&H7B, "")
        Me.Themes.Add(&H7C, "")
        Me.Themes.Add(&H7D, "")
        Me.Themes.Add(&H7E, "")
        Me.Themes.Add(&H7F, "")
        Me.Themes.Add(&H80, "Sports")
        Me.Themes.Add(&H81, "Sports - Special Event")
        Me.Themes.Add(130, "Sports - Magazine")
        Me.Themes.Add(&H83, "Sports - Football")
        Me.Themes.Add(&H84, "Sports - Tennis/Squash")
        Me.Themes.Add(&H85, "Sports - Team Sports")
        Me.Themes.Add(&H86, "Sports - Athletics")
        Me.Themes.Add(&H87, "Sports - MotorSport")
        Me.Themes.Add(&H88, "Sports - Water Sports")
        Me.Themes.Add(&H89, "Sports - Winter Sports")
        Me.Themes.Add(&H8A, "Sports - Equestrian")
        Me.Themes.Add(&H8B, "Sports - Martial Sports")
        Me.Themes.Add(140, "Sports - Rugby")
        Me.Themes.Add(&H8D, "Sports - Cycling")
        Me.Themes.Add(&H8E, "Sports - Other")
        Me.Themes.Add(&H8F, "")
        Me.Themes.Add(&H90, "")
        Me.Themes.Add(&H91, "")
        Me.Themes.Add(&H92, "")
        Me.Themes.Add(&H93, "")
        Me.Themes.Add(&H94, "")
        Me.Themes.Add(&H95, "")
        Me.Themes.Add(150, "")
        Me.Themes.Add(&H97, "")
        Me.Themes.Add(&H98, "")
        Me.Themes.Add(&H99, "")
        Me.Themes.Add(&H9A, "")
        Me.Themes.Add(&H9B, "")
        Me.Themes.Add(&H9C, "")
        Me.Themes.Add(&H9D, "")
        Me.Themes.Add(&H9E, "")
        Me.Themes.Add(&H9F, "")
        Me.Themes.Add(160, "Children")
        Me.Themes.Add(&HA1, "Children - Pre-School Programmes")
        Me.Themes.Add(&HA2, "Children - Programmes for 6-14 years")
        Me.Themes.Add(&HA3, "Children - Programmes for 10-16 years")
        Me.Themes.Add(&HA4, "Children - Educational")
        Me.Themes.Add(&HA5, "Children - Cartoons")
        Me.Themes.Add(&HA6, "")
        Me.Themes.Add(&HA7, "")
        Me.Themes.Add(&HA8, "Children - Factual")
        Me.Themes.Add(&HA9, "Children - Cartoons")
        Me.Themes.Add(170, "")
        Me.Themes.Add(&HAB, "")
        Me.Themes.Add(&HAC, "")
        Me.Themes.Add(&HAD, "")
        Me.Themes.Add(&HAE, "")
        Me.Themes.Add(&HAF, "Children - Other")
        Me.Themes.Add(&HB0, "")
        Me.Themes.Add(&HB1, "")
        Me.Themes.Add(&HB2, "")
        Me.Themes.Add(&HB3, "")
        Me.Themes.Add(180, "")
        Me.Themes.Add(&HB5, "")
        Me.Themes.Add(&HB6, "")
        Me.Themes.Add(&HB7, "")
        Me.Themes.Add(&HB8, "")
        Me.Themes.Add(&HB9, "")
        Me.Themes.Add(&HBA, "")
        Me.Themes.Add(&HBB, "")
        Me.Themes.Add(&HBC, "")
        Me.Themes.Add(&HBD, "")
        Me.Themes.Add(190, "")
        Me.Themes.Add(&HBF, "")
        Me.Themes.Add(&HC0, "Music")
        Me.Themes.Add(&HC1, "Music - Rock")
        Me.Themes.Add(&HC2, "Music - Live")
        Me.Themes.Add(&HC3, "")
        Me.Themes.Add(&HC4, "")
        Me.Themes.Add(&HC5, "")
        Me.Themes.Add(&HC6, "")
        Me.Themes.Add(&HC7, "")
        Me.Themes.Add(200, "")
        Me.Themes.Add(&HC9, "")
        Me.Themes.Add(&HCA, "")
        Me.Themes.Add(&HCB, "")
        Me.Themes.Add(&HCC, "")
        Me.Themes.Add(&HCD, "")
        Me.Themes.Add(&HCE, "")
        Me.Themes.Add(&HCF, "Music - Other")
        Me.Themes.Add(&HD0, "")
        Me.Themes.Add(&HD1, "")
        Me.Themes.Add(210, "")
        Me.Themes.Add(&HD3, "")
        Me.Themes.Add(&HD4, "")
        Me.Themes.Add(&HD5, "")
        Me.Themes.Add(&HD6, "")
        Me.Themes.Add(&HD7, "")
        Me.Themes.Add(&HD8, "")
        Me.Themes.Add(&HD9, "")
        Me.Themes.Add(&HDA, "")
        Me.Themes.Add(&HDB, "")
        Me.Themes.Add(220, "")
        Me.Themes.Add(&HDD, "")
        Me.Themes.Add(&HDE, "")
        Me.Themes.Add(&HDF, "")
        Me.Themes.Add(&HE0, "Arts & Culture")
        Me.Themes.Add(&HE1, "Arts & Culture - Performing Arts")
        Me.Themes.Add(&HE2, "Arts & Culture - Fine Arts")
        Me.Themes.Add(&HE3, "Arts & Culture - Religion")
        Me.Themes.Add(&HE4, "Arts & Culture - Traditional Arts")
        Me.Themes.Add(&HE5, "")
        Me.Themes.Add(230, "")
        Me.Themes.Add(&HE7, "")
        Me.Themes.Add(&HE8, "")
        Me.Themes.Add(&HE9, "")
        Me.Themes.Add(&HEA, "Arts & Culture - Magazine")
        Me.Themes.Add(&HEB, "Arts & Culture - Fashions")
        Me.Themes.Add(&HEC, "Arts & Culture - Other")
        Me.Themes.Add(&HED, "")
        Me.Themes.Add(&HEE, "")
        Me.Themes.Add(&HEF, "")
        Me.Themes.Add(240, "")
        Me.Themes.Add(&HF1, "")
        Me.Themes.Add(&HF2, "")
        Me.Themes.Add(&HF3, "")
        Me.Themes.Add(&HF4, "")
        Me.Themes.Add(&HF5, "")
        Me.Themes.Add(&HF6, "")
        Me.Themes.Add(&HF7, "")
        Me.Themes.Add(&HF8, "")
        Me.Themes.Add(&HF9, "")
        Me.Themes.Add(250, "")
        Me.Themes.Add(&HFB, "")
        Me.Themes.Add(&HFC, "")
        Me.Themes.Add(&HFD, "")
        Me.Themes.Add(&HFE, "")
        Me.Themes.Add(&HFF, "")
    End Sub
End Class

Public Class SkyGrabber
    Dim MapCards As List(Of Integer)
    ReadOnly CardstoMap As List(Of Card) = New List(Of Card)

    ReadOnly Settings As Settings = New Settings()
    Public firstask As Boolean = True
    Public WithEvents Sky As CustomDataGRabber 'Prviate _Sky as CustomDataGrabber in latst code.
    Public Channels As Dictionary(Of Integer, Sky_Channel) = New Dictionary(Of Integer, Sky_Channel)
    Public Bouquets As Dictionary(Of Integer, SkyBouquet) = New Dictionary(Of Integer, SkyBouquet)
    Public SDTInfo As Dictionary(Of String, SDTInfo) = New Dictionary(Of String, SDTInfo)
    Public NITInfo As Dictionary(Of Integer, NITSatDescriptor) = New Dictionary(Of Integer, NITSatDescriptor)

    Dim numberBouquetsPopulated As Integer = 0
    Dim SDTCount As Integer = 0

    Dim numberSDTPopulated As String = ""
    Dim GotAllSDT As Boolean = False
    Dim numberTIDPopulated As Integer = 0
    Dim GotAllTID As Boolean = False
    Public titlesDecoded As Integer = 0
    Dim summariesDecoded As Integer = 0
    Public titleDataCarouselStartLookup As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Public completedTitleDataCarousels As List(Of Integer) = New List(Of Integer)
    Public summaryDataCarouselStartLookup As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Public completedSummaryDataCarousels As List(Of Integer) = New List(Of Integer)
    Public CatsDesc As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Private orignH As HuffmanTreeNode = New HuffmanTreeNode()
    Private nH As HuffmanTreeNode
    Dim _layer As TvBusinessLayer = New TvBusinessLayer()
    Dim CPUHog As Integer = 0
    Dim MaxThisCanDo As Integer = 0
    Dim start As DateTime
    Dim DVBSChannel As DVBSChannel
    Dim FirstLCN As LCNHolder
    Public NITGot As Boolean = False
    Public Regions As List(Of String) = New List(Of String)()
    Public BouquetIDtoUse As Integer
    Public RegionIDtoUse As Integer
    Public GrabEPG As Boolean
    Public lasttime As DateTime
    Sub Reset()
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

    Function AreAllTitlesPopulated() As Object
        Return completedTitleDataCarousels.Count = 8
    End Function

    Function DoesTidCarryEpgTitleData(ByVal TableID As Integer) As Boolean
        Return TableID = 160 Or TableID = &HA1 Or TableID = &HA2 Or TableID = &HA3
    End Function

    Function IsTitleDataCarouselOnPidComplete(ByVal pid As Integer) As Boolean
        Dim pid1 As Integer
        For Each pid1 In completedTitleDataCarousels
            If (pid1 = pid) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub OnTitleReceived(ByVal pid As Integer, ByVal titleChannelEventUnionId As String)

        If titleDataCarouselStartLookup.ContainsKey(pid) Then
            If (titleDataCarouselStartLookup(pid) = titleChannelEventUnionId) Then
                completedTitleDataCarousels.Add(pid)
            End If
        Else
            titleDataCarouselStartLookup.Add(pid, titleChannelEventUnionId)
        End If

    End Sub

    Function AreAllSummariesPopulated()
        Return completedSummaryDataCarousels.Count = 8
    End Function

    Private Sub OnSummaryReceived(ByVal pid As Integer, ByVal summaryChannelEventUnionId As String)
        If summaryDataCarouselStartLookup.ContainsKey(pid) Then
            If (summaryDataCarouselStartLookup(pid) = summaryChannelEventUnionId) Then
                completedSummaryDataCarousels.Add(pid)
                If Not (AreAllSummariesPopulated()) Then
                    Return
                End If
            End If
        Else
            summaryDataCarouselStartLookup.Add(pid, summaryChannelEventUnionId)
        End If
    End Sub

    Function IsSummaryDataCarouselOnPidComplete(ByVal pid As Integer) As Boolean
        Dim pid1 As Integer
        For Each pid1 In completedSummaryDataCarousels
            If pid1 = pid Then Return True
        Next
        Return False
    End Function

    Sub UpdateEPGEvent(ByRef channelId As Integer, ByVal eventId As Integer, ByVal SkyEvent As SkyEvent)
        If Channels.ContainsKey(channelId) AndAlso Channels(channelId).Events.ContainsKey(eventId) Then
            Channels.Item(channelId).Events.Item(eventId) = SkyEvent
        End If
    End Sub

    Sub UpdateChannel(ByVal ChannelId As Integer, ByVal Channel As Sky_Channel)
        If Channels.ContainsKey(ChannelId) Then
            Channels.Item(ChannelId) = Channel
        End If
    End Sub

    Function GetEpgEvent(ByVal channelId As Long, ByVal eventId As Integer) As SkyEvent
        Dim channel As Sky_Channel = GetChannel(channelId)
        If Not channel.Events.ContainsKey(eventId) Then
            channel.Events.Add(eventId, New SkyEvent)
        End If
        Return channel.Events.Item(eventId)
    End Function

    Private Sub OnTitleSectionReceived(ByVal pid As Integer, ByVal section As Custom_Data_Grabber.Section)
        Try
            If Not (IsTitleDataCarouselOnPidComplete(pid)) AndAlso DoesTidCarryEpgTitleData(section.table_id) Then
                Dim buffer() As Byte = section.Data
                Dim totalLength As Integer = (((buffer(1) And 15) * 256) + buffer(2)) - 2
                If (section.section_length >= 20) Then
                    Dim channelId As Long = (buffer(3) * (2 ^ 8)) + buffer(4)
                    Dim mjdStart As Long = (buffer(8) * (2 ^ 8)) + buffer(9)
                    If Not (channelId = 0 Or mjdStart = 0) Then
                        Dim currentTitleItem As Integer = 10
                        Dim iterationCounter As Integer = 0
                        Do While (currentTitleItem < totalLength)
                            If (iterationCounter > 512) Then
                                Return
                            End If
                            iterationCounter += 1
                            Dim eventId As Integer = (buffer(currentTitleItem + 0) * (2 ^ 8)) + buffer(currentTitleItem + 1)
                            Dim headerType As Double = (buffer(currentTitleItem + 2) And &HF0) >> 4
                            Dim bodyLength As Integer = ((buffer(currentTitleItem + 2) And &HF) * (2 ^ 8)) + buffer(currentTitleItem + 3)
                            Dim carouselLookupId As String = channelId.ToString & ":" & eventId.ToString
                            OnTitleReceived(pid, carouselLookupId) ' check code for titlechanneleventunionid as this might be carousellookupid
                            If (IsTitleDataCarouselOnPidComplete(pid)) Then
                                Return
                            End If
                            Dim epgEvent As SkyEvent = GetEpgEvent(channelId, eventId)
                            If epgEvent Is Nothing Then
                                Return
                            End If
                            epgEvent.mjdStart = mjdStart
                            epgEvent.EventID = eventId
                            Const headerLength As Integer = 4
                            Dim currentTitleItemBody As Integer = currentTitleItem + headerLength
                            Dim titleDescriptor As Integer = buffer(currentTitleItemBody + 0)
                            Dim encodedBufferLength As Integer = buffer(currentTitleItemBody + 1) - 7
                            If (titleDescriptor = &HB5) Then
                                epgEvent.StartTime = (buffer(currentTitleItemBody + 2) * (2 ^ 9)) Or (buffer(currentTitleItemBody + 3) * (2 ^ 1))
                                epgEvent.Duration = (buffer(currentTitleItemBody + 4) * (2 ^ 9)) Or (buffer(currentTitleItemBody + 5) * (2 ^ 1))
                                Dim themeId As Byte = buffer(currentTitleItemBody + 6)
                                epgEvent.Category = themeId
                                epgEvent.SetFlags(buffer(currentTitleItemBody + 7))
                                epgEvent.SetCategory(buffer(currentTitleItemBody + 8))
                                epgEvent.seriesTermination = ((buffer(currentTitleItemBody + 8) And &H40) >> 6) Xor &H1
                                If (encodedBufferLength <= 0) Then
                                    currentTitleItem += (headerLength + bodyLength)
                                End If
                                If (epgEvent.Title = "") Then
                                    '//	Decode the huffman buffer
                                    Dim huffbuff As Byte() = New Byte(&H1001 - 1) {}
                                    If (currentTitleItemBody + 9 + encodedBufferLength > buffer.Length) Then
                                        Return
                                    End If
                                    Array.Copy(buffer, currentTitleItemBody + 9, huffbuff, 0, encodedBufferLength)
                                    epgEvent.Title = NewHuffman(huffbuff, encodedBufferLength)
                                    Dim title As String = ""
                                    If Not epgEvent.Title.StartsWith("[[") Then
                                        title = epgEvent.Title
                                    Else
                                        Dim index As Integer = epgEvent.Title.IndexOf("]")
                                        If (((index <> -1) AndAlso (Conversions.ToString(epgEvent.Title.Chars((index + 1))) = "]")) AndAlso ((index + 2) < epgEvent.Title.Length)) Then
                                            title = epgEvent.Title.Substring((index + 2))
                                        Else
                                            title = epgEvent.Title
                                        End If
                                    End If
                                    epgEvent.Title = title
                                    If (epgEvent.Title <> "") Then
                                        OnTitleDecoded()
                                    End If
                                Else
                                    Return
                                End If
                                Dim channelid2 As Integer = channelId
                                UpdateEPGEvent(channelid2, epgEvent.EventID, epgEvent)
                                channelId = channelid2
                            End If
                            currentTitleItem += (bodyLength + headerLength)
                        Loop
                        If (currentTitleItem <> (totalLength + 1)) Then
                        End If
                    End If
                End If
            End If
        Catch err As Exception
            RaiseEvent OnMessage("Error decoding title, " & err.Message, False)
            Return
        End Try
    End Sub

    Public Event OnMessage(ByVal Text As String, ByVal UpdateLast As Boolean)

    Sub ParseNIT(ByVal Data As Custom_Data_Grabber.Section, ByVal Length As Integer)
        Try
            If NITGot Then Return
            Dim buf As Byte() = Data.Data
            Dim section_syntax_indicator As Integer = buf(1) And &H80
            Dim section_length As Integer = ((buf(1) And 15) * 256) Or buf(2)
            Dim network_id As Integer = (buf(3) * 256) Or buf(4)
            Dim version_number As Integer = (buf(5) >> 1) And &H1F
            Dim current_next_indicator As Integer = buf(5) And 1
            Dim section_number As Integer = buf(6)
            Dim last_section_number As Integer = buf(7)
            Dim network_descriptor_length As Integer = ((buf(8) And 15) * 256) Or buf(9)
            Dim l1 As Integer = network_descriptor_length
            Dim pointer As Integer = 10
            Dim x As Integer = 0
            Do While (l1 > 0)
                Dim indicator As Integer = buf(pointer)
                x = buf(pointer + 1) + 2
                'LogDebug("decode nit desc1:%x len:%d", indicator, x)
                If (indicator = &H40) Then
                    Dim netWorkName As String = System.Text.Encoding.GetEncoding("iso-8859-1").GetString(buf, pointer + 2, x - 2)
                End If
                l1 -= x
                pointer += x
            Loop
            pointer = 10 + network_descriptor_length
            If (pointer <= section_length) Then
                'LogDebug("NIT: decode() network:'%s'", m_nit.NetworkName)
                Dim transport_stream_loop_length As Integer = ((buf(pointer) And &HF) * 256) + buf(pointer + 1)
                l1 = transport_stream_loop_length
                pointer += 2
                Do While (l1 > 0)
                    If (pointer + 2 > section_length) Then
                        Return
                    End If
                    Dim transport_stream_id As Integer = (buf(pointer) * 256) + buf(pointer + 1) 'new code uses TransportID
                    Dim original_network_id As Integer = (buf(pointer + 2) * 256) + buf(pointer + 3) 'new code uses networkID
                    Dim transport_descriptor_length As Integer = ((buf(pointer + 4) And &HF) * 256) + buf(pointer + 5)
                    pointer += 6
                    l1 -= 6
                    Dim l2 As Integer = transport_descriptor_length
                    Do While (l2 > 0)
                        If (pointer + 2 > section_length) Then
                            Return
                        End If
                        Dim indicator As Integer = buf(pointer)
                        x = buf(pointer + 1) + 2
                        If (indicator = &H43) Then ' sat
                            DVB_GetSatDelivSys(buf, pointer, x, original_network_id, transport_stream_id)
                        End If
                        pointer += x
                        l2 -= x
                        l1 -= x
                    Loop
                Loop
            End If
        Catch ex As Exception
            RaiseEvent OnMessage("Error Parsing NIT", False)
        End Try
    End Sub

    Sub DVB_GetSatDelivSys(ByVal b As Byte(), ByVal pointer As Integer, ByVal maxLen As Integer, ByVal NetworkID As Integer, ByVal TransportID As Integer)

        If (b(pointer + 0) = &H43 And maxLen >= 13) Then
            Dim descriptor_tag = b(pointer + 0)
            Dim descriptor_length = b(pointer + 1)

            If (descriptor_length <= 13) Then
                Dim satteliteNIT As New NITSatDescriptor
                satteliteNIT.TID = TransportID
                satteliteNIT.Frequency = (100000000 * ((b(pointer + 2) >> 4) And &HF))
                satteliteNIT.Frequency += (10000000 * (b(pointer + 2) And &HF))
                satteliteNIT.Frequency += (1000000 * ((b(pointer + 3) >> 4) And &HF))
                satteliteNIT.Frequency += (100000 * (b(pointer + 3) And &HF))
                satteliteNIT.Frequency += (10000 * ((b(pointer + 4) >> 4) And &HF))
                satteliteNIT.Frequency += (1000 * (b(pointer + 4) And &HF))
                satteliteNIT.Frequency += (100 * ((b(pointer + 5) >> 4) And &HF))
                satteliteNIT.Frequency += (10 * (b(pointer + 5) And &HF))
                satteliteNIT.OrbitalPosition += (1000 * ((b(pointer + 6) >> 4) And &HF))
                satteliteNIT.OrbitalPosition += (100 * ((b(pointer + 6) And &HF)))
                satteliteNIT.OrbitalPosition += (10 * ((b(pointer + 7) >> 4) And &HF))
                satteliteNIT.OrbitalPosition += (b(pointer + 7) And &HF)
                satteliteNIT.WestEastFlag = (b(pointer + 8) And &H80) >> 7
                Dim Polarisation As Integer = (b(pointer + 8) And &H60) >> 5
                satteliteNIT.Polarisation = Polarisation + 1
                satteliteNIT.isS2 = (b(pointer + 8) And &H4) >> 2
                If (satteliteNIT.isS2 > 0) Then
                    Dim rollOff = (b(pointer + 8) And &H18) >> 3
                    Select Case rollOff
                        Case Is = 0
                            satteliteNIT.RollOff = 3
                        Case Is = 1
                            satteliteNIT.RollOff = 2
                        Case Is = 2
                            satteliteNIT.RollOff = 1
                    End Select
                Else
                    satteliteNIT.RollOff = -1
                End If
                satteliteNIT.Modulation = (b(pointer + 8) And &H3)
                satteliteNIT.Symbolrate = (100000 * ((b(pointer + 9) >> 4) And &HF))
                satteliteNIT.Symbolrate += (10000 * ((b(pointer + 9) And &HF)))
                satteliteNIT.Symbolrate += (1000 * ((b(pointer + 10) >> 4) And &HF))
                satteliteNIT.Symbolrate += (100 * ((b(pointer + 10) And &HF)))
                satteliteNIT.Symbolrate += (10 * ((b(pointer + 11) >> 4) And &HF))
                satteliteNIT.Symbolrate += (1 * ((b(pointer + 11) And &HF)))
                Dim fec As Integer = (b(pointer + 12) And &HF)
                Select Case fec
                    Case 0
                        fec = 0
                    Case 1
                        fec = 1
                    Case 2
                        fec = 2
                    Case 3
                        fec = 3
                    Case 4
                        fec = 6
                    Case 5
                        fec = 8
                    Case 6
                        fec = 13
                    Case 7
                        fec = 4
                    Case 8
                        fec = 5
                    Case 9
                        fec = 14
                    Case Else
                        fec = 0
                End Select
                satteliteNIT.FECInner = fec
                If Not NITInfo.ContainsKey(TransportID) Then
                    NITInfo.Add(TransportID, satteliteNIT)
                Else
                    If GotAllTID <> True Then
                        RaiseEvent OnMessage("Got Network Information, " & NITInfo.Count & " transponders", False)
                    End If
                    GotAllTID = True
                    Return
                End If
            End If
        End If
    End Sub

    Public Sub OnTSPacket(ByVal Pid As Integer, ByVal Length As Integer, ByVal Data As Custom_Data_Grabber.Section)
        '  Try
        Select Case Pid
            Case Is = &H10
                'NIT
                If Not GotAllTID Then
                    ParseNIT(Data, Length)
                End If
                Exit Select
            Case Is = &H11
                'SDT/BAT
                ParseChannels(Data, Length)
                Exit Select
            Case Is = &H30, &H31, &H32, &H33, &H34, &H35, &H36, &H37
                'OpenTV Titles
                OnTitleSectionReceived(Pid, Data)
                Exit Select
            Case Is = &H40, &H41, &H42, &H43, &H44, &H45, &H46, &H47
                'OpenTV Sumarries
                OnSummarySectionReceived(Pid, Data)
                Exit Select
        End Select
        If IsEverythingGrabbed() Then
            RaiseEvent OnMessage("Everything Grabbed", False)
            Sky.SendComplete(0)
        End If
    End Sub

    Sub CreateGroups()

        If Settings.UseSkyCategories Then
            Dim groups As New List(Of String)
            If Settings.GetSkySetting("CatByte20", "-1") <> "-1" And Settings.GetSkySetting("CatText20", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText20", ""))
            If Settings.GetSkySetting("CatByte19", "-1") <> "-1" And Settings.GetSkySetting("CatText19", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText19", ""))
            If Settings.GetSkySetting("CatByte18", "-1") <> "-1" And Settings.GetSkySetting("CatText18", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText18", ""))
            If Settings.GetSkySetting("CatByte17", "-1") <> "-1" And Settings.GetSkySetting("CatText17", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText17", ""))
            If Settings.GetSkySetting("CatByte16", "-1") <> "-1" And Settings.GetSkySetting("CatText16", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText16", ""))
            If Settings.GetSkySetting("CatByte15", "-1") <> "-1" And Settings.GetSkySetting("CatText15", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText15", ""))
            If Settings.GetSkySetting("CatByte14", "-1") <> "-1" And Settings.GetSkySetting("CatText14", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText14", ""))
            If Settings.GetSkySetting("CatByte13", "-1") <> "-1" And Settings.GetSkySetting("CatText13", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText13", ""))
            If Settings.GetSkySetting("CatByte12", "-1") <> "-1" And Settings.GetSkySetting("CatText12", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText12", ""))
            If Settings.GetSkySetting("CatByte11", "-1") <> "-1" And Settings.GetSkySetting("CatText11", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText11", ""))
            If Settings.GetSkySetting("CatByte10", "-1") <> "-1" And Settings.GetSkySetting("CatText10", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText10", ""))
            If Settings.GetSkySetting("CatByte9", "-1") <> "-1" And Settings.GetSkySetting("CatText9", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText9", ""))
            If Settings.GetSkySetting("CatByte8", "-1") <> "-1" And Settings.GetSkySetting("CatText8", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText8", ""))
            If Settings.GetSkySetting("CatByte7", "-1") <> "-1" And Settings.GetSkySetting("CatText7", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText7", ""))
            If Settings.GetSkySetting("CatByte6", "-1") <> "-1" And Settings.GetSkySetting("CatText6", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText6", ""))
            If Settings.GetSkySetting("CatByte5", "-1") <> "-1" And Settings.GetSkySetting("CatText5", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText5", ""))
            If Settings.GetSkySetting("CatByte4", "-1") <> "-1" And Settings.GetSkySetting("CatText4", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText4", ""))
            If Settings.GetSkySetting("CatByte3", "-1") <> "-1" And Settings.GetSkySetting("CatText3", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText3", ""))
            If Settings.GetSkySetting("CatByte2", "-1") <> "-1" And Settings.GetSkySetting("CatText2", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText2", ""))
            If Settings.GetSkySetting("CatByte1", "-1") <> "-1" And Settings.GetSkySetting("CatText1", "") <> "" Then groups.Add(Settings.GetSkySetting("CatText1", ""))
            Dim count As Integer = groups.Count
            Dim name As String
            For Each name In groups
                _layer.CreateGroup(name)
                Dim groupbyname As ChannelGroup = _layer.GetGroupByName(name)
                groupbyname.SortOrder = count
                groupbyname.Persist()
                count -= 1
            Next
        End If
    End Sub

    Public Sub UpdateAddChannels()
        Try
            Dim DiseqC As Integer = Settings.DiseqC
            Dim UseSkyNumbers As Boolean = Settings.UseSkyNumbers
            Dim SwitchingFrequency As Integer = Settings.SwitchingFrequency
            Dim UseSkyRegions As Boolean = Settings.UseSkyRegions
            Dim UseSkyCategories As Boolean = Settings.UseSkyCategories
            Dim ChannelsAdded As Integer = 0
            Dim UseModNotSetSD As Boolean = Settings.UseNotSetModSD
            Dim UseModNotSetHD As Boolean = Settings.UseNotSetModHD
            Dim IgnoreScrambled As Boolean = Settings.IgnoreScrambled
            Dim nID As Integer = Settings.NID
            Dim channelnumber As Integer = 10000
            RaiseEvent OnMessage("", False)
            For Each pair As KeyValuePair(Of Integer, Sky_Channel) In Channels
                ChannelsAdded += 1
                RaiseEvent OnMessage("(" & ChannelsAdded & "/" & Channels.Count & ") Channels sorted", True)
                Dim ScannedChannel As Sky_Channel = pair.Value
                ScannedChannel = Nothing
                Dim ChannelId As Integer = pair.Key
                If ChannelId < 1 Then Continue For
                Dim VisibleInGuide As Boolean
                Dim DBChannel As Channel
                Dim channel As New DVBSChannel
                Dim currentDetail As TuningDetail = Nothing '= nothing has been added.
                If ScannedChannel.NID = 0 Or ScannedChannel.TID = 0 Or ScannedChannel.SID = 0 Then
                    Continue For
                End If
                Dim SDT As SDTInfo = GetChannelbySID(ScannedChannel.NID & "-" & ScannedChannel.TID & "-" & ScannedChannel.SID)

                If SDT Is Nothing Then
                    Continue For
                End If

                If IgnoreScrambled And SDT.isFTA Then
                    Continue For
                End If

                Dim checker As Channel = _layer.GetChannelbyExternalID(ScannedChannel.NID & ":" & ScannedChannel.ChannelID.ToString)

                If Not checker Is Nothing Then
                    Dim Channels As List(Of TuningDetail) = checker.ReferringTuningDetail
                    For Each Chann As TuningDetail In Channels
                        If Chann.ChannelType = 3 And Chann.NetworkId = nID Then
                            currentDetail = Chann
                            Exit For
                        End If
                    Next
                End If
                ' 
                If (Not currentDetail Is Nothing) Then
                    GoTo AddNewChannel
                End If
AddNewChannel:

                If Not NITInfo.ContainsKey(ScannedChannel.TID) Then
                    RaiseEvent OnMessage("No NIT found for : " & ScannedChannel.SID, False)
                    RaiseEvent OnMessage("", False)
                    Continue For
                End If

                If UseSkyNumbers Then
                    If ScannedChannel.LCNCount > 0 Then
                        If ScannedChannel.ContainsLCN(BouquetIDtoUse, RegionIDtoUse) Then
                            If ScannedChannel.ContainsLCN(BouquetIDtoUse, RegionIDtoUse) Then
                                channelnumber = ScannedChannel.GetLCN(BouquetIDtoUse, RegionIDtoUse).SkyNum
                            ElseIf ScannedChannel.ContainsLCN(BouquetIDtoUse, 255) Then
                                channelnumber = ScannedChannel.GetLCN(BouquetIDtoUse, 255).SkyNum
                            End If
                            If (channelnumber = 10000) Then
                                VisibleInGuide = False
                            End If
                        End If
                    End If
                End If
                DBChannel = _layer.AddNewChannel(SDT.ChannelName, channelnumber)
                If DBChannel Is Nothing Then
                    RaiseEvent OnMessage(("Error adding new channel : " & ScannedChannel.SID), False)
                    RaiseEvent OnMessage("", False)
                End If

                Dim NIT As NITSatDescriptor = NITInfo(ScannedChannel.TID)
                DVBSChannel.BandType = BandType.Universal
                DVBSChannel.DisEqc = CType(DiseqC, DisEqcType)
                DVBSChannel.FreeToAir = True
                DVBSChannel.Frequency = NIT.Frequency
                DVBSChannel.SymbolRate = NIT.Symbolrate
                DVBSChannel.InnerFecRate = DirectCast(NIT.FECInner, DirectShowLib.BDA.BinaryConvolutionCodeRate)
                DVBSChannel.IsRadio = SDT.isRadio
                DVBSChannel.IsTv = SDT.isTV
                DVBSChannel.FreeToAir = Not SDT.isFTA
                DBChannel.ChannelNumber = channelnumber
                DBChannel.SortOrder = channelnumber
                DVBSChannel.LogicalChannelNumber = channelnumber
                DBChannel.VisibleInGuide = VisibleInGuide
                If (NIT.isS2 And UseModNotSetHD) Or (NIT.isS2 = False And UseModNotSetSD) Then
                    DVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModNotSet
                Else
                    Select Case NIT.Modulation
                        Case 1
                            If NIT.isS2 Then
                                DVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModNbcQpsk
                            Else
                                DVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModQpsk
                            End If
                        Case 2
                            If NIT.isS2 Then
                                DVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModNbc8Psk
                            Else
                                DVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModNotDefined
                            End If
                        Case Else
                            DVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModNotDefined
                    End Select
                End If
                DVBSChannel.Name = SDT.ChannelName
                DVBSChannel.NetworkId = ScannedChannel.NID
                DVBSChannel.Pilot = Pilot.NotSet
                DVBSChannel.Rolloff = RollOff.NotSet
                If NIT.isS2 = 1 Then
                    DVBSChannel.Rolloff = DirectCast(NIT.RollOff, DirectShowLib.BDA.RollOff)
                End If
                DVBSChannel.PmtPid = 0
                DVBSChannel.Polarisation = DirectCast(NIT.Polarisation, DirectShowLib.BDA.Polarisation)
                DVBSChannel.Provider = SDT.Provider
                DVBSChannel.ServiceId = ScannedChannel.SID
                DVBSChannel.TransportId = ScannedChannel.TID
                DVBSChannel.SwitchingFrequency = SwitchingFrequency ' Option for user to enter
                DBChannel.IsRadio = SDT.isRadio
                DBChannel.IsTv = SDT.isTV
                DBChannel.ExternalId = ScannedChannel.NID & ":" & ScannedChannel.ChannelID.ToString
                DBChannel.Persist()
                MapChannelToCards(DBChannel)
                AddChannelToGroups(DBChannel, SDT, DVBSChannel, UseSkyCategories)
                _layer.AddTuningDetails(DBChannel, DVBSChannel)
                
                DBChannel = currentDetail.ReferencedChannel()
                If DBChannel Is Nothing Then
                    currentDetail.Remove()
                    currentDetail.Persist()
                    Continue For
                End If
                If DBChannel.ExternalId <> ScannedChannel.NID & ":" & ChannelId.ToString Then
                    'Problem with TVServer so need to add new channel.
                    GoTo AddNewChannel
                End If
                Dim checkDVBSChannel As DVBSChannel = DirectCast(_layer.GetTuningChannel(currentDetail), DVBSChannel)
                If checkDVBSChannel Is Nothing OrElse DBChannel Is Nothing OrElse SDTInfo.ContainsKey(String.Concat(New String() {Conversions.ToString(ScannedChannel.NID), "-", Conversions.ToString(ScannedChannel.TID), "-", Conversions.ToString(ScannedChannel.SID)})) Then
                    Continue For
                End If
                Dim Checksdt As SDTInfo
                If SDTInfo.ContainsKey(ScannedChannel.NID & "-" & ScannedChannel.TID & "-" & ScannedChannel.SID) Then
                    Dim haschanged As Boolean = False
                    Dim deleteepg As Boolean = False
                    Checksdt = SDTInfo(ScannedChannel.NID & "-" & ScannedChannel.TID & "-" & ScannedChannel.SID)
                    If DBChannel.DisplayName <> Checksdt.ChannelName Or currentDetail.Name <> Checksdt.ChannelName Then
                        RaiseEvent OnMessage("Channel " & DBChannel.DisplayName & " name changed to " & Checksdt.ChannelName, False)
                        DBChannel.DisplayName = Checksdt.ChannelName
                        checkDVBSChannel.Name = Checksdt.ChannelName
                        'Check Channel hasn't become a real channel from a test channel
                        If ScannedChannel.LCNCount > 0 And DBChannel.VisibleInGuide = False Then
                            DBChannel.VisibleInGuide = True
                            RaiseEvent OnMessage("Channel " & DBChannel.DisplayName & " is now part of the EPG making visible " & Checksdt.ChannelName & ".", False)
                        End If
                        haschanged = True
                    End If

                    If checkDVBSChannel.Provider <> Checksdt.Provider Then
                        RaiseEvent OnMessage("Channel " & DBChannel.DisplayName & " Provider name changed to " & Checksdt.Provider & ".", False)
                        RaiseEvent OnMessage("", False)
                        checkDVBSChannel.Provider = Checksdt.Provider
                        haschanged = True
                    End If

                    If currentDetail.TransportId <> ScannedChannel.TID Then
                        'Moved transponder
                        RaiseEvent OnMessage("Channel : " & DBChannel.DisplayName & " tuning details changed.", False)
                        RaiseEvent OnMessage("", False)
                        If NITInfo.ContainsKey(ScannedChannel.TID) Then
                            NIT = NITInfo(ScannedChannel.TID)
                        Else
                            Continue For
                        End If
                        checkDVBSChannel.BandType = 0
                        checkDVBSChannel.Frequency = NIT.Frequency
                        checkDVBSChannel.SymbolRate = NIT.Symbolrate
                        checkDVBSChannel.InnerFecRate = CType(NIT.FECInner, DirectShowLib.BDA.BinaryConvolutionCodeRate)
                        If (NIT.isS2 And UseModNotSetHD) Or (NIT.isS2 = False And UseModNotSetSD) Then
                            checkDVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModNotSet
                        Else
                            Select Case NIT.Modulation
                                Case 1
                                    If NIT.isS2 Then
                                        checkDVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModNbcQpsk
                                    Else
                                        checkDVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModQpsk
                                    End If
                                Case 2
                                    If NIT.isS2 Then
                                        checkDVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModNbc8Psk
                                    Else
                                        checkDVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModNotDefined
                                    End If
                                Case Else
                                    checkDVBSChannel.ModulationType = DirectShowLib.BDA.ModulationType.ModNotDefined
                            End Select

                        End If

                        checkDVBSChannel.Pilot = Pilot.NotSet
                        checkDVBSChannel.Rolloff = RollOff.NotSet

                        If NIT.isS2 = 1 Then
                            checkDVBSChannel.Rolloff = DirectCast(NIT.RollOff, DirectShowLib.BDA.RollOff)
                        End If

                        checkDVBSChannel.PmtPid = 0
                        checkDVBSChannel.Polarisation = DirectCast(NIT.Polarisation, DirectShowLib.BDA.Polarisation)
                        checkDVBSChannel.TransportId = ScannedChannel.TID
                        checkDVBSChannel.SwitchingFrequency = SwitchingFrequency ' Option for user to enter

                        haschanged = True
                        deleteepg = True
                        RaiseEvent OnMessage("Channel : " & DBChannel.DisplayName & " tuning details changed.", False)
                        RaiseEvent OnMessage("", False)
                    End If

                    If currentDetail.ServiceId <> ScannedChannel.SID Then
                        checkDVBSChannel.ServiceId = ScannedChannel.SID
                        checkDVBSChannel.PmtPid = 0
                        RaiseEvent OnMessage("Channel : " & DBChannel.DisplayName & " serviceID changed.", False)
                        RaiseEvent OnMessage("", False)
                        haschanged = True
                        deleteepg = True
                    End If

                    If UseSkyRegions = True Then
                        Dim checkLCN As Integer = 10000
                        If UseSkyNumbers Then
                            If ScannedChannel.LCNCount > 0 Then
                                If ScannedChannel.ContainsLCN(BouquetIDtoUse, RegionIDtoUse) Then
                                    Dim LCN As LCNHolder = ScannedChannel.GetLCN(BouquetIDtoUse, RegionIDtoUse)
                                    checkLCN = LCN.SkyNum
                                Else
                                    If ScannedChannel.ContainsLCN(BouquetIDtoUse, 255) Then
                                        Dim LCN As LCNHolder = ScannedChannel.GetLCN(BouquetIDtoUse, 255)
                                        checkLCN = LCN.SkyNum
                                    End If
                                End If

                                If (currentDetail.ChannelNumber <> checkLCN And checkLCN < 1000) Or (checkLCN = 10000 And DBChannel.SortOrder <> 10000) Then

                                    RaiseEvent OnMessage("Channel : " & DBChannel.DisplayName & " number has changed from : " & checkDVBSChannel.LogicalChannelNumber & " to : " & checkLCN & ".", False)
                                    RaiseEvent OnMessage("", False)
                                    DBChannel.RemoveFromAllGroups()
                                    currentDetail.ChannelNumber = checkLCN
                                    checkDVBSChannel.LogicalChannelNumber = checkLCN
                                    DBChannel.SortOrder = checkLCN
                                    DBChannel.VisibleInGuide = True
                                    haschanged = True
                                    AddChannelToGroups(DBChannel, Checksdt, checkDVBSChannel, UseSkyCategories)
                                End If

                            End If
                        End If
                    End If

                    If haschanged Then
                        DBChannel.Persist()
                        Dim tuning As TuningDetail = _layer.UpdateTuningDetails(DBChannel, checkDVBSChannel, currentDetail)
                        tuning.Persist()
                        MapChannelToCards(DBChannel)
                        If deleteepg Then
                            _layer.RemoveAllPrograms(DBChannel.IdChannel)
                        End If
                    End If

                End If


            Next
        Catch err As Exception

            MsgBox(err.Message)


        End Try


    End Sub
    Private Sub MapChannelToCards(ByVal DBChannel As Channel)
        For Each card__1 As Card In CardstoMap
            _layer.MapChannelToCard(card__1, DBChannel, False)
        Next
    End Sub

    Private Sub AddChannelToGroups(ByVal DBChannel As Channel, ByVal SDT As SDTInfo, ByVal DVBSChannel As DVBSChannel, ByVal UseSkyCategories As Boolean)
        If DBChannel.IsTv Then
            _layer.AddChannelToGroup(DBChannel, TvConstants.TvGroupNames.AllChannels)
            If DVBSChannel.LogicalChannelNumber < 750 Then 'was 1000
                If UseSkyCategories = True Then
                    If Settings.GetCategory(SDT.Category) <> SDT.Category.ToString Then
                        _layer.AddChannelToGroup(DBChannel, Settings.GetCategory(SDT.Category))
                    End If

                    If SDT.isHD Then
                        _layer.AddChannelToGroup(DBChannel, "HD Channels")
                    End If
                    If SDT.is3D Then
                        _layer.AddChannelToGroup(DBChannel, "3D Channels")
                    End If
                End If
            End If
        Else
            If DBChannel.IsRadio Then
                _layer.AddChannelToRadioGroup(DBChannel, TvConstants.RadioGroupNames.AllChannels)
            Else
                _layer.AddChannelToGroup(DBChannel, TvConstants.TvGroupNames.AllChannels)
            End If
        End If
    End Sub

    Public Sub UpdateEPG()
        Dim TVController1 As TvService.TVController = New TvService.TVController
        Dim DBUpd As New EpgDBUpdater(TVController1, "Sky TV EPG Updater", False)
        Dim ChannelstoUpdate As New List(Of EpgChannel)
        Dim AddExtraInfo As Boolean = Settings.useExtraInfo
        Dim now As DateTime = DateTime.Now
        'New method
        If _layer.GetPrograms(Now, Now.AddDays(1)).Count < 1 Then
            Dim listofprogs As New ProgramList

            Dim skychannelpair As KeyValuePair(Of Integer, Sky_Channel)
            For Each skychannelpair In Channels
                Dim skyChannel As Sky_Channel = skychannelpair.Value
                Dim DBChannel As Channel = _layer.GetChannelByTuningDetail(skyChannel.NID, skyChannel.TID, skyChannel.SID)
                If DBChannel Is Nothing Then

                Else
                    For Each SkyEvent1 As KeyValuePair(Of Integer, SkyEvent) In skyChannel.Events
                        Dim Eventtouse As SkyEvent = SkyEvent1.Value
                        If SkyEvent1.Value.EventID <> 0 And SkyEvent1.Value.Title <> "" Then
                            Dim programStartDay As DateTime = (New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds((Eventtouse.mjdStart + 2400000.5 - 2440587.5) * 86400)
                            Dim programStartTime As DateTime = programStartDay.AddSeconds(Eventtouse.StartTime)
                            '  Start time is in UTC, need to convert to local time
                            programStartTime = programStartTime.ToLocalTime()
                            '  Calculate end time
                            Dim programEndTime As DateTime = programStartTime.AddSeconds(Eventtouse.Duration)
                            Dim desc As String

                            If AddExtraInfo Then
                                desc = Eventtouse.Summary & " " & Eventtouse.DescriptionFlag
                            Else
                                desc = Eventtouse.Summary
                            End If

                            Dim ProgtoAdd As New Program(DBChannel.IdChannel, programStartTime, programEndTime, Eventtouse.Title _
                                                         , desc, Settings.GetTheme(Convert.ToInt32(Eventtouse.Category)), TvDatabase.Program.ProgramState.None,
                                                         New Date(1900, 1, 1), "", "", "", "", 0, Eventtouse.ParentalCategory, 0, Eventtouse.SeriesID.ToString(), Eventtouse.seriesTermination)
                            listofprogs.Add(ProgtoAdd)
                        End If
                    Next
                End If

            Next
            _layer.InsertPrograms(listofprogs, System.Threading.ThreadPriority.Highest)
        Else
            For Each SkyChannelPair As KeyValuePair(Of Integer, Sky_Channel) In Channels
                Dim skyChannel As Sky_Channel = SkyChannelPair.Value
                Dim EpgChannel As EpgChannel = New EpgChannel
                Dim baseChannel As DVBBaseChannel = New DVBSChannel()
                baseChannel.NetworkId = skyChannel.NID
                baseChannel.TransportId = skyChannel.TID
                baseChannel.ServiceId = skyChannel.SID
                baseChannel.Name = String.Empty
                EpgChannel.Channel = baseChannel
                For Each SkyEvent1 As KeyValuePair(Of Integer, SkyEvent) In skyChannel.Events
                    Dim Eventtouse As SkyEvent = SkyEvent1.Value
                    If SkyEvent1.Value.EventID <> 0 And SkyEvent1.Value.Title <> "" Then
                        Dim programStartDay As DateTime = (New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds((Eventtouse.mjdStart + 2400000.5 - 2440587.5) * 86400)
                        Dim programStartTime As DateTime = programStartDay.AddSeconds(Eventtouse.StartTime)
                        '  Start time is in UTC, need to convert to local time
                        programStartTime = programStartTime.ToLocalTime()
                        '  Calculate end time
                        Dim programEndTime As DateTime = programStartTime.AddSeconds(Eventtouse.Duration)

                        Dim skyProgramLang As EpgLanguageText

                        If AddExtraInfo Then
                            skyProgramLang = New EpgLanguageText("ALL", Eventtouse.Title, Eventtouse.Summary & " " & Eventtouse.DescriptionFlag, Settings.GetTheme(Convert.ToInt32(Eventtouse.Category)), 0, Eventtouse.ParentalCategory, -1)
                        Else
                            skyProgramLang = New EpgLanguageText("ALL", Eventtouse.Title, Eventtouse.Summary, Settings.GetTheme(Convert.ToInt32(Eventtouse.Category)), 0, Eventtouse.ParentalCategory, -1)
                        End If
                        Dim EPGProg As New EpgProgram(programStartTime, programEndTime)
                        EPGProg.Text.Add(skyProgramLang)
                        EPGProg.SeriesId = Eventtouse.SeriesID.ToString()
                        EPGProg.SeriesTermination = Eventtouse.seriesTermination
                        EpgChannel.Programs.Add(EPGProg)
                    End If
                Next
                If EpgChannel.Programs.Count > 0 Then
                    ChannelstoUpdate.Add(EpgChannel)
                End If
            Next
            Dim ChanNumber As Integer = 1
            RaiseEvent OnMessage("", False)
            For Each EpgChannel As EpgChannel In ChannelstoUpdate
                DBUpd.UpdateEpgForChannel(EpgChannel)
                RaiseEvent OnMessage("(" & ChanNumber & "/" & ChannelstoUpdate.Count & ") Channels Updated", True)
                ChanNumber += 1
            Next
        End If

        'TVController1 = Nothing
        'DBUpd = Nothing
        RaiseEvent OnMessage("EPG Update Complete", False)
    End Sub

    Public Event OnActivateControls()

    Sub UpdateDataBase(ByVal err As Boolean, ByVal errormessage As String)
        If Not err Then
            If Channels.Count < 46 Then
                RaiseEvent OnMessage("Error : Less than 46 channels found, Grabber found : " & Channels.Count, False)
            End If
            CreateGroups()
            If Settings.UpdateChannels Then
                RaiseEvent OnMessage("Moving/Deleting Old Channels", False)
                DeleteOldChannels()
                RaiseEvent OnMessage("Moving/Deleting Old Channels Complete", False)
                RaiseEvent OnMessage("Updating/Adding New Channels", False)
                UpdateAddChannels()
                RaiseEvent OnMessage("Updating/Adding New Channels Complete", False)
            End If

            If Settings.UpdateEPG Then
                RaiseEvent OnMessage("Updating EPG, please wait ... This can take upto 5 mins", False)
                UpdateEPG()
            End If
            Settings.LastUpdate = Now
            RaiseEvent OnMessage("Database Update Complete, took " & Int(Now.Subtract(start).TotalSeconds) & " Seconds", False)
        Else
            RaiseEvent OnMessage("Error Occured:- " & errormessage, False)
        End If
        RaiseEvent OnActivateControls()
        Settings.IsGrabbing = False
    End Sub

    Private Sub DeleteOldChannels()
        Dim UseRegions As Boolean = Settings.UseSkyRegions
        Dim DeleteOld As Boolean = Settings.DeleteOldChannels
        Dim OldFolder As String = Settings.OldChannelFolder
        RegionIDtoUse = Settings.RegionID

        Dim ChannelstoCheck As List(Of Channel) = DirectCast(_layer.Channels, List(Of Channel))

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
                If NetworkID <> &HA9 Then Continue For 'Not a Sky NZ channel
                If Channels.ContainsKey(ChannelID) = False Then
                    removechannel(Channelto, DeleteOld, OldFolder)
                    Continue For
                End If

                If UseRegions Then
                    'Move Channels that are not in this Bouquet
                    Dim ScannedChannel As Sky_Channel = Channels(ChannelID)
                    If Not ScannedChannel.ContainsLCN(BouquetIDtoUse, RegionIDtoUse) Or ScannedChannel.ContainsLCN(BouquetIDtoUse, 255) AndAlso (Channelto.IsTv And Channelto.VisibleInGuide) Then
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

    Sub removechannel(ByVal DBchannel As Channel, ByVal DeleteOld As Boolean, ByVal OldChannelFolder As String)
        'channel has been deleted
        If DeleteOld Then
            DBchannel.Delete()
            RaiseEvent OnMessage("Channel " & DBchannel.DisplayName & " no longer exists in the EPG, Deleted.", False)
        Else
            DBchannel.RemoveFromAllGroups()
            DBchannel.Persist()
            _layer.AddChannelToGroup(DBchannel, OldChannelFolder)
            RaiseEvent OnMessage("Channel " & DBchannel.DisplayName & " no longer exists in the EPG, moved to " & OldChannelFolder & ".", False)
        End If
    End Sub

    Private Sub Grabit()
        Sky = New CustomDataGRabber
        MapCards = Settings.CardMap
        If MapCards Is Nothing Or MapCards.Count = 0 Then
            RaiseEvent OnMessage("No cards have been selected for use, please ensure one is selected before continuing", False)
            Settings.IsGrabbing = False
            RaiseEvent OnActivateControls()
            Return
        End If
        Dim Cats() As String = My.Settings.UKCats.Split(vbNewLine)
        For Each Str As String In Cats
            Dim tr() As String
            tr = Str.Split("=")
            If Asc(tr(0).Substring(0, 1)) = 10 Then
                tr(0) = tr(0).Replace(Chr(10), "")
            End If
            CatsDesc.Add(tr(0), tr(1))
        Next
        LoadHuffman(0)
        RaiseEvent OnMessage("Huffman Loaded", False)
        Dim Pid_List As New List(Of Integer)
        Pid_List.Add(&H10)
        Pid_List.Add(&H11)
        If Settings.UpdateEPG Then
            For i = 0 To 7
                Pid_List.Add(&H30 + i)
                Pid_List.Add(&H40 + i)
            Next
        End If
        GrabEPG = Settings.UpdateEPG

        Dim Channel As Channel
        DVBSChannel = New DVBSChannel()

        Dim channelss As List(Of Channel) = _layer.GetChannelsByName("Sky NZ Grabber")
        If channelss.Count = 0 Then
            Channel = _layer.AddNewChannel("Sky NZ Grabber", 10000)
            Channel.VisibleInGuide = False
            Channel.SortOrder = 10000
            Channel.IsRadio = True
            Channel.IsTv = False
            DVBSChannel.BandType = 0
            DVBSChannel.DisEqc = DirectCast(Settings.DiseqC, DisEqcType)
            DVBSChannel.FreeToAir = True
            DVBSChannel.Frequency = Settings.frequency
            DVBSChannel.SymbolRate = Settings.SymbolRate
            DVBSChannel.InnerFecRate = BinaryConvolutionCodeRate.RateNotSet
            DVBSChannel.IsRadio = True
            DVBSChannel.IsTv = False
            DVBSChannel.LogicalChannelNumber = 10000
            DVBSChannel.ModulationType = DirectCast(Settings.modulation - 1, DirectShowLib.BDA.ModulationType)
            DVBSChannel.Name = "Sky NZ Grabber"
            DVBSChannel.NetworkId = Settings.NID
            DVBSChannel.Pilot = Pilot.NotSet
            DVBSChannel.PmtPid = 0
            DVBSChannel.Polarisation = DirectCast(Settings.polarisation - 1, Polarisation)
            DVBSChannel.Provider = "DJBlu"
            DVBSChannel.Rolloff = RollOff.NotSet
            DVBSChannel.ServiceId = Settings.ServiceID
            DVBSChannel.TransportId = Settings.TransportID
            DVBSChannel.SatelliteIndex = 16
            DVBSChannel.SwitchingFrequency = Settings.SwitchingFrequency
            Channel.Persist()
            _layer.AddTuningDetails(Channel, DVBSChannel)
            Dim id As Integer = -1
            For Each card__1 As Card In Card.ListAll()
                If RemoteControl.Instance.Type(card__1.IdCard) = CardType.DvbS Then
                    id += 1
                    If MapCards.Contains(id) Then
                        CardstoMap.Add(card__1)
                        _layer.MapChannelToCard(card__1, Channel, False)
                    End If
                End If
            Next
            _layer.AddChannelToRadioGroup(Channel, TvConstants.RadioGroupNames.AllChannels)
            RaiseEvent OnMessage("Sky NZ Grabber channel added to database", False)
        Else
            Channel = channelss(0)
            '  Dim num As Integer = Settings.CardToUseIndex
            Dim id As Integer = -1
            For Each card__1 As Card In Card.ListAll()
                If RemoteControl.Instance.Type(card__1.IdCard) = CardType.DvbS Then
                    id += 1
                    If MapCards.Contains(id) Then
                        CardstoMap.Add(card__1)
                    End If
                End If
            Next
        End If
        RaiseEvent OnMessage("Grabbing Data", False)

        If Channel Is Nothing Then
            RaiseEvent OnMessage("Channel was lost somewhere, try clicking on Grab data again", False)
        Else
            Dim grabtime As Integer = Settings.GrabTime
            RaiseEvent OnMessage("Grabber set to grab " & grabtime & " seconds of data", False)
            Sky.GrabData(Channel.IdChannel, grabtime, Pid_List)
        End If
    End Sub

    Public Sub Grab()

        RaiseEvent OnMessage("Sky Channel and EPG Grabber initialised", False)
        If Settings.IsGrabbing = False Then
            Settings.IsGrabbing = True
            Reset()
            Dim back As Threading.Thread = New Threading.Thread(AddressOf Grabit)
            back.Start()
        End If

    End Sub

    Private Sub LoadHuffman(ByVal type As Integer)

        Dim file1 As String

        file1 = My.Resources.UKDict
        Dim String1, String2 As String
        Dim Line() As String
        If nH Is Nothing Then
        Else
            nH.Clear()
            orignH.Clear()
        End If

        Line = file1.Split(vbNewLine)

        Dim a As Integer
        For a = 0 To Line.GetUpperBound(0)
            Line(a) = Line(a).Replace(Chr(10), "")
            String2 = Line(a).Substring(Line(a).LastIndexOf("=") + 1, Line(a).Length - Line(a).LastIndexOf("=") - 1)
            String1 = Line(a).Substring(0, Line(a).LastIndexOf("="))
            nH = orignH
            Dim t As Integer
            For t = 0 To String2.Length - 1
                If String2(t) = "1" Then
                    If (nH.P1 Is Nothing) Then
                        nH.P1 = New HuffmanTreeNode
                        nH = nH.P1
                    Else
                        nH = nH.P1
                    End If
                Else
                    If (nH.P0 Is Nothing) Then
                        nH.P0 = New HuffmanTreeNode
                        nH = nH.P0
                    Else
                        nH = nH.P0
                    End If
                End If
            Next
            nH.Value = String1
        Next
        nH = orignH
        Line = Nothing
        String1 = ""
        String2 = ""

    End Sub

    Public Function NewHuffman(ByVal Data() As Byte, ByVal Length As Integer) As String

        Dim DecodeText, DecodeErrorText As New StringBuilder
        Dim i, p, q
        Dim CodeError, IsFound As Boolean
        Dim showatend As Boolean = False
        Dim Byter, lastByte, Mask, lastMask As Byte
        nH = orignH
        p = 0
        q = 0
        DecodeText.Length = 0
        DecodeErrorText.Length = 0
        CodeError = False
        IsFound = False
        lastByte = 0
        lastMask = 0
        nH = orignH

        For i = 0 To Length - 1
            Byter = Data(i)
            Mask = &H80
            If (i = 0) Then
                If (Byter And &H20) = 1 Then
                    showatend = True

                End If

                Mask = &H20
                lastByte = i
                lastMask = Mask
            End If
loop1:
            If (IsFound) Then
                lastByte = i
                lastMask = Mask
                IsFound = False
            End If

            If ((Byter And Mask) = 0) Then

                If (CodeError) Then

                    DecodeErrorText.Append("0x30")
                    q += 1
                    GoTo nextloop1
                End If

                If (nH.P0 Is Nothing) = False Then
                    nH = nH.P0
                    If (nH.Value <> "") Then
                        If nH.Value <> "!!!" Then
                            DecodeText.Append(nH.Value)
                        End If

                        p += Len(nH.Value)
                        nH = orignH
                        IsFound = True
                    End If
                Else
                    p += 9
                    i = lastByte
                    Byter = Data(lastByte)
                    Mask = lastMask
                    CodeError = True
                    GoTo loop1
                End If

            Else

                If (CodeError) Then

                    DecodeErrorText.Append("0x31")
                    q += 1
                    GoTo nextloop1
                End If
                If (nH.P1 Is Nothing) = False Then
                    nH = nH.P1
                    If (nH.Value <> "") Then
                        If nH.Value <> "!!!" Then
                            DecodeText.Append(nH.Value)
                        End If
                        p += Len(nH.Value)
                        nH = orignH
                        IsFound = True
                    End If

                Else

                    p += 9
                    i = lastByte
                    Byter = Data(lastByte)
                    Mask = lastMask
                    CodeError = True
                    GoTo loop1
                End If
            End If
nextloop1:
            Mask = Mask >> 1
            If (Mask > 0) Then
                GoTo loop1
            End If


        Next

        Return DecodeText.ToString

    End Function

    Private Sub ParseSummaries(ByVal Data() As Byte, ByVal Length As Integer)

    End Sub

    Private Sub OnTitleDecoded()
        titlesDecoded += 1
    End Sub

    Private Sub OnSummaryDecoded()
        summariesDecoded += 1
    End Sub

    Private Sub ParseSDT(ByVal Data As Custom_Data_Grabber.Section, ByVal Length As Integer)

        Try

            If GotAllSDT = True Then Return
            Dim Section As Byte() = Data.Data
            Dim transport_id As Integer = ((Section(3)) * 256) + Section(4)
            Dim original_network_id As Long = ((Section(8)) * 256) + Section(9)
            Dim len1 As Integer = Length - 11 - 4
            Dim descriptors_loop_length As Integer
            Dim len2 As Integer
            Dim service_id As Long
            Dim EIT_schedule_flag As Integer
            Dim free_CA_mode As Integer
            Dim running_status As Integer
            Dim EIT_present_following_flag As Integer
            Dim pointer As Integer = 11
            Dim x As Integer = 0
            Do While (len1 > 0)
                service_id = (Section(pointer) * 256) + Section(pointer + 1)
                EIT_schedule_flag = (Section(pointer + 2) >> 1) And 1
                EIT_present_following_flag = Section(pointer + 2) And 1
                running_status = (Section(pointer + 3) >> 5) And 7
                free_CA_mode = (Section(pointer + 3) >> 4) And 1
                descriptors_loop_length = ((Section(pointer + 3) And &HF) * 256) + Section(pointer + 4)
                pointer += 5
                len1 -= 5
                len2 = descriptors_loop_length
                Do While (len2 > 0)
                    Dim indicator As Integer = Section(pointer)
                    x = 0
                    x = Section(pointer + 1) + 2
                    If (indicator = &H48) Then
                        Dim info As SDTInfo
                        info = DVB_GetServiceNew(Section, pointer)
                        info.SID = service_id
                        info.isFTA = free_CA_mode

                        If SDTInfo.ContainsKey(original_network_id & "-" & transport_id & "-" & service_id) = False Then
                            SDTInfo.Add(original_network_id & "-" & transport_id & "-" & service_id, info)
                            SDTCount += 1
                        End If
                        If AreAllBouquetsPopulated() And SDTCount = Channels.Count Then
                            If GotAllSDT = False Then
                                GotAllSDT = True
                                RaiseEvent OnMessage("Got All SDT Info, " & SDTInfo.Count & " Channels found", False)
                            End If
                        End If


                        'add sdt info
                    Else


                        Dim st As Integer = indicator
                        If (Not st = &H53 And Not st = &H64) Then
                            st = 1
                        End If
                    End If
                    len2 -= x
                    pointer += x
                    len1 -= x
                Loop
            Loop
        Catch ex As Exception
            RaiseEvent OnMessage("Error Parsing SDT", False)
            Return
        End Try



    End Sub

    Function DVB_GetServiceNew(ByVal b As Byte(), ByVal x As Integer) As SDTInfo
        Dim info As New SDTInfo
        Dim descriptor_tag As Integer
        Dim descriptor_length As Integer
        Dim service_provider_name_length As Integer
        Dim service_name_length As Integer
        Dim pointer As Integer = 0

        descriptor_tag = b(x + 0)
        descriptor_length = b(x + 1)
        If b(x + 2) = &H2 Then
            'Radio Channel
            info.isRadio = True
            info.isTV = False
            info.isHD = False
            info.is3D = False
        Else
            'TV Channel/3D/HD
            info.isRadio = False
            info.isTV = True
            info.isHD = False
            info.is3D = False
            If b(x + 2) = &H19 Or b(x + 2) = &H11 Then
                info.isHD = True
            End If
            If b(x + 2) >= &H80 And b(x + 2) <= &H84 Then
                info.is3D = True
            End If
        End If
        service_provider_name_length = b(x + 3)
        pointer = 4
        info.Provider = GetString(b, pointer + x, service_provider_name_length, False)
        pointer += service_provider_name_length
        service_name_length = b(x + pointer)
        pointer += 1
        info.ChannelName = GetString(b, pointer + x, service_name_length, False)
        pointer += service_name_length
        Select Case b(x + pointer)

            Case Is = &H49
                pointer += b(x + pointer + 1) + 2
                If (b(x + pointer) = &H5F) Then
                    pointer += b(x + pointer + 1) + 5
                    If ((b(x + pointer + 1) And &H1) = 1) Then
                        info.Category = b(x + pointer + 2)
                    Else
                        info.Category = b(x + pointer + 1)
                    End If
                End If

            Case Is = &HB2
                If ((b(x + pointer + 4) And &H1) = 1) Then
                    info.Category = b(x + pointer + 5)
                Else
                    info.Category = b(x + pointer + 4)
                End If
            Case Is = &H5F
                pointer += b(x + pointer + 1) + 5
                If ((b(x + pointer + 1) And &H1) = 1) Then
                    info.Category = b(x + pointer + 2)
                Else
                    info.Category = b(x + pointer + 1)
                End If
            Case Is = &H4B
                Dim offset As Integer = x + pointer
                Dim morechanlen As Integer = b(offset + 1)
                Dim tt As Integer
                offset += 2
                Dim Sid1, Nid1, Tid1 As Integer
                For tt = 0 To morechanlen Step 6
                    Tid1 = (b(offset + tt) * 256) Or b(offset + tt + 1)
                    Nid1 = (b(offset + tt + 2) * 256) Or b(offset + tt + 3)
                    Sid1 = (b(offset + tt + 4) * 256) Or b(offset + tt + 5)
                    If SDTInfo.ContainsKey(Nid1 & "-" & Tid1 & "-" & Sid1) = False And info.ChannelName <> "" Then
                        Dim SDT As New SDTInfo
                        SDT.ChannelName = info.ChannelName
                        SDT.Category = 0
                        SDT.SID = Sid1
                        SDT.isFTA = info.isFTA
                        SDT.isHD = info.isHD
                        SDT.isTV = info.isTV
                        SDT.isRadio = info.isRadio
                        SDT.Provider = info.Provider
                        SDTInfo.Add(Nid1 & "-" & Tid1 & "-" & Sid1, SDT)
                        SDTCount += 1
                    End If
                Next
        End Select
        Return info

    End Function

    Function GetString(ByVal byteData As Byte(), ByVal offset As Integer, ByVal length As Integer, ByVal replace As Boolean) As String
        If length = 0 Then
            Return (String.Empty)
        End If

        Dim isoTable As String = Nothing
        Dim startByte As Integer = 0

        If byteData(offset) >= &H20 Then
            isoTable = "iso-8859-1"
        Else
            Select Case byteData(offset)
                Case &H1, &H2, &H3, &H4, &H5, &H6, _
                 &H7, &H8, &H9, &HA, &HB
                    isoTable = "iso-8859-" & (byteData(offset) + 4).ToString()
                    startByte = 1
                    Exit Select
                Case &H10
                    If byteData(offset + 1) = &H0 Then
                        If byteData(offset + 2) <> &H0 AndAlso byteData(offset + 2) <> &HC Then
                            isoTable = "iso-8859-" & CInt(byteData(offset + 2)).ToString()
                            startByte = 3
                            Exit Select
                        Else
                            RaiseEvent OnMessage("Invalid DVB text string: byte 3 is not a valid value", replace)
                        End If
                    Else
                        RaiseEvent OnMessage("Invalid DVB text string: byte 2 is not a valid value", replace)
                    End If
                Case &H1F
                    If byteData(offset + 1) = &H1 OrElse byteData(offset + 1) = &H2 Then
                        '  Return (FreeSatDictionaryEntry.DecodeData(Utils.GetBytes(byteData, offset, length + 1)))
                    Else
                        RaiseEvent OnMessage("Invalid DVB text string: Custom text specifier is not recognized", replace)
                    End If
                Case Else
                    Return ("Invalid DVB text string: byte 1 is not a valid value")
            End Select
        End If

        Dim editedBytes As Byte() = New Byte(length - 1) {}
        Dim editedLength As Integer = 0

        For index As Integer = startByte To length - 1
            If byteData(offset + index) > &H1F Then
                If byteData(offset + index) < &H80 OrElse byteData(offset + index) > &H9F Then
                    editedBytes(editedLength) = byteData(offset + index)
                    editedLength += 1
                End If
            Else
                If replace Then
                    editedBytes(editedLength) = &H20
                    editedLength += 1
                End If
            End If
        Next

        If editedLength = 0 Then
            Return (String.Empty)
        End If

        Try
            Dim sourceEncoding As Encoding = Encoding.GetEncoding(isoTable)
            If sourceEncoding Is Nothing Then
                sourceEncoding = Encoding.GetEncoding("iso-8859-1")
            End If

            Return (sourceEncoding.GetString(editedBytes, 0, editedLength))
        Catch e As ArgumentException
            RaiseEvent OnMessage("** ERROR DECODING STRING - SEE COLLECTION LOG **", replace)
        End Try
    End Function

    Private Sub ParseChannels(ByVal Data As Custom_Data_Grabber.Section, ByVal Length As Integer)
        'If all bouquets are already fully populated, return
        Try

            If (Data.table_id) <> &H4A Then
                If AreAllBouquetsPopulated() Then
                    If Data.table_id = &H42 Or Data.table_id = &H46 Then
                        If GotAllSDT Then
                            Return
                        Else
                            ParseSDT(Data, Length)
                        End If
                    End If
                    Return
                Else
                    Return
                End If
            End If

            If AreAllBouquetsPopulated() Then
                Return
            End If

            Dim buffer() As Byte = Data.Data

            Dim bouquetId As Integer = (buffer(3) * 256) + buffer(4)
            Dim bouquetDescriptorLength As Integer = ((buffer(8) And &HF) * 256) + buffer(9)

            Dim skyBouquet As SkyBouquet = GetBouquet(bouquetId)
            If (skyBouquet.isPopulated) Then
                Return
            End If
            '	//	If the bouquet is not initialized, this is the first time we have seen it
            If (skyBouquet.isInitialized = False) Then
                skyBouquet.firstReceivedSectionNumber = Data.section_number
                skyBouquet.isInitialized = True
            Else
                If (Data.section_number = skyBouquet.firstReceivedSectionNumber) Then
                    skyBouquet.isPopulated = True
                    NotifyBouquetPopulated()
                    Return
                End If
            End If

            Dim body As Integer = 10 + bouquetDescriptorLength
            Dim bouquetPayloadLength As Integer = ((buffer(body + 0) And &HF) * 256) + buffer(body + 1)
            Dim endOfPacket As Integer = body + bouquetPayloadLength + 2
            Dim currentTransportGroup As Integer = body + 2

            Do While (currentTransportGroup < endOfPacket)

                Dim transportId As Integer = (buffer(currentTransportGroup + 0) * 256) + buffer(currentTransportGroup + 1)
                Dim networkId = (buffer(currentTransportGroup + 2) * 256) + buffer(currentTransportGroup + 3)
                Dim transportGroupLength As Integer = ((buffer(currentTransportGroup + 4) And &HF) * 256) + buffer(currentTransportGroup + 5)
                Dim currentTransportDescriptor As Integer = currentTransportGroup + 6
                Dim endOfTransportGroupDescriptors As Integer = currentTransportDescriptor + transportGroupLength

                Do While (currentTransportDescriptor < endOfTransportGroupDescriptors)

                    Dim descriptorType As Byte = buffer(currentTransportDescriptor)

                    Dim descriptorLength As Integer = buffer(currentTransportDescriptor + 1)
                    Dim currentServiceDescriptor As Integer = currentTransportDescriptor + 2
                    Dim endOfServiceDescriptors As Integer = currentServiceDescriptor + descriptorLength - 2

                    If (descriptorType = &HB1) Then
                        Dim RegionID As Integer = buffer(currentTransportDescriptor + 3)
                        Do While (currentServiceDescriptor < endOfServiceDescriptors)
                            Dim serviceId As Integer = (buffer(currentServiceDescriptor + 2) * 256) + buffer(currentServiceDescriptor + 3)
                            Dim channelId As Integer = (buffer(currentServiceDescriptor + 5) * 256) + buffer(currentServiceDescriptor + 6)
                            Dim skyChannelNumber As Integer = (buffer(currentServiceDescriptor + 7) * 256) + buffer(currentServiceDescriptor + 8)
                            Dim skyChannel As Sky_Channel = GetChannel(channelId)
                            Dim SkyLCN As New LCNHolder(bouquetId, RegionID, skyChannelNumber)

                            If (skyChannel.isPopulated = False) Then
                                skyChannel.NID = networkId
                                skyChannel.TID = transportId
                                skyChannel.SID = serviceId
                                skyChannel.ChannelID = channelId

                                If skyChannel.AddSkyLCN(SkyLCN) Then
                                    skyChannel.isPopulated = True
                                End If
                                UpdateChannel(skyChannel.ChannelID, skyChannel)
                            Else
                                skyChannel.AddSkyLCN(SkyLCN)
                                UpdateChannel(skyChannel.ChannelID, skyChannel)
                            End If
                            currentServiceDescriptor += 9
                        Loop
                    End If
                    currentTransportDescriptor += descriptorLength + 2
                Loop
                currentTransportGroup += transportGroupLength + 6
            Loop
        Catch ex As Exception
            RaiseEvent OnMessage("Error Parsing BAT", False)
            Return
        End Try
    End Sub

    Function GetBouquet(ByVal bouquetId As Integer) As SkyBouquet
        Dim returnBouquet As SkyBouquet
        If (Bouquets.ContainsKey(bouquetId)) Then
            returnBouquet = Bouquets(bouquetId)
        Else
            Bouquets.Add(bouquetId, New SkyBouquet)
            returnBouquet = Bouquets(bouquetId)
        End If
        Return returnBouquet
    End Function

    Function GetChannel(ByVal ChannelID As Integer) As Sky_Channel
        Dim returnChannel As Sky_Channel
        If (Channels.ContainsKey(ChannelID)) Then
            returnChannel = Channels(ChannelID)
        Else
            Channels.Add(ChannelID, New Sky_Channel)
            returnChannel = Channels(ChannelID)
            returnChannel.ChannelID = ChannelID
        End If
        Return returnChannel
    End Function

    Function GetChannelbySID(ByVal SID As String) As SDTInfo
        If (SDTInfo.ContainsKey(SID)) Then
            Return SDTInfo(SID)
        End If
        Return Nothing
    End Function

    Function AreAllBouquetsPopulated() As Boolean
        Return (Bouquets.Count > 0) And (Bouquets.Count = numberBouquetsPopulated)
    End Function

    Function IsEverythingGrabbed() As Boolean
        If GrabEPG Then
            If (AreAllBouquetsPopulated() And GotAllSDT) Then
                If AreAllSummariesPopulated() And AreAllTitlesPopulated() And GotAllTID = True Then
                    RaiseEvent OnMessage("Everything grabbed:- Titles(" & titlesDecoded & ") : Summaries(" & summariesDecoded & ")", False)
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            If (Bouquets.Count = numberBouquetsPopulated And GotAllSDT) Then
                If GotAllTID = True Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function

    Sub NotifyBouquetPopulated()
        numberBouquetsPopulated += 1
        If (Bouquets.Count = numberBouquetsPopulated) Then
            RaiseEvent OnMessage("Bouquet scan complete.  ", False)
            RaiseEvent OnMessage("Found " & Channels.Count & " channels in " & Bouquets.Count & " bouquets, searching SDT Information", False)
        End If
    End Sub
    Private Sub NotifySkyChannelPopulated(ByVal TID As Integer, ByVal NID As Integer, ByVal SID As Integer)
        If GotAllSDT Then Return
        If numberSDTPopulated = "" Then
            numberSDTPopulated = NID.ToString & "-" & TID.ToString & "-" & SID.ToString
        Else
            If NID.ToString & "-" & TID.ToString & "-" & SID.ToString = numberSDTPopulated Then
                GotAllSDT = True
                RaiseEvent OnMessage("Got all SDT Info, count: " & SDTInfo.Count, False)
            End If
        End If
    End Sub
    Private Sub NotifyTIDPopulated(ByVal TID As Integer)
        If GotAllTID Then Return
        If numberTIDPopulated = 0 Then
            numberTIDPopulated = TID
        Else
            If TID = numberTIDPopulated Then
                GotAllTID = True
                RaiseEvent OnMessage("Got all Network Information", False)
            End If
        End If
    End Sub
    Function DoesTidCarryEpgSummaryData(ByVal TableID As Integer) As Boolean
        If TableID = &HA8 Or TableID = &HA9 Or TableID = &HAA Or TableID = &HAB Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub OnSummarySectionReceived(ByVal pid As Integer, ByVal section As Custom_Data_Grabber.Section)
        Try
            '	If the summary data carousel is complete for this pid, we can discard the data as we already have it
            If IsSummaryDataCarouselOnPidComplete(pid) Then
                Return
            End If

            '	Validate table id
            If Not DoesTidCarryEpgSummaryData(section.table_id) Then
                Return
            End If

            Dim buffer As Byte() = section.Data

            '	Total length of summary data (2 less for this length field)
            Dim totalLength As Integer = (((buffer(1) And &HF) * 256) + buffer(2)) - 2

            '	If this section is a valid length (14 absolute minimum with 1 blank summary)
            If (section.section_length < 14) Then
                Return
            End If
            '	Get the channel id that this section's summary data relates to
            Dim channelId As Long = (buffer(3) * 256) + buffer(4)
            Dim mjdStartDate As Long = (buffer(8) * 256) + buffer(9)

            '	Check channel id and start date are valid
            If (channelId = 0 Or mjdStartDate = 0) Then
                Return
            End If

            '	Always starts at 10th byte
            Dim currentSummaryItem As Integer = 10

            Dim iterationCounter As Integer = 0


            '	Loop while we have more summary data
            Do While (currentSummaryItem < totalLength)
                If (iterationCounter > 512) Then
                    Return
                End If

                iterationCounter += 1

                '	Extract event id, header type and body length
                Dim eventId As Integer = (buffer(currentSummaryItem + 0) * 256) Or buffer(currentSummaryItem + 1)
                Dim headerType As Byte = (buffer(currentSummaryItem + 2) And &HF0) >> 4
                Dim bodyLength As Integer = ((buffer(currentSummaryItem + 2) And &HF) * 256) Or buffer(currentSummaryItem + 3)

                '	Build the carousel lookup id
                Dim carouselLookupId As String = channelId.ToString & ":" & eventId.ToString

                '	Notify the parser that a title has been received
                OnSummaryReceived(pid, carouselLookupId)

                '	If the summary carousel for this pid is now complete, we can return
                If (IsSummaryDataCarouselOnPidComplete(pid)) Then Return


                '	Get the epg event we are to populate from the manager
                Dim epgEvent As SkyEvent = GetEpgEvent(channelId, eventId)

                '	Check we have the event reference
                If epgEvent Is Nothing Then
                    Return
                End If

                Dim headerLength As Integer

                '	If this is an extended header (&HF) (7 bytes long)
                If (headerType = &HF) Then
                    headerLength = 7
                    '	Else if normal header (&HB) (4 bytes long)
                ElseIf (headerType = &HB) Then
                    headerLength = 4
                    '	Else other unknown header (not worked them out yet, at least 4 more)
                    '	Think these are only used for box office and adult channels so not really important
                Else
                    '	Cannot parse the rest of this packet as we dont know the header lengths/format etc
                    Return
                End If

                '	If body length is less than 3, there is no summary data for this event, move to next
                If (bodyLength < 3) Then

                    currentSummaryItem += (headerLength + bodyLength)

                End If


                '	Move to the body of the summary
                Dim currentSummaryItemBody As Integer = currentSummaryItem + headerLength

                '	Extract summary signature and huffman buffer length
                Dim summaryDescriptor As Integer = buffer(currentSummaryItemBody + 0)
                Dim encodedBufferLength As Integer = buffer(currentSummaryItemBody + 1)

                '	If normal summary item (&HB9)
                If (summaryDescriptor = &HB9) Then

                    If (epgEvent.Summary = "") Then

                        '	Decode the summary
                        'epgEvent.summary = skyManager.DecodeHuffmanData(&buffer(currentSummaryItemBody + 2), encodedBufferLength)
                        Dim HuffBuff(&H1000) As Byte
                        If (currentSummaryItemBody + 2 + encodedBufferLength) > buffer.Length Then
                            Return
                        End If
                        Array.Copy(buffer, currentSummaryItemBody + 2, HuffBuff, 0, encodedBufferLength)
                        epgEvent.Summary = NewHuffman(HuffBuff, encodedBufferLength)

                        '	If failed to decode

                        '	Notify the manager (for statistics)
                        OnSummaryDecoded()
                        UpdateEPGEvent(channelId, epgEvent.EventID, epgEvent)

                        '	Else if (&HBB) - Unknown data item (special box office or adult?)
                        '	Seems very rare (1 in every 2000 or so), so not important really
                    End If


                ElseIf (summaryDescriptor = &HBB) Then

                    '	Else other unknown data item, there are a few others that are unknown
                Else

                    Return
                    'skyManager.LogError("CSkyEpgSummaryDecoder::OnSummarySectionReceived() - Error, unrecognised summary descriptor")
                End If

                '	Is there any footer information?
                Dim footerLength As Integer = bodyLength - encodedBufferLength - 2

                If (footerLength >= 4) Then

                    Dim footerPointer As Integer = currentSummaryItemBody + 2 + encodedBufferLength

                    '	Get the descriptor
                    Dim footerDescriptor As Integer = buffer(footerPointer + 0)

                    '	If series id information (&HC1)
                    If (footerDescriptor = &HC1) Then
                        epgEvent.SeriesID = (buffer(footerPointer + 2) * 256) + (buffer(footerPointer + 3))
                    End If
                End If

                '	Move to next summary item
                currentSummaryItem += (bodyLength + headerLength)
            Loop

            '	Check the packet was parsed correctly - seem to get a few of these.  
            '	Seems to be some extra information tagged onto the end of some summary packets (1 in every 2000 or so)
            '	Not worked this out - possibly box office information
            If (currentSummaryItem <> (totalLength + 1)) Then
                'skyManager.LogError("CSkyEpgSummaryDecoder::OnSummarySectionReceived() - Warning, summary packet was not parsed correctly - pointer not in expected place")

                Return
            End If
        Catch err As Exception
            RaiseEvent OnMessage("Error decoding Summary, " & err.Message, False)
            Return
        End Try

    End Sub

End Class

Public Class LCNHolder
    Dim _BID As Integer
    Dim _RID As Integer
    Dim _SkyNum As Integer
    Public Sub New(ByVal BID As Integer, ByVal RID As Integer, ByVal SkyLCN As Integer)
        _BID = BID
        _RID = RID
        _SkyNum = SkyLCN
    End Sub
    Public Property RID As Integer
        Get
            Return _RID
        End Get
        Set(ByVal value As Integer)
            _RID = value
        End Set
    End Property
    Public Property BID As Integer
        Get
            Return _BID
        End Get
        Set(ByVal value As Integer)
            _BID = value
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

    Dim _ChannelId As Integer
    Dim _NID As Integer
    Dim _TID As Integer
    Dim _SID As Integer
    Dim _Channel_Name As String
    Dim _isPopulated As Boolean
    Dim _epgChannelNumber As New Dictionary(Of String, LCNHolder)
    Dim _encrypted As Boolean
    Dim _Name As String
    Dim _NewChannelRequired As Boolean
    Dim _HasChanged As Boolean


    Public ReadOnly Property LCNS
        Get
            Return _epgChannelNumber.Values
        End Get
    End Property
    Public ReadOnly Property LCNCount
        Get
            Return _epgChannelNumber.Count
        End Get
    End Property
    Public Function GetLCN(ByVal BouquetID As Integer, ByVal RegionId As Integer) As LCNHolder

        If _epgChannelNumber.ContainsKey(BouquetID.ToString & "-" & RegionId.ToString) Then
            Return _epgChannelNumber(BouquetID.ToString & "-" & RegionId.ToString)
        Else
            Return Nothing
        End If

    End Function
    Public Function ContainsLCN(ByVal BouquetID As Integer, ByVal RegionId As Integer) As Boolean
        Return _epgChannelNumber.ContainsKey(BouquetID.ToString & "-" & RegionId.ToString)
    End Function
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
    Public Property AddChannelRequired As Boolean
        Get
            Return _NewChannelRequired
        End Get
        Set(ByVal value As Boolean)
            _NewChannelRequired = value
        End Set
    End Property
    Public Function AddSkyLCN(ByVal LCNHold As LCNHolder) As Boolean
        If Not _epgChannelNumber.ContainsKey(LCNHold.BID & "-" & LCNHold.RID) Then
            _epgChannelNumber.Add(LCNHold.BID & "-" & LCNHold.RID, LCNHold)
            Return False
        Else
            Return True
        End If

    End Function
    Public Property ChannelID As Integer
        Get
            Return _ChannelId
        End Get
        Set(ByVal value As Integer)
            _ChannelId = value
        End Set
    End Property
    Public Property NID As Integer
        Get
            Return _NID
        End Get
        Set(ByVal value As Integer)
            _NID = value
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
    Public Property SID As Integer
        Get
            Return _SID
        End Get
        Set(ByVal value As Integer)
            _SID = value
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
    'EventID

    Public Events As New Dictionary(Of Integer, SkyEvent)

End Class

Public Class SkyEvent

    Dim _EventID As Integer
    Dim _StartTime As Integer
    Dim _duration As Integer
    Dim _ChannelID As Integer
    Dim _Title As String
    Dim _Summary As String
    Dim _Category As String
    Dim _ParentalCategory As String
    Dim _SeriesID As Integer
    Dim _mjdStart As Long
    Dim _seriesTermination As Integer
    Dim _AD As Boolean
    Dim _CP As Boolean
    Dim _HD As Boolean
    Dim _WS As Boolean
    Dim _Subs As Boolean
    Dim _SoundType As Integer
    Dim Flags As String
    Public Sub SetFlags(ByVal IntegerNumber As Integer)
        _AD = IntegerNumber And &H1
        _CP = IntegerNumber And &H2
        _HD = IntegerNumber And &H4
        _WS = IntegerNumber And &H8
        _Subs = IntegerNumber And &H10
        _SoundType = IntegerNumber >> 6
    End Sub
    Public Sub SetCategory(ByVal Category As Integer)

        Select Case Category And &HF
            Case 5
                _ParentalCategory = "18"
            Case 4
                _ParentalCategory = "15"
            Case 3
                _ParentalCategory = "12"
            Case 2
                _ParentalCategory = "PG"
            Case 1
                _ParentalCategory = "U"
            Case Else
                _ParentalCategory = ""

        End Select

    End Sub
    Public ReadOnly Property ParentalCategory As String
        Get
            Return _ParentalCategory
        End Get
    End Property


    Public ReadOnly Property DescriptionFlag As String
        Get
            Flags = ""
            If _AD Then
                Flags &= "[AD]"
            End If
            If _CP Then
                If Flags <> "" Then Flags &= ","
                Flags &= "[CP]"
            End If
            If _HD Then
                If Flags <> "" Then Flags &= ","
                Flags &= "[HD]"
            End If
            If _WS Then
                If Flags <> "" Then Flags &= ","
                Flags &= "[W]"
            End If
            If _Subs Then
                If Flags <> "" Then Flags &= ","
                Flags &= "[SUB]"
            End If

            Select Case _SoundType
                Case 1
                    If Flags <> "" Then Flags &= ","
                    Flags &= "[S]"
                Case 2
                    If Flags <> "" Then Flags &= ","
                    Flags &= "[DS]"
                Case 3
                    If Flags <> "" Then Flags &= ","
                    Flags &= "[DD]"
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

    Public Sub New()
        _EventID = -1
        _StartTime = -1
        _duration = -1
        _ChannelID = -1
        _Title = ""
        _Summary = ""
        _Category = ""
        _ParentalCategory = ""
        _SeriesID = Nothing
        _mjdStart = 0
        _seriesTermination = Nothing
        _AD = False
        _CP = False
        _HD = False
        _WS = False
        _Subs = False
        _SoundType = -1
        Flags = ""
    End Sub
End Class

Public Class SkyBouquet

    Dim _firstReceivedSectionNumber As Byte
    Dim _isInitialized As Boolean
    Dim _isPopulated As Boolean

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
    Public Sub New()
        _isInitialized = False
        _isPopulated = False
    End Sub

End Class

Public Class HuffHolder

    Dim _buff() As Byte
    Dim _Length As Integer
    Dim _NextID As String
    Public Property NextID() As String
        Get
            Return _NextID
        End Get
        Set(ByVal value As String)
            _NextID = value

        End Set
    End Property
    Public Property Buff() As Byte()
        Get
            Return _buff
        End Get
        Set(ByVal value As Byte())
            _buff = value
        End Set
    End Property
    Public Property Length() As Integer
        Get
            Return _Length
        End Get
        Set(ByVal value As Integer)
            _Length = value
        End Set
    End Property
End Class

Public Class HuffmanTreeNode
    Public Sub New()
    End Sub
    Private Shadows Function Equals() As Boolean
        Return False
    End Function
    Private Shadows Function ReferenceEquals() As Boolean
        Return False
    End Function

    Public Value As String 'the character found in the file.
    'amount of times the character was found in the file.
    Public Parent As HuffmanTreeNode 'the parent node.
    Public P1 As HuffmanTreeNode 'the left leaf.
    Public P0 As HuffmanTreeNode 'the right leaf.
    Public Function Clear() As Boolean
        If P1 Is Nothing Then
            Return True
        Else
            P1 = Nothing
            If P0 Is Nothing Then
            Else
                P0 = Nothing
            End If
        End If
        Return True
    End Function
    Public ReadOnly Property Path() As String  'the binary path to the node.
        Get
            Static strPath As String
            If strPath Is Nothing Then
                If Not (Me.Parent Is Nothing) Then
                    If (Me.Parent.P0 Is Me) Then strPath = "0"
                    If (Me.Parent.P1 Is Me) Then strPath = "1"
                    strPath = Parent.Path & strPath
                End If
            End If
            Return strPath
        End Get
    End Property

End Class

Public Class SDTInfo
    Dim _sid As Integer
    Dim _ChannelName As String
    Dim _Cat As Byte
    Dim _Provider As String
    Dim _isFTA As Boolean
    Dim _isRadio As Boolean
    Dim _isTV As Boolean
    Dim _isHD As Boolean
    Dim _is3d As Boolean



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
            _Cat = value
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
            Return _is3d
        End Get
        Set(ByVal value As Boolean)
            _isHD = value
        End Set
    End Property
End Class

Public Class NITSatDescriptor

    Dim _TransportID As Integer
    Dim _Frequency As Single
    Dim _OrbitalPosition As Integer
    Dim _WestEastFlag As Integer
    Dim _Polarisation As Integer
    Dim _Modulation As Integer
    Dim _Symbolrate As Integer
    Dim _FECInner As Integer
    Dim _RollOff As Integer
    Dim _isS2 As Integer
    Dim _NetworkName As String

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
            Return _Frequency
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
