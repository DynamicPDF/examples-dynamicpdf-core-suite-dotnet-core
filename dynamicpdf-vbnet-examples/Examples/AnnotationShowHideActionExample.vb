Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Forms

Public Class AnnotationShowHideActionExample
    Public Shared Sub Run()
        Dim document As New Document()
        Dim page As New Page()
        document.Pages.Add(page)

        Dim button As New Button("btn", 50, 150, 100, 30)
        button.Label = "Click Here"

        Dim field As New TextField("Text1", 330, 100, 100, 30)
        field.DefaultValue = "Text Field Value"

        Dim action As New AnnotationShowHideAction("Text1")
        button.ReaderEvents.MouseDown = action

        page.Elements.Add(button)
        page.Elements.Add(field)

        document.Draw(Util.GetPath("Output/annotations-example.pdf"))
    End Sub
End Class

