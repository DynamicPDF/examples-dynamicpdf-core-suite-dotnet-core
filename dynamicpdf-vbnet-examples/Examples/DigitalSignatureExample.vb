Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Forms

Namespace DynamicPDFCoreSuite.Examples
    Public Class DigitalSignatureExample
        Public Shared Sub Run()
            ExampleOne()
            ExampleTwo()
        End Sub

        Public Shared Sub ExampleOne()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)

            Dim signature As New Signature("SigField", 10, 10, 250, 100)
            page.Elements.Add(signature)
            document.Pages.Add(page)

            Dim certificate As New Certificate(Util.GetPath("Resources/Data/JohnDoe.pfx"), "password")

            document.Sign("SigField", certificate)

            document.Draw(Util.GetPath("Output/signed-visible-output.pdf"))
        End Sub

        Public Shared Sub ExampleTwo()
            Dim document As New Document()
            Dim page As New Page()

            document.Pages.Add(page)
            Dim certificate As New Certificate(Util.GetPath("Resources/Data/JohnDoe.pfx"), "password")

            ' Field name should not match any field names in the document 
            document.Sign("NonExistingField", certificate)

            document.Draw(Util.GetPath("Output/signed-invisible-output.pdf"))
        End Sub
    End Class
End Namespace

