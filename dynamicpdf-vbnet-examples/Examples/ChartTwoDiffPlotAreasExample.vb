Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Series

Namespace DynamicPDFCoreSuite.Examples
    Public Class ChartTwoDiffPlotAreasExample

        Public Shared Sub Run()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim hght As Single = document.Pages(0).Dimensions.Height - document.Pages(0).Dimensions.TopMargin * 2
            Dim wdth As Single = document.Pages(0).Dimensions.Width - document.Pages(0).Dimensions.RightMargin * 2

            Dim chart As New Chart(0, 0, wdth, hght)
            chart.BackgroundColor = RgbColor.AliceBlue

            Dim plotArea1 As PlotArea = chart.PlotAreas.Add(50, 10, 150, 200)
            Dim plotArea2 As PlotArea = chart.PlotAreas.Add(250, 10, 150, 200)

            Dim barSeries1 As New IndexedBarSeries("Item A")
            plotArea1.Series.Add(barSeries1)
            barSeries1.Values.Add(New Single() {5, 7, 9, 6})

            Dim barSeries2 As New IndexedBarSeries("Item B")
            plotArea1.Series.Add(barSeries2)
            barSeries2.Values.Add(New Single() {4, 2, 5, 8})

            Dim barSeries3 As New IndexedBarSeries("Item C")
            plotArea1.Series.Add(barSeries3)
            barSeries3.Values.Add(New Single() {2, 4, 6, 9})

            Dim pieSeries As New PieSeries()
            Dim dataLbl As New ScalarDataLabel(True, False, False)
            pieSeries.DataLabel = dataLbl

            plotArea2.Series.Add(pieSeries)

            Dim pe1 As New PieSeriesElement(10, "A", RgbColor.Green)
            Dim pe2 As New PieSeriesElement(20, "B", RgbColor.Red)
            Dim pe3 As New PieSeriesElement(13, "C", RgbColor.Purple)

            pieSeries.Elements.Add(pe1)
            pieSeries.Elements.Add(pe2)
            pieSeries.Elements.Add(pe3)

            chart.AutoLayout = False
            chart.Legends(0).X = 50
            chart.Legends(0).BorderStyle = LineStyle.Solid
            chart.Legends(0).BorderColor = RgbColor.Black
            chart.Legends(0).Y = plotArea1.Height + 55

            page.Elements.Add(chart)
            document.Draw(Util.GetPath("Output/chart-two-plots-different-output.pdf"))
        End Sub

    End Class
End Namespace

