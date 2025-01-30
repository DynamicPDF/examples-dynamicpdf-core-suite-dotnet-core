using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DynamicPDFCoreSuite.Examples
{
    public class GenerateReportExample
    {
        static string CONNECTION_STRING = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true";

        public static void Run()
        {
            GenerateUsingJson();
            GenerateUsingDataObjects();
            GenerateUsingLinqData();
            GenerateUsingDatabaseTable();
            GenerateUsingSql();
        }

        public static void GenerateUsingJson()
        {
            string data = File.ReadAllText(Util.GetPath("Resources/Data/report-with-cover-page.json"));
            var jsonData = JsonConvert.DeserializeObject(data);

            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"));

            LayoutData layoutData = new LayoutData(jsonData);
            Document document = layoutReport.Layout(layoutData);
            document.Draw(Util.GetPath("Output/report-json-layout-data-output.pdf"));
        }

        public static void GenerateUsingDataObjects()
        {
            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"));

            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("ReportCreatedFor", "Alex Smith");
            layoutData.Add("Products", ProductsData.Products);

            Document document = layoutReport.Layout(layoutData);
            document.Author = "DynamicPDF ReportWriter";
            document.Title = "Simple Report Example";
            document.Draw(Util.GetPath("Output/report-dataobject-layout-data-output.pdf"));
        }

        public static void GenerateUsingLinqData()
        {
            XElement root = XElement.Load(Util.GetPath("Resources/XML/ProductList.xml"));
            var products = root.Elements("Products")
                   .Select(p => new
                   {
                       ProductID = (int)p.Attribute("ProductID"),
                       ProductName = (string)p.Attribute("ProductName"),
                       QuantityPerUnit = (string)p.Attribute("QuantityPerUnit"),
                       UnitPrice = (decimal)p.Attribute("UnitPrice")
                   });

            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"));
            LayoutData layoutData = new LayoutData();
            layoutData.Add("ReportCreatedFor", "John Doe");
            layoutData.Add("Products", products);
            Document document = layoutReport.Layout(layoutData);
            document.Draw(Util.GetPath("Output/report-linq-layout-data-output.pdf"));
        }

        public static void GenerateUsingDatabaseTable()
        {
            string sql = "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM Products";

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"));
            NameValueLayoutData layoutData = new NameValueLayoutData();
            DataTableReportData data = new DataTableReportData(dataTable);
            layoutData.Add("ReportCreatedFor", "John Doe");
            layoutData.Add("Products", data);
            Document document = layoutReport.Layout(layoutData);
            document.Draw(Util.GetPath("Output/report-database-table-layout-data-output.pdf"));
        }

        public static void GenerateUsingSql()
        {
            string sql = "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM Products";
            Document document = null;
            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"));
            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("ReportCreatedFor", "John Doe");

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        layoutData.Add("Products", new DataReaderReportData(connection, reader));
                        document = layoutReport.Layout(layoutData);
                    }
                }
            }
            document.Draw(Util.GetPath("Output/report-query-layout-data-output.pdf"));
        }
    }
}
