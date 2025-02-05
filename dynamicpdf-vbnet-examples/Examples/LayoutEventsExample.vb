Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.LayoutEngine
Imports ceTe.DynamicPDF.LayoutEngine.LayoutElements
Imports ceTe.DynamicPDF.PageElements.BarCoding
Imports QrCode = ceTe.DynamicPDF.PageElements.BarCoding.QrCode

Namespace DynamicPDFCoreSuite.Examples
    Public Class LayoutEventsExample
        Public Shared Sub Run()
            ' Create the document's layout from a DLEX template
            Dim documentLayout As New DocumentLayout(Util.GetPath("Resources/DLEXs/PlaceHolder.dlex"))

            ' Retrieve the placeholder for the dynamic image and attach an event to it
            Dim barcode As ceTe.DynamicPDF.LayoutEngine.LayoutElements.PlaceHolder =
                CType(documentLayout.GetLayoutElementById("Barcode"), ceTe.DynamicPDF.LayoutEngine.LayoutElements.PlaceHolder)
            AddHandler barcode.LaidOut, AddressOf Barcode_LaidOut

            ' Specify the Data to use when laying out the document
            Dim layoutData As New NameValueLayoutData()
            layoutData.Add("HeaderData", "Popular Websites")
            layoutData.Add("Websites", PlaceHolderExampleData.Websites)

            ' Layout the PDF document
            Dim document As Document = documentLayout.Layout(layoutData)
            document.Author = "DynamicPDF ReportWriter"
            document.Title = "PlaceHolder Example"

            ' Outputs the document to a file
            document.Draw(Util.GetPath("Output/placeholder-layoutdata.pdf"))
        End Sub

        Private Shared Sub Barcode_LaidOut(ByVal sender As Object, ByVal e As PlaceHolderLaidOutEventArgs)
            ' Retrieve the image bytes from the layout data for the current record
            Dim url As String = e.LayoutWriter.Data("Url").ToString()

            ' Create a barcode page element from the data and set its properties
            Dim qrCode As New QRCode(url, 0, 0, 2)

            ' Add the barcode and a link to the placeholder's content area
            e.ContentArea.Add(qrCode)
            e.ContentArea.Add(New ceTe.DynamicPDF.PageElements.Link(0, 0, qrCode.GetSymbolWidth(), qrCode.GetSymbolHeight(), New UrlAction(url)))
        End Sub
    End Class
End Namespace
