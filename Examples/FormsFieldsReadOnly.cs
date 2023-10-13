using ceTe.DynamicPDF.Cryptography;
using ceTe.DynamicPDF.Merger;

namespace DynamicPDFCoreSuite.Examples
{
    class FormsFieldsReadOnly
    {

        public static void Run()
        {
            ExampleOne();
            ExampleTwo();
        }

        public static void ExampleOne()
        {
            ceTe.DynamicPDF.Merger.MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"));
            document.Form.Fields["nameField"].Value = "John Doe";
            document.Form.Fields["descriptionField"].Value = "Simple Form";
            document.Form.IsReadOnly = true;
            document.Draw(Util.GetPath("Output/readonly-form-field-output.pdf"));
        }

        public static void ExampleTwo()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"));
            document.Form.IsReadOnly = true;
            RC4128Security security = new RC4128Security("owner", "user");
            security.AllowFormFilling = false;
            security.AllowUpdateAnnotsAndFields = false;
            security.AllowEdit = false;
            document.Security = security;
            document.Draw(Util.GetPath("Output/readonly-encrypt-form-field-output.pdf"));
        }

    }
}


