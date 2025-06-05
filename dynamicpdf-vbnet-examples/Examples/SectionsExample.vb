Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Class SectionsExample
        Public Shared Sub Run()
            Dim document As New Document()
            Dim template As New Template()
            template.Elements.Add(New PageNumberingLabel("%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center))

            document.Sections.Begin(NumberingStyle.RomanLowerCase)
            document.Pages.Add(New Page()) ' Page 1
            document.Pages.Add(New Page()) ' Page 2

            document.Sections.Begin(NumberingStyle.Numeric, template)
            document.Pages.Add(New Page()) ' Page 3
            document.Pages.Add(New Page()) ' Page 4
            document.Pages.Add(New Page()) ' Page 5

            document.Sections.Begin(NumberingStyle.RomanLowerCase, "Appendix A - ")
            document.Pages.Add(New Page()) ' Page 6
            document.Pages.Add(New Page()) ' Page 7

            document.Draw(Util.GetPath("Output/sections-output.pdf"))
        End Sub
    End Class
End Namespace

