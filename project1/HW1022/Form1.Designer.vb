<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblGreeting = New System.Windows.Forms.Label()
        Me.imgPicture = New System.Windows.Forms.PictureBox()
        CType(Me.imgPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(426, 379)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(104, 30)
        Me.btnExit.TabIndex = 0
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblGreeting
        '
        Me.lblGreeting.Location = New System.Drawing.Point(241, 22)
        Me.lblGreeting.Name = "lblGreeting"
        Me.lblGreeting.Size = New System.Drawing.Size(264, 49)
        Me.lblGreeting.TabIndex = 1
        '
        'imgPicture
        '
        Me.imgPicture.Location = New System.Drawing.Point(241, 102)
        Me.imgPicture.Name = "imgPicture"
        Me.imgPicture.Size = New System.Drawing.Size(264, 236)
        Me.imgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgPicture.TabIndex = 2
        Me.imgPicture.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 447)
        Me.Controls.Add(Me.imgPicture)
        Me.Controls.Add(Me.lblGreeting)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.imgPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents lblGreeting As Label
    Friend WithEvents imgPicture As PictureBox
End Class
