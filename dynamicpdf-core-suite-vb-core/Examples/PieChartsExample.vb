Imports System.IO
Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.Charting
Imports ceTe.DynamicPDF.PageElements.Charting.Series

Public Class PieChartsExample

    Public Shared Sub Run()

        Dim outputPath As String
        outputPath = Util.GetPath("Output/pie-chart-output.pdf")

        ' Create a PDF Document
        Dim MyDocument As New Document()

        ' Create a Page and add it to the MyDocument
        Dim MyPage As New Page(PageSize.A4, PageOrientation.Landscape)
        MyDocument.Pages.Add(MyPage)

        ' Create a MyChart
        Dim MyChart = New Chart(0, 0, 700, 400)
        ' Add a plot area to the MyChart
        Dim MyPlotArea As PlotArea = MyChart.PlotAreas.Add(50, 50, 300, 300)

        ' Create the Header titles and add it to the MyChart
        Dim MytTitle As New Title("Website Viewers (in millions)")
        Dim MytTitle1 As New Title("Year 2007")
        MyChart.HeaderTitles.Add(MytTitle)
        MyChart.HeaderTitles.Add(MytTitle1)

        ' Create autogradient colors 
        Dim MyAutogradient1 As AutoGradient = New AutoGradient(90.0F, CmykColor.Red, CmykColor.IndianRed)
        Dim MyAutogradient2 As AutoGradient = New AutoGradient(90.0F, CmykColor.Green, CmykColor.YellowGreen)
        Dim MyAutogradient3 As AutoGradient = New AutoGradient(90.0F, CmykColor.Blue, CmykColor.LightBlue)

        ' Create a scalar datalabel
        Dim Myda As ScalarDataLabel = New ScalarDataLabel(True, False, False)
        ' Create a pie series 
        Dim MyPieSeries As New PieSeries()
        ' Set scalar datalabel to the pie series
        MyPieSeries.DataLabel = Myda
        ' Add series to the plot area
        MyPlotArea.Series.Add(MyPieSeries)

        'Add pie series elements to the pie series
        MyPieSeries.Elements.Add(27, "Website A")
        MyPieSeries.Elements.Add(19, "Website B")
        MyPieSeries.Elements.Add(21, "Website C")

        ' Assign autogradient colors to series elements
        MyPieSeries.Elements(0).Color = MyAutogradient1
        MyPieSeries.Elements(1).Color = MyAutogradient2
        MyPieSeries.Elements(2).Color = MyAutogradient3

        ' Add the MyChart to the MyPage
        MyPage.Elements.Add(MyChart)
        ' Save the pdf
        MyDocument.Draw(outputPath)
    End Sub


End Class
