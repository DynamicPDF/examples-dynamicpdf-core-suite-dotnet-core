
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using DynamicPDFCoreSuite.Examples;
using System;

namespace dynamicpdf_csharp_examples.Examples
{
    public class AddExistingContent
    {
        public static void Run()
        {
            ImportPage();
            ExtractImageDocument();
            ExtractDocumentAttachmentBookmarks();
        }

        public static void ImportPage()
        {
            Document document = new Document();
            document.Pages.Add(new Page(PageSize.Letter));
            ImportedPage page = new ImportedPage(Util.GetPath("Resources/PDFs/DocumentA.pdf"), 1);
            Label lbl = new Label("Imported Page Text", 0, 0, 500, 0);
            lbl.FontSize = 24;
            lbl.TextColor = RgbColor.Navy;
            page.Elements.Add(lbl);
            document.Pages.Insert(0, page);
            document.Draw(Util.GetPath("Output/existing-content-import-page-output.pdf"));
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

            document.Draw(Util.GetPath("Output/exiting-content-image-new-document-output.pdf"));

        }

        public static void ExtractDocumentAttachmentBookmarks()
        {
            PdfDocument pdfDoc = new PdfDocument(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            Attachment attachment = pdfDoc.GetAttachments()[0];
            EmbeddedFile embFile = new(attachment.GetData(), attachment.Filename, DateTime.Now);
            PdfOutline outline = pdfDoc.Outlines[1];

            Document document = new Document();
            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new ImportedPage(pdfDoc.Pages[1]));
            document.EmbeddedFiles.Add(embFile);
            document.Outlines.Add(outline);
            document.Draw(Util.GetPath("Output/existing-content-attachment-output.pdf"));
        }
    }
}
