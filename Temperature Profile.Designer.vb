<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTempProfile
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
        Me.lstTempProfile = New System.Windows.Forms.ListBox()
        Me.buttempSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtinibraketemp = New System.Windows.Forms.TextBox()
        Me.txtTempSpeed = New System.Windows.Forms.TextBox()
        Me.txttempWeight = New System.Windows.Forms.TextBox()
        Me.buttempReset = New System.Windows.Forms.Button()
        Me.buttempCompute = New System.Windows.Forms.Button()
        Me.butfilter = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstTempProfile
        '
        Me.lstTempProfile.FormattingEnabled = True
        Me.lstTempProfile.HorizontalScrollbar = True
        Me.lstTempProfile.ItemHeight = 16
        Me.lstTempProfile.Location = New System.Drawing.Point(12, 44)
        Me.lstTempProfile.Name = "lstTempProfile"
        Me.lstTempProfile.Size = New System.Drawing.Size(788, 228)
        Me.lstTempProfile.TabIndex = 0
        '
        'buttempSave
        '
        Me.buttempSave.Enabled = False
        Me.buttempSave.Location = New System.Drawing.Point(529, 278)
        Me.buttempSave.Name = "buttempSave"
        Me.buttempSave.Size = New System.Drawing.Size(86, 36)
        Me.buttempSave.TabIndex = 1
        Me.buttempSave.Text = "Save"
        Me.buttempSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Truck Weight (lb)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(287, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Speed (mph)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(568, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Initial Brake Temp (F)"
        '
        'txtinibraketemp
        '
        Me.txtinibraketemp.Location = New System.Drawing.Point(735, 12)
        Me.txtinibraketemp.Name = "txtinibraketemp"
        Me.txtinibraketemp.Size = New System.Drawing.Size(65, 22)
        Me.txtinibraketemp.TabIndex = 5
        '
        'txtTempSpeed
        '
        Me.txtTempSpeed.Location = New System.Drawing.Point(403, 9)
        Me.txtTempSpeed.Name = "txtTempSpeed"
        Me.txtTempSpeed.Size = New System.Drawing.Size(71, 22)
        Me.txtTempSpeed.TabIndex = 6
        '
        'txttempWeight
        '
        Me.txttempWeight.Location = New System.Drawing.Point(129, 12)
        Me.txttempWeight.Name = "txttempWeight"
        Me.txttempWeight.Size = New System.Drawing.Size(60, 22)
        Me.txttempWeight.TabIndex = 7
        '
        'buttempReset
        '
        Me.buttempReset.Location = New System.Drawing.Point(714, 278)
        Me.buttempReset.Name = "buttempReset"
        Me.buttempReset.Size = New System.Drawing.Size(86, 36)
        Me.buttempReset.TabIndex = 8
        Me.buttempReset.Text = "Reset"
        Me.buttempReset.UseVisualStyleBackColor = True
        '
        'buttempCompute
        '
        Me.buttempCompute.Location = New System.Drawing.Point(12, 278)
        Me.buttempCompute.Name = "buttempCompute"
        Me.buttempCompute.Size = New System.Drawing.Size(86, 36)
        Me.buttempCompute.TabIndex = 9
        Me.buttempCompute.Text = "Compute"
        Me.buttempCompute.UseVisualStyleBackColor = True
        '
        'butfilter
        '
        Me.butfilter.Enabled = False
        Me.butfilter.Location = New System.Drawing.Point(268, 278)
        Me.butfilter.Name = "butfilter"
        Me.butfilter.Size = New System.Drawing.Size(86, 36)
        Me.butfilter.TabIndex = 10
        Me.butfilter.Text = "Filter"
        Me.butfilter.UseVisualStyleBackColor = True
        '
        'frmTempProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 316)
        Me.Controls.Add(Me.butfilter)
        Me.Controls.Add(Me.buttempCompute)
        Me.Controls.Add(Me.buttempReset)
        Me.Controls.Add(Me.txttempWeight)
        Me.Controls.Add(Me.txtTempSpeed)
        Me.Controls.Add(Me.txtinibraketemp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.buttempSave)
        Me.Controls.Add(Me.lstTempProfile)
        Me.Name = "frmTempProfile"
        Me.Text = "Temperature_Profile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstTempProfile As ListBox
    Friend WithEvents buttempSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtinibraketemp As TextBox
    Friend WithEvents txtTempSpeed As TextBox
    Friend WithEvents txttempWeight As TextBox
    Friend WithEvents buttempReset As Button
    Friend WithEvents buttempCompute As Button
    Friend WithEvents butfilter As Button
End Class
