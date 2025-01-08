using ceTe.DynamicPDF.Merger;
using DynamicPDFCoreSuite.Examples;

namespace dynamicpdf_csharp_examples.Examples
{
    class FormFillingExample
    {
        public static void Run()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/form-example.pdf"));
            document.Form.Fields["check_box_nm"].Value = "Yes";
            document.Form.Fields["combo_box_nm"].Value = "Two";
            document.Form.Fields["list_box_nm"].Value = "Three";
            document.Form.Fields["radio_button_name"].Value = "ghi";
            document.Form.Fields["text_field_name"].Value = "This is a text box.";
            document.Draw(Util.GetPath("Output/form-filling-output.pdf"));
        }
    }
}
