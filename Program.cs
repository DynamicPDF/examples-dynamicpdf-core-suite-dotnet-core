using System;

namespace DynamicPDFCoreSuite
{
    class Program
    {
        static void Main(string[] args)
        {
            Examples.RetrievingFormFieldsExample.Run();
            Examples.FontsExample.Run();
            Examples.DigitalSignatureExample.Run();
            Examples.CertificateExample.Run();
            Examples.AddSignatureExample.Run();
            Examples.HtmlToPdf.Run();
            Examples.FormFlatteningExample.Run();
            Examples.GenerateReportExample.Run();
            Examples.ReadFormFieldsExample.Run();
            Examples.FormFieldsReadOnly.Run();

            Examples.AcroFormFilling.Run();
            Examples.Actions.Run();
            Examples.CombinePDFs.Run();
            Examples.CreatePDF.Run();
            Examples.EncryptPDF.Run();
            Examples.MergePDFs.Run();
            Examples.PageNumbers.Run();
            Examples.PasswordProtectPDF.Run();
            Examples.SplitPDF.Run();
            Examples.TiffToPDF.Run();
            Examples.FontKerning.Run();
            Examples.XmpMetadataExample.Run();
            Examples.WatermarkExample.Run();
            Examples.TextEncodingExample.Run();
            Examples.TextFormattingExample.Run();
            Examples.AddTemplateExample.Run();
            Examples.TaggedPdfExample.Run();
            Examples.ImageStampExample.Run();
            Examples.AddShapeExample.Run();
            Examples.SectionsExample.Run();
            Examples.ReaderEventExample.Run();
            Examples.PdfXCompatibleExample.Run();
            //Examples.PdfACompatibleExample.Run();
            Examples.PackagePdfExample.Run();
            Examples.AddNewContentExample.Run();
            Examples.ListsExample.Run();
            Examples.PageLinkExample.Run();
            Examples.LayoutGridExample.Run();
            Examples.JavascriptActionExample.Run();
            Examples.HtmlAreaExample.Run();
            Examples.GroupingExample.Run();
            Examples.DiskBufferingExample.Run();
            Examples.ChartsExample.Run();
            Examples.BookmarkOutlineExample.Run();
            Examples.AnnotationsExample.Run();
            Examples.AddImageExample.Run();
            Examples.AddFormFieldsExample.Run();
            Examples.BarcodeExample.Run();


            // Output files are saved to the Output folder
        }
    }
}
