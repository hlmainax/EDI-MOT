Imports System.Data.SqlClient
Imports ConnData
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Module NewFunc
    Public Function xMAX(ByVal Form As Form)
        Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
        Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height
        Form.Width = xW
        Form.Height = xH
        Form.WindowState = FormWindowState.Maximized
        Return Form
    End Function
    Public Sub textToMid(ByVal ss As String)
        FrmMDI.FormText.Text = ss
    End Sub


    Public Function xPanelCenter(ByVal frm As Form, ByVal xPnel As Panel)
        xPnel.Location = New System.Drawing.Point(((frm.Width - xPnel.Width) / 2), ((frm.Height - xPnel.Height - 150) / 2))
        Return xPnel
    End Function
    Public Sub SaveInvBal(ByVal invNo As String, ByVal invAmnt As Double, ByVal paidVal As Double, ByVal overPaid As Double, ByVal cusBal As Double)
        'AutoID, INVNo, InvAmnt, Pre, Paid, Bal, TotB
        Dim bbl As Double = invAmnt - paidVal
        Dim tval As Double = cusBal + bbl
        cmd = New SqlCommand("Insert Inv_Vals values('" & invNo & "','" & invAmnt & "','" & cusBal & "','" & paidVal & "','" & bbl & "','" & tval & "')", con)
        cmd.ExecuteNonQuery()
    End Sub
    Public Function xAcountLoad(ByVal cmbbx As ComboBox)
        cmd = New SqlCommand("Select Distinct PayAccount from Pay_Master order by PayAccount", con)
        'cmd = New SqlCommand("Select * from PayAcc order by AccName", con)
        rdr = cmd.ExecuteReader
        cmbbx.Items.Clear()
        While rdr.Read
            cmbbx.Items.Add(rdr("PayAccount"))
        End While
        rdr.Close()
        Return xAcountLoad
    End Function
    Public Function xAcountLoad1(ByVal cmbbx As ComboBox)
        'cmd = New SqlCommand("Select Distinct PayAccount from Pay_Master order by PayAccount", con)
        cmd = New SqlCommand("Select * from PayAcc order by AccName", con)
        rdr = cmd.ExecuteReader
        cmbbx.Items.Clear()
        While rdr.Read
            cmbbx.Items.Add(rdr("AccName"))
        End While
        rdr.Close()
        Return xAcountLoad1
    End Function
    Public Function xFRMT(ByVal xCODE1 As Double)
        xFRMT = xCODE1.ToString("C", New System.Globalization.CultureInfo("en-US")).Remove(0, 0)
        Return xFRMT
    End Function
    Public Function GetOverPaid(ByVal cusCode As String,ByVal invMant As Double, ByVal paidAmnt As Double)
        Dim overPaid As Double = 0
        Dim cusBal As Double = 0
        overPaid = paidAmnt - invMant
        'cmd = New SqlCommand("Select ISNULL(CusBalance,0) from Cst where CusCode='" & cusCode & "'", con)
        'cusBal = cmd.ExecuteScalar
        Dim tOut As Double = cusBal + overPaid
        Return tOut
    End Function

    Public Sub xDayEndUpdate(ByVal SaleDate As Date, ByVal CashSales As Double, ByVal Receipts As Double, ByVal SaleRtns As Double, ByVal Payments As Double, ByVal Expences As Double, ByVal Deposits As Double, ByVal DayBalance As Double, ByVal Widraw As Double)
        Dim xDBal As Double = (CashSales + Receipts) - (SaleRtns + Payments + Expences + Deposits)
        '                                                   BfBal, CashSl,       Rcpt,                  SlRtn,                            Paymnts,                   Expenses,                        Deposits, DayBal, LastUpdate
        cmd = New SqlCommand("Update CashFlow set CashSl+='" & CashSales & "',Rcpt+='" & Receipts & "',SlRtn+='" & SaleRtns & "',Paymnts+='" & Payments & "',Expenses+='" & Expences & "',Deposits+='" & Deposits & "',DayBal+='" & xDBal & "',Widraw+='" & Widraw & "' where LastUpdate='" & SaleDate & "'", con)
        cmd.ExecuteNonQuery()
    End Sub
    Public Function xCRINFOS(ByVal xRPT As Object)
        Dim xSERVER As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "Server", Nothing)
        Dim xPW As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "DatabasePw", Nothing)
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        With crConnectionInfo
            .ServerName = xSERVER
            .DatabaseName = "Kristal_Lanka"
            .UserID = "sa"
            .Password = xPW
        End With
        CrTables = xRPT.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        Return xRPT
    End Function
End Module
