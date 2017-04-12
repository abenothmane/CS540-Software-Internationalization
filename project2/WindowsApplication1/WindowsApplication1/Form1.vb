Public Class Form1

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Label1.Text = "Good Day!"
        Label1.ForeColor = Color.Yellow
        Label1.BackColor = Color.Red
        Button1.Text = "Exit"
        Button1.ForeColor = Color.Yellow
        Button1.BackColor = Color.Red
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Label1.Text = "Jó nap !"
        Label1.ForeColor = Color.Yellow
        Label1.BackColor = Color.Red
        Button1.Text = "Kijárat"
        Button1.ForeColor = Color.Yellow
        Button1.BackColor = Color.Red
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub
End Class
