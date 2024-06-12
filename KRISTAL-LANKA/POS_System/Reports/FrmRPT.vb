Imports System.Data.SqlClient
Imports ConnData
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Win32
Imports POS_System.NewFunc
Public Class FrmRPT
    Dim xSERVER As String = Nothing
    Dim xPW As String = Nothing
    Private Sub FrmRPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xSERVER = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "Server", Nothing)
        xPW = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "DatabasePw", Nothing)
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.WindowState = FormWindowState.Maximized
        If FrmMDI.txtCNT.Text = 1 Then
            'GRNREPORTS==================================
            If FrmGRNRPT.RBT1.Checked = True Then
                Dim grnRPTTTL As New RPTGRNTTL

                'grnRPTTTL.RecordSelectionFormula = "{Cust_Sub.LastUpdate} ='" & FrmREPORT.DTP2.Value & "'and {Cust_Sub.CusCode} ='" & FrmREPORT.txtCucCd.Text & "'"
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

                CrTables = grnRPTTTL.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = grnRPTTTL
                CrystalReportViewer1.Refresh()
            ElseIf FrmGRNRPT.RBT2.Checked = True Then
                Dim grnRPTTTL As New RPTGRNTTL
                grnRPTTTL.RecordSelectionFormula = "{GRN_Main.SupCode} ='" & FrmGRNRPT.SupCD.Text & "'"
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

                CrTables = grnRPTTTL.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = grnRPTTTL
                CrystalReportViewer1.Refresh()
            ElseIf FrmGRNRPT.RBT3.Checked = True Then
                Dim grnRPTTTL As New RPTGRNTTL
                'grnRPTTTL.RecordSelectionFormula = "{Cust_Sub.LastUpdate} ='" & FrmREPORT.DTP2.Value & "'and {Cust_Sub.CusCode} ='" & FrmREPORT.txtCucCd.Text & "'"
                grnRPTTTL.RecordSelectionFormula = "{GRN_Main.LastUpdate} >='" & FrmGRNRPT.DTP1.Value & "'and {GRN_Main.LastUpdate}<='" & FrmGRNRPT.DTP2.Value & "'"
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

                CrTables = grnRPTTTL.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = grnRPTTTL
                CrystalReportViewer1.Refresh()
            ElseIf FrmGRNRPT.RBT4.Checked = True Then
                Dim grnRPTTTL As New RPTGRNTTL
                'grnRPTTTL.RecordSelectionFormula = "{Cust_Sub.LastUpdate} ='" & FrmREPORT.DTP2.Value & "'and {Cust_Sub.CusCode} ='" & FrmREPORT.txtCucCd.Text & "'"
                grnRPTTTL.RecordSelectionFormula = "{GRN_Main.LastUpdate} >='" & FrmGRNRPT.DTP1.Value & "'and {GRN_Main.LastUpdate}<='" & FrmGRNRPT.DTP2.Value & "'and {GRN_Main.SupCode}='" & FrmGRNRPT.SupCD.Text & "'"
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

                CrTables = grnRPTTTL.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = grnRPTTTL
                CrystalReportViewer1.Refresh()
            ElseIf FrmGRNRPT.RBT5.Checked = True Then
                Dim grnRPTTITM As New RPTTPITM
                'grnRPTTTL.RecordSelectionFormula = "{Cust_Sub.LastUpdate} ='" & FrmREPORT.DTP2.Value & "'and {Cust_Sub.CusCode} ='" & FrmREPORT.txtCucCd.Text & "'"
                'grnRPTTTL.RecordSelectionFormula = "{GRN_Main.LastUpdate} >='" & FrmGRNRPT.DTP1.Value & "'and {GRN_Main.LastUpdate}<='" & FrmGRNRPT.DTP2.Value & "'and {GRN_Main.SupCode}='" & FrmGRNRPT.SupCD.Text & "'"
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
                CrTables = grnRPTTITM.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = grnRPTTITM
                CrystalReportViewer1.Refresh()
            ElseIf FrmGRNRPT.RBT6.Checked = True Then
                Dim GRNITM As New RPTGRNITM
                GRNITM.RecordSelectionFormula = "{GRN_Sub.GRNNo} ='" & FrmGRNRPT.GRNNo.Text & "'"
                'grnRPTTTL.RecordSelectionFormula = "{GRN_Main.LastUpdate} >='" & FrmGRNRPT.DTP1.Value & "'and {GRN_Main.LastUpdate}<='" & FrmGRNRPT.DTP2.Value & "'and {GRN_Main.SupCode}='" & FrmGRNRPT.SupCD.Text & "'"
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
                CrTables = GRNITM.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = GRNITM
                CrystalReportViewer1.Refresh()
            End If
        ElseIf FrmMDI.txtCNT.Text = 2 Then
            If FrmREPORT.xVW = True Then
                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Dim report01 As New RPT10
                report01.RecordSelectionFormula = "{Cust_Sub.LastUpdate} ='" & FrmREPORT.DTP2.Value & "'and {Cust_Sub.CusCode} ='" & FrmREPORT.txtCucCd.Text & "'"
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
                CrTables = report01.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report01
                CrystalReportViewer1.Refresh()
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            End If
            If FrmREPORT.CmbRPT.Text = "Customer Master" Then
                Dim report As New RPT1
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
                CrTables = report.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Supplier Returns" Then
            ElseIf FrmREPORT.CmbRPT.Text = "Supplier Master" Then
                Dim report1 As New RPT2
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
                CrTables = report1.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report1
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Item Master" Then
                Dim report2 As New RPT3
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
                CrTables = report2.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report2
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Day Summery" Then
                Dim report3 As New RPT4
                '" {tblname.datetimefield} In Date(" & format(text1,"yyyy,mm,dd") & ") "     & " To Date(" & format(text2,"yyyy,mm,dd") & ") "
                ' RptRaw.RecordSelectionFormula = " {Raw_Collect.ColDate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Raw_Collect.ColDate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
                'report2.RecordSelectionFormula = "{Customers.CusNIC}='" & Form1.TextBox2.Text & "'"
                report3.RecordSelectionFormula = "{Salesmaster.LastUpdate} ='" & Format(FrmREPORT.DTP1.Value, "yyyy-MM-dd") & "'"
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
                CrTables = report3.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report3
                CrystalReportViewer1.Refresh()
                Return
            ElseIf FrmREPORT.CmbRPT.Text = "Stock Summery" Then
                Dim report4 As New RPT5
                'report2.RecordSelectionFormula = "{Customers.CusNIC}='" & Form1.TextBox2.Text & "'"
                'report3.RecordSelectionFormula = "{Salesmaster.LastUpdate} ='" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "'"
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
                CrTables = report4.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report4
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Payment Summery" Then
                Dim report5 As New RPT6
                'm_Report.RecordSelectionFormula = "{MyTable.MyDateField} =Date(" & Format(Combo1.Text, "yyyy,mm,dd") & ")"
                'report2.RecordSelectionFormula = "{Customers.CusNIC}='" & Form1.TextBox2.Text & "'"
                'report3.RecordSelectionFormula = "{Salesmaster.LastUpdate} ='" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "'"
                '  In Date(" & format(text1,"yyyy,mm,dd") & ")
                'selectionFormula="{tblMain.bday}=CDate('"& datetimepicker.value &"')"
                Dim xxd As String = FrmREPORT.TextBox1.Text
                'report5.RecordSelectionFormula = "{Pay_Master.LastUpdate} ='" & xxd & "'"
                report5.RecordSelectionFormula = "{Pay_Master.LastUpdate} ='" & xxd & "'"
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
                CrTables = report5.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report5
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Month Sales" Then
                Dim xCSH As Double = 0
                Dim xCRD As Double = 0
                Dim xCRDT As Double = 0
                Dim xTTL As Double = 0
                Dim xDTE As String = Nothing
                'cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and InvType='" & "CASH" & "')", con)
                'rdr = cmd.ExecuteReader
                'If rdr.Read = True Then
                '    cmd1 = New SqlCommand("Select sum(InvAmnt) from Inv_Main where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and InvType='" & "CASH" & "')", con1)
                '    xCSH = cmd1.ExecuteScalar
                'End If
                'rdr.Close()

                'cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and InvType='" & "CARD" & "')", con)
                'rdr = cmd.ExecuteReader
                'If rdr.Read = True Then
                '    cmd1 = New SqlCommand("Select sum(InvAmnt) from Inv_Main where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and InvType='" & "CARD" & "')", con1)
                '    xCRD = cmd1.ExecuteScalar
                'End If
                'rdr.Close()

                'cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and InvType='" & "CREDIT" & "')", con)
                'rdr = cmd.ExecuteReader
                'If rdr.Read = True Then
                '    cmd1 = New SqlCommand("Select sum(InvAmnt) from Inv_Main where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and InvType='" & "CREDIT" & "')", con1)
                '    xCRDT = cmd1.ExecuteScalar
                'End If
                'rdr.Close()

                'cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "')", con)
                'rdr = cmd.ExecuteReader
                'If rdr.Read = True Then
                '    cmd1 = New SqlCommand("Select sum(InvAmnt) from Inv_Main where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "')", con1)
                '    xTTL = cmd1.ExecuteScalar
                'End If
                'rdr.Close()
                cmd = New SqlCommand("Select * from SalesMaster where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and CashSales > 0 )", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    cmd1 = New SqlCommand("Select sum(CashSales) from SalesMaster where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and CashSales > 0)", con1)
                    xCSH = cmd1.ExecuteScalar
                End If
                rdr.Close()
                cmd = New SqlCommand("Select * from SalesMaster where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and CardSLS > 0)", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    cmd1 = New SqlCommand("Select sum(CardSLS) from SalesMaster where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and CardSLS > 0)", con1)
                    xCRD = cmd1.ExecuteScalar
                End If
                rdr.Close()
                cmd = New SqlCommand("Select * from SalesMaster where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and CreditSales > 0)", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    cmd1 = New SqlCommand("Select sum(CreditSales) from SalesMaster where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "'and CreditSales > 0)", con1)
                    xCRDT = cmd1.ExecuteScalar
                End If
                rdr.Close()
                'cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "')", con)
                'rdr = cmd.ExecuteReader
                'If rdr.Read = True Then
                '    cmd1 = New SqlCommand("Select sum(InvAmnt) from Inv_Main where(LastUpdate>= '" & FrmREPORT.DTP1.Value & "'and LastUpdate<='" & FrmREPORT.DTP3.Value & "')", con1)
                '    xTTL = cmd1.ExecuteScalar
                'End If
                'rdr.Close()
                xDTE = Format(FrmREPORT.DTP1.Value, "yyyy - MMMM")
                xCSH = Format(xCSH, "0.00")
                xCRD = Format(xCRD, "0.00")
                xCRDT = Format(xCRDT, "0.00")
                xTTL = Format(xTTL, "0.00")
                Dim report3 As New RptMonthSale
                report3.RecordSelectionFormula = "{SalesMaster.LastUpdate} >='" & Format(FrmREPORT.DTP1.Value, "yyyy-MM-dd") & "'and {SalesMaster.LastUpdate} <='" & Format(FrmREPORT.DTP3.Value, "yyyy-MM-dd") & "'"
                report3.SetParameterValue("xCASHSL", xCSH)
                report3.SetParameterValue("xCARDSL", xCRD)
                report3.SetParameterValue("xCREDITSL", xCRDT)
                ' report3.SetParameterValue("xTOTALSL", xTTL)
                report3.SetParameterValue("xYEAR", xDTE)
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
                CrTables = report3.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report3
                CrystalReportViewer1.Refresh()
                '  xDTE = Format(FrmREPORT.DTP1.Value, "yyyy-MMMM")
            ElseIf FrmREPORT.CmbRPT.Text = "Item Wise" Then
                Dim report6 As New RPT7
                'selectionFormula="{tblMain.bday}=CDate('"& datetimepicker.value &"')"
                'report2.RecordSelectionFormula = "{Customers.CusNIC}='" & Form1.TextBox2.Text & "'"
                'report3.RecordSelectionFormula = "{Salesmaster.LastUpdate} ='" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "'"
                '  In Date(" & format(text1,"yyyy,mm,dd") & ")
                Dim xCC As String = FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd")
                'xCC = Format(xCC, "yyyy-MM-dd").ToString
                report6.RecordSelectionFormula = "{Inv_Sub.LastUpdate} ='" & FrmREPORT.TextBox1.Text & "'"
                'report6.RecordSelectionFormula = "{Inv_Sub.LastUpdate} =CDate('" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "')"
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
                CrTables = report6.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report6
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Cash Receipt" Then
                Dim report7 As New RPT19
                'selectionFormula="{tblMain.bday}=CDate('"& datetimepicker.value &"')"
                'report2.RecordSelectionFormula = "{Customers.CusNIC}='" & Form1.TextBox2.Text & "'"
                'report3.RecordSelectionFormula = "{Salesmaster.LastUpdate} ='" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "'"
                '  In Date(" & format(text1,"yyyy,mm,dd") & ")
                Dim xCCD As String = FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd")
                'xCC = Format(xCC, "yyyy-MM-dd").ToString
                report7.RecordSelectionFormula = "{Receipt_Main.RcvDT} ='" & FrmREPORT.TextBox1.Text & "'"
                'report6.RecordSelectionFormula = "{Inv_Sub.LastUpdate} =CDate('" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "')"
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
                CrTables = report7.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report7
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Supplier Acc" Then
                Dim report11 As New RPT11
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
                CrTables = report11.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = report11
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Day Sold Items" Then
                Dim reportSITM As New RPTSITM
                reportSITM.RecordSelectionFormula = "{Inv_Sub.LastUpdate} ='" & FrmREPORT.DTP1.Value & "'"
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
                CrTables = reportSITM.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = reportSITM
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Credit Sold Items" Then
                Dim reportCSI As New RPTCSI
                reportCSI.RecordSelectionFormula = "{Inv_Sub.LastUpdate} ='" & FrmREPORT.DTP1.Value & "'and {Inv_Sub.CusCode}='" & FrmREPORT.CusCode.Text & "'"
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
                CrTables = reportCSI.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = reportCSI
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Profit Wise" Then
                Dim reportPRFT As New RPTPROFIT
                reportPRFT.RecordSelectionFormula = "{Inv_Sub.LastUpdate} ='" & FrmREPORT.DTP1.Value & "'"
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
                CrTables = reportPRFT.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = reportPRFT
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Vegetable" Then
                Dim RPTVEG As New RPTVEG
                RPTVEG.RecordSelectionFormula = "{Inv_Sub.IType} ='" & "Veg" & "'and {Inv_Sub.LastUpdate}='" & FrmREPORT.DTP1.Value & "'"
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

                CrTables = RPTVEG.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                CrystalReportViewer1.ReportSource = RPTVEG
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Veg Stock" Then
                Dim report4 As New RPT5
                Dim xTY As String = "Veg"
                report4.RecordSelectionFormula = "{Stock_Main.IType}='" & xTY & "'"
                'report3.RecordSelectionFormula = "{Salesmaster.LastUpdate} ='" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "'"
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
                CrTables = report4.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next

                CrystalReportViewer1.ReportSource = report4
                CrystalReportViewer1.Refresh()
            ElseIf FrmREPORT.CmbRPT.Text = "Card Sales" Then
                Dim reportCRD As New PRTCARDPAY
                'Dim xTY As String = "Veg"
                reportCRD.RecordSelectionFormula = "{SalesMaster.LastUpdate}>'" & FrmREPORT.DTP1.Value & "'and {SalesMaster.LastUpdate}<'" & FrmREPORT.DTP3.Value & "'"
                'report3.RecordSelectionFormula = "{Salesmaster.LastUpdate} ='" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "'"
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

                CrTables = reportCRD.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next

                CrystalReportViewer1.ReportSource = reportCRD
                CrystalReportViewer1.Refresh()
            End If
        ElseIf FrmMDI.txtCNT.Text = 500 Then
            'Dim rptDEND As New RPTDEND
            'Dim crtableLogoninfos As New TableLogOnInfos
            'Dim crtableLogoninfo As New TableLogOnInfo
            'Dim crConnectionInfo As New ConnectionInfo
            'Dim CrTables As Tables
            'Dim CrTable As Table
            'With crConnectionInfo
            '    .ServerName = xSERVER
            '    .DatabaseName = "Pos_System"
            '    .UserID = "sa"
            '    .Password = xPW
            'End With

            'CrTables = rptDEND.Database.Tables
            'For Each CrTable In CrTables
            '    crtableLogoninfo = CrTable.LogOnInfo
            '    crtableLogoninfo.ConnectionInfo = crConnectionInfo
            '    CrTable.ApplyLogOnInfo(crtableLogoninfo)
            'Next
            'CrystalReportViewer1.ReportSource = rptDEND
            'CrystalReportViewer1.Refresh()

            'Dim report7 As New RPT8
            ''selectionFormula="{tblMain.bday}=CDate('"& datetimepicker.value &"')"
            ''report2.RecordSelectionFormula = "{Customers.CusNIC}='" & Form1.TextBox2.Text & "'"

            ''report3.RecordSelectionFormula = "{Salesmaster.LastUpdate} ='" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "'"
            ''  In Date(" & format(text1,"yyyy,mm,dd") & ")

            ''Dim xCC As String = FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd")
            ''xCC = Format(xCC, "yyyy-MM-dd").ToString
            'report7.RecordSelectionFormula = "{Cust_Sub.CusCode}='" & FrmREPORT.TextBox2.Text & "'or {Receipt_Main.CusCode} ='" & FrmREPORT.TextBox2.Text & "'"
            ''report6.RecordSelectionFormula = "{Inv_Sub.LastUpdate} =CDate('" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "')"
            'Dim crtableLogoninfos1 As New TableLogOnInfos

            'Dim crtableLogoninfo1 As New TableLogOnInfo
            'Dim crConnectionInfo1 As New ConnectionInfo
            'Dim CrTables1 As Tables
            'Dim CrTable1 As Table
            'With crConnectionInfo1
            '    .ServerName = xSERVER
            '    .DatabaseName = "Pos_System"
            '    .UserID = "sa"
            '    .Password = xPW
            'End With

            'CrTables1 = report7.Database.Tables
            'For Each CrTable1 In CrTables1
            '    crtableLogoninfo1 = CrTable1.LogOnInfo
            '    crtableLogoninfo1.ConnectionInfo = crConnectionInfo1
            '    CrTable1.ApplyLogOnInfo(crtableLogoninfo1)
            'Next

            'CrystalReportViewer1.ReportSource = report7
            'CrystalReportViewer1.Refresh()

        End If
      




    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class