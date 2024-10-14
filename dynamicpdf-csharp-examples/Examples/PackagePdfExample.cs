using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class PackagePdfExample
    {
        public static void Run()
        {
            Document document = new Document();

            EmbeddedFile embeddedFile1 = new EmbeddedFile(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            EmbeddedFile embeddedFile2 = new EmbeddedFile(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            document.EmbeddedFiles.Add(embeddedFile1);
            document.EmbeddedFiles.Add(embeddedFile2);

            Page page = new Page();
            document.Pages.Add(page);

            document.Package = new DocumentPackage(AttachmentLayout.Detailed);
            document.Package.OrderBy = AttachmentListingOrderBy.Name;
            document.Package.AscendingOrder = false;

            page.Elements.Add(new Label("Cover Page", 0, 0, 512, 40, Font.Helvetica, 30, TextAlign.Center,  RgbColor.BlueViolet));
            
            document.Draw(Util.GetPath("Output/package-pdf-output.pdf"));
        }

    }
}
