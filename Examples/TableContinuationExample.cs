using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class TableContinuationExample
    {
        public static void Run()
        {
            // Create a PDF Document 
            Document document = new Document();

            Table2 table = new Table2(0, 0, 200, 700);

            // Add columns to the table
            table.Columns.Add(100);
            table.Columns.Add(100);

            // create a header row for overflow
            Row2 rowH = table.Rows.Add(20);
            rowH.Cells.Add("Row Header");
            rowH.Cells.Add("Item Header");
            table.RepeatColumnHeaderCount = 1;

            // This loop populates the table 
            for (int i = 1; i <= 400; i++)
            {
                Row2 row = table.Rows.Add(20);
                row.Cells.Add("Row #" + i);
                row.Cells.Add("Item");
            }

            // This loop outputs the table to as many pages as is required
            do
            {
                Page page = new Page();
                document.Pages.Add(page);
                page.Elements.Add(table);
                table = table.GetOverflowRows();
            } while (table != null);

            // Save the PDF 
            document.Draw(Util.GetPath("Output/table-continuation-output.pdf"));
        }
    }
}
