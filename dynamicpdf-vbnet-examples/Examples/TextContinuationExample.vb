Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports dynamicpdf_vbnet_examples.DynamicPDFCoreSuite.Utility
Imports DynamicPDFCoreSuite.Utility

Namespace DynamicPDFCoreSuite.Examples
    Public Class TextContinuationExample
        Public Shared Sub Run()
            Dim document As New Document()

            Dim textArea As New TextArea(TextGenerator.GenerateLargeTextDoc(), 0, 0, 512, 692, Font.Helvetica, 14)

            Do
                Dim page As New Page()
                page.Elements.Add(textArea)
                document.Pages.Add(page)
                textArea = textArea.GetOverflowTextArea()
            Loop While textArea IsNot Nothing

            document.Draw(Util.GetPath("Output/text-area-overflow-example.pdf"))
        End Sub
    End Class
End Namespace

