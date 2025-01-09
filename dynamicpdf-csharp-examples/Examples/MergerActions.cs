
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using DynamicPDFCoreSuite.Examples;

namespace dynamicpdf_csharp_examples.Examples
{
    public class MergerActions
    {
        public static void Run()
        {
            FormFillingFdfData();
        }

        public static void FormFillingFdfData()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"));
            document.Pages[0].ReaderEvents.Open = new ImportFormDataAction((Util.GetPath("Resources/Data/simple-form-fill_data.fdf")));
            document.Draw(Util.GetPath("Output/completed-fdf-form-filling-output.pdf"));
        }
    }
}
