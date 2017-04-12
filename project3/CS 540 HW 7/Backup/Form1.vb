'SDSU Fall 2010
'CS 540 Software Globalization
'Example Program 07: Language/Culture-Sensitive Sorting

Imports System
Imports System.Globalization
Imports System.Threading

Public Class Form1

    Inherits System.Windows.Forms.Form

    Dim currentCulture As CultureInfo
    Dim localCurrentCultureName As String

    Dim usaCulture As CultureInfo = New CultureInfo("en-US")
    Dim spainCultureInternational As CultureInfo = New CultureInfo("es-ES")
    Dim spainCultureTraditional As CultureInfo = New CultureInfo(&H40A)
    Dim germanyCulture As CultureInfo = New CultureInfo("de-DE")

    Dim sortedStrings() As String = {"", "", ""}
    Dim unsortedStrings() As String = {"", "", ""}

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
    Friend WithEvents unsortedCaptionLabel As System.Windows.Forms.Label
    Friend WithEvents sortedCaptionLabel As System.Windows.Forms.Label
    Friend WithEvents thirdUnsortedTextBox As System.Windows.Forms.TextBox
    Friend WithEvents secondUnsortedTextBox As System.Windows.Forms.TextBox
    Friend WithEvents firstUnsortedTextBox As System.Windows.Forms.TextBox
    Friend WithEvents sortButton As System.Windows.Forms.Button
    Friend WithEvents firstSortedLabel As System.Windows.Forms.Label
    Friend WithEvents secondSortedLabel As System.Windows.Forms.Label
    Friend WithEvents thirdSortedLabel As System.Windows.Forms.Label
    Friend WithEvents languageLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents germanyFlagPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents spainFlagInternationalPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents spainFlagTraditionalPictureBox As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.usaFlagPictureBox = New System.Windows.Forms.PictureBox
        Me.unsortedCaptionLabel = New System.Windows.Forms.Label
        Me.germanyFlagPictureBox = New System.Windows.Forms.PictureBox
        Me.sortedCaptionLabel = New System.Windows.Forms.Label
        Me.thirdUnsortedTextBox = New System.Windows.Forms.TextBox
        Me.secondUnsortedTextBox = New System.Windows.Forms.TextBox
        Me.firstUnsortedTextBox = New System.Windows.Forms.TextBox
        Me.firstSortedLabel = New System.Windows.Forms.Label
        Me.secondSortedLabel = New System.Windows.Forms.Label
        Me.thirdSortedLabel = New System.Windows.Forms.Label
        Me.sortButton = New System.Windows.Forms.Button
        Me.spainFlagInternationalPictureBox = New System.Windows.Forms.PictureBox
        Me.languageLabel = New System.Windows.Forms.Label
        Me.spainFlagTraditionalPictureBox = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.usaFlagPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.germanyFlagPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spainFlagInternationalPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spainFlagTraditionalPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'usaFlagPictureBox
        '
        Me.usaFlagPictureBox.Image = CType(resources.GetObject("usaFlagPictureBox.Image"), System.Drawing.Image)
        Me.usaFlagPictureBox.Location = New System.Drawing.Point(73, 173)
        Me.usaFlagPictureBox.Name = "usaFlagPictureBox"
        Me.usaFlagPictureBox.Size = New System.Drawing.Size(100, 63)
        Me.usaFlagPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.usaFlagPictureBox.TabIndex = 0
        Me.usaFlagPictureBox.TabStop = False
        '
        'unsortedCaptionLabel
        '
        Me.unsortedCaptionLabel.BackColor = System.Drawing.Color.LightGray
        Me.unsortedCaptionLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unsortedCaptionLabel.Location = New System.Drawing.Point(153, 132)
        Me.unsortedCaptionLabel.Name = "unsortedCaptionLabel"
        Me.unsortedCaptionLabel.Size = New System.Drawing.Size(127, 24)
        Me.unsortedCaptionLabel.TabIndex = 8
        Me.unsortedCaptionLabel.Text = "UNSORTED"
        Me.unsortedCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'germanyFlagPictureBox
        '
        Me.germanyFlagPictureBox.Image = CType(resources.GetObject("germanyFlagPictureBox.Image"), System.Drawing.Image)
        Me.germanyFlagPictureBox.Location = New System.Drawing.Point(393, 173)
        Me.germanyFlagPictureBox.Name = "germanyFlagPictureBox"
        Me.germanyFlagPictureBox.Size = New System.Drawing.Size(100, 63)
        Me.germanyFlagPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.germanyFlagPictureBox.TabIndex = 11
        Me.germanyFlagPictureBox.TabStop = False
        '
        'sortedCaptionLabel
        '
        Me.sortedCaptionLabel.BackColor = System.Drawing.Color.LightGray
        Me.sortedCaptionLabel.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sortedCaptionLabel.Location = New System.Drawing.Point(287, 132)
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
        Me.thirdUnsortedTextBox.Location = New System.Drawing.Point(153, 97)
        Me.thirdUnsortedTextBox.Name = "thirdUnsortedTextBox"
        Me.thirdUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.thirdUnsortedTextBox.TabIndex = 15
        Me.thirdUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'secondUnsortedTextBox
        '
        Me.secondUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.secondUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.secondUnsortedTextBox.Location = New System.Drawing.Point(153, 62)
        Me.secondUnsortedTextBox.Name = "secondUnsortedTextBox"
        Me.secondUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.secondUnsortedTextBox.TabIndex = 16
        Me.secondUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'firstUnsortedTextBox
        '
        Me.firstUnsortedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.firstUnsortedTextBox.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firstUnsortedTextBox.Location = New System.Drawing.Point(153, 28)
        Me.firstUnsortedTextBox.Name = "firstUnsortedTextBox"
        Me.firstUnsortedTextBox.Size = New System.Drawing.Size(127, 30)
        Me.firstUnsortedTextBox.TabIndex = 17
        Me.firstUnsortedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'firstSortedLabel
        '
        Me.firstSortedLabel.BackColor = System.Drawing.Color.White
        Me.firstSortedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.firstSortedLabel.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firstSortedLabel.Location = New System.Drawing.Point(287, 28)
        Me.firstSortedLabel.Name = "firstSortedLabel"
        Me.firstSortedLabel.Size = New System.Drawing.Size(126, 30)
        Me.firstSortedLabel.TabIndex = 18
        Me.firstSortedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'secondSortedLabel
        '
        Me.secondSortedLabel.BackColor = System.Drawing.Color.White
        Me.secondSortedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.secondSortedLabel.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.secondSortedLabel.Location = New System.Drawing.Point(287, 62)
        Me.secondSortedLabel.Name = "secondSortedLabel"
        Me.secondSortedLabel.Size = New System.Drawing.Size(126, 31)
        Me.secondSortedLabel.TabIndex = 19
        Me.secondSortedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'thirdSortedLabel
        '
        Me.thirdSortedLabel.BackColor = System.Drawing.Color.White
        Me.thirdSortedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.thirdSortedLabel.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.thirdSortedLabel.Location = New System.Drawing.Point(287, 97)
        Me.thirdSortedLabel.Name = "thirdSortedLabel"
        Me.thirdSortedLabel.Size = New System.Drawing.Size(126, 30)
        Me.thirdSortedLabel.TabIndex = 20
        Me.thirdSortedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sortButton
        '
        Me.sortButton.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sortButton.Location = New System.Drawing.Point(447, 97)
        Me.sortButton.Name = "sortButton"
        Me.sortButton.Size = New System.Drawing.Size(86, 30)
        Me.sortButton.TabIndex = 21
        Me.sortButton.Text = "SORT"
        '
        'spainFlagInternationalPictureBox
        '
        Me.spainFlagInternationalPictureBox.Image = CType(resources.GetObject("spainFlagInternationalPictureBox.Image"), System.Drawing.Image)
        Me.spainFlagInternationalPictureBox.Location = New System.Drawing.Point(180, 173)
        Me.spainFlagInternationalPictureBox.Name = "spainFlagInternationalPictureBox"
        Me.spainFlagInternationalPictureBox.Size = New System.Drawing.Size(100, 63)
        Me.spainFlagInternationalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spainFlagInternationalPictureBox.TabIndex = 1
        Me.spainFlagInternationalPictureBox.TabStop = False
        '
        'languageLabel
        '
        Me.languageLabel.Location = New System.Drawing.Point(420, 132)
        Me.languageLabel.Name = "languageLabel"
        Me.languageLabel.Size = New System.Drawing.Size(140, 27)
        Me.languageLabel.TabIndex = 22
        Me.languageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'spainFlagTraditionalPictureBox
        '
        Me.spainFlagTraditionalPictureBox.Image = CType(resources.GetObject("spainFlagTraditionalPictureBox.Image"), System.Drawing.Image)
        Me.spainFlagTraditionalPictureBox.Location = New System.Drawing.Point(287, 173)
        Me.spainFlagTraditionalPictureBox.Name = "spainFlagTraditionalPictureBox"
        Me.spainFlagTraditionalPictureBox.Size = New System.Drawing.Size(100, 63)
        Me.spainFlagTraditionalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spainFlagTraditionalPictureBox.TabIndex = 23
        Me.spainFlagTraditionalPictureBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(180, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 21)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "International"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(287, 236)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 21)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Traditional"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(680, 309)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.spainFlagTraditionalPictureBox)
        Me.Controls.Add(Me.languageLabel)
        Me.Controls.Add(Me.sortButton)
        Me.Controls.Add(Me.thirdSortedLabel)
        Me.Controls.Add(Me.secondSortedLabel)
        Me.Controls.Add(Me.firstSortedLabel)
        Me.Controls.Add(Me.firstUnsortedTextBox)
        Me.Controls.Add(Me.secondUnsortedTextBox)
        Me.Controls.Add(Me.thirdUnsortedTextBox)
        Me.Controls.Add(Me.sortedCaptionLabel)
        Me.Controls.Add(Me.germanyFlagPictureBox)
        Me.Controls.Add(Me.unsortedCaptionLabel)
        Me.Controls.Add(Me.spainFlagInternationalPictureBox)
        Me.Controls.Add(Me.usaFlagPictureBox)
        Me.Name = "Form1"
        Me.Text = "CS-540 Software Internationalization:  Multilingual Sorting Example"
        CType(Me.usaFlagPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.germanyFlagPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spainFlagInternationalPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spainFlagTraditionalPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        languageChange(usaCulture, "en-US")
        Dim i As Integer
        For i = 0 To 2
            sortedStrings(i) = ""
            unsortedStrings(i) = ""
        Next i
        myRefresh()
    End Sub

    Private Sub clearSortedStrings()
        Dim i As Integer
        For i = 0 To 2
            sortedStrings(i) = ""
        Next i
    End Sub

    Private Sub languageChange(ByRef newCurrentCulture As CultureInfo, ByVal newLocalCurrentCultureName As String)
        currentCulture = newCurrentCulture
        localCurrentCultureName = newLocalCurrentCultureName
        clearSortedStrings()
        myRefresh()
    End Sub

    Private Sub myRefresh()
        Thread.CurrentThread.CurrentUICulture = currentCulture
        languageLabel.Text = localCurrentCultureName
        firstSortedLabel.Text = sortedStrings(0)
        secondSortedLabel.Text = sortedStrings(1)
        thirdSortedLabel.Text = sortedStrings(2)
    End Sub

    Private Sub usaFlagPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles usaFlagPictureBox.Click
        languageChange(usaCulture, "en-US")
    End Sub

    Private Sub spainFlagInternationalPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spainFlagInternationalPictureBox.Click
        languageChange(spainCultureInternational, "es-ES (international)")
    End Sub

    Private Sub spainFlagTraditionalPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spainFlagTraditionalPictureBox.Click
        languageChange(spainCultureTraditional, "es-ES (traditional)")
    End Sub

    Private Sub germanyFlagPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles germanyFlagPictureBox.Click
        languageChange(germanyCulture, "de-DE")
    End Sub

    Private Sub sort(ByRef u() As String, ByRef s() As String)

        Dim i As Integer
        Dim j As Integer
        Dim minindex As Integer
        Dim minString As String
        Dim temp As String

        For i = 0 To 2
            s(i) = u(i)
        Next i

        For i = 0 To 1
            minString = s(i)
            minindex = i
            For j = i To 2
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

    Private Sub sortButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sortButton.Click
        sort(unsortedStrings, sortedStrings)
        myRefresh()
    End Sub

    Private Sub firstUnsortedTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firstUnsortedTextBox.TextChanged
        unsortedStrings(0) = firstUnsortedTextBox.Text
    End Sub

    Private Sub secondUnsortedTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles secondUnsortedTextBox.TextChanged
        unsortedStrings(1) = secondUnsortedTextBox.Text
    End Sub

    Private Sub thirdUnsortedTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles thirdUnsortedTextBox.TextChanged
        unsortedStrings(2) = thirdUnsortedTextBox.Text
    End Sub

End Class
