
Imports dynamicpdf_vbnet_examples.DynamicPDFCoreSuite.Examples

Module Program
    Sub Main(args As String())

        Console.WriteLine(AppContext.BaseDirectory)

        Util.CreateOutput()

        PieChartsExample.Run()
        GridLinesExample.Run()

    End Sub





End Module
