Imports System.IO
Imports Microsoft.Office.Interop.Excel
Public Class frmLogin
    Dim oExcel As Object
    Dim oBook As Object
    Dim oSheet As Object
    Dim sheetCount As Integer
    Public Path As String
    Dim MyFileDialog As New System.Windows.Forms.OpenFileDialog
    Dim strFile As String
    Dim i As Integer
    Dim j As Integer
    Dim k As Integer
    Dim usernames() As String
    Dim passwords() As String
    Dim initialusername As String
    Dim initialpassword As String
    Dim usernameverify As String
    Dim passwordverify As String
    Dim Newusernames() As String
    Dim NewPasswords() As String
    Dim adminusername As String
    Dim adminpassword As String
    Dim usernameinienabled As String
    Dim usernameindexenabled As String
    Dim loginenabledresult As String
    Dim passwordindexenabled As String
    Dim passwordinienabled As String
    Dim loginusername As String
    Dim loginpassword As String
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpassword.TextChanged

    End Sub
    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles butReset.Click
        Path = "C:\Users\Vince\Desktop\Research\Current Research\Automating the GSRS\Usernames.xlsx"
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Open(Path)
        oSheet = oBook.Worksheets(1)
        oSheet.activate()
        sheetCount = oSheet.Cells(oSheet.Rows.Count, "A").End(XlDirection.xlUp).row
        initialusername = "admin"
        initialpassword = "password"
        adminusername = InputBox("Please Enter admin username", "Alert")
        adminpassword = InputBox("Please Enter admin password", "Alert")
        usernameverify = InputBox("Please Enter new admin username", "Alert")
        passwordverify = InputBox("Please Enter new admin password", "Alert")
        Do While String.IsNullOrEmpty(adminusername) = True And String.IsNullOrEmpty(adminpassword) = True
            MsgBox("You are not authorized to reset the login credentials!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
        Do While String.IsNullOrEmpty(adminusername) = False And String.IsNullOrEmpty(adminpassword) = False
            For j = 2 To sheetCount
                For k = 2 To sheetCount
                    If oSheet.Cells(j, 5).Text = "Administrator" And oSheet.Cells(k, 5).Text = "Administrator" Then
                        ReDim Preserve usernames(j)
                        ReDim Preserve passwords(k)
                        usernames(j) = oSheet.Cells(j, 3).Text
                        passwords(k) = oSheet.Cells(k, 4).Text
                        Me.txtusername.Text = ""
                        Me.txtpassword.Text = ""
                    End If
                Next
            Next
            For Each username As String In usernames
                For Each password As String In passwords
                    If (adminusername = initialusername Or adminusername = username) And (adminpassword = initialpassword Or adminpassword = password) Then
                        For j = 2 To sheetCount
                            For k = 2 To sheetCount
                                If oSheet.Cells(j, 5).Text = "Administrator" And oSheet.Cells(k, 5).Text = "Administrator" Then
                                    oSheet.Cells(j, 3).Value = usernameverify
                                    oSheet.Cells(k, 4).Value = passwordverify
                                    MsgBox("Administrator credentials have been updated",, "Success")
                                    oSheet.SaveAs("C:\Users\Vince\Desktop\Research\Current Research\Automating the GSRS\Usernames.xlsx")
                                    Me.txtusername.Text = ""
                                    Me.txtpassword.Text = ""
                                End If
                            Next
                        Next
                    End If
                Next
            Next
            For Each username As String In usernames
                For Each password As String In passwords
                    If (adminusername <> initialusername Or adminusername <> username) And (adminpassword <> initialpassword Or adminpassword <> password) Then
                        MsgBox("You are not authorized to reset the login credentials!",, "Alert")
                        Me.txtusername.Text = ""
                        Me.txtpassword.Text = ""
                        Exit Sub
                    End If
                Next
            Next
        Loop
        Do While String.IsNullOrEmpty(usernameverify) = True And String.IsNullOrEmpty(passwordverify) = False
            MsgBox("You are not authorized to reset the login credentials!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
        Do While String.IsNullOrEmpty(usernameverify) = False And String.IsNullOrEmpty(passwordverify) = True
            MsgBox("You are not authorized to reset the login credentials!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
        Do While String.IsNullOrEmpty(adminusername) = True And String.IsNullOrEmpty(adminpassword) = False
            MsgBox("You are not authorized to reset the login credentials!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
        Do While String.IsNullOrEmpty(adminusername) = False And String.IsNullOrEmpty(adminpassword) = True
            MsgBox("You are not authorized to reset the login credentials!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
    End Sub
    Private Sub butlogin_Click(sender As Object, e As EventArgs) Handles butlogin.Click
        Path = "C:\Users\Vince\Desktop\Research\Current Research\Automating the GSRS\Usernames.xlsx"
        MyFileDialog.Filter = "(*.xlsx)|*.xlsx"
        MyFileDialog.Title = "Open excel file"
        MyFileDialog.FileName = Path
        If File.Exists(MyFileDialog.FileName) Then
            strFile = MyFileDialog.FileName
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Open(Path)
            oSheet = oBook.Worksheets(1)
            oSheet.activate()
            sheetCount = oSheet.Cells(oSheet.Rows.Count, "A").End(XlDirection.xlUp).row
        Else MsgBox("Login credentials do not exist", vbCritical, "Alert")
        End If
        initialusername = "admin"
        initialpassword = "password"
        loginusername = txtusername.Text
        loginpassword = txtpassword.Text
        Do While String.IsNullOrEmpty(loginusername) = True And String.IsNullOrEmpty(loginpassword) = True
            MsgBox("Please enter username and password!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
        Do While String.IsNullOrEmpty(loginusername) = False And String.IsNullOrEmpty(loginpassword) = False
            For j = 2 To sheetCount
                For k = 2 To sheetCount
                    ReDim Preserve usernames(j)
                    ReDim Preserve passwords(k)
                    usernames(j) = oSheet.Cells(j, 3).Text
                    passwords(k) = oSheet.Cells(k, 4).Text
                Next
            Next
            For Each username As String In usernames
                For Each password As String In passwords
                    If (loginusername = initialusername Or loginusername = username) And (loginpassword = initialpassword Or loginpassword = password) Then
                        frmMain.Show()
                        Me.txtusername.Text = ""
                        Me.txtpassword.Text = ""
                        Exit Sub
                    End If
                Next
            Next
            For Each username As String In usernames
                For Each password As String In passwords
                    If (loginusername <> initialusername Or loginusername <> username) And (loginpassword <> initialpassword Or loginpassword <> password) Then
                        MsgBox("Sorry, username or password isn't correct!",, "Alert")
                        Me.txtusername.Text = ""
                        Me.txtpassword.Text = ""
                        Exit Sub
                    End If
                Next
            Next
        Loop
        Do While String.IsNullOrEmpty(loginusername) = True And String.IsNullOrEmpty(loginpassword) = False
            MsgBox("Please enter username and password!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
        Do While String.IsNullOrEmpty(loginusername) = False And String.IsNullOrEmpty(loginpassword) = True
            MsgBox("Please enter username and password!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
    End Sub
    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub
    Private Sub butAddUser_Click(sender As Object, e As EventArgs) Handles butAddUser.Click
        Path = "C:\Users\Vince\Desktop\Research\Current Research\Automating the GSRS\Usernames.xlsx"
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Open(Path)
        oSheet = oBook.Worksheets(1)
        oSheet.activate()
        sheetCount = oSheet.Cells(oSheet.Rows.Count, "A").End(XlDirection.xlUp).row
        initialusername = "admin"
        initialpassword = "password"
        adminusername = InputBox("Please Enter admin username", "Alert")
        adminpassword = InputBox("Please Enter admin password", "Alert")
        Do While String.IsNullOrEmpty(adminusername) = True And String.IsNullOrEmpty(adminpassword) = True
            MsgBox("You are not authorized to view the user form!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
        Do While String.IsNullOrEmpty(adminusername) = False And String.IsNullOrEmpty(adminpassword) = False
            For j = 2 To sheetCount
                For k = 2 To sheetCount
                    If oSheet.Cells(j, 5).Text = "Administrator" And oSheet.Cells(k, 5).Text = "Administrator" Then
                        ReDim Preserve usernames(j)
                        ReDim Preserve passwords(k)
                        usernames(j) = oSheet.Cells(j, 3).Text
                        passwords(k) = oSheet.Cells(k, 4).Text
                    End If
                Next
            Next
            For Each username As String In usernames
                For Each password As String In passwords
                    If (adminusername = initialusername Or adminusername = username) And (adminpassword = initialpassword Or adminpassword = password) Then
                        frmUserForm.Show()
                        Me.txtusername.Text = ""
                        Me.txtpassword.Text = ""
                        Exit Sub
                    End If
                Next
            Next
            For Each username As String In usernames
                For Each password As String In passwords
                    If (adminusername <> initialusername Or adminusername <> username) And (adminpassword <> initialpassword Or adminpassword <> password) Then
                        MsgBox("You are not authorized to view the user form!",, "Alert")
                        Me.txtusername.Text = ""
                        Me.txtpassword.Text = ""
                        Exit Sub
                    End If
                Next
            Next
        Loop
        Do While String.IsNullOrEmpty(adminusername) = True And String.IsNullOrEmpty(adminpassword) = False
            MsgBox("You are not authorized to view the user form!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
        Do While String.IsNullOrEmpty(adminusername) = False And String.IsNullOrEmpty(adminpassword) = True
            MsgBox("You are not authorized to view the user form!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Do
        Loop
    End Sub
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        butAddUser.Enabled = True
    End Sub
End Class