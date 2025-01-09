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
            Dim y2 As Single = pdfDocument.Form.Fields("text_field_name").GetY(page) + pdfDocument.Form.Fields("text_field_name").Height

            Dim rec As New Rectangle(x, y, 200, y2 - y)
            rec.FillColor = RgbColor.LightBlue
            rec.BorderColor = RgbColor.Navy
            page.Elements.Add(rec)

            document.Draw(Util.GetPath("Output/retrieve-form-field-dimensions-example-output.pdf"))
        End Sub
    End Class
End Namespace

