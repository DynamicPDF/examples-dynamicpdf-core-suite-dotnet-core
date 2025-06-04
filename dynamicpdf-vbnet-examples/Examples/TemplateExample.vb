Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Class TemplateExample

        Public Shared Sub Run()
            Simple()
            One()
        End Sub

        Public Shared Sub Simple()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim template As New Template()
            template.Elements.Add(New Label("Header", 0, 0, 200, 12))
            template.Elements.Add(New Image(Util.GetPath("Resources/Images/DPDFLogo.png"), 100, 0))

            document.Template = template
            document.Draw(Util.GetPath("Output/template-out.pdf"))
        End Sub

        Public Shared Sub One()
            Dim doc As New Document()
            Dim tmp As New Template()

            doc.Pages.Add(New Page())
            doc.Pages.Add(New Page())

            Dim hgt As Single = doc.Pages(0).Dimensions.Height
            Dim x As Single = -doc.Pages(0).Dimensions.LeftMargin
            Dim y As Single = -doc.Pages(0).Dimensions.TopMargin
            Dim wdt As Single = doc.Pages(0).Dimensions.Width

            tmp.Elements.Add(New Rectangle(x, y, wdt, hgt, RgbColor.LightSkyBlue, RgbColor.LightSkyBlue))
            tmp.Elements.Add(New Rectangle(x, y, 20, hgt, RgbColor.Navy, RgbColor.Navy))
            tmp.Elements.Add(New Image(Util.GetPath("Resources/Images/") & "DPDFLogo.png", x + 30, y + 5))
            tmp.Elements.Add(New Label("Test.", 200, 300, 200, 0))

            doc.Template = tmp

            doc.Draw(Util.GetPath("Output/addtemplatetopdf-out.pdf"))
        End Sub

    End Class


