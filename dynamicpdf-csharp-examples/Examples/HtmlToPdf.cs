
using ceTe.DynamicPDF;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    class HtmlToPdf
    {

        public static void Run()
        {
            PageInfo layoutPage = new PageInfo(PageSize.A4, PageOrientation.Portrait);
            Uri uri = new Uri(@"https://www.dynamicpdf.com/docs/dotnet/dynamic-pdf-core-suite-welcome");

            HtmlLayout html = new HtmlLayout(uri, layoutPage);

            html.Header.Center.Text = "%%PR%%%%SP%% of %%ST%%";
            html.Header.Center.HasPageNumbers = true;
            html.Header.Center.Width = 200;

            html.Footer.Center.Text = "%%PR%%%%SP(A)%% of %%ST(B)%%";
            html.Footer.Center.HasPageNumbers = true;
            html.Footer.Center.Width = 200;

            Document document = html.Layout();
            document.Draw(Util.GetPath("Output/html-to-pdf-output.pdf"));
        }

    }
}
