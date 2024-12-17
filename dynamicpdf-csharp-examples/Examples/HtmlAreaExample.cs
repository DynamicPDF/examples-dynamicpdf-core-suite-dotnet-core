using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Html;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    class HtmlAreaExample
    {
        public static void Run()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter);
            document.Pages.Add(page);

            float hgt = page.Dimensions.Height - page.Dimensions.TopMargin * 2;
            float wdth = page.Dimensions.Width - page.Dimensions.LeftMargin * 2;

            Uri filePath = new Uri(Util.GetPath("Resources/HTML/simple.html"));

            HtmlArea htmlArea = new HtmlArea(filePath, 0, 0, wdth, hgt);
            
            page.Elements.Add(htmlArea);

            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/html-area-output.pdf"));
        }

    }
}
