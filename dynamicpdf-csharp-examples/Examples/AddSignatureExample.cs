using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Forms;


namespace DynamicPDFCoreSuite.Examples
{
    class AddSignatureExample
    {

        public static void Run()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter);

            Signature signature = new Signature("MySigField", 10, 10, 300, 100);
            signature.FullPanel.SetImage(Util.GetPath("Resources/Images/DynamicPDF_top.gif"));
            signature.LeftPanel.TextColor = RgbColor.Red;
            signature.Font = Font.TimesRoman;

            page.Elements.Add(signature);

            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/add-signature-example.pdf"));
        }


    }
}
