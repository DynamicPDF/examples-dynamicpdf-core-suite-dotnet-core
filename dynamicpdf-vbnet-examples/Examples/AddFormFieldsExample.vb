Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Forms

Public Class AddFormFieldsExample

        Public Shared Sub Run()
            ExampleOne()
            ExampleTwo()
            ExampleThree()
            ExampleFour()
            ExampleFive()
            ExampleSix()
        End Sub

        Public Shared Sub ExampleOne()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)

            Dim button As New Button("btn", 50, 50, 100, 50)
            button.Action = New JavaScriptAction("app.alert('Hello');")
            button.Label = "Click"

            page.Elements.Add(button)
            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/button-output.pdf"))
        End Sub

        Public Shared Sub ExampleTwo()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)

            Dim checkBox As New CheckBox("Check Box Name", 5, 7, 50, 50)
            checkBox.DefaultChecked = True
            checkBox.ToolTip = "Check it"

            page.Elements.Add(checkBox)
            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/checkbox-output.pdf"))
        End Sub

        Public Shared Sub ExampleThree()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)

            Dim comboBox As New ComboBox("Combo Box Name", 50, 75, 150, 25)
            comboBox.Items.Add("One", True)
            comboBox.Items.Add("Two")
            comboBox.Items.Add("Three")
            comboBox.BackgroundColor = RgbColor.AliceBlue
            comboBox.BorderColor = RgbColor.DarkMagenta
            comboBox.Editable = True
            comboBox.ToolTip = "Select"

            page.Elements.Add(comboBox)
            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/combobox-output.pdf"))
        End Sub

        Public Shared Sub ExampleFour()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)

            Dim listBox As New ListBox("List Box Name", 5, 2, 100, 150)
            listBox.Items.Add("One", True)
            listBox.Items.Add("Two", True)
            listBox.Items.Add("Three")
            listBox.BackgroundColor = RgbColor.AliceBlue
            listBox.BorderColor = RgbColor.DarkMagenta
            listBox.BorderStyle = BorderStyle.Dashed
            listBox.Multiselect = True
            listBox.ToolTip = "Select"

            page.Elements.Add(listBox)
            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/listbox-output.pdf"))
        End Sub

        Public Shared Sub ExampleFive()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)

            Dim radio1 As New RadioButton("Radio Button Name", 50, 25, 100, 75)
            radio1.DefaultChecked = True
            radio1.ExportValue = "abc"
            radio1.ToolTip = "first"

            Dim radio2 As New RadioButton("Radio Button Name", 50, 140, 100, 75)
            radio2.ExportValue = "def"
            radio2.ToolTip = "second"

            Dim radio3 As New RadioButton("Radio Button Name", 50, 250, 100, 75)
            radio3.ExportValue = "ghi"
            radio3.ToolTip = "third"

            page.Elements.Add(radio1)
            page.Elements.Add(radio2)
            page.Elements.Add(radio3)
            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/radiobutton-output.pdf"))
        End Sub

        Public Shared Sub ExampleSix()
            Dim document As New Document()
            Dim page As New Page(PageSize.Letter)

            Dim textField As New TextField("Text Field Name", 50, 75, 150, 100)
            textField.TextAlign = Align.Center
            textField.BackgroundColor = RgbColor.AliceBlue
            textField.BorderColor = RgbColor.DeepPink
            textField.Font = Font.TimesItalic
            textField.FontSize = 16.0F
            textField.TextColor = RgbColor.Brown
            textField.DefaultValue = "ceTe Software"
            textField.MultiLine = True
            textField.ToolTip = "Text"

            page.Elements.Add(textField)
            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/textfield-output.pdf"))
        End Sub

    End Class

