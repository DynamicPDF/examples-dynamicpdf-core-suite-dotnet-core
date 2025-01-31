using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using static ProductCategoryData;

namespace DynamicPDFCoreSuite.Examples
{
    public class GenerateReportExample
    {
        static string CONNECTION_STRING = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true";

        public static void Run()
        {
            GenerateUsingDatabaseAndJson();
            GenerateUsingJson();
            GenerateSubReportUsingJson();
            GenerateUsingDataObjects();
            GenerateSubreportUsingDataObjects();
            GenerateUsingLinqData();
            GenerateUsingDatabaseTable();
            GenerateUsingSql();
            GenerateSubReportUsingSqlJson();
            GenerateSubReportUsingSqlEvent();
            GenerateTopLevelExample();
        }


        public static void GenerateUsingDatabaseAndJson()
        {
            string queryWithForJson = "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice FROM Products for json auto, root('Products')";
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                using (var cmd = new SqlCommand(queryWithForJson, conn))
                {
                    conn.Open();
                    var jsonResult = new StringBuilder();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(reader.GetValue(0).ToString());
                        }
                    }

                    var jsonData = JsonConvert.DeserializeObject(jsonResult.ToString());
                    DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/report-with-cover-page.dlex"));
                    LayoutData layoutData = new LayoutData(jsonData);
                    layoutData.Add("ReportCreatedFor", "John Doe");
                    Document document = layoutReport.Layout(layoutData);
                    document.Draw(Util.GetPath("Output/report-forjson-json-layout-data-output.pdf"));
                }
            }
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

        public static void GenerateSubReportUsingJson()
        {
            string data = File.ReadAllText(Util.GetPath("Resources/Data/subreport.json"));
            var jsonData = JsonConvert.DeserializeObject(data);

            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/subreport.dlex"));
            LayoutData layoutData = new LayoutData(jsonData);
            Document document = layoutReport.Layout(layoutData);
            document.Draw(Util.GetPath("Output/subreport-json-layout-data-output.pdf"));
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

        public static void GenerateSubreportUsingDataObjects()
        {
            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/subreport.dlex"));
            NameValueLayoutData layoutData = new NameValueLayoutData();
            List<ProductCategory> productCategoryData = ProductCategoryData.GetProductCategoryObjects();
            layoutData.Add("ProductsByCategory", productCategoryData);
            Document document = layoutReport.Layout(layoutData);
            document.Draw(Util.GetPath("Output/subreport-dataobject-layout-data-output.pdf"));
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

        public static void GenerateSubReportUsingSqlJson()
        {
            string queryWithForJson = "SELECT CategoryName as Name, ProductID,  ProductName, " + 
                "QuantityPerUnit, Discontinued, UnitPrice " +
                "FROM Categories, Products FOR JSON auto, root('ProductsByCategory')";
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                using (var cmd = new SqlCommand(queryWithForJson, conn))
                {
                    conn.Open();
                    var jsonResult = new StringBuilder();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(reader.GetValue(0).ToString());
                        }
                    }

                    var jsonData = JsonConvert.DeserializeObject(jsonResult.ToString());
                    DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/subreport.dlex"));
                    LayoutData layoutData = new LayoutData(jsonData);
                    Document document = layoutReport.Layout(layoutData);
                    document.Draw(Util.GetPath("Output/subreport-forjson-json-layout-data-output.pdf"));
                }
            }
        }

        public static void GenerateSubReportUsingSqlEvent()
        {

            DocumentLayout documentLayout = new DocumentLayout(Util.GetPath("Resources/DLEXs/subreport.dlex"));
            documentLayout.ReportDataRequired += DocumentLayout_ReportDataRequired;
            LayoutData layoutData = new LayoutData();
            Document document = documentLayout.Layout(layoutData);
            document.Draw(Util.GetPath("Output/subreport_db_sql_output.pdf"));
        }

        private static void DocumentLayout_ReportDataRequired(object sender, ReportDataRequiredEventArgs args)
        {

            if (args.ElementId == "ProductsByCategoryReport")
            {
                string sqlString =
                    "SELECT CategoryID, CategoryName Name " +
                    "FROM   Categories ";

                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                SqlCommand command = new SqlCommand(sqlString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                args.ReportData = new DataReaderReportData(connection, reader);
            }
            else if (args.ElementId == "ProductsByCategorySubReport")
            {
                string sqlString =
                    "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice, Discontinued " +
                    "FROM   Products " +
                    "WHERE  CategoryID = " + args.Data["CategoryID"] + " " +
                    "ORDER BY ProductName ";

                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                SqlCommand command = new SqlCommand(sqlString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                args.ReportData = new DataReaderReportData(connection, reader);
            }
        }

        public static void GenerateTopLevelExample()
        {

            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/form-fill.dlex"));
            LayoutData layoutData = new LayoutData();
            layoutData.Add("FirstNameAndI", "Alex B.");
            layoutData.Add("LastName", "Smith");
            layoutData.Add("SSN", "123-45-6789");
            layoutData.Add("HomeAddress", "456 Green Road");
            layoutData.Add("CityStateZip", "Somewhere, Earth  12345");
            layoutData.Add("Allowances", "2");
            layoutData.Add("IsSingle", true);

            Document document = layoutReport.Layout(layoutData);
            document.Author = "DynamicPDF ReportWriter";
            document.Title = "Form Fill Example";

            document.Draw(Util.GetPath("Output/toplevel-noobject-layoutdata.pdf"));
        }
    }
}
