using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Forms;

namespace DynamicPDFCoreSuite.Examples
{
    class AnnotationsExample
    {
        public static void Run()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Button button = new Button("btn", 50, 150, 100, 30);
            button.Label = "Click Here";
            ceTe.DynamicPDF.PageElements.Forms.TextField field = new ceTe.DynamicPDF.PageElements.Forms.TextField("Text1", 330, 100, 100, 30);
            field.DefaultValue = "Text Field Value";
            AnnotationShowHideAction action = new AnnotationShowHideAction("Text1");
            button.ReaderEvents.MouseDown = action;

            page.Elements.Add(button);
            document.Draw(Util.GetPath("Output/annotations-example.pdf"));
        }
    }
}
