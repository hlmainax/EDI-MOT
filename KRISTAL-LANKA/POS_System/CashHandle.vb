Imports System.Data.SqlClient
Imports ConnData
Public Class CashHandle
    'CashSales, CreditSales, CashReceipts, SalesReturn, Payments, LastUpdate, UName
    Public Function xSettle(ByVal oCSH As Double, ByVal oCRDT As Double, ByVal oRCPT As Double, ByVal oSLRTN As Double, ByVal oPYM As Double, ByVal oEZY As Double, ByVal oWHS As Double, ByVal oLUP As String, ByVal oUN As String, ByVal oMOR As Double, ByVal oCARD As Double)
        Dim iim As Integer
        Dim xDT As Date = Now.ToShortDateString
        cmd2 = New SqlCommand("Select * from SalesMaster where(LastUpdate='" & Date.Now.ToShortDateString & "') ", con2)
        rdr2 = cmd2.ExecuteReader
        If rdr2.Read = True Then
            'If xDT = rdr("LastUpdate") Then
            Dim aCSHS As Double = rdr2("CashSales").ToString
            Dim aCRSL As Double = rdr2("CreditSales").ToString
            Dim aCRCP As Double = rdr2("CashReceipts").ToString
            Dim aSRTN As Double = rdr2("SalesReturn").ToString
            Dim aPYMN As Double = rdr2("Payments").ToString
            Dim aEZY As Double = rdr2("EzyCash").ToString
            Dim aWHS As Double = rdr2("WholeSale").ToString
            Dim aMOR As Double = rdr2("Mornin").ToString
            Dim aCRD As Double = rdr2("CardSLS").ToString
            '  '                                                         CashSales,                      CreditSales,                     CashReceipts,                                 SalesReturn,                     Payments,                     LastUpdate,                          UName
            cmd3 = New SqlCommand("Update SalesMaster set CashSales='" & aCSHS + oCSH & "',CreditSales='" & aCRSL + oCRDT & "',CashReceipts='" & aCRCP + oRCPT & "',SalesReturn='" & aSRTN + oSLRTN & "',Payments='" & aPYMN + oPYM & "',WholeSale='" & aWHS + oWHS & "',EzyCash='" & aEZY + oEZY & "',UName='" & oUN & "',Mornin='" & oMOR + aMOR & "',CardSLS='" & aCRD + oCARD & "'where LastUpdate='" & rdr2("LastUpdate") & "'", con3)
            cmd3.ExecuteNonQuery()

            'Else
            '    '                                                 CashSales,     CreditSales,   CashReceipts,    SalesReturn,    Payments,               LastUpdate, UName
            '    cmd1 = New SqlCommand("Insert SalesMaster values('" & oCSH & "','" & oCRDT & "','" & oRCPT & "','" & oSLRTN & "','" & oPYM & "','" & oBLAM + oCSH + oCRDT + oRCPT - (oSLRTN + oPYM) & "','" & oLUP & "','" & oUN & "')", con1)
            '    cmd1.ExecuteNonQuery()

            'End If
        Else
            ' CashSales, CreditSales, CashReceipts, SalesReturn, Payments, EzyCash, WholeSale, LastUpdate, UName
            cmd3 = New SqlCommand("Insert SalesMaster values('" & oCSH & "','" & oCRDT & "','" & oRCPT & "','" & oSLRTN & "','" & oPYM & "','" & oEZY & "','" & oWHS & "','" & oLUP & "','" & oUN & "','" & oMOR & "','" & oCARD & "')", con3)
            cmd3.ExecuteNonQuery()
        End If
        rdr2.Close()



        Return iim
    End Function


End Class
