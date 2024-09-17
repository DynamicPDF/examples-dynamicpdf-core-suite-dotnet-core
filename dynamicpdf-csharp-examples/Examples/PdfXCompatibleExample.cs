using ceTe.DynamicPDF;


namespace DynamicPDFCoreSuite.Examples
{
    class PdfXCompatibleExample
    {
        public static void Run()
        {
            Document document = new Document();
            document.Title = "PDF/X-1a Document";
            document.PdfVersion = PdfVersion.v1_4;
            document.PdfXVersion = PdfXVersion.PDF_X_1a_2003;
            document.Pages.Add(new Page());
            IccProfile iccProfile = new IccProfile(Util.GetPath("Resources/Data/USWebCoatedSWOP.icc"));
            OutputIntent outputIntent = new OutputIntent("CGATS TR 001-1995 (SWOP)", "CGATS TR 001", "http://www.color.org", "U.S. Web Coated (SWOP) v2", iccProfile);
            document.OutputIntents.Add(outputIntent);
            document.Trapped = Trapped.False;


            document.Draw(Util.GetPath("Output/pdfx-output.pdf"));
        }
    }
}
