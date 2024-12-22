Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Cryptography
Imports ceTe.DynamicPDF.Merger

Namespace DynamicPDFCoreSuite.Examples
    Public Class EncryptPDF
        Public Shared Sub Run()
            Generator()
            Merger()
        End Sub

        Public Shared Sub Generator()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim security As New Aes256Security("OwnerPassword", "UserPassword")
            security.AllowAccessibility = True
            security.AllowFormFilling = False
            document.Security = security
            document.Draw(Util.GetPath("Output/encryptNewPDF.pdf"))
        End Sub

        Public Shared Sub Merger()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))

            Dim security As New Aes256Security("OwnerPassword", "UserPassword")
            security.AllowCopy = False
            security.AllowPrint = False
            document.Security = security

            document.Draw(Util.GetPath("Output/encryptExistingPDF.pdf"))
        End Sub
    End Class
End Namespace

