Public Class frmLogin
    Dim username As String
    Dim password As String
    Dim Newusername As String
    Dim NewPassword As String
    Dim usernameverify As String
    Dim passwordverify As String
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpassword.TextChanged

    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtusername.TextChanged

    End Sub
    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles butReset.Click
        usernameverify = InputBox("Enter administrator username", "Reset")
        passwordverify = InputBox("Enter administrator password", "Reset")
        If usernameverify = username And passwordverify = password Then
            username = InputBox("Enter new username", "Reset")
            Newusername = username
            password = InputBox("Enter new password", "Reset")
            NewPassword = password
            butReset.Enabled = False
        Else MsgBox("You don't have authorization to change login credentials",, "Wrong Credentials")
        End If
    End Sub
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub frmLogin_Click(sender As Object, e As EventArgs) Handles Me.Click

    End Sub
    Private Sub butlogin_Click(sender As Object, e As EventArgs) Handles butlogin.Click
        If butReset.Enabled = False Then
            If username = Newusername And password = NewPassword Then
                If txtusername.Text = username And txtpassword.Text = password Then
                    Me.Close()
                    frmMain.Show()
                Else MsgBox("Sorry, username or password is incorrect", vbCritical, "Alert")
                    txtusername.Text = ""
                    txtpassword.Text = ""
                End If
            End If
        ElseIf butReset.Enabled = True Then
            username = "admin"
            password = "password"
            If txtusername.Text = username And txtpassword.Text = password Then
                Me.Close()
                frmMain.Show()
            Else MsgBox("Sorry, username or password is incorrect", vbCritical, "Alert")
                txtusername.Text = ""
                txtpassword.Text = ""
            End If
        End If
    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub butAddUser_Click(sender As Object, e As EventArgs) Handles butAddUser.Click
        Dim adminusername As String
        Dim adminpassword As String
        frmUserForm.Show()
        frmUserForm.Hide()
        adminusername = InputBox("Please Enter admin username", "Alert")
        adminpassword = InputBox("Please Enter admin password", "Alert")
        frmUserForm.Show()
    End Sub
End Class