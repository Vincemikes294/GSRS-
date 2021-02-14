Imports System.IO
Imports Microsoft.Office.Interop.Excel
Public Class frmLogin
    Public Path As String = "C:\Users\Vince\Desktop\Research\Current Research\Automating the GSRS\GSRS with horizontal curve v 1.0\bin\Debug\Usernames.xlsx"
    Dim oExcel As Object = CreateObject("Excel.Application")
    Dim oBook As Object = oExcel.Workbooks.Open(Path)
    Dim oSheet As Object = oBook.Worksheets(1)
    Dim sheetCount As Integer
    Dim MyFileDialog As New System.Windows.Forms.OpenFileDialog
    Dim strFile As String
    Dim i As Integer
    Dim j As Integer
    Dim k As Integer
    Dim l As Integer
    Dim username() As String
    Dim password() As String
    Dim usernames() As String
    Dim passwords() As String
    Dim initialusername As String
    Dim initialpassword As String
    Dim usernameverify As String
    Dim passwordverify As String
    Dim adminusername As String
    Dim adminpassword As String
    Dim loginusername As String
    Dim loginpassword As String
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles butReset.Click
        Dim processes() As Process = Process.GetProcesses
        For p As Integer = processes.Count - 1 To 0 Step -1
            If processes(p).ProcessName = "EXCEL" Then
                processes(p).Kill()
            End If
        Next
        oExcel = CreateObject("Excel.Application")
        Dim Path As String = "C:\Users\Vince\Desktop\Research\Current Research\Automating the GSRS\GSRS with horizontal curve v 1.0\bin\Debug\Usernames.xlsx"
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
            Exit Sub
        Loop
        Do While String.IsNullOrEmpty(adminusername) = False And String.IsNullOrEmpty(adminpassword) = False
            For j = 2 To sheetCount
                ReDim Preserve usernames(j)
                ReDim Preserve passwords(j)
                If oSheet.Cells(j, 5).Text = "Administrator" Then
                    usernames(j) = oSheet.Cells(j, 3).Value
                    passwords(j) = oSheet.Cells(j, 4).Value
                End If
            Next

            For Each username As String In usernames
                For Each password As String In passwords
                    If oSheet.Cells(j, 5).Text = "Administrator" Then
                        If (adminusername = initialusername Or adminusername = usernames(j)) And (adminpassword = initialpassword Or adminpassword = passwords(j)) Then
                            oSheet.Cells(j, 3).Value = usernameverify
                            oSheet.Cells(j, 4).Value = passwordverify
                            Dim filefinal As IO.FileInfo = My.Computer.FileSystem.GetFileInfo("Usernames.xlsx")
                            filefinal.IsReadOnly = False
                            oSheet.SaveAs(Path)
                            MsgBox("Administrator credentials have been updated",, "Success")
                            oExcel.Workbooks.Close()
                            oExcel.Quit()
                            Me.txtusername.Text = ""
                            Me.txtpassword.Text = ""
                            Exit Sub
                        ElseIf (adminusername <> usernames(j)) And (adminpassword <> passwords(j)) Then
                            MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
                            Me.txtusername.Text = ""
                            Me.txtpassword.Text = ""
                            Exit Sub
                        ElseIf (adminusername = usernames(j)) And (adminpassword <> passwords(j)) Then
                            MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
                            Me.txtusername.Text = ""
                            Me.txtpassword.Text = ""
                            Exit Sub
                        ElseIf (adminusername <> usernames(j)) And (adminpassword = passwords(j)) Then
                            MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
                            Me.txtusername.Text = ""
                            Me.txtpassword.Text = ""
                            Exit Sub
                        End If
                    End If
                Next
            Next
            For j = 2 To sheetCount
                ReDim Preserve usernames(j)
                ReDim Preserve passwords(j)

                If oSheet.Cells(j, 5).Text = "Regular User" Then
                    usernames(j) = oSheet.Cells(j, 3).Value
                    passwords(j) = oSheet.Cells(j, 4).Value
                End If
            Next

            For Each username As String In usernames
                For Each password As String In passwords
                    If oSheet.Cells(j, 5).Text = "Regular User" Then
                        If (adminusername = initialusername Or adminusername = usernames(j)) And (adminpassword = initialpassword Or adminpassword Is passwords(j)) Then
                            MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
                            Me.txtusername.Text = ""
                            Me.txtpassword.Text = ""
                            Exit Sub
                        ElseIf (adminusername <> usernames(j)) And (adminpassword <> passwords(j)) Then
                            MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
                            Me.txtusername.Text = ""
                            Me.txtpassword.Text = ""
                            Exit Sub
                        ElseIf (adminusername = usernames(j)) And (adminpassword <> passwords(j)) Then
                            MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
                            Me.txtusername.Text = ""
                            Me.txtpassword.Text = ""
                            Exit Sub
                        ElseIf (adminusername <> usernames(j)) And (adminpassword = passwords(j)) Then
                            MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
                            Me.txtusername.Text = ""
                            Me.txtpassword.Text = ""
                            Exit Sub
                        End If
                    End If
                Next
            Next
        Loop
        Do While String.IsNullOrEmpty(adminusername) = True And String.IsNullOrEmpty(adminpassword) = False
                MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
                Me.txtusername.Text = ""
                Me.txtpassword.Text = ""
                Exit Sub
            Loop
            Do While String.IsNullOrEmpty(adminusername) = False And String.IsNullOrEmpty(adminpassword) = True
            MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Sub
        Loop
        Do While String.IsNullOrEmpty(adminusername) = True And String.IsNullOrEmpty(adminpassword) = False
            MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Sub
        Loop
        Do While String.IsNullOrEmpty(adminusername) = False And String.IsNullOrEmpty(adminpassword) = True
            MsgBox("You are Not authorized To reset the login credentials!",, "Alert")
            Me.txtusername.Text = ""
            Me.txtpassword.Text = ""
            Exit Sub
        Loop
    End Sub
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        butAddUser.Enabled = True
    End Sub

    Private Sub butlogin_Click(sender As Object, e As EventArgs) Handles butlogin.Click
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
        Else MsgBox("Login credentials Do Not exist", vbCritical, "Alert")
        End If
        initialusername = "admin"
        initialpassword = "password"
        loginusername = txtusername.Text
        loginpassword = txtpassword.Text
        Do While String.IsNullOrEmpty(loginusername) = True And String.IsNullOrEmpty(loginpassword) = True
            MsgBox("Please enter username And password!",, "Alert")
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
                        Exit Do
                    End If
                Next
            Next
            For Each username As String In usernames
                For Each password As String In passwords
                    If (loginusername <> initialusername Or loginusername <> username) And (loginpassword <> initialpassword Or loginpassword <> password) Then
                        MsgBox("Sorry, username Or password isn't correct!",, "Alert")
                        Exit Do
                    End If
                Next
            Next
        Loop
        Do While String.IsNullOrEmpty(loginusername) = True And String.IsNullOrEmpty(loginpassword) = False
            MsgBox("Please enter username and password!",, "Alert")
            Exit Do
        Loop
        Do While String.IsNullOrEmpty(loginusername) = False And String.IsNullOrEmpty(loginpassword) = True
            MsgBox("Please enter username and password!",, "Alert")
            Exit Do
        Loop
        Me.txtusername.Text = ""
        Me.txtpassword.Text = ""
    End Sub
    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub
    Private Sub butAddUser_Click(sender As Object, e As EventArgs) Handles butAddUser.Click
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
                        Exit Do
                    End If
                Next
            Next
            For Each username As String In usernames
                For Each password As String In passwords
                    If (adminusername <> initialusername Or adminusername <> username) And (adminpassword <> initialpassword Or adminpassword <> password) Then
                        MsgBox("You are not authorized to view the user form!",, "Alert")
                        Exit Do
                    End If
                Next
            Next
        Loop
        Do While String.IsNullOrEmpty(adminusername) = True And String.IsNullOrEmpty(adminpassword) = False
            MsgBox("You are not authorized to view the user form!",, "Alert")
            Exit Do
        Loop
        Do While String.IsNullOrEmpty(adminusername) = False And String.IsNullOrEmpty(adminpassword) = True
            MsgBox("You are not authorized to view the user form!",, "Alert")
            Exit Do
        Loop
        Me.txtusername.Text = ""
        Me.txtpassword.Text = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class