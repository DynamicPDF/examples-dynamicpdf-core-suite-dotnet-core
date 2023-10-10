using ceTe.DynamicPDF.Conversion;

namespace DynamicPDFCoreSuite.Examples
{
    class PowerpointToPdfExample
    {
        public static void Run()
        {
            Converter.Convert(Util.GetPath("Resources/Data/simple.pptx"), Util.GetPath("Output/powerpoint-output.pdf"));
        }
    }
}
