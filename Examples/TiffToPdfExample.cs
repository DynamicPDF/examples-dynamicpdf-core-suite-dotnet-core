using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Conversion;
using ceTe.DynamicPDF.Imaging;


namespace DynamicPDFCoreSuite.Examples
{
    class TiffToPdfExample
    {

        public static void Run()
        {
            ConvertExampleOne();
            ConvertExampleTwo();
        }

        public static void ConvertExampleOne()
        {
            TiffFile tiffFile = new TiffFile(Util.GetPath("Resources/Images/fw9_18.tif"));
            Document document = tiffFile.GetDocument();
            document.Draw(Util.GetPath("Output/convertExampleOne-pdf"));
        }

        // Convert a multipage TIFF image to a PDF document.
        // This code uses the DynamicPDF Converter for .NET product.
        // It used the following namespace from the ceTe.DynamicPDF.Converter.NET NuGet package:
        //  * ceTe.DynamicPDF.Conversion for the ImageConverter class

        public static void ConvertExampleTwo()
        {
            ImageConverter imageConverter = new ImageConverter(Util.GetPath("Resources/Images/fw9_18.tif"));
            imageConverter.Convert(Util.GetPath("Output/convertExampleTwo-pdf"));
        }

    }
}
