Imports System.Data.SqlClient
Imports ConnData
Public Class FrmSTCKENTER
    Dim xCPRICE As Double = 0
    Dim xSPRICE As Double = 0
    Dim xWPRICE As Double = 0
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If GRID1.Rows.Count = 0 Then Return
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Add these Items to Stock ?", "Add Items to Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            For i As Integer = 0 To GRID1.RowCount - 1
                '                               AutoID,           GRNNo,              SupCode,              ItemCode,                        ItemName,                UOM,                      CostPrice,                   Qty,                        Amount                                 LastUpdate                          UName
                'cmd = New SqlCommand("Insert GRN_Sub values('" & GRNNo.Text & "','" & SupCode.Text & "','" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(3, i).Value & "','" & GRID1(2, i).Value & "','" & GRID1(4, i).Value & "','" & GRID1(5, i).Value & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                'cmd.ExecuteNonQuery()

                cmd = New SqlCommand("Select * From ItemMaster where ItemCode='" & GRID1(0, i).Value & "'", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    xCPRICE = rdr("CostPrice").ToString
                    xSPRICE = rdr("SellPrice").ToString
                    xWPRICE = rdr("WsPrice").ToString
                End If
                rdr.Close()


                'Stock Update.....................................................................
                cmd = New SqlCommand("Select * from Stock_Main where ItemCode='" & GRID1(0, i).Value & "'", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    Dim xBLQTY As Double = rdr("BalanceQty").ToString
                    Dim xPCQty As Double = rdr("PisicalQty").ToString
                    cmd1 = New SqlCommand("Update Stock_Main Set RcvQty='" & Val(GRID1(6, i).Value) + Val(rdr("RcvQty")) & "',BalanceQty='" & xBLQTY + Val(GRID1(6, i).Value) & "',PisicalQty='" & xPCQty + Val(GRID1(6, i).Value) & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "'where ItemCode='" & GRID1(0, i).Value & "'", con1)
                    cmd1.ExecuteNonQuery()
                Else
                    '                   AutoID,                             ItemCode,                   ItemName,                   UOM,                     CostPrice,      SellPrice,              RcvQty,             SaleQty,        DmgQty,     RtnQty,        BalanceQty,                     PisicalQty,                              LastUpdate,                                 UName
                    cmd1 = New SqlCommand("Insert Stock_Main values('" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(2, i).Value & "','" & xCPRICE & "','" & xSPRICE & "','" & Val(GRID1(6, i).Value) & "','" & 0 & "','" & 0 & "','" & 0 & "','" & Val(GRID1(6, i).Value) & "','" & Val(GRID1(6, i).Value) & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & xWPRICE & "','" & "NON" & "')", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()
            Next
            MessageBox.Show("Add Items to Stock Succeed.", "Add Items to Stock", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
        CmdCancel_Click(sender, EventArgs.Empty)

    End Sub

    Private Sub FrmSTCKENTER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.WindowState = FormWindowState.Maximized
        Panel2.Hide()

        AboutBox1.Close()
    End Sub

    Private Sub FrmSTCKENTER_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        'Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        'Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        GRID1.Rows.Clear()
        ItemCode.Clear()
        ItemName.Clear()
        Price.Clear()
        WPrice.Clear()
        SPrice.Clear()
        UOM1.Clear()
        Qty.Clear()
        'Tot.Clear()
        ItemCode.Focus()

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

    Private Sub Qty_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty.KeyDown
        If e.KeyCode = 13 Then
            If ItemCode.Text = "" Then Return
            'Dim xAMT As Double
            Dim RowTrue As Boolean = False, RowID As Integer = 0
            For Each row As DataGridViewRow In GRID1.Rows
                If (row.Cells(0).Value = ItemCode.Text) Then
                    RowTrue = True : RowID = row.Index : Exit For
                End If
            Next
            If RowTrue = True Then
                GRID1.Rows(RowID).Cells(6).Value = GRID1.Rows(RowID).Cells(6).Value + Val(Qty.Text)

                'GRID1.Rows(RowID).Cells(5).Value = Tot.Text
            Else
                GRID1.Rows.Add(ItemCode.Text, ItemName.Text, UOM1.Text, Price.Text, WPrice.Text, SPrice.Text, Qty.Text)
            End If

            'Dim xTOT As Double
            'For Each row As DataGridViewRow In GRID1.Rows
            '    xTOT += row.Cells(5).Value
            'Next
            'Total.Text = xTOT
            'Total.Text = Format(Val(Total.Text), "0.00")


            ItemCode.Clear()
            ItemName.Clear()
            Price.Clear()
            WPrice.Clear()
            SPrice.Clear()
            UOM1.Clear()
            Qty.Clear()
            'Tot.Clear()
            ItemCode.Focus()
        End If
    End Sub

    Private Sub Qty_TextChanged(sender As Object, e As EventArgs) Handles Qty.TextChanged
        If IsNumeric(Qty.Text) = False Then Qty.Clear()
        'Tot.Text = Val(Price.Text) * Val(Qty.Text)
        'Tot.Text = Format(Val(Tot.Text), "0.00")
    End Sub

  

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        xITM(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
        UOM1.Text = GRID1.Item(2, GRID1.CurrentRow.Index).Value
        Qty.Text = GRID1.Item(6, GRID1.CurrentRow.Index).Value
        'Tot.Text = GRID1.Item(5, GRID1.CurrentRow.Index).Value
        GRID1.Rows.RemoveAt(GRID1.CurrentRow.Index)

        'Dim xTOT As Double
        'For Each row As DataGridViewRow In GRID1.Rows
        '    xTOT += row.Cells(5).Value
        'Next
        'Total.Text = xTOT
        'Total.Text = Format(Val(Total.Text), "0.00")
    End Sub
    Private Sub xITM(ByVal xITC As String)
        cmd = New SqlCommand("Select * from ItemMaster where(ItemCode='" & xITC & "'and InAct=0)", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            ItemCode.Text = rdr("ItemCode").ToString
            ItemName.Text = rdr("ItemName").ToString
            Price.Text = Format(rdr("CostPrice"), "0.00").ToString
            SPrice.Text = Format(rdr("SellPrice"), "0.00").ToString
            WPrice.Text = Format(rdr("WsPrice"), "0.00").ToString
            UOM1.Text = rdr("Uom").ToString
        End If
        rdr.Close()
    End Sub

    Private Sub ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemCode.KeyDown
        If e.KeyCode = 13 Then
            xITM(ItemCode.Text)
            ItemCode.Focus()
        ElseIf e.KeyCode = 113 Then
            Panel1.Hide()

            Panel2.Show()
            txtItemCode_TextChanged(sender, EventArgs.Empty)
            txtItemCode.Focus()

        ElseIf e.KeyCode = 27 Then
            ItemCode.Clear()
            ItemName.Clear()
            Price.Clear()
            WPrice.Clear()
            SPrice.Clear()
            UOM1.Clear()
            Qty.Clear()
            'Tot.Clear()
            ItemCode.Focus()
        End If
    End Sub

    Private Sub ItemCode_TextChanged(sender As Object, e As EventArgs) Handles ItemCode.TextChanged

    End Sub

    Private Sub txtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = 27 Then
            txtItemCode.Clear()
            txtItemCode.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()

            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtItemName.Focus()
        End If
    End Sub

    Private Sub txtItemCode_TextChanged(sender As Object, e As EventArgs) Handles txtItemCode.TextChanged
        If txtItemCode.Text = "" Then
            cmd = New SqlCommand("Select * from ItemMaster where InAct = 0 order by ItemCode ", con)
        Else
            cmd = New SqlCommand("Select * from ItemMaster where ItemCode like '" & txtItemCode.Text & "%' and Inact = 0 Order By ItemCode ", con)

        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()
    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown
        If e.KeyCode = 27 Then
            txtItemCode.Clear()
            txtItemName.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()

            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtItemCode.Focus()
        End If
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged
        If txtItemName.Text = "" Then
            cmd = New SqlCommand("Select * from ItemMaster where Inact=0 order by ItemCode", con)
        Else
            cmd = New SqlCommand("Select * from ItemMaster where ItemName like '" & txtItemName.Text & "%'and InAct=0 order by ItemCode ", con)

        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()
    End Sub

    Private Sub GRID2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentClick

    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        xITM(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        Panel2.Hide()

        Panel1.Show()
        ItemCode.Focus()
    End Sub

    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.Rows.Count = 0 Then Return
            xITM(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            Panel2.Hide()

            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            txtItemCode.Focus()
        End If
    End Sub

    Private Sub UOM1_TextChanged(sender As Object, e As EventArgs) Handles UOM1.TextChanged

    End Sub

    Private Sub Price_TextChanged(sender As Object, e As EventArgs) Handles Price.TextChanged

    End Sub

    Private Sub WPrice_TextChanged(sender As Object, e As EventArgs) Handles WPrice.TextChanged

    End Sub

    Private Sub SPrice_TextChanged(sender As Object, e As EventArgs) Handles SPrice.TextChanged

    End Sub
End Class