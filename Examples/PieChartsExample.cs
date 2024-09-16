
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace DynamicPDFCoreSuite.Examples
{
    public class PieChartsExample
    {
        public static void Run()
        {
            SimplePlotAreaExample();
            SimplePlotAreaPercentageExample();
            ManualExample();
        }


        public static void SimplePlotAreaExample()
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.A4, PageOrientation.Landscape));

            Chart chart = new Chart(0, 0, 700, 400);

            Title tTitle = new Title("Website Viewers (in millions)");
            Title tTitle1 = new Title("Year 2007");
            chart.HeaderTitles.Add(tTitle);
            chart.HeaderTitles.Add(tTitle1);

            
            ScalarDataLabel da = new ScalarDataLabel(true, false, false);
            PieSeries pieSeries = new PieSeries();
            pieSeries.DataLabel = da;
            chart.PrimaryPlotArea.Series.Add(pieSeries);

            pieSeries.Elements.Add(27, "Website A");
            pieSeries.Elements.Add(19, "Website B");
            pieSeries.Elements.Add(21, "Website C");

            pieSeries.Elements[0].Color = new AutoGradient(90f, CmykColor.Red, CmykColor.IndianRed);
            pieSeries.Elements[1].Color = new AutoGradient(90f, CmykColor.Green, CmykColor.YellowGreen);
            pieSeries.Elements[2].Color = new AutoGradient(90f, CmykColor.Blue, CmykColor.LightBlue);


            doc.Pages[0].Elements.Add(chart);
            doc.Draw(Util.GetPath("Output/piechart-simple-output.pdf"));
        }

        public static void ManualExample()
        {
            string outputPath = Util.GetPath("Output/piechart-manual-output.pdf");
            Document document = new();
            document.Pages.Add(new Page());

            Chart chart = new Chart(0, 0, 500, 500);
            chart.BackgroundColor = RgbColor.LightBlue;
            chart.AutoLayout = false;

            PlotArea plotArea = chart.PlotAreas.Add(10, 100, 100, 100);
            plotArea.BackgroundColor = RgbColor.Tan;
            PieSeries pieSeries = new PieSeries();
            ScalarDataLabel dataLbl = new ScalarDataLabel(true, false, false);
            pieSeries.DataLabel = dataLbl;

            plotArea.Series.Add(pieSeries);
            PieSeriesElement pe1 = new(10, "A", RgbColor.Green);
            PieSeriesElement pe2 = new(20, "B", RgbColor.Red);
            PieSeriesElement pe3 = new(13, "C", RgbColor.Purple);

            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);
            pieSeries.Elements.Add(pe3);

            
            chart.Layout();

            chart.Legends[0].X = 400;
            chart.Legends[0].Y = 250;


            document.Pages[0].Elements.Add(chart);
            document.Draw(outputPath);
        }


        public static void SimplePlotAreaPercentageExample()
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.A4, PageOrientation.Landscape));

            Chart chart = new Chart(0, 0, 700, 400);

            Title tTitle = new Title("Website Viewers (in millions)");
            Title tTitle1 = new Title("Year 2007");
            chart.HeaderTitles.Add(tTitle);
            chart.HeaderTitles.Add(tTitle1);


            ScalarDataLabel da = new ScalarDataLabel(true, true, true);
            PieSeries pieSeries = new PieSeries();
            pieSeries.DataLabel = da;
            chart.PrimaryPlotArea.Series.Add(pieSeries);

            pieSeries.Elements.Add(27, "Website A");
            pieSeries.Elements.Add(19, "Website B");
            pieSeries.Elements.Add(21, "Website C");

            pieSeries.Elements[0].Color = new AutoGradient(90f, CmykColor.Red, CmykColor.IndianRed);
            pieSeries.Elements[1].Color = new AutoGradient(90f, CmykColor.Green, CmykColor.YellowGreen);
            pieSeries.Elements[2].Color = new AutoGradient(90f, CmykColor.Blue, CmykColor.LightBlue);


            doc.Pages[0].Elements.Add(chart);
            doc.Draw(Util.GetPath("Output/piechart-simple-percentage-output.pdf"));
        }


    }
}
