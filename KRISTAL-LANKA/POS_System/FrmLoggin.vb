Imports System.Data.SqlClient
Imports ConnData
Imports System.Environment
Imports System.Net.Dns
Imports Microsoft.Win32
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.NetworkInformation
Imports System.Net

Imports System.Management


Public Class FrmLoggin

    Private Sub FrmLoggin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'GetIPAddress()
        ''"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""" Connection


        Timer1.Start()

        Panel1.Hide()
        'Try
        '    Dim regVersion As RegistryKey
        '    regVersion = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\EDIRI\\1.0", True)
        '    If regVersion Is Nothing Then

        '        ' Key doesn't exist; create it.
        '        regVersion = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\EDIRI\\1.0")
        '        Dim xServer As String = InputBox("Please Enter Server IP or Name")
        '        Dim xUnit As String = InputBox("Please Enter Unit ID")
        '        Dim xCsh As String = InputBox("Please Enter Cash Amount")
        '        'If xServer = "" And xUnit = "" And xCsh = "" Then

        '        'Set Default Value as assighned variable
        '        regVersion.SetValue("Server", xServer)
        '        regVersion.SetValue("UnitID", xUnit)
        '        regVersion.SetValue("CashInHnd", xCsh)

        '    Else

        '    End If

        '    Dim xxqw As String
        '    xxqw = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\EDIRI\1.0", "Server", Nothing)
        '    xSUid = "sa"
        '    'xSUid = Environment.UserName
        '    xSPas = "abc123"
        '    xSDb = "POS_System"
        '    xServerConnStr = "Server= " & xxqw & ";database= " & xSDb & "; user id= " & xSUid & "; password=  " & xSPas & ";"




        '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    con = New SqlConnection(xServerConnStr)
        '    con1 = New SqlConnection(xServerConnStr)
        '    con2 = New SqlConnection(xServerConnStr)
        '    con3 = New SqlConnection(xServerConnStr)
        '    con4 = New SqlConnection(xServerConnStr)
        '    con5 = New SqlConnection(xServerConnStr)

        '    If con.State = ConnectionState.Closed Then
        '        con.Close()
        '        con.Open()
        '    ElseIf con1.Open Then
        '        con1.Close()
        '        con1.Open()
        '    ElseIf con2.Open Then
        '        con2.Close()
        '        con2.Open()
        '    ElseIf con3.Open Then
        '        con3.Close()
        '        con3.Open()
        '    ElseIf con4.Open Then
        '        con4.Close()
        '        con4.Open()
        '    ElseIf con5.Open Then
        '        con5.Close()
        '        con5.Open()
        '    End If
        '    ''''''''''''''''''''''''''''''''

        '    regVersion.Close()



        'Catch ex As Exception..
        '    Application.Exit()
        'End Try


        'str = "server=HRNC-pc;Database=Library_System;User Id=sa;Password=a"
        'con = New SqlConnection(str)
        'con.Open()
        'con1.Open()

        'Dim xxqw As String = Nothing
        'xxqw = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\DrPhone\1.0", "Server", Nothing)
        'If xxqw = Nothing Then
        '    Application.Exit()
        'Else
        Try
            ConnecOpen()
            Dim sUNIT As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\EDIRI\1.0", "UnitID", Nothing)
            cmd1 = New SqlCommand("Select * from Workstation where(Unitid='" & sUNIT & "')", con1)
            rdr1 = cmd1.ExecuteReader
            If rdr1.Read = True Then
                Dim xDT As Date = Format(rdr1("LastUpdate"), "yyyy/MM/dd").ToString
                Dim nDT As Date = Format(Now, "yyyy/MM/dd")
                If xDT > nDT Then
                    MsgBox("Please Contact 0767 753 721 for Support !", MsgBoxStyle.Critical, "System has Locked")
                    Application.Exit()
                End If
            End If
            rdr1.Close()













            Dim SetAct As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\EDIRI\1.0", "ActSerial", Nothing)
            Dim xEXP As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\EDIRI\1.0", "Exp", Nothing)
            Dim Edate As Date = xEXP
            'If SetAct = "0000-0000-0000-0000" Then
            '    'Me.Hidef()
            '    Panel1.Show()
            'End If
            If Edate <= Format(Now, "yyyy-MM-dd") Then

                'Me.Hidef()
                Panel1.Show()
                'MessageBox.Show("The System Has Expired, Please Contact the Developer to Activate...!")
            End If













        Catch ex As Exception
            Application.Exit()
        End Try

        'End If


        'lblVr.Text = " HN POS " & Application.ProductVersion

        'lblVr.Text = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision

        'If My.Application.IsNetworkDeployed Then
        '    lblVr.Text = " HN POS " & " V " & My.Application.Deployment.CurrentVersion.ToString
        'Else
        '    lblVr.Text = ""
        'End If





    End Sub
    Private Sub ActivationCheck()
        Dim xd As String = ""
        Dim MOS As ManagementObjectSearcher = New ManagementObjectSearcher("Select * From Win32_BaseBoard")
        For Each getserial As ManagementObject In MOS.[Get]()
            xd = getserial("SerialNumber").ToString()
        Next
        'MessageBox.Show(xd)
        'xcmd=New SqlCommand("select * from SysAct where(SystemId='" &  &)")
        Dim regVersion As RegistryKey
        regVersion = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\EDIRI\\1.0", True)
        Dim xEXP As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\EDIRI\1.0", "Exp", Nothing)
        Dim Edate As Date = xEXP
        If HaveInternetConnection() = True Then
            Dim xCON As SqlConnection
            Dim xCON1 As SqlConnection
            Dim XSTR As String = ""
            XSTR = "server=206.189.140.82;Database=SystemAct;User Id=sa;Password=u56tyrgh@!"
            xCON = New SqlConnection(XSTR)
            Dim xcmd, xcmd1 As SqlCommand
            Dim xrdr, xrdr1 As SqlDataReader
            xCON.Open()
            Dim xtt As Boolean = False
            xcmd = New SqlCommand("Select * from SysAct where(PCSerial='" & xd & "'and CustomerID='" & "HameedMart" & "')", xCON)
            xrdr = xcmd.ExecuteReader
            If xrdr.Read = True Then
                xtt = True

            Else
                xtt = False
            End If
            xrdr.Close()
            If xtt = True Then
                If rdr("ExpireDate") <= Edate Then
                    Panel1.Show()
                End If
            ElseIf xtt = False Then
                Panel1.Show()
            End If


        Else
            If Edate <= Format(Now, "yyyy-MM-dd") Then
                Panel1.Show()
            End If
        End If

    End Sub






    Public Function HaveInternetConnection() As Boolean
        Try
            Return My.Computer.Network.Ping("206.189.140.82")
        Catch
            Return False
        End Try
    End Function



    Dim XTTR As Integer = 0
    Dim xxCV As Boolean = False
    Private Sub cmdLoggin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoggin.Click
        Try
            cmd = New SqlCommand("Select * from User_Option ", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
            Else
                XTTR = 1
            End If
            rdr.Close()
            If XTTR = 1 Then
                'MessageBox.Show("Invalid User Name Or Password", "Error Loggin", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Dim xUser As String = InputBox("Please Enter a User Name For use the system With admin rights And the password will be the same Of which you entered the user name.After logging To the system you can change the password")
                If xUser = Nothing Then xUser = "admin"
                '                                                   UserName,       Password,        Filee,     FOffice, BOffice, Financee,         Toolss,     Repor,  Adminn,          CusMas, Suppl,     CAT1,        CAT2,          ITMM,        CSH,       SLRT,        RCPT,      GRN,         SPRT,      DMG,        SPAY,      DBBK,        MRPT,        GRRPT,      DEND,       USR,        PRAD,      STITM,      xINT
                cmd = New SqlCommand("Insert User_Option values('" & xUser & "','" & xUser & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 1 & "','" & 0 & "')", con)
                cmd.ExecuteNonQuery()
                XTTR = 0
                FrmMDI.UName.Text = txtUname.Text
                FrmMDI.PWord.Text = txtPassword.Text
                FrmMDI.Show()
                Me.Hide()
            Else
                cmd = New SqlCommand("select * from User_Option where(UserName='" & txtUname.Text & "' and password='" & txtPassword.Text & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    xxCV = False
                Else
                    xxCV = True
                End If
                rdr.Close()

                If xxCV = True Then
                    MsgBox("Invalid User Name or Password", MsgBoxStyle.Critical, "Error Loggin")
                    txtUname.Clear()
                    txtPassword.Clear()
                    txtUname.Focus()
                ElseIf xxCV = False Then

                    FrmMDI.Show()
                    '  FrmMDI.UName.Text = txtUname.Text
                    '  FrmMDI.PWord.Text = txtPassword.Text
                    Me.Hide()
                End If
            End If


        Catch ex As Exception
            Application.Exit(e)
        End Try


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = 13 Then
            If txtPassword.Text = "" Then Return
            cmdLoggin.Focus()

        End If
    End Sub

    Private Sub txtUname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUname.KeyDown
        If e.KeyCode = 13 Then
            If txtUname.Text = "" Then Return
            txtPassword.Focus()
        End If
    End Sub


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        txtUname.Clear()
        txtPassword.Clear()
        txtUname.Focus()
    End Sub

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Application.Exit()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label7.Visible = True Then
            Label7.Visible = False
        ElseIf Label7.Visible = False Then
            Label7.Visible = True
        End If
    End Sub
End Class