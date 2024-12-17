Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Public Class DocumentSectioningExample
        Public Shared Sub Run()
            Dim myDoc As New Document()
            myDoc.Pages.Add(New Page())
            Dim template As New Template()
            template.Elements.Add(New PageNumberingLabel("%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center))

            myDoc.Template = template

            myDoc.Sections.Begin(NumberingStyle.RomanLowerCase)
            myDoc.Pages.Add(New Page()) 'Page 1
            myDoc.Pages.Add(New Page()) 'Page 2

            myDoc.Sections.Begin(NumberingStyle.Numeric, template)
            myDoc.Pages.Add(New Page()) 'Page 3
            myDoc.Pages.Add(New Page()) 'Page 4
            myDoc.Pages.Add(New Page()) 'Page 5

            myDoc.Sections.Begin(NumberingStyle.RomanLowerCase, "Appendix A - ")
            myDoc.Pages.Add(New Page()) 'Page 6
            myDoc.Pages.Add(New Page()) 'Page 7

            myDoc.Draw(Util.GetPath("Output/document-sectioning-out.pdf"))
        End Sub
    End Class
End Namespace
