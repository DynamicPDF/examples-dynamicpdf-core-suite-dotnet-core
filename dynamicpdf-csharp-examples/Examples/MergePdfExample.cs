using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;
using DynamicPDFCoreSuite.Utility;
using System.IO;

namespace DynamicPDFCoreSuite.Examples
{
    class MergePdfExample
    {
        public static void Run()
        {
            MergePDF();
            AppendPDF();
            MergeOption();
            MergeOptionStatic();
            MergeOptionStaticTwo();
            MergeFromStream();
            MergeFromByteArray();
            MergeToDocument();
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
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"), MergeOptions.All);
            MergeOptions options = new();
            options.Outlines = false;
            options.LogicalStructure = false;
            options.EmbeddedFiles = false;
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"), options);
            document.Append(Util.GetPath("Resources/PDFs/outline-example.pdf"));
            document.Draw(Util.GetPath("Output/merge-options-output.pdf"));
        }

        public static void MergeOptionStaticTwo()
        {
            MergeDocument document = MergeDocument.Merge(Util.GetPath("Resources/PDFs/DocumentB.pdf"), MergeOptions.None, Util.GetPath("Resources/PDFs/outline-example.pdf"), MergeOptions.None);
            document.Draw(Util.GetPath("Output/merge-options-static-two-output.pdf"));
        }

        public static void MergeOptionStatic()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"), MergeOptions.None);
            document.Append(Util.GetPath("Resources/PDFs/DocumentB.pdf"), MergeOptions.None);
            document.Append(Util.GetPath("Resources/PDFs/outline-example.pdf"), MergeOptions.All);
            document.Draw(Util.GetPath("Output/merge-options-static-output.pdf"));
        }

        public static void MergeToDocument()
        {
            Document document = new();
            PdfDocument pdfDoc = new PdfDocument(Util.GetPath("Resources/PDFs/DocumentA.pdf"));

            Page page = new Page(PageSize.Letter);
            Label lbl = new Label("New PDF Document, Multiple Pages", 0, 400, 400, 100);
            lbl.FontSize = 24;
            lbl.TextColor = RgbColor.Navy;
            page.Elements.Add(lbl);
            document.Pages.Add(page);

            TextArea textArea = new(TextGenerator.GenerateLargeTextDoc(), 0, 0, 512, 692,
                Font.Helvetica, 14);

            do
            {
                Page pageN = new Page();
                pageN.Elements.Add(textArea);
                document.Pages.Add(pageN);
                textArea = textArea.GetOverflowTextArea();

            } while (textArea != null);


            MergeDocument mergeDoc = MergeDocument.Merge(new PdfDocument(document.Draw()), pdfDoc);

            mergeDoc.Draw(Util.GetPath("Output/doc-new-exist-merge-output.pdf"));

        }


    }
}
