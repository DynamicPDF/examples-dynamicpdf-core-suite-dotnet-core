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

            SubmitAction submitAction = new SubmitAction("www.mydomain.com", FormExportFormat.HtmlPost);
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

            UrlAction action = new UrlAction("http://www.mydomain.com");
            Link link = new Link(50, 50, Font.Helvetica.GetTextWidth("My Domain", 18), 20, action);

            page.Elements.Add(link);
            document.Draw(Util.GetPath("Output/UrlAction.pdf"));
        }

        public static void FileOpenAction()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Button button = new Button("btn", 50, 150, 100, 30);
            button.Label = "Click Here";
            FileOpenAction action = new FileOpenAction(@"Path of the file to open", FileLaunchMode.NewWindow);
            button.ReaderEvents.MouseUp = action;
            
            page.Elements.Add(button);
            document.Draw(Util.GetPath("Output/FileOpenAction.pdf"));
        }
    }
}
