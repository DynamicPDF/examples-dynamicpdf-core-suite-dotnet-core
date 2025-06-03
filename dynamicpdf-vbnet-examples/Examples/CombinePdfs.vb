Imports ceTe.DynamicPDF.Merger

Namespace DynamicPDFCoreSuite.Examples
    Public Class CombinePDFs

        Public Shared Sub Run()
            CombinePDF()
            CombinePDFWithOptions()
        End Sub

        Public Shared Sub CombinePDF()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            document.Append(Util.GetPath("Resources/PDFs/DocumentC.pdf"), 1, 2)
            document.Draw(Util.GetPath("Output/CombinePDFs.pdf"))
        End Sub

        Public Shared Sub CombinePDFWithOptions()
            Dim options As MergeOptions = MergeOptions.All
            options.DocumentProperties = False
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"), options)
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            document.Draw(Util.GetPath("Output/CombinePDFWithOptions.pdf"))
        End Sub

    End Class
End Namespace
