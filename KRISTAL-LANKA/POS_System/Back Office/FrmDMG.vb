Imports System.Data.SqlClient
Imports conndata
Public Class FrmDMG
    Dim xUNITID As String = Nothing
    Dim xAAA As Integer = 0, zAAA As Integer = 0
    Private Sub FrmDMG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dd As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim ff As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = dd
        Me.Height = ff
        Me.WindowState = FormWindowState.Maximized
        Panel1.Show()

        Panel3.Hide()
        UnitID.Text = Trim(FrmMDI.ToolStripStatusLabel2.Text)
        cmd = New SqlCommand("Select * from ItemMaster order by ItemCode", con)
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()
        UNIL()

        'AboutBox1.Close()
    End Sub
    Private Sub UNIL()
        cmd = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xAAA = rdr("DMG")
            DMGNo.Text = rdr("UnitID") & "DMG" & (Format(xAAA, "00000000"))
        End If
        rdr.Close()

    End Sub

    Private Sub FrmDMG_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        'Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        ''Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
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

    Private Sub txtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = Keys.Right Then
            txtItemName.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = 27 Then
            txtItemName.Clear()
            txtItemCode.Clear()
            txtItemCode.Focus()
        End If
    End Sub

    Private Sub txtItemCode_TextChanged(sender As Object, e As EventArgs) Handles txtItemCode.TextChanged
        If txtItemCode.Text = "" Then
            cmd = New SqlCommand("Select * from ItemMaster ", con)
        Else
            cmd = New SqlCommand("Select * from ItemMaster where  ItemName like '" & txtItemCode.Text & "%' ", con)

        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()
    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown
        If e.KeyCode = Keys.Left Then
            txtItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = 27 Then
            txtItemName.Clear()
            txtItemCode.Focus()
        End If
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged
        If txtItemName.Text = "" Then
            cmd = New SqlCommand("Select * from ItemMaster  ", con)
        Else
            cmd = New SqlCommand("Select * from ItemMaster where  ItemName like '%" & txtItemName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()
    End Sub
    Private Sub ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemCode.KeyDown
        If e.KeyCode = 13 Then
            xITM(ItemCode.Text)
        ElseIf e.KeyCode = 27 Then
            RFId.Clear()
            ItemCode.Clear()
            ItemName.Clear()
            Description.Clear()
            CPrice.Clear()
            SPrice.Clear()
            Qty.Clear()
            LineTot.Clear()
            UOM.Clear()
            ItemCode.Focus()
        End If
    End Sub
    Dim xCOUNT As Integer = 0
    Private Sub xITM(ByVal xITC As String)
        cmd = New SqlCommand("Select * from ItemMaster where ItemCode='" & xITC & "'", con)
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Select * from Stock_Main where(ItemCode='" & rdr("ItemCode") & "'and BalanceQty > 0 )", con1)
            rdr1 = cmd1.ExecuteReader
            While rdr1.Read
                GRID3.Rows.Add(rdr1("AutoID"), rdr1("ItemCode"), rdr1("ItemName"), Format(rdr1("CostPrice"), "0.00"), Format(rdr1("SellPrice"), "0.00"), rdr1("UOM"), rdr1("BalanceQty"))
                xCOUNT += 1
                If xCOUNT > 1 Then
                    RFId.Clear()
                    'ItemCode.Clear()
                    ItemName.Clear()
                    Description.Clear()
                    CPrice.Clear()
                    SPrice.Clear()
                    Qty.Clear()
                    LineTot.Clear()
                    ItemCode.Focus()
                    Panel3.Show()
                    Panel1.Enabled = False
                    GRID3.Focus()
                Else
                    RFId.Text = rdr1("AutoID").ToString
                    ItemCode.Text = rdr1("ItemCode").ToString
                    ItemName.Text = rdr1("ItemName").ToString
                    CPrice.Text = rdr1("CostPrice").ToString
                    SPrice.Text = rdr1("SellPrice").ToString

                    CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                    SPrice.Text = Format(Val(SPrice.Text), "0.00").ToString



                    UOM.Text = rdr1("UOM").ToString
                End If
            End While
            rdr1.Close()
        End If
        rdr.Close()
        xCOUNT = 0
    End Sub
    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        xITM(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
    End Sub

    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.Rows.Count = 0 Then Return
            xITM(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        End If
    End Sub
    Dim xQTY As Double = 0
    Private Sub Qty_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty.KeyDown
        If e.KeyCode = 13 Then
            If ItemCode.Text = "" Or Qty.Text = "" Then Return
            cmd = New SqlCommand("Select * from Stock_Main where AutoID='" & RFId.Text & "'", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                xQTY = rdr("BalanceQty").ToString
            End If
            rdr.Close()
            If xQTY < Qty.Text Then Return
            Dim xAMT As Double
            Dim RowTrue As Boolean = False, RowID As Integer = 0
            For Each row As DataGridViewRow In GRID1.Rows
                If (row.Cells(1).Value = ItemCode.Text And row.Cells(4).Value = CPrice.Text) Then
                    RowTrue = True : RowID = row.Index : xAMT = row.Cells(7).Value : Exit For
                End If
            Next
            If RowTrue = True Then
                GRID1.Rows(RowID).Cells(6).Value = Qty.Text
                GRID1.Rows(RowID).Cells(7).Value = LineTot.Text
            Else
                GRID1.Rows.Add(RFId.Text, ItemCode.Text, ItemName.Text, Description.Text, CPrice.Text, SPrice.Text, Qty.Text, LineTot.Text, UOM.Text)
            End If
            Dim xTOT As Double
            For Each row As DataGridViewRow In GRID1.Rows
                xTOT += row.Cells(7).Value
            Next
            Total.Text = xTOT
            Total.Text = Format(Val(Total.Text), "0.00")
            RFId.Clear()
            ItemCode.Clear()
            ItemName.Clear()
            Description.Clear()
            CPrice.Clear()
            SPrice.Clear()
            Qty.Clear()
            LineTot.Clear()
            UOM.Clear()
            ItemCode.Focus()
        End If
    End Sub
    Private Sub Qty_TextChanged(sender As Object, e As EventArgs) Handles Qty.TextChanged
        If IsNumeric(Qty.Text) = False Then Qty.Clear()
        LineTot.Text = Val(CPrice.Text) * Val(Qty.Text)
        LineTot.Text = Format(Val(LineTot.Text), "0.00")
    End Sub
    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        RFId.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        ItemCode.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
        ItemName.Text = GRID1.Item(2, GRID1.CurrentRow.Index).Value
        Description.Text = GRID1.Item(3, GRID1.CurrentRow.Index).Value
        CPrice.Text = GRID1.Item(4, GRID1.CurrentRow.Index).Value
        SPrice.Text = GRID1.Item(5, GRID1.CurrentRow.Index).Value
        Qty.Text = GRID1.Item(6, GRID1.CurrentRow.Index).Value
        LineTot.Text = GRID1.Item(7, GRID1.CurrentRow.Index).Value
        UOM.Text = GRID1.Item(8, GRID1.CurrentRow.Index).Value
        GRID1.Rows.RemoveAt(GRID1.CurrentRow.Index)
        Qty.Focus()
        Dim xTOT As Double
        For Each row As DataGridViewRow In GRID1.Rows
            xTOT += row.Cells(7).Value
        Next
        Total.Text = xTOT
        Total.Text = Format(Val(Total.Text), "0.00")
    End Sub
    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        ItemCode.Clear()
        ItemName.Clear()
        Description.Clear()
        CPrice.Clear()
        Qty.Clear()
        LineTot.Clear()
        GRID1.Rows.Clear()
        Total.Clear()
        UOM.Clear()
        ItemCode.Focus()
        UNIL()
    End Sub
    Dim xBQty As Double = 0
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If GRID1.Rows.Count = 0 Then Return

        Dim result1 As DialogResult = MessageBox.Show("Do you want to Dispose these Damaged Items ?", "Dipose Damaged Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            '                                                   DMGNo,                  UnitID,                 LastUpdate,                                 UName
            cmd = New SqlCommand("Insert DMG_Main values('" & DMGNo.Text & "','" & UnitID.Text & "','" & Format(Now, "yyyy/MM/dd H:mm:ss ") & "','" & FrmMDI.UName.Text & "')", con)
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To GRID1.RowCount - 1
                xBQty = 0
                '  AutoID,                                       DMGNo,              UnitID,                RefID,                       ItemCode,                   ItemName,                    Description,                   UOM,                        CostPrice,                  Qty,                              Amount,                    LastUpdate,                                 UName
                cmd = New SqlCommand("Insert DMG_Sub values('" & DMGNo.Text & "','" & UnitID.Text & "','" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(2, i).Value & "','" & GRID1(3, i).Value & "','" & GRID1(8, i).Value & "','" & Val(GRID1(4, i).Value) & "','" & Val(GRID1(6, i).Value) & "','" & Val(GRID1(7, i).Value) & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "')", con)
                cmd.ExecuteNonQuery()

                cmd = New SqlCommand("Select * from Stock_Main where AutoID='" & GRID1(0, i).Value & "'", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    xBQty = rdr("BalanceQty").ToString
                End If
                rdr.Close()
                cmd = New SqlCommand("Update Stock_Main Set DmgQty='" & Val(GRID1(6, i).Value) & "',BalanceQty='" & xBQty - Val(GRID1(6, i).Value) & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "'where AutoID='" & GRID1(0, i).Value & "'", con)
                cmd.ExecuteNonQuery()
            Next
            '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
            cmd = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                zAAA = rdr("DMG")
            End If
            rdr.Close()
            cmd = New SqlCommand("Update Workstation set DMG='" & zAAA + 1 & "'  where(UnitID='" & UnitID.Text & "')", con)
            cmd.ExecuteNonQuery()
            '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
            MessageBox.Show("Record Save Succeed.", "Dispose Damaged Items", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If




        CmdCancel_Click(sender, EventArgs.Empty)
    End Sub
    Private Sub GRID3_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID3.CellContentDoubleClick
        RFId.Text = GRID3.Item(0, GRID3.CurrentRow.Index).Value
        ItemCode.Text = GRID3.Item(1, GRID3.CurrentRow.Index).Value
        ItemName.Text = GRID3.Item(2, GRID3.CurrentRow.Index).Value
        CPrice.Text = GRID3.Item(3, GRID3.CurrentRow.Index).Value
        SPrice.Text = GRID3.Item(4, GRID3.CurrentRow.Index).Value
        UOM.Text = GRID3.Item(5, GRID3.CurrentRow.Index).Value
        GRID3.Rows.Clear()
        Panel3.Hide()
        Panel1.Show()
        Panel1.Enabled = True
        ItemCode.Focus()
    End Sub
    Private Sub GRID3_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID3.KeyDown
        If e.KeyCode = 27 Then
            GRID3.Rows.Clear()
            Panel3.Hide()
            Panel1.Show()
            Panel1.Enabled = True
            ItemCode.Focus()
        ElseIf e.KeyCode = 13 Then
            RFId.Text = GRID3.Item(0, GRID3.CurrentRow.Index).Value
            ItemCode.Text = GRID3.Item(1, GRID3.CurrentRow.Index).Value
            ItemName.Text = GRID3.Item(2, GRID3.CurrentRow.Index).Value
            CPrice.Text = GRID3.Item(3, GRID3.CurrentRow.Index).Value
            SPrice.Text = GRID3.Item(4, GRID3.CurrentRow.Index).Value
            UOM.Text = GRID3.Item(5, GRID3.CurrentRow.Index).Value
            GRID3.Rows.Clear()
            Panel3.Hide()
            Panel1.Show()
            Panel1.Enabled = True
            ItemCode.Focus()
        End If
    End Sub

    Private Sub GRID2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID2.CellContentClick

    End Sub

    Private Sub ItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCode.TextChanged

    End Sub

    Private Sub GRID3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID3.CellContentClick

    End Sub
End Class