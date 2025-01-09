Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Forms
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements.Forms

Namespace DynamicPDFCoreSuite.Examples
    Public Class FormFieldsRemoveAddExample
        Public Shared Sub Run()
            Remove()
            Replace()
            RemoveAll()
            RemoveAllOutput()
        End Sub

        Public Shared Sub RemoveAllOutput()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"))
            document.Form.Output = FormOutput.Remove
            document.Draw(Util.GetPath("Output/formfield-remove-all-output-example.pdf"))
        End Sub

        Public Shared Sub RemoveAll()
            Dim mergeOptions As New MergeOptions()
            mergeOptions.FormFields = False
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"), mergeOptions)
            document.Draw(Util.GetPath("Output/formfield-remove-all-example.pdf"))
        End Sub

        Public Shared Sub Remove()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"))
            document.Form.Fields(0).Output = FormFieldOutput.Remove
            document.Draw(Util.GetPath("Output/formfield-remove-example.pdf"))
        End Sub

        Public Shared Sub Replace()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"))
            document.Form.Fields(0).Output = FormFieldOutput.Remove

            Dim pg As Page = document.Pages(0)

            Dim checkBox As New CheckBox("added_chk", 70, 90, 20, 20)
            checkBox.DefaultChecked = True
            pg.Elements.Add(checkBox)

            document.Draw(Util.GetPath("Output/formfield-remove-add-example.pdf"))
        End Sub
    End Class
End Namespace
