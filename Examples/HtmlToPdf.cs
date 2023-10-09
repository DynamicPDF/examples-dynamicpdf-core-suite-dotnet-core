using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Conversion;

namespace DynamicPDFCoreSuite.Examples
{
    class HtmlToPdf
    {
        public static void Run()
        {
            Example();
            ConverterExample();
        }

        public static void Example()
        {
            PageInfo layoutPage = new PageInfo(ceTe.DynamicPDF.PageSize.A4, ceTe.DynamicPDF.PageOrientation.Portrait);
            Uri uri = new Uri("http://www.google.com");

            HtmlLayout html = new HtmlLayout(uri, layoutPage);

            html.Header.Center.Text = "%%PR%%%%SP%% of %%ST%%";
            html.Header.Center.HasPageNumbers = true;
            html.Header.Center.Width = 200;

            html.Footer.Center.Text = "%%PR%%%%SP(A)%% of %%ST(B)%%";
            html.Footer.Center.HasPageNumbers = true;
            html.Footer.Center.Width = 200;

            Document document = html.Layout();

            document.Draw(Util.GetPath("Output/HtmlToPdf.pdf"));
        }

        public static void ConverterExample()
        {
            HtmlConversionOptions options = new HtmlConversionOptions(false);

            HtmlConverter htmlConverter = new HtmlConverter(new Uri(@"http://en.wikipedia.org"), options);

            htmlConverter.Convert(Util.GetPath("Output/HtmlToPDF_output.pdf"));
        }

    }
}
