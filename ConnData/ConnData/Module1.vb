Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports System.Management
Imports System.Environment
Public Module Module1
    'Dim xServerConnStr As String = "server= HRNS;Database=POS_System;User Id=sa;Password=abc123"
    Public con = New SqlConnection
    Public con1 = New SqlConnection
    Public con2 = New SqlConnection
    Public con3 = New SqlConnection
    Public con4 = New SqlConnection
    Public con5 = New SqlConnection
    Public cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Public rdr, rdr1, rdr2, rdr3, rdr4, rdr5 As SqlDataReader
    Public Function ConnecOpen()
        Dim xSSer As String, xSUid As String, xSPas As String, xSDb As String, xServerConnStr As String
        Dim aaa As Integer
        Dim xd As String = ""
        Dim MOS As ManagementObjectSearcher = New ManagementObjectSearcher("Select * From Win32_BaseBoard")
        For Each getserial As ManagementObject In MOS.[Get]()
            xd = getserial("SerialNumber").ToString()
        Next


        Try
            Dim regVersion As RegistryKey
            regVersion = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\EDIRI\\1.0", True)
            If regVersion Is Nothing Then
                ' Key doesn't exist; create it.
                regVersion = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\EDIRI\\1.0")
                Dim xServer As String = InputBox("Please Enter Server IP or Name")
                If xServer = Nothing Then xServer = "User"
                Dim xUnit As String = InputBox("Please Enter Unit ID")
                Dim xPSW As String = InputBox("Enter DB Password")
                Dim xCsh As String = InputBox("Please Enter Cash Amount")
                Dim xPID As String = InputBox("Enter Customer ID")
                Dim xEXP As String = Format(Now.AddDays(14), "yyyy-MM-dd")



                Dim xPW As String = "0"
                'If xServer = "" And xUnit = "" And xCsh = "" Then
                'Set Default Value as assighned variable
                regVersion.SetValue("Server", xServer)
                regVersion.SetValue("Customer", xPID)
                regVersion.SetValue("ProductID", xd)
                regVersion.SetValue("UnitID", xUnit)
                regVersion.SetValue("CashInHnd", xCsh)
                regVersion.SetValue("DatabasePw", xPSW)
                regVersion.SetValue("SetAct", xPW)
                regVersion.SetValue("Exp", xEXP)
                regVersion.SetValue("ActSerial", "0000-0000-0000-0000")
            Else
            End If
            Dim xxqw As String = Nothing
            Dim xxpw As String = Nothing
            xxqw = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\EDIRI\1.0", "Server", Nothing)
            xxpw = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\EDIRI\1.0", "DatabasePw", Nothing)
            xSUid = "sa"
            'xSUid = Environment.UserName
            xSPas = xxpw
            xSDb = "Ediri"
            xServerConnStr = "Server= " & xxqw & ";database= " & xSDb & "; user id= " & xSUid & "; password=  " & xSPas & ""
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            con = New SqlConnection(xServerConnStr)
            con1 = New SqlConnection(xServerConnStr)
            con2 = New SqlConnection(xServerConnStr)
            con3 = New SqlConnection(xServerConnStr)
            con4 = New SqlConnection(xServerConnStr)
            con5 = New SqlConnection(xServerConnStr)
            If con.open Then
                con.Close()
                con.Open()
            ElseIf con1.open Then
                con1.Close()
                con1.Open()
            ElseIf con2.open Then
                con2.Close()
                con2.Open()
            ElseIf con3.open Then
                con3.Close()
                con3.Open()
            ElseIf con4.open Then
                con4.Close()
                con4.Open()
            ElseIf con5.open Then
                con5.Close()
                con5.Open()
            End If
            '''''''''''''''''
            'If con.State = ConnectionState.Open Then
            '    con.Close()
            '    con.Open()
            'ElseIf con1.State = ConnectionState.Open Then
            '    con1.Close()
            '    con1.Open()
            'ElseIf con2.State = ConnectionState.Open Then
            '    con2.Close()
            '    con2.Open()
            'ElseIf con3.State = ConnectionState.Open Then
            '    con3.Close()
            '    con3.Open()
            'ElseIf con4.State = ConnectionState.Open Then
            '    con4.Close()
            '    con4.Open()
            'ElseIf con5.State = ConnectionState.Open Then
            '    con5.Close()
            '    con5.Open()
            'End If
            regVersion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return aaa
    End Function
End Module
