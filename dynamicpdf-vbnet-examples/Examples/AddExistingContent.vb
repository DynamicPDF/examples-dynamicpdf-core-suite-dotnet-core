Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements
Imports DynamicPDFCoreSuite.Examples
Imports System

Namespace dynamicpdf_vbnet_examples.Examples
    Public Class AddExistingContent
        Public Shared Sub Run()
            ImportPage()
            ExtractImageDocument()
            ExtractDocumentAttachmentBookmarks()
        End Sub

        Public Shared Sub ImportPage()
            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter))
            Dim page As New ImportedPage(Util.GetPath("Resources/PDFs/DocumentA.pdf"), 1)
            Dim lbl As New Label("Imported Page Text", 0, 0, 500, 0)
            lbl.FontSize = 24
            lbl.TextColor = RgbColor.Navy
            page.Elements.Add(lbl)
            document.Pages.Insert(0, page)
            document.Draw(Util.GetPath("Output/existing-content-import-page-output.pdf"))
        End Sub

        Public Shared Sub ExtractImageDocument()
            Dim document As New Document()
            Dim pdfDoc As New PdfDocument(Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            Dim page As New Page(PageSize.Letter)

            Dim pdfPage As PdfPage = pdfDoc.GetPage(1)
            Dim imageInfo As ImageInformation = pdfPage.GetImages()(0)
            Dim image As New Image(imageInfo.GetImage().Data, 0, 0, 0.5F)
            Dim lbl As New Label("Extracted Image", 10, 400, 600, 0)
            lbl.FontSize = 24
            lbl.TextColor = RgbColor.Navy

            page.Elements.Add(image)
            page.Elements.Add(lbl)
            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/exiting-content-image-new-document-output.pdf"))
        End Sub

        Public Shared Sub ExtractDocumentAttachmentBookmarks()
            Dim pdfDoc As New PdfDocument(Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            Dim attachment As Attachment = pdfDoc.GetAttachments()(0)
            Dim embFile As New EmbeddedFile(attachment.GetData(), attachment.Filename, DateTime.Now)
            Dim outline As PdfOutline = pdfDoc.Outlines(1)

            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New ImportedPage(pdfDoc.Pages(1)))
            document.EmbeddedFiles.Add(embFile)
            document.Outlines.Add(outline)
            document.Draw(Util.GetPath("Output/existing-content-attachment-output.pdf"))
        End Sub
    End Class
End Namespace
