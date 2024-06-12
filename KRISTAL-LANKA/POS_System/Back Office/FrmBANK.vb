Imports System.Data.SqlClient
Imports ConnData
Imports POS_System.NewFunc
Public Class FrmBANK

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

    Private Sub FrmBANK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
        Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = xW
        Me.Height = xH
        Me.WindowState = FormWindowState.Maximized
        xBANK()

        OnhandChqLoad()
        CHK1.Checked = False
        ExLoad()

        'AboutBox1.Close()
    End Sub
    Private Sub ExLoad()
        cmd = New SqlCommand("Select * from PayAcc order by AccName", con)
        rdr = cmd.ExecuteReader
        CmbAccEx.Items.Clear()
        CmbAccEx.Items.Add("")
        While rdr.Read
            CmbAccEx.Items.Add(rdr("AccName"))
        End While
        rdr.Close()
    End Sub

    Private Sub FrmBANK_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
    End Sub

    Private Sub xBANK()
        cmd = New SqlCommand("Select * from Bank_Main ", con)
        rdr = cmd.ExecuteReader
        CmbAccount.Items.Clear()
        CmbAccount1.Items.Clear()
        While rdr.Read
            CmbAccount.Items.Add(rdr("AccNo") & " - " & rdr("BankName"))
            CmbAccount1.Items.Add(rdr("AccNo") & " - " & rdr("BankName"))
        End While
        rdr.Close()
    End Sub
    Private Sub OnhandChqLoad()
        Dim DepBool As Boolean = False
        cmd = New SqlCommand("Select * from ChqRcv where(Status='" & "ON-HAND" & "')", con)
        rdr = cmd.ExecuteReader
        GRID4.Rows.Clear()
        While rdr.Read

            GRID4.Rows.Add(rdr("CHQNo"), Format(rdr("ChqDate"), "yyyy-MM-dd"), rdr("Bank"), Format(rdr("Amount"), "0.00"), DepBool)
        End While
        rdr.Close()
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If Val(TotalAmnt.Text) = 0 and CmbAccount.Text = "" Then Return
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Depsite..?", "CASH / CHQ DEPOSIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
              Dim BAccountNumber As String = CmbAccount.Text.Split(" - ")(0)
            Dim BankName As String = CmbAccount.Text.Split(" - ")(2)
            If GRID4.Rows.Count > 0 Then
                For Each row As DataGridViewRow In GRID4.Rows
                    If row.Cells(4).Value = True Then
                        cmd = New SqlCommand("Update ChqRcv set Status='" & "DEPOSIT" & "'where CHQNo='" & row.Cells(0).Value & "'and Bank='" & row.Cells(2).Value & "'", con)
                        cmd.ExecuteNonQuery()
                        ''                                                     AccNo,                  BankName,            Description,                                  Debit,             Credit,             LastUpdate,                     UpTime,                         UName
                        'cmd = New SqlCommand("Insert Acc_Main values('" & BAccountNumber & "','" & BankName & "','" & row.Cells(0).Value & " Deposit" & "','" & row.Cells(3).Value & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                        'cmd.ExecuteNonQuery()

                        '                                                     AccNo,                  BankName,            Description,                       Debit,        Credit,             LastUpdate,                     UpTime,                         UName
                        cmd = New SqlCommand("Insert Acc_Main values('" & BAccountNumber & "','" & BankName & "','" & row.Cells(0).Value & " Deposit" & "','" & row.Cells(3).Value & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                        cmd.ExecuteNonQuery()
                        cmd = New SqlCommand("Update Bank_Main set TotalDEP+='" & row.Cells(3).Value & "'where AccNo='" & BAccountNumber & "'", con)
                        cmd.ExecuteNonQuery()
                        '                                                 AccNo,                 BankName,                  CHQNo,                  CHQAmnt,                    CHQUpdate,                   LastUpdate,                            Uptime,                           UName
                        cmd = New SqlCommand("Insert CHQ_Dep values('" & BAccountNumber & "','" & BankName & "','" & row.Cells(0).Value & "','" & row.Cells(3).Value & "','" & row.Cells(1).Value & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "DEPOSIT" & "','" & row.Cells(2).Value & "')", con)
                        cmd.ExecuteNonQuery()


                    End If
                Next


            End If
            If Val(CashAmnt.Text) > 0 Then
                '                                                     AccNo,                  BankName,            Description,                    Debit,             Credit,             LastUpdate,                     UpTime,                         UName
                cmd = New SqlCommand("Insert Acc_Main values('" & BAccountNumber & "','" & BankName & "','" & "Cash" & " Deposit" & "','" & Val(CashAmnt.Text) & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Update Bank_Main set TotalDEP+='" & Val(CashAmnt.Text) & "'where AccNo='" & BAccountNumber & "'", con)
                cmd.ExecuteNonQuery()
                xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, 0, 0, 0, 0, Val(CashAmnt.Text), 0, 0)
            End If
            MessageBox.Show("Deposit Succeed.", "CHQ / Cash Deposit", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CmdCancel_Click(sender, EventArgs.Empty)
        End If

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        xBANK()
        ChqAmnt.Clear()
        CashAmnt.Clear()
        OnhandChqLoad()
    End Sub

    Private Sub CashAmnt_TextChanged(sender As Object, e As EventArgs) Handles CashAmnt.TextChanged
        TotalAmnt.Text = Val(CashAmnt.Text) + Val(ChqAmnt.Text)
        TotalAmnt.Text = Format(Val(TotalAmnt.Text), "0.00")
    End Sub

    Private Sub ChqAmnt_TextChanged(sender As Object, e As EventArgs) Handles ChqAmnt.TextChanged
        TotalAmnt.Text = Val(CashAmnt.Text) + Val(ChqAmnt.Text)
        TotalAmnt.Text = Format(Val(TotalAmnt.Text), "0.00")
    End Sub
    Private Sub CmdUpdate_Click(sender As Object, e As EventArgs) Handles CmdUpdate.Click
        Dim ChqAmounts As Double = 0
        For Each row As DataGridViewRow In GRID4.Rows
            Dim xTR As Boolean = row.Cells(4).Value
            If xTR = True Then
                ChqAmounts += row.Cells(3).Value
            End If
        Next
        ChqAmnt.Text = ChqAmounts
        ChqAmnt.Text = Format(Val(ChqAmnt.Text), "0.00")
    End Sub

    Private Sub CmdUpdate1_Click(sender As Object, e As EventArgs) Handles CmdUpdate1.Click
        Dim ChqAmounts As Double = 0
        For Each row As DataGridViewRow In GRID1.Rows
            Dim xTR As Boolean = row.Cells(4).Value
            If xTR = True Then
                ChqAmounts += row.Cells(3).Value
            End If
        Next
        ReturnAmnt.Text = ChqAmounts
        ReturnAmnt.Text = Format(Val(ReturnAmnt.Text), "0.00")
    End Sub

    Private Sub CmbAccount1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAccount1.SelectedIndexChanged
        Dim BAccountNumber As String = CmbAccount1.Text.Split(" - ")(0)
        Dim DepBool As Boolean = False
        cmd = New SqlCommand("Select * from CHQ_Dep where(AccNo='" & BAccountNumber & "'and Status='" & "DEPOSIT" & "')", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CHQNo"), Format(rdr("ChqDate"), "yyyy-MM-dd"), rdr("Bank"), Format(rdr("Amount"), "0.00"), DepBool)
        End While
        rdr.Close()

        cmd = New SqlCommand("Select * from CHQPAY_Sub where(BankAcc='" & BAccountNumber & "'and Status='" & "PAID" & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            GRID1.Rows.Add(rdr("CHQNo"), Format(rdr("CHQUpdate"), "yyyy-MM-dd"), rdr("BankName"), Format(rdr("CHQAmnt"), "0.00"), DepBool)
        End While
        rdr.Close()

        cmd = New SqlCommand("Select ISNULL(Sum(Debit - Credit),0) from Acc_Main where AccNo='" & BAccountNumber & "'and LastUpdate<='" & Format(Now, "yyyy-MM-dd") & "'", con)
        Dim gg As Double = cmd.ExecuteScalar
        txtBal.Text = Format(gg, "0.00")

        CHK1.Checked = False
    End Sub

    Private Sub CmdCancel1_Click(sender As Object, e As EventArgs) Handles CmdCancel1.Click
        xBANK()
        ReturnAmnt.Clear()
        WidrawAmnt.Clear()
        Descrip.Clear()
        GRID1.Rows.Clear()
        txtBal.Clear()
        ExLoad()
    End Sub

    Private Sub CmdExit1_Click(sender As Object, e As EventArgs) Handles CmdExit1.Click
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

    Private Sub CmdSave1_Click(sender As Object, e As EventArgs) Handles CmdSave1.Click
        If CHK1.Checked = False And Val(ReturnAmnt.Text) = 0 And Val(WidrawAmnt.Text) = 0 Then Return
        ' If CmbAccEx.Text = "" Then Return
        If Val(WidrawAmnt.Text) > 0 Then
            If CmbAccount1.Text = "" Then Return
        End If
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Return or Widraw..?", "CHQ RETURN / CASH WIDRAW", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            Dim xExAcc As String = Nothing
            Dim BAccountNumber As String = Nothing
            Dim BankName As String = Nothing
            If CmbAccount1.Text <> "" Then
                BAccountNumber = CmbAccount1.Text.Split(" - ")(0)
                BankName = CmbAccount1.Text.Split(" - ")(2)
            ElseIf CmbAccount1.Text = "" Then
                BAccountNumber = "ON-HAND"
                BankName = "ON-HAND"
            End If

            If Val(WidrawAmnt.Text) > 0 Then
                '                                                     AccNo,                  BankName,             Description,           Debit,             Credit,             LastUpdate,                     UpTime,                         UName
                cmd = New SqlCommand("Insert Acc_Main values('" & BAccountNumber & "','" & BankName & "','" & "Cash" & " Widraw for " & Descrip.Text & " - " & CmbAccEx.Text & "','" & 0 & "','" & Val(WidrawAmnt.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Update Bank_Main set TotalWD+='" & Val(CashAmnt.Text) & "'where AccNo='" & BAccountNumber & "'", con)
                cmd.ExecuteNonQuery()
                If CmbAccEx.Text <> "" Then
                    '   AutoID,                                                               Description,                Amnt,                              LastUpdate,                                 UName
                    cmd = New SqlCommand("Insert Pay_Master values('" & CmbAccEx.Text & "','" & Descrip.Text & "','" & Val(WidrawAmnt.Text) & "','" & Format(Now, "yyyy-MM-dd").ToString & "','" & FrmMDI.UName.Text & "')", con)
                    cmd.ExecuteNonQuery()
                    ' xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, 0, 0, 0, Val(WidrawAmnt.Text), 0, 0, 0)
                End If


                xDayEndUpdate(Format(Now, "yyyy-MM-dd"), 0, 0, 0, 0, 0, 0, 0, Val(WidrawAmnt.Text))
            End If
            If GRID1.Rows.Count > 0 Then

                For Each row As DataGridViewRow In GRID1.Rows
                    If row.Cells(4).Value = True Then
                        cmd = New SqlCommand("Update ChqRcv set Status='" & "RETURN" & "'where CHQNo='" & row.Cells(0).Value & "'and Bank='" & row.Cells(2).Value & "'", con)
                        cmd.ExecuteNonQuery()

                        cmd = New SqlCommand("Update CHQ_Dep set Status='" & "RETURN" & "'where CHQNo='" & row.Cells(0).Value & "'and Bank='" & row.Cells(2).Value & "'", con)
                        cmd.ExecuteNonQuery()

                        cmd = New SqlCommand("Update CHQPAY_Sub set Status='" & "RETURN" & "'where CHQNo='" & row.Cells(0).Value & "'", con)
                        cmd.ExecuteNonQuery()
                        If CHK1.Checked = True Then
                        ElseIf CHK1.Checked = False Then
                            '                                                     AccNo,                  BankName,            Description,                                  Debit,             Credit,             LastUpdate,                     UpTime,                         UName
                            cmd = New SqlCommand("Insert Acc_Main values('" & BAccountNumber & "','" & BankName & "','" & row.Cells(0).Value & " Return" & "','" & 0 & "','" & row.Cells(3).Value & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                            cmd.ExecuteNonQuery()
                        End If

                        cmd = New SqlCommand("Update Bank_Main set TotalRET+='" & row.Cells(3).Value & "'where AccNo='" & BAccountNumber & "'", con)
                        cmd.ExecuteNonQuery()
                        '                                                 AccNo,                 BankName,                  CHQNo,                  CHQAmnt,                    CHQUpdate,                   LastUpdate,                            Uptime,                           UName
                        cmd = New SqlCommand("Insert CHQ_Ret values('" & BAccountNumber & "','" & BankName & "','" & row.Cells(0).Value & "','" & row.Cells(3).Value & "','" & row.Cells(1).Value & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "RETURN" & "')", con)
                        cmd.ExecuteNonQuery()
                        cmd = New SqlCommand("Select CusCode,CusName from ChqRcv where(CHQNo='" & row.Cells(0).Value & "'and Bank='" & row.Cells(2).Value & "')", con)
                        rdr = cmd.ExecuteReader
                        If rdr.Read = True Then
                            cmd1 = New SqlCommand("Update Cus_Master set CusBalance+='" & Val(row.Cells(3).Value) & "',RceivedAmt-='" & Val(row.Cells(3).Value) & "'where CusCode='" & rdr("CusCode") & "'", con1)
                            cmd1.ExecuteNonQuery()
                            '                                                   CusCode,                CusName,                            InvDate,                  Descp,                        InvAmnt,                                 RcvDate,            Descr,      RcvAmnt
                            cmd1 = New SqlCommand("Insert CusState values('" & rdr("CusCode") & "','" & rdr("CusName") & "','" & Format(Now, "yyyy-MM-dd") & "','" & "CHQ-RETURN" & "','" & Val(row.Cells(3).Value) & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "')", con1)
                            cmd1.ExecuteNonQuery()
                        End If
                        rdr.Close()
                        cmd = New SqlCommand("Select SupCode,SupName from CHQPAY_Sub where(CHQNo='" & row.Cells(0).Value & "')", con)
                        rdr = cmd.ExecuteReader
                        If rdr.Read = True Then
                            cmd1 = New SqlCommand("Update Supplier set SupBalance+='" & Val(row.Cells(3).Value) & "'where SupCode='" & rdr("SupCode") & "'", con1)
                            cmd1.ExecuteNonQuery()
                            '                                                       SupCode,             SupName,                    GrnDate,                        Descp,                    GrnAmnt,                           PayDate,                     Descr,       PayAmnt
                            cmd1 = New SqlCommand("Insert SupState values('" & rdr("SupCode") & "','" & rdr("SupName") & "','" & Format(Now, "yyyy-MM-dd") & "','" & "CHQ-RETURN" & "','" & Val(row.Cells(3).Value) & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "')", con1)
                            cmd1.ExecuteNonQuery()
                        End If
                        rdr.Close()
                    End If
                Next
            End If
            MessageBox.Show("Return / Widraw Succeed.", "CHQ RETURN / CASH WIDRAWs", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CmdCancel1_Click(sender, EventArgs.Empty)
        End If




    End Sub

    Private Sub CHK1_CheckedChanged(sender As Object, e As EventArgs) Handles CHK1.CheckedChanged
        If CHK1.Checked = True Then
            xBANK()
            Dim DepBool As Boolean = False
            cmd = New SqlCommand("Select * from CHQPAY_Sub where(BankAcc='" & "ON-HAND" & "'and Status='" & "PAID" & "')", con)
            rdr = cmd.ExecuteReader
            GRID1.Rows.Clear()
            While rdr.Read
                GRID1.Rows.Add(rdr("CHQNo"), Format(rdr("CHQUpdate"), "yyyy-MM-dd"), rdr("BankName"), Format(rdr("CHQAmnt"), "0.00"), DepBool)
            End While
            rdr.Close()
        End If

    End Sub

    Private Sub CmdPass_Click(sender As Object, e As EventArgs) Handles CmdPass.Click
        If GRID1.Rows.Count = 0 Then Return
        Dim result1 As DialogResult = MessageBox.Show("Do you want to set PASS these CHQS..?", "SET CHQ PASS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            For Each row As DataGridViewRow In GRID1.Rows
                If row.Cells(4).Value = True Then
                    Dim xDATE1 As Date
                    xDATE1 = row.Cells(1).Value
                    xDATE1 = Format(xDATE1, "yyyy-MM-dd")
                    If xDATE1 >= Format(Now, "yyyy-MM-dd") Then Return
                    cmd = New SqlCommand("Update ChqRcv set Status='" & "PASSED" & "'where CHQNo='" & row.Cells(0).Value & "'and Amount='" & row.Cells(3).Value & "'and ChqDate='" & row.Cells(1).Value & "'", con)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update CHQ_Dep set Status='" & "PASSED" & "'where CHQNo='" & row.Cells(0).Value & "'and Amount='" & row.Cells(3).Value & "'and ChqDate='" & row.Cells(1).Value & "'", con)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update CHQPAY_Sub set Status='" & "PASSED" & "'where CHQNo='" & row.Cells(0).Value & "'and CHQAmnt='" & row.Cells(3).Value & "'and ChqUpdate='" & row.Cells(1).Value & "'", con)
                    cmd.ExecuteNonQuery()
                    Dim xIID As String = row.Cells(0).Value & " Deposit"
                    cmd = New SqlCommand("Update Acc_Main set Debit='" & row.Cells(3).Value & "'where Description='" & xIID & "'", con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            MessageBox.Show("PASSED Succeed.", "SET CHQ PASS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CmdCancel1_Click(sender, EventArgs.Empty)

        End If


    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub CmdStop_Click(sender As Object, e As EventArgs) Handles CmdStop.Click
        If CmbAccount1.Text = "" Or GRID1.Rows.Count = 0 Then Return
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Stop Payments these CHQS..?", "CHQ STOP PAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            Dim BAccountNumber As String = CmbAccount1.Text.Split(" - ")(0)
            Dim BankName As String = CmbAccount1.Text.Split(" - ")(1)
            For i As Integer = 0 To GRID1.Rows.Count - 1
                Dim xc As Boolean = GRID1(4, i).Value
                Dim xDT As Date = GRID1(1, i).Value
                If xc = True Then

                    cmd = New SqlCommand("update CHQPAY_Sub set Status='" & "STOPED" & "'where CHQNo='" & GRID1(0, i).Value & "'and BankAcc='" & BAccountNumber & "'", con)
                    cmd.ExecuteNonQuery()
                    ''                                                     AccNo,              BankName,            Description,                                            Debit,             Credit,                      LastUpdate,                     UpTime,                         UName
                    'cmd = New SqlCommand("Insert Acc_Main values('" & BAccountNumber & "','" & BankName & "','" & GRID1(0, i).Value & " Payment Stopped" & "','" & GRID1(3, i).Value & "','" & 0 & "','" & Format(xDT, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                    'cmd.ExecuteNonQuery()    '                                                     AccNo,              BankName,            Description,                                            Debit,             Credit,                      LastUpdate,                     UpTime,                         UName

                End If
                cmd = New SqlCommand("Select * from CHQPAY_Sub where ChqNo='" & GRID1(0, i).Value & "'and BankAcc='" & BAccountNumber & "'", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    '                                                    SupCode,                 SupName,              GrnDate,           Descp,                     GrnAmnt,             PayDate,               Descr,      PayAmnt
                    cmd1 = New SqlCommand("Insert SupState values('" & rdr("SupCode") & "','" & rdr("SupName") & "','" & xDT & "','" & "Payment Stopped" & "','" & GRID1(3, i).Value & "','" & xDT & "','" & "-" & "','" & 0 & "')", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()




            Next
            MessageBox.Show("Payment Stopped Succeed.", "CHQ PAYMENT STOP", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CmdCancel1_Click(sender, EventArgs.Empty)

        End If
    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub
End Class