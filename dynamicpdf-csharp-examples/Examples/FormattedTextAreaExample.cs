
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using DynamicPDFCoreSuite.Examples;
using System.IO;

namespace DynamicPDFCoreSuite.Examples
{
    public class FormattedTextAreaExample
    {
        public static void Run()
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            string txt = File.ReadAllText(Util.GetPath("Resources/Data/simple-fta.txt"));

            float pgWdth = doc.Pages[0].Dimensions.Width - doc.Pages[0].Dimensions.LeftMargin * 2;

            FormattedTextAreaStyle style = new(FontFamily.Helvetica, 12, false);

            FormattedTextArea fta = new(txt, 0, 0, pgWdth, 0, style);
            fta.Height = fta.GetRequiredHeight();

            doc.Pages[0].Elements.Add(fta);


            doc.Draw(Util.GetPath("Output/formatted-text-area-out.pdf"));
        }
    }
}
