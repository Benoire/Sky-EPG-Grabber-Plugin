
Imports Microsoft.VisualBasic.CompilerServices
Imports SetupTv
Imports TvDatabase
Imports TvControl
Imports TvLibrary.Interfaces
Imports TvLibrary.Log


Public Class Setup
    Inherits SectionSettings
    Dim WithEvents Grabber As SkyGrabber
    Dim Settings As New Settings

    Private WithEvents SkyNZ As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents Region_Group_Tab As System.Windows.Forms.GroupBox
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents SkyNZ_Region As System.Windows.Forms.ComboBox
    Private WithEvents SkyNZ_Channel_Groups As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CatText20 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte20 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CatText19 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte19 As System.Windows.Forms.TextBox
    Friend WithEvents CatText18 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte18 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CatText17 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte17 As System.Windows.Forms.TextBox
    Friend WithEvents CatText16 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte16 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CatText15 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte15 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CatText14 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte14 As System.Windows.Forms.TextBox
    Friend WithEvents CatText13 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte13 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CatText12 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte12 As System.Windows.Forms.TextBox
    Friend WithEvents CatText11 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte11 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CatText9 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte9 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CatText7 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte7 As System.Windows.Forms.TextBox
    Friend WithEvents CatText10 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte10 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CatText6 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte6 As System.Windows.Forms.TextBox
    Friend WithEvents CatText5 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte5 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CatText4 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte4 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CatText8 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte8 As System.Windows.Forms.TextBox
    Friend WithEvents CatText3 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CatText2 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte2 As System.Windows.Forms.TextBox
    Friend WithEvents CatText1 As System.Windows.Forms.TextBox
    Friend WithEvents CatByte1 As System.Windows.Forms.TextBox
    Friend WithEvents Save_Changes As System.Windows.Forms.Button
    Public Delegate Sub AddLog1(ByVal Value As String, ByVal UpdateLast As Boolean)
    Public Log1 As New AddLog1(AddressOf AddLog)

    Public Delegate Sub SetBool1(ByVal Value As Boolean)
    Public Bool1 As New SetBool1(AddressOf SetBool)

    Public Delegate Sub SetBool2(ByVal Value As Boolean)
    Public Bool2 As New SetBool2(AddressOf SetBool22)

    Public Delegate Sub SetBool3(ByVal Value As Boolean)
    Public Bool3 As New SetBool3(AddressOf SetBool33)

    Public Delegate Sub SetBool4(ByVal Value As Boolean)
    Public Bool4 As New SetBool4(AddressOf SetBool44)

    Public Delegate Sub SetBool5(ByVal Value As Boolean)
    Public Bool5 As New SetBool5(AddressOf SetBool55)
    Public Delegate Sub SetBool6(ByVal Value As Boolean)
    Public Bool6 As New SetBool6(AddressOf SetBool66)
    Friend WithEvents Schedule_Tab As System.Windows.Forms.TabPage
    Friend WithEvents chk_Sun As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Sat As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Fri As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Thu As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Wed As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Tue As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Mon As System.Windows.Forms.CheckBox
    Friend WithEvents Schedule_Hours_Label As System.Windows.Forms.Label
    Friend WithEvents chk_onthesedays As System.Windows.Forms.CheckBox
    Friend WithEvents chk_every_hours As System.Windows.Forms.CheckBox
    Friend WithEvents chk_schedule_enabled As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Schedule_scroll_time As System.Windows.Forms.DateTimePicker
    Friend WithEvents schedule_hours As System.Windows.Forms.NumericUpDown
    Friend WithEvents Cards_Mapping_Tab As System.Windows.Forms.TabPage
    Friend WithEvents Cards_For_Grabbing As System.Windows.Forms.CheckedListBox
    Private WithEvents Card_Map_Box As MediaPortal.UserInterface.Controls.MPGroupBox
    Private WithEvents Sky_NZ_Channel_Grabber_Settings As MediaPortal.UserInterface.Controls.MPGroupBox
    Private WithEvents Diseqc_Label As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents MP_Diseqc As MediaPortal.UserInterface.Controls.MPComboBox
    Private WithEvents Modulation_Label As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents MP_Modulation As MediaPortal.UserInterface.Controls.MPComboBox
    Private WithEvents Polarisation_Label As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents MP_Polarisation As MediaPortal.UserInterface.Controls.MPComboBox
    Private WithEvents Serviceid_label As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents txt_serviceid As System.Windows.Forms.TextBox
    Private WithEvents TransportID_Label As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents txt_transportid As System.Windows.Forms.TextBox
    Private WithEvents txt_frequency As System.Windows.Forms.TextBox
    Private WithEvents Fequency_Label As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents txt_symbol_rate As System.Windows.Forms.TextBox
    Private WithEvents Symbol_rate_Label As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents Frequency_Unit_Label As MediaPortal.UserInterface.Controls.MPLabel
    Friend WithEvents Schedule_panel As System.Windows.Forms.Panel
    Friend WithEvents Change_Log_Tab As System.Windows.Forms.TabPage
    Friend WithEvents txtbox_Change_log As System.Windows.Forms.TextBox
    Friend WithEvents Settings_Tab As System.Windows.Forms.TabPage
    Friend WithEvents Settings_Panel As System.Windows.Forms.Panel
    Private WithEvents chk_ignorescrambled As System.Windows.Forms.CheckBox
    Private WithEvents chk_modnotsetSD As System.Windows.Forms.CheckBox
    Private WithEvents chk_extrainfo As System.Windows.Forms.CheckBox
    Private WithEvents Expired_Channels_label As System.Windows.Forms.Label
    Private WithEvents chk_updateEPG As System.Windows.Forms.CheckBox
    Private WithEvents chk_DeleteOld As System.Windows.Forms.RadioButton
    Private WithEvents chk_replaceSDwithHD As System.Windows.Forms.CheckBox
    Private WithEvents chk_MoveOld As System.Windows.Forms.RadioButton
    Private WithEvents txt_Move_Old_Group As System.Windows.Forms.TextBox
    Private WithEvents chk_AutoUpdate As System.Windows.Forms.CheckBox
    Private WithEvents chk_SkyCategories As System.Windows.Forms.CheckBox
    Private WithEvents chk_SkyNumbers As System.Windows.Forms.CheckBox
    Private WithEvents chk_SkyRegions As System.Windows.Forms.CheckBox
    Private WithEvents General_Tab As System.Windows.Forms.TabPage
    Friend WithEvents Grabtime_time_label As System.Windows.Forms.Label
    Friend WithEvents Grabtime_label As System.Windows.Forms.Label
    Friend WithEvents Grabtime_grabtime As System.Windows.Forms.NumericUpDown
    Private WithEvents Output_Window As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Grab_Now As System.Windows.Forms.Button
    Private WithEvents chk_modnotsetHD As System.Windows.Forms.CheckBox
    Dim regions As New Dictionary(Of Integer, Region)

    Public Sub New()
        ' This call is required by the designer.        
        Grabber = New SkyGrabber
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        LoadSetting()
        '    SaveSettings()
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Setup))
        Me.SkyNZ = New System.Windows.Forms.TabControl()
        Me.General_Tab = New System.Windows.Forms.TabPage()
        Me.Grabtime_time_label = New System.Windows.Forms.Label()
        Me.Grabtime_label = New System.Windows.Forms.Label()
        Me.Grabtime_grabtime = New System.Windows.Forms.NumericUpDown()
        Me.Output_Window = New System.Windows.Forms.ListView()
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Grab_Now = New System.Windows.Forms.Button()
        Me.Settings_Tab = New System.Windows.Forms.TabPage()
        Me.Settings_Panel = New System.Windows.Forms.Panel()
        Me.chk_modnotsetHD = New System.Windows.Forms.CheckBox()
        Me.chk_ignorescrambled = New System.Windows.Forms.CheckBox()
        Me.chk_modnotsetSD = New System.Windows.Forms.CheckBox()
        Me.chk_extrainfo = New System.Windows.Forms.CheckBox()
        Me.Expired_Channels_label = New System.Windows.Forms.Label()
        Me.chk_updateEPG = New System.Windows.Forms.CheckBox()
        Me.chk_DeleteOld = New System.Windows.Forms.RadioButton()
        Me.chk_replaceSDwithHD = New System.Windows.Forms.CheckBox()
        Me.chk_MoveOld = New System.Windows.Forms.RadioButton()
        Me.txt_Move_Old_Group = New System.Windows.Forms.TextBox()
        Me.chk_AutoUpdate = New System.Windows.Forms.CheckBox()
        Me.chk_SkyCategories = New System.Windows.Forms.CheckBox()
        Me.chk_SkyNumbers = New System.Windows.Forms.CheckBox()
        Me.chk_SkyRegions = New System.Windows.Forms.CheckBox()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.Region_Group_Tab = New System.Windows.Forms.GroupBox()
        Me.SkyNZ_Channel_Groups = New System.Windows.Forms.GroupBox()
        Me.Save_Changes = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CatText20 = New System.Windows.Forms.TextBox()
        Me.CatByte20 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CatText19 = New System.Windows.Forms.TextBox()
        Me.CatByte19 = New System.Windows.Forms.TextBox()
        Me.CatText18 = New System.Windows.Forms.TextBox()
        Me.CatByte18 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CatText17 = New System.Windows.Forms.TextBox()
        Me.CatByte17 = New System.Windows.Forms.TextBox()
        Me.CatText16 = New System.Windows.Forms.TextBox()
        Me.CatByte16 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.CatText15 = New System.Windows.Forms.TextBox()
        Me.CatByte15 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.CatText14 = New System.Windows.Forms.TextBox()
        Me.CatByte14 = New System.Windows.Forms.TextBox()
        Me.CatText13 = New System.Windows.Forms.TextBox()
        Me.CatByte13 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CatText12 = New System.Windows.Forms.TextBox()
        Me.CatByte12 = New System.Windows.Forms.TextBox()
        Me.CatText11 = New System.Windows.Forms.TextBox()
        Me.CatByte11 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CatText9 = New System.Windows.Forms.TextBox()
        Me.CatByte9 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CatText7 = New System.Windows.Forms.TextBox()
        Me.CatByte7 = New System.Windows.Forms.TextBox()
        Me.CatText10 = New System.Windows.Forms.TextBox()
        Me.CatByte10 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CatText6 = New System.Windows.Forms.TextBox()
        Me.CatByte6 = New System.Windows.Forms.TextBox()
        Me.CatText5 = New System.Windows.Forms.TextBox()
        Me.CatByte5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CatText4 = New System.Windows.Forms.TextBox()
        Me.CatByte4 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CatText8 = New System.Windows.Forms.TextBox()
        Me.CatByte8 = New System.Windows.Forms.TextBox()
        Me.CatText3 = New System.Windows.Forms.TextBox()
        Me.CatByte3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CatText2 = New System.Windows.Forms.TextBox()
        Me.CatByte2 = New System.Windows.Forms.TextBox()
        Me.CatText1 = New System.Windows.Forms.TextBox()
        Me.CatByte1 = New System.Windows.Forms.TextBox()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.SkyNZ_Region = New System.Windows.Forms.ComboBox()
        Me.Cards_Mapping_Tab = New System.Windows.Forms.TabPage()
        Me.Card_Map_Box = New MediaPortal.UserInterface.Controls.MPGroupBox()
        Me.Cards_For_Grabbing = New System.Windows.Forms.CheckedListBox()
        Me.Sky_NZ_Channel_Grabber_Settings = New MediaPortal.UserInterface.Controls.MPGroupBox()
        Me.Diseqc_Label = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.MP_Diseqc = New MediaPortal.UserInterface.Controls.MPComboBox()
        Me.Modulation_Label = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.MP_Modulation = New MediaPortal.UserInterface.Controls.MPComboBox()
        Me.Polarisation_Label = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.MP_Polarisation = New MediaPortal.UserInterface.Controls.MPComboBox()
        Me.Serviceid_label = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.txt_serviceid = New System.Windows.Forms.TextBox()
        Me.TransportID_Label = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.txt_transportid = New System.Windows.Forms.TextBox()
        Me.txt_frequency = New System.Windows.Forms.TextBox()
        Me.Fequency_Label = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.txt_symbol_rate = New System.Windows.Forms.TextBox()
        Me.Symbol_rate_Label = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.Frequency_Unit_Label = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.Schedule_Tab = New System.Windows.Forms.TabPage()
        Me.Schedule_panel = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.schedule_hours = New System.Windows.Forms.NumericUpDown()
        Me.Schedule_scroll_time = New System.Windows.Forms.DateTimePicker()
        Me.chk_every_hours = New System.Windows.Forms.CheckBox()
        Me.chk_onthesedays = New System.Windows.Forms.CheckBox()
        Me.chk_Sun = New System.Windows.Forms.CheckBox()
        Me.chk_Sat = New System.Windows.Forms.CheckBox()
        Me.Schedule_Hours_Label = New System.Windows.Forms.Label()
        Me.chk_Fri = New System.Windows.Forms.CheckBox()
        Me.chk_Mon = New System.Windows.Forms.CheckBox()
        Me.chk_Thu = New System.Windows.Forms.CheckBox()
        Me.chk_Tue = New System.Windows.Forms.CheckBox()
        Me.chk_Wed = New System.Windows.Forms.CheckBox()
        Me.chk_schedule_enabled = New System.Windows.Forms.CheckBox()
        Me.Change_Log_Tab = New System.Windows.Forms.TabPage()
        Me.txtbox_Change_log = New System.Windows.Forms.TextBox()
        Me.SkyNZ.SuspendLayout()
        Me.General_Tab.SuspendLayout()
        CType(Me.Grabtime_grabtime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Settings_Tab.SuspendLayout()
        Me.Settings_Panel.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.Region_Group_Tab.SuspendLayout()
        Me.SkyNZ_Channel_Groups.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.Cards_Mapping_Tab.SuspendLayout()
        Me.Card_Map_Box.SuspendLayout()
        Me.Sky_NZ_Channel_Grabber_Settings.SuspendLayout()
        Me.Schedule_Tab.SuspendLayout()
        Me.Schedule_panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.schedule_hours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Change_Log_Tab.SuspendLayout()
        Me.SuspendLayout()
        '
        'SkyNZ
        '
        Me.SkyNZ.Controls.Add(Me.General_Tab)
        Me.SkyNZ.Controls.Add(Me.Settings_Tab)
        Me.SkyNZ.Controls.Add(Me.tabPage1)
        Me.SkyNZ.Controls.Add(Me.Cards_Mapping_Tab)
        Me.SkyNZ.Controls.Add(Me.Schedule_Tab)
        Me.SkyNZ.Controls.Add(Me.Change_Log_Tab)
        Me.SkyNZ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SkyNZ.Location = New System.Drawing.Point(0, 0)
        Me.SkyNZ.Name = "SkyNZ"
        Me.SkyNZ.SelectedIndex = 0
        Me.SkyNZ.Size = New System.Drawing.Size(456, 422)
        Me.SkyNZ.TabIndex = 3
        '
        'General_Tab
        '
        Me.General_Tab.Controls.Add(Me.Grabtime_time_label)
        Me.General_Tab.Controls.Add(Me.Grabtime_label)
        Me.General_Tab.Controls.Add(Me.Grabtime_grabtime)
        Me.General_Tab.Controls.Add(Me.Output_Window)
        Me.General_Tab.Controls.Add(Me.Grab_Now)
        Me.General_Tab.Location = New System.Drawing.Point(4, 22)
        Me.General_Tab.Name = "General_Tab"
        Me.General_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.General_Tab.Size = New System.Drawing.Size(448, 396)
        Me.General_Tab.TabIndex = 2
        Me.General_Tab.Text = "General"
        Me.General_Tab.UseVisualStyleBackColor = True
        '
        'Grabtime_time_label
        '
        Me.Grabtime_time_label.AutoSize = True
        Me.Grabtime_time_label.Location = New System.Drawing.Point(127, 11)
        Me.Grabtime_time_label.Name = "Grabtime_time_label"
        Me.Grabtime_time_label.Size = New System.Drawing.Size(49, 13)
        Me.Grabtime_time_label.TabIndex = 189
        Me.Grabtime_time_label.Text = "Seconds"
        '
        'Grabtime_label
        '
        Me.Grabtime_label.AutoSize = True
        Me.Grabtime_label.Location = New System.Drawing.Point(6, 12)
        Me.Grabtime_label.Name = "Grabtime_label"
        Me.Grabtime_label.Size = New System.Drawing.Size(56, 13)
        Me.Grabtime_label.TabIndex = 188
        Me.Grabtime_label.Text = "Grab Time"
        '
        'Grabtime_grabtime
        '
        Me.Grabtime_grabtime.Location = New System.Drawing.Point(68, 9)
        Me.Grabtime_grabtime.Name = "Grabtime_grabtime"
        Me.Grabtime_grabtime.Size = New System.Drawing.Size(53, 20)
        Me.Grabtime_grabtime.TabIndex = 187
        Me.Grabtime_grabtime.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Output_Window
        '
        Me.Output_Window.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1})
        Me.Output_Window.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Output_Window.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.Output_Window.Location = New System.Drawing.Point(3, 35)
        Me.Output_Window.Name = "Output_Window"
        Me.Output_Window.Size = New System.Drawing.Size(442, 322)
        Me.Output_Window.TabIndex = 179
        Me.Output_Window.UseCompatibleStateImageBehavior = False
        Me.Output_Window.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Width = 415
        '
        'Grab_Now
        '
        Me.Grab_Now.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Grab_Now.Location = New System.Drawing.Point(3, 357)
        Me.Grab_Now.Name = "Grab_Now"
        Me.Grab_Now.Size = New System.Drawing.Size(442, 36)
        Me.Grab_Now.TabIndex = 0
        Me.Grab_Now.Text = "Grab Now"
        Me.Grab_Now.UseVisualStyleBackColor = True
        '
        'Settings_Tab
        '
        Me.Settings_Tab.Controls.Add(Me.Settings_Panel)
        Me.Settings_Tab.Location = New System.Drawing.Point(4, 22)
        Me.Settings_Tab.Name = "Settings_Tab"
        Me.Settings_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Settings_Tab.Size = New System.Drawing.Size(448, 396)
        Me.Settings_Tab.TabIndex = 6
        Me.Settings_Tab.Text = "Settings"
        Me.Settings_Tab.UseVisualStyleBackColor = True
        '
        'Settings_Panel
        '
        Me.Settings_Panel.Controls.Add(Me.chk_modnotsetHD)
        Me.Settings_Panel.Controls.Add(Me.chk_ignorescrambled)
        Me.Settings_Panel.Controls.Add(Me.chk_modnotsetSD)
        Me.Settings_Panel.Controls.Add(Me.chk_extrainfo)
        Me.Settings_Panel.Controls.Add(Me.Expired_Channels_label)
        Me.Settings_Panel.Controls.Add(Me.chk_updateEPG)
        Me.Settings_Panel.Controls.Add(Me.chk_DeleteOld)
        Me.Settings_Panel.Controls.Add(Me.chk_replaceSDwithHD)
        Me.Settings_Panel.Controls.Add(Me.chk_MoveOld)
        Me.Settings_Panel.Controls.Add(Me.txt_Move_Old_Group)
        Me.Settings_Panel.Controls.Add(Me.chk_AutoUpdate)
        Me.Settings_Panel.Controls.Add(Me.chk_SkyCategories)
        Me.Settings_Panel.Controls.Add(Me.chk_SkyNumbers)
        Me.Settings_Panel.Controls.Add(Me.chk_SkyRegions)
        Me.Settings_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Settings_Panel.Location = New System.Drawing.Point(3, 3)
        Me.Settings_Panel.Name = "Settings_Panel"
        Me.Settings_Panel.Size = New System.Drawing.Size(442, 390)
        Me.Settings_Panel.TabIndex = 185
        '
        'chk_modnotsetHD
        '
        Me.chk_modnotsetHD.AutoSize = True
        Me.chk_modnotsetHD.Location = New System.Drawing.Point(3, 192)
        Me.chk_modnotsetHD.Name = "chk_modnotsetHD"
        Me.chk_modnotsetHD.Size = New System.Drawing.Size(239, 17)
        Me.chk_modnotsetHD.TabIndex = 191
        Me.chk_modnotsetHD.Text = "Set Modulation to ""Not Set"" for HD Channels"
        Me.chk_modnotsetHD.UseVisualStyleBackColor = True
        '
        'chk_ignorescrambled
        '
        Me.chk_ignorescrambled.AutoSize = True
        Me.chk_ignorescrambled.Location = New System.Drawing.Point(3, 215)
        Me.chk_ignorescrambled.Name = "chk_ignorescrambled"
        Me.chk_ignorescrambled.Size = New System.Drawing.Size(156, 17)
        Me.chk_ignorescrambled.TabIndex = 190
        Me.chk_ignorescrambled.Text = "Ignore Scrambled Channels"
        Me.chk_ignorescrambled.UseVisualStyleBackColor = True
        '
        'chk_modnotsetSD
        '
        Me.chk_modnotsetSD.AutoSize = True
        Me.chk_modnotsetSD.Location = New System.Drawing.Point(3, 169)
        Me.chk_modnotsetSD.Name = "chk_modnotsetSD"
        Me.chk_modnotsetSD.Size = New System.Drawing.Size(238, 17)
        Me.chk_modnotsetSD.TabIndex = 189
        Me.chk_modnotsetSD.Text = "Set Modulation to ""Not Set"" for SD Channels"
        Me.chk_modnotsetSD.UseVisualStyleBackColor = True
        '
        'chk_extrainfo
        '
        Me.chk_extrainfo.AutoSize = True
        Me.chk_extrainfo.Location = New System.Drawing.Point(3, 146)
        Me.chk_extrainfo.Name = "chk_extrainfo"
        Me.chk_extrainfo.Size = New System.Drawing.Size(251, 17)
        Me.chk_extrainfo.TabIndex = 188
        Me.chk_extrainfo.Text = "Include Extra Program Info ([HD],[SUB],[W] etc)"
        Me.chk_extrainfo.UseVisualStyleBackColor = True
        '
        'Expired_Channels_label
        '
        Me.Expired_Channels_label.AutoSize = True
        Me.Expired_Channels_label.Location = New System.Drawing.Point(3, 246)
        Me.Expired_Channels_label.Name = "Expired_Channels_label"
        Me.Expired_Channels_label.Size = New System.Drawing.Size(89, 13)
        Me.Expired_Channels_label.TabIndex = 172
        Me.Expired_Channels_label.Text = "Expired Channels"
        '
        'chk_updateEPG
        '
        Me.chk_updateEPG.AutoSize = True
        Me.chk_updateEPG.Location = New System.Drawing.Point(3, 35)
        Me.chk_updateEPG.Name = "chk_updateEPG"
        Me.chk_updateEPG.Size = New System.Drawing.Size(86, 17)
        Me.chk_updateEPG.TabIndex = 183
        Me.chk_updateEPG.Text = "Update EPG"
        Me.chk_updateEPG.UseVisualStyleBackColor = True
        '
        'chk_DeleteOld
        '
        Me.chk_DeleteOld.AutoSize = True
        Me.chk_DeleteOld.Location = New System.Drawing.Point(6, 262)
        Me.chk_DeleteOld.Name = "chk_DeleteOld"
        Me.chk_DeleteOld.Size = New System.Drawing.Size(56, 17)
        Me.chk_DeleteOld.TabIndex = 170
        Me.chk_DeleteOld.TabStop = True
        Me.chk_DeleteOld.Text = "Delete"
        Me.chk_DeleteOld.UseVisualStyleBackColor = True
        '
        'chk_replaceSDwithHD
        '
        Me.chk_replaceSDwithHD.AutoSize = True
        Me.chk_replaceSDwithHD.Location = New System.Drawing.Point(3, 123)
        Me.chk_replaceSDwithHD.Name = "chk_replaceSDwithHD"
        Me.chk_replaceSDwithHD.Size = New System.Drawing.Size(172, 17)
        Me.chk_replaceSDwithHD.TabIndex = 182
        Me.chk_replaceSDwithHD.Text = "Replace SD Channels with HD"
        Me.chk_replaceSDwithHD.UseVisualStyleBackColor = True
        '
        'chk_MoveOld
        '
        Me.chk_MoveOld.AutoSize = True
        Me.chk_MoveOld.Location = New System.Drawing.Point(6, 285)
        Me.chk_MoveOld.Name = "chk_MoveOld"
        Me.chk_MoveOld.Size = New System.Drawing.Size(64, 17)
        Me.chk_MoveOld.TabIndex = 171
        Me.chk_MoveOld.TabStop = True
        Me.chk_MoveOld.Text = "Move to"
        Me.chk_MoveOld.UseVisualStyleBackColor = True
        '
        'txt_Move_Old_Group
        '
        Me.txt_Move_Old_Group.Location = New System.Drawing.Point(6, 305)
        Me.txt_Move_Old_Group.Name = "txt_Move_Old_Group"
        Me.txt_Move_Old_Group.Size = New System.Drawing.Size(112, 20)
        Me.txt_Move_Old_Group.TabIndex = 174
        Me.txt_Move_Old_Group.Text = "Old Sky Channels"
        '
        'chk_AutoUpdate
        '
        Me.chk_AutoUpdate.AutoSize = True
        Me.chk_AutoUpdate.Location = New System.Drawing.Point(3, 13)
        Me.chk_AutoUpdate.Name = "chk_AutoUpdate"
        Me.chk_AutoUpdate.Size = New System.Drawing.Size(157, 17)
        Me.chk_AutoUpdate.TabIndex = 167
        Me.chk_AutoUpdate.Text = "Update/Add New Channels"
        Me.chk_AutoUpdate.UseVisualStyleBackColor = True
        '
        'chk_SkyCategories
        '
        Me.chk_SkyCategories.AutoSize = True
        Me.chk_SkyCategories.Location = New System.Drawing.Point(3, 79)
        Me.chk_SkyCategories.Name = "chk_SkyCategories"
        Me.chk_SkyCategories.Size = New System.Drawing.Size(122, 17)
        Me.chk_SkyCategories.TabIndex = 177
        Me.chk_SkyCategories.Text = "Use Sky Categories "
        Me.chk_SkyCategories.UseVisualStyleBackColor = True
        '
        'chk_SkyNumbers
        '
        Me.chk_SkyNumbers.AutoSize = True
        Me.chk_SkyNumbers.Location = New System.Drawing.Point(3, 57)
        Me.chk_SkyNumbers.Name = "chk_SkyNumbers"
        Me.chk_SkyNumbers.Size = New System.Drawing.Size(120, 17)
        Me.chk_SkyNumbers.TabIndex = 168
        Me.chk_SkyNumbers.Text = "Use Sky Numbering"
        Me.chk_SkyNumbers.UseVisualStyleBackColor = True
        '
        'chk_SkyRegions
        '
        Me.chk_SkyRegions.AutoSize = True
        Me.chk_SkyRegions.Location = New System.Drawing.Point(3, 101)
        Me.chk_SkyRegions.Name = "chk_SkyRegions"
        Me.chk_SkyRegions.Size = New System.Drawing.Size(306, 17)
        Me.chk_SkyRegions.TabIndex = 176
        Me.chk_SkyRegions.Text = "Use Sky Region (Untick to STOP channels moving around)"
        Me.chk_SkyRegions.UseVisualStyleBackColor = True
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.Region_Group_Tab)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(448, 396)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Region / Groups"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'Region_Group_Tab
        '
        Me.Region_Group_Tab.Controls.Add(Me.SkyNZ_Channel_Groups)
        Me.Region_Group_Tab.Controls.Add(Me.groupBox3)
        Me.Region_Group_Tab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Region_Group_Tab.Location = New System.Drawing.Point(3, 3)
        Me.Region_Group_Tab.Name = "Region_Group_Tab"
        Me.Region_Group_Tab.Size = New System.Drawing.Size(442, 390)
        Me.Region_Group_Tab.TabIndex = 177
        Me.Region_Group_Tab.TabStop = False
        '
        'SkyNZ_Channel_Groups
        '
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Save_Changes)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label15)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText20)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte20)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label16)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label17)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText19)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte19)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText18)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte18)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label18)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label19)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText17)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte17)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText16)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte16)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label20)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText15)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte15)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label21)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label22)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText14)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte14)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText13)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte13)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label23)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label24)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText12)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte12)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText11)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte11)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label5)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText9)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte9)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label11)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label12)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText7)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte7)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText10)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte10)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label13)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label14)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText6)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte6)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText5)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte5)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label7)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText4)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte4)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label3)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label4)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText8)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte8)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText3)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte3)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label2)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.Label1)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText2)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte2)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatText1)
        Me.SkyNZ_Channel_Groups.Controls.Add(Me.CatByte1)
        Me.SkyNZ_Channel_Groups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SkyNZ_Channel_Groups.Location = New System.Drawing.Point(3, 65)
        Me.SkyNZ_Channel_Groups.Name = "SkyNZ_Channel_Groups"
        Me.SkyNZ_Channel_Groups.Size = New System.Drawing.Size(436, 322)
        Me.SkyNZ_Channel_Groups.TabIndex = 174
        Me.SkyNZ_Channel_Groups.TabStop = False
        Me.SkyNZ_Channel_Groups.Text = "Groups"
        '
        'Save_Changes
        '
        Me.Save_Changes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Save_Changes.Location = New System.Drawing.Point(3, 285)
        Me.Save_Changes.Name = "Save_Changes"
        Me.Save_Changes.Size = New System.Drawing.Size(430, 34)
        Me.Save_Changes.TabIndex = 82
        Me.Save_Changes.Text = "Save Changes"
        Me.Save_Changes.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(218, 250)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(19, 13)
        Me.Label15.TabIndex = 81
        Me.Label15.Text = "20"
        '
        'CatText20
        '
        Me.CatText20.Location = New System.Drawing.Point(282, 247)
        Me.CatText20.Name = "CatText20"
        Me.CatText20.Size = New System.Drawing.Size(133, 20)
        Me.CatText20.TabIndex = 80
        '
        'CatByte20
        '
        Me.CatByte20.Location = New System.Drawing.Point(237, 247)
        Me.CatByte20.Name = "CatByte20"
        Me.CatByte20.Size = New System.Drawing.Size(39, 20)
        Me.CatByte20.TabIndex = 79
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(218, 224)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(19, 13)
        Me.Label16.TabIndex = 78
        Me.Label16.Text = "19"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(218, 198)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(19, 13)
        Me.Label17.TabIndex = 77
        Me.Label17.Text = "18"
        '
        'CatText19
        '
        Me.CatText19.Location = New System.Drawing.Point(282, 221)
        Me.CatText19.Name = "CatText19"
        Me.CatText19.Size = New System.Drawing.Size(133, 20)
        Me.CatText19.TabIndex = 76
        '
        'CatByte19
        '
        Me.CatByte19.Location = New System.Drawing.Point(237, 221)
        Me.CatByte19.Name = "CatByte19"
        Me.CatByte19.Size = New System.Drawing.Size(39, 20)
        Me.CatByte19.TabIndex = 75
        '
        'CatText18
        '
        Me.CatText18.Location = New System.Drawing.Point(282, 195)
        Me.CatText18.Name = "CatText18"
        Me.CatText18.Size = New System.Drawing.Size(133, 20)
        Me.CatText18.TabIndex = 74
        '
        'CatByte18
        '
        Me.CatByte18.Location = New System.Drawing.Point(237, 195)
        Me.CatByte18.Name = "CatByte18"
        Me.CatByte18.Size = New System.Drawing.Size(39, 20)
        Me.CatByte18.TabIndex = 73
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(218, 172)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(19, 13)
        Me.Label18.TabIndex = 72
        Me.Label18.Text = "17"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(218, 146)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(19, 13)
        Me.Label19.TabIndex = 71
        Me.Label19.Text = "16"
        '
        'CatText17
        '
        Me.CatText17.Location = New System.Drawing.Point(282, 169)
        Me.CatText17.Name = "CatText17"
        Me.CatText17.Size = New System.Drawing.Size(133, 20)
        Me.CatText17.TabIndex = 70
        '
        'CatByte17
        '
        Me.CatByte17.Location = New System.Drawing.Point(237, 169)
        Me.CatByte17.Name = "CatByte17"
        Me.CatByte17.Size = New System.Drawing.Size(39, 20)
        Me.CatByte17.TabIndex = 69
        '
        'CatText16
        '
        Me.CatText16.Location = New System.Drawing.Point(282, 143)
        Me.CatText16.Name = "CatText16"
        Me.CatText16.Size = New System.Drawing.Size(133, 20)
        Me.CatText16.TabIndex = 68
        '
        'CatByte16
        '
        Me.CatByte16.Location = New System.Drawing.Point(237, 143)
        Me.CatByte16.Name = "CatByte16"
        Me.CatByte16.Size = New System.Drawing.Size(39, 20)
        Me.CatByte16.TabIndex = 67
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(218, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(19, 13)
        Me.Label20.TabIndex = 66
        Me.Label20.Text = "15"
        '
        'CatText15
        '
        Me.CatText15.Location = New System.Drawing.Point(282, 117)
        Me.CatText15.Name = "CatText15"
        Me.CatText15.Size = New System.Drawing.Size(133, 20)
        Me.CatText15.TabIndex = 65
        '
        'CatByte15
        '
        Me.CatByte15.Location = New System.Drawing.Point(237, 117)
        Me.CatByte15.Name = "CatByte15"
        Me.CatByte15.Size = New System.Drawing.Size(39, 20)
        Me.CatByte15.TabIndex = 64
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(218, 94)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(19, 13)
        Me.Label21.TabIndex = 63
        Me.Label21.Text = "14"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(218, 68)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(19, 13)
        Me.Label22.TabIndex = 62
        Me.Label22.Text = "13"
        '
        'CatText14
        '
        Me.CatText14.Location = New System.Drawing.Point(282, 91)
        Me.CatText14.Name = "CatText14"
        Me.CatText14.Size = New System.Drawing.Size(133, 20)
        Me.CatText14.TabIndex = 61
        '
        'CatByte14
        '
        Me.CatByte14.Location = New System.Drawing.Point(237, 91)
        Me.CatByte14.Name = "CatByte14"
        Me.CatByte14.Size = New System.Drawing.Size(39, 20)
        Me.CatByte14.TabIndex = 60
        '
        'CatText13
        '
        Me.CatText13.Location = New System.Drawing.Point(282, 65)
        Me.CatText13.Name = "CatText13"
        Me.CatText13.Size = New System.Drawing.Size(133, 20)
        Me.CatText13.TabIndex = 59
        '
        'CatByte13
        '
        Me.CatByte13.Location = New System.Drawing.Point(237, 65)
        Me.CatByte13.Name = "CatByte13"
        Me.CatByte13.Size = New System.Drawing.Size(39, 20)
        Me.CatByte13.TabIndex = 58
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(218, 42)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(19, 13)
        Me.Label23.TabIndex = 57
        Me.Label23.Text = "12"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(218, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(19, 13)
        Me.Label24.TabIndex = 56
        Me.Label24.Text = "11"
        '
        'CatText12
        '
        Me.CatText12.Location = New System.Drawing.Point(282, 39)
        Me.CatText12.Name = "CatText12"
        Me.CatText12.Size = New System.Drawing.Size(133, 20)
        Me.CatText12.TabIndex = 55
        '
        'CatByte12
        '
        Me.CatByte12.Location = New System.Drawing.Point(237, 39)
        Me.CatByte12.Name = "CatByte12"
        Me.CatByte12.Size = New System.Drawing.Size(39, 20)
        Me.CatByte12.TabIndex = 54
        '
        'CatText11
        '
        Me.CatText11.Location = New System.Drawing.Point(282, 13)
        Me.CatText11.Name = "CatText11"
        Me.CatText11.Size = New System.Drawing.Size(133, 20)
        Me.CatText11.TabIndex = 53
        Me.CatText11.Text = "Interactive"
        '
        'CatByte11
        '
        Me.CatByte11.Location = New System.Drawing.Point(237, 13)
        Me.CatByte11.Name = "CatByte11"
        Me.CatByte11.Size = New System.Drawing.Size(39, 20)
        Me.CatByte11.TabIndex = 52
        Me.CatByte11.Text = "15"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 250)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "10"
        '
        'CatText9
        '
        Me.CatText9.Location = New System.Drawing.Point(72, 221)
        Me.CatText9.Name = "CatText9"
        Me.CatText9.Size = New System.Drawing.Size(133, 20)
        Me.CatText9.TabIndex = 50
        Me.CatText9.Text = "News & Documentaries"
        '
        'CatByte9
        '
        Me.CatByte9.Location = New System.Drawing.Point(27, 221)
        Me.CatByte9.Name = "CatByte9"
        Me.CatByte9.Size = New System.Drawing.Size(39, 20)
        Me.CatByte9.TabIndex = 49
        Me.CatByte9.Text = "191"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 224)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(13, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "9"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 198)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 13)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "8"
        '
        'CatText7
        '
        Me.CatText7.Location = New System.Drawing.Point(72, 169)
        Me.CatText7.Name = "CatText7"
        Me.CatText7.Size = New System.Drawing.Size(133, 20)
        Me.CatText7.TabIndex = 46
        Me.CatText7.Text = "News & Documentaries"
        '
        'CatByte7
        '
        Me.CatByte7.Location = New System.Drawing.Point(27, 169)
        Me.CatByte7.Name = "CatByte7"
        Me.CatByte7.Size = New System.Drawing.Size(39, 20)
        Me.CatByte7.TabIndex = 45
        Me.CatByte7.Text = "47"
        '
        'CatText10
        '
        Me.CatText10.Location = New System.Drawing.Point(72, 247)
        Me.CatText10.Name = "CatText10"
        Me.CatText10.Size = New System.Drawing.Size(133, 20)
        Me.CatText10.TabIndex = 44
        Me.CatText10.Text = "Adult"
        '
        'CatByte10
        '
        Me.CatByte10.Location = New System.Drawing.Point(27, 247)
        Me.CatByte10.Name = "CatByte10"
        Me.CatByte10.Size = New System.Drawing.Size(39, 20)
        Me.CatByte10.TabIndex = 43
        Me.CatByte10.Text = "255"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 172)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "7"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 146)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "6"
        '
        'CatText6
        '
        Me.CatText6.Location = New System.Drawing.Point(72, 143)
        Me.CatText6.Name = "CatText6"
        Me.CatText6.Size = New System.Drawing.Size(133, 20)
        Me.CatText6.TabIndex = 40
        Me.CatText6.Text = "Music Videos"
        '
        'CatByte6
        '
        Me.CatByte6.Location = New System.Drawing.Point(27, 143)
        Me.CatByte6.Name = "CatByte6"
        Me.CatByte6.Size = New System.Drawing.Size(39, 20)
        Me.CatByte6.TabIndex = 39
        Me.CatByte6.Text = "111"
        '
        'CatText5
        '
        Me.CatText5.Location = New System.Drawing.Point(72, 117)
        Me.CatText5.Name = "CatText5"
        Me.CatText5.Size = New System.Drawing.Size(133, 20)
        Me.CatText5.TabIndex = 38
        Me.CatText5.Text = "Sky Sports"
        '
        'CatByte5
        '
        Me.CatByte5.Location = New System.Drawing.Point(27, 117)
        Me.CatByte5.Name = "CatByte5"
        Me.CatByte5.Size = New System.Drawing.Size(39, 20)
        Me.CatByte5.TabIndex = 37
        Me.CatByte5.Text = "79"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "5"
        '
        'CatText4
        '
        Me.CatText4.Location = New System.Drawing.Point(72, 91)
        Me.CatText4.Name = "CatText4"
        Me.CatText4.Size = New System.Drawing.Size(133, 20)
        Me.CatText4.TabIndex = 33
        Me.CatText4.Text = "Sky Movies"
        '
        'CatByte4
        '
        Me.CatByte4.Location = New System.Drawing.Point(27, 91)
        Me.CatByte4.Name = "CatByte4"
        Me.CatByte4.Size = New System.Drawing.Size(39, 20)
        Me.CatByte4.TabIndex = 32
        Me.CatByte4.Text = "31"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "4"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "3"
        '
        'CatText8
        '
        Me.CatText8.Location = New System.Drawing.Point(72, 195)
        Me.CatText8.Name = "CatText8"
        Me.CatText8.Size = New System.Drawing.Size(133, 20)
        Me.CatText8.TabIndex = 29
        Me.CatText8.Text = "News & Documentaries"
        '
        'CatByte8
        '
        Me.CatByte8.Location = New System.Drawing.Point(27, 195)
        Me.CatByte8.Name = "CatByte8"
        Me.CatByte8.Size = New System.Drawing.Size(39, 20)
        Me.CatByte8.TabIndex = 28
        Me.CatByte8.Text = "159"
        '
        'CatText3
        '
        Me.CatText3.Location = New System.Drawing.Point(72, 65)
        Me.CatText3.Name = "CatText3"
        Me.CatText3.Size = New System.Drawing.Size(133, 20)
        Me.CatText3.TabIndex = 27
        Me.CatText3.Text = "Entertainment"
        '
        'CatByte3
        '
        Me.CatByte3.Location = New System.Drawing.Point(27, 65)
        Me.CatByte3.Name = "CatByte3"
        Me.CatByte3.Size = New System.Drawing.Size(39, 20)
        Me.CatByte3.TabIndex = 26
        Me.CatByte3.Text = "175"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "1"
        '
        'CatText2
        '
        Me.CatText2.Location = New System.Drawing.Point(72, 39)
        Me.CatText2.Name = "CatText2"
        Me.CatText2.Size = New System.Drawing.Size(133, 20)
        Me.CatText2.TabIndex = 3
        Me.CatText2.Text = "Entertainment"
        '
        'CatByte2
        '
        Me.CatByte2.Location = New System.Drawing.Point(26, 39)
        Me.CatByte2.Name = "CatByte2"
        Me.CatByte2.Size = New System.Drawing.Size(39, 20)
        Me.CatByte2.TabIndex = 2
        Me.CatByte2.Text = "127"
        '
        'CatText1
        '
        Me.CatText1.Location = New System.Drawing.Point(72, 13)
        Me.CatText1.Name = "CatText1"
        Me.CatText1.Size = New System.Drawing.Size(133, 20)
        Me.CatText1.TabIndex = 1
        Me.CatText1.Text = "Entertainment"
        '
        'CatByte1
        '
        Me.CatByte1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CatByte1.Location = New System.Drawing.Point(27, 13)
        Me.CatByte1.Name = "CatByte1"
        Me.CatByte1.Size = New System.Drawing.Size(39, 20)
        Me.CatByte1.TabIndex = 0
        Me.CatByte1.Text = "63"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.SkyNZ_Region)
        Me.groupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox3.Location = New System.Drawing.Point(3, 16)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(436, 49)
        Me.groupBox3.TabIndex = 175
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Region"
        '
        'SkyNZ_Region
        '
        Me.SkyNZ_Region.DisplayMember = "Sky_UK_Regions.RegionName"
        Me.SkyNZ_Region.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SkyNZ_Region.FormattingEnabled = True
        Me.SkyNZ_Region.Location = New System.Drawing.Point(3, 16)
        Me.SkyNZ_Region.Name = "SkyNZ_Region"
        Me.SkyNZ_Region.Size = New System.Drawing.Size(430, 21)
        Me.SkyNZ_Region.TabIndex = 148
        '
        'Cards_Mapping_Tab
        '
        Me.Cards_Mapping_Tab.Controls.Add(Me.Card_Map_Box)
        Me.Cards_Mapping_Tab.Controls.Add(Me.Sky_NZ_Channel_Grabber_Settings)
        Me.Cards_Mapping_Tab.Location = New System.Drawing.Point(4, 22)
        Me.Cards_Mapping_Tab.Name = "Cards_Mapping_Tab"
        Me.Cards_Mapping_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Cards_Mapping_Tab.Size = New System.Drawing.Size(448, 396)
        Me.Cards_Mapping_Tab.TabIndex = 4
        Me.Cards_Mapping_Tab.Text = "Cards / Mapping"
        Me.Cards_Mapping_Tab.UseVisualStyleBackColor = True
        '
        'Card_Map_Box
        '
        Me.Card_Map_Box.Controls.Add(Me.Cards_For_Grabbing)
        Me.Card_Map_Box.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Card_Map_Box.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Card_Map_Box.Location = New System.Drawing.Point(3, 118)
        Me.Card_Map_Box.Name = "Card_Map_Box"
        Me.Card_Map_Box.Size = New System.Drawing.Size(442, 275)
        Me.Card_Map_Box.TabIndex = 187
        Me.Card_Map_Box.TabStop = False
        Me.Card_Map_Box.Text = "Select Card(s) for grab and Mapping"
        '
        'Cards_For_Grabbing
        '
        Me.Cards_For_Grabbing.AccessibleDescription = "Use this to select the cards you wish to Map your channel searches to."
        Me.Cards_For_Grabbing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Cards_For_Grabbing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cards_For_Grabbing.FormattingEnabled = True
        Me.Cards_For_Grabbing.Location = New System.Drawing.Point(3, 16)
        Me.Cards_For_Grabbing.Name = "Cards_For_Grabbing"
        Me.Cards_For_Grabbing.Size = New System.Drawing.Size(436, 256)
        Me.Cards_For_Grabbing.TabIndex = 0
        '
        'Sky_NZ_Channel_Grabber_Settings
        '
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.Diseqc_Label)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.MP_Diseqc)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.Modulation_Label)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.MP_Modulation)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.Polarisation_Label)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.MP_Polarisation)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.Serviceid_label)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.txt_serviceid)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.TransportID_Label)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.txt_transportid)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.txt_frequency)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.Fequency_Label)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.txt_symbol_rate)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.Symbol_rate_Label)
        Me.Sky_NZ_Channel_Grabber_Settings.Controls.Add(Me.Frequency_Unit_Label)
        Me.Sky_NZ_Channel_Grabber_Settings.Dock = System.Windows.Forms.DockStyle.Top
        Me.Sky_NZ_Channel_Grabber_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Sky_NZ_Channel_Grabber_Settings.Location = New System.Drawing.Point(3, 3)
        Me.Sky_NZ_Channel_Grabber_Settings.Name = "Sky_NZ_Channel_Grabber_Settings"
        Me.Sky_NZ_Channel_Grabber_Settings.Size = New System.Drawing.Size(442, 115)
        Me.Sky_NZ_Channel_Grabber_Settings.TabIndex = 186
        Me.Sky_NZ_Channel_Grabber_Settings.TabStop = False
        Me.Sky_NZ_Channel_Grabber_Settings.Text = "Sky Channel Grabber setting"
        '
        'Diseqc_Label
        '
        Me.Diseqc_Label.AutoSize = True
        Me.Diseqc_Label.Location = New System.Drawing.Point(6, 66)
        Me.Diseqc_Label.Name = "Diseqc_Label"
        Me.Diseqc_Label.Size = New System.Drawing.Size(40, 13)
        Me.Diseqc_Label.TabIndex = 187
        Me.Diseqc_Label.Text = "Diseqc"
        '
        'MP_Diseqc
        '
        Me.MP_Diseqc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MP_Diseqc.FormattingEnabled = True
        Me.MP_Diseqc.Items.AddRange(New Object() {"None", "SimpleA", "SimpleB", "Level1AA", "Level1AB", "Level1BA", "Level1BB"})
        Me.MP_Diseqc.Location = New System.Drawing.Point(9, 81)
        Me.MP_Diseqc.Name = "MP_Diseqc"
        Me.MP_Diseqc.Size = New System.Drawing.Size(90, 21)
        Me.MP_Diseqc.TabIndex = 186
        '
        'Modulation_Label
        '
        Me.Modulation_Label.AutoSize = True
        Me.Modulation_Label.Location = New System.Drawing.Point(312, 65)
        Me.Modulation_Label.Name = "Modulation_Label"
        Me.Modulation_Label.Size = New System.Drawing.Size(62, 13)
        Me.Modulation_Label.TabIndex = 48
        Me.Modulation_Label.Text = "Modulation:"
        '
        'MP_Modulation
        '
        Me.MP_Modulation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MP_Modulation.FormattingEnabled = True
        Me.MP_Modulation.Items.AddRange(New Object() {"ModNotSet", "ModNotDefined", "Mod16Qam", "Mod32Qam", "Mod64Qam", "Mod80Qam", "Mod96Qam", "Mod112Qam", "Mod128Qam", "Mod160Qam", "Mod192Qam", "Mod224Qam", "Mod256Qam", "Mod320Qam", "Mod384Qam", "Mod448Qam", "Mod512Qam", "Mod640Qam", "Mod768Qam", "Mod896Qam", "Mod1024Qam", "ModQpsk", "ModBpsk", "ModOqpsk", "Mod8Vsb", "Mod16Vsb", "ModAnalogAmplitude", "ModAnalogFrequency", "Mod8Psk", "ModRF", "Mod16Apsk", "Mod32Apsk", "ModNbcQpsk", "ModNbc8Psk", "ModDirectTv", "ModMax"})
        Me.MP_Modulation.Location = New System.Drawing.Point(315, 81)
        Me.MP_Modulation.Name = "MP_Modulation"
        Me.MP_Modulation.Size = New System.Drawing.Size(92, 21)
        Me.MP_Modulation.TabIndex = 49
        '
        'Polarisation_Label
        '
        Me.Polarisation_Label.AutoSize = True
        Me.Polarisation_Label.Location = New System.Drawing.Point(158, 66)
        Me.Polarisation_Label.Name = "Polarisation_Label"
        Me.Polarisation_Label.Size = New System.Drawing.Size(64, 13)
        Me.Polarisation_Label.TabIndex = 46
        Me.Polarisation_Label.Text = "Polarisation:"
        '
        'MP_Polarisation
        '
        Me.MP_Polarisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MP_Polarisation.FormattingEnabled = True
        Me.MP_Polarisation.Items.AddRange(New Object() {"Not Set", "Not Defined", "Horizontal", "Vertical", "Circular Left", "Circular Right"})
        Me.MP_Polarisation.Location = New System.Drawing.Point(161, 81)
        Me.MP_Polarisation.Name = "MP_Polarisation"
        Me.MP_Polarisation.Size = New System.Drawing.Size(92, 21)
        Me.MP_Polarisation.TabIndex = 47
        '
        'Serviceid_label
        '
        Me.Serviceid_label.AutoSize = True
        Me.Serviceid_label.Location = New System.Drawing.Point(342, 16)
        Me.Serviceid_label.Name = "Serviceid_label"
        Me.Serviceid_label.Size = New System.Drawing.Size(57, 13)
        Me.Serviceid_label.TabIndex = 105
        Me.Serviceid_label.Text = "Service ID"
        '
        'txt_serviceid
        '
        Me.txt_serviceid.Location = New System.Drawing.Point(345, 32)
        Me.txt_serviceid.MaxLength = 5
        Me.txt_serviceid.Name = "txt_serviceid"
        Me.txt_serviceid.Size = New System.Drawing.Size(63, 20)
        Me.txt_serviceid.TabIndex = 104
        Me.txt_serviceid.Text = "9003"
        '
        'TransportID_Label
        '
        Me.TransportID_Label.AutoSize = True
        Me.TransportID_Label.Location = New System.Drawing.Point(230, 16)
        Me.TransportID_Label.Name = "TransportID_Label"
        Me.TransportID_Label.Size = New System.Drawing.Size(66, 13)
        Me.TransportID_Label.TabIndex = 103
        Me.TransportID_Label.Text = "Transport ID"
        '
        'txt_transportid
        '
        Me.txt_transportid.Location = New System.Drawing.Point(233, 32)
        Me.txt_transportid.MaxLength = 5
        Me.txt_transportid.Name = "txt_transportid"
        Me.txt_transportid.Size = New System.Drawing.Size(63, 20)
        Me.txt_transportid.TabIndex = 102
        Me.txt_transportid.Text = "3"
        '
        'txt_frequency
        '
        Me.txt_frequency.Location = New System.Drawing.Point(9, 32)
        Me.txt_frequency.MaxLength = 8
        Me.txt_frequency.Name = "txt_frequency"
        Me.txt_frequency.Size = New System.Drawing.Size(63, 20)
        Me.txt_frequency.TabIndex = 40
        Me.txt_frequency.Text = "12519000"
        '
        'Fequency_Label
        '
        Me.Fequency_Label.AutoSize = True
        Me.Fequency_Label.Location = New System.Drawing.Point(6, 16)
        Me.Fequency_Label.Name = "Fequency_Label"
        Me.Fequency_Label.Size = New System.Drawing.Size(60, 13)
        Me.Fequency_Label.TabIndex = 39
        Me.Fequency_Label.Text = "Frequency:"
        '
        'txt_symbol_rate
        '
        Me.txt_symbol_rate.Location = New System.Drawing.Point(121, 32)
        Me.txt_symbol_rate.MaxLength = 5
        Me.txt_symbol_rate.Name = "txt_symbol_rate"
        Me.txt_symbol_rate.Size = New System.Drawing.Size(63, 20)
        Me.txt_symbol_rate.TabIndex = 43
        Me.txt_symbol_rate.Text = "22500"
        '
        'Symbol_rate_Label
        '
        Me.Symbol_rate_Label.AutoSize = True
        Me.Symbol_rate_Label.Location = New System.Drawing.Point(118, 16)
        Me.Symbol_rate_Label.Name = "Symbol_rate_Label"
        Me.Symbol_rate_Label.Size = New System.Drawing.Size(70, 13)
        Me.Symbol_rate_Label.TabIndex = 42
        Me.Symbol_rate_Label.Text = "Symbol Rate:"
        '
        'Frequency_Unit_Label
        '
        Me.Frequency_Unit_Label.AutoSize = True
        Me.Frequency_Unit_Label.Location = New System.Drawing.Point(78, 35)
        Me.Frequency_Unit_Label.Name = "Frequency_Unit_Label"
        Me.Frequency_Unit_Label.Size = New System.Drawing.Size(26, 13)
        Me.Frequency_Unit_Label.TabIndex = 41
        Me.Frequency_Unit_Label.Text = "kHz"
        '
        'Schedule_Tab
        '
        Me.Schedule_Tab.Controls.Add(Me.Schedule_panel)
        Me.Schedule_Tab.Location = New System.Drawing.Point(4, 22)
        Me.Schedule_Tab.Name = "Schedule_Tab"
        Me.Schedule_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Schedule_Tab.Size = New System.Drawing.Size(448, 396)
        Me.Schedule_Tab.TabIndex = 3
        Me.Schedule_Tab.Text = "Schedule"
        Me.Schedule_Tab.UseVisualStyleBackColor = True
        '
        'Schedule_panel
        '
        Me.Schedule_panel.Controls.Add(Me.Panel1)
        Me.Schedule_panel.Controls.Add(Me.chk_schedule_enabled)
        Me.Schedule_panel.Location = New System.Drawing.Point(3, 0)
        Me.Schedule_panel.Name = "Schedule_panel"
        Me.Schedule_panel.Size = New System.Drawing.Size(445, 397)
        Me.Schedule_panel.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.schedule_hours)
        Me.Panel1.Controls.Add(Me.Schedule_scroll_time)
        Me.Panel1.Controls.Add(Me.chk_every_hours)
        Me.Panel1.Controls.Add(Me.chk_onthesedays)
        Me.Panel1.Controls.Add(Me.chk_Sun)
        Me.Panel1.Controls.Add(Me.chk_Sat)
        Me.Panel1.Controls.Add(Me.Schedule_Hours_Label)
        Me.Panel1.Controls.Add(Me.chk_Fri)
        Me.Panel1.Controls.Add(Me.chk_Mon)
        Me.Panel1.Controls.Add(Me.chk_Thu)
        Me.Panel1.Controls.Add(Me.chk_Tue)
        Me.Panel1.Controls.Add(Me.chk_Wed)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(445, 380)
        Me.Panel1.TabIndex = 13
        '
        'schedule_hours
        '
        Me.schedule_hours.Location = New System.Drawing.Point(114, 11)
        Me.schedule_hours.Name = "schedule_hours"
        Me.schedule_hours.Size = New System.Drawing.Size(58, 20)
        Me.schedule_hours.TabIndex = 14
        '
        'Schedule_scroll_time
        '
        Me.Schedule_scroll_time.CustomFormat = "HH:mm"
        Me.Schedule_scroll_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Schedule_scroll_time.Location = New System.Drawing.Point(114, 51)
        Me.Schedule_scroll_time.Name = "Schedule_scroll_time"
        Me.Schedule_scroll_time.ShowUpDown = True
        Me.Schedule_scroll_time.Size = New System.Drawing.Size(58, 20)
        Me.Schedule_scroll_time.TabIndex = 13
        '
        'chk_every_hours
        '
        Me.chk_every_hours.AutoSize = True
        Me.chk_every_hours.Location = New System.Drawing.Point(8, 12)
        Me.chk_every_hours.Name = "chk_every_hours"
        Me.chk_every_hours.Size = New System.Drawing.Size(53, 17)
        Me.chk_every_hours.TabIndex = 1
        Me.chk_every_hours.Text = "Every"
        Me.chk_every_hours.UseVisualStyleBackColor = True
        '
        'chk_onthesedays
        '
        Me.chk_onthesedays.AutoSize = True
        Me.chk_onthesedays.Location = New System.Drawing.Point(8, 54)
        Me.chk_onthesedays.Name = "chk_onthesedays"
        Me.chk_onthesedays.Size = New System.Drawing.Size(108, 17)
        Me.chk_onthesedays.TabIndex = 2
        Me.chk_onthesedays.Text = "On these days @"
        Me.chk_onthesedays.UseVisualStyleBackColor = True
        '
        'chk_Sun
        '
        Me.chk_Sun.AutoSize = True
        Me.chk_Sun.Location = New System.Drawing.Point(116, 109)
        Me.chk_Sun.Name = "chk_Sun"
        Me.chk_Sun.Size = New System.Drawing.Size(45, 17)
        Me.chk_Sun.TabIndex = 11
        Me.chk_Sun.Text = "Sun"
        Me.chk_Sun.UseVisualStyleBackColor = True
        '
        'chk_Sat
        '
        Me.chk_Sat.AutoSize = True
        Me.chk_Sat.Location = New System.Drawing.Point(63, 109)
        Me.chk_Sat.Name = "chk_Sat"
        Me.chk_Sat.Size = New System.Drawing.Size(42, 17)
        Me.chk_Sat.TabIndex = 10
        Me.chk_Sat.Text = "Sat"
        Me.chk_Sat.UseVisualStyleBackColor = True
        '
        'Schedule_Hours_Label
        '
        Me.Schedule_Hours_Label.AutoSize = True
        Me.Schedule_Hours_Label.Location = New System.Drawing.Point(173, 13)
        Me.Schedule_Hours_Label.Name = "Schedule_Hours_Label"
        Me.Schedule_Hours_Label.Size = New System.Drawing.Size(39, 13)
        Me.Schedule_Hours_Label.TabIndex = 4
        Me.Schedule_Hours_Label.Text = "hour(s)"
        '
        'chk_Fri
        '
        Me.chk_Fri.AutoSize = True
        Me.chk_Fri.Location = New System.Drawing.Point(8, 109)
        Me.chk_Fri.Name = "chk_Fri"
        Me.chk_Fri.Size = New System.Drawing.Size(37, 17)
        Me.chk_Fri.TabIndex = 9
        Me.chk_Fri.Text = "Fri"
        Me.chk_Fri.UseVisualStyleBackColor = True
        '
        'chk_Mon
        '
        Me.chk_Mon.AutoSize = True
        Me.chk_Mon.Location = New System.Drawing.Point(8, 86)
        Me.chk_Mon.Name = "chk_Mon"
        Me.chk_Mon.Size = New System.Drawing.Size(47, 17)
        Me.chk_Mon.TabIndex = 5
        Me.chk_Mon.Text = "Mon"
        Me.chk_Mon.UseVisualStyleBackColor = True
        '
        'chk_Thu
        '
        Me.chk_Thu.AutoSize = True
        Me.chk_Thu.Location = New System.Drawing.Point(173, 86)
        Me.chk_Thu.Name = "chk_Thu"
        Me.chk_Thu.Size = New System.Drawing.Size(45, 17)
        Me.chk_Thu.TabIndex = 8
        Me.chk_Thu.Text = "Thu"
        Me.chk_Thu.UseVisualStyleBackColor = True
        '
        'chk_Tue
        '
        Me.chk_Tue.AutoSize = True
        Me.chk_Tue.Location = New System.Drawing.Point(63, 86)
        Me.chk_Tue.Name = "chk_Tue"
        Me.chk_Tue.Size = New System.Drawing.Size(45, 17)
        Me.chk_Tue.TabIndex = 6
        Me.chk_Tue.Text = "Tue"
        Me.chk_Tue.UseVisualStyleBackColor = True
        '
        'chk_Wed
        '
        Me.chk_Wed.AutoSize = True
        Me.chk_Wed.Location = New System.Drawing.Point(116, 86)
        Me.chk_Wed.Name = "chk_Wed"
        Me.chk_Wed.Size = New System.Drawing.Size(49, 17)
        Me.chk_Wed.TabIndex = 7
        Me.chk_Wed.Text = "Wed"
        Me.chk_Wed.UseVisualStyleBackColor = True
        '
        'chk_schedule_enabled
        '
        Me.chk_schedule_enabled.AutoSize = True
        Me.chk_schedule_enabled.Dock = System.Windows.Forms.DockStyle.Top
        Me.chk_schedule_enabled.Location = New System.Drawing.Point(0, 0)
        Me.chk_schedule_enabled.Name = "chk_schedule_enabled"
        Me.chk_schedule_enabled.Size = New System.Drawing.Size(445, 17)
        Me.chk_schedule_enabled.TabIndex = 0
        Me.chk_schedule_enabled.Text = "Enabled"
        Me.chk_schedule_enabled.UseVisualStyleBackColor = True
        '
        'Change_Log_Tab
        '
        Me.Change_Log_Tab.Controls.Add(Me.txtbox_Change_log)
        Me.Change_Log_Tab.Location = New System.Drawing.Point(4, 22)
        Me.Change_Log_Tab.Name = "Change_Log_Tab"
        Me.Change_Log_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Change_Log_Tab.Size = New System.Drawing.Size(448, 396)
        Me.Change_Log_Tab.TabIndex = 5
        Me.Change_Log_Tab.Text = "Change Log"
        Me.Change_Log_Tab.UseVisualStyleBackColor = True
        '
        'txtbox_Change_log
        '
        Me.txtbox_Change_log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtbox_Change_log.Location = New System.Drawing.Point(3, 3)
        Me.txtbox_Change_log.Multiline = True
        Me.txtbox_Change_log.Name = "txtbox_Change_log"
        Me.txtbox_Change_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtbox_Change_log.Size = New System.Drawing.Size(442, 390)
        Me.txtbox_Change_log.TabIndex = 0
        Me.txtbox_Change_log.Text = resources.GetString("txtbox_Change_log.Text")
        '
        'Setup
        '
        Me.Controls.Add(Me.SkyNZ)
        Me.Name = "Setup"
        Me.Size = New System.Drawing.Size(456, 422)
        Me.SkyNZ.ResumeLayout(False)
        Me.General_Tab.ResumeLayout(False)
        Me.General_Tab.PerformLayout()
        CType(Me.Grabtime_grabtime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Settings_Tab.ResumeLayout(False)
        Me.Settings_Panel.ResumeLayout(False)
        Me.Settings_Panel.PerformLayout()
        Me.tabPage1.ResumeLayout(False)
        Me.Region_Group_Tab.ResumeLayout(False)
        Me.SkyNZ_Channel_Groups.ResumeLayout(False)
        Me.SkyNZ_Channel_Groups.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.Cards_Mapping_Tab.ResumeLayout(False)
        Me.Card_Map_Box.ResumeLayout(False)
        Me.Sky_NZ_Channel_Grabber_Settings.ResumeLayout(False)
        Me.Sky_NZ_Channel_Grabber_Settings.PerformLayout()
        Me.Schedule_Tab.ResumeLayout(False)
        Me.Schedule_panel.ResumeLayout(False)
        Me.Schedule_panel.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.schedule_hours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Change_Log_Tab.ResumeLayout(False)
        Me.Change_Log_Tab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private Sub AddLog(ByVal Value As String, ByVal UpdateLast As Boolean)
        If UpdateLast = True Then
            Output_Window.Items(Output_Window.Items.Count - 1).Text = Value
        Else
            Output_Window.Items.Add(Value)
        End If
        Output_Window.Items(Output_Window.Items.Count - 1).EnsureVisible()
    End Sub

    Private Sub SetBool(ByVal value As Boolean)
        Settings_Panel.Enabled = value
    End Sub

    Private Sub SetBool22(ByVal value As Boolean)
        Region_Group_Tab.Enabled = value
    End Sub

    Private Sub SetBool33(ByVal value As Boolean)
        Sky_NZ_Channel_Grabber_Settings.Enabled = value
    End Sub

    Private Sub SetBool44(ByVal value As Boolean)
        Card_Map_Box.Enabled = value
    End Sub

    Private Sub SetBool55(ByVal value As Boolean)
        Schedule_panel.Enabled = value
    End Sub

    Private Sub SetBool66(ByVal value As Boolean)
        Grab_Now.Enabled = value
    End Sub

    Sub active() Handles Grabber.OnActivateControls
        Dim param(0) As Boolean
        param(0) = True
        Try
            Settings_Panel.Invoke(Bool1, param(0))
            Region_Group_Tab.Invoke(Bool2, param(0))
            Sky_NZ_Channel_Grabber_Settings.Invoke(Bool3, param(0))
            Card_Map_Box.Invoke(Bool4, param(0))
            Schedule_panel.Invoke(Bool5, param(0))
            Grab_Now.Invoke(Bool6, param(0))
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub Grab_Now_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grab_Now.Click
        If Settings.IsGrabbing = False Then
            Output_Window.Items.Clear()
            Dim param(0) As Boolean
            param(0) = False
            Try
                Settings_Panel.Invoke(Bool1, param(0))
                Region_Group_Tab.Invoke(Bool2, param(0))
                Sky_NZ_Channel_Grabber_Settings.Invoke(Bool3, param(0))
                Card_Map_Box.Invoke(Bool4, param(0))
                Schedule_panel.Invoke(Bool5, param(0))
                Grab_Now.Invoke(Bool6, param(0))
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError()
            End Try
            Grabber.Grab()
        End If
    End Sub

    Private Sub OnMessage(ByVal Message As String, ByVal UpdateLast As Boolean) Handles Grabber.OnMessage
        Dim param() As Object = {Message, UpdateLast}
        Try
            Output_Window.Invoke(Log1, param)
            If UpdateLast = False Then
                Log.Write("Sky Plugin : " & Message)
            End If

        Catch

        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Changes.Click

        Try
            If CatByte1.Text <> "" And CatByte1.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte1.Text), CatText1.Text)
        Catch
            CatByte1.Text = ""
        End Try

        Try
            If CatByte2.Text <> "" And CatByte2.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte2.Text), CatText2.Text)
        Catch
            CatByte2.Text = ""
        End Try

        Try
            If CatByte3.Text <> "" And CatByte3.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte3.Text), CatText3.Text)
        Catch
            CatByte3.Text = ""
        End Try
        Try
            If CatByte4.Text <> "" And CatByte4.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte4.Text), CatText4.Text)
        Catch
            CatByte4.Text = ""
        End Try
        Try
            If CatByte5.Text <> "" And CatByte5.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte5.Text), CatText5.Text)
        Catch
            CatByte5.Text = ""
        End Try
        Try
            If CatByte6.Text <> "" And CatByte6.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte6.Text), CatText6.Text)
        Catch
            CatByte6.Text = ""
        End Try
        Try
            If CatByte7.Text <> "" And CatByte7.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte7.Text), CatText7.Text)
        Catch
            CatByte7.Text = ""
        End Try
        Try
            If CatByte8.Text <> "" And CatByte8.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte8.Text), CatText8.Text)
        Catch
            CatByte8.Text = ""
        End Try
        Try
            If CatByte9.Text <> "" And CatByte9.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte9.Text), CatText9.Text)
        Catch
            CatByte9.Text = ""
        End Try
        Try
            If CatByte10.Text <> "" And CatByte10.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte10.Text), CatText10.Text)
        Catch
            CatByte10.Text = ""
        End Try
        Try
            If CatByte11.Text <> "" And CatByte11.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte11.Text), CatText11.Text)
        Catch
            CatByte11.Text = ""
        End Try
        Try
            If CatByte12.Text <> "" And CatByte12.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte12.Text), CatText12.Text)
        Catch
            CatByte12.Text = ""
        End Try
        Try
            If CatByte13.Text <> "" And CatByte13.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte13.Text), CatText13.Text)
        Catch
            CatByte13.Text = ""
        End Try
        Try
            If CatByte14.Text <> "" And CatByte14.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte14.Text), CatText14.Text)
        Catch
            CatByte14.Text = ""
        End Try
        Try
            If CatByte15.Text <> "" And CatByte15.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte15.Text), CatText15.Text)
        Catch
            CatByte15.Text = ""
        End Try
        Try
            If CatByte16.Text <> "" And CatByte16.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte16.Text), CatText16.Text)
        Catch
            CatByte16.Text = ""
        End Try
        Try
            If CatByte17.Text <> "" And CatByte17.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte17.Text), CatText17.Text)
        Catch
            CatByte17.Text = ""
        End Try
        Try
            If CatByte18.Text <> "" And CatByte18.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte18.Text), CatText18.Text)
        Catch
            CatByte18.Text = ""
        End Try
        Try
            If CatByte19.Text <> "" And CatByte19.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte19.Text), CatText19.Text)
        Catch
            CatByte19.Text = ""
        End Try
        Try
            If CatByte20.Text <> "" And CatByte20.Text <> "0" Then Settings.SetCategory(Convert.ToInt32(CatByte20.Text), CatText20.Text)
        Catch
            CatByte20.Text = ""
        End Try
        SaveCatSettings()
    End Sub

    Sub LoadSetting()
        Dim layer As New TvBusinessLayer()
        Dim id As Integer = -1
        Dim checker As Integer = 0
        For Each card_1 As Card In Card.ListAll()
            If RemoteControl.Instance.Type(card_1.IdCard) = CardType.DvbS Then
                Cards_For_Grabbing.Items.Add(card_1.Name)
            End If
        Next
        Settings.IsLoading = True
        Dim listofmap As List(Of Integer) = Settings.CardMap
        If listofmap.Count > 0 And Cards_For_Grabbing.Items.Count > 0 Then
            For Each num In listofmap
                Try
                    Cards_For_Grabbing.SetItemChecked(num, True)
                Catch ex As Exception

                End Try
            Next
        End If
        Settings.IsLoading = False
        layer = Nothing

        Dim rr As New IO.StringReader(My.Settings.Regions)
        Dim ttt As New List(Of String)
        Dim lines() As String = My.Settings.Regions.Split(vbNewLine)
        For Each str As String In lines
            ttt.Add(str)
        Next

        Dim trt As Integer = -1
        For Each yt As String In ttt
            trt += 1
            Dim split(2) As String
            Dim Split2(2) As String
            split = yt.Split("=")
            SkyNZ_Region.Items.Add(split(1))
            Split2 = split(0).Split("-")
            Dim bad As New Region
            bad.BouquetID = Val(Split2(0))
            bad.RegionID = Val(Split2(1))
            regions.Add(trt, bad)
        Next

        If Settings.GetSkySetting(CatByte1.Name, CatByte1.Text) = "-1" Then
            CatByte1.Text = ""
            CatText1.Text = ""
        Else
            CatByte1.Text = Settings.GetSkySetting(CatByte1.Name, "-1")
            CatText1.Text = Settings.GetSkySetting(CatText1.Name, CatText1.Text)
        End If

        If Settings.GetSkySetting(CatByte2.Name, CatByte2.Text) = "-1" Then
            CatByte2.Text = ""
            CatText2.Text = ""
        Else
            CatByte2.Text = Settings.GetSkySetting(CatByte2.Name, "-1")
            CatText2.Text = Settings.GetSkySetting(CatText2.Name, CatText2.Text)
        End If


        If Settings.GetSkySetting(CatByte3.Name, CatByte3.Text) = "-1" Then
            CatByte3.Text = ""
            CatText3.Text = ""
        Else
            CatByte3.Text = Settings.GetSkySetting(CatByte3.Name, "-1")
            CatText3.Text = Settings.GetSkySetting(CatText3.Name, CatText3.Text)
        End If
        If Settings.GetSkySetting(CatByte4.Name, CatByte4.Text) = "-1" Then
            CatByte4.Text = ""
            CatText4.Text = ""
        Else
            CatByte4.Text = Settings.GetSkySetting(CatByte4.Name, "-1")
            CatText4.Text = Settings.GetSkySetting(CatText4.Name, CatText4.Text)
        End If

        If Settings.GetSkySetting(CatByte5.Name, CatByte5.Text) = "-1" Then
            CatByte5.Text = ""
            CatText5.Text = ""
        Else
            CatByte5.Text = Settings.GetSkySetting(CatByte5.Name, "-1")
            CatText5.Text = Settings.GetSkySetting(CatText5.Name, CatText5.Text)
        End If

        If Settings.GetSkySetting(CatByte6.Name, CatByte6.Text) = "-1" Then
            CatByte6.Text = ""
            CatText6.Text = ""
        Else
            CatByte6.Text = Settings.GetSkySetting(CatByte6.Name, "-1")
            CatText6.Text = Settings.GetSkySetting(CatText6.Name, CatText6.Text)
        End If

        If Settings.GetSkySetting(CatByte7.Name, CatByte7.Text) = "-1" Then
            CatByte7.Text = ""
            CatText7.Text = ""
        Else
            CatByte7.Text = Settings.GetSkySetting(CatByte7.Name, "-1")
            CatText7.Text = Settings.GetSkySetting(CatText7.Name, CatText7.Text)
        End If

        If Settings.GetSkySetting(CatByte8.Name, CatByte8.Text) = "-1" Then
            CatByte8.Text = ""
            CatText8.Text = ""
        Else
            CatByte8.Text = Settings.GetSkySetting(CatByte8.Name, "-1")
            CatText8.Text = Settings.GetSkySetting(CatText8.Name, CatText8.Text)
        End If

        If Settings.GetSkySetting(CatByte9.Name, CatByte9.Text) = "-1" Then
            CatByte9.Text = ""
            CatText9.Text = ""
        Else
            CatByte9.Text = Settings.GetSkySetting(CatByte9.Name, "-1")
            CatText9.Text = Settings.GetSkySetting(CatText9.Name, CatText9.Text)
        End If

        If Settings.GetSkySetting(CatByte10.Name, CatByte10.Text) = "-1" Then
            CatByte10.Text = ""
            CatText10.Text = ""
        Else
            CatByte10.Text = Settings.GetSkySetting(CatByte10.Name, "-1")
            CatText10.Text = Settings.GetSkySetting(CatText10.Name, CatText10.Text)
        End If

        If Settings.GetSkySetting(CatByte11.Name, CatByte11.Text) = "-1" Then
            CatByte11.Text = ""
            CatText11.Text = ""
        Else
            CatByte11.Text = Settings.GetSkySetting(CatByte11.Name, "-1")
            CatText11.Text = Settings.GetSkySetting(CatText11.Name, CatText11.Text)
        End If

        If Settings.GetSkySetting(CatByte12.Name, CatByte12.Text) = "-1" Then
            CatByte12.Text = ""
            CatText12.Text = ""
        Else
            CatByte12.Text = Settings.GetSkySetting(CatByte12.Name, "-1")
            CatText12.Text = Settings.GetSkySetting(CatText12.Name, CatText12.Text)
        End If

        If Settings.GetSkySetting(CatByte13.Name, CatByte13.Text) = "-1" Then
            CatByte13.Text = ""
            CatText13.Text = ""
        Else
            CatByte13.Text = Settings.GetSkySetting(CatByte13.Name, "-1")
            CatText13.Text = Settings.GetSkySetting(CatText13.Name, CatText13.Text)
        End If

        If Settings.GetSkySetting(CatByte14.Name, CatByte14.Text) = "-1" Then
            CatByte14.Text = ""
            CatText14.Text = ""
        Else
            CatByte14.Text = Settings.GetSkySetting(CatByte14.Name, "-1")
            CatText14.Text = Settings.GetSkySetting(CatText14.Name, CatText14.Text)
        End If

        If Settings.GetSkySetting(CatByte15.Name, CatByte15.Text) = "-1" Then
            CatByte15.Text = ""
            CatText15.Text = ""
        Else
            CatByte15.Text = Settings.GetSkySetting(CatByte15.Name, "-1")
            CatText15.Text = Settings.GetSkySetting(CatText15.Name, CatText15.Text)
        End If

        If Settings.GetSkySetting(CatByte16.Name, CatByte16.Text) = "-1" Then
            CatByte16.Text = ""
            CatText16.Text = ""
        Else
            CatByte16.Text = Settings.GetSkySetting(CatByte16.Name, "-1")
            CatText16.Text = Settings.GetSkySetting(CatText16.Name, CatText16.Text)
        End If

        If Settings.GetSkySetting(CatByte17.Name, CatByte17.Text) = "-1" Then
            CatByte17.Text = ""
            CatText17.Text = ""
        Else
            CatByte17.Text = Settings.GetSkySetting(CatByte17.Name, "-1")
            CatText17.Text = Settings.GetSkySetting(CatText17.Name, CatText17.Text)
        End If

        If Settings.GetSkySetting(CatByte18.Name, CatByte18.Text) = "-1" Then
            CatByte18.Text = ""
            CatText18.Text = ""
        Else
            CatByte18.Text = Settings.GetSkySetting(CatByte18.Name, "-1")
            CatText18.Text = Settings.GetSkySetting(CatText18.Name, CatText18.Text)
        End If

        If Settings.GetSkySetting(CatByte19.Name, CatByte19.Text) = "-1" Then
            CatByte19.Text = ""
            CatText19.Text = ""
        Else
            CatByte19.Text = Settings.GetSkySetting(CatByte19.Name, "-1")
            CatText19.Text = Settings.GetSkySetting(CatText19.Name, CatText19.Text)
        End If

        If Settings.GetSkySetting(CatByte20.Name, CatByte20.Text) = "-1" Then
            CatByte20.Text = ""
            CatText20.Text = ""
        Else
            CatByte20.Text = Settings.GetSkySetting(CatByte20.Name, "-1")
            CatText20.Text = Settings.GetSkySetting(CatText20.Name, CatText20.Text)
        End If
        txt_frequency.Text = Settings.frequency
        chk_AutoUpdate.Checked = Settings.UpdateChannels
        chk_SkyNumbers.Checked = Settings.UseSkyNumbers
        chk_SkyCategories.Checked = Settings.UseSkyCategories
        chk_SkyRegions.Checked = Settings.UseSkyRegions
        chk_DeleteOld.Checked = Settings.DeleteOldChannels
        chk_MoveOld.Checked = Not Settings.DeleteOldChannels
        chk_replaceSDwithHD.Checked = Settings.ReplaceSDwithHD
        chk_updateEPG.Checked = Settings.UpdateEPG
        'TextBox1.Text = Settings.SwitchingFrequency
        txt_Move_Old_Group.Text = Settings.OldChannelFolder
        SkyNZ_Region.SelectedIndex = Settings.RegionIndex
        Settings.RegionIndex = SkyNZ_Region.SelectedIndex
        txt_symbol_rate.Text = Settings.SymbolRate
        txt_transportid.Text = Settings.TransportID
        txt_serviceid.Text = Settings.ServiceID
        MP_Diseqc.SelectedIndex = Settings.DiseqC
        If MP_Diseqc.SelectedIndex = -1 Then
            MP_Diseqc.SelectedIndex = 0
            Settings.DiseqC = 0
        End If
        MP_Polarisation.SelectedIndex = Settings.polarisation
        If MP_Polarisation.SelectedIndex = -1 Then
            MP_Polarisation.SelectedIndex = 0
            Settings.polarisation = 0
        End If
        MP_Modulation.SelectedIndex = Settings.modulation
        If MP_Modulation.SelectedIndex = -1 Then
            MP_Modulation.SelectedIndex = 0
            Settings.modulation = 0
        End If
        txt_frequency.Text = Settings.frequency
        chk_schedule_enabled.Checked = Settings.AutoUpdate
        chk_every_hours.Checked = Settings.EveryHour
        chk_onthesedays.Checked = Settings.OnDaysAt
        If Settings.UpdateInterval = 0 Then
            Settings.UpdateInterval = 1
        End If
        chk_extrainfo.Checked = Settings.useExtraInfo
        chk_modnotsetSD.Checked = Settings.UseNotSetModSD
        chk_modnotsetHD.Checked = Settings.UseNotSetModHD
        chk_ignorescrambled.Checked = Settings.IgnoreScrambled

        Grabtime_grabtime.Value = Settings.GrabTime
        schedule_hours.Value = Settings.UpdateInterval
        Panel1.Visible = Settings.AutoUpdate
        Schedule_scroll_time.Value = Settings.UpdateTime

        chk_Mon.Checked = Settings.Mon
        chk_Tue.Checked = Settings.Tue
        chk_Wed.Checked = Settings.Wed
        chk_Thu.Checked = Settings.Thu
        chk_Fri.Checked = Settings.Fri
        chk_Sat.Checked = Settings.Sat
        chk_Sun.Checked = Settings.Sun

        If CatByte1.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte1.Text), CatText1.Text)
        If CatByte2.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte2.Text), CatText2.Text)
        If CatByte3.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte3.Text), CatText3.Text)
        If CatByte8.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte8.Text), CatText8.Text)
        If CatByte4.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte4.Text), CatText4.Text)
        If CatByte5.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte5.Text), CatText5.Text)
        If CatByte6.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte6.Text), CatText6.Text)
        If CatByte10.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte10.Text), CatText10.Text)
        If CatByte7.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte7.Text), CatText7.Text)
        If CatByte9.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte9.Text), CatText9.Text)
        If CatByte11.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte11.Text), CatText11.Text)
        If CatByte12.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte12.Text), CatText12.Text)
        If CatByte13.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte13.Text), CatText13.Text)
        If CatByte14.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte14.Text), CatText14.Text)
        If CatByte15.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte15.Text), CatText15.Text)
        If CatByte16.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte16.Text), CatText16.Text)
        If CatByte17.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte17.Text), CatText17.Text)
        If CatByte18.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte18.Text), CatText18.Text)
        If CatByte19.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte19.Text), CatText19.Text)
        If CatByte20.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte11.Text), CatText20.Text)
    End Sub

    Sub SaveCatSettings()

        Dim Temp As String
        Dim Name As String
        Dim Temo As String
        Dim Namo As String

        Temp = CatByte1.Text
        Name = CatByte1.Name
        Temo = CatText1.Text
        Namo = CatText1.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If

        Temp = CatByte2.Text
        Name = CatByte2.Name
        Temo = CatText2.Text
        Namo = CatText2.Name

        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
        Temp = CatByte3.Text
        Name = CatByte3.Name
        Temo = CatText3.Text
        Namo = CatText3.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If


        Temp = CatByte4.Text
        Name = CatByte4.Name
        Temo = CatText4.Text
        Namo = CatText4.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If

        Temp = CatByte5.Text
        Name = CatByte5.Name
        Temo = CatText5.Text
        Namo = CatText5.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
        Temp = CatByte6.Text
        Name = CatByte6.Name
        Temo = CatText6.Text
        Namo = CatText6.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If


        Temp = CatByte7.Text
        Name = CatByte7.Name
        Temo = CatText7.Text
        Namo = CatText7.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
        Temp = CatByte8.Text
        Name = CatByte8.Name
        Temo = CatText8.Text
        Namo = CatText8.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
        Temp = CatByte9.Text
        Name = CatByte9.Name
        Temo = CatText9.Text
        Namo = CatText9.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
        Temp = CatByte10.Text
        Name = CatByte10.Name
        Temo = CatText10.Text
        Namo = CatText10.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
        Temp = CatByte11.Text
        Name = CatByte11.Name
        Temo = CatText11.Text
        Namo = CatText11.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If

        Temp = CatByte12.Text
        Name = CatByte12.Name
        Temo = CatText12.Text
        Namo = CatText12.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
        Temp = CatByte13.Text
        Name = CatByte13.Name
        Temo = CatText13.Text
        Namo = CatText13.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If

        Temp = CatByte14.Text
        Name = CatByte14.Name
        Temo = CatText14.Text
        Namo = CatText14.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
        Temp = CatByte15.Text
        Name = CatByte15.Name
        Temo = CatText15.Text
        Namo = CatText15.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If

        Temp = CatByte16.Text
        Name = CatByte16.Name
        Temo = CatText16.Text
        Namo = CatText16.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
        Temp = CatByte17.Text
        Name = CatByte17.Name
        Temo = CatText17.Text
        Namo = CatText17.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If

        Temp = CatByte18.Text
        Name = CatByte18.Name
        Temo = CatText18.Text
        Namo = CatText18.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
        Temp = CatByte19.Text
        Name = CatByte19.Name
        Temo = CatText19.Text
        Namo = CatText19.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If

        Temp = CatByte20.Text
        Name = CatByte20.Name
        Temo = CatText20.Text
        Namo = CatText20.Name
        Settings.UpdateSetting(Namo, Temo)
        If Temp = "" Then
            Settings.UpdateSetting(Name, "-1")
        Else
            Settings.UpdateSetting(Name, Temp)
        End If
    End Sub

    Private Sub SkyUK_Region_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SkyNZ_Region.SelectedIndexChanged
        Dim region As Region = regions(SkyNZ_Region.SelectedIndex)
        Settings.RegionID = region.RegionID
        Settings.BouquetID = region.BouquetID
        Settings.RegionIndex = SkyNZ_Region.SelectedIndex
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Settings.SymbolRate = txt_symbol_rate.Text
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Settings.TransportID = txt_transportid.Text

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Settings.ServiceID = txt_serviceid.Text
    End Sub

    Private Sub MpComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MP_Modulation.SelectedIndexChanged
        Settings.modulation = MP_Modulation.SelectedIndex
    End Sub

    Private Sub mpDisEqc1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MP_Diseqc.SelectedIndexChanged
        Settings.DiseqC = MP_Diseqc.SelectedIndex
    End Sub

    Private Sub MpComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MP_Polarisation.SelectedIndexChanged
        Settings.polarisation = MP_Polarisation.SelectedIndex
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Settings.frequency = txt_frequency.Text
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_schedule_enabled.CheckedChanged
        Settings.AutoUpdate = chk_schedule_enabled.Checked
        Panel1.Visible = Settings.AutoUpdate
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_every_hours.CheckedChanged
        Settings.EveryHour = chk_every_hours.Checked
        Settings.OnDaysAt = Not chk_every_hours.Checked
        chk_onthesedays.Checked = Not chk_every_hours.Checked
        chk_Mon.Enabled = Not chk_every_hours.Checked
        chk_Tue.Enabled = Not chk_every_hours.Checked
        chk_Wed.Enabled = Not chk_every_hours.Checked
        chk_Thu.Enabled = Not chk_every_hours.Checked
        chk_Fri.Enabled = Not chk_every_hours.Checked
        chk_Sat.Enabled = Not chk_every_hours.Checked
        chk_Sun.Enabled = Not chk_every_hours.Checked
        Schedule_scroll_time.Enabled = Not chk_every_hours.Checked
        schedule_hours.Enabled = chk_every_hours.Checked
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_onthesedays.CheckedChanged
        Settings.OnDaysAt = chk_onthesedays.Checked
        Settings.EveryHour = Not chk_onthesedays.Checked
        chk_every_hours.Checked = Not chk_onthesedays.Checked
        chk_Mon.Enabled = Not chk_every_hours.Checked
        chk_Tue.Enabled = Not chk_every_hours.Checked
        chk_Wed.Enabled = Not chk_every_hours.Checked
        chk_Thu.Enabled = Not chk_every_hours.Checked
        chk_Fri.Enabled = Not chk_every_hours.Checked
        chk_Sat.Enabled = Not chk_every_hours.Checked
        chk_Sun.Enabled = Not chk_every_hours.Checked
        Schedule_scroll_time.Enabled = Not chk_every_hours.Checked
        schedule_hours.Enabled = chk_every_hours.Checked
    End Sub

    Private Sub Mon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Mon.CheckedChanged
        Settings.Mon = chk_Mon.Checked
    End Sub

    Private Sub Tue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Tue.CheckedChanged
        Settings.Tue = chk_Tue.Checked
    End Sub

    Private Sub Wed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Wed.CheckedChanged
        Settings.Wed = chk_Wed.Checked
    End Sub

    Private Sub Thu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Thu.CheckedChanged
        Settings.Thu = chk_Thu.Checked
    End Sub

    Private Sub Fri_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Fri.CheckedChanged
        Settings.Fri = chk_Fri.Checked
    End Sub

    Private Sub Sat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Sat.CheckedChanged
        Settings.Sat = chk_Sat.Checked
    End Sub

    Private Sub Sun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Sun.CheckedChanged
        Settings.Sun = chk_Sun.Checked
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles schedule_hours.ValueChanged
        Settings.UpdateInterval = schedule_hours.Value
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Schedule_scroll_time.ValueChanged
        Settings.UpdateTime = Schedule_scroll_time.Value.ToString
    End Sub

    Private Sub ChannelMap_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles Cards_For_Grabbing.ItemCheck
        If Settings.IsLoading = False Then
            Dim listofmap As New List(Of Integer)
            If Cards_For_Grabbing.Items.Count > 0 Then
                For a As Integer = 0 To Cards_For_Grabbing.Items.Count - 1
                    Try
                        '   MsgBox(e.Index & " : " & e.NewValue)
                        If e.Index = a Then
                            If (e.NewValue = 1) Then
                                listofmap.Add(a)
                            End If
                        Else
                            If Cards_For_Grabbing.GetItemChecked(a) Then
                                listofmap.Add(a)
                            End If
                        End If

                    Catch ex As Exception

                    End Try
                Next
            End If
            Settings.CardMap = listofmap
        End If
    End Sub

    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Settings.GrabTime = Grabtime_grabtime.Value
    End Sub

    Private Sub txt_Move_Old_Group_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Move_Old_Group.TextChanged
        Settings.OldChannelFolder = txt_Move_Old_Group.Text
    End Sub

    Private Sub TextBox6_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_frequency.TextChanged
        Settings.frequency = txt_frequency.Text
    End Sub

    Private Sub TextBox10_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_symbol_rate.TextChanged
        Settings.SymbolRate = txt_symbol_rate.Text

    End Sub

    Private Sub TextBox5_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_transportid.TextChanged
        Settings.TransportID = txt_transportid.Text

    End Sub

    Private Sub TextBox4_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_serviceid.TextChanged
        Settings.ServiceID = txt_serviceid.Text
    End Sub

    Private Sub CheckBox8_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_ignorescrambled.CheckedChanged
        Settings.IgnoreScrambled = chk_ignorescrambled.Checked
    End Sub

    Private Sub CheckBox7_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_modnotsetSD.CheckedChanged
        Settings.UseNotSetModSD = chk_modnotsetSD.Checked
    End Sub

    Private Sub chk_AutoUpdate_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_AutoUpdate.CheckedChanged
        Settings.UpdateChannels = chk_AutoUpdate.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_updateEPG.CheckedChanged
        Settings.UpdateEPG = chk_updateEPG.Checked
    End Sub

    Private Sub chk_SkyNumbers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_SkyNumbers.CheckedChanged
        Settings.UseSkyNumbers = chk_SkyNumbers.Checked
    End Sub

    Private Sub chk_SkyCategories_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_SkyCategories.CheckedChanged
        Settings.UseSkyCategories = chk_SkyCategories.Checked
    End Sub

    Private Sub chk_SkyRegions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_SkyRegions.CheckedChanged
        Settings.UseSkyRegions = chk_SkyRegions.Checked
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_replaceSDwithHD.CheckedChanged
        Settings.ReplaceSDwithHD = chk_replaceSDwithHD.Checked
    End Sub

    Private Sub CheckBox3_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_extrainfo.CheckedChanged
        Settings.useExtraInfo = chk_extrainfo.Checked
    End Sub

    Private Sub chk_DeleteOld_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_DeleteOld.CheckedChanged
        If chk_DeleteOld.Checked Then
            chk_MoveOld.Checked = False
            Settings.DeleteOldChannels = True
        End If
    End Sub

    Private Sub chk_MoveOld_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_MoveOld.CheckedChanged
        If chk_MoveOld.Checked Then
            chk_DeleteOld.Checked = False
            Settings.DeleteOldChannels = False
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_modnotsetHD.CheckedChanged
        Settings.UseNotSetModHD = chk_modnotsetHD.Checked
    End Sub

End Class

Public Class Region

    Dim _BouquetID As Integer
    Dim _RegionID As Integer
    Public Property BouquetID() As Integer
        Get
            Return _BouquetID
        End Get
        Set(ByVal value As Integer)
            _BouquetID = value
        End Set
    End Property

    Public Property RegionID() As Integer
        Get
            Return _RegionID
        End Get
        Set(ByVal value As Integer)
            _RegionID = value
        End Set
    End Property
End Class