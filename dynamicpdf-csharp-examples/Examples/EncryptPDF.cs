using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Cryptography;
using ceTe.DynamicPDF.Merger;

namespace DynamicPDFCoreSuite.Examples
{
    class EncryptPDF
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
            document.Pages.Add(page);
            
            Aes256Security security = new Aes256Security("OwnerPassword", "UserPassword");
            security.AllowAccessibility = true;
            security.AllowFormFilling = false;
            document.Security = security;
            document.Draw(Util.GetPath("Output/encryptNewPDF.pdf"));
        }

        public static void Merger()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            
            Aes256Security security = new Aes256Security("OwnerPassword", "UserPassword");
            security.AllowCopy = false;
            security.AllowPrint = false;
            document.Security = security;
            
            document.Draw(Util.GetPath("Output/encryptExistingPDF.pdf"));
        }
    }
}
