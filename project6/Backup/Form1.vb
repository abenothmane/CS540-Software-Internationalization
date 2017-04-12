Imports System
Imports System.Resources
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO

Public Class Form1
    Inherits System.Windows.Forms.Form
    Const WS_EX_LAYOUTRTL = &H400000
    Const WS_EX_NOINHERITLAYOUT = &H100000

    Private _mirrored As Boolean = False
    <Description("Change to the right-to-left layout."), _
    DefaultValue(False), Localizable(True), _
    Category("Appearance"), Browsable(True)> _
    Public Property Mirrored() As Boolean
        Get
            Return _mirrored
        End Get
        Set(ByVal Value As Boolean)
            If _mirrored <> Value Then
                _mirrored = Value
                MyBase.OnRightToLeftChanged(EventArgs.Empty)
            End If
        End Set
    End Property

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim CP As System.Windows.Forms.CreateParams = MyBase.CreateParams
            If Mirrored Then
                CP.ExStyle = CP.ExStyle Or WS_EX_LAYOUTRTL Or WS_EX_NOINHERITLAYOUT
            End If
            Return CP
        End Get
    End Property

    Dim current_resource_set As ResXResourceSet
    Dim english_resource_set As New ResXResourceSet("english_resources.resx")
    Dim arabic_resource_set As New ResXResourceSet("arabic_resources.resx")
    Dim bosnian_resource_set As New ResXResourceSet("bosnian_resources.resx")
    Dim iconicimage As Image
    Dim usflag As Image
    Dim saudiaflag As Image
    Dim bosniaflag As Image


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents AmericanFlag As System.Windows.Forms.PictureBox
    Friend WithEvents SaudiFlag As System.Windows.Forms.PictureBox
    Friend WithEvents BosnianFlag As System.Windows.Forms.PictureBox
    Friend WithEvents Button_Exit As System.Windows.Forms.Button
    Friend WithEvents Picture_IconicImage As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As customPanel
    Friend WithEvents Label_Greeting As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.AmericanFlag = New System.Windows.Forms.PictureBox()
        Me.SaudiFlag = New System.Windows.Forms.PictureBox()
        Me.BosnianFlag = New System.Windows.Forms.PictureBox()
        Me.Button_Exit = New System.Windows.Forms.Button()
        Me.Picture_IconicImage = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New CS596HW5V3.customPanel()
        Me.Label_Greeting = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AmericanFlag
        '
        Me.AmericanFlag.Image = CType(resources.GetObject("AmericanFlag.Image"), System.Drawing.Bitmap)
        Me.AmericanFlag.Location = New System.Drawing.Point(8, 16)
        Me.AmericanFlag.Name = "AmericanFlag"
        Me.AmericanFlag.Size = New System.Drawing.Size(104, 48)
        Me.AmericanFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AmericanFlag.TabIndex = 0
        Me.AmericanFlag.TabStop = False
        '
        'SaudiFlag
        '
        Me.SaudiFlag.Image = CType(resources.GetObject("SaudiFlag.Image"), System.Drawing.Bitmap)
        Me.SaudiFlag.Location = New System.Drawing.Point(120, 16)
        Me.SaudiFlag.Name = "SaudiFlag"
        Me.SaudiFlag.Size = New System.Drawing.Size(104, 48)
        Me.SaudiFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.SaudiFlag.TabIndex = 1
        Me.SaudiFlag.TabStop = False
        '
        'BosnianFlag
        '
        Me.BosnianFlag.Image = CType(resources.GetObject("BosnianFlag.Image"), System.Drawing.Bitmap)
        Me.BosnianFlag.Location = New System.Drawing.Point(232, 16)
        Me.BosnianFlag.Name = "BosnianFlag"
        Me.BosnianFlag.Size = New System.Drawing.Size(104, 48)
        Me.BosnianFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BosnianFlag.TabIndex = 2
        Me.BosnianFlag.TabStop = False
        '
        'Button_Exit
        '
        Me.Button_Exit.Location = New System.Drawing.Point(344, 40)
        Me.Button_Exit.Name = "Button_Exit"
        Me.Button_Exit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Exit.Size = New System.Drawing.Size(104, 24)
        Me.Button_Exit.TabIndex = 3
        Me.Button_Exit.Text = "Exit"
        '
        'Picture_IconicImage
        '
        Me.Picture_IconicImage.Image = CType(resources.GetObject("Picture_IconicImage.Image"), System.Drawing.Bitmap)
        Me.Picture_IconicImage.Location = New System.Drawing.Point(96, 80)
        Me.Picture_IconicImage.Name = "Picture_IconicImage"
        Me.Picture_IconicImage.Size = New System.Drawing.Size(264, 152)
        Me.Picture_IconicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture_IconicImage.TabIndex = 4
        Me.Picture_IconicImage.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.AmericanFlag, Me.SaudiFlag, Me.BosnianFlag, Me.Button_Exit})
        Me.Panel1.Location = New System.Drawing.Point(0, 264)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 72)
        Me.Panel1.TabIndex = 7
        '
        'Label_Greeting
        '
        Me.Label_Greeting.Font = New System.Drawing.Font("Tahoma", 20.25!)
        Me.Label_Greeting.Location = New System.Drawing.Point(72, 8)
        Me.Label_Greeting.Name = "Label_Greeting"
        Me.Label_Greeting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label_Greeting.Size = New System.Drawing.Size(320, 56)
        Me.Label_Greeting.TabIndex = 8
        Me.Label_Greeting.Text = "Good morning!"
        Me.Label_Greeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 342)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label_Greeting, Me.Panel1, Me.Picture_IconicImage})
        Me.Name = "Form1"
        Me.Text = "CS 596 HW5 V3"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MyRefresh()
        Label_Greeting.Text = current_resource_set.GetString("greeting")
        Panel1.Mirrored() = Me.Mirrored()
        Button_Exit.Text = current_resource_set.GetString("exitmsg")
        iconicimage = Image.FromFile(current_resource_set.GetString("imagepath"))
        Picture_IconicImage.Image = iconicimage
        

    End Sub

    Private Sub SetEnglish()
        current_resource_set = english_resource_set
        Me.Mirrored() = False
        MyRefresh()
    End Sub

    Private Sub SetArabic()
        current_resource_set = arabic_resource_set
        Me.Mirrored() = True
        MyRefresh()
    End Sub

    Private Sub SetBosnian()
        current_resource_set = bosnian_resource_set
        Me.Mirrored() = False
        MyRefresh()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        current_resource_set = english_resource_set
        MyRefresh()
    End Sub

    Private Sub AmericanFlag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmericanFlag.Click
        SetEnglish()
    End Sub

    Private Sub SaudiFlag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaudiFlag.Click
        SetArabic()
    End Sub

    Private Sub BosnianFlag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BosnianFlag.Click
        SetBosnian()
    End Sub

    Private Sub Button_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Exit.Click
        End
    End Sub


End Class
Public Class customPanel

    Inherits System.Windows.Forms.Panel
    Const WS_EX_LAYOUTRTL = &H400000
    Const WS_EX_NOINHERITLAYOUT = &H100000

    Private _mirrored As Boolean = False
    <Description("Change to the right-to-left layout."), _
    DefaultValue(False), Localizable(True), _
    Category("Appearance"), Browsable(True)> _
    Public Property Mirrored() As Boolean
        Get
            Return _mirrored
        End Get
        Set(ByVal Value As Boolean)
            If _mirrored <> Value Then
                _mirrored = Value
                MyBase.OnRightToLeftChanged(EventArgs.Empty)
            End If
        End Set
    End Property
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim CP As System.Windows.Forms.CreateParams = MyBase.CreateParams
            If Mirrored Then
                CP.ExStyle = CP.ExStyle Or WS_EX_LAYOUTRTL Or WS_EX_NOINHERITLAYOUT
            End If
            Return CP
        End Get
    End Property

End Class