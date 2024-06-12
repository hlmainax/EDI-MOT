Imports System.Data.SqlClient
Imports ConnData
Public Class frmBackup

    Private Sub CmdBackup_Click(sender As Object, e As EventArgs) Handles CmdBackup.Click
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.InitialDirectory = "C:\Users\acer-pc\Dropbox\My PC (acer-pc)\Documents"
        SaveFileDialog1.Filter = "Backup Files (*.bak)|*.bak"
        SaveFileDialog1.RestoreDirectory = True
        SaveFileDialog1.Title = "Create Database Backup"
        SaveFileDialog1.FileName = "POS" + Now.ToString("yyyy-MM-dd H:mm:ss")
        'Dim sName As String = "C:\Users\acer-pc\Dropbox\My PC (acer-pc)\Documents\" + "POS" + Now.ToString("yyyy-MM-dd H:mm:ss")


        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'getting backup file path...
            '  Dim path As String = System.IO.Path.GetFullPath(sName)
            path = System.IO.Path.GetFullPath(SaveFileDialog1.FileName)


            'Code to backup database.
            Try
                'Backup In progress...
                Timer1.Start()

                cmd = New SqlCommand("USE master; BACKUP DATABASE Kristal_Lanka TO DISK = '" & path.ToString & "'", con)
                'con.Open()
                cmd.ExecuteNonQuery()
                'MsgBox("Backup Succeed. System will Close, To Use the System Please Restart the System...", MsgBoxStyle.Information)
                'Application.Exit()
                'con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                'con.Close()
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Label3.Text = ProgressBar1.Value & (" %")
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            'MessageBox.Show("Database Backup", "Backup Succeed!", MsgBoxStyle.Information)
            MsgBox("DB Backup/Restore Succeed. System will Close, To Use the System Please Restart the System...", MsgBoxStyle.Information)

            ProgressBar1.Value = 0
            Label3.Text = "0 %"
            Application.Exit()
        End If
    End Sub

    Private Sub frmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'AboutBox1.Close()
    End Sub

    Private Sub frmBackup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Maximized
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'blank("restore")
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.InitialDirectory = "C:\Program Files"
        OpenFileDialog1.Filter = "Backup Files (*.bak)|*.bak"
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Title = "Open backup file"
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'getting restore file path.
            Dim path As String
            path = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
            '
            '  Code to restore database.
            Try
                con3.close()
                cmd3 = New SqlCommand("USE master ALTER DATABASE Kristal_Lanka  SET SINGLE_USER WITH ROLLBACK IMMEDIATE  RESTORE DATABASE   Kristal_Lanka FROM DISK = '" & path & "' ALTER DATABASE Kristal_Lanka SET MULTI_USER ;", con3)
                con3.Open()
                cmd3.CommandTimeout = 600
                cmd3.ExecuteNonQuery()
                con3.Close()
                Timer1.Enabled = True
                Timer1.Start()
            Catch ex As Exception
                MsgBox(ex.Message)
                con3.Close()
            End Try
        End If
    End Sub
End Class