using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class AddNewContentExample
    {
        public static void Run()
        {
            AddContent();
            AddPage();
        }

        public static void AddContent()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentC.pdf"));
            Page page = document.Pages[0];
            page.Elements.Add(new Label("New Content", 0, 0, 512, 12));
            document.Draw(Util.GetPath("Output/add-content-output.pdf"));
        }


        public static void AddPage()
        {
            MergeDocument document = new MergeDocument();
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait);
            page.Elements.Add(new Label("Cover Page", 0, 0, 512, 12));
            document.Pages.Add(page);
            document.Append(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            document.Draw(Util.GetPath("Output/add-page-output.pdf"));
        }
    }
}
