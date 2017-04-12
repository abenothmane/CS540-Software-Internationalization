Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Resources
Imports System.Threading
Imports System.Windows.Forms

Namespace Homework_10

    ''' <summary>
    ''' Summary description for Form1.
    ''' </summary>
    Public Class Form1
        Inherits Form

        Private currentResX As ResXResourceSet

        ' pointer to resX of current culture
        Private imgFlags As ArrayList

        ' dynamic array for storing up to 5 flag images
        Private components As Container = Nothing

        Private Const WS_EX_LAYOUTRTL As Integer = 4194304

        ' used for mirroring
        Private Const WS_EX_NOINHERITLAYOUT As Integer = 1048576

        Private lblGreeting As System.Windows.Forms.Label

        Private btnExit As System.Windows.Forms.Button

        Private imgPicture As System.Windows.Forms.PictureBox

        Private _mirrored As Boolean = False

        <Description("Change to the right-to-left layout."),
         DefaultValue(False),
         Localizable(True),
         Category("Appearance"),
         Browsable(True)>
        Private Property Mirrored As Boolean
            Get
                Return Me._mirrored
            End Get
            Set
                If (Me._mirrored <> Value) Then
                    Me._mirrored = Value
                    MyBase.OnRightToLeftChanged(EventArgs.Empty)
                End If

                ' if mirrored = true, set right to left on form
                If Me._mirrored Then
                    Me.RightToLeft = RightToLeft.Yes
                Else
                    Me.RightToLeft = RightToLeft.No
                End If

            End Set
        End Property

        ''' <summary>
        ''' System override for application of mirroring property
        ''' </summary>
        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim CP As CreateParams = MyBase.CreateParams
                If Me.Mirrored Then
                    CP.ExStyle = (CP.ExStyle _
                                Or (WS_EX_LAYOUTRTL Or WS_EX_NOINHERITLAYOUT))
                End If

                Return CP
            End Get
        End Property

        ''' <summary>
        ''' Form1 constructor
        ''' </summary>
        Public Sub New()
            MyBase.New
            Me.InitializeComponent()
            Me.imgFlags = New ArrayList(5)
            ' set max number of flags to 5
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If (Not (Me.components) Is Nothing) Then
                    Me.components.Dispose()
                End If

            End If

            MyBase.Dispose(disposing)
        End Sub
#Region "Windows Form Designer generated code"

        Private Sub InitializeComponent()
            Me.lblGreeting = New System.Windows.Forms.Label
            Me.btnExit = New System.Windows.Forms.Button
            Me.imgPicture = New System.Windows.Forms.PictureBox
            Me.SuspendLayout()
            ' 
            ' lblGreeting
            ' 
            Me.lblGreeting.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGreeting.Location = New System.Drawing.Point(264, 24)
            Me.lblGreeting.Name = "lblGreeting"
            Me.lblGreeting.Size = New System.Drawing.Size(344, 72)
            Me.lblGreeting.TabIndex = 0
            Me.lblGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' btnExit
            ' 
            Me.btnExit.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnExit.Location = New System.Drawing.Point(360, 384)
            Me.btnExit.Name = "btnExit"
            Me.btnExit.Size = New System.Drawing.Size(160, 40)
            Me.btnExit.TabIndex = 1
            AddHandler Me.btnExit.Click, AddressOf Me.exit_Click
            ' 
            ' imgPicture
            ' 
            Me.imgPicture.Location = New System.Drawing.Point(264, 112)
            Me.imgPicture.Name = "imgPicture"
            Me.imgPicture.Size = New System.Drawing.Size(344, 248)
            Me.imgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.imgPicture.TabIndex = 2
            Me.imgPicture.TabStop = False
            ' 
            ' Form1
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(640, 446)
            Me.Controls.Add(Me.imgPicture)
            Me.Controls.Add(Me.btnExit)
            Me.Controls.Add(Me.lblGreeting)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "Form1"
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.Text = "CS 540 - Example Code for HW #10"
            AddHandler Load, AddressOf Me.Form1_Load
            Me.ResumeLayout(False)
        End Sub
#End Region

        <STAThread()>
        Private Shared Sub Main()
            Application.Run(New Form1)
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.btnExit.Visible = False
            ' scan executable path for .resx files
            For Each strFileName As String In Directory.GetFiles(Application.StartupPath)
                If strFileName.EndsWith(".resx") Then
                    ' if there is enough room in the flag arraylist...
                    If (Me.imgFlags.Count < Me.imgFlags.Capacity) Then
                        Dim resources As ResXResourceSet = New ResXResourceSet(strFileName)
                        ' check for a culture value
                        If (Not (resources.GetString("culture")) Is Nothing) Then
                            ' create a new picturebox for the flag and add event handler
                            Dim pbxFlag As PictureBox = New PictureBox
                            AddHandler pbxFlag.Click, AddressOf Me.Flag_Click
                            pbxFlag.Size = New Size(152, 72)
                            pbxFlag.SizeMode = PictureBoxSizeMode.StretchImage
                            pbxFlag.Tag = strFileName
                            ' make sure there is a valid flag path
                            If ((Not (resources.GetString("flag_path")) Is Nothing) _
                                        AndAlso File.Exists(resources.GetString("flag_path"))) Then
                                pbxFlag.Image = Image.FromFile(resources.GetString("flag_path"))
                            Else
                                pbxFlag.Image = Me.GenerateFlag(resources.GetString("culture"))
                            End If

                            If (Me.imgFlags.Count = 0) Then
                                pbxFlag.Location = New Point(16, 32)
                            Else
                                pbxFlag.Location = New Point(CType(Me.imgFlags(0), PictureBox).Location.X, (CType(Me.imgFlags((Me.imgFlags.Count - 1)), PictureBox).Location.Y _
                                                + (pbxFlag.Size.Height + 8)))
                            End If

                            Me.Controls.Add(pbxFlag)
                            ' add image to the control array
                            Me.imgFlags.Add(pbxFlag)
                            ' add image to the flags arraylist
                        Else
                            ' no culture specified...  
                            ' skip this resx for now...
                        End If

                    End If

                End If

            Next
        End Sub

        Private Function GenerateFlag(ByVal strText As String) As Image
            Dim bmp As Bitmap = New Bitmap(1, 1)
            ' create an initial image
            Dim graphics As Graphics = System.Drawing.Graphics.FromImage(bmp)
            ' graphics object
            Dim brush As SolidBrush = New SolidBrush(Color.White)
            ' brush for drawing text
            Dim font As Font = New Font("Tahoma", 14, FontStyle.Bold)
            ' font for text
            Dim stringformat As StringFormat = New StringFormat(StringFormat.GenericTypographic)
            ' get sizes for bitmap, so text will fit
            Dim intHeight As Integer = Convert.ToInt32(graphics.MeasureString(strText, font, New PointF(0, 0), stringformat).Height)
            Dim intWidth As Integer = ((152 / 14) _
                        + Convert.ToInt32(graphics.MeasureString(strText, font, New PointF(0, 0), stringformat).Width))
            bmp = New Bitmap(intWidth, intHeight)
            ' resize image
            graphics = System.Drawing.Graphics.FromImage(bmp)
            graphics.Clear(Color.Black)
            graphics.TextRenderingHint = TextRenderingHint.SystemDefault
            ' draw text on canvas
            graphics.DrawString(strText.Replace(Microsoft.VisualBasic.ChrW(34), Microsoft.VisualBasic.ChrW(32)), font, brush, New Rectangle(0, 0, intWidth, intHeight))
            ' dispose of objects
            font.Dispose()
            stringformat.Dispose()
            graphics.Dispose()
            Return bmp
        End Function

        ''' <summary>
        ''' Generic event handler for click event on all flag images
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub Flag_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim graphics As Graphics = Me.lblGreeting.CreateGraphics
            Dim font As Font = New Font("Tahoma", 12)
            Dim fltFactorY As Single
            Dim fltFactor As Single
            Dim fltFactorX As Single
            Me.currentResX = New ResXResourceSet(CType(sender, PictureBox).Tag.ToString)
            ' display greeting, if available
            If (Not (Me.currentResX.GetString("greeting")) Is Nothing) Then
                Me.lblGreeting.Text = Me.currentResX.GetString("greeting")
            Else
                Me.lblGreeting.Text = "our default"
            End If

            ' resize font so text will fit
            fltFactorY = (Me.lblGreeting.Height / graphics.MeasureString(("  " _
                            + (Me.lblGreeting.Text + "  ")), font).Height)
            fltFactorX = (Me.lblGreeting.Width / graphics.MeasureString(("  " _
                            + (Me.lblGreeting.Text + "  ")), font).Width)
            If (fltFactorX > fltFactorY) Then
                fltFactor = fltFactorY
            Else
                fltFactor = fltFactorX
            End If

            Me.lblGreeting.Font = New Font(font.Name, (font.SizeInPoints * fltFactor))
            ' display representative image, if available
            If ((Not (Me.currentResX.GetString("image")) Is Nothing) _
                        AndAlso File.Exists(Me.currentResX.GetString("image"))) Then
                Me.imgPicture.Image = Image.FromFile(Me.currentResX.GetString("image"))
            Else
                Me.imgPicture.Image = Nothing
            End If

            ' display exit text, if available
            If (Not (Me.currentResX.GetString("exit")) Is Nothing) Then
                Me.btnExit.Text = Me.currentResX.GetString("exit")
            Else
                Me.btnExit.Text = "our default"
            End If

            ' resize exit font to fit button
            fltFactorY = (Me.btnExit.Height / graphics.MeasureString(("  " _
                            + (Me.btnExit.Text + "  ")), font).Height)
            fltFactorX = (Me.btnExit.Width / graphics.MeasureString(("  " _
                            + (Me.btnExit.Text + "  ")), font).Width)
            If (fltFactorX > fltFactorY) Then
                fltFactor = fltFactorY
            Else
                fltFactor = fltFactorX
            End If

            Me.btnExit.Font = New Font(font.Name, (font.SizeInPoints * fltFactor))
            Me.btnExit.Visible = True
            ' set rtl property if rtl is set in ResX file
            If (Not (Me.currentResX.GetString("rtl")) Is Nothing) Then
                Me.Mirrored = Convert.ToBoolean(Me.currentResX.GetString("rtl"))
            Else
                Me.Mirrored = False
            End If

        End Sub

        Private Sub exit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.Close()
        End Sub
    End Class
End Namespace