Imports System.IO
Imports System.Text.RegularExpressions

Public Class Util

    Public Shared Function GetPath(filePath As String) As String
        Dim exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        Dim appPathMatcher As New Regex("(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)")
        Dim appRoot = appPathMatcher.Match(exePath).Value
        Return System.IO.Path.Combine(appRoot, filePath)
    End Function

    Public Shared Sub CreateOutput()
        Dim exePath As String
        exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

        Dim dirInfo As New DirectoryInfo(exePath + "Output")

        If Not dirInfo.Exists Then
            Dim appPathMatcher As New Regex("(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)")
            Dim appRoot = appPathMatcher.Match(exePath).Value
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(appRoot, "Output"))
        End If
    End Sub

End Class
