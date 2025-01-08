using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    public class AddNewContentExample
    {
        public static void Run()
        {
            AddContent();
            AddPage();
            ImportPage();
            ImportPageAddElements();
            InsertPage();
            ImportPageBackgroundElements();
            ImportedPagePlacing();
            ImportedPageClipping();
        }

        public static void ImportedPageClipping()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Tabloid, PageOrientation.Landscape);
            ImportedPageArea importedPageArea = new ImportedPageArea(Util.GetPath("Resources/PDFs/DocumentC.pdf"), 1, 0, 0, 0.5f);
            importedPageArea.Contents.ClipLeft = 100;
            importedPageArea.Contents.ClipTop = 100;
            importedPageArea.Contents.ClipRight = 100;
            importedPageArea.Contents.ClipBottom = 100;
            page.Elements.Add(importedPageArea);
            document.Pages.Add(page);
            document.Draw(Util.GetPath("Output/import-page-clipping-output.pdf"));
        }

        public static void ImportedPagePlacing()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Tabloid, PageOrientation.Landscape);
            page.Elements.Add(new ImportedPageData(Util.GetPath("Resources/PDFs/doc-text.pdf"), 1, -306, 0));
            page.Elements.Add(new ImportedPageData(Util.GetPath("Resources/PDFs/DocumentA.pdf"), 2, 306, 0));
            document.Pages.Add(page);
            document.Draw(Util.GetPath("Output/import-page-placing-output.pdf"));
        }


        public static void ImportPageBackgroundElements()
        {
            MergeDocument document = new MergeDocument();
            ImportedPage importedPage = new ImportedPage(Util.GetPath("Resources/PDFs/doc-text.pdf"), 1);
            Image image = new Image(Util.GetPath("Resources/images/large-logo.png"), 40, 150, .5F);
            importedPage.BackgroundElements.Add(image);
            Label lbl = new Label("Added Image", 100, 600, 400, 0);
            lbl.FontSize = 56;
            lbl.TextColor = RgbColor.Red;
            importedPage.BackgroundElements.Add(lbl);
            document.Pages.Add(importedPage);
            document.Draw(Util.GetPath("Output/import-background-elements-output.pdf"));
        }

        public static void AddContent()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentC.pdf"));
            Page page = document.Pages[1];
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

        public static void InsertPage()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait);
            page.Elements.Add(new Label("Cover Page", 0, 0, 512, 12));
            document.Pages.Insert(1, page);
            document.Draw(Util.GetPath("Output/insert-page-output.pdf"));
        }

        public static void ImportPage()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentC.pdf"));
            ImportedPage page = new ImportedPage(Util.GetPath("Resources/PDFs/DocumentA.pdf"), 1);
            document.Pages.Insert(0, page);
            document.Draw(Util.GetPath("Output/import-page-output.pdf"));
        }

        public static void ImportPageAddElements()
        {
            MergeDocument document = new MergeDocument();
            ImportedPage page = new ImportedPage(Util.GetPath("Resources/PDFs/DocumentC.pdf"), 1);
            page.Elements.Add(new Image(Util.GetPath("Resources/images/bluerectangle.png"), 300, 175, 1));
            Label lbl = new Label("Label Text", 50, 75, 200, 12);
            lbl.FontSize = 72;
            lbl.TextColor = RgbColor.White;
            lbl.TextOutlineColor = RgbColor.Red;
            lbl.TextOutlineWidth = 3;
            page.Elements.Add(lbl);
            Rectangle rec = new Rectangle(10, 50, 250, 500, RgbColor.Black, RgbColor.DarkGreen);
            page.BackgroundElements.Add(rec);
            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/import-page-elements-output.pdf"));
        }


    }
}
