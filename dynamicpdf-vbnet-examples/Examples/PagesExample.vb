Imports ceTe.DynamicPDF

Namespace DynamicPDFCoreSuite.Examples
    Public Class PagesExample
        Public Shared Sub Run()
            Dim myDoc As New Document()

            myDoc.Pages.Add(New Page(PageSize.Legal))
            myDoc.Pages.Add(New Page(PageSize.Letter, PageOrientation.Landscape, 25))

            Dim pgDim As New PageDimensions(PageSize.Letter, PageOrientation.Portrait)
            pgDim.BottomMargin = 50
            pgDim.TopMargin = 50
            pgDim.LeftMargin = 35
            pgDim.RightMargin = 35

            myDoc.Pages.Add(New Page(pgDim))

            myDoc.Pages.Add(New Page(100, 200))

            myDoc.Draw(Util.GetPath("Output/pages-output.pdf"))
        End Sub
    End Class
End Namespace

