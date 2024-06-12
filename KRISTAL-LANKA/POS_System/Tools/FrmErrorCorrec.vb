Imports System.Data.SqlClient
Imports ConnData
Imports POS_System.NewFunc
Public Class FrmErrorCorrec
    Private Sub FrmErrorCorrec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
        Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = xW
        Me.Height = xH
        Me.WindowState = FormWindowState.Maximized
        DTP2.Value = Format(Now, "yyyy-MM-dd")

        'AboutBox1.Close()
    End Sub

    Private Sub FrmErrorCorrec_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
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

    Private Sub DTP2_ValueChanged(sender As Object, e As EventArgs) Handles DTP2.ValueChanged
        If RBT3.Checked = True Then
            cmd = New SqlCommand("Select * from CHQPAY_Sub where LastUpdate='" & DTP2.Text & "'and ", con)
            rdr = cmd.ExecuteReader
            GRID1.Rows.Clear()
            While rdr.Read
                GRID1.Rows.Add(rdr("AutoID"), rdr("SupCode"), rdr("SupName"), rdr("AccNo"), rdr("BankName"), rdr("CHQNo"), rdr("CHQUpdate"), rdr("CHQAmnt"), rdr("BankAcc"), rdr("UName"))
            End While
            rdr.Close()
        End If
    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        Dim result11 As DialogResult = MessageBox.Show("Are you sure to Delete ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result11 = vbYes Then
            Dim xA As String = Nothing
            Dim xB As String = Nothing
            Dim xC As String = Nothing
            Dim xD As String = Nothing
            Dim xE As String = Nothing
            xA = GRID1.Item(0, GRID1.CurrentRow.Index).Value
            xB = GRID1.Item(1, GRID1.CurrentRow.Index).Value
            xC = GRID1.Item(2, GRID1.CurrentRow.Index).Value
            xD = GRID1.Item(3, GRID1.CurrentRow.Index).Value
            xE = GRID1.Item(4, GRID1.CurrentRow.Index).Value






        End If

    End Sub

    Private Sub CmdEmpty_Click(sender As Object, e As EventArgs) Handles CmdEmpty.Click
        Dim result1 As DialogResult = MessageBox.Show("Before Execute this Proccess Please go to TOOLS and take a BACKUP of DATABASE first....! Do you want to Continue ?", "Empty Database", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            Dim result2 As DialogResult = MessageBox.Show("All Your Datas will be ERASED and no longer available anymore....! Do you want to Continue ?", "Empty Database", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
            If result2 = vbYes Then

                cmd = New SqlCommand("Select * from sys.tables", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    Dim xNAME As String = rdr("name").ToString
                    xNAME = xNAME.Trim("")
                    Dim xQry As String = "Delete from " & xNAME
                    If rdr("name").ToString = "Workstation" Then
                    Else
                        cmd1 = New SqlCommand(xQry, con1)
                        cmd1.ExecuteNonQuery()
                    End If
                End While
                rdr.Close()
                MessageBox.Show("Erased Succeed...! Please restart the App...!", "Empty Database", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If

    End Sub
End Class