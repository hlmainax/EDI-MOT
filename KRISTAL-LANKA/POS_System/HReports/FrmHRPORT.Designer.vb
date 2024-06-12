<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHRPORT
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
        Me.DTP2 = New System.Windows.Forms.DateTimePicker()
        Me.RBT8 = New System.Windows.Forms.RadioButton()
        Me.RBT7 = New System.Windows.Forms.RadioButton()
        Me.RBT6 = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DTP1 = New System.Windows.Forms.DateTimePicker()
        Me.RBT4 = New System.Windows.Forms.RadioButton()
        Me.RBT3 = New System.Windows.Forms.RadioButton()
        Me.RBT5 = New System.Windows.Forms.RadioButton()
        Me.RBT2 = New System.Windows.Forms.RadioButton()
        Me.RBT1 = New System.Windows.Forms.RadioButton()
        Me.CmdVeiw = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DTP2)
        Me.Panel1.Controls.Add(Me.RBT8)
        Me.Panel1.Controls.Add(Me.RBT7)
        Me.Panel1.Controls.Add(Me.RBT6)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.DTP1)
        Me.Panel1.Controls.Add(Me.RBT4)
        Me.Panel1.Controls.Add(Me.RBT3)
        Me.Panel1.Controls.Add(Me.RBT5)
        Me.Panel1.Controls.Add(Me.RBT2)
        Me.Panel1.Controls.Add(Me.RBT1)
        Me.Panel1.Controls.Add(Me.CmdVeiw)
        Me.Panel1.Controls.Add(Me.CmdCancel)
        Me.Panel1.Controls.Add(Me.CmdExit)
        Me.Panel1.Location = New System.Drawing.Point(16, 15)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(566, 350)
        Me.Panel1.TabIndex = 65
        '
        'DTP2
        '
        Me.DTP2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP2.CustomFormat = "yyyy-MM-dd"
        Me.DTP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP2.Location = New System.Drawing.Point(263, 215)
        Me.DTP2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTP2.Name = "DTP2"
        Me.DTP2.Size = New System.Drawing.Size(160, 23)
        Me.DTP2.TabIndex = 45
        Me.DTP2.Value = New Date(2015, 2, 22, 0, 0, 0, 0)
        Me.DTP2.Visible = False
        '
        'RBT8
        '
        Me.RBT8.AutoSize = True
        Me.RBT8.Location = New System.Drawing.Point(237, 178)
        Me.RBT8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RBT8.Name = "RBT8"
        Me.RBT8.Size = New System.Drawing.Size(98, 21)
        Me.RBT8.TabIndex = 44
        Me.RBT8.TabStop = True
        Me.RBT8.Text = "Card Sales"
        Me.RBT8.UseVisualStyleBackColor = True
        Me.RBT8.Visible = False
        '
        'RBT7
        '
        Me.RBT7.AutoSize = True
        Me.RBT7.Location = New System.Drawing.Point(91, 178)
        Me.RBT7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RBT7.Name = "RBT7"
        Me.RBT7.Size = New System.Drawing.Size(139, 21)
        Me.RBT7.TabIndex = 43
        Me.RBT7.TabStop = True
        Me.RBT7.Text = "Vegetables Stock"
        Me.RBT7.UseVisualStyleBackColor = True
        Me.RBT7.Visible = False
        '
        'RBT6
        '
        Me.RBT6.AutoSize = True
        Me.RBT6.Location = New System.Drawing.Point(237, 148)
        Me.RBT6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RBT6.Name = "RBT6"
        Me.RBT6.Size = New System.Drawing.Size(100, 21)
        Me.RBT6.TabIndex = 42
        Me.RBT6.TabStop = True
        Me.RBT6.Text = "Vegetables"
        Me.RBT6.UseVisualStyleBackColor = True
        Me.RBT6.Visible = False
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(11, 9)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(538, 62)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Day Report"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DTP1
        '
        Me.DTP1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP1.CustomFormat = "yyyy-MM-dd"
        Me.DTP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP1.Location = New System.Drawing.Point(93, 215)
        Me.DTP1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(160, 23)
        Me.DTP1.TabIndex = 40
        Me.DTP1.Value = New Date(2015, 2, 22, 0, 0, 0, 0)
        '
        'RBT4
        '
        Me.RBT4.AutoSize = True
        Me.RBT4.Location = New System.Drawing.Point(215, 94)
        Me.RBT4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RBT4.Name = "RBT4"
        Me.RBT4.Size = New System.Drawing.Size(117, 21)
        Me.RBT4.TabIndex = 39
        Me.RBT4.TabStop = True
        Me.RBT4.Text = "Day Summery"
        Me.RBT4.UseVisualStyleBackColor = True
        '
        'RBT3
        '
        Me.RBT3.AutoSize = True
        Me.RBT3.Location = New System.Drawing.Point(91, 122)
        Me.RBT3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RBT3.Name = "RBT3"
        Me.RBT3.Size = New System.Drawing.Size(147, 21)
        Me.RBT3.TabIndex = 38
        Me.RBT3.TabStop = True
        Me.RBT3.Text = "Payment Summery"
        Me.RBT3.UseVisualStyleBackColor = True
        Me.RBT3.Visible = False
        '
        'RBT5
        '
        Me.RBT5.AutoSize = True
        Me.RBT5.Location = New System.Drawing.Point(91, 94)
        Me.RBT5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RBT5.Name = "RBT5"
        Me.RBT5.Size = New System.Drawing.Size(109, 21)
        Me.RBT5.TabIndex = 37
        Me.RBT5.TabStop = True
        Me.RBT5.Text = "Day Invoices"
        Me.RBT5.UseVisualStyleBackColor = True
        Me.RBT5.Visible = False
        '
        'RBT2
        '
        Me.RBT2.AutoSize = True
        Me.RBT2.Location = New System.Drawing.Point(91, 148)
        Me.RBT2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RBT2.Name = "RBT2"
        Me.RBT2.Size = New System.Drawing.Size(127, 21)
        Me.RBT2.TabIndex = 36
        Me.RBT2.TabStop = True
        Me.RBT2.Text = "Stock Summery"
        Me.RBT2.UseVisualStyleBackColor = True
        Me.RBT2.Visible = False
        '
        'RBT1
        '
        Me.RBT1.AutoSize = True
        Me.RBT1.Location = New System.Drawing.Point(335, 176)
        Me.RBT1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RBT1.Name = "RBT1"
        Me.RBT1.Size = New System.Drawing.Size(136, 21)
        Me.RBT1.TabIndex = 33
        Me.RBT1.TabStop = True
        Me.RBT1.Text = "Customer Master"
        Me.RBT1.UseVisualStyleBackColor = True
        Me.RBT1.Visible = False
        '
        'CmdVeiw
        '
        Me.CmdVeiw.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdVeiw.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdVeiw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdVeiw.Image = Global.POS_System.My.Resources.Resources.Untitled_111
        Me.CmdVeiw.Location = New System.Drawing.Point(93, 266)
        Me.CmdVeiw.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmdVeiw.Name = "CmdVeiw"
        Me.CmdVeiw.Size = New System.Drawing.Size(120, 47)
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
        Me.CmdCancel.Location = New System.Drawing.Point(221, 266)
        Me.CmdCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(120, 47)
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
        Me.CmdExit.Location = New System.Drawing.Point(349, 266)
        Me.CmdExit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(120, 47)
        Me.CmdExit.TabIndex = 25
        Me.CmdExit.Text = "Exit"
        Me.CmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'FrmHRPORT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1816, 912)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmHRPORT"
        Me.Text = " HREPORTS  "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmdVeiw As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents RBT3 As System.Windows.Forms.RadioButton
    Friend WithEvents RBT5 As System.Windows.Forms.RadioButton
    Friend WithEvents RBT2 As System.Windows.Forms.RadioButton
    Friend WithEvents RBT1 As System.Windows.Forms.RadioButton
    Friend WithEvents RBT4 As System.Windows.Forms.RadioButton
    Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RBT6 As System.Windows.Forms.RadioButton
    Friend WithEvents RBT7 As System.Windows.Forms.RadioButton
    Friend WithEvents RBT8 As System.Windows.Forms.RadioButton
    Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
End Class
