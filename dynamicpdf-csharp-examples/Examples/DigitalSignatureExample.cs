
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Forms;

namespace DynamicPDFCoreSuite.Examples
{
    class DigitalSignatureExample
    {
        public static void Run()
        {
            ExampleOne();
            ExampleTwo();
        }

        public static void ExampleOne()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter);

            Signature signature = new Signature("SigField", 10, 10, 250, 100);
            page.Elements.Add(signature);
            document.Pages.Add(page);
            Certificate certificate = new Certificate(Util.GetPath("Resources/Data/JohnDoe.pfx"), "password");

            document.Sign("SigField", certificate);

            document.Draw(Util.GetPath("Output/signed-visible-output.pdf"));
        }

        public static void ExampleTwo()
        {
            Document document = new Document();
            Page page = new Page();

            document.Pages.Add(page);
            Certificate certificate = new Certificate(Util.GetPath("Resources/Data/JohnDoe.pfx"), "password");

            // Field name should not match any field names in the document 
            document.Sign("NonExistingField", certificate);
            document.Draw(Util.GetPath("Output/signed-invisible-output.pdf"));
        }

    }
}
