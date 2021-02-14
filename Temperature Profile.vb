Imports System.ComponentModel

Public Class frmTempProfile
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles buttempCompute.Click
        Dim W As String
        Dim W_Input As String
        Dim V As String
        Dim V_Input As String
        Dim T_0 As String
        Dim T_0_input As String
        Dim T_inf As String
        Dim Length As Integer
        Dim T_e(,) As Double
        Dim HP_eng As Double
        Dim K2 As Double
        Dim K1 As Double
        Dim F_Drag As Double
        Dim Theta As Double
        Dim L As Double
        Dim HP_b As Double
        Dim i As Double
        Dim j As Integer
        Dim TLtotal As Double
        Dim TL As Double() = {0.0}
        Dim T_f(,) As Double
        Dim T_f_s As Integer
        Dim T_lim_s As Integer
        Dim T_e_s As Integer
        Dim T_lim(,) As Double
        Dim Vs As Integer
        Dim k As Integer

        lstTempProfile.Items.Clear()
        If IsNumeric(txttempWeight.Text) And txttempWeight.Text <> "" And txttempWeight.Text > "0" Then
            W = txttempWeight.Text
        Else : MsgBox("Please Enter a positive numeric value for Weight")
            W_Input = (InputBox("Enter a positive numeric value "))
            Do While IsNumeric(W_Input) = False Or W_Input < "0"
                MessageBox.Show("Please enter a positive numeric Value for Weight")
                W_Input = (InputBox("Enter a positive numeric value for Weight"))
            Loop
            W = CDbl(W_Input)
            txttempWeight.Text = W
        End If
        If IsNumeric(txtTempSpeed.Text) And txtTempSpeed.Text <> "" And txtTempSpeed.Text > "0" Then
            V = txtTempSpeed.Text
        Else : MsgBox("Please Enter a positive numeric value for Speed")
            V_Input = (InputBox("Enter a positive numeric value for Speed"))
            Do While IsNumeric(V_Input) = False Or V_Input < "0"
                MessageBox.Show("Please enter a positive numeric Value for Speed")
                V_Input = (InputBox("Enter a positive numeric value  Speed"))
            Loop
            V = CDbl(V_Input)
            txtTempSpeed.Text = V
        End If
        If IsNumeric(txtinibraketemp.Text) Then
            If txtinibraketemp.Text >= 90 Then
                T_0 = txtinibraketemp.Text
                txtinibraketemp.Text = T_0
            ElseIf txtinibraketemp.Text < 90 Then
                T_0 = "150"
                txtinibraketemp.Text = T_0
            End If
        Else : MsgBox("Enter a numeric value greater or equal to 90 for Initial Temperature")
            T_0_input = (InputBox("Enter a numeric value greater or equal to 90 for Initial Temperature", "Alert", "150"))
            Do While IsNumeric(T_0_input) = False Or T_0_input = ""
                MessageBox.Show("Enter a numeric value greater or equal to 90 for Initial Temperature")
                T_0_input = (InputBox("Enter a numeric value greater or equal to 90 for Initial Temperature", "Alert", "150"))
            Loop
            If T_0_input >= 90 Then
                T_0 = T_0_input
                txtinibraketemp.Text = T_0
            ElseIf T_0_input < 90 Then
                T_0 = "150"
                txtinibraketemp.Text = T_0
            End If
        End If

        'Computations
        lstTempProfile.Items.Add("Weight (lb)" & "     Speed (mph)" & "    Distance (miles) " & "    Grade (%)" & vbTab & "   T_Desc (F) " & vbTab & "     T_Emerg (F)" & vbTab & "    T_Final (F)" & vbCrLf)

        For i = 1 To CInt(frmMain.txtNumSections.Text)
            TLtotal += frmMain.Length(i)
        Next

        For j = 1 To CInt(frmMain.txtNumSections.Text)
            ReDim Preserve TL(j)
            TL(j) = TL(j - 1) + frmMain.Length(j)
        Next

        TL(0) = 0
        j = 0

        Do Until j = CInt(frmMain.txtNumSections.Text)
            j = j + 1
            For i = 0 To TLtotal Step 0.5
                If i <= TL(j) And i > TL(j - 1) Then

                    ReDim T_e(V, 1)
                    T_e(V, 1) = (0.000000311) * W * (V ^ 2) 'temperature from emergency stopping
                    HP_eng = 63.3 'Engine brake force
                    K2 = 1 / (0.1602 + 0.0078 * V) 'Heat transfer parameter
                    K1 = 1.5 * (1.1852 + 0.0331 * V) 'Diffusivity constant
                    F_Drag = 459.35 + 0.132 * (V ^ 2) 'Drag forces

                    Theta = frmMain.Grade(j)
                    L = 0.5
                    HP_b = (W * Theta - F_Drag) * (V / 375) - 63.3 'power into brakes
                    ReDim T_f(V, 1)
                    T_f(V, 1) = T_0 + (T_inf - T_0 + K2 * HP_b) * (1 - Math.Exp(-K1 * (L / V)))
                    T_0 = T_f(V, 1)
                    ReDim T_lim(V, 1)
                    T_lim(V, 1) = T_f(V, 1) + T_e(V, 1)    'limiting brake temperature

                    Vs = V
                    T_lim_s = CInt(T_lim(Vs, 1))
                    T_f_s = CInt(T_f(Vs, 1))
                    T_e_s = CInt(T_e(Vs, 1))

                    lstTempProfile.Items.Add(W & vbTab & vbTab & Vs & vbTab & i & vbTab & vbTab & Theta & vbTab & vbTab & T_f_s & vbTab & vbTab & T_e_s & vbTab & vbTab & T_lim_s & vbCrLf)

                    frmTemperaturePlot.s.Points.AddXY(i, T_lim_s)
                End If
            Next
        Loop
        butPlot.Enabled = True
        buttempCompute.Enabled = False
        butfilter.Enabled = True
    End Sub
    Private Sub frmTempProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txttempWeight.Text = frmMain.txtMaxWeight.Text
        Me.txtTempSpeed.Text = frmMain.txtMaxSpeed.Text
        Me.txtinibraketemp.Text = frmMain.txtinitemp.Text
    End Sub
    Private Sub buttempSave_Click(sender As Object, e As EventArgs) Handles buttempSave.Click
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Text Files(*.txt)|*.txt|(*.xls)|*.xls|All Files (*.*)|*.*"

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim sb As New System.Text.StringBuilder()

            For Each o As Object In lstTempProfile.Items
                sb.AppendLine(o)
            Next

            System.IO.File.WriteAllText(SaveFileDialog1.FileName, sb.ToString())
        End If
    End Sub
    Private Sub buttempReset_Click(sender As Object, e As EventArgs) Handles buttempReset.Click
        lstTempProfile.Items.Clear()
        txtTempSpeed.Text = ""
        txttempWeight.Text = ""
        txtinibraketemp.Text = ""
        butPlot.Enabled = False
        butfilter.Enabled = False
    End Sub
    Private Sub butfilter_Click(sender As Object, e As EventArgs) Handles butfilter.Click
        buttempSave.Enabled = True
        Dim header As String = lstTempProfile.Items(0)

        Dim data As New List(Of DataValue)
        ' Skip the header row by starting at 1:
        For i As Integer = 1 To lstTempProfile.Items.Count - 1
            data.Add(New DataValue(lstTempProfile.Items(i)))
        Next

        Dim finalresults = From dv In data
        lstTempProfile.Items.Clear()
        lstTempProfile.Items.Add(header)


        For Each row In finalresults
            If row.T_Final > CInt(frmMain.cboMaxTemp.Text) Then
                lstTempProfile.Items.Add(row.ToString)
            End If
        Next

        butPlot.Enabled = False

    End Sub
    Public Class DataValue

        Public Sub New(ByVal strInput As String)
            Dim values() As String = strInput.Split({" ", vbTab}, StringSplitOptions.RemoveEmptyEntries)
            If values.Length >= 6 Then
                Try
                    Weight = Integer.Parse(values(0))
                    Speed = Integer.Parse(values(1))
                    Distance = Double.Parse(values(2))
                    Grade = Double.Parse(values(3))
                    T_Desc = Integer.Parse(values(4))
                    T_Emerg = Integer.Parse(values(5))
                    T_Final = Integer.Parse(values(6))
                Catch ex As Exception
                    MessageBox.Show("Invalid Input: Value failed to convert to Integer.")
                End Try
            Else
                MessageBox.Show("Invalid Input: Not enough values.")
            End If
        End Sub

        Public Overrides Function ToString() As String
            Return Weight & vbTab & vbTab & Speed & vbTab & Distance & vbTab & vbTab & Grade & vbTab & vbTab & T_Desc & vbTab & vbTab & T_Emerg & vbTab & vbTab & T_Final
        End Function

        Public Weight As Integer
        Public Speed As Integer
        Public Distance As Double
        Public Grade As Double
        Public T_Desc As Integer
        Public T_Emerg As Integer
        Public T_Final As Integer


    End Class
    Private Sub butPlot_Click(sender As Object, e As EventArgs) Handles butPlot.Click
        butfilter.Enabled = True
        butPlot.Enabled = False
        frmTemperaturePlot.Show()
    End Sub
    Private Sub frmTempProfile_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        lstTempProfile.Items.Clear()
        buttempCompute.Enabled = True
    End Sub
End Class