Imports System.Data.SqlClient
Imports ConnData
Public Class FrmUserControl
    'Dim con, con1 As SqlConnection
    'Dim cmd, cmd1 As SqlCommand
    'Dim rdr, rdr1 As SqlDataReader
    'Dim str As String
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        txtNuser.Clear()
        txtPW.Clear()
        txtCPW.Clear()
        'TreeView1.Nodes.Add("hello")
        txtNuser.Focus()
        xA = 0
        xB = 0
        xC = 0
        xD = 0
        xE = 0
        xF = 0
        xG = 0
        xH = 0
        xI = 0
        xJ = 0
        xK = 0
        xL = 0
        xM = 0
        xN = 0
        xO = 0
        xP = 0
        xQ = 0
        xR = 0
        xS = 0
        xT = 0
        xU = 0
        xAAA = 0
        xAAB = 0
        xAAC = 0
        xAAD = 0
        xAAE = 0
        xAAF = 0
        TreeView1.Nodes(0).Checked = False
        TreeView1.Nodes(0).Nodes(0).Checked = False
        TreeView1.Nodes(0).Nodes(1).Checked = False
        TreeView1.Nodes(0).Nodes(2).Checked = False
        TreeView1.Nodes(0).Nodes(3).Checked = False
        TreeView1.Nodes(0).Nodes(4).Checked = False

        TreeView1.Nodes(1).Checked = False
        TreeView1.Nodes(1).Nodes(0).Checked = False
        TreeView1.Nodes(1).Nodes(1).Checked = False
        TreeView1.Nodes(1).Nodes(2).Checked = False

        TreeView1.Nodes(2).Checked = False
        TreeView1.Nodes(2).Nodes(0).Checked = False
        TreeView1.Nodes(2).Nodes(1).Checked = False
        TreeView1.Nodes(2).Nodes(2).Checked = False

        TreeView1.Nodes(3).Checked = False
        TreeView1.Nodes(3).Nodes(0).Checked = False
        TreeView1.Nodes(4).Checked = False
        TreeView1.Nodes(4).Nodes(0).Checked = False
        TreeView1.Nodes(5).Checked = False

        TreeView1.Nodes(5).Nodes(0).Checked = False
        TreeView1.Nodes(5).Nodes(1).Checked = False
        TreeView1.Nodes(5).Nodes(2).Checked = False
        TreeView1.Nodes(6).Checked = False
        TreeView1.Nodes(6).Nodes(0).Checked = False
        TreeView1.Nodes(6).Nodes(1).Checked = False
        TreeView1.Nodes(6).Nodes(2).Checked = False
        TreeView1.Nodes(7).Checked = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'file--------------------------------------
        If TreeView1.Nodes(0).Checked = False Then
            xAAA = 0
            xA = 0
            xB = 0
            xC = 0
            xD = 0
            xE = 0
            TreeView1.Nodes(0).Nodes(0).Checked = False
            TreeView1.Nodes(0).Nodes(1).Checked = False
            TreeView1.Nodes(0).Nodes(2).Checked = False
            TreeView1.Nodes(0).Nodes(3).Checked = False
            TreeView1.Nodes(0).Nodes(4).Checked = False
        ElseIf TreeView1.Nodes(0).Checked = True Then
            xAAA = 1
            If TreeView1.Nodes(0).Nodes(0).Checked = True Then xA = 1
            If TreeView1.Nodes(0).Nodes(1).Checked = True Then xB = 1
            If TreeView1.Nodes(0).Nodes(2).Checked = True Then xC = 1
            If TreeView1.Nodes(0).Nodes(3).Checked = True Then xD = 1
            If TreeView1.Nodes(0).Nodes(4).Checked = True Then xE = 1

        End If
        'Front Office------------------------------
        If TreeView1.Nodes(1).Checked = False Then
            xAAB = 0
            xF = 0
            xG = 0
            xH = 0
            TreeView1.Nodes(1).Nodes(0).Checked = False
            TreeView1.Nodes(1).Nodes(1).Checked = False
            TreeView1.Nodes(1).Nodes(2).Checked = False
        ElseIf TreeView1.Nodes(1).Checked = True Then
            xAAB = 1
            If TreeView1.Nodes(1).Nodes(0).Checked = True Then xF = 1
            If TreeView1.Nodes(1).Nodes(1).Checked = True Then xG = 1
            If TreeView1.Nodes(1).Nodes(2).Checked = True Then xH = 1
        End If
        'Back Office-----------------------------------
        If TreeView1.Nodes(2).Checked = False Then
            xAAC = 0
            xI = 0
            xJ = 0
            xK = 0

            TreeView1.Nodes(2).Nodes(0).Checked = False
            TreeView1.Nodes(2).Nodes(1).Checked = False
            TreeView1.Nodes(2).Nodes(2).Checked = False
        ElseIf TreeView1.Nodes(2).Checked = True Then
            xAAC = 1
            If TreeView1.Nodes(2).Nodes(0).Checked = True Then xI = 1
            If TreeView1.Nodes(2).Nodes(1).Checked = True Then xJ = 1
            If TreeView1.Nodes(2).Nodes(2).Checked = True Then xK = 1
        End If
        'Finance-----------------------------------------
        If TreeView1.Nodes(3).Checked = False Then
            xAAD = 0
            xL = 0
            TreeView1.Nodes(3).Nodes(0).Checked = False
        ElseIf TreeView1.Nodes(3).Checked = True Then
            xAAD = 1
            If TreeView1.Nodes(3).Nodes(0).Checked = True Then xL = 1
        End If
        'Tools-------------------------------------------
        If TreeView1.Nodes(4).Checked = False Then
            xAAE = 0
            xM = 0

            TreeView1.Nodes(4).Nodes(0).Checked = False
        ElseIf TreeView1.Nodes(4).Checked = True Then
            xAAE = 1
            If TreeView1.Nodes(4).Nodes(0).Checked = True Then xM = 1
        End If
        'Reports------------------------------------------
        If TreeView1.Nodes(5).Checked = False Then
            xAAF = 0
            xN = 0
            xO = 0
            xP = 0

            TreeView1.Nodes(5).Nodes(0).Checked = False
            TreeView1.Nodes(5).Nodes(1).Checked = False
            TreeView1.Nodes(5).Nodes(2).Checked = False
        ElseIf TreeView1.Nodes(5).Checked = True Then
            xAAF = 1
            If TreeView1.Nodes(5).Nodes(0).Checked = True Then xN = 1
            If TreeView1.Nodes(5).Nodes(1).Checked = True Then xO = 1
            If TreeView1.Nodes(5).Nodes(2).Checked = True Then xP = 1
        End If
        'Admin-------------------------------------------
        If TreeView1.Nodes(6).Checked = False Then
            xAAG = 0
            xQ = 0
            xR = 0
            xS = 0
            xV = 0

            TreeView1.Nodes(6).Nodes(0).Checked = False
            TreeView1.Nodes(6).Nodes(1).Checked = False
            TreeView1.Nodes(6).Nodes(2).Checked = False
            TreeView1.Nodes(6).Nodes(3).Checked = False
        ElseIf TreeView1.Nodes(6).Checked = True Then
            xAAG = 1
            If TreeView1.Nodes(6).Nodes(0).Checked = True Then xQ = 1
            If TreeView1.Nodes(6).Nodes(1).Checked = True Then xR = 1
            If TreeView1.Nodes(6).Nodes(2).Checked = True Then xS = 1
            If TreeView1.Nodes(6).Nodes(3).Checked = True Then xV = 1
        End If

        If TreeView1.Nodes(7).Checked = True Then
            xU = 1
        ElseIf TreeView1.Nodes(7).Checked = False Then
            xU = 0
        End If
        cmd = New SqlCommand("Select * from User_Option where(UserName='" & txtNuser.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Update User_Option set Filee='" & xAAA & "',FOffice='" & xAAB & "',BOffice='" & xAAC & "',Financee='" & xAAD & "',Toolss='" & xAAE & "',Repor='" & xAAF & "',Adminn='" & xAAG & "',CusMas='" & xA & "',Suppl='" & xB & "',CAT1='" & xC & "',CAT2='" & xD & "',ITMM='" & xE & "',CSH='" & xF & "',SLRT='" & xG & "',RCPT='" & xH & "',GRN='" & xI & "',SPRT='" & xJ & "',DMG='" & xK & "',SPAY='" & xL & "',DBBK='" & xM & "',MRPT='" & xN & "',GRRPT='" & xO & "',DEND='" & xP & "',USR='" & xQ & "',PRAD='" & xR & "',STITM='" & xS & "',xINT='" & xU & "',Exl='" & xV & "'where UserName='" & txtNuser.Text & "'", con1)
            cmd1.ExecuteNonQuery()
        Else

        End If
        rdr.Close()
        'End If
        cmdCancel_Click(sender, EventArgs.Empty)

    End Sub

    Dim xA, xB, xC, xD, xE, xF, xG, xH, xI, xJ, xK, xL, xM, xN, xO, xP, xQ, xR, xS, xT, xU, xV, xAAA, xAAB, xAAC, xAAD, xAAE, xAAF, xAAG As Integer

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub FrmUserControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
        Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = xW
        Me.Height = xH
        Me.WindowState = FormWindowState.Maximized
        xA = 0
        xB = 0
        xC = 0
        xD = 0
        xE = 0
        xF = 0
        xG = 0
        xH = 0
        xI = 0
        xJ = 0
        xK = 0
        xL = 0
        xM = 0
        xN = 0
        xO = 0
        xP = 0
        xQ = 0
        xR = 0
        xS = 0
        xT = 0
        xU = 0
        xAAA = 0
        xAAB = 0
        xAAC = 0
        xAAD = 0
        xAAE = 0
        xAAF = 0
        uLOAD()

        ' FrmUserControl.Close()
        'AboutBox1.Close()
    End Sub


    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
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
    Private Sub uLOAD()
        cmd = New SqlCommand("Select * from User_Option", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("UserName"))
        End While
        rdr.Close()
    End Sub

    Private Sub FrmUserControl_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
    End Sub

    Private Sub txtNuser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNuser.KeyDown
        If e.KeyCode = 13 Then
            If txtNuser.Text = "" Then Return
            txtPW.Focus()
        End If
    End Sub

    Private Sub txtPW_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPW.KeyDown
        If e.KeyCode = 13 Then
            If txtPW.Text = "" Then Return
            txtCPW.Focus()
        End If
    End Sub

    Dim xTRUE As Boolean = False
    Private Sub CmdCreate_Click(sender As Object, e As EventArgs) Handles CmdCreate.Click
        If txtNuser.Text = "" Or txtPW.Text = "" Then Return
        cmd = New SqlCommand("Select * from  User_Option where(UserName='" & txtNuser.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xTRUE = True
        Else
            xTRUE=False
            '                                                   UserName,                    Password,          Filee,      FOffice,          BOffice,     Financee,       Toolss,       Repor,          Adminn,        CusMas,     Suppl,       CAT1,         CAT2,       ITMM,         CSH,         SLRT,         RCPT,        GRN,        SPRT,        DMG,        SPAY,         DBBK,        MRPT,        GRRPT,       DEND,        USR,          PRAD,        STITM
            cmd1 = New SqlCommand("Insert User_Option Values('" & txtNuser.Text & "','" & txtCPW.Text & "','" & xAAA & "','" & xAAB & "','" & xAAC & "','" & xAAD & "','" & xAAE & "','" & xAAF & "','" & xAAG & "','" & xA & "','" & xB & "','" & xC & "','" & xD & "','" & xE & "','" & xF & "','" & xG & "','" & xH & "','" & xI & "','" & xJ & "','" & xK & "','" & xL & "','" & xM & "','" & xN & "','" & xO & "','" & xP & "','" & xQ & "','" & xR & "','" & xS & "','" & xU & "','" & xV & "')", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        If xTRUE = True Then
            MessageBox.Show("Existing user..Please Try.!", "Create Users", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        ElseIf xTRUE = False Then
            MessageBox.Show("User create Success...!", "Create Users", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
        txtNuser.Clear()
        txtPW.Clear()
        txtCPW.Clear()
        uLOAD()
    End Sub

    Private Sub CmdReset_Click(sender As Object, e As EventArgs) Handles CmdReset.Click
        If txtNuser.Text = "" Or txtPW.Text = "" Then Return
        cmd = New SqlCommand("Select * from  User_Option where(UserName='" & txtNuser.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Update User_Option set Password='" & txtPW.Text & "'where UserName='" & txtNuser.Text & "'", con1)
            cmd1.ExecuteNonQuery()
            xTRUE = True
        Else
            xTRUE = False
        End If
        rdr.Close()
        If xTRUE = False Then
            MessageBox.Show("User not Exist ..Please try.!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        ElseIf xTRUE = True Then
            MessageBox.Show("reset Success.!", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
        txtCPW.Clear()
        txtPW.Clear()
        txtNuser.Clear()
    End Sub


    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        txtNuser.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        cmd = New SqlCommand("Select * from  User_Option where(UserName='" & txtNuser.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            If rdr("Filee") = 1 Then
                TreeView1.Nodes(0).Checked = True
                xAAA = 1
            ElseIf rdr("Filee") = 0 Then
                TreeView1.Nodes(0).Checked = False
                xAAA = 0
            End If
            If rdr("FOffice") = 1 Then
                TreeView1.Nodes(1).Checked = True
                xAAB = 1
            ElseIf rdr("FOffice") = 0 Then
                TreeView1.Nodes(1).Checked = False
                xAAB = 0
            End If
            If rdr("BOffice") = 1 Then
                TreeView1.Nodes(2).Checked = True
                xAAC = 1
            Else
                TreeView1.Nodes(2).Checked = False
                xAAC = 0
            End If
            If rdr("Financee") = 1 Then
                TreeView1.Nodes(3).Checked = True
                xAAD = 1
            Else
                TreeView1.Nodes(3).Checked = False
                xAAD = 0
            End If
            If rdr("Toolss") = 1 Then
                TreeView1.Nodes(4).Checked = True
                xAAE = 1
            Else
                TreeView1.Nodes(4).Checked = False
                xAAE = 0
            End If
            If rdr("Repor") = 1 Then
                TreeView1.Nodes(5).Checked = True
                xAAF = 1
            Else
                TreeView1.Nodes(5).Checked = False
                xAAF = 0
            End If
            If rdr("Adminn") = 1 Then
                TreeView1.Nodes(6).Checked = True
                xAAG = 1
            Else
                TreeView1.Nodes(6).Checked = False
                xAAG = 0
            End If
            If rdr("CusMas") = 1 Then
                TreeView1.Nodes(0).Nodes(0).Checked = True
                xA = 1
            Else
                TreeView1.Nodes(0).Nodes(0).Checked = False
                xA = 0
            End If
            If rdr("Suppl") = 1 Then
                TreeView1.Nodes(0).Nodes(1).Checked = True
                xB = 1
            Else
                TreeView1.Nodes(0).Nodes(1).Checked = False
                xB = 0
            End If
            If rdr("CAT1") = 1 Then
                TreeView1.Nodes(0).Nodes(2).Checked = True
                xC = 1
            Else
                TreeView1.Nodes(0).Nodes(2).Checked = False
                xC = 0
            End If
            If rdr("CAT2") = 1 Then
                TreeView1.Nodes(0).Nodes(3).Checked = True
                xD = 1
            Else
                TreeView1.Nodes(0).Nodes(3).Checked = False
                xD = 0
            End If
            If rdr("ITMM") = 1 Then
                TreeView1.Nodes(0).Nodes(4).Checked = True
                xE = 1
            Else
                TreeView1.Nodes(0).Nodes(4).Checked = False
                xE = 0
            End If
            If rdr("CSH") = 1 Then
                TreeView1.Nodes(1).Nodes(0).Checked = True
                xF = 1
            Else
                TreeView1.Nodes(1).Nodes(0).Checked = False
                xF = 0
            End If
            If rdr("SLRT") = 1 Then
                TreeView1.Nodes(1).Nodes(1).Checked = True
                xG = 1
            Else
                TreeView1.Nodes(1).Nodes(1).Checked = False
                xG = 0
            End If
            If rdr("RCPT") = 1 Then
                TreeView1.Nodes(1).Nodes(2).Checked = True
                xH = 1
            Else
                TreeView1.Nodes(1).Nodes(2).Checked = False
                xH = 0
            End If
            If rdr("GRN") = 1 Then
                TreeView1.Nodes(2).Nodes(0).Checked = True
                xI = 1
            Else
                TreeView1.Nodes(2).Nodes(0).Checked = False
                xI = 0
            End If
            If rdr("SPRT") = 1 Then
                TreeView1.Nodes(2).Nodes(1).Checked = True
                xJ = 1
            Else
                TreeView1.Nodes(2).Nodes(1).Checked = False
                xJ = 0
            End If
            If rdr("DMG") = 1 Then
                TreeView1.Nodes(2).Nodes(2).Checked = True
                xK = 1
            Else
                TreeView1.Nodes(2).Nodes(2).Checked = False
                xK = 0
            End If
            If rdr("SPAY") = 1 Then
                TreeView1.Nodes(3).Nodes(0).Checked = True
                xL = 1
            Else
                TreeView1.Nodes(3).Nodes(0).Checked = False
                xL = 0
            End If
            If rdr("DBBK") = 1 Then
                TreeView1.Nodes(4).Nodes(0).Checked = True
                xM = 1
            Else
                TreeView1.Nodes(4).Nodes(0).Checked = False
                xM = 0
            End If
            If rdr("MRPT") = 1 Then
                TreeView1.Nodes(5).Nodes(0).Checked = True
                xN = 1
            Else
                TreeView1.Nodes(5).Nodes(0).Checked = False
                xN = 0
            End If
            If rdr("GRRPT") = 1 Then
                TreeView1.Nodes(5).Nodes(1).Checked = True
                xO = 1
            Else
                TreeView1.Nodes(5).Nodes(1).Checked = False
                xO = 0
            End If
            If rdr("DEND") = 1 Then
                TreeView1.Nodes(5).Nodes(2).Checked = True
                xP = 1
            Else
                TreeView1.Nodes(5).Nodes(2).Checked = False
                xP = 0
            End If
            If rdr("USR") = 1 Then
                TreeView1.Nodes(6).Nodes(0).Checked = True
                xQ = 1
            Else
                TreeView1.Nodes(6).Nodes(0).Checked = False
                xQ = 0
            End If
            If rdr("PRAD") = 1 Then
                TreeView1.Nodes(6).Nodes(1).Checked = True
                xR = 1
            Else
                TreeView1.Nodes(6).Nodes(1).Checked = False
                xR = 0
            End If
            If rdr("STITM") = 1 Then
                TreeView1.Nodes(6).Nodes(2).Checked = True
                xS = 1
            Else
                TreeView1.Nodes(6).Nodes(2).Checked = False
                xS = 0
            End If
            If rdr("xINT") = 1 Then
                TreeView1.Nodes(7).Checked = True
                xU = 1
            Else
                TreeView1.Nodes(7).Checked = False
                xS = 0
            End If
        End If
        rdr.Close()
    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

End Class