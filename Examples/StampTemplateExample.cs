using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Html;
using DynamicPDFCoreSuite.Utility;

namespace DynamicPDFCoreSuite.Examples
{
    class StampTemplateExample
    {
        public static void Run()
        {
            Document doc = new();
            StampTemplateExample.CreatePage(doc);

            Template tmp = new();

            float hgt = doc.Pages[0].Dimensions.Height/2;
            float x = -doc.Pages[0].Dimensions.LeftMargin;
            float y = -doc.Pages[0].Dimensions.TopMargin;
            float wdt = doc.Pages[0].Dimensions.Width;

            Rectangle rec = new(x, y, 20, hgt);
            rec.FillColor = RgbColor.Navy;
            rec.BorderColor = RgbColor.Navy;

            Rectangle bkRec = new(x, y, wdt, hgt);
            bkRec.FillColor = RgbColor.LightSkyBlue;
            bkRec.BorderColor = RgbColor.LightSkyBlue;

            tmp.Elements.Add(new Rectangle(x, y, wdt, hgt, RgbColor.LightSkyBlue, RgbColor.LightSkyBlue));
            tmp.Elements.Add(new Rectangle(x, y, 20, hgt, RgbColor.Navy, RgbColor.Navy));
            tmp.Elements.Add((new Image(Util.GetPath("Resources/Images/") + "DPDFLogo.png", x + 30, y + 5)));
            tmp.Elements.Add(new Label("Test.", 200, 300, 200, 0, Font.Helvetica, 90, RgbColor.Red));
            doc.StampTemplate = tmp;

            doc.Draw(Util.GetPath("Output/stamptemplate-out.pdf"));
        }

        private static void CreatePage(Document doc)
        {
            Page pg = new Page();
            HtmlArea frmHtmlArea = new(TextGenerator.Generate(), 0, 0, pg.Dimensions.Width - (pg.Dimensions.LeftMargin * 2), pg.Dimensions.Height - (pg.Dimensions.TopMargin * 2));
            pg.Elements.Add(frmHtmlArea);
            doc.Pages.Add(pg);
        }
    }
}
