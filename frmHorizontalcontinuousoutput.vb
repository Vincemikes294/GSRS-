Public Class frmHorizontal
    Private Sub butFilter_Click(sender As Object, e As EventArgs) Handles butFilter.Click
        Dim header As String = lstFinalOutputView.Items(0)
        Dim T_max = frmMain.cboMaxTemp.Text
        Dim data As New List(Of DataValue)
        ' Skip the header row by starting at 1:
        For i As Integer = 1 To lstFinalOutputView.Items.Count - 1
            data.Add(New DataValue(lstFinalOutputView.Items(i)))
        Next

        Dim results = From dv In data
        lstFinalOutputView.Items.Clear()
        lstFinalOutputView.Items.Add(header)


        For Each row In results
            If row.T_Final < T_max Then
                lstFinalOutputView.Items.Add(row.ToString)

            End If
        Next


        Dim header1 As String = lstFinalOutputView.Items(0)

        Dim data1 As New List(Of DataValue)
        ' Skip the header row by starting at 1:
        For i As Integer = 1 To lstFinalOutputView.Items.Count - 1
            data1.Add(New DataValue(lstFinalOutputView.Items(i)))
        Next

        Dim finalresults = From dv In data1
                           Order By dv.MaxWeight Descending, dv.MaxSpeed Descending
                           Group dv By dv.MaxWeight Into g = Group
                           Select g.First

        Dim V_max = CInt(frmMain.txtMaxSpeed.Text)
        lstFinalOutputView.Items.Clear()
        lstFinalOutputView.Items.Add(header)


        For Each row In finalresults
            lstFinalOutputView.Items.Add(row.ToString)
            If row.MaxSpeed = V_max Then
                Exit For
            End If
        Next

    End Sub
    Public Class DataValue
        Public Sub New(ByVal strInput As String)
            Dim values() As String = strInput.Split({" ", vbTab}, StringSplitOptions.RemoveEmptyEntries)
            If values.Length >= 6 Then
                Try
                    MaxWeight = Integer.Parse(values(0))
                    MaxSpeed = Integer.Parse(values(1))
                    T_Desc = Integer.Parse(values(2))
                    T_Emerg = Integer.Parse(values(3))
                    T_Final = Integer.Parse(values(4))
                    Time = Integer.Parse(values(5))
                Catch ex As Exception
                    MessageBox.Show("Invalid Input: Value failed to convert to Integer.")
                End Try
            Else
                MessageBox.Show("Invalid Input: Not enough values.")
            End If
        End Sub
        Public Overrides Function ToString() As String
            Return MaxWeight & vbTab & vbTab & MaxSpeed & vbTab & vbTab & T_Desc & vbTab & vbTab & T_Emerg & vbTab & vbTab & T_Final & vbTab & vbTab & Time
        End Function

        Public MaxWeight As Integer
        Public MaxSpeed As Integer
        Public Time As Integer
        Public T_Emerg As Integer
        Public T_Final As Integer
        Public T_Desc As Integer

    End Class
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles butSave.Click
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Text Files(*.txt)|*.txt|(*.xls)|*.xls"

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim sb As New System.Text.StringBuilder()

            For Each o As Object In Me.lstFinalOutputView.Items
                sb.AppendLine(o)
            Next

            System.IO.File.WriteAllText(SaveFileDialog1.FileName, sb.ToString())
        End If
    End Sub

    Private Sub butReset_Click(sender As Object, e As EventArgs) Handles butReset.Click
        lstFinalOutputView.Items.Clear()
    End Sub
    Private Sub butLoad_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lstFinalOutputView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFinalOutputView.SelectedIndexChanged

    End Sub
End Class