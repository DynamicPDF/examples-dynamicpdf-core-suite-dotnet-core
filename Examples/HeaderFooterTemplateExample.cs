
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using DynamicPDFCoreSuite.Utility;

namespace DynamicPDFCoreSuite.Examples
{
    class HeaderFooterTemplateExample
    {
        public static void Run()
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page());

            HeaderFooterTemplate header = new HeaderFooterTemplate("Header text", "Footer text");
            HeaderFooterText leftText = new HeaderFooterText("Example Header");
            leftText.Font = Font.Helvetica;
            leftText.FontSize = 12;
            header.HeaderLeft = leftText;
            myDoc.Template = header;

            header.FooterLeft = header.FooterCenter;

            myDoc.Draw(Util.GetPath("Output/header-footer-template-out.pdf"));
        }
    }
}
