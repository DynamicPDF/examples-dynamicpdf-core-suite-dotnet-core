Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports System

Namespace DynamicPDFCoreSuite.Examples
    Class BookmarkOutlineExample
        Public Shared Sub Run()
            BookMarkExample()
            OutlineExample()
        End Sub

        Public Shared Sub BookMarkExample()
            Dim document As New Document()
            Dim page1 As New Page(PageSize.Letter)
            Dim page2 As New Page(PageSize.Letter)
            Dim page3 As New Page(PageSize.Letter)

            Dim parentOutline As Outline = document.Outlines.Add("Parent Outline")

            page1.Elements.Add(New Bookmark("Top level bookmark to page 1", 0, 0))
            page1.Elements.Add(New Bookmark("Bookmark to page 1", 0, 0, parentOutline))
            page2.Elements.Add(New Bookmark("Bookmark to page 2", 0, 0, parentOutline))
            page3.Elements.Add(New Bookmark("Bookmark to page 3", 0, 0, parentOutline))

            document.Pages.Add(page1)
            document.Pages.Add(page2)
            document.Pages.Add(page3)

            document.Draw(Util.GetPath("Output/bookmark-example.pdf"))
        End Sub

        Public Shared Sub OutlineExample()
            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New Page(PageSize.Letter))

            Dim outline1 As Outline = document.Outlines.Add("Outline1")
            outline1.Style = TextStyle.Bold
            outline1.Color = New RgbColor(1.0F, 0.0F, 0.0F)

            Dim outline1A As Outline = outline1.ChildOutlines.Add("Outline1A", New ZoomDestination(2, PageZoom.FitPage))
            outline1A.Expanded = False
            Dim outline1A1 As Outline = outline1A.ChildOutlines.Add("Outline1A1", New XYDestination(2, 0, 0))
            Dim outline1A2 As Outline = outline1A.ChildOutlines.Add("Outline1A2", New ZoomDestination(2, PageZoom.FitHeight))
            Dim outline1B As Outline = outline1.ChildOutlines.Add("Outline1B", New ZoomDestination(2, PageZoom.FitWidth))

            Dim outline2 As Outline = document.Outlines.Add("Outline2", New XYDestination(3, 0, 300))
            Dim outline2A As Outline = outline2.ChildOutlines.Add("Outline2A")

            document.Draw(Util.GetPath("Output/outlinek-example.pdf"))
        End Sub
    End Class
End Namespace

