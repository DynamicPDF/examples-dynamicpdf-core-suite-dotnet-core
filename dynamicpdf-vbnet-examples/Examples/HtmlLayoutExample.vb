Imports ceTe.DynamicPDF
Imports System.IO

Namespace DynamicPDFCoreSuite.Examples
    Public Class HtmlLayoutExample
        Public Shared Sub Run()
            Dim layoutPage As New PageInfo(PageSize.A4, PageOrientation.Portrait)
            Dim txt As String = File.ReadAllText(Util.GetPath("Resources/HTML/example.html"))
            Dim html As New HtmlLayout(txt, layoutPage)

            html.Header.Center.Text = "%%PR%%%%SP%% of %%ST%%"
            html.Header.Center.HasPageNumbers = True
            html.Header.Center.Width = 200

            html.Footer.Center.Text = "%%PR%%%%SP(A)%% of %%ST(B)%%"
            html.Footer.Center.HasPageNumbers = True
            html.Footer.Center.Width = 200

            Dim doc As Document = html.Layout()

            doc.Draw(Util.GetPath("Output/html-layout-out.pdf"))
        End Sub
    End Class
End Namespace

