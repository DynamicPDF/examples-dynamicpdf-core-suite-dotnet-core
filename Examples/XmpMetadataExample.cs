
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Xmp;
using System;
using System.IO;

namespace DynamicPDFCoreSuite.Examples
{
    class XmpMetadataExample
    {
        public static void Run()
        {
            BasicJobTicket();
            DublinCoreExample();
            PageTextSchemaExample();
            RightsManagementSchemaExample();
            BasicSchemaExample();



        }


        public static void BasicJobTicket()
        {
            Document document = new Document();

            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));

            XmpMetadata xmp = new XmpMetadata();
            BasicJobTicketSchema job = new BasicJobTicketSchema();
            job.JobRef.Add("MyCompany", "Xmp Test", new Uri("http://www.mydomain.com/"));
            job.JobRef.Add("MyProduct", "XMP Metadata", new Uri("http://www.mydomain.com/"));
            xmp.AddSchema(job);
            document.XmpMetadata = xmp;

            document.Draw(Util.GetPath("Output/xmp-basicjobticket-output.pdf"));
        }


        public static void DublinCoreExample()
        {
            Document document = new Document();

            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));

            XmpMetadata xmp = new XmpMetadata();

            DublinCoreSchema dc = xmp.DublinCore;
            dc.Contributors.Add("Abc");
            dc.Contributors.Add("Xyz");
            dc.Contributors.Add("Pqrs");
            dc.Coverage = "To test all the attributes of schema's provided";
            dc.Creators.Add("MyProduct");
            dc.Creators.Add("MyCompany");
            dc.Date.Add(DateTime.Now);
            dc.Description.AddLang("en-us", "XMP Schema's test");
            dc.Identifier = "First XMP pdf";
            dc.Publisher.Add("mydomain.com");
            dc.Publisher.Add("MyCompany");
            dc.Relation.Add("test pdf with xmp");
            dc.Rights.DefaultText = "US English";
            dc.Rights.AddLang("en-us", "All rights reserved 2012, MyCompany.");
            dc.Source = "XMP Project";
            dc.Subject.Add("eXtensible Metadata Platform");
            dc.Title.AddLang("en-us", "XMP");
            dc.Title.AddLang("it-it", "XMP - Piattaforma Estendible di Metadata");
            dc.Title.AddLang("du-du", "De hallo Wereld");
            dc.Title.AddLang("fr-fr", "XMP - Une Platforme Extensible pour les Métédonnées");
            dc.Title.AddLang("DE-DE", "ÄËßÜ Hallo Welt");

            document.XmpMetadata = xmp;

            document.Draw(Util.GetPath("Output/xmp-dublincore-output.pdf"));
        }

        public static void PageTextSchemaExample()
        {
            Document document = new Document();

            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));

            XmpMetadata xmp = new XmpMetadata();

            PagedTextSchema pt = new PagedTextSchema();
            xmp.AddSchema(pt);

            document.XmpMetadata = xmp;

            document.Draw(Util.GetPath("Output/xmp-pagetextschema-output.pdf"));
        }

        public static void RightsManagementSchemaExample()
        {
            Document document = new Document();

            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));

            XmpMetadata xmp = new XmpMetadata();

            RightsManagementSchema rm = new RightsManagementSchema();
            rm.Marked2 = CopyrightStatus.PublicDomain;
            rm.Owner.Add("Company Name");
            rm.UsageTerms.AddLang("en-us", "Contact MyCompany");
            xmp.AddSchema(rm);

            document.XmpMetadata = xmp;

            document.Draw(Util.GetPath("Output/xmp-rightsmanagementschema-output.pdf"));
        }

        public static void BasicSchemaExample()
        {
            Document document = new Document();

            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));

            XmpMetadata xmp = new XmpMetadata();

            BasicSchema bs = xmp.BasicSchema;
            bs.Advisory.Add("Date");
            bs.Advisory.Add("Contributors");
            bs.Nickname = "xyz";
            bs.Thumbnails.Add(106, 80, "JPEG", GetImage()); //imageData is byte array

            document.XmpMetadata = xmp;

            document.Draw(Util.GetPath("Output/basicschema-output.pdf"));
        }


        private static byte[] GetImage()
        {
            FileStream inFile = new FileStream(Util.GetPath("Resources/Images/DynamicPDF_top.gif"), FileMode.Open, FileAccess.Read);
            byte[] binaryData = new byte[inFile.Length];
            inFile.Read(binaryData, 0, (int)inFile.Length);
            inFile.Close();
            return binaryData;
        }


    }
}
