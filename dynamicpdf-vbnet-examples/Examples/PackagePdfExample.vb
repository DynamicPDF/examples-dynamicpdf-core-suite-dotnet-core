Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Public Class PackagePdfExample
        Public Shared Sub Run()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim embeddedFile1 As New EmbeddedFile(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            Dim embeddedFile2 As New EmbeddedFile(Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            Dim embeddedFile3 As New EmbeddedFile(Util.GetPath("Resources/Images/DPDFLogo.png"))
            Dim embeddedFile4 As New EmbeddedFile(Util.GetPath("Resources/Data/Doc1.docx"))
            document.EmbeddedFiles.Add(embeddedFile1)
            document.EmbeddedFiles.Add(embeddedFile2)
            document.EmbeddedFiles.Add(embeddedFile3)
            document.EmbeddedFiles.Add(embeddedFile4)

            document.Package = New DocumentPackage(AttachmentLayout.Tile)
            document.Package.OrderBy = AttachmentListingOrderBy.Name
            document.Package.AscendingOrder = False

            page.Elements.Add(New Label("Cover Page", 0, 0, 512, 40, Font.Helvetica, 30, TextAlign.Center, RgbColor.BlueViolet))

            document.Draw(Util.GetPath("Output/package-pdf-output.pdf"))
        End Sub
    End Class
End Namespace

