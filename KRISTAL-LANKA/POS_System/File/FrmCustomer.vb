Imports System.Data.SqlClient
Imports ConnData
Public Class FrmCustomer

    Private Sub FrmCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height

        Me.WindowState = FormWindowState.Maximized
        GLOAD()

        'AboutBox1.Close()
        '*******************
    End Sub

    Private Sub FrmCustomer_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
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

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If CusCode.Text = "" Or CusName.Text = "" Then Return

        cmd = New SqlCommand("Select * from Cus_Master where CusCode='" & CusCode.Text & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            Dim result1 As DialogResult = MessageBox.Show("Do you want to Update the Current Customer Details ?", "Update the Current Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                '         CusCode,                                          CusName,                Address,                        CusMobi,                    CusOff,                     CusMail,                         Remarks, CusBalance, CusCreditLimit, CreditPeriod, DueDate, Active, LastUpdate, UName
                cmd1 = New SqlCommand("Update Cus_Master Set CusName='" & CusName.Text & "',Address='" & CusAdd.Text & "',CusMobi='" & CusMobi.Text & "',CusOff='" & CusOff.Text & "',CusMail='" & CusMail.Text & "',Remarks='" & Remarks.Text & "',CusBalance='" & CusBalance.Text & "',CusCreditLimit='" & CusCrdtLmt.Text & "',CreditPeriod='" & CrPeriod.Text & "',Active='" & xACT & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "'where CusCode='" & CusCode.Text & "'", con1)
                cmd1.ExecuteNonQuery()
                MessageBox.Show("Customer Details Update Succeed.", "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            Dim result1 As DialogResult = MessageBox.Show("Do you want to Add New Customer ?", "Add New Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                '                                                    CusCode,                CusName,             Address,               CusMobi,                CusOff,                 CusMail,               Remarks,            CreditAmt,        RceivedAmt,       CusBalance,             CusCreditLimit,            CreditPeriod,          Active,               LastUpdate,                    UName,                  DueDate
                cmd1 = New SqlCommand("Insert Cus_Master Values('" & CusCode.Text & "','" & CusName.Text & "','" & CusAdd.Text & "','" & CusMobi.Text & "','" & CusOff.Text & "','" & CusMail.Text & "','" & Remarks.Text & "','" & CusBalance.Text & "','" & 0 & "','" & CusBalance.Text & "','" & CusCrdtLmt.Text & "','" & CrPeriod.Text & "','" & xACT & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "','" & "" & "')", con1)
                cmd1.ExecuteNonQuery()
                MessageBox.Show("Add New Customer Succeed.", "Add New Customer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If
            '                                                         CusCode,              CusName,                Address,            CusMobi,                CusOff,              CusMail,                Remarks,                CusBalance,               CusCreditLimit,     CreditPeriod, DueDate, Active, LastUpdate, UName
        End If
        rdr.Close()
        'CusState
        cmd = New SqlCommand("Select count(CusCode) from CusState where(CusCode='" & CusCode.Text & "')", con)
        Dim xNu As Integer = 0
        xNu = cmd.ExecuteScalar
        If xNu = 0 Then
            If Val(CusBalance.Text) > 0 Then
                '                                                   CusCode,            CusName,                    InvDate,                        Descp,                      InvAmnt,                         RcvDate,                   Descr,        RcvAmnt
                cmd = New SqlCommand("Insert CusState values('" & CusCode.Text & "','" & CusName.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Opening Bal" & "','" & Val(CusBalance.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "')", con)
                cmd.ExecuteNonQuery()
            End If
        End If



        CmdCancel_Click(sender, EventArgs.Empty)

    End Sub
    Private Sub GLOAD()
        '     cmd = New SqlCommand("select * from Supplier order by cast(SupCode as Int)ASC", con)
        cmd = New SqlCommand("select * from Cus_Master order by cast(CusCode as Int)ASC", con)
        ' cmd = New SqlCommand("Select * from Cus_Master", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"), Format(rdr("CusBalance"), "0.00"))
        End While
        rdr.Close()
    End Sub
    Dim xACT As Integer = 1
    Private Sub CHQ1_CheckedChanged(sender As Object, e As EventArgs) Handles CHQ1.CheckedChanged
        If CHQ1.Checked = True Then
            xACT = 0
        ElseIf CHQ1.Checked = False Then
            xACT = 1
        End If
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        CusCode.Clear()
        CusName.Clear()
        CusAdd.Clear()
        CusMobi.Clear()
        CusOff.Clear()
        CusMail.Clear()
        Remarks.Clear()
        CusCrdtLmt.Clear()
        CusBalance.Clear()
        CrPeriod.Clear()
        xACT = 0
        CHQ1.Checked = False
        CusCode.ReadOnly = False
        CusCrdtLmt.Enabled = True
        CusBalance.Enabled = True
        CrPeriod.Enabled = True
        CusCode.Focus()
        GLOAD()
    End Sub

    Private Sub CusCode_KeyDown(sender As Object, e As KeyEventArgs) Handles CusCode.KeyDown
        If e.KeyCode = 13 Then
            xCUS(CusCode.Text)
        ElseIf e.KeyCode = 27 Then
            CmdCancel_Click(sender, EventArgs.Empty)
        End If
    End Sub
    Private Sub xCUS(ByVal xCCODE As String)
        cmd = New SqlCommand("Select * from Cus_Master Where(CusCode='" & xCCODE & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            CusCode.Text = rdr("CusCode").ToString
            CusName.Text = rdr("CusName").ToString
            CusAdd.Text = rdr("Address").ToString
            CusMobi.Text = rdr("CusMobi").ToString
            CusOff.Text = rdr("CusOff").ToString
            CusMail.Text = rdr("CusMail").ToString
            Remarks.Text = rdr("Remarks").ToString
            CusCrdtLmt.Text = Format(rdr("CusCreditLimit"), "0.00").ToString
            CusBalance.Text = Format(rdr("CusBalance"), "0.00").ToString
            CrPeriod.Text = rdr("CreditPeriod").ToString
            If rdr("Active") = 1 Then
                CHQ1.Checked = True
            ElseIf rdr("Active") = 0 Then
                CHQ1.Checked = False
                CusCode.Focus()
            End If
            CusCode.ReadOnly = True
            CusCrdtLmt.Enabled = True
            CusBalance.Enabled = True
            CrPeriod.Enabled = True
            CusCode.Focus()
        End If
        rdr.Close()
    End Sub
    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        xCUS(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
    End Sub

    Private Sub txtCusID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCusID.KeyDown
        If e.KeyCode = 13 Then

        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtCusName.Focus()
        ElseIf e.KeyCode = 27 Then
            txtCusID.Clear()
            txtCusName.Clear()
            txtCusID.Focus()
            GLOAD()
        End If
    End Sub

    Private Sub txtCusID_TextChanged(sender As Object, e As EventArgs) Handles txtCusID.TextChanged
        If txtCusID.Text = "" Then
            cmd = New SqlCommand("select * from Cus_Master order by cast(CusCode as Int)ASC", con)
        Else
            cmd = New SqlCommand("Select * from Cus_Master where CusCode like '" & txtCusID.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"), Format(rdr("CusBalance"), "0.00"))
        End While
        rdr.Close()
    End Sub

    Private Sub txtCusName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCusName.KeyDown
        If e.KeyCode = 13 Then

        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtCusID.Focus()
        ElseIf e.KeyCode = 27 Then
            txtCusID.Clear()
            txtCusName.Clear()
            txtCusID.Focus()
            GLOAD()
        End If
    End Sub

    Private Sub txtCusName_TextChanged(sender As Object, e As EventArgs) Handles txtCusName.TextChanged
        If txtCusName.Text = "" Then
            cmd = New SqlCommand("select * from Cus_Master order by cast(CusCode as Int)ASC", con)
        Else
            cmd = New SqlCommand("Select * from Cus_Master where CusName like '%" & txtCusName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"), Format(rdr("CusBalance"), "0.00"))
        End While
        rdr.Close()
    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

    Private Sub GRID1_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID1.KeyDown

    End Sub

    Private Sub CusCode_TextChanged(sender As Object, e As EventArgs) Handles CusCode.TextChanged

    End Sub
End Class