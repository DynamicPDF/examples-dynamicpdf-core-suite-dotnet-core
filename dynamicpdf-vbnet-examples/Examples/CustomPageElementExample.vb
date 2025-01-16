Imports ceTe.DynamicPDF

Namespace DynamicPDFCoreSuite.Examples
    Public Class CustomPageElementExample

        Public Shared Sub Run()
            PolygonExample()
            TextAreaExample()
        End Sub

        Public Shared Sub PolygonExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim xCoordinates As Single() = {10, 50, 150, 350}
            Dim yCoordinates As Single() = {20, 250, 100, 10}

            Dim poly As New Polygon(xCoordinates, yCoordinates)
            poly.BorderColor = RgbColor.Red
            poly.BorderWidth = 3
            poly.FillColor = RgbColor.Blue
            poly.BorderStyle = LineStyle.Solid

            page.Elements.Add(poly)

            Dim page1 As New Page(PageSize.Letter)
            Dim ce As New CustomElement("This is Test", 0, 0, 500, 50)
            ce.FontSize = 62
            page1.Elements.Add(ce)

            document.Pages.Add(page1)

            document.Draw(Util.GetPath("Output/custom-page-element-poly-output.pdf"))
        End Sub

        Public Shared Sub TextAreaExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim ce As New CustomElement("A custom text area", 0, 0, 500, 50)
            ce.FontSize = 62
            document.Pages(0).Elements.Add(ce)
            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/custom-page-element-textarea-output.pdf"))
        End Sub

    End Class
End Namespace

