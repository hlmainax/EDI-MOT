<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUOP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CHK1 = New System.Windows.Forms.CheckBox()
        Me.GB3 = New System.Windows.Forms.GroupBox()
        Me.CmdGrant = New System.Windows.Forms.Button()
        Me.GRID1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GB2 = New System.Windows.Forms.GroupBox()
        Me.UsrName1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GRID2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdClear1 = New System.Windows.Forms.Button()
        Me.Pwrd1 = New System.Windows.Forms.TextBox()
        Me.CmdRset = New System.Windows.Forms.Button()
        Me.CnPwrd1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GB1 = New System.Windows.Forms.GroupBox()
        Me.UsrName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.Pwrd = New System.Windows.Forms.TextBox()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.CnPwrd = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GB3.SuspendLayout()
        CType(Me.GRID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB2.SuspendLayout()
        CType(Me.GRID2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CmdExit)
        Me.Panel1.Controls.Add(Me.CHK1)
        Me.Panel1.Controls.Add(Me.GB3)
        Me.Panel1.Controls.Add(Me.GB2)
        Me.Panel1.Controls.Add(Me.GB1)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1246, 576)
        Me.Panel1.TabIndex = 23
        '
        'CmdExit
        '
        Me.CmdExit.Location = New System.Drawing.Point(378, 528)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(172, 37)
        Me.CmdExit.TabIndex = 62
        Me.CmdExit.Text = "Exit"
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CHK1
        '
        Me.CHK1.AutoSize = True
        Me.CHK1.Location = New System.Drawing.Point(16, 277)
        Me.CHK1.Name = "CHK1"
        Me.CHK1.Size = New System.Drawing.Size(103, 17)
        Me.CHK1.TabIndex = 67
        Me.CHK1.Text = "Add Permissions"
        Me.CHK1.UseVisualStyleBackColor = True
        '
        'GB3
        '
        Me.GB3.BackColor = System.Drawing.Color.White
        Me.GB3.Controls.Add(Me.CmdGrant)
        Me.GB3.Controls.Add(Me.GRID1)
        Me.GB3.Location = New System.Drawing.Point(12, 295)
        Me.GB3.Name = "GB3"
        Me.GB3.Size = New System.Drawing.Size(1217, 227)
        Me.GB3.TabIndex = 66
        Me.GB3.TabStop = False
        Me.GB3.Text = "Add Permisions"
        '
        'CmdGrant
        '
        Me.CmdGrant.Location = New System.Drawing.Point(7, 183)
        Me.CmdGrant.Name = "CmdGrant"
        Me.CmdGrant.Size = New System.Drawing.Size(150, 38)
        Me.CmdGrant.TabIndex = 62
        Me.CmdGrant.Text = "Permission Grant"
        Me.CmdGrant.UseVisualStyleBackColor = True
        '
        'GRID1
        '
        Me.GRID1.AllowUserToAddRows = False
        Me.GRID1.AllowUserToDeleteRows = False
        Me.GRID1.AllowUserToResizeColumns = False
        Me.GRID1.AllowUserToResizeRows = False
        Me.GRID1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GRID1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column16, Me.Column3, Me.Column4, Me.Column5, Me.Column2, Me.Column6, Me.Column9, Me.Column7, Me.Column12, Me.Column8, Me.Column10, Me.Column17, Me.Column15, Me.Column18, Me.Column19, Me.Column11, Me.Column13, Me.Column14})
        Me.GRID1.Location = New System.Drawing.Point(7, 19)
        Me.GRID1.Name = "GRID1"
        Me.GRID1.RowHeadersVisible = False
        Me.GRID1.Size = New System.Drawing.Size(1194, 158)
        Me.GRID1.TabIndex = 13
        '
        'Column1
        '
        Me.Column1.HeaderText = "User"
        Me.Column1.Name = "Column1"
        '
        'Column16
        '
        Me.Column16.HeaderText = "FILE"
        Me.Column16.Name = "Column16"
        Me.Column16.Width = 60
        '
        'Column3
        '
        Me.Column3.HeaderText = "CUST"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 60
        '
        'Column4
        '
        Me.Column4.HeaderText = "SUPL"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 60
        '
        'Column5
        '
        Me.Column5.HeaderText = "CAT1"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 60
        '
        'Column2
        '
        Me.Column2.HeaderText = "CAT2"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 60
        '
        'Column6
        '
        Me.Column6.HeaderText = "ITEM"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 60
        '
        'Column9
        '
        Me.Column9.HeaderText = "LOFF"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 60
        '
        'Column7
        '
        Me.Column7.HeaderText = "EXIT"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 60
        '
        'Column12
        '
        Me.Column12.HeaderText = "FOFF"
        Me.Column12.Name = "Column12"
        Me.Column12.Width = 60
        '
        'Column8
        '
        Me.Column8.HeaderText = "CASH"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 60
        '
        'Column10
        '
        Me.Column10.HeaderText = "SRTN"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 60
        '
        'Column17
        '
        Me.Column17.HeaderText = "RCPT"
        Me.Column17.Name = "Column17"
        Me.Column17.Width = 60
        '
        'Column15
        '
        Me.Column15.HeaderText = "BOFF"
        Me.Column15.Name = "Column15"
        Me.Column15.Width = 60
        '
        'Column18
        '
        Me.Column18.HeaderText = "GRN"
        Me.Column18.Name = "Column18"
        Me.Column18.Width = 60
        '
        'Column19
        '
        Me.Column19.HeaderText = "SPRTN"
        Me.Column19.Name = "Column19"
        Me.Column19.Width = 60
        '
        'Column11
        '
        Me.Column11.HeaderText = "DMGE"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 60
        '
        'Column13
        '
        Me.Column13.HeaderText = "STKE"
        Me.Column13.Name = "Column13"
        Me.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column13.Width = 60
        '
        'Column14
        '
        Me.Column14.HeaderText = "PCHN"
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 60
        '
        'GB2
        '
        Me.GB2.BackColor = System.Drawing.Color.White
        Me.GB2.Controls.Add(Me.UsrName1)
        Me.GB2.Controls.Add(Me.Label4)
        Me.GB2.Controls.Add(Me.GRID2)
        Me.GB2.Controls.Add(Me.CmdClear1)
        Me.GB2.Controls.Add(Me.Pwrd1)
        Me.GB2.Controls.Add(Me.CmdRset)
        Me.GB2.Controls.Add(Me.CnPwrd1)
        Me.GB2.Controls.Add(Me.Label5)
        Me.GB2.Controls.Add(Me.Label6)
        Me.GB2.Location = New System.Drawing.Point(378, 108)
        Me.GB2.Name = "GB2"
        Me.GB2.Size = New System.Drawing.Size(851, 173)
        Me.GB2.TabIndex = 64
        Me.GB2.TabStop = False
        Me.GB2.Text = "Reset Password"
        '
        'UsrName1
        '
        Me.UsrName1.BackColor = System.Drawing.SystemColors.Info
        Me.UsrName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsrName1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsrName1.Location = New System.Drawing.Point(611, 16)
        Me.UsrName1.Name = "UsrName1"
        Me.UsrName1.Size = New System.Drawing.Size(224, 22)
        Me.UsrName1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(514, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "User Name"
        '
        'GRID2
        '
        Me.GRID2.AllowUserToAddRows = False
        Me.GRID2.AllowUserToDeleteRows = False
        Me.GRID2.AllowUserToResizeColumns = False
        Me.GRID2.AllowUserToResizeRows = False
        Me.GRID2.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GRID2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.GRID2.Location = New System.Drawing.Point(6, 19)
        Me.GRID2.Name = "GRID2"
        Me.GRID2.ReadOnly = True
        Me.GRID2.RowHeadersVisible = False
        Me.GRID2.Size = New System.Drawing.Size(490, 148)
        Me.GRID2.TabIndex = 65
        Me.GRID2.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "User Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 470
        '
        'CmdClear1
        '
        Me.CmdClear1.Location = New System.Drawing.Point(685, 103)
        Me.CmdClear1.Name = "CmdClear1"
        Me.CmdClear1.Size = New System.Drawing.Size(150, 48)
        Me.CmdClear1.TabIndex = 61
        Me.CmdClear1.Text = "Cancel"
        Me.CmdClear1.UseVisualStyleBackColor = True
        '
        'Pwrd1
        '
        Me.Pwrd1.BackColor = System.Drawing.SystemColors.Info
        Me.Pwrd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pwrd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pwrd1.Location = New System.Drawing.Point(611, 44)
        Me.Pwrd1.Name = "Pwrd1"
        Me.Pwrd1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Pwrd1.Size = New System.Drawing.Size(224, 22)
        Me.Pwrd1.TabIndex = 56
        '
        'CmdRset
        '
        Me.CmdRset.Location = New System.Drawing.Point(517, 103)
        Me.CmdRset.Name = "CmdRset"
        Me.CmdRset.Size = New System.Drawing.Size(162, 48)
        Me.CmdRset.TabIndex = 60
        Me.CmdRset.Text = "Reset Password"
        Me.CmdRset.UseVisualStyleBackColor = True
        '
        'CnPwrd1
        '
        Me.CnPwrd1.BackColor = System.Drawing.SystemColors.Info
        Me.CnPwrd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CnPwrd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CnPwrd1.Location = New System.Drawing.Point(611, 72)
        Me.CnPwrd1.Name = "CnPwrd1"
        Me.CnPwrd1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.CnPwrd1.Size = New System.Drawing.Size(224, 22)
        Me.CnPwrd1.TabIndex = 57
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(514, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Confirm Password"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(514, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Password"
        '
        'GB1
        '
        Me.GB1.BackColor = System.Drawing.Color.White
        Me.GB1.Controls.Add(Me.UsrName)
        Me.GB1.Controls.Add(Me.Label1)
        Me.GB1.Controls.Add(Me.CmdClear)
        Me.GB1.Controls.Add(Me.Pwrd)
        Me.GB1.Controls.Add(Me.CmdAdd)
        Me.GB1.Controls.Add(Me.CnPwrd)
        Me.GB1.Controls.Add(Me.Label3)
        Me.GB1.Controls.Add(Me.Label2)
        Me.GB1.Location = New System.Drawing.Point(16, 108)
        Me.GB1.Name = "GB1"
        Me.GB1.Size = New System.Drawing.Size(356, 167)
        Me.GB1.TabIndex = 63
        Me.GB1.TabStop = False
        Me.GB1.Text = "Add Users"
        '
        'UsrName
        '
        Me.UsrName.BackColor = System.Drawing.SystemColors.Info
        Me.UsrName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsrName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsrName.Location = New System.Drawing.Point(113, 19)
        Me.UsrName.Name = "UsrName"
        Me.UsrName.Size = New System.Drawing.Size(224, 22)
        Me.UsrName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "User Name"
        '
        'CmdClear
        '
        Me.CmdClear.Location = New System.Drawing.Point(191, 103)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(146, 48)
        Me.CmdClear.TabIndex = 61
        Me.CmdClear.Text = "Cancel"
        Me.CmdClear.UseVisualStyleBackColor = True
        '
        'Pwrd
        '
        Me.Pwrd.BackColor = System.Drawing.SystemColors.Info
        Me.Pwrd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pwrd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pwrd.Location = New System.Drawing.Point(113, 47)
        Me.Pwrd.Name = "Pwrd"
        Me.Pwrd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Pwrd.Size = New System.Drawing.Size(224, 22)
        Me.Pwrd.TabIndex = 56
        '
        'CmdAdd
        '
        Me.CmdAdd.Location = New System.Drawing.Point(19, 103)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(146, 48)
        Me.CmdAdd.TabIndex = 60
        Me.CmdAdd.Text = "Add User"
        Me.CmdAdd.UseVisualStyleBackColor = True
        '
        'CnPwrd
        '
        Me.CnPwrd.BackColor = System.Drawing.SystemColors.Info
        Me.CnPwrd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CnPwrd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CnPwrd.Location = New System.Drawing.Point(113, 75)
        Me.CnPwrd.Name = "CnPwrd"
        Me.CnPwrd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.CnPwrd.Size = New System.Drawing.Size(224, 22)
        Me.CnPwrd.TabIndex = 57
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Confirm Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Password"
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(12, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(1217, 94)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "User Permission Setting"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmUOP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmUOP"
        Me.Text = "  USER PERMITION  "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GB3.ResumeLayout(False)
        CType(Me.GRID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB2.ResumeLayout(False)
        Me.GB2.PerformLayout()
        CType(Me.GRID2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB1.ResumeLayout(False)
        Me.GB1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GRID1 As System.Windows.Forms.DataGridView
    Friend WithEvents UsrName As System.Windows.Forms.TextBox
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CnPwrd As System.Windows.Forms.TextBox
    Friend WithEvents Pwrd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CHK1 As System.Windows.Forms.CheckBox
    Friend WithEvents GB3 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdGrant As System.Windows.Forms.Button
    Friend WithEvents GB2 As System.Windows.Forms.GroupBox
    Friend WithEvents UsrName1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GRID2 As System.Windows.Forms.DataGridView
    Friend WithEvents CmdClear1 As System.Windows.Forms.Button
    Friend WithEvents Pwrd1 As System.Windows.Forms.TextBox
    Friend WithEvents CmdRset As System.Windows.Forms.Button
    Friend WithEvents CnPwrd1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GB1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewCheckBoxColumn
    Friend WithEvents Column3 As DataGridViewCheckBoxColumn
    Friend WithEvents Column4 As DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As DataGridViewCheckBoxColumn
    Friend WithEvents Column6 As DataGridViewCheckBoxColumn
    Friend WithEvents Column9 As DataGridViewCheckBoxColumn
    Friend WithEvents Column7 As DataGridViewCheckBoxColumn
    Friend WithEvents Column12 As DataGridViewCheckBoxColumn
    Friend WithEvents Column8 As DataGridViewCheckBoxColumn
    Friend WithEvents Column10 As DataGridViewCheckBoxColumn
    Friend WithEvents Column17 As DataGridViewCheckBoxColumn
    Friend WithEvents Column15 As DataGridViewCheckBoxColumn
    Friend WithEvents Column18 As DataGridViewCheckBoxColumn
    Friend WithEvents Column19 As DataGridViewCheckBoxColumn
    Friend WithEvents Column11 As DataGridViewCheckBoxColumn
    Friend WithEvents Column13 As DataGridViewCheckBoxColumn
    Friend WithEvents Column14 As DataGridViewCheckBoxColumn
End Class
