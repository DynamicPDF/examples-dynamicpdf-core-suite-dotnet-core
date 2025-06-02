Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Public Class AddImageExample
    Public Shared Sub Run()
        ImageExample()
        BackgroundImageExample()
    End Sub

    Public Shared Sub ImageExample()
        Dim document As New Document()

        Dim page As New Page()
        document.Pages.Add(page)

        Dim image As New Image(Util.GetPath("Resources/Images/DynamicPDF_top.gif"), 0, 0)
        page.Elements.Add(image)

        document.Draw(Util.GetPath("Output/images-one-example.pdf"))
    End Sub

    Public Shared Sub BackgroundImageExample()
        Dim document As New Document()

        Dim page As New Page()
        document.Pages.Add(page)

        Dim backgroundImage As New BackgroundImage(Util.GetPath("Resources/Images/DPDFLogo_Watermark.png"))
        backgroundImage.UseMargins = True

        page.Elements.Add(backgroundImage)

        document.Draw(Util.GetPath("Output/background-image-example.pdf"))
    End Sub
End Class

