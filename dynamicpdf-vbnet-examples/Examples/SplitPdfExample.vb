Imports ceTe.DynamicPDF.Merger

Namespace DynamicPDFCoreSuite.Examples
    Class SplitPdfExample
        Public Shared Sub Run()
            Dim pdf As New PdfDocument(Util.GetPath("Resources/PDFs/TimeMachine.pdf"))

            Dim part1 As New MergeDocument(pdf, 1, 4)
            part1.Draw(Util.GetPath("Output/TimeMachinePart1.pdf"))

            Dim part2 As New MergeDocument(pdf, 5, 8)
            part2.Draw(Util.GetPath("Output/TimeMachinePart2.pdf"))
        End Sub
    End Class
End Namespace

