Imports System.Collections.Generic

Public Class ProductsData
    Public Class Product
        Public Property ProductID As Integer
        Public Property ProductName As String
        Public Property QuantityPerUnit As String
        Public Property UnitPrice As Decimal
        Public Property Discontinued As Boolean
    End Class

    Public Shared Products As New List(Of Product) From {
        New Product With {.ProductID = 17, .ProductName = "Alice Mutton", .QuantityPerUnit = "20 - 1 kg tins", .UnitPrice = 39D, .Discontinued = True},
        New Product With {.ProductID = 3, .ProductName = "Aniseed Syrup", .QuantityPerUnit = "12 - 550 ml bottles", .UnitPrice = 10D, .Discontinued = False},
        New Product With {.ProductID = 40, .ProductName = "Boston Crab Meat", .QuantityPerUnit = "24 - 4 oz tins", .UnitPrice = 18.4D, .Discontinued = False},
        New Product With {.ProductID = 60, .ProductName = "Camembert Pierrot", .QuantityPerUnit = "15 - 300 g rounds", .UnitPrice = 34D, .Discontinued = False},
        New Product With {.ProductID = 18, .ProductName = "Carnarvon Tigers", .QuantityPerUnit = "16 kg pkg.", .UnitPrice = 62.5D, .Discontinued = False},
        New Product With {.ProductID = 1, .ProductName = "Chai", .QuantityPerUnit = "10 boxes x 20 bags", .UnitPrice = 18D, .Discontinued = False},
        New Product With {.ProductID = 2, .ProductName = "Chang", .QuantityPerUnit = "24 - 12 oz bottles", .UnitPrice = 19D, .Discontinued = False},
        New Product With {.ProductID = 39, .ProductName = "Chartreuse verte", .QuantityPerUnit = "750 cc per bottle", .UnitPrice = 18D, .Discontinued = False},
        New Product With {.ProductID = 4, .ProductName = "Chef Anton's Cajun Seasoning", .QuantityPerUnit = "48 - 6 oz jars", .UnitPrice = 22D, .Discontinued = False},
        New Product With {.ProductID = 5, .ProductName = "Chef Anton's Gumbo Mix", .QuantityPerUnit = "36 boxes", .UnitPrice = 21.35D, .Discontinued = True},
        New Product With {.ProductID = 48, .ProductName = "Chocolade", .QuantityPerUnit = "10 pkgs.", .UnitPrice = 12.75D, .Discontinued = False}
    }
End Class

