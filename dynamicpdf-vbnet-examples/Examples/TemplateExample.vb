Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Class TemplateExample
        Public Shared Sub Run()
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
End Namespace
