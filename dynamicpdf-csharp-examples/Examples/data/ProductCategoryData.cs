using DynamicPDFCoreSuite.Examples;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

    class ProductCategoryData
    {
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public bool Discontinued { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class ProductCategory
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Root
    {
        public List<ProductCategory> ProductsByCategory { get; set; }
    }

    public static List<ProductCategory> GetProductCategoryObjects()
    {
        string jsonFilePath = Util.GetPath("Resources/Data/subreport.json");
        string jsonData = File.ReadAllText(jsonFilePath);
        var productData = JsonConvert.DeserializeObject<ProductCategoryData.Root>(jsonData);
        //DisplayParseData(productData);
        return productData.ProductsByCategory;

    }

    private static void DisplayParseData(Root productData)
    {
        foreach (var category in productData.ProductsByCategory)
        {
            Console.WriteLine($"Category: {category.Name}");
            foreach (var product in category.Products)
            {
                Console.WriteLine($" - {product.ProductName}, Price: ${product.UnitPrice}");
            }
        }

    }
}