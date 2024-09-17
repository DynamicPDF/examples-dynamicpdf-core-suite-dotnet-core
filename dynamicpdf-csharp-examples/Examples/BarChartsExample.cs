
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;

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
            DateTimeStacked();
            DateTime();
            BarStacked100Example();

        }

        public static void DateTime()
        {
            string outputPath = Util.GetPath("Output/barchart-datetime-output.pdf");
            // Create a PDF Document
            Document document = new Document();

            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 400, 200);

            //Get the default plot area from the chart
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            // Create a date time bar series and add values to it
            DateTimeBarSeries barSeries1 = new DateTimeBarSeries("Website A");
            barSeries1.Values.Add(5, new DateTime(2007, 1, 1));
            barSeries1.Values.Add(7, new DateTime(2007, 2, 1));
            barSeries1.Values.Add(9, new DateTime(2007, 3, 1));
            barSeries1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTimeBarSeries barSeries2 = new DateTimeBarSeries("Website B");
            barSeries2.Values.Add(4, new DateTime(2007, 1, 1));
            barSeries2.Values.Add(2, new DateTime(2007, 2, 1));
            barSeries2.Values.Add(5, new DateTime(2007, 3, 1));
            barSeries2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTimeBarSeries barSeries3 = new DateTimeBarSeries("Website C");
            barSeries3.Values.Add(2, new DateTime(2007, 1, 1));
            barSeries3.Values.Add(4, new DateTime(2007, 2, 1));
            barSeries3.Values.Add(6, new DateTime(2007, 3, 1));
            barSeries3.Values.Add(9, new DateTime(2007, 4, 1));

            // Add date time bar series to the plot area
            plotArea.Series.Add(barSeries1);
            plotArea.Series.Add(barSeries2);
            plotArea.Series.Add(barSeries3);

            // Create a title and add it to the XAxis
            Title title3 = new Title("Viewers (in millions)");
            barSeries1.XAxis.Titles.Add(title3);

            // set label  format for the axis labels
            barSeries1.YAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(outputPath);
        }


        public static void DateTimeStacked()
        {
            string outputPath = Util.GetPath("Output/barchart-stacked-datetime-output.pdf");
            // Create a PDF Document
            Document document = new Document();

            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 400, 200);

            // Get the default plot area from the chart
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            // Create a date time stacked bar series element and add values to it
            DateTimeStackedBarSeriesElement seriesElement1 = new DateTimeStackedBarSeriesElement("Website A");
            seriesElement1.Values.Add(5, new DateTime(2007, 1, 1));
            seriesElement1.Values.Add(7, new DateTime(2007, 2, 1));
            seriesElement1.Values.Add(9, new DateTime(2007, 3, 1));
            seriesElement1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTimeStackedBarSeriesElement seriesElement2 = new DateTimeStackedBarSeriesElement("Website B");
            seriesElement2.Values.Add(4, new DateTime(2007, 1, 1));
            seriesElement2.Values.Add(2, new DateTime(2007, 2, 1));
            seriesElement2.Values.Add(5, new DateTime(2007, 3, 1));
            seriesElement2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTimeStackedBarSeriesElement seriesElement3 = new DateTimeStackedBarSeriesElement("Website C");
            seriesElement3.Values.Add(2, new DateTime(2007, 1, 1));
            seriesElement3.Values.Add(4, new DateTime(2007, 2, 1));
            seriesElement3.Values.Add(6, new DateTime(2007, 3, 1));
            seriesElement3.Values.Add(9, new DateTime(2007, 4, 1));

            // Create a date time stacked bar series and add date time stacked bar series elements to it
            DateTimeStackedBarSeries stackedBarSeries1 = new DateTimeStackedBarSeries();
            stackedBarSeries1.Add(seriesElement1);
            stackedBarSeries1.Add(seriesElement2);
            stackedBarSeries1.Add(seriesElement3);

            // Add date time stacked bar series to the plot area
            plotArea.Series.Add(stackedBarSeries1);

            // Create a title and add it to the XAxis
            Title title3 = new Title("Viewers");
            stackedBarSeries1.XAxis.Titles.Add(title3);

            // Set label  format for axis labels
            stackedBarSeries1.YAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(outputPath);
        }

        public static void BarStacked100Example()
        {
            string outputPath = Util.GetPath("Output/barchart-stacked-100-datetime-output.pdf");
            // Create a PDF Document
            Document document = new Document();

            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 400, 200);

            // Get the default plot area from the chart
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            // Create a date time 100 percent stacked bar series element and add values to it
            DateTime100PercentStackedBarSeriesElement seriesElement1 = new DateTime100PercentStackedBarSeriesElement("Website A");
            seriesElement1.Values.Add(5, new DateTime(2007, 1, 1));
            seriesElement1.Values.Add(7, new DateTime(2007, 2, 1));
            seriesElement1.Values.Add(9, new DateTime(2007, 3, 1));
            seriesElement1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTime100PercentStackedBarSeriesElement seriesElement2 = new DateTime100PercentStackedBarSeriesElement("Website B");
            seriesElement2.Values.Add(4, new DateTime(2007, 1, 1));
            seriesElement2.Values.Add(2, new DateTime(2007, 2, 1));
            seriesElement2.Values.Add(5, new DateTime(2007, 3, 1));
            seriesElement2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTime100PercentStackedBarSeriesElement seriesElement3 = new DateTime100PercentStackedBarSeriesElement("Website C");
            seriesElement3.Values.Add(2, new DateTime(2007, 1, 1));
            seriesElement3.Values.Add(4, new DateTime(2007, 2, 1));
            seriesElement3.Values.Add(6, new DateTime(2007, 3, 1));
            seriesElement3.Values.Add(9, new DateTime(2007, 4, 1));

            // Create a date time 100 percent stacked bar series and add date time 100 percent stacked bar series elements to it
            DateTime100PercentStackedBarSeries stackedBarSeries1 = new DateTime100PercentStackedBarSeries();
            stackedBarSeries1.Add(seriesElement1);
            stackedBarSeries1.Add(seriesElement2);
            stackedBarSeries1.Add(seriesElement3);

            // Add date time stacked bar series to the plot area
            plotArea.Series.Add(stackedBarSeries1);

            // Create a title and add it to the XAxis
            Title title3 = new Title("Viewers");
            stackedBarSeries1.XAxis.Titles.Add(title3);

            // Set label  format to the axis labels
            stackedBarSeries1.YAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(outputPath);
        }


        public static void SimpleBarChart()
        {
            string outputPath = Util.GetPath("Output/barchart-simple-output.pdf");
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
            document.Draw(outputPath);
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
            string outputPath = Util.GetPath("Output/barchart-simple-manual-layout-output.pdf");
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Chart chart = new Chart(0, 0, 400, 400);
            chart.BackgroundColor = RgbColor.AliceBlue;
            chart.AutoLayout = false;

            Legend legend = chart.Legends.Add(20, 75, 75, 75);
            legend.BackgroundColor = RgbColor.LightGrey;

            PlotArea plotArea = chart.PlotAreas.Add(200, 25, 175, 150);
            plotArea.BackgroundColor = RgbColor.Gray;
            
            IndexedBarSeries barSeries1 = new IndexedBarSeries("Item A");
            plotArea.Series.Add(barSeries1);
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Item B");
            plotArea.Series.Add(barSeries2);
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Item C");
            plotArea.Series.Add(barSeries3);
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            chart.Layout();
                         
            page.Elements.Add(chart);
            document.Draw(outputPath);
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
