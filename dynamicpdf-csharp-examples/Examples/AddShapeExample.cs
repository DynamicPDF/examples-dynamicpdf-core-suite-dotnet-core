using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class AddShapeExample
    {
        public static void Run()
        {
            AddCircle();
            AddRectangle();
            AddLine();
            AddPath();
        }

        public static void AddCircle()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            Circle circle1 = new Circle(100, 100, 50, 100, Grayscale.Black, RgbColor.OrangeRed, 2, LineStyle.Solid);

            page.Elements.Add(circle1);

            document.Draw(Util.GetPath("Output/circle-output.pdf"));
        }

        public static void AddRectangle()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            Rectangle rectangle = new Rectangle(10, 10, 400, 300, RgbColor.Red, RgbColor.Navy);
            page.Elements.Add(rectangle);

            document.Draw(Util.GetPath("Output/rectangle-output.pdf"));
        }

        public static void AddLine()
        {
            Document document = new();
            Page page = new Page();
            document.Pages.Add(page);
            Line line = new(150, 0, 150, 300);
            line.Color = RgbColor.Navy;
            line.Width = 10;
            line.Cap = LineCap.Butt;
            page.Elements.Add(line);
            document.Draw(Util.GetPath("Output/line-output.pdf"));
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
