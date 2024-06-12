<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGRNRPT
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GRNNo = New System.Windows.Forms.TextBox()
        Me.GRID2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBT6 = New System.Windows.Forms.RadioButton()
        Me.DTP1 = New System.Windows.Forms.DateTimePicker()
        Me.DTP2 = New System.Windows.Forms.DateTimePicker()
        Me.RBT1 = New System.Windows.Forms.RadioButton()
        Me.RBT2 = New System.Windows.Forms.RadioButton()
        Me.RBT3 = New System.Windows.Forms.RadioButton()
        Me.RBT5 = New System.Windows.Forms.RadioButton()
        Me.RBT4 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SupNm = New System.Windows.Forms.TextBox()
        Me.SupCD = New System.Windows.Forms.TextBox()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.CmdVeiw = New System.Windows.Forms.Button()
        Me.txtSupName = New System.Windows.Forms.TextBox()
        Me.txtSupCode = New System.Windows.Forms.TextBox()
        Me.GRID1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.GRID2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GRID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.GRNNo)
        Me.Panel1.Controls.Add(Me.GRID2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.SupNm)
        Me.Panel1.Controls.Add(Me.SupCD)
        Me.Panel1.Controls.Add(Me.CmdExit)
        Me.Panel1.Controls.Add(Me.CmdCancel)
        Me.Panel1.Controls.Add(Me.CmdVeiw)
        Me.Panel1.Controls.Add(Me.txtSupName)
        Me.Panel1.Controls.Add(Me.txtSupCode)
        Me.Panel1.Controls.Add(Me.GRID1)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(961, 455)
        Me.Panel1.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(622, 343)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "GRNNo"
        '
        'GRNNo
        '
        Me.GRNNo.BackColor = System.Drawing.Color.White
        Me.GRNNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GRNNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRNNo.Location = New System.Drawing.Point(622, 357)
        Me.GRNNo.Name = "GRNNo"
        Me.GRNNo.ReadOnly = True
        Me.GRNNo.Size = New System.Drawing.Size(240, 20)
        Me.GRNNo.TabIndex = 84
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
        Me.GRID2.Location = New System.Drawing.Point(364, 85)
        Me.GRID2.Name = "GRID2"
        Me.GRID2.ReadOnly = True
        Me.GRID2.RowHeadersVisible = False
        Me.GRID2.Size = New System.Drawing.Size(151, 331)
        Me.GRID2.TabIndex = 83
        Me.GRID2.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "GRN No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 130
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBT6)
        Me.GroupBox1.Controls.Add(Me.DTP1)
        Me.GroupBox1.Controls.Add(Me.DTP2)
        Me.GroupBox1.Controls.Add(Me.RBT1)
        Me.GroupBox1.Controls.Add(Me.RBT2)
        Me.GroupBox1.Controls.Add(Me.RBT3)
        Me.GroupBox1.Controls.Add(Me.RBT5)
        Me.GroupBox1.Controls.Add(Me.RBT4)
        Me.GroupBox1.Location = New System.Drawing.Point(619, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(252, 203)
        Me.GroupBox1.TabIndex = 82
        Me.GroupBox1.TabStop = False
        '
        'RBT6
        '
        Me.RBT6.AutoSize = True
        Me.RBT6.Location = New System.Drawing.Point(6, 180)
        Me.RBT6.Name = "RBT6"
        Me.RBT6.Size = New System.Drawing.Size(202, 17)
        Me.RBT6.TabIndex = 78
        Me.RBT6.TabStop = True
        Me.RBT6.Text = "Purchases of Items for Selected GRN"
        Me.RBT6.UseVisualStyleBackColor = True
        '
        'DTP1
        '
        Me.DTP1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP1.CustomFormat = "yyyy-MM-dd"
        Me.DTP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP1.Location = New System.Drawing.Point(6, 13)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(102, 20)
        Me.DTP1.TabIndex = 71
        Me.DTP1.Value = New Date(2015, 2, 22, 0, 0, 0, 0)
        '
        'DTP2
        '
        Me.DTP2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP2.CustomFormat = "yyyy-MM-dd"
        Me.DTP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP2.Location = New System.Drawing.Point(6, 39)
        Me.DTP2.Name = "DTP2"
        Me.DTP2.Size = New System.Drawing.Size(102, 20)
        Me.DTP2.TabIndex = 72
        Me.DTP2.Value = New Date(2015, 2, 22, 0, 0, 0, 0)
        '
        'RBT1
        '
        Me.RBT1.AutoSize = True
        Me.RBT1.Location = New System.Drawing.Point(6, 65)
        Me.RBT1.Name = "RBT1"
        Me.RBT1.Size = New System.Drawing.Size(102, 17)
        Me.RBT1.TabIndex = 73
        Me.RBT1.TabStop = True
        Me.RBT1.Text = "Total Purchases"
        Me.RBT1.UseVisualStyleBackColor = True
        '
        'RBT2
        '
        Me.RBT2.AutoSize = True
        Me.RBT2.Location = New System.Drawing.Point(6, 88)
        Me.RBT2.Name = "RBT2"
        Me.RBT2.Size = New System.Drawing.Size(201, 17)
        Me.RBT2.TabIndex = 74
        Me.RBT2.TabStop = True
        Me.RBT2.Text = "Total Purchases for selected Supplier"
        Me.RBT2.UseVisualStyleBackColor = True
        '
        'RBT3
        '
        Me.RBT3.AutoSize = True
        Me.RBT3.Location = New System.Drawing.Point(6, 111)
        Me.RBT3.Name = "RBT3"
        Me.RBT3.Size = New System.Drawing.Size(186, 17)
        Me.RBT3.TabIndex = 75
        Me.RBT3.TabStop = True
        Me.RBT3.Text = "Total Purchases for selected Date"
        Me.RBT3.UseVisualStyleBackColor = True
        '
        'RBT5
        '
        Me.RBT5.AutoSize = True
        Me.RBT5.Location = New System.Drawing.Point(6, 157)
        Me.RBT5.Name = "RBT5"
        Me.RBT5.Size = New System.Drawing.Size(145, 17)
        Me.RBT5.TabIndex = 77
        Me.RBT5.TabStop = True
        Me.RBT5.Text = "Total Purchases of Items "
        Me.RBT5.UseVisualStyleBackColor = True
        '
        'RBT4
        '
        Me.RBT4.AutoSize = True
        Me.RBT4.Location = New System.Drawing.Point(6, 134)
        Me.RBT4.Name = "RBT4"
        Me.RBT4.Size = New System.Drawing.Size(246, 17)
        Me.RBT4.TabIndex = 76
        Me.RBT4.TabStop = True
        Me.RBT4.Text = "Total Purchases for selected Supplier and date"
        Me.RBT4.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(622, 306)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(622, 267)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Code"
        '
        'SupNm
        '
        Me.SupNm.BackColor = System.Drawing.Color.White
        Me.SupNm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SupNm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupNm.Location = New System.Drawing.Point(622, 322)
        Me.SupNm.Name = "SupNm"
        Me.SupNm.ReadOnly = True
        Me.SupNm.Size = New System.Drawing.Size(240, 20)
        Me.SupNm.TabIndex = 79
        '
        'SupCD
        '
        Me.SupCD.BackColor = System.Drawing.Color.White
        Me.SupCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SupCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupCD.Location = New System.Drawing.Point(622, 284)
        Me.SupCD.Name = "SupCD"
        Me.SupCD.ReadOnly = True
        Me.SupCD.Size = New System.Drawing.Size(240, 20)
        Me.SupCD.TabIndex = 78
        '
        'CmdExit
        '
        Me.CmdExit.Image = Global.POS_System.My.Resources.Resources.wwwrong_10664423
        Me.CmdExit.Location = New System.Drawing.Point(781, 380)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(75, 36)
        Me.CmdExit.TabIndex = 70
        Me.CmdExit.Text = "Exit"
        Me.CmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.Image = Global.POS_System.My.Resources.Resources.Button_Cancel_icon1
        Me.CmdCancel.Location = New System.Drawing.Point(700, 380)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(75, 36)
        Me.CmdCancel.TabIndex = 69
        Me.CmdCancel.Text = "Cancel"
        Me.CmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'CmdVeiw
        '
        Me.CmdVeiw.Image = Global.POS_System.My.Resources.Resources.Untitled_111
        Me.CmdVeiw.Location = New System.Drawing.Point(619, 380)
        Me.CmdVeiw.Name = "CmdVeiw"
        Me.CmdVeiw.Size = New System.Drawing.Size(75, 36)
        Me.CmdVeiw.TabIndex = 68
        Me.CmdVeiw.Text = "Veiw"
        Me.CmdVeiw.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdVeiw.UseVisualStyleBackColor = True
        '
        'txtSupName
        '
        Me.txtSupName.BackColor = System.Drawing.Color.White
        Me.txtSupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupName.Location = New System.Drawing.Point(118, 61)
        Me.txtSupName.Name = "txtSupName"
        Me.txtSupName.Size = New System.Drawing.Size(397, 20)
        Me.txtSupName.TabIndex = 2
        '
        'txtSupCode
        '
        Me.txtSupCode.BackColor = System.Drawing.Color.White
        Me.txtSupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupCode.Location = New System.Drawing.Point(8, 61)
        Me.txtSupCode.Name = "txtSupCode"
        Me.txtSupCode.Size = New System.Drawing.Size(111, 20)
        Me.txtSupCode.TabIndex = 1
        '
        'GRID1
        '
        Me.GRID1.AllowUserToAddRows = False
        Me.GRID1.AllowUserToDeleteRows = False
        Me.GRID1.AllowUserToResizeColumns = False
        Me.GRID1.AllowUserToResizeRows = False
        Me.GRID1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GRID1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14})
        Me.GRID1.Location = New System.Drawing.Point(8, 85)
        Me.GRID1.Name = "GRID1"
        Me.GRID1.ReadOnly = True
        Me.GRID1.RowHeadersVisible = False
        Me.GRID1.Size = New System.Drawing.Size(350, 331)
        Me.GRID1.TabIndex = 2
        Me.GRID1.TabStop = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Sup Code"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 110
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 220
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(8, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(944, 51)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "GRN / Purchasing Reports"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmGRNRPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmGRNRPT"
        Me.Text = "  REPORT  "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GRID2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GRID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtSupName As System.Windows.Forms.TextBox
    Friend WithEvents txtSupCode As System.Windows.Forms.TextBox
    Friend WithEvents GRID1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents CmdVeiw As System.Windows.Forms.Button
    Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents RBT4 As System.Windows.Forms.RadioButton
    Friend WithEvents RBT3 As System.Windows.Forms.RadioButton
    Friend WithEvents RBT2 As System.Windows.Forms.RadioButton
    Friend WithEvents RBT1 As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RBT5 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SupNm As System.Windows.Forms.TextBox
    Friend WithEvents SupCD As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GRID2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GRNNo As System.Windows.Forms.TextBox
    Friend WithEvents RBT6 As System.Windows.Forms.RadioButton
End Class
