Imports System.Data.SqlClient
Imports ConnData
Imports System.IO
Imports System.Drawing
Imports POS_System.NewFunc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCashier
    Dim obj As New CashHandle
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
    Private prn As New RawPrinterHelper
    Private PrinterName As String = "EPSON TM-U220 Receipt"
    '******************************************************************************
    Dim xAAA As Integer = 0, zAAA As Integer = 0
    Dim xzSAVE As Boolean = False
    Private Sub FrmCashier_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F7 Then
        End If
    End Sub
    Dim CW As Integer = Me.Width
    Dim CH As Integer = Me.Height
    Dim IW As Integer = Me.Width
    Dim IH As Integer = Me.Height


    Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
    Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height

    Private Sub FrmCashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        FrmMDI.FormText.Text = "CASHIER"
        For i = 0 To GRID1.Rows.Count - 1
            GRID1.Rows(i).Height = 50
        Next
        'IW = Me.Width
        'IH = Me.Height
        Me.WindowState = FormWindowState.Maximized
        xW = Screen.PrimaryScreen.Bounds.Width + 40
        xH = Screen.PrimaryScreen.Bounds.Height
        Me.Width = xW
        Me.Height = xH
        UnitID.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "UnitID", Nothing)
        '  UnitID.Text = Trim(FrmMDI.ToolStripStatusLabel2.Text)
        'lblPaid.Text = "0.00"
        'lblBal.Text = "0.00"
        Dim xDG As New ArrayList
        Dim xDG1 As New ArrayList
        Dim xDG2 As New ArrayList
        Dim xDG3 As New ArrayList
        Dim xDG4 As New ArrayList
        Dim xSel As Boolean = False
        ''cmd = New SqlCommand("Select * from Stock_Main  order by ItemCode", con)
        ''rdr = cmd.ExecuteReader
        ''GRID5.Rows.Clear()
        '''GRID5.Refresh()
        ''While rdr.Read
        ''    'xDG.Add(rdr("AutoID"))
        ''    'xDG1.Add(rdr("ItemCode"))
        ''    'xDG2.Add(rdr("ItemName"))
        ''    'xDG3.Add(rdr("BalanceQty"))
        ''    'xDG4.Add(rdr("IType"))
        ''    'xDG4.Add(xSel)
        ''    GRID5.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("BalanceQty"), rdr("IType"), xSel)
        ''End While
        ''rdr.Close()
        'For i = 0 To xDG.Count - 1
        '    GRID5.Rows.Add(xDG.Item(i), xDG1.Item(i), xDG2.Item(i), xDG3.Item(i), xDG4.Item(i), xSel)
        'Next
        'For i = 0 To FrmMDI.xLIST.Count - 1
        '    GRID5.Rows.Add(FrmMDI.xLIST.Item(i), FrmMDI.xLIST1.Item(i), FrmMDI.xLIST1.Item(i), FrmMDI.xLIST3.Item(i), FrmMDI.xLIST4.Item(i))
        'Next
        cmd = New SqlCommand("Select * from InvGen where(UnitId='" & UnitID.Text & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            INVNum.Text = UnitID.Text & Format(rdr("LastUpdate"), "ddMMyyyy") & rdr("INV")
        Else
            '                                                 UnitID,            INV,               LastUpdate,                         Uname
            cmd1 = New SqlCommand("Insert InvGen Values('" & UnitID.Text & "','" & 1 & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        'UOM.Text = "PCS"
        'cmd = New SqlCommand("Select * from ItemMaster  order by ItemCode", con)
        'rdr = cmd.ExecuteReader
        'GRID5.Rows.Clear()
        'While rdr.Read
        '    GRID5.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("BalanceQty"))
        'End While
        'rdr.Close()
        Label41.Text = "CASH"
        Label41.BackColor = Color.Green
        'ByCash.Text = Val(NeTot.Text) - Val(CrdAmnt.Text)
        'ByCash.Text = Format(Val(ByCash.Text), "0.00")
        ' ItemCode.Focus()
        ItemCode.Focus()
        Timer1.Start()
        'xUNIT()
        aNUM()
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
        Panel5.Hide()
        Panel6.Hide()
        Panel8.Hide()
        ''''''''''''''''''''
        Discnt.Clear()
        Discnt.Text = "0"
        Discnt.Clear()
        PType.BackColor = Color.LightGreen
        LBLTYPE.Text = "CASH"
        LBLTYPE.BackColor = Color.LightGreen
        lblItems.Text = "00"
        DTP2.Value = Format(Now, "yyyy-MM-dd")
        'If GRID5.Rows.Count > 1 Then
        '    GRID5.ClearSelection()
        '    GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        'End If
        Dim xUse As String = FrmMDI.UName.Text
        cmd = New SqlCommand("Select * from User_Option where(UserName='" & xUse & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            If rdr("xINT") = 0 Then
                CmdTotalCost.Visible = True
                CPrice.Visible = True
                Prf.Visible = True
            Else
                Prf.Visible = False
                CmdTotalCost.Visible = False
                CPrice.Visible = False
                Label38.Visible = False
                Label37.Visible = False
                Label39.Width = Label39.Width + Label38.Width
                Label36.Width = Label36.Width + Label37.Width

            End If
        End If
        rdr.Close()
        xAcountLoad1(CmbAccount)
        BankLoad1()
        MorningCash()
        CreditTakens()
        ListBox1.Hide()
        gridItmList.Hide()
        ItemCode.Focus()
        FrmAct.Close()
        frmBackup.Close()
        FrmBANK.Close()
        'FrmCashier.Close()
        FrmCat1.Close()
        FrmCat2.Close()
        FrmCHQPAY.Close()
        FrmCustomer.Close()
        FrmDMG.Close()
        FrmErrorCorrec.Close()
        FrmExcel.Close()
        FrmGRNRPT.Close()
        FrmGRN.Close()
        FrmItem.Close()
        frmPchange.Close()
        FrmRCPT.Close()
        FrmREPORT.Close()
        FrmRPT.Close()
        FrmRPT1.Close()
        FrmRpts.Close()
        FrmRtn.Close()
        FrmSALESRE.Close()
        FrmSTCKENTER.Close()
        FrmSupPament.Close()
        FrmSupplier.Close()
        FrmSupplierRTN.Close()
        FrmUOP.Close()
        FrmUserControl.Close()
        BankLoad()
        SupLoad()


        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 150) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
        Me.Panel5.Location = New System.Drawing.Point(((Me.Width - Panel5.Width) / 2), ((Me.Height - Panel5.Height - 100) / 2))
        Me.Panel6.Location = New System.Drawing.Point(((Me.Width - Panel6.Width) / 2), ((Me.Height - Panel6.Height - 100) / 2))
        Me.Panel8.Location = New System.Drawing.Point(((Me.Width - Panel8.Width) / 2), ((Me.Height - Panel8.Height - 100) / 2))
        'Dim RW As Double = (Me.Width - CW) / CW














        ' FrmCashier_Resize(sender, EventArgs.Empty)
        'AboutBox1.Close()
    End Sub

    Private Sub BankLoad1()
        cmd = New SqlCommand("Select * from BankName", con)
        rdr = cmd.ExecuteReader
        CmbBank.Items.Clear()
        While rdr.Read
            CmbBank.Items.Add(rdr("BankName").ToString)
        End While
        rdr.Close()
    End Sub
    Private Sub BankLoad()
        cmd = New SqlCommand("Select * from Bank_Main", con)
        rdr = cmd.ExecuteReader
        CmbAccount101.Items.Clear()
        While rdr.Read
            CmbAccount101.Items.Add(rdr("AccNo") & " - " & rdr("BankName"))
        End While
        rdr.Close()
    End Sub
    Private Sub SupLoad()
        cmd = New SqlCommand("Select * from Supplier", con)
        rdr = cmd.ExecuteReader
        CmbSup.Items.Clear()
        While rdr.Read
            CmbSup.Items.Add(rdr("SupCode") & " - " & rdr("SupName"))
        End While
        rdr.Close()
    End Sub
    Private Sub MorningCash()
        cmd = New SqlCommand("Select * from MrningCash where(LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
        Else
            '                                                   PayAccount,    Description, Amnt,         LastUpdate
            cmd1 = New SqlCommand("Insert MrningCash values('" & "-" & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
    End Sub
    Private Sub CreditTakens()
        cmd = New SqlCommand("Select * from CreditTaken where(LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
        Else
            '                                                   CusName,            LastUpdate
            cmd1 = New SqlCommand("Insert CreditTaken values('" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
    End Sub
    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub
    '===============================================================================
    '~~~~~~~~~~~~~~~~~~~~~~~~~~
    Public Sub StartPrint()
        prn.OpenPrint(PrinterName)
    End Sub
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Public Sub PrintHeader()
        Print(eCentre + COMMAND)
        Print(eBigCharOn + eCentre + "HAMEED MART" + eLeft)
        Print(eBigCharOff + "7/1, Kandy RD, Gelioya")
        'Print(eBigCharOff + "Polgolla")
        Print("Tel:0812 310 299 / 0768 010 132" + eInit)
        'Print("Web: www.????.com")
        'Print("sales@????.com")
        'Print("VAT Reg No:123 4567 89" + eLeft)
        Print(eNmlText + eLeft + "INV No-" + INVNum.Text + "      " + "Cashier - " + FrmMDI.UName.Text + eRight)
        Print(eNmlText + eLeft + Format(Now, "dd-MM-yyyy") + "     " + Date.Now.ToShortTimeString + "      Customer - " + CusCode.Text + eRight)
        '""""""""""""""""""
        'Print(essd + eLeft + txtDT.Text + spc + txtTME.Text + eRight)
        '""""""""""""""""""""""
        'Print(eNmlText + eRight + txtTME.Text)
        PrintDashes()
        Print(eNmlText + "Description" + vbTab + "           Price" + "  Qty" + eRight + "     Total")
        PrintDashes()
    End Sub
    '"""""""""""""""""""""""""""++++(NEthmira Super)
    Public Sub PrintHeader11()
        'Print(eCentre + COMMAND)
        Print(eBigCharOn + eCentre + "KRISTAL LANKA")
        Print(eBigCharOff + "28, Yatinuwara Patumawatha")
        Print(eBigCharOff + "Kandy")
        'Print(eBigCharOff + "Polgolla")
        Print("Tel:077 88 44 877")
        Print(eCentre + eNmlText + "www.kristallanka.com")
        PrintDashes()
        'Print("Web: www.????.com")
        'Print("sales@????.com")
        'Print("VAT Reg No:123 4567 89" + eLeft)
        Print(eNmlText + eLeft + "INV -" + INVNum.Text + "-" + "Cashier- " + FrmMDI.UName.Text)
        Print(eNmlText + eLeft + Format(Now, "dd-MM-yyyy") + " " + Date.Now.ToShortTimeString)
        Print(eNmlText + "Customer - " + CusName.Text)
        Dim xx As String = GRID1.Rows.Count
        Print(eLeft + eNmlText + "No Of Items: " + xx)
        '""""""""""""""""""
        'Print(essd + eLeft + txtDT.Text + spc + txtTME.Text + eRight)
        '""""""""""""""""""""""
        'Print(eNmlText + eRight + txtTME.Text)
        PrintDashes()
        Print(eNmlText + "Description" + vbTab + " Qty " + "  Price " + " Total")
        PrintDashes()
    End Sub
    Public Sub PrintHeader11Q()
        'Print(eCentre + COMMAND)
        Print(eBigCharOn + eCentre + "KRISTAL LANKA")
        Print(eBigCharOff + "28, Yatinuwara Patumawatha")
        Print(eBigCharOff + "Kandy")
        'Print(eBigCharOff + "Polgolla")
        Print("Tel:077 88 44 877")
        Print(eCentre + eNmlText + "www.kristallanka.com")
        Print(eBigCharOn + eCentre + "~~~QUTATION~~~")
        PrintDashes()
        'Print("Web: www.????.com")
        'Print("sales@????.com")
        'Print("VAT Reg No:123 4567 89" + eLeft)
        Print(eNmlText + eLeft + "INV -" + INVNum.Text + "-" + "Cashier- " + FrmMDI.UName.Text)
        Print(eNmlText + eLeft + Format(Now, "dd-MM-yyyy") + " " + Date.Now.ToShortTimeString)
        Print(eNmlText + "Customer - " + CusName.Text)
        Dim xx As String = GRID1.Rows.Count
        Print(eLeft + eNmlText + "No Of Items: " + xx)
        '""""""""""""""""""
        'Print(essd + eLeft + txtDT.Text + spc + txtTME.Text + eRight)
        '""""""""""""""""""""""
        'Print(eNmlText + eRight + txtTME.Text)
        PrintDashes()
        Print(eNmlText + "Description" + vbTab + " Qty " + "  Price " + " Total")
        PrintDashes()
    End Sub
    'PrintReceipt==>>
    Private Sub PrintRCP(ByVal RcpNp As String, ByVal xCustomer As String)
        Print(eBigCharOn + eCentre + "KRISTAL LANKA")
        Print(eBigCharOff + "28, Yatinuwara Patumawatha")
        Print(eBigCharOff + "Kandy")
        Print("Tel:077 88 44 877")
        Print("www.kristallanka.com")
        PrintDashes()
        Print(eNmlText + eLeft + "RCP No-" + RcpNp + " " + "Cashier - " + FrmMDI.UName.Text + eRight)
        Print(eNmlText + eCentre + Format(Now, "dd-MM-yyyy") + "     " + Date.Now.ToShortTimeString)
        Print(eCentre & "Received with Thanks From")
        Print(eNmlText + eCentre + "Customer - " + xCustomer)
        '""""""""""""""""""
        If GridChq.Rows.Count > 0 Then
            PrintDashes()
        End If

    End Sub
    Private Sub PrintRCP101(ByVal xCustomer As String)
        Print(eBigCharOn + eCentre + "KRISTAL LANKA")
        Print(eBigCharOff + "28, Yatinuwara Patumawatha")
        Print(eBigCharOff + "Kandy")
        Print("Tel:077 88 44 877")
        Print("www.kristallanka.com")
        PrintDashes()
        Print(eNmlText + eCentre + Format(Now, "dd-MM-yyyy") + "     " + Date.Now.ToShortTimeString)
        Print(eNmlText + eCentre + "Customer - " + xCustomer)
        cmd = New SqlCommand("Select sum(CusBalance) from Cus_Master where(CusCode='" & CusCode.Text & "')", con)
        Dim xAMBT As Double = cmd.ExecuteScalar
        Dim txtB As New TextBox
        txtB.Text = xAMBT
        txtB.Text = Format(Val(txtB.Text), "0.00")
        Print(eCentre + eNmlText & "Current Balance: " + essd + txtB.Text)
        PrintDashes()
        ' PRNTD()
        Print(vbLf + vbLf + vbLf + vbLf + eCut + eDrawer)

        EndPrint()

    End Sub
    Public Sub PrintHeader111()
        'Print(eCentre + COMMAND)
        Print(eBigCharOn + eCentre + "KRISTAL LANKA")
        Print(eBigCharOff + "28, Yatinuwara Patumawatha")
        Print(eBigCharOff + "Kandy")
        'Print(eBigCharOff + "Polgolla")
        Print("Tel:077 88 44 877")
        Print("www.kristallanka.com")
        PrintDashes()
        'Print("Web: www.????.com")
        'Print("sales@????.com")
        'Print("VAT Reg No:123 4567 89" + eLeft)
        ''Print(eNmlText + eLeft + "INV No-" + INVNum.Text + "-" + "Cashier- " + FrmMDI.UName.Text)
        ''Print(eNmlText + eLeft + Format(Now, "dd-MM-yyyy") + " " + Date.Now.ToShortTimeString)
        ''Print(eNmlText + "Customer - " + CusCode.Text)




        Print(eNmlText + eLeft + "RP-" + CmbInv.Text + " " + "Cashier - " + FrmMDI.UName.Text)
        ' Print(eNmlText + eLeft + Format(Now, "dd-MM-yyyy") + " " + Date.Now.ToShortTimeString)
        Print(eNmlText + eLeft + InvTime.Text)
        Print(eNmlText + "Customer - " + CusName.Text)
        Dim xx As String = GRID101.Rows.Count
        Print(eLeft + eNmlText + "No Of Items: " + xx)
        '""""""""""""""""""
        'Print(essd + eLeft + txtDT.Text + spc + txtTME.Text + eRight)
        '""""""""""""""""""""""
        'Print(eNmlText + eRight + txtTME.Text)
        PrintDashes()
        Print(eNmlText + "Description" + vbTab + " Qty  " + "  Price" + "  Total")
        PrintDashes()
    End Sub
    Private Sub PrintInvoice()
        Dim ds As New DataSet2
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Inm", GetType(String))
        Table.Columns.Add("Prc", GetType(String))
        Table.Columns.Add("Qty", GetType(String))
        Table.Columns.Add("Dsc", GetType(String))
        Table.Columns.Add("Val", GetType(String))
        Table.Columns.Add("Uom", GetType(String))
        Table.Rows.Clear()
        For Each row As DataGridViewRow In GRID1.Rows
            Table.Rows.Add(row.Cells(2).Value, row.Cells(4).Value, row.Cells(6).Value, row.Cells(10).Value, row.Cells(7).Value, row.Cells(5).Value)
        Next
        Dim currBal As Double = 0
        Dim preBal As Double = 0
        If Label41.Text = "CREDIT" Then
            cmd = New SqlCommand("Select ISNULL((CusBalance),0) from Cus_Master where CusCode='" & CusCode.Text & "'", con)
            currBal = cmd.ExecuteScalar()
            ' preBal = currBal - Math.Abs(Val(BalAmt.Text))
            ' preBal = currBal - Math.Abs(Val(BalAmt.Text))
            preBal = Val(CusBalance.Text)
        ElseIf Label41.Text = "CASH" Then
            preBal = 0
        End If

        Dim xxc As New RptBill
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("inv", INVNum.Text)
        Dim idt As String = Format(Now, "yyyy-MM-dd") & " " & Format(Now, "H:mm:ss")
        xxc.SetParameterValue("dte", idt)
        xxc.SetParameterValue("un", FrmMDI.UName.Text)
        xxc.SetParameterValue("cus", CusName.Text)
        xxc.SetParameterValue("sbt", Format(Val(Total.Text), "0.00"))
        xxc.SetParameterValue("dcs", Format(Val(DiscVal.Text), "0.00"))
        xxc.SetParameterValue("net", Format(Val(NeTot.Text), "0.00"))
        xxc.SetParameterValue("pay", Format(Val(TenderedAmt.Text), "0.00"))
        xxc.SetParameterValue("bal", Format(Val(BalAmt.Text), "0.00"))
        xxc.SetParameterValue("pbal", Format(preBal, "0.00"))
        xxc.SetParameterValue("tout", Format(currBal, "0.00"))
        CType(xxc, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, "D:\123\'" & INVNum.Text & "'.pdf")
        If chk1.Checked = True Then
            Dim path As String = "C:\" + "Invoices" + "\" + Format(Now, "MMMM")
            If Not Directory.Exists(path) Then
                Directory.CreateDirectory(path)
            End If
            CType(xxc, ReportDocument).ExportToDisk(ExportFormatType.PortableDocFormat, path + "\" + INVNum.Text + ".pdf")
            'dte, ino, amn
            cmd = New SqlCommand("Insert Tth values('" & Format(Now, "yyyy-MM-dd") & "','" & INVNum.Text & "','" & NeTot.Text & "')", con)
            cmd.ExecuteNonQuery()
        End If
        'Dim printDocument As New System.Drawing.Printing.PrintDocument()
        'xxc.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName
        'xxc.PrintToPrinter(1, True, 1, 1)
    End Sub
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Public Sub PrintDTS()
        Print(eNmlText + eLeft + "txtDT.Text")
    End Sub
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~
    Public Sub PrintBody()

        Dim xNumber As Integer = 0
        For i As Integer = 0 To GRID1.RowCount - 1
            Dim SN As String = GRID1(0, i).Value
            SN.Trim()
            Dim ITM As String = GRID1(2, i).Value
            Dim Prc As String = GRID1(4, i).Value
            Prc.Trim()
            Dim xUM As String = GRID1(5, i).Value
            xUM.Trim()
            Dim qty As String = GRID1(6, i).Value
            qty.Trim()
            Dim tot As String = GRID1(7, i).Value
            tot.Trim()
            Dim xDISCNT As Double = Val(GRID1(10, i).Value)
            Dim PriceVal As Double = Prc + xDISCNT
            Dim Disc As String = xDISCNT
            'tot = tot(ContentAlignment.MiddleRight)
            ''""""""""""""""""""""""""
            Dim xP As String = " "
            Dim xDSCN As String = xDISCNT
            xPval = "Rs" & xPval & " -" & xDSCN & " = "

            xNumber += 1
            Print(xNumber.ToString + " " + ITM.PadRight(30, " "))
            Dim xprc = "Rs" & Prc
            Print(qty.PadLeft(4, " ") & xUM.PadLeft(3, " ") & " X" & xprc.PadLeft(9, " ") & "  -" & Disc.PadRight(4, " ") & tot.PadLeft(8, " "))
            xCV = Nothing
        Next
        'Print(eNmlText + "Tea                                   T1   1.30")
        '>>>>>>>>>>>>>>
        PrintDashes()
        Print("Sub Total:" & essd & Total.Text.PadLeft(14, " "))
        Dim xVALS As String = Format(Val(DiscVal.Text), "0.00")
        Print(eNmlText & "Discount: " & essd & xVALS.PadLeft(14, " "))
        Print(" ")
        Dim xBalAmount As Double = Val(Total.Text) - Val(DiscVal.Text)
        Dim xBals1 As New TextBox
        xBals1.Text = xBalAmount
        xBals1.Text = Format(Val(xBals1.Text), "0.00")
        Print(eNmlText & "Net Total:" & essd & xBals1.Text.PadLeft(14, " "))
        Print(" ")
        Dim xBals As String = Format(Val(BalAmt.Text), "0.00")
        Dim xOB As Double = 0
        If CusCode.Text <> "" Then
            cmd = New SqlCommand("Select count(CusCode)from Cus_Master where(CusCode='" & CusCode.Text & "')", con)
            Dim oInt As Integer = 0
            oInt = cmd.ExecuteScalar
            If oInt > 0 Then
                cmd = New SqlCommand("Select sum(CusBalance) from Cus_Master where(CusCode='" & CusCode.Text & "')", con)
                xOB = cmd.ExecuteScalar
            End If
        End If
        Dim xtet1 As New TextBox
        xtet1.Text = xOB
        Dim xOBals As String = Format(Val(xtet1.Text), "0.00")
        Dim xtet As New TextBox
        xtet.Text = Val(TenderedAmt.Text) + Val(ByCHQ.Text)
        Dim xPAid As String = Format(Val(xtet.Text), "0.00")
        Dim PrevBals As New TextBox
        If Val(BalAmt.Text) > 0 Then
            PrevBals.Text = Val(xtet1.Text) + Val(BalAmt.Text)
        ElseIf Val(BalAmt.Text) <= 0 Then
            PrevBals.Text = Val(xtet1.Text) - Math.Abs(Val(BalAmt.Text))
        End If
        PrevBals.Text = Format(Val(PrevBals.Text), "0.00")
        ' Print(eInit)
        Print(eNmlText & "Paid Amount: " & essd & xPAid.PadLeft(12, " "))
        '2021-80-10 Print(eNmlText & "Balance Amount: " & essd & xBals.PadLeft(10, " "))
        Print(eNmlText & "Invoice Balance:" & essd & xBals.PadLeft(10, " "))
        Print(" ")
        If Label41.Text = "CREDIT" Then
            Dim cusBal As Double = 0
            Dim cusCodee As String = Nothing
            cmd = New SqlCommand("Select CusName from Inv_Main where InvNo='" & INVNum.Text & "'", con)
            cusCodee = cmd.ExecuteScalar
            cmd = New SqlCommand("Select CusBalance from Cus_Master where CusName='" & cusCodee & "'", con)
            cusBal = cmd.ExecuteScalar
            'PrevBals.Text = cusBal - xBals1.Text
            PrevBals.Text = CusBalance.Text
            Dim ff As New TextBox
            ff.Text = xOBals
            ff.Text = (Val(NeTot.Text) - (Val(TenderedAmt.Text) + Val(ByCHQ.Text))) + Val(PrevBals.Text)
            ff.Text = Format(Val(ff.Text), "0.00")
            Print(eNmlText & "Previuos Balance: " & essd & PrevBals.Text.PadLeft(9, " "))
            Print(eNmlText & "Total Outstanding:" & essd & ff.Text.PadLeft(9, " "))
        Else
            If CusCode.Text = "" Then
                Dim cc As String = "0.00"
                Print(eNmlText & "Previuos Balance: " & essd & cc.PadLeft(9, " "))
                Print(eNmlText & "Total Outstanding:" & essd & cc.PadLeft(9, " "))
            Else
                Dim prvBal As New TextBox
                Dim ttOut As New TextBox
                prvBal.Text = GetOverPaid(CusCode.Text, Val(NeTot.Text), Val(TenderedAmt.Text))
                prvBal.Text = Format(Val(prvBal.Text), "0.00")
                ttOut.Text = Val(prvBal.Text) - (Val(TenderedAmt.Text) - Val(NeTot.Text))
                ttOut.Text = Format(Val(ttOut.Text), "0.00")
                Print(eNmlText & "Previuos Balance: " & essd & prvBal.Text.PadLeft(9, " "))
                Print(eNmlText & "Total Outstanding:" & essd & ttOut.Text.PadLeft(9, " "))
            End If

        End If
        'Dim xx As String = GRID1.Rows.Count
        'Print(eLeft + eNmlText + "No Of Items: " + xx)
        PrintDashes()
        ''PRNTD()
        'Print(eRight + eNmlText + "Total Discount:   1.30")
    End Sub
    Public Sub PrintBodyq()

        Dim xNumber As Integer = 0
        For i As Integer = 0 To GRID1.RowCount - 1
            Dim SN As String = GRID1(0, i).Value
            SN.Trim()
            Dim ITM As String = GRID1(2, i).Value
            Dim Prc As String = GRID1(4, i).Value
            Prc.Trim()
            Dim xUM As String = GRID1(5, i).Value
            xUM.Trim()
            Dim qty As String = GRID1(6, i).Value
            qty.Trim()
            Dim tot As String = GRID1(7, i).Value
            tot.Trim()
            Dim xDISCNT As Double = Val(GRID1(10, i).Value)
            Dim PriceVal As Double = Prc + xDISCNT
            Dim Disc As String = xDISCNT
            Dim xP As String = " "
            Dim xDSCN As String = xDISCNT
            xPval = "Rs" & xPval & " -" & xDSCN & " = "
            xNumber += 1
            Print(xNumber.ToString + " " + ITM.PadRight(30, " "))
            Dim xprc = "Rs" & Prc

            Print(qty.PadLeft(4, " ") & xUM.PadLeft(3, " ") & " X" & xprc.PadLeft(9, " ") & "  -" & Disc.PadRight(4, " ") & tot.PadLeft(8, " "))
            'Print(xCV)
            xCV = Nothing
        Next

        PrintDashes()
        Print("Sub Total:" & essd & Total.Text.PadLeft(14, " "))
        Print(" ")
        Dim xVALS As String = Format(Val(DiscVal.Text), "0.00")
        Print(eNmlText & "Discount: " & essd & xVALS.PadLeft(14, " "))
        Print(" ")
        Dim xBalAmount As Double = Val(Total.Text) - Val(DiscVal.Text)
        Dim xBals1 As New TextBox
        xBals1.Text = xBalAmount
        xBals1.Text = Format(Val(xBals1.Text), "0.00")
        Print(eNmlText & "Net Total:" & essd & xBals1.Text.PadLeft(14, " "))
        Print(" ")
        PrintDashes()
    End Sub
    Public Sub PrintRcpBody(ByVal xPaid As String, ByVal xBal As String)
        For Each row As DataGridViewRow In GridChq.Rows
            Print(row.Cells(0).Value & "-" & row.Cells(1).Value & " - " & row.Cells(3).Value)
        Next
        PrintDashes()
        Print(eCentre + eNmlText & "Paid Amount: " + essd + xPaid)
        Print(eCentre + eNmlText & "Current Balance: " + essd + xBal)
        PrintDashes()
        ' PRNTD()
        Print(vbLf + vbLf + vbLf + vbLf + eCut + eDrawer)

        'Print(eRight + eNmlText + "Total Discount:   1.30")
    End Sub
    Public Sub PrintBody1()
        Dim cCde As String = Nothing
        cmd = New SqlCommand("Select CusCode from Inv_Sub where InvNo='" & CmbInv.Text & "'", con)
        cCde = cmd.ExecuteScalar
        Dim xNumber As Integer = 0
        For i As Integer = 0 To GRID101.RowCount - 1
            Dim SN As String = GRID101(0, i).Value
            Dim ITM As String = GRID101(2, i).Value
            Dim Prc As String = GRID101(4, i).Value
            Dim xUM As String = GRID101(3, i).Value
            Dim qty As String = GRID101(5, i).Value
            Dim tot As String = GRID101(6, i).Value
            Dim xDISCNT As Double = Val(GRID101(7, i).Value)
            Dim PriceVal As Double = Prc + xDISCNT

            'Dim PriceVal As Double = Prc + xDISCNT
            Dim Disc As String = xDISCNT
            'tot = tot(ContentAlignment.MiddleRight)

            ''""""""""""""""""""""""""
            Dim xP As String = " "

            Dim xDSCN As String = xDISCNT
            xPval = "Rs" & xPval & " -" & xDSCN & " = "
            xNumber += 1
            'Dim tWord As String = ITM.Split(" ").Last
            'Dim xStingg As String = ITM
            'xStingg = xStingg.Substring(0, xStingg.LastIndexOf(" ")).Trim()
            Print(xNumber.ToString + " " + ITM.PadRight(30, " "))
            Dim xprc = "Rs" & Prc
            Print(qty.PadLeft(4, " ") & xUM.PadLeft(3, " ") & " X" & xprc.PadLeft(9, " ") & "  -" & Disc.PadRight(4, " ") & tot.PadLeft(8, " "))
            'Print(xCV)
            xCV = Nothing
        Next
        'Print(eNmlText + "Tea                                   T1   1.30")
        '>>>>>>>>>>>>>>
        PrintDashes()
        Print("Sub Total:" & essd & InvAmount.Text.PadLeft(14, " "))
        Dim xVALS As String = Format(Val(Disc.Text), "0.00")
        Print(eNmlText & "Discount: " & essd & xVALS.PadLeft(14, " "))
        Print(" ")
        Dim xBalanceAmount As Double = Val(InvAmount.Text) - Val(Disc.Text)
        Dim xNetBalance As New TextBox
        xNetBalance.Text = xBalanceAmount
        xNetBalance.Text = Format(Val(xNetBalance.Text), "0.00")
        Print(eNmlText & "Net Total:" & essd & xNetBalance.Text.PadLeft(14, " "))
        Print(" ")
        Dim txt1 As New TextBox
        txt1.Text = Val(CashTen.Text) - Val(CardInt.Text)
        txt1.Text = Format(Val(txt1.Text), "0.00")
        Dim xBALNC As String = txt1.Text
        Dim xBals As String = "0.00"
        Dim PrevBals As New TextBox
        If Val(txt1.Text) > 0 Then
            PrevBals.Text = Val(txtCurBal.Text) + Val(txt1.Text)
        ElseIf Val(txt1.Text) <= 0 Then
            PrevBals.Text = Val(txtCurBal.Text) - Val(txt1.Text)
        End If
        PrevBals.Text = Format(Val(PrevBals.Text), "0.00")
        Dim xPaids As String = Format(Val(CashTen.Text), "0.00")
        Print(eNmlText & "Paid Amount: " & essd & xPaids.PadLeft(12, " "))
        Print(eNmlText & "Invoice Balance:" & essd & xBALNC.PadLeft(10, " "))
        Print(" ")
        If itp = "CREDIT" Then
            Dim cusBal As Double = 0
            Dim cusCode As String = Nothing
            cmd = New SqlCommand("Select CusName from Inv_Main where InvNo='" & CmbInv.Text & "'", con)
            cusCode = cmd.ExecuteScalar
            cmd = New SqlCommand("Select CusBalance from Cus_Master where CusName='" & cusCode & "'", con)
            cusBal = cmd.ExecuteScalar
            PrevBals.Text = cusBal - xNetBalance.Text
            PrevBals.Text = Val(PrevBals.Text) + Val(CashTen.Text)
            PrevBals.Text = Format(Val(PrevBals.Text), "0.00")

            Dim prvBal As New TextBox
            Dim ttOut As New TextBox
            cmd = New SqlCommand("Select * from Inv_Vals where InvNo='" & CmbInv.Text & "'", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                prvBal.Text = rdr("Pre").ToString
                ttOut.Text = rdr("TotB").ToString
            End If
            rdr.Close()

            prvBal.Text = Format(Val(prvBal.Text), "0.00")
            ttOut.Text = Format(Val(ttOut.Text), "0.00")


            Print(eNmlText & "Previuos Balance: " & essd & prvBal.Text.PadLeft(9, " "))
            Print(eNmlText & "Total Outstanding:" & essd & ttOut.Text.PadLeft(9, " "))
        Else
            If cCde = "" Then
                Dim hh As String = "0.00"
                Print(eNmlText & "Previuos Balance: " & essd & hh.PadLeft(9, " "))
                Print(eNmlText & "Total Outstanding:" & essd & hh.PadLeft(9, " "))
            Else

                Dim prvBal As New TextBox
                Dim ttOut As New TextBox
                cmd = New SqlCommand("Select * from Inv_Vals where InvNo='" & CmbInv.Text & "'", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    prvBal.Text = rdr("Pre").ToString
                    ttOut.Text = rdr("TotB").ToString
                End If
                rdr.Close()
                prvBal.Text = Format(Val(prvBal.Text), "0.00")
                ttOut.Text = Format(Val(ttOut.Text), "0.00")
                Print(eNmlText & "Previuos Balance: " & essd & prvBal.Text.PadLeft(9, " "))
                Print(eNmlText & "Total Outstanding:" & essd & ttOut.Text.PadLeft(9, " "))
            End If
        End If
        'Print(eNmlText & "Balance Amount:" & essd & xBALNC.PadLeft(11, " "))
        'Print(eNmlText & "Old Balance: " & essd & xBals.PadLeft(12, " "))
        'Dim xx As String = GRID101.Rows.Count
        'Print(eLeft + eNmlText + "No Of Items: " + xx)
        PrintDashes()
    End Sub
    Public Sub PrintFooter()
        Print(eCentre + eNmlText + "Thank You Come Again!")
        PRNTD()
        'Print(eCentre + eNmlText + "Exchange Possible Withing 7 Days" + eLeft)
        'Print(eCentre + eNmlText + "With Tag and Original Receipt" + eLeft + eInit)
        Print(eCentre + eNmlText + "Powered By Ainax 0767 753 721" + eInit + vbLf)
        Print(vbLf + vbLf + eCut + eDrawer)
    End Sub
    Public Sub PrintFooter1()
        Print(eDrawer)
    End Sub
    Public Sub Print(ByVal Line As String)
        prn.SendStringToPrinter(PrinterName, Line + vbLf)
    End Sub
    Public Sub PrintDashes()
        Print(eLeft + eNmlText + "-".PadRight(33, "-"))
    End Sub
    Public Sub PRNTD()
        Print(eCentre + eNmlText + ".".PadRight(25, "."))
    End Sub
    Public Sub EndPrint()
        prn.ClosePrint()
    End Sub
    '~~~~~~~~~~~~~~~~~~~~~~~~~~~
    '===============================================================================
    Private Sub FrmCashier_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 150) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
        Me.Panel5.Location = New System.Drawing.Point(((Me.Width - Panel5.Width) / 2), ((Me.Height - Panel5.Height - 100) / 2))
        Me.Panel6.Location = New System.Drawing.Point(((Me.Width - Panel6.Width) / 2), ((Me.Height - Panel6.Height - 100) / 2))
        Me.Panel8.Location = New System.Drawing.Point(((Me.Width - Panel8.Width) / 2), ((Me.Height - Panel8.Height - 100) / 2))
        'Dim RW As Double = (Me.Width - CW) / CW
        'Dim RH As Double = (Me.Height - CH) / CH

        'For Each Ctrl As Control In Controls
        '    'Ctrl.Font.Size = 1pts
        '    Ctrl.Height += CInt(Ctrl.Height * RH)
        '    Ctrl.Left += CInt(Ctrl.Left * RW)
        '    Ctrl.Top += CInt(Ctrl.Top * RH)
        '    CW = Me.Width
        '    CH = Me.Height
        'Next
    End Sub
    Public Sub op()
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 150) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
        Me.Panel5.Location = New System.Drawing.Point(((Me.Width - Panel5.Width) / 2), ((Me.Height - Panel5.Height - 100) / 2))
        Me.Panel6.Location = New System.Drawing.Point(((Me.Width - Panel6.Width) / 2), ((Me.Height - Panel6.Height - 100) / 2))
        Me.Panel8.Location = New System.Drawing.Point(((Me.Width - Panel8.Width) / 2), ((Me.Height - Panel8.Height - 100) / 2))
        'Dim RW As Double = (Me.Width - CW) / CW
        'Dim RH As Double = (Me.Height - CH) / CH

        'For Each Ctrl As Control In Controls
        '    'Ctrl.Font.Size = 1pts
        '    Ctrl.Height += CInt(Ctrl.Height * RH)
        '    Ctrl.Left += CInt(Ctrl.Left * RW)
        '    Ctrl.Top += CInt(Ctrl.Top * RH)
        '    CW = Me.Width
        '    CH = Me.Height
        'Next
    End Sub

    Private Sub xUNIT()
        cmd = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xAAA = rdr("INV")
        End If
        rdr.Close()
        INVNum.Text = UnitID.Text & "INV" & (Format(xAAA, "00000000"))
    End Sub
    Private Sub aNUM()
        cmd = New SqlCommand("Select * from InvGen where(UnitID='" & UnitID.Text & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            INVNum.Text = UnitID.Text & Format(Now, "ddMMyyyy") & rdr("INV")
        End If
        rdr.Close()
    End Sub
    Private Sub ItemCode_GotFocus(sender As Object, e As EventArgs) Handles ItemCode.GotFocus
        ItemCode.BackColor = Color.Yellow
    End Sub
    Private Sub ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemCode.KeyDown
        If e.KeyCode = 13 Then
            If ItemCode.Text = "" Then
                ' Discnt.Focus()
            Else
                xITM(ItemCode.Text)
                'ListBox1.Hide()
                gridItmList.Hide()
            End If
        ElseIf e.KeyCode = Keys.Right Then
            TenderedAmt.Focus()
            'ElseIf e.KeyCode = Keys.Oemplus Then
            '    ItemCode.Clear()
            '    TenderedAmt.Focus()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Clear()
            Description.Clear()
            Price.Clear()
            '  UOM.Clear()
            Qty.Clear()
            LineTot.Clear()
            Price.Clear()
            txtType.Clear()
            CPrice.Clear()
            DisValue100.Clear()
            QtyInHand.Clear()
            ItemCode.Focus()
            'ElseIf e.KeyCode = Keys.F2 Then
            '    StartPrint()
            '    If prn.PrinterIsOpen = True Then
            '        PrintFooter1()
            '        EndPrint()
            '    End If
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
            'ElseIf e.KeyCode = Keys.Up Then
            '    RFID.Clear()
            '    ItemCode.Clear()
            '    Description.Clear()
            '    CPrice.Clear()
            '    Price.Clear()
            '    Qty.Clear()
            '    LineTot.Clear()
            '    '  UOM.Clear()
            '    ItName.Clear()
            '    txtType.Clear()
            '    ItName.Focus()
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
            'ElseIf e.KeyCode = Keys.F9 Then
            '    Label41.Text = "WHOLE SALE"
            '    Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        ElseIf e.KeyCode = Keys.Down Then
            If ItemCode.Text <> "" Then
                'ListBox1.Focus()

                'ListBox1.SelectedIndex = -1
                'ListBox1.SelectedItem = -1
                gridItmList.Focus()
                gridItmList.Rows(0).Selected = True
            Else
                GRID1.Focus()
            End If

        End If
    End Sub
    Private Sub CusCode_GotFocus(sender As Object, e As EventArgs) Handles CusCode.GotFocus
        CusCode.BackColor = Color.Yellow
    End Sub
    Private Sub CusCode_KeyDown(sender As Object, e As KeyEventArgs) Handles CusCode.KeyDown
        If e.KeyCode = 13 Then
            Panel6.Show()
            Panel1.Enabled = False
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
            'xCUST(CusCode.Text)
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = 113 Then
            Panel6.Show()
            Panel1.Enabled = False
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = 27 Then
            CusCode.Clear()
            CusName.Clear()
            CusCode.Focus()
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        End If
    End Sub
    Private Sub xCUST(ByVal xCCODE As String)
        cmd = New SqlCommand("select * from Cus_Master where(CusCode='" & xCCODE & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            If rdr("Active") = 1 Then
                CusCode.Text = rdr("CusCode").ToString
                CusName.Text = rdr("CusName").ToString
                CusBalance.Text = rdr("CusBalance").ToString
                CusBalance.Text = Format(Val(CusBalance.Text), "0.00")
                txtTotalCr.Text = Format(Val(CusBalance.Text), "0.00")
                CrdtLmt.Text = rdr("CusCreditLimit")
                CrdtLmt.Text = Format(Val(CrdtLmt.Text), "0.00")
                If Val(CrdtLmt.Text) > 0 Then
                    CanGv.Text = rdr("CusCreditLimit") - rdr("CusBalance")
                    CanGv.Text = Format(Val(CanGv.Text), "0.00")
                Else
                End If
            Else
                cmd1 = New SqlCommand("Update Cus_Master set Active='" & 1 & "'where CusCode='" & xCCODE & "'", con1)
                cmd1.ExecuteNonQuery()
                cmd1 = New SqlCommand("select * from Cus_Master where(CusCode='" & xCCODE & "')", con1)
                rdr1 = cmd1.ExecuteReader
                If rdr1.Read = True Then
                    CusCode.Text = rdr1("CusCode").ToString
                    CusName.Text = rdr1("CusName").ToString
                    CusBalance.Text = rdr1("CusBalance").ToString
                    CusBalance.Text = Format(Val(CusBalance.Text), "0.00")
                    CrdtLmt.Text = rdr1("CusCreditLimit")
                    CrdtLmt.Text = Format(Val(CrdtLmt.Text), "0.00")
                    If Val(CrdtLmt.Text) > 0 Then
                        CanGv.Text = rdr("CusCreditLimit") - rdr("CusBalance")
                        CanGv.Text = Format(Val(CanGv.Text), "0.00")
                    Else
                    End If
                End If
                rdr1.Close()
            End If
        End If
        rdr.Close()
    End Sub
    Private Sub CusCode_LostFocus(sender As Object, e As EventArgs) Handles CusCode.LostFocus
        CusCode.BackColor = Nothing
    End Sub
    Dim xQTY As Double = 0
    Private Sub Qty_GotFocus(sender As Object, e As EventArgs) Handles Qty.GotFocus
        Qty.BackColor = Color.Yellow
    End Sub
    Private Sub Qty_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty.KeyDown
        If e.KeyCode = 13 Then
            'Dim itemHave As Boolean = False
            'cmd = New SqlCommand("Select * from ItemMaster where(ItemCode='" & ItemCode.Text & "')", con)
            'rdr = cmd.ExecuteReader
            'If rdr.Read = True Then
            '    itemHave = True
            'Else
            '    '                                                      ItemCode,            ItemName,                                 Cat1,          Cat1Name,             Cat2,    at2Name,    Description,   SupCode,      SupName,       Uom,                CostPrice,                SellPrice,                  Inact                           LastUpdate                              UName                   UName
            '    cmd1 = New SqlCommand("Insert ItemMaster values('" & ItemCode.Text & "','" & Description.Text.Replace("'", "") & "','" & "-" & "','" & "-" & "','" & "-" & "','" & "-" & "','" & "-" & "','" & "-" & "','" & "-" & "','" & UOM.Text & "','" & Val(CPrice.Text) & "','" & Val(Price.Text) & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "9" & "','" & Val(Price.Text) & "')", con1)
            '    cmd1.ExecuteNonQuery()
            '    '                   AutoID,                           ItemCode,                          ItemName,                      UOM,                    CostPrice,                   SellPrice,                 RcvQty,                  SaleQty,      DmgQty,  RtnQty,             BalanceQty,                 PisicalQty,                     LastUpdate,                         UName,                      WsPrice,                    IType
            '    cmd1 = New SqlCommand("Insert Stock_Main values('" & ItemCode.Text & "','" & Description.Text.Replace("'", "") & "','" & UOM.Text & "','" & Val(Price.Text) & "','" & Val(Price.Text) & "','" & Val(Qty.Text) & "','" & 0 & "','" & 0 & "','" & 0 & "','" & Val(Qty.Text) & "','" & Val(Qty.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "','" & Val(Price.Text) & "','" & "NON" & "')", con1)
            '    cmd1.ExecuteNonQuery()
            '    cmd1 = New SqlCommand("Select MAX(AutoID) from Stock_Main", con1)
            '    RFID.Text = cmd1.ExecuteScalar
            'End If
            'rdr.Close()
            'If itemHave = True Then
            '    cmd = New SqlCommand("Select * from Stock_Main where(ItemCode='" & ItemCode.Text & "')", con)
            '    rdr = cmd.ExecuteReader
            '    If rdr.Read = True Then
            '        cmd1 = New SqlCommand("Update ItemMaster Set ItemName='" & Description.Text.Replace("'", "") & "',SellPrice='" & Val(Price.Text) & "'where ItemCode='" & ItemCode.Text & "'", con1)
            '        cmd1.ExecuteNonQuery()
            '        cmd1 = New SqlCommand("Update Stock_Main Set ItemName='" & Description.Text.Replace("'", "") & "',SellPrice ='" & Val(Price.Text) & "'where ItemCode='" & ItemCode.Text & "'", con1)
            '        cmd1.ExecuteNonQuery()
            '    Else
            '        '                   AutoID,                           ItemCode,                          ItemName,                      UOM,                    CostPrice,                   SellPrice,                 RcvQty,       SaleQty,  DmgQty,      RtnQty,             BalanceQty,         PisicalQty,             LastUpdate,                         UName,                      WsPrice,                    IType
            '        cmd1 = New SqlCommand("Insert Stock_Main values('" & ItemCode.Text & "','" & Description.Text.Replace("'", "") & "','" & UOM.Text & "','" & Val(Price.Text) & "','" & Val(Price.Text) & "','" & Val(Qty.Text) & "','" & 0 & "','" & 0 & "','" & 0 & "','" & Val(Qty.Text) & "','" & Val(Qty.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "','" & Val(Price.Text) & "','" & "NON" & "')", con1)
            '        cmd1.ExecuteNonQuery()

            '        cmd1 = New SqlCommand("Select MAX(AutoID) from Stock_Main", con1)
            '        RFID.Text = cmd1.ExecuteScalar
            '    End If
            '    rdr.Close()
            'End If
            If INVNum.Text = "" Or ItemCode.Text = "" Or RFID.Text = "" Then Return
            If Val(Qty.Text) = 0 Then Return
            '************************8
            'If ItemCode.Text = "SERVICE" Then
            'ElseIf ItemCode.Text = "EZY" Then
            'Else
            cmd = New SqlCommand("Select * from Stock_Main where AutoID='" & RFID.Text & "'", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                xQTY = rdr("BalanceQty")
            End If
            rdr.Close()
            If xQTY < Val(Qty.Text) Or xQTY = 0 Then Return
            'End If
            '************************
            If Label41.Text = "CREDIT" Then
                If CusCode.Text = "" Then Return

                Dim xCDVC As Double = 0
                xCDVC = Val(CanGv.Text) - Val(NeTot.Text)
                If Val(LineTot.Text) > Val(CanGv.Text) Then
                    MsgBox("Please Check Customer Balance")
                    Return
                ElseIf Val(CanGv.Text) < Val(LineTot.Text) + Val(NeTot.Text) Then
                    MsgBox("Please Check Customer Balance")
                    Return
                End If
            End If
            '***************************
            If UOM.Text.Length > 3 Then
                UOM.Text = Mid(UOM.Text, 1, 3)
            End If
            If UOM.Text.ToUpper() = "KG" Then
                If Val(Qty.Text) < 1 Then
                    UOM.Text = "Grm"
                End If
            End If
            Dim fgj As Double = 0
            For Each row As DataGridViewRow In GRID1.Rows
                If (row.Cells(1).Value = ItemCode.Text) Then
                    fgj += Val(row.Cells(7).Value)
                End If
            Next

            If Val(QtyInHand.Text) <= fgj Then Return



            'Dim xAMT As Double
            'Dim RowTrue As Boolean = False, RowID As Integer = 0
            'For Each row As DataGridViewRow In GRID1.Rows
            '    If (row.Cells(1).Value = ItemCode.Text And row.Cells(4).Value = Format(Val(Price.Text), "0.00")) Then
            '        RowTrue = True : RowID = row.Index : xAMT = row.Cells(7).Value : Exit For
            '    End If
            'Next
            'If RowTrue = True Then Return
            GRID1.Rows.Add(RFID.Text, ItemCode.Text, Description.Text, CPrice.Text.Trim, Format(Val(Price.Text) + Val(DisValue100.Text), "0.00"), UOM.Text.Trim, Qty.Text.Trim, Format(Val(LineTot.Text), "0.00"), Val(CLTot.Text), txtType.Text, DisValue100.Text)
            GRID1.FirstDisplayedScrollingRowIndex = GRID1.RowCount - 1
            'Clear the last selection
            GRID1.ClearSelection()
            'Select the last row.
            GRID1.Rows(GRID1.RowCount - 1).Selected = True
            GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LawnGreen
            'If xGdrGet = False Then
            '    GRID1.Rows.Add(RFID.Text, ItemCode.Text, Description.Text, CPrice.Text.Trim, Format(Val(Price.Text) + Val(DisValue100.Text), "0.00"), UOM.Text.Trim, Qty.Text.Trim, Format(Val(LineTot.Text), "0.00"), Val(CLTot.Text), txtType.Text, DisValue100.Text)
            '    GRID1.FirstDisplayedScrollingRowIndex = GRID1.RowCount - 1
            '    'Clear the last selection
            '    GRID1.ClearSelection()
            '    'Select the last row.
            '    GRID1.Rows(GRID1.RowCount - 1).Selected = True
            '    GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LawnGreen
            'ElseIf xGdrGet = True Then
            '    GRID1.Rows.Insert(xGdr, RFID.Text, ItemCode.Text, Description.Text, CPrice.Text.Trim, Format(Val(Price.Text) + Val(DisValue100.Text), "0.00"), UOM.Text.Trim, Qty.Text.Trim, Format(Val(LineTot.Text), "0.00"), Val(CLTot.Text), txtType.Text, DisValue100.Text)
            '    GRID1.ClearSelection()
            '    ' DataGridView1.CurrentCell = DataGridView1.Rows(MyDesiredIndex).Cells(0)
            '    GRID1.Rows(xGdr).Selected = True
            '    GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LawnGreen
            'End If
            For i = 0 To GRID1.Rows.Count - 1
                GRID1.Rows(i).Height = 35
            Next
            'If RowTrue = True Then
            '    'GRID1.Rows(RowID).Cells(7).Value = GRID1.Rows(RowID).Cells(7).Value + Val(LineTot.Text)
            '    'GRID1.Rows(RowID).Cells(8).Value = GRID1.Rows(RowID).Cells(8).Value + Val(CLTot.Text)
            'Else
            '    '                 0         1               2               3               4                                 5           6              7
            '    GRID1.Rows.Add(RFID.Text, ItemCode.Text, Description.Text, CPrice.Text, Format(Val(Price.Text), "0.00"), UOM.Text, Qty.Text, Format(Val(LineTot.Text), "0.00"), Val(CLTot.Text), txtType.Text, DisValue100.Text)
            'End If
            Dim xTOT As Double = 0
            Dim xCTOT As Double = 0
            Dim xDISCVALUE As Double = 0
            For Each row As DataGridViewRow In GRID1.Rows
                xTOT += Val(row.Cells(7).Value) + (Val(row.Cells(10).Value) * Val(row.Cells(6).Value))
                'xDISCVALUE += Val(row.Cells(6).Value) * ItemPriceS
                xCTOT += Val(row.Cells(8).Value)
                xDISCVALUE += Val(row.Cells(6).Value) * Val(row.Cells(10).Value)
            Next
            Discnt.Clear()
            Discnt.Text = "0"
            GRID1.Rows(RowID).Cells(7).Value = Format(Val(GRID1.Rows(RowID).Cells(7).Value), "0.00")
            Total.Text = xTOT
            Total.Text = Format(Val(Total.Text), "0.00")
            CostTotal.Text = xCTOT
            DiscVal.Text = xDISCVALUE
            DiscVal.Text = Format(Val(DiscVal.Text), "0.00")
            NeTot.Text = Val(Total.Text) - Val(DiscVal.Text)
            NeTot.Text = Format(Val(NeTot.Text), "0.00")
            Prf.Text = Val(NeTot.Text) - Val(CostTotal.Text)
            Prf.Text = Format(Val(Prf.Text), "0.00")
            lblItems.Text = GRID1.Rows.Count
            RFID.Clear()
            ItemCode.Clear()
            Description.Clear()
            CPrice.Clear()
            Price.Clear()
            Qty.Clear()
            LineTot.Clear()
            CLTot.Clear()
            DisValue100.Clear()
            ItemPriceS = 0
            UOM.Clear()
            ItemPriceS = 0
            txtType.Clear()
            ItemCode.Clear()
            xGdr = 0
            xGdrGet = False
            QtyInHand.Clear()
            ItemCode.Focus()
            If Label41.Text = "CREDIT" Then
                txtTotalCr.Text = Val(CusBalance.Text) + Val(NeTot.Text)
                txtTotalCr.Text = Format(Val(txtTotalCr.Text), "0.00")
            End If
            'If GRID5.Rows.Count > 0 Then
            '    GRID5.ClearSelection()
            '    GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
            'End If
            'For i As Integer = 0 To GRID5.Rows.Count - 1
            '    GRID5.Rows(i).DefaultCellStyle.BackColor = Color.White
            'Next
            'ItName.Clear()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
            'ElseIf e.KeyCode = Keys.Left Then
            '    Price.Focus()
            'ElseIf e.KeyCode = Keys.Right Then
            '    Discnt.Focus()
            '    Discnt.Clear()
            '    Discnt.Text = "0"
            '    Discnt.Clear()
            'ElseIf e.KeyCode = Keys.Up Then
            '    RFID.Clear()
            '    ItemCode.Clear()
            '    Description.Clear()
            '    CPrice.Clear()
            '    Price.Clear()
            '    Qty.Clear()
            '    LineTot.Clear()
            '    'UOM.Clear()
            '    ItemCode.Clear()
            '    txtType.Clear()
            '    ItemCode.Focus()
            'ElseIf e.KeyCode = Keys.F2 Then
            '    StartPrint()
            '    If prn.PrinterIsOpen = True Then
            '        PrintFooter1()
            '        EndPrint()
            '    End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
            'ElseIf e.KeyCode = Keys.F9 Then
            '    Label41.Text = "WHOLE SALE"
            '    Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub
    Private Sub Qty_LostFocus(sender As Object, e As EventArgs) Handles Qty.LostFocus
        Qty.BackColor = Nothing
    End Sub
    Private Sub Qty_TextChanged(sender As Object, e As EventArgs) Handles Qty.TextChanged
        If IsNumeric(Val(Qty.Text)) = False Then
            Return
        Else
            LineTot.Text = Val(Price.Text) * Val(Qty.Text)
            LineTot.Text = Format(Val(LineTot.Text), "0.00")
            CLTot.Text = Val(CPrice.Text) * Val(Qty.Text)
        End If
    End Sub
    Dim xCOUNT As Integer = 0
    Private Sub xITM(ByVal xITC As String)
        Dim sHV As Boolean = False
        cmd = New SqlCommand("Select * from ItemMaster where ItemCode='" & xITC & "'", con)
        rdr = cmd.ExecuteReader
        GRID4.Rows.Clear()
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Select count(ItemCode) from Stock_Main where ItemCode='" & rdr("ItemCode") & "'", con1)
            Dim xDN As Integer = 0
            xDN = cmd1.ExecuteScalar()
            If xDN > 0 Then
                cmd1 = New SqlCommand("Select * from Stock_Main where(ItemCode='" & rdr("ItemCode") & "')", con1)
                rdr1 = cmd1.ExecuteReader
                While rdr1.Read
                    QtyInHand.Text = rdr1("BalanceQty").ToString
                    GRID4.Rows.Add(rdr1("AutoID"), rdr1("ItemCode"), rdr1("ItemName"), rdr1("CostPrice"), rdr1("SellPrice"), rdr1("UOM"), rdr1("BalanceQty"), "")
                    xCOUNT += 1
                    If xCOUNT > 1 Then
                        RFID.Clear()
                        'ItemCode.Clear()
                        Description.Clear()
                        CPrice.Clear()
                        Price.Clear()
                        Qty.Clear()
                        ItemPriceS = 0
                        LineTot.Clear()
                        ItemCode.Focus()
                        Panel4.Show()
                        Panel2.Hide()
                        Panel1.Enabled = False
                        GRID4.Focus()
                    ElseIf xCOUNT = 0 Then
                    Else
                        If Label41.Text = "WHOLE SALE" Then
                            If rdr1("WsPrice") = 0 Then
                                RFID.Text = rdr1("AutoID").ToString
                                ItemCode.Text = rdr1("ItemCode").ToString
                                Description.Text = rdr1("ItemName").ToString
                                CPrice.Text = rdr1("CostPrice").ToString
                                Price.Text = rdr1("SellPrice").ToString
                                ItemPriceS = rdr("SellPrice")
                                CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                                Price.Text = Format(Val(Price.Text), "0.00").ToString
                                UOM.Text = rdr1("UOM").ToString
                                txtType.Text = rdr1("IType").ToString
                            Else

                                RFID.Text = rdr1("AutoID").ToString
                                ItemCode.Text = rdr1("ItemCode").ToString
                                Description.Text = rdr1("ItemName").ToString
                                CPrice.Text = rdr1("CostPrice").ToString
                                Price.Text = rdr1("WsPrice").ToString
                                ItemPriceS = rdr("WsPrice")
                                CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                                Price.Text = Format(Val(Price.Text), "0.00").ToString
                                UOM.Text = rdr1("UOM").ToString
                                txtType.Text = rdr1("IType").ToString
                            End If
                        Else
                            RFID.Text = rdr1("AutoID").ToString
                            ItemCode.Text = rdr1("ItemCode").ToString
                            Description.Text = rdr1("ItemName").ToString
                            CPrice.Text = rdr1("CostPrice").ToString
                            Price.Text = rdr1("SellPrice").ToString
                            ItemPriceS = rdr("SellPrice")
                            CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                            Price.Text = Format(Val(Price.Text), "0.00").ToString
                            UOM.Text = rdr1("UOM").ToString
                            txtType.Text = rdr1("IType").ToString
                            Price.Focus()
                        End If
                    End If
                End While
                rdr1.Close()
                'If sHV = True Then
                '    ''                   AutoID,                             ItemCode,                   ItemName,                      UOM,                    CostPrice,                   SellPrice, R          SaleQty,      DmgQty,  RtnQty,             BalanceQty,                 PisicalQty,                     LastUpdate,                         UName,                      WsPrice,                    IType
                '    ''                                                         ItemCode,                  ItemName,  Description, SupCode, SupName, UOM, CostPrice, SellPrice, Inact, LastUpdate, UName, ROLevel, WSPrice
                '    'cmd1 = New SqlCommand("Insert Stock_Main values('" & rdr("ItemCode") & "','" & rdr("ItemName") & "','" & rdr("UOM") & "','" & rdr("CostPrice") & "','" & rdr("SellPrice") & "','" & 1 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 1 & "','" & 1 & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "','" & rdr("WSPrice") & "','" & "NON" & "')", con1)
                '    'cmd1.ExecuteNonQuery()
                'End If
            ElseIf xDN = 0 Then
                'ItemCode.Text = ItName.Text
                'Description.Focus()
            End If
        Else
            'ItemCode.Text = ItName.Text
            'Description.Focus()
        End If
        rdr.Close()
        xCOUNT = 0
    End Sub
    Dim xxxCOUNT As Integer = 0
    Public Sub grddclick(ByVal iccd As String)
        cmd = New SqlCommand("Select * from Stock_Main where(AutoID='" & iccd & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            If Label41.Text = "WHOLE SALE" Then
                If rdr("WsPrice") = 0 Then
                    RFID.Text = rdr("AutoID").ToString
                    ItemCode.Text = rdr("ItemCode").ToString
                    Description.Text = rdr("ItemName").ToString
                    CPrice.Text = rdr("CostPrice").ToString
                    Price.Text = rdr("SellPrice").ToString
                    CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                    Price.Text = Format(Val(Price.Text), "0.00").ToString
                    UOM.Text = rdr("UOM").ToString
                    txtType.Text = rdr("IType").ToString
                Else

                    RFID.Text = rdr("AutoID").ToString
                    ItemCode.Text = rdr("ItemCode").ToString
                    Description.Text = rdr("ItemName").ToString
                    CPrice.Text = rdr("CostPrice").ToString
                    CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                    Price.Text = rdr("WsPrice").ToString
                    Price.Text = Format(Val(Price.Text), "0.00").ToString
                    UOM.Text = rdr("UOM").ToString
                    txtType.Text = rdr("IType").ToString
                End If
            Else
                RFID.Text = rdr("AutoID").ToString
                ItemCode.Text = rdr("ItemCode").ToString
                Description.Text = rdr("ItemName").ToString
                CPrice.Text = rdr("CostPrice").ToString
                CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                Price.Text = rdr("SellPrice").ToString
                Price.Text = Format(Val(Price.Text), "0.00").ToString
                UOM.Text = rdr("UOM").ToString
                txtType.Text = rdr("IType").ToString
            End If
        End If
        rdr.Close()
        GRID4.Rows.Clear()
        Panel4.Hide()
        Panel2.Hide()
        Panel1.Show()
        Panel1.Enabled = True
        Qty.Focus()
    End Sub
    Private Sub GRID4_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID4.CellContentDoubleClick
        grddclick(GRID4.Item(0, GRID4.CurrentRow.Index).Value)
        GRID4.Rows.Clear()
        Panel4.Hide()
        Panel2.Hide()
        Panel1.Show()
        Panel1.Enabled = True
        Price.Focus()
    End Sub
    Private Sub GRID4_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID4.KeyDown
        If e.KeyCode = 13 Then
            If GRID4.Rows.Count = 0 Then Return
            grddclick(GRID4.Item(0, GRID4.CurrentRow.Index).Value)
            GRID4.Rows.Clear()
            Panel4.Hide()
            Panel2.Hide()
            Panel1.Show()
            Panel1.Enabled = True
            Price.Focus()
        ElseIf e.KeyCode = 27 Then
            Panel4.Hide()
            Panel2.Hide()
            Panel1.Show()
            Panel1.Enabled = True
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        End If
    End Sub
    Dim xBLQTY As Double = 0
    Dim xPCQty As Double = 0
    Private Sub xSAVE()      '                 
        If PType.Text = "CARD" Then
            Label41.Text = "CARD"
        End If
        Dim xPaidTYP As String = Nothing
        If Val(ByCHQ.Text) > 0 Then
            xPaidTYP = "CHQ"
        Else
            xPaidTYP = "CASH-ONLY"
        End If
        ' INVNo, InvAmnt, InvType, LastUpdate, UName
        If CusName.Text = "" Then
            CusName.Text = "CASH CUSTOMER"
        End If
        cmd = New SqlCommand("Insert Inv_Main values('" & INVNum.Text & "','" & Val(NeTot.Text) & "','" & Label41.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & Val(TenderedAmt.Text) & "','" & Val(ByCHQ.Text) & "','" & xPaidTYP & "','" & CusName.Text & "','" & Val(DiscVal.Text) & "')", con)
        cmd.ExecuteNonQuery()
        For i As Integer = 0 To GRID1.RowCount - 1
            '                                    AutoID,     INVNo,                   RefID,                     ItemCode,                   ItemName,                   Uom,                          CPrice                          SellPrice,                 Qty,                         Amnt,                        LastUpdate,                        UpdTme,                                 UName                  CusCode
            cmd = New SqlCommand("Insert Inv_Sub values('" & INVNum.Text & "','" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(2, i).Value & "','" & GRID1(5, i).Value & "','" & GRID1(3, i).Value & "','" & GRID1(4, i).Value & "','" & GRID1(6, i).Value & "','" & GRID1(7, i).Value & "','" & Format(Now, "yyyy-MM-dd ") & "','" & Format(Now, "H:mm:ss ") & "','" & FrmMDI.UName.Text & "','" & CusCode.Text & "','" & Val(GRID1(10, i).Value) & "')", con)
            cmd.ExecuteNonQuery()
            Dim xSRV As String = "SERVICE"
            Dim xSRV1 As String = "EZY"
            'Stock Update.....................................................................
            'cmd = New SqlCommand("Select * from Stock_Main where AutoId='" & GRID1(0, i).Value & "'", con)
            'rdr = cmd.ExecuteReader
            'If rdr.Read = True Then
            If GRID1(1, i).Value = "SERVICE" Then
            ElseIf GRID1(1, i).Value = "EZY" Then
                'cmd = New SqlCommand("Select * from Stock_Main where(ItemCode='" & "13006" & "')", con)
                'rdr = cmd.ExecuteReader
                'If rdr.Read = True Then
                '    cmd1 = New SqlCommand("Update Stock_Main Set BalanceQty='" & rdr("BalanceQty") + Val(GRID1(6, i).Value) & "',SaleQty='" & rdr("SaleQty") + Val(GRID1(6, i).Value) & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "'where ItemCode='" & rdr("ItemCode") & "'", con1)
                '    cmd1.ExecuteNonQuery()
                'End If
                'rdr.Close()
                'obj.xSettle(0, 0, 0, 0, 0, GRID1(7, i).Value, 0, Format(Now, "yyyy-MM-dd"), FrmMDI.UName.Text, 0, 0)
            Else
                cmd = New SqlCommand("Select * from Stock_Main where AutoID='" & GRID1(0, i).Value & "'", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    Dim xBALL As Double = 0
                    xBALL = rdr("BalanceQty")
                    Dim xVAL As Double = 0
                    xVAL = Val(GRID1(6, i).Value)
                    Dim xSLQ As Double = 0
                    xSLQ = rdr("SaleQty")
                    Dim xQQTY As Double = 0
                    Dim xQQTY1 As Double = 0
                    xQQTY = xBALL - xVAL
                    xQQTY1 = xSLQ + xVAL
                    cmd1 = New SqlCommand("Update Stock_Main Set BalanceQty='" & xQQTY & "',SaleQty='" & xQQTY1 & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "'where AutoID='" & GRID1(0, i).Value & "'", con1)
                    cmd1.ExecuteNonQuery()
                    xBALL = 0
                    xVAL = 0
                    xSLQ = 0
                End If
                rdr.Close()
            End If
            'End If
            'rdr.Close()
        Next
        cmd = New SqlCommand("Select * from Prof_Ws where(LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Update Prof_Ws set CPTot='" & rdr("CPTot") + Val(CostTotal.Text) & "',SPTot='" & rdr("SPTot") + Val(NeTot.Text) & "'where LastUpdate='" & Format(Now, "yyyy-MM-dd") & "' ", con1)
            cmd1.ExecuteNonQuery()
        Else
            '                                                   CPTot,                          SPTot,                  LastUpdate
            cmd1 = New SqlCommand("Insert Prof_Ws values('" & Val(CostTotal.Text) & "','" & Val(NeTot.Text) & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        '[TAX...]
        If Format(Now, "HH:mm:ss") > "12:00" Then
            If Format(Now, "HH:mm:ss") > "18:00" Then
                '====TAX HIDE
                cmd = New SqlCommand("Select * from TaxHide where(LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    cmd1 = New SqlCommand("Update TaxHide set TaxRate='" & 25 & "',TaxAmt='" & rdr("TaxAmt") + (Val(NeTot.Text) / 4) & "'where LastUpdate='" & Format(Now, "yyyy-MM-dd") & "'", con1)
                    cmd1.ExecuteNonQuery()
                Else
                    '                                             TaxRate,              TaxAmt,                     LastUpdate,                         UName
                    cmd1 = New SqlCommand("Insert TaxHide values('" & 100 & "','" & Val(NeTot.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "')", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()
            ElseIf Format(Now, "HH:mm:ss") < "18:00" Then
                '====TAX HIDE
                cmd = New SqlCommand("Select * from TaxHide where(LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    cmd1 = New SqlCommand("Update TaxHide set TaxRate='" & 50 & "',TaxAmt='" & rdr("TaxAmt") + (Val(NeTot.Text) / 2) & "'where LastUpdate='" & Format(Now, "yyyy-MM-dd") & "'", con1)
                    cmd1.ExecuteNonQuery()
                Else
                    '                                             TaxRate,              TaxAmt,                     LastUpdate,                         UName
                    cmd1 = New SqlCommand("Insert TaxHide values('" & 100 & "','" & Val(NeTot.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "')", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()
            End If
        ElseIf Format(Now, "HH:mm:ss") < "12:00" Then
            '====TAX HIDE
            cmd = New SqlCommand("Select * from TaxHide where(LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                cmd1 = New SqlCommand("Update TaxHide set TaxRate='" & 100 & "',TaxAmt='" & rdr("TaxAmt") + Val(NeTot.Text) & "'where LastUpdate='" & Format(Now, "yyyy-MM-dd") & "'", con1)
                cmd1.ExecuteNonQuery()
            Else
                '                                             TaxRate,              TaxAmt,                     LastUpdate,                         UName
                cmd1 = New SqlCommand("Insert TaxHide values('" & 100 & "','" & Val(NeTot.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "')", con1)
                cmd1.ExecuteNonQuery()
            End If
            rdr.Close()
        End If
    End Sub
    Dim xTRUU As Boolean = False
    Dim xITTCD As String = Nothing
    Dim xDTE As Date = Now.ToShortDateString
    Dim xCPRD As String = Nothing
    Dim xBALC As Double = 0
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        '>>>>>>>>>>>>>> 2021-08-10
        Dim paidValue As Double = 0
        Dim invoiceValue As Double = 0
        paidValue = Val(TenderedAmt.Text)
        invoiceValue = Val(NeTot.Text)

        Dim xSaleType As String = Label41.Text
        Select Case xSaleType
            Case "CREDIT"
                If CusCode.Text = "" Then Return
            Case Else
                If Val(TenderedAmt.Text) <= 0 Then Return
                If Val(TenderedAmt.Text) < Val(NeTot.Text) Then Return
        End Select
        If xSaleType = "CREDIT" Then
            If CusCode.Text = "" Then Return
        ElseIf xSaleType = "CASH" Then
            If Val(TenderedAmt.Text) <= 0 Then Return
            If Val(TenderedAmt.Text) < Val(NeTot.Text) Then Return
        End If
        If invoiceValue <= paidValue Then Label41.Text = "CASH" : Label41.BackColor = Color.Green
        '>>>>>>>>>>>>>> 2021-08-10
        Dim xINVS As Boolean = False
        If CusCode.Text <> "" And GRID1.Rows.Count = 0 And Val(TenderedAmt.Text) + Val(ByCHQ.Text) > 0 Then
            xINVS = True
        End If
        If xINVS = False Then
            If GRID1.Rows.Count = 0 Or Val(Total.Text) = 0 Then ItemCode.Focus() : Return
            Dim result11 As DialogResult = MessageBox.Show("Are you sure the Sale ?", "Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If result11 = vbYes Then
                If GridChq.Rows.Count > 0 Then
                    If CusCode.Text = "" Then
                        MessageBox.Show("Please check the Customer Information...!")
                        Return
                    End If
                    For i As Integer = 0 To GridChq.Rows.Count - 1
                        '                                                 INVNo,                   CusCode,          CusName,                    CHQNo,                        ChqDate,                     Bank,                        Amount,                        LastUpdate,                         UpTime,                          UName
                        cmd = New SqlCommand("Insert ChqRcv values('" & INVNum.Text & "','" & CusCode.Text & "','" & CusName.Text & "','" & GridChq(0, i).Value & "','" & GridChq(1, i).Value & "','" & GridChq(2, i).Value & "','" & GridChq(3, i).Value & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "ON-HAND" & "')", con)
                        cmd.ExecuteNonQuery()
                        cmd = New SqlCommand("Select * from BankName where BankName='" & GridChq(2, i).Value & "'", con)
                        rdr = cmd.ExecuteReader
                        If rdr.Read Then
                        Else
                            cmd1 = New SqlCommand("Insert BankName Values('" & GridChq(2, i).Value & "')", con1)
                            cmd1.ExecuteNonQuery()
                        End If
                        rdr.Close()
                    Next
                End If
                cmd = New SqlCommand("Select * from Inv_Main where(INVNo='" & INVNum.Text & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    cmd1 = New SqlCommand("Delete from Inv_Main where(INVNo='" & INVNum.Text & "')", con1)
                    cmd1.ExecuteNonQuery()
                    cmd1 = New SqlCommand("Delete from   Inv_Sub where(INVNo='" & INVNum.Text & "')", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()
                xTRUU = False
                If xTRUU = True Then
                    'MsgBox("Please Check " & "[" & xITTCD & "]" & " Item Qty In Stock Again...!")
                    MessageBox.Show("Please Check [ " & xITTCD & " ] Item Qty In Stock Again...!", "Item Qty Error..", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return
                Else
                    If Label41.Text = "CASH" Then
                        '            CashSales, CreditSales, CashReceipts, SalesReturn, Payments, TotalSls, BalanceAmt, LastUpdate, UName
                        obj.xSettle(Val(NeTot.Text), 0, 0, 0, 0, 0, 0, Format(Now, "yyyy-MM-dd"), FrmMDI.UName.Text, 0, 0)
                        xDayEndUpdate(Format(Now, "yyyy-MM-dd"), Val(NeTot.Text), 0, 0, 0, Val(PaydAmt.Text), 0, 0, 0)
                        '2021-08-10>>>
                        If CusCode.Text <> "" Then
                            '                                                   CusCode,            CusName,                    InvDate,                         Descp,              InvAmnt,                         RcvDate,                  Descr,              RcvAmnt
                            cmd1 = New SqlCommand("Insert CusState values('" & CusCode.Text & "','" & CusName.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Inv" & "','" & invoiceValue & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Rcv" & "','" & Val(TenderedAmt.Text) + Val(ByCHQ.Text) & "')", con1)
                            cmd1.ExecuteNonQuery()
                            '                                                       RcptNo,                      UnitID,                CusCode,             CusName,               RcvAmt,                                         Descrip,                RcvDT,                            RcvTM,        UName                  
                            cmd1 = New SqlCommand("Insert Receipt_Main values('" & INVNum.Text & "RCV" & "','" & UnitID.Text & "','" & CusCode.Text & "','" & CusName.Text & "','" & paidValue & "','" & "Paid" & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con1)
                            cmd1.ExecuteNonQuery()
                            Dim overPaid As Double = 0
                            overPaid = Val(TenderedAmt.Text) - Val(NeTot.Text)
                            cmd1 = New SqlCommand("Update Cus_Master Set CusBalance-='" & overPaid & "'where CusCode='" & CusCode.Text & "'", con1)
                            cmd1.ExecuteNonQuery()
                            '                                AutoID,             CusCode,                CusName,               InvNum,              Amount,                    LastUpdate,                             UpTme,                                          UName
                            cmd1 = New SqlCommand("Insert  Cust_Sub values('" & CusCode.Text & "','" & CusName.Text & "','" & INVNum.Text & "','" & invoiceValue & "','" & Format(Now, "yyyy-MM-dd").ToString & "','" & Format(Now, "H:mm:ss").ToString & "','" & FrmMDI.UName.Text & "')", con1)
                            cmd1.ExecuteNonQuery()
                            If overPaid > 0 Then
                                xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, overPaid, 0, 0, 0, 0, 0, 0)
                            End If
                            '2021-08-10>>>
                        End If
                    ElseIf Label41.Text = "CREDIT" Then
                        If CusCode.Text.Trim(" ") = "" Then Return
                        cmd = New SqlCommand("Select * from Cus_Master where(CusCode='" & CusCode.Text & "')", con)
                        rdr = cmd.ExecuteReader
                        Dim Rcet As Double = 0
                        If Val(TenderedAmt.Text) > 0 Then
                            If Val(NeTot.Text) < Val(TenderedAmt.Text) Then
                                Rcet = Val(TenderedAmt.Text) - Val(NeTot.Text)
                            ElseIf Val(TenderedAmt.Text) < Val(NeTot.Text) Then
                                Rcet = Val(TenderedAmt.Text)
                            End If
                            '                                                       RcptNo,                      UnitID,                CusCode,             CusName,               RcvAmt,                                         Descrip,                RcvDT,                            RcvTM,        UName                  
                            cmd1 = New SqlCommand("Insert Receipt_Main values('" & INVNum.Text & "RCV" & "','" & UnitID.Text & "','" & CusCode.Text & "','" & CusName.Text & "','" & Rcet & "','" & "Paid" & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con1)
                            cmd1.ExecuteNonQuery()
                        End If
                        '                                                   CusCode,            CusName,                    InvDate,                         Descp,              InvAmnt,                         RcvDate,                   Descr,              RcvAmnt
                        cmd1 = New SqlCommand("Insert CusState values('" & CusCode.Text & "','" & CusName.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Inv" & "','" & Val(NeTot.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Rcv" & "','" & Val(TenderedAmt.Text) + Val(ByCHQ.Text) & "')", con1)
                        cmd1.ExecuteNonQuery()
                        '------------------------------------------
                        If rdr.Read = True Then
                            xCPRD = rdr("CreditPeriod").ToString
                            xBALC = rdr("CusBalance").ToString
                            If xBALC = 0 Then
                                cmd1 = New SqlCommand("update Cus_Master Set DueDate='" & xDTE.AddDays(xCPRD) & "',CusBalance='" & xBALC + (Val(NeTot.Text) - (Val(TenderedAmt.Text) + Val(ByCHQ.Text))) & "' where CusCode='" & CusCode.Text & "'", con1)
                                cmd1.ExecuteNonQuery()
                            Else
                                cmd1 = New SqlCommand("update Cus_Master set CusBalance='" & xBALC + (Val(NeTot.Text) - (Val(TenderedAmt.Text) + Val(ByCHQ.Text))) & "' where CusCode='" & CusCode.Text & "'", con1)
                                cmd1.ExecuteNonQuery()
                            End If
                            '                                AutoID,             CusCode,                CusName,               InvNum,              Amount,                    LastUpdate,                             UpTme,                                          UName
                            cmd1 = New SqlCommand("Insert  Cust_Sub values('" & CusCode.Text & "','" & CusName.Text & "','" & INVNum.Text & "','" & Val(NeTot.Text) & "','" & Format(Now, "yyyy-MM-dd").ToString & "','" & Format(Now, "H:mm:ss").ToString & "','" & FrmMDI.UName.Text & "')", con1)
                            cmd1.ExecuteNonQuery()
                        End If
                        rdr.Close()
                        obj.xSettle(0, Val(NeTot.Text), Val(TenderedAmt.Text), 0, 0, 0, 0, Format(Now, "yyyy-MM-dd"), FrmMDI.UName.Text, 0, 0)
                        Dim Amnt As Double = 0
                        If Val(TenderedAmt.Text) > 0 Then
                            If Val(NeTot.Text) < Val(TenderedAmt.Text) Then
                                Amnt = Val(TenderedAmt.Text) - Val(NeTot.Text)
                                xDayEndUpdate(Format(Now, "yyyy-MM-dd"), Val(NeTot.Text), Amnt, 0, 0, 0, Val(PaydAmt.Text), 0, 0)
                            ElseIf Val(TenderedAmt.Text) < Val(NeTot.Text) Then
                                xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, Val(TenderedAmt.Text), 0, 0, 0, Val(PaydAmt.Text), 0, 0)
                            End If
                        ElseIf Val(TenderedAmt.Text) = 0 Then
                            xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, Val(TenderedAmt.Text), 0, 0, 0, Val(PaydAmt.Text), 0, 0)
                        End If
                    ElseIf Label41.Text = "WHOLE SALE" Then
                        Dim result1 As DialogResult = MessageBox.Show("Credit Whole Sale ?", "Payment Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If result1 = vbYes Then
                            If CusCode.Text = "" Then
                                MsgBox("Please Select a Credit Customer and try", MsgBoxStyle.Information, "Credit Wholesale")
                                Panel1.Enabled = False
                                Panel6.Show()
                                txtCsCode_TextChanged(sender, EventArgs.Empty)
                                txtCsCode.Focus()
                                Return
                                'MsgBox("Please Select a Credit Customer", "Credit Wholesale", MessageBoxIcon.Stop)
                            End If
                            cmd = New SqlCommand("Select * from Cus_Master where(CusCode='" & CusCode.Text & "')", con)
                            rdr = cmd.ExecuteReader
                            '------------------------------------------
                            If rdr.Read = True Then
                                cmd1 = New SqlCommand("update Cus_Master set CusBalance='" & xBALC + (Val(NeTot.Text) - Val(TenderedAmt.Text)) & "' where CusCode='" & CusCode.Text & "'", con1)
                                cmd1.ExecuteNonQuery()
                                '                                AutoID,             CusCode,                CusName,               InvNum,              Amount,                    LastUpdate,                             UpTme,                                          UName
                                cmd1 = New SqlCommand("Insert  Cust_Sub values('" & CusCode.Text & "','" & CusName.Text & "','" & INVNum.Text & "','" & Val(NeTot.Text) & "','" & Format(Now, "yyyy-MM-dd").ToString & "','" & Format(Now, "H:mm:ss").ToString & "','" & FrmMDI.UName.Text & "')", con1)
                                cmd1.ExecuteNonQuery()
                                If Val(TenderedAmt.Text) > 0 Then
                                    '                                                       RcptNo,                      UnitID,                CusCode,             CusName,                RcvAmt,                        Descrip,                RcvDT,                            RcvTM,        UName                  
                                    cmd1 = New SqlCommand("Insert Receipt_Main values('" & INVNum.Text & "RCV" & "','" & UnitID.Text & "','" & CusCode.Text & "','" & CusName.Text & "','" & Val(TenderedAmt.Text) + Val(ByCHQ.Text) & "','" & "Paid" & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con1)
                                    cmd1.ExecuteNonQuery()
                                End If
                                '                                                   CusCode,            CusName,                    InvDate,                         Descp,              InvAmnt,                         RcvDate,                   Descr,              RcvAmnt
                                cmd1 = New SqlCommand("Insert CusState values('" & CusCode.Text & "','" & CusName.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Inv" & "','" & Val(NeTot.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Rcv" & "','" & Val(TenderedAmt.Text) & "')", con1)
                                cmd1.ExecuteNonQuery()
                            End If
                            rdr.Close()
                            obj.xSettle(0, Val(NeTot.Text), Val(TenderedAmt.Text), 0, 0, 0, Val(NeTot.Text), Format(Now, "yyyy-MM-dd"), FrmMDI.UName.Text, 0, 0)
                            xDayEndUpdate(Format(Now, "yyyy-MM-dd"), Val(TenderedAmt.Text), 0, 0, 0, Val(PaydAmt.Text), 0, 0, 0)
                        Else
                            obj.xSettle(Val(NeTot.Text), 0, 0, 0, 0, 0, Val(NeTot.Text), Format(Now, "yyyy-MM-dd"), FrmMDI.UName.Text, 0, 0)
                            xDayEndUpdate(Format(Now, "yyyy-MM-dd"), Val(NeTot.Text), 0, 0, 0, Val(PaydAmt.Text), 0, 0, 0)
                        End If
                    End If
                    xSAVE()
                    'Delete Hold Sale
                    DeleteHoldSale(TSnId.Text)
                    obj.xSettle(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Val(CrdAmnt.Text) + Val(CardInterest.Text))
                    '***************************************
                    cmd = New SqlCommand("Select * from InvGen where(UnitId='" & UnitID.Text & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
                    rdr = cmd.ExecuteReader
                    If rdr.Read = True Then
                        cmd1 = New SqlCommand("Update InvGen set INV='" & rdr("INV") + 1 & "'where UnitId='" & UnitID.Text & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "'", con1)
                        cmd1.ExecuteNonQuery()
                    End If
                    rdr.Close()
                    'Stock Update.....................................................................
                End If
                cmd = New SqlCommand("Select * from Stock_Main  order by ItemCode", con)
                rdr = cmd.ExecuteReader
                GRID5.Rows.Clear()
                While rdr.Read
                    GRID5.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("BalanceQty"), rdr("IType"))
                End While
                rdr.Close()
                'cmd = New SqlCommand("Delete from TempInv_Main where AutoID='" & TSnId.Text & "'", con)
                'cmd.ExecuteNonQuery()
                'cmd = New SqlCommand("Delete from TempInv_Sub where RefId='" & TSnId.Text & "'", con)
                'cmd.ExecuteNonQuery()
                If CusCode.Text = "" Then
                Else
                    Dim pig As Double = Val(TenderedAmt.Text) + Val(ByCHQ.Text)
                    SaveInvBal(INVNum.Text, Val(NeTot.Text), pig, pig - Val(NeTot.Text), CusBalance.Text)
                End If
                Dim result2 As DialogResult = MessageBox.Show("Want to  Print Invoice.?", "Print Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result2 = vbYes Then

                    StartPrint()
                    If prn.PrinterIsOpen = True Then

                        PrintHeader11()
                        PrintBody()
                        PrintFooter()
                        EndPrint()

                    End If
                    PrintInvoice()
                ElseIf vbNo Then
                    PrintInvoice()
                End If

                Panel3.Show()
                Panel1.Enabled = False
                txtinv1.Text = INVNum.Text
                txtTotalAmt.Text = Total.Text
                txtdisP.Text = Discnt.Text
                txtDisAm.Text = DiscVal.Text
                txtNtot.Text = NeTot.Text
                txtTender.Text = TenderedAmt.Text
                txtBal.Text = BalAmt.Text
                ByCaard.Text = TenderedAmt.Text
                ByCaard.Text = Format(Val(ByCaard.Text), "0.00")
                ByCaash.Text = ByCHQ.Text
                ByCaash.Text = Format(Val(ByCaash.Text), "0.00")
                CANCELSALE(1)
                FrmCashier_Resize(sender, EventArgs.Empty)
                Panel3.BringToFront()
                txtTotalAmt.Focus()
                txtTotalAmt.SelectAll()
                txtTotalAmt.Focus()
            End If
        ElseIf xINVS = True Then
            Dim result11 As DialogResult = MessageBox.Show("Are you sure the Receipt ?", "CHQ / CASH RECEIPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If result11 = vbYes Then
                If CusCode.Text = "" Then MsgBox("Please Define a Customer and try again...!") : Return
                Dim xCheq As String = Nothing
                For Each row As DataGridViewRow In GridChq.Rows
                    xCheq &= row.Cells(0).Value & " - "
                    '                                                   INVNo,             CusCode,                 CusName,                CHQNo,                      ChqDate,                     Bank,                           Amount,                LastUpdate,                             UpTime,                         UName,                      Status
                    cmd = New SqlCommand("Insert ChqRcv values('" & INVNum.Text & "','" & CusCode.Text & "','" & CusName.Text & "','" & row.Cells(0).Value & "','" & row.Cells(1).Value & "','" & row.Cells(2).Value & "','" & row.Cells(3).Value & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "ON-HAND" & "')", con)
                    cmd.ExecuteNonQuery()
                Next
                If Val(TenderedAmt.Text) > 0 Then
                    '                                                       RcptNo,                      UnitID,                CusCode,             CusName,                RcvAmt,                        Descrip,                RcvDT,                            RcvTM,                         UName                  
                    cmd = New SqlCommand("Insert Receipt_Main values('" & INVNum.Text & "RCV" & "','" & UnitID.Text & "','" & CusCode.Text & "','" & CusName.Text & "','" & Val(TenderedAmt.Text) & "','" & "Paid" & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                    cmd.ExecuteNonQuery()
                    xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, Val(TenderedAmt.Text), 0, 0, 0, 0, 0, 0)
                End If
                cmd = New SqlCommand("Update Cus_Master Set CusBalance-='" & Val(ByCHQ.Text) + Val(TenderedAmt.Text) & "'where CusCode='" & CusCode.Text & "'", con)
                cmd.ExecuteNonQuery()
                '                                                   CusCode,            CusName,                    InvDate,                         Descp,      InvAmnt         RcvDate,                       Descr,              RcvAmnt
                cmd = New SqlCommand("Insert CusState values('" & CusCode.Text & "','" & CusName.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Rcv " & xCheq & "','" & Val(TenderedAmt.Text) + Val(ByCHQ.Text) & "')", con)
                cmd.ExecuteNonQuery()
                '***************************************
                cmd = New SqlCommand("Select * from InvGen where(UnitId='" & UnitID.Text & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    cmd1 = New SqlCommand("Update InvGen set INV='" & rdr("INV") + 1 & "'where UnitId='" & UnitID.Text & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "'", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()
                MessageBox.Show("CHQ / CASH RECEIPT Succeed...!", "CHQ / CASH RECEIPT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Dim result12 As DialogResult = MessageBox.Show("Do you want to Print Receipt ?", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If result12 = vbYes Then
                    StartPrint()
                    If prn.PrinterIsOpen = True Then
                        PrintRCP(INVNum.Text, CusName.Text)
                        cmd = New SqlCommand("Select sum(CusBalance) from Cus_Master where(CusCode='" & CusCode.Text & "')", con)
                        Dim xAMBT As Double = cmd.ExecuteScalar
                        Dim txtB As New TextBox
                        txtB.Text = xAMBT
                        txtB.Text = Format(Val(txtB.Text), "0.00")
                        PrintRcpBody(Val(ByCHQ.Text) + Val(TenderedAmt.Text), txtB.Text)
                        EndPrint()
                    End If
                End If
            End If
            CANCELSALE(1)
        End If
    End Sub
    Private Sub DeleteHoldSale(ByVal HoldedId As String)
        cmd = New SqlCommand("Delete from TempInv_Main where(AutoID='" & HoldedId & "')", con)
        cmd.ExecuteNonQuery()
        cmd = New SqlCommand("Delete from TempInv_Sub where(RefId='" & HoldedId & "')", con)
        cmd.ExecuteNonQuery()

    End Sub
    Private Sub ItCode_GotFocus(sender As Object, e As EventArgs) Handles ItCode.GotFocus
        ItCode.BackColor = Color.Yellow
    End Sub
    Private Sub ItCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItCode.KeyDown
        If e.KeyCode = Keys.Down Then
            GRID5.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            Discnt.Focus()
            Discnt.Clear()
            Discnt.Text = "0"
            Discnt.Clear()
        ElseIf e.KeyCode = Keys.Right Then
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel6.Show()
            Panel1.Enabled = False
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel5.Show()
            Panel1.Enabled = False
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        ElseIf e.KeyCode = 13 Then
            ItName.Text = ItCode.Text
            xITM(ItCode.Text)
            ItName.SelectAll()
        End If
    End Sub
    Private Sub ItCode_LostFocus(sender As Object, e As EventArgs) Handles ItCode.LostFocus
        ItCode.BackColor = Nothing
    End Sub
    Private Sub ItCode_TextChanged(sender As Object, e As EventArgs) Handles ItCode.TextChanged
        If ItCode.Text = "" Then
            cmd = New SqlCommand("Select * from Stock_Main  order by ItemCode", con)
        Else
            cmd = New SqlCommand("Select * from Stock_Main where ItemCode Like '" & ItCode.Text & "%'  ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID5.Rows.Clear()
        While rdr.Read
            GRID5.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("BalanceQty"), rdr("IType"), False)
        End While
        rdr.Close()
        'GRID5.ClearSelection()
        'GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
    End Sub
    Private Sub ItName_GotFocus(sender As Object, e As EventArgs) Handles ItName.GotFocus
        ItName.BackColor = Color.Yellow
    End Sub
    Private Sub ItName_KeyDown(sender As Object, e As KeyEventArgs) Handles ItName.KeyDown
        If e.KeyCode = Keys.Down Then
            GRID5.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            'Discnt.Focus()
            'Discnt.Clear()
            'Discnt.Text = "0"
            'Discnt.Clear()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.Right Then
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        ElseIf e.KeyCode = 27 Then
            ItName.Clear()
        ElseIf e.KeyCode = 13 Then
            xITM(ItName.Text)
            ' ItemCode.Focus()
        End If
    End Sub
    Private Sub ItName_LostFocus(sender As Object, e As EventArgs) Handles ItName.LostFocus
        ItName.BackColor = Nothing
    End Sub
    Private Sub ItName_TextChanged(sender As Object, e As EventArgs) Handles ItName.TextChanged
        If ItName.Text = "" Then
            cmd = New SqlCommand("Select * from Stock_Main  order by ItemCode", con)
        Else
            cmd = New SqlCommand("Select * from Stock_Main where ItemName like '%" & ItName.Text & "%'  ", con)
        End If
        rdr = cmd.ExecuteReader
        Dim xDG As New ArrayList
        Dim xDG1 As New ArrayList
        Dim xDG2 As New ArrayList
        Dim xDG3 As New ArrayList
        Dim xDG4 As New ArrayList
        While rdr.Read
            xDG.Add(rdr("AutoID"))
            xDG1.Add(rdr("ItemCode"))
            xDG2.Add(rdr("ItemName"))
            xDG3.Add(rdr("BalanceQty"))
            xDG4.Add(rdr("IType"))
            xDG4.Add(False)
            'GRID5.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("BalanceQty"), rdr("IType"))
        End While
        rdr.Close()
        GRID5.Rows.Clear()
        GRID5.Refresh()
        For i = 0 To xDG.Count - 1
            GRID5.Rows.Add(xDG.Item(i), xDG1.Item(i), xDG2.Item(i), xDG3.Item(i), xDG4.Item(i), False)
        Next
        'GRID5.ClearSelection()
        'For i = 0 To GRID5.Rows.Count - 1
        '    GRID5.Rows(i).DefaultCellStyle.BackColor = Color.White
        'Next
    End Sub
    Dim xGno As Integer = 0
    Private Sub GRID5_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID5.CellContentDoubleClick
        xxITC(GRID5.Item(0, GRID5.CurrentRow.Index).Value)
        xGno = (e.RowIndex)
        GRID5.ClearSelection()
        GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        Price.Focus()
    End Sub
    Private Sub ItemCode_LostFocus(sender As Object, e As EventArgs) Handles ItemCode.LostFocus
        ItemCode.BackColor = Nothing
    End Sub
    Private Sub TenderedAmt_GotFocus(sender As Object, e As EventArgs) Handles TenderedAmt.GotFocus
        TenderedAmt.BackColor = Color.Yellow
    End Sub
    Private Sub TenderedAmt_KeyDown(sender As Object, e As KeyEventArgs) Handles TenderedAmt.KeyDown
        If e.KeyCode = 13 Then
            If GRID1.Rows.Count > 0 Then
                CmdSave.Focus()
            ElseIf GRID1.Rows.Count = 0 Then
                If Val(TenderedAmt.Text) > 0 Then
                    CmdSave.Focus()
                Else
                    ItemCode.Focus()
                End If

            End If
            'ElseIf e.KeyCode = Keys.F2 Then
            '    StartPrint()
            '    If prn.PrinterIsOpen = True Then
            '        PrintFooter1()
            '        EndPrint()
            '    End If
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
            'ElseIf e.KeyCode = Keys.Up Then
            '    TenderedAmt.Clear()
            '    PType.Focus()
            '    PType.BackColor = Color.Yellow
            'ElseIf e.KeyCode = Keys.Left Then
            '    Discnt.Focus()
            '    Discnt.Clear()
            '    Discnt.Text = "0"
            '    Discnt.Clear()
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
            'ElseIf e.KeyCode = Keys.F9 Then
            '    Label41.Text = "WHOLE SALE"
            '    Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()

        End If
    End Sub
    Private Sub TenderedAmt_LostFocus(sender As Object, e As EventArgs) Handles TenderedAmt.LostFocus
        TenderedAmt.BackColor = Nothing
    End Sub
    Private Sub TenderedAmt_TextChanged(sender As Object, e As EventArgs) Handles TenderedAmt.TextChanged
        BalAmt.Text = (Val(ByCHQ.Text) + Val(TenderedAmt.Text)) - Val(NeTot.Text)
        BalAmt.Text = Format(Val(BalAmt.Text), "0.00").ToString
    End Sub
    Private Sub xxITC(ByVal xEEE As String)
        cmd = New SqlCommand("Select * from Stock_Main where(AutoId='" & xEEE & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            If Label41.Text = "WHOLE SALE" Then
                If rdr("WsPrice") = 0 Then
                    RFID.Text = rdr("AutoId").ToString
                    ItemCode.Text = rdr("ItemCode").ToString
                    Description.Text = rdr("ItemName").ToString
                    Price.Text = rdr("WsPrice").ToString
                    ItemPriceS = rdr("WsPrice")
                    Price.Text = Format(Val(Price.Text), "0.00").ToString
                    CPrice.Text = rdr("CostPrice").ToString
                    CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                    UOM.Text = rdr("UOM").ToString
                    txtType.Text = rdr("IType").ToString
                Else
                    RFID.Text = rdr("AutoId").ToString
                    ItemCode.Text = rdr("ItemCode").ToString
                    Description.Text = rdr("ItemName").ToString
                    Price.Text = rdr("WsPrice").ToString
                    ItemPriceS = rdr("WsPrice")
                    Price.Text = Format(Val(Price.Text), "0.00").ToString
                    CPrice.Text = rdr("CostPrice").ToString
                    CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                    UOM.Text = rdr("UOM").ToString
                    txtType.Text = rdr("IType").ToString
                End If
            ElseIf Label41.Text = "CASH" Or Label41.Text = "CREDIT" Then
                RFID.Text = rdr("AutoId").ToString
                ItemCode.Text = rdr("ItemCode").ToString
                Description.Text = rdr("ItemName").ToString
                Price.Text = rdr("SellPrice").ToString
                Price.Text = Format(Val(Price.Text), "0.00").ToString
                ItemPriceS = rdr("SellPrice")
                CPrice.Text = rdr("CostPrice").ToString
                CPrice.Text = Format(Val(CPrice.Text), "0.00").ToString
                UOM.Text = rdr("UOM").ToString
                txtType.Text = rdr("IType").ToString
            End If
        End If
        rdr.Close()
        Price.Focus()
    End Sub
    Dim xWER As Integer = 0
    Dim ItemPriceS As Double = 0
    Private Sub HoldInvv()
        cmd = New SqlCommand("Delete  from TempInv_Sub where RefID='" & TSnId.Text & "'", con)
        cmd.ExecuteNonQuery()
        For i As Integer = 0 To GRID1.RowCount - 1
            '                                      AutoID,      RefID,                    UnitID,               IRefID,                      ItemCode,                    ItemName,                      Uom,                     CostPrice,                 SellPrice,                   Qty,                    Amnt,                                                           LastUpdate,                                 UName
            cmd = New SqlCommand("Insert TempInv_Sub values('" & TSnId.Text & "','" & UnitID.Text & "','" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(2, i).Value & "','" & GRID1(5, i).Value & "','" & GRID1(3, i).Value & "','" & GRID1(4, i).Value & "','" & GRID1(6, i).Value & "','" & GRID1(7, i).Value & "','" & GRID1(10, i).Value & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
            cmd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub HOLDSALE()
        If INVNum.Text = "" Or GRID1.RowCount = 0 Then Return
        cmd1 = New SqlCommand("Select * from TempInv_Main where(AutoID='" & TSnId.Text & "')", con1)
        rdr1 = cmd1.ExecuteReader
        If rdr1.Read = True Then
            cmd = New SqlCommand("Update TempInv_Main set Amnt='" & Total.Text & "',LastUpdate='" & Format(Now, "yyyy/MM/dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "'where AutoID='" & TSnId.Text & "'", con)
            cmd.ExecuteNonQuery()
            HoldInvv()
        Else
            '                                    AutoID,             UnitID,             Amnt,                  Status,             LastUpdate,                                  UName
            cmd = New SqlCommand("Insert TempInv_Main values('" & UnitID.Text & "','" & Total.Text & "','" & "Pending" & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "')", con)
            cmd.ExecuteNonQuery()
            'SELECT TOP 1 * FROM MyTable ORDER BY MyColumn DESC
            '  SELECT * FROM    TempInv_Main WHERE   AutoID = (SELECT MAX(AutoID)  FROM TempInv_Main)
            cmd = New SqlCommand("Select MAX(AutoID) from TempInv_Main", con)
            Dim gg As Integer = cmd.ExecuteScalar
            'cmd = New SqlCommand("SELECT TOP 1 * FROM TempInv_Main ORDER BY AutoID DESC", con)
            'rdr = cmd.ExecuteReader
            'If rdr.Read = True Then
            '    xWER = rdr("AutoID")
            'End If
            'rdr.Close()
            For i As Integer = 0 To GRID1.RowCount - 1
                '                                      AutoID,      RefID,           UnitID,               IRefID,                      ItemCode,                    ItemName,                      Uom,                     CostPrice,                 SellPrice,                   Qty,                    Amnt,                              LastUpdate,                                 UName
                cmd = New SqlCommand("Insert TempInv_Sub values('" & gg & "','" & UnitID.Text & "','" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(2, i).Value & "','" & GRID1(5, i).Value & "','" & GRID1(3, i).Value & "','" & GRID1(4, i).Value & "','" & GRID1(6, i).Value & "','" & GRID1(7, i).Value & "','" & GRID1(10, i).Value & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                cmd.ExecuteNonQuery()
            Next
        End If
        rdr1.Close()
        RFID.Clear()
        CPrice.Clear()
        ItemCode.Clear()
        Description.Clear()
        Price.Clear()
        'UOM.Clear()
        Qty.Clear()
        LineTot.Clear()
        txtType.Clear()
        GRID1.Rows.Clear()
        Total.Clear()
        NeTot.Clear()
        TenderedAmt.Clear()
        ItemCode.Focus()
    End Sub
    Private Sub RECALLSALE()
        dtpOld.Value = Now.Date
        Panel1.Enabled = False
        Panel4.Hide()
        Panel2.Show()
        Panel2.BringToFront()
        Panel2.Enabled = True
        cmd = New SqlCommand("Select * from TempInv_Main where (Status='" & "Pending" & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')order by AutoID DESC", con)
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("AutoID"), Format(rdr("Amnt"), "0.00"), rdr("Status"))
        End While
        rdr.Close()
        GRID2.Focus()
        GRID6.Rows.Clear()
    End Sub
    Private Sub REFRESH1()
        cmd = New SqlCommand("Select * from TempInv_Main where (Status='" & "Pending" & "'and LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')order by AutoID DESC", con)
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("AutoID"), Format(rdr("Amnt"), "0.00"), rdr("Status"))
        End While
        rdr.Close()
    End Sub
    Private Sub xCLOSE()
        Panel1.Enabled = True
        Panel4.Hide()
        Panel2.Hide()
        ItemCode.Focus()
    End Sub
    Private Sub GRID2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentClick
        cmd = New SqlCommand("Select * from TempInv_Sub where(RefId='" & GRID2.Item(0, GRID2.CurrentRow.Index).Value & "')", con)
        rdr = cmd.ExecuteReader
        GRID6.Rows.Clear()
        While rdr.Read
            GRID6.Rows.Add(rdr("AutoID"), rdr("RefID"), rdr("UnitID"), rdr("IRefID"), rdr("ItemCode"), rdr("ItemName"), rdr("Uom"), rdr("CostPrice"), rdr("SellPrice"), rdr("Qty"), rdr("Amnt"), rdr("xType"))
        End While
        rdr.Close()
    End Sub
    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        cmd = New SqlCommand("Select * from TempInv_Main where(AutoID='" & GRID2.Item(0, GRID2.CurrentRow.Index).Value & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            TSnId.Text = rdr("AutoId").ToString
            Total.Text = rdr("Amnt").ToString
            Total.Text = Format(Val(Total.Text), "0.00")
            cmd1 = New SqlCommand("Select * from TempInv_sub where(RefId='" & TSnId.Text & "')", con1)
            rdr1 = cmd1.ExecuteReader
            GRID1.Rows.Clear()
            While rdr1.Read
                GRID1.Rows.Add(rdr1("IRefID"), rdr1("ItemCode"), rdr1("ItemName"), rdr1("CostPrice"), Format(rdr1("SellPrice"), "0.00"), rdr1("Uom"), rdr1("Qty"), Format(rdr1("Amnt"), "0.00"), "", "", rdr1("xType"))
            End While
            rdr1.Close()
        End If
        rdr.Close()
        cmd = New SqlCommand("Select sum(xType*Qty)from TempInv_sub where(RefId='" & TSnId.Text & "')", con)
        Dim xDiscounts As Double = cmd.ExecuteScalar
        DiscVal.Text = xDiscounts
        DiscVal.Text = Format(Val(DiscVal.Text), "0.00")

        lblItems.Text = GRID1.Rows.Count
        Panel2.Hide()
        Panel1.Enabled = True
        ItemCode.Focus()
        For i = 0 To GRID1.Rows.Count - 1
            GRID1.Rows(i).Height = 35
        Next

    End Sub
    Private Sub CANCELSALE(ByVal g As Integer)
        If g = 0 Then
            Dim result1 As DialogResult = MessageBox.Show("Do you want to Cancel This Sale ?", "Cancel Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                CusCode.Clear()
                CrdtLmt.Clear()
                CusName.Clear()
                CusBalance.Clear()
                CanGv.Clear()
                CPrice.Clear()
                RFID.Clear()
                TSnId.Clear()
                PayFor.Clear()
                PaydAmt.Clear()
                ItemCode.Clear()
                RFID.Clear()
                CPrice.Clear()
                ItemCode.Clear()
                Description.Clear()
                Price.Clear()
                'UOM.Clear()
                Qty.Clear()
                LineTot.Clear()
                CLTot.Clear()
                GRID1.Rows.Clear()
                ' NeTot.BackColor = Nothing
                CostTotal.Clear()
                Label41.Text = "CASH"
                Label41.BackColor = Color.Green
                DiscVal.Clear()
                Discnt.Clear()
                Total.Clear()
                NeTot.Clear()
                TenderedAmt.Clear()
                BalAmt.Clear()
                Discnt.Clear()
                Discnt.Text = "0"
                Discnt.Clear()
                txtType.Clear()
                txtPay.Clear()
                lblItems.Text = "00"
                ItemPriceS = 0
                QtyInHand.Clear()
                'lblPaid.Text = "0.00"
                For i = 0 To GRID5.Rows.Count - 1
                    GRID5(5, i).Value = False
                Next
                'xUNIT()
                aNUM()
                txtMOR.Clear()
                PType.BackColor = Color.LightGreen
                PType.Text = "CASH"
                LBLTYPE.Text = "CASH"
                LBLTYPE.BackColor = Color.LightGreen
                CrdAmnt.Clear()
                CrdNO.Clear()
                ByCHQ.Text = "0.00"
                CardInterest.Clear()
                XC = False
                ItCode.Clear()
                ItName.Clear()
                Prf.Clear()
                xGdr = 0
                xGdrGet = False
                ' ItemCode.Focus()
                DTP2.Value = Format(Now, "yyyy-MM-dd")
                CHQNo.Clear()
                ChqVal.Clear()
                GridChq.Rows.Clear()

                DisValue100.Clear()

                xAcountLoad1(CmbAccount)
                BankLoad()
                SupLoad()
                PaySup.Clear()
                DepositedAmount.Clear()
                Panel1.Enabled = True
                BankLoad1()
                txtTotalCr.Clear()
                chk1.Checked = False
                ItemCode.Focus()

            End If
        Else
            CusCode.Clear()
            CrdtLmt.Clear()
            CusName.Clear()
            CusBalance.Clear()
            CanGv.Clear()
            CPrice.Clear()
            RFID.Clear()
            TSnId.Clear()
            PayFor.Clear()
            PaydAmt.Clear()
            ItemCode.Clear()
            RFID.Clear()
            CPrice.Clear()
            ItemCode.Clear()
            Description.Clear()
            Price.Clear()
            'UOM.Clear()
            Qty.Clear()
            LineTot.Clear()
            CLTot.Clear()
            GRID1.Rows.Clear()
            ' NeTot.BackColor = Nothing
            CostTotal.Clear()
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
            DiscVal.Clear()
            Discnt.Clear()
            Total.Clear()
            NeTot.Clear()
            TenderedAmt.Clear()
            BalAmt.Clear()
            Discnt.Clear()
            Discnt.Text = "0"
            Discnt.Clear()
            txtType.Clear()
            txtPay.Clear()
            lblItems.Text = "00"
            ItemPriceS = 0
            QtyInHand.Clear()
            'lblPaid.Text = "0.00"
            For i = 0 To GRID5.Rows.Count - 1
                GRID5(5, i).Value = False
            Next
            'xUNIT()
            aNUM()
            txtMOR.Clear()
            PType.BackColor = Color.LightGreen
            PType.Text = "CASH"
            LBLTYPE.Text = "CASH"
            LBLTYPE.BackColor = Color.LightGreen
            CrdAmnt.Clear()
            CrdNO.Clear()
            ByCHQ.Text = "0.00"
            CardInterest.Clear()
            XC = False
            ItCode.Clear()
            ItName.Clear()
            Prf.Clear()
            xGdr = 0
            xGdrGet = False
            ' ItemCode.Focus()
            DTP2.Value = Format(Now, "yyyy-MM-dd")
            CHQNo.Clear()
            ChqVal.Clear()
            GridChq.Rows.Clear()

            DisValue100.Clear()

            xAcountLoad1(CmbAccount)
            BankLoad()
            SupLoad()
            PaySup.Clear()
            DepositedAmount.Clear()
            Panel1.Enabled = True
            BankLoad1()
            txtTotalCr.Clear()
            chk1.Checked = False
            ItemCode.Focus()
        End If



        'GRID5.ClearSelection()
        '' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        'For i As Integer = 0 To GRID5.Rows.Count - 1
        '    GRID5.Rows(i).DefaultCellStyle.BackColor = Color.White
        'Next
    End Sub
    Private Sub PaydAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PaydAmt.KeyDown
        If e.KeyCode = 13 Then
            If PaydAmt.Text = "" Or PayFor.Text = "" Or CmbAccount.Text = "" Then Return
            Dim result1 As DialogResult = MessageBox.Show("Are you sure the Payment for ?", "Payment Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result1 = vbYes Then
                '   AutoID,                                                          Description,                Amnt, LastUpdate, UName
                cmd = New SqlCommand("Insert Pay_Master values('" & CmbAccount.Text & "','" & PayFor.Text & "','" & PaydAmt.Text & "','" & Format(Now, "yyyy-MM-dd").ToString & "','" & FrmMDI.UName.Text & "')", con)
                cmd.ExecuteNonQuery()
                'If PayFor.Text = "Credit Paid" Then
                '    '                                                           CusName,            Refrence,    CreditAmt,                  LastUpdate,                 Reference1,             CreditPaid,                 PayDate
                '    cmd = New SqlCommand("Insert Credit_Taken values('" & CmbAccount.Text & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & PayFor.Text & "','" & Val(PaydAmt.Text) & "','" & Format(Now, "yyyy-MM-dd") & "')", con)
                '    cmd.ExecuteNonQuery()
                'End If
                ' CashSales, CreditSales, CashReceipts, SalesReturn, Payments, BalanceAmt, LastUpdate, UName
                obj.xSettle(0, 0, 0, 0, Val(PaydAmt.Text), 0, 0, Format(Now, "yyyy-MM-dd"), FrmMDI.UName.Text, 0, Val(CrdAmnt.Text))
                xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, 0, 0, 0, Val(PaydAmt.Text), 0, 0, 0)
                If PayFor.Text.ToUpper().Contains("CREDIT PAID") Then
                    Dim result2 As DialogResult = MessageBox.Show("Do you want to print...?", "Payment Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If result2 = vbYes Then
                        StartPrint()
                        If prn.PrinterIsOpen = True Then
                            PrintDashes()
                            Print(eCentre + COMMAND)
                            Print(eBigCharOn + eCentre + "HAMEED MART" + eLeft)
                            Print(eBigCharOff + "7/1, Kandy RD, Gelioya")
                            Print("Tel:0812 310 299 / 0768 010 132" + eInit)
                            PrintDashes()
                            Print(eCentre + eNmlText + "Account: " + essd + CmbAccount.Text)
                            Dim xInte As Integer = 0
                            Dim xCreditTaken As Double = 0
                            Dim xCreditPaid As Double = 0
                            cmd = New SqlCommand("Select count(CusName) from Credit_Taken where CusName='" & CmbAccount.Text & "'", con)
                            xInte = cmd.ExecuteScalar
                            If xInte > 0 Then
                                cmd = New SqlCommand("Select sum(CreditAmt) from Credit_Taken where CusName='" & CmbAccount.Text & "'", con)
                                xCreditTaken = cmd.ExecuteScalar
                                cmd = New SqlCommand("Select sum(CreditPaid) from Credit_Taken where CusName='" & CmbAccount.Text & "'", con)
                                xCreditPaid = cmd.ExecuteScalar
                            End If
                            Print(eCentre + eNmlText + "Paid Amount: " + essd + PaydAmt.Text)
                            Print(eCentre + eNmlText + "Balance: " + essd + xCreditPaid.ToString)
                            PrintDashes()
                            PrintFooter()
                            EndPrint()
                        End If
                    End If
                End If
                MessageBox.Show("Payment Succeed.", "Payments", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
            PayFor.Clear()
            PaydAmt.Clear()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.Up Then
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Dim xGdr As Integer = 0
    Dim xGdrGet As Boolean = False
    Private Sub GRID1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        GRID1.ClearSelection()
        GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LawnGreen

        xGdr = GRID1.CurrentRow.Index
        xGdrGet = True
        RFID.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        ItemCode.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
        Description.Text = GRID1.Item(2, GRID1.CurrentRow.Index).Value
        CPrice.Text = GRID1.Item(3, GRID1.CurrentRow.Index).Value
        Price.Text = GRID1.Item(4, GRID1.CurrentRow.Index).Value
        UOM.Text = GRID1.Item(5, GRID1.CurrentRow.Index).Value
        Qty.Text = GRID1.Item(6, GRID1.CurrentRow.Index).Value
        LineTot.Text = GRID1.Item(7, GRID1.CurrentRow.Index).Value
        CLTot.Text = GRID1.Item(8, GRID1.CurrentRow.Index).Value
        txtType.Text = GRID1.Item(9, GRID1.CurrentRow.Index).Value
        DisValue100.Text = GRID1.Item(10, GRID1.CurrentRow.Index).Value
        cmd = New SqlCommand("Select SellPrice from Stock_Main where AutoID='" & RFID.Text & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            ItemPriceS = rdr("SellPrice")
        End If
        rdr.Close()
        GRID1.Rows.RemoveAt(GRID1.CurrentRow.Index)
        ItemCode.Focus()

        Dim RowID As Integer = 0
        Dim xTOT As Double = 0
        Dim xCTOT As Double = 0
        Dim xDISCVALUE As Double = 0
        For Each row As DataGridViewRow In GRID1.Rows
            RowID = row.Index
            xTOT += Val(row.Cells(7).Value) + (Val(row.Cells(10).Value) * Val(row.Cells(6).Value))
            'xTOT += Val(row.Cells(6).Value) * ItemPriceS
            xCTOT += Val(row.Cells(8).Value)
            xDISCVALUE += Val(row.Cells(6).Value) * Val(row.Cells(10).Value)
        Next
        If GRID1.Rows.Count > 0 Then
            GRID1.Rows(RowID).Cells(7).Value = Format(Val(GRID1.Rows(RowID).Cells(7).Value), "0.00")
        End If

        Total.Text = xTOT
        Total.Text = Format(Val(Total.Text), "0.00")
        CostTotal.Text = xCTOT
        DiscVal.Text = xDISCVALUE
        DiscVal.Text = Format(Val(DiscVal.Text), "0.00")
        NeTot.Text = Val(Total.Text) - Val(DiscVal.Text)
        NeTot.Text = Format(Val(NeTot.Text), "0.00")
        Prf.Text = Val(NeTot.Text) - Val(CostTotal.Text)
        Prf.Text = Format(Val(Prf.Text), "0.00")
        ItemCode.Focus()

        If Label41.Text = "CREDIT" Then
            txtTotalCr.Text = Val(CusBalance.Text) + Val(NeTot.Text)
            txtTotalCr.Text = Format(Val(txtTotalCr.Text), "0.00")
        End If


        'Dim xTOT As Double = 0
        'Dim xCTOT As Double = 0
        'Dim xDISCVALU As Double = 0
        'For Each row As DataGridViewRow In GRID1.Rows
        '    xTOT += row.Cells(7).Value
        '    xCTOT += Val(row.Cells(8).Value)
        '    xDISCVALU += Val(row.Cells(6).Value) * Val(row.Cells(10).Value)
        'Next
        'Total.Text = xTOT
        'Total.Text = Format(Val(Total.Text), "0.00")
        'DiscVal.Text = xDISCVALU
        'DiscVal.Text = Format(Val(DiscVal.Text), "0.00")
        'CostTotal.Text = xCTOT
        'Prf.Text = Val(NeTot.Text) - Val(CostTotal.Text)
        'Prf.Text = Format(Val(Prf.Text), "0.00")


        lblItems.Text = GRID1.Rows.Count
    End Sub
    Private Sub GRID5_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID5.KeyDown
        If e.KeyCode = 13 Then
            If GRID5.RowCount = 0 Then Return
            xGno = GRID5.CurrentRow.Index
            xxITC(GRID5.Item(0, GRID5.CurrentRow.Index).Value)
            'GRID5.ClearSelection()
            'GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
            'For i As Integer = 0 To GRID5.Rows.Count - 1
            '    GRID5.Rows(i).DefaultCellStyle.BackColor = Color.White
            'Next
            'GRID5.Refresh()
            Price.Focus()
        ElseIf e.KeyCode = Keys.F12 Then
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
            ItemCode.SelectAll()
            'GRID5.ClearSelection()
            '' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
            'For i As Integer = 0 To GRID5.Rows.Count - 1
            '    GRID5.Rows(i).DefaultCellStyle.BackColor = Color.White
            'Next
        End If
    End Sub
    Private Sub Discnt_GotFocus(sender As Object, e As EventArgs) Handles Discnt.GotFocus
        Discnt.BackColor = Color.Yellow
        Discnt.Clear()
        Discnt.Text = "0"
        Discnt.Clear()
    End Sub
    Private Sub Discnt_KeyDown(sender As Object, e As KeyEventArgs) Handles Discnt.KeyDown
        If e.KeyCode = Keys.Down Then
        ElseIf e.KeyCode = Keys.Right Then
            DiscVal.Text = Val(Total.Text) / 100 * Val(Discnt.Text)
            DiscVal.Text = Format(Val(DiscVal.Text), "0.00")

            NeTot.Text = Val(Total.Text) - Val(DiscVal.Text)
            NeTot.Text = Format(Val(NeTot.Text), "0.00")
            TenderedAmt.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            Discnt.Clear()
            Discnt.Clear()
            Discnt.Text = "0"
            Discnt.Clear()
            RFID.Clear()
            ItemCode.Clear()
            Description.Clear()
            CPrice.Clear()
            Price.Clear()
            Qty.Clear()
            LineTot.Clear()
            'UOM.Clear()
            ItemCode.Clear()
            txtType.Clear()
            ItemCode.Focus()
        ElseIf e.KeyCode = 13 Then
            'DiscVal.Text = Val(Total.Text) / 100 * Val(Discnt.Text)
            'DiscVal.Text = Format(Val(DiscVal.Text), "0.00")

            'NeTot.Text = Val(Total.Text) - Val(DiscVal.Text)
            'NeTot.Text = Format(Val(NeTot.Text), "0.00")
            DiscVal.Focus()

        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub Discnt_LostFocus(sender As Object, e As EventArgs) Handles Discnt.LostFocus
        Discnt.BackColor = Nothing
    End Sub
    Private Sub Discnt_TextChanged(sender As Object, e As EventArgs) Handles Discnt.TextChanged
        'Discnt.Clear()
        DiscVal.Text = Val(Total.Text) / 100 * Val(Discnt.Text)
        DiscVal.Text = Format(Val(DiscVal.Text), "0.00")
        NeTot.Text = Val(Total.Text) - Val(DiscVal.Text)
        NeTot.Text = Format(Val(NeTot.Text), "0.00")
    End Sub
    Dim xNETAMOUNT As Double = 0
    Private Sub Total_TextChanged(sender As Object, e As EventArgs) Handles Total.TextChanged
        DiscVal.Text = Val(Total.Text) - (Val(Total.Text) / 100 * Val(Discnt.Text))
        DiscVal.Text = Format(Val(DiscVal.Text), "0.00")
        NeTot.Text = Val(Total.Text) - Val(DiscVal.Text)
        NeTot.Text = Format(Val(NeTot.Text), "0.00")
        ' xNETAMOUNT = Val(NeTot.Text)
    End Sub
    Private Sub Price_GotFocus(sender As Object, e As EventArgs) Handles Price.GotFocus
        Price.BackColor = Color.Yellow
    End Sub
    Private Sub Price_KeyDown(sender As Object, e As KeyEventArgs) Handles Price.KeyDown
        If e.KeyCode = 13 Then
            If Val(Price.Text) <= 0 Then Return
            Qty.Focus()
            Qty.Text = 1
            Qty.SelectAll()
            ' UOM.Focus()
            'ElseIf e.KeyCode = Keys.Left Then
            '    ItemCode.Focus()
            'ElseIf e.KeyCode = Keys.Up Then
            '    RFID.Clear()
            '    ItemCode.Clear()
            '    Description.Clear()
            '    CPrice.Clear()
            '    Price.Clear()
            '    Qty.Clear()
            '    LineTot.Clear()
            '    'UOM.Clear()
            '    ItemCode.Clear()
            '    txtType.Clear()
            '    ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
            'ElseIf e.KeyCode = Keys.Right Then
            '    Discnt.Focus()
            '    Discnt.Clear()
            '    Discnt.Text = "0"
            '    Discnt.Clear()
            'ElseIf e.KeyCode = Keys.F2 Then
            '    StartPrint()
            '    If prn.PrinterIsOpen = True Then
            '        PrintFooter1()
            '        EndPrint()
            '    End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel6.Show()
            Panel1.Enabled = False
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
            'ElseIf e.KeyCode = Keys.F9 Then
            '    Label41.Text = "WHOLE SALE"
            '    Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub
    Private Sub Price_LostFocus(sender As Object, e As EventArgs) Handles Price.LostFocus
        Price.BackColor = Nothing
    End Sub
    Private Sub Price_TextChanged(sender As Object, e As EventArgs) Handles Price.TextChanged
        LineTot.Text = Val(Price.Text) * Val(Qty.Text)
        LineTot.Text = Format(Val(LineTot.Text), "0.00")
        If ItemPriceS <= Val(Price.Text) Then
            DisValue100.Text = "0"
        Else
            DisValue100.Text = ItemPriceS - Val(Price.Text)
            DisValue100.Text = Format(Val(DisValue100.Text), "0.00")
        End If

    End Sub
    Private Sub CmdRPR_Click(sender As Object, e As EventArgs)
        Panel5.Show()
        Panel1.Enabled = False
    End Sub
    Private Sub CmdClose1_Click(sender As Object, e As EventArgs) Handles CmdClose1.Click
        Panel5.Hide()
        Panel1.Enabled = True
        For i = 0 To GRID1.Rows.Count - 1
            GRID1.Rows(i).Height = 35
        Next
    End Sub
    Private Sub CmdSave_GotFocus(sender As Object, e As EventArgs) Handles CmdSave.GotFocus
        CmdSave.BackColor = Color.Yellow
        CmdSave.ForeColor = Color.Black
    End Sub
    Private Sub CmdSave_KeyDown(sender As Object, e As KeyEventArgs) Handles CmdSave.KeyDown
        If e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub CmdSave_LostFocus(sender As Object, e As EventArgs) Handles CmdSave.LostFocus
        CmdSave.BackColor = Color.DodgerBlue
        CmdSave.ForeColor = Color.White
    End Sub
    Private Sub DTP1_ValueChanged(sender As Object, e As EventArgs) Handles DTP1.ValueChanged
        cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate='" & DTP1.Text & "')", con)
        rdr = cmd.ExecuteReader
        CmbInv.Items.Clear()
        While rdr.Read
            CmbInv.Items.Add(rdr("INVNo").ToString)
        End While
        rdr.Close()
    End Sub
    Dim xACT As Boolean = False
    Private Sub txtCsCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCsCode.KeyDown
        If e.KeyCode = Keys.Right Then
            txtCsName.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID110.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtCsName.Clear()
            txtCsCode.Clear()
            Panel6.Hide()
            Panel1.Show()
            Panel1.Enabled = True
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        End If
    End Sub
    Private Sub txtCsCode_TextChanged(sender As Object, e As EventArgs) Handles txtCsCode.TextChanged
        If txtCsCode.Text = "" Then
            cmd = New SqlCommand("select * from Cus_Master order by cast(CusCode as Int)ASC", con)
        Else
            cmd = New SqlCommand("Select * from Cus_Master where CusCode like '" & txtCsCode.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID110.Rows.Clear()
        While rdr.Read
            If rdr("Active") = 0 Then
                xACT = False
            ElseIf rdr("Active") = 1 Then
                xACT = True
            End If
            GRID110.Rows.Add(rdr("CusCode"), rdr("CusName"), Format(rdr("CusBalance"), "0.00"), xACT)
        End While
        rdr.Close()
    End Sub
    Private Sub CmdClose11_Click(sender As Object, e As EventArgs) Handles CmdClose11.Click
        Panel6.Hide()
        Panel1.Enabled = True
        ItemCode.Focus()
        For i = 0 To GRID1.Rows.Count - 1
            GRID1.Rows(i).Height = 35
        Next
    End Sub
    Private Sub GRID110_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID110.CellContentDoubleClick
        xCUST(GRID110.Item(0, GRID110.CurrentRow.Index).Value)
        Panel1.Enabled = True
        Panel6.Hide()
        ItemCode.Focus()
        For i = 0 To GRID1.Rows.Count - 1
            GRID1.Rows(i).Height = 35
        Next
        txtTotalCr.Text = Val(NeTot.Text) + Val(CusBalance.Text)
        txtTotalCr.Text = Format(Val(txtTotalCr.Text), "0.00")
    End Sub
    Private Sub txtCsName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCsName.KeyDown
        If e.KeyCode = Keys.Left Then
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID110.Focus()
        ElseIf e.KeyCode = 27 Then
            txtCsName.Clear()
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        End If
    End Sub
    Private Sub txtCsName_TextChanged(sender As Object, e As EventArgs) Handles txtCsName.TextChanged
        If txtCsName.Text = "" Then
            cmd = New SqlCommand("select * from Cus_Master order by cast(CusCode as Int)ASC", con)
        Else
            cmd = New SqlCommand("Select * from Cus_Master where CusName like '" & txtCsName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID110.Rows.Clear()
        While rdr.Read
            If rdr("Active") = 0 Then
                xACT = False
            ElseIf rdr("Active") = 1 Then
                xACT = True
            End If
            GRID110.Rows.Add(rdr("CusCode"), rdr("CusName"), Format(rdr("CusBalance"), "0.00"), xACT)
        End While
        rdr.Close()
    End Sub
    Private Sub CmadCan_Click(sender As Object, e As EventArgs) Handles CmadCan.Click
        txtCsCode.Clear()
        txtCsName.Clear()
        txtCsCode.Focus()
        txtCsCode_TextChanged(sender, EventArgs.Empty)
    End Sub
    Private Sub CmdNew_Click(sender As Object, e As EventArgs) Handles CmdNew.Click
        If CusCode11.Text = "" Or CusName11.Text = "" Or CusCrdtLmt11.Text = "" Then Return
        cmd = New SqlCommand("Select * from Cus_Master where(CusCode='" & CusCode11.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then

        Else
            '                                                   CusCode,                 CusName,               Address,                   CusMobi,                  CusOff,               CusMail,                  Remarks,            CreditAmt, RceivedAmt, CusBalance,      CusCreditLimit,                     CreditPeriod,            Active,                LastUpdate,                         UName,                    DueDate
            cmd1 = New SqlCommand("Insert Cus_Master values('" & CusCode11.Text & "','" & CusName11.Text & "','" & CusAdd11.Text & "','" & CusMobi11.Text & "','" & CusOff11.Text & "','" & CusMail11.Text & "','" & Remarks11.Text & "','" & 0 & "','" & 0 & "','" & 0 & "','" & Val(CusCrdtLmt11.Text) & "','" & Val(CrPeriod11.Text) & "','" & 1 & "','" & Format(Now, "yyyy-MM-dd").ToString & "','" & FrmMDI.UName.Text & "','" & "" & "') ", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        xCUST(CusCode11.Text)
        CusCode.Focus()
        Panel1.Enabled = True
        Panel6.Hide()
        CusCode11.Clear()
        CusName11.Clear()
        CusAdd11.Clear()
        CusMobi11.Clear()
        CusOff11.Clear()
        CusMail11.Clear()
        Remarks11.Clear()
        CusCrdtLmt11.Clear()
        CrPeriod11.Clear()
    End Sub
    Private Sub CmdRes_Click(sender As Object, e As EventArgs) Handles CmdRes.Click
        CusCode11.Clear()
        CusName11.Clear()
        CusAdd11.Clear()
        CusMobi11.Clear()
        CusOff11.Clear()
        CusMail11.Clear()
        Remarks11.Clear()
        CusCrdtLmt11.Clear()
        CrPeriod11.Clear()
        CusCode11.Focus()
    End Sub
    Private Sub GRID110_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID110.KeyDown
        If e.KeyCode = 13 Then
            If GRID110.RowCount = 0 Then Return
            xCUST(GRID110.Item(0, GRID110.CurrentRow.Index).Value)
            Panel1.Enabled = True
            Panel6.Hide()
            ItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            txtCsName.Clear()
            txtCsCode.Clear()
            Panel6.Hide()
            Panel1.Show()
            CusCode.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        End If
    End Sub
    Private Sub GRID1_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID1.KeyDown
        ' GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LightBlue
        GRID1.ClearSelection()
        ' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        For i As Integer = 0 To GRID1.Rows.Count - 1
            GRID1.Rows(i).DefaultCellStyle.BackColor = Color.White

        Next


        If e.KeyCode = Keys.F2 Then
            'StartPrint()
            'If prn.PrinterIsOpen = True Then
            '    PrintFooter1()
            '    EndPrint()
            'End If
        ElseIf e.KeyCode = Keys.Left Then
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            TenderedAmt.Focus()
        ElseIf e.KeyCode = Keys.Add Then
            TenderedAmt.Focus()
        ElseIf e.KeyCode = Keys.F3 Then

            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        ElseIf e.KeyCode = 13 Then
            If GRID1.RowCount = 0 Then Return
            xGdr = GRID1.CurrentRow.Index
            xGdrGet = True
            RFID.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
            ItemCode.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
            Description.Text = GRID1.Item(2, GRID1.CurrentRow.Index).Value
            CPrice.Text = GRID1.Item(3, GRID1.CurrentRow.Index).Value
            Price.Text = GRID1.Item(4, GRID1.CurrentRow.Index).Value
            UOM.Text = GRID1.Item(5, GRID1.CurrentRow.Index).Value
            Qty.Text = GRID1.Item(6, GRID1.CurrentRow.Index).Value
            LineTot.Text = GRID1.Item(7, GRID1.CurrentRow.Index).Value
            CLTot.Text = GRID1.Item(8, GRID1.CurrentRow.Index).Value
            txtType.Text = GRID1.Item(9, GRID1.CurrentRow.Index).Value
            DisValue100.Text = GRID1.Item(10, GRID1.CurrentRow.Index).Value
            cmd = New SqlCommand("Select SellPrice from Stock_Main where AutoID='" & RFID.Text & "'", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                ItemPriceS = rdr("SellPrice")
            End If
            rdr.Close()


            GRID1.Rows.RemoveAt(GRID1.CurrentRow.Index)
            ItemCode.Focus()
            Dim RowID As Integer = 0
            Dim xTOT As Double = 0
            Dim xCTOT As Double = 0
            Dim xDISCVALUE As Double = 0
            For Each row As DataGridViewRow In GRID1.Rows
                RowID = row.Index
                xTOT += Val(row.Cells(7).Value) + (Val(row.Cells(10).Value) * Val(row.Cells(6).Value))
                'xTOT += Val(row.Cells(6).Value) * ItemPriceS
                xCTOT += Val(row.Cells(8).Value)
                xDISCVALUE += Val(row.Cells(6).Value) * Val(row.Cells(10).Value)
            Next
            If GRID1.Rows.Count > 0 Then
                GRID1.Rows(RowID).Cells(7).Value = Format(Val(GRID1.Rows(RowID).Cells(7).Value), "0.00")
            End If
            Total.Text = xTOT
            Total.Text = Format(Val(Total.Text), "0.00")
            CostTotal.Text = xCTOT
            DiscVal.Text = xDISCVALUE
            DiscVal.Text = Format(Val(DiscVal.Text), "0.00")
            NeTot.Text = Val(Total.Text) - Val(DiscVal.Text)
            NeTot.Text = Format(Val(NeTot.Text), "0.00")
            Prf.Text = Val(NeTot.Text) - Val(CostTotal.Text)
            Prf.Text = Format(Val(Prf.Text), "0.00")
            ItemCode.Focus()








            'Dim xTOT As Double = 0
            'Dim xCTOT As Double = 0
            'For Each row As DataGridViewRow In GRID1.Rows
            '    xTOT += row.Cells(7).Value
            '    xCTOT += Val(row.Cells(8).Value)
            'Next
            'Total.Text = xTOT
            'Total.Text = Format(Val(Total.Text), "0.00")
            'CostTotal.Text = xCTOT
            'Prf.Text = Val(NeTot.Text) - Val(CostTotal.Text)
            'Prf.Text = Format(Val(Prf.Text), "0.00")
        End If
    End Sub
    Private Sub CmdCancel_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        End If
    End Sub
    Private Sub CmdExit_GotFocus(sender As Object, e As EventArgs) Handles CmdExit.GotFocus
        CmdExit.BackColor = Color.Yellow
        CmdExit.ForeColor = Color.Black
    End Sub
    Private Sub CmdExit_KeyDown(sender As Object, e As KeyEventArgs) Handles CmdExit.KeyDown
        If e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub

    Private Sub CmdExit_LostFocus(sender As Object, e As EventArgs) Handles CmdExit.LostFocus
        CmdExit.BackColor = Color.Red
        CmdExit.ForeColor = Color.White
    End Sub

    Private Sub CmdTmp_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            MsgBox("DrawOpen")
        End If
    End Sub
    Private Sub CmdRecl_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        End If
    End Sub
    Private Sub PayFor_KeyDown(sender As Object, e As KeyEventArgs) Handles PayFor.KeyDown
        If e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.Up Then
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub CmbInv_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbInv.KeyDown
        If e.KeyCode = 13 Then
            CashTen.Focus()
        End If
    End Sub
    Dim itp As String = Nothing
    Private Sub CmbInv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbInv.SelectedIndexChanged
        cmd = New SqlCommand("Select * from  Inv_Sub where(INVNo='" & CmbInv.Text & "')", con)
        rdr = cmd.ExecuteReader
        Dim xCode As String = Nothing
        GRID101.Rows.Clear()
        While rdr.Read
            GRID101.Rows.Add(rdr("AutoID"), rdr("ItemCode"), rdr("ItemName"), rdr("Uom"), Format(rdr("SellPrice"), "0.00"), rdr("Qty"), Format(rdr("Amnt"), "0.00"), Format(rdr("IType"), "0.00"))
            InvTime.Text = Format(rdr("LastUpdate"), "yyyy-MM-dd").ToString & "  " & rdr("UpTime").ToString
            xCode = rdr("CusCode").ToString

        End While
        rdr.Close()
        Dim xTOT As Double = 0
        Dim xDISCVAL As Double = 0
        Dim currentBals As Double = 0
        cmd = New SqlCommand("Select * from Cus_Master where(CusCode='" & xCode & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            CusName.Text = rdr("CusName").ToString
            currentBals = rdr("CusBalance").ToString
        Else
            CusName.Clear()
        End If
        rdr.Close()




        For Each row As DataGridViewRow In GRID101.Rows
            xTOT += Val(row.Cells(4).Value) * Val(row.Cells(5).Value)
            xDISCVAL += Val(row.Cells(5).Value) * Val(row.Cells(7).Value)
        Next
        InvAmount.Text = xTOT
        InvAmount.Text = Format(Val(InvAmount.Text), "0.00")

        cmd = New SqlCommand("Select * from  Inv_Main where(INVNo='" & CmbInv.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            Disc.Text = rdr("DiscVal").ToString
            CashTen.Text = rdr("ByCash") + rdr("ByCard")
            itp = rdr("InvType")
        Else
            Disc.Clear()
        End If
        rdr.Close()

        ' Disc.Text = xDISCVAL
        Disc.Text = Format(Val(Disc.Text), "0.00")
        CashTen.Text = Format(Val(CashTen.Text), "0.00")
        txtCurBal.Text = currentBals
        txtCurBal.Text = Format(Val(txtCurBal.Text), "0.00")
    End Sub
    Private Sub CashTen_GotFocus(sender As Object, e As EventArgs) Handles CashTen.GotFocus
        CashTen.BackColor = Color.Yellow
    End Sub

    Private Sub CashTen_KeyDown(sender As Object, e As KeyEventArgs) Handles CashTen.KeyDown
        If e.KeyCode = 13 Then
            CmdPrint.Focus()
        End If
    End Sub
    Private Sub CashTen_LostFocus(sender As Object, e As EventArgs) Handles CashTen.LostFocus
        CashTen.BackColor = Nothing
    End Sub
    Private Sub CashTen_TextChanged(sender As Object, e As EventArgs) Handles CashTen.TextChanged
        BalanceAmount.Text = Val(CashTen.Text) - Val(CardInt.Text)
        BalanceAmount.Text = Format(Val(BalanceAmount.Text), "0.00")
    End Sub
    Private Sub CmdPrint_Click(sender As Object, e As EventArgs) Handles CmdPrint.Click
        StartPrint()
        If prn.PrinterIsOpen = True Then
            PrintHeader111()
            PrintBody1()
            PrintFooter()
            EndPrint()
        End If
    End Sub
    Private Sub CmdPrint_GotFocus(sender As Object, e As EventArgs) Handles CmdPrint.GotFocus
        CmdPrint.BackColor = Color.Yellow
    End Sub
    Private Sub CmdPrint_LostFocus(sender As Object, e As EventArgs) Handles CmdPrint.LostFocus
        CmdPrint.BackColor = Nothing
    End Sub
    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.RowCount = 0 Then Return
            cmd = New SqlCommand("Select * from TempInv_Main where(AutoID='" & GRID2.Item(0, GRID2.CurrentRow.Index).Value & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                TSnId.Text = rdr("AutoId").ToString
                Total.Text = rdr("Amnt").ToString
                cmd1 = New SqlCommand("Select * from TempInv_sub where(RefId='" & TSnId.Text & "')", con1)
                rdr1 = cmd1.ExecuteReader
                GRID1.Rows.Clear()
                While rdr1.Read
                    GRID1.Rows.Add(rdr1("IRefID"), rdr1("ItemCode"), rdr1("ItemName"), rdr1("CostPrice"), rdr1("SellPrice"), rdr1("Uom"), rdr1("Qty"), rdr1("Amnt"), rdr1("xType"))
                End While
                rdr1.Close()
            End If
            rdr.Close()
            Panel2.Hide()
            Panel1.Enabled = True
            For i = 0 To GRID1.Rows.Count - 1
                GRID1.Rows(i).Height = 50
            Next


            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.F11 Then
            REFRESH1()
        ElseIf e.KeyCode = Keys.F12 Then
            Panel2.Hide()
            Panel1.Enabled = True
            ItemCode.Focus()
        End If
    End Sub
    Dim xHAVV As Boolean = False
    Private Sub CusCode11_GotFocus(sender As Object, e As EventArgs) Handles CusCode11.GotFocus
        CusCode11.BackColor = Color.Yellow
    End Sub
    Private Sub CusCode11_KeyDown(sender As Object, e As KeyEventArgs) Handles CusCode11.KeyDown
        If e.KeyCode = 13 Then
            cmd = New SqlCommand("Select * from Cus_Master where(CusCode='" & CusCode11.Text & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                xHAVV = True
            End If
            rdr.Close()
            If xHAVV = True Then
                MsgBox("Existing Customer please try with different one")
                CusCode11.Focus()
                Return
            Else
                CusName11.Focus()
            End If
        End If
    End Sub
    Private Sub CusCode11_LostFocus(sender As Object, e As EventArgs) Handles CusCode11.LostFocus
        CusCode11.BackColor = Nothing
    End Sub
    Private Sub CusName11_GotFocus(sender As Object, e As EventArgs) Handles CusName11.GotFocus
        CusName11.BackColor = Color.Yellow
    End Sub
    Private Sub CusName11_KeyDown(sender As Object, e As KeyEventArgs) Handles CusName11.KeyDown
        If e.KeyCode = 13 Then
            CusAdd11.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            CusCode11.Focus()
        End If
    End Sub

    Private Sub CusName11_LostFocus(sender As Object, e As EventArgs) Handles CusName11.LostFocus
        CusName11.BackColor = Nothing
    End Sub
    Private Sub CusAdd11_KeyDown(sender As Object, e As KeyEventArgs) Handles CusAdd11.KeyDown
        If e.KeyCode = 13 Then
            CusMobi11.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            CusCode11.Focus()
        End If
    End Sub
    Private Sub CmdRest_Click(sender As Object, e As EventArgs) Handles CmdRest.Click
        GRID101.Rows.Clear()
        InvAmount.Clear()
        Disc.Clear()
        CashTen.Clear()
        BalanceAmount.Clear()
        BCash.Clear()
        BCard.Clear()
        txtCurBal.Clear()
        DTP1.Text = Format(Now, "yyyy-MM-dd")
    End Sub
    Private Sub txtTotalAmt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalAmt.KeyDown
        If e.KeyCode = 13 Then
            Panel3.Hide()
            Panel1.Enabled = True
            ItemCode.Focus()
        End If
    End Sub
    Private Sub Description_KeyDown(sender As Object, e As KeyEventArgs) Handles Description.KeyDown
        If e.KeyCode = 13 Then
            If Description.Text = "" Then Return
            Price.Focus()
            'ElseIf e.KeyCode = Keys.Right Then
            '    Discnt.Focus()
            '    Discnt.Clear()
            '    Discnt.Text = "0"
            '    Discnt.Clear()
        ElseIf e.KeyCode = Keys.Left Then
            ItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Clear()
            Description.Clear()
            Price.Clear()
            'UOM.Clear()
            Qty.Clear()
            LineTot.Clear()
            Price.Clear()
            txtType.Clear()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            'StartPrint()
            'If prn.PrinterIsOpen = True Then
            '    PrintFooter1()
            '    EndPrint()
            'End If
        ElseIf e.KeyCode = Keys.Up Then
            'RFID.Clear()
            'ItemCode.Clear()
            'Description.Clear()
            'CPrice.Clear()
            'Price.Clear()
            'Qty.Clear()
            'LineTot.Clear()
            ''UOM.Clear()
            'ItName.Clear()
            'txtType.Clear()
            'ItName.Focus()
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            'Label41.Text = "WHOLE SALE"
            'Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub CmdUpdate_Click(sender As Object, e As EventArgs) Handles CmdUpdate.Click
        Dim result1 As DialogResult = MessageBox.Show("Are you sure to update ?", "Update Item Code", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            cmd = New SqlCommand("Select * from Stock_Main where(AutoID='" & RFID.Text & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                Dim xIICC As String = rdr("ItemCode")
                cmd1 = New SqlCommand("Update ItemMaster set  ItemCode='" & ItemCode.Text & "'where ItemCode='" & xIICC & "'", con1)
                cmd1.ExecuteNonQuery()
            End If
            rdr.Close()
            cmd = New SqlCommand("Update Stock_Main set  ItemCode='" & ItemCode.Text & "'where AutoID='" & RFID.Text & "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Item Update Success.!")
        End If
        CANCELSALE(1)
    End Sub
    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click
        If ItemCode.Text = "" Or Description.Text = "" Then Return
        Dim result1 As DialogResult = MessageBox.Show("Are you sure to delete Selected Items from the List ?", "Dalete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            cmd = New SqlCommand("Delete from Stock_Main where AutoID='" & RFID.Text & "'", con)
            cmd.ExecuteNonQuery()
            'Dim xTr As Boolean = False
            'For i As Integer = 0 To GRID5.Rows.Count - 1
            '    If GRID5(5, i).Value = True Then
            '        xTr = True
            '    End If
            'Next
            'If xTr = True Then
            '    For i As Integer = GRID5.Rows.Count - 1 To 0 Step -1
            '        Dim xIndx As Integer = 0
            '        Dim xNV As Boolean = GRID5(5, i).Value
            '        If xNV = True Then
            '            xIndx = GRID5.Rows(i).Index
            '            cmd = New SqlCommand("Delete from Stock_Main where AutoID='" & RFID.Text & "'", con)
            '            cmd.ExecuteNonQuery()
            '            GRID5.Rows.RemoveAt(xIndx)
            '        End If
            '    Next
            ItemCode.Clear()
            Description.Clear()
            Price.Clear()
            'UOM.Clear()
            Qty.Clear()
            LineTot.Clear()
            Price.Clear()
            txtType.Clear()
            ItemCode.Focus()
            CPrice.Clear()
            xGno = 0
            MsgBox("Item Deleted Success.!")

        End If
    End Sub
    Private Sub txtMOR_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMOR.KeyDown
        If e.KeyCode = 13 Then
            If txtMOR.Text = "" Then Return
            If Val(txtMOR.Text) = 0 Then Return
            Dim result1 As DialogResult = MessageBox.Show("Are you sure the amount ?", "Morning Cash Amount", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                '                                                   PayAccount,              Description,           Amnt,                       LastUpdate
                cmd = New SqlCommand("Insert MrningCash values('" & CmbAccount.Text & "','" & PayFor.Text & "','" & Val(txtMOR.Text) & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
                cmd.ExecuteNonQuery()
                'cmd = New SqlCommand("Update MrningCash set Description='" & Description.Text & "',PayAccount='" & CmbAccount.Text & "',Amnt+='" & Val(txtMOR.Text) & "'where LastUpdate='" & Format(Now, "yyyy-MM-dd") & "'", con)
                'cmd.ExecuteNonQuery()
                obj.xSettle(0, 0, 0, 0, 0, 0, 0, Format(Now, "yyyy-MM-dd"), FrmMDI.UName.Text, Val(txtMOR.Text), 0)
                MsgBox("Success.!")
                txtMOR.Clear()
                Description.Clear()
                xAcountLoad(CmbAccount)
            End If
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.Up Then
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub PType_GotFocus(sender As Object, e As EventArgs) Handles PType.GotFocus
        PType.BackColor = Color.Yellow
    End Sub
    Dim XC As Boolean = False
    Private Sub PType_KeyDown(sender As Object, e As KeyEventArgs) Handles PType.KeyDown
        If e.KeyCode = 13 Then
            If PType.Text = "CASH" Then
                TenderedAmt.Focus()
            ElseIf PType.Text = "CARD" Then
                CrdAmnt.Focus()
            End If
        ElseIf e.KeyCode = Keys.Right Then
            If XC = True Then
                Return
            ElseIf XC = False Then
                PType.Text = "CARD"
                PType.BackColor = Color.Pink
                CrdAmnt.Text = NeTot.Text
                LBLTYPE.Text = "CARD"
                LBLTYPE.BackColor = Color.Pink
                XC = True
            End If
        ElseIf e.KeyCode = Keys.Left Then
            XC = False
            PType.Text = "CASH"
            PType.BackColor = Color.LightGreen
            CrdAmnt.Clear()
            CrdAmnt.Text = "0"
            LBLTYPE.Text = "CASH"
            LBLTYPE.BackColor = Color.LightGreen
        ElseIf e.KeyCode = Keys.Up Then
            Discnt.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub PType_LostFocus(sender As Object, e As EventArgs) Handles PType.LostFocus
        If PType.Text = "CARD" Then
            PType.BackColor = Color.Pink
        ElseIf PType.Text = "CASH" Then
            PType.BackColor = Color.LightGreen
        End If
    End Sub
    Private Sub CrdAmnt_GotFocus(sender As Object, e As EventArgs) Handles CrdAmnt.GotFocus
        CrdAmnt.BackColor = Color.Yellow
    End Sub
    Private Sub CrdAmnt_KeyDown(sender As Object, e As KeyEventArgs) Handles CrdAmnt.KeyDown
        If e.KeyCode = 13 Then
            CrdNO.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            PType.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub CrdAmnt_LostFocus(sender As Object, e As EventArgs) Handles CrdAmnt.LostFocus
        CrdAmnt.BackColor = Nothing
    End Sub
    Private Sub CrdAmnt_TextChanged(sender As Object, e As EventArgs) Handles CrdAmnt.TextChanged
        If PType.Text.ToUpper = "CARD" Then
            ByCHQ.Text = Val(NeTot.Text) - Val(CrdAmnt.Text)
            ByCHQ.Text = Format(Val(ByCHQ.Text), "0.00")
            CardInterest.Text = Val(CrdAmnt.Text) / 100 * 3
            CardInterest.Text = Format(Val(CardInterest.Text), "0.00")
        End If

    End Sub
    Private Sub CrdNO_GotFocus(sender As Object, e As EventArgs) Handles CrdNO.GotFocus
        CrdNO.BackColor = Color.Yellow
    End Sub
    Private Sub CrdNO_KeyDown(sender As Object, e As KeyEventArgs) Handles CrdNO.KeyDown
        If e.KeyCode = 13 Then
            CardInterest.Focus()
            ' TenderedAmt.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            CrdAmnt.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub CrdNO_LostFocus(sender As Object, e As EventArgs) Handles CrdNO.LostFocus
        CrdNO.BackColor = Nothing
    End Sub
    Private Sub NeTot_TextChanged(sender As Object, e As EventArgs) Handles NeTot.TextChanged
        'ByCash.Text = Val(NeTot.Text) - (Val(CrdAmnt.Text) + Val(CardInterest.Text))
        'ByCash.Text = Format(Val(ByCash.Text), "0.00")
    End Sub
    Private Sub CardInterest_TextChanged(sender As Object, e As EventArgs) Handles CardInterest.TextChanged
        NeTot.Text = (Val(Total.Text) - Val(DiscVal.Text)) + Val(CardInterest.Text)
        NeTot.Text = Format(Val(NeTot.Text), "0.00")
    End Sub
    Private Sub CardInterest_KeyDown(sender As Object, e As KeyEventArgs) Handles CardInterest.KeyDown
        If e.KeyCode = 13 Then
            TenderedAmt.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            CrdAmnt.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub CardInterest_GotFocus(sender As Object, e As EventArgs) Handles CardInterest.GotFocus
        CardInterest.BackColor = Color.Yellow
    End Sub
    Private Sub BCard_TextChanged(sender As Object, e As EventArgs) Handles BCard.TextChanged
        CardInt.Text = Val(BCard.Text) / 100 * 3
    End Sub
    Private Sub CardInterest_LostFocus(sender As Object, e As EventArgs) Handles CardInterest.LostFocus
        CardInterest.BackColor = Nothing
    End Sub
    Private Sub Total_KeyDown(sender As Object, e As KeyEventArgs) Handles Total.KeyDown
        If e.KeyCode = 13 Then
            Discnt.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
            'ElseIf e.KeyCode = Keys.Left Then
            '    Price.Focus()
            'ElseIf e.KeyCode = Keys.Right Then
            '    Discnt.Focus()
            '    Discnt.Clear()
            '    Discnt.Text = "0"
            '    Discnt.Clear()
        ElseIf e.KeyCode = Keys.Up Then
            Qty.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub DiscVal_KeyDown(sender As Object, e As KeyEventArgs) Handles DiscVal.KeyDown
        If e.KeyCode = 13 Then
            TenderedAmt.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.Up Then
            Discnt.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub NeTot_KeyDown(sender As Object, e As KeyEventArgs) Handles NeTot.KeyDown
        If e.KeyCode = 13 Then
            TenderedAmt.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.BringToFront()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.Up Then
            CardInterest.Focus()
        ElseIf e.KeyCode = Keys.F2 Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintFooter1()
                EndPrint()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            Panel1.Enabled = False
            Panel6.Show()
            Panel6.BringToFront()
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            FrmRCPT.Show()
            FrmRCPT.Show()
            FrmRCPT.MdiParent = FrmMDI
            FrmRCPT.BringToFront()
        ElseIf e.KeyCode = Keys.F6 Then
            Panel1.Enabled = False
            Panel5.Show()
            Panel5.BringToFront()
            CmbInv.Focus()
            DTP1.Text = Format(Now, "yyyy-MM-dd")
        ElseIf e.KeyCode = Keys.F7 Then
            FrmRtn.Show()
            FrmRtn.MdiParent = FrmMDI
            FrmRtn.BringToFront()
            Me.Enabled = False
        ElseIf e.KeyCode = Keys.F8 Then
            Label41.Text = "CASH"
            Label41.BackColor = Color.Green
        ElseIf e.KeyCode = Keys.F9 Then
            Label41.Text = "WHOLE SALE"
            Label41.BackColor = Color.Fuchsia
        ElseIf e.KeyCode = Keys.F10 Then
            HOLDSALE()
        ElseIf e.KeyCode = Keys.F11 Then
            RECALLSALE()
        ElseIf e.KeyCode = Keys.F12 Then
            CANCELSALE(0)
        End If
    End Sub
    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        StartPrint()
        If prn.PrinterIsOpen = True Then
            PrintFooter1()
            EndPrint()
        End If
        ItemCode.Focus()
    End Sub
    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click
        Label41.Text = "CREDIT"
        Label41.BackColor = Color.Red
        Panel1.Enabled = False
        Panel6.Show()
        Panel6.BringToFront()
        txtCsCode_TextChanged(sender, EventArgs.Empty)
        txtCsCode.Focus()
    End Sub
    Private Sub Label39_Click(sender As Object, e As EventArgs) Handles Label39.Click
        Label41.Text = "CASH"
        Label41.BackColor = Color.Green
        ItemCode.Focus()
    End Sub
    Private Sub Label40_Click(sender As Object, e As EventArgs) Handles Label40.Click
        Label41.Text = "WHOLE SALE"
        Label41.BackColor = Color.Fuchsia
        ItemCode.Focus()
    End Sub
    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click
        FrmRtn.Show()
        FrmRtn.MdiParent = FrmMDI
        FrmRtn.BringToFront()
        Me.Enabled = False
    End Sub
    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click
        FrmRCPT.Show()
        FrmRCPT.Show()
        FrmRCPT.MdiParent = FrmMDI
        FrmRCPT.BringToFront()
    End Sub
    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click
        Panel1.Enabled = False
        Panel5.Show()
        Panel5.BringToFront()
        CmbInv.Focus()
        DTP1.Text = Format(Now, "yyyy-MM-dd")
    End Sub
    Private Sub Label42_Click(sender As Object, e As EventArgs) Handles Label42.Click
        HOLDSALE()
        ''ItemCode.Focus()
        'Dim frmcs As New FrmCashier
        'xPanelCenter(frmcs, frmcs.Panel1)
        'frmcs.Show()
        'frmcs.BringToFront()
    End Sub
    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click
        RECALLSALE()
        'For i As Integer = 0 To CmbBank.Items.Count - 1
        '    cmd = New SqlCommand("Select Count(BankName) from BankName", con)
        '    Dim xVN As Integer = cmd.ExecuteScalar
        '    If xVN > 0 Then
        '    ElseIf xVN = 0 Then
        '        cmd = New SqlCommand("Insert BankName values('" & CmbBank.Items(i) & "')", con)
        '        cmd.ExecuteNonQuery()
        '    End If

        'Next
    End Sub
    Private Sub Label44_Click(sender As Object, e As EventArgs) Handles Label44.Click

        CANCELSALE(0)
        'Dim words() As String = {"A", "Net", "Perls"}
        '' Loop over words.
        'For Each w As String In words
        '    Console.WriteLine(w.PadLeft(15))
        'Next
    End Sub
    Private Sub txtPay_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPay.KeyDown
        If e.KeyCode = 13 Then
            If txtPay.Text = "" Or PayFor.Text = "" Or CmbAccount.Text = "" Then Return
            Dim result1 As DialogResult = MessageBox.Show("Are you sure the Credit Taken ?", "Credit Taken", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                'CusName, Refrence, CreditAmt, LastUpdate
                'CreditTaken
                cmd = New SqlCommand("Select * from CreditTaken where(LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    cmd1 = New SqlCommand("Update CreditTaken set CreditAmt+='" & Val(txtPay.Text) & "'where(LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con1)
                    cmd1.ExecuteNonQuery()
                Else
                    '                                                   CusName,                        LastUpdate
                    cmd1 = New SqlCommand("Insert CreditTaken values('" & Val(txtPay.Text) & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()
                cmd = New SqlCommand("Insert CreditTaken_Sub values('" & CmbAccount.Text & "','" & PayFor.Text & "','" & Val(txtPay.Text) & "','" & Format(Now, "yyyy-MM-dd") & "')", con)
                cmd.ExecuteNonQuery()
                '                                                           CusName,                Refrence,               CreditAmt,                  LastUpdate,                     Reference1, CreditPaid,         PayDate
                cmd = New SqlCommand("Insert Credit_Taken values('" & CmbAccount.Text & "','" & PayFor.Text & "','" & Val(txtPay.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "')", con)
                cmd.ExecuteNonQuery()
                'cmd = New SqlCommand("Update Cus_Master Set CusBalance+='" & Val(txtPay.Text) & "'where CusCode='" & CusCode.Text & "'", con)
                'cmd.ExecuteNonQuery()
                'obj.xSettle(0, Val(NeTot.Text), Val(TenderedAmt.Text), 0, 0, 0, 0, Format(Now, "yyyy-MM-dd"), FrmMDI.UName.Text, Val(txtMOR.Text), 0)
                MessageBox.Show("Credit Taken Success..!", "Credit Taken", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtPay.Clear()
                PayFor.Clear()
                'txtPay.Clear()
                'CANCELSALE()
            End If
        End If
    End Sub
    Private Sub GRID5_LostFocus(sender As Object, e As EventArgs) Handles GRID5.LostFocus
        'GRID5.ClearSelection()
        '' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        'For i As Integer = 0 To GRID5.Rows.Count - 1
        '    GRID5.Rows(i).DefaultCellStyle.BackColor = Color.White
        'Next
    End Sub
    Private Sub GRID5_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GRID5.CellEnter
        'GRID5.ClearSelection()
        'GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LawnGreen
    End Sub
    Private Sub GRID5_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles GRID5.CellLeave
        'GRID5.ClearSelection()
        '' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        'For i As Integer = 0 To GRID5.Rows.Count - 1
        '    GRID5.Rows(i).DefaultCellStyle.BackColor = Color.White
        'Next
    End Sub
    Private Sub GRID5_Leave(sender As Object, e As EventArgs) Handles GRID5.Leave
        'GRID5.ClearSelection()
        '' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        'For i As Integer = 0 To GRID5.Rows.Count - 1
        '    GRID5.Rows(i).DefaultCellStyle.BackColor = Color.White
        'Next
    End Sub
    Private Sub GRID5_TabIndexChanged(sender As Object, e As EventArgs) Handles GRID5.TabIndexChanged
        'GRID5.ClearSelection()
        '' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        'For i As Integer = 0 To GRID5.Rows.Count - 1
        '    GRID5.Rows(i).DefaultCellStyle.BackColor = Color.White
        'Next
    End Sub
    Private Sub Description_GotFocus(sender As Object, e As EventArgs) Handles Description.GotFocus
        Description.BackColor = Color.Yellow
    End Sub
    Private Sub Description_LostFocus(sender As Object, e As EventArgs) Handles Description.LostFocus
        Description.BackColor = Color.White
    End Sub
    Private Sub UOM_KeyDown(sender As Object, e As KeyEventArgs) Handles UOM.KeyDown
        If e.KeyCode = 13 Then
            Qty.Focus()
        End If
    End Sub
    Private Sub UOM_GotFocus(sender As Object, e As EventArgs) Handles UOM.GotFocus
        UOM.BackColor = Color.Yellow
    End Sub
    Private Sub UOM_LostFocus(sender As Object, e As EventArgs) Handles UOM.LostFocus
        UOM.BackColor = Color.White
    End Sub
    Private Sub txtinv1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtinv1.KeyDown
        If e.KeyCode = 13 Then
            txtTotalAmt_KeyDown(sender, e)
        End If
    End Sub
    Private Sub txtdisP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtdisP.KeyDown
        If e.KeyCode = 13 Then
            txtTotalAmt_KeyDown(sender, e)
        End If
    End Sub
    Private Sub txtDisAm_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDisAm.KeyDown
        If e.KeyCode = 13 Then
            txtTotalAmt_KeyDown(sender, e)
        End If
    End Sub
    Private Sub txtTender_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTender.KeyDown
        If e.KeyCode = 13 Then
            txtTotalAmt_KeyDown(sender, e)
        End If
    End Sub
    Private Sub ByCaard_KeyDown(sender As Object, e As KeyEventArgs) Handles ByCaard.KeyDown
        If e.KeyCode = 13 Then
            txtTotalAmt_KeyDown(sender, e)
        End If
    End Sub
    Private Sub ByCaash_KeyDown(sender As Object, e As KeyEventArgs) Handles ByCaash.KeyDown
        If e.KeyCode = 13 Then
            txtTotalAmt_KeyDown(sender, e)
        End If
    End Sub
    Private Sub txtBal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBal.KeyDown
        If e.KeyCode = 13 Then
            txtTotalAmt_KeyDown(sender, e)
        End If
    End Sub
    Private Sub DiscVal_TextChanged(sender As Object, e As EventArgs) Handles DiscVal.TextChanged
        NeTot.Text = Val(Total.Text) - Val(DiscVal.Text)
        NeTot.Text = Format(Val(NeTot.Text), "0.00")





    End Sub
    Private Sub txtNtot_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNtot.KeyDown
        If e.KeyCode = 13 Then
            txtTotalAmt_KeyDown(sender, e)
        End If
    End Sub
    Private Sub DiscVal_GotFocus(sender As Object, e As EventArgs) Handles DiscVal.GotFocus
        DiscVal.BackColor = Color.Yellow
    End Sub
    Private Sub CmdAddAcc_Click(sender As Object, e As EventArgs) Handles CmdAddAcc.Click
        Dim result11 As DialogResult = MessageBox.Show("Are you sure to Add New Account ?", "Add Acount", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result11 = vbYes Then
            Dim PAccnt As String = InputBox("Please Enter an Account")
            If PAccnt = "" Then
            Else
                cmd = New SqlCommand("Select * from PayAcc where(AccName='" & PAccnt & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                Else
                    cmd1 = New SqlCommand("Insert PayAcc values('" & PAccnt & "')", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()
                MessageBox.Show("Account Add Success...!")
                xAcountLoad1(CmbAccount)
                CmbAccount.Text = PAccnt
            End If
        End If
    End Sub
    Private Sub CmdTotalCost_Click(sender As Object, e As EventArgs) Handles CmdTotalCost.Click
        Dim TotCostValue As Double = 0
        cmd = New SqlCommand("Select * from Stock_Main", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            TotCostValue += rdr("CostPrice") * rdr("BalanceQty")
        End While
        rdr.Close()
        MessageBox.Show(TotCostValue)
    End Sub
    Private Sub DiscVal_LostFocus(sender As Object, e As EventArgs) Handles DiscVal.LostFocus
        DiscVal.BackColor = Color.White
    End Sub

    Private Sub PaydAmt_TextChanged(sender As Object, e As EventArgs) Handles PaydAmt.TextChanged

    End Sub

    Private Sub GRID5_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID5.CellContentClick

    End Sub

    Private Sub ItemCode_TextChanged(sender As Object, e As EventArgs) Handles ItemCode.TextChanged
        If ItemCode.Text = "+" Then
            ItemCode.Clear()
            TenderedAmt.Focus()
        Else
            Dim hn As Boolean = False
            cmd3 = New SqlCommand("Select * from Stock_Main where ItemCode = '" & ItemCode.Text & "'", con3)
            rdr3 = cmd3.ExecuteReader
            If rdr3.Read = True Then
                hn = True
            Else
                hn = False
            End If
            rdr3.Close()



            If hn = True Then
                ' ListBox1.Hide()
                gridItmList.Hide()
            ElseIf hn = False Then

                If ItemCode.Text = "" Then
                    cmd = New SqlCommand("Select * from Stock_Main  order by ItemCode", con)
                    ' ListBox1.Hide()
                    gridItmList.Hide()
                Else
                    cmd = New SqlCommand("Select * from Stock_Main where ItemCode like '" & ItemCode.Text & "%'  ", con)
                    '  ListBox1.Show()
                    gridItmList.Show()
                End If
                rdr = cmd.ExecuteReader
                ' ListBox1.Items.Clear()
                gridItmList.Rows.Clear()
                While rdr.Read
                    gridItmList.Rows.Add(rdr("ItemCode"), rdr("ItemName"), Format(rdr("SellPrice"), "0.00"))
                End While
                rdr.Close()
            End If
        End If





    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick
        GRID1.ClearSelection()
        GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LawnGreen

    End Sub

    Private Sub Disc_TextChanged(sender As Object, e As EventArgs) Handles Disc.TextChanged
        CardInt.Text = Val(InvAmount.Text) - Val(Disc.Text)
        CardInt.Text = Format(Val(CardInt.Text), "0.00")
    End Sub

    Private Sub CPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles CPrice.KeyDown
        If e.KeyCode = 13 Then
            If RFID.Text = "" Or ItemCode.Text = "" Then Return
            cmd = New SqlCommand("Update Stock_Main set CostPrice='" & CPrice.Text & "'where(AutoID='" & RFID.Text & "')", con)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Update ItemMaster set CostPrice='" & CPrice.Text & "'where(ItemCode='" & ItemCode.Text & "')", con)
            cmd.ExecuteNonQuery()
            Qty.Focus()
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub GRID5_ParentChanged(sender As Object, e As EventArgs) Handles GRID5.ParentChanged

    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        'If e.KeyCode = 13 Then
        '    If ListBox1.SelectedItem = "" Then Return
        '    Dim oItemCode As String = ListBox1.SelectedItem

        '    Dim first_word As String = oItemCode.Split(" ")(0)
        '    ItemCode.Text = first_word
        '    xITM(ItemCode.Text)


        'ElseIf e.KeyCode = 27 Then
        '    ItemCode.Focus()
        '    ListBox1.Items.Clear()
        '    ListBox1.Hide()
        'End If
    End Sub

    Private Sub GRID1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GRID1.CellMouseClick

    End Sub

    Private Sub ItemCode_MouseClick(sender As Object, e As MouseEventArgs) Handles ItemCode.MouseClick
        ItemCode_TextChanged(sender, EventArgs.Empty)
    End Sub

    Private Sub CusCode_TextChanged(sender As Object, e As EventArgs) Handles CusCode.TextChanged

    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        'If ListBox1.SelectedItem = "" Then Return
        'Dim oItemCode As String = ListBox1.SelectedItem

        'Dim first_word As String = oItemCode.Split(" ")(0)
        'ItemCode.Text = first_word
        'xITM(ItemCode.Text)
        'ListBox1.Hide()
    End Sub

    Private Sub txtTotalAmt_TextChanged(sender As Object, e As EventArgs) Handles txtTotalAmt.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Panel2.Hide()
        Panel1.Enabled = True
        ItemCode.Focus()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        REFRESH1()
    End Sub

    Private Sub ChqVal_TextChanged(sender As Object, e As EventArgs) Handles ChqVal.TextChanged

    End Sub

    Private Sub CusCode_MouseClick(sender As Object, e As MouseEventArgs) Handles CusCode.MouseClick
        If e.Button = MouseButtons.Left Then
            Panel6.Show()
            Panel6.BringToFront()
            Panel1.Enabled = False
            Label41.Text = "CREDIT"
            Label41.BackColor = Color.Red
            txtCsCode_TextChanged(sender, EventArgs.Empty)
            txtCsCode.Focus()

        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub GridChq_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridChq.CellContentClick

    End Sub

    Private Sub ChqVal_KeyDown(sender As Object, e As KeyEventArgs) Handles ChqVal.KeyDown
        If e.KeyCode = 13 Then
            If CHQNo.Text = "" Or CmbBank.Text = "" Or ChqVal.Text = "" Then Return
            Dim RowTrue As Boolean = False, RowID As Integer = 0
            For Each row As DataGridViewRow In GridChq.Rows
                If (row.Cells(0).Value = CHQNo.Text) Then
                    RowTrue = True : RowID = row.Index : Exit For
                End If
            Next
            If RowTrue = True Then
                GridChq.Rows(RowID).Cells(3).Value = Format(Val(ChqVal.Text), "0.00")
                GridChq.Rows(RowID).Cells(2).Value = CmbBank.Text
            Else
                GridChq.Rows.Add(CHQNo.Text, DTP2.Text, CmbBank.Text, Format(Val(ChqVal.Text), "0.00"))
            End If
            CHQNo.Clear()
            ChqVal.Clear()
            Dim ChqAmounts As Double = 0
            For Each row As DataGridViewRow In GridChq.Rows
                ChqAmounts += Val(row.Cells(3).Value)
            Next
            ByCHQ.Text = ChqAmounts
            ByCHQ.Text = Format(Val(ByCHQ.Text), "0.00")


            For i = 0 To GridChq.Rows.Count - 1
                GridChq.Rows(i).Height = 33
            Next


        End If
    End Sub

    Private Sub ByCHQ_TextChanged(sender As Object, e As EventArgs) Handles ByCHQ.TextChanged
        BalAmt.Text = (Val(ByCHQ.Text) + Val(TenderedAmt.Text)) - Val(NeTot.Text)
        BalAmt.Text = Format(Val(BalAmt.Text), "0.00").ToString
    End Sub

    Private Sub GridChq_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridChq.CellContentDoubleClick
        CHQNo.Text = GridChq.Item(0, GridChq.CurrentRow.Index).Value
        DTP2.Text = GridChq.Item(1, GridChq.CurrentRow.Index).Value
        CmbBank.Text = GridChq.Item(2, GridChq.CurrentRow.Index).Value
        ChqVal.Text = GridChq.Item(3, GridChq.CurrentRow.Index).Value
        GridChq.Rows.RemoveAt(GridChq.CurrentRow.Index)

        Dim ChqAmounts As Double = 0
        For Each row As DataGridViewRow In GridChq.Rows
            ChqAmounts += Val(row.Cells(3).Value)
        Next
        ByCHQ.Text = ChqAmounts
        ByCHQ.Text = Format(Val(ByCHQ.Text), "0.00")

    End Sub

    Private Sub GRID1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellEnter
        'GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LightBlue
        If GRID1.Rows.Count > 0 Then
            GRID1.ClearSelection()
            GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LawnGreen
        End If


        '


    End Sub

    Private Sub Description_TextChanged(sender As Object, e As EventArgs) Handles Description.TextChanged

    End Sub

    Private Sub GRID1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellLeave
        ' GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LightBlue
        GRID1.ClearSelection()
        ' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        For i As Integer = 0 To GRID1.Rows.Count - 1
            GRID1.Rows(i).DefaultCellStyle.BackColor = Color.White
        Next






    End Sub

    Private Sub GRID1_Leave(sender As Object, e As EventArgs) Handles GRID1.Leave
        ' GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LightBlue
        GRID1.ClearSelection()
        ' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        For i As Integer = 0 To GRID1.Rows.Count - 1
            GRID1.Rows(i).DefaultCellStyle.BackColor = Color.White
        Next
    End Sub

    Private Sub GRID1_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.RowLeave
        ' GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LightBlue
        GRID1.ClearSelection()
        ' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        For i As Integer = 0 To GRID1.Rows.Count - 1
            GRID1.Rows(i).DefaultCellStyle.BackColor = Color.White
        Next
    End Sub

    Private Sub CmdCls_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        FrmMDI.FormText.Text = "NO"
        ' FrmMDI.Dispose()
        FrmMDI.Close()
        FrmLoggin.txtUname.Clear()
        FrmLoggin.txtPassword.Clear()
        FrmLoggin.Show()
        FrmLoggin.txtUname.Focus()
        FrmLoggin.BringToFront()

    End Sub

    Private Sub GRID1_TabIndexChanged(sender As Object, e As EventArgs) Handles GRID1.TabIndexChanged
        ' GRID1.Rows(GRID1.CurrentRow.Index).DefaultCellStyle.BackColor = Color.LightBlue
        GRID1.ClearSelection()
        ' GRID5.Rows(GRID5.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
        For i As Integer = 0 To GRID1.Rows.Count - 1
            GRID1.Rows(i).DefaultCellStyle.BackColor = Color.White
        Next
    End Sub

    Private Sub txtPay_TextChanged(sender As Object, e As EventArgs) Handles txtPay.TextChanged

    End Sub

    Private Sub txtMOR_TextChanged(sender As Object, e As EventArgs) Handles txtMOR.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CusCode.Text = "" Then Return
        Dim result12 As DialogResult = MessageBox.Show("Do you want to Print Receipt ?", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result12 = vbYes Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintRCP101(CusName.Text)
                EndPrint()
            End If
        End If


    End Sub

    Private Sub UnitID_TextChanged(sender As Object, e As EventArgs) Handles UnitID.TextChanged

    End Sub

    Private Sub Panel1_Resize(sender As Object, e As EventArgs) Handles Panel1.Resize


        'FrmCashier_Resize(sender, EventArgs.Empty)
    End Sub

    Private Sub LineTot_TextChanged(sender As Object, e As EventArgs) Handles LineTot.TextChanged

    End Sub

    Private Sub Label41_Click(sender As Object, e As EventArgs) Handles Label41.Click

    End Sub

    Private Sub UnitID_Resize(sender As Object, e As EventArgs) Handles UnitID.Resize

    End Sub

    Private Sub Price_Click(sender As Object, e As EventArgs) Handles Price.Click
        'Button1_Click(sender, EventArgs.Empty)
    End Sub

    Private Sub DepositedAmount_TextChanged(sender As Object, e As EventArgs) Handles DepositedAmount.TextChanged

    End Sub

    Private Sub CmdClose1_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles CmdClose1.ChangeUICues

    End Sub

    Private Sub DepositedAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles DepositedAmount.KeyDown
        If e.KeyCode = 13 Then
            If CmbAccount101.Text = "" Or Val(DepositedAmount.Text) <= 0 Then Return
            Dim result1 As DialogResult = MessageBox.Show("Are you sure to Deposit This Amount ?", "Cash Deposit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                Dim first_word As String = CmbAccount101.Text.Split(" ")(0)
                Dim first_word1 As String = CmbAccount101.Text.Split(" ")(1)
                '                                                     AccNo,             BankName,            Description,                             Debit,                Credit,             LastUpdate,                     UpTime,                         UName
                cmd = New SqlCommand("Insert Acc_Main values('" & first_word & "','" & first_word1 & "','" & "CASH " & " Deposit" & "','" & Val(DepositedAmount.Text) & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Update Bank_Main set TotalDEP+='" & Val(DepositedAmount.Text) & "'where AccNo='" & first_word & "'", con)
                cmd.ExecuteNonQuery()
                xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, 0, 0, 0, 0, Val(DepositedAmount.Text), 0, 0)
                MessageBox.Show("Deposit Succeed.", "Cash Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DepositedAmount.Clear()
                BankLoad()
            End If
        End If



    End Sub

    Private Sub PaySup_TextChanged(sender As Object, e As EventArgs) Handles PaySup.TextChanged

    End Sub

    Private Sub ListBox1_MarginChanged(sender As Object, e As EventArgs) Handles ListBox1.MarginChanged

    End Sub

    Private Sub PaySup_KeyDown(sender As Object, e As KeyEventArgs) Handles PaySup.KeyDown
        If e.KeyCode = 13 Then
            If CmbSup.Text = "" Or Val(PaySup.Text) <= 0 Then Return
            Dim result1 As DialogResult = MessageBox.Show("Are you sure to Pay This Amount ?", "Cash Pay For Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                Dim first_word As String = CmbSup.Text.Split(" ")(0)
                Dim first_word1 As String = CmbSup.Text.Split(" ")(1)
                '                                                   PayNo,                           PayDate,                PayMethod,          UnitID,             SupCode,                   Amount,                     LastUpdate
                cmd = New SqlCommand("Insert SUPPayment values('" & INVNum.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & "CASH" & "','" & UnitID.Text & "','" & first_word & "','" & Val(PaySup.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "CASH PAID" & "','" & "-" & "')", con)
                cmd.ExecuteNonQuery()
                '       AutoID,                                     PayAccount,             Description,                         Amnt,                      LastUpdate,                              UName
                cmd = New SqlCommand("Insert Pay_Master values('" & CmbSup.Text & "','" & "Suplier Payment" & "','" & Val(PaySup.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "')", con)
                cmd.ExecuteNonQuery()
                '                                                    SupCode,            SupName,               GrnDate,                        Descp,      GrnAmnt,        PayDate,                              Descr,                 PayAmnt
                cmd1 = New SqlCommand("Insert SupState values('" & first_word & "','" & first_word1 & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & "CASH PAID" & "','" & Val(PaySup.Text) & "')", con1)
                cmd1.ExecuteNonQuery()
                xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, 0, 0, Val(PaySup.Text), 0, 0, 0, 0)
                MessageBox.Show("Payment Succeed.", "Cash Payment", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                PaySup.Clear()
                SupLoad()
            End If
        End If
    End Sub

    Private Sub CmbAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAccount.SelectedIndexChanged
        PayFor.Clear()
        PayFor.Text = "CASH PAID"
        PaydAmt.Focus()

    End Sub

    Private Sub PayFor_TextChanged(sender As Object, e As EventArgs) Handles PayFor.TextChanged

    End Sub

    Private Sub ListBox1_MouseHover(sender As Object, e As EventArgs) Handles ListBox1.MouseHover

    End Sub

    Private Sub PayFor_GotFocus(sender As Object, e As EventArgs) Handles PayFor.GotFocus
        PayFor.Focus()
        PayFor.SelectAll()
    End Sub

    Private Sub PayFor_Click(sender As Object, e As EventArgs) Handles PayFor.Click
        PayFor.Focus()
        PayFor.SelectAll()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Panel8.Hide()
        Panel1.BringToFront()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub PayFor_MouseDown(sender As Object, e As MouseEventArgs) Handles PayFor.MouseDown
        PayFor.Focus()
        PayFor.SelectAll()
    End Sub
    Private Function xCRINFO(ByVal xRPT As ReportClass)

        Dim xSERVER As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "Server", Nothing)
        Dim xPW As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "DatabasePw", Nothing)
        xRPT.DataSourceConnections.Clear()
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        With crConnectionInfo
            .ServerName = xSERVER
            .DatabaseName = "Kristal_Lanka"
            .UserID = "sa"
            .Password = xPW
        End With
        CrTables = xRPT.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        Return xRPT
    End Function

    Private Sub GRID110_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID110.CellContentClick

    End Sub

    Private Sub Label2_DoubleClick(sender As Object, e As EventArgs) Handles Label2.DoubleClick
        Dim xInt As Integer = 0
        cmd = New SqlCommand("Select UserName from User_Option where UserName='" & FrmMDI.UName.Text & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xInt = rdr("xInt")
        End If
        rdr.Close()
        If xInt = 0 Then
            Panel8.Show()
            Panel8.BringToFront()
            Dim report6 As New RptStatement
            Dim TotalSales As Double = 0
            cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate= '" & Format(Now, "yyyy-MM-dd") & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                cmd1 = New SqlCommand("Select sum(InvAmnt) from Inv_Main where(LastUpdate= '" & Format(Now, "yyyy-MM-dd") & "')", con1)
                TotalSales = cmd1.ExecuteScalar
            End If
            rdr.Close()
            report6.SetParameterValue("xSLS", TotalSales)
            report6.RecordSelectionFormula = "{CashFlow.LastUpdate} ='" & Format(Now, "yyyy-MM-dd") & "'"
            xCRINFO(report6)
            CrystalReportViewer1.ReportSource = report6
            CrystalReportViewer1.Refresh()
        End If

    End Sub

    Private Sub FrmCashier_MaximumSizeChanged(sender As Object, e As EventArgs) Handles Me.MaximumSizeChanged

    End Sub

    Private Sub gridItmList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridItmList.CellContentClick

    End Sub

    Private Sub CusCode_Click(sender As Object, e As EventArgs) Handles CusCode.Click

    End Sub

    Private Sub gridItmList_KeyDown(sender As Object, e As KeyEventArgs) Handles gridItmList.KeyDown
        If e.KeyCode = 13 Then

            ' If gridItmList.SelectedRows = "" Then Return
            Dim oItemCode As String = gridItmList.CurrentRow.Cells(0).Value
            Dim first_word As String = oItemCode
            ItemCode.Text = first_word
            xITM(ItemCode.Text)
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
            gridItmList.Rows.Clear()
            gridItmList.Hide()
        End If
    End Sub

    Private Sub btnOld_Click(sender As Object, e As EventArgs) Handles btnOld.Click
        cmd = New SqlCommand("Select * from TempInv_Main where (Status='" & "Pending" & "'and LastUpdate='" & Format(dtpOld.Value, "yyyy-MM-dd") & "')order by AutoID DESC", con)
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("AutoID"), Format(rdr("Amnt"), "0.00"), rdr("Status"))
        End While
        rdr.Close()
        GRID2.Focus()
        GRID6.Rows.Clear()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If GRID1.Rows.Count = 0 Then
            Return
        End If
        Dim result1 As DialogResult = MessageBox.Show("Are you sure to Print this Quotation ?", "Print Quotation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            StartPrint()
            If prn.PrinterIsOpen = True Then
                PrintHeader11Q()
                PrintBodyq()
                PrintFooter()
                EndPrint()
            End If
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub gridItmList_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridItmList.CellContentDoubleClick
        ' If gridItmList.SelectedRows = "" Then Return
        Dim oItemCode As String = gridItmList.CurrentRow.Cells(0).Value
        Dim first_word As String = oItemCode
        ItemCode.Text = first_word
        xITM(ItemCode.Text)
        ItemCode.Focus()
        gridItmList.Rows.Clear()
        gridItmList.Hide()

    End Sub
End Class