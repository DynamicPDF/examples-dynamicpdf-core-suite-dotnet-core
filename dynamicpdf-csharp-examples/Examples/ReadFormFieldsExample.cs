using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;
using System.IO;

namespace DynamicPDFCoreSuite.Examples
{
    class ReadFormFieldsExample
    {

        public static void Run()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"));
            FormFieldList list = document.Form.Fields;
            string output = "Field values\n";

            for (int i = 0; i < list.Count; i++)
            {
                output += "name: " + list[i].FullName + " value: " + list[i].Value + "\n";
            }

            File.WriteAllText(Util.GetPath("Output/read-form-fields-output.txt"), output);
        }
    }
}
