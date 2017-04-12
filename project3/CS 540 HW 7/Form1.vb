
'SDSU spring 2016
'CS 540 Software Globalization
'Anass Benothmane
'Assignment 7

Imports System
Imports System.Globalization
Imports System.IO
Imports System.Threading

Public Class Form1

    Inherits System.Windows.Forms.Form

    Dim currentCulture As CultureInfo
    Dim localCurrentCultureName As String
    Dim inputLocalCurrentCultureName As String


    Dim usaCulture As CultureInfo = New CultureInfo("en-US")
    Dim mexicoCultureInternational As CultureInfo = New CultureInfo("es-ES")
    Dim spainCultureTraditional As CultureInfo = New CultureInfo(&H40A)
    Dim germanyCulture As CultureInfo = New CultureInfo("de-DE")
    Dim russiaCulture As CultureInfo = New CultureInfo("ru-RU")

    Dim sortedStrings() As String = {"", "", "", "", "", "", "", "", "", ""}

    Friend WithEvents exitButton As Button
    Friend WithEvents fourthUnsortedTextBox As TextBox
    Friend WithEvents sixthSortedTextBox As TextBox
    Friend WithEvents fifthSortedTextBox As TextBox
    Friend WithEvents fourthSortedTextBox As TextBox
    Friend WithEvents tenthUnsortedTextBox As TextBox
    Friend WithEvents ninthUnsortedTextBox As TextBox
    Friend WithEvents eigthUnsortedTextBox As TextBox
    Friend WithEvents seventhUnsortedTextBox As TextBox
    Friend WithEvents sixthUnsortedTextBox As TextBox
    Friend WithEvents fifthUnsortedTextBox As TextBox
    Friend WithEvents eighthSortedTextBox As TextBox
    Friend WithEvents ninthSortedTextBox As TextBox
    Friend WithEvents tenthSortedTextBox As TextBox
    Friend WithEvents seventhSortedTextBox As TextBox
    Friend WithEvents textFileInput As TextBox
    Friend WithEvents pathLabel As Label
    Friend WithEvents Label2 As Label
    Dim unSortedStrings() As String = {"", "", "", "", "", "", "", "", "", ""}

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
    Friend WithEvents unsortedCaptionLabel As System.Windows.Forms.Label
    Friend WithEvents sortedCaptionLabel As System.Windows.Forms.Label
    Friend WithEvents thirdUnsortedTextBox As System.Windows.Forms.TextBox
    Friend WithEvents secondUnsortedTextBox As System.Windows.Forms.TextBox
    Friend WithEvents firstUnsortedTextBox As System.Windows.Forms.TextBox
    Friend WithEvents sortButton As System.Windows.Forms.Button
    Friend WithEvents firstSortedTextBox As System.Windows.Forms.Label
    Friend WithEvents secondSortedTextBox As System.Windows.Forms.Label
    Friend WithEvents thirdSortedTextBox As System.Windows.Forms.Label
    Friend WithEvents languageLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.unsortedCaptionLabel = New System.Windows.Forms.Label()
        Me.sortedCaptionLabel = New System.Windows.Forms.Label()
        Me.thirdUnsortedTextBox = New System.Windows.Forms.TextBox()
        Me.secondUnsortedTextBox = New System.Windows.Forms.TextBox()
        Me.firstUnsortedTextBox = New System.Windows.Forms.TextBox()
        Me.firstSortedTextBox = New System.Windows.Forms.Label()
        Me.secondSortedTextBox = New System.Windows.Forms.Label()
        Me.thirdSortedTextBox = New System.Windows.Forms.Label()
        Me.sortButton = New System.Windows.Forms.Button()
        Me.languageLabel = New System.Windows.Forms.Label()
        Me.exitButton = New System.Windows.Forms.Button()
        Me.fourthUnsortedTextBox = New System.Windows.Forms.TextBox()
        Me.sixthSortedTextBox = New System.Windows.Forms.TextBox()
        Me.fifthSortedTextBox = New System.Windows.Forms.TextBox()
        Me.fourthSortedTextBox = New System.Windows.Forms.TextBox()
        Me.tenthUnsortedTextBox = New System.Windows.Forms.TextBox()
        Me.ninthUnsortedTextBox = New System.Windows.Forms.TextBox()
        Me.eigthUnsortedTextBox = New System.Windows.Forms.TextBox()
        Me.seventhUnsortedTextBox = New System.Windows.Forms.TextBox()
        Me.sixthUnsortedTextBox = New System.Windows.Forms.TextBox()
        Me.fifthUnsortedTextBox = New System.Windows.Forms.TextBox()
        Me.eighthSortedTextBox = New System.Windows.Forms.TextBox()
        Me.ninthSortedTextBox = New System.Windows.Forms.TextBox()
        Me.tenthSortedTextBox = New System.Windows.Forms.TextBox()
        Me.seventhSortedTextBox = New System.Windows.Forms.TextBox()
        Me.textFileInput = New System.Windows.Forms.TextBox()
        Me.pathLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'unsortedCaptionLabel
        '
        Me.unsortedCaptionLabel.BackColor = System.Drawing.Color.LightGray
        Me.unsortedCaptionLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unsortedCaptionLabel.Location = New System.Drawing.Point(295, 465)
        Me.unsortedCaptionLabel.Name = "unsortedCaptionLabel"
        Me.unsortedCaptionLabel.Size = New System.Drawing.Size(127, 24)
        Me.unsortedCaptionLabel.TabIndex = 8
        Me.unsortedCaptionLabel.Text = "UNSORTED"
        Me.unsortedCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sortedCaptionLabel
        '
        Me.sortedCaptionLabel.BackColor = System.Drawing.Color.LightGray
        Me.sortedCaptionLabel.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sortedCaptionLabel.Location = New System.Drawing.Point(430, 465)
        Me.sortedCaptionLabel.Name = "sortedCaptionLabel"
        Me.sortedCaptionLabel.Size = New System.Drawing.Size(126, 24)
        Me.sortedCaptionLabel.TabIndex = 14
        Me.sortedCaptionLabel.Text = "SORTED"
        Me.sortedCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'thirdUnsortedTextBox
        '
        Me.thirdUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.thirdUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.thirdUnsortedTextBox.Location = New System.Drawing.Point(295, 157)
        Me.thirdUnsortedTextBox.Name = "thirdUnsortedTextBox"
        Me.thirdUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.thirdUnsortedTextBox.TabIndex = 15
        Me.thirdUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'secondUnsortedTextBox
        '
        Me.secondUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.secondUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.secondUnsortedTextBox.Location = New System.Drawing.Point(295, 122)
        Me.secondUnsortedTextBox.Name = "secondUnsortedTextBox"
        Me.secondUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.secondUnsortedTextBox.TabIndex = 16
        Me.secondUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'firstUnsortedTextBox
        '
        Me.firstUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.firstUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firstUnsortedTextBox.Location = New System.Drawing.Point(295, 88)
        Me.firstUnsortedTextBox.Name = "firstUnsortedTextBox"
        Me.firstUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.firstUnsortedTextBox.TabIndex = 17
        Me.firstUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'firstSortedTextBox
        '
        Me.firstSortedTextBox.BackColor = System.Drawing.Color.White
        Me.firstSortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.firstSortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firstSortedTextBox.Location = New System.Drawing.Point(430, 88)
        Me.firstSortedTextBox.Name = "firstSortedTextBox"
        Me.firstSortedTextBox.Size = New System.Drawing.Size(126, 30)
        Me.firstSortedTextBox.TabIndex = 18
        Me.firstSortedTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'secondSortedTextBox
        '
        Me.secondSortedTextBox.BackColor = System.Drawing.Color.White
        Me.secondSortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.secondSortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.secondSortedTextBox.Location = New System.Drawing.Point(430, 122)
        Me.secondSortedTextBox.Name = "secondSortedTextBox"
        Me.secondSortedTextBox.Size = New System.Drawing.Size(126, 31)
        Me.secondSortedTextBox.TabIndex = 19
        Me.secondSortedTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'thirdSortedTextBox
        '
        Me.thirdSortedTextBox.BackColor = System.Drawing.Color.White
        Me.thirdSortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.thirdSortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.thirdSortedTextBox.Location = New System.Drawing.Point(430, 157)
        Me.thirdSortedTextBox.Name = "thirdSortedTextBox"
        Me.thirdSortedTextBox.Size = New System.Drawing.Size(126, 30)
        Me.thirdSortedTextBox.TabIndex = 20
        Me.thirdSortedTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sortButton
        '
        Me.sortButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sortButton.Location = New System.Drawing.Point(27, 461)
        Me.sortButton.Name = "sortButton"
        Me.sortButton.Size = New System.Drawing.Size(128, 30)
        Me.sortButton.TabIndex = 21
        Me.sortButton.Text = "Read and Sort"
        '
        'languageLabel
        '
        Me.languageLabel.Location = New System.Drawing.Point(351, 45)
        Me.languageLabel.Name = "languageLabel"
        Me.languageLabel.Size = New System.Drawing.Size(140, 27)
        Me.languageLabel.TabIndex = 22
        Me.languageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(587, 576)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(75, 23)
        Me.exitButton.TabIndex = 28
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'fourthUnsortedTextBox
        '
        Me.fourthUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fourthUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fourthUnsortedTextBox.Location = New System.Drawing.Point(295, 193)
        Me.fourthUnsortedTextBox.Name = "fourthUnsortedTextBox"
        Me.fourthUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.fourthUnsortedTextBox.TabIndex = 29
        Me.fourthUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sixthSortedTextBox
        '
        Me.sixthSortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sixthSortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sixthSortedTextBox.Location = New System.Drawing.Point(428, 265)
        Me.sixthSortedTextBox.Name = "sixthSortedTextBox"
        Me.sixthSortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.sixthSortedTextBox.TabIndex = 30
        Me.sixthSortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'fifthSortedTextBox
        '
        Me.fifthSortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fifthSortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fifthSortedTextBox.Location = New System.Drawing.Point(428, 229)
        Me.fifthSortedTextBox.Name = "fifthSortedTextBox"
        Me.fifthSortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.fifthSortedTextBox.TabIndex = 31
        Me.fifthSortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'fourthSortedTextBox
        '
        Me.fourthSortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fourthSortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fourthSortedTextBox.Location = New System.Drawing.Point(429, 193)
        Me.fourthSortedTextBox.Name = "fourthSortedTextBox"
        Me.fourthSortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.fourthSortedTextBox.TabIndex = 32
        Me.fourthSortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tenthUnsortedTextBox
        '
        Me.tenthUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tenthUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tenthUnsortedTextBox.Location = New System.Drawing.Point(295, 409)
        Me.tenthUnsortedTextBox.Name = "tenthUnsortedTextBox"
        Me.tenthUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.tenthUnsortedTextBox.TabIndex = 33
        Me.tenthUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ninthUnsortedTextBox
        '
        Me.ninthUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ninthUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ninthUnsortedTextBox.Location = New System.Drawing.Point(295, 373)
        Me.ninthUnsortedTextBox.Name = "ninthUnsortedTextBox"
        Me.ninthUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.ninthUnsortedTextBox.TabIndex = 34
        Me.ninthUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'eigthUnsortedTextBox
        '
        Me.eigthUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.eigthUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eigthUnsortedTextBox.Location = New System.Drawing.Point(295, 337)
        Me.eigthUnsortedTextBox.Name = "eigthUnsortedTextBox"
        Me.eigthUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.eigthUnsortedTextBox.TabIndex = 35
        Me.eigthUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'seventhUnsortedTextBox
        '
        Me.seventhUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.seventhUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seventhUnsortedTextBox.Location = New System.Drawing.Point(295, 301)
        Me.seventhUnsortedTextBox.Name = "seventhUnsortedTextBox"
        Me.seventhUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.seventhUnsortedTextBox.TabIndex = 36
        Me.seventhUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sixthUnsortedTextBox
        '
        Me.sixthUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sixthUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sixthUnsortedTextBox.Location = New System.Drawing.Point(295, 265)
        Me.sixthUnsortedTextBox.Name = "sixthUnsortedTextBox"
        Me.sixthUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.sixthUnsortedTextBox.TabIndex = 37
        Me.sixthUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'fifthUnsortedTextBox
        '
        Me.fifthUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fifthUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fifthUnsortedTextBox.Location = New System.Drawing.Point(295, 229)
        Me.fifthUnsortedTextBox.Name = "fifthUnsortedTextBox"
        Me.fifthUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.fifthUnsortedTextBox.TabIndex = 38
        Me.fifthUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'eighthSortedTextBox
        '
        Me.eighthSortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.eighthSortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eighthSortedTextBox.Location = New System.Drawing.Point(428, 337)
        Me.eighthSortedTextBox.Name = "eighthSortedTextBox"
        Me.eighthSortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.eighthSortedTextBox.TabIndex = 39
        Me.eighthSortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ninthSortedTextBox
        '
        Me.ninthSortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ninthSortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ninthSortedTextBox.Location = New System.Drawing.Point(429, 373)
        Me.ninthSortedTextBox.Name = "ninthSortedTextBox"
        Me.ninthSortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.ninthSortedTextBox.TabIndex = 40
        Me.ninthSortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tenthSortedTextBox
        '
        Me.tenthSortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tenthSortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tenthSortedTextBox.Location = New System.Drawing.Point(429, 409)
        Me.tenthSortedTextBox.Name = "tenthSortedTextBox"
        Me.tenthSortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.tenthSortedTextBox.TabIndex = 41
        Me.tenthSortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'seventhSortedTextBox
        '
        Me.seventhSortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.seventhSortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seventhSortedTextBox.Location = New System.Drawing.Point(428, 301)
        Me.seventhSortedTextBox.Name = "seventhSortedTextBox"
        Me.seventhSortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.seventhSortedTextBox.TabIndex = 42
        Me.seventhSortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textFileInput
        '
        Me.textFileInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textFileInput.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFileInput.Location = New System.Drawing.Point(27, 124)
        Me.textFileInput.Name = "textFileInput"
        Me.textFileInput.Size = New System.Drawing.Size(127, 30)
        Me.textFileInput.TabIndex = 43
        Me.textFileInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pathLabel
        '
        Me.pathLabel.AutoSize = True
        Me.pathLabel.Location = New System.Drawing.Point(24, 88)
        Me.pathLabel.Name = "pathLabel"
        Me.pathLabel.Size = New System.Drawing.Size(48, 13)
        Me.pathLabel.TabIndex = 45
        Me.pathLabel.Text = "File Path"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(310, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Language/Locale-Sensitive Sort Order Used"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(674, 611)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pathLabel)
        Me.Controls.Add(Me.textFileInput)
        Me.Controls.Add(Me.seventhSortedTextBox)
        Me.Controls.Add(Me.tenthSortedTextBox)
        Me.Controls.Add(Me.ninthSortedTextBox)
        Me.Controls.Add(Me.eighthSortedTextBox)
        Me.Controls.Add(Me.fifthUnsortedTextBox)
        Me.Controls.Add(Me.sixthUnsortedTextBox)
        Me.Controls.Add(Me.seventhUnsortedTextBox)
        Me.Controls.Add(Me.eigthUnsortedTextBox)
        Me.Controls.Add(Me.ninthUnsortedTextBox)
        Me.Controls.Add(Me.tenthUnsortedTextBox)
        Me.Controls.Add(Me.fourthSortedTextBox)
        Me.Controls.Add(Me.fifthSortedTextBox)
        Me.Controls.Add(Me.sixthSortedTextBox)
        Me.Controls.Add(Me.fourthUnsortedTextBox)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.languageLabel)
        Me.Controls.Add(Me.sortButton)
        Me.Controls.Add(Me.thirdSortedTextBox)
        Me.Controls.Add(Me.secondSortedTextBox)
        Me.Controls.Add(Me.firstSortedTextBox)
        Me.Controls.Add(Me.firstUnsortedTextBox)
        Me.Controls.Add(Me.secondUnsortedTextBox)
        Me.Controls.Add(Me.thirdUnsortedTextBox)
        Me.Controls.Add(Me.sortedCaptionLabel)
        Me.Controls.Add(Me.unsortedCaptionLabel)
        Me.Name = "Form1"
        Me.Text = "CS 540 HW 7 EXAMPLE PROGRAM:  Multilingual Sorting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer
        For i = 0 To 9
            sortedStrings(i) = ""
            unSortedStrings(i) = ""
        Next i

    End Sub


    Private Sub sort(ByRef u() As String, ByRef s() As String)

        Dim i As Integer
        Dim j As Integer
        Dim minindex As Integer
        Dim minString As String
        Dim temp As String

        For i = 0 To 9
            s(i) = u(i)
        Next i

        For i = 0 To 9
            minString = s(i)
            minindex = i
            For j = i To 9
                If currentCulture.CompareInfo.Compare(s(j), minString) < 0 Then
                    minindex = j
                    minString = s(j)
                End If
            Next j
            temp = s(i)
            s(i) = minString
            s(minindex) = temp
        Next i

    End Sub

    Private Sub sortButton_Click(sender As Object, e As EventArgs) Handles sortButton.Click


        Dim sr As New StreamReader(textFileInput.Text)
        Dim word As String = ""
        Dim words(12) As String
        Dim i As Integer = 0
        Dim j As Integer = 0

        clearSortedStrings()
        clearUnSortedStrings()

        Do Until sr.Peek = -1
            word = sr.ReadLine()
            words(i) = word
            i += 1
        Loop

        inputLocalCurrentCultureName = words(0)
        For i = 1 To 10
            unSortedStrings(i - 1) = words(i)
        Next i

        If String.Compare(inputLocalCurrentCultureName, "en-US") = 0 Then
            currentCulture = usaCulture
            localCurrentCultureName = inputLocalCurrentCultureName
        End If

        If String.Compare(inputLocalCurrentCultureName, "de-DE") = 0 Then
            currentCulture = germanyCulture
            localCurrentCultureName = inputLocalCurrentCultureName
        End If

        If String.Compare(inputLocalCurrentCultureName, "es-MX") = 0 Then
            currentCulture = mexicoCultureInternational
            localCurrentCultureName = "es-ES"
        End If

        If String.Compare(inputLocalCurrentCultureName, "es-TRADITIONAL") = 0 Then
            currentCulture = spainCultureTraditional
            localCurrentCultureName = &H40A
        End If

        If String.Compare(inputLocalCurrentCultureName, "ru-RU") = 0 Then
            currentCulture = russiaCulture
            localCurrentCultureName = "ru-RU"
        End If
        placeUnsorted()
        sort(unSortedStrings, sortedStrings)
        placeUnsorted()
        placeSorted()
        languageLabel.Text = words(0)
    End Sub

    Private Sub placeUnsorted()
        firstUnsortedTextBox.Text = unSortedStrings(0)
        secondUnsortedTextBox.Text = unSortedStrings(1)
        thirdUnsortedTextBox.Text = unSortedStrings(2)
        fourthUnsortedTextBox.Text = unSortedStrings(3)
        fifthUnsortedTextBox.Text = unSortedStrings(4)
        sixthUnsortedTextBox.Text = unSortedStrings(5)
        seventhUnsortedTextBox.Text = unSortedStrings(6)
        eigthUnsortedTextBox.Text = unSortedStrings(7)
        ninthUnsortedTextBox.Text = unSortedStrings(8)
        tenthUnsortedTextBox.Text = unSortedStrings(9)

    End Sub

    Private Sub placeSorted()
        firstSortedTextBox.Text = sortedStrings(0)
        secondSortedTextBox.Text = sortedStrings(1)
        thirdSortedTextBox.Text = sortedStrings(2)
        fourthSortedTextBox.Text = sortedStrings(3)
        fifthSortedTextBox.Text = sortedStrings(4)
        sixthSortedTextBox.Text = sortedStrings(5)
        seventhSortedTextBox.Text = sortedStrings(6)
        eighthSortedTextBox.Text = sortedStrings(7)
        ninthSortedTextBox.Text = sortedStrings(8)
        tenthSortedTextBox.Text = sortedStrings(9)

    End Sub

    Private Sub clearSortedStrings() 'Clear out sortedStrings array. 
        Dim i As Integer
        For i = 0 To 9
            sortedStrings(i) = ""
        Next i
    End Sub

    Private Sub clearUnSortedStrings() 'Clear out unsortedStrings array.
        Dim i As Integer
        For i = 0 To 9
            unSortedStrings(i) = ""
        Next i
    End Sub



    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        End
    End Sub

    Private Sub firstSortedLabel_Click(sender As Object, e As EventArgs) Handles firstSortedTextBox.Click

    End Sub
End Class
