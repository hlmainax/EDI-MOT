Imports ConnData
Imports System.Data.SqlClient

Public Class FrmAct
    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Application.Exit()
    End Sub

    Private Sub FrmAct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmLoggin.SendToBack()
        Me.BringToFront()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class