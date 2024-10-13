using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    class ChartYaxisExamples
    {
        public static void Run()
        {
            NumericYaxisExample();
            DateTimeYaxisExample();
            PercentageYaxisExample();
            IndexedYaxisExample();
        }

        public static void NumericYaxisExample()
        {
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

            // Create date time xAxis
            DateTimeXAxis xAxis = new DateTimeXAxis();

            // Create a numeric yAxis 
            NumericYAxis yAxis = new NumericYAxis();

            // Create a date time area series and add values to it
            DateTimeAreaSeries areaSeries1 = new DateTimeAreaSeries("Website A", xAxis, yAxis);
            areaSeries1.Values.Add(5, new DateTime(2007, 1, 1));
            areaSeries1.Values.Add(7, new DateTime(2007, 2, 1));
            areaSeries1.Values.Add(9, new DateTime(2007, 3, 1));
            areaSeries1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTimeAreaSeries areaSeries2 = new DateTimeAreaSeries("Website B", xAxis, yAxis);
            areaSeries2.Values.Add(4, new DateTime(2007, 1, 1));
            areaSeries2.Values.Add(2, new DateTime(2007, 2, 1));
            areaSeries2.Values.Add(5, new DateTime(2007, 3, 1));
            areaSeries2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTimeAreaSeries areaSeries3 = new DateTimeAreaSeries("Website C", xAxis, yAxis);
            areaSeries3.Values.Add(2, new DateTime(2007, 1, 1));
            areaSeries3.Values.Add(4, new DateTime(2007, 2, 1));
            areaSeries3.Values.Add(6, new DateTime(2007, 3, 1));
            areaSeries3.Values.Add(9, new DateTime(2007, 4, 1));

            // Add date time  area series to the plot area
            plotArea.Series.Add(areaSeries1);
            plotArea.Series.Add(areaSeries2);
            plotArea.Series.Add(areaSeries3);

            // Create a title and add it to the YAxis
            Title title3 = new Title("Viewers (in millions)");
            yAxis.Titles.Add(title3);

            // Set label  format for the axis labels
            areaSeries1.XAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);


            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-numericyaxis-example-out.pdf"));
        }
        public static void DateTimeYaxisExample()
        {
            // Create a PDF Document
            Document document = new Document();

            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 400, 200);

            // Get the default plot from the chart
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            // Create percentage xAxis
            PercentageXAxis xAxis = new PercentageXAxis();

            // Create date time yAxis
            DateTimeYAxis yAxis = new DateTimeYAxis();
            yAxis.DateTimeType = DateTimeType.Year;

            // Create a date time 100 percent stacked bar series element and add values to it
            DateTime100PercentStackedBarSeriesElement seriesElement1 = new DateTime100PercentStackedBarSeriesElement("Website A");
            seriesElement1.Values.Add(5, new DateTime(2007, 1, 1));
            seriesElement1.Values.Add(7, new DateTime(2006, 2, 1));
            seriesElement1.Values.Add(9, new DateTime(2005, 3, 1));
            seriesElement1.Values.Add(6, new DateTime(2004, 4, 1));
            DateTime100PercentStackedBarSeriesElement seriesElement2 = new DateTime100PercentStackedBarSeriesElement("Website B");
            seriesElement2.Values.Add(4, new DateTime(2007, 1, 1));
            seriesElement2.Values.Add(2, new DateTime(2006, 2, 1));
            seriesElement2.Values.Add(5, new DateTime(2005, 3, 1));
            seriesElement2.Values.Add(8, new DateTime(2004, 4, 1));
            DateTime100PercentStackedBarSeriesElement seriesElement3 = new DateTime100PercentStackedBarSeriesElement("Website C");
            seriesElement3.Values.Add(2, new DateTime(2007, 1, 1));
            seriesElement3.Values.Add(4, new DateTime(2006, 2, 1));
            seriesElement3.Values.Add(6, new DateTime(2005, 3, 1));
            seriesElement3.Values.Add(9, new DateTime(2004, 4, 1));

            // Create a date time 100 percent stacked bar series and add date time 100 percent stacked bar series elements to it
            DateTime100PercentStackedBarSeries stackedBarSeries1 = new DateTime100PercentStackedBarSeries(xAxis, yAxis);
            stackedBarSeries1.Add(seriesElement1);
            stackedBarSeries1.Add(seriesElement2);
            stackedBarSeries1.Add(seriesElement3);

            // Add date time 100 percent stacked bar series to the plot area
            plotArea.Series.Add(stackedBarSeries1);

            // Create a title and add it to the x axis
            Title title3 = new Title("Viewers");
            stackedBarSeries1.XAxis.Titles.Add(title3);

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-datetimeyaxis-example-out.pdf"));
        }

        public static void PercentageYaxisExample()
        {
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

            // Create percentage yAxis and add labels to it
            PercentageYAxis yAxis = new PercentageYAxis();

            // Create a date time xAxis
            DateTimeXAxis xAxis = new DateTimeXAxis();

            // Create a date time 100percent stacked area series element and add values to it
            DateTime100PercentStackedAreaSeriesElement areaSeriesElement1 = new DateTime100PercentStackedAreaSeriesElement("Website A");
            areaSeriesElement1.Values.Add(5, new DateTime(2007, 1, 1));
            areaSeriesElement1.Values.Add(7, new DateTime(2007, 2, 1));
            areaSeriesElement1.Values.Add(9, new DateTime(2007, 3, 1));
            areaSeriesElement1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTime100PercentStackedAreaSeriesElement areaSeriesElement2 = new DateTime100PercentStackedAreaSeriesElement("Website B");
            areaSeriesElement2.Values.Add(4, new DateTime(2007, 1, 1));
            areaSeriesElement2.Values.Add(2, new DateTime(2007, 2, 1));
            areaSeriesElement2.Values.Add(5, new DateTime(2007, 3, 1));
            areaSeriesElement2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTime100PercentStackedAreaSeriesElement areaSeriesElement3 = new DateTime100PercentStackedAreaSeriesElement("Website C");
            areaSeriesElement3.Values.Add(2, new DateTime(2007, 1, 1));
            areaSeriesElement3.Values.Add(4, new DateTime(2007, 2, 1));
            areaSeriesElement3.Values.Add(6, new DateTime(2007, 3, 1));
            areaSeriesElement3.Values.Add(9, new DateTime(2007, 4, 1));

            // Create a date time  100 percent stacked area  series and add date time 100 percent stacked area series elements to it
            DateTime100PercentStackedAreaSeries stackedAreaSeries1 = new DateTime100PercentStackedAreaSeries(xAxis, yAxis);
            stackedAreaSeries1.Add(areaSeriesElement1);
            stackedAreaSeries1.Add(areaSeriesElement2);
            stackedAreaSeries1.Add(areaSeriesElement3);

            // Add date time  100 percent stacked bar series to the plot area
            plotArea.Series.Add(stackedAreaSeries1);

            // Set label list format for the axis labels
            stackedAreaSeries1.XAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-percentageyaxis-example-out.pdf"));
        }

        public static void IndexedYaxisExample()
        {
            // Create a PDF Document
            Document document = new Document();

            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 400, 230);

            // Get the default plot area from the chart
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

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
            Title lTitle = new Title("Visitors (in millions)");
            xAxis.Titles.Add(lTitle);

            // Create a indexed bar series and add values to it
            IndexedBarSeries barSeries1 = new IndexedBarSeries("Website A", xAxis, yAxis);
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Website B", xAxis, yAxis);
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Website C", xAxis, yAxis);
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Add indexed bar series to the plot area
            plotArea.Series.Add(barSeries1);
            plotArea.Series.Add(barSeries2);
            plotArea.Series.Add(barSeries3);

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-indexedyaxis-example-out.pdf"));
        }

    }
}