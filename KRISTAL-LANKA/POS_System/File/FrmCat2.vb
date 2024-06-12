Imports System.Data.SqlClient
Imports ConnData
Public Class FrmCat2

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

    Private Sub FrmCat2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height

        Me.WindowState = FormWindowState.Maximized
        Panel2.Hide()
        Panel3.Hide()

        ' AboutBox1.Close()
    End Sub

    Private Sub FrmCat2_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
    End Sub
    Private Sub xCATCODE(ByVal xCAT As String)
        cmd = New SqlCommand("Select * from CatLevel1 where(CatCode='" & xCAT & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            Cat1Code.Text = rdr("CatCode").ToString
            Cat1Name.Text = rdr("CatName").ToString
            Cat1Code.Focus()
        End If
        rdr.Close()
    End Sub

    Private Sub Cat1Code_KeyDown(sender As Object, e As KeyEventArgs) Handles Cat1Code.KeyDown
        If e.KeyCode = 13 Then
            If Cat1Code.Text = "" Then Return
            xCATCODE(Cat1Code.Text)
        ElseIf e.KeyCode = 113 Then
            Panel1.Hide()
            Panel3.Hide()
            Panel2.Show()
            txtCat1Code.Focus()
            txtCat1Code_TextChanged(sender, EventArgs.Empty)
        ElseIf e.KeyCode = 27 Then
            CmdCancel_Click(sender, EventArgs.Empty)
        End If
    End Sub

    Private Sub txtCat1Code_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCat1Code.KeyDown
        If e.KeyCode = 27 Then
            txtCat1Code.Clear()
            txtCat1Name.Clear()
            GRID1.Rows.Clear()
            Panel2.Hide()
            Panel1.Show()
            Cat1Code.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtCat1Name.Focus()
        End If
    End Sub

    Private Sub txtCat1Code_TextChanged(sender As Object, e As EventArgs) Handles txtCat1Code.TextChanged
        If txtCat1Code.Text = "" Then
            cmd = New SqlCommand("Select * from CatLevel1 order by CatCode", con)
        Else
            cmd = New SqlCommand("Select * from CatLevel1 where CatCode like '" & txtCat1Code.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CatCode"), rdr("CatName"))
        End While
        rdr.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Cat1Code.Clear()
        Cat1Name.Clear()
        Cat2Code.Clear()
        Cat2Name.Clear()
        Cat1Code.Focus()
    End Sub

    Private Sub txtCat1Name_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCat1Name.KeyDown
        If e.KeyCode = 27 Then
            txtCat1Code.Clear()
            txtCat1Name.Clear()
            GRID1.Rows.Clear()
            Panel2.Hide()
            Panel1.Show()
            Cat1Code.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtCat1Code.Focus()
        End If
    End Sub

    Private Sub txtCat1Name_TextChanged(sender As Object, e As EventArgs) Handles txtCat1Name.TextChanged
        If txtCat1Name.Text = "" Then
            cmd = New SqlCommand("Select * from CatLevel1 order by CatCode", con)
        Else
            cmd = New SqlCommand("Select * from CatLevel1 where CatName like '%" & txtCat1Name.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CatCode"), rdr("CatName"))
        End While
        rdr.Close()
    End Sub


    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        xCATCODE(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel3.Hide()
        Panel1.Show()
    End Sub

    Private Sub GRID1_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID1.KeyDown
        If e.KeyCode = 13 Then
            If GRID1.RowCount = 0 Then Return
            xCATCODE(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
        ElseIf e.KeyCode = 27 Then
            txtCat1Code.Focus()
           
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
            Cat2Code.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtCat2Name.Focus()
        End If
    End Sub

    Private Sub txtCat2Code_TextChanged(sender As Object, e As EventArgs) Handles txtCat2Code.TextChanged
        If txtCat2Code.Text = "" Then
            cmd = New SqlCommand("Select * from CatLevel2 where(CatCode1='" & Cat1Code.Text & "')order by CatCode1", con)
        Else
            cmd = New SqlCommand("Select * from CatLevel2 where CatCode1='" & Cat1Code.Text & "'and CatCode2 like '" & txtCat2Code.Text & "%' ", con)
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
            Panel1.Show()
            Cat2Code.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtCat2Code.Focus()
        End If
    End Sub

    Private Sub txtCat2Name_TextChanged(sender As Object, e As EventArgs) Handles txtCat2Name.TextChanged
        If txtCat2Name.Text = "" Then
            cmd = New SqlCommand("Select * from CatLevel2 where(CatCode1='" & Cat1Code.Text & "')order by CatCode1", con)
        Else
            cmd = New SqlCommand("Select * from CatLevel2 where CatCode1='" & Cat1Code.Text & "'and CatName2 like '%" & txtCat2Name.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("CatCode2"), rdr("CatName2"))
        End While
        rdr.Close()
    End Sub

    Private Sub Cat2Code_KeyDown(sender As Object, e As KeyEventArgs) Handles Cat2Code.KeyDown
        If e.KeyCode = 13 Then
            If Cat1Code.Text = "" Then Return
            xCATCODE1(Cat2Code.Text)
        ElseIf e.KeyCode = 113 Then
            Panel1.Hide()
            Panel3.Show()
            Panel2.Hide()
            txtCat2Code.Focus()
            txtCat2Code_TextChanged(sender, EventArgs.Empty)
        ElseIf e.KeyCode = 27 Then
            Cat2Code.Clear()
            Cat2Name.Clear()
            Cat1Code.Focus()
        End If
    End Sub

 
    Private Sub xCATCODE1(ByVal xCAT1 As String)
        cmd = New SqlCommand("Select * from CatLevel2 where(CatCode2='" & xCAT1 & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            Cat2Code.Text = rdr("CatCode2").ToString
            Cat2Name.Text = rdr("CatName2").ToString
            Cat2Code.Focus()
        End If
        rdr.Close()
    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        xCATCODE1(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel3.Hide()
        Panel1.Show()
    End Sub

    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.RowCount = 0 Then Return
            xCATCODE1(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
        ElseIf e.KeyCode = 27 Then
            txtCat2Code.Focus()
        End If
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click

        If Cat1Code.Text = "" Or Cat2Code.Text = "" Then Return
        cmd = New SqlCommand("Select * from CatLevel2 where(CatCode1='" & Cat1Code.Text & "'and CatCode2='" & Cat2Code.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            Dim result1 As DialogResult = MessageBox.Show("Do you want to Update the Current Category Level2 Details ?", "Update Category Level2 Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                '                       CatCode1, CatName1,             CatCode2,                       CatName2,                        LastUpdate,                                                Uname
                cmd1 = New SqlCommand("Update CatLevel2 set CatCode2='" & Cat2Code.Text & "',CatName2='" & Cat2Name.Text & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "'where CatCode1='" & Cat1Code.Text & "'and CatCode2='" & Cat2Code.Text & "'", con1)
                cmd1.ExecuteNonQuery()
                MessageBox.Show("Update Category Level2 Details Succeed.", "Update Category Level2 Details", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            Dim result1 As DialogResult = MessageBox.Show("Do you want to Add New Category Level2 ?", "Add New Category Level2", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                '                                                     CatCode1,               CatName1,                CatCode2,               CatName2,                    LastUpdate,                             Uname
                cmd1 = New SqlCommand("Insert CatLevel2 values('" & Cat1Code.Text & "','" & Cat1Name.Text & "','" & Cat2Code.Text & "','" & Cat2Name.Text & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con1)
                cmd1.ExecuteNonQuery()
                MessageBox.Show("Add New Category Level2 Save Succeed.", "Add New Category Level2", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
            rdr.Close()
        Cat2Code.Clear()
        Cat2Name.Clear()
        Cat2Code.Focus()
    End Sub
   
End Class