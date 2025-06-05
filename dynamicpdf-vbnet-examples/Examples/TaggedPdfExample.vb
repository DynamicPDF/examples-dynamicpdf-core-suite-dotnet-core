Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples

    Class TaggedPdfExample

        Public Shared Sub Run()
            Dim document As New Document()
            document.Tag = New TagOptions(True)

            Dim page As New Page()
            document.Pages.Add(page)

            Dim image As New Image(Util.GetPath("Resources/Images/DynamicPDF_top.gif"), 180.0F, 150.0F, 0.24F)
            image.Height = 200
            image.Width = 200

            Dim imageStructureElement As New StructureElement(TagType.Figure)
            imageStructureElement.IncludeDefaultAttributes = True
            imageStructureElement.AlternateText = "DynamicPDF Logo"

            image.Tag = imageStructureElement
            page.Elements.Add(image)

            document.Draw(Util.GetPath("Output/tagged-pdf-output.pdf"))
        End Sub

    End Class

End Namespace

