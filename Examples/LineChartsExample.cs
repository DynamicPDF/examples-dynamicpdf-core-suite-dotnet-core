using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace DynamicPDFCoreSuite.Examples
{
    public class LineChartsExample
    {

        public static void Run()
        {
            LineChartExample();
            StackedLineChartExample();
            Stacked100PercentLineChartExample();
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
