
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    public class PageNumbers
    {
        public static void Run()
        {
            CreatePdf();
            MergePdf();
        }

        public static void CreatePdf()
        {
            Document document = new Document();
            Template documentTemplate = new Template();
            document.Template = documentTemplate;

            documentTemplate.Elements.Add(new PageNumberingLabel("%%PR%%%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center));

            document.Sections.Begin(NumberingStyle.RomanLowerCase);

            document.Pages.Add(new Page());
            document.Pages.Add(new Page());
            document.Pages.Add(new Page());

            document.Sections.Begin(NumberingStyle.Numeric);

            document.Pages.Add(new Page());
            document.Pages.Add(new Page());
            document.Pages.Add(new Page());

            document.Sections.Begin(NumberingStyle.RomanLowerCase, "Appendix A - ");

            document.Pages.Add(new Page());
            document.Pages.Add(new Page());
            document.Pages.Add(new Page());

            document.Draw(Util.GetPath("Output/AddPageNumbersToNewPdf.pdf"));


        }

        public static void MergePdf()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            Template template = new Template();
            PageNumberingLabel pageLabel = new PageNumberingLabel("%%CP%% of %%TP%%", 0, 0, 200, 20);
            template.Elements.Add(pageLabel);
            document.Template = template;
            document.Draw(Util.GetPath("Output/AddPageNumbersToExistingPdf.pdf"));
        }

    }
}
