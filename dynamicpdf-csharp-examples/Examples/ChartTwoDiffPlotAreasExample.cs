using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace DynamicPDFCoreSuite.Examples
{
    public class ChartTwoDiffPlotAreasExample
    {

        public static void Run()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            float hght = document.Pages[0].Dimensions.Height - document.Pages[0].Dimensions.TopMargin * 2;
            float wdth = document.Pages[0].Dimensions.Width - document.Pages[0].Dimensions.RightMargin * 2;


            Chart chart = new Chart(0, 0, wdth, hght);
            chart.BackgroundColor = RgbColor.AliceBlue;

            PlotArea plotArea1 = chart.PlotAreas.Add(50, 10, 150, 200);
            PlotArea plotArea2 = chart.PlotAreas.Add(250, 10, 150, 200);

            IndexedBarSeries barSeries1 = new IndexedBarSeries("Item A");
            plotArea1.Series.Add(barSeries1);
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Item B");
            plotArea1.Series.Add(barSeries2);
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Item C");
            plotArea1.Series.Add(barSeries3);
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            PieSeries pieSeries = new PieSeries();
            ScalarDataLabel dataLbl = new ScalarDataLabel(true, false, false);
            pieSeries.DataLabel = dataLbl;

            plotArea2.Series.Add(pieSeries);

            PieSeriesElement pe1 = new(10, "A", RgbColor.Green);
            PieSeriesElement pe2 = new(20, "B", RgbColor.Red);
            PieSeriesElement pe3 = new(13, "C", RgbColor.Purple);

            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);
            pieSeries.Elements.Add(pe3);

            chart.AutoLayout = false;
            chart.Legends[0].X = 50;
            chart.Legends[0].BorderStyle = LineStyle.Solid;
            chart.Legends[0].BorderColor = RgbColor.Black;
            chart.Legends[0].Y = plotArea1.Height + 55;


            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/chart-two-plots-different-output.pdf"));
        }


    }
}
