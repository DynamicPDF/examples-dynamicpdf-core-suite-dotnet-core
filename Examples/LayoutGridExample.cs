using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class LayoutGridExample
    {

        public static void Run()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            LayoutGrid grid = new LayoutGrid(LayoutGrid.GridType.Decimal);
            page.Elements.Add(new Rectangle(50, 50, 50, 50, 2));
            page.Elements.Add(grid);

            document.Draw(Util.GetPath("Output/layout-grid-output.pdf"));
        }
    }
}
