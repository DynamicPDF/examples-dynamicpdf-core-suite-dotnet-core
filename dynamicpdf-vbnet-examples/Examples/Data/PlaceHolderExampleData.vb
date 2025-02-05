Imports System.Collections.Generic

Public Class PlaceHolderExampleData

    Public Class Website
        Public Property Name As String
        Public Property Description As String
        Public Property Url As String
    End Class

    Private Shared websites_1 As New List(Of Website) From {
        New Website With {.Name = "DynamicPDF", .Description = "Founded in 2002, DynamicPDF is a leader in PDF SDKs and libraries.", .Url = "https://www.dynamicpdf.com"},
        New Website With {.Name = "Facebook", .Description = "Founded in 2004, Facebook is a popular social networking website.", .Url = "https://www.facebook.com"},
        New Website With {.Name = "Google", .Description = "Founded in 1997, Google is a popular search engine.", .Url = "https://www.google.com"},
        New Website With {.Name = "Twitter", .Description = "Founded in 2006, Twitter is a popular news and social media website.", .Url = "https://twitter.com"}
    }

    Public Shared ReadOnly Property Websites As List(Of Website)
        Get
            Return websites_1
        End Get
    End Property

End Class

