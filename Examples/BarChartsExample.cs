
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace DynamicPDFCoreSuite.Examples
{
    public class BarChartsExample
    {
        public static void Run()
        {
            SimpleBarChart();
            SimpleBarChartIndexedAxis();
            SimpleBarChartManualLayout();
        }

        public static void SimpleBarChart()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Chart chart = new Chart(0, 0, 400, 200);
            chart.BackgroundColor = RgbColor.AliceBlue;
            chart.PrimaryPlotArea.BackgroundColor = RgbColor.Gray;
            IndexedBarSeries barSeries1 = new IndexedBarSeries("Item A");
            chart.PrimaryPlotArea.Series.Add(barSeries1);
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Item B");
            chart.PrimaryPlotArea.Series.Add(barSeries2);
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Item C");
            chart.PrimaryPlotArea.Series.Add(barSeries3);
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            chart.Legends[0].BackgroundColor = RgbColor.Tan;

            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/barchart-simple-output.pdf"));
        }

        public static void SimpleBarChartIndexedAxis()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Chart chart = new Chart(0, 0, 400, 200);

            // Create a indexed yAxis
            IndexedYAxis yAxis = new IndexedYAxis();

            // Create indexed y axis labels and add those to indexed y Axis
            yAxis.Labels.Add(new IndexedYAxisLabel("Q1", 0));
            yAxis.Labels.Add(new IndexedYAxisLabel("Q2", 1));
            yAxis.Labels.Add(new IndexedYAxisLabel("Q3", 2));
            yAxis.Labels.Add(new IndexedYAxisLabel("Q4", 3));

            // Create a numeric xAxis
            NumericXAxis xAxis = new NumericXAxis();

            // Create a title and add it to the XAxis
        

            IndexedBarSeries barSeries1 = new IndexedBarSeries("Item A", xAxis, yAxis);
            chart.PrimaryPlotArea.Series.Add(barSeries1);
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Item B", xAxis, yAxis);
            chart.PrimaryPlotArea.Series.Add(barSeries2);
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Item C", xAxis, yAxis);
            chart.PrimaryPlotArea.Series.Add(barSeries3);
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/barchart-simple-axis-output.pdf"));
        }

        public static void SimpleBarChartManualLayout()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Chart chart = new Chart(0, 0, 400, 200);
            chart.BackgroundColor = RgbColor.AliceBlue;
            chart.PrimaryPlotArea.BackgroundColor = RgbColor.Gray;
            
            IndexedBarSeries barSeries1 = new IndexedBarSeries("Item A");
            chart.PrimaryPlotArea.Series.Add(barSeries1);
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Item B");
            chart.PrimaryPlotArea.Series.Add(barSeries2);
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Item C");
            chart.PrimaryPlotArea.Series.Add(barSeries3);
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            chart.AutoLayout = false;
            chart.Layout();
            chart.Legends[0].X = 20;
            chart.Legends[0].Y = 75;
            chart.Legends[0].BackgroundColor = RgbColor.Tan;

            chart.PrimaryPlotArea.Height = 150;
            chart.PrimaryPlotArea.Width = 175;
            chart.PrimaryPlotArea.X = 200;
            chart.PrimaryPlotArea.Y = 25;

            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/barchart-simple-manual-layout-output.pdf"));
        }

    }
}
