using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPDFCoreSuite.Examples
{
    class FormFlatteningExample
    {
        public static void Run()
        {
            ExampleOne();
            ExampleTwo();
        }

        public static void ExampleOne()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"));
            document.Form.Output = FormOutput.Flatten;
            document.Draw(Util.GetPath("Output/form-flattening-one-output.pdf"));
        }

        public static void ExampleTwo()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"));
            document.Form.Fields[0].Output = FormFieldOutput.Flatten;
            document.Draw(Util.GetPath("Output/form-flattening-two-output.pdf"));
        }
    }
}
