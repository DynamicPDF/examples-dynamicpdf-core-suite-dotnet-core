using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    class FormFieldNamesExample
    {
        public static void Run()
        {
            ceTe.DynamicPDF.Merger.MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"));

            FormFieldList list = document.Form.Fields;

            for(int i = 0; i < list.Count;i++)
            {
                Console.WriteLine(list[i].FullName);
            }

        }
    }
}
