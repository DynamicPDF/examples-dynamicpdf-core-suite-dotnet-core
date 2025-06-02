using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;


namespace DynamicPDFCoreSuite.Examples
{
    class ChartsExample
    {

        public static void Run()
        {
            ExampleOne();
            ExampleTwo();
            ExampleThree();
            ExampleFive();
            ExampleSix();
            ExampleSeven();
        }

        public static void ExampleOne()
        {
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
            document.Draw(Util.GetPath("Output/chart-one-output.pdf"));
        }


        public static void ExampleTwo()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Chart chart = new Chart(0, 0, 400, 230);
            PlotArea plotArea = chart.PrimaryPlotArea;

            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            IndexedBarSeries barSeries1 = new IndexedBarSeries("Website A");
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Website B");
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Website C");
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            AutoGradient autogradient1 = new AutoGradient(180f, CmykColor.Red, CmykColor.IndianRed);
            barSeries1.Color = autogradient1;
            AutoGradient autogradient2 = new AutoGradient(180f, CmykColor.Green, CmykColor.YellowGreen);
            barSeries2.Color = autogradient2;
            AutoGradient autogradient3 = new AutoGradient(180f, CmykColor.Blue, CmykColor.LightBlue);
            barSeries3.Color = autogradient3;

            plotArea.Series.Add(barSeries1);
            plotArea.Series.Add(barSeries2);
            plotArea.Series.Add(barSeries3);

            Title lTitle = new Title("Visitors (in millions)");
            barSeries1.XAxis.Titles.Add(lTitle);

            barSeries1.YAxis.Labels.Add(new IndexedYAxisLabel("Q1", 0));
            barSeries1.YAxis.Labels.Add(new IndexedYAxisLabel("Q2", 1));
            barSeries1.YAxis.Labels.Add(new IndexedYAxisLabel("Q3", 2));
            barSeries1.YAxis.Labels.Add(new IndexedYAxisLabel("Q4", 3));

            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/chart-two-output.pdf"));
        }

        public static void ExampleThree()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Chart chart = new Chart(0, 0, 400, 230);
            PlotArea plotArea = chart.PrimaryPlotArea;

            Title title1 = new Title("Website Visitors");
            Title title2 = new Title("Year - 2007");
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            IndexedColumnSeries columnSeries1 = new IndexedColumnSeries("Website A");
            columnSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedColumnSeries columnSeries2 = new IndexedColumnSeries("Website B");
            columnSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedColumnSeries columnSeries3 = new IndexedColumnSeries("Website C");
            columnSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            AutoGradient autogradient1 = new AutoGradient(180f, CmykColor.Red, CmykColor.IndianRed);
            columnSeries1.Color = autogradient1;
            AutoGradient autogradient2 = new AutoGradient(180f, CmykColor.Green, CmykColor.YellowGreen);
            columnSeries2.Color = autogradient2;
            AutoGradient autogradient3 = new AutoGradient(180f, CmykColor.Blue, CmykColor.LightBlue);
            columnSeries3.Color = autogradient3;

            plotArea.Series.Add(columnSeries1);
            plotArea.Series.Add(columnSeries2);
            plotArea.Series.Add(columnSeries3);

            Title lTitle = new Title("Visitors (in millions)");
            columnSeries1.YAxis.Titles.Add(lTitle);

            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q1", 0));
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q2", 1));
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q3", 2));
            columnSeries1.XAxis.Labels.Add(new IndexedXAxisLabel("Q4", 3));

            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/chart-three-output.pdf"));
        }

 

        public static void ExampleFive()
        {
            Document document = new Document();
            Page page = new Page(PageSize.A4, PageOrientation.Landscape);
            document.Pages.Add(page);

            Chart chart = new Chart(0, 0, 700, 400);
            PlotArea plotArea = chart.PlotAreas.Add(50, 50, 300, 300);

            Title tTitle = new Title("Website Viewers (in millions)");
            Title tTitle1 = new Title("Year 2007");
            chart.HeaderTitles.Add(tTitle);
            chart.HeaderTitles.Add(tTitle1);

            AutoGradient autogradient1 = new AutoGradient(90f, CmykColor.Red, CmykColor.IndianRed);
            AutoGradient autogradient2 = new AutoGradient(90f, CmykColor.Green, CmykColor.YellowGreen);
            AutoGradient autogradient3 = new AutoGradient(90f, CmykColor.Blue, CmykColor.LightBlue);

            ScalarDataLabel da = new ScalarDataLabel(true, false, false);
            PieSeries pieSeries = new PieSeries();
            pieSeries.DataLabel = da;
            plotArea.Series.Add(pieSeries);

            pieSeries.Elements.Add(27, "Website A");
            pieSeries.Elements.Add(19, "Website B");
            pieSeries.Elements.Add(21, "Website C");

            pieSeries.Elements[0].Color = autogradient1;
            pieSeries.Elements[1].Color = autogradient2;
            pieSeries.Elements[2].Color = autogradient3;

            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/chart-five-output.pdf"));
        }

        public static void ExampleSix()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            Chart chart = new Chart(0, 0, 450, 200);
            PlotArea plotArea = chart.PrimaryPlotArea;

            Title tTitle = new Title("Player Height and Weight");
            chart.HeaderTitles.Add(tTitle);

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

            plotArea.Series.Add(xyScatterSeries1);
            plotArea.Series.Add(xyScatterSeries2);

            Title title1 = new Title("Height (Inches)");
            Title title2 = new Title("Weight (Pounds)");
            xyScatterSeries1.YAxis.Titles.Add(title1);
            xyScatterSeries1.XAxis.Titles.Add(title2);

            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/chart-six-output.pdf"));
        }

        public static void ExampleSeven()
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
            document.Draw(Util.GetPath("Output/chart-seven-output.pdf"));
        }

    }
}
