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
            float height = pdfDocument.Form.Fields["check_box_nm"].Height;
            float width = pdfDocument.Form.Fields["check_box_nm"].Width;
            string txt = "(" + x + ", " + y + ", " + width + ", " + height + ")";
            Label label = new Label(txt, x + width + 10, y, 100, 20);
            page.Elements.Add(label);
            document.Draw(Util.GetPath("Output/retrieve-form-field-dimensions-example-output.pdf"));
        }
    }
}
