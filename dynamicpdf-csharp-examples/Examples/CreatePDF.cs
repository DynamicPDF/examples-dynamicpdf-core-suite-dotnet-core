using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class CreatePDF
    {
        public static void Run()
        {
            Document document = new Document();

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);
            
            string labelText = "Hello World...\nFrom DynamicPDF Core Suite for .NET\nDynamicPDF.com";
            Label label = new Label(labelText, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label);
            
            document.Draw(Util.GetPath("Output/CreatePDF.pdf"));
        }
    }
}
