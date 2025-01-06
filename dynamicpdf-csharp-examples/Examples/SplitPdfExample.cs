using ceTe.DynamicPDF.Merger;

namespace DynamicPDFCoreSuite.Examples
{
    class SplitPdfExample
    {
        public static void Run()
        {
            PdfDocument pdf = new PdfDocument(Util.GetPath("Resources/PDFs/TimeMachine.pdf"));

            MergeDocument part1 = new MergeDocument(pdf, 1, 4);
            part1.Draw(Util.GetPath("Output/TimeMachinePart1.pdf"));

            MergeDocument part2 = new MergeDocument(pdf, 5, 8);
            part2.Draw(Util.GetPath("Output/TimeMachinePart2.pdf"));
        }

    }
}
