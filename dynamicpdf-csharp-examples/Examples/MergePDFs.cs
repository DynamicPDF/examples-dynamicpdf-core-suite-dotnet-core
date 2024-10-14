using ceTe.DynamicPDF.Merger;

namespace DynamicPDFCoreSuite.Examples
{
    class MergePDFs
    {
        public static void Run()
        {
            MergePDF();
            AppendPDF();
            MergeOption();
        }

        public static void MergePDF()
        {
            MergeDocument document = MergeDocument.Merge(Util.GetPath("Resources/PDFs/DocumentA.pdf"), Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            document.Draw(Util.GetPath("Output/MergePDFs.pdf"));
        }

        public static void AppendPDF()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            document.Append(Util.GetPath("Resources/PDFs/DocumentC.pdf"));
            document.Draw(Util.GetPath("Output/AppendPDF.pdf"));
        }

        public static void MergeOption()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            MergeOptions options = MergeOptions.Append;
            options.Outlines = false;
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"), options);
            document.Append(Util.GetPath("Resources/PDFs/DocumentC.pdf"));
            document.Draw(Util.GetPath("Output/MergeOption.pdf"));
        }
    }
}
