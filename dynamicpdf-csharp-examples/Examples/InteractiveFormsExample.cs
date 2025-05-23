﻿using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    public class InteractiveFormsExample
    {

        public static void Run()
        {
            Document document = new();
            document.Pages.Add(new Page(PageSize.Letter));
            AddCheckbox(document);
            AddComboBox(document);
            AddListBoxField(document);
            AddRadioButton(document);
            AddTextField(document);
            //AddSignatureField(document);
            //AddButton(document);
            //AddSubmitButton(document);
            MailForm(document);
            document.Draw(Util.GetPath("Output/interactive-forms-output.pdf"));

        }


        public static void AddCheckbox(Document document)
        {
            Label label = new Label("Check Box:",0,10,100,0);
            CheckBox checkBox = new CheckBox("check_box_nm", 110, 7, 50, 50);
            checkBox.DefaultChecked = true;
            checkBox.ToolTip = "Check it";
            document.Pages[0].Elements.Add(label);
            document.Pages[0].Elements.Add(checkBox);
        }

        public static void AddComboBox(Document document)
        {
            Label label = new Label("Combo Box:", 0, 75, 100, 0);
            ComboBox comboBox = new ComboBox("combo_box_nm", 110, 75, 150, 25);
            comboBox.Items.Add("One", true);
            comboBox.Items.Add("Two");
            comboBox.Items.Add("Three");
            comboBox.BackgroundColor = RgbColor.AliceBlue;
            comboBox.BorderColor = RgbColor.DarkMagenta;
            comboBox.Editable = true;
            comboBox.ToolTip = "Select";
            document.Pages[0].Elements.Add(label);
            document.Pages[0].Elements.Add(comboBox);
        }

        public static void AddListBoxField(Document document)
        {
            Label label = new Label("List Box:", 0, 175, 100, 0);
            ListBox listBox = new ListBox("list_box_nm", 110, 175, 100, 150);
            listBox.Items.Add("One", true);
            listBox.Items.Add("Two", true);
            listBox.Items.Add("Three");
            listBox.BackgroundColor = RgbColor.AliceBlue;
            listBox.BorderColor = RgbColor.DarkMagenta;
            listBox.BorderStyle = BorderStyle.Dashed;
            listBox.Multiselect = true;
            listBox.ToolTip = "Select";
            document.Pages[0].Elements.Add(label);
            document.Pages[0].Elements.Add(listBox);
        }

        public static void AddRadioButton(Document document)
        {
            Label label = new Label("Radio Button:", 0, 375, 100, 0);
            RadioButton radio1 = new RadioButton("Radio Button Name", 100, 375, 25, 25);
            radio1.DefaultChecked = true;
            radio1.ExportValue = "abc";
            radio1.ToolTip = "first";
            RadioButton radio2 = new RadioButton("Radio Button Name", 150, 375, 25, 25);
            radio2.ExportValue = "def";
            radio2.ToolTip = "second";
            RadioButton radio3 = new RadioButton("Radio Button Name", 200, 375, 25, 25);
            radio3.ExportValue = "ghi";
            radio3.ToolTip = "third";
            document.Pages[0].Elements.Add(label);
            document.Pages[0].Elements.Add(radio1);
            document.Pages[0].Elements.Add(radio2);
            document.Pages[0].Elements.Add(radio3);
        }

        public static void AddTextField(Document document)
        {
            Label label = new Label("Text Field:", 0, 450, 100, 0);
            TextField textField = new TextField("Text Field Name", 100, 450, 150, 100);
            textField.TextAlign = Align.Center;
            textField.Font = Font.TimesItalic;
            textField.FontSize = 16.0f;
            textField.TextColor = RgbColor.Brown;
            textField.DefaultValue = "ceTe Software";
            textField.MultiLine = true;
            textField.ToolTip = "Text";
            document.Pages[0].Elements.Add(label);
            document.Pages[0].Elements.Add(textField);
        }

        public static void AddSignatureField(Document document)
        {
            Label label = new Label("Signature:", 0, 575, 100, 0);
            Signature signature = new Signature("MySigField", 100, 575, 300, 100);
            signature.LeftPanel.SetImage(Util.GetPath("Resources/Images/signature.png"));
            signature.FullPanel.FitImage = true;
            document.Pages[0].Elements.Add(label);
            document.Pages[0].Elements.Add(signature);

        }

        public static void AddButton(Document document)
        {
            Button button = new Button("Button Name", 0, 700, 100, 30);
            button.Action = new JavaScriptAction("app.alert('Hello');");
            button.BackgroundColor = RgbColor.AliceBlue;
            button.BorderStyle = BorderStyle.Beveled;
            button.Label = "Push";
            button.TextColor = RgbColor.DarkGreen;
            button.ToolTip = "Push the button";

            button.Image = ImageData.GetImage(Util.GetPath("Resources/Images/button-a.png"));
            button.LabelImageLayout = LabelImageLayoutOptions.LabelLeftImageRight;
            button.Behavior = Behavior.CreatePush("Down", "Over", ImageData.GetImage(Util.GetPath("Resources/Images/button-c.png")), ImageData.GetImage(Util.GetPath("Resources/Images/button-b.png")));

            document.Pages[0].Elements.Add(button);
        }

        public static void AddSubmitButton(Document document)
        {
            Button button = new Button("Submit", 125, 700, 150, 30);
            button.Action = new SubmitAction("http://localhost:8000/handle.php", FormExportFormat.FDF);
            button.BackgroundColor = RgbColor.AliceBlue;
            button.BorderStyle = BorderStyle.Beveled;
            button.Label = "Submit";
            button.TextColor = RgbColor.DarkGreen;
            document.Pages[0].Elements.Add(button);
        }

        public static void MailForm(Document document)
        {

            string bodyMsg = "Thank you for submitting this form.";
            string javascriptString = "var cEmailURL = \"mailto:myname@mydomain.com?subject='Form Submission'&body='" + bodyMsg + "'\";";
            javascriptString += " this.submitForm({ cURL: encodeURI(cEmailURL), cSubmitAs: 'PDF', cCharSet: 'utf-8'});";

            Button button = new Button("email", 125,700, 100, 20);

            button.BackgroundColor = RgbColor.Yellow;
            button.BorderStyle = BorderStyle.Beveled;
            button.Action = new JavaScriptAction(javascriptString);
            button.Label = "Email";
            document.Pages[0].Elements.Add(button);

        }



    }
}
