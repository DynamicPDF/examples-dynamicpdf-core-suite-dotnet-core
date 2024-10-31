using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace DynamicPDFCoreSuite.Examples
{
    class Actions
    {
        public static void Run()
        {
            ChainAction();
            GoToAction();
            ResetAction();
            SubmitAction();
            UrlAction();
            FileOpenAction();
            AnnotationShowHideAction();
            XyDestinationZoomDestination();
        }

        public static void ChainAction()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            
            Label label = new Label("Text Field:", 0, 50, 100, 0);
            TextField textField = new TextField("text1", 100, 50, 150, 100);
            Label label2 = new Label("Hide All Fields:", 0, 10, 100, 0);
            CheckBox checkBox = new CheckBox("check_box_nm", 110, 7, 50, 50);

            Button button = new Button("btn", 50, 150, 100, 30);
            button.Label = "Hide";

            AnnotationShowHideAction action = new AnnotationShowHideAction("check_box_nm");
            action.NextAction = new AnnotationShowHideAction("text1");
            action.NextAction.NextAction = new JavaScriptAction("app.alert(\"Fields Hidden.\")");
            action.NextAction.NextAction.NextAction = new FileOpenAction(Util.GetPath("Resources/PDFs/DocumentA.pdf"), FileLaunchMode.NewWindow);

            button.ReaderEvents.MouseDown = action;
           

            document.Pages[0].Elements.Add(label);
            document.Pages[0].Elements.Add(checkBox);
            document.Pages[0].Elements.Add(label2);
            document.Pages[0].Elements.Add(textField);
            document.Pages[0].Elements.Add(button);

            document.Draw(Util.GetPath("Output/ChainingAction.pdf"));

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
            FileOpenAction action = new FileOpenAction(Util.GetPath("Resources/PDFs/DocumentA.pdf"), FileLaunchMode.NewWindow);
            button.ReaderEvents.MouseUp = action;
            
            page.Elements.Add(button);
            document.Draw(Util.GetPath("Output/FileOpenAction.pdf"));
        }

        public static void XyDestinationZoomDestination()
        {
            Document document = new Document();

            // Add three blank pages
            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));
            document.Pages.Add(new Page(PageSize.Letter));

            // Add a top level outline and set properties
            Outline outline1 = document.Outlines.Add("Outline1");
            outline1.Style = TextStyle.Bold;
            outline1.Color = new RgbColor(1.0f, 0.0f, 0.0f);

            // Add child outlines
            Outline outline1A = outline1.ChildOutlines.Add("Outline1A", new UrlAction("http://www.mydomain.com"));
            outline1A.Expanded = false;
            Outline outline1A1 = outline1A.ChildOutlines.Add("Outline1A1", new XYDestination(2, 0, 0));
            Outline outline1A2 = outline1A.ChildOutlines.Add("Outline1A2", new ZoomDestination(2, PageZoom.FitHeight));
            Outline outline1B = outline1.ChildOutlines.Add("Outline1B", new ZoomDestination(2, PageZoom.FitWidth));

            // Add a second top level outline
            Outline outline2 = document.Outlines.Add("Outline2", new XYDestination(3, 0, 300));

            // Add a child outline
            Outline outline2A = outline2.ChildOutlines.Add("Outline2A");

            // Save the PDF document
            document.Draw(Util.GetPath("Output/XyDestinationZoomDestinationAction.pdf"));
        }


    }
}
