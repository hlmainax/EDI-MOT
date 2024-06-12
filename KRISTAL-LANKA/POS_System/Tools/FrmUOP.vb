Imports System.Data.SqlClient
Imports ConnData
Public Class FrmUOP
    Dim xA, xB, xC, xD, xE, xF, xG, xH, xI, xJ, xK, xL, xM, xN, xO, xP, xQ, xR, xS, xT, xU, xV, xW, xX, xY, xZ As Integer
    Private Sub FrmUOP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        cmd = New SqlCommand("Select * from User_Option1 ", con)
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("UserName"))
            ' UserName, Password, Filee, FOffice, BOffice, Financee, Toolss, Repor, Adminn, CusMas, Suppl, CAT1, CAT2, ITMM, CSH, SLRT, RCPT, GRN, SPRT,DMG, STK, PCHG, SPAY, DBBK, USR, STITM, RPT, ADMN

        End While
        rdr.Close()


        CHK1.Checked = False
        GB3.Enabled = False


    End Sub
    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub FrmUOP_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        'Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        'Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        ''Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
    End Sub
    Dim xTRR As Boolean = False
    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click

        If UsrName.Text = "" Or Pwrd.Text = "" Or CnPwrd.Text = "" Then Return
        If UsrName.Text = Pwrd.Text Then
            MsgBox("Username and Password cannot be the same. Please try again..!")
            UsrName.Clear()
            Pwrd.Clear()
            CnPwrd.Clear()
            UsrName.Focus()
            Return
        ElseIf Pwrd.Text <> CnPwrd.Text Then
            MsgBox("Password does not matched please try again..!")
            Pwrd.Clear()
            CnPwrd.Clear()
            UsrName.Focus()
            Return
        End If

        cmd = New SqlCommand("Select * from User_Option1 where(UserName='" & UsrName.Text & "') ", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xTRR = True
        End If
        rdr.Close()
        If xTRR = True Then
            MsgBox("You Entered the user already in the list please try another one..!")
            UsrName.Clear()
            Pwrd.Clear()
            CnPwrd.Clear()
            Return
        Else
            '                                                   UserName,                Password,           Filee,  FOffice,    BOffice,    Financee,   Toolss,        Repor,       Adminn,     CusMas,    Suppl,      CAT1,      CAT2,        ITMM,      CSH,       SLRT,        RCPT,       GRN,        SPRT,        DMG,        STK,       PCHG,       SPAY,       DBBK,        USR,       STITM,      RPT,        ADMN
            cmd = New SqlCommand("Insert User_Option1 values('" & UsrName.Text & "','" & Pwrd.Text & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "' )", con)
            cmd.ExecuteNonQuery()
            MsgBox("User Added")
            UsrName.Clear()
            Pwrd.Clear()
            CnPwrd.Clear()
        End If

        cmd = New SqlCommand("Select * from User_Option1", con)
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("UserName"))
        End While
        rdr.Close()
    End Sub

    Private Sub CmdGrant_Click(sender As Object, e As EventArgs) Handles CmdGrant.Click
        For i As Integer = 0 To GRID1.RowCount - 1


            If GRID1(1, i).Value = True Or GRID1(1, i).Value = 1 Then xA = 1 Else xA = 0
            If GRID1(2, i).Value = True Or GRID1(2, i).Value = 1 Then xB = 1 Else xB = 0
            If GRID1(3, i).Value = True Or GRID1(3, i).Value = 1 Then xC = 1 Else xC = 0
            If GRID1(4, i).Value = True Or GRID1(4, i).Value = 1 Then xD = 1 Else xD = 0
            If GRID1(5, i).Value = True Or GRID1(5, i).Value = 1 Then xE = 1 Else xE = 0
            If GRID1(6, i).Value = True Or GRID1(6, i).Value = 1 Then xF = 1 Else xF = 0
            If GRID1(7, i).Value = True Or GRID1(7, i).Value = 1 Then xG = 1 Else xG = 0
            If GRID1(8, i).Value = True Or GRID1(8, i).Value = 1 Then xH = 1 Else xH = 0
            If GRID1(9, i).Value = True Or GRID1(9, i).Value = 1 Then xI = 1 Else xI = 0
            If GRID1(10, i).Value = True Or GRID1(10, i).Value = 1 Then xJ = 1 Else xJ = 0
            If GRID1(11, i).Value = True Or GRID1(11, i).Value = 1 Then xK = 1 Else xK = 0
            If GRID1(12, i).Value = True Or GRID1(12, i).Value = 1 Then xL = 1 Else xL = 0
            If GRID1(13, i).Value = True Or GRID1(13, i).Value = 1 Then xM = 1 Else xM = 0
            If GRID1(14, i).Value = True Or GRID1(14, i).Value = 1 Then xN = 1 Else xN = 0
            If GRID1(15, i).Value = True Or GRID1(15, i).Value = 1 Then xO = 1 Else xO = 0
            If GRID1(16, i).Value = True Or GRID1(16, i).Value = 1 Then xP = 1 Else xP = 0
            If GRID1(17, i).Value = True Or GRID1(17, i).Value = 1 Then xQ = 1 Else xQ = 0
            If GRID1(18, i).Value = True Or GRID1(18, i).Value = 1 Then xR = 1 Else xR = 0



            'cmd = New SqlCommand("Select * from Stock_Main where AutoID='" & GRID1(0, i).Value & "'", con)
            'UserName,Password,                                   Supplier,            ItemCreate,         Cat1,            Cat2,               Cashier,              GRN,         DMG,            RTN,            SRT,             STK,              PAY,             RPT,             RPT1,              UOP


            '                                                  SLMN,             SPLR,      CAT1,       CAT2,                         ITMM,             CSH,            SLRT,              GRN,             SPRT,             DMG,             STK,             BCD,               SPAY,        DBBK,              USR,               STITM,         RPT,             RPT1
            cmd = New SqlCommand("Update User_Option1 set SLMN='" & xA & "',SPLR='" & xB & "',CAT1='" & xC & "',CAT2='" & xD & "',ITMM='" & xE & "',CSH='" & xF & "',SLRT='" & xG & "',GRN='" & xH & "',SPRT='" & xI & "',DMG='" & xJ & "',STK='" & xK & "',BCD='" & xL & "',SPAY='" & xM & "',DBBK='" & xN & "',USR='" & xO & "',STITM='" & xP & "',RPT='" & xQ & "',RPT1='" & xR & "' where UserName='" & GRID1(0, i).Value & "' ", con)
            cmd.ExecuteNonQuery()

        Next
        MessageBox.Show("Permission Granted", "Permission Granting", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        CHK1.Checked = False
    End Sub

    Private Sub CHK1_CheckedChanged(sender As Object, e As EventArgs) Handles CHK1.CheckedChanged
        If CHK1.Checked = True Then
            GB3.Enabled = True
            cmd = New SqlCommand("Select * from User_Option1 ", con)
            rdr = cmd.ExecuteReader
            GRID1.Rows.Clear()
            GRID2.Rows.Clear()
            While rdr.Read
                GRID2.Rows.Add(rdr("UserName"))
                'UserName, Password,                 SLMN,          SPLR,      CAT1,       CAT2,          ITMM,       CSH,        SLRT,        GRN,      SPRT,          DMG,       STK,        BCD,       SPAY,        DBBK,         USR,          STITM,     RPT,         RPT1
                GRID1.Rows.Add(rdr("UserName"), rdr("SLMN"), rdr("SPLR"), rdr("CAT1"), rdr("CAT2"), rdr("ITMM"), rdr("CSH"), rdr("SLRT"), rdr("GRN"), rdr("SPRT"), rdr("DMG"), rdr("STK"), rdr("BCD"), rdr("SPAY"), rdr("DBBK"), rdr("USR"), rdr("STITM"), rdr("RPT"), rdr("RPT1"))
            End While
            rdr.Close()
        ElseIf CHK1.Checked = False Then
            GB3.Enabled = False
            GRID1.Rows.Clear()
        End If

    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        UsrName1.Text = GRID2.Item(0, GRID2.CurrentRow.Index).Value
        UsrName1.Focus()
    End Sub

    Private Sub CmdRset_Click(sender As Object, e As EventArgs) Handles CmdRset.Click
        If UsrName1.Text = "" Or Pwrd1.Text = "" Or CnPwrd1.Text = "" Then Return
        If UsrName1.Text = Pwrd1.Text Then
            MsgBox("Username and Password cannot be the same. Please try again..!")
            Return
        ElseIf Pwrd1.Text <> CnPwrd1.Text Then
            MsgBox("Password does not matched please try again..!")
            Return
        End If

        cmd = New SqlCommand("Update User_Option1 set Password='" & CnPwrd1.Text & "'where UserName='" & UsrName1.Text & "'", con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Password Resting success...!", "Password Resetting", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        UsrName1.Clear()
        Pwrd1.Clear()
        CnPwrd1.Clear()


    End Sub

    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        ''''''''''''''''''''
        cmd = New SqlCommand("Select * from User_Option1", con)
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("UserName"))
        End While
        rdr.Close()
        UsrName.Clear()
        Pwrd.Clear()
        CnPwrd.Clear()
        UsrName.Focus()
    End Sub

    Private Sub CmdClear1_Click(sender As Object, e As EventArgs) Handles CmdClear1.Click
        UsrName1.Clear()
        Pwrd1.Clear()
        CnPwrd1.Clear()
        UsrName1.Focus()
    End Sub
End Class