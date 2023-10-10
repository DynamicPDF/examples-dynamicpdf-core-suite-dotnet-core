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
    }
}
