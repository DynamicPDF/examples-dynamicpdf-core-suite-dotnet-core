
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace DynamicPDFCoreSuite.Examples
{
    public class ChartLegendsExample
    {
        public static void Run()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            float hght = document.Pages[0].Dimensions.Height - document.Pages[0].Dimensions.TopMargin * 2;
            float wdth = document.Pages[0].Dimensions.Width - document.Pages[0].Dimensions.RightMargin * 2;

            Chart chart = new Chart(0, 0, wdth, hght/2);

            Legend myLegend = chart.Legends.Add(2, 3, 100, 50);
            myLegend.BackgroundColor = RgbColor.Tan;

            IndexedBarSeries barSeries1 = new IndexedBarSeries("Item A");
            chart.PrimaryPlotArea.Series.Add(barSeries1);
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Item B");
            chart.PrimaryPlotArea.Series.Add(barSeries2);
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Item C");
            chart.PrimaryPlotArea.Series.Add(barSeries3);
            barSeries3.Values.Add(new float[] { 2, 4, 6, 9 });

            chart.Legends.LabelsLayout = LayOut.Horizontal;
            chart.Legends[0].BorderStyle = LineStyle.Solid;
            chart.Legends[0].BorderColor = RgbColor.Black;
            chart.Legends[0].BackgroundColor = RgbColor.Tan;


            page.Elements.Add(chart);
            document.Draw(Util.GetPath("Output/chart-legends-output.pdf"));
        }


    }
}
