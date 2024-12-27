Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Class AddNewContentExample
        Public Shared Sub Run()
            AddContent()
            AddPage()
        End Sub

        Public Shared Sub AddContent()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentC.pdf"))
            Dim page As Page = document.Pages(0)
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
    End Class
End Namespace

