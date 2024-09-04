
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace DynamicPDFCoreSuite.Examples
{
    public class BarChartsExample
    {
        public static void Run()
        {
            SimpleBarChart();
        }

        public static void SimpleBarChart()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Chart chart = new Chart(0, 0, 400, 200);

            IndexedBarSeries barSeries1 = new IndexedBarSeries("Item A");
            chart.PrimaryPlotArea.Series.Add(barSeries1);
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Item B");
            chart.PrimaryPlotArea.Series.Add(barSeries2);
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Item C");
            chart.PrimaryPlotArea.Series.Add(barSeries3);
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/barchart-simple-output.pdf"));
        }

    }
}
