using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Forms;

namespace DynamicPDFCoreSuite.Examples
{
    class ReaderEventExample
    {
        public static void Run()
        {
            WillSaveExample();
            OpenExample();
            TextExample();
        }


        public static void WillSaveExample()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            JavaScriptAction action = new JavaScriptAction("app.alert(\"Hello your text Saved!!\")");
            document.ReaderEvents.WillSave = action;

            document.Draw(Util.GetPath("Output/willsave-event-output.pdf"));
        }

        public static void OpenExample()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            JavaScriptAction action = new JavaScriptAction("app.alert(\"Welcome !!\")");
            page.ReaderEvents.Open = action;

            document.Draw(Util.GetPath("Output/open-event-output.pdf"));
        }

        public static void TextExample()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            TextField textField = new TextField("Text1", 0, 0, 100, 15);
            JavaScriptAction action = new JavaScriptAction("app.alert(\"Welcome !!\")");
            textField.ReaderEvents.OnFocus = action;

            page.Elements.Add(textField);

            document.Draw(Util.GetPath("Output/text-event-output.pdf"));
        }

    }
}
