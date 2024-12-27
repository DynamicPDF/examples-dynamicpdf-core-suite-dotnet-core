Imports ceTe.DynamicPDF.Merger
Imports System.IO

Namespace DynamicPDFCoreSuite.Examples
    Class MergePDFs
        Public Shared Sub Run()
            MergePDF()
            AppendPDF()
            MergeOption()
            MergeFromStream()
            MergeFromByteArray()
        End Sub

        Public Shared Sub MergePDF()
            Dim document As MergeDocument = MergeDocument.Merge(Util.GetPath("Resources/PDFs/DocumentA.pdf"), Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            document.Draw(Util.GetPath("Output/merge-output.pdf"))
        End Sub

        Public Shared Sub AppendPDF()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            document.Append(Util.GetPath("Resources/PDFs/DocumentC.pdf"))
            document.Draw(Util.GetPath("Output/append-pdf-output.pdf"))
        End Sub

        Public Shared Sub MergeFromStream()
            Dim streamA As Stream = File.OpenRead(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            Dim streamB As Stream = File.OpenRead(Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            Dim streamC As Stream = File.OpenRead(Util.GetPath("Resources/PDFs/DocumentC.pdf"))
            Dim document As New MergeDocument(New PdfDocument(streamA))
            document.Append(New PdfDocument(streamB), 1, 2)
            document.Append(New PdfDocument(streamC))
            document.Draw(Util.GetPath("Output/stream-pdf-output.pdf"))
        End Sub

        Public Shared Sub MergeFromByteArray()
            Dim dataA As Byte() = File.ReadAllBytes(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            Dim dataB As Byte() = File.ReadAllBytes(Util.GetPath("Resources/PDFs/DocumentB.pdf"))
            Dim dataC As Byte() = File.ReadAllBytes(Util.GetPath("Resources/PDFs/DocumentC.pdf"))

            Dim document As New MergeDocument(New PdfDocument(dataA))
            document.Append(New PdfDocument(dataB), 1, 2)
            document.Append(New PdfDocument(dataC))
            document.Draw(Util.GetPath("Output/byte-pdf-output.pdf"))
        End Sub

        Public Shared Sub MergeOption()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))
            Dim options As MergeOptions = MergeOptions.Append
            options.Outlines = False
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"), options)
            document.Append(Util.GetPath("Resources/PDFs/DocumentC.pdf"))
            document.Draw(Util.GetPath("Output/merge-options-output.pdf"))
        End Sub
    End Class
End Namespace

