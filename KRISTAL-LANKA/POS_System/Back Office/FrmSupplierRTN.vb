Imports System.Data.SqlClient
Imports ConnData
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO.Ports

Public Class FrmSupplierRTN

    Dim xUNITID As String = Nothing
    Dim xAAA As Integer = 0, zAAA As Integer = 0
    Private Sub FrmSupplierRTN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dd As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim ff As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = dd
        Me.Height = ff
        Me.WindowState = FormWindowState.Maximized
        Panel1.Show()
        Panel2.Hide()
        Panel4.Hide()
        UnitID.Text = Trim(FrmMDI.ToolStripStatusLabel2.Text)
        UNIL()
        'xUNITID = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\TestApp\1.0", "UnitID", Nothing)
        xITM()
        'MsgBox(Format(16, "000000"))
        'Dim value As Double

        'value = 123
        'Console.WriteLine(value.ToString("00000"))
        'Console.WriteLine(String.Format("{0:00000}", value))

        'AboutBox1.Close()
    End Sub
    Private Sub xITM()
        cmd = New SqlCommand("Select * from Stock_Main where BalanceQty > 0 ", con)
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()
    End Sub
    Private Sub UNIL()
        cmd = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xAAA = rdr("SRTN")
            RtnNo.Text = rdr("UnitID") & "SRTN" & (Format(xAAA, "00000000"))
        End If
        rdr.Close()
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

    Private Sub FrmSupplierRTN_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        'Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
    End Sub

    Private Sub SupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles SupCode.KeyDown

        If e.KeyCode = 13 Then
            xSSUP(SupCode.Text)
            SupCode.Focus()
        ElseIf e.KeyCode = 113 Then
            Panel2.Show()
            Panel1.Hide()
            txtSupID_TextChanged(sender, EventArgs.Empty)
            txtSupID.Focus()
        ElseIf e.KeyCode = 27 Then
            SupCode.Clear()
            SupName.Clear()
            SupCode.Focus()
        End If

    End Sub
    Private Sub xSSUP(ByVal xSP As String)

        cmd = New SqlCommand("Select * from Supplier where(SupCode='" & xSP & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            SupCode.Text = rdr("SupCode").ToString
            SupName.Text = rdr("SupName").ToString
        End If
        rdr.Close()
    End Sub

    Private Sub txtSupID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupID.KeyDown
        If e.KeyCode = 27 Then
            txtSupName.Clear()
            txtSupID.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtSupName.Focus()
        End If
    End Sub

    Private Sub txtSupID_TextChanged(sender As Object, e As EventArgs) Handles txtSupID.TextChanged
        If txtSupID.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupCode like '" & txtSupID.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Private Sub txtSupName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupName.KeyDown
        If e.KeyCode = 27 Then
            txtSupName.Clear()
            txtSupID.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtSupID.Focus()
        End If
    End Sub

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupName like '%" & txtSupName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        xSSUP(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel1.Show()
        SupCode.Focus()
    End Sub

    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.Rows.Count = 0 Then Return
            xSSUP(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel1.Show()
            SupCode.Focus()
        End If
    End Sub

    Private Sub ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemCode.KeyDown
        If e.KeyCode = 13 Then
            xIITEM(ItemCode.Text)
            ItemCode.Focus()
        ElseIf e.KeyCode = 113 Then
            'Panel2.Show()
            'Panel1.Hide()
            'txtItemCode_TextChanged(sender, EventArgs.Empty)
            'txtItemCode.Focus()

        ElseIf e.KeyCode = 27 Then
            ItemCode.Clear()
            ItemName.Clear()
            Price.Clear()
            Description.Clear()
            Qty.Clear()
            LineTot.Clear()
            UOM.Clear()
            ItemCode.Focus()

        End If
    End Sub
    Dim XCNT As Integer = 0
    Private Sub xIITEM(ByVal xITM As String)

        cmd = New SqlCommand("Select * from Stock_Main where ItemCode='" & xITM & "'", con)
        rdr = cmd.ExecuteReader
        GRID4.Rows.Clear()
        While rdr.Read
            GRID4.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), Format(rdr("CostPrice"), "0.00"), Format(rdr("SellPrice"), "0.00"), rdr("UOM"), rdr("BalanceQty"))
            XCNT += 1
            If XCNT > 1 Then
                Panel4.Show()
                Panel1.Enabled = False
                GRID4.Focus()
                RFId.Clear()
                ItemCode.Clear()
                ItemName.Clear()
                Price.Clear()
                UOM.Clear()


            Else
                If rdr("PisicalQty") = 0 Then
                    MessageBox.Show("Item in Stock = 0.", "Item Stock Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                Else
                    RFId.Text = rdr("AutoID").ToString
                    ItemCode.Text = rdr("ItemCode").ToString
                    ItemName.Text = rdr("ItemName").ToString
                    Qty1.Text = rdr("BalanceQty").ToString
                    Price.Text = Format(rdr("CostPrice"), "0.00").ToString
                    UOM.Text = rdr("UOM").ToString
                End If
            End If
        End While
        rdr.Close()
        XCNT = 0
    End Sub

    Private Sub txtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = 27 Then
            txtItemCode.Clear()
            txtItemName.Clear()
            GRID3.Rows.Clear()
            Panel2.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID3.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtItemName.Focus()
        End If
    End Sub

    Private Sub txtItemCode_TextChanged(sender As Object, e As EventArgs) Handles txtItemCode.TextChanged
        If txtItemCode.Text = "" Then
            cmd = New SqlCommand("Select * from Stock_Main where BalanceQty > 0 ", con)
        Else
            cmd = New SqlCommand("Select * from Stock_Main where BalanceQty > 0 and ItemCode like '" & txtItemCode.Text & "%'  ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()
    End Sub
    Private Sub xITLOD(ByVal xITCDE As String)
        cmd = New SqlCommand("Select * from Stock_Main where(AutoID='" & xITCDE & "'and BalanceQty >0 )", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            RFId.Text = rdr("autoID")
            ItemCode.Text = rdr("ItemCode")
            ItemName.Text = rdr("ItemName")
            Price.Text = rdr("CostPrice")
            Price.Text = Format(Val(Price.Text), "0.00")
            Qty1.Text = rdr("BalanceQty")
            UOM.Text = rdr("UOM")
            Description.Focus()
        End If
        rdr.Close()
    End Sub



    Private Sub GRID3_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID3.CellContentDoubleClick
        xITLOD(GRID3.Item(0, GRID3.CurrentRow.Index).Value)

    End Sub

    Private Sub GRID3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID3.CellContentClick

    End Sub

    Private Sub GRID3_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID3.KeyDown
        If e.KeyCode = 13 Then
            If GRID3.RowCount = 0 Then Return
            xITLOD(GRID3.Item(0, GRID3.CurrentRow.Index).Value)
        ElseIf e.KeyCode = 27 Then
            txtItemCode.Focus()
        End If
    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown
        If e.KeyCode = 27 Then
            txtItemName.Clear()
            txtItemCode.Clear()
            GRID3.Rows.Clear()
            Panel2.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID3.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtItemCode.Focus()
        End If
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged
        If txtItemName.Text = "" Then
            cmd = New SqlCommand("Select * from Stock_Main whare BalanceQty > 0 ", con)
        Else
            cmd = New SqlCommand("Select * from Stock_Main where BalanceQty > 0 and ItemName like '%" & txtItemName.Text & "%'  ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()
    End Sub

    Private Sub Qty_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty.KeyDown
        If e.KeyCode = 13 Then

            If SupCode.Text = "" Or ItemCode.Text = "" Then Return
            If Val(Qty1.Text) < Val(Qty.Text) Then
                MsgBox("Qty Error")
                Return
            End If

            Dim xAMT As Double
            Dim RowTrue As Boolean = False, RowID As Integer = 0
            For Each row As DataGridViewRow In GRID1.Rows
                If (row.Cells(1).Value = ItemCode.Text And row.Cells(4).Value = Price.Text) Then
                    RowTrue = True : RowID = row.Index : xAMT = row.Cells(6).Value : Exit For
                End If
            Next
            If RowTrue = True Then
                GRID1.Rows(RowID).Cells(5).Value = Qty.Text
                GRID1.Rows(RowID).Cells(6).Value = LineTot.Text
            Else
                GRID1.Rows.Add(RFId.Text, ItemCode.Text, ItemName.Text, Description.Text, Price.Text, Qty.Text, LineTot.Text, UOM.Text)
            End If

            Dim xTOT As Double
            For Each row As DataGridViewRow In GRID1.Rows
                xTOT += row.Cells(6).Value
            Next
            Total.Text = xTOT
            Total.Text = Format(Val(Total.Text), "0.00")

            RFId.Clear()
            ItemCode.Clear()
            ItemName.Clear()
            Description.Clear()
            Price.Clear()
            UOM.Clear()
            Qty.Clear()
            LineTot.Clear()
            ItemCode.Focus()

        End If
    End Sub

    Private Sub Qty_TextChanged(sender As Object, e As EventArgs) Handles Qty.TextChanged
        If IsNumeric(Qty.Text) = False Then Qty.Clear()
        LineTot.Text = Val(Price.Text) * Val(Qty.Text)
        LineTot.Text = Format(Val(LineTot.Text), "0.00")
    End Sub

    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick

        RFId.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        ItemCode.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
        ItemName.Text = GRID1.Item(2, GRID1.CurrentRow.Index).Value
        Description.Text = GRID1.Item(3, GRID1.CurrentRow.Index).Value
        Price.Text = GRID1.Item(4, GRID1.CurrentRow.Index).Value
        Qty.Text = GRID1.Item(5, GRID1.CurrentRow.Index).Value
        LineTot.Text = GRID1.Item(6, GRID1.CurrentRow.Index).Value
        UOM.Text = GRID1.Item(7, GRID1.CurrentRow.Index).Value
        GRID1.Rows.RemoveAt(GRID1.CurrentRow.Index)

        Dim xTOTAL As Double
        For Each row As DataGridViewRow In GRID1.Rows
            xTOTAL += row.Cells(6).Value
        Next
        Total.Text = xTOTAL
        Total.Text = Format(Val(Total.Text), "0.00")

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        xBLQTTY = 0
        xPSCQTTY = 0
        GRID1.Rows.Clear()
        RFId.Clear()
        ItemCode.Clear()
        ItemName.Clear()
        Description.Clear()
        Price.Clear()
        UOM.Clear()
        Qty.Clear()
        Qty1.Clear()
        LineTot.Clear()
        SupCode.Clear()
        SupName.Clear()
        Total.Clear()
        ItemCode.Focus()
        UNIL()
    End Sub
    Dim xBLQTTY As Double = 0
    Dim xPSCQTTY As Double = 0
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If UnitID.Text = "" Or RtnNo.Text = "" Or SupCode.Text = "" Or GRID1.Rows.Count = 0 Then Return

        Dim result1 As DialogResult = MessageBox.Show("Do you want to Return these Items to Supplier ?", "Supplier Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            '                                                    RtnNo,                 UnitID,             SupCode,                SupName,                Amount,                 LastUpdate,                                     UName      
            cmd = New SqlCommand("Insert SUPRTN_Main values('" & RtnNo.Text & "','" & UnitID.Text & "','" & SupCode.Text & "','" & SupName.Text & "','" & Total.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
            cmd.ExecuteNonQuery()

            For i As Integer = 0 To GRID1.RowCount - 1
                '                                         AutoID,    RtnNo,             SupCode,                    ItemCode,               ItemName,                   Description,                        UOM,                CostPrice,                       Qty,                       Amount,                     LastUpdate,                                     UName
                cmd = New SqlCommand("Insert SUPRTN_Sub values('" & RtnNo.Text & "','" & SupCode.Text & "','" & GRID1(1, i).Value & "','" & GRID1(2, i).Value & "','" & GRID1(3, i).Value & "','" & GRID1(7, i).Value & "','" & GRID1(4, i).Value & "','" & GRID1(5, i).Value & "','" & GRID1(6, i).Value & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                cmd.ExecuteNonQuery()


                cmd = New SqlCommand("Select * from Stock_Main where AutoID='" & GRID1(0, i).Value & "'", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    xBLQTTY = rdr("BalanceQty").ToString
                    xPSCQTTY = rdr("PisicalQty").ToString
                End If
                rdr.Close()
                cmd = New SqlCommand("Update Stock_Main Set RtnQty='" & GRID1(5, i).Value & "',BalanceQty='" & xBLQTTY - Val(GRID1(5, i).Value) & "',PisicalQty= '" & xPSCQTTY - Val(GRID1(5, i).Value) & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "'where AutoID='" & GRID1(0, i).Value & "'", con)
                cmd.ExecuteNonQuery()
            Next

            '                                                       SupCode,          SupName,                    GrnDate,                        Descp,    GrnAmnt,        PayDate,                        Descr,                               PayAmnt
            cmd = New SqlCommand("Insert SupState values('" & SupCode.Text & "','" & SupName.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Goods Returns Deduction" & "','" & Val(Total.Text) & "')", con1)
            cmd.ExecuteNonQuery()


            cmd = New SqlCommand("Select * from Supplier where(SupCode='" & SupCode.Text & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                Dim xBLNC As Double = rdr("SupBalance").ToString
                cmd1 = New SqlCommand("Update Supplier set SupBalance='" & xBLNC - Val(Total.Text) & "'where SupCode='" & SupCode.Text & "'", con1)
                cmd1.ExecuteNonQuery()
            End If
            rdr.Close()



            '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
            cmd = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                zAAA = rdr("SRTN")
            End If
            rdr.Close()
            cmd = New SqlCommand("Update Workstation set SRTN='" & zAAA + 1 & "'  where(UnitID='" & UnitID.Text & "')", con)
            cmd.ExecuteNonQuery()
            '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
            '*********************
            MessageBox.Show("Supplier Return Succeed.", "Supplier Return", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If



        'SupCode, SupName, GrnAmt, SupPay, SupRtn, BalanceAmt, LastUpdate, UName SupAcc_Main
        'cmd = New SqlCommand("Select * from SupAcc_Main where SupCode='" & SupCode.Text & "'", con)
        'rdr = cmd.ExecuteReader
        'If rdr.Read = True Then

        '    cmd1 = New SqlCommand("Update SupAcc_Main set SupRtn='" & rdr("SupRtn") + Total.Text & "',BalanceAmt='" & rdr("BalanceAmt") - Total.Text & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "' where SupCode='" & SupCode.Text & "'", con1)
        '    cmd1.ExecuteNonQuery()

        'Else
        '    '                                                     SupCode,                 SupName,           GrnAmt,     SupPay,       SupRtn,                       BalanceAmt,                                LastUpdate,                      UName
        '    cmd1 = New SqlCommand("Insert SupAcc_Main values('" & SupCode.Text & "','" & SupName.Text & "','" & 0 & "','" & 0 & "','" & Total.Text & "','" & rdr("BalanceAmt") + Total.Text & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con1)
        '    cmd1.ExecuteNonQuery()
        'End If
        'rdr.Close()
        '*********************






        CmdCancel_Click(sender, EventArgs.Empty)

    End Sub

    Private Sub GRID4_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID4.CellContentDoubleClick


        If GRID4.Item(6, GRID4.CurrentRow.Index).Value = 0 Then
            MessageBox.Show("Item in Stock = 0.", "Item Stock Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            RFId.Text = GRID3.Item(0, GRID3.CurrentRow.Index).Value
            ItemCode.Text = GRID3.Item(1, GRID3.CurrentRow.Index).Value
            ItemName.Text = GRID3.Item(2, GRID3.CurrentRow.Index).Value
            Price.Text = GRID3.Item(3, GRID3.CurrentRow.Index).Value
            Panel1.Show()
            Panel2.Hide()
            Panel4.Hide()
            ItemCode.Focus()
        End If



    End Sub

    Private Sub GRID4_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID4.KeyDown
        If e.KeyCode = 13 Then
            If GRID4.RowCount = 0 Then Return
            If GRID4.Item(6, GRID4.CurrentRow.Index).Value = 0 Then
                MessageBox.Show("Item in Stock = 0.", "Item Stock Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                RFId.Text = GRID3.Item(0, GRID3.CurrentRow.Index).Value
                ItemCode.Text = GRID3.Item(1, GRID3.CurrentRow.Index).Value
                ItemName.Text = GRID3.Item(2, GRID3.CurrentRow.Index).Value
                Price.Text = GRID3.Item(3, GRID3.CurrentRow.Index).Value
                Panel1.Show()
                Panel2.Hide()
                Panel4.Hide()
                ItemCode.Focus()
            End If
        ElseIf e.KeyCode = 27 Then
            Panel4.Hide()
            Panel1.Show()
            Panel1.Enabled = True
        End If
    End Sub

    Private Sub GRID4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID4.CellContentClick

    End Sub

    Private Sub GRID3_Invalidated(sender As Object, e As InvalidateEventArgs) Handles GRID3.Invalidated

    End Sub

    Private Sub ItemCode_TextChanged(sender As Object, e As EventArgs) Handles ItemCode.TextChanged

    End Sub
End Class