Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports ConnData
Public Class FrmItem

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

    Private Sub FrmItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        CrystalReportViewer1.Hide()
        Me.WindowState = FormWindowState.Maximized
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
        Panel5.Hide()
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
        ''FrmItem.Close()
        'frmPchange.Close()
        'FrmRCPT.Close()
        'FrmREPORT.Close()
        'FrmRPT.Close()
        'FrmRPT1.Close()
        'FrmRpts.Close()
        'FrmRtn.Close()
        'FrmSALESRE.Close()
        'FrmSTCKENTER.Close()
        'FrmSupPament.Close()
        'FrmSupplier.Close()
        'FrmSupplierRTN.Close()
        'FrmUOP.Close()
        'FrmUserControl.Close()
        ItemList()
        ' AboutBox1.Close()
    End Sub

    Private Sub FrmItem_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
        Me.Panel5.Location = New System.Drawing.Point(((Me.Width - Panel5.Width) / 2), ((Me.Height - Panel5.Height - 100) / 2))
    End Sub

    Private Sub ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemCode.KeyDown

        If e.KeyCode = 13 Then
            xITEMCD(ItemCode.Text)
            ItemCode.Focus()


        ElseIf e.KeyCode = 113 Then
            Panel2.Show()
            Panel1.Hide()
            txtItemCode_TextChanged(sender, EventArgs.Empty)
            txtItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            CmdCancel_Click(sender, EventArgs.Empty)
        End If

    End Sub

    Private Sub txtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = 27 Then
            txtItemCode.Clear()
            txtItemCode.Clear()
            GRID1.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtItemName.Focus()
        End If
    End Sub


    Private Sub txtItemCode_TextChanged(sender As Object, e As EventArgs) Handles txtItemCode.TextChanged
        If txtItemCode.Text = "" Then
            cmd = New SqlCommand("Select * from ItemMaster order by ItemCode", con)
        Else
            cmd = New SqlCommand("Select * from ItemMaster where ItemCode like '" & txtItemCode.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()

    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown
        If e.KeyCode = 27 Then
            txtItemCode.Clear()
            txtItemCode.Clear()
            GRID1.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtItemCode.Focus()
        End If
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged

        If txtItemName.Text = "" Then
            cmd = New SqlCommand("Select * from ItemMaster order by ItemCode", con)
        Else
            cmd = New SqlCommand("Select * from ItemMaster where ItemName like '" & txtItemName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()

    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If ItemCode.Text = "" Or ItemName.Text = "" Then Return

        Dim Pbf = New CommonFunc



        'Dim xINAME As String = ItemName.Text
        'convertQuotes(xINAME)
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Add New Items Details ?", "Add Items Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result1 = vbYes Then
            Pbf.SaveItem(ItemCode.Text, ItemName.Text, Descrip.Text, Val(WsalePr.Text), 0)
            If Val(OpeningBal.Text) > 0 Then
                Pbf.SaveItemTrans(ItemCode.Text, Val(CostPrice.Text), Val(SellPrice.Text), Val(OpeningBal.Text), Now.Date, "OP", 0, "NA")
            End If
            MessageBox.Show("Item Add Succeed.", "Add Items Details", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If




        CmdCancel_Click(sender, EventArgs.Empty)
    End Sub
    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "'")

    End Function
    Private Sub CHK1_CheckedChanged(sender As Object, e As EventArgs) Handles CHK1.CheckedChanged
        If CHK1.Checked = True Then
            CHK1.CheckState = 1
        Else
            CHK1.CheckState = 0

        End If
    End Sub

    Private Sub CatCode2_KeyDown(sender As Object, e As KeyEventArgs) Handles CatCode2.KeyDown
        If e.KeyCode = 113 Then
            Panel3.Show()
            Panel2.Hide()
            Panel1.Hide()
            txtCat2Code_TextChanged(sender, EventArgs.Empty)
            txtCat2Code.Focus()
        ElseIf e.KeyCode = 13 Then
            xCatCode(CatCode2.Text)
            CatCode2.Focus()
        ElseIf e.KeyCode = 27 Then
            CatCode1.Clear()
            CatName1.Clear()
            CatCode2.Clear()
            CatName2.Clear()
            CatCode2.Focus()
        End If
    End Sub


    Private Sub txtCat2Code_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCat2Code.KeyDown
        If e.KeyCode = 27 Then
            txtCat2Code.Clear()
            txtCat2Name.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtCat2Name.Focus()
        End If
    End Sub

    Private Sub txtCat2Code_TextChanged(sender As Object, e As EventArgs) Handles txtCat2Code.TextChanged
        If txtCat2Code.Text = "" Then
            cmd = New SqlCommand("Select * from CatLevel2 order by CatCode2", con)
        Else
            cmd = New SqlCommand("Select * from CatLevel2 where CatCode2 like '" & txtCat2Code.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("CatCode2"), rdr("CatName2"))
        End While
        rdr.Close()
    End Sub

    Private Sub txtCat2Name_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCat2Name.KeyDown
        If e.KeyCode = 27 Then
            txtCat2Code.Clear()
            txtCat2Name.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtCat2Code.Focus()
        End If
    End Sub

    Private Sub txtCat2Name_TextChanged(sender As Object, e As EventArgs) Handles txtCat2Name.TextChanged
        If txtCat2Name.Text = "" Then
            cmd = New SqlCommand("Select * from CatLevel2 order by CatCode2", con)
        Else
            cmd = New SqlCommand("Select * from CatLevel2 where CatName2 like '%" & txtCat2Name.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("CatCode2"), rdr("CatName2"))
        End While
        rdr.Close()
    End Sub
    Private Sub xCatCode(ByRef xCat As String)
        cmd = New SqlCommand("Select * from CatLevel2 where(CatCode2='" & xCat & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            CatCode1.Text = rdr("CatCode1").ToString
            CatName1.Text = rdr("CatName1").ToString
            CatCode2.Text = rdr("CatCode2").ToString
            CatName2.Text = rdr("CatName2").ToString
            CatCode2.Focus()
        End If
        rdr.Close()
    End Sub
    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        xCatCode(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
        Panel1.Show()
        CatCode2.Focus()
    End Sub

    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.Rows.Count = 0 Then Return
            xCatCode(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            CatCode2.Focus()
        ElseIf e.KeyCode = 27 Then
            txtCat2Code.Focus()
        End If
    End Sub

    Private Sub txtSupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupCode.KeyDown
        If e.KeyCode = 27 Then
            txtSupCode.Clear()
            txtSupName.Clear()
            GRID3.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            SupCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID3.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtSupName.Focus()
        End If
    End Sub

    Private Sub txtSupCode_TextChanged(sender As Object, e As EventArgs) Handles txtSupCode.TextChanged
        If txtSupCode.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier where Active='" & 1 & "' order by SupName ", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupCode like '" & txtSupCode.Text & "%'and Active='" & 1 & "'", con)
        End If
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Private Sub SupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles SupCode.KeyDown

        If e.KeyCode = 13 Then
            xSUPID(SupCode.Text)
            SupCode.Focus()
            ' Panel1.Hide()


        ElseIf e.KeyCode = 113 Then

            Panel4.Show()
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Hide()
            txtSupCode_TextChanged(sender, EventArgs.Empty)
            txtSupCode.Focus()
        ElseIf e.KeyCode = 27 Then
            SupName.Clear()
            SupCode.Clear()
            SupCode.Focus()

        End If
    End Sub


    Private Sub txtSupName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupName.KeyDown
        If e.KeyCode = 27 Then
            txtSupCode.Clear()
            txtSupName.Clear()
            GRID3.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            SupCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID3.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtSupName.Focus()
        End If
    End Sub

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier where Active='" & 1 & "' order by SupName", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupName like '%" & txtSupName.Text & "%'and Active ='" & 1 & "'", con)
        End If
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub
    Private Sub xSUPID(ByVal xSID As String)
        cmd = New SqlCommand("Select * from Supplier where(SupCode='" & xSID & "') ", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            If rdr("Active") = 1 Then
                SupCode.Text = rdr("SupCode").ToString
                SupName.Text = rdr("SupName").ToString
            Else
                MsgBox("Suplier Not Active Yet")
            End If

        End If
        rdr.Close()
    End Sub



    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.Hide()
        ItemCode.Clear()
        ItemName.Clear()
        CatCode1.Clear()
        CatName1.Clear()
        CatCode2.Clear()
        CatName2.Clear()
        Descrip.Clear()
        SupCode.Clear()
        SupName.Clear()
        UOM.Clear()
        CostPrice.Clear()
        SellPrice.Clear()
        WsalePr.Clear()
        CHK1.Checked = False
        OpeningBal.Clear()
        ListBox1.Items.Clear()
        txtQty.Clear()
        ItemList()
        ItemCode.Focus()

        '*************************************************(Verry Important)
        'Dim TestString As String = "Mid Function Demo"
        '' Returns "Mid". 
        'Dim FirstWord As String = Mid(TestString, 14, 4)
        'txtQty.Text = FirstWord
        '**************************************************

    End Sub


    Private Sub GRID3_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID3.CellContentDoubleClick
        xSUPID(GRID3.Item(0, GRID3.CurrentRow.Index).Value)
        SupCode.Focus()
        Panel1.Show()
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
    End Sub

    Private Sub GRID3_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID3.KeyDown
        If e.KeyCode = 13 Then
            If GRID3.Rows.Count = 0 Then Return
            xSUPID(GRID3.Item(0, GRID3.CurrentRow.Index).Value)
            SupCode.Focus()
            Panel1.Show()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
        ElseIf e.KeyCode = 27 Then
            txtSupCode.Focus()
        End If
    End Sub

    Private Sub xITEMCD(ByVal xITCOD As String)
        Dim spr As String
        cmd3 = New SqlCommand("Select ISNULL(SellPrice,0) from Itr where ItemCode='" & xITCOD & "'and Sts=0", con3)
        spr = cmd3.ExecuteScalar
        cmd3 = New SqlCommand("Select * from Itm where(ItemCode='" & xITCOD & "'and Sts='" & 0 & "')", con3)
        rdr3 = cmd3.ExecuteReader
        If rdr3.Read = True Then
            ' ItemCode, ItemName, Cat1, Cat1Name, Cat2, Cat2Name, Description, SupCode, SupName, Uom, CostPrice, SellPrice, Inact
            ItemCode.Text = rdr3("ItemCode").ToString
            ItemName.Text = rdr3("ItemName").ToString
            Descrip.Text = rdr3("Description").ToString
            WsalePr.Text = rdr3("ROLevel").ToString
            SellPrice.Text = spr
        Else
            ' ItemCode.Clear()
            ItemName.Clear()
            CatCode1.Clear()
            CatName1.Clear()
            CatCode2.Clear()
            CatName2.Clear()
            Descrip.Clear()
            SupCode.Clear()
            SupName.Clear()
            UOM.Clear()
            SellPrice.Clear()
            CostPrice.Clear()
            WsalePr.Clear()
            OpeningBal.Clear()
            CHK1.Checked = False
            ItemCode.Focus()
        End If
        rdr3.Close()
        Dim inStock = 0
        cmd3 = New SqlCommand("Select ISNULL(SUM(Qty),0) from Itr where ItemCode='" & ItemCode.Text & "'and Sts=0", con3)
        inStock = cmd3.ExecuteScalar
        txtQty.Text = inStock.ToString

    End Sub

    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        xITEMCD(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
        Panel1.Show()
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
    End Sub

    Private Sub GRID1_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID1.KeyDown
        If e.KeyCode = 13 Then
            If GRID1.Rows.Count = 0 Then Return
            xITEMCD(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
            Panel1.Show()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
        ElseIf e.KeyCode = 27 Then

            txtItemCode.Focus()
        End If
    End Sub

    Private Sub CostPrice_TextChanged(sender As Object, e As EventArgs) Handles CostPrice.TextChanged
        If IsNumeric(CostPrice.Text) = False Then CostPrice.Clear()
        'If Val(CostPrice.Text) > Val(SellPrice.Text) Then CostPrice.Clear()
    End Sub

    Private Sub SellPrice_TextChanged(sender As Object, e As EventArgs) Handles SellPrice.TextChanged
        If IsNumeric(SellPrice.Text) = False Then SellPrice.Clear()
        'If Val(SellPrice.Text) < Val(CostPrice.Text) Then SellPrice.Clear()
    End Sub

    Private Sub WsalePr_TextChanged(sender As Object, e As EventArgs) Handles WsalePr.TextChanged
        If IsNumeric(WsalePr.Text) = False Then WsalePr.Clear()
        'If Val(SellPrice.Text) < Val(WsalePr.Text) Then WsalePr.Text = SellPrice.Text
        'If Val(CostPrice.Text) > Val(WsalePr.Text) Then WsalePr.Text = CostPrice.Text


    End Sub

    Private Sub ItemName_TextChanged(sender As Object, e As EventArgs) Handles ItemName.TextChanged
        cmd4 = New SqlCommand("Select ItemCode,ItemName from Itm where Sts='" & 0 & "'and ItemName like '%" & ItemName.Text & "%'", con4)
        rdr4 = cmd4.ExecuteReader
        ListBox1.Items.Clear()
        While rdr4.Read
            ListBox1.Items.Add(rdr4("ItemCode") & " - " & rdr4("ItemName"))
        End While
        rdr4.Close()
    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click
        'If ItemCode.Text = "" Then Return
        'Dim result1 As DialogResult = MessageBox.Show("Do you want to delete this item ?", "Delete an Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        'If result1 = vbYes Then
        '    cmd = New SqlCommand("Delete from ItemMaster where(ItemCode='" & ItemCode.Text & "')", con)
        '    cmd.ExecuteNonQuery()
        '    cmd = New SqlCommand("Delete from Stock_Main where(ItemCode='" & ItemCode.Text & "')", con)
        '    cmd.ExecuteNonQuery()


        '    CmdCancel_Click(sender, EventArgs.Empty)
        'End If
        Panel1.Hide()
        Panel5.Show()
        Panel5.BringToFront()
    End Sub

    Private Sub ItemCode_TextChanged(sender As Object, e As EventArgs) Handles ItemCode.TextChanged
        cmd = New SqlCommand("Select ItemCode,ItemName from Itm where Sts='" & 0 & "'and ItemCode like '%" & ItemCode.Text & "%'", con)
        rdr = cmd.ExecuteReader
        ListBox1.Items.Clear()
        While rdr.Read
            ListBox1.Items.Add(rdr("ItemCode") & " - " & rdr("ItemName"))
        End While
        rdr.Close()
    End Sub


    Private Sub ItemList()
        cmd = New SqlCommand("Select ItemCode,ItemName from Itm where Sts='" & 0 & "'", con)
        rdr = cmd.ExecuteReader
        ListBox1.Items.Clear()
        While rdr.Read
            ListBox1.Items.Add(rdr("ItemCode") & " - " & rdr("ItemName"))
        End While
        rdr.Close()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If ItemCode.Text = "" Then Return
        If rbt2.Checked = True Then
            CrystalReportViewer1.Show()
            Dim report6 As New RptCode
            report6.SetParameterValue("cde", ItemCode.Text) 'd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
            '  report6.SetParameterValue("prc", Format(Val(SellPrice.Text), "0.00"))
            report6.SetParameterValue("prc", Format(Val(SellPrice.Text), "0.00"))
            report6.SetParameterValue("inm", SupCode.Text & "-" & ItemName.Text)
            CrystalReportViewer1.ReportSource = report6
            CrystalReportViewer1.Refresh()
            report6.Close()
            report6.Dispose()
        ElseIf rbt1.Checked = True Then
            CrystalReportViewer1.Show()
            Dim report6 As New RptCode1
            report6.SetParameterValue("icd", ItemCode.Text) 'd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
            '  report6.SetParameterValue("prc", Format(Val(SellPrice.Text), "0.00"))
            report6.SetParameterValue("prc", Format(Val(SellPrice.Text), "0.00"))
            report6.SetParameterValue("inm", SupCode.Text & "-" & ItemName.Text)
            CrystalReportViewer1.ReportSource = report6
            CrystalReportViewer1.Refresh()
            report6.Close()
            report6.Dispose()
        End If




    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        gridExcel.DataSource = Nothing
        'gridExcel.Rows.Clear()
        Panel5.Hide()
        Panel1.Show()
        Panel1.BringToFront()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
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
                gridExcel.DataSource = dts
                gridExcel.DataMember = "[Sheet1$]"
                conn.Close()

                gridExcel.Columns.Item(0).Width = 99
                gridExcel.Columns.Item(1).Width = 380
                gridExcel.Columns.Item(2).Width = 99
                gridExcel.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridExcel.Columns.Item(3).Width = 99
                gridExcel.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridExcel.Columns.Item(4).Width = 99
                gridExcel.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                gridExcel.Columns.Item(5).Width = 99
                gridExcel.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'addnewnewandrefresh()
                'DELETEROW()
            End If
        Catch ex As Exception
            ' ex.Message("")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        gridExcel.DataSource = Nothing
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Add New Items Details ?", "Add Items Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If result1 = vbYes Then
            Dim comf As New CommonFunc
            For Each row As DataGridViewRow In gridExcel.Rows
                Dim itemCode As String = row.Cells(0).Value.ToString
                Dim itemName As String = row.Cells(1).Value.ToString
                Dim partNo As String = row.Cells(2).Value.ToString
                Dim cost As Double = Val(row.Cells(3).Value)
                Dim sell As Double = Val(row.Cells(4).Value)
                Dim qty As Double = Val(row.Cells(5).Value)
                If itemCode = "" Or itemName = "" Then
                Else
                    comf.SaveItem(itemCode, itemName, partNo, 0, 0)
                    comf.SaveItemTrans(itemCode, cost, sell, qty, Now.Date, "OP", 0, "OP")
                End If
            Next
            MessageBox.Show("Item Add Succeed.", "Add Items Details", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            gridExcel.DataSource = Nothing
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Dim itemcode As String = ListBox1.SelectedItem.ToString.Split("-")(0).Trim
        xITEMCD(itemcode)

    End Sub

    Private Sub Descrip_TextChanged(sender As Object, e As EventArgs) Handles Descrip.TextChanged
        cmd5 = New SqlCommand("Select ItemCode,ItemName from Itm where Sts='" & 0 & "'and Description like '%" & Descrip.Text & "%'", con5)
        rdr5 = cmd5.ExecuteReader
        ListBox1.Items.Clear()
        While rdr5.Read
            ListBox1.Items.Add(rdr5("ItemCode") & " - " & rdr5("ItemName"))
        End While
        rdr5.Close()
    End Sub
End Class