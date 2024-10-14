using ceTe.DynamicPDF.Forms;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.Merger.Forms;
using DynamicPDFCoreSuite.Examples;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    public class AcroformExamineExample
    {
        public static void Run()
        {
            PdfDocument document =new(Util.GetPath("Resources/PDFs/CV014ServiceRequest3.pdf"));
            PdfForm form = document.Form;

            for (int i = 0; i < form.Fields.Count; i++)
            {
                Console.WriteLine(form.Fields[i].Name + " | " + form.Fields[i].GetType());

                if (form.Fields[i].HasJavaScript())
                {
                    Console.WriteLine(form.Fields[i].GetJavaScriptString());
                }

            }

            MergeDocument doc = new MergeDocument(document);

            Form form2 = doc.Form;

  
            for(int i = 0; i < form2.Fields.Count; i ++)
            {
                Console.WriteLine(form2.Fields[i].Name + " | " + form2.Fields[i].GetType());
                
                if(form2.Fields[i] is ButtonField)
                {
                    form2.Fields[i].Output = FormFieldOutput.Remove;
                }                
            }

            string outputPath = Util.GetPath("Output/acroform-remove-output.pdf");
            doc.Draw(outputPath);
        }
    }
}
