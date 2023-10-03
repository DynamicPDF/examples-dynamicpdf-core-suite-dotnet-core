using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using System.Text;
using Encoder = ceTe.DynamicPDF.Text.Encoder;

namespace DynamicPDFCoreSuite.Examples
{
    class TextEncodingExample
    {

        public static void Run()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            Font centralEuropeHelveticaFont = new Helvetica(Encoder.CentralEurope);
            page.Elements.Add(new TextArea("Text", 0, 0, 200, 12, centralEuropeHelveticaFont, 12));

            document.Draw(Util.GetPath("Output/text-encoding-exampleOne-pdf"));
        }

    }
}
