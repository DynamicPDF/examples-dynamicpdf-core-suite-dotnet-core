Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports System.IO

Namespace DynamicPDFCoreSuite.Examples
    Public Class FormattedTextAreaExample
        Public Shared Sub Run()
            Dim doc As New Document()
            doc.Pages.Add(New Page(PageSize.Letter))

            Dim txt As String = File.ReadAllText(Util.GetPath("Resources/Data/simple-fta.txt"))

            Dim pgWdth As Single = doc.Pages(0).Dimensions.Width - doc.Pages(0).Dimensions.LeftMargin * 2

            Dim style As New FormattedTextAreaStyle(FontFamily.Helvetica, 12, False)

            Dim fta As New FormattedTextArea(txt, 0, 0, pgWdth, 0, style)
            fta.Height = fta.GetRequiredHeight()

            doc.Pages(0).Elements.Add(fta)

            doc.Draw(Util.GetPath("Output/formatted-text-area-out.pdf"))
        End Sub
    End Class
End Namespace
