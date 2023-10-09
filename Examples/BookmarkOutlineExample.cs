using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPDFCoreSuite.Examples
{
    class BookmarkOutlineExample
    {
        public static void Run()
        {
            BookMarkExample();
            OutlineExample();
        }

        public static void BookMarkExample()
        {
            Document document = new Document();
            Page page1 = new Page(PageSize.Letter);
            Page page2 = new Page(PageSize.Letter);
            Page page3 = new Page(PageSize.Letter);

            Outline parentOutline = document.Outlines.Add("Parent Outline");

            page1.Elements.Add(new Bookmark("Top level bookmark to page 1", 0, 0));

            page1.Elements.Add(new Bookmark("Bookmark to page 1", 0, 0, parentOutline));
            page2.Elements.Add(new Bookmark("Bookmark to page 2", 0, 0, parentOutline));
            page3.Elements.Add(new Bookmark("Bookmark to page 3", 0, 0, parentOutline));

            document.Pages.Add(page1);
            document.Pages.Add(page2);
            document.Pages.Add(page3);

            document.Draw(Util.GetPath("Output/bookmark-example.pdf"));
        }

        public static void OutlineExample()
        {
            Document document = new Document();
            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));

            Outline outline1 = document.Outlines.Add("Outline1");
            outline1.Style = TextStyle.Bold;
            outline1.Color = new RgbColor(1.0f, 0.0f, 0.0f);

            Outline outline1A = outline1.ChildOutlines.Add("Outline1A", new ZoomDestination(2, PageZoom.FitPage));
            outline1A.Expanded = false;
            Outline outline1A1 = outline1A.ChildOutlines.Add("Outline1A1", new XYDestination(2, 0, 0));
            Outline outline1A2 = outline1A.ChildOutlines.Add("Outline1A2", new ZoomDestination(2, PageZoom.FitHeight));
            Outline outline1B = outline1.ChildOutlines.Add("Outline1B", new ZoomDestination(2, PageZoom.FitWidth));

            Outline outline2 = document.Outlines.Add("Outline2", new XYDestination(3, 0, 300));
            Outline outline2A = outline2.ChildOutlines.Add("Outline2A");

            document.Draw(Util.GetPath("Output/outlinek-example.pdf"));
        }
    }
}
