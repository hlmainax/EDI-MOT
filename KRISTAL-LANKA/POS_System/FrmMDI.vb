Imports System.Data.SqlClient
Imports ConnData
Imports Microsoft.Win32
Imports System.Linq
Public Class FrmMDI
    Dim xUNIT As String = Nothing
    Dim xSERVER As String = Nothing
    Dim xCSH As String = Nothing

    Private Sub FrmMDI_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.F12 Then
        '    UsrLogOff_Click(sender, EventArgs.Empty)
        'End If
    End Sub
    Public xLIST, xLIST1, xLIST2, xLIST3, xLIST4 As New ArrayList
    Private Sub FrmMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xw As Integer = Screen.PrimaryScreen.Bounds.Width
        Me.WindowState = FormWindowState.Maximized
        'Dim xTR As String = InputBox("Your Trail Period has Expired.Please Activate the Sytem")
        'ConnecOpen()
        'If Format(Now, "yyyy-MM-dd") > "2020-09-13" Then
        '    MessageBox.Show("Your Trial Period has Expired...Please contact the System Developer")
        '    Application.Exit()
        'End If
        Timer1_Tick(sender, EventArgs.Empty)
        'str = "server=HRNS;Database=Library_System;User Id=sa;Password=123abc"
        'con = New SqlConnection(str)
        'con.Open()
        UName.Text = FrmLoggin.txtUname.Text
        PWord.Text = FrmLoggin.txtPassword.Text

        cmd = New SqlCommand("select * from User_Option where(UserName='" & UName.Text & "'and Password='" & PWord.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            If rdr("Filee") = 1 Then M1000.Enabled = True Else M1000.Enabled = False : M1000.Visible = False
            If rdr("FOffice") = 1 Then M2000.Enabled = True Else M2000.Enabled = False : M2000.Visible = False
            If rdr("BOffice") = 1 Then M3000.Enabled = True Else M3000.Enabled = False : M3000.Visible = False
            If rdr("Financee") = 1 Then M4000.Enabled = True Else M4000.Enabled = False : M4000.Visible = False
            If rdr("Toolss") = 1 Then M5000.Enabled = True Else M5000.Enabled = False : M5000.Visible = False
            If rdr("Repor") = 1 Then M6000.Enabled = True Else M6000.Enabled = False : M6000.Visible = False
            If rdr("Adminn") = 1 Then M7000.Enabled = True Else M7000.Enabled = False : M7000.Visible = False

            If rdr("CusMas") = 1 Then M1001.Enabled = True Else M1001.Enabled = False : M1001.Visible = False
            If rdr("Suppl") = 1 Then M1002.Enabled = True Else M1002.Enabled = False : M1002.Visible = False
            If rdr("CAT1") = 1 Then M1003.Enabled = True Else M1003.Enabled = False : M1003.Visible = False
            If rdr("CAT2") = 1 Then M1004.Enabled = True Else M1004.Enabled = False : M1004.Visible = False
            If rdr("ITMM") = 1 Then M1005.Enabled = True Else M1005.Enabled = False : M1005.Visible = False

            If rdr("CSH") = 1 Then M2001.Enabled = True Else M2001.Enabled = False : M2001.Visible = False
            If rdr("SLRT") = 1 Then M2002.Enabled = True Else M2002.Enabled = False : M2002.Visible = False
            ' If rdr("RCPT") = 1 Then M2003.Enabled = True Else M2003.Enabled = False : M2003.Visible = False

            If rdr("GRN") = 1 Then M3001.Enabled = True Else M3001.Enabled = False : M3001.Visible = False
            If rdr("SPRT") = 1 Then M3002.Enabled = True Else M3002.Enabled = False : M3002.Visible = False
            If rdr("DMG") = 1 Then M3003.Enabled = True Else M3003.Enabled = False : M3003.Visible = False

            If rdr("SPAY") = 1 Then M4001.Enabled = True Else M4001.Enabled = False : M4001.Visible = False

            If rdr("DBBK") = 1 Then M5001.Enabled = True Else M5001.Enabled = False : M5001.Visible = False

            If rdr("MRPT") = 1 Then M6001.Enabled = True Else M6001.Enabled = False : M6001.Visible = False
            If rdr("GRRPT") = 1 Then M6002.Enabled = True Else M6002.Enabled = False : M6002.Visible = False
            'If rdr("DEND") = 1 Then M6003.Enabled = True Else M6003.Enabled = False


            If rdr("USR") = 1 Then M7001.Enabled = True Else M7001.Enabled = False : M7001.Visible = False
            If rdr("PRAD") = 1 Then M7002.Enabled = True Else M7002.Enabled = False : M7002.Visible = False
            If rdr("STITM") = 1 Then M7003.Enabled = True Else M7003.Enabled = False : M7003.Visible = False
            If rdr("Exl") = 1 Then M7004.Enabled = True Else M7004.Enabled = False : M7004.Visible = False

            If rdr("xINT") = 1 Then M2002.Visible = False Else M2002.Enabled = True : M2002.Visible = True
            If rdr("xINT") = 1 Then M2003.Visible = True Else M2003.Enabled = False : M2003.Visible = False


        End If
        rdr.Close()
        xUNIT = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\EDIRI\1.0", "UnitID", Nothing)
        xSERVER = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\EDIRI\1.0", "Server", Nothing)
        xCSH = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\EDIRI\1.0", "CashInHnd", Nothing)

        ToolStripStatusLabel2.Text = "                              " & xUNIT
        ToolStripStatusLabel3.Text = "                              " & UName.Text

        cmd = New SqlCommand("Select * from Workstation where UnitID='" & xUNIT & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then

        Else
            '                                                     UnitID,           Server,          GRN,        DMG,    SRTN,          INV,         SPAY,       Csh,                   LastUpdate,                          SLRTN
            cmd1 = New SqlCommand("Insert Workstation values('" & xUNIT & "','" & xSERVER & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & xCSH & "','" & Format(Now, "yyyy/MM/dd HH:mm:ss ") & "','" & 1 & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        'AutoID, PayAccount, Description, Amnt, LastUpdate, UName

        cmd = New SqlCommand("Select * from Pay_Master where LastUpdate='" & Format(Now, "yyyy-MM-dd") & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
        Else
            '     AutoID,                                        PayAccount,   Description, Amnt,     LastUpdate,                     UName
            cmd1 = New SqlCommand("Insert Pay_Master values('" & "-" & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & UName.Text & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        cmd = New SqlCommand("Select * from SUPPayment where LastUpdate='" & Format(Now, "yyyy-MM-dd") & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
        Else
            '                                                         PayDate,                         PayMethod,         UnitID,    SupCode,      Amount,            LastUpdate,                   UpTime,                             Uname,           Descrip,     ChqPaid
            cmd1 = New SqlCommand("Insert SUPPayment values('" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & "-" & "','" & 0 & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & UName.Text & "','" & "-" & "','" & "-" & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        'RcptNo, UnitID, CusCode, CusName, RcvAmt, Descrip, RcvDT, RcvTM, UName
        cmd = New SqlCommand("Select * from Receipt_Main where RcvDT='" & Format(Now, "yyyy-MM-dd") & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
        Else
            '                                                  RcptNo,        UnitID,       CusCode,         CusName,    RcvAmt,    Descrip,             RcvDT,                                      RcvTM,             UName
            cmd1 = New SqlCommand("Insert Receipt_Main values('" & "-" & "','" & "-" & "','" & "-" & "','" & "-" & "','" & 0 & "','" & "-" & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & UName.Text & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()

        ' INVNo, CusCode, CusName, CHQNo, ChqDate, Bank, Amount, LastUpdate, UpTime, UName, Status
        cmd = New SqlCommand("Select * from ChqRcv where LastUpdate='" & Format(Now, "yyyy-MM-dd") & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
        Else
            '                                               NVNo,      CusCode,       CusName,       CHQNo,      ChqDate,      Bank,         Amount,      LastUpdate,                                UpTime,                   UName, Status
            cmd1 = New SqlCommand("Insert ChqRcv values('" & "-" & "','" & "-" & "','" & "-" & "','" & "-" & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & UName.Text & "','" & "-" & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()






        '   FrmCashier.MdiParent = Me

        CheckCashFlow()
        ChqDeposit()

        txtPP.Visible = False
    End Sub
    Private Sub ChqDeposit()
        cmd = New SqlCommand("Select * from CHQPAY_Sub where(BankAcc<>'" & "ON-HAND" & "'and Status='" & "PAID" & "'and CHQUpdate<='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            cmd1 = New SqlCommand("Select BankName from Bank_Main where AccNo='" & rdr("BankAcc") & "'", con1)
            Dim xBank As String = cmd1.ExecuteScalar
            cmd1 = New SqlCommand("Update Bank_Main set TotalWD+='" & rdr("CHQAmnt") & "'where AccNo='" & rdr("BankAcc") & "'", con1)
            cmd1.ExecuteNonQuery()
            '                                                     AccNo,                  BankName,            Description,                 Debit,    Credit,             LastUpdate,                     UpTime,                         UName
            cmd1 = New SqlCommand("Insert Acc_Main values('" & rdr("BankAcc") & "','" & xBank & "','" & rdr("CHQNo") & " Payment" & "','" & 0 & "','" & rdr("CHQAmnt") & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & UName.Text & "')", con1)
            cmd1.ExecuteNonQuery()
        End While
        rdr.Close()

        cmd = New SqlCommand("Update CHQPAY_Sub set Status='" & "PASSED" & "'where(BankAcc<>'" & "ON-HAND" & "'and Status='" & "PAID" & "'and CHQUpdate<='" & Format(Now, "yyyy-MM-dd") & "')", con)
        cmd.ExecuteNonQuery()

    End Sub

    Private Sub ItemMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles M1005.Click
        FrmCashier.Dispose()
        FrmItem.Show()
        FrmItem.MdiParent = Me
        FrmItem.BringToFront()
    End Sub
    Dim xMAXX As Boolean = False
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles M1007.Click
        FrmCashier.Dispose()
        xMAXX = True
        Dim xx As String = Format(Now, "yyyy-MM-dd H:mm:ss")
        Dim xx1 As String = xx & "POS_System.bak"
        xx1 = xx1.Replace(" ", "-")
        xx1 = xx1.Replace(":", "-")

        'End If
        'getting backup file path...
        ' Dim path As String = "C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Backup\" & xx1

        'D:\Dropbox
        'Dim path As String = "C:\Users\acer-pc\Dropbox\My PC (acer-pc)\Documents\" & xx1
        Dim path As String = "C:\123\" & xx1
        '  path = System.IO.Path.GetFullPath(SaveFileDialog1.FileName)
        '   path = SaveFileDialog1.InitialDirectory(SaveFileDialog1.FileName)


        'Code to backup database.
        Try
            ConnecOpen()
            'Backup In progress...
            'Timer1.Start()

            cmd = New SqlCommand("USE master; BACKUP DATABASE Ediri TO DISK = '" & path.ToString & "'", con)
            ' cmd = New SqlCommand(" BACKUP DATABASE POS_System TO DISK = '" & path.ToString & "'", con)
            'con.Open()
            cmd.ExecuteNonQuery()
            'MsgBox("Backup Succeed!", MsgBoxStyle.Information)

            'con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            'con.Close()
        End Try

        Application.Exit()
    End Sub
    Private Sub CheckCashFlow()
        Dim xhv As Boolean = False
        cmd = New SqlCommand("Select * from CashFlow where(LastUpdate='" & Format(Now, "yyyy-MM-dd") & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
        Else
            xhv = True
            '                                               BfBal,      CashSl,      Rcpt,      SlRtn,    Paymnts,                  Deposits,    DayBal,                LastUpdate
            cmd1 = New SqlCommand("Insert CashFlow values('" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & 0 & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        If xhv = True Then
            cmd = New SqlCommand("Select count(LastUpdate) from CashFlow where(LastUpdate<>'" & Format(Now, "yyyy-MM-dd") & "')", con)
            Dim xNumber As Integer = cmd.ExecuteScalar
            If xNumber > 0 Then
                Dim xDATE As Date
                Dim DayBalance As Double = 0
                cmd = New SqlCommand("Select max(LastUpdate) from CashFlow where(LastUpdate<>'" & Format(Now, "yyyy-MM-dd") & "')", con)
                xDATE = cmd.ExecuteScalar
                cmd = New SqlCommand("Select DayBal from CashFlow where(LastUpdate='" & xDATE & "')", con)
                DayBalance = cmd.ExecuteScalar
                '                                                         BfBal,      CashSl,      Rcpt,      SlRtn,    Paymnts,                  Deposits,    DayBal,                LastUpdate
                cmd = New SqlCommand("Update CashFlow set BfBal='" & DayBalance & "',DayBal='" & DayBalance & "'where LastUpdate='" & Format(Now, "yyyy-MM-dd") & "'", con)
                cmd.ExecuteNonQuery()
            End If
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = Date.Now.ToLongTimeString
    End Sub

    Private Sub SupplierMaster_Click(sender As Object, e As EventArgs) Handles M1002.Click
        FrmCashier.Dispose()
        FrmSupplier.Show()
        FrmSupplier.MdiParent = Me
        FrmSupplier.BringToFront()
    End Sub

    Private Sub Cat2_Click(sender As Object, e As EventArgs) Handles M1004.Click
        FrmCashier.Dispose()
        FrmCat2.Show()
        FrmCat2.MdiParent = Me
        FrmCat2.BringToFront()
    End Sub

    Private Sub Cat1_Click(sender As Object, e As EventArgs) Handles M1003.Click
        FrmCashier.Dispose()
        FrmCat1.Show()
        FrmCat1.MdiParent = Me
        FrmCat1.BringToFront()
    End Sub

    Private Sub GRNNote_Click(sender As Object, e As EventArgs) Handles M3001.Click
        FrmCashier.Dispose()
        FrmGRN.Show()
        FrmGRN.MdiParent = Me
        FrmGRN.BringToFront()
    End Sub

    Private Sub SRNNote_Click(sender As Object, e As EventArgs) Handles M3002.Click
        FrmCashier.Dispose()
        FrmSupplierRTN.Show()
        FrmSupplierRTN.MdiParent = Me
        FrmSupplierRTN.BringToFront()
    End Sub

    Private Sub DamageNote_Click(sender As Object, e As EventArgs) Handles M3003.Click
        FrmCashier.Dispose()
        FrmDMG.Show()
        FrmDMG.MdiParent = Me
        FrmDMG.BringToFront()
    End Sub

    Private Sub SUPPay_Click(sender As Object, e As EventArgs) Handles M4001.Click
        FrmCashier.Dispose()
        FrmSupPament.Show()
        FrmSupPament.MdiParent = Me
        FrmSupPament.BringToFront()
    End Sub


    Private Sub Cashier_Click(sender As Object, e As EventArgs) Handles M2001.Click
        txtPP.Clear()
        txtPP.Visible = False
        Dim xw As Integer = Screen.PrimaryScreen.Bounds.Width
        If xw < 1920 Then
            FrmCash1.Show()
            FrmCash1.BringToFront()
            FrmCash1.MdiParent = Me
        Else
            FrmCashier.Show()
            FrmCashier.MdiParent = Me
            FrmCashier.BringToFront()
        End If

    End Sub

    Private Sub UsrLogOff_Click(sender As Object, e As EventArgs) Handles M1006.Click
        xMAXX = True
        FrmCashier.Dispose()
        ' FrmCashier.Close()
        FrmLoggin.txtUname.Clear()
        FrmLoggin.txtPassword.Clear()
        FrmLoggin.Show()
        FrmLoggin.txtUname.Focus()
        FrmLoggin.BringToFront()
        Me.Close()

    End Sub

    Private Sub BcpDtbase_Click(sender As Object, e As EventArgs) Handles M5001.Click
        FrmCashier.Dispose()
        frmBackup.Show()
        frmBackup.MdiParent = Me
        frmBackup.BringToFront()
    End Sub

    Private Sub CusMast_Click(sender As Object, e As EventArgs) Handles M1001.Click
        FrmCashier.Dispose()
        FrmCustomer.Show()
        FrmCustomer.MdiParent = Me
        FrmCustomer.BringToFront()
    End Sub

    Dim XHAVE As Boolean = False

    Private Sub M6001_Click(sender As Object, e As EventArgs) Handles M6001.Click
        FrmCashier.Dispose()
        cmd = New SqlCommand("Select * from User_Option where(UserName='" & UName.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            If rdr("xINT") = 1 Then
                XHAVE = True
            ElseIf rdr("xINT") = 0 Then
                XHAVE = False
            End If
        End If
        rdr.Close()
        If XHAVE = True Then
            FrmHRPORT.Show()
            FrmHRPORT.MdiParent = Me
            FrmHRPORT.BringToFront()
        ElseIf XHAVE = False Then
            FrmRpts.Show()
            FrmRpts.MdiParent = Me
            FrmRpts.BringToFront()
        End If

    End Sub

    Private Sub M2002_Click(sender As Object, e As EventArgs) Handles M2002.Click
        'FrmCashier.Dispose()
        'FrmRtn.Show()
        'FrmRtn.MdiParent = Me
        'FrmRtn.BringToFront()
    End Sub



    Private Sub M7001_Click(sender As Object, e As EventArgs) Handles M7002.Click
        FrmCashier.Dispose()
        Dim xx As Integer = 0
        cmd = New SqlCommand("Select xINT from User_Option where UserName='" & UName.Text & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xx = rdr("xINT")
        End If
        rdr.Close()
        If xx = 1 Then
            txtPP.Visible = True
            If txtPP.Text = "" Then

            Else
                Return
            End If
        Else
            frmPchange.Show()
            frmPchange.MdiParent = Me
            frmPchange.BringToFront()
        End If

    End Sub

    Private Sub M2003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCashier.Dispose()
        FrmRCPT.Show()
        FrmRCPT.MdiParent = Me
        FrmRCPT.BringToFront()
    End Sub

    Private Sub M6002_Click(sender As Object, e As EventArgs) Handles M6002.Click
        FrmCashier.Dispose()
        FrmGRNRPT.Show()
        FrmGRNRPT.MdiParent = Me
        FrmGRNRPT.BringToFront()
    End Sub

    Private Sub M7002_Click(sender As Object, e As EventArgs) Handles M7003.Click
        FrmStkAdjust.Show()
        FrmStkAdjust.MdiParent = Me
        FrmStkAdjust.BringToFront()
    End Sub

    Private Sub M7003_Click(sender As Object, e As EventArgs) Handles M7001.Click
        FrmCashier.Dispose()
        FrmUserControl.Show()
        FrmUserControl.MdiParent = Me
        FrmUserControl.BringToFront()
    End Sub

    Private Sub M6003_Click(sender As Object, e As EventArgs)
        FrmCashier.Dispose()
        txtCNT.Text = 500
        FrmRPT.Show()
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        'FrmCashier.Close()
        'AboutBox1.Show()
        'AboutBox1.MdiParent = Me
        'AboutBox1.BringToFront()
    End Sub

    Private Sub ImportFromExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles M7004.Click
        FrmCashier.Dispose()
        FrmExcel.Show()
        FrmExcel.MdiParent = Me
        FrmExcel.BringToFront()
    End Sub

    Private Sub CASHCHQDepositeWidrawToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CASHCHQDepositeWidrawToolStripMenuItem.Click
        FrmCashier.Dispose()
        FrmBANK.Show()
        FrmBANK.MdiParent = Me
        FrmBANK.BringToFront()
    End Sub

    Private Sub ErrorCorrectionToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FrmCashier.Dispose()
        FrmErrorCorrec.Show()
        FrmErrorCorrec.MdiParent = Me
        FrmErrorCorrec.BringToFront()
    End Sub

    Private Sub FrmToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        FrmCashier.Dispose()
        Form1.Show()
        Form1.MdiParent = Me
        Form1.BringToFront()
    End Sub

    Private Sub UName_TextChanged(sender As Object, e As EventArgs) Handles UName.TextChanged

    End Sub

    Private Sub FrmMDI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'FrmCashier.Dispose()
        'FrmBANK.Show()
        'FrmBANK.MdiParent = Me
        'FrmBANK.BringToFront()
    End Sub

    Private Sub M2000_Click(sender As Object, e As EventArgs) Handles M2000.Click

    End Sub

    Private Sub M1000_Click(sender As Object, e As EventArgs) Handles M1000.Click

    End Sub

    Private Sub M4000_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtPP.TextChanged

    End Sub

    Private Sub M3004_Click(sender As Object, e As EventArgs) Handles M3004.Click
        FrmCashier.Dispose()
        FrmBANK.Show()
        FrmBANK.MdiParent = Me
        FrmBANK.BringToFront()
    End Sub

    Private Sub M7000_Click(sender As Object, e As EventArgs) Handles M7000.Click

    End Sub

    Private Sub M2003_Click_1(sender As Object, e As EventArgs) Handles M2003.Click
        FrmCashier.Dispose()
        ' FrmCash1.Dispose()
        Frmgg.Show()
        Frmgg.MdiParent = Me
        Frmgg.BringToFront()
    End Sub

    Private Sub CHARTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CHARTToolStripMenuItem.Click
        FrmCashier.Dispose()
        FrmSALESRE.Show()
        FrmSALESRE.MdiParent = Me
        FrmSALESRE.BringToFront()
    End Sub

    Private Sub FrmMDI_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'FrmCashier.Dispose()
        'FrmCashier.Show()
        'FrmCashier.MdiParent = Me
        'FrmCashier.BringToFront()
    End Sub

    Private Sub FrmMDI_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            ' FrmCashier.WindowState = FormWindowState.Minimized
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Try
                'FrmCashier.Close()
                Dim xw As Integer = Screen.PrimaryScreen.Bounds.Width
                If xw < 1920 Then
                    'FrmCash1.Hide()
                    'FrmCash1.Show()
                    'FrmCash1.BringToFront()
                    'FrmCash1.WindowState = FormWindowState.Maximized
                    'FrmCash1.MdiParent = Me
                    FrmCash1.op()

                Else
                    'FrmCashier.Hide()
                    'FrmCashier.Show()
                    'FrmCashier.MdiParent = Me
                    'FrmCashier.BringToFront()
                    'FrmCashier.WindowState = FormWindowState.Maximized
                    FrmCashier.op()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            ' FrmCashier.Dispose()
            FrmCashier.op()
        End If

    End Sub

    Private Sub txtPP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPP.KeyDown
        If e.KeyCode = 13 Then
            Dim xx As Integer = 0
            cmd = New SqlCommand("Select xINT from User_Option where UserName='" & UName.Text & "'", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                xx = rdr("xINT")
            End If
            rdr.Close()
            If xx = 1 Then
                txtPP.Visible = True
                If txtPP.Text = "ANAH5477" Then
                    frmPchange.Show()
                    frmPchange.MdiParent = Me
                    frmPchange.BringToFront()
                    txtPP.Clear()
                    txtPP.Visible = False
                Else
                    txtPP.Clear()
                    Return
                End If
            Else
            End If
        ElseIf e.KeyCode = 27 Then
            txtPP.Clear()
            txtPP.Visible = False
        End If
    End Sub
End Class
