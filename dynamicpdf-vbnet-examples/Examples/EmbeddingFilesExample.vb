Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Public Class EmbeddingFilesExample
        Public Shared Sub Run()
            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter))
            Dim label As New Label("Embedded Files Example", 50, 20, 215, 0)
            document.Pages(0).Elements.Add(label)

            Dim fileOne As String = Util.GetPath("Resources/PDFs/DocumentA.pdf")
            Dim fileTwo As String = Util.GetPath("Resources/PDFs/DocumentB.pdf")
            Dim fileThree As String = Util.GetPath("Resources/Images/DPDFLogo.png")
            Dim fileFour As String = Util.GetPath("Resources/Data/Doc1.docx")

            Dim embeddedFile1 As New EmbeddedFile(fileOne)
            Dim embeddedFile2 As New EmbeddedFile(fileTwo)
            Dim embeddedFile3 As New EmbeddedFile(fileThree)
            Dim embeddedFile4 As New EmbeddedFile(fileFour)

            document.EmbeddedFiles.Add(embeddedFile1)
            document.EmbeddedFiles.Add(embeddedFile2)
            document.EmbeddedFiles.Add(embeddedFile3)
            document.EmbeddedFiles.Add(embeddedFile4)

            document.Draw(Util.GetPath("Output/embedding-files-output.pdf"))
        End Sub
    End Class
End Namespace
