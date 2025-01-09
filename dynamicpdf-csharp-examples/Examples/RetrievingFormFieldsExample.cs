using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class RetrievingFormFieldsExample
    {
        public static void Run()
        {
            PdfDocument pdfDocument = new PdfDocument(Util.GetPath("Resources/PDFs/form-example.pdf"));
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/form-example.pdf"));
            Page page = document.Pages[0];
            
            float x = pdfDocument.Form.Fields["check_box_nm"].GetX(page);
            float y = pdfDocument.Form.Fields["check_box_nm"].GetY(page);
            float y2 = pdfDocument.Form.Fields["text_field_name"].GetY(page) + pdfDocument.Form.Fields["text_field_name"].Height;

            Rectangle rec = new Rectangle(x, y, 200, y2 - y);
            rec.FillColor = RgbColor.LightBlue;
            rec.BorderColor = RgbColor.Navy;
            page.Elements.Add(rec);
            document.Draw(Util.GetPath("Output/retrieve-form-field-dimensions-example-output.pdf"));
        }
    }
}
