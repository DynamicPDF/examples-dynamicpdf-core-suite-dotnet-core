Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Series

Namespace DynamicPDFCoreSuite.Examples
    Public Class PieChartsExample
        Public Shared Sub Run()
            SimplePlotAreaExample()
            SimplePlotAreaPercentageExample()
            ManualExample()
        End Sub

        Public Shared Sub SimplePlotAreaExample()
            Dim doc As New Document()
            doc.Pages.Add(New Page(PageSize.A4, PageOrientation.Landscape))

            Dim chart As New Chart(0, 0, 700, 400)

            Dim tTitle As New Title("Website Viewers (in millions)")
            Dim tTitle1 As New Title("Year 2007")
            chart.HeaderTitles.Add(tTitle)
            chart.HeaderTitles.Add(tTitle1)

            Dim da As New ScalarDataLabel(True, False, False)
            Dim pieSeries As New PieSeries()
            pieSeries.DataLabel = da
            chart.PrimaryPlotArea.Series.Add(pieSeries)

            pieSeries.Elements.Add(27, "Website A")
            pieSeries.Elements.Add(19, "Website B")
            pieSeries.Elements.Add(21, "Website C")

            pieSeries.Elements(0).Color = New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
            pieSeries.Elements(1).Color = New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
            pieSeries.Elements(2).Color = New AutoGradient(90.0F, CmykColor.Blue, CmykColor.LightBlue)

            doc.Pages(0).Elements.Add(chart)
            doc.Draw(Util.GetPath("Output/piechart-simple-output.pdf"))
        End Sub

        Public Shared Sub ManualExample()
            Dim outputPath As String = Util.GetPath("Output/piechart-manual-output.pdf")
            Dim document As New Document()
            document.Pages.Add(New Page())

            Dim chart As New Chart(0, 0, 500, 500)
            chart.BackgroundColor = RgbColor.LightBlue
            chart.AutoLayout = False

            Dim plotArea As PlotArea = chart.PlotAreas.Add(10, 100, 100, 100)
            plotArea.BackgroundColor = RgbColor.Tan
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

            chart.Layout()

            chart.Legends(0).X = 400
            chart.Legends(0).Y = 250

            document.Pages(0).Elements.Add(chart)
            document.Draw(outputPath)
        End Sub

        Public Shared Sub SimplePlotAreaPercentageExample()
            Dim doc As New Document()
            doc.Pages.Add(New Page(PageSize.A4, PageOrientation.Landscape))

            Dim chart As New Chart(0, 0, 700, 400)

            Dim tTitle As New Title("Website Viewers (in millions)")
            Dim tTitle1 As New Title("Year 2007")
            chart.HeaderTitles.Add(tTitle)
            chart.HeaderTitles.Add(tTitle1)

            Dim da As New ScalarDataLabel(True, True, True)
            Dim pieSeries As New PieSeries()
            pieSeries.DataLabel = da
            chart.PrimaryPlotArea.Series.Add(pieSeries)

            pieSeries.Elements.Add(27, "Website A")
            pieSeries.Elements.Add(19, "Website B")
            pieSeries.Elements.Add(21, "Website C")

            pieSeries.Elements(0).Color = New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
            pieSeries.Elements(1).Color = New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
            pieSeries.Elements(2).Color = New AutoGradient(90.0F, CmykColor.Blue, CmykColor.LightBlue)

            doc.Pages(0).Elements.Add(chart)
            doc.Draw(Util.GetPath("Output/piechart-simple-percentage-output.pdf"))
        End Sub
    End Class
End Namespace
