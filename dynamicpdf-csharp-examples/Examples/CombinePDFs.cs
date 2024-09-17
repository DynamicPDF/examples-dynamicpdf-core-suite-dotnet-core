using ceTe.DynamicPDF.Merger;

namespace DynamicPDFCoreSuite.Examples
{
    class CombinePDFs
    {
        public static void Run()
        {
            CombinePDF();
            CombinePDFWithOptions();
        }

        public static void CombinePDF()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            document.Append(Util.GetPath("Resources/PDFs/DocumentC.pdf"), 1, 2);
            document.Draw(Util.GetPath("Output/CombinePDFs.pdf"));
        }

        public static void CombinePDFWithOptions()
        {
            MergeOptions options = MergeOptions.All;
            options.DocumentProperties = false;
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"), options);
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            document.Draw(Util.GetPath("Output/CombinePDFWithOptions.pdf"));
        }
    }
}
