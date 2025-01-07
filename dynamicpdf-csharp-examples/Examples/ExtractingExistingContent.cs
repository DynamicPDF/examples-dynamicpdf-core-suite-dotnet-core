
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using DynamicPDFCoreSuite.Examples;
using System;

namespace dynamicpdf_csharp_examples.Examples
{
    public class ExtractingExistingContent
    {
        public static void Run()
        {
            ExtractImageMergeDocument();
            ExtractImageDocument();
            ExtractTextMergeDocument();
            ExtractTextAreaMergeDocument();
            ExtractDocumentAttachmentBookmarks();
        }

        public static void ExtractDocumentAttachmentBookmarks()
        {
            PdfDocument pdfDoc = new PdfDocument(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            Attachment attachment = pdfDoc.GetAttachments()[0];
            EmbeddedFile embFile = new(attachment.GetData(), attachment.Filename, DateTime.Now);
            PdfOutline outline = pdfDoc.Outlines[1];

            MergeDocument document = new MergeDocument();
            document.Pages.Add(new ImportedPage(pdfDoc.Pages[1]));
            document.EmbeddedFiles.Add(embFile);
            document.Outlines.Add(outline);
            document.Draw(Util.GetPath("Output/extract-attachment-output.pdf"));
        }

        public static void ExtractImageDocument()
        {
            Document document = new();
            PdfDocument pdfDoc = new PdfDocument(Util.GetPath("Resources/PDFs/DocumentB.pdf"));

            Page page = new Page(PageSize.Letter);

            PdfPage pdfPage = pdfDoc.GetPage(1);
            ImageInformation imageInfo = pdfPage.GetImages()[0];
            Image image = new Image(imageInfo.GetImage().Data, 0, 0, .5F);
            Label lbl = new Label("Extracted Image", 10, 400, 600, 0);
            lbl.FontSize = 24;
            lbl.TextColor = RgbColor.Navy;

            page.Elements.Add(image);
            page.Elements.Add(lbl);
            document.Pages.Add(page);
            
            document.Draw(Util.GetPath("Output/extract-image-new-document-output.pdf"));

        }

        public static void ExtractImageMergeDocument()
        {
            MergeDocument document = new();
            PdfDocument pdfDoc = new PdfDocument(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            PdfDocument pdfDoc2 = new(Util.GetPath("Resources/PDFs/DocumentA.pdf"));

            Page page = new Page(PageSize.Letter);

            PdfPage pdfPage = pdfDoc.GetPage(1);
            ImageInformation imageInfo = pdfPage.GetImages()[0];
            Image image = new Image(imageInfo.GetImage().Data, 0, 0, .5F);
            Label lbl = new Label("Extracted Image", 10, 400, 600, 0);
            lbl.FontSize = 24;
            lbl.TextColor = RgbColor.Navy;

            page.Elements.Add(image);
            page.Elements.Add(lbl);

            document.Pages.Add(page);
            document.Append(pdfDoc2);

            document.Draw(Util.GetPath("Output/extract-image-output.pdf"));
        }

        public static void ExtractTextMergeDocument()
        {
            MergeDocument document = new(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            PdfDocument pdfA = new PdfDocument(Util.GetPath("Resources/PDFs/doc-text.pdf"));
            string extractedText = pdfA.Pages[1].GetText();
            Page page = new Page(PageSize.Letter);
            page.Elements.Add(new TextArea(extractedText, 0, 0, 612, 792));
            document.Pages.Add(page);
            document.Draw(Util.GetPath("Output/extract-text-output.pdf"));
        }

        public static void ExtractTextAreaMergeDocument()
        {
            MergeDocument document = new(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            PdfDocument pdfA = new PdfDocument(Util.GetPath("Resources/PDFs/doc-text.pdf"));
            string extractedText = pdfA.Pages[1].GetText(0, 0, 100, 400);
            Page page = new Page(PageSize.Letter);
            page.Elements.Add(new TextArea(extractedText, 0, 0, 612, 792));
            document.Pages.Add(page);
            document.Draw(Util.GetPath("Output/extract-text-area-output.pdf"));
        }

    }
}
