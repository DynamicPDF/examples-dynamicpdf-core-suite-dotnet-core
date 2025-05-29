Imports ceTe.DynamicPDF.Forms
Imports ceTe.DynamicPDF.Merger

Class FormFieldNamesExample

    Public Shared Sub Run()

        Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"))
        Dim list As FormFieldList = document.Form.Fields
        For i As Integer = 0 To list.Count - 1
            Console.WriteLine(list(i).FullName)
        Next
    End Sub
End Class
