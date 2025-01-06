using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements.Forms;

namespace DynamicPDFCoreSuite.Examples
{
    public class FormFieldsRemoveAddExample
    {
        public static void Run()
        {
            Remove();
            Replace();
        }

        public static void Remove()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"));
            document.Form.Fields[0].Output = FormFieldOutput.Remove;
            document.Draw(Util.GetPath("Output/formfield-remove-example.pdf"));
        }

        public static void Replace()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"));
            document.Form.Fields[0].Output = FormFieldOutput.Remove;

            Page pg = document.Pages[0];

            CheckBox checkBox = new CheckBox("added_chk", 70, 90, 20, 20);
            checkBox.DefaultChecked = true;
            pg.Elements.Add(checkBox);

            document.Draw(Util.GetPath("Output/formfield-remove-add-example.pdf"));
        }

    }
}
