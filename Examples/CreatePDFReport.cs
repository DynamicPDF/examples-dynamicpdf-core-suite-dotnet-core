using System.IO;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

using Newtonsoft.Json;

namespace DynamicPDFCoreSuite.Examples
{
    class CreatePDFReport
    {
        public static void Run()
        {
            var jsonData = JsonConvert.DeserializeObject(File.ReadAllText(Util.GetPath("Resources/Data/SimpleReportData.json")));
            
            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/SimpleReportWithCoverPageFromJSON.dlex"));

            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("ReportCreatedFor", "Alex Smith");
            layoutData.Add("Products", jsonData);

            Document document = layoutReport.Layout(layoutData);
            document.Draw(Util.GetPath("Output/SimpleReportWithCoverPageFromJSON.pdf"));
        }
    }
}
