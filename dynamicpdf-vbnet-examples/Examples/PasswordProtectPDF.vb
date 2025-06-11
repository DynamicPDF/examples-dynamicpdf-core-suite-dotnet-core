Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Cryptography
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples

    Class PasswordProtectPDF

        Public Shared Sub Run()
            Generator()
            Merger()
        End Sub

        Public Shared Sub Generator()
            Dim document As New Document()
            Dim page As New Page()
            page.Elements.Add(New Label("Protected", 0, 0, 100, 15))
            document.Pages.Add(page)

            Dim security As New Aes256Security("OwnerPassword", "UserPassword")
            document.Security = security

            document.Draw(Util.GetPath("Output/PasswordProtectNewPDF.pdf"))
        End Sub

        Public Shared Sub Merger()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            Dim security As New Aes256Security("OwnerPassword", "UserPassword")
            document.Security = security

            document.Draw(Util.GetPath("Output/PasswordProtectExistingPDF.pdf"))
        End Sub

    End Class

End Namespace

