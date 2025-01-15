
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using DynamicPDFCoreSuite.Examples;
using System;

namespace dynamicpdf_csharp_examples.Examples
{
    class ExistingOutlinesExample
    {
        public static void Run()
        {
            ReadOutline();
            AddOutline();
            AddBookmark();
            AddBookmarkToExistingPage();
            ReplaceOutline();
            ModifyOutline();
        }

        public static void ReadOutline()
        {
            PdfDocument pdfDocument = new PdfDocument(Util.GetPath("Resources/PDFs/outline-example.pdf"));
            for (int i = 0; i < pdfDocument.Outlines.Count; i++)
            {
                PdfOutline outline = pdfDocument.Outlines[i];
                PrintOutline(outline);
            }
        }

        private static void PrintOutline(PdfOutline outline)
        {
            Console.WriteLine(outline.Text + ": " + outline.TargetPageNumber);

            if (outline.ChildOutlines.Count > 0)
            {
                for (int j = 0; j < outline.ChildOutlines.Count; j++)
                {
                    PrintOutline(outline.ChildOutlines[j]);
                }
            }
        }


        public static void AddOutline()
        {
            PdfDocument pdfDocument = new PdfDocument(Util.GetPath("Resources/PDFs/outline-example.pdf"));
            PdfOutline pdfOutline = pdfDocument.Outlines[0];
            MergeDocument document = new MergeDocument(pdfDocument);
            Outline outline1 = document.Outlines.Add("ChildA");
            Outline outline1A = outline1.ChildOutlines.Add("ChildA 1", new XYDestination(2, 0, 0));
            document.Draw(Util.GetPath("Output/add-to-outline-output.pdf"));
        }


        public static void ReplaceOutline()
        {
            PdfDocument pdfDocument = new PdfDocument(Util.GetPath("Resources/PDFs/outline-example.pdf"));
            PdfOutline pdfOutline = pdfDocument.Outlines[0];
            MergeOptions options = new MergeOptions();
            options.Outlines = false;
            MergeDocument document = new MergeDocument(pdfDocument, options);
            Outline root = document.Outlines.Add("Replaced-Outline1");
            Outline outline1A = root.ChildOutlines.Add("Replaced ChildA 1", new XYDestination(2, 0, 0));
            document.Draw(Util.GetPath("Output/modify-outline-output.pdf"));
        }


        public static void AddBookmark()
        {
            PdfDocument pdfDocument = new PdfDocument(Util.GetPath("Resources/PDFs/bookmark-example.pdf"));
            MergeDocument document = new MergeDocument(pdfDocument);
            Page addedPage = new Page(PageSize.Letter);
            document.Pages.Add(addedPage);
            addedPage.Elements.Add(new Bookmark("Added Bookmark", 0, 0));
            document.Draw(Util.GetPath("Output/add-to-bookmark-output.pdf"));
        }

        public static void AddBookmarkToExistingPage()
        {
            PdfDocument pdfDocument = new PdfDocument(Util.GetPath("Resources/PDFs/bookmark-example.pdf"));
            MergeDocument document = new MergeDocument(pdfDocument);
            Page page = document.Pages[3];
            page.Elements.Add(new Bookmark("Added Bookmark", 0, 0));
            document.Draw(Util.GetPath("Output/add-to-bookmark-existing-page-output.pdf"));
        }

        public static void ModifyOutline()
        {
            PdfDocument docA = new(Util.GetPath("Resources/PDFs/outline-a.pdf"));
            PdfDocument docB = new(Util.GetPath("Resources/PDFs/outline-b.pdf"));
            PdfOutline pdfOutB = docB.Outlines[1];

            MergeDocument document = new();
            document.Append(docA, MergeOptions.None);
            document.Append(docB, MergeOptions.None);

            Outline root = document.Outlines.Add("Merged Document");

            root.ChildOutlines.Add("DynamicPDF Website", new UrlAction("https://www.dynamicpdf.com/"));

            for (int i = 1; i <= document.Pages.Count; i++)
            {
                root.ChildOutlines.Add("Page " + i, new XYDestination(i, 0, 0));
            }

            document.Outlines.Add(pdfOutB.Text);

            for(int i = 0; i < pdfOutB.ChildOutlines.Count; i++)
            {
                int targetPage = docA.Pages.Count + pdfOutB.ChildOutlines[i].TargetPageNumber;
                document.Outlines[1].ChildOutlines.Add("Bookmark Page " + targetPage, new XYDestination(targetPage, 0,0));
                
            }
             
            document.Draw(Util.GetPath("Output/modify-outline-output.pdf"));

        }
    }
}
