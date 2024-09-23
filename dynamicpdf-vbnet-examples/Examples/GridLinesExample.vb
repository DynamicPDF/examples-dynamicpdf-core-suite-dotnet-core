Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Axes
Imports ceTe.DynamicPDF.PageElements.Charting.Series

Namespace DynamicPDFCoreSuite.Examples
    Public Class GridLinesExample
        Public Shared Sub Run()
            Dim outputPath As String = Util.GetPath("Output/gridlines-output.pdf")

            Dim document As New Document()
            document.Pages.Add(New Page(PageSize.Letter, PageOrientation.Landscape))

            Dim chart As New Chart(0, 0, 500, 500)

            Dim ls As New IndexedLineSeries("Website A")
            ls.Values.Add(New Single() {48, 83, 19, 23})
            Dim ls2 As New IndexedLineSeries("Website B")
            ls2.Values.Add(New Single() {52, 74, 9, 21})
            Dim ls3 As New IndexedLineSeries("Website C")
            ls3.Values.Add(New Single() {15, 43, 12, 8})

            chart.PrimaryPlotArea.Series.Add(ls)
            chart.PrimaryPlotArea.Series.Add(ls2)
            chart.PrimaryPlotArea.Series.Add(ls3)

            Dim title As New Title("Page Views")
            ls.YAxis.Titles.Add(title)

            ls.XAxis.Labels.Add(New IndexedXAxisLabel("Home", 0))
            ls.XAxis.Labels.Add(New IndexedXAxisLabel("Examples", 1))
            ls.XAxis.Labels.Add(New IndexedXAxisLabel("About", 2))
            ls.XAxis.Labels.Add(New IndexedXAxisLabel("Ordering", 3))

            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorGridLines = New XAxisGridLines()
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MinorGridLines = New XAxisGridLines()
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorGridLines = New YAxisGridLines()

            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorTickMarks = New YAxisTickMarks()
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MinorTickMarks = New YAxisTickMarks()

            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorTickMarks = New XAxisTickMarks()

            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorGridLines.Color = RgbColor.Navy
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorGridLines.LineStyle = LineStyle.DashLarge
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MinorGridLines.LineStyle = LineStyle.DashSmall
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MinorGridLines.Color = RgbColor.LightBlue

            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorGridLines.LineStyle = LineStyle.Solid
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorGridLines.Color = RgbColor.LightGrey

            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MajorTickMarks.Color = RgbColor.LightGrey
            chart.PrimaryPlotArea.YAxes.DefaultNumericAxis.MinorTickMarks.Visible = False
            chart.PrimaryPlotArea.XAxes.DefaultIndexedAxis.MajorTickMarks.Visible = False

            Dim title2 As New Title("Page")
            ls.XAxis.Titles.Add(title2)

            ls.XAxis.Labels.Angle = 45
            ls.XAxis.LabelOffset = 5
            ls.XAxis.Labels.TextColor = RgbColor.Green
            ls.XAxis.Labels.FontSize = 8
            ls.XAxis.TitlePosition = XAxisTitlePosition.AboveXAxis
            ls.XAxis.Titles(0).TextColor = RgbColor.Navy

            document.Pages(0).Elements.Add(chart)

            document.Draw(outputPath)
        End Sub
    End Class
End Namespace

