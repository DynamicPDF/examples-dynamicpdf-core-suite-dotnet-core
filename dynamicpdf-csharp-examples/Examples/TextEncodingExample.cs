using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;

namespace DynamicPDFCoreSuite.Examples
{
    class TextEncodingExample
    {

        public static void Run()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            string czech = "Tohle je textová zpráva, která říká: Ahoj, jak se máš?";
            Font fnt1 = new Helvetica(Encoder.CentralEurope);
            page.Elements.Add(new TextArea(czech, 0, 0, 300, 12, fnt1, 12));
            page.Elements.Add(new TextArea(czech, 0, 20, 300, 12, Font.Helvetica, 12));
            document.Draw(Util.GetPath("Output/text-encoding-exampleOne.pdf"));
        }

    }
}
