Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Public Class ListsExample
        Public Shared Sub Run()
            OrderedList()
            UnorderedList()
        End Sub

        Public Shared Sub OrderedList()
            Dim document As New Document()

            document.Pages.Add(New Page(PageSize.Letter))

            Dim listRoman As New OrderedList(50, 50, 300, 500, Font.Courier, 14, NumberingStyle.RomanUpperCase)

            listRoman.Items.Add("Item One")
            listRoman.Items.Add("Item Two")
            listRoman.Items.Add("Item Three")
            listRoman.Items.Add("Item Four")

            document.Pages(0).Elements.Add(listRoman)

            Dim page As New Page()

            Dim list As New OrderedList(50, 50, 300, 500)

            list.ListItemTopMargin = 5
            list.ListItemBottomMargin = 5
            list.BulletPrefix = "("
            list.BulletSuffix = ")"
            list.TextColor = RgbColor.BlueViolet

            Dim item1 As ListItem = list.Items.Add("List item 1")
            item1.Underline = True
            Dim item2 As ListItem = list.Items.Add("List item 2")
            item2.Underline = True
            Dim item3 As ListItem = list.Items.Add("List item 3")
            item3.Underline = True
            Dim item4 As ListItem = list.Items.Add("List item 4")
            item4.Underline = True

            Dim subList1 As OrderedSubList = item1.SubLists.AddOrderedSubList(NumberingStyle.RomanUpperCase)
            subList1.TextColor = RgbColor.HotPink
            Dim item5 As ListItem = subList1.Items.Add("Sub-list item 1")
            Dim item6 As ListItem = subList1.Items.Add("Sub-list item 2")

            Dim subList2 As OrderedSubList = item5.SubLists.AddOrderedSubList(NumberingStyle.AlphabeticLowerCase)
            subList2.TextColor = RgbColor.DarkGoldenRod
            Dim item7 As ListItem = subList2.Items.Add("Second level sub-list item 1")
            Dim item8 As ListItem = subList2.Items.Add("Second level sub-list item 2")

            page.Elements.Add(list)

            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/ordered-list-output.pdf"))
        End Sub

        Public Shared Sub UnorderedList()
            Dim document As New Document()

            Dim page As New Page()
            Dim list As New UnorderedList(50, 50, 300, 500)

            list.ListItemTopMargin = 5
            list.ListItemBottomMargin = 5
            list.TextColor = RgbColor.BlueViolet

            Dim item1 As ListItem = list.Items.Add("List item 1")
            item1.Underline = True
            Dim item2 As ListItem = list.Items.Add("List item 2")
            item2.Underline = True
            Dim item3 As ListItem = list.Items.Add("List item 3")
            item3.Underline = True
            Dim item4 As ListItem = list.Items.Add("List item 4")
            item4.Underline = True

            Dim subList1 As UnorderedSubList = item1.SubLists.AddUnorderedSubList(UnorderedListStyle.Circle)
            subList1.TextColor = RgbColor.HotPink
            Dim item5 As ListItem = subList1.Items.Add("Sub-list item 1")
            Dim item6 As ListItem = subList1.Items.Add("Sub-list item 2")

            Dim subList2 As UnorderedSubList = item5.SubLists.AddUnorderedSubList(UnorderedListStyle.Square)
            subList2.TextColor = RgbColor.DarkGoldenRod
            Dim item7 As ListItem = subList2.Items.Add("Second level sub-list item 1")
            Dim item8 As ListItem = subList2.Items.Add("Second level sub-list item 2")

            page.Elements.Add(list)

            Dim listCustom As New UnorderedList(50, 250, 300, 500, Font.Courier, 14, New UnorderedListStyle("$", Font.CourierBold))

            listCustom.Items.Add("List item 1")
            listCustom.Items.Add("List item 2")
            listCustom.Items.Add("List item 3")
            listCustom.Items.Add("List item 4")

            page.Elements.Add(listCustom)

            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/unordered-list-output.pdf"))
        End Sub
    End Class
End Namespace

