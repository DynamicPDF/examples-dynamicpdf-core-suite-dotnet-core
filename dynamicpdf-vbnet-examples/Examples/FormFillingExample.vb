Imports ceTe.DynamicPDF.Merger

Namespace dynamicpdf_vb_examples.Examples
    Class FormFillingExample
        Public Shared Sub Run()
            FillingForm()
            CombineFormsFill()
        End Sub

        Public Shared Sub FillingForm()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/form-example.pdf"))
            document.Form.Fields("check_box_nm").Value = "Yes"
            document.Form.Fields("combo_box_nm").Value = "Two"
            document.Form.Fields("list_box_nm").Value = "Three"
            document.Form.Fields("radio_button_name").Value = "ghi"
            document.Form.Fields("text_field_name").Value = "This is a text box."
            document.Draw(Util.GetPath("Output/form-filling-output.pdf"))
        End Sub

        Public Shared Sub CombineFormsFill()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/form-example.pdf"), New MergeOptions(True, "form1"))
            document.Append(Util.GetPath("Resources/PDFs/form-example.pdf"), New MergeOptions(True, "form2"))
            document.Form.Fields("form1.text_field_name").Value = "This is a text box."
            document.Form.Fields("form2.text_field_name").Value = "This is another text box."
            document.Draw(Util.GetPath("Output/form-filling-combine-output.pdf"))
        End Sub


    End Class
End Namespace

