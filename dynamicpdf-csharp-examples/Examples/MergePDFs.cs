using ceTe.DynamicPDF.Merger;
using System.IO;

namespace DynamicPDFCoreSuite.Examples
{
    class MergePDFs
    {
        public static void Run()
        {
            MergePDF();
            AppendPDF();
            MergeOption();
            MergeFromStream();
            MergeFromByteArray();
        }

        public static void MergePDF()
        {
            MergeDocument document = MergeDocument.Merge(Util.GetPath("Resources/PDFs/DocumentA.pdf"), Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            document.Draw(Util.GetPath("Output/merge-output.pdf"));
        }

        public static void AppendPDF()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            document.Append(Util.GetPath("Resources/PDFs/DocumentC.pdf"));
            document.Draw(Util.GetPath("Output/append-pdf-output.pdf"));
        }

        public static void MergeFromStream()
        {
            Stream streamA = File.OpenRead(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            Stream streamB = File.OpenRead(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            Stream streamC = File.OpenRead(Util.GetPath("Resources/PDFs/DocumentC.pdf"));
            MergeDocument document = new MergeDocument(new PdfDocument(streamA));
            document.Append(new PdfDocument(streamB), 1, 2);
            document.Append(new PdfDocument(streamC));
            document.Draw(Util.GetPath("Output/stream-pdf-output.pdf"));
        }

        public static void MergeFromByteArray()
        {
            byte[] dataA = File.ReadAllBytes(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            byte[] dataB = File.ReadAllBytes(Util.GetPath("Resources/PDFs/DocumentB.pdf"));
            byte[] dataC = File.ReadAllBytes(Util.GetPath("Resources/PDFs/DocumentC.pdf"));

            MergeDocument document = new MergeDocument(new PdfDocument(dataA));
            document.Append(new PdfDocument(dataB), 1, 2);
            document.Append(new PdfDocument(dataC));
            document.Draw(Util.GetPath("Output/byte-pdf-output.pdf"));
        }


        public static void MergeOption()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));
            MergeOptions options = MergeOptions.Append;
            options.Outlines = false;
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"), options);
            document.Append(Util.GetPath("Resources/PDFs/DocumentC.pdf"));
            document.Draw(Util.GetPath("Output/merge-options-output.pdf"));
        }
    }
}
