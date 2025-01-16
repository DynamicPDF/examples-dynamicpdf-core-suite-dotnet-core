using ceTe.DynamicPDF;

namespace DynamicPDFCoreSuite.Examples
{
    class CustomPageElementExample
    {

        public static void Run()
        {
            PolygonExample();
            TextAreaExample();
        }

        public static void PolygonExample()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            float[] xCoordinates = { 10, 50, 150, 350 };
            float[] yCoordinates = { 20, 250, 100, 10 };

            Polygon poly = new Polygon(xCoordinates, yCoordinates);
            poly.BorderColor = RgbColor.Red;
            poly.BorderWidth = 3;
            poly.FillColor = RgbColor.Blue;
            poly.BorderStyle = LineStyle.Solid;

            page.Elements.Add(poly);

            Page page1 = new Page(PageSize.Letter);
            CustomElement ce = new CustomElement("This is Test", 0, 0, 500, 50);
            ce.FontSize = 62;
            page1.Elements.Add(ce);

            document.Pages.Add(page1);



            document.Draw(Util.GetPath("Output/custom-page-element-poly-output.pdf"));
        }

        public static void TextAreaExample()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            CustomElement ce = new CustomElement("A custom text area", 0, 0, 500, 50);
            ce.FontSize = 62;
            document.Pages[0].Elements.Add(ce);
            document.Pages.Add(page);
            document.Draw(Util.GetPath("Output/custom-page-element-textarea-output.pdf"));
        }

    }
}
