using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

namespace DynamicPDFCoreSuite.Examples
{
    class JavascriptActionExample
    {
        public static void Run()
        {
            ExampleOne();
            ExampleTwo();
            ExampleThree();
            ExampleFour();
            ExampleFive();
            ExampleSix();
        }

        public static void ExampleOne()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            ceTe.DynamicPDF.PageElements.Label label1 = new ceTe.DynamicPDF.PageElements.Label("Please Enter your Date of Birth :", 50, 50, 200, 50);
            TextField textField1 = new TextField("dob", 270, 50, 100, 50);
            textField1.ReaderEvents.OnBlur = new JavaScriptAction(" var no = this.getField(\"dob\").value; var temp = Math.abs(new Date(Date.now()).getTime() - new Date(no).getTime()); var days = Math.ceil(temp / (1000 * 3600 * 24));this.getField(\"age\").value = Math.floor(days/365); ");
            page.Elements.Add(label1);
            page.Elements.Add(textField1);
            ceTe.DynamicPDF.PageElements.Label label2 = new ceTe.DynamicPDF.PageElements.Label("Your Age is :", 50, 120, 100, 50);
            TextField textField2 = new TextField("age", 270, 120, 100, 50);
            page.Elements.Add(label2);
            page.Elements.Add(textField2);

            document.Draw(Util.GetPath("Output/javascript-action-one-output.pdf"));
        }

        public static void ExampleTwo()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            ceTe.DynamicPDF.PageElements.Label label1 = new ceTe.DynamicPDF.PageElements.Label("Please Enter a Number :", 50, 50, 200, 50);
            TextField textField1 = new TextField("number", 270, 50, 100, 50);
            textField1.ReaderEvents.OnBlur = new JavaScriptAction("var no = this.getField(\"number\").value; this.getField(\"number\").value = no.toFixed(2); ");
            page.Elements.Add(label1);
            page.Elements.Add(textField1);

            document.Draw(Util.GetPath("Output/javascript-action-two-output.pdf"));
        }

        public static void ExampleThree()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Label label = new Label("Please Enter a Number :", 0, 50, 150, 30);
            ceTe.DynamicPDF.PageElements.Forms.TextField textField = new ceTe.DynamicPDF.PageElements.Forms.TextField("txt", 170, 30, 150, 30);
            textField.DefaultValue = "0";
            textField.ToolTip = "Enter only Numbers";
            textField.ReaderEvents.OnBlur = new JavaScriptAction(" var no = this.getField(\"txt\").value; if( isNaN(no)) { app.alert(\"Please Enter number in the text field\"); } ");
            page.Elements.Add(textField);
            page.Elements.Add(label);

            document.Draw(Util.GetPath("Output/javascript-action-three-output.pdf"));
        }

        public static void ExampleFour()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            JavaScriptAction action = new JavaScriptAction("this.print({bUI: false, bSilent: true, bShrinkToFit: true});");

            Button button = new Button("Button Name", 200, 200, 100, 25);
            button.Behavior = Behavior.Push;
            button.Label = "Submit";
            button.Action = action;

            page.Elements.Add(button);
            document.Draw(Util.GetPath("Output/javascript-action-four-output.pdf"));
        }

        public static void ExampleFive()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            document.JavaScripts.Add(new DocumentJavaScript("Say Hi", "app.alert(\"Hello!!\")"));
            document.Draw(Util.GetPath("Output/javascript-action-five-output.pdf"));
        }

        public static void ExampleSix()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            document.JavaScripts.Add(new DocumentJavaScript("Say Bye", "function bye(){app.alert(\"Good Bye!!\")}"));
            JavaScriptAction action = new JavaScriptAction("bye()");
            Button button = new Button("Button", 200, 300, 100, 25);
            button.Behavior = Behavior.Push;
            button.Label = "Say Bye";
            button.Action = action;
            page.Elements.Add(button);

            document.Draw(Util.GetPath("Output/javascript-action-six-output.pdf"));
        }

    }
}
