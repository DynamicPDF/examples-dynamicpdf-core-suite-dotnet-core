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
            TemplateNewDocWatermarkExample();
        }

        public static void ImageWaterMarkExample()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            ImageWatermark imageWm = new ImageWatermark(Util.GetPath("Resources/Images/large-logo.png"));
            imageWm.ScaleX = .75f;
            imageWm.ScaleY = .75f;
            page.Elements.Add(imageWm);
            document.Draw(Util.GetPath("Output/imagewatermark-output.pdf"));
        }

        public static void TemplateNewDocWatermarkExample()
        {
            Document document = new Document();
            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));
            Image image = new Image(Util.GetPath("Resources/Images/stamp.png"), 0, 0);
            Template watermarkTemplate = new Template();
            watermarkTemplate.Elements.Add(image);
            document.Template = watermarkTemplate;
            document.Draw(Util.GetPath("Output/templatewatermark-newdoc-output.pdf"));
        }


        public static void TextWatermarkExample()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            string text = "This is a text watermark.";
            TextWatermark twm = new TextWatermark(text);
            page.Elements.Add(twm);
            document.Draw(Util.GetPath("Output/textwatermark-output.pdf"));
        }

        public static void TemplateWatermarkExample()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            Image image = new Image(Util.GetPath("Resources/Images/stamp.png"), 0, 0);
            Template watermarkTemplate = new Template();
            watermarkTemplate.Elements.Add(image);
            document.Template = watermarkTemplate;
            document.Draw(Util.GetPath("Output/templatewatermark-output.pdf"));
        }
    }
}
