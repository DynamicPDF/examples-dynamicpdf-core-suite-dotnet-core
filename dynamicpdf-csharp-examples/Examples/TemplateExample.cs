using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;


namespace DynamicPDFCoreSuite.Examples
{
    class TemplateExample
    {
        public static void Run()
        {
            Simple();
            One();
        }

        public static void Simple()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            Template template = new Template();
            template.Elements.Add(new Label("Header", 0, 0, 200, 12));
            template.Elements.Add(new Image(Util.GetPath("Resources/Images/DPDFLogo.png"), 100, 0));
            document.Template = template;
            document.Draw(Util.GetPath("Output/template-out.pdf"));
        }

        public static void One()
        {
            Document doc = new();
            Template tmp = new();

            doc.Pages.Add(new Page());
            doc.Pages.Add(new Page());

            float hgt = doc.Pages[0].Dimensions.Height;
            float x = -doc.Pages[0].Dimensions.LeftMargin;
            float y = -doc.Pages[0].Dimensions.TopMargin;
            float wdt = doc.Pages[0].Dimensions.Width;

            tmp.Elements.Add(new Rectangle(x, y, wdt, hgt, RgbColor.LightSkyBlue, RgbColor.LightSkyBlue));
            tmp.Elements.Add(new Rectangle(x, y, 20, hgt, RgbColor.Navy, RgbColor.Navy));
            tmp.Elements.Add(new Image(Util.GetPath("Resources/Images/") + "DPDFLogo.png", x + 30, y + 5));
            tmp.Elements.Add(new Label("Test.", 200, 300, 200, 0));
            doc.Template = tmp;

            doc.Draw(Util.GetPath("Output/addtemplatetopdf-out.pdf"));
        }

    }
}
