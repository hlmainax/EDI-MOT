Imports System.Data.SqlClient
Imports ConnData
Public Class FrmREPORT
    Public xVW As Boolean = False
    Private Sub FrmREPORT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        DTP1.Value = Now.ToShortDateString
        DTP2.Value = Now.ToShortDateString
        DTP3.Value = Now.ToShortDateString
        Panel1.Hide()
        gridLd()
        FrmMDI.txtCNT.Text = 0
        FrmMDI.txtCNT.Text = 2
    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdVeiw_Click(sender As Object, e As EventArgs) Handles CmdVeiw.Click
        xVW = False
        TextBox1.Text = Format(DTP1.Value, "yyyy-MM-dd").ToString

        If CmbRPT.Text = "Credit Sold Items" Then
            If CusCode.Text = "" Then Return
        End If


        FrmRPT.Show()

    End Sub

    Private Sub FrmREPORT_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        'Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        'Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
    End Sub

    Private Sub CusCoode_TextChanged(sender As Object, e As EventArgs) Handles CusCoode.TextChanged
        If CusCoode.Text = "" Then
            cmd = New SqlCommand("Select * from Cus_Master order by CusName", con)
        Else
            cmd = New SqlCommand("Select * from Cus_Master where CusCode like '" & CusCoode.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"))
        End While
        rdr.Close()
    End Sub
    Private Sub gridLd()
        cmd = New SqlCommand("Select * from Cus_Master order by CusName", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"))
        End While
        rdr.Close()
    End Sub

    Private Sub CusName_TextChanged(sender As Object, e As EventArgs) Handles CusName.TextChanged
        If CusName.Text = "" Then
            cmd = New SqlCommand("Select * from Cus_Master order by CusName", con)
        Else
            cmd = New SqlCommand("Select * from Cus_Master where CusName like '" & CusName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"))
        End While
        rdr.Close()
    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick
        CusCode.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value()
    End Sub

    Private Sub CmdVw_Click(sender As Object, e As EventArgs) Handles CmdVw.Click
        xVW = True
        FrmRPT.Show()
        Panel2.Enabled = True
        txtCucCd.Clear()
        txtCusNm.Clear()
        Panel1.Hide()
    End Sub

    Private Sub CmdCanc_Click(sender As Object, e As EventArgs) Handles CmdCanc.Click
        xVW = False
        Panel2.Enabled = True
        txtCucCd.Clear()
        txtCusNm.Clear()
        Panel1.Hide()
        Panel2.BringToFront()
    End Sub

    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        Panel2.Enabled = False
        Panel1.Show()
        Panel1.BringToFront()
        txtCucCd.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        txtCusNm.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        DTP1.Value = Now.ToShortDateString
        DTP2.Value = Now.ToShortDateString
        DTP3.Value = Now.ToShortDateString
    End Sub
End Class