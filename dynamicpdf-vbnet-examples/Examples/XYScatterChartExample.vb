Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Series

Namespace DynamicPDFCoreSuite.Examples
    Class XYScatterChartExample
        Public Shared Sub Run()
            ' Create a PDF Document
            Dim document As New Document()
            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a chart
            Dim chart As New Chart(0, 0, 450, 200)
            ' Add a plot Area to the chart
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            ' Create a Header title and add it to the chart
            Dim tTitle As New Title("Player Height and Weight")
            chart.HeaderTitles.Add(tTitle)

            ' Create a xyScatter series and add values to it
            Dim xyScatterSeries1 As New XYScatterSeries("Team A")
            xyScatterSeries1.Values.Add(112, 110)
            xyScatterSeries1.Values.Add(125, 120)
            xyScatterSeries1.Values.Add(138, 136)
            xyScatterSeries1.Values.Add(150, 146)
            xyScatterSeries1.Values.Add(172, 164)

            Dim xyScatterSeries2 As New XYScatterSeries("Team B")
            xyScatterSeries2.Values.Add(110, 108)
            xyScatterSeries2.Values.Add(128, 124)
            xyScatterSeries2.Values.Add(140, 140)
            xyScatterSeries2.Values.Add(155, 150)
            xyScatterSeries2.Values.Add(170, 160)

            ' Add xyScatter series to the plot Area
            plotArea.Series.Add(xyScatterSeries1)
            plotArea.Series.Add(xyScatterSeries2)

            ' Create axis titles and add them to the axis
            Dim title1 As New Title("Height (Inches)")
            Dim title2 As New Title("Weight (Pounds)")
            xyScatterSeries1.YAxis.Titles.Add(title1)
            xyScatterSeries1.XAxis.Titles.Add(title2)

            ' Add the chart to the page
            page.Elements.Add(chart)

            ' Save the PDF
            Util.GetPath("Output/xyscatter-chart-output.pdf")
        End Sub
    End Class
End Namespace

