Imports System.Data.SqlClient
Imports ConnData
Imports System.Windows.Forms.Application
Public Class FrmSupPament
    Dim obj As New CashHandle
    Private Sub FrmSupPament_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
        Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = xW
        Me.Height = xH
        Me.WindowState = FormWindowState.Maximized
        PayDay.Value = Format(Now, "yyyy-MM-dd")
        DTP2.Value = Format(Now, "yyyy-MM-dd")
        UnitID.Text = Trim(FrmMDI.ToolStripStatusLabel2.Text)
        Panel2.Hide()
        UNIL()
        AccountLoad()

        BanknameLoad()
        'AboutBox1.Close()

    End Sub
    Private Sub AccountLoad()
        cmd = New SqlCommand("Select * from Bank_Main", con)
        rdr = cmd.ExecuteReader
        CmbAccount.Items.Clear()
        CmbAccount.Items.Add("ON-DRAWER")
        While rdr.Read
            CmbAccount.Items.Add(rdr("AccNo"))
        End While
        rdr.Close()
    End Sub
    Private Sub BanknameLoad()
        cmd = New SqlCommand("Select * from BankName order by BankName", con)
        rdr = cmd.ExecuteReader
        CmbBank.Items.Clear()
        While rdr.Read
            CmbBank.Items.Add(rdr("BankName").ToString)
        End While
        rdr.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub GRID4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID4.CellContentClick

    End Sub

    Private Sub Amount_TextChanged(sender As Object, e As EventArgs) Handles Amount.TextChanged

    End Sub

    Private Sub Amount_KeyDown(sender As Object, e As KeyEventArgs) Handles Amount.KeyDown
        If e.KeyCode = 13 Then
            ' If ChqNo.Text = "" Or CmbAccount.Text = "" Or Amount.Text = "" Then Return
            If RBT1.Checked = True Then
                If ChqNo.Text = "" Or CmbBank.Text = "" Or Amount.Text = "" Then Return
            End If
            If (RBT1.Checked = False And RBT2.Checked = False) Then Return
            If RBT2.Checked = True Then
                If CmbAccount.Text = "" Then Return

            End If


            Dim RowTrue As Boolean = False, RowID As Integer = 0
            For Each row As DataGridViewRow In GRID4.Rows
                If (row.Cells(0).Value = CHQNo.Text And row.Cells(4).Value = CmbAccount.Text) Then
                    RowTrue = True : RowID = row.Index : Exit For
                End If
            Next
            If RowTrue = True Then
                GRID4.Rows(RowID).Cells(3).Value = Format(Val(Amount.Text), "0.00")
                GRID4.Rows(RowID).Cells(2).Value = CmbBank.Text
            Else
                GRID4.Rows.Add(CHQNo.Text, DTP2.Text, CmbBank.Text, Format(Val(Amount.Text), "0.00"), CmbAccount.Text)
            End If
            ' CHQNo.Clear()
            Amount.Clear()
            Dim ChqAmounts As Double = 0
            For Each row As DataGridViewRow In GRID4.Rows
                ChqAmounts += Val(row.Cells(3).Value)
            Next
            txtChQPay.Text = ChqAmounts
            txtChQPay.Text = Format(Val(txtChQPay.Text), "0.00")
            txtTotalPaid.Text = Val(txtChQPay.Text) + Val(txtCash.Text)
            txtTotalPaid.Text = Format(Val(txtTotalPaid.Text), "0.00")
            DTP2.Enabled = True
            CmbBank.Enabled = True
            Amount.ReadOnly = False

        End If
    End Sub

    Private Sub FrmSupPament_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
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
    Private Sub UNIL()
        cmd = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xAAA = rdr("SPAY")
            PAYNO.Text = rdr("UnitID") & "SP-" & xAAA
        End If
        rdr.Close()
    End Sub

    Private Sub SupCode_TextChanged(sender As Object, e As EventArgs) Handles SupCode.TextChanged

    End Sub

    Private Sub SupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles SupCode.KeyDown

        If e.KeyCode = 113 Then

            txtSupID_TextChanged(sender, EventArgs.Empty)
            Panel1.Hide()
            Panel2.Show()
            txtSupID.Focus()


        ElseIf e.KeyCode = 13 Then
            xSUP(SupCode.Text)
            'xSPGR(SupCode.Text)
            'sPAY(SupCode.Text)

        ElseIf e.KeyCode = 27 Then

            CmdCancel_Click(sender, EventArgs.Empty)


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

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        UNIL()
        SupCode.Clear()
        SupName.Clear()
        txtCurBal.Clear()
        GRID4.Rows.Clear()
        ChqNo.DropDownStyle = ComboBoxStyle.DropDown
        ChqNo.Items.Clear()
        RBT1.Checked = False
        RBT2.Checked = False
        Amount.Clear()
        txtChQPay.Clear()
        txtCash.Clear()
        PayDescrip.Clear()
        PayDay.Value = Format(Now, "yyyy-MM-dd")
        DTP2.Value = Format(Now, "yyyy-MM-dd")
        AccountLoad()
        BanknameLoad()

        For Each form In My.Application.OpenForms
            If (form.name = FrmCashier.Name) Then
                FrmCashier.Dispose()
                FrmCashier.Show()
                FrmCashier.MdiParent = Me
                FrmCashier.BringToFront()
                'If form.Visible Then
                '    'do work when visible
                'End If
            End If
        Next





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

    Private Sub GRID2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentClick

    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        xSUP(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel1.Show()
    End Sub

    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.Rows.Count = 0 Then Return
            xSUP(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel1.Show()
            ' xSPGR(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            'sPAY(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        End If
    End Sub
    Private Sub xSUP(ByVal xSP As String)
        cmd = New SqlCommand("Select * from Supplier where SupCode='" & xSP & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            SupCode.Text = rdr("SupCode").ToString
            SupName.Text = rdr("SupName").ToString
            txtCurBal.Text = rdr("SupBalance").ToString
            txtCurBal.Text = Format(Val(txtCurBal.Text), "0.00")
        End If
        rdr.Close()
    End Sub
    Private Sub txtSupID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupID.KeyDown
        If e.KeyCode = 27 Then
            txtSupID.Clear()
            txtSupName.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()
            'Panel3.Hide()
            Panel1.Show()
            txtSupID.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtSupName.Focus()
        End If
    End Sub
    Private Sub txtSupName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupName.KeyDown
        If e.KeyCode = 27 Then
            txtSupID.Clear()
            txtSupName.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()
            'Panel3.Hide()
            Panel1.Show()
            txtSupID.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtSupID.Focus()
        End If
    End Sub
    Private Sub GRID4_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID4.CellContentDoubleClick
        ChqNo.Text = GRID4.Item(0, GRID4.CurrentRow.Index).Value
        DTP2.Text = GRID4.Item(1, GRID4.CurrentRow.Index).Value
        CmbBank.Text = GRID4.Item(2, GRID4.CurrentRow.Index).Value
        Amount.Text = GRID4.Item(3, GRID4.CurrentRow.Index).Value
        CmbAccount.Text = GRID4.Item(4, GRID4.CurrentRow.Index).Value
        GRID4.Rows.RemoveAt(GRID4.CurrentRow.Index)

        Dim ChqAmounts As Double = 0
        For Each row As DataGridViewRow In GRID4.Rows
            ChqAmounts += Val(row.Cells(3).Value)
        Next
        txtChQPay.Text = ChqAmounts
        txtChQPay.Text = Format(Val(txtChQPay.Text), "0.00")
        txtTotalPaid.Text = Val(txtChQPay.Text) + Val(txtCash.Text)
        txtTotalPaid.Text = Format(Val(txtTotalPaid.Text), "0.00")

    End Sub
    Private Sub txtChQPay_TextChanged(sender As Object, e As EventArgs) Handles txtChQPay.TextChanged
        txtTotalPaid.Text = Val(txtChQPay.Text) + Val(txtCash.Text)
        txtTotalPaid.Text = Format(Val(txtTotalPaid.Text), "0.00")
    End Sub
    Private Sub txtTotalPaid_TextChanged(sender As Object, e As EventArgs) Handles txtTotalPaid.TextChanged
        'txtTotalPaid.Text = Val(txtChQPay.Text) + Val(txtCash.Text)
        'txtTotalPaid.Text = Format(Val(txtTotalPaid.Text), "0.00")
    End Sub
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If SupCode.Text = "" Or Val(txtTotalPaid.Text) = 0 Then Return
        If CmbAccount.Text <> "ON-DRAWER" Then

            ' If RBT1.Checked = False And RBT2.Checked = False Then Return
        End If
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Do Payment for this Supplier ?", "Supplier Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            Dim xT As Boolean = False
            If GRID4.Rows.Count = 0 Then
                'AutoID,                                            SupCode,                SupName,                AccNo,          BankName,          CHQNo,       CHQAmnt,   CHQUpdate,                         LastUpdate,                              Uptime,                         UName
                cmd = New SqlCommand("Insert CHQPAY_Sub values('" & SupCode.Text & "','" & SupName.Text & "','" & PAYNO.Text & "','" & "-" & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "-" & "','" & "N" & "')", con)
                cmd.ExecuteNonQuery()
            End If
            For i As Integer = 0 To GRID4.Rows.Count - 1
                cmd = New SqlCommand("Select * from CHQPAY_Sub where(CHQNo='" & GRID4(0, i).Value & "'and BankName='" & GRID4(2, i).Value & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    xT = True
                Else
                    xT = False
                End If
                rdr.Close()
            Next
            If xT = True Then
                MessageBox.Show("One or more CHEQUES alredy paid please check again")
                Return
            ElseIf xT = False Then
                For i As Integer = 0 To GRID4.Rows.Count - 1
                    Dim AccNum As String = GRID4(4, i).Value
                    If GRID4(4, i).Value = "" Then
                        AccNum = "ON-HAND"
                    Else
                    End If
                    'AutoID,                                            SupCode,                SupName,                AccNo,              BankName,                       CHQNo,                      CHQAmnt,                    CHQUpdate,              LastUpdate,                              Uptime,                         UName
                    cmd = New SqlCommand("Insert CHQPAY_Sub values('" & SupCode.Text & "','" & SupName.Text & "','" & PAYNO.Text & "','" & GRID4(2, i).Value & "','" & GRID4(0, i).Value & "','" & GRID4(3, i).Value & "','" & GRID4(1, i).Value & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & AccNum & "','" & "PAID" & "')", con)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update ChqRcv set Status='" & "PAID" & "'where CHQNo='" & GRID4(0, i).Value & "'and Bank='" & GRID4(2, i).Value & "'", con)
                    cmd.ExecuteNonQuery()
                    Dim ChqDetais As String = GRID4(0, i).Value & " - " & GRID4(2, i).Value & " - " & GRID4(1, i).Value
                    '                                                   PayNo,              PayDate,                PayMethod,          UnitID,             SupCode,                   Amount,                     LastUpdate
                    cmd = New SqlCommand("Insert SUPPayment values('" & PAYNO.Text & "','" & PayDay.Value & "','" & "CHEQUE" & "','" & UnitID.Text & "','" & SupCode.Text & "','" & GRID4(3, i).Value & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & PayDescrip.Text & "','" & ChqDetais & "')", con)
                    cmd.ExecuteNonQuery()
                Next
                If Val(txtCash.Text) > 0 Then
                    '                                                   PayNo,              PayDate,                PayMethod,      UnitID,             SupCode,                Amount,                     LastUpdate
                    cmd = New SqlCommand("Insert SUPPayment values('" & PAYNO.Text & "','" & PayDay.Value & "','" & "CASH" & "','" & UnitID.Text & "','" & SupCode.Text & "','" & txtCash.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & PayDescrip.Text & "','" & "-" & "')", con)
                    cmd.ExecuteNonQuery()
                End If
                If Val(txtCash.Text) > 0 Then
                    If CmbAccount.Text <> "ON-DRAWER" Then
                        '                                                 AccNo,                   BankName,                                     Description,    Debit,           Credit,                       LastUpdate,                             UpTime,                       UName
                        cmd = New SqlCommand("Insert Acc_Main values('" & CmbAccount.Text & "','" & CmbBank.Text & "','" & "Cash Paid For " & SupName.Text & "','" & 0 & "','" & Val(txtCash.Text) & "','" & PayDay.Value & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                        cmd.ExecuteNonQuery()
                        cmd = New SqlCommand("Update Bank_Main set TotalWD+= '" & Val(txtCash.Text) & "'where AccNo='" & CmbAccount.Text & "'", con)
                        cmd.ExecuteNonQuery()
                    ElseIf CmbAccount.Text = "ON-DRAWER" Then
                        obj.xSettle(0, 0, 0, 0, Val(txtCash.Text), 0, 0, PayDay.Text, FrmMDI.UName.Text, 0, 0)
                        xDayEndUpdate(PayDay.Value, 0, 0, 0, Val(txtCash.Text), 0, 0, 0, 0)
                        ' AutoID,                                          PayAccount,               Description,               Amnt,                   LastUpdate, UName
                        cmd = New SqlCommand("Insert Pay_Master values('" & SupName.Text & "','" & "Suplier Payment" & "','" & txtCash.Text & "','" & PayDay.Value & "','" & FrmMDI.UName.Text & "')", con)
                        cmd.ExecuteNonQuery()
                    End If
                End If
                '(Supplier Balance Update)**************************************************************************************************************
                cmd = New SqlCommand("Select * from Supplier where SupCode='" & SupCode.Text & "'", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    Dim xCSH As Double = rdr("SupBalance")
                    cmd1 = New SqlCommand("Update Supplier Set SupBalance='" & xCSH - Val(txtTotalPaid.Text) & "'where SupCode='" & SupCode.Text & "'", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()

                '                                                    SupCode,           SupName,                    GrnDate,           Descp,       GrnAmnt,    PayDate,               Descr,                 PayAmnt
                cmd1 = New SqlCommand("Insert SupState values('" & SupCode.Text & "','" & SupName.Text & "','" & PayDay.Value & "','" & "-" & "','" & 0 & "','" & PayDay.Value & "','" & "PAID" & "','" & Val(txtTotalPaid.Text) & "')", con1)
                cmd1.ExecuteNonQuery()



                '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
                cmd = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    zAAA = rdr("SPAY")
                End If
                rdr.Close()
                cmd = New SqlCommand("Update Workstation set SPAY='" & zAAA + 1 & "'  where(UnitID='" & UnitID.Text & "')", con)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Supplier Payment Succeed.", "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                'Dim result2 As DialogResult = MessageBox.Show("Do you want to Do Print Receipt for this Payment ?", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                'If result2 = vbYes Then
                '    Dim PrnCls As New PrintClass
                '    PrnCls.StartPrint()
                '    If PrnCls.prn.PrinterIsOpen = True Then
                '        PrnCls.SupReceipt(SupName.Text, PAYNO.Text, PayDay.Text, Val(txtCurBal.Text), Val(txtTotalPaid.Text))
                '        PrnCls.EndPrint()
                '    End If
                'End If
                CmdCancel_Click(sender, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged
        txtTotalPaid.Text = Val(txtChQPay.Text) + Val(txtCash.Text)
        txtTotalPaid.Text = Format(Val(txtTotalPaid.Text), "0.00")
    End Sub

    Private Sub SupCode_MouseClick(sender As Object, e As MouseEventArgs) Handles SupCode.MouseClick
        txtSupID_TextChanged(sender, EventArgs.Empty)
        Panel1.Hide()
        Panel2.Show()
        txtSupID.Focus()
    End Sub

    Private Sub SupCode_GotFocus(sender As Object, e As EventArgs) Handles SupCode.GotFocus
        SupCode.BackColor = Color.Yellow
    End Sub

    Private Sub SupCode_LostFocus(sender As Object, e As EventArgs) Handles SupCode.LostFocus
        SupCode.BackColor = Color.White
    End Sub

    Private Sub txtSupID_GotFocus(sender As Object, e As EventArgs) Handles txtSupID.GotFocus
        txtSupID.BackColor = Color.Yellow
    End Sub

    Private Sub txtSupID_LostFocus(sender As Object, e As EventArgs) Handles txtSupID.LostFocus
        txtSupID.BackColor = Color.White
    End Sub

    Private Sub txtSupName_LostFocus(sender As Object, e As EventArgs) Handles txtSupName.LostFocus
        txtSupName.BackColor = Color.White
    End Sub

    Private Sub txtSupName_GotFocus(sender As Object, e As EventArgs) Handles txtSupName.GotFocus
        txtSupName.BackColor = Color.Yellow
    End Sub

    Private Sub CHQNo_GotFocus(sender As Object, e As EventArgs)
        ChqNo.BackColor = Color.Yellow
    End Sub

    Private Sub CHQNo_Layout(sender As Object, e As LayoutEventArgs)

    End Sub

    Private Sub CmbBank_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmbBank_GotFocus(sender As Object, e As EventArgs)
        CmbBank.BackColor = Color.Yellow
    End Sub

    Private Sub CmbBank_LostFocus(sender As Object, e As EventArgs)
        CmbBank.BackColor = Color.White
    End Sub

    Private Sub Amount_GotFocus(sender As Object, e As EventArgs) Handles Amount.GotFocus
        Amount.BackColor = Color.Yellow
    End Sub

    Private Sub Amount_LostFocus(sender As Object, e As EventArgs) Handles Amount.LostFocus
        Amount.BackColor = Color.White
    End Sub

    Private Sub txtCash_GotFocus(sender As Object, e As EventArgs) Handles txtCash.GotFocus
        txtCash.BackColor = Color.Yellow
    End Sub

    Private Sub txtCash_LostFocus(sender As Object, e As EventArgs) Handles txtCash.LostFocus
        txtCash.BackColor = Color.White
    End Sub

    Private Sub PayDescrip_TextChanged(sender As Object, e As EventArgs) Handles PayDescrip.TextChanged

    End Sub

    Private Sub PayDescrip_GotFocus(sender As Object, e As EventArgs) Handles PayDescrip.GotFocus
        PayDescrip.BackColor = Color.Yellow
    End Sub

    Private Sub PayDescrip_LostFocus(sender As Object, e As EventArgs) Handles PayDescrip.LostFocus
        PayDescrip.BackColor = Color.White
    End Sub

    Private Sub CHQNo_LostFocus(sender As Object, e As EventArgs)
        ChqNo.BackColor = Color.White
    End Sub

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        Dim result11 As DialogResult = MessageBox.Show("Are you sure to Add New Account ?", "Add Acount", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result11 = vbYes Then
            Dim PAccnt As String = InputBox("Please Enter an Account Number with Bank Name")
            If PAccnt = "" Then
            Else
                Dim BAccountNumber As String = PAccnt.Split(" ")(0)
                Dim BAccountName As String = PAccnt.Split(" ")(1)
                cmd = New SqlCommand("Select * from Bank_Main where(AccNo='" & BAccountNumber & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                Else
                    '                                                     AccNo,                BankName,           TotalWD,    TotalDEP,   TotalRET,           LastUpdate,                         UpTime,                         UName
                    cmd1 = New SqlCommand("Insert Bank_Main values('" & BAccountNumber & "','" & BAccountName & "','" & 0 & "','" & 0 & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()
                MessageBox.Show("Add New Succeed.", "Add New Account", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                AccountLoad()
                CmbAccount.Text = BAccountNumber
            End If
        End If

    End Sub

    Private Sub CmbAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAccount.SelectedIndexChanged
        cmd = New SqlCommand("Select * from Bank_Main where(AccNo='" & CmbAccount.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            CmbBank.Text = rdr("BankName")
        Else
            CmbBank.Text = ""
            CmbBank.SelectedIndex = -1

        End If
        rdr.Close()
    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click
        If CmbAccount.Text = "" Then Return
        Dim result11 As DialogResult = MessageBox.Show("Are you sure to Delete Account ?", "Delete Acount", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result11 = vbYes Then
            cmd = New SqlCommand("Delete from Bank_Main where(AccNo='" & CmbAccount.Text & "')", con)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Account Delete Succeed.", "Delete Acount", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            AccountLoad()
        End If

    End Sub

    Private Sub RBT1_CheckedChanged(sender As Object, e As EventArgs) Handles RBT1.CheckedChanged
        If RBT1.Checked = True Then
            cmd = New SqlCommand("Select CHQNo from ChqRcv where(Status='" & "ON-HAND" & "')", con)
            rdr = cmd.ExecuteReader
            ChqNo.Items.Clear()
            While rdr.Read
                ChqNo.Items.Add(rdr("CHQNo"))
            End While
            rdr.Close()
            ChqNo.DropDownStyle = ComboBoxStyle.DropDownList
            DTP2.Value = Format(Now, "yyyy-MM-dd")
            Amount.Clear()
        End If
    End Sub

    Private Sub RBT2_CheckedChanged(sender As Object, e As EventArgs) Handles RBT2.CheckedChanged
        If RBT2.Checked = True Then
            ChqNo.Text = ""
            ChqNo.Items.Clear()
            ChqNo.DropDownStyle = ComboBoxStyle.DropDown
            DTP2.Value = Format(Now, "yyyy-MM-dd")
            Amount.Clear()
        End If
    End Sub

    Private Sub ChqNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChqNo.SelectedIndexChanged
        Dim xcv As Boolean = False
        Dim xBANK As String = Nothing
        cmd = New SqlCommand("Select * from ChqRcv where(CHQNo='" & ChqNo.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            DTP2.Text = rdr("ChqDate")
            xBANK = rdr("Bank")
            Amount.Text = rdr("Amount")
            xcv = True
            DTP2.Enabled = False
            CmbBank.Enabled = False
            Amount.Focus()
            Amount.ReadOnly = True

        Else
            xcv = False
            DTP2.Enabled = True
            CmbBank.Enabled = True
            Amount.ReadOnly = False
            DTP2.Value = Format(Now, "yyyy-MM-dd")
            Amount.Clear()
        End If
        rdr.Close()
        xcv = True
        CmbAccount.SelectedIndex = -1
        CmbAccount.SelectedItem = ""
        CmbAccount.Text = ""
        CmbBank.Text = xBANK
    End Sub
End Class