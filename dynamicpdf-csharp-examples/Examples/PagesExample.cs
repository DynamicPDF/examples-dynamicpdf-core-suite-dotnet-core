

using ceTe.DynamicPDF;

namespace DynamicPDFCoreSuite.Examples
{
    public class PagesExample
    {
        public static void Run()
        {
            Document myDoc = new();

            myDoc.Pages.Add(new Page(PageSize.Legal));
            myDoc.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape, 25));

            PageDimensions pgDim = new(PageSize.Letter, PageOrientation.Portrait);
            pgDim.BottomMargin = 50;
            pgDim.TopMargin = 50;
            pgDim.LeftMargin = 35;
            pgDim.RightMargin = 35;

            myDoc.Pages.Add(new Page(pgDim));

            myDoc.Pages.Add(new Page(100, 200));

            myDoc.Draw(Util.GetPath("Output/pages-output.pdf"));



        }
    }
}
