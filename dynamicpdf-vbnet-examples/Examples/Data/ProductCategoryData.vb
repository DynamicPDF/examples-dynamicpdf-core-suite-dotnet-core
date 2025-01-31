Imports System
Imports System.Collections.Generic
Imports System.IO
Imports Newtonsoft.Json

Public Class ProductCategoryData

    Public Class Product
        Public Property ProductID As Integer
        Public Property ProductName As String
        Public Property QuantityPerUnit As String
        Public Property Discontinued As Boolean
        Public Property UnitPrice As Decimal
    End Class

    Public Class ProductCategory
        Public Property Name As String
        Public Property Products As List(Of Product)
    End Class

    Public Class Root
        Public Property ProductsByCategory As List(Of ProductCategory)
    End Class

    Public Shared Function GetProductCategoryObjects() As List(Of ProductCategory)
        Dim jsonFilePath As String = Util.GetPath("Resources/Data/subreport.json")
        Dim jsonData As String = File.ReadAllText(jsonFilePath)
        Dim productData As Root = JsonConvert.DeserializeObject(Of Root)(jsonData)
        ' DisplayParseData(productData)
        Return productData.ProductsByCategory
    End Function

    Private Shared Sub DisplayParseData(ByVal productData As Root)
        For Each category In productData.ProductsByCategory
            Console.WriteLine($"Category: {category.Name}")
            For Each product In category.Products
                Console.WriteLine($" - {product.ProductName}, Price: ${product.UnitPrice}")
            Next
        Next
    End Sub

End Class
