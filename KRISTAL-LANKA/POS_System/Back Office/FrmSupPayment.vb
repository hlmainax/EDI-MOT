Imports System.Data.SqlClient
Imports ConnData
Public Class FrmSupPayment
    Dim xAAA As Integer = 0, zAAA As Integer = 0, xZZZ As String = Nothing
    Private Sub FrmSupPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Panel2.Hide()
        CmbBank.Enabled = False
        UnitID.Text = Trim(FrmMDI.ToolStripStatusLabel2.Text)
        UNIL()

        CHQNo.Enabled = False


    End Sub
    Private Sub UNIL()
        cmd = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xAAA = rdr("SPAY")
            PAYNO.Text = rdr("UnitID") & "SPAY" & (Format(xAAA, "00000000"))
        End If
        rdr.Close()
    End Sub



    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub FrmSupPayment_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        'Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        ''Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
    End Sub

    Private Sub SupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles SupCode.KeyDown

        If e.KeyCode = 113 Then

            txtSupID_TextChanged(sender, EventArgs.Empty)
            Panel1.Hide()
            Panel2.Show()
            txtSupID.Focus()


        ElseIf e.KeyCode = 13 Then
            xSUP(SupCode.Text)
            xSPGR(SupCode.Text)
            'sPAY(SupCode.Text)

        ElseIf e.KeyCode = 27 Then

            CmdCancel_Click(sender, EventArgs.Empty)


        End If
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

   
    Private Sub txtSupID_TextChanged(sender As Object, e As EventArgs) Handles txtSupID.TextChanged
        If txtSupID.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier", con)
        Else
            cmd = New SqlCommand("Select * from Supplier SupCode like '" & txtSupID.Text & "%' ", con)
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

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier", con)
        Else
            cmd = New SqlCommand("Select * from Supplier SupName like '" & txtSupName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()


    End Sub

    Private Sub xSUP(ByVal xSP As String)
        cmd = New SqlCommand("Select * from Supplier where SupCode='" & xSP & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            SupCode.Text = rdr("SupCode").ToString
            SupName.Text = rdr("SupName").ToString
        End If
        rdr.Close()
    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        xSUP(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel1.Show()
        xSPGR(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        'sPAY(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
    End Sub

    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.Rows.Count = 0 Then Return
            xSUP(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel1.Show()
            xSPGR(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            'sPAY(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        End If
    End Sub

    Private Sub SupCode_TextChanged(sender As Object, e As EventArgs) Handles SupCode.TextChanged

    End Sub
    Private Sub xSPGR(ByVal xSG As String)
        cmd = New SqlCommand("Select * from GRN_Main where SupCode='" & xSG & "'", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("GRNNo"), (Format(rdr("GRNDate"), "yyyy-MM-dd")), rdr("InvNo"), Format(rdr("Amount"), "0.00"))
        End While
        rdr.Close()
    End Sub
    Private Sub xSPPY(ByVal xGRN As String)
        cmd = New SqlCommand("Select * from SUPPayment where PayNo='" & xGRN & "'", con)
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            ' PAYNO, GRNNo, PayDate, PayMethod, UnitID, SupCode, Amount, Balance, LastUpdate, Uname
            GRID3.Rows.Add(rdr("PayNo"), rdr("GRNNo"), (Format(rdr("PayDate"), "yyyy-MM-dd")), Format(rdr("Amount"), "0.00"), Format(rdr("Balance"), "0.00"))
        End While
        rdr.Close()
    End Sub
    Private Sub RB1_CheckedChanged(sender As Object, e As EventArgs) Handles RB1.CheckedChanged
        If RB1.Checked = True Then
            CmbBank.Enabled = True
            CHQNo.Enabled = True
            xZZZ = "Cheque"

        Else
            CmbBank.Enabled = False
            CHQNo.Enabled = False
            CHQNo.Clear()
            CmbBank.SelectedIndex = -1
            CmbBank.Text = ""
            xZZZ = "Cash"
        End If
    End Sub

    Private Sub RB2_CheckedChanged(sender As Object, e As EventArgs) Handles RB2.CheckedChanged
        If RB2.Checked = True Then
            CmbBank.Enabled = False
            CHQNo.Enabled = False
            CHQNo.Clear()
            CmbBank.SelectedIndex = -1
            CmbBank.Text = ""
            xZZZ = "Cash"
        Else
            CmbBank.Enabled = True
            CHQNo.Enabled = True
            xZZZ = "Cheque"
        End If
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        UNIL()
        SupCode.Clear()
        SupName.Clear()
        PayDay.Value = Date.Now.ToShortDateString
        RB1.Checked = False
        RB2.Checked = False
        xZZZ = Nothing
        CmbBank.SelectedIndex = -1
        CmbBank.Text = ""
        CHQNo.Clear()
        Amount.Clear()
        GRID1.Rows.Clear()
        GRID3.Rows.Clear()
        SupCode.Focus()

    End Sub
    Dim xCASH As Double = 0
    Dim xAMT As Double = 0
    Dim xPRC As Double = 0
    Dim xCNT As Double = 0
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If SupCode.Text = "" Or Amount.Text = "" Or GRNNum.Text = "" Or GRID1.Rows.Count = 0 Or (RB1.Checked = False And RB2.Checked = False) Then Return
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Do Payment for this Supplier ?", "Supplier Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then


            If xZZZ = "Cheque" Then
                If GRID4.Rows.Count = 0 Then Return
                For i As Integer = 0 To GRID4.RowCount - 1
                    '                                       AutoID,     GRNNo,              PAYNO,                  CHQNo,                      ChqDate,                  UnitID,               SupCode,                SupName,             Amount,                      Status,                LastUpdate,                                 UName
                    'cmd = New SqlCommand("Insert CHQ_Main values('" & GRNNum.Text & "','" & PAYNO.Text & "','" & GRID4(1, i).Value & "','" & GRID4(2, i).Value & "','" & UnitID.Text & "','" & SupCode.Text & "','" & SupName.Text & "','" & GRID4(4, i).Value & "','" & "Pending" & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                    'cmd.ExecuteNonQuery()
                    'xCNT += GRID4(4, i).Value
                Next
                ''                                                   PayNo,                 PayDate,         PayMethod,          UnitID,                SupCode,          Amount,              LastUpdate
                cmd = New SqlCommand("Insert SUPPayment values('" & PAYNO.Text & "','" & PayDay.Value & "','" & xZZZ & "','" & UnitID.Text & "','" & SupCode.Text & "','" & xCNT + Val(Amount.Text) & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "')", con)
                cmd.ExecuteNonQuery()
            ElseIf xZZZ = "Cash" Then
                ''                                                   PayNo,                 PayDate,         PayMethod,          UnitID,                SupCode,          Amount,              LastUpdate
                cmd = New SqlCommand("Insert SUPPayment values('" & PAYNO.Text & "','" & PayDay.Value & "','" & xZZZ & "','" & UnitID.Text & "','" & SupCode.Text & "','" & xCNT + Val(Amount.Text) & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "')", con)
                cmd.ExecuteNonQuery()
            End If

            ''(GRN Status Done)**************************************************************************************************************
            'cmd = New SqlCommand("Select * from SUPPayment where GRNNo='" & GRNNum.Text & "'", con)
            'rdr = cmd.ExecuteReader
            'While rdr.Read
            '    xPRC += rdr("Amount")
            'End While
            'rdr.Close()

            'cmd = New SqlCommand("Select * from GRN_Main where GRNNo='" & GRNNum.Text & "'", con)
            'rdr = cmd.ExecuteReader
            'If rdr.Read = True Then
            '    If rdr("Amount") <= xPRC Then
            '        cmd1 = New SqlCommand("Update GRN_Main set Status='" & "Done" & "'where GRNNo='" & GRNNum.Text & "'", con1)
            '        cmd1.ExecuteNonQuery()
            '    End If
            'End If
            'rdr.Close()
            ''****************************************************************************************************************



            '(Supplier Balance Update)**************************************************************************************************************
            cmd = New SqlCommand("Select * from Supplier where SupCode='" & SupCode.Text & "'", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                Dim xCSH As Double = rdr("SupBalance")
                cmd1 = New SqlCommand("Update Supplier Set SupBalance='" & xCSH - Amount.Text & "'where SupCode='" & SupCode.Text & "'", con1)
                cmd1.ExecuteNonQuery()
            End If
            rdr.Close()
            '***************************************************************************************************************************************
            cmd = New SqlCommand("Select * from GRN_Main where(GRNNo='" & GRNNum.Text & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                xCASH = rdr("Amount")
            End If
            rdr.Close()

            cmd = New SqlCommand("Select * from SUPPayment where(PayNo='" & GRNNum.Text & "')", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                xAMT += rdr("Amount")
            End While
            rdr.Close()

            'cmd = New SqlCommand("Update SUPPayment set Balance='" & xCASH - xAMT & "' where payno='" & PAYNO.Text & "' ", con)
            'cmd.ExecuteNonQuery()

            '****
            xSPPY(GRNNum.Text)
            '****

            '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
            cmd = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                zAAA = rdr("SPAY")
            End If
            rdr.Close()
            cmd = New SqlCommand("Update Workstation set SPAY='" & zAAA + 1 & "'  where(UnitID='" & UnitID.Text & "')", con)
            cmd.ExecuteNonQuery()
            '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
            '*********************
            'SupCode, SupName, GrnAmt, SupPay, SupRtn, BalanceAmt, LastUpdate, UName SupAcc_Main
            'cmd = New SqlCommand("Select * from SupAcc_Main where SupCode='" & SupCode.Text & "'", con)
            'rdr = cmd.ExecuteReader
            'If rdr.Read = True Then

            '    cmd1 = New SqlCommand("Update SupAcc_Main set SupPay='" & rdr("SupPay") + Amount.Text & "',BalanceAmt='" & rdr("BalanceAmt") - Amount.Text & "'where SupCode='" & SupCode.Text & "'", con1)
            '    cmd1.ExecuteNonQuery()

            'Else
            '    '                                                     SupCode,                 SupName,           GrnAmt,      SupPay,             SupRtn,         BalanceAmt,                                 LastUpdate,                                UName
            '    cmd1 = New SqlCommand("Insert SupAcc_Main values('" & SupCode.Text & "','" & SupName.Text & "','" & 0 & "','" & Amount.Text & "','" & 0 & "','" & rdr("BalanceAmt") - Amount.Text & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con1)
            '    cmd1.ExecuteNonQuery()
            'End If
            'rdr.Close()
            '*********************

            MessageBox.Show("Supplier Payment Succeed.", "Supplier Payment", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If



        '*******************************************************************************************************************

        '*******************************************************************************************************************





        PayDay.Value = Date.Now.ToShortDateString
        RB1.Checked = False
        RB2.Checked = False
        xZZZ = Nothing
        CmbBank.SelectedIndex = -1
        CmbBank.Text = ""
        CHQNo.Clear()
        Amount.Clear()
        GRID4.Rows.Clear()
        xSPGR(SupCode.Text)
        UNIL()
        If GRID1.RowCount = 0 Then
            GRID3.Rows.Clear()
        End If
        xCASH = 0
        xAMT = 0
        xPRC = 0
        xCNT = 0

        'sPAY(SupCode.Text)


    End Sub

    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        GRNNum.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        GrnDate.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
        xSPPY(GRNNum.Text)
    End Sub
    Dim xCC As Double = 0
    Private Sub Amount_KeyDown(sender As Object, e As KeyEventArgs) Handles Amount.KeyDown
        If e.KeyCode = 13 Then
            If RB1.Checked = False And RB2.Checked = False Then Return
            If xZZZ = "Cheque" Then
                Dim RowTrue As Boolean = False, RowID As Integer = 0
                For Each row As DataGridViewRow In GRID4.Rows
                    If (row.Cells(1).Value = CHQNo.Text) Then
                        RowTrue = True : RowID = row.Index : Exit For
                    End If
                Next
                If RowTrue = True Then
                    GRID4.Rows(RowID).Cells(4).Value = Format(Val(Amount.Text), "0.00")
                    GRID4.Rows(RowID).Cells(3).Value = CmbBank.Text
                Else
                    GRID4.Rows.Add(GRNNum.Text, CHQNo.Text, PayDay.Text, CmbBank.Text, Format(Val(Amount.Text), "0.00"))
                End If
            End If

            cmd = New SqlCommand("Select * from GRN_Main where GRNNo='" & GRNNum.Text & "'", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                xCC = rdr("Amount")
            End If
            rdr.Close()
            Amount.Clear()
        End If
    End Sub

    Private Sub Amount_TextChanged(sender As Object, e As EventArgs) Handles Amount.TextChanged

    End Sub

    Private Sub GRID4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID4.CellContentClick

    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

    Private Sub GRID2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentClick

    End Sub
End Class