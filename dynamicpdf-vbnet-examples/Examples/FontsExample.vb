Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.Text

Namespace DynamicPDFCoreSuite.Examples
    Class FontsExample
        Public Shared Sub Run()
            OpenTypeFontExample()
            CJKExample()
            GoogleFontsExample()
            EncodingExample()
        End Sub

        Public Shared Sub EncodingExample()
            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter))

            Dim centralEuropeHelveticaFont As Font = New Helvetica(Encoder.CentralEurope)

            Dim lbl As New Label("čárka nad písmenem, silný přízvuk", 0, 0, 200, 12, centralEuropeHelveticaFont, 12)
            Dim lbl2 As New Label("čárka nad písmenem, silný přízvuk", 0, 100, 300, 0, Font.Helvetica, 12)

            document.Pages(0).Elements.Add(lbl)
            document.Pages(0).Elements.Add(lbl2)

            document.Draw(Util.GetPath("Output/encoding-font-example-one.pdf"))
        End Sub

        Public Shared Sub OpenTypeFontExample()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            ' Create an OpenType font class.
            Dim openTypeFont As New OpenTypeFont(Util.GetPath("Resources/Data/cnr.otf"))
            ' Use the OpenType font in a text area Page Element.
            page.Elements.Add(New TextArea("Text", 0, 0, 200, 12, openTypeFont, 12))

            document.Draw(Util.GetPath("Output/opentype-font-example-one.pdf"))
        End Sub

        Public Shared Sub GoogleFontsExample()
            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter))

            Dim googleFont As GoogleFont = Font.Google("Roboto", False, False)

            Dim lbl As New Label("A Google Font Example.", 10, 10, 150, 50, googleFont, 22)
            document.Pages(0).Elements.Add(lbl)

            document.Draw(Util.GetPath("Output/googlefont-font-example-one.pdf"))
        End Sub

        Public Shared Sub CJKExample()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            page.Elements.Add(New TextArea("CJK Text", 0, 0, 200, 12, Font.HeiseiKakuGothicW5, 16))

            document.Draw(Util.GetPath("Output/cjk-font-example-one.pdf"))
        End Sub
    End Class
End Namespace

