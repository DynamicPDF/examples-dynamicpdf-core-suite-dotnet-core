Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Public Class ListContinuationExample
        Public Shared Sub Run()
            Dim doc As New Document()

            Dim ol As New OrderedList(0, 0, 512, 692)

            ol.ListItemTopMargin = 5
            ol.ListItemBottomMargin = 5

            For i As Integer = 0 To 9
                Dim item1 As ListItem = ol.Items.Add("item " & i)

                Dim sl As OrderedSubList = item1.SubLists.AddOrderedSubList(NumberingStyle.AlphabeticLowerCase)

                For j As Integer = 0 To 9
                    Dim subItem As ListItem = sl.Items.Add("sub-item " & j)
                Next
            Next

            Do
                Dim page As New Page()
                page.Elements.Add(ol)
                doc.Pages.Add(page)
                ol = ol.GetOverFlowList()
            Loop While ol IsNot Nothing

            doc.Draw(Util.GetPath("Output/list-overflow-example.pdf"))
        End Sub
    End Class
End Namespace

