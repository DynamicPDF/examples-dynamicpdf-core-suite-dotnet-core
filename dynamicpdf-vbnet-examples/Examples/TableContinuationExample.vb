Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Class TableContinuationExample
        Public Shared Sub Run()
            OverflowRows()
            OverflowColumns()
        End Sub

        Public Shared Sub OverflowRows()
            ' Create a PDF Document 
            Dim document As New Document()

            Dim table As New Table2(0, 0, 200, 700)

            ' Add columns to the table
            table.Columns.Add(100)
            table.Columns.Add(100)

            ' Create a header row for overflow
            Dim rowH As Row2 = table.Rows.Add(20)
            rowH.Cells.Add("Row Header")
            rowH.Cells.Add("Item Header")
            table.RepeatColumnHeaderCount = 1

            ' This loop populates the table 
            For i As Integer = 1 To 400
                Dim row As Row2 = table.Rows.Add(20)
                row.Cells.Add("Row #" & i.ToString())
                row.Cells.Add("Item")
            Next

            ' This loop outputs the table to as many pages as is required
            Do
                Dim page As New Page()
                document.Pages.Add(page)
                page.Elements.Add(table)
                table = table.GetOverflowRows()
            Loop While table IsNot Nothing

            ' Save the PDF 
            document.Draw(Util.GetPath("Output/table-continuation-output.pdf"))
        End Sub

        Public Shared Sub OverflowColumns()
            ' Create a PDF Document 
            Dim document As New Document()

            Dim table As New Table2(0, 0, 500, 50)

            ' Create the headers for the two rows
            table.Columns.Add(150)
            table.Columns.Add(150)
            Dim row1 As Row2 = table.Rows.Add(20)
            Dim row2 As Row2 = table.Rows.Add(20)
            row1.Cells.Add("Column Header")
            row2.Cells.Add("Row Header")
            table.RepeatRowHeaderCount = 2

            ' Create columns
            Dim cols As Integer = 50
            For i As Integer = 0 To cols
                table.Columns.Add(100)
                For j As Integer = 0 To cols
                    row1.Cells.Add("Column #" & j.ToString())
                    row2.Cells.Add("Item")
                Next
            Next

            ' This loop outputs the table to as many pages as is required
            Do
                Dim page As New Page()
                document.Pages.Add(page)
                page.Elements.Add(table)
                table = table.GetOverflowColumns()
            Loop While table IsNot Nothing

            ' Save the PDF 
            document.Draw(Util.GetPath("Output/table-column-continuation-output.pdf"))
        End Sub
    End Class
End Namespace
