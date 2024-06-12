Imports System.Data.SqlClient
Imports ConnData
Imports POS_System.NewFunc
Public Class FrmRtn
    Dim xUNITID As String = Nothing
    Dim xAAA As Integer = 0, zAAA As Integer = 0
    Dim xSTL As New CashHandle
    Public Const eClear As String = Chr(27) + "@"
    Public Const COMMAND As String = Chr(29) + Chr(40) + "L" + Chr(6) + Chr(0) + Chr(48) + Chr(69) + Chr(32) + Chr(32) + Chr(1) + Chr(1)
    Public Const eDrawer As String = eClear + Chr(27) + "p" + Chr(0) + ".}"
    Private prn As New RawPrinterHelper

    Private PrinterName As String = "EPSON TM-T82II Receipt5"
    Private Sub FrmRtn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xMAX(Me)
        ' Me.WindowState = FormWindowState.Maximized
        Panel1.Show()
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
        UnitID.Text = Trim(FrmMDI.ToolStripStatusLabel2.Text)


        cmd = New SqlCommand("Select * from SlRtnGen where(UnitId='" & UnitID.Text & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            SLRTNNo.Text = UnitID.Text & Format(rdr("LastUpdate"), "ddMMyyyy") & rdr("SLRTN")
        Else
            '                                                 UnitID,            INV,               LastUpdate,                         Uname
            cmd1 = New SqlCommand("Insert SlRtnGen Values('" & UnitID.Text & "','" & 1 & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        UNIL()
        DTP1.Text = Date.Now.ToShortDateString

        CustLoad()
        ' AboutBox1.Close()
    End Sub
    Private Sub CustLoad()
        cmd = New SqlCommand("select * from Cus_Master order by cast(CusCode as Int)ASC", con)
        rdr = cmd.ExecuteReader
        CmbCus.Items.Clear()
        CmbCus.Items.Add("")
        While rdr.Read
            CmbCus.Items.Add(rdr("CusCode") & " - " & rdr("CusName"))
        End While
        rdr.Close()
    End Sub
    Public Sub StartPrint()
        prn.OpenPrint(PrinterName)
    End Sub
    Public Sub PrintFooter1()
        Print(eDrawer)
    End Sub
    Public Sub EndPrint()
        prn.ClosePrint()
    End Sub

    Private Sub FrmRtn_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        xPanelCenter(Me, Panel1)
        xPanelCenter(Me, Panel2)
        xPanelCenter(Me, Panel3)
        xPanelCenter(Me, Panel4)

        'Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        'Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        'Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        'Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))

    End Sub


    Private Sub xCLOSE()
        Me.Close()
        Dim xw As Integer = Screen.PrimaryScreen.Bounds.Width
        If xw < 1920 Then
            FrmCash1.Enabled = True
            FrmCash1.WindowState = FormWindowState.Maximized
        Else
            FrmCashier.Enabled = True
            FrmCashier.WindowState = FormWindowState.Maximized
        End If

    End Sub
    Private Sub UNIL()
        cmd = New SqlCommand("Select * from SlRtnGen where(UnitID='" & UnitID.Text & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            SLRTNNo.Text = UnitID.Text & "SLRTN" & Format(Now, "ddMMyyyy") & rdr("SLRTN")
            'INVNum.Text = UnitID.Text & Format(Now, "ddMMyyyy") & rdr("INV")
        End If
        rdr.Close()
    End Sub

    Private Sub ItCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItCode.KeyDown
        If e.KeyCode = Keys.Right Then
            ItName.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = 27 Then
            ItName.Clear()
            GRID2.Rows.Clear()
            ItCode.Clear()
            Panel1.Show()
            Panel2.Hide()
            Panel4.Hide()
        End If
    End Sub

    Private Sub ItCode_TextChanged(sender As Object, e As EventArgs) Handles ItCode.TextChanged
        If ItCode.Text = "" Then
            cmd = New SqlCommand("Select * from Stock_Main ", con)
        Else
            cmd = New SqlCommand("Select * from Stock_Main where ItemCode like '" & ItCode.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("CostPrice"), rdr("SellPrice"), rdr("BalanceQty"))
        End While
        rdr.Close()
    End Sub

    Private Sub ItName_KeyDown(sender As Object, e As KeyEventArgs) Handles ItName.KeyDown
        If e.KeyCode = Keys.Left Then
            ItCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = 27 Then
            ItName.Clear()
            ItCode.Focus()
        End If
    End Sub

    Private Sub ItName_TextChanged(sender As Object, e As EventArgs) Handles ItName.TextChanged
        If ItName.Text = "" Then
            cmd = New SqlCommand("Select * from Stock_Main ", con)
        Else
            cmd = New SqlCommand("Select * from Stock_Main where ItemName like '%" & ItName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("CostPrice"), rdr("SellPrice"), rdr("BalanceQty"))
        End While
        rdr.Close()
    End Sub

    Private Sub ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemCode.KeyDown
        If e.KeyCode = 13 Then
            xITM(ItemCode.Text)
            Descrip.Focus()
        ElseIf e.KeyCode = 113 Then
            ItCode_TextChanged(sender, EventArgs.Empty)
            Panel2.Show()
            Panel1.Hide()
            Panel4.Hide()
            ItCode.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            RfiD.Clear()
            ItemCode.Clear()
            ItemName.Clear()
            Descrip.Clear()
            CPrice.Clear()
            Price.Clear()
            Qty.Clear()
            LineTot.Clear()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.F3 Then
            CancelA()
        ElseIf e.KeyCode = Keys.F12 Then
            xCLOSE()
        ElseIf e.KeyCode = Keys.F2 Then
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            xSAVE()
        End If
    End Sub

    Private Sub ItemCode_TextChanged(sender As Object, e As EventArgs) Handles ItemCode.TextChanged

    End Sub
    Dim xCOUNT As Integer = 0
    Private Sub xITM(ByVal xITC As String)
        cmd = New SqlCommand("Select * from ItemMaster where ItemCode='" & xITC & "'", con)
        rdr = cmd.ExecuteReader
        GRID4.Rows.Clear()
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Select * from Stock_Main where(ItemCode='" & rdr("ItemCode") & "')", con1)
            rdr1 = cmd1.ExecuteReader
            While rdr1.Read
                GRID4.Rows.Add(rdr1("AutoID"), rdr1("ItemCode"), rdr1("ItemName"), Format(rdr1("CostPrice"), "0.00"), Format(rdr1("SellPrice"), "0.00"), rdr1("UOM"), rdr1("BalanceQty"))
                xCOUNT += 1
                If xCOUNT > 1 Then
                    RFID.Clear()
                    'ItemCode.Clear()
                    ItemName.Clear()
                    Descrip.Clear()
                    CPrice.Clear()
                    Price.Clear()
                    Qty.Clear()
                    LineTot.Clear()
                    ItemCode.Focus()
                    Panel4.Show()
                    Panel1.Enabled = False
                    GRID4.Focus()
                Else
                    RFID.Text = rdr1("AutoID").ToString
                    ItemCode.Text = rdr1("ItemCode").ToString
                    ItemName.Text = rdr1("ItemName").ToString
                    CPrice.Text = rdr1("CostPrice").ToString
                    Price.Text = rdr1("SellPrice").ToString
                    CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                    Price.Text = Format(Val(Price.Text), "0.00").ToString
                    UOM.Text = rdr1("UOM").ToString
                End If
            End While
            rdr1.Close()
        End If
        rdr.Close()
        xCOUNT = 0
    End Sub
    Private Sub xICDD(ByVal xCODEE As String)
        cmd = New SqlCommand("Select * from Stock_Main where(AutoID='" & xCODEE & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            RfiD.Text = rdr("AutoID").ToString
            ItemCode.Text = rdr("ItemCode").ToString
            ItemName.Text = rdr("ItemName").ToString
            CPrice.Text = Format(rdr("CostPrice"), "0.00").ToString
            Price.Text = Format(rdr("SellPrice"), "0.00").ToString
            UOM.Text = rdr("UOM").ToString
        End If
        rdr.Close()
    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        xICDD(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        Panel1.Show()
        Panel2.Hide()
        Panel4.Hide()
        ItemCode.Focus()
    End Sub

    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.RowCount = 0 Then Return
            xICDD(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            Panel1.Show()
            Panel2.Hide()
            Panel4.Hide()
            ItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            ItName.Clear()
            ItCode.Clear()
            ItCode.Focus()
        End If
    End Sub

    Private Sub GRID4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID4.CellContentClick
        xICDD(GRID4.Item(0, GRID4.CurrentRow.Index).Value)
        Panel1.Show()
        Panel1.Enabled = True
        Panel2.Hide()
        Panel4.Hide()
        ItemCode.Focus()
    End Sub

    Private Sub GRID4_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID4.KeyDown
        If e.KeyCode = 13 Then
            If GRID4.RowCount = 0 Then Return
            xICDD(GRID4.Item(0, GRID4.CurrentRow.Index).Value)
            Panel1.Show()
            Panel1.Enabled = True
            Panel2.Hide()
            Panel4.Hide()
            ItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            Panel1.Show()
            Panel1.Enabled = True
            Panel2.Hide()
            Panel4.Hide()
        End If
    End Sub
    Dim xQTY As Double = 0
    Private Sub Qty_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty.KeyDown
        If e.KeyCode = 13 Then
            If SLRTNNo.Text = "" Or ItemCode.Text = "" Or Qty.Text = "" Then Return

            'cmd = New SqlCommand("Select * from Stock_Main where AutoID='" & RfiD.Text & "'", con)
            'rdr = cmd.ExecuteReader
            'If rdr.Read = True Then
            '    xQTY = rdr("BalanceQty")
            'End If
            'rdr.Close()
            'If xQTY < Val(Qty.Text) Or xQTY = 0 Then Return
            Dim xAMT As Double
            Dim RowTrue As Boolean = False, RowID As Integer = 0
            For Each row As DataGridViewRow In GRID1.Rows
                If (row.Cells(1).Value = ItemCode.Text And row.Cells(0).Value = RfiD.Text) Then
                    RowTrue = True : RowID = row.Index : xAMT = row.Cells(7).Value : Exit For
                End If
            Next
            If RowTrue = True Then
                GRID1.Rows(RowID).Cells(6).Value = Qty.Text
                GRID1.Rows(RowID).Cells(7).Value = LineTot.Text
            Else
                '                 0         1               2               3              4          5           6           7         8
                GRID1.Rows.Add(RfiD.Text, ItemCode.Text, ItemName.Text, Descrip.Text, Price.Text, UOM.Text, Qty.Text, LineTot.Text, CPrice.Text)
            End If

            Dim xTOT As Double = 0
            For Each row As DataGridViewRow In GRID1.Rows
                xTOT += row.Cells(7).Value
            Next
            Totall.Text = xTOT
            Totall.Text = Format(Val(Totall.Text), "0.00")

            RfiD.Clear()
            ItemCode.Clear()
            ItemName.Clear()
            Descrip.Clear()
            CPrice.Clear()
            Price.Clear()
            Qty.Clear()
            LineTot.Clear()
            UOM.Clear()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            RfiD.Clear()
            ItemCode.Clear()
            ItemName.Clear()
            Descrip.Clear()
            CPrice.Clear()
            Price.Clear()
            Qty.Clear()
            LineTot.Clear()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.F3 Then
            CancelA()
        ElseIf e.KeyCode = Keys.F12 Then
            xCLOSE()
        ElseIf e.KeyCode = Keys.F2 Then
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            xSAVE()
        End If

    End Sub

    Private Sub Qty_TextChanged(sender As Object, e As EventArgs) Handles Qty.TextChanged
        ' If IsNumeric(Qty.Text) = False Then Qty.Clear()
        LineTot.Text = Val(Price.Text) * Val(Qty.Text)
        LineTot.Text = Format(Val(LineTot.Text), "0.00")

    End Sub
    Dim xBLQTTY As Double = 0
    Dim xPSCQTTY As Double = 0
    Dim xRCVQTY As Double = 0
    Private Sub xSAVE()
        If SLRTNNo.Text = "" Or GRID1.RowCount = 0 Or CmbInv.Text = "" Then Return

        Dim result1 As DialogResult = MessageBox.Show("Do you want to Return These Items ?", "Sales Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            '                                                           RtnNo,                  UnitID,                  Amount,              LastUpdate,                        UName 
            cmd = New SqlCommand("Insert SLRTN_Main values('" & SLRTNNo.Text & "','" & UnitID.Text & "','" & Val(Totall.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & CmbInv.Text & "')", con)
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To GRID1.RowCount - 1
                Dim xREF As Integer = GRID1(0, i).Value
                Dim xQTY As Double = Val(GRID1(6, i).Value)
                Dim xCPR As Double = Val(GRID1(8, i).Value)
                Dim xSPR As Double = Val(GRID1(4, i).Value)
                Dim xAMT As Double = Val(GRID1(7, i).Value)
                'Dim xREF As Integer = GRID1(0, i).Value
                '                            AutoID,              RefID,              RtnNo,               ItemCode,                      ItemName,                   Description,                UOM,                   Qty,                      SoldPrice,      Amount,                        LastUpdate,                        UpTime                           UName
                cmd = New SqlCommand("Insert SLRTN_Sub values('" & xREF & "','" & SLRTNNo.Text & "','" & GRID1(1, i).Value & "','" & GRID1(2, i).Value & "','" & GRID1(3, i).Value & "','" & GRID1(5, i).Value & "','" & xQTY & "','" & xCPR & "','" & xSPR & "','" & xAMT & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & xCusCode & "')", con)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Select * from Stock_Main where AutoID='" & GRID1(0, i).Value & "'", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    xBLQTTY = rdr("BalanceQty").ToString
                    xPSCQTTY = rdr("PisicalQty").ToString
                    xRCVQTY = rdr("RcvQty").ToString
                End If
                rdr.Close()
                cmd = New SqlCommand("Update Stock_Main Set RcvQty='" & xRCVQTY + Val(GRID1(6, i).Value) & "',BalanceQty='" & xBLQTTY + Val(GRID1(6, i).Value) & "',PisicalQty= '" & xPSCQTTY + Val(GRID1(6, i).Value) & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "'where AutoID='" & GRID1(0, i).Value & "'", con)
                cmd.ExecuteNonQuery()
            Next
            ' Public Function xSettle(ByVal oCSH As String, ByVal oCRDT As String, ByVal oRCPT As String, ByVal oSLRTN As String, ByVal oPYM As String, ByVal oBLAM As String, ByVal oLUP As String, ByVal oUN As String)
            'obj.xSettle(Total.Text, 0, 0, 0, 0, 0, Date.Now.ToShortDateString, FrmMDI.UName.Text)
            xSTL.xSettle(0, 0, 0, Val(Totall.Text), 0, 0, 0, Format(Now, "yyyy-MM-dd"), FrmMDI.UName.Text, 0, 0)
            If CmbCus.Text = "" Then
                xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, 0, Val(Totall.Text), 0, 0, 0, 0, 0)
            ElseIf CmbCus.Text <> "" Then
                cmd = New SqlCommand("Update Cus_Master set CusBalance-= '" & Val(Totall.Text) & "'where CusCode='" & xCusCode & "'", con)
                cmd.ExecuteNonQuery()
                Dim xCusName As String = Nothing
                cmd = New SqlCommand("Select CusName from Cus_Master where(CusCode='" & xCusCode & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    xCusName = rdr("CusName").ToString
                End If
                rdr.Close()
                '                                                   CusCode,            CusName,                    InvDate,                  Descp,      InvAmnt,             RcvDate,                   Descr,                     RcvAmnt
                cmd1 = New SqlCommand("Insert CusState values('" & xCusCode & "','" & xCusName & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Sales Return" & "','" & Val(Totall.Text) & "')", con1)
                cmd1.ExecuteNonQuery()
            End If
            '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
            cmd = New SqlCommand("Select * from SlRtnGen where(UnitID='" & UnitID.Text & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                cmd1 = New SqlCommand("Update SlRtnGen set SLRTN='" & rdr("SLRTN") + 1 & "'  where(UnitID='" & UnitID.Text & "' and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con1)
                cmd1.ExecuteNonQuery()
            End If
            rdr.Close()
            MessageBox.Show("Sales Return Succeed.", "Sales Return", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
        '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
        CancelA()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs)
        CustLoad()

    End Sub
    Private Sub CancelA()
        RfiD.Clear()
        ItemCode.Clear()
        ItemName.Clear()
        Descrip.Clear()
        CPrice.Clear()
        Price.Clear()
        Qty.Clear()
        LineTot.Clear()
        UOM.Clear()
        GRID1.Rows.Clear()
        Totall.Clear()
        Totall.Text = Format(Val(Totall.Text), "0.00")
        UNIL()
        xBLQTTY = 0
        xPSCQTTY = 0
        xRCVQTY = 0
        CustLoad()
        ItemCode.Focus()
    End Sub

    Private Sub InvNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles InvNum.KeyDown
        If e.KeyCode = 13 Then
            If InvNum.Text = "" Then Return

            Dim xCOL As String = UnitID.Text & Format(DTP1.Value, "ddMMyyy") & InvNum.Text
            cmd = New SqlCommand("Select * from  Inv_Main where(INVNo='" & xCOL & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                cmd1 = New SqlCommand("Select * from Inv_Sub where(INVNo='" & rdr("InvNo") & "')", con1)
                rdr1 = cmd1.ExecuteReader

                GRID1.Rows.Clear()
                While rdr1.Read
                    '                   RefID,           ItemCode, ItemName, Uom, SellPrice, Qty, Amnt, LastUpdate, UName
                    GRID1.Rows.Add(rdr1("RefID"), rdr1("ItemCode"), rdr1("ItemName"), "", Format(rdr1("SellPrice"), "0.00"), rdr1("UOM"), rdr1("Qty"), Format(rdr1("Amnt"), "0.00"), rdr1("CPrice"))

                End While
                rdr1.Close()
                Totall.Text = rdr("InvAmnt")
                Totall.Text = Format(Val(Totall.Text), "0.00")

            End If
            rdr.Close()
            ItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            InvNum.Clear()
            GRID1.Rows.Clear()
        ElseIf e.KeyCode = Keys.F3 Then
            CancelA()
        ElseIf e.KeyCode = Keys.F12 Then
            Me.Close()
            FrmCashier.Enabled = True
            FrmCashier.WindowState = FormWindowState.Maximized
        ElseIf e.KeyCode = Keys.F2 Then
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            xSAVE()
        End If
    End Sub

    Private Sub InvNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvNum.TextChanged

    End Sub

    Private Sub GRID1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

    Private Sub GRID1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        xITM(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
        GRID1.Rows.RemoveAt(GRID1.CurrentRow.Index)
        ItemCode.Focus()
     
    End Sub

    Private Sub GRID1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRID1.KeyDown
        If e.KeyCode = 13 Then
            If GRID1.RowCount = 0 Then Return
            'Dim result1 As DialogResult = MessageBox.Show("Are you sure the return ?", "Sales Return", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            'If result1 = vbYes Then
            '    Panel3.Show()
            '    Panel1.Enabled = False

            'End If
            xITM(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
            GRID1.Rows.RemoveAt(GRID1.CurrentRow.Index)
            ItemCode.Focus()

        ElseIf e.KeyCode = Keys.F3 Then
            CancelA()
        ElseIf e.KeyCode = Keys.F12 Then
            xCLOSE()
        ElseIf e.KeyCode = Keys.F2 Then
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            xSAVE()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If

    End Sub

    Private Sub GRID1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GRID1.KeyPress

    End Sub

    Private Sub Descrip_KeyDown(sender As Object, e As KeyEventArgs) Handles Descrip.KeyDown
        If e.KeyCode = Keys.F3 Then
            CancelA()
        ElseIf e.KeyCode = Keys.F12 Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            xSAVE()
        ElseIf e.KeyCode = Keys.Up Then
            RfiD.Clear()
            ItemCode.Clear()
            ItemName.Clear()
            Descrip.Clear()
            CPrice.Clear()
            Price.Clear()
            Qty.Clear()
            LineTot.Clear()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = 13 Then
            Price.Focus()
        End If
    End Sub

    Private Sub Descrip_TextChanged(sender As Object, e As EventArgs) Handles Descrip.TextChanged

    End Sub

    Private Sub ItemName_TextChanged(sender As Object, e As EventArgs) Handles ItemName.TextChanged

    End Sub

    Private Sub Price_KeyDown(sender As Object, e As KeyEventArgs) Handles Price.KeyDown
        If e.KeyCode = 13 Then
            Qty.Focus()
        ElseIf e.KeyCode = Keys.F3 Then
            CancelA()
        ElseIf e.KeyCode = Keys.F2 Then
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            xCLOSE()
        ElseIf e.KeyCode = Keys.F4 Then
            xSAVE()
        ElseIf e.KeyCode = Keys.Up Then
            RfiD.Clear()
            ItemCode.Clear()
            ItemName.Clear()
            Descrip.Clear()
            CPrice.Clear()
            Price.Clear()
            Qty.Clear()
            LineTot.Clear()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        End If
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        If prn.PrinterIsOpen = True Then
            PrintFooter1()
            EndPrint()
        End If
    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click
        CancelA()
    End Sub

    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click
        xSAVE()
    End Sub

    Private Sub Label44_Click(sender As Object, e As EventArgs) Handles Label44.Click
        xCLOSE()
        'Dim xw As Integer = Screen.PrimaryScreen.Bounds.Width
        'If xw < 1920 Then
        '    FrmCash1.Show()
        '    FrmCash1.MdiParent = FrmMDI
        '    FrmCash1.Enabled = True
        '    FrmCash1.BringToFront()
        'Else
        '    FrmCashier.Show()
        '    FrmCashier.MdiParent = FrmMDI
        '    FrmCashier.BringToFront()
        'End If
    End Sub

    Private Sub DTP1_ValueChanged(sender As Object, e As EventArgs) Handles DTP1.ValueChanged
        cmd = New SqlCommand("Select INVNo from Inv_Main where(LastUpdate='" & DTP1.Text & "')", con)
        rdr = cmd.ExecuteReader
        CmbInv.Items.Clear()
        While rdr.Read
            CmbInv.Items.Add(rdr("INVNo"))
        End While
        rdr.Close()

    End Sub
    Dim xCusCode As String = Nothing
    Private Sub CmbCus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCus.SelectedIndexChanged
        xCusCode = CmbCus.Text.Split("-")(0)
    End Sub

    Private Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnGet.Click
        If CmbInv.Text = "" Then
            Return
        End If
        cmd = New SqlCommand("Select * from  Inv_Main where(INVNo='" & CmbInv.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            DTP1.Value = rdr("LastUpdate").ToString()
            cmd1 = New SqlCommand("Select * from Inv_Sub where(INVNo='" & rdr("InvNo") & "')", con1)
            rdr1 = cmd1.ExecuteReader

            GRID1.Rows.Clear()
            While rdr1.Read
                '                   RefID,           ItemCode, ItemName, Uom, SellPrice, Qty, Amnt, LastUpdate, UName
                GRID1.Rows.Add(rdr1("RefID"), rdr1("ItemCode"), rdr1("ItemName"), "", Format(rdr1("SellPrice"), "0.00"), rdr1("UOM"), rdr1("Qty"), Format(rdr1("Amnt"), "0.00"), rdr1("CPrice"))

            End While
            rdr1.Close()
            Totall.Text = rdr("InvAmnt")
            Totall.Text = Format(Val(Totall.Text), "0.00")
        End If
        rdr.Close()


    End Sub

    Private Sub CmbInv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbInv.SelectedIndexChanged
        GRID1.Rows.Clear()
    End Sub

    Private Sub Price_TextChanged(sender As Object, e As EventArgs) Handles Price.TextChanged
        If IsNumeric(Price.Text) = False Then Price.Clear()
    End Sub
End Class