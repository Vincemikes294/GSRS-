Public Class MDI

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        frmMain.MdiParent = Me
        frmLogin.MDIParent = Me
    End Sub
    Private Sub ContinuousSlopeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ContinuousSlopeToolStripMenuItem.Click
        frmMain.Show()
        frmMain.MdiParent = Me
        frmMain.GroupContinuousSlope.Enabled = True
        frmMain.GroupSeparateSlope.Enabled = False
    End Sub
    Private Sub SeparateSlopeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SeparateSlopeToolStripMenuItem.Click
        frmMain.Show()
        frmMain.MdiParent = Me
        frmMain.GroupContinuousSlope.Enabled = False
        frmMain.GroupSeparateSlope.Enabled = True
    End Sub
    Private Sub LogOutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        frmMain.Close()
        frmLogin.Show()
        frmLogin.MdiParent = Me

    End Sub
    Private Sub mnuItems_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles mnuItems.ItemClicked

    End Sub
    Private Sub FileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub
End Class