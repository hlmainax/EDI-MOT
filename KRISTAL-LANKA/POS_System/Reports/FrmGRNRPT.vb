Imports System.Data.SqlClient
Imports ConnData
Public Class FrmGRNRPT

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
        Dim xw As Integer = Screen.PrimaryScreen.Bounds.Width
        If xw < 1920 Then
            FrmCash1.Show()
            FrmCash1.BringToFront()
        Else
            FrmCashier.Show()
            FrmCashier.MdiParent = FrmMDI
            FrmCashier.BringToFront()
        End If
    End Sub

    Private Sub FrmGRNRPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
        Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = xW
        Me.Height = xH
        Me.WindowState = FormWindowState.Maximized
        xSUP()
        DTP1.Text = Format(Now, "yyyy-MM-dd")
        DTP2.Text = Format(Now, "yyyy-MM-dd")

        'AboutBox1.Close()
    End Sub

    Private Sub FrmGRNRPT_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
    End Sub
    Private Sub xSUP()
        cmd = New SqlCommand("Select * from Supplier", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick
        cmd = New SqlCommand("Select * from GRN_Main where(SupCode='" & GRID1.Item(0, GRID1.CurrentRow.Index).Value & "')", con)
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("GRNNo"))
        End While
        rdr.Close()
    End Sub

    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        SupCD.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        SupNm.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
    End Sub

    Private Sub CmdVeiw_Click(sender As Object, e As EventArgs) Handles CmdVeiw.Click
        If (RBT1.Checked = False And RBT2.Checked = False And RBT3.Checked = False And RBT4.Checked = False And RBT5.Checked = False And RBT6.Checked = False) Then Return
        FrmMDI.txtCNT.Text = 0
        FrmMDI.txtCNT.Text = 1
        FrmRPT.Show()
    End Sub

    Private Sub RBT1_CheckedChanged(sender As Object, e As EventArgs) Handles RBT1.CheckedChanged
      
    End Sub

    Private Sub txtSupCode_TextChanged(sender As Object, e As EventArgs) Handles txtSupCode.TextChanged

        If txtSupCode.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier order by SupName", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupCode like '" & txtSupCode.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()

    End Sub

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier order by SupName", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupName like '" & txtSupName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        SupCD.Clear()
        txtSupCode.Clear()
        SupNm.Clear()
        txtSupName.Clear()
        GRID2.Rows.Clear()
    End Sub

    Private Sub GRID2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentClick

    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        GRNNo.Text = GRID2.Item(0, GRID2.CurrentRow.Index).Value
    End Sub

    Private Sub RBT5_CheckedChanged(sender As Object, e As EventArgs) Handles RBT5.CheckedChanged

    End Sub

    Private Sub RBT4_CheckedChanged(sender As Object, e As EventArgs) Handles RBT4.CheckedChanged

    End Sub

    Private Sub RBT6_CheckedChanged(sender As Object, e As EventArgs) Handles RBT6.CheckedChanged

    End Sub
End Class