Imports System.Data.SqlClient
Imports ConnData
Public Class FrmCat1

    Private Sub FrmCat1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height

        Me.WindowState = FormWindowState.Maximized
        Panel2.Hide()

        ' AboutBox1.Close()
        'Me.SomeListBox.Items.Add(f)
        'Next
    End Sub

    Private Sub FrmCat1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
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

    Private Sub CatCode_KeyDown(sender As Object, e As KeyEventArgs) Handles CatCode.KeyDown
        If e.KeyCode = 13 Then
            If CatCode.Text = "" Then Return
            xCATCODE(CatCode.Text)
        ElseIf e.KeyCode = 113 Then
            Panel1.Hide()
            Panel2.Show()
            txtCatCode.Focus()
            txtCatCode_TextChanged(sender, EventArgs.Empty)
        ElseIf e.KeyCode = 27 Then
            CmdCancel_Click(sender, EventArgs.Empty)
        End If
    End Sub

    Private Sub txtCatCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCatCode.KeyDown
      
        If e.KeyCode = 27 Then
            txtCatCode.Clear()
            txtCatName.Clear()
            GRID1.Rows.Clear()
            Panel2.Hide()
            Panel1.Show()
            CatCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtCatName.Focus()
        End If
    End Sub

   

    Private Sub txtCatCode_TextChanged(sender As Object, e As EventArgs) Handles txtCatCode.TextChanged
        If txtCatCode.Text = "" Then
            cmd = New SqlCommand("Select * from CatLevel1 order by CatCode ", con)
        Else
            cmd = New SqlCommand("Select * from CatLevel1 where CatCode like '" & txtCatCode.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CatCode"), rdr("CatName"))
        End While
        rdr.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        CatCode.Clear()
        CatName.Clear()
        CatCode.Focus()
    End Sub

    Private Sub txtCatName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCatName.KeyDown

        If e.KeyCode = 27 Then
            txtCatCode.Clear()
            txtCatName.Clear()
            GRID1.Rows.Clear()
            Panel2.Hide()
            Panel1.Show()
            CatCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtCatCode.Focus()
        End If

    End Sub

    Private Sub txtCatName_TextChanged(sender As Object, e As EventArgs) Handles txtCatName.TextChanged
        If txtCatName.Text = "" Then
            cmd = New SqlCommand("Select * from CatLevel1 order by CatCode", con)
        Else
            cmd = New SqlCommand("Select * from CatLevel1 where CatName like '%" & txtCatName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CatCode"), rdr("CatName"))
        End While
        rdr.Close()
    End Sub


    Private Sub xCATCODE(ByVal xCAT As String)
        cmd = New SqlCommand("Select * from CatLevel1 where(CatCode='" & xCAT & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            CatCode.Text = rdr("CatCode").ToString
            CatName.Text = rdr("CatName").ToString
            CatCode.Focus()
        End If
        rdr.Close()
    End Sub
    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        xCATCODE(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel1.Show()
    End Sub

    Private Sub GRID1_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID1.KeyDown
        If e.KeyCode = 13 Then
            If GRID1.RowCount = 0 Then Return
            xCATCODE(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel1.Show()
        ElseIf e.KeyCode = 27 Then
            txtCatCode.Focus()
         
        End If
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If CatCode.Text = "" Or CatName.Text = "" Then Return

        cmd = New SqlCommand("Select * from CatLevel1 where(CatCode='" & CatCode.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            Dim result1 As DialogResult = MessageBox.Show("Do you want to Update the current Category Level1 Details ?", "Update the current Category Level1 Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                '                    CatCode,                    CatName                                         LastUpdate                                                  Uname
                cmd1 = New SqlCommand("Update CatLevel1 set CatName='" & CatName.Text & "',LastUpdate='" & Format(Now, "yyy-MM-dd H:mm:ss") & "',Uname='" & FrmMDI.UName.Text & "'where CatCode='" & CatCode.Text & "'", con1)
                cmd1.ExecuteNonQuery()
                MessageBox.Show("Category Level1 Update Succeed.", "Category Updating", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Else
            Dim result1 As DialogResult = MessageBox.Show("Do you want to Add New Category Level1 ?", "Add New Category Level1", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                '                                                   CatCode,                    CatName                         LastUpdate                          Uname
                cmd1 = New SqlCommand("Insert CatLevel1 values('" & CatCode.Text & "','" & CatName.Text & "','" & Format(Now, "yyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con1)
                cmd1.ExecuteNonQuery()
                MessageBox.Show("Category Level1 Add Succeed.", "Category Updating", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
        rdr.Close()
        CmdCancel_Click(sender, EventArgs.Empty)
    End Sub

    Private Sub CatCode_TextChanged(sender As Object, e As EventArgs) Handles CatCode.TextChanged

    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub
End Class