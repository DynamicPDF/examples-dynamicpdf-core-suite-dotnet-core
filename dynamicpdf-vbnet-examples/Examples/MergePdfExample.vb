Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements
Imports dynamicpdf_vbnet_examples.DynamicPDFCoreSuite.Utility
Imports System.IO

Namespace DynamicPDFCoreSuite.Examples
    Class MergePdfExample
        Public Shared Sub Run()
            MergePDF()
            AppendPDF()
            MergeOption()
            MergeOptionStatic()
            MergeOptionStaticTwo()
            MergeFromStream()
            MergeFromByteArray()
            MergeToDocument()
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
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"), MergeOptions.All)
            Dim options As New MergeOptions() With {
                .Outlines = False,
                .LogicalStructure = False,
                .EmbeddedFiles = False
            }

            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"), options)
            document.Append(Util.GetPath("Resources/PDFs/outline-example.pdf"))
            document.Draw(Util.GetPath("Output/merge-options-output.pdf"))
        End Sub

        Public Shared Sub MergeOptionStaticTwo()
            Dim document As MergeDocument = MergeDocument.Merge(Util.GetPath("Resources/PDFs/DocumentB.pdf"), MergeOptions.None, Util.GetPath("Resources/PDFs/outline-example.pdf"), MergeOptions.None)
            document.Draw(Util.GetPath("Output/merge-options-static-two-output.pdf"))
        End Sub

        Public Shared Sub MergeOptionStatic()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"), MergeOptions.None)
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"), MergeOptions.None)
            document.Append(Util.GetPath("Resources/PDFs/outline-example.pdf"), MergeOptions.All)
            document.Draw(Util.GetPath("Output/merge-options-static-output.pdf"))
        End Sub

        Public Shared Sub MergeToDocument()
            Dim document As New Document()
            Dim pdfDoc As New PdfDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"))

            Dim page As New Page(PageSize.Letter)
            Dim lbl As New Label("New PDF Document, Multiple Pages", 0, 400, 400, 100) With {
                .FontSize = 24,
                .TextColor = RgbColor.Navy
            }
            page.Elements.Add(lbl)
            document.Pages.Add(page)

            Dim textArea As New TextArea(TextGenerator.GenerateLargeTextDoc(), 0, 0, 512, 692, Font.Helvetica, 14)

            Do
                Dim pageN As New Page()
                pageN.Elements.Add(textArea)
                document.Pages.Add(pageN)
                textArea = textArea.GetOverflowTextArea()
            Loop While textArea IsNot Nothing

            Dim mergeDoc As MergeDocument = MergeDocument.Merge(New PdfDocument(document.Draw()), pdfDoc)
            mergeDoc.Draw(Util.GetPath("Output/doc-new-exist-merge-output.pdf"))
        End Sub
    End Class
End Namespace
