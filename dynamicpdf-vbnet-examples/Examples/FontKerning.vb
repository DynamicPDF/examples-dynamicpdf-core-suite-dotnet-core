Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.Text

Namespace DynamicPDFCoreSuite.Examples
    Class FontKerning
        Public Shared Sub Run()
            Dim document As New Document()
            Dim page As New Page()
            Dim text As String = "To and WA are examples of when kerning would be used."
            Dim textArea As New TextArea(text, 10, 10, 400, 700, Font.TimesRoman)

            textArea.KerningEnabled = True
            Dim kernValues As KerningValues = textArea.GetKerningValues()

            For i As Integer = 0 To kernValues.Spacing.Length - 1
                kernValues.Spacing(i) = CType(kernValues.Spacing(i) - 400, Short)
            Next

            page.Elements.Add(textArea)
            document.Pages.Add(page)
            document.Draw(Util.GetPath("Output/fontkerning-output.pdf"))
        End Sub
    End Class
End Namespace

