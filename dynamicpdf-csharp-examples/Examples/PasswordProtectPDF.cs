using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Cryptography;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class PasswordProtectPDF
    {
        public static void Run()
        {
            Generator();
            Merger();
        }

        public static void Generator()
        {
            Document document = new Document();

            Page page = new Page();
            page.Elements.Add(new Label("Protected", 0, 0, 100, 15));
            document.Pages.Add(page);

            Aes256Security security = new Aes256Security("OwnerPassword", "UserPassword");
            document.Security = security;

            document.Draw("PasswordProtectPDFGenerator.pdf");
            document.Draw(Util.GetPath("Output/PasswordProtectNewPDF.pdf"));

        }

        public static void Merger()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));

            Aes256Security security = new Aes256Security("OwnerPassword", "UserPassword");
            document.Security = security;

            document.Draw("PasswordProtectPDFMerger.pdf");
            document.Draw(Util.GetPath("Output/PasswordProtectExistingPDF.pdf"));

        }
    }
}
