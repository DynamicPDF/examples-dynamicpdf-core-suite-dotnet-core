
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
            template.Elements.Add(new PageNumberingLabel("%%SP%% of %%ST%%", 0, 680, 512, 12, Font.Helvetica, 32, TextAlign.Center));
            document.Sections.Begin(NumberingStyle.Numeric, template);
            document.Pages.Add(new Page());
            document.Sections.Begin(NumberingStyle.AlphabeticUpperCase, template);
            document.Pages.Add(new Page());
            document.Pages.Add(new Page());
            document.Pages.Add(new Page());
            document.Sections.Begin(NumberingStyle.RomanUpperCase, template);
            document.Pages.Add(new Page());
            document.Pages.Add(new Page());
            document.Pages.Add(new Page());
            document.Pages[3].ApplySectionTemplate = false;
            document.Draw(Util.GetPath("Output/sections-output.pdf"));
        }

    }
}
