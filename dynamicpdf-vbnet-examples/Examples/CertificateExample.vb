Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Forms

Namespace DynamicPDFCoreSuite.Examples
    Public Class CertificateExample

        Public Shared Sub Run()
            Visible()
            InVisible()
        End Sub

        Public Shared Sub Visible()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)

            ' Create & add Signature Form Field
            Dim signature As New Signature("SigField", 10, 10, 250, 100)
            page.Elements.Add(signature)
            document.Pages.Add(page)
            Dim certificate As New Certificate(Util.GetPath("Resources/Data/JohnDoe.pfx"), "password")

            ' Field name should be one of the signature field names 
            document.Certify("SigField", certificate, CertifyingPermission.NoChangesAllowed)

            document.Draw(Util.GetPath("Output/certificate-visible-output.pdf"))
        End Sub

        Public Shared Sub InVisible()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)
            document.Pages.Add(page)

            Dim certificate As New Certificate(Util.GetPath("Resources/Data/JohnDoe.pfx"), "password")

            document.Certify("NonExistingField", certificate, CertifyingPermission.NoChangesAllowed)

            document.Draw(Util.GetPath("Output/certificate-invisible-output.pdf"))
        End Sub

    End Class
End Namespace

