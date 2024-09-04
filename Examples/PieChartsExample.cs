
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
        }

        public static void SimplePlotAreaExample()
        {
            Document doc = new();
            doc.Pages.Add(new Page());

            Chart chart = new Chart(0, 0, 500, 500);
            chart.BackgroundColor = RgbColor.LightBlue;

            PlotArea plotArea = chart.PlotAreas.Add(10, 100, 300, 300);
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


            chart.AutoLayout = false;
            chart.Legends[0].X = 400;
            chart.Legends[0].Y = 250;

            doc.Pages[0].Elements.Add(chart);


            doc.Draw(Util.GetPath("Output/piechart-simple-output.pdf"));
        }


    }
}
