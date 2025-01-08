Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Public Class AddNewContentExample
        Public Shared Sub Run()
            AddContent()
            AddPage()
            ImportPage()
            ImportPageAddElements()
            InsertPage()
            ImportPageBackgroundElements()
        End Sub
        Public Shared Sub ImportPageBackgroundElements()
            Dim document As New MergeDocument()
            Dim importedPage As New ImportedPage(Util.GetPath("Resources/PDFs/doc-text.pdf"), 1)
            Dim image As New Image(Util.GetPath("Resources/images/large-logo.png"), 40, 150, 0.5F)
            importedPage.BackgroundElements.Add(image)

            Dim lbl As New Label("Added Image", 100, 600, 400, 0)
            lbl.FontSize = 56
            lbl.TextColor = RgbColor.Red
            importedPage.BackgroundElements.Add(lbl)

            document.Pages.Add(importedPage)
            document.Draw(Util.GetPath("Output/import-background-elements-output.pdf"))
        End Sub


        Public Shared Sub AddContent()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentC.pdf"))
            Dim page As Page = document.Pages(1)
            page.Elements.Add(New Label("New Content", 0, 0, 512, 12))
            document.Draw(Util.GetPath("Output/add-content-output.pdf"))
        End Sub

        Public Shared Sub AddPage()
            Dim document As New MergeDocument()
            Dim page As New Page(PageSize.Letter, PageOrientation.Portrait)
            page.Elements.Add(New Label("Cover Page", 0, 0, 512, 12))
            document.Pages.Add(page)
            document.Append(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            document.Draw(Util.GetPath("Output/add-page-output.pdf"))
        End Sub

        Public Shared Sub InsertPage()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            Dim page As New Page(PageSize.Letter, PageOrientation.Portrait)
            page.Elements.Add(New Label("Cover Page", 0, 0, 512, 12))
            document.Pages.Insert(1, page)
            document.Draw(Util.GetPath("Output/insert-page-output.pdf"))
        End Sub

        Public Shared Sub ImportPage()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentC.pdf"))
            Dim page As New ImportedPage(Util.GetPath("Resources/PDFs/DocumentA.pdf"), 1)
            document.Pages.Insert(0, page)
            document.Draw(Util.GetPath("Output/import-page-output.pdf"))
        End Sub

        Public Shared Sub ImportPageAddElements()
            Dim document As New MergeDocument()
            Dim page As New ImportedPage(Util.GetPath("Resources/PDFs/DocumentC.pdf"), 1)
            page.Elements.Add(New Image(Util.GetPath("Resources/images/bluerectangle.png"), 300, 175, 1))
            Dim lbl As New Label("Label Text", 50, 75, 200, 12) With {
                .FontSize = 72,
                .TextColor = RgbColor.White,
                .TextOutlineColor = RgbColor.Red,
                .TextOutlineWidth = 3
            }
            page.Elements.Add(lbl)
            Dim rec As New Rectangle(10, 50, 250, 500, RgbColor.Black, RgbColor.DarkGreen)
            page.BackgroundElements.Add(rec)
            document.Pages.Add(page)
            document.Draw(Util.GetPath("Output/import-page-elements-output.pdf"))
        End Sub
    End Class
End Namespace
