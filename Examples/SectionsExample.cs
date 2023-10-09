using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class SectionsExample
    {
        public static void Run()
        {
            Document document = new Document();
            Template template = new Template();
            template.Elements.Add(new PageNumberingLabel("%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center));

            document.Sections.Begin(NumberingStyle.RomanLowerCase);
            document.Pages.Add(new Page()); //Page 1
            document.Pages.Add(new Page()); //Page 2

            document.Sections.Begin(NumberingStyle.Numeric, template);
            document.Pages.Add(new Page()); //Page 3
            document.Pages.Add(new Page()); //page 4
            document.Pages.Add(new Page()); //page 5

            document.Sections.Begin(NumberingStyle.RomanLowerCase, "Appendix A - ");
            document.Pages.Add(new Page()); //page 6
            document.Pages.Add(new Page()); //page 7

            document.Draw(Util.GetPath("Output/sections-output.pdf"));
        }
    }
}
