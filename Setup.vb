
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports Microsoft.VisualBasic.CompilerServices
Imports SetupTv
Imports TvDatabase
Imports TvControl
Imports TvLibrary.Interfaces
Imports TvLibrary.Log
Imports Microsoft.VisualBasic


Public Class Setup
    Inherits SectionSettings
    Dim WithEvents Grabber As SkyGrabber
    Dim Settings As New Settings

    Private WithEvents SkyIT_Tab As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents skyUKContainer As System.Windows.Forms.GroupBox
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents SkyUK_Region As System.Windows.Forms.ComboBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
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
    Friend WithEvents Button4 As System.Windows.Forms.Button
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
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Sun As System.Windows.Forms.CheckBox
    Friend WithEvents Sat As System.Windows.Forms.CheckBox
    Friend WithEvents Fri As System.Windows.Forms.CheckBox
    Friend WithEvents Thu As System.Windows.Forms.CheckBox
    Friend WithEvents Wed As System.Windows.Forms.CheckBox
    Friend WithEvents Tue As System.Windows.Forms.CheckBox
    Friend WithEvents Mon As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ChannelMap As System.Windows.Forms.CheckedListBox
    Private WithEvents MpGroupBox2 As MediaPortal.UserInterface.Controls.MPGroupBox
    Private WithEvents MpGroupBox1 As MediaPortal.UserInterface.Controls.MPGroupBox
    Private WithEvents MpLabel1 As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents mpDisEqc1 As MediaPortal.UserInterface.Controls.MPComboBox
    Private WithEvents MpLabel6 As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents MpComboBox1 As MediaPortal.UserInterface.Controls.MPComboBox
    Private WithEvents MpLabel8 As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents MpComboBox2 As MediaPortal.UserInterface.Controls.MPComboBox
    Private WithEvents MpLabel3 As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents TextBox4 As System.Windows.Forms.TextBox
    Private WithEvents MpLabel4 As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents TextBox5 As System.Windows.Forms.TextBox
    Private WithEvents TextBox6 As System.Windows.Forms.TextBox
    Private WithEvents MpLabel5 As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents TextBox10 As System.Windows.Forms.TextBox
    Private WithEvents MpLabel9 As MediaPortal.UserInterface.Controls.MPLabel
    Private WithEvents MpLabel10 As MediaPortal.UserInterface.Controls.MPLabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Private WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Private WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Private WithEvents chk_DeleteOld As System.Windows.Forms.RadioButton
    Private WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Private WithEvents chk_MoveOld As System.Windows.Forms.RadioButton
    Private WithEvents txt_Move_Old_Group As System.Windows.Forms.TextBox
    Private WithEvents chk_AutoUpdate As System.Windows.Forms.CheckBox
    Private WithEvents chk_SkyCategories As System.Windows.Forms.CheckBox
    Private WithEvents chk_SkyNumbers As System.Windows.Forms.CheckBox
    Private WithEvents chk_SkyRegions As System.Windows.Forms.CheckBox
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Private WithEvents listViewStatus As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents CheckBox9 As System.Windows.Forms.CheckBox
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
        Me.SkyIT_Tab = New System.Windows.Forms.TabControl()
        Me.tabPage3 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.listViewStatus = New System.Windows.Forms.ListView()
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.chk_DeleteOld = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chk_MoveOld = New System.Windows.Forms.RadioButton()
        Me.txt_Move_Old_Group = New System.Windows.Forms.TextBox()
        Me.chk_AutoUpdate = New System.Windows.Forms.CheckBox()
        Me.chk_SkyCategories = New System.Windows.Forms.CheckBox()
        Me.chk_SkyNumbers = New System.Windows.Forms.CheckBox()
        Me.chk_SkyRegions = New System.Windows.Forms.CheckBox()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.skyUKContainer = New System.Windows.Forms.GroupBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
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
        Me.SkyUK_Region = New System.Windows.Forms.ComboBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.MpGroupBox2 = New MediaPortal.UserInterface.Controls.MPGroupBox()
        Me.ChannelMap = New System.Windows.Forms.CheckedListBox()
        Me.MpGroupBox1 = New MediaPortal.UserInterface.Controls.MPGroupBox()
        Me.MpLabel1 = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.mpDisEqc1 = New MediaPortal.UserInterface.Controls.MPComboBox()
        Me.MpLabel6 = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.MpComboBox1 = New MediaPortal.UserInterface.Controls.MPComboBox()
        Me.MpLabel8 = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.MpComboBox2 = New MediaPortal.UserInterface.Controls.MPComboBox()
        Me.MpLabel3 = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.MpLabel4 = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.MpLabel5 = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.MpLabel9 = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.MpLabel10 = New MediaPortal.UserInterface.Controls.MPLabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.Sun = New System.Windows.Forms.CheckBox()
        Me.Sat = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Fri = New System.Windows.Forms.CheckBox()
        Me.Mon = New System.Windows.Forms.CheckBox()
        Me.Thu = New System.Windows.Forms.CheckBox()
        Me.Tue = New System.Windows.Forms.CheckBox()
        Me.Wed = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SkyIT_Tab.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.skyUKContainer.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.MpGroupBox2.SuspendLayout()
        Me.MpGroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'SkyIT_Tab
        '
        Me.SkyIT_Tab.Controls.Add(Me.tabPage3)
        Me.SkyIT_Tab.Controls.Add(Me.TabPage6)
        Me.SkyIT_Tab.Controls.Add(Me.tabPage1)
        Me.SkyIT_Tab.Controls.Add(Me.TabPage4)
        Me.SkyIT_Tab.Controls.Add(Me.TabPage2)
        Me.SkyIT_Tab.Controls.Add(Me.TabPage5)
        Me.SkyIT_Tab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SkyIT_Tab.Location = New System.Drawing.Point(0, 0)
        Me.SkyIT_Tab.Name = "SkyIT_Tab"
        Me.SkyIT_Tab.SelectedIndex = 0
        Me.SkyIT_Tab.Size = New System.Drawing.Size(456, 422)
        Me.SkyIT_Tab.TabIndex = 3
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.Label10)
        Me.tabPage3.Controls.Add(Me.Label9)
        Me.tabPage3.Controls.Add(Me.NumericUpDown2)
        Me.tabPage3.Controls.Add(Me.listViewStatus)
        Me.tabPage3.Controls.Add(Me.Button1)
        Me.tabPage3.Location = New System.Drawing.Point(4, 22)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage3.Size = New System.Drawing.Size(448, 396)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "General"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(127, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 189
        Me.Label10.Text = "Seconds"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 188
        Me.Label9.Text = "Grab Time"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(68, 9)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(53, 20)
        Me.NumericUpDown2.TabIndex = 187
        Me.NumericUpDown2.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'listViewStatus
        '
        Me.listViewStatus.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1})
        Me.listViewStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.listViewStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.listViewStatus.Location = New System.Drawing.Point(3, 35)
        Me.listViewStatus.Name = "listViewStatus"
        Me.listViewStatus.Size = New System.Drawing.Size(442, 322)
        Me.listViewStatus.TabIndex = 179
        Me.listViewStatus.UseCompatibleStateImageBehavior = False
        Me.listViewStatus.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Width = 415
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Button1.Location = New System.Drawing.Point(3, 357)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(442, 36)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Grab Now"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.Panel2)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(448, 396)
        Me.TabPage6.TabIndex = 6
        Me.TabPage6.Text = "Settings"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CheckBox9)
        Me.Panel2.Controls.Add(Me.CheckBox8)
        Me.Panel2.Controls.Add(Me.CheckBox7)
        Me.Panel2.Controls.Add(Me.CheckBox3)
        Me.Panel2.Controls.Add(Me.label8)
        Me.Panel2.Controls.Add(Me.CheckBox2)
        Me.Panel2.Controls.Add(Me.chk_DeleteOld)
        Me.Panel2.Controls.Add(Me.CheckBox1)
        Me.Panel2.Controls.Add(Me.chk_MoveOld)
        Me.Panel2.Controls.Add(Me.txt_Move_Old_Group)
        Me.Panel2.Controls.Add(Me.chk_AutoUpdate)
        Me.Panel2.Controls.Add(Me.chk_SkyCategories)
        Me.Panel2.Controls.Add(Me.chk_SkyNumbers)
        Me.Panel2.Controls.Add(Me.chk_SkyRegions)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(442, 390)
        Me.Panel2.TabIndex = 185
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(3, 192)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(239, 17)
        Me.CheckBox9.TabIndex = 191
        Me.CheckBox9.Text = "Set Modulation to ""Not Set"" for HD Channels"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(3, 215)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(156, 17)
        Me.CheckBox8.TabIndex = 190
        Me.CheckBox8.Text = "Ignore Scrambled Channels"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(3, 169)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(238, 17)
        Me.CheckBox7.TabIndex = 189
        Me.CheckBox7.Text = "Set Modulation to ""Not Set"" for SD Channels"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(3, 146)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(251, 17)
        Me.CheckBox3.TabIndex = 188
        Me.CheckBox3.Text = "Include Extra Program Info ([HD],[SUB],[W] etc)"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 246)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(89, 13)
        Me.label8.TabIndex = 172
        Me.label8.Text = "Expired Channels"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(3, 35)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(86, 17)
        Me.CheckBox2.TabIndex = 183
        Me.CheckBox2.Text = "Update EPG"
        Me.CheckBox2.UseVisualStyleBackColor = True
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
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(3, 123)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(172, 17)
        Me.CheckBox1.TabIndex = 182
        Me.CheckBox1.Text = "Replace SD Channels with HD"
        Me.CheckBox1.UseVisualStyleBackColor = True
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
        Me.tabPage1.Controls.Add(Me.skyUKContainer)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(448, 396)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Region / Groups"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'skyUKContainer
        '
        Me.skyUKContainer.Controls.Add(Me.groupBox1)
        Me.skyUKContainer.Controls.Add(Me.groupBox3)
        Me.skyUKContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.skyUKContainer.Location = New System.Drawing.Point(3, 3)
        Me.skyUKContainer.Name = "skyUKContainer"
        Me.skyUKContainer.Size = New System.Drawing.Size(442, 390)
        Me.skyUKContainer.TabIndex = 177
        Me.skyUKContainer.TabStop = False
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.Button4)
        Me.groupBox1.Controls.Add(Me.Label15)
        Me.groupBox1.Controls.Add(Me.CatText20)
        Me.groupBox1.Controls.Add(Me.CatByte20)
        Me.groupBox1.Controls.Add(Me.Label16)
        Me.groupBox1.Controls.Add(Me.Label17)
        Me.groupBox1.Controls.Add(Me.CatText19)
        Me.groupBox1.Controls.Add(Me.CatByte19)
        Me.groupBox1.Controls.Add(Me.CatText18)
        Me.groupBox1.Controls.Add(Me.CatByte18)
        Me.groupBox1.Controls.Add(Me.Label18)
        Me.groupBox1.Controls.Add(Me.Label19)
        Me.groupBox1.Controls.Add(Me.CatText17)
        Me.groupBox1.Controls.Add(Me.CatByte17)
        Me.groupBox1.Controls.Add(Me.CatText16)
        Me.groupBox1.Controls.Add(Me.CatByte16)
        Me.groupBox1.Controls.Add(Me.Label20)
        Me.groupBox1.Controls.Add(Me.CatText15)
        Me.groupBox1.Controls.Add(Me.CatByte15)
        Me.groupBox1.Controls.Add(Me.Label21)
        Me.groupBox1.Controls.Add(Me.Label22)
        Me.groupBox1.Controls.Add(Me.CatText14)
        Me.groupBox1.Controls.Add(Me.CatByte14)
        Me.groupBox1.Controls.Add(Me.CatText13)
        Me.groupBox1.Controls.Add(Me.CatByte13)
        Me.groupBox1.Controls.Add(Me.Label23)
        Me.groupBox1.Controls.Add(Me.Label24)
        Me.groupBox1.Controls.Add(Me.CatText12)
        Me.groupBox1.Controls.Add(Me.CatByte12)
        Me.groupBox1.Controls.Add(Me.CatText11)
        Me.groupBox1.Controls.Add(Me.CatByte11)
        Me.groupBox1.Controls.Add(Me.Label5)
        Me.groupBox1.Controls.Add(Me.CatText9)
        Me.groupBox1.Controls.Add(Me.CatByte9)
        Me.groupBox1.Controls.Add(Me.Label11)
        Me.groupBox1.Controls.Add(Me.Label12)
        Me.groupBox1.Controls.Add(Me.CatText7)
        Me.groupBox1.Controls.Add(Me.CatByte7)
        Me.groupBox1.Controls.Add(Me.CatText10)
        Me.groupBox1.Controls.Add(Me.CatByte10)
        Me.groupBox1.Controls.Add(Me.Label13)
        Me.groupBox1.Controls.Add(Me.Label14)
        Me.groupBox1.Controls.Add(Me.CatText6)
        Me.groupBox1.Controls.Add(Me.CatByte6)
        Me.groupBox1.Controls.Add(Me.CatText5)
        Me.groupBox1.Controls.Add(Me.CatByte5)
        Me.groupBox1.Controls.Add(Me.Label7)
        Me.groupBox1.Controls.Add(Me.CatText4)
        Me.groupBox1.Controls.Add(Me.CatByte4)
        Me.groupBox1.Controls.Add(Me.Label3)
        Me.groupBox1.Controls.Add(Me.Label4)
        Me.groupBox1.Controls.Add(Me.CatText8)
        Me.groupBox1.Controls.Add(Me.CatByte8)
        Me.groupBox1.Controls.Add(Me.CatText3)
        Me.groupBox1.Controls.Add(Me.CatByte3)
        Me.groupBox1.Controls.Add(Me.Label2)
        Me.groupBox1.Controls.Add(Me.Label1)
        Me.groupBox1.Controls.Add(Me.CatText2)
        Me.groupBox1.Controls.Add(Me.CatByte2)
        Me.groupBox1.Controls.Add(Me.CatText1)
        Me.groupBox1.Controls.Add(Me.CatByte1)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(3, 65)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(436, 322)
        Me.groupBox1.TabIndex = 174
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Groups"
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Button4.Location = New System.Drawing.Point(3, 285)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(430, 34)
        Me.Button4.TabIndex = 82
        Me.Button4.Text = "Save Changes"
        Me.Button4.UseVisualStyleBackColor = True
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
        Me.CatText15.Text = "Sky Help"
        '
        'CatByte15
        '
        Me.CatByte15.Location = New System.Drawing.Point(237, 117)
        Me.CatByte15.Name = "CatByte15"
        Me.CatByte15.Size = New System.Drawing.Size(39, 20)
        Me.CatByte15.TabIndex = 64
        Me.CatByte15.Text = "16"
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
        Me.CatText14.Text = "Adult"
        '
        'CatByte14
        '
        Me.CatByte14.Location = New System.Drawing.Point(237, 91)
        Me.CatByte14.Name = "CatByte14"
        Me.CatByte14.Size = New System.Drawing.Size(39, 20)
        Me.CatByte14.TabIndex = 60
        Me.CatByte14.Text = "63"
        '
        'CatText13
        '
        Me.CatText13.Location = New System.Drawing.Point(282, 65)
        Me.CatText13.Name = "CatText13"
        Me.CatText13.Size = New System.Drawing.Size(133, 20)
        Me.CatText13.TabIndex = 59
        Me.CatText13.Text = "Specialist"
        '
        'CatByte13
        '
        Me.CatByte13.Location = New System.Drawing.Point(237, 65)
        Me.CatByte13.Name = "CatByte13"
        Me.CatByte13.Size = New System.Drawing.Size(39, 20)
        Me.CatByte13.TabIndex = 58
        Me.CatByte13.Text = "255"
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
        Me.CatText12.Text = "Gaming & Dating"
        '
        'CatByte12
        '
        Me.CatByte12.Location = New System.Drawing.Point(237, 39)
        Me.CatByte12.Name = "CatByte12"
        Me.CatByte12.Size = New System.Drawing.Size(39, 20)
        Me.CatByte12.TabIndex = 54
        Me.CatByte12.Text = "95"
        '
        'CatText11
        '
        Me.CatText11.Location = New System.Drawing.Point(282, 13)
        Me.CatText11.Name = "CatText11"
        Me.CatText11.Size = New System.Drawing.Size(133, 20)
        Me.CatText11.TabIndex = 53
        Me.CatText11.Text = "International"
        '
        'CatByte11
        '
        Me.CatByte11.Location = New System.Drawing.Point(237, 13)
        Me.CatByte11.Name = "CatByte11"
        Me.CatByte11.Size = New System.Drawing.Size(39, 20)
        Me.CatByte11.TabIndex = 52
        Me.CatByte11.Text = "223"
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
        Me.CatText9.Text = "Shopping"
        '
        'CatByte9
        '
        Me.CatByte9.Location = New System.Drawing.Point(27, 221)
        Me.CatByte9.Name = "CatByte9"
        Me.CatByte9.Size = New System.Drawing.Size(39, 20)
        Me.CatByte9.TabIndex = 49
        Me.CatByte9.Text = "48"
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
        Me.CatText7.Text = "Kids"
        '
        'CatByte7
        '
        Me.CatByte7.Location = New System.Drawing.Point(27, 169)
        Me.CatByte7.Name = "CatByte7"
        Me.CatByte7.Size = New System.Drawing.Size(39, 20)
        Me.CatByte7.TabIndex = 45
        Me.CatByte7.Text = "80"
        '
        'CatText10
        '
        Me.CatText10.Location = New System.Drawing.Point(72, 247)
        Me.CatText10.Name = "CatText10"
        Me.CatText10.Size = New System.Drawing.Size(133, 20)
        Me.CatText10.TabIndex = 44
        Me.CatText10.Text = "Religion"
        '
        'CatByte10
        '
        Me.CatByte10.Location = New System.Drawing.Point(27, 247)
        Me.CatByte10.Name = "CatByte10"
        Me.CatByte10.Size = New System.Drawing.Size(39, 20)
        Me.CatByte10.TabIndex = 43
        Me.CatByte10.Text = "191"
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
        Me.CatText6.Text = "Documentaries"
        '
        'CatByte6
        '
        Me.CatByte6.Location = New System.Drawing.Point(27, 143)
        Me.CatByte6.Name = "CatByte6"
        Me.CatByte6.Size = New System.Drawing.Size(39, 20)
        Me.CatByte6.TabIndex = 39
        Me.CatByte6.Text = "127"
        '
        'CatText5
        '
        Me.CatText5.Location = New System.Drawing.Point(72, 117)
        Me.CatText5.Name = "CatText5"
        Me.CatText5.Size = New System.Drawing.Size(133, 20)
        Me.CatText5.TabIndex = 38
        Me.CatText5.Text = "News"
        '
        'CatByte5
        '
        Me.CatByte5.Location = New System.Drawing.Point(27, 117)
        Me.CatByte5.Name = "CatByte5"
        Me.CatByte5.Size = New System.Drawing.Size(39, 20)
        Me.CatByte5.TabIndex = 37
        Me.CatByte5.Text = "176"
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
        Me.CatText4.Text = "Sports"
        '
        'CatByte4
        '
        Me.CatByte4.Location = New System.Drawing.Point(27, 91)
        Me.CatByte4.Name = "CatByte4"
        Me.CatByte4.Size = New System.Drawing.Size(39, 20)
        Me.CatByte4.TabIndex = 32
        Me.CatByte4.Text = "240"
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
        Me.CatText8.Text = "Music"
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
        Me.CatText3.Text = "Movies"
        '
        'CatByte3
        '
        Me.CatByte3.Location = New System.Drawing.Point(27, 65)
        Me.CatByte3.Name = "CatByte3"
        Me.CatByte3.Size = New System.Drawing.Size(39, 20)
        Me.CatByte3.TabIndex = 26
        Me.CatByte3.Text = "208"
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
        Me.CatText2.Text = "Lifestyle & Culture"
        '
        'CatByte2
        '
        Me.CatByte2.Location = New System.Drawing.Point(26, 39)
        Me.CatByte2.Name = "CatByte2"
        Me.CatByte2.Size = New System.Drawing.Size(39, 20)
        Me.CatByte2.TabIndex = 2
        Me.CatByte2.Text = "31"
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
        Me.CatByte1.Text = "112"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.SkyUK_Region)
        Me.groupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox3.Location = New System.Drawing.Point(3, 16)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(436, 49)
        Me.groupBox3.TabIndex = 175
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Region"
        '
        'SkyUK_Region
        '
        Me.SkyUK_Region.DisplayMember = "Sky_UK_Regions.RegionName"
        Me.SkyUK_Region.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SkyUK_Region.FormattingEnabled = True
        Me.SkyUK_Region.Location = New System.Drawing.Point(3, 16)
        Me.SkyUK_Region.Name = "SkyUK_Region"
        Me.SkyUK_Region.Size = New System.Drawing.Size(430, 21)
        Me.SkyUK_Region.TabIndex = 148
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.MpGroupBox2)
        Me.TabPage4.Controls.Add(Me.MpGroupBox1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(448, 396)
        Me.TabPage4.TabIndex = 4
        Me.TabPage4.Text = "Cards / Mapping"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'MpGroupBox2
        '
        Me.MpGroupBox2.Controls.Add(Me.ChannelMap)
        Me.MpGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MpGroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MpGroupBox2.Location = New System.Drawing.Point(3, 118)
        Me.MpGroupBox2.Name = "MpGroupBox2"
        Me.MpGroupBox2.Size = New System.Drawing.Size(442, 275)
        Me.MpGroupBox2.TabIndex = 187
        Me.MpGroupBox2.TabStop = False
        Me.MpGroupBox2.Text = "Select Card(s) for grab and Mapping"
        '
        'ChannelMap
        '
        Me.ChannelMap.AccessibleDescription = "Use this to select the cards you wish to Map your channel searches to."
        Me.ChannelMap.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChannelMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChannelMap.FormattingEnabled = True
        Me.ChannelMap.Location = New System.Drawing.Point(3, 16)
        Me.ChannelMap.Name = "ChannelMap"
        Me.ChannelMap.Size = New System.Drawing.Size(436, 256)
        Me.ChannelMap.TabIndex = 0
        '
        'MpGroupBox1
        '
        Me.MpGroupBox1.Controls.Add(Me.MpLabel1)
        Me.MpGroupBox1.Controls.Add(Me.mpDisEqc1)
        Me.MpGroupBox1.Controls.Add(Me.MpLabel6)
        Me.MpGroupBox1.Controls.Add(Me.MpComboBox1)
        Me.MpGroupBox1.Controls.Add(Me.MpLabel8)
        Me.MpGroupBox1.Controls.Add(Me.MpComboBox2)
        Me.MpGroupBox1.Controls.Add(Me.MpLabel3)
        Me.MpGroupBox1.Controls.Add(Me.TextBox4)
        Me.MpGroupBox1.Controls.Add(Me.MpLabel4)
        Me.MpGroupBox1.Controls.Add(Me.TextBox5)
        Me.MpGroupBox1.Controls.Add(Me.TextBox6)
        Me.MpGroupBox1.Controls.Add(Me.MpLabel5)
        Me.MpGroupBox1.Controls.Add(Me.TextBox10)
        Me.MpGroupBox1.Controls.Add(Me.MpLabel9)
        Me.MpGroupBox1.Controls.Add(Me.MpLabel10)
        Me.MpGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.MpGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MpGroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.MpGroupBox1.Name = "MpGroupBox1"
        Me.MpGroupBox1.Size = New System.Drawing.Size(442, 115)
        Me.MpGroupBox1.TabIndex = 186
        Me.MpGroupBox1.TabStop = False
        Me.MpGroupBox1.Text = "Sky Channel Grabber setting"
        '
        'MpLabel1
        '
        Me.MpLabel1.AutoSize = True
        Me.MpLabel1.Location = New System.Drawing.Point(6, 66)
        Me.MpLabel1.Name = "MpLabel1"
        Me.MpLabel1.Size = New System.Drawing.Size(40, 13)
        Me.MpLabel1.TabIndex = 187
        Me.MpLabel1.Text = "Diseqc"
        '
        'mpDisEqc1
        '
        Me.mpDisEqc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.mpDisEqc1.FormattingEnabled = True
        Me.mpDisEqc1.Items.AddRange(New Object() {"None", "SimpleA", "SimpleB", "Level1AA", "Level1AB", "Level1BA", "Level1BB"})
        Me.mpDisEqc1.Location = New System.Drawing.Point(9, 81)
        Me.mpDisEqc1.Name = "mpDisEqc1"
        Me.mpDisEqc1.Size = New System.Drawing.Size(90, 21)
        Me.mpDisEqc1.TabIndex = 186
        '
        'MpLabel6
        '
        Me.MpLabel6.AutoSize = True
        Me.MpLabel6.Location = New System.Drawing.Point(312, 65)
        Me.MpLabel6.Name = "MpLabel6"
        Me.MpLabel6.Size = New System.Drawing.Size(62, 13)
        Me.MpLabel6.TabIndex = 48
        Me.MpLabel6.Text = "Modulation:"
        '
        'MpComboBox1
        '
        Me.MpComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MpComboBox1.FormattingEnabled = True
        Me.MpComboBox1.Items.AddRange(New Object() {"ModNotSet", "ModNotDefined", "Mod16Qam", "Mod32Qam", "Mod64Qam", "Mod80Qam", "Mod96Qam", "Mod112Qam", "Mod128Qam", "Mod160Qam", "Mod192Qam", "Mod224Qam", "Mod256Qam", "Mod320Qam", "Mod384Qam", "Mod448Qam", "Mod512Qam", "Mod640Qam", "Mod768Qam", "Mod896Qam", "Mod1024Qam", "ModQpsk", "ModBpsk", "ModOqpsk", "Mod8Vsb", "Mod16Vsb", "ModAnalogAmplitude", "ModAnalogFrequency", "Mod8Psk", "ModRF", "Mod16Apsk", "Mod32Apsk", "ModNbcQpsk", "ModNbc8Psk", "ModDirectTv", "ModMax"})
        Me.MpComboBox1.Location = New System.Drawing.Point(315, 81)
        Me.MpComboBox1.Name = "MpComboBox1"
        Me.MpComboBox1.Size = New System.Drawing.Size(92, 21)
        Me.MpComboBox1.TabIndex = 49
        '
        'MpLabel8
        '
        Me.MpLabel8.AutoSize = True
        Me.MpLabel8.Location = New System.Drawing.Point(158, 66)
        Me.MpLabel8.Name = "MpLabel8"
        Me.MpLabel8.Size = New System.Drawing.Size(64, 13)
        Me.MpLabel8.TabIndex = 46
        Me.MpLabel8.Text = "Polarisation:"
        '
        'MpComboBox2
        '
        Me.MpComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MpComboBox2.FormattingEnabled = True
        Me.MpComboBox2.Items.AddRange(New Object() {"Not Set", "Not Defined", "Horizontal", "Vertical", "Circular Left", "Circular Right"})
        Me.MpComboBox2.Location = New System.Drawing.Point(161, 81)
        Me.MpComboBox2.Name = "MpComboBox2"
        Me.MpComboBox2.Size = New System.Drawing.Size(92, 21)
        Me.MpComboBox2.TabIndex = 47
        '
        'MpLabel3
        '
        Me.MpLabel3.AutoSize = True
        Me.MpLabel3.Location = New System.Drawing.Point(342, 16)
        Me.MpLabel3.Name = "MpLabel3"
        Me.MpLabel3.Size = New System.Drawing.Size(57, 13)
        Me.MpLabel3.TabIndex = 105
        Me.MpLabel3.Text = "Service ID"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(345, 32)
        Me.TextBox4.MaxLength = 5
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(63, 20)
        Me.TextBox4.TabIndex = 104
        Me.TextBox4.Text = "4152"
        '
        'MpLabel4
        '
        Me.MpLabel4.AutoSize = True
        Me.MpLabel4.Location = New System.Drawing.Point(230, 16)
        Me.MpLabel4.Name = "MpLabel4"
        Me.MpLabel4.Size = New System.Drawing.Size(66, 13)
        Me.MpLabel4.TabIndex = 103
        Me.MpLabel4.Text = "Transport ID"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(233, 32)
        Me.TextBox5.MaxLength = 5
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(63, 20)
        Me.TextBox5.TabIndex = 102
        Me.TextBox5.Text = "2004"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(9, 32)
        Me.TextBox6.MaxLength = 8
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(63, 20)
        Me.TextBox6.TabIndex = 40
        Me.TextBox6.Text = "11778000"
        '
        'MpLabel5
        '
        Me.MpLabel5.AutoSize = True
        Me.MpLabel5.Location = New System.Drawing.Point(6, 16)
        Me.MpLabel5.Name = "MpLabel5"
        Me.MpLabel5.Size = New System.Drawing.Size(60, 13)
        Me.MpLabel5.TabIndex = 39
        Me.MpLabel5.Text = "Frequency:"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(121, 32)
        Me.TextBox10.MaxLength = 5
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(63, 20)
        Me.TextBox10.TabIndex = 43
        Me.TextBox10.Text = "27500"
        '
        'MpLabel9
        '
        Me.MpLabel9.AutoSize = True
        Me.MpLabel9.Location = New System.Drawing.Point(118, 16)
        Me.MpLabel9.Name = "MpLabel9"
        Me.MpLabel9.Size = New System.Drawing.Size(70, 13)
        Me.MpLabel9.TabIndex = 42
        Me.MpLabel9.Text = "Symbol Rate:"
        '
        'MpLabel10
        '
        Me.MpLabel10.AutoSize = True
        Me.MpLabel10.Location = New System.Drawing.Point(82, 53)
        Me.MpLabel10.Name = "MpLabel10"
        Me.MpLabel10.Size = New System.Drawing.Size(26, 13)
        Me.MpLabel10.TabIndex = 41
        Me.MpLabel10.Text = "kHz"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(448, 396)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Schedule"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.CheckBox4)
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(445, 394)
        Me.Panel3.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.NumericUpDown1)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.CheckBox5)
        Me.Panel1.Controls.Add(Me.CheckBox6)
        Me.Panel1.Controls.Add(Me.Sun)
        Me.Panel1.Controls.Add(Me.Sat)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Fri)
        Me.Panel1.Controls.Add(Me.Mon)
        Me.Panel1.Controls.Add(Me.Thu)
        Me.Panel1.Controls.Add(Me.Tue)
        Me.Panel1.Controls.Add(Me.Wed)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(445, 377)
        Me.Panel1.TabIndex = 13
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(114, 11)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(58, 20)
        Me.NumericUpDown1.TabIndex = 14
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "HH:mm"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(114, 51)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(58, 20)
        Me.DateTimePicker1.TabIndex = 13
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(8, 12)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(53, 17)
        Me.CheckBox5.TabIndex = 1
        Me.CheckBox5.Text = "Every"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(8, 54)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(108, 17)
        Me.CheckBox6.TabIndex = 2
        Me.CheckBox6.Text = "On these days @"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'Sun
        '
        Me.Sun.AutoSize = True
        Me.Sun.Location = New System.Drawing.Point(116, 109)
        Me.Sun.Name = "Sun"
        Me.Sun.Size = New System.Drawing.Size(45, 17)
        Me.Sun.TabIndex = 11
        Me.Sun.Text = "Sun"
        Me.Sun.UseVisualStyleBackColor = True
        '
        'Sat
        '
        Me.Sat.AutoSize = True
        Me.Sat.Location = New System.Drawing.Point(63, 109)
        Me.Sat.Name = "Sat"
        Me.Sat.Size = New System.Drawing.Size(42, 17)
        Me.Sat.TabIndex = 10
        Me.Sat.Text = "Sat"
        Me.Sat.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(173, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "hour(s)"
        '
        'Fri
        '
        Me.Fri.AutoSize = True
        Me.Fri.Location = New System.Drawing.Point(8, 109)
        Me.Fri.Name = "Fri"
        Me.Fri.Size = New System.Drawing.Size(37, 17)
        Me.Fri.TabIndex = 9
        Me.Fri.Text = "Fri"
        Me.Fri.UseVisualStyleBackColor = True
        '
        'Mon
        '
        Me.Mon.AutoSize = True
        Me.Mon.Location = New System.Drawing.Point(8, 86)
        Me.Mon.Name = "Mon"
        Me.Mon.Size = New System.Drawing.Size(47, 17)
        Me.Mon.TabIndex = 5
        Me.Mon.Text = "Mon"
        Me.Mon.UseVisualStyleBackColor = True
        '
        'Thu
        '
        Me.Thu.AutoSize = True
        Me.Thu.Location = New System.Drawing.Point(173, 86)
        Me.Thu.Name = "Thu"
        Me.Thu.Size = New System.Drawing.Size(45, 17)
        Me.Thu.TabIndex = 8
        Me.Thu.Text = "Thu"
        Me.Thu.UseVisualStyleBackColor = True
        '
        'Tue
        '
        Me.Tue.AutoSize = True
        Me.Tue.Location = New System.Drawing.Point(63, 86)
        Me.Tue.Name = "Tue"
        Me.Tue.Size = New System.Drawing.Size(45, 17)
        Me.Tue.TabIndex = 6
        Me.Tue.Text = "Tue"
        Me.Tue.UseVisualStyleBackColor = True
        '
        'Wed
        '
        Me.Wed.AutoSize = True
        Me.Wed.Location = New System.Drawing.Point(116, 86)
        Me.Wed.Name = "Wed"
        Me.Wed.Size = New System.Drawing.Size(49, 17)
        Me.Wed.TabIndex = 7
        Me.Wed.Text = "Wed"
        Me.Wed.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.CheckBox4.Location = New System.Drawing.Point(0, 0)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(445, 17)
        Me.CheckBox4.TabIndex = 0
        Me.CheckBox4.Text = "Enabled"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.TextBox1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(448, 396)
        Me.TabPage5.TabIndex = 5
        Me.TabPage5.Text = "Change Log"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(3, 3)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(442, 390)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Setup
        '
        Me.Controls.Add(Me.SkyIT_Tab)
        Me.Name = "Setup"
        Me.Size = New System.Drawing.Size(456, 422)
        Me.SkyIT_Tab.ResumeLayout(False)
        Me.tabPage3.ResumeLayout(False)
        Me.tabPage3.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tabPage1.ResumeLayout(False)
        Me.skyUKContainer.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.MpGroupBox2.ResumeLayout(False)
        Me.MpGroupBox1.ResumeLayout(False)
        Me.MpGroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private Sub AddLog(ByVal Value As String, ByVal UpdateLast As Boolean)
        If UpdateLast = True Then
            listViewStatus.Items(listViewStatus.Items.Count - 1).Text = Value
        Else
            listViewStatus.Items.Add(Value)
        End If
        listViewStatus.Items(listViewStatus.Items.Count - 1).EnsureVisible()
    End Sub

    Private Sub SetBool(ByVal value As Boolean)
        Panel2.Enabled = value
    End Sub

    Private Sub SetBool22(ByVal value As Boolean)
        skyUKContainer.Enabled = value
    End Sub

    Private Sub SetBool33(ByVal value As Boolean)
        MpGroupBox1.Enabled = value
    End Sub

    Private Sub SetBool44(ByVal value As Boolean)
        MpGroupBox2.Enabled = value
    End Sub

    Private Sub SetBool55(ByVal value As Boolean)
        Panel3.Enabled = value
    End Sub

    Private Sub SetBool66(ByVal value As Boolean)
        Button1.Enabled = value
    End Sub

    Sub active() Handles Grabber.OnActivateControls
        Dim param(0) As Boolean
        param(0) = True
        Try
            Panel2.Invoke(Bool1, param(0))
            skyUKContainer.Invoke(Bool2, param(0))
            MpGroupBox1.Invoke(Bool3, param(0))
            MpGroupBox2.Invoke(Bool4, param(0))
            Panel3.Invoke(Bool5, param(0))
            Button1.Invoke(Bool6, param(0))
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not Settings.IsGrabbing Then
            listViewStatus.Items.Clear()
            Dim param(0) As Boolean
            param(0) = False
            Try
                Panel2.Invoke(Bool1, param(0))
                skyUKContainer.Invoke(Bool2, param(0))
                MpGroupBox1.Invoke(Bool3, param(0))
                MpGroupBox2.Invoke(Bool4, param(0))
                Panel3.Invoke(Bool5, param(0))
                Button1.Invoke(Bool6, param(0))
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
            listViewStatus.Invoke(Log1, param)
            If Not UpdateLast Then
                Log.Write("Sky Plugin : " & Message)
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If CatByte1.Text <> "" And CatByte1.Text <> "0" Then Settings.SetCategory(1, CatByte1.Text, CatText1.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte1.Text = ""
            ProjectData.ClearProjectError()
        End Try

        Try
            If CatByte2.Text <> "" And CatByte2.Text <> "0" Then Settings.SetCategory(2, CatByte2.Text, CatText2.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte2.Text = ""
            ProjectData.ClearProjectError()
        End Try

        Try
            If CatByte3.Text <> "" And CatByte3.Text <> "0" Then Settings.SetCategory(3, CatByte3.Text, CatText3.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte3.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte4.Text <> "" And CatByte4.Text <> "0" Then Settings.SetCategory(4, CatByte4.Text, CatText4.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte4.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte5.Text <> "" And CatByte5.Text <> "0" Then Settings.SetCategory(5, CatByte5.Text, CatText5.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte5.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte6.Text <> "" And CatByte6.Text <> "0" Then Settings.SetCategory(6, CatByte6.Text, CatText6.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte6.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte7.Text <> "" And CatByte7.Text <> "0" Then Settings.SetCategory(7, CatByte7.Text, CatText7.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte7.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte8.Text <> "" And CatByte8.Text <> "0" Then Settings.SetCategory(8, CatByte8.Text, CatText8.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte8.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte9.Text <> "" And CatByte9.Text <> "0" Then Settings.SetCategory(9, CatByte9.Text, CatText9.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte9.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte10.Text <> "" And CatByte10.Text <> "0" Then Settings.SetCategory(10, CatByte10.Text, CatText10.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte10.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte11.Text <> "" And CatByte11.Text <> "0" Then Settings.SetCategory(11, CatByte11.Text, CatText11.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte11.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte12.Text <> "" And CatByte12.Text <> "0" Then Settings.SetCategory(12, CatByte12.Text, Me.CatText12.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte12.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte13.Text <> "" And CatByte13.Text <> "0" Then Settings.SetCategory(13, CatByte13.Text, CatText13.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte13.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte14.Text <> "" And CatByte14.Text <> "0" Then Settings.SetCategory(14, CatByte14.Text, CatText14.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte14.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte15.Text <> "" And CatByte15.Text <> "0" Then Settings.SetCategory(15, CatByte15.Text, CatText15.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte15.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte16.Text <> "" And CatByte16.Text <> "0" Then Settings.SetCategory(16, CatByte16.Text, CatText16.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte16.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte17.Text <> "" And CatByte17.Text <> "0" Then Settings.SetCategory(17, CatByte17.Text, CatText17.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte17.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte18.Text <> "" And CatByte18.Text <> "0" Then Settings.SetCategory(18, CatByte18.Text, CatText18.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte18.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte19.Text <> "" And CatByte19.Text <> "0" Then Settings.SetCategory(19, CatByte19.Text, CatText19.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte19.Text = ""
            ProjectData.ClearProjectError()
        End Try
        Try
            If CatByte20.Text <> "" And CatByte20.Text <> "0" Then Settings.SetCategory(20, CatByte20.Text, CatText20.Text)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            CatByte20.Text = ""
            ProjectData.ClearProjectError()
        End Try
        SaveCatSettings()
    End Sub

    Public Sub LoadSetting()
        Dim layer As New TvBusinessLayer
        Dim str As String
        Dim str2 As String
        If Not Settings.SettingsLoaded Then
            Settings.LoadSettings()
        End If
        Settings.IsLoading = True
        ChannelMap.Items.Clear()
        Dim card As Card
        For Each card In card.ListAll
            Try
                If ((RemoteControl.Instance.Type(card.IdCard) = CardType.DvbS) AndAlso Not ChannelMap.Items.Contains(card.Name)) Then
                    ChannelMap.Items.Add(card.Name)
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError()
            End Try
        Next
        Dim cardMap As List(Of Integer) = Settings.CardMap
        If cardMap.Count > 0 And ChannelMap.Items.Count > 0 Then
            Dim num4 As Integer
            For Each num4 In cardMap
                Try
                    ChannelMap.SetItemChecked(num4, True)
                Catch exception3 As Exception
                    ProjectData.SetProjectError(exception3)
                    ProjectData.ClearProjectError()
                End Try
            Next
        End If
        Settings.IsLoading = False
        layer = Nothing

        Dim reader As New StringReader(My.Settings.Regions)
        Dim list2 As New List(Of String)
        Dim str4 As String
        For Each str4 In My.Settings.Regions.Split(vbNewLine)
            If Not list2.Contains(str4) Then
                list2.Add(str4)
            End If
        Next
        Dim key As Integer = -1
        Dim str5 As String
        For Each str5 In list2
            key += 1
            Dim strArray3 As String() = New String(3 - 1) {}
            Dim strArray4 As String() = New String(3 - 1) {}
            strArray3 = str5.Split("=")
            If Not SkyUK_Region.Items.Contains(strArray3(1)) Then
                SkyUK_Region.Items.Add(strArray3(1))
            End If
            strArray4 = strArray3(0).Split("-")
            Dim region As New Region With {.BouquetID = Val(strArray4(0)), .RegionID = Val(strArray4(1))}
            If Not regions.ContainsKey(key) Then
                regions.Add(key, [region])
            End If
        Next
        TextBox6.Text = Settings.frequency
        chk_AutoUpdate.Checked = Settings.UpdateChannels
        chk_SkyNumbers.Checked = Settings.UseSkyNumbers
        chk_SkyCategories.Checked = Settings.UseSkyCategories
        chk_SkyRegions.Checked = Settings.UseSkyRegions
        chk_DeleteOld.Checked = Settings.DeleteOldChannels
        chk_MoveOld.Checked = Not Settings.DeleteOldChannels
        CheckBox1.Checked = Settings.ReplaceSDwithHD
        CheckBox2.Checked = Settings.UpdateEPG
        txt_Move_Old_Group.Text = Settings.OldChannelFolder
        SkyUK_Region.SelectedIndex = Settings.RegionIndex
        Settings.RegionIndex = SkyUK_Region.SelectedIndex
        TextBox10.Text = Settings.SymbolRate
        TextBox5.Text = Settings.TransportID
        TextBox4.Text = Settings.ServiceID
        mpDisEqc1.SelectedIndex = Settings.DiseqC
        If (mpDisEqc1.SelectedIndex = -1) Then
            mpDisEqc1.SelectedIndex = 0
            Settings.DiseqC = 0
        End If
        MpComboBox2.SelectedIndex = Settings.polarisation
        If (MpComboBox2.SelectedIndex = -1) Then
            MpComboBox2.SelectedIndex = 0
            Settings.polarisation = 0
        End If
        'CheckBox10.Checked = Settings.UpdateLogos
        'CheckBox11.Checked = Settings.UseThrottle
        MpComboBox1.SelectedIndex = Settings.modulation
        If (MpComboBox1.SelectedIndex = -1) Then
            MpComboBox1.SelectedIndex = 0
            Settings.modulation = 0
        End If
        TextBox6.Text = Settings.frequency
        CheckBox4.Checked = Settings.AutoUpdate
        CheckBox5.Checked = Settings.EveryHour
        CheckBox6.Checked = Settings.OnDaysAt
        If (Settings.UpdateInterval = 0) Then
            Settings.UpdateInterval = 1
        End If
        CheckBox3.Checked = Settings.useExtraInfo
        CheckBox7.Checked = Settings.UseNotSetModSD
        CheckBox9.Checked = Settings.UseNotSetModHD
        CheckBox8.Checked = Settings.IgnoreScrambled
        'CheckBox10.Checked = Settings.UpdateLogos
        'CheckBox11.Checked = Settings.UseThrottle
        NumericUpDown2.Value = New Decimal(Settings.GrabTime)
        NumericUpDown1.Value = New Decimal(Settings.UpdateInterval)
        Panel1.Visible = Settings.AutoUpdate
        DateTimePicker1.Value = Settings.UpdateTime
        'TextBox2.Text = Settings.LogoDirectory
        Mon.Checked = Settings.Mon
        Tue.Checked = Settings.Tue
        Wed.Checked = Settings.Wed
        Thu.Checked = Settings.Thu
        Fri.Checked = Settings.Fri
        Sat.Checked = Settings.Sat
        Sun.Checked = Settings.Sun
        Dim separator As String() = New String() {",.,"}
        Dim categoryByTextBoxNum As String = Settings.GetCategoryByTextBoxNum(1)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray5 As String() = New String(3 - 1) {}
            strArray5 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray5(0)
            str2 = strArray5(1)
        End If
        CatByte1.Text = str
        CatText1.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(2)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray6 As String() = New String(3 - 1) {}
            strArray6 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray6(0)
            str2 = strArray6(1)
        End If
        CatByte2.Text = str
        CatText2.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(3)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray7 As String() = New String(3 - 1) {}
            strArray7 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray7(0)
            str2 = strArray7(1)
        End If
        CatByte3.Text = str
        CatText3.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(4)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray8 As String() = New String(3 - 1) {}
            strArray8 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray8(0)
            str2 = strArray8(1)
        End If
        CatByte4.Text = str
        CatText4.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(5)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray9 As String() = New String(3 - 1) {}
            strArray9 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray9(0)
            str2 = strArray9(1)
        End If
        CatByte5.Text = str
        CatText5.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(6)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray10 As String() = New String(3 - 1) {}
            strArray10 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray10(0)
            str2 = strArray10(1)
        End If
        CatByte6.Text = str
        CatText6.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(7)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray11 As String() = New String(3 - 1) {}
            strArray11 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray11(0)
            str2 = strArray11(1)
        End If
        CatByte7.Text = str
        CatText7.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(8)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray12 As String() = New String(3 - 1) {}
            strArray12 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray12(0)
            str2 = strArray12(1)
        End If
        CatByte8.Text = str
        CatText8.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(9)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray13 As String() = New String(3 - 1) {}
            strArray13 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray13(0)
            str2 = strArray13(1)
        End If
        CatByte9.Text = str
        CatText9.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(10)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray14 As String() = New String(3 - 1) {}
            strArray14 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray14(0)
            str2 = strArray14(1)
        End If
        CatByte10.Text = str
        CatText10.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(11)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray15 As String() = New String(3 - 1) {}
            strArray15 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray15(0)
            str2 = strArray15(1)
        End If
        CatByte11.Text = str
        CatText11.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(12)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray16 As String() = New String(3 - 1) {}
            strArray16 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray16(0)
            str2 = strArray16(1)
        End If
        CatByte12.Text = str
        CatText12.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(13)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray17 As String() = New String(3 - 1) {}
            strArray17 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray17(0)
            str2 = strArray17(1)
        End If
        CatByte13.Text = str
        CatText13.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(14)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray18 As String() = New String(3 - 1) {}
            strArray18 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray18(0)
            str2 = strArray18(1)
        End If
        CatByte14.Text = str
        CatText14.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(15)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray19 As String() = New String(3 - 1) {}
            strArray19 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray19(0)
            str2 = strArray19(1)
        End If
        CatByte15.Text = str
        CatText15.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(&H10)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray20 As String() = New String(3 - 1) {}
            strArray20 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray20(0)
            str2 = strArray20(1)
        End If
        CatByte16.Text = str
        CatText16.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(&H11)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray21 As String() = New String(3 - 1) {}
            strArray21 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray21(0)
            str2 = strArray21(1)
        End If
        CatByte17.Text = str
        CatText17.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(&H12)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray22 As String() = New String(3 - 1) {}
            strArray22 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray22(0)
            str2 = strArray22(1)
        End If
        CatByte18.Text = str
        CatText18.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(&H13)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray23 As String() = New String(3 - 1) {}
            strArray23 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray23(0)
            str2 = strArray23(1)
        End If
        CatByte19.Text = str
        CatText19.Text = str2
        categoryByTextBoxNum = Settings.GetCategoryByTextBoxNum(20)
        If (categoryByTextBoxNum = "-1,., ") Then
            str = ""
            str2 = ""
        Else
            Dim strArray24 As String() = New String(3 - 1) {}
            strArray24 = categoryByTextBoxNum.Split(separator, StringSplitOptions.None)
            str = strArray24(0)
            str2 = strArray24(1)
        End If
        CatByte20.Text = str
        CatText20.Text = str2
        Settings.IsLoading = False
    End Sub
    'Sub LoadSetting()
    '    Dim layer As New TvBusinessLayer()
    '    Dim id As Integer = -1
    '    Dim checker As Integer = 0
    '    For Each card_1 As Card In Card.ListAll()
    '        If RemoteControl.Instance.Type(card_1.IdCard) = CardType.DvbS Then
    '            ChannelMap.Items.Add(card_1.Name)
    '        End If
    '    Next
    '    Settings.IsLoading = True
    '    Dim listofmap As List(Of Integer) = Settings.CardMap
    '    If listofmap.Count > 0 And ChannelMap.Items.Count > 0 Then
    '        For Each num In listofmap
    '            Try
    '                ChannelMap.SetItemChecked(num, True)
    '            Catch ex As Exception

    '            End Try
    '        Next
    '    End If
    '    Settings.IsLoading = False
    '    layer = Nothing

    '    Dim rr As New IO.StringReader(My.Settings.Regions)
    '    Dim ttt As New List(Of String)
    '    Dim lines() As String = My.Settings.Regions.Split(vbNewLine)
    '    For Each str As String In lines
    '        ttt.Add(str)
    '    Next

    '    Dim trt As Integer = -1
    '    For Each yt As String In ttt
    '        trt += 1
    '        Dim split(2) As String
    '        Dim Split2(2) As String
    '        split = yt.Split("=")
    '        SkyUK_Region.Items.Add(split(1))
    '        Split2 = split(0).Split("-")
    '        Dim bad As New Region
    '        bad.BouquetID = Val(Split2(0))
    '        bad.RegionID = Val(Split2(1))
    '        regions.Add(trt, bad)
    '    Next

    '    If Settings.GetSkySetting(CatByte1.Name, CatByte1.Text) = "-1" Then
    '        CatByte1.Text = ""
    '        CatText1.Text = ""
    '    Else
    '        CatByte1.Text = Settings.GetSkySetting(CatByte1.Name, "-1")
    '        CatText1.Text = Settings.GetSkySetting(CatText1.Name, CatText1.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte2.Name, CatByte2.Text) = "-1" Then
    '        CatByte2.Text = ""
    '        CatText2.Text = ""
    '    Else
    '        CatByte2.Text = Settings.GetSkySetting(CatByte2.Name, "-1")
    '        CatText2.Text = Settings.GetSkySetting(CatText2.Name, CatText2.Text)
    '    End If


    '    If Settings.GetSkySetting(CatByte3.Name, CatByte3.Text) = "-1" Then
    '        CatByte3.Text = ""
    '        CatText3.Text = ""
    '    Else
    '        CatByte3.Text = Settings.GetSkySetting(CatByte3.Name, "-1")
    '        CatText3.Text = Settings.GetSkySetting(CatText3.Name, CatText3.Text)
    '    End If
    '    If Settings.GetSkySetting(CatByte4.Name, CatByte4.Text) = "-1" Then
    '        CatByte4.Text = ""
    '        CatText4.Text = ""
    '    Else
    '        CatByte4.Text = Settings.GetSkySetting(CatByte4.Name, "-1")
    '        CatText4.Text = Settings.GetSkySetting(CatText4.Name, CatText4.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte5.Name, CatByte5.Text) = "-1" Then
    '        CatByte5.Text = ""
    '        CatText5.Text = ""
    '    Else
    '        CatByte5.Text = Settings.GetSkySetting(CatByte5.Name, "-1")
    '        CatText5.Text = Settings.GetSkySetting(CatText5.Name, CatText5.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte6.Name, CatByte6.Text) = "-1" Then
    '        CatByte6.Text = ""
    '        CatText6.Text = ""
    '    Else
    '        CatByte6.Text = Settings.GetSkySetting(CatByte6.Name, "-1")
    '        CatText6.Text = Settings.GetSkySetting(CatText6.Name, CatText6.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte7.Name, CatByte7.Text) = "-1" Then
    '        CatByte7.Text = ""
    '        CatText7.Text = ""
    '    Else
    '        CatByte7.Text = Settings.GetSkySetting(CatByte7.Name, "-1")
    '        CatText7.Text = Settings.GetSkySetting(CatText7.Name, CatText7.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte8.Name, CatByte8.Text) = "-1" Then
    '        CatByte8.Text = ""
    '        CatText8.Text = ""
    '    Else
    '        CatByte8.Text = Settings.GetSkySetting(CatByte8.Name, "-1")
    '        CatText8.Text = Settings.GetSkySetting(CatText8.Name, CatText8.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte9.Name, CatByte9.Text) = "-1" Then
    '        CatByte9.Text = ""
    '        CatText9.Text = ""
    '    Else
    '        CatByte9.Text = Settings.GetSkySetting(CatByte9.Name, "-1")
    '        CatText9.Text = Settings.GetSkySetting(CatText9.Name, CatText9.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte10.Name, CatByte10.Text) = "-1" Then
    '        CatByte10.Text = ""
    '        CatText10.Text = ""
    '    Else
    '        CatByte10.Text = Settings.GetSkySetting(CatByte10.Name, "-1")
    '        CatText10.Text = Settings.GetSkySetting(CatText10.Name, CatText10.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte11.Name, CatByte11.Text) = "-1" Then
    '        CatByte11.Text = ""
    '        CatText11.Text = ""
    '    Else
    '        CatByte11.Text = Settings.GetSkySetting(CatByte11.Name, "-1")
    '        CatText11.Text = Settings.GetSkySetting(CatText11.Name, CatText11.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte12.Name, CatByte12.Text) = "-1" Then
    '        CatByte12.Text = ""
    '        CatText12.Text = ""
    '    Else
    '        CatByte12.Text = Settings.GetSkySetting(CatByte12.Name, "-1")
    '        CatText12.Text = Settings.GetSkySetting(CatText12.Name, CatText12.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte13.Name, CatByte13.Text) = "-1" Then
    '        CatByte13.Text = ""
    '        CatText13.Text = ""
    '    Else
    '        CatByte13.Text = Settings.GetSkySetting(CatByte13.Name, "-1")
    '        CatText13.Text = Settings.GetSkySetting(CatText13.Name, CatText13.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte14.Name, CatByte14.Text) = "-1" Then
    '        CatByte14.Text = ""
    '        CatText14.Text = ""
    '    Else
    '        CatByte14.Text = Settings.GetSkySetting(CatByte14.Name, "-1")
    '        CatText14.Text = Settings.GetSkySetting(CatText14.Name, CatText14.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte15.Name, CatByte15.Text) = "-1" Then
    '        CatByte15.Text = ""
    '        CatText15.Text = ""
    '    Else
    '        CatByte15.Text = Settings.GetSkySetting(CatByte15.Name, "-1")
    '        CatText15.Text = Settings.GetSkySetting(CatText15.Name, CatText15.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte16.Name, CatByte16.Text) = "-1" Then
    '        CatByte16.Text = ""
    '        CatText16.Text = ""
    '    Else
    '        CatByte16.Text = Settings.GetSkySetting(CatByte16.Name, "-1")
    '        CatText16.Text = Settings.GetSkySetting(CatText16.Name, CatText16.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte17.Name, CatByte17.Text) = "-1" Then
    '        CatByte17.Text = ""
    '        CatText17.Text = ""
    '    Else
    '        CatByte17.Text = Settings.GetSkySetting(CatByte17.Name, "-1")
    '        CatText17.Text = Settings.GetSkySetting(CatText17.Name, CatText17.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte18.Name, CatByte18.Text) = "-1" Then
    '        CatByte18.Text = ""
    '        CatText18.Text = ""
    '    Else
    '        CatByte18.Text = Settings.GetSkySetting(CatByte18.Name, "-1")
    '        CatText18.Text = Settings.GetSkySetting(CatText18.Name, CatText18.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte19.Name, CatByte19.Text) = "-1" Then
    '        CatByte19.Text = ""
    '        CatText19.Text = ""
    '    Else
    '        CatByte19.Text = Settings.GetSkySetting(CatByte19.Name, "-1")
    '        CatText19.Text = Settings.GetSkySetting(CatText19.Name, CatText19.Text)
    '    End If

    '    If Settings.GetSkySetting(CatByte20.Name, CatByte20.Text) = "-1" Then
    '        CatByte20.Text = ""
    '        CatText20.Text = ""
    '    Else
    '        CatByte20.Text = Settings.GetSkySetting(CatByte20.Name, "-1")
    '        CatText20.Text = Settings.GetSkySetting(CatText20.Name, CatText20.Text)
    '    End If
    '    TextBox6.Text = Settings.frequency
    '    chk_AutoUpdate.Checked = Settings.UpdateChannels
    '    chk_SkyNumbers.Checked = Settings.UseSkyNumbers
    '    chk_SkyCategories.Checked = Settings.UseSkyCategories
    '    chk_SkyRegions.Checked = Settings.UseSkyRegions
    '    chk_DeleteOld.Checked = Settings.DeleteOldChannels
    '    chk_MoveOld.Checked = Not Settings.DeleteOldChannels
    '    CheckBox1.Checked = Settings.ReplaceSDwithHD
    '    CheckBox2.Checked = Settings.UpdateEPG
    '    'TextBox1.Text = Settings.SwitchingFrequency
    '    txt_Move_Old_Group.Text = Settings.OldChannelFolder
    '    SkyUK_Region.SelectedIndex = Settings.RegionIndex
    '    Settings.RegionIndex = SkyUK_Region.SelectedIndex
    '    TextBox10.Text = Settings.SymbolRate
    '    TextBox5.Text = Settings.TransportID
    '    TextBox4.Text = Settings.ServiceID
    '    mpDisEqc1.SelectedIndex = Settings.DiseqC
    '    If mpDisEqc1.SelectedIndex = -1 Then
    '        mpDisEqc1.SelectedIndex = 0
    '        Settings.DiseqC = 0
    '    End If
    '    MpComboBox2.SelectedIndex = Settings.polarisation
    '    If MpComboBox2.SelectedIndex = -1 Then
    '        MpComboBox2.SelectedIndex = 0
    '        Settings.polarisation = 0
    '    End If
    '    MpComboBox1.SelectedIndex = Settings.modulation
    '    If MpComboBox1.SelectedIndex = -1 Then
    '        MpComboBox1.SelectedIndex = 0
    '        Settings.modulation = 0
    '    End If
    '    TextBox6.Text = Settings.frequency
    '    CheckBox4.Checked = Settings.AutoUpdate
    '    CheckBox5.Checked = Settings.EveryHour
    '    CheckBox6.Checked = Settings.OnDaysAt
    '    If Settings.UpdateInterval = 0 Then
    '        Settings.UpdateInterval = 1
    '    End If
    '    CheckBox3.Checked = Settings.useExtraInfo
    '    CheckBox7.Checked = Settings.UseNotSetModSD
    '    CheckBox9.Checked = Settings.UseNotSetModHD
    '    CheckBox8.Checked = Settings.IgnoreScrambled

    '    NumericUpDown2.Value = Settings.GrabTime
    '    NumericUpDown1.Value = Settings.UpdateInterval
    '    Panel1.Visible = Settings.AutoUpdate
    '    DateTimePicker1.Value = Settings.UpdateTime

    '    Mon.Checked = Settings.Mon
    '    Tue.Checked = Settings.Tue
    '    Wed.Checked = Settings.Wed
    '    Thu.Checked = Settings.Thu
    '    Fri.Checked = Settings.Fri
    '    Sat.Checked = Settings.Sat
    '    Sun.Checked = Settings.Sun

    '    If CatByte1.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte1.Text), CatText1.Text)
    '    If CatByte2.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte2.Text), CatText2.Text)
    '    If CatByte3.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte3.Text), CatText3.Text)
    '    If CatByte8.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte8.Text), CatText8.Text)
    '    If CatByte4.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte4.Text), CatText4.Text)
    '    If CatByte5.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte5.Text), CatText5.Text)
    '    If CatByte6.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte6.Text), CatText6.Text)
    '    If CatByte10.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte10.Text), CatText10.Text)
    '    If CatByte7.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte7.Text), CatText7.Text)
    '    If CatByte9.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte9.Text), CatText9.Text)
    '    If CatByte11.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte11.Text), CatText11.Text)
    '    If CatByte12.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte12.Text), CatText12.Text)
    '    If CatByte13.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte13.Text), CatText13.Text)
    '    If CatByte14.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte14.Text), CatText14.Text)
    '    If CatByte15.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte15.Text), CatText15.Text)
    '    If CatByte16.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte16.Text), CatText16.Text)
    '    If CatByte17.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte17.Text), CatText17.Text)
    '    If CatByte18.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte18.Text), CatText18.Text)
    '    If CatByte19.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte19.Text), CatText19.Text)
    '    If CatByte20.Text <> "" Then Settings.SetCategory(Convert.ToInt32(CatByte11.Text), CatText20.Text)
    'End Sub

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

    Private Sub SkyUK_Region_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SkyUK_Region.SelectedIndexChanged
        Dim region As Region = regions(SkyUK_Region.SelectedIndex)
        Settings.RegionID = region.RegionID
        Settings.BouquetID = region.BouquetID
        Settings.RegionIndex = SkyUK_Region.SelectedIndex
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Settings.SymbolRate = TextBox10.Text
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Settings.TransportID = TextBox5.Text

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Settings.ServiceID = TextBox4.Text
    End Sub

    Private Sub MpComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MpComboBox1.SelectedIndexChanged
        Settings.modulation = MpComboBox1.SelectedIndex
    End Sub

    Private Sub mpDisEqc1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mpDisEqc1.SelectedIndexChanged
        Settings.DiseqC = mpDisEqc1.SelectedIndex
    End Sub

    Private Sub MpComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MpComboBox2.SelectedIndexChanged
        Settings.polarisation = MpComboBox2.SelectedIndex
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Settings.frequency = TextBox6.Text
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        Settings.AutoUpdate = CheckBox4.Checked
        Panel1.Visible = Settings.AutoUpdate
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        Settings.EveryHour = CheckBox5.Checked
        Settings.OnDaysAt = Not CheckBox5.Checked
        CheckBox6.Checked = Not CheckBox5.Checked
        Mon.Enabled = Not CheckBox5.Checked
        Tue.Enabled = Not CheckBox5.Checked
        Wed.Enabled = Not CheckBox5.Checked
        Thu.Enabled = Not CheckBox5.Checked
        Fri.Enabled = Not CheckBox5.Checked
        Sat.Enabled = Not CheckBox5.Checked
        Sun.Enabled = Not CheckBox5.Checked
        DateTimePicker1.Enabled = Not CheckBox5.Checked
        NumericUpDown1.Enabled = CheckBox5.Checked
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        Settings.OnDaysAt = CheckBox6.Checked
        Settings.EveryHour = Not CheckBox6.Checked
        CheckBox5.Checked = Not CheckBox6.Checked
        Mon.Enabled = Not CheckBox5.Checked
        Tue.Enabled = Not CheckBox5.Checked
        Wed.Enabled = Not CheckBox5.Checked
        Thu.Enabled = Not CheckBox5.Checked
        Fri.Enabled = Not CheckBox5.Checked
        Sat.Enabled = Not CheckBox5.Checked
        Sun.Enabled = Not CheckBox5.Checked
        DateTimePicker1.Enabled = Not CheckBox5.Checked
        NumericUpDown1.Enabled = CheckBox5.Checked
    End Sub

    Private Sub Mon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mon.CheckedChanged
        Settings.Mon = Mon.Checked
    End Sub

    Private Sub Tue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tue.CheckedChanged
        Settings.Tue = Tue.Checked
    End Sub

    Private Sub Wed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Wed.CheckedChanged
        Settings.Wed = Wed.Checked
    End Sub

    Private Sub Thu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Thu.CheckedChanged
        Settings.Thu = Thu.Checked
    End Sub

    Private Sub Fri_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fri.CheckedChanged
        Settings.Fri = Fri.Checked
    End Sub

    Private Sub Sat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sat.CheckedChanged
        Settings.Sat = Sat.Checked
    End Sub

    Private Sub Sun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sun.CheckedChanged
        Settings.Sun = Sun.Checked
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        Settings.UpdateInterval = NumericUpDown1.Value
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Settings.UpdateTime = DateTimePicker1.Value.ToString
    End Sub

    Private Sub ChannelMap_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ChannelMap.ItemCheck
        If Settings.IsLoading = False Then
            Dim listofmap As New List(Of Integer)
            If ChannelMap.Items.Count > 0 Then
                For a As Integer = 0 To ChannelMap.Items.Count - 1
                    Try
                        '   MsgBox(e.Index & " : " & e.NewValue)
                        If e.Index = a Then
                            If (e.NewValue = 1) Then
                                listofmap.Add(a)
                            End If
                        Else
                            If ChannelMap.GetItemChecked(a) Then
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
        Settings.GrabTime = NumericUpDown2.Value
    End Sub

    Private Sub txt_Move_Old_Group_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Move_Old_Group.TextChanged
        Settings.OldChannelFolder = txt_Move_Old_Group.Text
    End Sub

    Private Sub TextBox6_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        Settings.frequency = TextBox6.Text
    End Sub

    Private Sub TextBox10_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged
        Settings.SymbolRate = TextBox10.Text

    End Sub

    Private Sub TextBox5_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        Settings.TransportID = TextBox5.Text

    End Sub

    Private Sub TextBox4_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Settings.ServiceID = TextBox4.Text
    End Sub

    Private Sub CheckBox8_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        Settings.IgnoreScrambled = CheckBox8.Checked
    End Sub

    Private Sub CheckBox7_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        Settings.UseNotSetModSD = CheckBox7.Checked
    End Sub

    Private Sub chk_AutoUpdate_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_AutoUpdate.CheckedChanged
        Settings.UpdateChannels = chk_AutoUpdate.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Settings.UpdateEPG = CheckBox2.Checked
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

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Settings.ReplaceSDwithHD = CheckBox1.Checked
    End Sub

    Private Sub CheckBox3_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Settings.useExtraInfo = CheckBox3.Checked
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

    Private Sub CheckBox9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox9.CheckedChanged
        Settings.UseNotSetModHD = CheckBox9.Checked
    End Sub

End Class

'Public Class Region

'    Dim _BouquetID As Integer
'    Dim _RegionID As Integer
'    Public Property BouquetID() As Integer
'        Get
'            Return _BouquetID
'        End Get
'        Set(ByVal value As Integer)
'            _BouquetID = value
'        End Set
'    End Property

'    Public Property RegionID() As Integer
'        Get
'            Return _RegionID
'        End Get
'        Set(ByVal value As Integer)
'            _RegionID = value
'        End Set
'    End Property
'End Class