Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger

Namespace dynamicpdf_vb_examples.Examples
    Public Class MergerActions
        Public Shared Sub Run()
            FormFillingFdfData()
        End Sub

        Public Shared Sub FormFillingFdfData()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"))
            document.Pages(0).ReaderEvents.Open = New ImportFormDataAction(Util.GetPath("Resources/Data/simple-form-fill_data.fdf"))
            document.Draw(Util.GetPath("Output/completed-fdf-form-filling-output.pdf"))
        End Sub
    End Class
End Namespace

