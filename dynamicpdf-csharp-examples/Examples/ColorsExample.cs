using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class ColorsExample
    {

        public static void Run()
        {
            Document document = new();
            Page page = new Page(PageSize.Letter);
            document.Pages.Add(page);

            CmykColor cmykColor1 = new CmykColor(0.5f, 0.3f, 0.6f, 0.0f);
            CmykColor cmykColor2 = new CmykColor(0.3f, 0.5f, 0.6f, 0.2f);
            page.Elements.Add(new Circle(10, 100, 40, cmykColor1, cmykColor2));
            page.Elements.Add(new Circle(150, 100, 40, CmykColor.Black, CmykColor.Red));

            RgbColor rgbColor1 = new RgbColor(0.5f, 0.3f, 0.6f);
            RgbColor rgbColor2 = new RgbColor(0.3f, 0.5f, 0.2f);
            page.Elements.Add(new Circle(10, 200, 40, rgbColor1, rgbColor2));
            page.Elements.Add(new Circle(150, 200, 40, RgbColor.Black, RgbColor.Red));

            WebColor webColor1 = new WebColor("#FF0080");
            WebColor webColor2 = new WebColor("aqua");
            page.Elements.Add(new Circle(10, 300, 40, webColor1, webColor2));


            Grayscale grayscale1 = new Grayscale(0.3f);
            Grayscale grayscale2 = new Grayscale(0.6f);
            page.Elements.Add(new Circle(10, 400, 40, grayscale1, grayscale2));
            page.Elements.Add(new Circle(150, 400, 40, Grayscale.White, Grayscale.Black));

            Gradient gradient1 = new Gradient(0, 0, 200, 200, Grayscale.White, Grayscale.Black);
            Gradient gradient2 = new Gradient(50, 0, 250, 200, RgbColor.YellowGreen, RgbColor.DarkMagenta);
            page.Elements.Add(new Circle(10, 500, 40, gradient1, gradient1));
            page.Elements.Add(new Circle(150, 500, 40, gradient2, gradient2));


            AutoGradient autogradient1 = new AutoGradient(90.0f, CmykColor.Blue, CmykColor.Red);
            AutoGradient autogradient2 = new AutoGradient(90.0f, CmykColor.Red, CmykColor.Blue);
            page.Elements.Add(new Circle(10, 600, 40, autogradient1, autogradient1));
            page.Elements.Add(new Circle(150, 600, 40, autogradient2, autogradient2));

            CmykColor alternateColor = new CmykColor(0.2f, 0.9f, 0.5f, 0.2f);
            SpotColorInk ink = new SpotColorInk("My Red", alternateColor);
            SpotColor tint100 = new SpotColor(1, ink);
            SpotColor tint50 = new SpotColor(0.5f, ink);
            page.Elements.Add(new Circle(10, 700, 40, tint50, tint50));
            page.Elements.Add(new Circle(150, 700, 40, tint100, tint100));


            document.Draw(Util.GetPath("Output/color-output.pdf"));
        }

    }
}
