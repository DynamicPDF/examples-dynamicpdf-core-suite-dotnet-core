Imports ceTe.DynamicPDF
Imports System

Namespace DynamicPDFCoreSuite.Examples
    Class HtmlToPdf

        Public Shared Sub Run()
            Dim layoutPage As New PageInfo(PageSize.A4, PageOrientation.Portrait)
            Dim uri As New Uri("https://www.dynamicpdf.com/docs/dotnet/dynamic-pdf-core-suite-welcome")

            Dim html As New HtmlLayout(uri, layoutPage)

            html.Header.Center.Text = "%%PR%%%%SP%% of %%ST%%"
            html.Header.Center.HasPageNumbers = True
            html.Header.Center.Width = 200

            html.Footer.Center.Text = "%%PR%%%%SP(A)%% of %%ST(B)%%"
            html.Footer.Center.HasPageNumbers = True
            html.Footer.Center.Width = 200

            Dim document As Document = html.Layout()
            document.Draw(Util.GetPath("Output/html-to-pdf-output.pdf"))
        End Sub

    End Class
End Namespace

