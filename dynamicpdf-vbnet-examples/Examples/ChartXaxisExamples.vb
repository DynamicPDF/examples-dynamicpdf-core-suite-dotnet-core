Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Axes
Imports ceTe.DynamicPDF.PageElements.Charting.Series
Imports System

Namespace DynamicPDFCoreSuite.Examples
    Public Class ChartsXaxisExample
        Public Shared Sub Run()
            NumericXaxisExample()
            DateTimeXaxisExample()
            PercentageXaxisExample()
            IndexedXaxisExample()
        End Sub

        Public Shared Sub NumericXaxisExample()
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

            ' Create a date time yAxis
            Dim yAxis As New DateTimeYAxis()

            ' Create a numeric xAxis 
            Dim xAxis As New NumericXAxis()

            ' Create a date time bar series and add values to it
            Dim barSeries1 As New DateTimeBarSeries("Website A", xAxis, yAxis)
            barSeries1.Values.Add(5, New DateTime(2007, 1, 1))
            barSeries1.Values.Add(7, New DateTime(2007, 2, 1))
            barSeries1.Values.Add(9, New DateTime(2007, 3, 1))
            barSeries1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim barSeries2 As New DateTimeBarSeries("Website B", xAxis, yAxis)
            barSeries2.Values.Add(4, New DateTime(2007, 1, 1))
            barSeries2.Values.Add(2, New DateTime(2007, 2, 1))
            barSeries2.Values.Add(5, New DateTime(2007, 3, 1))
            barSeries2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim barSeries3 As New DateTimeBarSeries("Website C", xAxis, yAxis)
            barSeries3.Values.Add(2, New DateTime(2007, 1, 1))
            barSeries3.Values.Add(4, New DateTime(2007, 2, 1))
            barSeries3.Values.Add(6, New DateTime(2007, 3, 1))
            barSeries3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Add date time bar series to the plot area
            plotArea.Series.Add(barSeries1)
            plotArea.Series.Add(barSeries2)
            plotArea.Series.Add(barSeries3)

            ' Create a title and add it to the xAxis
            Dim title3 As New Title("Viewers (in millions)")
            xAxis.Titles.Add(title3)

            ' Set label format for the axis labels
            barSeries1.YAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-numericxaxis-example-out.pdf"))
        End Sub

        Public Shared Sub DateTimeXaxisExample()
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

            ' Create date time xAxis
            Dim xAxis As New DateTimeXAxis()
            xAxis.DateTimeType = DateTimeType.Year

            ' Create percentage yAxis
            Dim yAxis As New PercentageYAxis()

            ' Create a date time 100 percent stacked line series element and add values to it
            Dim seriesElement1 As New DateTime100PercentStackedLineSeriesElement("Website A")
            seriesElement1.Values.Add(5, New DateTime(2004, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2005, 2, 1))
            seriesElement1.Values.Add(9, New DateTime(2006, 3, 1))
            seriesElement1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim seriesElement2 As New DateTime100PercentStackedLineSeriesElement("Website B")
            seriesElement2.Values.Add(4, New DateTime(2004, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2005, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2006, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim seriesElement3 As New DateTime100PercentStackedLineSeriesElement("Website C")
            seriesElement3.Values.Add(2, New DateTime(2004, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2005, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2006, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Create a date time 100 percent stacked line series and add date time 100 percent stacked line series elements to it
            Dim stackedLineSeries1 As New DateTime100PercentStackedLineSeries(xAxis, yAxis)
            stackedLineSeries1.Add(seriesElement1)
            stackedLineSeries1.Add(seriesElement2)
            stackedLineSeries1.Add(seriesElement3)

            ' Add date time 100 percent stacked line series to the plot area
            plotArea.Series.Add(stackedLineSeries1)

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-datetimexaxis-example-out.pdf"))
        End Sub

        Public Shared Sub PercentageXaxisExample()
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

            ' Create percentage xAxis
            Dim xAxis As New PercentageXAxis()

            ' Create a date time yAxis
            Dim yAxis As New DateTimeYAxis()

            ' Create a date time 100percent stacked bar series element and add values to it
            Dim barSeriesElement1 As New DateTime100PercentStackedBarSeriesElement("Website A")
            barSeriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            barSeriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            barSeriesElement1.Values.Add(9, New DateTime(2007, 3, 1))
            barSeriesElement1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim barSeriesElement2 As New DateTime100PercentStackedBarSeriesElement("Website B")
            barSeriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            barSeriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            barSeriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            barSeriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim barSeriesElement3 As New DateTime100PercentStackedBarSeriesElement("Website C")
            barSeriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            barSeriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            barSeriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            barSeriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Create a date time 100percent stacked bar series and add date time 100percent stacked bar series elements to it
            Dim stackedBarSeries1 As New DateTime100PercentStackedBarSeries(xAxis, yAxis)
            stackedBarSeries1.Add(barSeriesElement1)
            stackedBarSeries1.Add(barSeriesElement2)
            stackedBarSeries1.Add(barSeriesElement3)

            ' Add date time 100percent stacked bar series to the plot area
            plotArea.Series.Add(stackedBarSeries1)

            ' Set label format for the axis labels
            stackedBarSeries1.YAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-percentagexaxis-example-out.pdf"))
        End Sub

        Public Shared Sub IndexedXaxisExample()
            ' Create a PDF Document
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 230)

            ' Get the default plot area from the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add it to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create an indexed xAxis
            Dim xAxis As New IndexedXAxis()

            ' Create indexed axis labels and add those to indexed xAxis
            xAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            xAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            xAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            xAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))

            ' Create a numeric yAxis
            Dim yAxis As New NumericYAxis()

            ' Create a title and add it to the YAxis
            Dim lTitle As New Title("Visitors (in millions)")
            yAxis.Titles.Add(lTitle)

            ' Create a indexed area series and add values to it
            Dim areaSeries1 As New IndexedAreaSeries("Website A", xAxis, yAxis)
            areaSeries1.Values.Add(New Single() {5, 7, 9, 6})

            Dim areaSeries2 As New IndexedAreaSeries("Website B", xAxis, yAxis)
            areaSeries2.Values.Add(New Single() {4, 2, 5, 8})

            Dim areaSeries3 As New IndexedAreaSeries("Website C", xAxis, yAxis)
            areaSeries3.Values.Add(New Single() {2, 4, 6, 9})

            ' Add indexed area series to the plot area
            plotArea.Series.Add(areaSeries1)
            plotArea.Series.Add(areaSeries2)
            plotArea.Series.Add(areaSeries3)

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-indexedxaxis-example-out.pdf"))
        End Sub


    End Class
End Namespace




