Imports System.Data.SqlClient
Imports ConnData
Imports System.Windows.Forms.PrintDialog
Imports System.Windows.Forms.PrintPreviewDialog
Imports System.Drawing.Printing.PrintDocument
Imports POS_System.NewFunc
Imports Newtonsoft.Json
Public Class FrmGRN
    Dim xUNITID As String = Nothing
    Dim xAAA As Integer = 0, zAAA As Integer = 0
    Private Sub FrmGRN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
        Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = xW
        Me.Height = xH

        Me.WindowState = FormWindowState.Maximized
        Panel2.Hide()
        Panel3.Hide()
        UnitID.Text = Trim(FrmMDI.ToolStripStatusLabel2.Text)
        GRNNo.Text = GetGrnNumber(UnitID.Text)
        xYES = False
        CHQ1.Checked = True
        CHQ1.Checked = False
        btnModi.Enabled = False
        ListItem.Hide()
        DTP1.Value = Format(Now, "yyyy-MM-dd")
        dtp2.Value = Format(Now, "yyyy-MM-dd")
        dtp3.Value = Format(Now, "yyyy-MM-dd")
        lstSup.Hide()
    End Sub
    Private Function GetGrnNumber(ByVal unitId As String)
        Dim gnNo As String = "NA"
        Dim cnt As Integer = 0
        cmd = New SqlCommand("Select Count(PNo) from Purch", con)
        cnt = cmd.ExecuteScalar
        If cnt = 0 Then
            gnNo = unitId & "P" & "1"
        Else
            gnNo = unitId & "P" & (cnt + 1).ToString
        End If
        Return gnNo
    End Function

    Private Sub FrmGRN_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        'Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
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

    Private Sub SupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles SupCode.KeyDown

    End Sub
    Private Sub txtSupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupCode.KeyDown
        If e.KeyCode = 27 Then
            txtSupCode.Clear()
            txtSupName.Clear()
            GRID3.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID3.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtSupName.Focus()
        End If
    End Sub

    Private Sub txtSupCode_TextChanged(sender As Object, e As EventArgs) Handles txtSupCode.TextChanged
        If txtSupCode.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier where Sts =0", con)
        Else
            'cmd = New SqlCommand("Select * from ItemMaster where ItemCode like '" & txtItemCode.Text & "%' ", con)
            cmd = New SqlCommand("Select * from Supplier where SupCode like '" & txtSupCode.Text & "%'and Sts=0", con)
        End If
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub


    Private Sub xSUPP(ByVal xSPCD As String)
        cmd = New SqlCommand("Select * from Supplier where(SupCode='" & xSPCD & "'and Sts=0)", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            SupCode.Text = rdr("SupCode").ToString
            SupName.Text = rdr("SupName").ToString
        End If
        rdr.Close()
    End Sub

    Private Sub txtSupName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupName.KeyDown
        If e.KeyCode = 27 Then
            txtSupCode.Clear()
            txtSupName.Clear()
            GRID3.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID3.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtSupCode.Focus()
        End If
    End Sub

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier where Active ='" & 1 & "'", con)
        Else
            'cmd = New SqlCommand("Select * from ItemMaster where ItemCode like '" & txtItemCode.Text & "%' ", con)
            cmd = New SqlCommand("Select * from Supplier where SupName like '%" & txtSupName.Text & "%'and Active='" & 1 & "'", con)
        End If
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub
    Private Sub xITM(ByVal xITC As String)
        cmd = New SqlCommand("Select ItemCode,ItemName from Itm where(ItemCode='" & xITC & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            ItemCode.Text = rdr("ItemCode").ToString
            ItemName.Text = rdr("ItemName").ToString
            Price.Focus()
        End If
        rdr.Close()

    End Sub

    Private Sub ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemCode.KeyDown
        If e.KeyCode = 13 Then
            xITM(ItemCode.Text)
            ListItem.Hide()
            ' ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If ItemCode.Text = "" Then
            Else
                ListItem.Focus()
                ListItem.Show()
                ListItem.SelectedIndex = 0
                ListItem.SelectedItem = 0
            End If

        ElseIf e.KeyCode = 27 Then
            ItemCode.Clear()
            ItemName.Clear()
            Price.Clear()
            'WsPrice.Clear()
            SPrice.Clear()
            'UOM.Clear()
            Qty.Clear()
            'FreeIs.Clear()
            Tot.Clear()

            ListItem.Hide()
            ItemCode.Focus()
        End If
    End Sub

    Private Sub GRID3_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID3.CellContentDoubleClick
        xSUPP(GRID3.Item(0, GRID3.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel3.Hide()
        Panel1.Show()
        SupCode.Focus()
    End Sub

    Private Sub GRID3_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID3.KeyDown
        If e.KeyCode = 13 Then
            If GRID3.Rows.Count = 0 Then Return
            xSUPP(GRID3.Item(0, GRID3.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            SupCode.Focus()
        End If
    End Sub
    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        LoadPurchItems(GRID2.Item(3, GRID2.CurrentRow.Index).Value)
        SupName.Text = GRID2.Item(1, GRID2.CurrentRow.Index).Value.ToString
        SupCode.Text = GRID2.Item(6, GRID2.CurrentRow.Index).Value.ToString
        lstSup.Items.Clear()
        lstSup.Hide()
        InvNo.Text = GRID2.Item(2, GRID2.CurrentRow.Index).Value.ToString
        txtDisc.Text = GRID2.Item(5, GRID2.CurrentRow.Index).Value.ToString
        ' Total.Text = Val(GRID2.Item(4, GRID2.CurrentRow.Index).Value) + Val(txtDisc.Text)
        GRNNo.Text = GRID2.Item(3, GRID2.CurrentRow.Index).Value.ToString
        DTP1.Value = GRID2.Item(0, GRID2.CurrentRow.Index).Value
        CmdSave.Enabled = False
        btnModi.Enabled = True
        Panel2.Hide()
        Panel1.Show()
        ItemCode.Focus()
    End Sub
    Private Sub LoadPurchItems(ByVal grnNo As String)
        GRID1.Rows.Clear()
        Dim pItems As New List(Of Sitems)
        cmd = New SqlCommand("Select * from Purch where PNo='" & grnNo & "'and Sts=0", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            Dim items As String = rdr("Itms").ToString
            pItems = JsonConvert.DeserializeObject(Of List(Of Sitems))(items)
        End If
        rdr.Close()
        If pItems.Count > 0 Then
            Dim totl As Double = 0
            For Each row As Sitems In pItems
                Dim qtyy As Double = 0
                cmd = New SqlCommand("Select ISNULL(SUM(Qty),0) from Itr where ItemCode='" & row.itemCode & "'and Sts=0", con)
                qtyy = cmd.ExecuteScalar
                GRID1.Rows.Add(row.itemCode, row.itemName, row.cost, row.selling, row.qty, row.vals, qtyy, "Print")
                totl += Val(row.vals)
            Next
            Total.Text = totl
        End If
    End Sub

    Private Sub Qty_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty.KeyDown
        If e.KeyCode = 13 Then
            If ItemCode.Text = "" Or Val(Price.Text) < 0 Or Val(Qty.Text) = 0 Then Return
            Dim qtyy As Double = 0
            cmd = New SqlCommand("Select ISNULL(SUM(Qty),0) from Itr where ItemCode='" & ItemCode.Text & "'and Sts=0", con)
            qtyy = cmd.ExecuteScalar
            GRID1.Rows.Add(ItemCode.Text, ItemName.Text, Price.Text, SPrice.Text, Qty.Text, Tot.Text, qtyy.ToString, "Print")
            Dim totals As Double = 0
            For Each row As DataGridViewRow In GRID1.Rows
                Dim lineT As Double = Val(row.Cells(5).Value)
                totals += lineT
            Next
            Total.Text = Format(totals, "0.00")
            Dim partNo As String = "NA"
            Try
                partNo = ItemName.Text.Split("*")(1)
            Catch ex As Exception
            End Try
            Dim cmf As New CommonFunc
            Dim nn As Integer = 0
            cmd = New SqlCommand("Select Count(ItemCode) from Itm where ItemCode='" & ItemCode.Text & "'and Sts=0", con)
            nn = cmd.ExecuteScalar
            If nn = 0 Then
                If ItemName.Text.Contains("*") Then
                    ItemName.Text = ItemName.Text.Split("*")(0).Trim
                End If
                cmf.SaveItem(ItemCode.Text, ItemName.Text, partNo, Qty.Text, 0)
            End If


            ItemCode.Clear()
            ItemName.Clear()
            Price.Clear()
            SPrice.Clear()
            Qty.Clear()
            Tot.Clear()
            ItemCode.Focus()
            ' FreeIs.Focus()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub
    Private Sub PrintCode(ByVal iCode As String, ByVal Sell As Double, ByVal inm As String, ByVal spd As String)
        If iCode = "" Then Return
        If rbt2.Checked = True Then
            CrystalReportViewer1.Show()
            Dim report6 As New RptCode
            report6.SetParameterValue("cde", iCode) 'd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
            report6.SetParameterValue("prc", Format(Sell, "0.00"))
            report6.SetParameterValue("inm", spd & "-" & inm)
            CrystalReportViewer1.ReportSource = report6
            CrystalReportViewer1.Refresh()
            report6.Close()
            report6.Dispose()
        ElseIf rbt1.Checked = True Then
            CrystalReportViewer1.Show()
            Dim report6 As New RptCode1
            report6.SetParameterValue("icd", iCode) 'd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
            '  report6.SetParameterValue("prc", Format(Val(SellPrice.Text), "0.00"))
            report6.SetParameterValue("prc", Format(Sell, "0.00"))
            report6.SetParameterValue("inm", spd & "-" & inm)
            CrystalReportViewer1.ReportSource = report6
            CrystalReportViewer1.Refresh()
            report6.Close()
            report6.Dispose()
        End If


    End Sub
    Private Sub Qty_TextChanged(sender As Object, e As EventArgs) Handles Qty.TextChanged
        'If IsNumeric(Qty.Text) = False Then Qty.Clear()
        Tot.Text = Val(Price.Text) * Val(Qty.Text)
            Tot.Text = Format(Val(Tot.Text), "0.00")
    End Sub


    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        'xITM(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
        'ListItem.Hide()
        'Qty.Text = GRID1.Item(6, GRID1.CurrentRow.Index).Value
        ''  FreeIs.Text = GRID1.Item(7, GRID1.CurrentRow.Index).Value
        'Tot.Text = GRID1.Item(8, GRID1.CurrentRow.Index).Value
        GRID1.Rows.RemoveAt(GRID1.CurrentRow.Index)

        Dim xTOT As Double
        For Each row As DataGridViewRow In GRID1.Rows
            xTOT += row.Cells(5).Value
        Next
        Total.Text = xTOT
        Total.Text = Format(Val(Total.Text), "0.00")

    End Sub
    Dim xYES As Boolean = False
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If GRNNo.Text = "" Or GRID1.Rows.Count = 0 Or UnitID.Text = "" Or InvNo.Text = "" Then Return

        Dim result1 As DialogResult = MessageBox.Show("Do you want to Add this GRN NOTE ?", "GRN NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            Dim cFn As New CommonFunc
            cFn.SaveSupLed(SupCode.Text, Val(txtNET.Text), 0, DTP1.Value.Date, GRNNo.Text, 0)
            Dim items As String
            Dim pItems As New List(Of Sitems)
            For Each row As DataGridViewRow In GRID1.Rows
                Dim pitm As New Sitems
                pitm.itemCode = row.Cells(0).Value.ToString
                pitm.itemName = row.Cells(1).Value.ToString
                pitm.cost = row.Cells(2).Value.ToString
                pitm.selling = row.Cells(3).Value.ToString
                pitm.qty = row.Cells(4).Value.ToString
                pitm.vals = row.Cells(5).Value.ToString
                pItems.Add(pitm)
                cFn.SaveItemTrans(row.Cells(0).Value.ToString, Val(row.Cells(2).Value), Val(row.Cells(3).Value), Val(row.Cells(4).Value), DTP1.Value.Date, GRNNo.Text, 0, SupCode.Text)
            Next
            items = JsonConvert.SerializeObject(pItems)
            cFn.SaveGrn(GRNNo.Text, Val(txtNET.Text), Val(txtDisc.Text), DTP1.Value.Date, SupCode.Text, items, 0, InvNo.Text)
            MessageBox.Show("GRN NOTE Save Succeed.", "GRN NOTE", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

        '++++++++++++++++++++
        CmdCancel_Click(sender, EventArgs.Empty)

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        SupCode.Clear()
        SupName.Clear()
        ItemCode.Clear()
        ItemName.Clear()
        Price.Clear()
        ' WsPrice.Clear()
        SPrice.Clear()
        ' UOM.Clear()
        'UOM.Text = "UNIT"
        Qty.Clear()
        Tot.Clear()
        Total.Clear()
        ' FreeIs.Clear()
        InvNo.Clear()
        GRID1.Rows.Clear()
        SupName.Focus()
        DTP1.Text = Format(Now, "yyyy-MM-dd")
        CHQ1.Checked = True
        CHQ1.Checked = False
        xYES = False
        ListItem.Hide()
        xItemfind = False
        ListItem.Items.Clear()
        txtOthr.Clear()
        CmdSave.Enabled = True
        btnModi.Enabled = False
        GRNNo.Text = GetGrnNumber(UnitID.Text)
    End Sub

    Private Sub Price_TextChanged(sender As Object, e As EventArgs) Handles Price.TextChanged
        If IsNumeric(Price.Text) = False Then Return
        Tot.Text = Val(Price.Text) * Val(Qty.Text)
        Tot.Text = Format(Val(Tot.Text), "0.00")
    End Sub
    Dim xItemfind As Boolean = False
    Private Sub ItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCode.TextChanged
        If ItemCode.Text = "" Then
            ListItem.Hide()
        Else
            cmd3 = New SqlCommand("Select ItemCode,ItemName,Description from Itm where ItemCode like '%" & ItemCode.Text & "%'and Sts=0", con3)
            ListItem.Show()
            rdr3 = cmd3.ExecuteReader
            ListItem.Items.Clear()
            While rdr3.Read
                ListItem.Items.Add(rdr3("ItemCode") & " - " & rdr3("ItemName") & " - " & rdr3("Description"))
                'GRID2.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
            End While
            rdr3.Close()
        End If

    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

    Private Sub FreeIs_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            If SupCode.Text = "" Or ItemCode.Text = "" Then Return
            Dim xAMT As Double
            Dim RowTrue As Boolean = False, RowID As Integer = 0
            For Each row As DataGridViewRow In GRID1.Rows
                If (row.Cells(0).Value = ItemCode.Text And row.Cells(2).Value = Price.Text) Then
                    RowTrue = True : RowID = row.Index : xAMT = row.Cells(8).Value : Exit For
                End If
            Next
            If RowTrue = True Then
                GRID1.Rows(RowID).Cells(6).Value = Val(Qty.Text)
                '  GRID1.Rows(RowID).Cells(7).Value = Val(FreeIs.Text)
                GRID1.Rows(RowID).Cells(8).Value = Val(Tot.Text)
            Else
                'cmd = New SqlCommand("Select * from ItemMaster where(ItemCode='" & ItemCode.Text & "')", con)
                'rdr = cmd.ExecuteReader
                'If rdr.Read = True Then
                '    cmd1 = New SqlCommand("Update ItemMaster set ItemName='" & ItemName.Text & "',CostPrice='" & Val(Price.Text) & "',SellPrice='" & Val(SPrice.Text) & "',WSPrice='" & Val(WsPrice.Text) & "'where ItemCode='" & ItemCode.Text & "'", con1)
                '    cmd1.ExecuteNonQuery()
                'Else
                '    cmd1 = New SqlCommand("Insert ItemMaster values('" & ItemCode.Text & "','" & ItemName.Text.Replace("'", "") & "','" & "00" & "','" & "00" & "','" & "00" & "','" & "00" & "','" & "Descrip" & "','" & SupCode.Text & "','" & SupName.Text & "','" & UOM.Text & "','" & Val(Price.Text) & "','" & Val(SPrice.Text) & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "9" & "','" & Val(WsPrice.Text) & "')", con1)
                '    cmd1.ExecuteNonQuery()
                'End If
                'rdr.Close()
                '   GRID1.Rows.Add(ItemCode.Text, ItemName.Text, Val(Price.Text), Val(WsPrice.Text), Val(SPrice.Text), UOM.Text, Val(Qty.Text), Val(FreeIs.Text), Val(Tot.Text))
            End If
            Dim xTOT As Double
            For Each row As DataGridViewRow In GRID1.Rows
                xTOT += row.Cells(8).Value
            Next
            Total.Text = xTOT
            Total.Text = Format(Val(Total.Text), "0.00")
            ItemCode.Clear()
            ItemName.Clear()
            Price.Clear()
            '  WsPrice.Clear()
            SPrice.Clear()
            ' UOM.Clear()
            '  UOM.Text = "UNIT"
            Qty.Clear()
            ' FreeIs.Clear()
            Tot.Clear()
            ListItem.Hide()
            ItemCode.Focus()
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cmd = New SqlCommand("Select * from GRN_Sub", con)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    Dim xQTY As Double = rdr("Qty")
        '    Dim xQTY1 As Double = rdr("FreeQty")
        '    '       AutoID,                                            ItemCode,                   ItemName,           UOM,                   CostPrice,          SellPrice,            RcvQty,                   SaleQty,       DmgQty,   RtnQty,               BalanceQty,                          PisicalQty,                           LastUpdate, UName, WsPrice
        '    cmd1 = New SqlCommand("Insert Stock_Main values('" & rdr("ItemCode") & "','" & rdr("ItemName") & "','" & rdr("UOM") & "','" & rdr("CostPrice") & "','" & 0 & "','" & xQTY + xQTY1 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & xQTY + xQTY1 & "','" & xQTY + xQTY1 & "','" & rdr("LastUpdate") & "','" & FrmMDI.UName.Text & "','" & 0 & "')", con1)
        '    cmd1.ExecuteNonQuery()
        'End While
        'rdr.Close()
    End Sub
    Dim xCPRICE As Double = 0
    Dim xSPRICE As Double = 0
    Private Sub Total_TextChanged(sender As Object, e As EventArgs) Handles Total.TextChanged
        txtNET.Text = Val(Total.Text) - Val(txtDisc.Text)
        txtNET.Text = Format(Val(txtNET.Text), "0.00")
    End Sub

    Private Sub txtDisc_TextChanged(sender As Object, e As EventArgs) Handles txtDisc.TextChanged
        txtNET.Text = Val(Total.Text) - Val(txtDisc.Text)
        txtNET.Text = Format(Val(txtNET.Text), "0.00")
    End Sub

    Private Sub GRID101_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
    Dim xTYP As String = Nothing

    Private Sub ListItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListItem.SelectedIndexChanged

    End Sub

    Private Sub CHQ1_CheckedChanged(sender As Object, e As EventArgs) Handles CHQ1.CheckedChanged
        If CHQ1.Checked = True Then
            xTYP = "Veg"
        ElseIf CHQ1.Checked = False Then
            xTYP = "NonVeg"
        End If
    End Sub

    Private Sub SupCode_TextChanged(sender As Object, e As EventArgs) Handles SupCode.TextChanged

    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) Handles ListItem.KeyDown
        If e.KeyCode = 13 Then
            If ListItem.SelectedItem = "" Then Return
            Dim oItemCode As String = ListItem.SelectedItem
            Dim first_word As String = oItemCode.Split(" ")(0)
            ItemCode.Text = first_word
            xITM(ItemCode.Text)
            ListItem.Hide()
            ItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            ListItem.Items.Clear()
            ListItem.Hide()
            ItemCode.Focus()
        End If
    End Sub

    Private Sub InvNo_TextChanged(sender As Object, e As EventArgs) Handles InvNo.TextChanged

    End Sub

    Private Sub SupCode_MouseClick(sender As Object, e As MouseEventArgs) Handles SupCode.MouseClick

    End Sub

    Private Sub InvNo_GotFocus(sender As Object, e As EventArgs) Handles InvNo.GotFocus
        InvNo.BackColor = Color.Yellow
    End Sub

    Private Sub InvNo_LostFocus(sender As Object, e As EventArgs) Handles InvNo.LostFocus
        InvNo.BackColor = Color.Aquamarine
    End Sub

    Private Sub SupCode_GotFocus(sender As Object, e As EventArgs) Handles SupCode.GotFocus
        SupCode.BackColor = Color.Yellow
    End Sub

    Private Sub SupCode_LostFocus(sender As Object, e As EventArgs) Handles SupCode.LostFocus
        SupCode.BackColor = Color.White
    End Sub

    Private Sub WsPrice_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Price_KeyDown(sender As Object, e As KeyEventArgs) Handles Price.KeyDown
        If e.KeyCode = 13 Then
            SPrice.Focus()
            '  WsPrice.Focus()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub

    Private Sub SPrice_TextChanged(sender As Object, e As EventArgs) Handles SPrice.TextChanged

    End Sub

    Private Sub WsPrice_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            SPrice.Focus()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub

    Private Sub SPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles SPrice.KeyDown
        If e.KeyCode = 13 Then
            Qty.Focus()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub

    Private Sub ItemCode_GotFocus(sender As Object, e As EventArgs) Handles ItemCode.GotFocus
        ItemCode.BackColor = Color.Yellow
    End Sub

    Private Sub ItemCode_LostFocus(sender As Object, e As EventArgs) Handles ItemCode.LostFocus
        ItemCode.BackColor = Color.White
    End Sub

    Private Sub Price_GotFocus(sender As Object, e As EventArgs) Handles Price.GotFocus
        Price.BackColor = Color.Yellow
    End Sub

    Private Sub Price_LostFocus(sender As Object, e As EventArgs) Handles Price.LostFocus
        Price.BackColor = Color.White
    End Sub
    Private Sub SPrice_GotFocus(sender As Object, e As EventArgs) Handles SPrice.GotFocus
        SPrice.BackColor = Color.Yellow
    End Sub

    Private Sub SPrice_LostFocus(sender As Object, e As EventArgs) Handles SPrice.LostFocus
        SPrice.BackColor = Color.White
    End Sub
    Private Sub txtDisc_GotFocus(sender As Object, e As EventArgs) Handles txtDisc.GotFocus
        txtDisc.BackColor = Color.Yellow
    End Sub

    Private Sub txtDisc_LostFocus(sender As Object, e As EventArgs) Handles txtDisc.LostFocus
        txtDisc.BackColor = Color.White
    End Sub

    Private Sub txtSupCode_GotFocus(sender As Object, e As EventArgs) Handles txtSupCode.GotFocus
        txtSupCode.BackColor = Color.Yellow
    End Sub

    Private Sub txtSupCode_LostFocus(sender As Object, e As EventArgs) Handles txtSupCode.LostFocus
        txtSupCode.BackColor = Color.White
    End Sub

    Private Sub txtSupName_GotFocus(sender As Object, e As EventArgs) Handles txtSupName.GotFocus
        txtSupName.BackColor = Color.Yellow
    End Sub

    Private Sub txtSupName_LostFocus(sender As Object, e As EventArgs) Handles txtSupName.LostFocus
        txtSupName.BackColor = Color.White
    End Sub

    Private Sub ListItem_DoubleClick(sender As Object, e As EventArgs) Handles ListItem.DoubleClick

    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click
        If GRNNo.Text = "" Then Return
        Dim result1 As DialogResult = MessageBox.Show("Do you want to delete this GRN ?", "GRN Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            '  cmd = New SqlCommand("Select * from GRN_Main where(GRNNo='" & GRNNo.Text & "')", con)
            cmd = New SqlCommand("Delete from GRN_Main where(GRNNo='" & GRNNo.Text & "')", con)
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("Delete from GRN_Sub where(GRNNo='" & GRNNo.Text & "')", con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("GRN Delete Succeed.", "GRN Delete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CmdCancel_Click(sender, e)
        End If
    End Sub

    Private Sub ItemName_TextChanged(sender As Object, e As EventArgs) Handles ItemName.TextChanged
        ListItem.Hide()
        If ItemName.Text = "" Then
        Else
            cmd3 = New SqlCommand("Select ItemCode,ItemName,Description from Itm where ItemName like '%" & ItemName.Text & "%'", con3)
            rdr3 = cmd3.ExecuteReader
            ListItem.Items.Clear()
            While rdr3.Read
                ListItem.Show()
                ListItem.Items.Add(rdr3("ItemCode") & " - " & rdr3("ItemName") & " - " & rdr3("Description"))
                'GRID2.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
            End While
            rdr3.Close()
        End If
    End Sub

    Private Sub ListItem_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListItem.MouseDoubleClick
        If ListItem.SelectedItem = "" Then Return
        Dim oItemCode As String = ListItem.SelectedItem
        Dim first_word As String = oItemCode.Split(" ")(0)
        ItemCode.Text = first_word
        xITM(ItemCode.Text)
        ListItem.Hide()
        ItemCode.Focus()
    End Sub

    Private Sub ItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemName.KeyDown
        If e.KeyCode = 13 Then
            'xITM(ItemCode.Text)
            'ListItem.Hide()
            ' ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If ItemName.Text = "" Then
            Else
                ListItem.Focus()
                ListItem.Show()
                ListItem.SelectedIndex = 0
                ListItem.SelectedItem = 0
            End If
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub

    Private Sub Qty_GotFocus(sender As Object, e As EventArgs) Handles Qty.GotFocus
        Qty.BackColor = Color.Yellow
        Qty.SelectAll()
    End Sub

    Private Sub SupName_TextChanged(sender As Object, e As EventArgs) Handles SupName.TextChanged
        lstSup.Items.Clear()
        If SupName.Text = "" Then

            lstSup.Hide()
        Else
            cmd = New SqlCommand("Select  SupCode, SupName from Supplier where SupName like '%" & SupName.Text & "%'", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                lstSup.Show()
                lstSup.BringToFront()
                lstSup.Items.Add(rdr("SupCode") & " - " & rdr("SupName"))
            End While
            rdr.Close()
        End If
    End Sub

    Private Sub Qty_LostFocus(sender As Object, e As EventArgs) Handles Qty.LostFocus
        Qty.BackColor = Color.White
    End Sub

    Private Sub lstSup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSup.SelectedIndexChanged

    End Sub

    Private Sub SupName_KeyDown(sender As Object, e As KeyEventArgs) Handles SupName.KeyDown
        If e.KeyCode = 27 Then
            SupCode.Clear()
            SupName.Clear()
            lstSup.Items.Clear()
            lstSup.Hide()
            SupName.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If SupName.Text = "" Then Return
            lstSup.Focus()
            lstSup.SelectedIndex = 0
            lstSup.SelectedItem = 0

        End If
    End Sub

    Private Sub lstSup_DoubleClick(sender As Object, e As EventArgs) Handles lstSup.DoubleClick
        Dim sCode As String = lstSup.SelectedItem.ToString.Split("-")(0)
        Dim sName As String = lstSup.SelectedItem.ToString.Split("-")(1)
        SupCode.Text = sCode.Trim
        SupName.Text = sName.Trim
        lstSup.Items.Clear()
        lstSup.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Panel2.Hide()
        Panel1.Show()

    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        Panel1.Hide()
        Panel2.Show()
        Panel2.BringToFront()
    End Sub
    Private Sub LoadSavedGrn(ByVal dte As DateTime, ByVal dte1 As DateTime)
        GRID2.Rows.Clear()
        Dim sql As String = "SELECT Supplier.SupName, Purch.SCode,Purch.PNo,Purch.Ino,Purch.Dte,Purch.PAmnt,Purch.Disc FROM Supplier INNER JOIN Purch ON Supplier.SupCode = Purch.SCode where Purch.Dte>='" & dte.Date & "'and Purch.Dte<='" & dte1.Date & "'and Purch.Sts=0 order by Purch.Dte"
        cmd = New SqlCommand(sql, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            GRID2.Rows.Add(Format(rdr("Dte"), "yyyy-MM-dd"), rdr("SupName"), rdr("Ino"), rdr("PNo"), Format(rdr("PAmnt"), "0.00"), rdr("Disc"), rdr("SCode"))
        End While
        rdr.Close()
    End Sub

    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        LoadSavedGrn(dtp2.Value.Date, dtp3.Value.Date)
    End Sub

    Private Sub dtp3_ValueChanged(sender As Object, e As EventArgs) Handles dtp3.ValueChanged
        LoadSavedGrn(dtp2.Value.Date, dtp3.Value.Date)
    End Sub

    Private Sub GRID2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentClick

    End Sub

    Private Sub btnModi_Click(sender As Object, e As EventArgs) Handles btnModi.Click
        If GRNNo.Text = "" Or GRID1.Rows.Count = 0 Or UnitID.Text = "" Or InvNo.Text = "" Then Return
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Modify this GRN NOTE ?", "MODIFY GRN NOTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            cmd = New SqlCommand("Update Purch Set Sts=1 where PNo='" & GRNNo.Text & "'", con)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Update SLed Set Sts=1 where Tno='" & GRNNo.Text & "'", con)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Update Itr Set Sts=1 where Tno='" & GRNNo.Text & "'", con)
            cmd.ExecuteNonQuery()

            Dim cFn As New CommonFunc
            cFn.SaveSupLed(SupCode.Text, Val(txtNET.Text), 0, DTP1.Value.Date, GRNNo.Text, 0)
            Dim items As String
            Dim pItems As New List(Of Sitems)
            For Each row As DataGridViewRow In GRID1.Rows
                Dim pitm As New Sitems
                pitm.itemCode = row.Cells(0).Value.ToString
                pitm.itemName = row.Cells(1).Value.ToString
                pitm.cost = row.Cells(2).Value.ToString
                pitm.selling = row.Cells(3).Value.ToString
                pitm.qty = row.Cells(4).Value.ToString
                pitm.vals = row.Cells(5).Value.ToString
                pItems.Add(pitm)
                cFn.SaveItemTrans(row.Cells(0).Value.ToString, Val(row.Cells(2).Value), Val(row.Cells(3).Value), Val(row.Cells(4).Value), DTP1.Value.Date, GRNNo.Text, 0, SupCode.Text)
            Next
            items = JsonConvert.SerializeObject(pItems)
            cFn.SaveGrn(GRNNo.Text, Val(txtNET.Text), Val(txtDisc.Text), DTP1.Value.Date, SupCode.Text, items, 0, InvNo.Text)
            MessageBox.Show("GRN NOTE MODIFY Succeed...!", "GRN NOTE MODIFY", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

        '++++++++++++++++++++
        CmdCancel_Click(sender, EventArgs.Empty)

    End Sub

    Private Sub lstSup_KeyDown(sender As Object, e As KeyEventArgs) Handles lstSup.KeyDown
        If e.KeyCode = 13 Then
            Dim sCode As String = lstSup.SelectedItem.ToString.Split("-")(0)
            Dim sName As String = lstSup.SelectedItem.ToString.Split("-")(1)
            SupCode.Text = sCode.Trim
            SupName.Text = sName.Trim
            lstSup.Items.Clear()
            lstSup.Hide()
        ElseIf e.KeyCode = 27 Then
            lstSup.Items.Clear()
            lstSup.Hide()
            SupName.Focus()

        End If
    End Sub

    Private Sub GRID1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellClick
        If e.ColumnIndex = 7 Then
            Try
                Dim iCode As String = GRID1.CurrentRow.Cells(0).Value.ToString
                Dim sell As Double = Val(GRID1.CurrentRow.Cells(3).Value)
                Dim iNm As String = GRID1.CurrentRow.Cells(1).Value.ToString

                PrintCode(iCode, sell, iNm, SupCode.Text)
            Catch ex As Exception
                MessageBox.Show("Error...!")
            End Try

        End If
    End Sub
End Class