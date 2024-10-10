
Imports dynamicpdf_vbnet_examples.DynamicPDFCoreSuite.Examples

Module Program
    Sub Main(args As String())

        Console.WriteLine(AppContext.BaseDirectory)

        Util.CreateOutput()

        PieChartsExample.Run()
        GridLinesExample.Run()
        CreatePDF.Run()
        PagesExample.Run()
        TemplateExample.Run()
        EvenOddTemplateExample.Run()
        StampTemplateExample.Run()
        HeaderFooterTemplateExample.Run()
        DocumentSectioningExample.Run()
        HtmlLayoutExample.Run()
        FormattedTextAreaExample.Run()
        HtmlAreaExample.Run()
        ListsExample.Run()
        ListContinuationExample.Run()
        TextContinuationExample.Run()
        TableExample.Run()
        TableContinuationExample.Run()
        BarChartsExample.Run()
        ChartLegendsExample.Run()
        ChartTwoDiffPlotAreasExample.Run()

    End Sub
End Module
