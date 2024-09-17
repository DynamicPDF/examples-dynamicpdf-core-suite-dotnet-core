

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace DynamicPDFCoreSuite.Examples
{
    class XYScatterChartExample
    {
        public static void Run()
        {
            string outputPath = Util.GetPath("Output/xyscatter-chart-output.pdf");
            // Create a PDF Document
            Document document = new Document();
            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create a chart
            Chart chart = new Chart(0, 0, 450, 200);
            // Add a plot Area to the chart
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create a Header title and add it to the chart
            Title tTitle = new Title("Player Height and Weight");
            chart.HeaderTitles.Add(tTitle);

            // Create a xyScatter series and add values to it
            XYScatterSeries xyScatterSeries1 = new XYScatterSeries("Team A");
            xyScatterSeries1.Values.Add(112, 110);
            xyScatterSeries1.Values.Add(125, 120);
            xyScatterSeries1.Values.Add(138, 136);
            xyScatterSeries1.Values.Add(150, 146);
            xyScatterSeries1.Values.Add(172, 164);
            XYScatterSeries xyScatterSeries2 = new XYScatterSeries("Team B");
            xyScatterSeries2.Values.Add(110, 108);
            xyScatterSeries2.Values.Add(128, 124);
            xyScatterSeries2.Values.Add(140, 140);
            xyScatterSeries2.Values.Add(155, 150);
            xyScatterSeries2.Values.Add(170, 160);

            // Add xyScatter series to the plot Area
            plotArea.Series.Add(xyScatterSeries1);
            plotArea.Series.Add(xyScatterSeries2);

            // Create axis titles and add it to the axis
            Title title1 = new Title("Height (Inches)");
            Title title2 = new Title("Weight (Pounds)");
            xyScatterSeries1.YAxis.Titles.Add(title1);
            xyScatterSeries1.XAxis.Titles.Add(title2);

            // Add the chart to the page
            page.Elements.Add(chart);
            // Save the PDF
            document.Draw(outputPath);
        }

    }
}
