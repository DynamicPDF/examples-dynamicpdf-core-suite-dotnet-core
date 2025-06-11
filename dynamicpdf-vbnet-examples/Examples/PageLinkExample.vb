Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Class PageLinkExample

        Public Shared Sub Run()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim text As String = "This is a link to mydomain.com"
            Dim font As Font = Font.Helvetica

            Dim label As New Label(text, 50, 50, 400, 20, font, 18, RgbColor.Blue)
            label.Underline = True

            Dim action As New UrlAction("http://www.mydomain.com")
            Dim link As New Link(50, 50, font.GetTextWidth(text, 18), 20, action)

            page.Elements.Add(label)
            page.Elements.Add(link)

            document.Draw(Util.GetPath("Output/page-link-output.pdf"))
        End Sub

    End Class
End Namespace
