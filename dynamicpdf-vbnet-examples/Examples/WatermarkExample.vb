Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Class WatermarkExample

    Public Shared Sub Run()
        ImageWaterMarkExample()
        TextWatermarkExample()
        TemplateWatermarkExample()
        TemplateNewDocWatermarkExample()
    End Sub

    Public Shared Sub TemplateNewDocWatermarkExample()
        Dim document As New Document()
        document.Pages.Add(New Page(PageSize.Letter))
        document.Pages.Add(New Page(PageSize.Letter))

        Dim image As New Image(Util.GetPath("Resources/Images/stamp.png"), 0, 0)

        Dim watermarkTemplate As New Template()
        watermarkTemplate.Elements.Add(image)

        document.Template = watermarkTemplate

        document.Draw(Util.GetPath("Output/templatewatermark-newdoc-output.pdf"))
    End Sub


    Public Shared Sub ImageWaterMarkExample()
        Dim document As New Document()
        Dim page As New Page()
        document.Pages.Add(page)

        Dim imageWm As New ImageWatermark(Util.GetPath("Resources/Images/large-logo.png"))
        imageWm.ScaleX = 0.75F
        imageWm.ScaleY = 0.75F
        page.Elements.Add(imageWm)

        document.Draw(Util.GetPath("Output/imagewatermark-output.pdf"))
    End Sub

    Public Shared Sub TextWatermarkExample()
        Dim document As New Document()
        Dim page As New Page()
        document.Pages.Add(page)

        Dim text As String = "This is a text watermark."
        Dim twm As New TextWatermark(text)
        page.Elements.Add(twm)

        document.Draw(Util.GetPath("Output/textwatermark-output.pdf"))
    End Sub

    Public Shared Sub TemplateWatermarkExample()
        Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
        Dim image As New Image(Util.GetPath("Resources/Images/stamp.png"), 0, 0)

        Dim watermarkTemplate As New Template()
        watermarkTemplate.Elements.Add(image)
        document.Template = watermarkTemplate

        document.Draw(Util.GetPath("Output/templatewatermark-output.pdf"))
    End Sub

End Class
