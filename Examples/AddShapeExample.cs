

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class AddShapeExample
    {
        public static void Run()
        {
            AddCircle();
            AddPath();
        }

        public static void AddCircle()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            Circle circle1 = new Circle(100, 100, 50, 100, Grayscale.Black, RgbColor.OrangeRed, 2, LineStyle.Solid);
            Circle circle2 = new Circle(150, 75, 50, 50, Grayscale.Black, RgbColor.Lime, 2, LineStyle.Solid);

            page.Elements.Add(circle1);
            page.Elements.Add(circle2);

            document.Draw(Util.GetPath("Output/circle-output.pdf"));
        }

        public static void AddPath()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            Path path = new Path(50, 150, RgbColor.Blue, RgbColor.Yellow, 3, LineStyle.Solid, true);

            path.SubPaths.Add(new CurveSubPath(50, 400, 300, 150, -200, 400));
            path.SubPaths.Add(new LineSubPath(300, 400));
            path.SubPaths.Add(new CurveToSubPath(300, 150, 50, 300));
            path.SubPaths.Add(new CurveFromSubPath(150, 100, 200, -100));

            page.Elements.Add(path);

            document.Draw(Util.GetPath("Output/path-output.pdf"));
        }
    }
}
