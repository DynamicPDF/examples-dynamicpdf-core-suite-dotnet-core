Imports System.Collections
Imports System.Collections.Generic

Public Class Product
    Public Property ProductID As Integer
    Public Property ProductName As String
    Public Property QuantityPerUnit As String
    Public Property UnitPrice As Decimal
    Public Property Discontinued As Boolean
End Class

Public Class Products
    Implements IEnumerable(Of Product)

    Private values As List(Of Product) = theProducts

    Public Sub Add(product As Product)
        values.Add(product)
    End Sub

    Public Iterator Function GetEnumerator() As IEnumerator(Of Product) Implements IEnumerable(Of Product).GetEnumerator
        For Each product As Product In values
            Yield product
        Next
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function

    Private Shared theProducts As New List(Of Product) From {
        New Product With {.ProductID = 17, .ProductName = "Alice Mutton", .QuantityPerUnit = "20 - 1 kg tins", .UnitPrice = 39D, .Discontinued = True},
        New Product With {.ProductID = 3, .ProductName = "Aniseed Syrup", .QuantityPerUnit = "12 - 550 ml bottles", .UnitPrice = 10D, .Discontinued = False}
    }
End Class

