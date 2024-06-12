<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMDI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMDI))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.M1000 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1001 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1002 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.M1003 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1004 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1005 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.M1006 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M1007 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2000 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2001 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2002 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M2003 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3000 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3001 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3002 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3003 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M3004 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M4000 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M4001 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CASHCHQDepositeWidrawToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.M5000 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M5001 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M6000 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M6001 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M6002 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CHARTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.M7000 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M7001 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M7002 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M7003 = New System.Windows.Forms.ToolStripMenuItem()
        Me.M7004 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UName = New System.Windows.Forms.TextBox()
        Me.PWord = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtCNT = New System.Windows.Forms.TextBox()
        Me.FormText = New System.Windows.Forms.TextBox()
        Me.txtPP = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M1000, Me.M2000, Me.M3000, Me.M4000, Me.M5000, Me.M6000, Me.M7000, Me.AboutUsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(10, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1924, 36)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'M1000
        '
        Me.M1000.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M1001, Me.M1002, Me.ToolStripSeparator2, Me.M1003, Me.M1004, Me.M1005, Me.ToolStripSeparator1, Me.M1006, Me.M1007})
        Me.M1000.Name = "M1000"
        Me.M1000.Size = New System.Drawing.Size(59, 32)
        Me.M1000.Text = "File"
        '
        'M1001
        '
        Me.M1001.Name = "M1001"
        Me.M1001.Size = New System.Drawing.Size(260, 32)
        Me.M1001.Text = "Customer Master"
        '
        'M1002
        '
        Me.M1002.Name = "M1002"
        Me.M1002.Size = New System.Drawing.Size(260, 32)
        Me.M1002.Text = "Supplier Master"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(257, 6)
        '
        'M1003
        '
        Me.M1003.Name = "M1003"
        Me.M1003.Size = New System.Drawing.Size(260, 32)
        Me.M1003.Text = "Cat 1"
        '
        'M1004
        '
        Me.M1004.Name = "M1004"
        Me.M1004.Size = New System.Drawing.Size(260, 32)
        Me.M1004.Text = "Cat 2"
        '
        'M1005
        '
        Me.M1005.Name = "M1005"
        Me.M1005.Size = New System.Drawing.Size(260, 32)
        Me.M1005.Text = "Item Master"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(257, 6)
        '
        'M1006
        '
        Me.M1006.Name = "M1006"
        Me.M1006.Size = New System.Drawing.Size(260, 32)
        Me.M1006.Text = "Log Off"
        '
        'M1007
        '
        Me.M1007.Name = "M1007"
        Me.M1007.Size = New System.Drawing.Size(260, 32)
        Me.M1007.Text = "Exit"
        '
        'M2000
        '
        Me.M2000.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M2001, Me.M2002, Me.M2003})
        Me.M2000.Name = "M2000"
        Me.M2000.Size = New System.Drawing.Size(140, 32)
        Me.M2000.Text = "Front Office"
        '
        'M2001
        '
        Me.M2001.Name = "M2001"
        Me.M2001.Size = New System.Drawing.Size(210, 32)
        Me.M2001.Text = "Cashier"
        '
        'M2002
        '
        Me.M2002.Name = "M2002"
        Me.M2002.Size = New System.Drawing.Size(210, 32)
        Me.M2002.Text = "SalesReturn"
        '
        'M2003
        '
        Me.M2003.Name = "M2003"
        Me.M2003.Size = New System.Drawing.Size(210, 32)
        Me.M2003.Text = "GRN"
        '
        'M3000
        '
        Me.M3000.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M3001, Me.M3002, Me.M3003, Me.M3004})
        Me.M3000.Name = "M3000"
        Me.M3000.Size = New System.Drawing.Size(135, 32)
        Me.M3000.Text = "Back Office"
        '
        'M3001
        '
        Me.M3001.Name = "M3001"
        Me.M3001.Size = New System.Drawing.Size(229, 32)
        Me.M3001.Text = "GRN Note"
        '
        'M3002
        '
        Me.M3002.Name = "M3002"
        Me.M3002.Size = New System.Drawing.Size(229, 32)
        Me.M3002.Text = "PRN Note"
        '
        'M3003
        '
        Me.M3003.Name = "M3003"
        Me.M3003.Size = New System.Drawing.Size(229, 32)
        Me.M3003.Text = "Damage Note"
        '
        'M3004
        '
        Me.M3004.Name = "M3004"
        Me.M3004.Size = New System.Drawing.Size(229, 32)
        Me.M3004.Text = "Banking"
        Me.M3004.Visible = False
        '
        'M4000
        '
        Me.M4000.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M4001, Me.CASHCHQDepositeWidrawToolStripMenuItem})
        Me.M4000.Name = "M4000"
        Me.M4000.Size = New System.Drawing.Size(98, 32)
        Me.M4000.Text = "Finance"
        '
        'M4001
        '
        Me.M4001.Name = "M4001"
        Me.M4001.Size = New System.Drawing.Size(373, 32)
        Me.M4001.Text = "SUP Pay"
        '
        'CASHCHQDepositeWidrawToolStripMenuItem
        '
        Me.CASHCHQDepositeWidrawToolStripMenuItem.Name = "CASHCHQDepositeWidrawToolStripMenuItem"
        Me.CASHCHQDepositeWidrawToolStripMenuItem.Size = New System.Drawing.Size(373, 32)
        Me.CASHCHQDepositeWidrawToolStripMenuItem.Text = "CASH/CHQ Deposite/Widraw"
        '
        'M5000
        '
        Me.M5000.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M5001})
        Me.M5000.Name = "M5000"
        Me.M5000.Size = New System.Drawing.Size(75, 32)
        Me.M5000.Text = "Tools"
        '
        'M5001
        '
        Me.M5001.Name = "M5001"
        Me.M5001.Size = New System.Drawing.Size(268, 32)
        Me.M5001.Text = "Backup Data Base"
        '
        'M6000
        '
        Me.M6000.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M6001, Me.M6002, Me.CHARTToolStripMenuItem})
        Me.M6000.Name = "M6000"
        Me.M6000.Size = New System.Drawing.Size(100, 32)
        Me.M6000.Text = "Reports"
        '
        'M6001
        '
        Me.M6001.Name = "M6001"
        Me.M6001.Size = New System.Drawing.Size(244, 32)
        Me.M6001.Text = "Master Reports"
        '
        'M6002
        '
        Me.M6002.Name = "M6002"
        Me.M6002.Size = New System.Drawing.Size(244, 32)
        Me.M6002.Text = "GRN Reports"
        '
        'CHARTToolStripMenuItem
        '
        Me.CHARTToolStripMenuItem.Name = "CHARTToolStripMenuItem"
        Me.CHARTToolStripMenuItem.Size = New System.Drawing.Size(244, 32)
        Me.CHARTToolStripMenuItem.Text = "CHART"
        Me.CHARTToolStripMenuItem.Visible = False
        '
        'M7000
        '
        Me.M7000.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.M7001, Me.M7002, Me.M7003, Me.M7004})
        Me.M7000.Name = "M7000"
        Me.M7000.Size = New System.Drawing.Size(88, 32)
        Me.M7000.Text = "Admin"
        '
        'M7001
        '
        Me.M7001.Name = "M7001"
        Me.M7001.Size = New System.Drawing.Size(321, 32)
        Me.M7001.Text = "User Permition Settings"
        '
        'M7002
        '
        Me.M7002.Name = "M7002"
        Me.M7002.Size = New System.Drawing.Size(321, 32)
        Me.M7002.Text = "Modify Produst"
        '
        'M7003
        '
        Me.M7003.Name = "M7003"
        Me.M7003.Size = New System.Drawing.Size(321, 32)
        Me.M7003.Text = "Stock Adjust"
        '
        'M7004
        '
        Me.M7004.Name = "M7004"
        Me.M7004.Size = New System.Drawing.Size(321, 32)
        Me.M7004.Text = "Import from Excel"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(113, 32)
        Me.AboutUsToolStripMenuItem.Text = "About Us"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 1033)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 24, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1924, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 16)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 16)
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(0, 16)
        '
        'UName
        '
        Me.UName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UName.Location = New System.Drawing.Point(1575, 5)
        Me.UName.Margin = New System.Windows.Forms.Padding(5)
        Me.UName.Name = "UName"
        Me.UName.Size = New System.Drawing.Size(263, 22)
        Me.UName.TabIndex = 3
        Me.UName.Visible = False
        '
        'PWord
        '
        Me.PWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PWord.Location = New System.Drawing.Point(1041, 5)
        Me.PWord.Margin = New System.Windows.Forms.Padding(5)
        Me.PWord.Name = "PWord"
        Me.PWord.Size = New System.Drawing.Size(263, 22)
        Me.PWord.TabIndex = 4
        Me.PWord.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'txtCNT
        '
        Me.txtCNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCNT.Location = New System.Drawing.Point(1336, 5)
        Me.txtCNT.Margin = New System.Windows.Forms.Padding(5)
        Me.txtCNT.Name = "txtCNT"
        Me.txtCNT.Size = New System.Drawing.Size(88, 22)
        Me.txtCNT.TabIndex = 6
        Me.txtCNT.Visible = False
        '
        'FormText
        '
        Me.FormText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FormText.Location = New System.Drawing.Point(1456, 6)
        Me.FormText.Margin = New System.Windows.Forms.Padding(5)
        Me.FormText.Name = "FormText"
        Me.FormText.Size = New System.Drawing.Size(88, 22)
        Me.FormText.TabIndex = 8
        Me.FormText.Visible = False
        '
        'txtPP
        '
        Me.txtPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPP.Location = New System.Drawing.Point(0, 49)
        Me.txtPP.Margin = New System.Windows.Forms.Padding(5)
        Me.txtPP.Name = "txtPP"
        Me.txtPP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPP.Size = New System.Drawing.Size(350, 30)
        Me.txtPP.TabIndex = 10
        '
        'FrmMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtPP)
        Me.Controls.Add(Me.FormText)
        Me.Controls.Add(Me.txtCNT)
        Me.Controls.Add(Me.PWord)
        Me.Controls.Add(Me.UName)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "FrmMDI"
        Me.Text = "  EDIRISINGHE MOTORS  "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents M1000 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1005 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1002 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1003 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1004 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1007 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2000 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3000 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M4000 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents UName As System.Windows.Forms.TextBox
    Friend WithEvents PWord As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents M3001 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3002 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3003 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M4001 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2001 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M1006 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M5000 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M5001 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents M1001 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M6000 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M6001 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M2002 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M7000 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M7002 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M6002 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCNT As System.Windows.Forms.TextBox
    Friend WithEvents M7003 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M7001 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CHARTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents M3004 As ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents M7004 As ToolStripMenuItem
    Friend WithEvents CASHCHQDepositeWidrawToolStripMenuItem As ToolStripMenuItem
    Public WithEvents FormText As TextBox
    Friend WithEvents txtPP As TextBox
    Friend WithEvents M2003 As ToolStripMenuItem
End Class
