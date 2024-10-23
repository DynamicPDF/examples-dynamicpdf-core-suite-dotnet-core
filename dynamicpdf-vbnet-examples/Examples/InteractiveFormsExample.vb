Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.Forms

Namespace DynamicPDFCoreSuite.Examples
    Public Class InteractiveFormsExample

        Public Shared Sub Run()
            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter))
            AddButton(document)
            AddCheckbox(document)
            AddComboBox(document)
            AddListBoxField(document)
            AddRadioButton(document)
            AddTextField(document)
            AddSignatureField(document)
            document.Draw(Util.GetPath("Output/interactive-forms-output.pdf"))
        End Sub

        Public Shared Sub AddButton(document As Document)
            Dim MyButton As Button = New Button("Button Name", 50, 50, 100, 50)
            MyButton.Action = New JavaScriptAction("app.alert('Hello');")
            MyButton.BackgroundColor = RgbColor.AliceBlue
            MyButton.Behavior = Behavior.CreatePush("downLabel", "rolloverLabel")
            MyButton.BorderColor = RgbColor.BlueViolet
            MyButton.BorderStyle = BorderStyle.Beveled
            MyButton.Label = "Push"
            MyButton.TextColor = RgbColor.DarkGreen
            MyButton.ToolTip = "Click"
            document.Pages(0).Elements.Add(MyButton)
        End Sub

        Public Shared Sub AddCheckbox(document As Document)
            Dim label As New Label("Check Box:", 0, 10, 100, 0)
            Dim checkBox As New CheckBox("check_box_nm", 110, 7, 50, 50)
            checkBox.DefaultChecked = True
            checkBox.ToolTip = "Check it"
            document.Pages(0).Elements.Add(label)
            document.Pages(0).Elements.Add(checkBox)
        End Sub

        Public Shared Sub AddComboBox(document As Document)
            Dim label As New Label("Combo Box:", 0, 75, 100, 0)
            Dim comboBox As New ComboBox("combo_box_nm", 110, 75, 150, 25)
            comboBox.Items.Add("One", True)
            comboBox.Items.Add("Two")
            comboBox.Items.Add("Three")
            comboBox.BackgroundColor = RgbColor.AliceBlue
            comboBox.BorderColor = RgbColor.DarkMagenta
            comboBox.Editable = True
            comboBox.ToolTip = "Select"
            document.Pages(0).Elements.Add(label)
            document.Pages(0).Elements.Add(comboBox)
        End Sub

        Public Shared Sub AddListBoxField(document As Document)
            Dim label As New Label("List Box:", 0, 175, 100, 0)
            Dim listBox As New ListBox("list_box_nm", 110, 175, 100, 150)
            listBox.Items.Add("One", True)
            listBox.Items.Add("Two", True)
            listBox.Items.Add("Three")
            listBox.BackgroundColor = RgbColor.AliceBlue
            listBox.BorderColor = RgbColor.DarkMagenta
            listBox.BorderStyle = BorderStyle.Dashed
            listBox.Multiselect = True
            listBox.ToolTip = "Select"
            document.Pages(0).Elements.Add(label)
            document.Pages(0).Elements.Add(listBox)
        End Sub

        Public Shared Sub AddRadioButton(document As Document)
            Dim label As New Label("Radio Button:", 0, 375, 100, 0)
            Dim radio1 As New RadioButton("Radio Button Name", 100, 375, 25, 25)
            radio1.DefaultChecked = True
            radio1.ExportValue = "abc"
            radio1.ToolTip = "first"
            Dim radio2 As New RadioButton("Radio Button Name", 150, 375, 25, 25)
            radio2.ExportValue = "def"
            radio2.ToolTip = "second"
            Dim radio3 As New RadioButton("Radio Button Name", 200, 375, 25, 25)
            radio3.ExportValue = "ghi"
            radio3.ToolTip = "third"
            document.Pages(0).Elements.Add(label)
            document.Pages(0).Elements.Add(radio1)
            document.Pages(0).Elements.Add(radio2)
            document.Pages(0).Elements.Add(radio3)
        End Sub

        Public Shared Sub AddTextField(document As Document)
            Dim label As New Label("Text Field:", 0, 450, 100, 0)
            Dim textField As New TextField("Text Field Name", 100, 450, 150, 100)
            textField.TextAlign = Align.Center
            textField.Font = Font.TimesItalic
            textField.FontSize = 16.0F
            textField.TextColor = RgbColor.Brown
            textField.DefaultValue = "ceTe Software"
            textField.MultiLine = True
            textField.ToolTip = "Text"
            document.Pages(0).Elements.Add(label)
            document.Pages(0).Elements.Add(textField)
        End Sub

        Public Shared Sub AddSignatureField(document As Document)
            Dim label As New Label("Signature:", 0, 575, 100, 0)
            Dim signature As New Signature("MySigField", 100, 575, 300, 100)
            signature.FullPanel.SetImage(Util.GetPath("Resources/Images/signature.png"))
            document.Pages(0).Elements.Add(label)
            document.Pages(0).Elements.Add(signature)
        End Sub
    End Class
End Namespace

