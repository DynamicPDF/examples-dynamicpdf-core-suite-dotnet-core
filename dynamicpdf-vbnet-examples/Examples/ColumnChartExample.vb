
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Axes
Imports ceTe.DynamicPDF.PageElements.Charting.Series

Namespace DynamicPDFCoreSuite.Examples
    Public Class ColumnChartExample

        Public Shared Sub Run()
            IndexedColumn()
            DateTimeColumn()
            IndexedStacked()
            StackedDateTime()
            Stacked100DateTime()
            Stacked100Indexed()
        End Sub

        Public Shared Sub DateTimeColumn()
            Dim outputPath As String = Util.GetPath("Output/column-datetime-output.pdf")
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

            ' Create a date time column series element and add values to it
            Dim seriesElement1 As New DateTimeColumnSeries("Website A")
            seriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            seriesElement1.Values.Add(9, New DateTime(2007, 3, 1))
            seriesElement1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim seriesElement2 As New DateTimeColumnSeries("Website B")
            seriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim seriesElement3 As New DateTimeColumnSeries("Website C")
            seriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Add date time column series to plot area 
            plotArea.Series.Add(seriesElement1)
            plotArea.Series.Add(seriesElement2)
            plotArea.Series.Add(seriesElement3)

            ' Create a title and add it to the yAxis
            Dim title3 As New Title("Viewers (in millions)")
            seriesElement1.YAxis.Titles.Add(title3)

            ' Set label format for the axis labels
            seriesElement1.XAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(outputPath)
        End Sub


        Public Shared Sub IndexedColumn()
            Dim outputPath As String = Util.GetPath("Output/column-indexed-output.pdf")
            ' Create a PDF Document
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

            ' Create a indexed column series and add values to it
            Dim columnSeries1 As New IndexedColumnSeries("Website A")
            columnSeries1.Values.Add(New Single() {5, 7, 9, 6})
            Dim columnSeries2 As New IndexedColumnSeries("Website B")
            columnSeries2.Values.Add(New Single() {4, 2, 5, 8})
            Dim columnSeries3 As New IndexedColumnSeries("Website C")
            columnSeries3.Values.Add(New Single() {2, 4, 6, 9})

            ' Create autogradient and assign it to series
            Dim autogradient1 As New AutoGradient(180.0F, CmykColor.Red, CmykColor.IndianRed)
            columnSeries1.Color = autogradient1
            Dim autogradient2 As New AutoGradient(180.0F, CmykColor.Green, CmykColor.YellowGreen)
            columnSeries2.Color = autogradient2
            Dim autogradient3 As New AutoGradient(180.0F, CmykColor.Blue, CmykColor.LightBlue)
            columnSeries3.Color = autogradient3

            ' Add indexed column series to the plot area
            plotArea.Series.Add(columnSeries1)
            plotArea.Series.Add(columnSeries2)
            plotArea.Series.Add(columnSeries3)

            ' Create a title and add it to the y-axis
            Dim lTitle As New Title("Visitors (in millions)")
            columnSeries1.YAxis.Titles.Add(lTitle)

            ' Adding AxisLabels to the XAxis
            columnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            columnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            columnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            columnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))

            ' Add the chart to the page
            page.Elements.Add(chart)
            ' Save the PDF
            document.Draw(outputPath)
        End Sub


        Public Shared Sub Stacked100Indexed()
            Dim outputPath As String = Util.GetPath("Output/column-stacked-indexed-output.pdf")
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

            ' Create a date time 100 percent stacked column series elements and add values to it
            Dim seriesElement1 As New DateTime100PercentStackedColumnSeriesElement("Website A")
            seriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            seriesElement1.Values.Add(4, New DateTime(2007, 3, 1))
            seriesElement1.Values.Add(3, New DateTime(2007, 4, 1))

            Dim seriesElement2 As New DateTime100PercentStackedColumnSeriesElement("Website B")
            seriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim seriesElement3 As New DateTime100PercentStackedColumnSeriesElement("Website C")
            seriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Create a date time 100 percent stacked column series and add elements to it
            Dim stackedColumnSeries1 As New DateTime100PercentStackedColumnSeries()
            stackedColumnSeries1.Add(seriesElement1)
            stackedColumnSeries1.Add(seriesElement2)
            stackedColumnSeries1.Add(seriesElement3)

            ' Add the series to plot area
            plotArea.Series.Add(stackedColumnSeries1)

            ' Set label format for the axis labels
            stackedColumnSeries1.XAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(outputPath)
        End Sub

        Public Shared Sub Stacked100DateTime()
            Dim outputPath As String = Util.GetPath("Output/column-stacked-100-datetime-output.pdf")
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

            ' Create a date time 100 percent stacked column series elements and add values to it
            Dim seriesElement1 As New DateTime100PercentStackedColumnSeriesElement("Website A")
            seriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            seriesElement1.Values.Add(4, New DateTime(2007, 3, 1))
            seriesElement1.Values.Add(3, New DateTime(2007, 4, 1))

            Dim seriesElement2 As New DateTime100PercentStackedColumnSeriesElement("Website B")
            seriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim seriesElement3 As New DateTime100PercentStackedColumnSeriesElement("Website C")
            seriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Create a date time 100 percent stacked column series and add elements to it
            Dim stackedColumnSeries1 As New DateTime100PercentStackedColumnSeries()
            stackedColumnSeries1.Add(seriesElement1)
            stackedColumnSeries1.Add(seriesElement2)
            stackedColumnSeries1.Add(seriesElement3)

            ' Add the series to plot area
            plotArea.Series.Add(stackedColumnSeries1)

            ' Set label format for the axis labels
            stackedColumnSeries1.XAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(outputPath)
        End Sub

        Public Shared Sub StackedDateTime()
            Dim outputPath As String = Util.GetPath("Output/column-stacked-datetime-output.pdf")
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

            ' Create a date time stacked column series element and add values to it
            Dim seriesElement1 As New DateTimeStackedColumnSeriesElement("Website A")
            seriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            seriesElement1.Values.Add(9, New DateTime(2007, 3, 1))
            seriesElement1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim seriesElement2 As New DateTimeStackedColumnSeriesElement("Website B")
            seriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim seriesElement3 As New DateTimeStackedColumnSeriesElement("Website C")
            seriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            ' Create a date time stacked column series and add elements to it
            Dim stackedColumnSeries1 As New DateTimeStackedColumnSeries()
            stackedColumnSeries1.Add(seriesElement1)
            stackedColumnSeries1.Add(seriesElement2)
            stackedColumnSeries1.Add(seriesElement3)

            ' Add the series to plot area
            plotArea.Series.Add(stackedColumnSeries1)

            ' Create a title and add it to the yAxis
            Dim title3 As New Title("Viewers (in millions)")
            stackedColumnSeries1.YAxis.Titles.Add(title3)

            ' Set label format for the axis labels
            stackedColumnSeries1.XAxis.LabelFormat = "MMM"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(outputPath)
        End Sub

        Public Shared Sub IndexedStacked()
            Dim outputPath As String = Util.GetPath("Output/column-indexed-stacked-output.pdf")
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

            ' Create a indexed stacked column series elements and add values to it
            Dim seriesElement1 As New IndexedStackedColumnSeriesElement("Website A")
            seriesElement1.Values.Add(5)
            seriesElement1.Values.Add(7)
            seriesElement1.Values.Add(9)
            seriesElement1.Values.Add(6)

            Dim seriesElement2 As New IndexedStackedColumnSeriesElement("Website B")
            seriesElement2.Values.Add(4)
            seriesElement2.Values.Add(2)
            seriesElement2.Values.Add(5)
            seriesElement2.Values.Add(8)

            Dim seriesElement3 As New IndexedStackedColumnSeriesElement("Website C")
            seriesElement3.Values.Add(2)
            seriesElement3.Values.Add(4)
            seriesElement3.Values.Add(6)
            seriesElement3.Values.Add(9)

            ' Create a indexed stacked column series and add elements to it
            Dim stackedColumnSeries1 As New IndexedStackedColumnSeries()
            stackedColumnSeries1.Add(seriesElement1)
            stackedColumnSeries1.Add(seriesElement2)
            stackedColumnSeries1.Add(seriesElement3)

            ' Add the series to plot area
            plotArea.Series.Add(stackedColumnSeries1)

            ' Create a title and add it to the yAxis
            Dim title3 As New Title("Viewers (in millions)")
            stackedColumnSeries1.YAxis.Titles.Add(title3)

            ' Set label format for the axis labels
            stackedColumnSeries1.XAxis.LabelFormat = "Month"

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            document.Draw(outputPath)
        End Sub
    End Class
End Namespace

