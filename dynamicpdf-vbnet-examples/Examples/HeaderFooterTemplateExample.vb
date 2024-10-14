Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.Html
Imports dynamicpdf_vbnet_examples.DynamicPDFCoreSuite.Utility

Namespace DynamicPDFCoreSuite.Examples
    Class HeaderFooterTemplateExample
        Public Shared Sub Run()
            RunOne()
            RunTwo()
            RunThree()
        End Sub

        Public Shared Sub RunOne()
            Dim myDoc As New Document()
            myDoc.Pages.Add(New Page())

            Dim header As New HeaderFooterTemplate("Header text", "Footer text")
            Dim leftText As New HeaderFooterText("Example Header")
            leftText.Font = Font.Helvetica
            leftText.FontSize = 12
            header.HeaderLeft = leftText
            myDoc.Template = header

            header.FooterLeft = header.FooterCenter

            myDoc.Draw(Util.GetPath("Output/header-footer-template-out.pdf"))
        End Sub

        Public Shared Sub RunTwo()
            Dim myDoc As New Document()
            DocumentExampleGenerator.Generate(myDoc)

            Dim x As Single = myDoc.Pages(0).Dimensions.Width - myDoc.Pages(0).Dimensions.RightMargin * 2
            Dim y As Single = -myDoc.Pages(0).Dimensions.TopMargin / 2

            Dim header As New HeaderFooterTemplate("OF", "Example Footer")
            header.HeaderCenter.Font = Font.Helvetica
            header.HeaderCenter.FontSize = 14

            Dim pglb As New PageNumberingLabel("PAGE %%CP%%", 0, y, 100, 50, Font.Helvetica, 14, TextAlign.Right)
            pglb.IgnoreMargins = True
            pglb.VAlign = VAlign.Bottom
            header.Elements.Add(pglb)

            Dim pglbRgt As New PageNumberingLabel("%%TP%% PAGES", x, y, 100, 50, Font.Helvetica, 14, TextAlign.Right)
            pglbRgt.X -= (pglb.Width / 2)
            pglbRgt.VAlign = VAlign.Bottom
            pglbRgt.IgnoreMargins = True
            header.Elements.Add(pglbRgt)

            myDoc.Template = header

            AddLines(myDoc.Pages(0))
            myDoc.Draw(Util.GetPath("Output/header-footer-template-pagenumbering-out.pdf"))
        End Sub

        Public Shared Sub RunThree()
            Dim myDoc As New Document()
            myDoc.Pages.Add(New Page())

            Dim h As Single = myDoc.Pages(0).Dimensions.TopMargin
            Dim w As Single = myDoc.Pages(0).Dimensions.Width
            Dim x As Single = myDoc.Pages(0).Dimensions.Width - myDoc.Pages(0).Dimensions.RightMargin * 2

            Dim header As New HeaderFooterTemplate("HeaderText", "FooterText")
            Dim filePath As New Uri(Util.GetPath("Resources/HTML/example-header.html"))
            Dim htmlArea As New HtmlArea(filePath, 0, 0, w, h)
            htmlArea.IgnoreMargins = True
            header.Elements.Add(htmlArea)

            Dim pglb As New PageNumberingLabel("PAGE %%CP%% of %%TP%%", x, 0, 100, 50, Font.Helvetica, 14, TextAlign.Left)
            pglb.IgnoreMargins = True
            pglb.VAlign = VAlign.Center
            header.Elements.Add(pglb)

            myDoc.Template = header

            myDoc.Draw(Util.GetPath("Output/header-footer-template-htmlarea-out.pdf"))
        End Sub

        Private Shared Sub AddLines(ByVal pg As Page)
            Dim rec As New Rectangle(0, 0, pg.Dimensions.Width - pg.Dimensions.LeftMargin * 2, pg.Dimensions.Height - pg.Dimensions.TopMargin * 2)
            rec.BorderColor = RgbColor.Red
            rec.BorderStyle = LineStyle.Dash
            pg.Elements.Add(rec)

            Dim ctrX As Single = (pg.Dimensions.Width - pg.Dimensions.LeftMargin * 2) / 2
            Dim ctrY As Single = (-pg.Dimensions.TopMargin / 2)

            Dim crc As New Circle(ctrX, ctrY, 1)
            crc.BorderColor = RgbColor.Red
            crc.FillColor = RgbColor.Red
            pg.Elements.Add(crc)

            Dim ln As New Line(pg.Dimensions.RightMargin, 0, pg.Dimensions.RightMargin, pg.Dimensions.TopMargin)
            ln.IgnoreMargins = True
            ln.Style = LineStyle.Dash
            ln.Color = RgbColor.Red
            pg.Elements.Add(ln)

            Dim ln2 As New Line(pg.Dimensions.Width - pg.Dimensions.RightMargin, 0, pg.Dimensions.Width - pg.Dimensions.RightMargin, pg.Dimensions.TopMargin)
            ln2.IgnoreMargins = True
            ln2.Style = LineStyle.Dash
            ln2.Color = RgbColor.Red
            pg.Elements.Add(ln2)

            Dim ln3 As New Line(pg.Dimensions.RightMargin, 25, pg.Dimensions.Width - pg.Dimensions.LeftMargin, 25)
            ln3.Style = LineStyle.Dash
            ln3.Color = RgbColor.Red
            ln3.IgnoreMargins = True
            pg.Elements.Add(ln3)
        End Sub
    End Class
End Namespace

