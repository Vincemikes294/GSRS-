Public Class frmLogin

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "username" And TextBox2.Text = "password" Then
            MDI.mnuItems.Enabled = True
            Me.Close()
        Else : MsgBox("Sorry, The Username or Password was incorrect.", MsgBoxStyle.Critical, "Information")
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If

    End Sub
    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MDI.mnuItems.Enabled = False
    End Sub
End Class