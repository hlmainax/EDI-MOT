Imports System.Data.SqlClient
Imports ConnData
Imports POS_System.NewFunc
Public Class FrmRCPT
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
    Private PrinterName As String = "BIXOLON SRP-E302"
    Dim xCLASS As New CashHandle
    Private Sub FrmRCPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        xMAX(Me)
        Dim sUNIT As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "UnitID", Nothing)
        UnitID.Text = sUNIT
        xCUS()



        Dim xDDT As String = Format(Now, "yyyy-MM-dd").ToString
        Dim xTMM As String = Format(Now, "HH:mm:ss").ToString



        cmd = New SqlCommand("Select * from RcptGen where(UnitId='" & UnitID.Text & "'and RcpDT='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            RcpNo.Text = UnitID.Text & Format(rdr("RcpDT"), "ddMMyyyy") & rdr("RCP") & "R"
        Else
            '                                                 UnitID,            RCPT,               RcpDT,          RcpDT,               Uname
            cmd1 = New SqlCommand("Insert RcptGen values('" & UnitID.Text & "','" & 1 & "','" & xDDT & "','" & xTMM & "','" & FrmMDI.UName.Text & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        xUNT()

        'AboutBox1.Close()
    End Sub

    Private Sub FrmRCPT_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        'Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        'Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        'Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
    End Sub





    Private Sub xUNT()

        cmd = New SqlCommand("Select * from RcptGen where(UnitID='" & UnitID.Text & "'and RcpDT='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            RcpNo.Text = UnitID.Text & Format(Now, "ddMMyyyy") & rdr("RCP") & "R"
        End If
        rdr.Close()
    End Sub

    Private Sub xCUS()
        cmd = New SqlCommand("Select * from Cus_Master", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"), Format(rdr("CusBalance"), "0.00"))
        End While
        rdr.Close()
    End Sub

    Private Sub CustCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CustCode.KeyDown
        If e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            CustName.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            If RcpNo.Text = "" Or RcvDescrip.Text = "" Or Amnt.Text = "" Or CusName.Text = "" Then Return
            xRCPTSAVE()
        ElseIf e.KeyCode = Keys.F11 Then
            CusCode.Clear()
            CusName.Clear()
            CusBalance.Clear()
            RcvDescrip.Clear()
            Amnt.Clear()
        ElseIf e.KeyCode = Keys.F12 Then
            Me.Close()
        End If
    End Sub


    Private Sub CustCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustCode.TextChanged
        If CustCode.Text = "" Then
            cmd = New SqlCommand("Select * from Cus_Master   order by CusCode", con)
        Else
            cmd = New SqlCommand("Select * from Cus_Master where CusCode like '" & CustCode.Text & "%'  ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"), rdr("CusBalance"))
        End While
        rdr.Close()
    End Sub

    Private Sub CustName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CustName.KeyDown
        If e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            CustCode.Focus()
        ElseIf e.KeyCode = Keys.F4 Then
            If RcpNo.Text = "" Or RcvDescrip.Text = "" Or Amnt.Text = "" Or CusName.Text = "" Then Return
            xRCPTSAVE()
        ElseIf e.KeyCode = Keys.F11 Then
            CusCode.Clear()
            CusName.Clear()
            CusBalance.Clear()
            RcvDescrip.Clear()
            Amnt.Clear()
        ElseIf e.KeyCode = Keys.F12 Then
            Me.Close()
        End If
    End Sub

    Private Sub CustName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustName.TextChanged
        If CustName.Text = "" Then
            cmd = New SqlCommand("Select * from Cus_Master   order by CusCode", con)
        Else
            cmd = New SqlCommand("Select * from Cus_Master where CusName like '%" & CustName.Text & "%'  ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"), rdr("CusBalance"))
        End While
        rdr.Close()
    End Sub

    Private Sub GRID1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

    Private Sub GRID1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        CusCode.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        CusName.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
        CusBalance.Text = GRID1.Item(2, GRID1.CurrentRow.Index).Value
    End Sub

    Private Sub GRID1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRID1.KeyDown
        If e.KeyCode = 13 Then
            If GRID1.RowCount = 0 Then Return
            CusCode.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
            CusName.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
            CusBalance.Text = GRID1.Item(2, GRID1.CurrentRow.Index).Value
        ElseIf e.KeyCode = Keys.F4 Then
            If RcpNo.Text = "" Or RcvDescrip.Text = "" Or Amnt.Text = "" Or CusCode.Text = "" Then Return
            xRCPTSAVE()
        ElseIf e.KeyCode = Keys.F11 Then
            CusCode.Clear()
            CusName.Clear()
            CusBalance.Clear()
            RcvDescrip.Clear()
            Amnt.Clear()
        ElseIf e.KeyCode = Keys.F12 Then
            Me.Close()
        End If
    End Sub



    Private Sub UnitID_TextChanged(sender As Object, e As EventArgs) Handles UnitID.TextChanged

    End Sub

    Private Sub RcpNo_TextChanged(sender As Object, e As EventArgs) Handles RcpNo.TextChanged

    End Sub
    Private Sub xRCPTSAVE()
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Save the Receipt ?", "Cash Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            '                                                    RcptNo,              UnitId,                 CusCode,             CusName,                 RcvAmt,              Descrip,                               RcvDT,                                  RcvTM,                      UName
            cmd = New SqlCommand("Insert Receipt_Main values('" & RcpNo.Text & "','" & UnitID.Text & "','" & CusCode.Text & "','" & CusName.Text & "','" & Amnt.Text & "','" & RcvDescrip.Text & "','" & Format(Now, "yyyy-MM-dd").ToString & "','" & Format(Now, "HH:mm:ss").ToString & "','" & FrmMDI.UName.Text & "')", con)
            cmd.ExecuteNonQuery()
            '                                       UnitID, RCP, RcpDT, RcpTm, Uname
            cmd = New SqlCommand("Select * from RcptGen where(UnitID='" & UnitID.Text & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                cmd1 = New SqlCommand("Update RcptGen Set RCP='" & rdr("RCP") + 1 & "'where UnitID='" & rdr("UnitID") & "'", con1)
                cmd1.ExecuteNonQuery()
            End If
            rdr.Close()
            cmd = New SqlCommand("Select * from Cus_Master where(CusCode='" & CusCode.Text & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                cmd1 = New SqlCommand("Update Cus_Master Set CusBalance='" & rdr("CusBalance") - Amnt.Text & "'where CusCode='" & rdr("CusCode") & "'", con1)
                cmd1.ExecuteNonQuery()
            End If
            rdr.Close()
            '                                                   CusCode,            CusName,                    InvDate,                         Descp,     InvAmnt,             RcvDate,                      Descr,              RcvAmnt
            cmd1 = New SqlCommand("Insert CusState values('" & CusCode.Text & "','" & CusName.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Rcv" & "','" & Val(Amnt.Text) & "')", con1)
            cmd1.ExecuteNonQuery()
            xCLASS.xSettle(0, 0, Val(Amnt.Text), 0, 0, 0, 0, Format(Now, "yyyy-MM-dd"), FrmMDI.UName.Text, 0, 0)
            xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, Val(Amnt.Text), 0, 0, 0, 0, 0, 0)
            'Dim result2 As DialogResult = MessageBox.Show("Do you want to Print the Receipt ?", "Cash Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            'If result2 = vbYes Then
            '    'Dim cForm As New FrmCashier

            '    ' Dim prn As New RawPrinterHelper
            '    StartPrint()
            '    If prn.PrinterIsOpen = True Then
            '        PrintRCP(RcpNo.Text, CusName.Text)
            '        Dim xBAL As Double = Val(CusBalance.Text) - Val(Amnt.Text)
            '        xBAL = Format(Val(xBAL), "0.00")
            '        PrintRcpBody(CusBalance.Text, Format(Val(Amnt.Text), "0.00"), xBAL.ToString)
            '        PrintFooter()
            '        EndPrint()
            '    End If
            'End If
            MessageBox.Show("Cash Receipt Succeed.", "Cash Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            xCUS()
            xUNT()
            CusCode.Clear()
            CusName.Clear()
            CusBalance.Clear()
            RcvDescrip.Clear()
            Amnt.Clear()
        End If
    End Sub
    Private Sub EndPrint()
        prn.ClosePrint()
    End Sub
    Private Sub PrintFooter()
        Print(eCentre + eNmlText + "Follow us on FB @cherrypick.lk")
        Print(eCentre + eNmlText + "Thank You Come Again!" + eLeft)
        PRNTD()
        'Print(eCentre + eNmlText + "Exchange Possible Withing 7 Days" + eLeft)
        'Print(eCentre + eNmlText + "With Tag and Original Receipt" + eLeft + eInit)
        Print(eCentre + eNmlText + "Powered By Softlab 0763313333" + eLeft + eInit + vbLf)
        Print(vbLf + vbLf + eCut + eDrawer)
    End Sub
    Private Sub PrintRcpBody(ByVal xPrev As String, ByVal xPaid As String, ByVal xBal As String)
        'PrintDashes()
        Print(eCentre + eNmlText + "Previous Balance: " + essd + xPrev)
        Print(eCentre + eNmlText + "Paid Amount: " + essd + xPaid)
        Print(eCentre + eNmlText + "Current Balance: " + essd + xBal)
        PrintDashes()
        PRNTD()
        'Print(eRight + eNmlText + "Total Discount:   1.30")
    End Sub
    Private Sub StartPrint()
        prn.OpenPrint(PrinterName)
    End Sub
    Private Sub PRNTD()
        Print(eCentre + eNmlText + "*".PadRight(25, "*"))
    End Sub
    Private Sub PrintRCP(ByVal RcpNp As String, ByVal xCustomer As String)
        Print(eCentre + COMMAND)
        Print(eBigCharOn + eCentre + "HAMEED MART" + eLeft)
        Print(eBigCharOff + "7/1, Kandy RD, Gelioya")
        Print("Tel:0812 310 299 / 0768 010 132" + eInit)
        Print(eNmlText + eLeft + "RCP No-" + RcpNp + "      " + "Cashier - " + FrmMDI.UName.Text + eRight)
        Print(eNmlText + eCentre + Format(Now, "dd-MM-yyyy") + "     " + Date.Now.ToShortTimeString)
        Print(eNmlText + eCentre + "Customer - " + essd + xCustomer)
        '""""""""""""""""""
        PrintDashes()
    End Sub
    Private Sub Print(ByVal Line As String)
        prn.SendStringToPrinter(PrinterName, Line + vbLf)
    End Sub
    Private Sub PrintDashes()
        Print(eLeft + eNmlText + "~".PadRight(48, "~"))
    End Sub

    Private Sub RcvDescrip_KeyDown(sender As Object, e As KeyEventArgs) Handles RcvDescrip.KeyDown
        If e.KeyCode = 13 Then
        ElseIf e.KeyCode = Keys.F4 Then
            If RcpNo.Text = "" Or RcvDescrip.Text = "" Or Amnt.Text = "" Or CusName.Text = "" Then Return
            xRCPTSAVE()
        ElseIf e.KeyCode = Keys.F11 Then
            CusCode.Clear()
            CusName.Clear()
            CusBalance.Clear()
            RcvDescrip.Clear()
            Amnt.Clear()
        ElseIf e.KeyCode = Keys.F12 Then
            Me.Close()
        End If
    End Sub
    Private Sub Amnt_KeyDown(sender As Object, e As KeyEventArgs) Handles Amnt.KeyDown
        If e.KeyCode = 13 Then
        ElseIf e.KeyCode = Keys.F4 Then
            If RcpNo.Text = "" Or RcvDescrip.Text = "" Or Amnt.Text = "" Or CusCode.Text = "" Then Return
            xRCPTSAVE()
        ElseIf e.KeyCode = Keys.F11 Then
            CusCode.Clear()
            CusName.Clear()
            CusBalance.Clear()
            RcvDescrip.Clear()
            Amnt.Clear()
        ElseIf e.KeyCode = Keys.F12 Then
            Me.Close()
        End If
    End Sub

    Private Sub Amnt_TextChanged(sender As Object, e As EventArgs) Handles Amnt.TextChanged

    End Sub

    Private Sub Label39_Click(sender As Object, e As EventArgs) Handles Label39.Click
        If RcpNo.Text = "" Or RcvDescrip.Text = "" Or Amnt.Text = "" Or CusCode.Text = "" Then Return
        xRCPTSAVE()
        CusCode.Focus()

    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click
        CusCode.Clear()
        CusName.Clear()
        CusBalance.Clear()
        RcvDescrip.Clear()
        Amnt.Clear()
        CusCode.Focus()
    End Sub

    Private Sub Label44_Click(sender As Object, e As EventArgs) Handles Label44.Click
        Me.Close()
        Dim xw As Integer = Screen.PrimaryScreen.Bounds.Width
        If xw < 1920 Then
            FrmCash1.Show()
            FrmCash1.BringToFront()
        Else
            FrmCashier.Show()
            FrmCashier.MdiParent = FrmMDI
            FrmCashier.BringToFront()
        End If
    End Sub
End Class