using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPDFCoreSuite.Examples
{
    class HtmlAreaExample
    {
        public static void Run()
        {
            Document document = new Document();

            Uri filePath = new Uri(Util.GetPath("Resources/HTML/example.html"));

            HtmlArea htmlArea = new HtmlArea(filePath, 0, 0, 500, 600);
            Page page = new Page();
            page.Elements.Add(htmlArea);

            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/html-area-output.pdf"));
        }

    }
}
