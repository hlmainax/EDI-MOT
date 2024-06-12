Imports System.Data.SqlClient
Imports ConnData
Public Class FrmHRPORT

    Private Sub RBT5_CheckedChanged(sender As Object, e As EventArgs) Handles RBT5.CheckedChanged
        If RBT5.Checked = True Then
            FrmMDI.txtCNT.Text = "1000"
        End If
    End Sub

    Private Sub FrmHRPORT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
        Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = xW
        Me.Height = xH
        Me.WindowState = FormWindowState.Maximized
        DTP1.Text = Format(Now, "yyyy-MM-dd")
        DTP2.Text = Date.Now.ToShortDateString
    End Sub

    Private Sub FrmHRPORT_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
    End Sub

    Private Sub CmdVeiw_Click(sender As Object, e As EventArgs) Handles CmdVeiw.Click
        FrmRPT1.Show()
    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
        'Dim xw As Integer = Screen.PrimaryScreen.Bounds.Width
        'If xw < 1920 Then
        '    FrmCash1.Show()
        '    FrmCash1.BringToFront()
        'Else
        '    FrmCashier.Show()
        '    FrmCashier.MdiParent = FrmMDI
        '    FrmCashier.BringToFront()
        'End If
    End Sub

    Private Sub RBT2_CheckedChanged(sender As Object, e As EventArgs) Handles RBT2.CheckedChanged
        If RBT2.Checked = True Then
            FrmMDI.txtCNT.Text = "2000"
        End If
    End Sub

    Private Sub RBT3_CheckedChanged(sender As Object, e As EventArgs) Handles RBT3.CheckedChanged
        If RBT3.Checked = True Then
            FrmMDI.txtCNT.Text = "3000"
        End If
    End Sub

    Private Sub RBT4_CheckedChanged(sender As Object, e As EventArgs) Handles RBT4.CheckedChanged
        If RBT4.Checked = True Then
            FrmMDI.txtCNT.Text = "4000"
        End If
    End Sub

    Private Sub RBT6_CheckedChanged(sender As Object, e As EventArgs) Handles RBT6.CheckedChanged
        If RBT6.Checked = True Then
            FrmMDI.txtCNT.Text = "1122"
        End If
    End Sub

    Private Sub RBT7_CheckedChanged(sender As Object, e As EventArgs) Handles RBT7.CheckedChanged
        If RBT7.Checked = True Then
            FrmMDI.txtCNT.Text = "1123"
        End If
    End Sub

    Private Sub RBT8_CheckedChanged(sender As Object, e As EventArgs) Handles RBT8.CheckedChanged
        If RBT8.Checked = True Then
            FrmMDI.txtCNT.Text = "1124"
        End If
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        DTP1.Text = Format(Now, "yyyy-MM-dd")
        DTP2.Text = Date.Now.ToShortDateString
    End Sub
End Class