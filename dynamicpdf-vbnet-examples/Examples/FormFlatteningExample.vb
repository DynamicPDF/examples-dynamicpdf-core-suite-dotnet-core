Imports ceTe.DynamicPDF.Forms
Imports ceTe.DynamicPDF.Merger

Namespace DynamicPDFCoreSuite.Examples
    Class FormFlatteningExample
        Public Shared Sub Run()
            ExampleOne()
            ExampleTwo()
        End Sub

        Public Shared Sub ExampleOne()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"))
            document.Form.Output = FormOutput.Flatten
            document.Draw(Util.GetPath("Output/form-flattening-one-output.pdf"))
        End Sub

        Public Shared Sub ExampleTwo()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"))
            document.Form.Fields(0).Output = FormFieldOutput.Flatten
            document.Draw(Util.GetPath("Output/form-flattening-two-output.pdf"))
        End Sub
    End Class
End Namespace

