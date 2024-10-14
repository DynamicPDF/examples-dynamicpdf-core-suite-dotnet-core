

using ceTe.DynamicPDF;

namespace DynamicPDFCoreSuite.Examples
{
    class DiskBufferingExample
    {

        public static void Run()
        {
            Document document = new Document();
            document.Pages.Add(new Page());
            DiskBufferingOptions options = new DiskBufferingOptions();
            options.Location = @"PhysicalTempFilePath";
            document.DiskBuffering = options;
            document.Draw(Util.GetPath("Output/diskbuffering-output.pdf"));
        }

    }
}
