Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.IO

Namespace DynamicPDFCoreSuite.Examples
    Public Class CustomElement
        Inherits ceTe.DynamicPDF.PageElements.TextArea

        Public Sub New(ByVal text As String, ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single)
            MyBase.New(text, x, y, width, height)
        End Sub

        Public Overrides Sub Draw(ByVal writer As PageWriter)
            Dim font As Font = Font.CourierBold
            writer.SetTextMode()
            writer.SetFont(font, 25.0F)
            writer.SetTextRenderingMode(TextRenderingMode.FillAndStroke)
            writer.SetStrokeColor(RgbColor.Red)
            writer.SetFillColor(RgbColor.LightBlue)
            writer.SetLeading(font.GetDefaultLeading(12))
            writer.Write_Tm(MyBase.X, MyBase.Y)
            writer.Write_SQuote(MyBase.Text.ToCharArray(), 0, MyBase.Text.Length, False)
        End Sub

    End Class
End Namespace

