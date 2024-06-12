Imports ConnData
Imports System.Data.SqlClient
Imports POS_System.NewFunc

Public Class FrmStkAdjust
    Private Sub FrmStkAdjust_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xMAX(Me)
        CmdVeiw.Enabled = False
        StockLoad()
    End Sub

    Private Sub FrmStkAdjust_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        CmdVeiw.Enabled = False
        StockLoad()
    End Sub
    Private Sub StockLoad()
        GRID1.Rows.Clear()
        cmd = New SqlCommand("Select AutoID,ItemCode,ItemName,BalanceQty,PisicalQty from Stock_Main Order by ItemName", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            GRID1.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("BalanceQty"), "0", "0")
        End While
        rdr.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If GRID1.RowCount = 0 Then Return
        For Each row As DataGridViewRow In GRID1.Rows
            Dim curStk As Double = Val(row.Cells(3).Value)
            Dim adStk As Double = Val(row.Cells(4).Value)
            Dim difStk As Double = curStk - adStk
            row.Cells(5).Value = difStk
        Next
        CmdVeiw.Enabled = True
    End Sub

    Private Sub CmdVeiw_Click(sender As Object, e As EventArgs) Handles CmdVeiw.Click
        If GRID1.RowCount = 0 Then Return
        Dim result11 As DialogResult = MessageBox.Show("Are you sure the Stock Adjustment ?", "Stock Adjustment", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result11 = vbYes Then
            '  Aid, ItemCode, ItemName, RcvQty, SaleQty, DmgQty, LastUpdate Stock_Adj
            For Each row As DataGridViewRow In GRID1.Rows
                Dim aid As Integer = row.Cells(0).Value
                cmd = New SqlCommand("Update Stock_Main set BalanceQty='" & Val(row.Cells(4).Value) & "',PisicalQty='" & Val(row.Cells(4).Value) & "' where AutoId='" & aid & "'", con)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Insert Stock_Adj values('" & row.Cells(0).Value & "','" & row.Cells(1).Value & "','" & row.Cells(2).Value & "','" & Val(row.Cells(3).Value) & "','" & Val(row.Cells(4).Value) & "','" & Val(row.Cells(5).Value) & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "')", con)
                cmd.ExecuteNonQuery()
            Next
            MessageBox.Show("Stock Adjust Successs...!")
            CmdCancel_Click(sender, e)

        End If
    End Sub
End Class