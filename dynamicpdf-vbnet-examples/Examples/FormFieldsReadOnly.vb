Imports ceTe.DynamicPDF.Cryptography
Imports ceTe.DynamicPDF.Merger

Namespace DynamicPDFCoreSuite.Examples
    Class FormFieldsReadOnly

        Public Shared Sub Run()
            ExampleOne()
            ExampleTwo()
        End Sub

        Public Shared Sub ExampleOne()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"))
            document.Form.Fields("nameField").Value = "John Doe"
            document.Form.Fields("descriptionField").Value = "Simple Form"
            document.Form.IsReadOnly = True
            document.Draw(Util.GetPath("Output/readonly-form-field-output.pdf"))
        End Sub

        Public Shared Sub ExampleTwo()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"))
            document.Form.IsReadOnly = True
            Dim security As New RC4128Security("owner", "user")
            security.AllowFormFilling = False
            security.AllowUpdateAnnotsAndFields = False
            security.AllowEdit = False
            document.Security = security
            document.Draw(Util.GetPath("Output/readonly-encrypt-form-field-output.pdf"))
        End Sub

    End Class
End Namespace
