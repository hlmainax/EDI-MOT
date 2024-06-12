Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelProductName.Text = "Softlab POS"
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        'Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCopyright.Text = "Copyright© Softlab Solutions"
        Me.LabelCompanyName.Text = "Glinmax Holdings (Pvt)Ltd"
        Dim xDISC As String = "SOFTLAB SOLUTIONS (PVT) LTD

We are a subsidiary of Glinmax Holdings (Pvt) Ltd. We provide solutions for web designing, social media marketing, software development, graphic designing, mobile applications and other digital marketing solutions.

Considering the needs of the market we offer the " & "Softlab POS System" & " in order to fulfill the requirements of our client in smarter ways.

Our System Includes
- Billing and Order Processing
- Sales Monitoring and Reports
- Inventory and Stock Management
- Customer Relationship and Experience
- Employee Management
- Supplier Details
- Loyalty Programs and Gift Cards

System can be customized according to the requirements of the respective client. 

Contact Details
E-mail: info@glinmax.com
Hotline: 0763313333
Address: 453/A, Block 2, Peradeniya Road, Kandy

"
        '  Me.TextBoxDescription.Text = My.Application.Info.Description
        Me.TextBoxDescription.Text = xDISC
        FrmAct.Close()
        frmBackup.Close()
        FrmBANK.Close()
        FrmCashier.Close()
        FrmCat1.Close()
        FrmCat2.Close()
        FrmCHQPAY.Close()
        FrmCustomer.Close()
        FrmDMG.Close()
        FrmErrorCorrec.Close()
        FrmExcel.Close()
        FrmGRNRPT.Close()
        FrmGRN.Close()
        FrmItem.Close()
        frmPchange.Close()
        FrmRCPT.Close()
        FrmREPORT.Close()
        FrmRPT.Close()
        FrmRPT1.Close()
        FrmRpts.Close()
        FrmRtn.Close()
        FrmSALESRE.Close()
        FrmSTCKENTER.Close()
        FrmSupPament.Close()
        FrmSupplier.Close()
        FrmSupplierRTN.Close()
        FrmUOP.Close()
        FrmUserControl.Close()
        'AboutBox1.Close()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
        FrmCashier.Show()
        FrmCashier.MdiParent = FrmMDI
        FrmCashier.BringToFront()
    End Sub

    Private Sub AboutBox1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FrmCashier.Show()
        FrmCashier.MdiParent = FrmMDI
        FrmCashier.BringToFront()
    End Sub
End Class
