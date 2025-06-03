Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Axes
Imports ceTe.DynamicPDF.PageElements.Charting.Series


Class ChartsExample

    Public Shared Sub Run()
        ExampleOne()
        ExampleTwo()
        ExampleThree()
        ExampleFive()
        ExampleSix()
        ExampleSeven()
    End Sub

    Public Shared Sub ExampleOne()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 400, 230)
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            Dim areaSeries1 As New IndexedAreaSeries("Website A")
            areaSeries1.Values.Add(New Single() {5, 7, 9, 6})

            Dim autogradient1 As New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
            areaSeries1.Color = autogradient1

            plotArea.Series.Add(areaSeries1)

            Dim lTitle As New Title("Visitors (in millions)")
            areaSeries1.YAxis.Titles.Add(lTitle)

            areaSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            areaSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            areaSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            areaSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))

            page.Elements.Add(chart)
            document.Draw(Util.GetPath("Output/chart-one-output.pdf"))
        End Sub

        Public Shared Sub ExampleTwo()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 400, 230)
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            Dim barSeries1 As New IndexedBarSeries("Website A")
            barSeries1.Values.Add(New Single() {5, 7, 9, 6})
            Dim barSeries2 As New IndexedBarSeries("Website B")
            barSeries2.Values.Add(New Single() {4, 2, 5, 8})
            Dim barSeries3 As New IndexedBarSeries("Website C")
            barSeries3.Values.Add(New Single() {2, 4, 6, 9})

            Dim autogradient1 As New AutoGradient(180.0F, CmykColor.Red, CmykColor.IndianRed)
            barSeries1.Color = autogradient1
            Dim autogradient2 As New AutoGradient(180.0F, CmykColor.Green, CmykColor.YellowGreen)
            barSeries2.Color = autogradient2
            Dim autogradient3 As New AutoGradient(180.0F, CmykColor.Blue, CmykColor.LightBlue)
            barSeries3.Color = autogradient3

            plotArea.Series.Add(barSeries1)
            plotArea.Series.Add(barSeries2)
            plotArea.Series.Add(barSeries3)

            Dim lTitle As New Title("Visitors (in millions)")
            barSeries1.XAxis.Titles.Add(lTitle)

            barSeries1.YAxis.Labels.Add(New IndexedYAxisLabel("Q1", 0))
            barSeries1.YAxis.Labels.Add(New IndexedYAxisLabel("Q2", 1))
            barSeries1.YAxis.Labels.Add(New IndexedYAxisLabel("Q3", 2))
            barSeries1.YAxis.Labels.Add(New IndexedYAxisLabel("Q4", 3))

            page.Elements.Add(chart)
            document.Draw(Util.GetPath("Output/chart-two-output.pdf"))
        End Sub

        Public Shared Sub ExampleThree()
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 400, 230)
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            Dim columnSeries1 As New IndexedColumnSeries("Website A")
            columnSeries1.Values.Add(New Single() {5, 7, 9, 6})
            Dim columnSeries2 As New IndexedColumnSeries("Website B")
            columnSeries2.Values.Add(New Single() {4, 2, 5, 8})
            Dim columnSeries3 As New IndexedColumnSeries("Website C")
            columnSeries3.Values.Add(New Single() {2, 4, 6, 9})

            Dim autogradient1 As New AutoGradient(180.0F, CmykColor.Red, CmykColor.IndianRed)
            columnSeries1.Color = autogradient1
            Dim autogradient2 As New AutoGradient(180.0F, CmykColor.Green, CmykColor.YellowGreen)
            columnSeries2.Color = autogradient2
            Dim autogradient3 As New AutoGradient(180.0F, CmykColor.Blue, CmykColor.LightBlue)
            columnSeries3.Color = autogradient3

            plotArea.Series.Add(columnSeries1)
            plotArea.Series.Add(columnSeries2)
            plotArea.Series.Add(columnSeries3)

            Dim lTitle As New Title("Visitors (in millions)")
            columnSeries1.YAxis.Titles.Add(lTitle)

            columnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            columnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            columnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            columnSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))

            page.Elements.Add(chart)
            document.Draw(Util.GetPath("Output/chart-three-output.pdf"))
        End Sub

        Public Shared Sub ExampleFive()
            Dim document As New Document()
            Dim page As New Page(PageSize.A4, PageOrientation.Landscape)
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 700, 400)
            Dim plotArea As PlotArea = chart.PlotAreas.Add(50, 50, 300, 300)

            Dim tTitle As New Title("Website Viewers (in millions)")
            Dim tTitle1 As New Title("Year 2007")
            chart.HeaderTitles.Add(tTitle)
            chart.HeaderTitles.Add(tTitle1)

            Dim autogradient1 As New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
            Dim autogradient2 As New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
            Dim autogradient3 As New AutoGradient(90.0F, CmykColor.Blue, CmykColor.LightBlue)

            Dim da As New ScalarDataLabel(True, False, False)
            Dim pieSeries As New PieSeries()
            pieSeries.DataLabel = da
            plotArea.Series.Add(pieSeries)

            pieSeries.Elements.Add(27, "Website A")
            pieSeries.Elements.Add(19, "Website B")
            pieSeries.Elements.Add(21, "Website C")

            pieSeries.Elements(0).Color = autogradient1
            pieSeries.Elements(1).Color = autogradient2
            pieSeries.Elements(2).Color = autogradient3

            page.Elements.Add(chart)
            document.Draw(Util.GetPath("Output/chart-five-output.pdf"))
        End Sub

    Public Shared Sub ExampleSix()
        Dim document As New Document()
        Dim page As New Page()
        document.Pages.Add(page)

        Dim chart As New Chart(0, 0, 450, 200)
        Dim plotArea As PlotArea = chart.PrimaryPlotArea

        Dim tTitle As New Title("Player Height and Weight")
        chart.HeaderTitles.Add(tTitle)

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

        plotArea.Series.Add(xyScatterSeries1)
        plotArea.Series.Add(xyScatterSeries2)

        Dim title1 As New Title("Height (Inches)")
        Dim title2 As New Title("Weight (Pounds)")
        xyScatterSeries1.YAxis.Titles.Add(title1)
        xyScatterSeries1.XAxis.Titles.Add(title2)

        page.Elements.Add(chart)
        document.Draw(Util.GetPath("Output/chart-six-output.pdf"))
    End Sub

    Public Shared Sub ExampleSeven()
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

        ' Create indexed line series and add values to them
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

        ' Create a title and add it to the Y axis
        Dim lTitle As New Title("Visitors (in millions)")
        lineSeries1.YAxis.Titles.Add(lTitle)

        ' Adding axis labels to the X axis
        lineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
        lineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
        lineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
        lineSeries1.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))

        ' Add the chart to the page
        page.Elements.Add(chart)
        ' Save the PDF
        document.Draw(Util.GetPath("Output/chart-seven-output.pdf"))
    End Sub


End Class


