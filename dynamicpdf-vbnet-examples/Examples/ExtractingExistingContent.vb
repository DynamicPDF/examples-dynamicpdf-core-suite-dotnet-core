Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements
Imports System

Namespace dynamicpdf_vb_examples.Examples
    Public Class ExtractingExistingContent
        Public Shared Sub Run()
            ExtractImageMergeDocument()
            ExtractImageDocument()
            ExtractTextMergeDocument()
            ExtractTextAreaMergeDocument()
            ExtractDocumentAttachmentBookmarks()
        End Sub

        Public Shared Sub ExtractDocumentAttachmentBookmarks()
            Dim pdfDoc As New PdfDocument(Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            Dim attachment As Attachment = pdfDoc.GetAttachments()(0)
            Dim embFile As New EmbeddedFile(attachment.GetData(), attachment.Filename, DateTime.Now)
            Dim outline As PdfOutline = pdfDoc.Outlines(1)

            Dim document As New MergeDocument()
            document.Pages.Add(New ImportedPage(pdfDoc.Pages(1)))
            document.EmbeddedFiles.Add(embFile)
            document.Outlines.Add(outline)
            document.Draw(Util.GetPath("Output/extract-attachment-output.pdf"))
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

            document.Draw(Util.GetPath("Output/extract-image-new-document-output.pdf"))
        End Sub

        Public Shared Sub ExtractImageMergeDocument()
            Dim document As New MergeDocument()
            Dim pdfDoc As New PdfDocument(Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            Dim pdfDoc2 As New PdfDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))

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
            document.Append(pdfDoc2)

            document.Draw(Util.GetPath("Output/extract-image-output.pdf"))
        End Sub

        Public Shared Sub ExtractTextMergeDocument()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            Dim pdfA As New PdfDocument(Util.GetPath("Resources/PDFs/doc-text.pdf"))
            Dim extractedText As String = pdfA.Pages(1).GetText()

            Dim page As New Page(PageSize.Letter)
            page.Elements.Add(New TextArea(extractedText, 0, 0, 612, 792))

            document.Pages.Add(page)
            document.Draw(Util.GetPath("Output/extract-text-output.pdf"))
        End Sub

        Public Shared Sub ExtractTextAreaMergeDocument()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            Dim pdfA As New PdfDocument(Util.GetPath("Resources/PDFs/doc-text.pdf"))
            Dim extractedText As String = pdfA.Pages(1).GetText(0, 0, 100, 400)

            Dim page As New Page(PageSize.Letter)
            page.Elements.Add(New TextArea(extractedText, 0, 0, 612, 792))

            document.Pages.Add(page)
            document.Draw(Util.GetPath("Output/extract-text-area-output.pdf"))
        End Sub
    End Class
End Namespace

