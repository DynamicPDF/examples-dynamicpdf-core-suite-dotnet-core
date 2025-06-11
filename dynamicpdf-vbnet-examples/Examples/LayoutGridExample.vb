Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Class LayoutGridExample

        Public Shared Sub Run()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim grid As New LayoutGrid(LayoutGrid.GridType.Decimal)
            page.Elements.Add(New Rectangle(50, 50, 50, 50, 2))
            page.Elements.Add(grid)

            document.Draw(Util.GetPath("Output/layout-grid-output.pdf"))
        End Sub

    End Class
End Namespace
