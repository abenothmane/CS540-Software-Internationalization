'Assignment 8
'CS540
'ANASS BENOTHMANE


Imports System
Imports System.IO


Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim bWeHaveAValidInputFile As Boolean = False ''''''''' 
    Dim stringInputStringFile As FileStream
    Dim stringReader As StreamReader
    Dim workingString As String = ""
    Const FILE_PATH As String = "cs540hw8input.txt"

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
    Friend WithEvents resizeControlLabel As System.Windows.Forms.Label
    Friend WithEvents resizeFontLabel As System.Windows.Forms.Label
    Friend WithEvents nextButton As System.Windows.Forms.Button
    Friend WithEvents statusBarLabel As System.Windows.Forms.Label
    Friend WithEvents resizeControlLabelLbl As System.Windows.Forms.Label
    Friend WithEvents resizeFontLabelLbl As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.resizeControlLabelLbl = New System.Windows.Forms.Label()
        Me.resizeControlLabel = New System.Windows.Forms.Label()
        Me.resizeFontLabelLbl = New System.Windows.Forms.Label()
        Me.resizeFontLabel = New System.Windows.Forms.Label()
        Me.nextButton = New System.Windows.Forms.Button()
        Me.statusBarLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'resizeControlLabelLbl
        '
        Me.resizeControlLabelLbl.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.resizeControlLabelLbl.Location = New System.Drawing.Point(24, 112)
        Me.resizeControlLabelLbl.Name = "resizeControlLabelLbl"
        Me.resizeControlLabelLbl.Size = New System.Drawing.Size(176, 32)
        Me.resizeControlLabelLbl.TabIndex = 0
        Me.resizeControlLabelLbl.Text = "resizeControlLabel:"
        Me.resizeControlLabelLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'resizeControlLabel
        '
        Me.resizeControlLabel.BackColor = System.Drawing.Color.OrangeRed
        Me.resizeControlLabel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.resizeControlLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.resizeControlLabel.Location = New System.Drawing.Point(206, 112)
        Me.resizeControlLabel.Name = "resizeControlLabel"
        Me.resizeControlLabel.Size = New System.Drawing.Size(206, 32)
        Me.resizeControlLabel.TabIndex = 1
        Me.resizeControlLabel.Text = "<Resize Control>"
        Me.resizeControlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'resizeFontLabelLbl
        '
        Me.resizeFontLabelLbl.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.resizeFontLabelLbl.Location = New System.Drawing.Point(24, 173)
        Me.resizeFontLabelLbl.Name = "resizeFontLabelLbl"
        Me.resizeFontLabelLbl.Size = New System.Drawing.Size(176, 32)
        Me.resizeFontLabelLbl.TabIndex = 2
        Me.resizeFontLabelLbl.Text = "resizeFontLabel:"
        Me.resizeFontLabelLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'resizeFontLabel
        '
        Me.resizeFontLabel.BackColor = System.Drawing.Color.OrangeRed
        Me.resizeFontLabel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.resizeFontLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.resizeFontLabel.Location = New System.Drawing.Point(206, 173)
        Me.resizeFontLabel.Name = "resizeFontLabel"
        Me.resizeFontLabel.Size = New System.Drawing.Size(454, 32)
        Me.resizeFontLabel.TabIndex = 3
        Me.resizeFontLabel.Text = "<Resize Font Size>"
        Me.resizeFontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nextButton
        '
        Me.nextButton.Location = New System.Drawing.Point(210, 237)
        Me.nextButton.Name = "nextButton"
        Me.nextButton.Size = New System.Drawing.Size(64, 24)
        Me.nextButton.TabIndex = 4
        Me.nextButton.Text = "NEXT"
        '
        'statusBarLabel
        '
        Me.statusBarLabel.Location = New System.Drawing.Point(207, 73)
        Me.statusBarLabel.Name = "statusBarLabel"
        Me.statusBarLabel.Size = New System.Drawing.Size(488, 16)
        Me.statusBarLabel.TabIndex = 5
        Me.statusBarLabel.Text = "<Status Bar>"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(723, 366)
        Me.Controls.Add(Me.statusBarLabel)
        Me.Controls.Add(Me.nextButton)
        Me.Controls.Add(Me.resizeFontLabel)
        Me.Controls.Add(Me.resizeFontLabelLbl)
        Me.Controls.Add(Me.resizeControlLabel)
        Me.Controls.Add(Me.resizeControlLabelLbl)
        Me.Name = "Form1"
        Me.Text = "CS 540 PROGRAMMING ASSIGNMENT 8  :  EXAMPLE SOURCE CODE"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Function readValidInputTextFile(ByVal fileName As String) As Boolean
        'Reads input file in, returns True if file was valid according to spec
        'False if an error happens or if file does not match spec
        Try
            stringInputStringFile = New FileStream(fileName, FileMode.Open, FileAccess.Read)
            stringReader = New StreamReader(stringInputStringFile)
            bWeHaveAValidInputFile = True
            Return True
        Catch e As Exception
            'File does not exist, or other error happened. Error is handled 
            'by returning False in the function call
            bWeHaveAValidInputFile = False
            Return False
        End Try
    End Function

    Private Function getNextString(ByRef reader As StreamReader) As String
        Dim readString As String
        If reader.Peek > -1 Then
            readString = reader.ReadLine()
        Else
            readString = ""
        End If
        Return readString
    End Function


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If readValidInputTextFile(FILE_PATH) Then
            statusBarLabel.Text = "File is Loaded"
            workingString = stringReader.ReadLine() ''''''''''''
            processString(workingString)
        Else
            statusBarLabel.Text = "Input text file not found or is invalid"
        End If
    End Sub

    Private Sub processString(ByVal str As String)

        'Resize control:
        Dim g1 As Graphics
        Dim s1 As SizeF
        Dim marginBuffer As Integer
        g1 = Me.resizeFontLabel.CreateGraphics()    ''''''''''''''''''
        s1 = g1.MeasureString(str, resizeControlLabel.Font)
        marginBuffer = g1.MeasureString("  ", resizeControlLabel.Font).Width
        g1.Dispose()
        resizeControlLabel.Width = s1.Width + 20 * marginBuffer
        resizeControlLabel.Text = str

        'Resize font using original method:
        Dim f2 As Font
        Dim g2 As Graphics
        Dim s2 As SizeF
        Dim Faktor, FaktorX, FaktorY, FaktorV, FaktorW As Single
        g2 = Me.resizeFontLabel.CreateGraphics() ''''''''''''''
        s2 = g2.MeasureString("    " + str, resizeFontLabel.Font)
        g2.Dispose()
        FaktorV = s2.Width
        FaktorW = s2.Height
        FaktorX = resizeFontLabel.Width / s2.Width
        FaktorY = resizeFontLabel.Height / s2.Height

        If FaktorX > FaktorY Then
            Faktor = FaktorY
        Else
            Faktor = FaktorX
        End If
        f2 = resizeFontLabel.Font
        resizeFontLabel.Font = New Font(f2.Name, f2.SizeInPoints * Faktor)
        resizeFontLabel.Text = str

        'Resize cont using alternative method


    End Sub


    Private Sub nextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nextButton.Click
        If bWeHaveAValidInputFile Then
            workingString = getNextString(stringReader)
            If workingString <> "" Then
                processString(workingString)
            Else
                End
            End If
        End If
    End Sub
End Class
