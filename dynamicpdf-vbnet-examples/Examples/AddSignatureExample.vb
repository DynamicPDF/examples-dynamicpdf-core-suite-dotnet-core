Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Forms

Public Class AddSignatureExample

        Public Shared Sub Run()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)

            Dim signature As New Signature("MySigField", 10, 10, 300, 100)
            signature.FullPanel.SetImage(Util.GetPath("Resources/Images/DynamicPDF_top.gif"))
            signature.LeftPanel.TextColor = RgbColor.Red
            signature.Font = Font.TimesRoman

            page.Elements.Add(signature)

            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/add-signature-example.pdf"))
        End Sub

    End Class

