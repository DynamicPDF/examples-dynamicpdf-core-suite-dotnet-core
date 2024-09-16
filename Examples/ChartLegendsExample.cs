
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace DynamicPDFCoreSuite.Examples
{
    public class ChartLegendsExample
    {
        public static void Run()
        {
            LabelsExampleOne();
            LabelsExampleTwo();
            LegendsExampleThree();
        }

        public static void LabelsExampleOne()
        {
            string outputPath = Util.GetPath("Output/chart-legends-one-output.pdf");
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

            chart.Legends.Placement = LegendPlacement.BottomLeft;

            page.Elements.Add(chart);
            document.Draw(outputPath);
        }

        public static void LabelsExampleTwo()
        {
            string outputPath = Util.GetPath("Output/chart-legends-two-output.pdf");
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            float wdth = doc.Pages[0].Dimensions.Width - 100;
            float hght = doc.Pages[0].Dimensions.Height - 100;

            Chart chart = new Chart(0, 0, wdth, hght);
            chart.BackgroundColor = RgbColor.LightGreen;

            chart.PrimaryPlotArea.BackgroundColor = RgbColor.LightBlue;

           // Legend legend = chart.Legends.Add(400, 250, 50, 50);

            PieSeries pieSeries = new PieSeries();
            ScalarDataLabel dataLbl = new ScalarDataLabel(true, false, false);
            pieSeries.DataLabel = dataLbl;

            chart.PrimaryPlotArea.Series.Add(pieSeries);

            PieSeriesElement pe1 = new(10, "A", RgbColor.Green);
            PieSeriesElement pe2 = new(20, "B", RgbColor.Red);
            PieSeriesElement pe3 = new(13, "C", RgbColor.Purple);

            pieSeries.Elements.Add(pe1);
            pieSeries.Elements.Add(pe2);
            pieSeries.Elements.Add(pe3);

            chart.Legends[0].LegendLabelList[0].TextColor = RgbColor.OrangeRed;
            chart.Legends[0].LegendLabelList[1].Text = chart.Legends[0].LegendLabelList[1].Text + " (highest value)";


            LayoutGrid grid = new();
            grid.ShowTitle = false;



            chart.AutoLayout = false;
            chart.Layout();

            //chart.Legends[0].X = 400;
           // chart.Legends[0].Y = 250;

  
            doc.Pages[0].Elements.Add(chart);
            doc.Pages[0].Elements.Add(grid);

            doc.Draw(outputPath);
        }

        public static void LabelsExampleTwoOld()
        {
            string outputPath = Util.GetPath("Output/chart-legends-two-output.pdf");
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            float wdth = doc.Pages[0].Dimensions.Width - 100;
            float hght = doc.Pages[0].Dimensions.Height - 100;

            Chart chart = new Chart(0, 0, wdth, hght);
            chart.AutoLayout = false;
            chart.BackgroundColor = RgbColor.LightGreen;

            PlotArea plotArea = chart.PlotAreas.Add(10, 100, 300, 300);
            plotArea.BackgroundColor = RgbColor.LightBlue;

            Legend legend = chart.Legends.Add(400, 250, 50, 50);

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

            chart.Legends[0].LegendLabelList[0].TextColor = RgbColor.OrangeRed;
            chart.Legends[0].LegendLabelList[1].Text = chart.Legends[0].LegendLabelList[1].Text + " (highest value)";


            LayoutGrid grid = new();
            grid.ShowTitle = false;




            // chart.Layout();


            doc.Pages[0].Elements.Add(chart);
            doc.Pages[0].Elements.Add(grid);

            doc.Draw(outputPath);
        }

        public static void LegendsExampleThree()
        {
            string outputPath = Util.GetPath("Output/chart-legends-three-output.pdf");
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);

            float hght = document.Pages[0].Dimensions.Height - document.Pages[0].Dimensions.TopMargin * 2;
            float wdth = document.Pages[0].Dimensions.Width - document.Pages[0].Dimensions.RightMargin * 2;


            Chart chart = new Chart(0, 0, wdth, hght);
            
            PlotArea plotArea1 = chart.PlotAreas.Add(50, 10, 150, 200);
            PlotArea plotArea2 = chart.PlotAreas.Add(250, 10, 150, 200);

            Legend legend = chart.Legends.Add();
            legend.BorderColor = RgbColor.Black;
            legend.BackgroundColor = RgbColor.Tan;
            legend.BorderStyle = LineStyle.DashSmall;

            Legend legend2 = chart.Legends.Add();
            legend2.BackgroundColor = RgbColor.LightBlue;
            legend2.BorderColor = RgbColor.Black;
            legend2.BorderStyle = LineStyle.Solid;

            IndexedBarSeries barSeries1 = new IndexedBarSeries("Item A");
            barSeries1.Legend = legend;
            plotArea1.Series.Add(barSeries1);
            barSeries1.Values.Add(new float[] { 5, 7, 9, 6 });
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Item B");
            barSeries2.Legend = legend;
            plotArea1.Series.Add(barSeries2);
            barSeries2.Values.Add(new float[] { 4, 2, 5, 8 });

   
            IndexedBarSeries barSeries4 = new IndexedBarSeries("Item 1");
            barSeries4.Legend = legend2;
            plotArea2.Series.Add(barSeries4);
            barSeries4.Values.Add(new float[] { 3, 4, 6, 6 });
            IndexedBarSeries barSeries5 = new IndexedBarSeries("Item 2");
            barSeries5.Legend = legend2;
            plotArea2.Series.Add(barSeries5);
            barSeries5.Values.Add(new float[] { 4, 2, 6, 7 });

            
            page.Elements.Add(chart);
            document.Draw(outputPath);
        }


    }
}
