using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Xmp;

namespace DynamicPDFCoreSuite.Examples
{
    class PdfACompatibleExample
    {

        public static void Run()
        {
            ExampleOne();
            ExampleTwo();
        }

        public static void ExampleOne()
        {
            Document document = new Document();
            document.Title = "PDF/A1 Document";
 
            XmpMetadata xmp = new XmpMetadata();

            PdfASchema pdfaschema = new PdfASchema(PdfAStandard.PDF_A_1a_2005);
            xmp.AddSchema(pdfaschema);

            DublinCoreSchema dc = xmp.DublinCore;
            dc.Title.DefaultText = document.Title;
            dc.Description.DefaultText = document.Subject;
            dc.Creators.Add(document.Author);
            dc.Title.AddLang("en-us", "PDF/A1 Document");
            document.XmpMetadata = xmp;

            IccProfile iccProfile = new IccProfile(Util.GetPath("Resources/Data/sRGB_IEC61966-2-1_noBPC.icc"));
            OutputIntent outputIntents = new OutputIntent("", "IEC 61966-2.1 Default RGB colour space - sRGB 1 ", "http://www.color.org", "sRGB IEC61966-2.1 1", iccProfile);
            outputIntents.Version = OutputIntentVersion.PDF_A;
            document.OutputIntents.Add(outputIntents);

            string text = "PDF/A (Archiving) specifically targets PDF documents that need to be preserved long term.";
            Label label = new Label(text, 0, 0, 504, 100, Font.Courier, 18, TextAlign.Center, RgbColor.BlueViolet);

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            page.Elements.Add(label);
            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/pdfa-one-output.pdf"));
        }

        public static void ExampleTwo()
        {
            Document document = new Document();
            document.Title = "PDF/A1 Document";
      
            XmpMetadata xmp = new XmpMetadata();

            PdfASchema pdfaschema = new PdfASchema(PdfAStandard.PdfA3a);
            xmp.AddSchema(pdfaschema);

            DublinCoreSchema dc = xmp.DublinCore;
            dc.Title.DefaultText = document.Title;
            dc.Description.DefaultText = document.Subject;
            dc.Creators.Add(document.Author);
            dc.Title.AddLang("en-us", "PDF/A1 Document");
            document.XmpMetadata = xmp;

            IccProfile iccProfile = new IccProfile(Util.GetPath("Resources/Data/USWebCoatedSWOP.icc"));
            OutputIntent outputIntent = new OutputIntent("CGATS TR 001-1995 (SWOP)", "CGATS TR 001", "http://www.color.org", "U.S. Web Coated (SWOP) v2", iccProfile);

            outputIntent.Version = OutputIntentVersion.PDF_A;
            document.OutputIntents.Add(outputIntent);

            EmbeddedFile embeddedFile1 = new EmbeddedFile(Util.GetPath("Resources/Data/HelloWorldExcel.xls"));
            embeddedFile1.Relation = EmbeddedFileRelation.Data;
            embeddedFile1.MimeType = "application/excel";
            document.EmbeddedFiles.Add(embeddedFile1);

            EmbeddedFile embeddedFile2 = new EmbeddedFile(Util.GetPath("Resources/Data/Simple.xml"));
            embeddedFile2.Relation = EmbeddedFileRelation.Source;
            embeddedFile2.MimeType = "application/xml";
            document.EmbeddedFiles.Add(embeddedFile2);

            string text = "PDF/A (Archiving) specifically targets PDF documents that need to be preserved long term.";
           
            Label label = new Label(text, 0, 0, 504, 100, Font.Courier, 18, TextAlign.Center, RgbColor.BlueViolet);

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            page.Elements.Add(label);
            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/pdfa-two-output.pdf"));
        }

    }
}
