Imports System.Data.OleDb
Imports System.IO
Public Class frmUserForm
    Dim FirstName As String
    Dim LastName As String
    Dim Username As String
    Dim Password As String
    Dim Status As String
    Private Sub butAdd_Click(sender As Object, e As EventArgs) Handles butAdd.Click
        FirstName = txtFirstName.Text
        LastName = txtLastName.Text
        Username = txtUsername.Text
        Password = txtPassword.Text
        Status = cboStatus.Text
        lstViewUsers.View = View.Details
        lstViewUsers.Items.Add(New ListViewItem(New String() {FirstName, LastName, Username, Password, Status}))
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""

    End Sub
    Private Sub butDelete_Click(sender As Object, e As EventArgs) Handles butDelete.Click
        For Each item As ListViewItem In lstViewUsers.SelectedItems
            item.Remove()
        Next
    End Sub
    Private Sub frmUserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstViewUsers.View = View.Details
        lstViewUsers.Columns.Add("First Name", 100, HorizontalAlignment.Center)
        lstViewUsers.Columns.Add("Last Name", 100, HorizontalAlignment.Center)
        lstViewUsers.Columns.Add("Username", 100, HorizontalAlignment.Center)
        lstViewUsers.Columns.Add("Password", 100, HorizontalAlignment.Center)
        lstViewUsers.Columns.Add("Status", 100, HorizontalAlignment.Center)
        lstViewUsers.Columns.Add(vbCrLf)

    End Sub

    Private Sub lstViewUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstViewUsers.SelectedIndexChanged

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles butSave.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim lview As ListViewItem
        Dim lview2 As ListViewItem.ListViewSubItem
        Dim row, col As Integer

        'Start a new workbook in Excel

        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add
        oSheet = oBook.Worksheets(1)

        oSheet.Cells(1, 1) = "First Name"
        oSheet.Cells(1, 2) = "Last Name"
        oSheet.Cells(1, 3) = "Username"
        oSheet.Cells(1, 4) = "Password"
        oSheet.Cells(1, 5) = "Status"

        row = 2
        col = 1
        For Each lview In lstViewUsers.Items

            oSheet.Cells(row, col) = lview.Text

            For Each lview2 In lview.SubItems

                oSheet.Cells(row, col) = lview2.Text

                col = col + 1

            Next

            col = 1

            row = row + 1

        Next

        'Save the Workbook and Quit Excel

        oBook.SaveAs("C:\Users\Vince\Desktop\Research\Current Research\Automating the GSRS\Usernames.xlsx")

        oExcel.Quit()


        MsgBox("Data has been successfully exported to" & " C:\Users\Vince\Desktop\Research\Current Research\Automating the GSRS\Usernames.xlsx", MsgBoxStyle.Information)
    End Sub
    Private Sub butLoad_Click(sender As Object, e As EventArgs) Handles butLoad.Click
        Dim MyFileDialog As New System.Windows.Forms.OpenFileDialog
        MyFileDialog.Filter = "(*.xlsx)|*.xlsx"
        MyFileDialog.Title = "Open excel file"
        MyFileDialog.FileName = "C:\Users\Vince\Desktop\Research\Current Research\Automating the GSRS\Usernames.xlsx"
        If File.Exists(MyFileDialog.FileName) Then
            Dim strFile As String = MyFileDialog.FileName
            Dim reader As StreamReader
            reader = New StreamReader(New FileStream(strFile, FileMode.Open))

            ' If the file was not found, tell the user.

        Else MessageBox.Show("File was Not found. Please try again.", "Alert!!")
            Exit Sub
        End If

        Dim con As New OleDbConnection
        Dim Exfilepath As String = "C:\Users\Vince\Desktop\Research\Current Research\Automating the GSRS\Usernames.xlsx"
        Dim da As New OleDbDataAdapter("Select * from [Sheet1$]", con)
        Dim dt As New DataTable
        Dim ds As New DataSet
        con.ConnectionString = "provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & Exfilepath & "';Extended Properties=Excel 8.0;"
        con.Open()
        ds.Tables.Add(dt)
        da.Fill(dt)
        For Each myRow In dt.Rows
            lstViewUsers.Items.Add(myRow.Item(0))
            lstViewUsers.Items(lstViewUsers.Items.Count - 1).SubItems.Add(myRow.Item(1))
            lstViewUsers.Items(lstViewUsers.Items.Count - 1).SubItems.Add(myRow.Item(2))
            lstViewUsers.Items(lstViewUsers.Items.Count - 1).SubItems.Add(myRow.Item(3))
            lstViewUsers.Items(lstViewUsers.Items.Count - 1).SubItems.Add(myRow.Item(4))
        Next

        con.Close()
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub
End Class

