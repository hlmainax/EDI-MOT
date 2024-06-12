<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmREPORT
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
        Me.CmbRPT = New System.Windows.Forms.ComboBox()
        Me.DTP1 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.GB1 = New System.Windows.Forms.GroupBox()
        Me.CusName = New System.Windows.Forms.TextBox()
        Me.CusCoode = New System.Windows.Forms.TextBox()
        Me.GRID1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmdCanc = New System.Windows.Forms.Button()
        Me.CmdVw = New System.Windows.Forms.Button()
        Me.DTP2 = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCusNm = New System.Windows.Forms.TextBox()
        Me.txtCucCd = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DTP3 = New System.Windows.Forms.DateTimePicker()
        Me.CusCode = New System.Windows.Forms.TextBox()
        Me.CmdVeiw = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.GB1.SuspendLayout()
        CType(Me.GRID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbRPT
        '
        Me.CmbRPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbRPT.FormattingEnabled = True
        Me.CmbRPT.Items.AddRange(New Object() {"Customer Master", "Supplier Master", "Item Master", "Day Summery", "Stock Summery", "Payment Summery", "Item Wise", "Cash Receipt", "Supplier Acc", "Day Sold Items", "Credit Sold Items", "Card Sales", "Profit Wise", "Vegetable", "Veg Stock", "Month Sales", "Supplier Returns"})
        Me.CmbRPT.Location = New System.Drawing.Point(3, 44)
        Me.CmbRPT.Name = "CmbRPT"
        Me.CmbRPT.Size = New System.Drawing.Size(248, 21)
        Me.CmbRPT.TabIndex = 26
        '
        'DTP1
        '
        Me.DTP1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP1.CustomFormat = "yyyy-MM-dd"
        Me.DTP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP1.Location = New System.Drawing.Point(3, 71)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(121, 20)
        Me.DTP1.TabIndex = 28
        Me.DTP1.Value = New Date(2015, 2, 22, 0, 0, 0, 0)
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(3, 123)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 29
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(3, 97)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(121, 20)
        Me.TextBox2.TabIndex = 30
        '
        'GB1
        '
        Me.GB1.BackColor = System.Drawing.Color.AliceBlue
        Me.GB1.Controls.Add(Me.CusName)
        Me.GB1.Controls.Add(Me.CusCoode)
        Me.GB1.Controls.Add(Me.GRID1)
        Me.GB1.Location = New System.Drawing.Point(291, 14)
        Me.GB1.Name = "GB1"
        Me.GB1.Size = New System.Drawing.Size(549, 333)
        Me.GB1.TabIndex = 31
        Me.GB1.TabStop = False
        '
        'CusName
        '
        Me.CusName.Location = New System.Drawing.Point(124, 17)
        Me.CusName.Name = "CusName"
        Me.CusName.Size = New System.Drawing.Size(415, 20)
        Me.CusName.TabIndex = 33
        '
        'CusCoode
        '
        Me.CusCoode.Location = New System.Drawing.Point(7, 17)
        Me.CusCoode.Name = "CusCoode"
        Me.CusCoode.Size = New System.Drawing.Size(111, 20)
        Me.CusCoode.TabIndex = 32
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
        Me.GRID1.Location = New System.Drawing.Point(7, 43)
        Me.GRID1.Name = "GRID1"
        Me.GRID1.ReadOnly = True
        Me.GRID1.RowHeadersVisible = False
        Me.GRID1.Size = New System.Drawing.Size(532, 277)
        Me.GRID1.TabIndex = 3
        Me.GRID1.TabStop = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Cus Code"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 110
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 400
        '
        'CmdCanc
        '
        Me.CmdCanc.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdCanc.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCanc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCanc.Location = New System.Drawing.Point(331, 42)
        Me.CmdCanc.Name = "CmdCanc"
        Me.CmdCanc.Size = New System.Drawing.Size(125, 29)
        Me.CmdCanc.TabIndex = 35
        Me.CmdCanc.Text = "Cancel"
        Me.CmdCanc.UseVisualStyleBackColor = False
        '
        'CmdVw
        '
        Me.CmdVw.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdVw.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdVw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdVw.Location = New System.Drawing.Point(140, 42)
        Me.CmdVw.Name = "CmdVw"
        Me.CmdVw.Size = New System.Drawing.Size(185, 29)
        Me.CmdVw.TabIndex = 34
        Me.CmdVw.Text = "Veiw"
        Me.CmdVw.UseVisualStyleBackColor = False
        '
        'DTP2
        '
        Me.DTP2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP2.CustomFormat = "yyyy-MM-dd"
        Me.DTP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP2.Location = New System.Drawing.Point(11, 42)
        Me.DTP2.Name = "DTP2"
        Me.DTP2.Size = New System.Drawing.Size(123, 26)
        Me.DTP2.TabIndex = 32
        Me.DTP2.Value = New Date(2015, 2, 22, 0, 0, 0, 0)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtCusNm)
        Me.Panel1.Controls.Add(Me.CmdCanc)
        Me.Panel1.Controls.Add(Me.txtCucCd)
        Me.Panel1.Controls.Add(Me.DTP2)
        Me.Panel1.Controls.Add(Me.CmdVw)
        Me.Panel1.Location = New System.Drawing.Point(925, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(469, 86)
        Me.Panel1.TabIndex = 63
        '
        'txtCusNm
        '
        Me.txtCusNm.Enabled = False
        Me.txtCusNm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCusNm.Location = New System.Drawing.Point(140, 10)
        Me.txtCusNm.Name = "txtCusNm"
        Me.txtCusNm.Size = New System.Drawing.Size(316, 26)
        Me.txtCusNm.TabIndex = 35
        '
        'txtCucCd
        '
        Me.txtCucCd.Enabled = False
        Me.txtCucCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCucCd.Location = New System.Drawing.Point(11, 10)
        Me.txtCucCd.Name = "txtCucCd"
        Me.txtCucCd.Size = New System.Drawing.Size(123, 26)
        Me.txtCucCd.TabIndex = 34
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.DTP3)
        Me.Panel2.Controls.Add(Me.CusCode)
        Me.Panel2.Controls.Add(Me.CmbRPT)
        Me.Panel2.Controls.Add(Me.CmdVeiw)
        Me.Panel2.Controls.Add(Me.GB1)
        Me.Panel2.Controls.Add(Me.CmdCancel)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.CmdExit)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.DTP1)
        Me.Panel2.Location = New System.Drawing.Point(12, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(894, 363)
        Me.Panel2.TabIndex = 64
        '
        'DTP3
        '
        Me.DTP3.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP3.CustomFormat = "yyyy-MM-dd"
        Me.DTP3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP3.Location = New System.Drawing.Point(130, 71)
        Me.DTP3.Name = "DTP3"
        Me.DTP3.Size = New System.Drawing.Size(121, 20)
        Me.DTP3.TabIndex = 33
        Me.DTP3.Value = New Date(2015, 2, 22, 0, 0, 0, 0)
        '
        'CusCode
        '
        Me.CusCode.Location = New System.Drawing.Point(3, 149)
        Me.CusCode.Name = "CusCode"
        Me.CusCode.Size = New System.Drawing.Size(100, 20)
        Me.CusCode.TabIndex = 32
        '
        'CmdVeiw
        '
        Me.CmdVeiw.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdVeiw.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdVeiw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdVeiw.Image = Global.POS_System.My.Resources.Resources.Untitled_111
        Me.CmdVeiw.Location = New System.Drawing.Point(3, 309)
        Me.CmdVeiw.Name = "CmdVeiw"
        Me.CmdVeiw.Size = New System.Drawing.Size(90, 38)
        Me.CmdVeiw.TabIndex = 23
        Me.CmdVeiw.Text = "Veiw"
        Me.CmdVeiw.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdVeiw.UseVisualStyleBackColor = False
        '
        'CmdCancel
        '
        Me.CmdCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdCancel.Image = Global.POS_System.My.Resources.Resources.Button_Cancel_icon1
        Me.CmdCancel.Location = New System.Drawing.Point(99, 309)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(90, 38)
        Me.CmdCancel.TabIndex = 24
        Me.CmdCancel.Text = "Cancel"
        Me.CmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdCancel.UseVisualStyleBackColor = False
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdExit.Image = Global.POS_System.My.Resources.Resources.wwwrong_10664423
        Me.CmdExit.Location = New System.Drawing.Point(195, 309)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(90, 38)
        Me.CmdExit.TabIndex = 25
        Me.CmdExit.Text = "Exit"
        Me.CmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'FrmREPORT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmREPORT"
        Me.Text = "  REPORTS  "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GB1.ResumeLayout(False)
        Me.GB1.PerformLayout()
        CType(Me.GRID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents CmdVeiw As System.Windows.Forms.Button
    Friend WithEvents CmbRPT As System.Windows.Forms.ComboBox
    Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents GB1 As System.Windows.Forms.GroupBox
    Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmdCanc As System.Windows.Forms.Button
    Friend WithEvents CmdVw As System.Windows.Forms.Button
    Friend WithEvents CusName As System.Windows.Forms.TextBox
    Friend WithEvents CusCoode As System.Windows.Forms.TextBox
    Friend WithEvents GRID1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCusNm As System.Windows.Forms.TextBox
    Friend WithEvents txtCucCd As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CusCode As System.Windows.Forms.TextBox
    Friend WithEvents DTP3 As System.Windows.Forms.DateTimePicker
End Class
