Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.Html
Imports dynamicpdf_vbnet_examples.DynamicPDFCoreSuite.Utility

Namespace DynamicPDFCoreSuite.Examples
    Class StampTemplateExample
        Public Shared Sub Run()
            Dim doc As New Document()
            StampTemplateExample.CreatePage(doc)

            Dim tmp As New Template()

            Dim hgt As Single = doc.Pages(0).Dimensions.Height / 2
            Dim x As Single = -doc.Pages(0).Dimensions.LeftMargin
            Dim y As Single = -doc.Pages(0).Dimensions.TopMargin
            Dim wdt As Single = doc.Pages(0).Dimensions.Width

            Dim rec As New Rectangle(x, y, 20, hgt)
            rec.FillColor = RgbColor.Navy
            rec.BorderColor = RgbColor.Navy

            Dim bkRec As New Rectangle(x, y, wdt, hgt)
            bkRec.FillColor = RgbColor.LightSkyBlue
            bkRec.BorderColor = RgbColor.LightSkyBlue

            tmp.Elements.Add(New Rectangle(x, y, wdt, hgt, RgbColor.LightSkyBlue, RgbColor.LightSkyBlue))
            tmp.Elements.Add(New Rectangle(x, y, 20, hgt, RgbColor.Navy, RgbColor.Navy))
            tmp.Elements.Add(New Image(Util.GetPath("Resources/Images/") & "DPDFLogo.png", x + 30, y + 5))
            tmp.Elements.Add(New Label("Test.", 200, 300, 200, 0, Font.Helvetica, 90, RgbColor.Red))
            doc.StampTemplate = tmp

            doc.Draw(Util.GetPath("Output/stamptemplate-out.pdf"))
        End Sub

        Private Shared Sub CreatePage(ByVal doc As Document)
            Dim pg As New Page()
            Dim frmHtmlArea As New HtmlArea(TextGenerator.Generate(), 0, 0, pg.Dimensions.Width - (pg.Dimensions.LeftMargin * 2), pg.Dimensions.Height - (pg.Dimensions.TopMargin * 2))
            pg.Elements.Add(frmHtmlArea)
            doc.Pages.Add(pg)
        End Sub
    End Class
End Namespace

