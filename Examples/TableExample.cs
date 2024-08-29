using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPDFCoreSuite.Examples
{
    class TableExample
    {
        public static void Run()
        {
            TableExample.SimpleTable();
            TableExample.ColAndRowSpanExample();
            TableExample.TextFormattingExample();
            TableExample.BorderExample();
            TableExample.CompleteExample();
            TableExample.CompleteExampleTwo();
            TableExample.PageElementsExample();
        }

        private static void CompleteExample()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            Table2 table = new Table2(0, 0, 600, 600);

            Column2 column1 = table.Columns.Add(150);
            column1.CellDefault.Align = TextAlign.Center;
            table.Columns.Add(90);
            table.Columns.Add(90);
            table.Columns.Add(90);

            Row2 row1 = table.Rows.Add(40, Font.HelveticaBold, 16, Grayscale.Black, Grayscale.Gray);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;
            row1.Cells.Add("Header 1");
            row1.Cells.Add("Header 2");
            row1.Cells.Add("Header 3");
            row1.Cells.Add("Header 4");

            Row2 row2 = table.Rows.Add(30);
            Cell2 cell1 = row2.Cells.Add("Rowheader 1", Font.HelveticaBold, 16, Grayscale.Black, Grayscale.Gray, 1);
            cell1.Align = TextAlign.Center;
            cell1.VAlign = VAlign.Center;
            row2.Cells.Add("Item 1");
            row2.Cells.Add("Item 2");
            row2.Cells.Add("Item 3");

            Row2 row3 = table.Rows.Add(30);
            Cell2 cell2 = row3.Cells.Add("Rowheader 2", Font.HelveticaBold, 16, Grayscale.Black, Grayscale.Gray, 1);
            cell2.Align = TextAlign.Center;
            cell2.VAlign = VAlign.Center;
            row3.Cells.Add("Item 4");
            row3.Cells.Add("Item 5");
            row3.Cells.Add("Item 6");

            table.CellDefault.Padding.Value = 5.0f;
            table.CellSpacing = 5.0f;
            table.Border.Top.Color = RgbColor.Blue;
            table.Border.Bottom.Color = RgbColor.Blue;
            table.Border.Top.Width = 2;
            table.Border.Bottom.Width = 2;
            table.Border.Left.LineStyle = LineStyle.None;
            table.Border.Right.LineStyle = LineStyle.None;

            page.Elements.Add(table);

            document.Draw(Util.GetPath("Output/table-output.pdf"));
        }

        private static void CompleteExampleTwo()
        {
            // Create a PDF Document 
            Document document = new Document();

            // Create a Page and add it to the document 
            Page page = new Page();
            document.Pages.Add(page);

            Table2 table = new Table2(0, 0, 600, 600);
            table.CellDefault.Border.Color = RgbColor.Blue;
            table.CellSpacing = 5.0f;

            // Add columns to the table
            table.Columns.Add(150);
            table.Columns.Add(90);
            table.Columns.Add(90);

            // Add rows to the table and add cells to the rows
            Row2 row1 = table.Rows.Add(40, Font.HelveticaBold, 16, RgbColor.Black,
                RgbColor.Gray);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;
            row1.Cells.Add("Header 1");
            row1.Cells.Add("Header 2");
            row1.Cells.Add("Header 3");

            Row2 row2 = table.Rows.Add(30);
            Cell2 cell1 = row2.Cells.Add("Rowheader 1", Font.HelveticaBold, 16,
                RgbColor.Black, RgbColor.Gray, 1);
            cell1.Align = TextAlign.Center;
            cell1.VAlign = VAlign.Center;
            row2.Cells.Add("Item 1");
            row2.Cells.Add("Item 2, this item is much longer than the rest so that " +
                "you can see that each row will automatically expand to fit to the " +
                "height of the largest element in that row.");

            Row2 row3 = table.Rows.Add(30);
            Cell2 cell2 = row3.Cells.Add("Rowheader 2", Font.HelveticaBold, 16,
                RgbColor.Black, RgbColor.Gray, 1);
            cell2.Align = TextAlign.Center;
            cell2.VAlign = VAlign.Center;
            row3.Cells.Add("Item 3");
            row3.Cells.Add("Item 4");

            // Add the table to the page
            page.Elements.Add(table);
            // Save the PDF 
            document.Draw(Util.GetPath("Output/table-example2-output.pdf"));
        }

        private static void SimpleTable()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            // Create a table 
            Table2 table = new Table2(0, 0, 600, 600);

            //Add two columns to the table
            table.Columns.Add(150);
            table.Columns.Add(90);

            // Add two rows to the table
            Row2 row1 = table.Rows.Add(40);
            Row2 row2 = table.Rows.Add(30);

            row1.Cells.Add("A1");
            row1.Cells.Add("A2");

            row2.Cells.Add("B1");
            row2.Cells.Add("B2");

            page.Elements.Add(table);

            document.Draw(Util.GetPath("Output/simple-table-output.pdf"));
        }

        public static void ColAndRowSpanExample()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);


            // Create a table 
            Table2 table = new Table2(0, 0, 600, 600);

            //Add columns to the table
            table.Columns.Add(150);
            table.Columns.Add(90);
            table.Columns.Add(90);
            table.Columns.Add(90);

            // Add rows to the table and add cells to the rows
            Row2 row1 = table.Rows.Add(40);
            row1.Cells.Add("A1");
            row1.Cells[0].RowSpan = 2;
            row1.Cells.Add("A2");
            row1.Cells.Add("A3");
            row1.Cells[2].ColumnSpan = 2;

            Row2 row2 = table.Rows.Add(30);
            row2.Cells.Add("B2");
            row2.Cells.Add("B3");
            row2.Cells.Add("B4");

            page.Elements.Add(table);

            document.Draw(Util.GetPath("Output/col-row-span-table-output.pdf"));
        }

        public static void TextFormattingExample()
        {

            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            Table2 table = new Table2(0, 0, 600, 600);
            table.BackgroundColor = RgbColor.Red;

            table.Columns.Add(150);
            table.Columns.Add(90);

            Row2 row1 = table.Rows.Add(40, Font.HelveticaBold, 14, RgbColor.Navy, Grayscale.Gray);
            row1.Cells.Add("A1");
            row1.Cells.Add("A2");
            row1.Cells.Add("A1");
            row1.Cells.Add("A2");

            Row2 row2 = table.Rows.Add(30);
            row2.Cells.Add("B1");
            row2.Cells.Add("B2");
            row2.Cells[0].BackgroundColor = RgbColor.Blue;
            row2.Cells[0].FontSize = 18;
            row2.Cells[0].TextColor = RgbColor.Orange;

            page.Elements.Add(table);

            document.Draw(Util.GetPath("Output/text-formatting-table-output.pdf"));
        }

        public static void BorderExample()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);
            Table2 table = new Table2(0, 0, 600, 600);
            table.Columns.Add(150);
            table.Columns.Add(90);
            table.Border.LineStyle = LineStyle.None;

            Row2 row1 = table.Rows.Add(20);
            row1.Cells.Add("Header");
            row1.Cells[0].ColumnSpan = 2;
            row1.Cells.Add("Test");
            row1.Cells[0].Border.LineStyle = LineStyle.None;
            row1.Cells[0].Border.Bottom.LineStyle = LineStyle.Solid;
            row1.Cells[0].Border.Bottom.LineStyle = LineStyle.Dash;
            row1.Cells[0].Border.Bottom.Color = RgbColor.Navy;

            Row2 row2 = table.Rows.Add(10);
            Row2 row3 = table.Rows.Add(10);

            row2.Cells.Add("A1");
            row2.Cells.Add("A2");
            row3.Cells.Add("B1");
            row3.Cells.Add("B2");

            row2.Cells[0].Border.LineStyle = LineStyle.None;
            row2.Cells[1].Border.LineStyle = LineStyle.None;
            row3.Cells[0].Border.LineStyle = LineStyle.None;
            row3.Cells[1].Border.LineStyle = LineStyle.None;

            table.Border.Top.LineStyle = LineStyle.Solid;
            table.Border.Top.Color = RgbColor.Red;
            table.Border.Bottom.LineStyle = LineStyle.Solid;
            table.Border.Bottom.Color = RgbColor.Red;

            page.Elements.Add(table);

            document.Draw(Util.GetPath("Output/border-table-output.pdf"));
        }

        public static void PageElementsExample()
        {
            // Create a PDF Document 
            Document document = new Document();

            // Create a Page and add it to the document 
            Page page = new Page();
            document.Pages.Add(page);

            // create a table
            Table2 table = new Table2(0, 0, 400, 400);
            table.CellDefault.Border.Color = RgbColor.Blue;
            table.CellDefault.Border.LineStyle = LineStyle.Solid;
            table.CellDefault.Padding.Value = 3.0f;

            // Add columns to the table
            table.Columns.Add(90);
            table.Columns.Add(150);
            table.Columns.Add(110);

            // The first row is used as the table heading
            Row2 row1 = table.Rows.Add(20, Font.HelveticaBold, 14, RgbColor.Black,
            RgbColor.Gray);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;
            row1.Cells.Add("Page Element", 3);

            // The second row is the column headings
            Row2 row2 = table.Rows.Add(Font.HelveticaBoldOblique, 12);
            row2.CellDefault.Align = TextAlign.Center;
            row2.Cells.Add("Name");
            row2.Cells.Add("Element");
            row2.Cells.Add("Implements IArea");

            // Add IArea page elements directly to the cell
            Row2 row3 = table.Rows.Add(30);
            row3.Cells.Add("FormattedTextArea");
            row3.CellDefault.Border.Color = RgbColor.Green;

            string formattedText = "<font face=" + "Times" + ">This is a formatted text area. font face,</font> <font size=" + "0/>color,</font> <b>bold.</b>";
            row3.Cells.Add(new FormattedTextArea(formattedText, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
            
            Cell2 cell1 = row3.Cells.Add("YES");
            cell1.Align = TextAlign.Center;
            cell1.VAlign = VAlign.Center;

            // Add page elemnts (Lines) to a cell using the AreaGroup
            Row2 row4 = table.Rows.Add(30);
            row4.Cells.Add("Line");
            AreaGroup lineGroup = new AreaGroup(150, 150);
            lineGroup.Add(new Line(25, 25, 125, 125, 5));
            lineGroup.Add(new Line(25, 125, 125, 25, 5));
            row4.Cells.Add(lineGroup);
            Cell2 cell2 = row4.Cells.Add("NO");
            cell2.Align = TextAlign.Center;
            cell2.VAlign = VAlign.Center;

            //add image to table

            Row2 row5 = table.Rows.Add(30);
            row5.Cells.Add("Image");
            Image img = new(Util.GetPath("Resources/Images/") + "DPDFLogo.png", 0,0);
            row5.Cells.Add(img);
            Cell2 cell3 = row5.Cells.Add("YES");
            cell3.Align = TextAlign.Center;
            cell3.VAlign = VAlign.Center;

            // Add the table to the page
            page.Elements.Add(table);
            // Save the PDF 

            document.Draw(Util.GetPath("Output/table-page-elements-output.pdf"));
        }

    }
}
