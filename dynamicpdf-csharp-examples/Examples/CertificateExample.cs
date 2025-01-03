﻿using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Forms;

namespace DynamicPDFCoreSuite.Examples
{
    public class CertificateExample
    {

        public static void Run()
        {
            Visible();
            InVisible();
        }


        public static void Visible()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter);

            //Create & add Signature Form Field
            Signature signature = new Signature("SigField", 10, 10, 250, 100);
            page.Elements.Add(signature);
            document.Pages.Add(page);
            Certificate certificate = new Certificate(Util.GetPath("Resources/Data/JohnDoe.pfx"), "password");

            // Field name should be one of the signature field name 
            document.Certify("SigField", certificate, CertifyingPermission.NoChangesAllowed);

            document.Draw(Util.GetPath("Output/certificate-visible-output.pdf"));
        }

        public static void InVisible()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter);
            document.Pages.Add(page);

            Certificate certificate = new Certificate(Util.GetPath("Resources/Data/JohnDoe.pfx"), "password");

            document.Certify("NonExistingField", certificate, CertifyingPermission.NoChangesAllowed);

            document.Draw(Util.GetPath("Output/certificate-invisible-output.pdf"));
        }

    }
}
