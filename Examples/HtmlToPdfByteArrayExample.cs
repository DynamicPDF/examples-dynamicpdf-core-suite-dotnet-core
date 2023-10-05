
using ceTe.DynamicPDF.Conversion;
using System;
using System.IO;

namespace DynamicPDFCoreSuite.Examples
{

    class HtmlToPdfByteArrayExample
    {
        public static void Run()
        {
            byte[] pdfByteArray = Converter.Convert("https://www.google.com");
            File.WriteAllBytes(Util.GetPath("Output/html-byte-array-output.pdf"), pdfByteArray);
        }
    }
}
