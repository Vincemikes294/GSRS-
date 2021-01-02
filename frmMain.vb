Option Explicit On
Imports System.IO
Public Class frmMain

    Public T_max As Double
    Public Shared Grade() As Double
    Public Shared Length() As Double
    Public Shared Radius() As Double
    Public Shared Gradec() As Double
    Public Shared Lengthc() As Double
    Public Shared Radiusc() As Double
    Dim i As Integer
Dim j As Integer
Dim j_max As Integer
Dim i_max As Double
Dim W_max As Double
Dim Valid As Boolean
Public Datagrade As String
    Public DataLength As String
    Public DataRadius As String
    Public Datagradec As String
    Public DataLengthc As String
    Public DataRadiusc As String
    Public Res() As Array
Dim T_lim(,) As Double
Public TL As Double
Public W As Double
Public V_max As Double
Dim V As Integer
Dim T_0 As Double
Dim T_inf As Double
Dim T_e(,) As Double
Dim HP_eng As Double
Dim K2 As Double
Dim K1 As Double
Dim F_drag As Double
Dim Theta As Double
Dim L As Double
Dim HP_b As Double
Dim T_f(,) As Double
Public Vs As Double
Public T_lim_s As Integer
Public T_f_s As Double
Public T_e_s As Double
Dim T_lims As Double
Dim W_Maxinput As String
Dim V_Maxinput As String
Dim T_0_input As String
Dim T_inf_input As String
Dim T_max_input As String
Dim Ts_e As Integer
Dim Ts_f As Integer
Dim p As Integer
Dim Group_Number As String
Dim N_secteion As String
Dim TLnew As Double
Dim a As Integer
Dim Grades_max As String
Dim Grades_maxinput As String
Dim Sections_max As String
Dim Sections_maxinput As String
    Public Property ExcelReaderFactory As Object
    Public Property ExcelDataReader As Object

    Private Sub cboMaxTemp_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If cboMaxTemp.Text = "500" Then
            T_max = 500
        ElseIf cboMaxTemp.Text = "530" Then
            T_max = 530
        End If
    End Sub
    Private Sub butGradeLength_Click(sender As System.Object, e As System.EventArgs) Handles butGradeLength.Click
    If txtNumSections.Text = "" Or IsNumeric(txtNumSections.Text) = False Then
        MsgBox("Please Enter number of segments")
        txtNumSections.Text = ""
        butCompute.Enabled = False
        butGradeLength.Enabled = True
    ElseIf CInt(txtNumSections.Text) > 6 Then
        If MsgBox("Would you like to import segment data?", vbYesNo) = MsgBoxResult.Yes Then
            butImport.PerformClick()
            Exit Sub
        Else
                lstGradeLength.Items.Add("Grade(In Radians)" & vbTab & "Length(In Miles)" & vbTab & "    Radius(In Feet)")
                For Me.i = 1 To txtNumSections.Text

                    ReDim Preserve Grade(i)
                    ReDim Preserve Length(i)
                    ReDim Preserve Radius(i)

                    Datagrade = (InputBox("Enter Decimal Grade " & i & " in Radians"))


                Do While String.IsNullOrEmpty(Datagrade) Or IsNumeric(Datagrade) = False Or Datagrade >= "1"
                    MessageBox.Show("Please enter a Numeric Value less than 1")
                    Datagrade = (InputBox("Enter Decimal Grade " & i & " in Radians"))
                Loop
                Grade(i) = Datagrade




                DataLength = (InputBox("Enter Length " & i & " in Miles"))

                Do While String.IsNullOrEmpty(DataLength) Or IsNumeric(DataLength) = False
                    MessageBox.Show("Please enter a Numeric Value")
                    DataLength = (InputBox("Enter Length " & i & " in Miles"))
                Loop
                    Length(i) = DataLength


                    DataRadius = (InputBox("Enter Radius " & i & " in Feet"))

                    Do While String.IsNullOrEmpty(DataRadius) Or IsNumeric(DataRadius) = False
                        MessageBox.Show("Please enter a Numeric Value")
                        DataRadius = (InputBox("Enter Radius " & i & " in Feet"))
                    Loop
                    Radius(i) = DataRadius

                    lstGradeLength.Items.Add(Grade(i) & vbTab & vbTab & vbTab & Length(i) & vbTab & vbTab & vbTab & Radius(i) & vbCrLf)

                Next
            butCompute.Enabled = True
        End If
        butImport.Enabled = True

    ElseIf CInt(txtNumSections.Text) <= 6 Then

            lstGradeLength.Items.Add("Grade(In Radians)" & vbTab & "Length(In Miles)" & vbTab & "    Radius(In Feet)")
            For Me.i = 1 To txtNumSections.Text

                ReDim Preserve Grade(i)
                ReDim Preserve Length(i)
                ReDim Preserve Radius(i)

                Datagrade = (InputBox("Enter Decimal Grade " & i & " in Radians"))


            Do While String.IsNullOrEmpty(Datagrade) Or IsNumeric(Datagrade) = False Or Datagrade >= "1"
                MessageBox.Show("Please enter a Numeric Value less than 1")
                Datagrade = (InputBox("Enter Decimal Grade " & i & " in Radians"))
            Loop
            Grade(i) = Datagrade




            DataLength = (InputBox("Enter Length " & i & " in Miles"))

            Do While String.IsNullOrEmpty(DataLength) Or IsNumeric(DataLength) = False
                MessageBox.Show("Please enter a Numeric Value")
                DataLength = (InputBox("Enter Length " & i & " in Miles"))
            Loop
            Length(i) = DataLength



                DataRadius = (InputBox("Enter Radius " & i & " in Feet"))

                Do While String.IsNullOrEmpty(DataRadius) Or IsNumeric(DataRadius) = False
                    MessageBox.Show("Please enter a Numeric Value")
                    DataRadius = (InputBox("Enter Length " & i & " in Feet"))
                Loop
                Radius(i) = DataRadius


                lstGradeLength.Items.Add(Grade(i) & vbTab & vbTab & vbTab & Length(i) & vbTab & vbTab & vbTab & Radius(i) & vbCrLf)

            Next
        butCompute.Enabled = True
    End If
    butImport.Enabled = True
End Sub
Private Sub butCompute_Click(sender As System.Object, e As System.EventArgs) Handles butCompute.Click
    butSave.Enabled = True
    butFilter.Enabled = True
    butCompute.Enabled = False
    butGradeLength.Enabled = False

    If IsNumeric(txtMaxWeight.Text) And txtMaxWeight.Text <> "" And txtMaxWeight.Text > "0" Then
        W_max = txtMaxWeight.Text
    Else : MsgBox("Please Enter a positive numeric value for Maximum Weight")
        W_Maxinput = (InputBox("Enter a positive numeric value for Maximum Weight"))
        Do While IsNumeric(W_Maxinput) = False Or W_Maxinput < "0"
            MessageBox.Show("Please enter a positive numeric Value for Maximum Weight")
            W_Maxinput = (InputBox("Enter a positive numeric value for Maximum Weight"))
        Loop
        W_max = CDbl(W_Maxinput)
        txtMaxWeight.Text = W_max
    End If
    If IsNumeric(txtMaxSpeed.Text) And txtMaxSpeed.Text <> "" And txtMaxSpeed.Text > "0" Then
        V_max = txtMaxSpeed.Text
    Else : MsgBox("Please Enter a positive numeric value for Maximum Speed")
        V_Maxinput = (InputBox("Enter a positive numeric value for Maximum Speed"))
        Do While IsNumeric(V_Maxinput) = False Or V_Maxinput < "0"
            MessageBox.Show("Please enter a positive numeric Value for Maximum Speed")
            V_Maxinput = (InputBox("Enter a positive numeric value for Maximum Speed"))
        Loop
        V_max = CDbl(V_Maxinput)
        txtMaxSpeed.Text = V_max
    End If

    If IsNumeric(txtinitemp.Text) Then
        If txtinitemp.Text >= 90 Then
            T_0 = txtinitemp.Text
            txtinitemp.Text = T_0
        ElseIf txtinitemp.Text < 90 Then
            T_0 = "150"
            txtinitemp.Text = T_0
        End If
    Else : MsgBox("Enter a numeric value greater or equal to 90 for Initial Temperature")
        T_0_input = (InputBox("Enter a numeric value greater or equal to 90 for Initial Temperature", "Alert", "150"))
        Do While IsNumeric(T_0_input) = False Or T_0_input = ""
            MessageBox.Show("Enter a numeric value greater or equal to 90 for Initial Temperature")
            T_0_input = (InputBox("Enter a numeric value greater or equal to 90 for Initial Temperature", "Alert", "150"))
        Loop
        If T_0_input >= 90 Then
            T_0 = T_0_input
            txtinitemp.Text = T_0
        ElseIf T_0_input < 90 Then
            T_0 = "150"
            txtinitemp.Text = T_0
        End If
    End If

    If IsNumeric(txtambient.Text) Then
        If txtambient.Text >= 90 Then
            T_inf = "90"
            txtambient.Text = T_inf
        ElseIf txtambient.Text < 90 Then
            T_inf = "90"
            txtambient.Text = T_inf
        End If
    Else : MsgBox("Enter a value of 90 for the Ambient Temperature")
        T_inf_input = (InputBox("Enter a value of 90 for the Ambient Temperature", "Alert", "90"))
        Do While IsNumeric(T_inf_input) = False Or T_inf_input = ""
            MessageBox.Show("Enter a value of 90 for the Ambient Temperature")
            T_inf_input = (InputBox("Enter a value of 90 for the Ambient Temperature", "Alert", "90"))
        Loop
        If T_inf_input >= 90 Then
            T_inf = "90"
            txtambient.Text = T_inf
        ElseIf T_inf_input < 90 Then
            T_inf = "90"
            txtambient.Text = T_inf
        End If
    End If
    If IsNumeric(cboMaxTemp.Text) And cboMaxTemp.Text <> "" And cboMaxTemp.Text = "500" Or cboMaxTemp.Text = "530" Then
        T_max = cboMaxTemp.Text
        Else : MsgBox("Please input " & "500 or 530 for Maximum Brake Temperature")
            T_max_input = (InputBox("Input " & "500 or 530 for Maximum Brake Temperature"))
            Do While IsNumeric(T_max_input) = False Or T_max_input <> "500" And T_max_input <> "530"
                MessageBox.Show("Input " & "500 or 530 for Maximum Brake Temperature")
                T_max_input = (InputBox("Input " & "500 or 530 for Maximum Brake Temperature"))
            Loop
        T_max = CDbl(T_max_input)
        cboMaxTemp.Text = T_max
    End If
        Me.lstOutputView.Items.Add("Max Weight (lb) " & "    Max Speed (mph) " & "     T_Desc (F) " & "           T_Emerg (F) " & "        T_Final (F)" & "                Time (min) " & vbCrLf & vbCrLf)

        'Computations
        j_max = W_max / 5000

    For Me.i = 1 To CInt(txtNumSections.Text)
        TL += Length(i)
    Next

    For Me.j = 0 To j_max
        W = W_max - j * 5000

        For Me.V = 1 To V_max

            T_0 = CDbl(txtinitemp.Text) 'initial brake temperature
            T_inf = CDbl(txtambient.Text) 'ambient temperature

            ReDim T_e(V, 1)
            T_e(V, 1) = (0.000000311) * W * (V ^ 2) 'temperature from emergency stopping
            HP_eng = 63.3 'Engine brake force
            K2 = 1 / (0.1602 + 0.0078 * V) 'Heat transfer parameter
            K1 = 1.5 * (1.1852 + 0.0331 * V) 'Diffusivity constant
            F_drag = 459.35 + 0.132 * (V ^ 2) 'Drag forces

            For Me.i = 1 To txtNumSections.Text

                Theta = Grade(i)
                L = Length(i)
                HP_b = (W * Theta - F_drag) * (V / 375) - 63.3 'power into brakes
                ReDim T_f(V, 1)
                T_f(V, 1) = T_0 + (T_inf - T_0 + K2 * HP_b) * (1 - Math.Exp(-K1 * (L / V)))
                T_0 = T_f(V, 1)

            Next

            ReDim T_lim(V, 1)
            T_lim(V, 1) = T_f(V, 1) + T_e(V, 1)    'limiting brake temperature


            Vs = V
            T_lim_s = CInt(T_lim(V, 1))
            T_f_s = CInt(T_f(V, 1))
            T_e_s = CInt(T_e(V, 1))


                lstOutputView.Items.Add(W & vbTab & vbTab & Vs & vbTab & vbTab & T_f_s & vbTab & vbTab & T_e_s & vbTab & vbTab & T_lim_s & vbTab & vbTab & CInt(TL * 60 / Vs) & vbCrLf)
            Next
    Next
    If txtNumSections.Text <> "" And lstGradeLength.Items.Count <> 0 Then
        butTempProfile.Enabled = True
    Else
        butTempProfile.Enabled = False
    End If

End Sub
    Private Sub frmGSRS(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RadioButtonContinuousSlope.Checked = True
        butSave.Enabled = False
        butFilter.Enabled = False
        butsSave.Enabled = False
        butsFilter.Enabled = False

    End Sub
    Private Sub butSave_Click(sender As System.Object, e As System.EventArgs)

End Sub
Private Sub butFilter_Click(sender As System.Object, e As System.EventArgs)

End Sub
Private Sub butSave_Click_1(sender As System.Object, e As System.EventArgs) Handles butSave.Click
    Dim SaveFileDialog1 As New SaveFileDialog
    SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Text Files(*.txt)|*.txt|(*.xls)|*.xls"

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
        Dim sb As New System.Text.StringBuilder()

        For Each o As Object In lstOutputView.Items
            sb.AppendLine(o)
        Next

        System.IO.File.WriteAllText(SaveFileDialog1.FileName, sb.ToString())
    End If
End Sub
Private Sub butFilter_Click_1(sender As System.Object, e As System.EventArgs) Handles butFilter.Click
    Dim header As String = lstOutputView.Items(0)

    Dim data As New List(Of DataValue)
    ' Skip the header row by starting at 1:
    For i As Integer = 1 To lstOutputView.Items.Count - 1
        data.Add(New DataValue(lstOutputView.Items(i)))
    Next

    Dim results = From dv In data
    lstOutputView.Items.Clear()
    lstOutputView.Items.Add(header)


    For Each row In results
        If row.T_Final < T_max Then
            lstOutputView.Items.Add(row.ToString)

        End If
    Next


    Dim header1 As String = lstOutputView.Items(0)

    Dim data1 As New List(Of DataValue)
    ' Skip the header row by starting at 1:
    For i As Integer = 1 To lstOutputView.Items.Count - 1
        data1.Add(New DataValue(lstOutputView.Items(i)))
    Next

    Dim finalresults = From dv In data1
                       Order By dv.MaxWeight Descending, dv.MaxSpeed Descending
                       Group dv By dv.MaxWeight Into g = Group
                       Select g.First

    Dim V_max = CInt(Me.txtMaxSpeed.Text)
    lstOutputView.Items.Clear()
    lstOutputView.Items.Add(header)


    For Each row In finalresults
        lstOutputView.Items.Add(row.ToString)
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

Private Sub RadioButtonContinuousSlope_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButtonContinuousSlope.CheckedChanged
    GroupContinuousSlope.Enabled = True
    GroupSeparateSlope.Enabled = True
    butsReset.PerformClick()
    GroupSeparateSlope.Enabled = False

End Sub

Private Sub RadioButtonSeperateSlope_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButtonSeperateSlope.CheckedChanged
    GroupSeparateSlope.Enabled = True
    GroupContinuousSlope.Enabled = True
    butReset.PerformClick()
    GroupContinuousSlope.Enabled = False
    Group_Number = "1"
    txtsGroupNumber.Text = Group_Number
    a = txtsGroupNumber.Text
End Sub
Private Sub butReset_Click(sender As System.Object, e As System.EventArgs) Handles butReset.Click
    txtNumSections.Text = ""
    txtambient.Text = ""
    txtMaxSpeed.Text = ""
    txtMaxWeight.Text = ""
    txtinitemp.Text = ""
    cboMaxTemp.Text = ""
    butImport.Enabled = True
    butGradeLength.Enabled = True
    butClear.Enabled = True
    butCompute.Enabled = False
    butTempProfile.Enabled = False
    lstGradeLength.Items.Clear()
    lstOutputView.Items.Clear()
    RichTextBox1.Clear()
    lblPath.Text = ""
    TL = 0

End Sub

Private Sub GroupBox10_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox10.Enter

End Sub

Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

End Sub

    Private Sub butsSave_Click(sender As System.Object, e As System.EventArgs) Handles butsSave.Click
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Text Files(*.txt)|*.txt|(*.xls)|*.xls"

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim sb As New System.Text.StringBuilder()

            For Each o As Object In lstsOutputView.Items
                sb.AppendLine(o)
            Next

            System.IO.File.WriteAllText(SaveFileDialog1.FileName, sb.ToString())
        End If
    End Sub
    Private Sub butsClear_Click(sender As System.Object, e As System.EventArgs) Handles butsClear.Click
        RichTextBox2.Clear()
        lstsGradeLength.Items.Clear()
        lstsOutputView.Items.Clear()
        butsGradeLength.Enabled = True
        butsImport.Enabled = True
        txtsNumSections.Text = ""
        lblnPath.Text = ""
        butFilter.Enabled = False
        TLnew = 0
    End Sub
    Private Sub butsCompute_Click(sender As System.Object, e As System.EventArgs) Handles butsCompute.Click
        butsSave.Enabled = True
        butsFilter.Enabled = True
        butsCompute.Enabled = False
        butsGradeLength.Enabled = False
        Dim numgradesoutput As Integer
        If IsNumeric(txtsNumberGrades.Text) And txtsNumberGrades.Text <> "" And txtsNumberGrades.Text > "0" And (Integer.TryParse(txtsNumberGrades.Text, numgradesoutput)) = True Then
            Grades_max = txtsNumberGrades.Text
        Else : MsgBox("Please Enter a positive integer value for Number of Grades", , "Seperate Slope")
            Grades_maxinput = (InputBox("Enter a positive integer value for Number of Grades", "Seperate Slope"))
            Do While IsNumeric(Grades_maxinput) = False Or Grades_maxinput < "0" Or (Integer.TryParse(Grades_maxinput, numgradesoutput)) = False
                MessageBox.Show("Please enter a positive integer value for Number of Grades", "Seperate Slope")
                Grades_maxinput = (InputBox("Enter a positive integer value for Number of Grades", "Seperate Slope"))
            Loop
            Grades_max = Grades_maxinput
        End If
        txtsNumberGrades.Text = Grades_max

        If IsNumeric(txtsMaxWeight.Text) And txtsMaxWeight.Text <> "" And txtsMaxWeight.Text > "0" Then
            W_max = txtsMaxWeight.Text
        Else : MsgBox("Please Enter a positive numeric value for Maximum Weight", , "Seperate Slope")
            W_Maxinput = (InputBox("Enter a positive numeric value for Maximum Weight", "Seperate Slope"))
            Do While IsNumeric(W_Maxinput) = False Or W_Maxinput < "0"
                MessageBox.Show("Please enter a positive numeric Value for Maximum Weight", "Seperate Slope")
                W_Maxinput = (InputBox("Enter a positive numeric value for Maximum Weight", "Seperate Slope"))
            Loop
            W_max = CDbl(W_Maxinput)
        End If
        txtsMaxWeight.Text = W_max
        If IsNumeric(txtsMaxSpeed.Text) And txtsMaxSpeed.Text <> "" And txtsMaxSpeed.Text > "0" Then
            V_max = txtsMaxSpeed.Text
        Else : MsgBox("Please Enter a positive numeric value for Maximum Speed", , "Seperate Slope")
            V_Maxinput = (InputBox("Enter a positive numeric value for Maximum Speed", "Seperate Slope"))
            Do While IsNumeric(V_Maxinput) = False Or V_Maxinput < "0"
                MessageBox.Show("Please enter a positive numeric Value for Maximum Speed", "Seperate Slope")
                V_Maxinput = (InputBox("Enter a positive numeric value for Maximum Speed", "Seperate Slope"))
            Loop
            V_max = CDbl(V_Maxinput)
        End If
        txtsMaxSpeed.Text = V_max
        If IsNumeric(txtsinitemp.Text) Then
            If txtsinitemp.Text >= 90 Then
                T_0 = txtsinitemp.Text
                txtsinitemp.Text = T_0
            ElseIf txtsinitemp.Text < 90 Then
                T_0 = "150"
                txtsinitemp.Text = T_0
            End If
        Else : MsgBox("Enter a numeric value greater Or equal to 90 for Initial Temperature", , "Seperate Slope")
            T_0_input = (InputBox("Enter a numeric value greater Or equal to 90 for Initial Temperature", "Alert", "150"))
            Do While IsNumeric(T_0_input) = False Or T_0_input = ""
                MessageBox.Show("Enter a numeric value greater Or equal to 90 for Initial Temperature", "Seperate Slope")
                T_0_input = (InputBox("Enter a numeric value greater Or equal to 90 for Initial Temperature", "Alert", "150"))
            Loop
            If T_0_input >= 90 Then
                T_0 = T_0_input
                txtsinitemp.Text = T_0
            ElseIf T_0_input < 90 Then
                T_0 = "150"
                txtsinitemp.Text = T_0
            End If
        End If

        If IsNumeric(txtsiniambient.Text) Then
            If txtsiniambient.Text >= 90 Then
                T_inf = "90"
                txtsiniambient.Text = T_inf
            ElseIf txtsiniambient.Text < 90 Then
                T_inf = "90"
                txtsiniambient.Text = T_inf
            End If
        Else : MsgBox("Enter a value of 90 for the Ambient Temperature", , "Seperate Slope")
            T_inf_input = (InputBox("Enter a value of 90 for the Ambient Temperature", "Alert", "90"))
            Do While IsNumeric(T_inf_input) = False Or T_inf_input = ""
                MessageBox.Show("Enter a value of 90 for the Ambient Temperature", "Seperate Slope")
                T_inf_input = (InputBox("Enter a value of 90 for the Ambient Temperature", "Alert", "90"))
            Loop
            If T_inf_input >= 90 Then
                T_inf = "90"
                txtsiniambient.Text = T_inf
            ElseIf T_inf_input < 90 Then
                T_inf = "90"
                txtsiniambient.Text = T_inf
            End If
        End If
        If IsNumeric(cbosMaxTemp.Text) And cbosMaxTemp.Text <> "" And cbosMaxTemp.Text = "500" Or cbosMaxTemp.Text = "530" Then
            T_max = cbosMaxTemp.Text
        Else : MsgBox("Please input " & "500 Or 530 for Maximum Temperature", , "Seperate Slope")
            T_max_input = (InputBox("Input " & "500 Or 530 for Maximum Temperature", "Seperate Slope"))
            Do While IsNumeric(T_max_input) = False Or T_max_input <> "500" And T_max_input <> "530"
                MessageBox.Show("Input " & "500 Or 530 for Maximum Temperature", "Seperate Slope")
                T_max_input = (InputBox("Input " & "500 Or 530 for Maximum Temperature", "Seperate Slope"))
            Loop
            T_max = CDbl(T_max_input)
        End If
        cbosMaxTemp.Text = T_max
        lstsOutputView.Items.Add("Group" & "        Max Weight (lb)" & "           Max Speed (mph)" & "                         T_Desc (F)" & "               T_Emerg (F)" & "      T_Final (F)" & "          Time (min) " & vbCrLf & vbCrLf)

        a = txtsGroupNumber.Text
        Group_Number = a
        p = txtsNumberGrades.Text
        'Computations
        'm = 0
        i_max = W_max / 5000
        N_secteion = txtsNumSections.Text
        Dim input_info(,) As Double = New Double(CInt(N_secteion - 1), 1) {}
        For Me.i = 1 To N_secteion
            Dim intIndexGrade As New Integer
            Dim intIndexLength As New Integer

            For intIndexGrade = 1 To N_secteion
                input_info(intIndexGrade - 1, 0) = Gradec(intIndexGrade)
            Next
            For intIndexLength = 1 To N_secteion
                input_info(intIndexLength - 1, 1) = Lengthc(intIndexLength)

            Next
        Next


        If a Mod 2 = 1 Then
            T_lim_s = Group1(input_info, V_max, W_max, T_0, Group_Number)
        End If



        If a Mod 2 = 0 Then
            T_lim_s = CalVel(input_info, W_max, i_max, V_max, T_max, T_0, Group_Number)
        End If

    End Sub
    Private Sub butClear_Click(sender As System.Object, e As System.EventArgs) Handles butClear.Click
        RichTextBox1.Clear()
        lstGradeLength.Items.Clear()
        lstOutputView.Items.Clear()
        butGradeLength.Enabled = True
        butImport.Enabled = True
        txtNumSections.Text = ""
        lblPath.Text = ""
        butTempProfile.Enabled = False
        butFilter.Enabled = False
        TL = 0
    End Sub
    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles butImport.Click
        Dim MyFileDialog As New System.Windows.Forms.OpenFileDialog

        ' Configure the dialog to show both text and excel files
        ' Set its title and set the filename field blank for the moment.
        MyFileDialog.Filter = "Text Files(*.txt)|*.txt|(*.xlsx)|*.xlsx"
        MyFileDialog.Title = " Open a Text or excel file"
        MyFileDialog.FileName = ""
        ' Show the dialog and see if the user pressed ok.

        If MyFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Check to see if they selected a file and that it exists.

            If File.Exists(MyFileDialog.FileName) Then

                Dim strFile As String = MyFileDialog.FileName
                Dim textextension As String
                Dim reader As StreamReader
                Dim testFile As System.IO.FileInfo
                Try
                    ' Setup a file stream reader to read the text file.

                    textextension = Path.GetExtension(strFile)
                    If textextension = ".txt" Then
                        reader = New StreamReader(New FileStream(strFile, FileMode.Open, FileAccess.Read))
                        testFile = My.Computer.FileSystem.GetFileInfo(strFile)
                        lblPath.Text = testFile.FullName

                        ' While there is data to be read, read each line into a rich edit box control.

                        While reader.Peek > -1

                            RichTextBox1.Text &= reader.ReadLine() & vbCrLf

                        End While

                        lstGradeLength.Items.Add("Grade (in Radians)" & vbTab & "   Length (in Miles)" & vbTab & "   Radius (in Feet)")

                        Dim m As Integer
                        For m = 1 To CInt(UBound(RichTextBox1.Lines))
                            ReDim Preserve Grade(m)
                            ReDim Preserve Length(m)
                            Grade(m) = RichTextBox1.Lines(m - 1).Split(" ").First
                            Length(m) = RichTextBox1.Lines(m - 1).Split(" ").First + 1
                            Radius(m) = RichTextBox1.Lines(m - 1).Split(" ").Last
                            lstGradeLength.Items.Add(Grade(m) & vbTab & vbTab & vbTab & Length(m) & vbTab & vbTab & vbTab & Radius(m) & vbCrLf)
                            butGradeLength.Enabled = False
                        Next
                        txtNumSections.Text = UBound(RichTextBox1.Lines)
                    End If

                    If textextension = ".xlsx" Then
                        Dim oExcel As Object = CreateObject("Excel.Application")
                        Dim oBook As Object = oExcel.Workbooks.Open(strFile)
                        Dim oSheet As Object = oBook.Worksheets(1)
                        Dim i As Integer
                        Dim cellA As String
                        Dim cellB As String
                        Dim cellC As String
                        lstGradeLength.Items.Add("Grade (in Radians)" & vbTab & "   Length (in Miles)" & vbTab & "   Radius (in Feet)")
                        For i = 0 To AscW(lstGradeLength.Items.Count.ToString()(i = i + 1)) - 1

                            cellA = "A" & Convert.ToString(i + 1)
                            cellB = "B" & Convert.ToString(i + 1)
                            cellC = "C" & Convert.ToString(i + 1)
                            cellA = oSheet.Range(cellA).Value
                            cellB = oSheet.Range(cellB).Value
                            cellC = oSheet.Range(cellC).Value
                            If cellA = "" And cellB = "" And cellC = "" Then
                                Exit For
                            Else
                                RichTextBox1.AppendText(cellA & " " & cellB & " " & cellC & vbCrLf)

                            End If
                        Next
                        oExcel.Quit()
                        Dim m As Integer
                        For m = 1 To CInt(UBound(RichTextBox1.Lines))
                            ReDim Preserve Grade(m)
                            ReDim Preserve Length(m)
                            ReDim Preserve Radius(m)
                            Grade(m) = RichTextBox1.Lines(m - 1).Split(" ").First
                            Length(m) = RichTextBox1.Lines(m - 1).Split(" ").First + 1
                            Radius(m) = RichTextBox1.Lines(m - 1).Split(" ").Last
                            lstGradeLength.Items.Add(Grade(m) & vbTab & vbTab & vbTab & Length(m) & vbTab & vbTab & vbTab & Radius(m) & vbCrLf)
                            butGradeLength.Enabled = False
                        Next
                        testFile = My.Computer.FileSystem.GetFileInfo(strFile)

                        lblPath.Text = testFile.FullName

                        txtNumSections.Text = lstGradeLength.Items.Count - 1
                    End If

                Catch ex As FileNotFoundException

                    ' If the file was not found, tell the user.

                    MessageBox.Show("File was Not found. Please try again.")

                End Try

            End If
        Else
            txtNumSections.Text = ""
            butImport.Enabled = True
            butGradeLength.Enabled = True
            butClear.Enabled = True
            Exit Sub
        End If

        butImport.Enabled = False
        butCompute.Enabled = True
    End Sub
    ' Function to calculate V
    Function Group1(input_info, V_max, W_max, T_0, Group_Number)
        Dim Space = ("        ")
        W = W_max
        V = V_max
        For Me.i = 1 To txtsNumSections.Text
            TLnew += Lengthc(i)
        Next
        For Me.j = 0 To (V_max - 15) / 5
            V = V_max - 5 * j
            T_0 = txtsinitemp.Text
            T_inf = txtsiniambient.Text  'ambient temperature

            Ts_e = (0.000000311) * W * (V ^ 2) ' temperature from emergency stopping
            HP_eng = 63.3 'engine brake force
            K2 = 1 / (0.1602 + 0.0078 * V) 'heat transfer parameter
            K1 = 1.5 * (1.1852 + 0.0331 * V) 'diffusivity constant
            F_drag = 459.35 + 0.132 * (V ^ 2) 'drag forces

            For Me.i = 1 To txtsNumSections.Text
                Theta = Gradec(i)
                L = Lengthc(i)
                HP_b = (W * Theta - F_drag) * (V / 375) - 63.3 'power into brakes
                Ts_f = T_0 + (T_inf - T_0 + K2 * HP_b) * (1 - Math.Exp(-K1 * (L / V)))
                T_0 = Ts_f

            Next
            T_lims = Ts_f + Ts_e 'limiting brake temperature


            lstsOutputView.Items.Add(Space & Group_Number & vbTab & vbTab & W & vbTab & vbTab & Space & V & vbTab & vbTab & Space & vbTab & Ts_f & vbTab & Space & vbTab & Ts_e & vbTab & Space & T_lims & vbTab & vbTab & Space & CInt(TLnew * 60 / V) & vbCrLf)
        Next
        Me.butsFilter.Enabled = True
    End Function
    Function CalVel(input_info, W_max, i_max, V_max, T_max, T_0, Group_Number)
        Dim T_f(,) As Double
        Dim T_e(,) As Double
        Dim j_max As Integer
        j_max = W_max / 5000
        For Me.i = 1 To txtsNumSections.Text
            TLnew += Lengthc(i)
        Next

        For Me.j = 0 To j_max
            W = W_max - j * 5000

            For Me.V = 1 To V_max

                T_0 = txtsinitemp.Text 'initial brake temperature
                T_inf = txtsiniambient.Text 'ambient temperature

                ReDim T_e(V, 1)
                T_e(V, 1) = (0.000000311) * W * (V ^ 2) 'temperature from emergency stopping
                HP_eng = 63.3 'Engine brake force
                K2 = 1 / (0.1602 + 0.0078 * V) 'Heat transfer parameter
                K1 = 1.5 * (1.1852 + 0.0331 * V) 'Diffusivity constant
                F_drag = 459.35 + 0.132 * (V ^ 2) 'Drag forces

                For Me.i = 1 To txtsNumSections.Text

                    Theta = Gradec(i)
                    L = Lengthc(i)
                    HP_b = (W * Theta - F_drag) * (V / 375) - 63.3 'power into brakes
                    ReDim T_f(V, 1)
                    T_f(V, 1) = T_0 + (T_inf - T_0 + K2 * HP_b) * (1 - Math.Exp(-K1 * (L / V)))
                    T_0 = T_f(V, 1)

                Next

                ReDim T_lim(V, 1)

                T_lim(V, 1) = T_f(V, 1) + T_e(V, 1)    'limiting brake temperature



                Vs = V
                T_lim_s = CInt(T_lim(V, 1))
                T_f_s = CInt(T_f(V, 1))
                T_e_s = CInt(T_e(V, 1))
                Dim Space = ("        ")
                lstsOutputView.Items.Add(Space & Group_Number & vbTab & vbTab & W & vbTab & vbTab & Space & V & vbTab & vbTab & Space & vbTab & Ts_f & vbTab & Space & vbTab & Ts_e & vbTab & Space & T_lims & vbTab & vbTab & Space & CInt(TLnew * 60 / V) & vbCrLf)
            Next
        Next

        Me.butsFilter.Enabled = True
    End Function
    Private Sub cbosMaxTemp_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbosMaxTemp.SelectedIndexChanged
        If cbosMaxTemp.Text = "500" Then
            T_max = 500
        ElseIf cbosMaxTemp.Text = "530" Then
            T_max = 530

        End If
    End Sub

    Private Sub butsFilter_Click(sender As System.Object, e As System.EventArgs) Handles butsFilter.Click
        Dim header As String
        Dim data As New List(Of DataValue1)
        Dim results = From dv In data
        Dim header1 As String
        Dim header2 As String
        Dim data1 As New List(Of DataValue1)
        Dim data2 As New List(Of DataValue1)
        Dim finalresults = From dv In data1
        Dim finalresults2 = From dv In data1
        Dim V_max = CInt(Me.txtsMaxSpeed.Text)
        Dim Max_weight = CInt(Me.txtsMaxWeight.Text)
        If a Mod 2 = 0 Then
            header = lstsOutputView.Items(0)

            ' Skip the header row by starting at 1:
            For i As Integer = 1 To lstsOutputView.Items.Count - 1
                data.Add(New DataValue1(lstsOutputView.Items(i)))
            Next

            lstsOutputView.Items.Clear()
            lstsOutputView.Items.Add(header)


            For Each row In results
                If row.T_Final < T_max Then
                    lstsOutputView.Items.Add(row.ToString)

                End If
            Next


            header1 = lstsOutputView.Items(0)

            ' Skip the header row by starting at 1:
            For i As Integer = 1 To lstsOutputView.Items.Count - 1
                data1.Add(New DataValue1(lstsOutputView.Items(i)))
            Next

            finalresults = From dv In data1
                           Order By dv.MaxWeight Descending, dv.MaxSpeed Descending
                           Group dv By dv.MaxWeight Into g = Group
                           Select g.First


            lstsOutputView.Items.Clear()
            lstsOutputView.Items.Add(header)


            For Each row In finalresults
                lstsOutputView.Items.Add(row.ToString)
                If row.MaxSpeed = V_max Then
                    Exit For
                End If
            Next

            MsgBox("Select row for maximum weight",, "Seperate Slope")
            header2 = lstsOutputView.Items(0)

            ' Skip the header row by starting at 1:
            For i As Integer = 1 To lstsOutputView.Items.Count - 1
                data2.Add(New DataValue1(lstsOutputView.Items(i)))
            Next

            finalresults2 = From dv In data2
                            Order By dv.MaxWeight Descending
                            Group dv By dv.MaxWeight Into g = Group
                            Select g.First

            lstsOutputView.Items.Clear()
            lstsOutputView.Items.Add(header)

            For Each row In finalresults2
                lstsOutputView.Items.Add(row.ToString)
                If row.MaxWeight = Max_weight Then
                    txtNewTemp.Text = row.T_Final
                End If
                Exit For
            Next
        End If

        If a Mod 2 = 1 Then
                ' Skip the header row by starting at 1:

                header = lstsOutputView.Items(0)
                For i As Integer = 1 To lstsOutputView.Items.Count - 1
                    data.Add(New DataValue1(lstsOutputView.Items(i)))
                Next

                lstsOutputView.Items.Clear()
                lstsOutputView.Items.Add(header)


                For Each row In results
                    If row.T_Final < T_max Then
                        lstsOutputView.Items.Add(row.ToString)

                    End If
                Next

                ' Skip the header row by starting at 1:
                For i As Integer = 1 To lstsOutputView.Items.Count - 1
                    data1.Add(New DataValue1(lstsOutputView.Items(i)))
                Next

                finalresults = From dv In data1
                               Order By dv.MaxWeight Descending, dv.Time Ascending
                               Group dv By dv.MaxWeight Into g = Group
                               Select g.First

                lstsOutputView.Items.Clear()
                lstsOutputView.Items.Add(header)


                For Each row In finalresults

                    lstsOutputView.Items.Add(row.ToString)
                    txtNewTemp.Text = row.T_Final

                Next
            End If


        Dim Answer As Integer

        If a Mod 2 = 0 Then
            Answer = MsgBox("Enter segments for downgrade of next braking segment?", vbYesNoCancel, "Alert")
            If Answer = vbYes Then
                btnNext.Enabled = True
                btnNext.Select()
            Else
            End If
        End If
        If a Mod 2 = 1 Then
            Answer = MsgBox("Enter segments for downgrade of next non-braking segment?", vbYesNoCancel, "Alert")
            If Answer = vbYes Then
                btnNext.Enabled = True
                btnNext.Select()
            Else

            End If
        End If

    End Sub
    Private Sub butsReset_Click(sender As System.Object, e As System.EventArgs) Handles butsReset.Click
        txtsNumberGrades.Text = ""
        txtsGroupNumber.Text = 1
        txtsNumSections.Text = ""
        txtsiniambient.Text = ""
        txtsMaxSpeed.Text = ""
        txtsMaxWeight.Text = ""
        txtsinitemp.Text = ""
        cbosMaxTemp.Text = ""
        butsImport.Enabled = True
        butsGradeLength.Enabled = True
        butsClear.Enabled = True
        butsCompute.Enabled = False
        lstsGradeLength.Items.Clear()
        lstsOutputView.Items.Clear()
        RichTextBox2.Clear()
        lblnPath.Text = ""
        TLnew = 0
    End Sub

    Public Class DataValue1

        Public Sub New(ByVal strInput As String)
            Dim values() As String = strInput.Split({" ", vbTab}, StringSplitOptions.RemoveEmptyEntries)
            If values.Length >= 7 Then
                Try
                    GroupNumber = Integer.Parse(values(0))
                    MaxWeight = Integer.Parse(values(1))
                    MaxSpeed = Integer.Parse(values(2))
                    T_Desc = Integer.Parse(values(3))
                    T_Emerg = Integer.Parse(values(4))
                    T_Final = Integer.Parse(values(5))
                    Time = Integer.Parse(values(6))
                Catch ex As Exception
                    MessageBox.Show("Invalid Input: Value failed to convert to Integer.")
                End Try
            Else
                MessageBox.Show("Invalid Input:  Not enough values.")
            End If
        End Sub

        Public Overrides Function ToString() As String
            Dim Space = ("        ")

            Return Space & GroupNumber & vbTab & vbTab & MaxWeight & vbTab & vbTab & MaxSpeed & vbTab & vbTab & Space & Space & T_Desc & Space & vbTab & vbTab & Space & T_Emerg & vbTab & Space & T_Final & vbTab & Space & vbTab & Time

        End Function
        Public GroupNumber As Integer
        Public MaxWeight As Integer
        Public MaxSpeed As Integer
        Public Time As Integer
        Public T_Emerg As Integer
        Public T_Final As Integer
        Public T_Desc As Integer
    End Class
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles butTempProfile.Click
        frmTempProfile.Show()
    End Sub
    Private Sub txtNumSections_TextChanged(sender As Object, e As EventArgs) Handles txtNumSections.TextChanged
        If txtNumSections.Text <> "" And lstGradeLength.Items.Count <> 0 Then
            butCompute.Enabled = True
        Else
            butCompute.Enabled = False
        End If
    End Sub

    Private Sub lstGradeLength_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstGradeLength.SelectedIndexChanged
        If txtNumSections.Text <> "" And lstGradeLength.Items.Count <> 0 Then
            butCompute.Enabled = True
        Else
            butCompute.Enabled = False

        End If
    End Sub
    Private Sub butTempProfile_EnabledChanged(sender As Object, e As EventArgs) Handles butTempProfile.EnabledChanged

    End Sub

    Private Sub butTempProfile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles butTempProfile.KeyPress

    End Sub

    Private Sub butTempProfile_MouseHover(sender As Object, e As EventArgs) Handles butTempProfile.MouseHover
        If txtNumSections.Text <> "" And txtambient.Text <> "" And txtMaxSpeed.Text <> "" And txtMaxWeight.Text <> "" And txtinitemp.Text <> "" And cboMaxTemp.Text <> "" And lstGradeLength.Items.Count <> 0 Then
            butTempProfile.Enabled = True
        Else
            butTempProfile.Enabled = False
        End If
    End Sub

    Private Sub GroupSeparateSlope_Enter(sender As Object, e As EventArgs) Handles GroupSeparateSlope.Enter

    End Sub

    Private Sub txtsNumSections_TextChanged(sender As Object, e As EventArgs) Handles txtsNumSections.TextChanged
        If txtsNumberGrades.Text <> "" And txtsNumSections.Text <> "" And lstsGradeLength.Items.Count <> 0 Then
            butsCompute.Enabled = True
        Else
            butsCompute.Enabled = False
        End If
    End Sub

    Private Sub cboMaxTemp_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboMaxTemp.SelectedIndexChanged
        If cboMaxTemp.Text = "500" Then
            T_max = 500
        ElseIf cboMaxTemp.Text = "530" Then
            T_max = 530

        End If
    End Sub

    Private Sub txtMaxWeight_TextChanged(sender As Object, e As EventArgs) Handles txtMaxWeight.TextChanged

    End Sub

    Private Sub txtsMaxWeight_TextChanged(sender As Object, e As EventArgs) Handles txtsMaxWeight.TextChanged

    End Sub

    Private Sub txtMaxSpeed_TextChanged(sender As Object, e As EventArgs) Handles txtMaxSpeed.TextChanged

    End Sub

    Private Sub txtsMaxSpeed_TextChanged(sender As Object, e As EventArgs) Handles txtsMaxSpeed.TextChanged

    End Sub

    Private Sub txtinitemp_TextChanged(sender As Object, e As EventArgs) Handles txtinitemp.TextChanged

    End Sub

    Private Sub txtsinitemp_TextChanged(sender As Object, e As EventArgs) Handles txtsinitemp.TextChanged

    End Sub

    Private Sub txtambient_TextChanged(sender As Object, e As EventArgs) Handles txtambient.TextChanged

    End Sub

    Private Sub txtsiniambient_TextChanged(sender As Object, e As EventArgs) Handles txtsiniambient.TextChanged

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Group_Number = Group_Number + 1
        a = Group_Number
        txtsGroupNumber.Text = a
        txtsNumSections.Text = ""
        txtsinitemp.Text = ""
        cboMaxTemp.Text = ""
        butsImport.Enabled = True
        butsGradeLength.Enabled = True
        butsClear.Enabled = True
        butsCompute.Enabled = False
        lstsGradeLength.Items.Clear()
        lstsOutputView.Items.Clear()
        RichTextBox2.Clear()
        lblnPath.Text = ""
        TLnew = 0
        txtsinitemp.Text = txtNewTemp.Text

        Dim Query As Integer

        If Group_Number = p + 1 Then
            Query = MsgBox("Downgrade limit reached; Reset?", vbYesNoCancel, "Alert")
            If Query = vbYes Then
                butsReset.PerformClick()
                RadioButtonSeperateSlope.Checked = True
            Else

            End If
        End If
    End Sub

    Private Sub butsGradeLength_Click(sender As Object, e As EventArgs) Handles butsGradeLength.Click
        Dim numbergrades As Integer
    Dim numsegments As Integer
    If IsNumeric(txtsNumberGrades.Text) And txtsNumberGrades.Text <> "" And txtsNumberGrades.Text > "0" And (Integer.TryParse(txtsNumberGrades.Text, numbergrades)) Then
        Grades_max = txtsNumberGrades.Text
        Else : MsgBox("Please Enter a positive integer value for Number of Grades", "Seperate Slope")
            Grades_maxinput = (InputBox("Enter a positive integer value for Number of Grades"))
        Do While IsNumeric(Grades_maxinput) = False Or Grades_maxinput < "0" Or Grades_maxinput = "" Or (Not Integer.TryParse(Grades_maxinput, numbergrades))
            MessageBox.Show("Please enter a positive integer value for Number of Grades")
                Grades_maxinput = (InputBox("Enter a positive integer value for Number of Grades", "Seperate Slope"))
                butsCompute.Enabled = False
            butsGradeLength.Enabled = True
        Loop
        Grades_max = Grades_maxinput
    End If
    txtsNumberGrades.Text = Grades_max
    If IsNumeric(txtsNumSections.Text) And txtsNumSections.Text <> "" And txtNumSections.Text > "0" And (Integer.TryParse(txtsNumSections.Text, numsegments)) Then
        Sections_max = txtsNumSections.Text
        Else : MsgBox("Please Enter a positive integer value for Number of Segments for Group(" & a & ")")
            Sections_maxinput = (InputBox("Please Enter a positive integer value for Number of Segments for Group(" & a & ")"))
            Do While IsNumeric(Sections_maxinput) = False Or Sections_maxinput < "0" Or Sections_maxinput = "" Or (Not Integer.TryParse(Sections_maxinput, numsegments))
                MessageBox.Show("Please Enter a positive integer value for Number of Segments for Group(" & a & ")")
                Sections_maxinput = (InputBox("Please Enter a positive integer value for Number of Segments for Group(" & a & ")"))
                butsCompute.Enabled = False
                butsGradeLength.Enabled = True
            Loop
            Sections_max = Sections_maxinput
     End If
        txtsNumSections.Text = Sections_max
     If txtsNumSections.Text > 6 Then
            If MsgBox("Would you Like to import segment data?", vbYesNo) = MsgBoxResult.Yes Then
                butsImport.PerformClick()
                Exit Sub
            Else
                lstsGradeLength.Items.Add("Grade(In Radians)" & vbTab & "Length(In Miles)" & vbTab & "    Radius(In Feet)")
                For Me.i = 1 To txtsNumSections.Text

                    ReDim Preserve Gradec(i)
                    ReDim Preserve Lengthc(i)
                    ReDim Preserve Radiusc(i)

                    Datagradec = (InputBox("Enter Decimal Grade " & i & " in Radians"))


                    Do While String.IsNullOrEmpty(Datagradec) Or IsNumeric(Datagradec) = False Or Datagradec >= "1"
                        MessageBox.Show("Please enter a Numeric Value less than 1")
                        Datagradec = (InputBox("Enter Decimal Grade " & i & " in Radians"))
                    Loop
                    Gradec(i) = Datagradec




                    DataLengthc = (InputBox("Enter Length " & i & " in Miles"))

                    Do While String.IsNullOrEmpty(DataLengthc) Or IsNumeric(DataLengthc) = False
                        MessageBox.Show("Please enter a Numeric Value")
                        DataLengthc = (InputBox("Enter Length " & i & " in Miles"))
                    Loop
                    Lengthc(i) = DataLengthc


                    DataRadiusc = (InputBox("Enter Radius " & i & " in Feet"))

                    Do While String.IsNullOrEmpty(DataRadiusc) Or IsNumeric(DataRadiusc) = False
                        MessageBox.Show("Please enter a Numeric Value")
                        DataRadiusc = (InputBox("Enter Radius " & i & " in Feet"))
                    Loop
                    Radiusc(i) = DataRadiusc

                    lstsGradeLength.Items.Add(Gradec(i) & vbTab & vbTab & vbTab & Lengthc(i) & vbTab & vbTab & vbTab & Radiusc(i) & vbCrLf)

                Next
                butsCompute.Enabled = True
            End If
            butsImport.Enabled = True

        ElseIf CInt(txtsNumSections.Text) <= 6 Then

            lstsGradeLength.Items.Add("Grade(In Radians)" & vbTab & "Length(In Miles)" & vbTab & "    Radius(In Feet)")
            For Me.i = 1 To txtsNumSections.Text

                ReDim Preserve Gradec(i)
                ReDim Preserve Lengthc(i)
                ReDim Preserve Radiusc(i)

                Datagradec = (InputBox("Enter Decimal Grade " & i & " in Radians"))


                Do While String.IsNullOrEmpty(Datagradec) Or IsNumeric(Datagradec) = False Or Datagradec >= "1"
                    MessageBox.Show("Please enter a Numeric Value less than 1")
                    Datagradec = (InputBox("Enter Decimal Grade " & i & " in Radians"))
                Loop
                Gradec(i) = Datagradec




                DataLengthc = (InputBox("Enter Length " & i & " in Miles"))

                Do While String.IsNullOrEmpty(DataLengthc) Or IsNumeric(DataLengthc) = False
                    MessageBox.Show("Please enter a Numeric Value")
                    DataLengthc = (InputBox("Enter Length " & i & " in Miles"))
                Loop
                Lengthc(i) = DataLengthc


                DataRadiusc = (InputBox("Enter Radius " & i & " in Feet"))

                Do While String.IsNullOrEmpty(DataRadiusc) Or IsNumeric(DataRadiusc) = False
                    MessageBox.Show("Please enter a Numeric Value")
                    DataRadiusc = (InputBox("Enter Radius " & i & " in Feet"))
                Loop
                Radiusc(i) = DataRadiusc

                lstsGradeLength.Items.Add(Gradec(i) & vbTab & vbTab & vbTab & Lengthc(i) & vbTab & vbTab & vbTab & Radiusc(i) & vbCrLf)

            Next
            butsCompute.Enabled = True
        End If
        butsImport.Enabled = True
    End Sub

    Private Interface IExcelDataReader
        Sub Close()
        Function ReadLine() As String
        Function Peek() As Integer
    End Interface

    Private Sub GroupBox11_Enter(sender As Object, e As EventArgs) Handles GroupBox11.Enter

    End Sub

    Private Sub butsImport_Click(sender As Object, e As EventArgs) Handles butsImport.Click
        Dim MyFileDialog As New System.Windows.Forms.OpenFileDialog

        ' Configure the dialog to show only text and excel files
        ' Set its title and set the filename field blank for the moment.
        MyFileDialog.Filter = "Text Files(*.txt)|*.txt|(*.xlsx)|*.xlsx"
        MyFileDialog.Title = "Open a Text or excel file"
        MyFileDialog.FileName = ""
        ' Show the dialog and see if the user pressed ok.

        If MyFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Check to see if they selected a file and that it exists.

            If File.Exists(MyFileDialog.FileName) Then

                Dim strFile As String = MyFileDialog.FileName
                Dim textextension As String
                Dim reader As StreamReader
                Dim testFile As System.IO.FileInfo
                Try
                    ' Setup a file stream reader to read the text and excel files.

                    textextension = Path.GetExtension(strFile)
                    If textextension = ".txt" Then
                        reader = New StreamReader(New FileStream(strFile, FileMode.Open, FileAccess.Read))
                        testFile = My.Computer.FileSystem.GetFileInfo(strFile)
                        lblnPath.Text = testFile.FullName

                        ' While there is data to be read, read each line into a rich edit box control.

                        While reader.Peek > -1

                            RichTextBox2.Text &= reader.ReadLine() & vbCrLf

                        End While

                        lstsGradeLength.Items.Add("Grade (in Radians)" & vbTab & "   Length (in Miles)" & vbTab & "   Radius (in Feet)")

                        Dim m As Integer
                        For m = 1 To CInt(UBound(RichTextBox2.Lines))
                            ReDim Preserve Gradec(m)
                            ReDim Preserve Lengthc(m)
                            ReDim Preserve Radiusc(m)
                            Gradec(m) = RichTextBox2.Lines(m - 1).Split(" ").First
                            Lengthc(m) = RichTextBox2.Lines(m - 1).Split(" ").First + 1
                            Radiusc(m) = RichTextBox2.Lines(m - 1).Split(" ").Last
                            lstsGradeLength.Items.Add(Gradec(m) & vbTab & vbTab & vbTab & Lengthc(m) & vbTab & vbTab & vbTab & Radiusc(m) & vbCrLf)
                            butsGradeLength.Enabled = False
                        Next
                        txtsNumSections.Text = UBound(RichTextBox2.Lines)
                    End If

                    If textextension = ".xlsx" Then
                        Dim oExcel As Object = CreateObject("Excel.Application")
                        Dim oBook As Object = oExcel.Workbooks.Open(strFile)
                        Dim oSheet As Object = oBook.Worksheets(1)
                        Dim i As Integer
                        Dim cellA As String
                        Dim cellB As String
                        Dim cellC As String
                        lstsGradeLength.Items.Add("Grade (in Radians)" & vbTab & "   Length (in Miles)" & vbTab & "   Radius (in Feet)")
                        For i = 0 To AscW(lstsGradeLength.Items.Count.ToString()(i = i + 1)) - 1

                            cellA = "A" & Convert.ToString(i + 1)
                            cellB = "B" & Convert.ToString(i + 1)
                            cellC = "C" & Convert.ToString(i + 1)
                            cellA = oSheet.Range(cellA).Value
                            cellB = oSheet.Range(cellB).Value
                            cellC = oSheet.Range(cellC).Value
                            If cellA = "" And cellB = "" And cellC = "" Then
                                Exit For
                            Else
                                RichTextBox2.AppendText(cellA & " " & cellB & " " & cellC & vbCrLf)

                            End If
                        Next
                        oExcel.Quit()
                        Dim m As Integer
                        For m = 1 To CInt(UBound(RichTextBox2.Lines))
                            ReDim Preserve Gradec(m)
                            ReDim Preserve Lengthc(m)
                            ReDim Preserve Radiusc(m)
                            Gradec(m) = RichTextBox2.Lines(m - 1).Split(" ").First
                            Lengthc(m) = RichTextBox2.Lines(m - 1).Split(" ").First + 1
                            Radiusc(m) = RichTextBox2.Lines(m - 1).Split(" ").Last
                            lstsGradeLength.Items.Add(Gradec(m) & vbTab & vbTab & vbTab & Lengthc(m) & vbTab & vbTab & vbTab & Radiusc(m) & vbCrLf)
                            butsGradeLength.Enabled = False
                        Next
                        testFile = My.Computer.FileSystem.GetFileInfo(strFile)

                        lblnPath.Text = testFile.FullName

                        txtsNumSections.Text = lstsGradeLength.Items.Count - 1
                    End If

                Catch ex As FileNotFoundException

                    ' If the file was not found, tell the user.

                    MessageBox.Show("File was Not found. Please try again.")

                End Try

            End If
        Else
            txtsNumSections.Text = ""
            butsImport.Enabled = True
            butsGradeLength.Enabled = True
            butsClear.Enabled = True
            Exit Sub
        End If

        butsImport.Enabled = False
        butsCompute.Enabled = True
    End Sub
    Private Sub butlogout_Click(sender As Object, e As EventArgs) Handles butlogout.Click
        Me.Close()
        frmLogin.Show()
        frmLogin.txtusername.Text = ""
        frmLogin.txtpassword.Text = ""
    End Sub
End Class
