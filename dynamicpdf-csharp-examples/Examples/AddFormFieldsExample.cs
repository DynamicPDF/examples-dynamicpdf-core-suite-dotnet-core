using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPDFCoreSuite.Examples
{
    class AddFormFieldsExample
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
            Page page = new Page(PageSize.Letter);

            Button button = new Button("btn", 50, 50, 100, 50);
            button.Action = new JavaScriptAction("app.alert('Hello');");
            button.Label = "Click";

            page.Elements.Add(button);
            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/button-output.pdf"));
        }

        public static void ExampleTwo()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter);

            CheckBox checkBox = new CheckBox("Check Box Name", 5, 7, 50, 50);
            checkBox.DefaultChecked = true;
            checkBox.ToolTip = "Check it";

            page.Elements.Add(checkBox);
            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/checkbox-output.pdf"));
        }

        public static void ExampleThree()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter);

            ComboBox comboBox = new ComboBox("Combo Box Name", 50, 75, 150, 25);
            comboBox.Items.Add("One", true);
            comboBox.Items.Add("Two");
            comboBox.Items.Add("Three");
            comboBox.BackgroundColor = RgbColor.AliceBlue;
            comboBox.BorderColor = RgbColor.DarkMagenta;
            comboBox.Editable = true;
            comboBox.ToolTip = "Select";

            page.Elements.Add(comboBox);
            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/combobox-output.pdf"));
        }

        public static void ExampleFour()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter);

            ListBox listBox = new ListBox("List Box Name", 5, 2, 100, 150);
            listBox.Items.Add("One", true);
            listBox.Items.Add("Two", true);
            listBox.Items.Add("Three");
            listBox.BackgroundColor = RgbColor.AliceBlue;
            listBox.BorderColor = RgbColor.DarkMagenta;
            listBox.BorderStyle = BorderStyle.Dashed;
            listBox.Multiselect = true;
            listBox.ToolTip = "Select";

            page.Elements.Add(listBox);
            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/listbox-output.pdf"));
        }

        public static void ExampleFive()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter);

            RadioButton radio1 = new RadioButton("Radio Button Name", 50, 25, 100, 75);
            radio1.DefaultChecked = true;
            radio1.ExportValue = "abc";
            radio1.ToolTip = "first";
            RadioButton radio2 = new RadioButton("Radio Button Name", 50, 140, 100, 75);
            radio2.ExportValue = "def";
            radio2.ToolTip = "second";
            RadioButton radio3 = new RadioButton("Radio Button Name", 50, 250, 100, 75);
            radio3.ExportValue = "ghi";
            radio3.ToolTip = "third";

            page.Elements.Add(radio1);
            page.Elements.Add(radio2);
            page.Elements.Add(radio3);
            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/radiobutton-output.pdf"));
        }

        public static void ExampleSix()
        {
            Document document = new Document();
            Page page = new Page(PageSize.Letter);

            TextField textField = new TextField("Text Field Name", 50, 75, 150, 100);
            textField.TextAlign = Align.Center;
            textField.BackgroundColor = RgbColor.AliceBlue;
            textField.BorderColor = RgbColor.DeepPink;
            textField.Font = Font.TimesItalic;
            textField.FontSize = 16.0f;
            textField.TextColor = RgbColor.Brown;
            textField.DefaultValue = "ceTe Software";
            textField.MultiLine = true;
            textField.ToolTip = "Text";

            page.Elements.Add(textField);
            document.Pages.Add(page);

            document.Draw(Util.GetPath("Output/textfield-output.pdf"));
        }
    }
}
