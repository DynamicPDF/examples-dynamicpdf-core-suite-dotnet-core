Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.Text

Class TextEncodingExample

    Public Shared Sub Run()
        Dim document As New Document()
        Dim page As New Page()
        document.Pages.Add(page)

        Dim czech As String = "Tohle je textová zpráva, která říká: Ahoj, jak se máš?"
        Dim fnt1 As Font = New Helvetica(Encoder.CentralEurope)

        page.Elements.Add(New TextArea(czech, 0, 0, 300, 12, fnt1, 12))
        page.Elements.Add(New TextArea(czech, 0, 20, 300, 12, Font.Helvetica, 12))

        document.Draw(Util.GetPath("Output/text-encoding-exampleOne.pdf"))
    End Sub

End Class
