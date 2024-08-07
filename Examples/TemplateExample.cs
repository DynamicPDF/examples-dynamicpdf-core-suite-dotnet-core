using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;


namespace DynamicPDFCoreSuite.Examples
{
    class TemplateExample
    {
        public static void Run()
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

            doc.Draw(Util.GetPath("Output/AddTemplateToPDF.pdf"));
        }
    }
}
