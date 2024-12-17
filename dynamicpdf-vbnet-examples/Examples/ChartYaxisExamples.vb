Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Axes
Imports ceTe.DynamicPDF.PageElements.Charting.Series
Imports System

Namespace DynamicPDFCoreSuite.Examples
    Public Class ChartYaxisExamples
        Public Shared Sub Run()
            NumericYaxisExample()
            DateTimeYaxisExample()
            PercentageYaxisExample()
            IndexedYaxisExample()
        End Sub

        Public Shared Sub NumericYaxisExample()
            ' Create a PDF Document
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 200)

            ' Get the default plot area from the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add them to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create date time xAxis
            Dim xAxis As New DateTimeXAxis()

            ' Create a numeric yAxis 
            Dim yAxis As New NumericYAxis()

            ' Create a date time area series and add values to it
            Dim areaSeries1 As New DateTimeAreaSeries("Website A", xAxis, yAxis)
            areaSeries1.Values.Add(5, New DateTime(2007, 1, 1))
            areaSeries1.Values.Add(7, New DateTime(2007, 2, 1))
            areaSeries1.Values.Add(9, New DateTime(2007, 3, 1))
            areaSeries1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim areaSeries2 As New DateTimeAreaSeries("Website B", xAxis, yAxis)
            areaSeries2.Values.Add(4, New DateTime(2007, 1, 1))
            areaSeries2.Values.Add(2, New DateTime(2007, 2, 1))
            areaSeries2.Values.Add(5, New DateTime(2007, 3, 1))
            areaSeries2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim areaSeries3 As New DateTimeAreaSeries("Website C", xAxis, yAxis)
            areaSeries3.Values.Add(2, New DateTime(2007, 1, 1))
            areaSeries3.Values.Add(4, New DateTime(2007, 2, 1))
            areaSeries3.Values.Add(6, New DateTime(2007, 3, 1))
            areaSeries3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Add date time area series to the plot area
            plotArea.Series.Add(areaSeries1)
            plotArea.Series.Add(areaSeries2)
            plotArea.Series.Add(areaSeries3)

            ' Create a title and add it to the YAxis
            Dim title3 As New Title("Viewers (in millions)")
            yAxis.Titles.Add(title3)

            ' Set label format for the axis labels
            areaSeries1.XAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-numericyaxis-example-out.pdf"))
        End Sub

        Public Shared Sub DateTimeYaxisExample()
            ' Create a PDF Document
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 200)

            ' Get the default plot area from the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add them to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create percentage xAxis
            Dim xAxis As New PercentageXAxis()

            ' Create date time yAxis
            Dim yAxis As New DateTimeYAxis()
            yAxis.DateTimeType = DateTimeType.Year

            ' Create a date time 100 percent stacked bar series element and add values to it
            Dim seriesElement1 As New DateTime100PercentStackedBarSeriesElement("Website A")
            seriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2006, 2, 1))
            seriesElement1.Values.Add(9, New DateTime(2005, 3, 1))
            seriesElement1.Values.Add(6, New DateTime(2004, 4, 1))

            Dim seriesElement2 As New DateTime100PercentStackedBarSeriesElement("Website B")
            seriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2006, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2005, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2004, 4, 1))

            Dim seriesElement3 As New DateTime100PercentStackedBarSeriesElement("Website C")
            seriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2006, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2005, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2004, 4, 1))

            ' Create a date time 100 percent stacked bar series and add date time 100 percent stacked bar series elements to it
            Dim stackedBarSeries1 As New DateTime100PercentStackedBarSeries(xAxis, yAxis)
            stackedBarSeries1.Add(seriesElement1)
            stackedBarSeries1.Add(seriesElement2)
            stackedBarSeries1.Add(seriesElement3)

            ' Add date time 100 percent stacked bar series to the plot area
            plotArea.Series.Add(stackedBarSeries1)

            ' Create a title and add it to the x axis
            Dim title3 As New Title("Viewers")
            stackedBarSeries1.XAxis.Titles.Add(title3)

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-datetimeyaxis-example-out.pdf"))
        End Sub

        Public Shared Sub PercentageYaxisExample()
            ' Create a PDF Document
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 200)

            ' Get the default plot area from the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add them to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create percentage yAxis and add labels to it
            Dim yAxis As New PercentageYAxis()

            ' Create a date time xAxis
            Dim xAxis As New DateTimeXAxis()

            ' Create a date time 100 percent stacked area series element and add values to it
            Dim areaSeriesElement1 As New DateTime100PercentStackedAreaSeriesElement("Website A")
            areaSeriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            areaSeriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            areaSeriesElement1.Values.Add(9, New DateTime(2007, 3, 1))
            areaSeriesElement1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim areaSeriesElement2 As New DateTime100PercentStackedAreaSeriesElement("Website B")
            areaSeriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            areaSeriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            areaSeriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            areaSeriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim areaSeriesElement3 As New DateTime100PercentStackedAreaSeriesElement("Website C")
            areaSeriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            areaSeriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            areaSeriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            areaSeriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Create a date time 100 percent stacked area series and add elements to it
            Dim stackedAreaSeries1 As New DateTime100PercentStackedAreaSeries(xAxis, yAxis)
            stackedAreaSeries1.Add(areaSeriesElement1)
            stackedAreaSeries1.Add(areaSeriesElement2)
            stackedAreaSeries1.Add(areaSeriesElement3)

            ' Add date time 100 percent stacked area series to the plot area
            plotArea.Series.Add(stackedAreaSeries1)

            ' Set label list format for the axis labels
            stackedAreaSeries1.XAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-percentageyaxis-example-out.pdf"))
        End Sub

        Public Shared Sub IndexedYaxisExample()
            ' Create a PDF Document
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 230)

            ' Get the default plot area from the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add them to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create an indexed yAxis
            Dim yAxis As New IndexedYAxis()

            ' Create indexed y axis labels and add those to indexed yAxis
            yAxis.Labels.Add(New IndexedYAxisLabel("Q1", 0))
            yAxis.Labels.Add(New IndexedYAxisLabel("Q2", 1))
            yAxis.Labels.Add(New IndexedYAxisLabel("Q3", 2))
            yAxis.Labels.Add(New IndexedYAxisLabel("Q4", 3))

            ' Create a numeric xAxis
            Dim xAxis As New NumericXAxis()

            ' Create a title and add it to the xAxis
            Dim lTitle As New Title("Visitors (in millions)")
            xAxis.Titles.Add(lTitle)

            ' Create an indexed bar series and add values to it
            Dim barSeries1 As New IndexedBarSeries("Website A", xAxis, yAxis)
            barSeries1.Values.Add(New Single() {5, 7, 9, 6})

            Dim barSeries2 As New IndexedBarSeries("Website B", xAxis, yAxis)
            barSeries2.Values.Add(New Single() {4, 2, 5, 8})

            Dim barSeries3 As New IndexedBarSeries("Website C", xAxis, yAxis)
            barSeries3.Values.Add(New Single() {2, 4, 6, 9})

            ' Add indexed bar series to the plot area
            plotArea.Series.Add(barSeries1)
            plotArea.Series.Add(barSeries2)
            plotArea.Series.Add(barSeries3)

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-indexedyaxis-example-out.pdf"))
        End Sub

    End Class
End Namespace

