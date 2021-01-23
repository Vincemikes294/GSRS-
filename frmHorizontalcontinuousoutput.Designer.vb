<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorizontalcontinuousoutput
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
        Me.lstFinalOutputView = New System.Windows.Forms.ListBox()
        Me.butReset = New System.Windows.Forms.Button()
        Me.butFilter = New System.Windows.Forms.Button()
        Me.butLoad = New System.Windows.Forms.Button()
        Me.butSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstFinalOutputView
        '
        Me.lstFinalOutputView.FormattingEnabled = True
        Me.lstFinalOutputView.HorizontalScrollbar = True
        Me.lstFinalOutputView.ItemHeight = 16
        Me.lstFinalOutputView.Location = New System.Drawing.Point(12, 12)
        Me.lstFinalOutputView.Name = "lstFinalOutputView"
        Me.lstFinalOutputView.Size = New System.Drawing.Size(415, 340)
        Me.lstFinalOutputView.TabIndex = 26
        '
        'butReset
        '
        Me.butReset.Location = New System.Drawing.Point(355, 375)
        Me.butReset.Name = "butReset"
        Me.butReset.Size = New System.Drawing.Size(72, 35)
        Me.butReset.TabIndex = 31
        Me.butReset.Text = "Reset"
        Me.butReset.UseVisualStyleBackColor = True
        '
        'butFilter
        '
        Me.butFilter.Enabled = False
        Me.butFilter.Location = New System.Drawing.Point(239, 375)
        Me.butFilter.Name = "butFilter"
        Me.butFilter.Size = New System.Drawing.Size(77, 35)
        Me.butFilter.TabIndex = 30
        Me.butFilter.Text = "Filter"
        Me.butFilter.UseVisualStyleBackColor = True
        '
        'butLoad
        '
        Me.butLoad.Location = New System.Drawing.Point(13, 374)
        Me.butLoad.Name = "butLoad"
        Me.butLoad.Size = New System.Drawing.Size(82, 36)
        Me.butLoad.TabIndex = 29
        Me.butLoad.Text = "Load"
        Me.butLoad.UseVisualStyleBackColor = True
        '
        'butSave
        '
        Me.butSave.Location = New System.Drawing.Point(128, 375)
        Me.butSave.Name = "butSave"
        Me.butSave.Size = New System.Drawing.Size(82, 36)
        Me.butSave.TabIndex = 32
        Me.butSave.Text = "Save"
        Me.butSave.UseVisualStyleBackColor = True
        '
        'frmHorizontalcontinuousoutput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 431)
        Me.Controls.Add(Me.butSave)
        Me.Controls.Add(Me.butReset)
        Me.Controls.Add(Me.butFilter)
        Me.Controls.Add(Me.butLoad)
        Me.Controls.Add(Me.lstFinalOutputView)
        Me.Name = "frmHorizontalcontinuousoutput"
        Me.Text = "                                            Final Output"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstFinalOutputView As ListBox
    Friend WithEvents butReset As Button
    Friend WithEvents butFilter As Button
    Friend WithEvents butLoad As Button
    Friend WithEvents butSave As Button
End Class
