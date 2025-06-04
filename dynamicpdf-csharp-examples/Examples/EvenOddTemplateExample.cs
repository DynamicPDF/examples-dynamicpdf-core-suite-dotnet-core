using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class EvenOddTemplateExample
    {

        public static void Run()
        {
            Simple();
            Documentation();
        }

        public static void Simple()
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page());
            myDoc.Pages.Add(new Page());
            myDoc.Pages.Add(new Page());
            EvenOddTemplate tmp = new EvenOddTemplate();
            tmp.EvenElements.Add(new Label("ODD", 0, 0, 200, 12));
            tmp.OddElements.Add(new Label("EVEN", 0, 0, 200, 12));
            myDoc.Template = tmp;
            myDoc.Draw(Util.GetPath("Output/simple-evenodd-out.pdf"));
        }

        public static void Documentation()
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page());
            myDoc.Pages.Add(new Page());
            myDoc.Pages.Add(new Page());
            myDoc.Pages.Add(new Page());
            EvenOddTemplate tmp = new EvenOddTemplate();
            tmp.EvenElements.Add(new PageNumberingLabel("%%SP%%  John Doe", 0, 0, 512, 12, Font.Helvetica, 12, TextAlign.Left));
            tmp.OddElements.Add(new PageNumberingLabel("The DynamicPDF Core Suite %%SP%%", 0, 0, 500, 12, Font.Helvetica, 12, TextAlign.Right));
            myDoc.Template = tmp;
            myDoc.Draw(Util.GetPath("Output/evenOddtemplateExample-out.pdf"));
        }
    }
}
