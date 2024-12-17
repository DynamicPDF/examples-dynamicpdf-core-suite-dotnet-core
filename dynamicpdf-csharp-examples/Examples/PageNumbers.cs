using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class PageNumbers
    {
        public static void Run()
        {
            Merger();
            Generator();
        }
        public static void Merger()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));

            Template template = new Template();
            PageNumberingLabel pageLabels = new PageNumberingLabel("%%CP%% of %%TP%%", 0, 0, 200, 20);
            template.Elements.Add(pageLabels);
            document.Template = template;

            document.Draw(Util.GetPath("Output/AddPageNumberToExistingPDF.pdf"));
        }

        public static void Generator()
        {
            Document document = new Document();
            Template documentTemplate = new Template();
            document.Template = documentTemplate;

            documentTemplate.Elements.Add(new PageNumberingLabel("%%PR%%%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center));

            document.Sections.Begin(NumberingStyle.RomanLowerCase);

            document.Pages.Add(new Page()); //Page 1
            document.Pages.Add(new Page()); //Page 2
            document.Pages.Add(new Page()); //Page 3

            document.Sections.Begin(NumberingStyle.Numeric);

            document.Pages.Add(new Page()); //Page 4
            document.Pages.Add(new Page()); //page 5
            document.Pages.Add(new Page()); //page 6
            document.Pages.Add(new Page()); //page 7

            document.Sections.Begin(NumberingStyle.RomanLowerCase, "Appendix A - ");
            document.Pages.Add(new Page()); //page 8
            document.Pages.Add(new Page()); //page 9

            document.Draw(Util.GetPath("Output/AddPageNumberToNewPDF.pdf"));
        }
    }
}
