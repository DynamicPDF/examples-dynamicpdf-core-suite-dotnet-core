
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
            SimpleDoubleBarChart();


        }

        public static void SimpleBarChart()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Chart chart = new Chart(0, 0, 400, 200);
            Title topTitle = new Title("DynamicPDF Item Report");
            topTitle.FontSize = 24;
            Title subTitle = new Title("For the 2024 Calendar Year.");
            Title bottomTitle = new Title("Produced by CeTe 2024");
            bottomTitle.FontSize = 6;



            chart.HeaderTitles.Add(topTitle);
            chart.HeaderTitles.Add(subTitle);
            chart.FooterTitles.Add(bottomTitle);

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

            Title title = new Title("Item Count");
            title.FontSize = 8;
            Title title2 = new Title("In thousands of items.");
            title2.FontSize = 8;
            chart.PrimaryPlotArea.TopTitles.Add(title);
            chart.PrimaryPlotArea.BottomTitles.Add(title2);

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

        public static void SimpleDoubleBarChart()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            float hght = document.Pages[0].Dimensions.Height - document.Pages[0].Dimensions.TopMargin * 2;
            float wdth = document.Pages[0].Dimensions.Width - document.Pages[0].Dimensions.RightMargin * 2;


            Chart chart = new Chart(0, 0, wdth, hght);
            chart.BackgroundColor = RgbColor.AliceBlue;

            PlotArea plotArea1 = chart.PlotAreas.Add(50, 10, 150, 200);
            PlotArea plotArea2 = chart.PlotAreas.Add(250, 10, 150, 200);
        

            IndexedBarSeries barSeries1 = new IndexedBarSeries("Item A");
            plotArea1.Series.Add(barSeries1);
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Item B");
            plotArea1.Series.Add(barSeries2);
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Item C");
            plotArea1.Series.Add(barSeries3);
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            IndexedBarSeries barSeries4 = new IndexedBarSeries("Item 1");
            plotArea2.Series.Add(barSeries4);
            barSeries4.Values.Add(new float[] { 3, 4, 6, 6 });
            IndexedBarSeries barSeries5 = new IndexedBarSeries("Item 2");
            plotArea2.Series.Add(barSeries5);
            barSeries5.Values.Add(new float[] { 4, 2, 6, 7 });
            IndexedBarSeries barSeries6 = new IndexedBarSeries("Item 3");
            plotArea2.Series.Add(barSeries6);
            barSeries6.Values.Add(new float[] { 2, 2, 6, 3 });

            chart.AutoLayout = false;
            chart.Legends[0].X = 50;
            chart.Legends[0].BorderStyle = LineStyle.Solid;
            chart.Legends[0].BorderColor = RgbColor.Black;
            chart.Legends[0].Y = plotArea1.Height + 55;


            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/barchart-two-plots-output.pdf"));
        }

    }
}
