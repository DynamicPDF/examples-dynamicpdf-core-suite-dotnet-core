using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    public class LineChartsExample
    {

        public static void Run()
        {
            LineChartExample();
            StackedLineChartExample();
            Stacked100PercentLineChartExample();
            DateTimeExample();
            DateTimeStackedExample();
            DateTime100PercentStackedExample();
        }

        public static void DateTimeExample()
        {
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

            // Create positions
            DateTime p0 = new DateTime(2007, 1, 1);
            DateTime p1 = new DateTime(2007, 2, 1);
            DateTime p2 = new DateTime(2007, 3, 1);
            DateTime p3 = new DateTime(2007, 4, 1);

            // Create a date time line series and add values to it
            DateTimeLineSeries lineSeries1 = new DateTimeLineSeries("Website A");
            lineSeries1.Values.Add(5, p0);
            lineSeries1.Values.Add(7, p1);
            lineSeries1.Values.Add(9, p2);
            lineSeries1.Values.Add(6, p3);
            DateTimeLineSeries lineSeries2 = new DateTimeLineSeries("Website B");
            lineSeries2.Values.Add(4, p0);
            lineSeries2.Values.Add(2, p1);
            lineSeries2.Values.Add(5, p2);
            lineSeries2.Values.Add(8, p3);
            DateTimeLineSeries lineSeries3 = new DateTimeLineSeries("Website C");
            lineSeries3.Values.Add(2, p0);
            lineSeries3.Values.Add(4, p1);
            lineSeries3.Values.Add(6, p2);
            lineSeries3.Values.Add(9, p3);

            // Add date time line series to the plot area
            plotArea.Series.Add(lineSeries1);
            plotArea.Series.Add(lineSeries2);
            plotArea.Series.Add(lineSeries3);

            // Create a title and add it to the yAxis
            Title title3 = new Title("Viewers (in millions)");
            lineSeries1.YAxis.Titles.Add(title3);

            // set label  format for the axis labels
            lineSeries1.XAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-line-chart-date-time-output.pdf"));

        }

        public static void DateTimeStackedExample()
        {
            Document document = new Document();

            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 400, 400);

            // Get the default plot area from the chart
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            // Create a date time stacked line series element and add values to it
            DateTimeStackedLineSeriesElement seriesElement1 = new DateTimeStackedLineSeriesElement("Website A");
            seriesElement1.Values.Add(5, new DateTime(2007, 1, 1));
            seriesElement1.Values.Add(7, new DateTime(2007, 2, 1));
            seriesElement1.Values.Add(9, new DateTime(2007, 3, 1));
            seriesElement1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTimeStackedLineSeriesElement seriesElement2 = new DateTimeStackedLineSeriesElement("Website B");
            seriesElement2.Values.Add(4, new DateTime(2007, 1, 1));
            seriesElement2.Values.Add(2, new DateTime(2007, 2, 1));
            seriesElement2.Values.Add(5, new DateTime(2007, 3, 1));
            seriesElement2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTimeStackedLineSeriesElement seriesElement3 = new DateTimeStackedLineSeriesElement("Website C");
            seriesElement3.Values.Add(2, new DateTime(2007, 1, 1));
            seriesElement3.Values.Add(4, new DateTime(2007, 2, 1));
            seriesElement3.Values.Add(6, new DateTime(2007, 3, 1));
            seriesElement3.Values.Add(9, new DateTime(2007, 4, 1));

            // Create a date time stacked line series and add date time stacked line series elements to it
            DateTimeStackedLineSeries stackedLineSeries1 = new DateTimeStackedLineSeries();
            stackedLineSeries1.Add(seriesElement1);
            stackedLineSeries1.Add(seriesElement2);
            stackedLineSeries1.Add(seriesElement3);

            // Add date time stacked line series to plot area
            plotArea.Series.Add(stackedLineSeries1);

            // set label  format for the axis labels
            stackedLineSeries1.XAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);

            document.Draw(Util.GetPath("Output/chart-line-chart-date-time-stacked-output.pdf"));

        }

        public static void DateTime100PercentStackedExample()
        {
            Document document = new Document();

            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 400, 400);

            // Add a plot area to the chart
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            // Create a date time 100 percent stacked line series element and add values to it
            DateTime100PercentStackedLineSeriesElement seriesElement1 = new DateTime100PercentStackedLineSeriesElement("Website A");
            seriesElement1.Values.Add(5, new DateTime(2007, 1, 1));
            seriesElement1.Values.Add(7, new DateTime(2007, 2, 1));
            seriesElement1.Values.Add(9, new DateTime(2007, 3, 1));
            seriesElement1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTime100PercentStackedLineSeriesElement seriesElement2 = new DateTime100PercentStackedLineSeriesElement("Website B");
            seriesElement2.Values.Add(4, new DateTime(2007, 1, 1));
            seriesElement2.Values.Add(2, new DateTime(2007, 2, 1));
            seriesElement2.Values.Add(5, new DateTime(2007, 3, 1));
            seriesElement2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTime100PercentStackedLineSeriesElement seriesElement3 = new DateTime100PercentStackedLineSeriesElement("Website C");
            seriesElement3.Values.Add(2, new DateTime(2007, 1, 1));
            seriesElement3.Values.Add(4, new DateTime(2007, 2, 1));
            seriesElement3.Values.Add(6, new DateTime(2007, 3, 1));
            seriesElement3.Values.Add(9, new DateTime(2007, 4, 1));

            // Create a date time 100 percent stacked line series and add date time 100 percent stacked line series elements to it
            DateTime100PercentStackedLineSeries stackedLineSeries1 = new DateTime100PercentStackedLineSeries();
            stackedLineSeries1.Add(seriesElement1);
            stackedLineSeries1.Add(seriesElement2);
            stackedLineSeries1.Add(seriesElement3);

            // Add date time 100 percent stacked line series to plot area
            plotArea.Series.Add(stackedLineSeries1);

            // set label  format for the axis labels
            stackedLineSeries1.XAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);

            document.Draw(Util.GetPath("Output/chart-line-date-time-stacked-100-chart-output.pdf"));
        }

        public static void LineChartExample()
        {
            Document document = new Document();
            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 400, 230);
            // Create a plot area
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            // Create a indexed line series and add values to it
            IndexedLineSeries lineSeries1 = new IndexedLineSeries("Website A");
            lineSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedLineSeries lineSeries2 = new IndexedLineSeries("Website B");
            lineSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedLineSeries lineSeries3 = new IndexedLineSeries("Website C");
            lineSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Add indexed line series to the plot area
            plotArea.Series.Add(lineSeries1);
            plotArea.Series.Add(lineSeries2);
            plotArea.Series.Add(lineSeries3);

            // Create a title and add it to the yaxis
            Title lTitle = new Title("Visitors (in millions)");
            lineSeries1.YAxis.Titles.Add(lTitle);

            //Adding AxisLabels to the XAxis
            lineSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            lineSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            lineSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            lineSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));

            // Add the chart to the page
            page.Elements.Add(chart);
            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-line-chart-output.pdf"));
        }

        public static void StackedLineChartExample()
        {
            // Create a PDF Document
            Document document = new Document();
            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 400, 230);
            // Create a plot area
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            // Create a indexed stacked line series elements and add values to it
            IndexedStackedLineSeriesElement seriesElement1 = new IndexedStackedLineSeriesElement("Website A");
            seriesElement1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedStackedLineSeriesElement seriesElement2 = new IndexedStackedLineSeriesElement("Website B");
            seriesElement2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedStackedLineSeriesElement seriesElement3 = new IndexedStackedLineSeriesElement("Website C");
            seriesElement3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Create a Indexed Stacked Line Series
            IndexedStackedLineSeries lineSeries = new IndexedStackedLineSeries();
            // Add indexed stacked line series elements to the Indexed Stacked Line Series
            lineSeries.Add(seriesElement1);
            lineSeries.Add(seriesElement2);
            lineSeries.Add(seriesElement3);

            // Add the series to the plot area
            plotArea.Series.Add(lineSeries);

            // Create a title and add it to the yaxis
            Title lTitle = new Title("Visitors (in millions)");
            lineSeries.YAxis.Titles.Add(lTitle);

            //Adding AxisLabels to the XAxis
            lineSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            lineSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            lineSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            lineSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));

            // Add the chart to the page
            page.Elements.Add(chart);
            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-stacked-line-chart-output.pdf"));
        }

        public static void Stacked100PercentLineChartExample()
        {
            Document document = new Document();
            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 400, 230);
            // Create a plot area
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            // Create indexed 100% line series elements and add values to it
            Indexed100PercentStackedLineSeriesElement seriesElement1 = new Indexed100PercentStackedLineSeriesElement("Website A");
            seriesElement1.Values.Add(new float[] { 5, 7, 9, 6 });
            Indexed100PercentStackedLineSeriesElement seriesElement2 = new Indexed100PercentStackedLineSeriesElement("Website B");
            seriesElement2.Values.Add(new float[] { 4, 2, 5, 8 });
            Indexed100PercentStackedLineSeriesElement seriesElement3 = new Indexed100PercentStackedLineSeriesElement("Website C");
            seriesElement3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Create a Indexed 100% Stacked Line Series
            Indexed100PercentStackedLineSeries lineSeries = new Indexed100PercentStackedLineSeries();
            // Add indexed 100% line series elements to the Indexed 100% Stacked Line Series
            lineSeries.Add(seriesElement1);
            lineSeries.Add(seriesElement2);
            lineSeries.Add(seriesElement3);
            // Add the series to the plot area
            plotArea.Series.Add(lineSeries);

            // Create a title and add it to the yaxis
            Title lTitle = new Title("Visitors (in millions)");
            lineSeries.YAxis.Titles.Add(lTitle);

            //Adding AxisLabels to the XAxis
            lineSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            lineSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            lineSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            lineSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));

            // Add the chart to the page
            page.Elements.Add(chart);
            // Save the PDF
            document.Draw(Util.GetPath("Output/chart-stacked-100-line-chart-output.pdf"));
        }
    }
}
