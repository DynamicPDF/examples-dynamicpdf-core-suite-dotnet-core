using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace DynamicPDFCoreSuite.Examples
{
    class Actions
    {
        public static void Run()
        {
            GoToAction();
            ResetAction();
            SubmitAction();
            UrlAction();
            FileOpenAction();
            AnnotationShowHideAction();
        }

        public static void AnnotationShowHideAction()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            Button button = new Button("btn", 50, 150, 100, 30);
            button.Label = "Hide";
            TextField field = new TextField("Text1", 330, 100, 100, 30);
            field.DefaultValue = "Text Field Value";
            AnnotationShowHideAction action = new AnnotationShowHideAction("Text1");
            button.ReaderEvents.MouseDown = action;

            Button button2 = new Button("btn", 175, 150, 100, 30);
            button2.Label = "Show";
            AnnotationShowHideAction action2 = new AnnotationShowHideAction("Text1");
            action2.ShowField = true;
            button2.ReaderEvents.MouseDown = action2;

            page.Elements.Add(button);
            page.Elements.Add(button2);
            page.Elements.Add(field);
            document.Draw(Util.GetPath("Output/AnnotationShowHideAction.pdf"));

        }

        public static void GoToAction()
        {
            Document document = new Document();
            Page page1 = new Page();
            document.Pages.Add(page1);
            Page page2 = new Page();
            page2.Elements.Add(new Label("Page 2", 0, 0, 100, 15));
            document.Pages.Add(page2);

            Button button = new Button("btn", 50, 150, 100, 30);
            button.Label = "Click Here";
            GoToAction action = new GoToAction(2, PageZoom.FitWidth);
            button.ReaderEvents.MouseUp = action;

            page1.Elements.Add(button);
            document.Draw(Util.GetPath("Output/GoToAction.pdf"));
        }

        public static void ResetAction()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            ResetAction action = new ResetAction();
            Button button = new Button("btn", 50, 300, 100, 50);
            button.Label = "Reset";
            button.ReaderEvents.MouseEnter = action;

            page.Elements.Add(button);
            document.Draw(Util.GetPath("Output/ResetAction.pdf"));
        }

        public static void SubmitAction()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            Label label = new("Checked?", 0, 0, 100, 0);
            CheckBox checkBox = new("checked", label.Width + 5, 0, 20, 20);
            checkBox.DefaultChecked = false;
            page.Elements.Add(label);
            page.Elements.Add(checkBox);

            SubmitAction submitAction = new SubmitAction("http://www.mydomain.com", FormExportFormat.HtmlPost);
            Button button = new Button("btn", 50, 300, 100, 50);
            button.Label = "Submit";
            button.Action = submitAction;

            page.Elements.Add(button);
            document.Draw(Util.GetPath("Output/SubmitAction.pdf"));
        }

        public static void UrlAction()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Font font = Font.TimesRoman;
            string text = "This is a link to DynamicPDF.com.";
          
            Label label = new Label(text, 50, 20, 215, 80, font, 12, RgbColor.Blue);
            label.Underline = true;
            Link link = new Link(50, 20, font.GetTextWidth(text, 12),
                12 - font.GetDescender(12), new UrlAction("http://www.dynamicpdf.com"));

            UrlAction action = new UrlAction("http://www.dynamicpdf.com");
            Button button = new Button("btn", 50, 100, 100, 50);
            button.Label = "Click";
            button.Action = action;

            page.Elements.Add(label);
            page.Elements.Add(link);
            page.Elements.Add(button);
            document.Draw(Util.GetPath("Output/UrlAction.pdf"));
        }

        public static void FileOpenAction()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Button button = new Button("btn", 50, 150, 100, 30);
            button.Label = "Click Here";
            FileOpenAction action = new FileOpenAction(Util.GetPath("Output/UrlAction.pdf"), FileLaunchMode.NewWindow);
            button.ReaderEvents.MouseUp = action;
            
            page.Elements.Add(button);
            document.Draw(Util.GetPath("Output/FileOpenAction.pdf"));
        }
    }
}
