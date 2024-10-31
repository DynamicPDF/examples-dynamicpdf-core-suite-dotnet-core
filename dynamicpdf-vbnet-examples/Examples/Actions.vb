Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.Forms

Namespace DynamicPDFCoreSuite.Examples
    Class Actions
        Public Shared Sub Run()
            GoToAction()
            ResetAction()
            SubmitAction()
            UrlAction()
            FileOpenAction()
            AnnotationShowHideAction()
            XyDestinationZoomDestination()
            ChainAction()
        End Sub

        Public Shared Sub ChainAction()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim label As New Label("Text Field:", 0, 50, 100, 0)
            Dim textField As New TextField("text1", 100, 50, 150, 100)
            Dim label2 As New Label("Hide All Fields:", 0, 10, 100, 0)
            Dim checkBox As New CheckBox("check_box_nm", 110, 7, 50, 50)

            Dim button As New Button("btn", 50, 150, 100, 30)
            button.Label = "Hide"

            Dim action As New AnnotationShowHideAction("check_box_nm")
            action.NextAction = New AnnotationShowHideAction("text1")
            action.NextAction.NextAction = New JavaScriptAction("app.alert(""Fields Hidden."")")
            action.NextAction.NextAction.NextAction = New FileOpenAction(Util.GetPath("Resources/PDFs/DocumentA.pdf"), FileLaunchMode.NewWindow)

            button.ReaderEvents.MouseDown = action

            document.Pages(0).Elements.Add(label)
            document.Pages(0).Elements.Add(checkBox)
            document.Pages(0).Elements.Add(label2)
            document.Pages(0).Elements.Add(textField)
            document.Pages(0).Elements.Add(button)

            document.Draw(Util.GetPath("Output/ChainingAction.pdf"))
        End Sub


        Public Shared Sub XyDestinationZoomDestination()
            Dim document As New Document()

            ' Add three blank pages
            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New Page(PageSize.Letter))

            ' Add a top-level outline and set properties
            Dim outline1 As Outline = document.Outlines.Add("Outline1")
            outline1.Style = TextStyle.Bold
            outline1.Color = New RgbColor(1.0F, 0.0F, 0.0F)

            ' Add child outlines
            Dim outline1A As Outline = outline1.ChildOutlines.Add("Outline1A", New UrlAction("http://www.mydomain.com"))
            outline1A.Expanded = False
            Dim outline1A1 As Outline = outline1A.ChildOutlines.Add("Outline1A1", New XYDestination(2, 0, 0))
            Dim outline1A2 As Outline = outline1A.ChildOutlines.Add("Outline1A2", New ZoomDestination(2, PageZoom.FitHeight))
            Dim outline1B As Outline = outline1.ChildOutlines.Add("Outline1B", New ZoomDestination(2, PageZoom.FitWidth))

            ' Add a second top-level outline
            Dim outline2 As Outline = document.Outlines.Add("Outline2", New XYDestination(3, 0, 300))

            ' Add a child outline
            Dim outline2A As Outline = outline2.ChildOutlines.Add("Outline2A")

            ' Save the PDF document
            document.Draw(Util.GetPath("Output/XyDestinationZoomDestinationAction.pdf"))
        End Sub


        Public Shared Sub AnnotationShowHideAction()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)
            Dim button As New Button("btn", 50, 150, 100, 30)
            button.Label = "Hide"
            Dim field As New TextField("Text1", 330, 100, 100, 30)
            field.DefaultValue = "Text Field Value"
            Dim action As New AnnotationShowHideAction("Text1")
            button.ReaderEvents.MouseDown = action

            Dim button2 As New Button("btn", 175, 150, 100, 30)
            button2.Label = "Show"
            Dim action2 As New AnnotationShowHideAction("Text1")
            action2.ShowField = True
            button2.ReaderEvents.MouseDown = action2

            page.Elements.Add(button)
            page.Elements.Add(button2)
            page.Elements.Add(field)
            document.Draw(Util.GetPath("Output/AnnotationShowHideAction.pdf"))
        End Sub

        Public Shared Sub GoToAction()
            Dim document As New Document()
            Dim page1 As New Page()
            document.Pages.Add(page1)
            Dim page2 As New Page()
            page2.Elements.Add(New Label("Page 2", 0, 0, 100, 15))
            document.Pages.Add(page2)

            Dim button As New Button("btn", 50, 150, 100, 30)
            button.Label = "Click Here"
            Dim action As New GoToAction(2, PageZoom.FitWidth)
            button.ReaderEvents.MouseUp = action

            page1.Elements.Add(button)
            document.Draw(Util.GetPath("Output/GoToAction.pdf"))
        End Sub

        Public Shared Sub ResetAction()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim action As New ResetAction()
            Dim button As New Button("btn", 50, 300, 100, 50)
            button.Label = "Reset"
            button.ReaderEvents.MouseEnter = action

            page.Elements.Add(button)
            document.Draw(Util.GetPath("Output/ResetAction.pdf"))
        End Sub

        Public Shared Sub SubmitAction()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)
            Dim label As New Label("Checked?", 0, 0, 100, 0)
            Dim checkBox As New CheckBox("checked", label.Width + 5, 0, 20, 20)
            checkBox.DefaultChecked = False
            page.Elements.Add(label)
            page.Elements.Add(checkBox)

            Dim submitAction As New SubmitAction("http://www.mydomain.com", FormExportFormat.HtmlPost)
            Dim button As New Button("btn", 50, 300, 100, 50)
            button.Label = "Submit"
            button.Action = submitAction

            page.Elements.Add(button)
            document.Draw(Util.GetPath("Output/SubmitAction.pdf"))
        End Sub

        Public Shared Sub UrlAction()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim font As Font = Font.TimesRoman
            Dim text As String = "This is a link to DynamicPDF.com."

            Dim label As New Label(text, 50, 20, 215, 80, font, 12, RgbColor.Blue)
            label.Underline = True
            Dim link As New Link(50, 20, font.GetTextWidth(text, 12), 12 - font.GetDescender(12), New UrlAction("http://www.dynamicpdf.com"))

            Dim action As New UrlAction("http://www.dynamicpdf.com")
            Dim button As New Button("btn", 50, 100, 100, 50)
            button.Label = "Click"
            button.Action = action

            page.Elements.Add(label)
            page.Elements.Add(link)
            page.Elements.Add(button)
            document.Draw(Util.GetPath("Output/UrlAction.pdf"))
        End Sub

        Public Shared Sub FileOpenAction()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim button As New Button("btn", 50, 150, 100, 30)
            button.Label = "Click Here"
            Dim action As New FileOpenAction(Util.GetPath("Output/UrlAction.pdf"), FileLaunchMode.NewWindow)
            button.ReaderEvents.MouseUp = action

            page.Elements.Add(button)
            document.Draw(Util.GetPath("Output/FileOpenAction.pdf"))
        End Sub
    End Class
End Namespace

