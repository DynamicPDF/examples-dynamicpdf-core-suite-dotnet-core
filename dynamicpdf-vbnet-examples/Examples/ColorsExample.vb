Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Public Class ColorsExample

        Public Shared Sub Run()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)
            document.Pages.Add(page)

            Dim cmykColor1 As New CmykColor(0.5F, 0.3F, 0.6F, 0.0F)
            Dim cmykColor2 As New CmykColor(0.3F, 0.5F, 0.6F, 0.2F)
            page.Elements.Add(New Circle(10, 100, 40, cmykColor1, cmykColor2))
            page.Elements.Add(New Circle(150, 100, 40, CmykColor.Black, CmykColor.Red))

            Dim rgbColor1 As New RgbColor(0.5F, 0.3F, 0.6F)
            Dim rgbColor2 As New RgbColor(0.3F, 0.5F, 0.2F)
            page.Elements.Add(New Circle(10, 200, 40, rgbColor1, rgbColor2))
            page.Elements.Add(New Circle(150, 200, 40, RgbColor.Black, RgbColor.Red))

            Dim webColor1 As New WebColor("#FF0080")
            Dim webColor2 As New WebColor("aqua")
            page.Elements.Add(New Circle(10, 300, 40, webColor1, webColor2))

            Dim grayscale1 As New Grayscale(0.3F)
            Dim grayscale2 As New Grayscale(0.6F)
            page.Elements.Add(New Circle(10, 400, 40, grayscale1, grayscale2))
            page.Elements.Add(New Circle(150, 400, 40, Grayscale.White, Grayscale.Black))

            Dim gradient1 As New Gradient(0, 0, 200, 200, Grayscale.White, Grayscale.Black)
            Dim gradient2 As New Gradient(50, 0, 250, 200, RgbColor.YellowGreen, RgbColor.DarkMagenta)
            page.Elements.Add(New Circle(10, 500, 40, gradient1, gradient1))
            page.Elements.Add(New Circle(150, 500, 40, gradient2, gradient2))

            Dim autogradient1 As New AutoGradient(90.0F, CmykColor.Blue, CmykColor.Red)
            Dim autogradient2 As New AutoGradient(90.0F, CmykColor.Red, CmykColor.Blue)
            page.Elements.Add(New Circle(10, 600, 40, autogradient1, autogradient1))
            page.Elements.Add(New Circle(150, 600, 40, autogradient2, autogradient2))

            Dim alternateColor As New CmykColor(0.2F, 0.9F, 0.5F, 0.2F)
            Dim ink As New SpotColorInk("My Red", alternateColor)
            Dim tint100 As New SpotColor(1, ink)
            Dim tint50 As New SpotColor(0.5F, ink)
            page.Elements.Add(New Circle(10, 700, 40, tint50, tint50))
            page.Elements.Add(New Circle(150, 700, 40, tint100, tint100))

            document.Draw(Util.GetPath("Output/color-output.pdf"))
        End Sub

    End Class
End Namespace

