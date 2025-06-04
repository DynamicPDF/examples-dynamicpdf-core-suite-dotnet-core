Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Imaging

Class TiffToPDF
    Public Shared Sub Run()
        Dim tiffFile As New TiffFile(Util.GetPath("Resources/Images/fw9_18.tif"))
        Dim document As Document = tiffFile.GetDocument()
        document.Draw(Util.GetPath("Output/TiffToPDF.pdf"))
    End Sub
End Class

