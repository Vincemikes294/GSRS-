<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDI))
        Me.mnuItems = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContinuousSlopeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeparateSlopeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItems.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuItems
        '
        Me.mnuItems.AutoSize = False
        Me.mnuItems.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.LogOutToolStripMenuItem})
        Me.mnuItems.Location = New System.Drawing.Point(0, 0)
        Me.mnuItems.Name = "mnuItems"
        Me.mnuItems.Size = New System.Drawing.Size(1860, 28)
        Me.mnuItems.TabIndex = 1
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContinuousSlopeToolStripMenuItem, Me.SeparateSlopeToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(132, 24)
        Me.FileToolStripMenuItem.Text = "Analysis Options"
        '
        'ContinuousSlopeToolStripMenuItem
        '
        Me.ContinuousSlopeToolStripMenuItem.Name = "ContinuousSlopeToolStripMenuItem"
        Me.ContinuousSlopeToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.ContinuousSlopeToolStripMenuItem.Text = "Continuous Slope"
        '
        'SeparateSlopeToolStripMenuItem
        '
        Me.SeparateSlopeToolStripMenuItem.Name = "SeparateSlopeToolStripMenuItem"
        Me.SeparateSlopeToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.SeparateSlopeToolStripMenuItem.Text = "Separate Slope"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(72, 24)
        Me.LogOutToolStripMenuItem.Text = "LogOut"
        '
        'MDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1860, 861)
        Me.Controls.Add(Me.mnuItems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuItems
        Me.Name = "MDI"
        Me.Text = "                                                                                 " &
    "                                                                GSRS Automator"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuItems.ResumeLayout(False)
        Me.mnuItems.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mnuItems As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContinuousSlopeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeparateSlopeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
