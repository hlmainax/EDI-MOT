
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Imports ConnData
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Win32
Imports POS_System.NewFunc
Public Class FrmRpts
    Dim xSERVER As String = Nothing
    Dim xPW As String = Nothing
    Private Sub GridLd()
        'cmd = New SqlCommand("Select * from Cus_Master order by CusName", con)
        'rdr = cmd.ExecuteReader
        'GRID1.Rows.Clear()
        'While rdr.Read
        '    GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"))
        'End While
        'rdr.Close()
        'cmd = New SqlCommand("Select * from Supplier order by SupName", con)
        'rdr = cmd.ExecuteReader
        'GRID2.Rows.Clear()
        'While rdr.Read
        '    GRID2.Rows.Add(rdr("SupCode"), rdr("SupName"))
        'End While
        'rdr.Close()
        'xAcountLoad(CmbAccount)
    End Sub
    Private Sub FrmRpts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'xSERVER = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "Server", Nothing)
        'xPW = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "DatabasePw", Nothing)
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.WindowState = FormWindowState.Maximized
        DTP1.Value = Format(Now, "yyyy-MM-dd")
        DTP2.Value = Format(Now, "yyyy-MM-dd")
        GridLd()
        Me.ControlBox = False
        xBANK()
        ItemLoad()
        'FrmAct.Close()
        'frmBackup.Close()
        'FrmBANK.Close()
        'FrmCashier.Close()
        'FrmCat1.Close()
        'FrmCat2.Close()
        'FrmCHQPAY.Close()
        'FrmCustomer.Close()
        'FrmDMG.Close()
        'FrmErrorCorrec.Close()
        'FrmExcel.Close()
        'FrmGRNRPT.Close()
        'FrmGRN.Close()
        'FrmItem.Close()
        'frmPchange.Close()
        'FrmRCPT.Close()
        'FrmREPORT.Close()
        'FrmRPT.Close()
        'FrmRPT1.Close()
        ''FrmRpts.Close()
        'FrmRtn.Close()
        'FrmSALESRE.Close()
        'FrmSTCKENTER.Close()
        'FrmSupPament.Close()
        'FrmSupplier.Close()
        'FrmSupplierRTN.Close()
        'FrmUOP.Close()
        'FrmUserControl.Close()
        'AboutBox1.Close()
    End Sub
    Private Sub xBANK()
        cmd = New SqlCommand("Select * from Bank_Main ", con)
        rdr = cmd.ExecuteReader
        CmbAccount1.Items.Clear()
        While rdr.Read
            CmbAccount1.Items.Add(rdr("AccNo") & " - " & rdr("BankName"))
        End While
        rdr.Close()
    End Sub
    Private Sub ItemLoad()
        'cmd = New SqlCommand("Select Distinct * from Inv_Sub ", con)
        'rdr = cmd.ExecuteReader
        'CmbItem.Items.Clear()
        'While rdr.Read
        '    CmbItem.Items.Add(rdr("ItemCode") & " - " & rdr("ItemName"))
        'End While
        'rdr.Close()
    End Sub



    Private Function xCRINFO(ByVal xRPT As ReportClass)

        Dim xSERVER As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "Server", Nothing)
        Dim xPW As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "DatabasePw", Nothing)
        xRPT.DataSourceConnections.Clear()
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

    Private Sub FrmRpts_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()

        Dim sql As String = "SELECT Cst.CCode,Cst.CusName,Cst.Sts,Cled.CCode,CLed.Cr,CLed.Dr
        From Cst
        INNER Join CLed ON Cst.CCode=Cled.CCode where CLed.Sts='0'and Cst.Sts='0'and Cst.CCode<>'C01'"
        cmd = New SqlCommand(sql, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Table.Rows.Add(rdr("CCode"), rdr("CusName"), rdr("Cr"), rdr("Dr"), "0")
        End While
        rdr.Close()


        Dim xxc As New RptCrd
        xxc.SetDataSource(ds.Tables(1))
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()

        '  RptRaw.RecordSelectionFormula = " {Raw_Collect.ColDate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Raw_Collect.ColDate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Farmer_Master.FrmRout}='" & CmbRoute.Text & "'"
        'RptSALE.Load()

        CrystalReportViewer1.ReportSource = xxc
        'CrystalReportViewer1.Zoom(1)
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim RptSup As New RPT2
        Dim xGN As Double = 0
        Dim xPay As Double = 0

        '  RptRaw.RecordSelectionFormula = " {Raw_Collect.ColDate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Raw_Collect.ColDate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Farmer_Master.FrmRout}='" & CmbRoute.Text & "'"
        'RptSALE.Load()
        xCRINFO(RptSup)
        CrystalReportViewer1.ReportSource = RptSup
        'CrystalReportViewer1.Zoom(1)
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()
        cmd = New SqlCommand("Select ItemCode,ItemName,Description from Itm where Sts=0 order by ItemName", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Table.Rows.Add(rdr("ItemCode"), rdr("ItemName"), rdr("Description"), "-", "-")
        End While
        rdr.Close()
        Dim xxc As New RptItem
        xxc.SetDataSource(ds.Tables(1))
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        '  Dim report3 As New RptDaySummerya
        Dim sales As Double = 0
        Dim cost As Double = 0
        Dim credit As Double = 0
        Dim retun As Double = 0
        Dim rtnCost As Double = 0

        cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0) from Inv where Dte='" & DTP1.Value.Date & "'and Sts=0 and InvAmnt>0", con)
        sales = cmd.ExecuteScalar
        cmd = New SqlCommand("Select ISNULL(SUM(CPrice*Qty),0) from Itr where LastUpdate='" & DTP1.Value.Date & "'and Sts=0 and Qty<0 and Tno like'%" & "IN" & "%'", con)
        cost = cmd.ExecuteScalar
        cmd = New SqlCommand("Select ISNULL(SUM(CPrice*Qty),0) from Itr where LastUpdate='" & DTP1.Value.Date & "'and Sts=0 and Qty>0 and Tno like'%" & "IN" & "%'", con)
        rtnCost = cmd.ExecuteScalar
        cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt-Paid),0) from Inv where Dte='" & DTP1.Value.Date & "'and Sts=0 and CusCode<>'C01' and InvAmnt>=Paid", con)
        credit = cmd.ExecuteScalar
        cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0) from Inv where Dte='" & DTP1.Value.Date & "'and Sts=0 and InvAmnt<0", con)
        retun = cmd.ExecuteScalar

        Dim prf As Double = 0
        cost = cost * -1
        retun = retun * -1
        prf = (sales - retun) - (cost - rtnCost)

        Dim report3 As New RptSls
        report3.SetParameterValue("sls", Format(sales, "0.00"))
        report3.SetParameterValue("csls", Format(credit, "0.00"))
        report3.SetParameterValue("rsls", Format(retun, "0.00"))
        report3.SetParameterValue("cbl", Format(sales - (credit + retun), "0.00"))
        report3.SetParameterValue("prf", Format(prf, "0.00"))
        report3.SetParameterValue("dte", DTP1.Text)


        CrystalReportViewer1.ReportSource = report3
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked

        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()

        Dim sql As String = "SELECT Itm.ItemCode, Itm.ItemName, Itr.Qty,Itr.CPrice
From Itm
INNER Join Itr ON Itm.ItemCode=Itr.ItemCode where Itr.Sts='0'and Itm.Sts='0'"
        cmd = New SqlCommand(sql, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Table.Rows.Add(rdr("ItemCode"), rdr("ItemName"), rdr("CPrice"), rdr("Qty"), "0")
        End While
        rdr.Close()


        Dim xxc As New RptStk
        xxc.SetDataSource(ds.Tables(1))
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()
        '  xxc.Close()
        '  xxc.Dispose()
        ' report5.RecordSelectionFormula = "{Pay_Master.LastUpdate} ='" & xxd & "'"
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim report3 As New RPT6
        report3.SetParameterValue("xFROM", DTP1.Text)
        report3.SetParameterValue("xTO", DTP2.Text)

        report3.RecordSelectionFormula = "{Pay_Master.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Pay_Master.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report3)
        CrystalReportViewer1.ReportSource = report3
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()
        Dim sql As String = "SELECT Itm.ItemCode, Itm.ItemName, Itr.Qty,Itr.SellPrice
From Itm
INNER Join Itr ON Itm.ItemCode=Itr.ItemCode where Itr.Sts='0'and Itr.Qty<0 and Itr.LastUpdate>='" & DTP1.Value.Date & "'and lastUpdate<='" & DTP2.Value.Date & "'"
        Try
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                Table.Rows.Add(rdr("ItemCode"), rdr("ItemName"), rdr("SellPrice"), rdr("Qty"), "0")
            End While
            rdr.Close()
        Catch ex As Exception
            rdr.Close()
        End Try


        Dim report6 As New RPT7
        report6.SetDataSource(ds.Tables(1))
        'report6.RecordSelectionFormula = "{Inv_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        'xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Dim report19 As New RPT19
        ' report7.RecordSelectionFormula = "{Receipt_Main.RcvDT} ='" & FrmREPORT.TextBox1.Text & "'"
        report19.RecordSelectionFormula = "{Receipt_Main.RcvDT} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Receipt_Main.RcvDT} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report19)
        CrystalReportViewer1.ReportSource = report19
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Dim report20 As New RPTCSI
        ' report7.RecordSelectionFormula = "{Receipt_Main.RcvDT} ='" & FrmREPORT.TextBox1.Text & "'"
        report20.RecordSelectionFormula = "{Inv_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Inv_Sub.CusCode}<>'" & "" & "'"
        xCRINFO(report20)
        CrystalReportViewer1.ReportSource = report20
        CrystalReportViewer1.Refresh()
        ' Dim reportPRFT As New RPTPROFIT
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Dim report6 As New RPTPROFIT
        report6.RecordSelectionFormula = "{Inv_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub CusName_TextChanged(sender As Object, e As EventArgs) Handles CusName.TextChanged
        If CusName.Text = "" Then
            cmd = New SqlCommand("Select * from Cus_Master order by CusName", con)
        Else
            cmd = New SqlCommand("Select * from Cus_Master where CusName like '%" & CusName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"))
        End While
        rdr.Close()
    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        CusCoode.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        CusName.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
    End Sub

    Private Sub LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Dim report01 As New RPT10
        report01.RecordSelectionFormula = "{Cust_Sub.CusCode}='" & CusCoode.Text & "'"
        xCRINFO(report01)
        CrystalReportViewer1.ReportSource = report01
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Dim report01 As New RPT10
        report01.RecordSelectionFormula = "{Cust_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Cust_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Cust_Sub.CusCode}='" & CusCoode.Text & "'"
        xCRINFO(report01)
        CrystalReportViewer1.ReportSource = report01
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel13_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        Dim report01 As New RptCusSt
        report01.RecordSelectionFormula = "{CusState.CusCode}='" & CusCoode.Text & "'"
        xCRINFO(report01)
        CrystalReportViewer1.ReportSource = report01
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel14_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Dim report6 As New RptDamage
        report6.RecordSelectionFormula = "{DMG_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {DMG_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub
    Dim CusCode As String = Nothing
    Private Sub GRID2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentClick

    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        txtSupCode.Text = GRID2.Item(0, GRID2.CurrentRow.Index).Value
        txtSupName.Text = GRID2.Item(1, GRID2.CurrentRow.Index).Value
    End Sub

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier order by SupName", con)
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

    Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Dim report6 As New RptSupRtn
        report6.RecordSelectionFormula = "{SUPRTN_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {SUPRTN_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {SUPRTN_Sub.SupCode}='" & txtSupCode.Text & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel16_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel16.LinkClicked
        Dim reportMRN As New RptShopBL
        reportMRN.RecordSelectionFormula = "{MrningCash.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {MrningCash.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(reportMRN)
        CrystalReportViewer1.ReportSource = reportMRN
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel17_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel17.LinkClicked
        Dim reportCRD As New RptCashTaken
        reportCRD.RecordSelectionFormula = "{CreditTaken_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {CreditTaken_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(reportCRD)
        CrystalReportViewer1.ReportSource = reportCRD
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel18_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel18.LinkClicked
        Dim report19 As New RPT19
        ' report7.RecordSelectionFormula = "{Receipt_Main.RcvDT} ='" & FrmREPORT.TextBox1.Text & "'"
        report19.RecordSelectionFormula = "{Receipt_Main.CusName} ='" & CusName.Text & "'"
        xCRINFO(report19)
        CrystalReportViewer1.ReportSource = report19
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel19_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel19.LinkClicked
        If CmbAccount.Text = "" Then Return
        Dim report3 As New RPT6
        report3.SetParameterValue("xFROM", DTP1.Text)
        report3.SetParameterValue("xTO", DTP2.Text)
        report3.RecordSelectionFormula = "{Pay_Master.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Pay_Master.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Pay_Master.PayAccount}='" & CmbAccount.Text & "'"
        xCRINFO(report3)
        CrystalReportViewer1.ReportSource = report3
        CrystalReportViewer1.Refresh()





        'Dim reportCRT As New RptCreditTaken
        'reportCRT.RecordSelectionFormula = "{Credit_Taken.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Credit_Taken.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Credit_Taken.CusName}='" & CmbAccount.Text & "'"
        'xCRINFO(reportCRT)
        'CrystalReportViewer1.ReportSource = reportCRT
        'CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel20_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        If CmbAccount.Text = "" Then Return
        Dim reportCRT As New RptCreditTaken
        reportCRT.RecordSelectionFormula = "{Credit_Taken.CusName}='" & CmbAccount.Text & "'"
        xCRINFO(reportCRT)
        CrystalReportViewer1.ReportSource = reportCRT
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel21_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel21.LinkClicked
        Dim reportPNL As New RptPNL
        Dim aINT As Integer = 0
        Dim xTotalSales As Double = 0
        Dim xTotalCosts As Double = 0
        Dim xGrossProfit As Double = 0
        Dim xTotalRetuns As Double = 0
        Dim xTotalRtCosts As Double = 0
        Dim xRtnLost As Double = 0
        Dim xEspences As Double = 0
        Dim xNetProfit As Double = 0




        cmd = New SqlCommand("Select count(INVNo) from Inv_Main where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
        aINT = cmd.ExecuteScalar
        If aINT > 0 Then
            cmd = New SqlCommand("Select sum(Amnt) from Inv_Sub where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
            xTotalSales = cmd.ExecuteScalar

            cmd = New SqlCommand("Select sum(CPrice*Qty) from Inv_Sub where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
            xTotalCosts = cmd.ExecuteScalar
            xGrossProfit = xTotalSales - xTotalCosts
        End If
        aINT = 0

        cmd = New SqlCommand("Select count(Amount) from SLRTN_Main where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
        aINT = cmd.ExecuteScalar
        If aINT > 0 Then
            cmd = New SqlCommand("Select sum(Amount) from SLRTN_Main where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
            xTotalRetuns = cmd.ExecuteScalar
            cmd = New SqlCommand("Select sum(CPrice*Qty) from SLRTN_Sub where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
            xTotalRtCosts = cmd.ExecuteScalar
            xRtnLost = xTotalRetuns - xTotalRtCosts
        End If
        aINT = 0
        cmd = New SqlCommand("Select count(Amnt) from Pay_Master where(Description <>'" & "Suplier Payment" & "'and LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
        aINT = cmd.ExecuteScalar
        If aINT > 0 Then
            cmd = New SqlCommand("Select sum(Amnt) from Pay_Master where(Description <>'" & "Suplier Payment" & "'and LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
            xEspences = cmd.ExecuteScalar
        End If
        xNetProfit = xGrossProfit - (xRtnLost + xEspences)
        Dim xTotalSalesS As String = xFRMT(xTotalSales)
        Dim xTotalCostsS As String = xFRMT(xTotalCosts)
        Dim xGrossProfitS As String = xFRMT(xGrossProfit)
        Dim xTotalRetunsS As String = xFRMT(xTotalRetuns)
        Dim xTotalRtCostsS As String = xFRMT(xTotalRtCosts)
        Dim xRtnLostS As String = xFRMT(xRtnLost)
        Dim xEspencesS As String = xFRMT(xEspences)
        Dim xNetProfitS As String = xFRMT(xNetProfit)
        reportPNL.SetParameterValue("xTSLS", xTotalSalesS)
        reportPNL.SetParameterValue("xTCOST", xTotalCostsS)
        reportPNL.SetParameterValue("xGPRF", xGrossProfitS)
        reportPNL.SetParameterValue("xRTNS", xTotalRetunsS)
        reportPNL.SetParameterValue("xRCOST", xTotalRtCostsS)
        reportPNL.SetParameterValue("xLOST", xRtnLostS)
        reportPNL.SetParameterValue("xEXPN", xEspencesS)
        reportPNL.SetParameterValue("xNETPF", xNetProfitS)
        reportPNL.RecordSelectionFormula = "{Pay_Master.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Pay_Master.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Pay_Master.Description} <>'" & "Suplier Payment" & "'"
        ' reportPNL.RecordSelectionFormula = "{Credit_Taken.CusName}='" & CmbAccount.Text & "'"
        xCRINFO(reportPNL)
        CrystalReportViewer1.ReportSource = reportPNL
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub LinkLabel22_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel22.LinkClicked
        If txtSupName.Text = "" Then Return
        'Dim xInteger As Integer = 0
        'cmd = New SqlCommand("Select Count(SupCode) from CHQPAY_Sub where(SupName='" & txtSupName.Text & "')", con)
        'xInteger = cmd.ExecuteScalar
        'Dim xChqpaid As Double = 0
        'If xInteger > 0 Then
        cmd = New SqlCommand("Select sum(SupBalance) from Supplier where(SupName='" & txtSupName.Text & "')", con)
        xChqpaid = cmd.ExecuteScalar
        'End If
        Dim reportCRT As New SupPayments
        reportCRT.SetParameterValue("xSUPNAME", txtSupName.Text)
        reportCRT.SetParameterValue("xCURBAL", xChqpaid)

        reportCRT.RecordSelectionFormula = "{Supplier.SupName}='" & txtSupName.Text & "'"
        xCRINFO(reportCRT)
        CrystalReportViewer1.ReportSource = reportCRT
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel23_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel23.LinkClicked
        Dim NumberOfDays As Integer = DateDiff(DateInterval.Day, DTP1.Value, DTP2.Value)
        Dim TotalSales As Double = 0
        cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate>= '" & DTP1.Value & "'and LastUpdate<='" & DTP2.Value & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Select sum(InvAmnt) from Inv_Main where(LastUpdate>= '" & DTP1.Value & "'and LastUpdate<='" & DTP2.Value & "')", con1)
            TotalSales = cmd1.ExecuteScalar
        End If
        rdr.Close()
        NumberOfDays = NumberOfDays + 1
        Dim AverageSales As Double = TotalSales / NumberOfDays
        Dim Avera As New RptAverage
        Avera.SetParameterValue("xFROM", DTP1.Text)
        Avera.SetParameterValue("xTO", DTP2.Text)
        Avera.SetParameterValue("xNO", NumberOfDays)
        Avera.SetParameterValue("xAVG", AverageSales)
        Avera.RecordSelectionFormula = "{Inv_Main.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Main.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(Avera)
        CrystalReportViewer1.ReportSource = Avera
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub LinkLabel24_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel24.LinkClicked
        If CmbAccount1.Text = "" Then Return
        Dim BAccountNumber As String = CmbAccount1.Text.Split(" - ")(0)
        Dim TotalCR As Double = 0
        Dim TotalDR As Double = 0
        cmd = New SqlCommand("Select * from Acc_Main where(AccNo='" & BAccountNumber & "'and LastUpdate< '" & DTP1.Value & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Select sum(Credit) from Acc_Main where(AccNo='" & BAccountNumber & "'and LastUpdate< '" & DTP1.Value & "')", con1)
            TotalCR = cmd1.ExecuteScalar

            cmd1 = New SqlCommand("Select sum(Debit) from Acc_Main where(AccNo='" & BAccountNumber & "'and LastUpdate< '" & DTP1.Value & "')", con1)
            TotalDR = cmd1.ExecuteScalar
        End If
        rdr.Close()
        Dim AccSum As New RptAccountSum
        AccSum.SetParameterValue("xACC", CmbAccount1.Text)
        AccSum.SetParameterValue("xFROM", DTP1.Text)
        AccSum.SetParameterValue("xTO", DTP2.Text)
        AccSum.SetParameterValue("xBF", TotalDR - TotalCR)
        'AccSum.SetParameterValue("xAVG", AverageSales)
        AccSum.RecordSelectionFormula = "{Acc_Main.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Acc_Main.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(AccSum)
        CrystalReportViewer1.ReportSource = AccSum
        CrystalReportViewer1.Refresh()


    End Sub

    Private Sub LinkLabel25_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel25.LinkClicked
        'If CmbItem.Text = "" Then Return
        'Dim ItemCodeS As String = CmbItem.Text.Split(" - ")(0)
        Dim report6 As New RPT7
        report6.RecordSelectionFormula = "{Inv_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Inv_Sub.ItemCode}='" & ItemCode.Text & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel26_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel26.LinkClicked

        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()
        Dim sales As Double = 0
        Dim cost As Double = 0
        Dim rtnCost As Double = 0
        Dim prf As Double = 0
        Dim startP As DateTime = DTP1.Value.Date
        Dim endP As DateTime = DTP2.Value.Date
        Dim CurrD As DateTime = startP

        While (CurrD <= endP)
            cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0) from Inv where Dte='" & CurrD & "'and Sts=0 and InvAmnt>0", con)
            sales = cmd.ExecuteScalar

            cmd = New SqlCommand("Select ISNULL(SUM(CPrice*Qty),0) from Itr where LastUpdate='" & CurrD & "'and Sts=0 and Qty<0 and Tno like'%" & "IN" & "%'", con)
            cost = cmd.ExecuteScalar
            cmd = New SqlCommand("Select ISNULL(SUM(CPrice*Qty),0) from Itr where LastUpdate='" & CurrD & "'and Sts=0 and Qty>0 and Tno like'%" & "IN" & "%'", con)
            rtnCost = cmd.ExecuteScalar
            cost = cost * -1
            prf = sales - (cost - rtnCost)
            Table.Rows.Add(CurrD.ToShortDateString, sales, prf, "0", "0")
            CurrD = CurrD.AddDays(1)
        End While
        Dim AccSum As New RptDayAll
        AccSum.SetDataSource(ds.Tables(1))
        AccSum.SetParameterValue("dte", DTP1.Text & "  -  " & DTP2.Text)
        CrystalReportViewer1.ReportSource = AccSum
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel27_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel27.LinkClicked
        Dim report6 As New RptDayInv
        report6.RecordSelectionFormula = "{Inv_Main.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Main.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub ItemCode_TextChanged(sender As Object, e As EventArgs) Handles ItemCode.TextChanged
        cmd = New SqlCommand("Select * from Inv_Sub where ItemCode = '" & ItemCode.Text & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            ItemName.Text = rdr("ItemName")
        Else
            ItemName.Clear()
        End If
        rdr.Close()
    End Sub

    Private Sub LinkLabel20_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel20.LinkClicked
        If txtSupCode.Text = "" Then Return
        Dim xGN As Double = 0
        Dim xPay As Double = 0
        cmd = New SqlCommand("Select * from SupState where SupCode='" & txtSupCode.Text & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Select sum(GrnAmnt) from SupState where(SupCode='" & txtSupCode.Text & "')", con1)
            xGN = cmd1.ExecuteScalar
            cmd1 = New SqlCommand("Select sum(PayAmnt) from SupState where(SupCode='" & txtSupCode.Text & "')", con1)
            xPay = cmd1.ExecuteScalar
            cmd1 = New SqlCommand("Update Supplier set SupBalance='" & xGN - xPay & "'where SupCode='" & txtSupCode.Text & "'", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        Dim report6 As New RptSupState
        report6.SetParameterValue("xFROM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        ' report6.RecordSelectionFormula = "{SupState.GrnDate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {SupState.GrnDate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {SupState.SupName}='" & txtSupName.Text & "'"
        report6.RecordSelectionFormula = "{SupState.SupCode}='" & txtSupCode.Text & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel28_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel28.LinkClicked
        Dim report6 As New RptDmg
        report6.SetParameterValue("xFROM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        report6.RecordSelectionFormula = "{DMG_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {DMG_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel29_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel29.LinkClicked
        Dim report6 As New RptRcvdChq
        report6.SetParameterValue("xFRM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        report6.RecordSelectionFormula = "{ChqRcv.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {ChqRcv.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {ChqRcv.CHQNo} <>'" & "-" & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel30_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel30.LinkClicked
        Dim report6 As New RptChqPay
        report6.SetParameterValue("xFRM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        report6.RecordSelectionFormula = "{CHQPAY_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {CHQPAY_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {CHQPAY_Sub.CHQNo} <>'" & "-" & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel31_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel31.LinkClicked


        Dim report6 As New RptDepChq
        report6.SetParameterValue("xFRM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        report6.RecordSelectionFormula = "{CHQ_Dep.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {CHQ_Dep.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel32_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel32.LinkClicked
        If CusCoode.Text = "" Then Return
        Dim report6 As New RptRcvdChq
        report6.SetParameterValue("xFRM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        report6.RecordSelectionFormula = "{ChqRcv.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {ChqRcv.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {ChqRcv.CHQNo} <>'" & "-" & "'and {ChqRcv.CusCode}='" & CusCoode.Text & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel33_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel33.LinkClicked
        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()
        cmd = New SqlCommand("Select * from Edt where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Table.Rows.Add(rdr("ItemCode"), rdr("ImtmName"), rdr("Description"), rdr("NewDes"), Format(rdr("LastUpdate"), "yyyy-MM-dd"))
        End While
        rdr.Close()
        Dim xxc As New RptLogs
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("xf", DTP1.Text)
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel34_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel34.LinkClicked
        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()
        cmd = New SqlCommand("Select * from CHQPAY_Sub where Status='" & "STOPED" & "'", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Table.Rows.Add(rdr("BankAcc"), rdr("CHQNo"), Format(rdr("CHQUpdate"), "yyyy-MM-dd"), rdr("CHQAmnt"), rdr("SupName"))
        End While
        rdr.Close()
        Dim xxc As New RtpStopped
        xxc.SetDataSource(ds.Tables(1))
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel35_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel35.LinkClicked
        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()
        ' cmd = New SqlCommand("Select Stock_Sub.ItemCode,Stock_Sub.ItemName,Stock_Sub.RcvQty,ItemMaster.ItemCode,ItemMaster.SellPrice from (Stock_Sub INNER JOIN ItemMaster on Stock_Sub.ItemCode=ItemMaster.ItemCode)ORDER BY cast(Stock_Sub.ItemCode as Int)ASC", con)
        cmd = New SqlCommand("Select Stock_Adj.ItemCode,Stock_Adj.ItemName,Stock_Adj.RcvQty,Stock_Adj.SaleQty,Stock_Adj.DmgQty,Stock_Main.CostPrice from(Stock_Adj INNER JOIN Stock_Main on Stock_Adj.ItemCode=Stock_Main.ItemCode) where Stock_Adj.DmgQty<>0 order by Stock_Adj.LastUpdate", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            'ItemCode, ItemName, RcvQty, SaleQty, DmgQty
            Table.Rows.Add(rdr("ItemCode"), rdr("ItemName"), rdr("RcvQty"), rdr("CostPrice"), rdr("DmgQty") * -1)
        End While
        rdr.Close()

        Dim acc As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Stock_Adj.DmgQty*Stock_Main.CostPrice),0) from(Stock_Adj INNER JOIN Stock_Main on Stock_Adj.ItemCode = Stock_Main.ItemCode)where Stock_Adj.DmgQty<0", con)
        acc = cmd.ExecuteScalar

        Dim shrt As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Stock_Adj.DmgQty*Stock_Main.CostPrice),0) from(Stock_Adj INNER JOIN Stock_Main on Stock_Adj.ItemCode = Stock_Main.ItemCode)where Stock_Adj.DmgQty>0", con)
        shrt = cmd.ExecuteScalar

        Dim shorts As String = Format(shrt, "0.00")
        Dim access As String = Format(acc * -1, "0.00")

        Dim xxc As New RptStkAdjusted
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("xShort", shorts)
        xxc.SetParameterValue("xAcce", access)
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub LinkLabel36_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel36.LinkClicked
        If txtEmp.Text = "" Then
            MsgBox("Please Type an Emplyee Code and Try...!")
            Return
        End If
        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()
        Dim stDate As DateTime = DTP1.Value.Date
        While stDate <= DTP2.Value.Date
            Dim saleAmnt As Double = 0
            cmd = New SqlCommand("Select ISNULL(SUM(Amnt),0) from Inv_Sub where LastUpdate='" & stDate.Date & "'and ItemName like '%" & "#" & txtEmp.Text & "#" & "%'", con)
            saleAmnt = cmd.ExecuteScalar
            Table.Rows.Add(stDate.ToShortDateString(), saleAmnt, "0", "0", "0")
            stDate = stDate.AddDays(1)
        End While

        Dim xxc As New RptSalesEmp
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("ss", "Sales Summery For Emplyee - " & txtEmp.Text)
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel37_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel37.LinkClicked
        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()
        cmd = New SqlCommand("Select Distinct(UnitId) from Workstation", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Dim sales As Double = 0
            cmd1 = New SqlCommand("Select ISNULL(SUM(InvAmnt),0) from Inv_Main where INVNo like '%" & rdr("UnitID") & "%'and LastUpdate='" & DTP1.Value.Date & "'", con1)
            sales = cmd1.ExecuteScalar
            Table.Rows.Add(rdr("UnitID"), Format(sales, "0.00"), "0", "0", "0")
        End While
        rdr.Close()
        Dim xxc As New RptUsl
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("xdt", "Sales Summery For Counters for the day of - " & DTP1.Text)
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()

    End Sub
End Class