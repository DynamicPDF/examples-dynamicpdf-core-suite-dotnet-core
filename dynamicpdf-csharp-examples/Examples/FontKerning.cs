
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;

namespace DynamicPDFCoreSuite.Examples
{
    class FontKerning
    {
        public static void Run()
        {
            Document document = new Document();
            Page page = new Page();
            string text = "To and WA are examples of when kerning would be used.";
            TextArea textArea = new TextArea(text, 10, 10, 400, 700, Font.TimesRoman);

            textArea.KerningEnabled = true;
            KerningValues kernValues = textArea.GetKerningValues();

            for (int i = 0; i < kernValues.Spacing.Length; i++)
            {
                kernValues.Spacing[i] = (short)(kernValues.Spacing[i] - 400);
            }

            page.Elements.Add(textArea);
            document.Pages.Add(page);
            document.Draw(Util.GetPath("Output/fontkerning-output.pdf"));
        }

    }
}
