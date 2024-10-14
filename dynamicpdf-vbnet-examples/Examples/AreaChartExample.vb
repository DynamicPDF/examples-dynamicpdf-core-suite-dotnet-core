Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Axes
Imports ceTe.DynamicPDF.PageElements.Charting.Series
Imports System

Namespace DynamicPDFCoreSuite.Examples
    Class AreaChartExample
        Public Shared Sub Run()
            Normal()
            Stacked()
            Stacked100()
            DateTimeNormal()
            DateTimeStacked()
        End Sub

        Public Shared Sub Normal()
            Dim outputPath As String = Util.GetPath("Output/areachart-simple-output.pdf")
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
            document.Draw(outputPath)
        End Sub

        Public Shared Sub Stacked()
            Dim outputPath As String = Util.GetPath("Output/areachart-stacked-output.pdf")
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 400, 230)
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            Dim seriesElement1 As New IndexedStackedAreaSeriesElement("Website A")
            seriesElement1.Values.Add(New Single() {5, 7, 9, 6})
            Dim seriesElement2 As New IndexedStackedAreaSeriesElement("Website B")
            seriesElement2.Values.Add(New Single() {4, 2, 5, 8})
            Dim seriesElement3 As New IndexedStackedAreaSeriesElement("Website C")
            seriesElement3.Values.Add(New Single() {2, 4, 6, 9})

            Dim autogradient1 As New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
            seriesElement1.Color = autogradient1
            Dim autogradient2 As New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
            seriesElement2.Color = autogradient2
            Dim autogradient3 As New AutoGradient(120.0F, CmykColor.Blue, CmykColor.LightBlue)
            seriesElement3.Color = autogradient3

            Dim areaSeries As New IndexedStackedAreaSeries()
            areaSeries.Add(seriesElement1)
            areaSeries.Add(seriesElement2)
            areaSeries.Add(seriesElement3)

            plotArea.Series.Add(areaSeries)

            Dim lTitle As New Title("Visitors (in millions)")
            areaSeries.YAxis.Titles.Add(lTitle)

            areaSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            areaSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            areaSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            areaSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))

            page.Elements.Add(chart)
            document.Draw(outputPath)
        End Sub

        Public Shared Sub Stacked100()
            Dim outputPath As String = Util.GetPath("Output/areachart-stacked-100-output.pdf")
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 400, 230)
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            Dim seriesElement1 As New Indexed100PercentStackedAreaSeriesElement("Website A")
            seriesElement1.Values.Add(New Single() {5, 7, 9, 6})
            Dim seriesElement2 As New Indexed100PercentStackedAreaSeriesElement("Website B")
            seriesElement2.Values.Add(New Single() {4, 2, 5, 8})
            Dim seriesElement3 As New Indexed100PercentStackedAreaSeriesElement("Website C")
            seriesElement3.Values.Add(New Single() {2, 4, 6, 9})

            Dim autogradient1 As New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
            seriesElement1.Color = autogradient1
            Dim autogradient2 As New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
            seriesElement2.Color = autogradient2
            Dim autogradient3 As New AutoGradient(120.0F, CmykColor.Blue, CmykColor.LightBlue)
            seriesElement3.Color = autogradient3

            Dim areaSeries As New Indexed100PercentStackedAreaSeries()
            areaSeries.Add(seriesElement1)
            areaSeries.Add(seriesElement2)
            areaSeries.Add(seriesElement3)

            plotArea.Series.Add(areaSeries)

            Dim lTitle As New Title("Visitors (in millions)")
            areaSeries.YAxis.Titles.Add(lTitle)

            areaSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q1", 0))
            areaSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q2", 1))
            areaSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q3", 2))
            areaSeries.XAxis.Labels.Add(New IndexedXAxisLabel("Q4", 3))

            page.Elements.Add(chart)
            document.Draw(outputPath)
        End Sub

        Public Shared Sub DateTimeNormal()
            Dim outputPath As String = Util.GetPath("Output/areachart-datetime-normal-output.pdf")
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 400, 200)
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            Dim p0 As New DateTime(2007, 1, 1)
            Dim p1 As New DateTime(2007, 2, 1)
            Dim p2 As New DateTime(2007, 3, 1)
            Dim p3 As New DateTime(2007, 4, 1)

            Dim areaSeries1 As New DateTimeAreaSeries("Website A")
            areaSeries1.Values.Add(5, p0)
            areaSeries1.Values.Add(7, p1)
            areaSeries1.Values.Add(9, p2)
            areaSeries1.Values.Add(6, p3)
            Dim areaSeries2 As New DateTimeAreaSeries("Website B")
            areaSeries2.Values.Add(4, p0)
            areaSeries2.Values.Add(2, p1)
            areaSeries2.Values.Add(5, p2)
            areaSeries2.Values.Add(8, p3)
            Dim areaSeries3 As New DateTimeAreaSeries("Website C")
            areaSeries3.Values.Add(2, p0)
            areaSeries3.Values.Add(4, p1)
            areaSeries3.Values.Add(6, p2)
            areaSeries3.Values.Add(9, p3)

            plotArea.Series.Add(areaSeries1)
            plotArea.Series.Add(areaSeries2)
            plotArea.Series.Add(areaSeries3)

            Dim title3 As New Title("Viewers (in millions)")
            areaSeries1.YAxis.Titles.Add(title3)

            areaSeries1.XAxis.LabelFormat = "MMM"

            page.Elements.Add(chart)
            document.Draw(outputPath)
        End Sub

        Public Shared Sub DateTimeStacked()
            Dim outputPath As String = Util.GetPath("Output/areachart-datetime-stacked-output.pdf")
            Dim document As New Document()
            Dim page As New Page()
            document.Pages.Add(page)

            Dim chart As New Chart(0, 0, 400, 200)
            Dim plotArea As PlotArea = chart.PrimaryPlotArea

            Dim title1 As New Title("Website Visitors")
            Dim title2 As New Title("Year - 2007")
            chart.HeaderTitles.Add(title1)
            chart.HeaderTitles.Add(title2)

            Dim seriesElement1 As New DateTimeStackedAreaSeriesElement("Website A")
            seriesElement1.Values.Add(5, New DateTime(2007, 1, 1))
            seriesElement1.Values.Add(7, New DateTime(2007, 2, 1))
            seriesElement1.Values.Add(9, New DateTime(2007, 3, 1))
            seriesElement1.Values.Add(6, New DateTime(2007, 4, 1))

            Dim seriesElement2 As New DateTimeStackedAreaSeriesElement("Website B")
            seriesElement2.Values.Add(4, New DateTime(2007, 1, 1))
            seriesElement2.Values.Add(2, New DateTime(2007, 2, 1))
            seriesElement2.Values.Add(5, New DateTime(2007, 3, 1))
            seriesElement2.Values.Add(8, New DateTime(2007, 4, 1))

            Dim seriesElement3 As New DateTimeStackedAreaSeriesElement("Website C")
            seriesElement3.Values.Add(2, New DateTime(2007, 1, 1))
            seriesElement3.Values.Add(4, New DateTime(2007, 2, 1))
            seriesElement3.Values.Add(6, New DateTime(2007, 3, 1))
            seriesElement3.Values.Add(9, New DateTime(2007, 4, 1))

            Dim areaSeries As New DateTimeStackedAreaSeries()
            areaSeries.Add(seriesElement1)
            areaSeries.Add(seriesElement2)
            areaSeries.Add(seriesElement3)

            plotArea.Series.Add(areaSeries)

            Dim title3 As New Title("Visitors (in millions)")
            areaSeries.YAxis.Titles.Add(title3)

            areaSeries.XAxis.LabelFormat = "MMM"

            page.Elements.Add(chart)
            document.Draw(outputPath)
        End Sub
    End Class
End Namespace

