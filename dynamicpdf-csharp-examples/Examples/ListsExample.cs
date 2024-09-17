using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class ListsExample
    {
        public static void Run()
        {
            OrderedList();
            UnorderedList();

        }

        public static void OrderedList()
        {
            Document document = new Document();

            document.Pages.Add(new Page(PageSize.Letter));

            OrderedList listRoman = new OrderedList(50, 50, 300, 500, Font.Courier, 14, NumberingStyle.RomanUpperCase);

            listRoman.Items.Add("Item One");
            listRoman.Items.Add("Item Two");
            listRoman.Items.Add("Item Three");
            listRoman.Items.Add("Item Four");

            document.Pages[0].Elements.Add(listRoman);

            Page page = new Page();

            OrderedList list = new OrderedList(50, 50, 300, 500);

            list.ListItemTopMargin = 5;
            list.ListItemBottomMargin = 5;
            list.BulletPrefix = "(";
            list.BulletSuffix = ")";
            list.TextColor = RgbColor.BlueViolet;

            ListItem item1 = list.Items.Add("List item 1");
            item1.Underline = true;
            ListItem item2 = list.Items.Add("List item 2");
            item2.Underline = true;
            ListItem item3 = list.Items.Add("List item 3");
            item3.Underline = true;
            ListItem item4 = list.Items.Add("List item 4");
            item4.Underline = true;

            OrderedSubList subList1 = item1.SubLists.AddOrderedSubList(NumberingStyle.RomanUpperCase);
            subList1.TextColor = RgbColor.HotPink;
            ListItem item5 = subList1.Items.Add("Sub-list item 1");
            ListItem item6 = subList1.Items.Add("Sub-list item 2");

            OrderedSubList subList2 = item5.SubLists.AddOrderedSubList(NumberingStyle.AlphabeticLowerCase);
            subList2.TextColor = RgbColor.DarkGoldenRod;
            ListItem item7 = subList2.Items.Add("Second level sub-list item 1");
            ListItem item8 = subList2.Items.Add("Second level sub-list item 2");

            page.Elements.Add(list);

            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/ordered-list-output.pdf"));
        }

        public static void UnorderedList()
        {
            Document document = new Document();

            Page page = new Page();
            UnorderedList list = new UnorderedList(50, 50, 300, 500);

            list.ListItemTopMargin = 5;
            list.ListItemBottomMargin = 5;
            list.TextColor = RgbColor.BlueViolet;

            ListItem item1 = list.Items.Add("List item 1");
            item1.Underline = true;
            ListItem item2 = list.Items.Add("List item 2");
            item2.Underline = true;
            ListItem item3 = list.Items.Add("List item 3");
            item3.Underline = true;
            ListItem item4 = list.Items.Add("List item 4");
            item4.Underline = true;

            UnorderedSubList subList1 = item1.SubLists.AddUnorderedSubList(UnorderedListStyle.Circle);
            subList1.TextColor = RgbColor.HotPink;
            ListItem item5 = subList1.Items.Add("Sub-list item 1");
            ListItem item6 = subList1.Items.Add("Sub-list item 2");

            UnorderedSubList subList2 = item5.SubLists.AddUnorderedSubList(UnorderedListStyle.Square);
            subList2.TextColor = RgbColor.DarkGoldenRod;
            ListItem item7 = subList2.Items.Add("Second level sub-list item 1");
            ListItem item8 = subList2.Items.Add("Second level sub-list item 2");

            page.Elements.Add(list);

            UnorderedList listCustom = new UnorderedList(50, 250, 300, 500, Font.Courier, 14, new UnorderedListStyle("$", Font.CourierBold));

            listCustom.Items.Add("List item 1");
            listCustom.Items.Add("List item 2");
            listCustom.Items.Add("List item 3");
            listCustom.Items.Add("List item 4");

            page.Elements.Add(listCustom);

            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/unordered-list-output.pdf"));
        }
    }
}
