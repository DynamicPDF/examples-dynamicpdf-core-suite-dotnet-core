using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using System.IO;


namespace DynamicPDFCoreSuite.Examples
{
    class WatermarkExample
    {
        public static void Run()
        {
            ImageWaterMarkExample();
            TextWatermarkExample();
            TemplateWatermarkExample();
        }

        public static void ImageWaterMarkExample()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            document.PdfVersion = PdfVersion.v1_6;

            ImageWatermark imageWm = new ImageWatermark(GetImage());

            page.Elements.Add(imageWm);

            document.Draw(Util.GetPath("Output/imagewatermark-output.pdf"));
        }

        public static void TextWatermarkExample()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            document.PdfVersion = PdfVersion.v1_6;

            string text = "This is a text watermark.";
            TextWatermark twm = new TextWatermark(text);

            page.Elements.Add(twm);

            document.Draw(Util.GetPath("Output/textwatermark-output.pdf"));
        }

        public static void TemplateWatermarkExample()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));

            Image image = new Image(Util.GetPath("Resources/Images/DPDFLogo_Watermark.png"), 0, 0);
            Template watermarkTemplate = new Template();
            watermarkTemplate.Elements.Add(image);
            document.Template = watermarkTemplate;

            document.Draw(Util.GetPath("Output/templatewatermark-output.pdf"));
        }


        private static byte[] GetImage()
        {
            FileStream inFile = new FileStream(Util.GetPath("Resources/Images/DPDFLogo_Watermark.png"), FileMode.Open, FileAccess.Read);
            byte[] binaryData = new byte[inFile.Length];
            inFile.Read(binaryData, 0, (int)inFile.Length);
            inFile.Close();
            return binaryData;
        }
    }
}
