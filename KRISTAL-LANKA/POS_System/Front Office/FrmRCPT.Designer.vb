<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRCPT
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Amnt = New System.Windows.Forms.TextBox()
        Me.RcvDescrip = New System.Windows.Forms.TextBox()
        Me.CusName = New System.Windows.Forms.TextBox()
        Me.CusCode = New System.Windows.Forms.TextBox()
        Me.CusBalance = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.RcpNo = New System.Windows.Forms.TextBox()
        Me.CustName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UnitID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GRID1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustCode = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.GRID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label44)
        Me.Panel1.Controls.Add(Me.Label43)
        Me.Panel1.Controls.Add(Me.Label39)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Amnt)
        Me.Panel1.Controls.Add(Me.RcvDescrip)
        Me.Panel1.Controls.Add(Me.CusName)
        Me.Panel1.Controls.Add(Me.CusCode)
        Me.Panel1.Controls.Add(Me.CusBalance)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.RcpNo)
        Me.Panel1.Controls.Add(Me.CustName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.UnitID)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.GRID1)
        Me.Panel1.Controls.Add(Me.CustCode)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(589, 495)
        Me.Panel1.TabIndex = 29
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Crimson
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(203, 454)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(88, 27)
        Me.Label44.TabIndex = 137
        Me.Label44.Text = "Close-F12"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.DarkOrange
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(109, 454)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(88, 27)
        Me.Label43.TabIndex = 136
        Me.Label43.Text = "Cancel-F11"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(15, 454)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(88, 27)
        Me.Label39.TabIndex = 135
        Me.Label39.Text = "Save-F4"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(433, 412)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Amount"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 412)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Description"
        '
        'Amnt
        '
        Me.Amnt.BackColor = System.Drawing.SystemColors.Info
        Me.Amnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Amnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Amnt.Location = New System.Drawing.Point(436, 428)
        Me.Amnt.Name = "Amnt"
        Me.Amnt.Size = New System.Drawing.Size(137, 20)
        Me.Amnt.TabIndex = 73
        Me.Amnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RcvDescrip
        '
        Me.RcvDescrip.BackColor = System.Drawing.SystemColors.Info
        Me.RcvDescrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RcvDescrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RcvDescrip.Location = New System.Drawing.Point(14, 428)
        Me.RcvDescrip.Name = "RcvDescrip"
        Me.RcvDescrip.Size = New System.Drawing.Size(416, 20)
        Me.RcvDescrip.TabIndex = 72
        '
        'CusName
        '
        Me.CusName.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.CusName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CusName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CusName.Location = New System.Drawing.Point(157, 387)
        Me.CusName.Name = "CusName"
        Me.CusName.Size = New System.Drawing.Size(273, 20)
        Me.CusName.TabIndex = 65
        Me.CusName.TabStop = False
        '
        'CusCode
        '
        Me.CusCode.BackColor = System.Drawing.SystemColors.Info
        Me.CusCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CusCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CusCode.Location = New System.Drawing.Point(14, 387)
        Me.CusCode.Name = "CusCode"
        Me.CusCode.Size = New System.Drawing.Size(137, 20)
        Me.CusCode.TabIndex = 4
        Me.CusCode.TabStop = False
        '
        'CusBalance
        '
        Me.CusBalance.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.CusBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CusBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CusBalance.Location = New System.Drawing.Point(436, 387)
        Me.CusBalance.Name = "CusBalance"
        Me.CusBalance.Size = New System.Drawing.Size(135, 20)
        Me.CusBalance.TabIndex = 71
        Me.CusBalance.TabStop = False
        Me.CusBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(304, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Receipt No"
        '
        'RcpNo
        '
        Me.RcpNo.BackColor = System.Drawing.SystemColors.Info
        Me.RcpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RcpNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RcpNo.Location = New System.Drawing.Point(377, 90)
        Me.RcpNo.Name = "RcpNo"
        Me.RcpNo.ReadOnly = True
        Me.RcpNo.Size = New System.Drawing.Size(194, 20)
        Me.RcpNo.TabIndex = 62
        Me.RcpNo.TabStop = False
        Me.RcpNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CustName
        '
        Me.CustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustName.Location = New System.Drawing.Point(134, 116)
        Me.CustName.Name = "CustName"
        Me.CustName.Size = New System.Drawing.Size(437, 20)
        Me.CustName.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Unit ID"
        '
        'UnitID
        '
        Me.UnitID.BackColor = System.Drawing.SystemColors.Info
        Me.UnitID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UnitID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitID.Location = New System.Drawing.Point(60, 90)
        Me.UnitID.Name = "UnitID"
        Me.UnitID.ReadOnly = True
        Me.UnitID.Size = New System.Drawing.Size(137, 20)
        Me.UnitID.TabIndex = 27
        Me.UnitID.TabStop = False
        Me.UnitID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(13, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(558, 70)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "CASH RECEIPT"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GRID1
        '
        Me.GRID1.AllowUserToAddRows = False
        Me.GRID1.AllowUserToDeleteRows = False
        Me.GRID1.AllowUserToResizeColumns = False
        Me.GRID1.AllowUserToResizeRows = False
        Me.GRID1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRID1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GRID1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column6, Me.Column5})
        Me.GRID1.Location = New System.Drawing.Point(13, 135)
        Me.GRID1.Name = "GRID1"
        Me.GRID1.ReadOnly = True
        Me.GRID1.RowHeadersVisible = False
        Me.GRID1.Size = New System.Drawing.Size(558, 246)
        Me.GRID1.TabIndex = 1
        Me.GRID1.TabStop = False
        '
        'Column1
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "Cus Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 120
        '
        'Column6
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column6.HeaderText = "Name"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 320
        '
        'Column5
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Balance"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 95
        '
        'CustCode
        '
        Me.CustCode.BackColor = System.Drawing.SystemColors.Info
        Me.CustCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustCode.Location = New System.Drawing.Point(13, 116)
        Me.CustCode.Name = "CustCode"
        Me.CustCode.Size = New System.Drawing.Size(122, 20)
        Me.CustCode.TabIndex = 5
        '
        'FrmRCPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1362, 741)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmRCPT"
        Me.Text = "  CASH RECEIPT  "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GRID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CusName As System.Windows.Forms.TextBox
    Friend WithEvents CusCode As System.Windows.Forms.TextBox
    Friend WithEvents CusBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents RcpNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UnitID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CustName As System.Windows.Forms.TextBox
    Friend WithEvents GRID1 As System.Windows.Forms.DataGridView
    Friend WithEvents CustCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Amnt As System.Windows.Forms.TextBox
    Friend WithEvents RcvDescrip As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
End Class
