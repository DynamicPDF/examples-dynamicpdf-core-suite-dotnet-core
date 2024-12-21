Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.Forms

Namespace DynamicPDFCoreSuite.Examples
    Class JavaScriptExample
        Public Shared Sub Run()
            DocumentExample()
            FormLevelExample()
            AutoFillableExample()
            ValidationExample()
            FormattingExample()
            CallingDocumentExample()
        End Sub

        Public Shared Sub DocumentExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            document.JavaScripts.Add(New DocumentJavaScript("Say Hi", "app.alert(""Hello!!"")"))
            document.Draw(Util.GetPath("Output/javascript-document-output.pdf"))
        End Sub

        Public Shared Sub FormLevelExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim action As New JavaScriptAction("this.print({bUI: false, bSilent: true, bShrinkToFit: true});")

            Dim button As New Button("Button Name", 200, 200, 100, 25)
            button.Behavior = Behavior.Push
            button.Label = "Submit"
            button.Action = action

            page.Elements.Add(button)
            document.Draw(Util.GetPath("Output/javascript-form-level-output.pdf"))
        End Sub

        Public Shared Sub AutoFillableExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim label1 As New Label("Please Enter your Date of Birth :", 50, 50, 200, 50)
            Dim textField1 As New TextField("dob", 270, 50, 100, 50)
            textField1.ReaderEvents.OnBlur = New JavaScriptAction(" var no = this.getField(""dob"").value; var temp = Math.abs(new Date(Date.now()).getTime() - new Date(no).getTime()); var days = Math.ceil(temp / (1000 * 3600 * 24));this.getField(""age"").value = Math.floor(days/365); ")
            page.Elements.Add(label1)
            page.Elements.Add(textField1)

            Dim label2 As New Label("Your Age is :", 50, 120, 100, 50)
            Dim textField2 As New TextField("age", 270, 120, 100, 50)
            page.Elements.Add(label2)
            page.Elements.Add(textField2)

            document.Draw(Util.GetPath("Output/javascript-auto-fillable-output.pdf"))
        End Sub

        Public Shared Sub ValidationExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim label1 As New Label("Please Enter a Number :", 50, 50, 200, 50)
            Dim textField1 As New TextField("number", 270, 50, 100, 50)
            textField1.ReaderEvents.OnBlur = New JavaScriptAction("var no = this.getField(""number"").value; this.getField(""number"").value = no.toFixed(2); ")
            page.Elements.Add(label1)
            page.Elements.Add(textField1)

            document.Draw(Util.GetPath("Output/javascript-validation-output.pdf"))
        End Sub

        Public Shared Sub FormattingExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim label As New Label("Please Enter a Number :", 0, 50, 150, 30)
            Dim textField As New TextField("txt", 170, 30, 150, 30)
            textField.DefaultValue = "0"
            textField.ToolTip = "Enter only Numbers"
            textField.ReaderEvents.OnBlur = New JavaScriptAction(" var no = this.getField(""txt"").value; if( isNaN(no)) { app.alert(""Please Enter number in the text field""); } ")
            page.Elements.Add(textField)
            page.Elements.Add(label)

            document.Draw(Util.GetPath("Output/javascript-fomatting-output.pdf"))
        End Sub

        Public Shared Sub CallingDocumentExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            document.JavaScripts.Add(New DocumentJavaScript("Say Bye", "function bye(){app.alert(""Good Bye!!"")}"))
            Dim action As New JavaScriptAction("bye()")
            Dim button As New Button("Button", 200, 300, 100, 25)
            button.Behavior = Behavior.Push
            button.Label = "Say Bye"
            button.Action = action
            page.Elements.Add(button)

            document.Draw(Util.GetPath("Output/javascript-document-calling-output.pdf"))
        End Sub
    End Class
End Namespace

