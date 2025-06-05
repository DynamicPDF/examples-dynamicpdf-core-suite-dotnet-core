Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Class ImageStampExample

        Public Shared Sub Run()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentB.pdf"))

            Dim image As New Image(Util.GetPath("Resources/images/stamp.png"), 0, 0)
            Dim stampTemplate As New Template()
            stampTemplate.Elements.Add(image)

            document.StampTemplate = stampTemplate

            document.Draw(Util.GetPath("Output/stamped-output.pdf"))
        End Sub

    End Class
End Namespace

