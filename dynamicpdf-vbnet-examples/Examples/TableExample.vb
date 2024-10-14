Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Class TableExample
        Public Shared Sub Run()
            SimpleTable()
            ColAndRowSpanExample()
            TextFormattingExample()
            BorderExample()
            CompleteExample()
            CompleteExampleTwo()
            PageElementsExample()
        End Sub

        Private Shared Sub CompleteExample()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim table As New Table2(0, 0, 600, 600)

            Dim column1 As Column2 = table.Columns.Add(150)
            column1.CellDefault.Align = TextAlign.Center
            table.Columns.Add(90)
            table.Columns.Add(90)
            table.Columns.Add(90)

            Dim row1 As Row2 = table.Rows.Add(40, Font.HelveticaBold, 16, Grayscale.Black, Grayscale.Gray)
            row1.CellDefault.Align = TextAlign.Center
            row1.CellDefault.VAlign = VAlign.Center
            row1.Cells.Add("Header 1")
            row1.Cells.Add("Header 2")
            row1.Cells.Add("Header 3")
            row1.Cells.Add("Header 4")

            Dim row2 As Row2 = table.Rows.Add(30)
            Dim cell1 As Cell2 = row2.Cells.Add("Rowheader 1", Font.HelveticaBold, 16, Grayscale.Black, Grayscale.Gray, 1)
            cell1.Align = TextAlign.Center
            cell1.VAlign = VAlign.Center
            row2.Cells.Add("Item 1")
            row2.Cells.Add("Item 2")
            row2.Cells.Add("Item 3")

            Dim row3 As Row2 = table.Rows.Add(30)
            Dim cell2 As Cell2 = row3.Cells.Add("Rowheader 2", Font.HelveticaBold, 16, Grayscale.Black, Grayscale.Gray, 1)
            cell2.Align = TextAlign.Center
            cell2.VAlign = VAlign.Center
            row3.Cells.Add("Item 4")
            row3.Cells.Add("Item 5")
            row3.Cells.Add("Item 6")

            table.CellDefault.Padding.Value = 5.0F
            table.CellSpacing = 5.0F
            table.Border.Top.Color = RgbColor.Blue
            table.Border.Bottom.Color = RgbColor.Blue
            table.Border.Top.Width = 2
            table.Border.Bottom.Width = 2
            table.Border.Left.LineStyle = LineStyle.None
            table.Border.Right.LineStyle = LineStyle.None

            page.Elements.Add(table)

            document.Draw(Util.GetPath("Output/table-output.pdf"))
        End Sub

        Private Shared Sub CompleteExampleTwo()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim table As New Table2(0, 0, 600, 600)
            table.CellDefault.Border.Color = RgbColor.Blue
            table.CellSpacing = 5.0F

            table.Columns.Add(150)
            table.Columns.Add(90)
            table.Columns.Add(90)

            Dim row1 As Row2 = table.Rows.Add(40, Font.HelveticaBold, 16, RgbColor.Black, RgbColor.Gray)
            row1.CellDefault.Align = TextAlign.Center
            row1.CellDefault.VAlign = VAlign.Center
            row1.Cells.Add("Header 1")
            row1.Cells.Add("Header 2")
            row1.Cells.Add("Header 3")

            Dim row2 As Row2 = table.Rows.Add(30)
            Dim cell1 As Cell2 = row2.Cells.Add("Rowheader 1", Font.HelveticaBold, 16, RgbColor.Black, RgbColor.Gray, 1)
            cell1.Align = TextAlign.Center
            cell1.VAlign = VAlign.Center
            row2.Cells.Add("Item 1")
            row2.Cells.Add("Item 2, this item is much longer than the rest so that you can see that each row will automatically expand to fit to the height of the largest element in that row.")

            Dim row3 As Row2 = table.Rows.Add(30)
            Dim cell2 As Cell2 = row3.Cells.Add("Rowheader 2", Font.HelveticaBold, 16, RgbColor.Black, RgbColor.Gray, 1)
            cell2.Align = TextAlign.Center
            cell2.VAlign = VAlign.Center
            row3.Cells.Add("Item 3")
            row3.Cells.Add("Item 4")

            page.Elements.Add(table)

            document.Draw(Util.GetPath("Output/table-example2-output.pdf"))
        End Sub

        Private Shared Sub SimpleTable()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim table As New Table2(0, 0, 600, 600)

            table.Columns.Add(150)
            table.Columns.Add(90)

            Dim row1 As Row2 = table.Rows.Add(40)
            Dim row2 As Row2 = table.Rows.Add(30)

            row1.Cells.Add("A1")
            row1.Cells.Add("A2")

            row2.Cells.Add("B1")
            row2.Cells.Add("B2")

            page.Elements.Add(table)

            document.Draw(Util.GetPath("Output/simple-table-output.pdf"))
        End Sub

        Public Shared Sub ColAndRowSpanExample()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim table As New Table2(0, 0, 600, 600)

            table.Columns.Add(150)
            table.Columns.Add(90)
            table.Columns.Add(90)
            table.Columns.Add(90)

            Dim row1 As Row2 = table.Rows.Add(40)
            row1.Cells.Add("A1")
            row1.Cells(0).RowSpan = 2
            row1.Cells.Add("A2")
            row1.Cells.Add("A3")
            row1.Cells(2).ColumnSpan = 2

            Dim row2 As Row2 = table.Rows.Add(30)
            row2.Cells.Add("B2")
            row2.Cells.Add("B3")
            row2.Cells.Add("B4")

            page.Elements.Add(table)

            document.Draw(Util.GetPath("Output/col-row-span-table-output.pdf"))
        End Sub

        Public Shared Sub TextFormattingExample()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim table As New Table2(0, 0, 600, 600)
            table.BackgroundColor = RgbColor.Red

            table.Columns.Add(150)
            table.Columns.Add(90)

            Dim row1 As Row2 = table.Rows.Add(40, Font.HelveticaBold, 14, RgbColor.Navy, Grayscale.Gray)
            row1.Cells.Add("A1")
            row1.Cells.Add("A2")
            row1.Cells.Add("A1")
            row1.Cells.Add("A2")

            Dim row2 As Row2 = table.Rows.Add(30)
            row2.Cells.Add("B1")
            row2.Cells.Add("B2")
            row2.Cells(0).BackgroundColor = RgbColor.Blue
            row2.Cells(0).FontSize = 18
            row2.Cells(0).TextColor = RgbColor.Orange

            page.Elements.Add(table)

            document.Draw(Util.GetPath("Output/text-formatting-table-output.pdf"))
        End Sub

        Public Shared Sub BorderExample()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim table As New Table2(0, 0, 600, 600)
            table.Columns.Add(150)
            table.Columns.Add(90)
            table.Border.LineStyle = LineStyle.None

            Dim row1 As Row2 = table.Rows.Add(20)
            row1.Cells.Add("Header")
            row1.Cells(0).ColumnSpan = 2
            row1.Cells.Add("Test")
            row1.Cells(0).Border.LineStyle = LineStyle.None
            row1.Cells(0).Border.Bottom.LineStyle = LineStyle.Solid
            row1.Cells(0).Border.Bottom.LineStyle = LineStyle.Dash
            row1.Cells(0).Border.Bottom.Color = RgbColor.Navy

            Dim row2 As Row2 = table.Rows.Add(10)
            Dim row3 As Row2 = table.Rows.Add(10)

            row2.Cells.Add("A1")
            row2.Cells.Add("A2")
            row3.Cells.Add("B1")
            row3.Cells.Add("B2")

            row2.Cells(0).Border.LineStyle = LineStyle.None
            row2.Cells(1).Border.LineStyle = LineStyle.None
            row3.Cells(0).Border.LineStyle = LineStyle.None
            row3.Cells(1).Border.LineStyle = LineStyle.None

            table.Border.Top.LineStyle = LineStyle.Solid
            table.Border.Top.Color = RgbColor.Red
            table.Border.Bottom.LineStyle = LineStyle.Solid
            table.Border.Bottom.Color = RgbColor.Red

            page.Elements.Add(table)

            document.Draw(Util.GetPath("Output/border-table-output.pdf"))
        End Sub

        Public Shared Sub PageElementsExample()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim table As New Table2(0, 0, 400, 400)
            table.CellDefault.Border.Color = RgbColor.Blue
            table.CellDefault.Border.LineStyle = LineStyle.Solid
            table.CellDefault.Padding.Value = 3.0F

            table.Columns.Add(90)
            table.Columns.Add(150)
            table.Columns.Add(110)

            Dim row1 As Row2 = table.Rows.Add(20, Font.HelveticaBold, 14, RgbColor.Black, RgbColor.Gray)
            row1.CellDefault.Align = TextAlign.Center
            row1.CellDefault.VAlign = VAlign.Center
            row1.Cells.Add("Page Element", 3)

            Dim row2 As Row2 = table.Rows.Add(Font.HelveticaBoldOblique, 12)
            row2.CellDefault.Align = TextAlign.Center
            row2.Cells.Add("Name")
            row2.Cells.Add("Element")
            row2.Cells.Add("Implements IArea")

            Dim row3 As Row2 = table.Rows.Add(30)
            row3.Cells.Add("FormattedTextArea")
            row3.CellDefault.Border.Color = RgbColor.Green

            Dim formattedText As String = "<font face=" & "Times" & ">This is a formatted text area. font face,</font> <font size=" & "0/>color,</font> <b>bold.</b>"
            row3.Cells.Add(New FormattedTextArea(formattedText, 0, 0, 140, 50, FontFamily.Helvetica, 12, False))

            Dim cell1 As Cell2 = row3.Cells.Add("YES")
            cell1.Align = TextAlign.Center
            cell1.VAlign = VAlign.Center

            Dim row4 As Row2 = table.Rows.Add(30)
            row4.Cells.Add("Line")
            Dim lineGroup As New AreaGroup(150, 150)
            lineGroup.Add(New Line(25, 25, 125, 125, 5))
            lineGroup.Add(New Line(25, 125, 125, 25, 5))
            row4.Cells.Add(lineGroup)
            Dim cell2 As Cell2 = row4.Cells.Add("NO")
            cell2.Align = TextAlign.Center
            cell2.VAlign = VAlign.Center

            Dim row5 As Row2 = table.Rows.Add(30)
            row5.Cells.Add("Image")
            Dim img As New Image(Util.GetPath("Resources/Images/") & "DPDFLogo.png", 0, 0)
            row5.Cells.Add(img)
            Dim cell3 As Cell2 = row5.Cells.Add("YES")
            cell3.Align = TextAlign.Center
            cell3.VAlign = VAlign.Center

            page.Elements.Add(table)

            document.Draw(Util.GetPath("Output/table-page-elements-output.pdf"))
        End Sub
    End Class
End Namespace

