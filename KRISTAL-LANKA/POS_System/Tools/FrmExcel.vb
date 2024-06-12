Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports ConnData
Public Class FrmExcel
    Private Sub FrmExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
        Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = xW
        Me.Height = xH
        Me.WindowState = FormWindowState.Maximized

        ' AboutBox1.Close()
    End Sub
    Private Sub FrmExcel_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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
    Private Sub CmdImport_Click(sender As Object, e As EventArgs) Handles CmdImport.Click
        Try
            Dim conn As OleDbConnection
            Dim dta As OleDbDataAdapter
            Dim dts As DataSet
            Dim excel As String
            Dim openfile As New OpenFileDialog
            'openfile.InitialDirectory = "C:"
            openfile.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            openfile.Filter = "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls"
            If (openfile.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                Dim fi As New IO.FileInfo(openfile.FileName)
                Dim FileName As String = openfile.FileName
                excel = fi.FullName
                conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
                dta = New OleDbDataAdapter("Select * From [Sheet1$]", conn)
                dts = New DataSet
                dta.Fill(dts, "[Sheet1$]")
                GRID1.DataSource = dts
                GRID1.DataMember = "[Sheet1$]"
                conn.Close()

                GRID1.Columns.Item(0).Width = 150
                GRID1.Columns.Item(1).Width = 350
                GRID1.Columns.Item(2).Width = 90
                GRID1.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRID1.Columns.Item(3).Width = 85
                GRID1.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRID1.Columns.Item(4).Width = 90
                GRID1.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRID1.Columns.Item(5).Width = 70
                GRID1.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'addnewnewandrefresh()
                'DELETEROW()
            End If
        Catch ex As Exception
            ' ex.Message("")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If GRID1.Rows.Count = 0 Then Return
        Dim result11 As DialogResult = MessageBox.Show("Are you sure to Save ?", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result11 = vbYes Then
            For i As Integer = 0 To GRID1.Rows.Count - 1
                If GRID1(2, i).Value.ToString = "" Then GRID1(2, i).Value = 0
                If GRID1(3, i).Value.ToString = "" Then GRID1(3, i).Value = 0
                If GRID1(4, i).Value.ToString = "" Then GRID1(4, i).Value = 0
                If GRID1(5, i).Value.ToString = "" Then GRID1(5, i).Value = 0
                If GRID1(0, i).Value.ToString = "" Then
                Else
                    'AutoID, ItemCode, ItemName, UOM, CostPrice, SellPrice, RcvQty, SaleQty, DmgQty, RtnQty, BalanceQty, PisicalQty, LastUpdate, UName, WsPrice, IType
                    cmd = New SqlCommand("Select * from Stock_Main where(ItemCode='" & GRID1(0, i).Value & "')", con)
                    rdr = cmd.ExecuteReader
                    If rdr.Read = True Then
                    Else
                        '                   AutoID,                             ItemCode,                   ItemName,                 UOM,        CostPrice,                            SellPrice,                              RcvQty,             SaleQty,        DmgQty,     RtnQty,        BalanceQty,                     PisicalQty,                              LastUpdate,                                 UName
                        cmd1 = New SqlCommand("Insert Stock_Main values('" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(6, i).Value & "','" & Val(GRID1(2, i).Value) & "','" & Val(GRID1(4, i).Value) & "','" & Val(GRID1(5, i).Value) & "','" & 0 & "','" & 0 & "','" & 0 & "','" & Val(GRID1(5, i).Value) & "','" & Val(GRID1(5, i).Value) & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & GRID1(3, i).Value & "','" & "NON" & "')", con1)
                        cmd1.ExecuteNonQuery()
                        '                                                          ItemCode,                 ItemName,                                Cat1,        Cat1Name,     Cat2,         Cat2Name,      Description,   SupCode,    SupName,              Uom,                CostPrice,                SellPrice,                  Inact                           LastUpdate                              UName                   UName
                        cmd1 = New SqlCommand("Insert ItemMaster values('" & GRID1(0, i).Value & "','" & GRID1(1, i).Value.Replace("'", "") & "','" & "-" & "','" & "-" & "','" & "-" & "','" & "-" & "','" & "-" & "','" & "-" & "','" & "-" & "','" & GRID1(6, i).Value & "','" & Val(GRID1(2, i).Value) & "','" & Val(GRID1(4, i).Value) & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "10" & "','" & Val(GRID1(3, i).Value) & "')", con1)
                        cmd1.ExecuteNonQuery()
                    End If
                    rdr.Close()
                End If
            Next
            MessageBox.Show("Data Added Success..!", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            GRID1.DataSource = Nothing
        End If
    End Sub
End Class