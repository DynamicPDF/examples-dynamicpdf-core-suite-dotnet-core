Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements.BarCoding

Namespace DynamicPDFCoreSuite.Examples
    Class BarcodeExample

        Public Shared Sub Run()
            Dim document As Document = New Document()
            document = CodaBarBarcode(document)
            document = Code11Barcode(document)
            document = Code128Barcode(document)
            document = Code25Barcode(document)
            document = Code39Barcode(document)
            document = Code93Barcode(document)
            document = Ean8Barcode(document)
            document = Ean8Supplement2Barcode(document)
            document = Ean8Supplement5Barcode(document)
            document = Ean13Barcode(document)
            document = Ean13Supplement2Barcode(document)
            document = Ean13Supplement5Barcode(document)
            document = Ean14Barcode(document)
            document = UpcABarcode(document)
            document = UpcVersionASup5(document)
            document = UpcASupplement2Barcode(document)
            document = UpcVersionE(document)
            document = UpcVersionESup2(document)
            document = UpcVersionESup5(document)
            document = GS1DataBarBarcode(document)
            document = StackedGS1DatabarBarcode(document)
            document = Iata25Barcode(document)
            document = Interleaved25Barcode(document)
            document = IsbnBarcode(document)
            document = IsbnSupplement2Barcode(document)
            document = IsbnSupplement5Barcode(document)
            document = IsmnBarcode(document)
            document = IsmnSupplement2Barcode(document)
            document = IsmnSupplement5Barcode(document)
            document = IssnBarcode(document)
            document = IssnSupplement2Barcode(document)
            document = IssnSupplement5Barcode(document)
            document = Itf14Barcode(document)
            document = Postnet(document)
            document = IntelligentMailBarCode(document)
            document = MsiBarcodeBarcode(document)
            document = Rm4scc(document)
            document = SingaporePost(document)
            document = AustraliaPost(document)
            document = Kix(document)
            document = DeutschePostIdentcode(document)
            document = DeutschePostLeitcode(document)
            document = Aztec(document)
            document = QrCode(document)
            document = DataMatrixBarcode(document)
            document = Pdf417(document)
            document = MacroPdf417(document)


            document.Draw(Util.GetPath("Output/barcodes-example.pdf"))
        End Sub

        Public Shared Function CodaBarBarcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Codabar("A1234B", 50, 0, 48)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function


        Public Shared Function Code11Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Code11("12345678", 50, 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Code128Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Code128("Code 128 Barcode.", 50, 50, 48, 0.75F)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Code25Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Code25("1234567890", 50, 100, 48)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Code39Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Code39("CODE 39", 50, 150, 48)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Code93Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Code93("CODE 93", 50, 150, 48)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Ean8Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Ean8("12345670", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Ean8Supplement2Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Ean8Sup2("1234567012", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Ean8Supplement5Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Ean8Sup5("1234567012345", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Ean13Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Ean13("123456789012", 50, 300)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Ean13Supplement2Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Ean13Sup2("12345678901212", 50, 400)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Ean13Supplement5Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Ean13Sup5("12345678901212345", 50, 500)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Ean14Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Ean14("1234567890123", 50, 50, 48, 0.75F)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function UpcABarcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New UpcVersionA("12345678901", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function UpcVersionASup5(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New UpcVersionASup5("1234567890112345", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function UpcASupplement2Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New UpcVersionASup2("1234567890112", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function UpcVersionE(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New UpcVersionE("0123456", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function UpcVersionESup2(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New UpcVersionESup2("012345612", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function UpcVersionESup5(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New UpcVersionESup5("012345612345", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function GS1DataBarBarcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New GS1DataBar("(01)9889876543210", 50, 50, 50, GS1DataBarType.Omnidirectional)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function StackedGS1DatabarBarcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New StackedGS1DataBar("(01)9889876543210", 50, 50, 50, StackedGS1DataBarType.Stacked)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Iata25Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Iata25("1234567", 50, 100, 48)
            barcode.IncludeCheckDigit = True
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Interleaved25Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Interleaved25("1234567890", 50, 200, 48)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function IsbnBarcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Isbn("978-1-23-456789-7", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function IsbnSupplement2Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New IsbnSup2("978-1-23-456789-7", "12", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function IsbnSupplement5Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New IsbnSup5("978-1-23-456789-7", "12345", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function IsmnBarcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Ismn("979-0-1234-5678", 50, 300)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function IsmnSupplement2Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New IsmnSup2("979-0-1234-5678", "12", 50, 300)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function IsmnSupplement5Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New IsmnSup5("979-0-1234-5678", "12345", 50, 300)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function IssnBarcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Issn("977-1234-56700", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function IssnSupplement2Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New IssnSup2("977-1234-56700", "12", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function IssnSupplement5Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New IssnSup5("979-0-1234-5678", "12345", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Itf14Barcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Itf14("1234567890", 50, 50, 48)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Postnet(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Postnet("20815470412", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function IntelligentMailBarcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New IntelligentMailBarCode("0123456709498765432101234567891", 50, 150)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function MsiBarcodeBarcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New MsiBarcode("1234567890", 50, 100, 48)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Rm4scc(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Rm4scc("20815470412", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function SingaporePost(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New SingaporePost("208154", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function AustraliaPost(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New AustraliaPost("1139549554", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Kix(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Kix("1231FZ13XHS", 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function DeutschePostIdentcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New DeutschePostIdentcode("12345678901", 50, 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function DeutschePostLeitcode(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New DeutschePostLeitcode("1234567890123", 50, 50, 50)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function Aztec(document As Document) As Document
            Dim page As New Page()
            Dim barcode As New Aztec("Hello World", 50, 50, AztecSymbolSize.Full, 5)
            page.Elements.Add(barcode)
            document.Pages.Add(page)
            Return document
        End Function

        Public Shared Function QrCode(document As Document) As Document
            Dim page As New Page()
            document.Pages.Add(page)

            Dim qrCode1 As New QrCode("QR code sample.", 100, 100)
            page.Elements.Add(qrCode1)
            Return document
        End Function

        Public Shared Function DataMatrixBarcode(document As Document) As Document
            Dim page As New Page()
            document.Pages.Add(page)

            Dim dataMatrixBarcode1 As New DataMatrixBarcode("DataMatrix to PDF", 100, 100)
            page.Elements.Add(dataMatrixBarcode1)
            Return document
        End Function

        Public Shared Function Pdf417(document As Document) As Document
            Dim page As New Page()
            document.Pages.Add(page)

            Dim pdf417a As New Pdf417("Pdf417 to PDF", 10.0F, 10.0F, 2, 2.0F)
            page.Elements.Add(pdf417a)
            Return document
        End Function

        Public Shared Function MacroPdf417(document As Document) As Document
            Dim page As New Page()
            document.Pages.Add(page)

            Dim macroPdf417a As New MacroPdf417("MacroPdf417 to PDF", 10.0F, 10.0F, 3, 2.0F)
            page.Elements.Add(macroPdf417a)
            Return document
        End Function

    End Class

End Namespace

