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

            // Output files are saved to the Output folder
        }
    }
}
