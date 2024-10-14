Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Axes
Imports ceTe.DynamicPDF.PageElements.Charting.Series
Imports System

Namespace DynamicPDFCoreSuite.Examples
    Public Class BarChartsExample
        Public Shared Sub Run()
            SimpleBarChart()
            SimpleBarChartIndexedAxis()
            SimpleBarChartManualLayout()
            SimpleDoubleBarChart()
            DateTimeStacked()
            DateTimeChart()
            BarStacked100Example()
        End Sub

        Public Shared Sub SimpleBarChart()
            Dim outputPath As String = Util.GetPath("Output/barchart-simple-output.pdf")
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 400, 200)
            Dim topTitle As New Title("DynamicPDF Item Report")
            topTitle.FontSize = 24
            Dim subTitle As New Title("For the 2024 Calendar Year.")
            Dim bottomTitle As New Title("Produced by CeTe 2024")
            bottomTitle.FontSize = 6

            chart.HeaderTitles.Add(topTitle)
            chart.HeaderTitles.Add(subTitle)
            chart.FooterTitles.Add(bottomTitle)

            chart.BackgroundColor = RgbColor.AliceBlue
            chart.PrimaryPlotArea.BackgroundColor = RgbColor.Gray
            Dim barSeries1 As New IndexedBarSeries("Item A")
            chart.PrimaryPlotArea.Series.Add(barSeries1)
            barSeries1.Values.Add(New Single() {5, 7, 9, 6})
            Dim barSeries2 As New IndexedBarSeries("Item B")
            chart.PrimaryPlotArea.Series.Add(barSeries2)
            barSeries2.Values.Add(New Single() {4, 2, 5, 8})
            Dim barSeries3 As New IndexedBarSeries("Item C")
            chart.PrimaryPlotArea.Series.Add(barSeries3)
            barSeries3.Values.Add(New Single() {2, 4, 6, 9})

            chart.Legends(0).BackgroundColor = RgbColor.Tan

            Dim title As New Title("Item Count")
            title.FontSize = 8
            Dim title2 As New Title("In thousands of items.")
            title2.FontSize = 8
            chart.PrimaryPlotArea.TopTitles.Add(title)
            chart.PrimaryPlotArea.BottomTitles.Add(title2)

            page.Elements.Add(chart)
            document.Draw(outputPath)
        End Sub

        Public Shared Sub SimpleBarChartIndexedAxis()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 400, 200)

            ' Create an indexed yAxis
            Dim yAxis As New IndexedYAxis()

            ' Create indexed y axis labels and add those to indexed y Axis
            yAxis.Labels.Add(New IndexedYAxisLabel("Q1", 0))
            yAxis.Labels.Add(New IndexedYAxisLabel("Q2", 1))
            yAxis.Labels.Add(New IndexedYAxisLabel("Q3", 2))
            yAxis.Labels.Add(New IndexedYAxisLabel("Q4", 3))

            ' Create a numeric xAxis
            Dim xAxis As New NumericXAxis()

            ' Create a title and add it to the XAxis

            Dim barSeries1 As New IndexedBarSeries("Item A", xAxis, yAxis)
            chart.PrimaryPlotArea.Series.Add(barSeries1)
            barSeries1.Values.Add(New Single() {5, 7, 9, 6})
            Dim barSeries2 As New IndexedBarSeries("Item B", xAxis, yAxis)
            chart.PrimaryPlotArea.Series.Add(barSeries2)
            barSeries2.Values.Add(New Single() {4, 2, 5, 8})
            Dim barSeries3 As New IndexedBarSeries("Item C", xAxis, yAxis)
            chart.PrimaryPlotArea.Series.Add(barSeries3)
            barSeries3.Values.Add(New Single() {2, 4, 6, 9})

            page.Elements.Add(chart)
            document.Draw(Util.GetPath("Output/barchart-simple-axis-output.pdf"))
        End Sub

        Public Shared Sub SimpleBarChartManualLayout()
            Dim outputPath As String = Util.GetPath("Output/barchart-simple-manual-layout-output.pdf")
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 400, 400)
            chart.BackgroundColor = RgbColor.AliceBlue
            chart.AutoLayout = False

            Dim legend As Legend = chart.Legends.Add(20, 75, 75, 75)
            legend.BackgroundColor = RgbColor.LightGrey

            Dim plotArea As PlotArea = chart.PlotAreas.Add(200, 25, 175, 150)
            plotArea.BackgroundColor = RgbColor.Gray

            Dim barSeries1 As New IndexedBarSeries("Item A")
            plotArea.Series.Add(barSeries1)
            barSeries1.Values.Add(New Single() {5, 7, 9, 6})
            Dim barSeries2 As New IndexedBarSeries("Item B")
            plotArea.Series.Add(barSeries2)
            barSeries2.Values.Add(New Single() {4, 2, 5, 8})
            Dim barSeries3 As New IndexedBarSeries("Item C")
            plotArea.Series.Add(barSeries3)
            barSeries3.Values.Add(New Single() {2, 4, 6, 9})

            chart.Layout()

            page.Elements.Add(chart)
            document.Draw(outputPath)
        End Sub

        Public Shared Sub SimpleDoubleBarChart()
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

            Dim barSeries4 As New IndexedBarSeries("Item 1")
            plotArea2.Series.Add(barSeries4)
            barSeries4.Values.Add(New Single() {3, 4, 6, 6})
            Dim barSeries5 As New IndexedBarSeries("Item 2")
            plotArea2.Series.Add(barSeries5)
            barSeries5.Values.Add(New Single() {4, 2, 6, 7})
            Dim barSeries6 As New IndexedBarSeries("Item 3")
            plotArea2.Series.Add(barSeries6)
            barSeries6.Values.Add(New Single() {2, 2, 6, 3})

            chart.AutoLayout = False
            chart.Legends(0).X = 50
            chart.Legends(0).BorderStyle = LineStyle.Solid
            chart.Legends(0).BorderColor = RgbColor.Black
            chart.Legends(0).Y = plotArea1.Height + 55

            page.Elements.Add(chart)
            document.Draw(Util.GetPath("Output/barchart-two-plots-output.pdf"))
        End Sub

        Public Shared Sub DateTimeChart()
            Dim outputPath As String = Util.GetPath("Output/barchart-datetime-output.pdf")
            ' Create a PDF Document
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 200)

            'Get the default plot area from the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add it to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create a date time bar series and add values to it
            Dim barSeries1 As New DateTimeBarSeries("Website A")
            barSeries1.Values.Add(5, New DateTime(2007, 1, 1))
            barSeries1.Values.Add(7, New DateTime(2007, 2, 1))
            barSeries1.Values.Add(9, New DateTime(2007, 3, 1))
            barSeries1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim barSeries2 As New DateTimeBarSeries("Website B")
            barSeries2.Values.Add(4, New DateTime(2007, 1, 1))
            barSeries2.Values.Add(2, New DateTime(2007, 2, 1))
            barSeries2.Values.Add(5, New DateTime(2007, 3, 1))
            barSeries2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim barSeries3 As New DateTimeBarSeries("Website C")
            barSeries3.Values.Add(2, New DateTime(2007, 1, 1))
            barSeries3.Values.Add(4, New DateTime(2007, 2, 1))
            barSeries3.Values.Add(6, New DateTime(2007, 3, 1))
            barSeries3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Add date time bar series to the plot area
            plotArea.Series.Add(barSeries1)
            plotArea.Series.Add(barSeries2)
            plotArea.Series.Add(barSeries3)

            ' Create a title and add it to the XAxis
            Dim title3 As New Title("Viewers (in millions)")
            barSeries1.XAxis.Titles.Add(title3)

            ' Set label format for the axis labels
            barSeries1.YAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(outputPath)
        End Sub

        Public Shared Sub DateTimeStacked()
            Dim outputPath As String = Util.GetPath("Output/barchart-stacked-datetime-output.pdf")
            ' Create a PDF Document
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 200)

            ' Get the default plot area from the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add it to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create a date time stacked bar series element and add values to it
            Dim seriesElement1 As New DateTimeStackedBarSeriesElement("Website A")
            seriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            seriesElement1.Values.Add(9, New DateTime(2007, 3, 1))
            seriesElement1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim seriesElement2 As New DateTimeStackedBarSeriesElement("Website B")
            seriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim seriesElement3 As New DateTimeStackedBarSeriesElement("Website C")
            seriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Create a date time stacked bar series and add date time stacked bar series elements to it
            Dim stackedBarSeries1 As New DateTimeStackedBarSeries()
            stackedBarSeries1.Add(seriesElement1)
            stackedBarSeries1.Add(seriesElement2)
            stackedBarSeries1.Add(seriesElement3)

            ' Add date time stacked bar series to the plot area
            plotArea.Series.Add(stackedBarSeries1)

            ' Create a title and add it to the XAxis
            Dim title3 As New Title("Viewers")
            stackedBarSeries1.XAxis.Titles.Add(title3)

            ' Set label format for axis labels
            stackedBarSeries1.YAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(outputPath)
        End Sub

        Public Shared Sub BarStacked100Example()
            Dim outputPath As String = Util.GetPath("Output/barchart-stacked-100-datetime-output.pdf")
            ' Create a PDF Document
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 200)

            ' Get the default plot area from the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add it to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create a date time 100 percent stacked bar series element and add values to it
            Dim seriesElement1 As New DateTime100PercentStackedBarSeriesElement("Website A")
            seriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            seriesElement1.Values.Add(9, New DateTime(2007, 3, 1))
            seriesElement1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim seriesElement2 As New DateTime100PercentStackedBarSeriesElement("Website B")
            seriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim seriesElement3 As New DateTime100PercentStackedBarSeriesElement("Website C")
            seriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Create a date time 100 percent stacked bar series and add date time 100 percent stacked bar series elements to it
            Dim stackedBarSeries1 As New DateTime100PercentStackedBarSeries()
            stackedBarSeries1.Add(seriesElement1)
            stackedBarSeries1.Add(seriesElement2)
            stackedBarSeries1.Add(seriesElement3)

            ' Add date time stacked bar series to the plot area
            plotArea.Series.Add(stackedBarSeries1)

            ' Create a title and add it to the XAxis
            Dim title3 As New Title("Viewers")
            stackedBarSeries1.XAxis.Titles.Add(title3)

            ' Set label format to the axis labels
            stackedBarSeries1.YAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(outputPath)
        End Sub

    End Class
End Namespace