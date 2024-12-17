Imports ceTe.DynamicPDF

Namespace DynamicPDFCoreSuite.Examples
    Public Class PdfXCompatibleExample
        Public Shared Sub Run()
            Dim document As New Document()
            document.Title = "PDF/X-1a Document"
            document.PdfVersion = PdfVersion.v1_4
            document.PdfXVersion = PdfXVersion.PDF_X_1a_2003
            document.Pages.Add(New Page())

            Dim iccProfile As New IccProfile(Util.GetPath("Resources/Data/USWebCoatedSWOP.icc"))
            Dim outputIntent As New OutputIntent("CGATS TR 001-1995 (SWOP)", "CGATS TR 001", "http://www.color.org", "U.S. Web Coated (SWOP) v2", iccProfile)
            document.OutputIntents.Add(outputIntent)
            document.Trapped = Trapped.False

            document.Draw(Util.GetPath("Output/pdfx-output.pdf"))
        End Sub
    End Class
End Namespace

