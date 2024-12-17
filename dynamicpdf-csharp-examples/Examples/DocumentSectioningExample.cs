using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class DocumentSectioningExample
    {
        public static void Run()
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page());
            Template template = new Template();
            template.Elements.Add(new PageNumberingLabel("%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center));

            myDoc.Template = template;

            myDoc.Sections.Begin(NumberingStyle.RomanLowerCase);
            myDoc.Pages.Add(new Page()); //Page 1
            myDoc.Pages.Add(new Page()); //Page 2

            myDoc.Sections.Begin(NumberingStyle.Numeric, template);
            myDoc.Pages.Add(new Page()); //Page 3
            myDoc.Pages.Add(new Page()); //page 4
            myDoc.Pages.Add(new Page()); //page 5

            myDoc.Sections.Begin(NumberingStyle.RomanLowerCase, "Appendix A - ");
            myDoc.Pages.Add(new Page()); //page 6
            myDoc.Pages.Add(new Page()); //page 7

            myDoc.Draw(Util.GetPath("Output/document-sectioning-out.pdf"));
        }
    }
}
