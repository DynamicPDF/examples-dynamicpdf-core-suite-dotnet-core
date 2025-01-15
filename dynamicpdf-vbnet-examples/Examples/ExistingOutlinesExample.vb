Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements
Imports System

Namespace dynamicpdf_vbnet_examples.Examples
    Class ExistingOutlinesExample
        Public Shared Sub Run()
            ReadOutline()
            AddOutline()
            AddBookmark()
            AddBookmarkToExistingPage()
            ReplaceOutline()
            ModifyOutline()
        End Sub
        Public Shared Sub ModifyOutline()
            Dim docA As New PdfDocument(Util.GetPath("Resources/PDFs/outline-a.pdf"))
            Dim docB As New PdfDocument(Util.GetPath("Resources/PDFs/outline-b.pdf"))
            Dim pdfOutB As PdfOutline = docB.Outlines(1)

            Dim document As New MergeDocument()
            document.Append(docA, MergeOptions.None)
            document.Append(docB, MergeOptions.None)

            Dim root As Outline = document.Outlines.Add("Merged Document")

            root.ChildOutlines.Add("DynamicPDF Website", New UrlAction("https://www.dynamicpdf.com/"))

            For i As Integer = 1 To document.Pages.Count
                root.ChildOutlines.Add("Page " & i, New XYDestination(i, 0, 0))
            Next

            document.Outlines.Add(pdfOutB.Text)

            For i As Integer = 0 To pdfOutB.ChildOutlines.Count - 1
                Dim targetPage As Integer = docA.Pages.Count + pdfOutB.ChildOutlines(i).TargetPageNumber
                document.Outlines(1).ChildOutlines.Add("Bookmark Page " & targetPage, New XYDestination(targetPage, 0, 0))
            Next

            document.Draw(Util.GetPath("Output/modify-outline-output.pdf"))
        End Sub

        Public Shared Sub ReadOutline()
            Dim pdfDocument As New PdfDocument(Util.GetPath("Resources/PDFs/outline-example.pdf"))
            For i As Integer = 0 To pdfDocument.Outlines.Count - 1
                Dim outline As PdfOutline = pdfDocument.Outlines(i)
                PrintOutline(outline)
            Next
        End Sub

        Private Shared Sub PrintOutline(ByVal outline As PdfOutline)
            Console.WriteLine(outline.Text & ": " & outline.TargetPageNumber)

            If outline.ChildOutlines.Count > 0 Then
                For j As Integer = 0 To outline.ChildOutlines.Count - 1
                    PrintOutline(outline.ChildOutlines(j))
                Next
            End If
        End Sub

        Public Shared Sub AddOutline()
            Dim pdfDocument As New PdfDocument(Util.GetPath("Resources/PDFs/outline-example.pdf"))
            Dim pdfOutline As PdfOutline = pdfDocument.Outlines(0)
            Dim document As New MergeDocument(pdfDocument)
            Dim outline1 As Outline = document.Outlines.Add("ChildA")
            Dim outline1A As Outline = outline1.ChildOutlines.Add("ChildA 1", New XYDestination(2, 0, 0))
            document.Draw(Util.GetPath("Output/add-to-outline-output.pdf"))
        End Sub

        Public Shared Sub ReplaceOutline()
            Dim pdfDocument As New PdfDocument(Util.GetPath("Resources/PDFs/outline-example.pdf"))
            Dim pdfOutline As PdfOutline = pdfDocument.Outlines(0)
            Dim options As New MergeOptions()
            options.Outlines = False
            Dim document As New MergeDocument(pdfDocument, options)
            Dim root As Outline = document.Outlines.Add("Replaced-Outline1")
            Dim outline1A As Outline = root.ChildOutlines.Add("Replaced ChildA 1", New XYDestination(2, 0, 0))
            document.Draw(Util.GetPath("Output/modify-outline-output.pdf"))
        End Sub

        Public Shared Sub AddBookmark()
            Dim pdfDocument As New PdfDocument(Util.GetPath("Resources/PDFs/bookmark-example.pdf"))
            Dim document As New MergeDocument(pdfDocument)
            Dim addedPage As New Page(PageSize.Letter)
            document.Pages.Add(addedPage)
            addedPage.Elements.Add(New Bookmark("Added Bookmark", 0, 0))
            document.Draw(Util.GetPath("Output/add-to-bookmark-output.pdf"))
        End Sub

        Public Shared Sub AddBookmarkToExistingPage()
            Dim pdfDocument As New PdfDocument(Util.GetPath("Resources/PDFs/bookmark-example.pdf"))
            Dim document As New MergeDocument(pdfDocument)
            Dim page As Page = document.Pages(3)
            page.Elements.Add(New Bookmark("Added Bookmark", 0, 0))
            document.Draw(Util.GetPath("Output/add-to-bookmark-existing-page-output.pdf"))
        End Sub
    End Class
End Namespace

