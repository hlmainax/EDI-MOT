<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCHQPAY
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCHQPAY))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChqTo = New System.Windows.Forms.TextBox()
        Me.ChqFrom = New System.Windows.Forms.TextBox()
        Me.Bank = New System.Windows.Forms.TextBox()
        Me.AccNum1 = New System.Windows.Forms.TextBox()
        Me.CmbBank = New System.Windows.Forms.ComboBox()
        Me.GRID2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccNumber = New System.Windows.Forms.TextBox()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.GRID2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ChqTo)
        Me.Panel1.Controls.Add(Me.ChqFrom)
        Me.Panel1.Controls.Add(Me.Bank)
        Me.Panel1.Controls.Add(Me.AccNum1)
        Me.Panel1.Controls.Add(Me.CmbBank)
        Me.Panel1.Controls.Add(Me.GRID2)
        Me.Panel1.Controls.Add(Me.AccNumber)
        Me.Panel1.Controls.Add(Me.CmdExit)
        Me.Panel1.Controls.Add(Me.CmdCancel)
        Me.Panel1.Controls.Add(Me.CmdSave)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(821, 597)
        Me.Panel1.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(206, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "SupCode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Acc No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Bank "
        '
        'ChqTo
        '
        Me.ChqTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChqTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ChqTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChqTo.Location = New System.Drawing.Point(613, 116)
        Me.ChqTo.Name = "ChqTo"
        Me.ChqTo.Size = New System.Drawing.Size(190, 20)
        Me.ChqTo.TabIndex = 45
        Me.ChqTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChqFrom
        '
        Me.ChqFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChqFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ChqFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChqFrom.Location = New System.Drawing.Point(429, 120)
        Me.ChqFrom.Name = "ChqFrom"
        Me.ChqFrom.Size = New System.Drawing.Size(171, 20)
        Me.ChqFrom.TabIndex = 44
        Me.ChqFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Bank
        '
        Me.Bank.BackColor = System.Drawing.SystemColors.Info
        Me.Bank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Bank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bank.Location = New System.Drawing.Point(247, 93)
        Me.Bank.Name = "Bank"
        Me.Bank.ReadOnly = True
        Me.Bank.Size = New System.Drawing.Size(283, 20)
        Me.Bank.TabIndex = 42
        Me.Bank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccNum1
        '
        Me.AccNum1.BackColor = System.Drawing.SystemColors.Info
        Me.AccNum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AccNum1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccNum1.Location = New System.Drawing.Point(66, 91)
        Me.AccNum1.Name = "AccNum1"
        Me.AccNum1.ReadOnly = True
        Me.AccNum1.Size = New System.Drawing.Size(134, 20)
        Me.AccNum1.TabIndex = 40
        Me.AccNum1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmbBank
        '
        Me.CmbBank.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBank.FormattingEnabled = True
        Me.CmbBank.Items.AddRange(New Object() {"BOC", "Commercial", "HNB", "HSBC", "Nation Trust", "PABC", "Peoples Bank", "RDB", "Sampth Bank"})
        Me.CmbBank.Location = New System.Drawing.Point(66, 117)
        Me.CmbBank.Name = "CmbBank"
        Me.CmbBank.Size = New System.Drawing.Size(134, 21)
        Me.CmbBank.TabIndex = 39
        '
        'GRID2
        '
        Me.GRID2.AllowUserToAddRows = False
        Me.GRID2.AllowUserToDeleteRows = False
        Me.GRID2.AllowUserToResizeColumns = False
        Me.GRID2.AllowUserToResizeRows = False
        Me.GRID2.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GRID2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column3, Me.Column4})
        Me.GRID2.Location = New System.Drawing.Point(12, 204)
        Me.GRID2.Name = "GRID2"
        Me.GRID2.ReadOnly = True
        Me.GRID2.RowHeadersVisible = False
        Me.GRID2.Size = New System.Drawing.Size(518, 288)
        Me.GRID2.TabIndex = 38
        Me.GRID2.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "AccountNum"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Bank"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "CHQNo"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "ChqDate"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'AccNumber
        '
        Me.AccNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AccNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AccNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccNumber.Location = New System.Drawing.Point(65, 144)
        Me.AccNumber.Name = "AccNumber"
        Me.AccNumber.Size = New System.Drawing.Size(176, 20)
        Me.AccNumber.TabIndex = 27
        Me.AccNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.Image = Global.POS_System.My.Resources.Resources.wwwrong_10664423
        Me.CmdExit.Location = New System.Drawing.Point(447, 543)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(89, 33)
        Me.CmdExit.TabIndex = 22
        Me.CmdExit.Text = "Exit"
        Me.CmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'CmdCancel
        '
        Me.CmdCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancel.Image = Global.POS_System.My.Resources.Resources.Button_Cancel_icon1
        Me.CmdCancel.Location = New System.Drawing.Point(351, 543)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(90, 33)
        Me.CmdCancel.TabIndex = 21
        Me.CmdCancel.Text = "Cancel"
        Me.CmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdCancel.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdSave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Image = Global.POS_System.My.Resources.Resources.right_wrong_10664423
        Me.CmdSave.Location = New System.Drawing.Point(255, 543)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(90, 33)
        Me.CmdSave.TabIndex = 20
        Me.CmdSave.Text = "Save"
        Me.CmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(12, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(718, 69)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Cheque Payments"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmCHQPAY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCHQPAY"
        Me.Text = "  CHEQUE PAYMENT  "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GRID2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChqTo As System.Windows.Forms.TextBox
    Friend WithEvents ChqFrom As System.Windows.Forms.TextBox
    Friend WithEvents Bank As System.Windows.Forms.TextBox
    Friend WithEvents AccNum1 As System.Windows.Forms.TextBox
    Friend WithEvents CmbBank As System.Windows.Forms.ComboBox
    Friend WithEvents GRID2 As System.Windows.Forms.DataGridView
    Friend WithEvents AccNumber As System.Windows.Forms.TextBox
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
