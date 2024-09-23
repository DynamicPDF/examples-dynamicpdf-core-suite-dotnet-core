using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace DynamicPDFCoreSuite.Examples
{
    public class GridLinesExample
    {
        public static void Run()
        {
            string outputPath = Util.GetPath("Output/gridlines-output.pdf");

            Document document = new();
            document.Pages.Add(new Page(PageSize.Letter, PageOrientation.Landscape));

            Chart chart = new Chart(0, 0, 500, 500);

            IndexedLineSeries ls = new IndexedLineSeries("Website A");
            ls.Values.Add(new float[] { 48, 83, 19, 23 });
            IndexedLineSeries ls2 = new IndexedLineSeries("Website B");
            ls2.Values.Add(new float[] { 52, 74, 9, 21 });
            IndexedLineSeries ls3 = new IndexedLineSeries("Website C");
            ls3.Values.Add(new float[] { 15, 43, 12, 8 });

            chart.PrimaryPlotArea.Series.Add(ls);
            chart.PrimaryPlotArea.Series.Add(ls2);
            chart.PrimaryPlotArea.Series.Add(ls3);


            Title title = new Title("Page Views");
            ls.YAxis.Titles.Add(title);

            ls.XAxis.Labels.Add(new IndexedXAxisLabel("Home", 0));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("Examples", 1));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("About", 2));
            ls.XAxis.Labels.Add(new IndexedXAxisLabel("Ordering", 3));

            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorGridLines = new XAxisGridLines();
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MinorGridLines = new XAxisGridLines();
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorGridLines = new YAxisGridLines();

            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorTickMarks = new YAxisTickMarks();
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MinorTickMarks = new YAxisTickMarks();

            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorTickMarks = new XAxisTickMarks();


            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorGridLines.Color = RgbColor.Navy;
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorGridLines.LineStyle = LineStyle.DashLarge;
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MinorGridLines.LineStyle = LineStyle.DashSmall;
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MinorGridLines.Color = RgbColor.LightBlue;

            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorGridLines.LineStyle = LineStyle.Solid;
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorGridLines.Color = RgbColor.LightGrey;

            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorTickMarks.Color = RgbColor.LightGrey;
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MinorTickMarks.Visible = false;
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorTickMarks.Visible = false;

            Title title2 = new Title("Page");
            ls.XAxis.Titles.Add(title2);

            ls.XAxis.Labels.Angle = 45;
            ls.XAxis.LabelOffset = 5;
            ls.XAxis.Labels.TextColor = RgbColor.Green;
            ls.XAxis.Labels.FontSize = 8;
            ls.XAxis.TitlePosition = XAxisTitlePosition.AboveXAxis;
            ls.XAxis.Titles[0].TextColor = RgbColor.Navy;

            document.Pages[0].Elements.Add(chart);

            document.Draw(outputPath);
        }
    }
}
