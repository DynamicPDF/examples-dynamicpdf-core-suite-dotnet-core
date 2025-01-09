Imports ceTe.DynamicPDF.Forms
Imports ceTe.DynamicPDF.Merger
Imports System

Namespace DynamicPDFCoreSuite.Examples
    Class ReadFormFieldsExample

        Public Shared Sub Run()
            Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/AllFormFields.pdf"))

            Dim list As FormFieldList = document.Form.Fields

            For i As Integer = 0 To list.Count - 1
                Console.WriteLine("name: " & list(i).FullName & " value: " & list(i).Value)
            Next
        End Sub

    End Class
End Namespace

