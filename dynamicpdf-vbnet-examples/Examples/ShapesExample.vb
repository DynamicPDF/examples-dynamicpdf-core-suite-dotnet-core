Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports DynamicPDFCoreSuite.Examples

Namespace dynamicpdf_vbnet_examples.Examples
    Class ShapesExample

        Public Shared Sub Run()
            AddLine()
            AddCircle()
            AddPath()
            AddRectangle()
        End Sub

        Public Shared Sub AddLine()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim line As New Line(50, 50, 50, 400, 5, Grayscale.Black, LineStyle.Solid)
            line.Cap = LineCap.Round
            page.Elements.Add(line)

            page.Elements.Add(New Line(60, 50, 150, 400, 2, RgbColor.Blue, LineStyle.DashLarge))

            document.Draw(Util.GetPath("Output/shape-line-example-output.pdf"))
        End Sub

        Public Shared Sub AddRectangle()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim rectangle As New Rectangle(50, 50, 200, 200, Grayscale.Black, RgbColor.Gray, 4, LineStyle.Solid)
            rectangle.CornerRadius = 10
            page.Elements.Add(rectangle)

            document.Draw(Util.GetPath("Output/shape-rectangle-example-output.pdf"))
        End Sub

        Public Shared Sub AddCircle()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim circle1 As New Circle(100, 100, 50, 100, Grayscale.Black, RgbColor.LightBlue, 2, LineStyle.Solid)
            Dim circle2 As New Circle(150, 75, 50, 50, Grayscale.Black, RgbColor.Lime, 2, LineStyle.Solid)

            page.Elements.Add(circle1)
            page.Elements.Add(circle2)

            document.Draw(Util.GetPath("Output/shape-circle-example-output.pdf"))
        End Sub

        Public Shared Sub AddPath()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim path As New Path(50, 150, RgbColor.DarkRed, RgbColor.LimeGreen, 3, LineStyle.Solid, True)
            path.SubPaths.Add(New CurveSubPath(50, 400, 300, 150, -200, 400))
            path.SubPaths.Add(New LineSubPath(330, 450))
            path.SubPaths.Add(New CurveToSubPath(300, 120, 50, 300))
            path.SubPaths.Add(New CurveFromSubPath(150, 130, 200, -100))

            page.Elements.Add(path)

            document.Draw(Util.GetPath("Output/shape-path-example-output.pdf"))
        End Sub

    End Class
End Namespace

