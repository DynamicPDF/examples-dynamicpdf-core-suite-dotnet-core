using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class AddTemplateExample
    {

        public static void Run()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Template template = new Template(); 
            template.Elements.Add(new Label("Header", 0, 0, 200, 12));
            document.Template = template;
            document.Draw(Util.GetPath("Output/template-output.pdf"));
        }

    }
}
