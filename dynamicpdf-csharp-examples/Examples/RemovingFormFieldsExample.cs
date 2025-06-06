
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;
using DynamicPDFCoreSuite.Examples;

namespace dynamicpdf_csharp_examples.Examples
{
    class RemovingFormFieldsExample
    {
        public static void Run()
        {
            RemoveAllFields();
            RemoveSingleField();
        }

        public static void RemoveAllFields()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/form-example.pdf"));
            document.Form.Output = FormOutput.Remove;
            document.Draw(Util.GetPath("Output/remove-all-form-fields-output.pdf"));
        }

        public static void RemoveSingleField()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/form-example.pdf"));
            document.Form.Fields["check_box_nm"].Output = FormFieldOutput.Remove;
            document.Draw(Util.GetPath("Output/remove-form-field-output.pdf"));
        }
    }
}
