Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Axes
Imports ceTe.DynamicPDF.PageElements.Charting.Series
Imports System

Namespace DynamicPDFCoreSuite.Examples
    Public Class LineChartsExample
        Public Shared Sub Run()
            LineChartExample()
            StackedLineChartExample()
            Stacked100PercentLineChartExample()
            DateTimeExample()
            DateTimeStackedExample()
            DateTime100PercentStackedExample()
        End Sub

        Public Shared Sub Stacked100PercentLineChartExample()
            Dim document As New Document()
            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 230)
            ' Create a plot area
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add it to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create indexed 100% line series elements and add values to it
            Dim seriesElement1 As New Indexed100PercentStackedLineSeriesElement("Website A")
            seriesElement1.Values.Add(New Single() {5, 7, 9, 6})
            Dim seriesElement2 As New Indexed100PercentStackedLineSeriesElement("Website B")
            seriesElement2.Values.Add(New Single() {4, 2, 5, 8})
            Dim seriesElement3 As New Indexed100PercentStackedLineSeriesElement("Website C")
            seriesElement3.Values.Add(New Single() {2, 4, 6, 9})

            ' Create a Indexed 100% Stacked Line Series
            Dim lineSeries As New Indexed100PercentStackedLineSeries()
            ' Add indexed 100% line series elements to the Indexed 100% Stacked Line Series
            lineSeries.Add(seriesElement1)
            lineSeries.Add(seriesElement2)
            lineSeries.Add(seriesElement3)
            ' Add the series to the plot area
            plotArea.Series.Add(lineSeries)

            ' Create a title and add it to the y-axis
            Dim lTitle As New Title("Visitors (in millions)")
            lineSeries.YAxis.Titles.Add(lTitle)

            ' Adding AxisLabels to the XAxis
            lineSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            lineSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            lineSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            lineSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))

            ' Add the chart to the page
            page.Elements.Add(chart)
            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-stacked-100-line-chart-output.pdf"))
        End Sub


        Public Shared Sub StackedLineChartExample()
            ' Create a PDF Document
            Dim document As New Document()
            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 230)
            ' Create a plot area
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add them to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create indexed stacked line series elements and add values to them
            Dim seriesElement1 As New IndexedStackedLineSeriesElement("Website A")
            seriesElement1.Values.Add(New Single() {5, 7, 9, 6})
            Dim seriesElement2 As New IndexedStackedLineSeriesElement("Website B")
            seriesElement2.Values.Add(New Single() {4, 2, 5, 8})
            Dim seriesElement3 As New IndexedStackedLineSeriesElement("Website C")
            seriesElement3.Values.Add(New Single() {2, 4, 6, 9})

            ' Create an Indexed Stacked Line Series
            Dim lineSeries As New IndexedStackedLineSeries()
            ' Add indexed stacked line series elements to the Indexed Stacked Line Series
            lineSeries.Add(seriesElement1)
            lineSeries.Add(seriesElement2)
            lineSeries.Add(seriesElement3)

            ' Add the series to the plot area
            plotArea.Series.Add(lineSeries)

            ' Create a title and add it to the y-axis
            Dim lTitle As New Title("Visitors (in millions)")
            lineSeries.YAxis.Titles.Add(lTitle)

            ' Adding AxisLabels to the XAxis
            lineSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            lineSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            lineSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            lineSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))

            ' Add the chart to the page
            page.Elements.Add(chart)
            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-stacked-line-chart-output.pdf"))
        End Sub


        Public Shared Sub LineChartExample()
            Dim document As New Document()
            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 230)
            ' Create a plot area
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add it to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create an indexed line series and add values to it
            Dim lineSeries1 As New IndexedLineSeries("Website A")
            lineSeries1.Values.Add(New Single() {5, 7, 9, 6})
            Dim lineSeries2 As New IndexedLineSeries("Website B")
            lineSeries2.Values.Add(New Single() {4, 2, 5, 8})
            Dim lineSeries3 As New IndexedLineSeries("Website C")
            lineSeries3.Values.Add(New Single() {2, 4, 6, 9})

            ' Add indexed line series to the plot area
            plotArea.Series.Add(lineSeries1)
            plotArea.Series.Add(lineSeries2)
            plotArea.Series.Add(lineSeries3)

            ' Create a title and add it to the y-axis
            Dim lTitle As New Title("Visitors (in millions)")
            lineSeries1.YAxis.Titles.Add(lTitle)

            ' Adding AxisLabels to the XAxis
            lineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            lineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            lineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            lineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))

            ' Add the chart to the page
            page.Elements.Add(chart)
            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-line-chart-output.pdf"))
        End Sub


        Public Shared Sub DateTimeExample()
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

            ' Create positions
            Dim p0 As New DateTime(2007, 1, 1)
            Dim p1 As New DateTime(2007, 2, 1)
            Dim p2 As New DateTime(2007, 3, 1)
            Dim p3 As New DateTime(2007, 4, 1)

            ' Create a date time line series and add values to it
            Dim lineSeries1 As New DateTimeLineSeries("Website A")
            lineSeries1.Values.Add(5, p0)
            lineSeries1.Values.Add(7, p1)
            lineSeries1.Values.Add(9, p2)
            lineSeries1.Values.Add(6, p3)

            Dim lineSeries2 As New DateTimeLineSeries("Website B")
            lineSeries2.Values.Add(4, p0)
            lineSeries2.Values.Add(2, p1)
            lineSeries2.Values.Add(5, p2)
            lineSeries2.Values.Add(8, p3)

            Dim lineSeries3 As New DateTimeLineSeries("Website C")
            lineSeries3.Values.Add(2, p0)
            lineSeries3.Values.Add(4, p1)
            lineSeries3.Values.Add(6, p2)
            lineSeries3.Values.Add(9, p3)

            ' Add date time line series to the plot area
            plotArea.Series.Add(lineSeries1)
            plotArea.Series.Add(lineSeries2)
            plotArea.Series.Add(lineSeries3)

            ' Create a title and add it to the yAxis
            Dim title3 As New Title("Viewers (in millions)")
            lineSeries1.YAxis.Titles.Add(title3)

            ' Set label format for the axis labels
            lineSeries1.XAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(Util.GetPath("Output/chart-line-chart-date-time-output.pdf"))
        End Sub

        Public Shared Sub DateTimeStackedExample()
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 400)

            ' Get the default plot area from the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add it to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create a date time stacked line series element and add values to it
            Dim seriesElement1 As New DateTimeStackedLineSeriesElement("Website A")
            seriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            seriesElement1.Values.Add(9, New DateTime(2007, 3, 1))
            seriesElement1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim seriesElement2 As New DateTimeStackedLineSeriesElement("Website B")
            seriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim seriesElement3 As New DateTimeStackedLineSeriesElement("Website C")
            seriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Create a date time stacked line series and add date time stacked line series elements to it
            Dim stackedLineSeries1 As New DateTimeStackedLineSeries()
            stackedLineSeries1.Add(seriesElement1)
            stackedLineSeries1.Add(seriesElement2)
            stackedLineSeries1.Add(seriesElement3)

            ' Add date time stacked line series to plot area
            plotArea.Series.Add(stackedLineSeries1)

            ' Set label format for the axis labels
            stackedLineSeries1.XAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            document.Draw(Util.GetPath("Output/chart-line-chart-date-time-stacked-output.pdf"))
        End Sub

        Public Shared Sub DateTime100PercentStackedExample()
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 400, 400)

            ' Add a plot area to the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create header titles and add it to the chart
            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            ' Create a date time 100 percent stacked line series element and add values to it
            Dim seriesElement1 As New DateTime100PercentStackedLineSeriesElement("Website A")
            seriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            seriesElement1.Values.Add(9, New DateTime(2007, 3, 1))
            seriesElement1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim seriesElement2 As New DateTime100PercentStackedLineSeriesElement("Website B")
            seriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim seriesElement3 As New DateTime100PercentStackedLineSeriesElement("Website C")
            seriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Create a date time 100 percent stacked line series and add date time 100 percent stacked line series elements to it
            Dim stackedLineSeries1 As New DateTime100PercentStackedLineSeries()
            stackedLineSeries1.Add(seriesElement1)
            stackedLineSeries1.Add(seriesElement2)
            stackedLineSeries1.Add(seriesElement3)

            ' Add date time 100 percent stacked line series to plot area
            plotArea.Series.Add(stackedLineSeries1)

            ' Set label format for the axis labels
            stackedLineSeries1.XAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            document.Draw(Util.GetPath("Output/chart-line-date-time-stacked-100-chart-output.pdf"))
        End Sub


    End Class
End Namespace

