using System.Collections;
using System.Collections.Generic;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public bool Discontinued { get; set; }
}

public class Products : IEnumerable<Product>
{
    private List<Product> values = theProducts;

    public void Add(Product product)
    {
        values.Add(product);
    }

    public IEnumerator<Product> GetEnumerator()
    {
        foreach (var product in values)
        {
            yield return product;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private static List<Product> theProducts = new List<Product>()
        {
            new Product { ProductID  =  17, ProductName  =  "Alice Mutton", QuantityPerUnit = "20 - 1 kg tins", UnitPrice = 39m, Discontinued = true },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", QuantityPerUnit = "12 - 550 ml bottles", UnitPrice = 10m, Discontinued = false }
        };
}

