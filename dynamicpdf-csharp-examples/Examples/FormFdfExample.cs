
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;
using DynamicPDFCoreSuite.Examples;

namespace dynamicpdf_csharp_examples.Examples
{
    public class FormFdfExample
    {
        public static void Run()
        {
            FormFillingFdfData();
            FormFillingFdfDataDocument();
        }

        public static void FormFillingFdfData()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"));
            document.Pages[0].ReaderEvents.Open = new ImportFormDataAction((Util.GetPath("Resources/Data/simple-form-fill_data.fdf")));
            document.Draw(Util.GetPath("Output/completed-fdf-form-filling-mergedocument-output.pdf"));
        }

        public static void FormFillingFdfDataDocument()
        {
            Document document = new Document();

            // Create a page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create label and text field
            Label label1 = new Label("Name:", 0, 0, 250, 30);
            TextField nameField = new TextField("nameField", 100, 0, 200, 25);
            Label label2 = new Label("Description:", 0, 100, 100, 30);
            TextField descriptionField = new TextField("descriptionField", 150, 100, 200, 50);
            Button button = new Button("btn", 50, 250, 100, 30);
            button.Label = "Fill Form";

            // Add the label and form fields to the page
            page.Elements.Add(button);
            page.Elements.Add(nameField);
            page.Elements.Add(descriptionField);
            page.Elements.Add(label1);
            page.Elements.Add(label2);

            // Create a import form data action and assign to the button events.
            ImportFormDataAction action = new ImportFormDataAction((Util.GetPath("Resources/Data/simple-form-fill_data.fdf")));
            button.ReaderEvents.MouseUp = action;

            // Save the PDF
            document.Draw(Util.GetPath("Output/completed-fdf-form-filling-document-output.pdf"));
        }
    }
}
