using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace DynamicPDFCoreSuite.Examples
{
    class EventsExample
    {
        public static void Run()
        {
            PageReaderEvents();
            DocumentReaderEvents();
            FormFieldEvents();
        }

        public static void PageReaderEvents()
        {
            Document document = new Document();
            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));
            Page page = document.Pages[1];
            JavaScriptAction action = new JavaScriptAction("app.alert(\"Welcome !!\")");
            page.ReaderEvents.Open = action;

            JavaScriptAction action2 = new JavaScriptAction("app.alert(\"Goodbye !!\")");
            page.ReaderEvents.Close = action2;
            document.Pages.Add(new Page(PageSize.Letter));
            document.Draw(Util.GetPath("Output/page-reader-events-output.pdf"));

        }

        public static void DocumentReaderEvents()
        {
            Document document = new Document();
            document.Pages.Add(new Page(PageSize.Letter));
            Label lbl = new Label("Page One", 10, 200, 200, 100);
            document.Pages[0].Elements.Add(lbl);

            JavaScriptAction action = new JavaScriptAction("app.alert(\"Will Save.\")");
            document.ReaderEvents.WillSave = action;

            JavaScriptAction action2 = new JavaScriptAction("app.alert(\"Goodbye !!\")");
            document.ReaderEvents.WillClose = action2;

            document.Draw(Util.GetPath("Output/document-reader-events-output.pdf"));
        }

        public static void FormFieldEvents()
        {
            Document document = new Document();
            document.Pages.Add(new Page(PageSize.Letter));

            Label label = new Label("Check Box:", 0, 10, 100, 0);
            CheckBox checkBox = new CheckBox("check_box_nm", 110, 7, 50, 50);
            checkBox.DefaultChecked = true;
            checkBox.ToolTip = "Check it";

            JavaScriptAction action = new JavaScriptAction("app.alert(\"focus !!\")");
            checkBox.ReaderEvents.OnFocus = action;

            JavaScriptAction action2 = new JavaScriptAction("app.alert(\"mouse-down !!\")");
            checkBox.ReaderEvents.MouseDown = action2;

            document.Pages[0].Elements.Add(label);
            document.Pages[0].Elements.Add(checkBox);

            document.Draw(Util.GetPath("Output/form-reader-events-output.pdf"));
        }
    }
}
