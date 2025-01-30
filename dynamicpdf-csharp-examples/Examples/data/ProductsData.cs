using System.Collections.Generic;

public class ProductsData
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }

    private static List<Product> products   =   new List<Product>()
        {
            new Product { ProductID  =  17, ProductName  =  "Alice Mutton", QuantityPerUnit = "20 - 1 kg tins", UnitPrice = 39m, Discontinued = true },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", QuantityPerUnit = "12 - 550 ml bottles", UnitPrice = 10m, Discontinued = false },
            new Product { ProductID = 40, ProductName = "Boston Crab Meat", QuantityPerUnit = "24 - 4 oz tins", UnitPrice = 18.4m, Discontinued = false },
            new Product { ProductID = 60, ProductName = "Camembert Pierrot", QuantityPerUnit = "15 - 300 g rounds", UnitPrice = 34m, Discontinued = false },
            new Product { ProductID = 18, ProductName = "Carnarvon Tigers", QuantityPerUnit = "16 kg pkg.", UnitPrice = 62.5m, Discontinued = false },
            new Product { ProductID = 1, ProductName = "Chai", QuantityPerUnit = "10 boxes x 20 bags", UnitPrice = 18m, Discontinued = false },
            new Product { ProductID = 2, ProductName = "Chang", QuantityPerUnit = "24 - 12 oz bottles", UnitPrice = 19m, Discontinued = false },
            new Product { ProductID = 39, ProductName = "Chartreuse verte", QuantityPerUnit = "750 cc per bottle", UnitPrice = 18m, Discontinued = false },
            new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", QuantityPerUnit = "48 - 6 oz jars", UnitPrice = 22m, Discontinued = false },
            new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", QuantityPerUnit = "36 boxes", UnitPrice = 21.35m, Discontinued = true },
            new Product { ProductID = 48, ProductName = "Chocolade", QuantityPerUnit = "10 pkgs.", UnitPrice = 12.75m, Discontinued = false },
            new Product { ProductID = 38, ProductName = "Côte de Blaye", QuantityPerUnit = "12 - 75 cl bottles", UnitPrice = 263.5m, Discontinued = false },
            new Product { ProductID = 58, ProductName = "Escargots de Bourgogne", QuantityPerUnit = "24 pieces", UnitPrice = 13.25m, Discontinued = false },
            new Product { ProductID = 52, ProductName = "Filo Mix", QuantityPerUnit = "16 - 2 kg boxes", UnitPrice = 7m, Discontinued = false },
            new Product { ProductID = 71, ProductName = "Flotemysost", QuantityPerUnit = "10 - 500 g pkgs.", UnitPrice = 21.5m, Discontinued = false },
            new Product { ProductID = 33, ProductName = "Geitost", QuantityPerUnit = "500 g", UnitPrice = 2.5m, Discontinued = false },
            new Product { ProductID = 15, ProductName = "Genen Shouyu", QuantityPerUnit = "24 - 250 ml bottles", UnitPrice = 15.5m, Discontinued = false },
            new Product { ProductID = 56, ProductName = "Gnocchi di nonna Alice", QuantityPerUnit = "24 - 250 g pkgs.", UnitPrice = 38m, Discontinued = false },
            new Product { ProductID = 31, ProductName = "Gorgonzola Telino", QuantityPerUnit = "12 - 100 g pkgs", UnitPrice = 12.5m, Discontinued = false },
            new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", QuantityPerUnit = "12 - 8 oz jars", UnitPrice = 25m, Discontinued = false },
            new Product { ProductID = 37, ProductName = "Gravad lax", QuantityPerUnit = "12 - 500 g pkgs.", UnitPrice = 26m, Discontinued = false },
            new Product { ProductID = 24, ProductName = "Guaraná Fantástica", QuantityPerUnit = "12 - 355 ml cans", UnitPrice = 4.5m, Discontinued = true },
            new Product { ProductID = 69, ProductName = "Gudbrandsdalsost", QuantityPerUnit = "10 kg pkg.", UnitPrice = 36m, Discontinued = false },
            new Product { ProductID = 44, ProductName = "Gula Malacca", QuantityPerUnit = "20 - 2 kg bags", UnitPrice = 19.45m, Discontinued = false },
            new Product { ProductID = 26, ProductName = "Gumbär Gummibärchen", QuantityPerUnit = "100 - 250 g bags", UnitPrice = 31.23m, Discontinued = false },
            new Product { ProductID = 22, ProductName = "Gustaf's Knäckebröd", QuantityPerUnit = "24 - 500 g pkgs.", UnitPrice = 21m, Discontinued = false },
            new Product { ProductID = 10, ProductName = "Ikura", QuantityPerUnit = "12 - 200 ml jars", UnitPrice = 31m, Discontinued = false },
            new Product { ProductID = 36, ProductName = "Inlagd Sill", QuantityPerUnit = "24 - 250 g  jars", UnitPrice = 19m, Discontinued = false },
            new Product { ProductID = 43, ProductName = "Ipoh Coffee", QuantityPerUnit = "16 - 500 g tins", UnitPrice = 46m, Discontinued = false },
            new Product { ProductID = 41, ProductName = "Jack's New England Clam Chowder", QuantityPerUnit = "12 - 12 oz cans", UnitPrice = 9.65m, Discontinued = false },
            new Product { ProductID = 13, ProductName = "Konbu", QuantityPerUnit = "2 kg box", UnitPrice = 6m, Discontinued = false },
            new Product { ProductID = 76, ProductName = "Lakkalikööri", QuantityPerUnit = "500 ml", UnitPrice = 18m, Discontinued = false },
            new Product { ProductID = 67, ProductName = "Laughing Lumberjack Lager", QuantityPerUnit = "24 - 12 oz bottles", UnitPrice = 14m, Discontinued = false },
            new Product { ProductID = 74, ProductName = "Longlife Tofu", QuantityPerUnit = "5 kg pkg.", UnitPrice = 10m, Discontinued = false },
            new Product { ProductID = 65, ProductName = "Louisiana Fiery Hot Pepper Sauce", QuantityPerUnit = "32 - 8 oz bottles", UnitPrice = 21.05m, Discontinued = false },
            new Product { ProductID = 66, ProductName = "Louisiana Hot Spiced Okra", QuantityPerUnit = "24 - 8 oz jars", UnitPrice = 17m, Discontinued = false },
            new Product { ProductID = 51, ProductName = "Manjimup Dried Apples", QuantityPerUnit = "50 - 300 g pkgs.", UnitPrice = 53m, Discontinued = false },
            new Product { ProductID = 32, ProductName = "Mascarpone Fabioli", QuantityPerUnit = "24 - 200 g pkgs.", UnitPrice = 32m, Discontinued = false },
            new Product { ProductID = 49, ProductName = "Maxilaku", QuantityPerUnit = "24 - 50 g pkgs.", UnitPrice = 20m, Discontinued = false },
            new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", QuantityPerUnit = "18 - 500 g pkgs.", UnitPrice = 97m, Discontinued = true },
            new Product { ProductID = 72, ProductName = "Mozzarella di Giovanni", QuantityPerUnit = "24 - 200 g pkgs.", UnitPrice = 34.8m, Discontinued = false },
            new Product { ProductID = 30, ProductName = "Nord-Ost Matjeshering", QuantityPerUnit = "10 - 200 g glasses", UnitPrice = 25.89m, Discontinued = false },
            new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", QuantityPerUnit = "12 - 12 oz jars", UnitPrice = 40m, Discontinued = false },
            new Product { ProductID = 25, ProductName = "NuNuCa Nuß-Nougat-Creme", QuantityPerUnit = "20 - 450 g glasses", UnitPrice = 14m, Discontinued = false },
            new Product { ProductID = 77, ProductName = "Original Frankfurter grüne Soße", QuantityPerUnit = "12 boxes", UnitPrice = 13m, Discontinued = false },
            new Product { ProductID = 70, ProductName = "Outback Lager", QuantityPerUnit = "24 - 355 ml bottles", UnitPrice = 15m, Discontinued = false },
            new Product { ProductID = 55, ProductName = "Pâté chinois", QuantityPerUnit = "24 boxes x 2 pies", UnitPrice = 24m, Discontinued = false },
            new Product { ProductID = 16, ProductName = "Pavlova", QuantityPerUnit = "32 - 500 g boxes", UnitPrice = 17.45m, Discontinued = false },
            new Product { ProductID = 53, ProductName = "Perth Pasties", QuantityPerUnit = "48 pieces", UnitPrice = 32.8m, Discontinued = true },
            new Product { ProductID = 11, ProductName = "Queso Cabrales", QuantityPerUnit = "1 kg pkg.", UnitPrice = 21m, Discontinued = false },
            new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", QuantityPerUnit = "10 - 500 g pkgs.", UnitPrice = 38m, Discontinued = false },
            new Product { ProductID = 59, ProductName = "Raclette Courdavault", QuantityPerUnit = "5 kg pkg.", UnitPrice = 55m, Discontinued = false },
            new Product { ProductID = 57, ProductName = "Ravioli Angelo", QuantityPerUnit = "24 - 250 g pkgs.", UnitPrice = 19.5m, Discontinued = false },
            new Product { ProductID = 75, ProductName = "Rhönbräu Klosterbier", QuantityPerUnit = "24 - 0.5 l bottles", UnitPrice = 7.75m, Discontinued = false },
            new Product { ProductID = 73, ProductName = "Röd Kaviar", QuantityPerUnit = "24 - 150 g jars", UnitPrice = 15m, Discontinued = false },
            new Product { ProductID = 45, ProductName = "Rogede sild", QuantityPerUnit = "1k pkg.", UnitPrice = 9.5m, Discontinued = false },
            new Product { ProductID = 28, ProductName = "Rössle Sauerkraut", QuantityPerUnit = "25 - 825 g cans", UnitPrice = 45.6m, Discontinued = true },
            new Product { ProductID = 34, ProductName = "Sasquatch Ale", QuantityPerUnit = "24 - 12 oz bottles", UnitPrice = 14m, Discontinued = false },
            new Product { ProductID = 27, ProductName = "Schoggi Schokolade", QuantityPerUnit = "100 - 100 g pieces", UnitPrice = 43.9m, Discontinued = false },
            new Product { ProductID = 68, ProductName = "Scottish Longbreads", QuantityPerUnit = "10 boxes x 8 pieces", UnitPrice = 12.5m, Discontinued = false },
            new Product { ProductID = 42, ProductName = "Singaporean Hokkien Fried Mee", QuantityPerUnit = "32 - 1 kg pkgs.", UnitPrice = 14m, Discontinued = true },
            new Product { ProductID = 20, ProductName = "Sir Rodney's Marmalade", QuantityPerUnit = "30 gift boxes", UnitPrice = 81m, Discontinued = false },
            new Product { ProductID = 21, ProductName = "Sir Rodney's Scones", QuantityPerUnit = "24 pkgs. x 4 pieces", UnitPrice = 10m, Discontinued = false },
            new Product { ProductID = 61, ProductName = "Sirop d'érable", QuantityPerUnit = "24 - 500 ml bottles", UnitPrice = 28.5m, Discontinued = false },
            new Product { ProductID = 46, ProductName = "Spegesild", QuantityPerUnit = "4 - 450 g glasses", UnitPrice = 12m, Discontinued = false },
            new Product { ProductID = 35, ProductName = "Steeleye Stout", QuantityPerUnit = "24 - 12 oz bottles", UnitPrice = 18m, Discontinued = false },
            new Product { ProductID = 62, ProductName = "Tarte au sucre", QuantityPerUnit = "48 pies", UnitPrice = 49.3m, Discontinued = false },
            new Product { ProductID = 19, ProductName = "Teatime Chocolate Biscuits", QuantityPerUnit = "10 boxes x 12 pieces", UnitPrice = 9.2m, Discontinued = false },
            new Product { ProductID = 29, ProductName = "Thüringer Rostbratwurst", QuantityPerUnit = "50 bags x 30 sausgs.", UnitPrice = 123.79m, Discontinued = true },
            new Product { ProductID = 14, ProductName = "Tofu", QuantityPerUnit = "40 - 100 g pkgs.", UnitPrice = 23.25m, Discontinued = false },
            new Product { ProductID = 54, ProductName = "Tourtière", QuantityPerUnit = "16 pies", UnitPrice = 7.45m, Discontinued = false },
            new Product { ProductID = 23, ProductName = "Tunnbröd", QuantityPerUnit = "12 - 250 g pkgs.", UnitPrice = 9m, Discontinued = false },
            new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", QuantityPerUnit = "12 - 1 lb pkgs.", UnitPrice = 30m, Discontinued = false },
            new Product { ProductID = 50, ProductName = "Valkoinen suklaa", QuantityPerUnit = "12 - 100 g bars", UnitPrice = 16.25m, Discontinued = false },
            new Product { ProductID = 63, ProductName = "Vegie-spread", QuantityPerUnit = "15 - 625 g jars", UnitPrice = 43.9m, Discontinued = false },
            new Product { ProductID = 64, ProductName = "Wimmers gute Semmelknödel", QuantityPerUnit = "20 bags x 4 pieces", UnitPrice = 33.25m, Discontinued = false },
            new Product { ProductID = 47, ProductName = "Zaanse koeken", QuantityPerUnit = "10 - 4 oz boxes", UnitPrice = 9.5m, Discontinued = false }
        };

    public static List<Product> Products
    {
        get { return products; }
    }
}