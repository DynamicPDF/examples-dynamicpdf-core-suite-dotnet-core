

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    public class ChartsXaxisExample
    {
        public static void Run()
        {
            NumericXaxisExample();
            DateTimeXaxisExample();
            PercentageXaxisExample();
            IndexedXaxisExample();
        }

        public static void NumericXaxisExample()
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

            // Create a date time  yAxis
            DateTimeYAxis yAxis = new DateTimeYAxis();

            // Create a numeric xAxis 
            NumericXAxis xAxis = new NumericXAxis();

            // Create a date time bar series and add values to it
            DateTimeBarSeries barSeries1 = new DateTimeBarSeries("Website A", xAxis, yAxis);
            barSeries1.Values.Add(5, new DateTime(2007, 1, 1));
            barSeries1.Values.Add(7, new DateTime(2007, 2, 1));
            barSeries1.Values.Add(9, new DateTime(2007, 3, 1));
            barSeries1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTimeBarSeries barSeries2 = new DateTimeBarSeries("Website B", xAxis, yAxis);
            barSeries2.Values.Add(4, new DateTime(2007, 1, 1));
            barSeries2.Values.Add(2, new DateTime(2007, 2, 1));
            barSeries2.Values.Add(5, new DateTime(2007, 3, 1));
            barSeries2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTimeBarSeries barSeries3 = new DateTimeBarSeries("Website C", xAxis, yAxis);
            barSeries3.Values.Add(2, new DateTime(2007, 1, 1));
            barSeries3.Values.Add(4, new DateTime(2007, 2, 1));
            barSeries3.Values.Add(6, new DateTime(2007, 3, 1));
            barSeries3.Values.Add(9, new DateTime(2007, 4, 1));

            // Add date time  bar series to the plot area
            plotArea.Series.Add(barSeries1);
            plotArea.Series.Add(barSeries2);
            plotArea.Series.Add(barSeries3);

            // Create a title and add it to the xAxis
            Title title3 = new Title("Viewers (in millions)");
            xAxis.Titles.Add(title3);

            // Set label  format for the axis labels
            barSeries1.YAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);


            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-numericxaxis-example-out.pdf"));
        }

        public static void DateTimeXaxisExample()
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

            // Create date time xAxis
            DateTimeXAxis xAxis = new DateTimeXAxis();
            xAxis.DateTimeType = DateTimeType.Year;

            // Create percentage yAxis
            PercentageYAxis yAxis = new PercentageYAxis();

            // Create a date time 100 percent stacked line series element and add values to it
            DateTime100PercentStackedLineSeriesElement seriesElement1 = new DateTime100PercentStackedLineSeriesElement("Website A");
            seriesElement1.Values.Add(5, new DateTime(2004, 1, 1));
            seriesElement1.Values.Add(7, new DateTime(2005, 2, 1));
            seriesElement1.Values.Add(9, new DateTime(2006, 3, 1));
            seriesElement1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTime100PercentStackedLineSeriesElement seriesElement2 = new DateTime100PercentStackedLineSeriesElement("Website B");
            seriesElement2.Values.Add(4, new DateTime(2004, 1, 1));
            seriesElement2.Values.Add(2, new DateTime(2005, 2, 1));
            seriesElement2.Values.Add(5, new DateTime(2006, 3, 1));
            seriesElement2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTime100PercentStackedLineSeriesElement seriesElement3 = new DateTime100PercentStackedLineSeriesElement("Website C");
            seriesElement3.Values.Add(2, new DateTime(2004, 1, 1));
            seriesElement3.Values.Add(4, new DateTime(2005, 2, 1));
            seriesElement3.Values.Add(6, new DateTime(2006, 3, 1));
            seriesElement3.Values.Add(9, new DateTime(2007, 4, 1));

            // Create a date time 100 percent stacked line series and add date time 100 percent stacked line series elements to it
            DateTime100PercentStackedLineSeries stackedLineSeries1 = new DateTime100PercentStackedLineSeries(xAxis, yAxis);
            stackedLineSeries1.Add(seriesElement1);
            stackedLineSeries1.Add(seriesElement2);
            stackedLineSeries1.Add(seriesElement3);

            // Add date time 100 percent stacked line series to the plot area
            plotArea.Series.Add(stackedLineSeries1);

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-datetimexaxis-example-out.pdf"));

        }

        public static void PercentageXaxisExample()
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

            // Create percentage xAxis 
            PercentageXAxis xAxis = new PercentageXAxis();

            // Create a date time yAxis
            DateTimeYAxis yAxis = new DateTimeYAxis();

            // Create a date time 100percent stacked bar series element and add values to it
            DateTime100PercentStackedBarSeriesElement barSeriesElement1 = new DateTime100PercentStackedBarSeriesElement("Website A");
            barSeriesElement1.Values.Add(5, new DateTime(2007, 1, 1));
            barSeriesElement1.Values.Add(7, new DateTime(2007, 2, 1));
            barSeriesElement1.Values.Add(9, new DateTime(2007, 3, 1));
            barSeriesElement1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTime100PercentStackedBarSeriesElement barSeriesElement2 = new DateTime100PercentStackedBarSeriesElement("Website B");
            barSeriesElement2.Values.Add(4, new DateTime(2007, 1, 1));
            barSeriesElement2.Values.Add(2, new DateTime(2007, 2, 1));
            barSeriesElement2.Values.Add(5, new DateTime(2007, 3, 1));
            barSeriesElement2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTime100PercentStackedBarSeriesElement barSeriesElement3 = new DateTime100PercentStackedBarSeriesElement("Website C");
            barSeriesElement3.Values.Add(2, new DateTime(2007, 1, 1));
            barSeriesElement3.Values.Add(4, new DateTime(2007, 2, 1));
            barSeriesElement3.Values.Add(6, new DateTime(2007, 3, 1));
            barSeriesElement3.Values.Add(9, new DateTime(2007, 4, 1));

            // Create a date time 100percent stacked bar series and add date time 100percent stacked bar series elements to it
            DateTime100PercentStackedBarSeries stackedBarSeries1 = new DateTime100PercentStackedBarSeries(xAxis, yAxis);
            stackedBarSeries1.Add(barSeriesElement1);
            stackedBarSeries1.Add(barSeriesElement2);
            stackedBarSeries1.Add(barSeriesElement3);

            // Add date time 100percent stacked bar series to the plot area
            plotArea.Series.Add(stackedBarSeries1);

            // Set label  format for the axislabels
            stackedBarSeries1.YAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-percentagexaxis-example-out.pdf"));
        }

        public static void IndexedXaxisExample()
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

            // Create a indexed xAxis
            IndexedXAxis xAxis = new IndexedXAxis();

            // Create indexed axis labels and add those to indexed xAxis
            xAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            xAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            xAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            xAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));

            // Create a numeric yAxis
            NumericYAxis yAxis = new NumericYAxis();

            // Create a title and add it to the YAxis
            Title lTitle = new Title("Visitors (in millions)");
            yAxis.Titles.Add(lTitle);

            // Create a indexed area series and add values to it
            IndexedAreaSeries areaSeries1 = new IndexedAreaSeries("Website A", xAxis, yAxis);
            areaSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedAreaSeries areaSeries2 = new IndexedAreaSeries("Website B", xAxis, yAxis);
            areaSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedAreaSeries areaSeries3 = new IndexedAreaSeries("Website C", xAxis, yAxis);
            areaSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Add indexed area series to the plot area
            plotArea.Series.Add(areaSeries1);
            plotArea.Series.Add(areaSeries2);
            plotArea.Series.Add(areaSeries3);

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-indexedxaxis-example-out.pdf"));
        }

    }
}
