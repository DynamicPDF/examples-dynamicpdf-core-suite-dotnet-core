
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class RetrievingFormFieldsExample
    {
        public static void Run()
        {
            PdfDocument pdfDocument = new PdfDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"));
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"), MergeOptions.None);
            Page page = document.Pages[0];
            Image image = new Image(Util.GetPath("Resources/Images/DynamicPDF_top.gif"), 0, 0);
            image.X = pdfDocument.Form.Fields["nameField"].GetX(page);
            image.Y = pdfDocument.Form.Fields["descriptionField"].GetY(page);
            image.Height = pdfDocument.Form.Fields["descriptionField"].Height;
            image.Width = pdfDocument.Form.Fields["descriptionField"].Width;
            page.Elements.Add(image);
            document.Draw(Util.GetPath("Output/retrieve-form-field-example-output.pdf"));
        }
    }
}
