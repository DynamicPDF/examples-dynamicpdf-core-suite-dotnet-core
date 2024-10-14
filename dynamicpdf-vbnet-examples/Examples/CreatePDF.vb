Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Class CreatePDF
        Public Shared Sub Run()
            Dim document As New Document()
            Dim outputPath As String = Util.GetPath("Output/CreatePDF-output.pdf")

            Dim page As New Page(PageSize.Letter, PageOrientation.Portrait, 54.0F)
            document.Pages.Add(page)

            Dim labelText As String = "Hello World..." & vbLf & "From DynamicPDF Core Suite for .NET" & vbLf & "DynamicPDF.com"
            Dim label As New Label(labelText, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center)
            page.Elements.Add(label)

            document.Draw(outputPath)
        End Sub
    End Class
End Namespace
