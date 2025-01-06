
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using DynamicPDFCoreSuite.Examples;

namespace dynamicpdf_csharp_examples.Examples
{
    public class AddExistingContent
    {
        public static void Run()
        {
            ExtractImage();
            ExtractImageDocument();
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

        public static void ExtractImage()
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

    }
}
