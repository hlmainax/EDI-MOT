Imports System.Data.SqlClient
Imports ConnData
Public Class FrmSupplier
   
    Private Sub FrmSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height

        Me.WindowState = FormWindowState.Maximized
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Gridstdload()

        'AboutBox1.Close()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        Dim cFn As New CommonFunc
        If SupCode.Text = "" Or SupName.Text = "" Or SupAdd.Text = "" Or SupMobi.Text = "" Or txtSupBal.Text = "" Then
            MsgBox("Please fill the all feilds")
            Return
        Else
            Dim result1 As DialogResult = MessageBox.Show("Do you want to Add New Supplier Details ?", "Add New Supplier Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                cFn.SaveSupplier(SupCode.Text, SupName.Text, SupAdd.Text, SupMobi.Text, 0)
                cFn.SaveSupLed(SupCode.Text, Val(txtSupBal.Text), 0, Now.Date, "OP", 0)
                MessageBox.Show("Supplier Details Update Succeed.", "Supplier Details Updating", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
            Gridstdload()
            CmdCancel_Click(sender, EventArgs.Empty)
        End If
    End Sub
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        SupCode.Clear()
        SupName.Clear()
        SupAdd.Clear()
        SupMobi.Clear()
        txtSupBal.Clear()
        SupCode.Focus()
        SupCode.ReadOnly = False
    End Sub

    Private Sub Gridstdload()
        ' cmd = New SqlCommand("Select * from ItemMaster ORDER BY cast(ItemCode as Int)ASC", con)
        cmd = New SqlCommand("select SupCode,SupName from Supplier where Sts=0", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
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
    Private Sub FrmSupplier_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
    End Sub


    Private Sub SupCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SupCode.KeyDown
        If e.KeyCode = 13 Then
            If SupCode.Text = "" Then Return
            xSupCode(SupCode.Text)
        ElseIf e.KeyCode = 27 Then
            CmdCancel_Click(sender, EventArgs.Empty)
        End If
    End Sub

    Private Sub GRID1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellDoubleClick
        'cmd = New SqlCommand("select * from Supplier where(SupCode='" & GRID1.Item(0, GRID1.CurrentRow.Index).Value & "')", con)
        xSupCode(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
        SupCode.Focus()

    End Sub
    Private Sub xSupCode(ByVal xSup As String)
        cmd = New SqlCommand("select * from Supplier where(SupCode='" & xSup & "'and Sts=0)", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            SupCode.Text = rdr("SupCode").ToString
            SupName.Text = rdr("SupName").ToString
            SupAdd.Text = rdr("Address").ToString
            SupMobi.Text = rdr("SupMobi").ToString
            'SupCode.ReadOnly = True
            'SupBalance.Enabled = False
        End If
        rdr.Close()
    End Sub

    Private Sub SupMobi_TextChanged(sender As Object, e As EventArgs) Handles SupMobi.TextChanged
        If IsNumeric(SupMobi.Text) = False Then SupMobi.Clear()
    End Sub

    Private Sub SupOff_TextChanged(sender As Object, e As EventArgs) Handles txtSupBal.TextChanged
        If IsNumeric(txtSupBal.Text) = False Then txtSupBal.Clear()
    End Sub

    Private Sub txtSupID_TextChanged(sender As Object, e As EventArgs) Handles txtSupID.TextChanged
        If txtSupID.Text = "" Then
            cmd = New SqlCommand("select SupCode,SupName from Supplier Sts=0", con)
        Else
            cmd = New SqlCommand("Select SupCode,SupName from Supplier where SupCode like '" & txtSupID.Text & "%'and Sts=0 ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
        'SELECT Name FROM Person WHERE Name LIKE '%Jon%'
    End Sub

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("select SupCode,SupName from SupplierSts=0", con)
        Else
            cmd = New SqlCommand("Select SupCode,SupName from Supplier where SupName like '%" & txtSupName.Text & "%'and Sts=0", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Dim sACT As Integer = 1


    Private Sub SupCode_TextChanged(sender As Object, e As EventArgs) Handles SupCode.TextChanged

    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub
End Class