Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Html

Namespace DynamicPDFCoreSuite.Utility
    Public Class DocumentExampleGenerator
        Public Shared Sub Generate(ByVal doc As Document)
            For i As Integer = 0 To 4
                Dim pg As New Page(PageSize.Letter)

                Dim width As Single = pg.Dimensions.Width - (pg.Dimensions.LeftMargin * 2)
                Dim height As Single = pg.Dimensions.Height - (pg.Dimensions.TopMargin * 2)

                Dim frmHtmlArea As New HtmlArea(TextGenerator.Generate(), 0, 0, width, height)

                pg.Elements.Add(frmHtmlArea)
                doc.Pages.Add(pg)
            Next
        End Sub
    End Class
End Namespace

