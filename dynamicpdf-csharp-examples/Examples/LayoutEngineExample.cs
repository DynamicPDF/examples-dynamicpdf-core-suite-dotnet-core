using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DynamicPDFCoreSuite.Examples
{
    class Category
    {
        public string Name;
        public List<Product> Products;
    }

    class Product
    {
        public int ProductID;
        public string ProductName;
        public string QuantityPerUnit;
        public Boolean Discontinued;
        public double UnitPrice;
    }


    class LayoutEngineExample
    {
        static string CONNECTION_STRING = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true";

        public static void Run()
        {

            string dlexString = Util.GetPath("Resources/DLEXs/subreport.dlex");
            string jsonString = Util.GetPath("Resources/Data/subreport.json");

            // four different ways to create report with subreport
            // 1. JSON document
            // 2. Obtain data from database and then convert to JSON
            // 3. Obtain data from database and programatically use data
            // 4. Obtain data from a name values

            JsonVersion(dlexString, jsonString);
            DatabaseVersionWithJson(dlexString);
            NameValuesExample(dlexString);

            //from documentation
            TopLevelDataExample();
        }

        // Create a PDF using DLEX and JSON document.

        static void JsonVersion(String dlexString, String jsonString)
        {

            DocumentLayout docLayout = new DocumentLayout(dlexString);
            LayoutData layoutData = new LayoutData(
                JsonConvert.DeserializeObject(
                    File.ReadAllText(jsonString)));
            Document document = docLayout.Layout(layoutData);
            document.Draw(Util.GetPath("Output/subreport_json_output.pdf"));
        }

        // Create a PDF using DLEX, obtain data from dtabase as JSON using "for json auto" clause

        static void DatabaseVersionWithJson(String dlexString)
        {

            string sql = "select CategoryName Name, ProductID, ProductName, QuantityPerUnit, Discontinued, UnitPrice "
                + "from Products, Categories as ProductsByCategory "
                + "where Products.CategoryID = ProductsByCategory.CategoryID " +
                "order by CategoryName for json auto, root('ProductsByCategory')";

            var jsonResult = new StringBuilder();

            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(
                                reader.GetValue(0).ToString());
                        }
                    }
                }
            }

            DocumentLayout docLayout = new DocumentLayout(dlexString);
            LayoutData layoutData = new LayoutData(JsonConvert.DeserializeObject(jsonResult.ToString()));
            Document document = docLayout.Layout(layoutData);
            document.Draw(Util.GetPath("Output/subreport_db_json_output.pdf"));
        }

        //Create a PDF using data from database and the ReportDataRequired event.

 

        //Create a PDF using data from data model.

        private static void NameValuesExample(String dlexString)
        {
            // Create the document's layout from a DLEX template
            DocumentLayout documentLayout = new DocumentLayout(dlexString);

            List<Category> productsByCategory = new List<Category>();
            Category a = new Category
            {
                Name = "Beverages",
                Products = new List<Product>() {
                new Product { ProductID = 1, ProductName = "Chai", QuantityPerUnit = "10 boxes x 20 bags", Discontinued = false, UnitPrice = 12.22},
                new Product { ProductID = 2, ProductName = "Chang", QuantityPerUnit = "5 boxes x 10 bags", Discontinued = true, UnitPrice = 9.99} }
            };

            Category b = new Category
            {
                Name = "Condiments",
                Products = new List<Product>() {
                new Product { ProductID = 3, ProductName = "Aniseed Syrup", QuantityPerUnit = "20 boxes x 2 bottles", Discontinued = true, UnitPrice = 3.92},
                new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", QuantityPerUnit = "10 boxes x 10 containers", Discontinued = false, UnitPrice = 3.23} }
            };

            productsByCategory.Add(a);
            productsByCategory.Add(b);

            LayoutData layoutData = new LayoutData();
            layoutData.Add("ProductsByCategory", productsByCategory);

            // Layout the document and save the PDF
            Document document = documentLayout.Layout(layoutData);
            document.Draw(Util.GetPath("Output/subreport_db_object_output.pdf"));
        }

        public static void TopLevelDataExample()
        {
            // Create the document's layout from a DLEX template
            DocumentLayout layoutReport = new DocumentLayout(Util.GetPath("Resources/DLEXs/FormFill.dlex"));

            // Specify the data.
            NameValueLayoutData layoutData = new NameValueLayoutData();
            W4Data w4Data = new W4Data
            {
                FirstNameAndI = "Alex B.",
                LastName = "Smith",
                SSN = "123-45-6789",
                HomeAddress = "456 Green Road",
                IsSingle = true,
                CityStateZip = "Somewhere, Earth  12345",
                Allowances = 2
            };

            layoutData.Add("W4Data", w4Data);

            // Layout the document and save the PDF
            Document document = layoutReport.Layout(layoutData);
            document.Author = "DynamicPDF ReportWriter";
            document.Title = "Form Fill Example";

            document.Draw(Util.GetPath("Output/toplevel-layoutdata.pdf"));
        }

    }
}
