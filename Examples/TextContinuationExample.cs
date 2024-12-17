using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using DynamicPDFCoreSuite.Utility;

namespace DynamicPDFCoreSuite.Examples
{
    public class TextContinuationExample
    {
        public static void Run()
        {
            Document document = new Document();

            TextArea textArea = new(TextGenerator.GenerateLargeTextDoc(), 0, 0, 512, 692,
                Font.Helvetica, 14);

            do
            {
                Page page = new Page();
                page.Elements.Add(textArea);
                document.Pages.Add(page);
                textArea = textArea.GetOverflowTextArea();

            } while (textArea != null);
                      
            document.Draw(Util.GetPath("Output/text-area-overflow-example.pdf"));
        }
    }
}
