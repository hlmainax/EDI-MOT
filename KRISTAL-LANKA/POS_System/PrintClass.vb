Imports System.Data.SqlClient
Imports ConnData
Imports Microsoft.Win32

Public Class PrintClass
    '**************************************************************************
    Private _Path As String
    Public Const eClear As String = Chr(27) + "@"
    Public Const eCentre As String = Chr(27) + Chr(97) + "1"
    Public Const eLeft As String = Chr(27) + Chr(97) + "0"
    Public Const eRight As String = Chr(27) + Chr(97) + "2"
    Public Const eJuS As String = Chr(27) + Chr(9)
    Public Const eDrawer As String = eClear + Chr(27) + "p" + Chr(0) + ".}"
    Public Const eCut As String = Chr(27) + "i" + vbCrLf
    Public Const eSmlText As String = Chr(27) + "!" + Chr(1)
    Public Const eNmlText As String = Chr(27) + "!" + Chr(0)
    Public Const eInit As String = eNmlText + Chr(13) + Chr(27) + "c6" + Chr(1) + Chr(27) + "R3" + vbCrLf
    Public Const eBigCharOn As String = Chr(27) + "!" + Chr(56)
    Public Const eBigCharOff As String = Chr(27) + "!" + Chr(0)
    Public Const essd As String = Chr(27) + "!" + Chr(97) + Chr(27) + Chr(69) + Chr(13)
    Public Const eTottxt As String = Chr(27) + "!" + Chr(69)
    Public Const spc As String = "   "
    Public Const lftmrgn As String = Chr(27) + Chr(108) + Chr(13)
    Public Const ittb As String = ""
    Public Const COMMAND As String = Chr(29) + Chr(40) + "L" + Chr(6) + Chr(0) + Chr(48) + Chr(69) + Chr(32) + Chr(32) + Chr(1) + Chr(1)
    Public prn As New RawPrinterHelper
    Public PrinterName As String = "POS_Printer"
    '******************************************************************************
    Public Sub SupReceipt(ByVal xSupName As String, ByVal xRcpNo As String, ByVal xDate As String, ByVal xPrev As Double, ByVal xPay As Double)
        Print(eCentre + COMMAND)
        Print(eBigCharOn + eCentre + "HAMEED MART" + eLeft)
        Print(eBigCharOff + "7/1, Kandy RD, Gelioya")

        Print("Tel:0812 310 299 / 0768 010 132" + eInit)
        Print(eNmlText + eLeft + "Rcp No-" + xRcpNo + "      " + "Cashier - " + FrmMDI.UName.Text + eRight)
        Print(eNmlText + eLeft + "Date - " + xDate + "      " + "Time - " + Format(Now, "H:mm:ss").ToString + eRight)
        Print(eNmlText + eLeft + "Supplier - " + xSupName)
        PrintDashes()
        Print(eCentre + eNmlText + "Pervious Balance: " + essd + xPrev.ToString)
        Print(eCentre + eNmlText + "Payment: " + essd + xPay.ToString)
        Print(eCentre + eNmlText + "Current Balance: " + essd + (xPrev - xPay).ToString)
        PrintFooter()
    End Sub

    Public Sub StartPrint()
        prn.OpenPrint(PrinterName)
    End Sub
    Public Sub PrintHeader()
        'Print(eCentre + COMMAND)
        'Print(eBigCharOn + eCentre + "HAMEED MART" + eLeft)
        'Print(eBigCharOff + "7/1, Kandy RD, Gelioya")
        ''Print(eBigCharOff + "Polgolla")
        'Print("Tel:0812 310 299 / 0768 010 132" + eInit)
        ''Print("Web: www.????.com")
        ''Print("sales@????.com")
        ''Print("VAT Reg No:123 4567 89" + eLeft)
        'Print(eNmlText + eLeft + "INV No-" + INVNum.Text + "      " + "Cashier - " + FrmMDI.UName.Text + eRight)
        'Print(eNmlText + eLeft + Format(Now, "dd-MM-yyyy") + "     " + Date.Now.ToShortTimeString + "      Customer - " + CusCode.Text + eRight)
        ''""""""""""""""""""
        ''Print(essd + eLeft + txtDT.Text + spc + txtTME.Text + eRight)
        ''""""""""""""""""""""""
        ''Print(eNmlText + eRight + txtTME.Text)
        'PrintDashes()
        'Print(eNmlText + "Description" + vbTab + "           Price" + "  Qty" + eRight + "     Total")
        'PrintDashes()
    End Sub
    Public Sub PrintDTS()
        Print(eNmlText + eLeft + "txtDT.Text")
    End Sub
    Public Sub PrintBody(ByVal GRID1 As DataGridView)
        'For i As Integer = 0 To GRID1.RowCount - 1
        '    Dim SN As String = GRID1(0, i).Value
        '    Dim ITM As String = GRID1(2, i).Value
        '    Dim Prc As String = GRID1(4, i).Value
        '    Dim xUM As String = GRID1(5, i).Value
        '    Dim qty As String = GRID1(6, i).Value
        '    Dim tot As String = GRID1(7, i).Value
        '    'tot = tot(ContentAlignment.MiddleRight)
        '    If ITM.Length < 44 Then
        '        While ITM.Length <= 44
        '            ITM += " "
        '        End While
        '    ElseIf ITM.Length > 44 Then
        '        ITM = Mid(ITM, 1, 44)
        '    End If
        '    '""""""""""""""""""""""""
        '    Dim xP As String = " "
        '    If Prc.Length < 10 Then
        '        While Prc.Length <= 10
        '            Prc = Prc.Insert(0, " ")
        '        End While
        '    ElseIf Prc.Length > 10 Then
        '        Prc = Mid(Prc, 1, 10)
        '    End If
        '    '""""""""""""""""""""""""
        '    '""""""""""""""""""""""""
        '    If qty.Length < 8 Then
        '        While qty.Length <= 8
        '            qty = qty.Insert(0, " ")
        '        End While
        '    ElseIf qty.Length > 8 Then
        '        qty = Mid(qty, 1, 8)
        '    End If
        '    '""""""""""""""""""""""""
        '    '""""""""""""""""""""""""
        '    If xUM.Length < 5 Then
        '        While xUM.Length <= 5
        '            xUM = xUM.Insert(0, " ")
        '        End While
        '    ElseIf xUM.Length > 5 Then
        '        xUM = Mid(xUM, 1, 5)
        '    End If
        '    '"""""""""""""""""""""""""""""
        '    If tot.Length < 14 Then
        '        While tot.Length <= 14
        '            tot = tot.Insert(0, " ")
        '        End While
        '    ElseIf tot.Length > 14 Then
        '        tot = Mid(tot, 1, 14)
        '    End If
        '    '""""""""""""""""""""""""
        '    If SN.Length < 3 Then
        '        While SN.Length <= 3
        '            SN += " "
        '        End While
        '    End If
        '    'If Prc.Length < 5 Then
        '    '    Dim pp As Char = " "
        '    '    While Prc.Length <= 5
        '    '        Prc = " "
        '    '    End While
        '    'ElseIf Prc.Length > 5 Then
        '    '    Prc = Mid(ITM, 1, 5)
        '    'End If
        '    Dim xSS As String = ""
        '    If xSS.Length < 3 Then
        '        While xSS.Length <= 3
        '            xSS += " "
        '        End While
        '    ElseIf xSS.Length > 3 Then
        '        xSS = Mid(xSS, 1, 3)
        '    End If
        '    'Print(ITM + " " + Prc.PadLeft(8, " ") + " x " + qty.PadLeft(6, " ") + "=" + tot.PadLeft(9, " "))
        '    Print(" " + ITM)
        '    Print(xSS + Prc + " X " + qty + xUM + tot)
        'Next
        ''Print(eNmlText + "Tea                                   T1   1.30")
        ''>>>>>>>>>>>>>>
        'PrintDashes()
        'Print(eRight + eNmlText + "Sub Total: " + essd + Total.Text)
        'Print(eRight + eNmlText + "Discount: " + Format(Val(DiscVal.Text), "0.00"))
        'Print(eRight + eNmlText + "Net Total: " + essd + Format(Val(NeTot.Text), "0.00"))
        'Print(eRight + eNmlText + "By Cash: " + essd + Format(Val(ByCash.Text), "0.00"))
        'Print(eRight + eNmlText + "By Card: " + essd + Format(Val(CrdAmnt.Text), "0.00"))
        ''Print(eRight + eNmlText + "Card Int: " + essd + Format(Val(CardInterest.Text), "0.00"))
        'Print(eRight + eNmlText + "Paid Amount: " + Format(Val(TenderedAmt.Text), "0.00"))
        'Print(eRight + eNmlText + "Balance Amount: " + essd + Format(Val(BalAmt.Text), "0.00"))
        'Dim xx As String = GRID1.Rows.Count
        'Print(eLeft + eNmlText + "No Of Items: " + xx)
        'PrintDashes()
        'PRNTD()
        'Print(eRight + eNmlText + "Total Discount:   1.30")
    End Sub
    Public Sub PrintFooter()
        Print(eCentre + eNmlText + "Follow us on FB @cherrypick.lk")
        Print(eCentre + eNmlText + "Thank You Come Again!" + eLeft)
        PRNTD()
        'Print(eCentre + eNmlText + "Exchange Possible Withing 7 Days" + eLeft)
        'Print(eCentre + eNmlText + "With Tag and Original Receipt" + eLeft + eInit)
        Print(eCentre + eNmlText + "Powered By Softlab 0763313333" + eLeft + eInit + vbLf)
        Print(vbLf + vbLf + eCut + eDrawer)
    End Sub
    Public Sub PrintFooter1()
        Print(eDrawer)
    End Sub
    Public Sub Print(ByVal Line As String)
        prn.SendStringToPrinter(PrinterName, Line + vbLf)
    End Sub
    Public Sub PrintDashes()
        Print(eLeft + eNmlText + "~".PadRight(48, "~"))
    End Sub
    Public Sub PRNTD()
        Print(eCentre + eNmlText + "*".PadRight(25, "*"))
    End Sub
    Public Sub EndPrint()
        prn.ClosePrint()
    End Sub








End Class
