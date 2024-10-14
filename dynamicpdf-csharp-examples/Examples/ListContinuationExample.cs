using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    public class ListContinuationExample
    {
        public static void Run()
        {
            Document doc = new Document();

            OrderedList ol = new OrderedList(0, 0, 512, 692);

            ol.ListItemTopMargin = 5;
            ol.ListItemBottomMargin = 5;

            for (int i = 0; i < 10; i++)
            {
                ListItem item1 = ol.Items.Add("item " + i);

                OrderedSubList sl = item1.SubLists.AddOrderedSubList(NumberingStyle.AlphabeticLowerCase);

                for (int j = 0; j < 10; j++)
                {
                  ListItem subItem = sl.Items.Add("sub-item " + j);
                }
            }

            do
            {
                Page page = new Page();
                page.Elements.Add(ol);
                doc.Pages.Add(page);
                ol = ol.GetOverFlowList();
            } while (ol != null);

            doc.Draw(Util.GetPath("Output/list-overflow-example.pdf"));

        }
    }
}
