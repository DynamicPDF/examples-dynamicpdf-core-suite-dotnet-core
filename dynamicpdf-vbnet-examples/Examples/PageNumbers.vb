Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Public Class PageNumbers
    Public Shared Sub Run()
        Merger()
        Generator()
    End Sub

    Public Shared Sub Merger()
        Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))

        Dim template As New Template()
        Dim pageLabels As New PageNumberingLabel("%%CP%% of %%TP%%", 0, 0, 200, 20)
        template.Elements.Add(pageLabels)
        document.Template = template

        document.Draw(Util.GetPath("Output/AddPageNumberToExistingPDF.pdf"))
    End Sub

    Public Shared Sub Generator()
        Dim document As New Document()
        Dim documentTemplate As New Template()
        document.Template = documentTemplate

        documentTemplate.Elements.Add(New PageNumberingLabel("%%PR%%%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center))

        document.Sections.Begin(NumberingStyle.RomanLowerCase)

        document.Pages.Add(New Page()) ' Page 1
        document.Pages.Add(New Page()) ' Page 2
        document.Pages.Add(New Page()) ' Page 3

        document.Sections.Begin(NumberingStyle.Numeric)

        document.Pages.Add(New Page()) ' Page 4
        document.Pages.Add(New Page()) ' Page 5
        document.Pages.Add(New Page()) ' Page 6
        document.Pages.Add(New Page()) ' Page 7

        document.Sections.Begin(NumberingStyle.RomanLowerCase, "Appendix A - ")
        document.Pages.Add(New Page()) ' Page 8
        document.Pages.Add(New Page()) ' Page 9

        document.Draw(Util.GetPath("Output/AddPageNumberToNewPDF.pdf"))
    End Sub
End Class

