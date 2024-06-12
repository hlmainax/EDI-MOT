Imports System.Data.SqlClient
Imports ConnData
Public Class frmPchange

    Private Sub frmPchange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height

        Me.WindowState = FormWindowState.Maximized
        Panel3.Hide()
        Dim xx As Integer = 0
        cmd = New SqlCommand("Select xINT from User_Option where UserName='" & FrmMDI.UName.Text & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xx = rdr("xINT")
        End If
        rdr.Close()



        cmd = New SqlCommand("Select * from Stock_Main ", con)
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("BalanceQty"))
            cmd1 = New SqlCommand("Update ItemMaster set SellPrice='" & rdr("SellPrice") & "'where ItemCode='" & rdr("ItemCode") & "'", con1)
            cmd1.ExecuteNonQuery()
        End While
        rdr.Close()
        FrmCashier.Dispose()




        'If xx = 1 Then
        '    GRID2.Columns(3).Visible = False
        'Else
        '    GRID2.Columns(3).Visible = True
        'End If

        'For Each f As Form In My.Application.OpenForms
        '    If f.Name = Me.Name Then
        '    ElseIf f.Name = "FrmMDI" Then
        '    ElseIf f.Name = "FrmLoggin" Then
        '    Else
        '        f.Dispose()
        '    End If
        '    'Me.SomeListBox.Items.Add(f)
        'Next



        'AboutBox1.Close()











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

    Private Sub frmPchange_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        'Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        'Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
    End Sub

    Private Sub txtItemCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = Keys.Right Then
            txtItemName.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = 27 Then
            txtItemCode.Clear()
            txtItemName.Clear()

        End If
    End Sub

    Private Sub txtItemCode_TextChanged(sender As Object, e As EventArgs) Handles txtItemCode.TextChanged
        If txtItemCode.Text = "" Then
            cmd = New SqlCommand("Select * from Stock_Main", con)
        Else
            cmd = New SqlCommand("Select * from Stock_Main where ItemCode like '" & txtItemCode.Text & "%'and BalanceQty > 0 ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("BalanceQty"))
        End While
        rdr.Close()
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged
        If txtItemName.Text = "" Then
            cmd = New SqlCommand("Select * from Stock_Main", con)
        Else
            cmd = New SqlCommand("Select * from Stock_Main where ItemName like '%" & txtItemName.Text & "%'and BalanceQty > 0 ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("BalanceQty"))
        End While
        rdr.Close()
    End Sub

    Private Sub GRID2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentClick

    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        cmd = New SqlCommand("Select * from Stock_Main where(AutoID='" & GRID2.Item(0, GRID2.CurrentRow.Index).Value & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            ' AutoID, ItemCode, ItemName, UOM, CostPrice, SellPrice, RcvQty, SaleQty, DmgQty, RtnQty, BalanceQty, PisicalQty, LastUpdate, UName, WsPrice
            RFId.Text = rdr("AutoID").ToString
            ItemCode.Text = rdr("ItemCode").ToString
            ItemName.Text = rdr("ItemName").ToString
            UOM.Text = rdr("UOM").ToString
            CPrice.Text = rdr("CostPrice").ToString
            CPrice.Text = Format(Val(CPrice.Text), "0.00")
            SPrice.Text = rdr("SellPrice").ToString
            SPrice.Text = Format(Val(SPrice.Text), "0.00")
            WPrice.Text = rdr("WsPrice").ToString
            WPrice.Text = Format(Val(WPrice.Text), "0.00")
            Qty.Text = rdr("BalanceQty").ToString
            ItemName.Focus()
        End If
        rdr.Close()
    End Sub

    Private Sub SPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles SPrice.KeyDown
        If e.KeyCode = 13 Then
            Qty.Focus()
        End If

    End Sub

    Private Sub SPrice_TextChanged(sender As Object, e As EventArgs) Handles SPrice.TextChanged

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        RFId.Clear()
        ItemCode.Clear()
        ItemName.Clear()
        UOM.Clear()
        CPrice.Clear()
        WPrice.Clear()
        SPrice.Clear()
        Qty.Clear()
        ItemCode.Focus()
        GRID1.Rows.Clear()
    End Sub

    Private Sub ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemCode.KeyDown
        If e.KeyCode = 13 Then
            xITM(ItemCode.Text)
        ElseIf e.KeyCode = 27 Then
            RFId.Clear()
            ItemCode.Clear()
            ItemName.Clear()
            CPrice.Clear()
            WPrice.Clear()
            SPrice.Clear()
            UOM.Clear()
            txtItemCode.Focus()
        End If
    End Sub

    'SELECT ItemCode, COUNT(*) TotalCount FROM Stock_Main GROUP BY ItemCode HAVING COUNT(*) > 1 ORDER BY COUNT(*) DESC 


    Private Sub ItemCode_TextChanged(sender As Object, e As EventArgs) Handles ItemCode.TextChanged

    End Sub
    Dim xCOUNT As Integer = 0
    Private Sub xITM(ByVal xITC As String)
        cmd = New SqlCommand("Select * from ItemMaster where ItemCode='" & xITC & "'", con)
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Select * from Stock_Main where(ItemCode='" & rdr("ItemCode") & "')", con1)
            rdr1 = cmd1.ExecuteReader
            While rdr1.Read
                GRID3.Rows.Add(rdr1("AutoID"), rdr1("ItemCode"), rdr1("ItemName"), Format(rdr1("CostPrice"), "0.00"), Format(rdr1("WsPrice"), "0.00"), Format(rdr1("SellPrice"), "0.00"), rdr1("UOM"), rdr1("BalanceQty"))
                xCOUNT += 1
                If xCOUNT > 1 Then
                    RFId.Clear()
                    'ItemCode.Clear()
                    ItemName.Clear()
                    CPrice.Clear()
                    WPrice.Clear()
                    SPrice.Clear()
                    ItemCode.Focus()
                    Panel3.Show()
                    Panel1.Enabled = False
                    GRID3.Focus()
                Else
                    RFId.Text = rdr1("AutoID").ToString
                    ItemCode.Text = rdr1("ItemCode").ToString
                    ItemName.Text = rdr1("ItemName").ToString
                    CPrice.Text = rdr1("CostPrice").ToString
                    WPrice.Text = rdr1("WsPrice").ToString
                    SPrice.Text = rdr1("SellPrice").ToString


                    CPrice.Text = Format(Val(CPrice.Text), "0.00")
                    WPrice.Text = Format(Val(WPrice.Text), "0.00")
                    SPrice.Text = Format(Val(SPrice.Text), "0.00")
                    Qty.Text = rdr1("BalanceQty").ToString
                    UOM.Text = rdr1("UOM").ToString
                    ItemName.Focus()
                End If
            End While
            rdr1.Close()
        End If
        rdr.Close()
        xCOUNT = 0
    End Sub

    Private Sub GRID3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID3.CellContentClick

    End Sub

    Private Sub GRID3_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID3.CellContentDoubleClick
        RFId.Text = GRID3.Item(0, GRID3.CurrentRow.Index).Value
        ItemCode.Text = GRID3.Item(1, GRID3.CurrentRow.Index).Value
        ItemName.Text = GRID3.Item(2, GRID3.CurrentRow.Index).Value
        CPrice.Text = GRID3.Item(3, GRID3.CurrentRow.Index).Value
        WPrice.Text = GRID3.Item(4, GRID3.CurrentRow.Index).Value
        SPrice.Text = GRID3.Item(5, GRID3.CurrentRow.Index).Value
        UOM.Text = GRID3.Item(6, GRID3.CurrentRow.Index).Value
        Qty.Text = GRID3.Item(7, GRID3.CurrentRow.Index).Value
        GRID3.Rows.Clear()
        Panel3.Hide()
        Panel1.Show()
        Panel1.Enabled = True
        ItemCode.Focus()
    End Sub

    Private Sub GRID3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRID3.KeyDown
        If e.KeyCode = 13 Then
            If GRID3.RowCount = 0 Then Return
            RFId.Text = GRID3.Item(0, GRID3.CurrentRow.Index).Value
            ItemCode.Text = GRID3.Item(1, GRID3.CurrentRow.Index).Value
            ItemName.Text = GRID3.Item(2, GRID3.CurrentRow.Index).Value
            CPrice.Text = GRID3.Item(3, GRID3.CurrentRow.Index).Value
            WPrice.Text = GRID3.Item(4, GRID3.CurrentRow.Index).Value
            SPrice.Text = GRID3.Item(5, GRID3.CurrentRow.Index).Value
            UOM.Text = GRID3.Item(6, GRID3.CurrentRow.Index).Value
            Qty.Text = GRID3.Item(7, GRID3.CurrentRow.Index).Value
            GRID3.Rows.Clear()
            Panel3.Hide()
            Panel1.Show()
            Panel1.Enabled = True
            ItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            Panel3.Hide()
            Panel1.Show()
            Panel1.Enabled = True
            ItemCode.Focus()
        End If
    End Sub

    Private Sub GRID2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.RowCount = 0 Then Return
            cmd = New SqlCommand("Select * from Stock_Main where(AutoID='" & GRID2.Item(0, GRID2.CurrentRow.Index).Value & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                ' AutoID, ItemCode, ItemName, UOM, CostPrice, SellPrice, RcvQty, SaleQty, DmgQty, RtnQty, BalanceQty, PisicalQty, LastUpdate, UName, WsPrice
                RFId.Text = rdr("AutoID").ToString
                ItemCode.Text = rdr("ItemCode").ToString
                ItemName.Text = rdr("ItemName").ToString
                UOM.Text = rdr("UOM").ToString
                CPrice.Text = rdr("CostPrice").ToString
                CPrice.Text = Format(Val(CPrice.Text), "0.00")
                SPrice.Text = rdr("SellPrice").ToString
                SPrice.Text = Format(Val(SPrice.Text), "0.00")
                WPrice.Text = rdr("WsPrice").ToString
                WPrice.Text = Format(Val(WPrice.Text), "0.00")
                Qty.Text = rdr("BalanceQty").ToString
                ItemName.Focus()
            End If
            rdr.Close()

        End If
    End Sub

    Private Sub GRID1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

    Private Sub GRID1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        RFId.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        ItemCode.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
        ItemName.Text = GRID1.Item(2, GRID1.CurrentRow.Index).Value
        CPrice.Text = GRID1.Item(4, GRID1.CurrentRow.Index).Value
        WPrice.Text = GRID1.Item(5, GRID1.CurrentRow.Index).Value
        SPrice.Text = GRID1.Item(6, GRID1.CurrentRow.Index).Value
        UOM.Text = GRID1.Item(3, GRID1.CurrentRow.Index).Value
        Qty.Text = GRID1.Item(7, GRID1.CurrentRow.Index).Value
        GRID1.Rows.RemoveAt(GRID1.CurrentRow.Index)
    End Sub

    Private Sub Qty_TextChanged(sender As Object, e As EventArgs) Handles Qty.TextChanged
        'If Val(Qty.Text) < 1 Then
        '    Qty.Clear()
        'End If
    End Sub
    Dim xBL As Double = 0
    Dim xBL1 As Double = 0
    Private Sub Qty_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty.KeyDown
        If e.KeyCode = 13 Then
            If ItemCode.Text = "" Then Return


            cmd = New SqlCommand("Select * from Stock_Main where(AutoId='" & RFId.Text & "') ", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                Dim result1 As DialogResult = MessageBox.Show("Do you want to Update the current Items Details ?", "Update the current Items Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If result1 = vbYes Then
                    Dim itemCode1 As String = rdr("ItemCode").ToString()
                    Dim itemName1 As String = rdr("ItemName").ToString()
                    Dim itemCprice1 As String = rdr("CostPrice").ToString()
                    Dim itemWPrice1 As String = rdr("WsPrice").ToString()
                    Dim itemSPrice1 As String = rdr("SellPrice").ToString()
                    Dim itemQty1 As String = rdr("BalanceQty").ToString()

                    Dim ff As String = itemCprice1 & " - " & itemWPrice1 & " - " & itemSPrice1 & " - " & itemQty1
                    Dim fa As String = CPrice.Text & " - " & WPrice.Text & " - " & SPrice.Text & " - " & Qty.Text
                    'Aid,                                      ItemCode,          ImtmName,    Description,NewDes, LastUpdate                    
                    cmd1 = New SqlCommand("Insert Edt values('" & itemCode1 & "','" & itemName1 & "','" & ff & "','" & fa & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
                    cmd1.ExecuteNonQuery()


                    xBL = rdr("BalanceQty")
                    cmd1 = New SqlCommand("Update Stock_Main Set ItemName='" & itemName.Text & "',UOM='" & UOM.Text & "', CostPrice='" & Val(CPrice.Text) & "',WsPrice='" & Val(WPrice.Text) & "',SellPrice='" & Val(SPrice.Text) & "',BalanceQty='" & Val(Qty.Text) & "' where ItemCode='" & itemCode.Text & "'", con1)
                    cmd1.ExecuteNonQuery()
                    cmd1 = New SqlCommand("Update ItemMaster set SellPrice='" & Val(SPrice.Text) & "'where ItemCode='" & itemCode.Text & "'", con1)
                    cmd1.ExecuteNonQuery()
                    MessageBox.Show("Item Details Update Succeed.", "Update the current Items Details", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If
            rdr.Close()


            '>>>>>>>>>>>>Old Update 2019-11-26
            cmd = New SqlCommand("Select * from Stock_Main where AutoID='" & RFId.Text & "'", con)
            rdr = cmd.ExecuteReader
            GRID1.Rows.Clear()
            While rdr.Read
                GRID1.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("UOM"), rdr("CostPrice"), rdr("WsPrice"), rdr("SellPrice"), rdr("BalanceQty"))
            End While
            rdr.Close()



            'cmd = New SqlCommand("Select * from Stock_Main Order by LastUpdate ", con)
            'rdr = cmd.ExecuteReader
            'GRID1.Rows.Clear()
            'While rdr.Read

            '    GRID1.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("UOM"), rdr("CostPrice"), rdr("WsPrice"), rdr("SellPrice"), rdr("BalanceQty"))
            'End While
            'rdr.Close()

            RFId.Clear()
            ItemCode.Clear()
            ItemName.Clear()
            UOM.Clear()
            CPrice.Clear()
            WPrice.Clear()
            SPrice.Clear()
            Qty.Clear()
            ItemCode.Focus()

        End If
    End Sub

    Private Sub ItemName_TextChanged(sender As Object, e As EventArgs) Handles ItemName.TextChanged

    End Sub

    Private Sub ItemName_GotFocus(sender As Object, e As EventArgs) Handles ItemName.GotFocus
        ItemName.BackColor = Color.Yellow

    End Sub

    Private Sub ItemName_LostFocus(sender As Object, e As EventArgs) Handles ItemName.LostFocus
        ItemName.BackColor = Color.White
    End Sub

    Private Sub ItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemName.KeyDown
        If e.KeyCode = 13 Then
            If ItemCode.Text = "" Then Return
            UOM.Focus()
        End If
    End Sub

    Private Sub UOM_TextChanged(sender As Object, e As EventArgs) Handles UOM.TextChanged

    End Sub

    Private Sub UOM_KeyDown(sender As Object, e As KeyEventArgs) Handles UOM.KeyDown
        If e.KeyCode = 13 Then
            CPrice.Focus()
        End If
    End Sub

    Private Sub CPrice_TextChanged(sender As Object, e As EventArgs) Handles CPrice.TextChanged

    End Sub

    Private Sub CPrice_GotFocus(sender As Object, e As EventArgs) Handles CPrice.GotFocus
        CPrice.BackColor = Color.Yellow
    End Sub

    Private Sub CPrice_LostFocus(sender As Object, e As EventArgs) Handles CPrice.LostFocus
        CPrice.BackColor = Color.White
    End Sub

    Private Sub CPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles CPrice.KeyDown
        If e.KeyCode = 13 Then
            WPrice.Focus()
        End If
    End Sub

    Private Sub WPrice_TextChanged(sender As Object, e As EventArgs) Handles WPrice.TextChanged

    End Sub

    Private Sub WPrice_GotFocus(sender As Object, e As EventArgs) Handles WPrice.GotFocus
        WPrice.BackColor = Color.Yellow
    End Sub

    Private Sub WPrice_LostFocus(sender As Object, e As EventArgs) Handles WPrice.LostFocus
        WPrice.BackColor = Color.White
    End Sub

    Private Sub WPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles WPrice.KeyDown
        If e.KeyCode = 13 Then
            SPrice.Focus()
        End If
    End Sub

    Private Sub SPrice_GotFocus(sender As Object, e As EventArgs) Handles SPrice.GotFocus
        SPrice.BackColor = Color.Yellow
    End Sub

    Private Sub SPrice_LostFocus(sender As Object, e As EventArgs) Handles SPrice.LostFocus
        SPrice.BackColor = Color.White
    End Sub

    Private Sub Qty_GotFocus(sender As Object, e As EventArgs) Handles Qty.GotFocus
        Qty.BackColor = Color.Yellow
    End Sub

    Private Sub Qty_LostFocus(sender As Object, e As EventArgs) Handles Qty.LostFocus
        Qty.BackColor = Color.White
    End Sub

    Private Sub ItemCode_GotFocus(sender As Object, e As EventArgs) Handles ItemCode.GotFocus
        ItemCode.BackColor = Color.Yellow
    End Sub

    Private Sub ItemCode_LostFocus(sender As Object, e As EventArgs) Handles ItemCode.LostFocus
        ItemCode.BackColor = Color.White
    End Sub

    Private Sub GRID1_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID1.KeyDown

    End Sub

    Private Sub txtItemName_GotFocus(sender As Object, e As EventArgs) Handles txtItemName.GotFocus
        txtItemName.BackColor = Color.Yellow
    End Sub

    Private Sub txtItemName_LostFocus(sender As Object, e As EventArgs) Handles txtItemName.LostFocus
        txtItemName.BackColor = Color.White
    End Sub

    Private Sub UOM_GotFocus(sender As Object, e As EventArgs) Handles UOM.GotFocus
        UOM.BackColor = Color.Yellow
    End Sub

    Private Sub UOM_LostFocus(sender As Object, e As EventArgs) Handles UOM.LostFocus
        UOM.BackColor = Color.White
    End Sub
End Class