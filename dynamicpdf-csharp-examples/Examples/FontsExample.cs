
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;

namespace DynamicPDFCoreSuite.Examples
{
    class FontsExample
    {
        public static void Run()
        {
            OpenTypeFontExample();
            CJKExample();
            GoogleFontsExample();
            EncodingExample();

        }

        public static void EncodingExample()
        {
            Document document = new();
            document.Pages.Add(new Page(PageSize.Letter));
                      
            Font centralEuropeHelveticaFont = new Helvetica(Encoder.CentralEurope);

            Label lbl = new("čárka nad písmenem, silný přízvuk", 0, 0, 200, 12, centralEuropeHelveticaFont, 12);
            Label lbl2 = new("čárka nad písmenem, silný přízvuk", 0, 100, 300, 0, Font.Helvetica, 12);
           

            document.Pages[0].Elements.Add(lbl);
            document.Pages[0].Elements.Add(lbl2);

            document.Draw(Util.GetPath("Output/encoding-font-example-one.pdf"));
        }


        public static void OpenTypeFontExample()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            // Create a OpenType font class.
            OpenTypeFont openTypeFont = new OpenTypeFont(Util.GetPath("Resources/Data/cnr.otf"));
            // Use the OpenType font in a text area Page Element. 
            page.Elements.Add(new TextArea("Text", 0, 0, 200, 12, openTypeFont, 12));

            document.Draw(Util.GetPath("Output/opentype-font-example-one.pdf"));
        }

        public static void GoogleFontsExample()
        {
            Document document = new();
            document.Pages.Add(new Page(PageSize.Letter));

            GoogleFont googleFont = Font.Google("Roboto", false, false);


            Label lbl = new Label("A Google Font Example.", 10, 10, 150, 50, googleFont, 22);
            document.Pages[0].Elements.Add(lbl);

            document.Draw(Util.GetPath("Output/googlefont-font-example-one.pdf"));
        }


        public static void CJKExample()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            page.Elements.Add(new TextArea("CJK Text", 0, 0, 200, 12, Font.HeiseiKakuGothicW5, 16));

            document.Draw(Util.GetPath("Output/cjk-font-example-one.pdf"));
        }

    }
}
