
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    class AreaChartExample
    {
        public static void Run()
        {
            Normal();
            Stacked();
            Stacked100();
            DateTimeNormal();
            DateTimeStacked();
        }

        public static void Normal()
        {
            string outputPath = Util.GetPath("Output/areachart-simple-output.pdf");
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);


            Chart chart = new Chart(0, 0, 400, 230);
            PlotArea plotArea = chart.PrimaryPlotArea;

            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            IndexedAreaSeries areaSeries1 = new IndexedAreaSeries("Website A");
            areaSeries1.Values.Add(new float[] { 5, 7, 9, 6 });

            AutoGradient autogradient1 = new AutoGradient(90f, CmykColor.Red, CmykColor.IndianRed);
            areaSeries1.Color = autogradient1;

            plotArea.Series.Add(areaSeries1);


            Title lTitle = new Title("Visitors (in millions)");
            areaSeries1.YAxis.Titles.Add(lTitle);

            areaSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            areaSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            areaSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            areaSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));

            page.Elements.Add(chart);
            document.Draw(outputPath);
        }

        public static void Stacked()
        {
            string outputPath = Util.GetPath("Output/areachart-stacked-output.pdf");
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

            // Create indexed stacked area series elements and add values to it
            IndexedStackedAreaSeriesElement seriesElement1 = new IndexedStackedAreaSeriesElement("Website A");
            seriesElement1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedStackedAreaSeriesElement seriesElement2 = new IndexedStackedAreaSeriesElement("Website B");
            seriesElement2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedStackedAreaSeriesElement seriesElement3 = new IndexedStackedAreaSeriesElement("Website C");
            seriesElement3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Create autogradient and assign it to series
            AutoGradient autogradient1 = new AutoGradient(90f, CmykColor.Red, CmykColor.IndianRed);
            seriesElement1.Color = autogradient1;
            AutoGradient autogradient2 = new AutoGradient(90f, CmykColor.Green, CmykColor.YellowGreen);
            seriesElement2.Color = autogradient2;
            AutoGradient autogradient3 = new AutoGradient(120f, CmykColor.Blue, CmykColor.LightBlue);
            seriesElement3.Color = autogradient3;

            // Create a Indexed Stacked Area Series
            IndexedStackedAreaSeries areaSeries = new IndexedStackedAreaSeries();

            // Add indexed stacked area series elements to the Indexed Stacked Area Series
            areaSeries.Add(seriesElement1);
            areaSeries.Add(seriesElement2);
            areaSeries.Add(seriesElement3);

            // Add series to the plot area
            plotArea.Series.Add(areaSeries);

            // Create a title and add it to the YAxis
            Title lTitle = new Title("Visitors (in millions)");
            areaSeries.YAxis.Titles.Add(lTitle);

            //Adding AxisLabels to the XAxis
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));

            // Add the chart to the page
            page.Elements.Add(chart);
            // Save the PDF
            document.Draw(outputPath);
        }

        public static void Stacked100()
        {
            string outputPath = Util.GetPath("Output/areachart-stacked-100-output.pdf");

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

            // Create a indexed 100% stacked area series elements and add values to it
            Indexed100PercentStackedAreaSeriesElement seriesElement1 = new Indexed100PercentStackedAreaSeriesElement("Website A");
            seriesElement1.Values.Add(new float[] { 5, 7, 9, 6 });
            Indexed100PercentStackedAreaSeriesElement seriesElement2 = new Indexed100PercentStackedAreaSeriesElement("Website B");
            seriesElement2.Values.Add(new float[] { 4, 2, 5, 8 });
            Indexed100PercentStackedAreaSeriesElement seriesElement3 = new Indexed100PercentStackedAreaSeriesElement("Website C");
            seriesElement3.Values.Add(new float[] { 2, 4, 6, 9 });

            // Create autogradient and assign it to series
            AutoGradient autogradient1 = new AutoGradient(90f, CmykColor.Red, CmykColor.IndianRed);
            seriesElement1.Color = autogradient1;
            AutoGradient autogradient2 = new AutoGradient(90f, CmykColor.Green, CmykColor.YellowGreen);
            seriesElement2.Color = autogradient2;
            AutoGradient autogradient3 = new AutoGradient(120f, CmykColor.Blue, CmykColor.LightBlue);
            seriesElement3.Color = autogradient3;

            // Create a Indexed 100% Stacked Area Series
            Indexed100PercentStackedAreaSeries areaSeries = new Indexed100PercentStackedAreaSeries();

            // Add indexed 100% stacked area series elements to the Indexed 100% Stacked Area Series
            areaSeries.Add(seriesElement1);
            areaSeries.Add(seriesElement2);
            areaSeries.Add(seriesElement3);

            // Add series to the plot area
            plotArea.Series.Add(areaSeries);

            // Create a title and add it to the yAxis
            Title lTitle = new Title("Visitors (in millions)");
            areaSeries.YAxis.Titles.Add(lTitle);

            //Adding AxisLabels to the XAxis
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            areaSeries.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));

            // Add the chart to the page
            page.Elements.Add(chart);
            // Save the PDF
            document.Draw(outputPath);
        }

        public static void DateTimeNormal()
        {
            string outputPath = Util.GetPath("Output/areachart-datetime-normal-output.pdf");

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

            // Create positions
            DateTime p0 = new DateTime(2007, 1, 1);
            DateTime p1 = new DateTime(2007, 2, 1);
            DateTime p2 = new DateTime(2007, 3, 1);
            DateTime p3 = new DateTime(2007, 4, 1);

            // Create date time area series and add values to it
            DateTimeAreaSeries areaSeries1 = new DateTimeAreaSeries("Website A");
            areaSeries1.Values.Add(5, p0);
            areaSeries1.Values.Add(7, p1);
            areaSeries1.Values.Add(9, p2);
            areaSeries1.Values.Add(6, p3);
            DateTimeAreaSeries areaSeries2 = new DateTimeAreaSeries("Website B");
            areaSeries2.Values.Add(4, p0);
            areaSeries2.Values.Add(2, p1);
            areaSeries2.Values.Add(5, p2);
            areaSeries2.Values.Add(8, p3);
            DateTimeAreaSeries areaSeries3 = new DateTimeAreaSeries("Website C");
            areaSeries3.Values.Add(2, p0);
            areaSeries3.Values.Add(4, p1);
            areaSeries3.Values.Add(6, p2);
            areaSeries3.Values.Add(9, p3);

            //Add date time area series to the plot area
            plotArea.Series.Add(areaSeries1);
            plotArea.Series.Add(areaSeries2);
            plotArea.Series.Add(areaSeries3);

            // Create a title and add it to yAxis
            Title title3 = new Title("Viewers (in millions)");
            areaSeries1.YAxis.Titles.Add(title3);

            // Set label  format for the axis labels
            areaSeries1.XAxis.LabelFormat = "MMM";

            //Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(outputPath);
        }

        public static void DateTimeStacked()
        {
            string outputPath = Util.GetPath("Output/areachart-datetime-stacked-output.pdf");

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

            // Create a date time stacked area series element and add values to it
            DateTimeStackedAreaSeriesElement seriesElement1 = new DateTimeStackedAreaSeriesElement("Website A");
            seriesElement1.Values.Add(5, new DateTime(2007, 1, 1));
            seriesElement1.Values.Add(7, new DateTime(2007, 2, 1));
            seriesElement1.Values.Add(9, new DateTime(2007, 3, 1));
            seriesElement1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTimeStackedAreaSeriesElement seriesElement2 = new DateTimeStackedAreaSeriesElement("Website B");
            seriesElement2.Values.Add(4, new DateTime(2007, 1, 1));
            seriesElement2.Values.Add(2, new DateTime(2007, 2, 1));
            seriesElement2.Values.Add(5, new DateTime(2007, 3, 1));
            seriesElement2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTimeStackedAreaSeriesElement seriesElement3 = new DateTimeStackedAreaSeriesElement("Website C");
            seriesElement3.Values.Add(2, new DateTime(2007, 1, 1));
            seriesElement3.Values.Add(4, new DateTime(2007, 2, 1));
            seriesElement3.Values.Add(6, new DateTime(2007, 3, 1));
            seriesElement3.Values.Add(9, new DateTime(2007, 4, 1));

            // Create a date time stacked area series and add date time stacked area series elements to it
            DateTimeStackedAreaSeries stackedAreaSeries1 = new DateTimeStackedAreaSeries();
            stackedAreaSeries1.Add(seriesElement1);
            stackedAreaSeries1.Add(seriesElement2);
            stackedAreaSeries1.Add(seriesElement3);

            // Add date time stacked area series to the plot area
            plotArea.Series.Add(stackedAreaSeries1);

            // Create a title and add it to the yAxis
            Title title3 = new Title("Viewers (in millions)");
            stackedAreaSeries1.YAxis.Titles.Add(title3);

            // set label list format for the axis labels
            stackedAreaSeries1.XAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(outputPath);
        }

        public static void DateTime100Stacked()
        {
            string outputPath = Util.GetPath("Output/areachart-datetime-stacked-100-output.pdf");

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

            // Create a date time 100 percent stacked area series element and add values to it
            DateTime100PercentStackedAreaSeriesElement seriesElement1 = new DateTime100PercentStackedAreaSeriesElement("Website A");
            seriesElement1.Values.Add(5, new DateTime(2007, 1, 1));
            seriesElement1.Values.Add(7, new DateTime(2007, 2, 1));
            seriesElement1.Values.Add(9, new DateTime(2007, 3, 1));
            seriesElement1.Values.Add(6, new DateTime(2007, 4, 1));
            DateTime100PercentStackedAreaSeriesElement seriesElement2 = new DateTime100PercentStackedAreaSeriesElement("Website B");
            seriesElement2.Values.Add(4, new DateTime(2007, 1, 1));
            seriesElement2.Values.Add(2, new DateTime(2007, 2, 1));
            seriesElement2.Values.Add(5, new DateTime(2007, 3, 1));
            seriesElement2.Values.Add(8, new DateTime(2007, 4, 1));
            DateTime100PercentStackedAreaSeriesElement seriesElement3 = new DateTime100PercentStackedAreaSeriesElement("Website C");
            seriesElement3.Values.Add(2, new DateTime(2007, 1, 1));
            seriesElement3.Values.Add(4, new DateTime(2007, 2, 1));
            seriesElement3.Values.Add(6, new DateTime(2007, 3, 1));
            seriesElement3.Values.Add(9, new DateTime(2007, 4, 1));

            // Create a date time 100 percent stacked area series and add date time 100 percent stacked area series elements to it
            DateTime100PercentStackedAreaSeries stackedAreaSeries1 = new DateTime100PercentStackedAreaSeries();
            stackedAreaSeries1.Add(seriesElement1);
            stackedAreaSeries1.Add(seriesElement2);
            stackedAreaSeries1.Add(seriesElement3);

            // Add date time 100 percent stacked area series to the plot area
            plotArea.Series.Add(stackedAreaSeries1);

            // set label  format for the axis labels
            stackedAreaSeries1.XAxis.LabelFormat = "MMM";

            // Add the chart to the page
            page.Elements.Add(chart);

            // Save the PDF
            document.Draw(outputPath);
        }

    }
}
