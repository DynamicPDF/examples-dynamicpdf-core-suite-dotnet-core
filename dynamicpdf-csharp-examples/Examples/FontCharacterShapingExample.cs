
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using DynamicPDFCoreSuite.Examples;

namespace DynamicPDFCoreSuite.Examples
{
    public class FontCharacterShapingExample
    {

        public static void Run()
        {
            // Create a PDF Document
            Document document = new Document();
            // Create an OpenTypeFont object with useCharacterShaping parameter set to true. 
            OpenTypeFont openTypeFont = new OpenTypeFont(Util.GetPath("Resources/Data/cnr.otf"));
            // Create a page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);
            // Create and add a TextArea that uses the OpenTypeFont object.  
            TextArea area = new TextArea("Text requiring character shaping", 0, 0, 300, 30, openTypeFont, 18);
            page.Elements.Add(area);
            // Save the PDF
            document.Draw(Util.GetPath("Output/font-charshaping-output.pdf"));
        }

    }
}
