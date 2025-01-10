Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Merger
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.Forms

Namespace dynamicpdf_vb_examples.Examples
    Public Class FormFdfExample
        Public Shared Sub Run()
            FormFillingFdfData()
            FormFillingFdfDataDocument()
        End Sub

        Public Shared Sub FormFillingFdfData()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/simple-form-fill.pdf"))
            document.Pages(0).ReaderEvents.Open = New ImportFormDataAction(Util.GetPath("Resources/Data/simple-form-fill_data.fdf"))
            document.Draw(Util.GetPath("Output/completed-fdf-form-filling-output.pdf"))
        End Sub

        Public Shared Sub FormFillingFdfDataDocument()
            Dim document As New Document()

            ' Create a page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create label and text field
            Dim label1 As New Label("Name:", 0, 0, 250, 30)
            Dim nameField As New TextField("nameField", 100, 0, 200, 25)
            Dim label2 As New Label("Description:", 0, 100, 100, 30)
            Dim descriptionField As New TextField("descriptionField", 150, 100, 200, 50)
            Dim button As New Button("btn", 50, 250, 100, 30)
            button.Label = "Fill Form"

            ' Add the label and form fields to the page
            page.Elements.Add(button)
            page.Elements.Add(nameField)
            page.Elements.Add(descriptionField)
            page.Elements.Add(label1)
            page.Elements.Add(label2)

            ' Create an import form data action and assign it to the button events.
            Dim action As New ImportFormDataAction(Util.GetPath("Resources/Data/simple-form-fill_data.fdf"))
            button.ReaderEvents.MouseUp = action

            ' Save the PDF
            document.Draw(Util.GetPath("Output/completed-fdf-form-filling-document-output.pdf"))
        End Sub

    End Class
End Namespace

