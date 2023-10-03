using System;

namespace DynamicPDFCoreSuite
{
    class Program
    {
        static void Main(string[] args)
        {
            Examples.AcroFormFilling.Run();
            Examples.Actions.Run();
            Examples.CombinePDFs.Run();
            Examples.CreatePDF.Run();
            Examples.CreatePDFReport.Run();
            Examples.EncryptPDF.Run();
            Examples.MergePDFs.Run();
            Examples.PageNumbers.Run();
            Examples.PasswordProtectPDF.Run();
            Examples.SplitPDF.Run();
            Examples.TiffToPDF.Run();
            Examples.FontKerning.Run();
            Examples.XmpMetadataExample.Run();
            Examples.WatermarkExample.Run();
            Examples.TiffToPdfExample.Run();
            Examples.TextEncodingExample.Run();
            Examples.TextFormattingExample.Run();
            Examples.AddTemplateExample.Run();
            Examples.TaggedPdfExample.Run();
            Examples.ImageStampExample.Run();

            // Output files are saved to the Output folder
        }
    }
}
