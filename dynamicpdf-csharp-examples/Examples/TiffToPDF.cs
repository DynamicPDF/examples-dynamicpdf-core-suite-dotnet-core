using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;

namespace DynamicPDFCoreSuite.Examples
{
    class TiffToPDF
    {
        public static void Run()
        {
            TiffFile tiffFile = new TiffFile(Util.GetPath("Resources/Images/fw9_18.tif"));
            Document document = tiffFile.GetDocument();
            document.Draw(Util.GetPath("Output/TiffToPDF.pdf"));
        }
    }
}
