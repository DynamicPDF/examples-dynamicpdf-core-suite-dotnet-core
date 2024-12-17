using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class PackagePdfExample
    {
        public static void Run()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            EmbeddedFile embeddedFile1 = new EmbeddedFile(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            EmbeddedFile embeddedFile2 = new EmbeddedFile(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            EmbeddedFile embeddedFile3 = new EmbeddedFile(Util.GetPath("Resources/Images/DPDFLogo.png"));
            EmbeddedFile embeddedFile4 = new EmbeddedFile(Util.GetPath("Resources/Data/Doc1.docx"));
            document.EmbeddedFiles.Add(embeddedFile1);
            document.EmbeddedFiles.Add(embeddedFile2);
            document.EmbeddedFiles.Add(embeddedFile3);
            document.EmbeddedFiles.Add(embeddedFile4);


            document.Package = new DocumentPackage(AttachmentLayout.Tile);
            document.Package.OrderBy = AttachmentListingOrderBy.Name;
            document.Package.AscendingOrder = false;

            page.Elements.Add(new Label("Cover Page", 0, 0, 512, 40, Font.Helvetica, 30, TextAlign.Center,  RgbColor.BlueViolet));
            
            document.Draw(Util.GetPath("Output/package-pdf-output.pdf"));
        }

    }
}
