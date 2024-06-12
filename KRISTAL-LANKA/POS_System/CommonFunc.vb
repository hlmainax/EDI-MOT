Imports System.Data.SqlClient
Imports ConnData
Public Class CommonFunc
    Public Sub SaveItem(ByVal itemCode As String, ByVal itemName As String, ByVal descr As String, ByVal roLvl As Double, ByVal sts As Integer)
        cmd = New SqlCommand("Update Itm set Sts='" & 1 & "'where ItemCode='" & itemCode & "'", con)
        cmd.ExecuteNonQuery()
        ' cmd = New SqlCommand("Insert Itm values('" & itemCode & "','" & itemName & "',N'" & descr & "','" & roLvl & "','" & sts & "')", con)
        cmd = New SqlCommand("Insert Itm values('" & itemCode & "','" & itemName & "','" & descr & "','" & roLvl & "','" & sts & "')", con)
        cmd.ExecuteNonQuery()
    End Sub
    'ItemCode, CPrice, SellPrice, Qty, LastUpdate, Tno, Sts, CusCode

    Public Sub SaveItemTrans(ByVal ItemCode As String, ByVal CPrice As Double, ByVal SellPrice As Double, ByVal Qty As Double, ByVal LastUpdate As Date, ByVal Tno As String, ByVal Sts As Integer, ByVal CusCode As String)
        cmd = New SqlCommand("Insert Itr values('" & ItemCode & "','" & CPrice & "','" & SellPrice & "','" & Qty & "','" & LastUpdate & "','" & Tno & "','" & Sts & "','" & CusCode & "')", con)
        cmd.ExecuteNonQuery()
    End Sub

    Public Sub SaveInv(ByVal INVNo As String, ByVal InvAmnt As Double, ByVal Paid As Double, ByVal Disc As Double, ByVal Dte As Date, ByVal UpTime As DateTime, ByVal CusCode As String, ByVal Itms As String, ByVal Sts As Integer)
        cmd = New SqlCommand("Insert Inv values('" & INVNo & "','" & InvAmnt & "','" & Paid & "','" & Disc & "','" & Dte & "','" & UpTime & "','" & CusCode & "','" & Itms & "','" & Sts & "')", con)
        cmd.ExecuteNonQuery()
    End Sub
    'InvAmnt, Paid, Disc, Dte, CusCode, Itms, Sts
    Public Sub SaveInvT(ByVal InvAmnt As Double, ByVal Paid As Double, ByVal Disc As Double, ByVal Dte As Date, ByVal CusCode As String, ByVal Itms As String, ByVal Sts As Integer)
        cmd = New SqlCommand("Insert InvT values('" & InvAmnt & "','" & Paid & "','" & Disc & "','" & Dte & "','" & CusCode & "','" & Itms & "','" & Sts & "')", con)
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub SaveCusLed(ByVal CCode As String, ByVal Cr As Double, ByVal Dr As Double, ByVal Dte As Date, ByVal Tno As String, ByVal Sts As Integer)
        cmd = New SqlCommand("Insert CLed values('" & CCode & "','" & Cr & "','" & Dr & "','" & Dte & "','" & Tno & "','" & Sts & "')", con)
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub SaveCustomer(ByVal CCode As String, ByVal CusName As String, ByVal Sts As Integer)
        cmd = New SqlCommand("Update Cst set Sts='" & 1 & "'where CCode='" & CCode & "'", con)
        cmd.ExecuteNonQuery()
        cmd = New SqlCommand("Insert Cst values('" & CCode & "','" & CusName & "','" & Sts & "')", con)
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub SaveSupplier(ByVal SupCode As String, ByVal SupName As String, ByVal Address As String, ByVal SupMobi As String, ByVal Sts As Integer)
        cmd = New SqlCommand("Update Supplier set Sts='" & 1 & "'where SupCode='" & SupCode & "'", con)
        cmd.ExecuteNonQuery()
        cmd = New SqlCommand("Insert Supplier values('" & SupCode & "','" & SupName & "','" & Address & "','" & SupMobi & "','" & Sts & "')", con)
        cmd.ExecuteNonQuery()
    End Sub

    Public Sub SaveSupLed(ByVal SCode As String, ByVal Cr As Double, ByVal Dr As Double, ByVal Dte As Date, ByVal Tno As String, ByVal Sts As Integer)
        cmd = New SqlCommand("Insert SLed values('" & SCode & "','" & Cr & "','" & Dr & "','" & Dte & "','" & Tno & "','" & Sts & "')", con)
        cmd.ExecuteNonQuery()
    End Sub
    'PNo, PAmnt, Disc, Dte,  SCode, Itms, Sts
    Public Sub SaveGrn(ByVal PNo As String, ByVal PAmnt As Double, ByVal Disc As Double, ByVal Dte As Date, ByVal SCode As String, ByVal Itms As String, ByVal Sts As Integer, ByVal Ino As String)
        cmd = New SqlCommand("Insert Purch values('" & PNo & "','" & PAmnt & "','" & Disc & "','" & Dte & "','" & SCode & "','" & Itms & "','" & Sts & "','" & Ino & "')", con)
        cmd.ExecuteNonQuery()
    End Sub

End Class
