Imports System
Imports System.Globalization
Imports System.Threading

Public Class Form1

    Inherits System.Windows.Forms.Form

    Dim currentCulture As CultureInfo

    Dim usaCulture As CultureInfo = New CultureInfo("en-US")
    Dim ukCulture As CultureInfo = New CultureInfo("en-GB")
    Dim indiaCulture As CultureInfo = New CultureInfo("hi-In")
    Dim saudiCulture As CultureInfo = New CultureInfo("ar-SA")
    Dim hungarianCulture As CultureInfo = New CultureInfo("hu-HU")
    Dim disneyCulture As CultureInfo = New CultureInfo("")  'note use of invariant culture as constructor argument

    Dim dateTime As DateTime = New DateTime(0)
    Dim dateTime1 As DateTime = New DateTime(1 / 1 / 2016)
    Dim numberOfminutes As Long = DateDiff(DateInterval.Minute, dateTime1, DateTime.Now)
    Dim numberOfTacosSold As Long = 63417 + (600 * numberOfminutes)
    Dim tacosSold As String = CStr(numberOfTacosSold)


    Dim displayMode As String

    Dim arabic_digits As Char() = {"۰"c, "١"c, "٢"c, "٣"c, "٤"c, "٥"c, "٦"c, "٧"c, "٨"c, "٩"c}
    Dim hindi_digits As Char() = {"०"c, "१"c, "२"c, "३"c, "४"c, "५"c, "६"c, "७"c, "८"c, "९"c}
    Dim latin_digits As Char() = {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c}
    Dim arabic_digits_enabled As Boolean
    Dim hindi_digits_enabled As Boolean
    Dim latin_digits_enabled As Boolean
    Dim latin_India_currency_symbol As String
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents RubioPicture As PictureBox
    Dim hindi_India_currency_symbol As String

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
    Friend WithEvents usaFlagPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents indiaFlagPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents disneyFlagPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents asDisplayedLabel As System.Windows.Forms.Label
    Friend WithEvents asCurrencyButton As System.Windows.Forms.Button
    Friend WithEvents asNumberButton As System.Windows.Forms.Button
    Friend WithEvents asDisplayedCaptionLabel As System.Windows.Forms.Label
    Friend WithEvents valueEnteredCaptionLabel As System.Windows.Forms.Label
    Friend WithEvents valueEnteredTextBox As System.Windows.Forms.TextBox
    Friend WithEvents germanFlagPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents dateTimeLabel As System.Windows.Forms.Label
    Friend WithEvents dateTimeCaptionLabel As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents hindiButton As System.Windows.Forms.Button
    Friend WithEvents latinButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.usaFlagPictureBox = New System.Windows.Forms.PictureBox()
        Me.indiaFlagPictureBox = New System.Windows.Forms.PictureBox()
        Me.disneyFlagPictureBox = New System.Windows.Forms.PictureBox()
        Me.asDisplayedLabel = New System.Windows.Forms.Label()
        Me.valueEnteredTextBox = New System.Windows.Forms.TextBox()
        Me.asCurrencyButton = New System.Windows.Forms.Button()
        Me.asNumberButton = New System.Windows.Forms.Button()
        Me.asDisplayedCaptionLabel = New System.Windows.Forms.Label()
        Me.valueEnteredCaptionLabel = New System.Windows.Forms.Label()
        Me.germanFlagPictureBox = New System.Windows.Forms.PictureBox()
        Me.dateTimeLabel = New System.Windows.Forms.Label()
        Me.dateTimeCaptionLabel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.hindiButton = New System.Windows.Forms.Button()
        Me.latinButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RubioPicture = New System.Windows.Forms.PictureBox()
        CType(Me.usaFlagPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.indiaFlagPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.disneyFlagPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.germanFlagPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RubioPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'usaFlagPictureBox
        '
        Me.usaFlagPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.usaFlagPictureBox.Image = CType(resources.GetObject("usaFlagPictureBox.Image"), System.Drawing.Image)
        Me.usaFlagPictureBox.Location = New System.Drawing.Point(448, 378)
        Me.usaFlagPictureBox.Name = "usaFlagPictureBox"
        Me.usaFlagPictureBox.Size = New System.Drawing.Size(112, 72)
        Me.usaFlagPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.usaFlagPictureBox.TabIndex = 0
        Me.usaFlagPictureBox.TabStop = False
        '
        'indiaFlagPictureBox
        '
        Me.indiaFlagPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.indiaFlagPictureBox.Image = CType(resources.GetObject("indiaFlagPictureBox.Image"), System.Drawing.Image)
        Me.indiaFlagPictureBox.Location = New System.Drawing.Point(448, 478)
        Me.indiaFlagPictureBox.Name = "indiaFlagPictureBox"
        Me.indiaFlagPictureBox.Size = New System.Drawing.Size(112, 72)
        Me.indiaFlagPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.indiaFlagPictureBox.TabIndex = 1
        Me.indiaFlagPictureBox.TabStop = False
        '
        'disneyFlagPictureBox
        '
        Me.disneyFlagPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.disneyFlagPictureBox.ErrorImage = Nothing
        Me.disneyFlagPictureBox.Image = CType(resources.GetObject("disneyFlagPictureBox.Image"), System.Drawing.Image)
        Me.disneyFlagPictureBox.InitialImage = Nothing
        Me.disneyFlagPictureBox.Location = New System.Drawing.Point(607, 377)
        Me.disneyFlagPictureBox.Name = "disneyFlagPictureBox"
        Me.disneyFlagPictureBox.Size = New System.Drawing.Size(112, 72)
        Me.disneyFlagPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.disneyFlagPictureBox.TabIndex = 2
        Me.disneyFlagPictureBox.TabStop = False
        '
        'asDisplayedLabel
        '
        Me.asDisplayedLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.asDisplayedLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.asDisplayedLabel.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.asDisplayedLabel.Location = New System.Drawing.Point(51, 270)
        Me.asDisplayedLabel.Name = "asDisplayedLabel"
        Me.asDisplayedLabel.Size = New System.Drawing.Size(668, 40)
        Me.asDisplayedLabel.TabIndex = 3
        Me.asDisplayedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'valueEnteredTextBox
        '
        Me.valueEnteredTextBox.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valueEnteredTextBox.Location = New System.Drawing.Point(26, 377)
        Me.valueEnteredTextBox.Name = "valueEnteredTextBox"
        Me.valueEnteredTextBox.Size = New System.Drawing.Size(380, 46)
        Me.valueEnteredTextBox.TabIndex = 4
        Me.valueEnteredTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'asCurrencyButton
        '
        Me.asCurrencyButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.asCurrencyButton.Location = New System.Drawing.Point(216, 562)
        Me.asCurrencyButton.Name = "asCurrencyButton"
        Me.asCurrencyButton.Size = New System.Drawing.Size(176, 24)
        Me.asCurrencyButton.TabIndex = 5
        Me.asCurrencyButton.Text = "AS CURRENCY (C)"
        '
        'asNumberButton
        '
        Me.asNumberButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.asNumberButton.Location = New System.Drawing.Point(26, 562)
        Me.asNumberButton.Name = "asNumberButton"
        Me.asNumberButton.Size = New System.Drawing.Size(184, 24)
        Me.asNumberButton.TabIndex = 6
        Me.asNumberButton.Text = "AS NUMBER (N)"
        '
        'asDisplayedCaptionLabel
        '
        Me.asDisplayedCaptionLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.asDisplayedCaptionLabel.Location = New System.Drawing.Point(52, 230)
        Me.asDisplayedCaptionLabel.Name = "asDisplayedCaptionLabel"
        Me.asDisplayedCaptionLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.asDisplayedCaptionLabel.Size = New System.Drawing.Size(161, 24)
        Me.asDisplayedCaptionLabel.TabIndex = 7
        Me.asDisplayedCaptionLabel.Text = "TACOS SOLD TO DATE"
        Me.asDisplayedCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'valueEnteredCaptionLabel
        '
        Me.valueEnteredCaptionLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valueEnteredCaptionLabel.Location = New System.Drawing.Point(135, 426)
        Me.valueEnteredCaptionLabel.Name = "valueEnteredCaptionLabel"
        Me.valueEnteredCaptionLabel.Size = New System.Drawing.Size(153, 24)
        Me.valueEnteredCaptionLabel.TabIndex = 8
        Me.valueEnteredCaptionLabel.Text = "VALUE ENTERED"
        Me.valueEnteredCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'germanFlagPictureBox
        '
        Me.germanFlagPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.germanFlagPictureBox.Image = CType(resources.GetObject("germanFlagPictureBox.Image"), System.Drawing.Image)
        Me.germanFlagPictureBox.Location = New System.Drawing.Point(607, 478)
        Me.germanFlagPictureBox.Name = "germanFlagPictureBox"
        Me.germanFlagPictureBox.Size = New System.Drawing.Size(112, 72)
        Me.germanFlagPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.germanFlagPictureBox.TabIndex = 11
        Me.germanFlagPictureBox.TabStop = False
        '
        'dateTimeLabel
        '
        Me.dateTimeLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dateTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dateTimeLabel.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateTimeLabel.Location = New System.Drawing.Point(26, 478)
        Me.dateTimeLabel.Name = "dateTimeLabel"
        Me.dateTimeLabel.Size = New System.Drawing.Size(380, 48)
        Me.dateTimeLabel.TabIndex = 12
        Me.dateTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dateTimeCaptionLabel
        '
        Me.dateTimeCaptionLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateTimeCaptionLabel.Location = New System.Drawing.Point(135, 526)
        Me.dateTimeCaptionLabel.Name = "dateTimeCaptionLabel"
        Me.dateTimeCaptionLabel.Size = New System.Drawing.Size(152, 24)
        Me.dateTimeCaptionLabel.TabIndex = 13
        Me.dateTimeCaptionLabel.Text = "DATE / TIME"
        Me.dateTimeCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'hindiButton
        '
        Me.hindiButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hindiButton.Location = New System.Drawing.Point(504, 562)
        Me.hindiButton.Name = "hindiButton"
        Me.hindiButton.Size = New System.Drawing.Size(56, 21)
        Me.hindiButton.TabIndex = 14
        Me.hindiButton.Text = "HINDI"
        '
        'latinButton
        '
        Me.latinButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.latinButton.Location = New System.Drawing.Point(433, 562)
        Me.latinButton.Name = "latinButton"
        Me.latinButton.Size = New System.Drawing.Size(56, 21)
        Me.latinButton.TabIndex = 15
        Me.latinButton.Text = "LATIN"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(562, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 40)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "$4.29"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(535, 230)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(184, 24)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "PRICE OF TACO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 190)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(469, 40)
        Me.Label3.TabIndex = 18
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(216, 320)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(264, 24)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "AS DISPLAYED"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RubioPicture
        '
        Me.RubioPicture.Image = CType(resources.GetObject("RubioPicture.Image"), System.Drawing.Image)
        Me.RubioPicture.Location = New System.Drawing.Point(52, 45)
        Me.RubioPicture.Name = "RubioPicture"
        Me.RubioPicture.Size = New System.Drawing.Size(651, 123)
        Me.RubioPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RubioPicture.TabIndex = 20
        Me.RubioPicture.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(731, 614)
        Me.Controls.Add(Me.RubioPicture)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.latinButton)
        Me.Controls.Add(Me.hindiButton)
        Me.Controls.Add(Me.dateTimeCaptionLabel)
        Me.Controls.Add(Me.dateTimeLabel)
        Me.Controls.Add(Me.germanFlagPictureBox)
        Me.Controls.Add(Me.valueEnteredCaptionLabel)
        Me.Controls.Add(Me.asDisplayedCaptionLabel)
        Me.Controls.Add(Me.asNumberButton)
        Me.Controls.Add(Me.asCurrencyButton)
        Me.Controls.Add(Me.valueEnteredTextBox)
        Me.Controls.Add(Me.asDisplayedLabel)
        Me.Controls.Add(Me.disneyFlagPictureBox)
        Me.Controls.Add(Me.indiaFlagPictureBox)
        Me.Controls.Add(Me.usaFlagPictureBox)
        Me.Name = "Form1"
        Me.Text = "CS 540 HW 6 EXAMPLE PROGRAM 1:  NUMBER/CURRENCY/DATE FORMATTING"
        CType(Me.usaFlagPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.indiaFlagPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.disneyFlagPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.germanFlagPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RubioPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub xlt_digits_to_A(ByRef latin As String)
        Dim i As Integer
        For i = 0 To 9
            latin = latin.Replace(latin_digits(i), arabic_digits(i))
        Next i
    End Sub

    Private Sub xlt_digits_to_H(ByRef latin As String)
        Dim i As Integer
        For i = 0 To 9
            latin = latin.Replace(latin_digits(i), hindi_digits(i))
        Next i
    End Sub

    Private Sub definedisneyCulture()
        Dim disneyCurrencyGroupSizes As Integer() = {3}
        Dim disneyNumberGroupSizes As Integer() = {4, 3}

        disneyCulture.NumberFormat.CurrencyDecimalDigits = 2
        disneyCulture.NumberFormat.CurrencyDecimalSeparator = "."
        disneyCulture.NumberFormat.CurrencyGroupSizes = disneyCurrencyGroupSizes
        disneyCulture.NumberFormat.CurrencyGroupSeparator = ","
        disneyCulture.NumberFormat.CurrencySymbol = "ஜ"
        disneyCulture.NumberFormat.CurrencyPositivePattern = 1
        disneyCulture.NumberFormat.NumberDecimalDigits = 3
        disneyCulture.NumberFormat.NumberDecimalSeparator = "."
        disneyCulture.NumberFormat.NumberGroupSizes = disneyNumberGroupSizes
        disneyCulture.NumberFormat.NumberGroupSeparator = "*"
        disneyCulture.DateTimeFormat.ShortDatePattern = "yyy/mm/dd"
        disneyCulture.DateTimeFormat.ShortTimePattern = "mm:HH"


    End Sub

    Private Sub initializeDualIndiaCulture()
        hindi_India_currency_symbol = indiaCulture.NumberFormat.CurrencySymbol
        latin_India_currency_symbol = "Rs"
        latin_digits_enabled = True
        hindi_digits_enabled = False
        indiaCulture.NumberFormat.CurrencySymbol = latin_India_currency_symbol
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        displayMode = "N"
        currentCulture = usaCulture
        definedisneyCulture()
        initializeDualIndiaCulture()
    End Sub

    Private Sub myRefresh()
        Dim i As Integer
        Thread.CurrentThread.CurrentUICulture = currentCulture
        If valueEnteredTextBox.Text <> "" Then asDisplayedLabel.Text = CDbl(valueEnteredTextBox.Text).ToString(displayMode, currentCulture)
        If hindi_digits_enabled Then
            xlt_digits_to_H(asDisplayedLabel.Text)
            xlt_digits_to_H(dateTimeLabel.Text)
        ElseIf arabic_digits_enabled Then
            xlt_digits_to_A(asDisplayedLabel.Text)
            xlt_digits_to_A(dateTimeLabel.Text)
        End If
    End Sub

    Private Sub usaFlagPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles usaFlagPictureBox.Click
        currentCulture = usaCulture
        myRefresh()
    End Sub

    Private Sub indiaFlagPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles indiaFlagPictureBox.Click
        currentCulture = indiaCulture
        indiaCulture.NumberFormat.CurrencySymbol = latin_India_currency_symbol
        arabic_digits_enabled = False
        hindi_digits_enabled = False
        latin_digits_enabled = True
        myRefresh()
    End Sub

    Private Sub latinButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles latinButton.Click
        indiaCulture.NumberFormat.CurrencySymbol = latin_India_currency_symbol
        arabic_digits_enabled = False
        hindi_digits_enabled = False
        latin_digits_enabled = True
        myRefresh()
    End Sub

    Private Sub hindiButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hindiButton.Click
        indiaCulture.NumberFormat.CurrencySymbol = hindi_India_currency_symbol
        arabic_digits_enabled = False
        hindi_digits_enabled = True
        latin_digits_enabled = False
        myRefresh()
    End Sub

    Private Sub disneyFlagPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disneyFlagPictureBox.Click
        currentCulture = disneyCulture
        arabic_digits_enabled = False
        hindi_digits_enabled = False
        latin_digits_enabled = True
        myRefresh()
    End Sub

    Private Sub ukFlagPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        currentCulture = ukCulture
        arabic_digits_enabled = False
        hindi_digits_enabled = False
        latin_digits_enabled = True
        myRefresh()
    End Sub

    Private Sub saudiFlagPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        currentCulture = saudiCulture
        arabic_digits_enabled = True
        hindi_digits_enabled = False
        latin_digits_enabled = False
        myRefresh()
    End Sub

    Private Sub hungarianFlagPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles germanFlagPictureBox.Click
        currentCulture = hungarianCulture
        arabic_digits_enabled = False
        hindi_digits_enabled = False
        latin_digits_enabled = True
        myRefresh()
    End Sub

    Private Sub asNumberButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles asNumberButton.Click
        displayMode = "N"
        myRefresh()
    End Sub

    Private Sub asCurrencyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles asCurrencyButton.Click
        displayMode = "C"
        myRefresh()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        dateTimeLabel.Text = DateTime.Now().ToString("F", currentCulture)

        myRefresh()
    End Sub

    Private Sub valueEnteredTextBox_TextChanged(sender As Object, e As EventArgs) Handles valueEnteredTextBox.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Label3.Text = tacosSold
    End Sub
End Class
