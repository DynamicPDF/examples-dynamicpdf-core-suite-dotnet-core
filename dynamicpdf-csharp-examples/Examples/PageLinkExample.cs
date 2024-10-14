using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class PageLinkExample
    {
        public static void Run()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            string text = "This is a link to mydomain.com";
            Font font = Font.Helvetica;

            Label label = new Label(text, 50, 50, 400, 20, font, 18, RgbColor.Blue);
            label.Underline = true;


            UrlAction action = new UrlAction("http://www.mydomain.com");
            Link link = new Link(50, 50, font.GetTextWidth(text, 18), 20, action);

            page.Elements.Add(label);
            page.Elements.Add(link);

            document.Draw(Util.GetPath("Output/page-link-output.pdf"));
        }

    }
}
