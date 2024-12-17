Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.Forms

Namespace DynamicPDFCoreSuite.Examples
    Class EventsExample
        Public Shared Sub Run()
            PageReaderEvents()
            DocumentReaderEvents()
            FormFieldEvents()
        End Sub

        Public Shared Sub PageReaderEvents()
            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New Page(PageSize.Letter))
            Dim page As Page = document.Pages(1)
            Dim action As New JavaScriptAction("app.alert(""Welcome !!"")")
            page.ReaderEvents.Open = action

            Dim action2 As New JavaScriptAction("app.alert(""Goodbye !!"")")
            page.ReaderEvents.Close = action2
            document.Pages.Add(New Page(PageSize.Letter))
            document.Draw(Util.GetPath("Output/page-reader-events-output.pdf"))
        End Sub

        Public Shared Sub DocumentReaderEvents()
            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter))
            Dim lbl As New Label("Page One", 10, 200, 200, 100)
            document.Pages(0).Elements.Add(lbl)

            Dim action As New JavaScriptAction("app.alert(""Will Save."")")
            document.ReaderEvents.WillSave = action

            Dim action2 As New JavaScriptAction("app.alert(""Goodbye !!"")")
            document.ReaderEvents.WillClose = action2

            document.Draw(Util.GetPath("Output/document-reader-events-output.pdf"))
        End Sub

        Public Shared Sub FormFieldEvents()
            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter))

            Dim label As New Label("Check Box:", 0, 10, 100, 0)
            Dim checkBox As New CheckBox("check_box_nm", 110, 7, 50, 50)
            checkBox.DefaultChecked = True
            checkBox.ToolTip = "Check it"

            Dim action As New JavaScriptAction("app.alert(""focus !!"")")
            checkBox.ReaderEvents.OnFocus = action

            Dim action2 As New JavaScriptAction("app.alert(""mouse-down !!"")")
            checkBox.ReaderEvents.MouseDown = action2

            document.Pages(0).Elements.Add(label)
            document.Pages(0).Elements.Add(checkBox)

            document.Draw(Util.GetPath("Output/form-reader-events-output.pdf"))
        End Sub
    End Class
End Namespace

