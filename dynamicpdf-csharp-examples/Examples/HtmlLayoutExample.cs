using ceTe.DynamicPDF;
using System.IO;


namespace DynamicPDFCoreSuite.Examples
{
    public class HtmlLayoutExample
    {
        public static void Run()
        {
            PageInfo layoutPage = new PageInfo(PageSize.A4, PageOrientation.Portrait);
            string txt = File.ReadAllText(Util.GetPath("Resources/HTML/example.html"));
            HtmlLayout html = new HtmlLayout(txt, layoutPage);
            html.Header.Center.Text = "%%PR%%%%SP%% of %%ST%%";
            html.Header.Center.HasPageNumbers = true;
            html.Header.Center.Width = 200;
            html.Footer.Center.Text = "%%PR%%%%SP(A)%% of %%ST(B)%%";
            html.Footer.Center.HasPageNumbers = true;
            html.Footer.Center.Width = 200;

            Document doc = html.Layout();

            doc.Draw(Util.GetPath("Output/html-layout-out.pdf"));
        }
    }
}
