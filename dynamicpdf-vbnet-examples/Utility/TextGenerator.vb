Imports System.IO
Imports DynamicPDFCoreSuite.Examples

Namespace DynamicPDFCoreSuite.Utility
    Public Class TextGenerator
        Public Shared Function Generate() As String
            Return File.ReadAllText(Util.GetPath("Resources/HTML/simple.html"))
        End Function

        Public Shared Function GenerateLargeTextDoc() As String
            Dim txtData As String = File.ReadAllText(Util.GetPath("Resources/Data/simple.txt"))
            For i As Integer = 0 To 9
                txtData &= txtData
            Next
            Return txtData.Replace("\n", Environment.NewLine).Replace("  ", " ")
        End Function
    End Class
End Namespace

