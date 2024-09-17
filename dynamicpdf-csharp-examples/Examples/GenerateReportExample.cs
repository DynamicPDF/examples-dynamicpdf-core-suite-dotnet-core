

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using Newtonsoft.Json;
using System.IO;

namespace DynamicPDFCoreSuite.Examples
{
    class GenerateReportExample
    {

        public static void Run()
        {
            string data = File.ReadAllText(Util.GetPath("Resources/Data/SimpleReportWithCoverPage.json"));
            var jsonData = JsonConvert.DeserializeObject(data);

            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/SimpleReportWithCoverPage.dlex"));

            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("ReportCreatedFor", "Alex Smith");
            layoutData.Add("Products", jsonData);

            Document document = layoutReport.Layout(layoutData);
            document.Draw(Util.GetPath("Output/report-output-example.pdf"));
        }

    }
}
