Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples

    Class AddShapeExample

        Public Shared Sub Run()
            AddCircle()
            AddRectangle()
            AddLine()
            AddPath()
        End Sub

        Public Shared Sub AddCircle()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim circle1 As New Circle(100, 100, 50, 100, Grayscale.Black, RgbColor.OrangeRed, 2, LineStyle.Solid)

            page.Elements.Add(circle1)

            document.Draw(Util.GetPath("Output/circle-output.pdf"))
        End Sub

        Public Shared Sub AddRectangle()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim rectangle As New Rectangle(10, 10, 400, 300, RgbColor.Red, RgbColor.Navy)
            page.Elements.Add(rectangle)

            document.Draw(Util.GetPath("Output/rectangle-output.pdf"))
        End Sub

        Public Shared Sub AddLine()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim line As New Line(150, 0, 150, 300)
            line.Color = RgbColor.Navy
            line.Width = 10
            line.Cap = LineCap.Butt

            page.Elements.Add(line)
            document.Draw(Util.GetPath("Output/line-output.pdf"))
        End Sub

        Public Shared Sub AddPath()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim path As New Path(50, 150, RgbColor.Blue, RgbColor.Yellow, 3, LineStyle.Solid, True)

            path.SubPaths.Add(New CurveSubPath(50, 400, 300, 150, -200, 400))
            path.SubPaths.Add(New LineSubPath(300, 400))
            path.SubPaths.Add(New CurveToSubPath(300, 150, 50, 300))
            path.SubPaths.Add(New CurveFromSubPath(150, 100, 200, -100))

            page.Elements.Add(path)

            document.Draw(Util.GetPath("Output/path-output.pdf"))
        End Sub

    End Class

End Namespace

