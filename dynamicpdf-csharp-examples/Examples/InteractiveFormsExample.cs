using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;

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
            AddSignatureField(document);
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
            signature.FullPanel.SetImage(Util.GetPath("Resources/Images/signature.png"));
            document.Pages[0].Elements.Add(label);
            document.Pages[0].Elements.Add(signature);

        }



    }
}
