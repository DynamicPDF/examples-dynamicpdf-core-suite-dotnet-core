
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    public class ColumnChartExample
    {

        public static void Run() {

            IndexedColumn();
            DateTimeColumn();
        }

        public static void DateTimeColumn()
        {
                string outputPath = Util.GetPath("Output/column-datetime-output.pdf");
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

                // Create a date time  column series element and add values to it
                DateTimeColumnSeries seriesElement1 = new DateTimeColumnSeries("Website A");
                seriesElement1.Values.Add(5, new DateTime(2007, 1, 1));
                seriesElement1.Values.Add(7, new DateTime(2007, 2, 1));
                seriesElement1.Values.Add(9, new DateTime(2007, 3, 1));
                seriesElement1.Values.Add(6, new DateTime(2007, 4, 1));
                DateTimeColumnSeries seriesElement2 = new DateTimeColumnSeries("Website B");
                seriesElement2.Values.Add(4, new DateTime(2007, 1, 1));
                seriesElement2.Values.Add(2, new DateTime(2007, 2, 1));
                seriesElement2.Values.Add(5, new DateTime(2007, 3, 1));
                seriesElement2.Values.Add(8, new DateTime(2007, 4, 1));
                DateTimeColumnSeries seriesElement3 = new DateTimeColumnSeries("Website C");
                seriesElement3.Values.Add(2, new DateTime(2007, 1, 1));
                seriesElement3.Values.Add(4, new DateTime(2007, 2, 1));
                seriesElement3.Values.Add(6, new DateTime(2007, 3, 1));
                seriesElement3.Values.Add(9, new DateTime(2007, 4, 1));

                // Add date time  column series to plot area 
                plotArea.Series.Add(seriesElement1);
                plotArea.Series.Add(seriesElement2);
                plotArea.Series.Add(seriesElement3);

                // Create a title and add it to the yAxis
                Title title3 = new Title("Viewers (in millions)");
                seriesElement1.YAxis.Titles.Add(title3);

                // set label  format for the axis labels
                seriesElement1.XAxis.LabelFormat = "MMM";

                // Add the chart to the page
                page.Elements.Add(chart);

                // Save the PDF
                document.Draw(outputPath);
        }


        public static void IndexedColumn()
        {
            string outputPath = Util.GetPath("Output/column-indexed-output.pdf");
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

            // Create a indexed column series and add values to it
            IndexedColumnSeries columnSeries1 = new IndexedColumnSeries("Website A");
            columnSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedColumnSeries columnSeries2 = new IndexedColumnSeries("Website B");
            columnSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedColumnSeries columnSeries3 = new IndexedColumnSeries("Website C");
            columnSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Create autogradient and assign it to series
            AutoGradient autogradient1 = new AutoGradient(180f, CmykColor.Red, CmykColor.IndianRed);
            columnSeries1.Color = autogradient1;
            AutoGradient autogradient2 = new AutoGradient(180f, CmykColor.Green, CmykColor.YellowGreen);
            columnSeries2.Color = autogradient2;
            AutoGradient autogradient3 = new AutoGradient(180f, CmykColor.Blue, CmykColor.LightBlue);
            columnSeries3.Color = autogradient3;

            // Add indexed column series to the plot area
            plotArea.Series.Add(columnSeries1);
            plotArea.Series.Add(columnSeries2);
            plotArea.Series.Add(columnSeries3);

            // Create a title and add it to the yaxis
            Title lTitle = new Title("Visitors (in millions)");
            columnSeries1.YAxis.Titles.Add(lTitle);

            //Adding AxisLabels to the XAxis
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));

            // Add the chart to the page
            page.Elements.Add(chart);
            // Save the PDF
            document.Draw(outputPath);
        }


    }
}
