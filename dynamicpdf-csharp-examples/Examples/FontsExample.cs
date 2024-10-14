
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;

namespace DynamicPDFCoreSuite.Examples
{
    class FontsExample
    {
        public static void Run()
        {
            ExampleOne();
            ExampleTwo();

        }

        public static void ExampleOne()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            // Create a OpenType font class.
            OpenTypeFont openTypeFont = new OpenTypeFont(Util.GetPath("Resources/Data/cnr.otf"));
            // Use the OpenType font in a text area Page Element. 
            page.Elements.Add(new TextArea("Text", 0, 0, 200, 12, openTypeFont, 12));

            document.Draw(Util.GetPath("Output/fonts-example-one.pdf"));
        }


        public static void ExampleTwo()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            page.Elements.Add(new TextArea("CJK Text", 0, 0, 200, 12, Font.HeiseiKakuGothicW5, 16));

            document.Draw(Util.GetPath("Output/fonts_example_two.pdf"));
        }

    }
}
