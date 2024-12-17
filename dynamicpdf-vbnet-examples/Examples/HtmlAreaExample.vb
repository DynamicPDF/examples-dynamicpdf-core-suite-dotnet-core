Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Html
Imports System

Namespace DynamicPDFCoreSuite.Examples
    Public Class HtmlAreaExample
        Public Shared Sub Run()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)
            document.Pages.Add(page)

            Dim hgt As Single = page.Dimensions.Height - page.Dimensions.TopMargin * 2
            Dim wdth As Single = page.Dimensions.Width - page.Dimensions.LeftMargin * 2

            Dim filePath As New Uri(Util.GetPath("Resources/HTML/simple.html"))

            Dim htmlArea As New HtmlArea(filePath, 0, 0, wdth, hgt)

            page.Elements.Add(htmlArea)

            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/html-area-output.pdf"))

        End Sub
    End Class
End Namespace