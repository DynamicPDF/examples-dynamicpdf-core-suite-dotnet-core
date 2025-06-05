
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using DynamicPDFCoreSuite.Examples;

namespace dynamicpdf_csharp_examples.Examples
{
    class ShapesExample
    {

        public static void Run()
        {
            AddLine();
            AddCircle();
            AddPath();
            AddRectange();
        }

        public static void AddLine()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            Line line = new Line(50, 50, 50, 400, 5, Grayscale.Black,
               LineStyle.Solid);
            line.Cap = LineCap.Round;
            page.Elements.Add(line);
            page.Elements.Add(new Line(60, 50, 150, 400, 2,
               RgbColor.Blue, LineStyle.DashLarge));
            document.Draw(Util.GetPath("Output/shape-line-example-output.pdf"));
        }

        public static void AddRectange()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            Rectangle rectangle = new Rectangle(50, 50, 200, 200,
               Grayscale.Black, RgbColor.Gray, 4, LineStyle.Solid);
            rectangle.CornerRadius = 10;
            page.Elements.Add(rectangle);
            document.Draw(Util.GetPath("Output/shape-rectangle-example-output.pdf"));
        }

        public static void AddCircle()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            Circle circle1 = new Circle(100, 100, 50, 100, Grayscale.Black, RgbColor.LightBlue,
                2, LineStyle.Solid);
            Circle circle2 = new Circle(150, 75, 50, 50, Grayscale.Black, RgbColor.Lime,
                2, LineStyle.Solid);
            page.Elements.Add(circle1);
            page.Elements.Add(circle2);
            document.Draw(Util.GetPath("Output/shape-circle-example-output.pdf"));
        }

        public static void AddPath()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            Path path = new Path(50, 150, RgbColor.DarkRed, RgbColor.LimeGreen,
                3, LineStyle.Solid, true);
            path.SubPaths.Add(new CurveSubPath(50, 400, 300, 150, -200, 400));
            path.SubPaths.Add(new LineSubPath(330, 450));
            path.SubPaths.Add(new CurveToSubPath(300, 120, 50, 300));
            path.SubPaths.Add(new CurveFromSubPath(150, 130, 200, -100));
            page.Elements.Add(path);
            document.Draw(Util.GetPath("Output/shape-path-example-output.pdf"));
        }

    }
}
