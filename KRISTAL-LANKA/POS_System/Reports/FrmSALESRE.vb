Imports System.Data.SqlClient
Imports ConnData
Public Class FrmSALESRE

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub FrmSALESRE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.ChartAreas(0).AxisY.Interval = 5000
        cmd = New SqlCommand("Select CashSales,LastUpdate from SalesMaster ", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Chart1.Series("Series1").Points.AddXY(rdr("LastUpdate").ToString, rdr("CashSales").ToString)
        End While
        rdr.Close()

    End Sub
End Class