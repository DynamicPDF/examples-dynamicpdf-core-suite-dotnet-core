Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Forms
Imports ceTe.DynamicPDF.Merger
Imports DynamicPDFCoreSuite.Examples

Namespace dynamicpdf_vbnet_examples.Examples
    Class RemovingFormFieldsExample

        Public Shared Sub Run()
            RemoveAllFields()
            RemoveSingleField()
        End Sub

        Public Shared Sub RemoveAllFields()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/form-example.pdf"))
            document.Form.Output = FormOutput.Remove
            document.Draw(Util.GetPath("Output/remove-all-form-fields-output.pdf"))
        End Sub

        Public Shared Sub RemoveSingleField()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/form-example.pdf"))
            document.Form.Fields("check_box_nm").Output = FormFieldOutput.Remove
            document.Draw(Util.GetPath("Output/remove-form-field-output.pdf"))
        End Sub

    End Class
End Namespace

