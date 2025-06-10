Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Forms

Namespace DynamicPDFCoreSuite.Examples
    Public Class ReaderEventExample

        Public Shared Sub Run()
            WillSaveExample()
            OpenExample()
            TextExample()
        End Sub

        Public Shared Sub WillSaveExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim action As New JavaScriptAction("app.alert(""Hello your text Saved!!"")")
            document.ReaderEvents.WillSave = action

            document.Draw(Util.GetPath("Output/willsave-event-output.pdf"))
        End Sub

        Public Shared Sub OpenExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim action As New JavaScriptAction("app.alert(""Welcome !!"")")
            page.ReaderEvents.Open = action

            document.Draw(Util.GetPath("Output/open-event-output.pdf"))
        End Sub

        Public Shared Sub TextExample()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim textField As New TextField("Text1", 0, 0, 100, 15)
            Dim action As New JavaScriptAction("app.alert(""Welcome !!"")")
            textField.ReaderEvents.OnFocus = action

            page.Elements.Add(textField)

            document.Draw(Util.GetPath("Output/text-event-output.pdf"))
        End Sub

    End Class
End Namespace
