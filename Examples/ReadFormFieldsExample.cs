using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPDFCoreSuite.Examples
{
    class ReadFormFieldsExample
    {

        public static void Run()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"));

            FormFieldList list = document.Form.Fields;

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("name: " + list[i].FullName + " value: " + list[i].Value);
            }

        }
    }
}
