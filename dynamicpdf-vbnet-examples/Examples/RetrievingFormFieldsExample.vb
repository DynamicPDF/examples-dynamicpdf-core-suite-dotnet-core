Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples

    Class RetrievingFormFieldsExample

        Public Shared Sub Run()
            Dim pdfDocument As New PdfDocument(Util.GetPath("Resources/PDFs/form-example.pdf"))
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/form-example.pdf"))
            Dim page As Page = document.Pages(0)

            Dim x As Single = pdfDocument.Form.Fields("check_box_nm").GetX(page)
            Dim y As Single = pdfDocument.Form.Fields("check_box_nm").GetY(page)
            Dim height As Single = pdfDocument.Form.Fields("check_box_nm").Height
            Dim width As Single = pdfDocument.Form.Fields("check_box_nm").Width

            Dim txt As String = "(" & x.ToString() & ", " & y.ToString() & ", " & width.ToString() & ", " & height.ToString() & ")"
            Dim label As New Label(txt, x + width + 10, y, 100, 20)

            page.Elements.Add(label)

            document.Draw(Util.GetPath("Output/retrieve-form-field-dimensions-example-output.pdf"))
        End Sub

    End Class

End Namespace


