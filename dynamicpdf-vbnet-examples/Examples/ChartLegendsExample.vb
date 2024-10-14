Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Series

Namespace DynamicPDFCoreSuite.Examples
    Public Class ChartLegendsExample
        Public Shared Sub Run()
            LabelsExampleOne()
            LabelsExampleTwo()
            LegendsExampleThree()
        End Sub

        Public Shared Sub LabelsExampleOne()
            Dim outputPath As String = Util.GetPath("Output/chart-legends-one-output.pdf")
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim hght As Single = document.Pages(0).Dimensions.Height - document.Pages(0).Dimensions.TopMargin * 2
            Dim wdth As Single = document.Pages(0).Dimensions.Width - document.Pages(0).Dimensions.RightMargin * 2

            Dim chart As New Chart(0, 0, wdth, hght / 2)

            Dim myLegend As Legend = chart.Legends.Add(2, 3, 100, 50)
            myLegend.BackgroundColor = RgbColor.Tan

            Dim barSeries1 As New IndexedBarSeries("Item A")
            chart.PrimaryPlotArea.Series.Add(barSeries1)
            barSeries1.Values.Add(New Single() {5, 7, 9, 6})

            Dim barSeries2 As New IndexedBarSeries("Item B")
            chart.PrimaryPlotArea.Series.Add(barSeries2)
            barSeries2.Values.Add(New Single() {4, 2, 5, 8})

            Dim barSeries3 As New IndexedBarSeries("Item C")
            chart.PrimaryPlotArea.Series.Add(barSeries3)
            barSeries3.Values.Add(New Single() {2, 4, 6, 9})

            chart.Legends.LabelsLayout = LayOut.Horizontal
            chart.Legends(0).BorderStyle = LineStyle.Solid
            chart.Legends(0).BorderColor = RgbColor.Black
            chart.Legends(0).BackgroundColor = RgbColor.Tan

            chart.Legends.Placement = LegendPlacement.BottomLeft

            page.Elements.Add(chart)
            document.Draw(outputPath)
        End Sub

        Public Shared Sub LabelsExampleTwo()
            Dim outputPath As String = Util.GetPath("Output/chart-legends-two-output.pdf")
            Dim doc As New Document()
            doc.Pages.Add(New Page(PageSize.Letter))

            Dim wdth As Single = doc.Pages(0).Dimensions.Width - 100
            Dim hght As Single = doc.Pages(0).Dimensions.Height - 100

            Dim chart As New Chart(0, 0, wdth, hght)
            chart.BackgroundColor = RgbColor.LightGreen
            chart.PrimaryPlotArea.BackgroundColor = RgbColor.LightBlue

            Dim pieSeries As New PieSeries()
            Dim dataLbl As New ScalarDataLabel(True, False, False)
            pieSeries.DataLabel = dataLbl

            chart.PrimaryPlotArea.Series.Add(pieSeries)

            Dim pe1 As New PieSeriesElement(10, "A", RgbColor.Green)
            Dim pe2 As New PieSeriesElement(20, "B", RgbColor.Red)
            Dim pe3 As New PieSeriesElement(13, "C", RgbColor.Purple)

            pieSeries.Elements.Add(pe1)
            pieSeries.Elements.Add(pe2)
            pieSeries.Elements.Add(pe3)

            chart.Legends(0).LegendLabelList(0).TextColor = RgbColor.OrangeRed
            chart.Legends(0).LegendLabelList(1).Text = chart.Legends(0).LegendLabelList(1).Text & " (highest value)"

            Dim grid As New LayoutGrid()
            grid.ShowTitle = False

            chart.AutoLayout = False
            chart.Layout()

            doc.Pages(0).Elements.Add(chart)
            doc.Pages(0).Elements.Add(grid)

            doc.Draw(outputPath)
        End Sub

        Public Shared Sub LabelsExampleTwoOld()
            Dim outputPath As String = Util.GetPath("Output/chart-legends-two-output.pdf")
            Dim doc As New Document()
            doc.Pages.Add(New Page(PageSize.Letter))

            Dim wdth As Single = doc.Pages(0).Dimensions.Width - 100
            Dim hght As Single = doc.Pages(0).Dimensions.Height - 100

            Dim chart As New Chart(0, 0, wdth, hght)
            chart.AutoLayout = False
            chart.BackgroundColor = RgbColor.LightGreen

            Dim plotArea As PlotArea = chart.PlotAreas.Add(10, 100, 300, 300)
            plotArea.BackgroundColor = RgbColor.LightBlue

            Dim legend As Legend = chart.Legends.Add(400, 250, 50, 50)

            Dim pieSeries As New PieSeries()
            Dim dataLbl As New ScalarDataLabel(True, False, False)
            pieSeries.DataLabel = dataLbl

            plotArea.Series.Add(pieSeries)

            Dim pe1 As New PieSeriesElement(10, "A", RgbColor.Green)
            Dim pe2 As New PieSeriesElement(20, "B", RgbColor.Red)
            Dim pe3 As New PieSeriesElement(13, "C", RgbColor.Purple)

            pieSeries.Elements.Add(pe1)
            pieSeries.Elements.Add(pe2)
            pieSeries.Elements.Add(pe3)

            chart.Legends(0).LegendLabelList(0).TextColor = RgbColor.OrangeRed
            chart.Legends(0).LegendLabelList(1).Text = chart.Legends(0).LegendLabelList(1).Text & " (highest value)"

            Dim grid As New LayoutGrid()
            grid.ShowTitle = False

            doc.Pages(0).Elements.Add(chart)
            doc.Pages(0).Elements.Add(grid)

            doc.Draw(outputPath)
        End Sub

        Public Shared Sub LegendsExampleThree()
            Dim outputPath As String = Util.GetPath("Output/chart-legends-three-output.pdf")
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim hght As Single = document.Pages(0).Dimensions.Height - document.Pages(0).Dimensions.TopMargin * 2
            Dim wdth As Single = document.Pages(0).Dimensions.Width - document.Pages(0).Dimensions.RightMargin * 2

            Dim chart As New Chart(0, 0, wdth, hght)

            Dim plotArea1 As PlotArea = chart.PlotAreas.Add(50, 10, 150, 200)
            Dim plotArea2 As PlotArea = chart.PlotAreas.Add(250, 10, 150, 200)

            Dim legend As Legend = chart.Legends.Add()
            legend.BorderColor = RgbColor.Black
            legend.BackgroundColor = RgbColor.Tan
            legend.BorderStyle = LineStyle.DashSmall

            Dim legend2 As Legend = chart.Legends.Add()
            legend2.BackgroundColor = RgbColor.LightBlue
            legend2.BorderColor = RgbColor.Black
            legend2.BorderStyle = LineStyle.Solid

            Dim barSeries1 As New IndexedBarSeries("Item A")
            barSeries1.Legend = legend
            plotArea1.Series.Add(barSeries1)
            barSeries1.Values.Add(New Single() {5, 7, 9, 6})

            Dim barSeries2 As New IndexedBarSeries("Item B")
            barSeries2.Legend = legend
            plotArea1.Series.Add(barSeries2)
            barSeries2.Values.Add(New Single() {4, 2, 5, 8})

            Dim barSeries4 As New IndexedBarSeries("Item 1")
            barSeries4.Legend = legend2
            plotArea2.Series.Add(barSeries4)
            barSeries4.Values.Add(New Single() {3, 4, 6, 6})

            Dim barSeries5 As New IndexedBarSeries("Item 2")
            barSeries5.Legend = legend2
            plotArea2.Series.Add(barSeries5)
            barSeries5.Values.Add(New Single() {4, 2, 6, 7})

            page.Elements.Add(chart)
            document.Draw(outputPath)
        End Sub
    End Class
End Namespace

