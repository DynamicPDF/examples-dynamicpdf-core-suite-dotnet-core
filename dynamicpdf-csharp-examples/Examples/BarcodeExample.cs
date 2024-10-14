using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.BarCoding;

namespace DynamicPDFCoreSuite.Examples
{
    class BarcodeExample
    {

        public static void Run()
        {
            Document document = new Document();
            document = CodaBarBarcode(document);
            document = Code11Barcode(document);
            document = Code128Barcode(document);
            document = Code25Barcode(document);
            document = Code39Barcode(document);
            document = Code93Barcode(document);
            document = Ean8Barcode(document);
            document = Ean8Supplement2Barcode(document);
            document = Ean8Supplement5Barcode(document);
            document = Ean13Barcode(document);
            document = Ean13Supplement2Barcode(document);
            document = Ean13Supplement5Barcode(document);
            document = Ean14Barcode(document);
            document = UpcABarcode(document);
            document = UpcVersionASup5(document);
            document = UpcASupplement2Barcode(document);
            document = UpcVersionE(document);
            document = UpcVersionESup2(document);
            document = UpcVersionESup5(document);
            document = GS1DataBarBarcode(document);
            document = StackedGS1DatabarBarcode(document);
            document = Iata25Barcode(document);
            document = Interleaved25Barcode(document);
            document = IsbnBarcode(document);
            document = IsbnSupplement2Barcode(document);
            document = IsbnSupplement5Barcode(document);
            document = IsmnBarcode(document);
            document = IsmnSupplement2Barcode(document);
            document = IsmnSupplement5Barcode(document);
            document = IssnBarcode(document);
            document = IssnSupplement2Barcode(document);
            document = IssnSupplement5Barcode(document);
            document = Itf14Barcode(document);
            document = Postnet(document);
            document = IntelligentMailBarcode(document);
            document = MsiBarcodeBarcode(document);
            document = Rm4scc(document);
            document = SignaporePost(document);
            document = AustraliaPost(document);
            document = Kix(document);
            document = DeutschePostIdentcode(document);
            document = DeutschePostLeitcode(document);
            document = Aztec(document);
            document = QrCode(document);
            document = DataMatrixBarcode(document);
            document = Pdf417(document);
            document = MacroPdf417(document);
            document.Draw(Util.GetPath("Output/barcodes-example.pdf"));

        }

        public static Document CodaBarBarcode(Document document)
        {
            Page page = new Page();
            Codabar barcode = new Codabar("A1234B", 50, 0, 48);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document Code11Barcode(Document document)
        {
            Page page = new Page();
            Code11 barcode = new Code11("12345678", 50, 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Code128Barcode(Document document)
        {
            Page page = new Page();
            Code128 barcode = new Code128("Code 128 Barcode.", 50, 50, 48, 0.75F);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Code25Barcode(Document document)
        {
            Page page = new Page();
            Code25 barcode = new Code25("1234567890", 50, 100, 48);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Code39Barcode(Document document)
        {
            Page page = new Page();
            Code39 barcode = new Code39("CODE 39", 50, 150, 48);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Code93Barcode(Document document)
        {
            Page page = new Page();
            Code93 barcode = new Code93("CODE 93", 50, 150, 48);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Ean8Barcode(Document document)
        {
            Page page = new Page();
            Ean8 barcode = new Ean8("12345670", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Ean8Supplement2Barcode(Document document)
        {
            Page page = new Page();
            Ean8Sup2 barcode = new Ean8Sup2("1234567012", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Ean8Supplement5Barcode(Document document)
        {
            Page page = new Page();
            Ean8Sup5 barcode = new Ean8Sup5("1234567012345", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Ean13Barcode(Document document)
        {
            Page page = new Page();
            Ean13 barcode = new Ean13("123456789012", 50, 300);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Ean13Supplement2Barcode(Document document)
        {
            Page page = new Page();
            Ean13Sup2 barcode = new Ean13Sup2("12345678901212", 50, 400);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Ean13Supplement5Barcode(Document document)
        {
            Page page = new Page();
            Ean13Sup5 barcode = new Ean13Sup5("12345678901212345", 50, 500);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document Ean14Barcode(Document document)
        {
            Page page = new Page();
            Ean14 barcode = new Ean14("1234567890123", 50, 50, 48, 0.75F);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document UpcABarcode(Document document)
        {
            Page page = new Page();
            UpcVersionA barcode = new UpcVersionA("12345678901", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document UpcVersionASup5(Document document)
        {
            Page page = new Page();
            UpcVersionASup5 barcode = new UpcVersionASup5("1234567890112345", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document UpcASupplement2Barcode(Document document)
        {
            Page page = new Page();
            UpcVersionASup2 barcode = new UpcVersionASup2("1234567890112", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document UpcVersionE(Document document)
        {
            Page page = new Page();
            UpcVersionE barcode = new UpcVersionE("0123456", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document UpcVersionESup2(Document document)
        {
            Page page = new Page();
            UpcVersionESup2 barcode = new UpcVersionESup2("012345612", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document UpcVersionESup5(Document document)
        {
            Page page = new Page();
            UpcVersionESup5 barcode = new UpcVersionESup5("012345612345", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document GS1DataBarBarcode(Document document)
        {
            Page page = new Page();
            GS1DataBar barcode = new GS1DataBar("(01)9889876543210", 50, 50, 50, GS1DataBarType.Omnidirectional);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document StackedGS1DatabarBarcode(Document document)
        {
            Page page = new Page();
            StackedGS1DataBar barcode = new StackedGS1DataBar("(01)9889876543210", 50, 50, 50, StackedGS1DataBarType.Stacked);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document Iata25Barcode(Document document)
        {
            Page page = new Page();
            Iata25 barcode = new Iata25("1234567", 50, 100, 48);
            barcode.IncludeCheckDigit = true;
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document Interleaved25Barcode(Document document)
        {
            Page page = new Page();
            Interleaved25 barcode = new Interleaved25("1234567890", 50, 200, 48);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document IsbnBarcode(Document document)
        {
            Page page = new Page();
            Isbn barcode = new Isbn("978-1-23-456789-7", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document IsbnSupplement2Barcode(Document document)
        {
            Page page = new Page();
            IsbnSup2 barcode = new IsbnSup2("978-1-23-456789-7", "12", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document IsbnSupplement5Barcode(Document document)
        {
            Page page = new Page();
            IsbnSup5 barcode = new IsbnSup5("978-1-23-456789-7", "12345", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document IsmnBarcode(Document document)
        {
            Page page = new Page();
            Ismn barcode = new Ismn("979-0-1234-5678", 50, 300);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document IsmnSupplement2Barcode(Document document)
        {
            Page page = new Page();
            IsmnSup2 barcode = new IsmnSup2("979-0-1234-5678", "12", 50, 300);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document IsmnSupplement5Barcode(Document document)
        {
            Page page = new Page();
            IsmnSup5 barcode = new IsmnSup5("979-0-1234-5678", "12345", 50, 300);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document IssnBarcode(Document document)
        {
            Page page = new Page();
            Issn barcode = new Issn("977-1234-56700", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }
        public static Document IssnSupplement2Barcode(Document document)
        {
            Page page = new Page();
            IssnSup2 barcode = new IssnSup2("977-1234-56700", "12", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document IssnSupplement5Barcode(Document document)
        {
            Page page = new Page();
            IssnSup5 barcode = new IssnSup5("979-0-1234-5678", "12345", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document Itf14Barcode(Document document)
        {
            Page page = new Page();
            Itf14 barcode = new Itf14("1234567890", 50, 50, 48);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document Postnet(Document document)
        {
            Page page = new Page();
            Postnet barcode = new Postnet("20815470412", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document IntelligentMailBarcode(Document document)
        {
            Page page = new Page();
            IntelligentMailBarCode barcode = new IntelligentMailBarCode("0123456709498765432101234567891", 50, 150);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }


        public static Document MsiBarcodeBarcode(Document document)
        {
            Page page = new Page();
            MsiBarcode barcode = new MsiBarcode("1234567890", 50, 100, 48);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }


        public static Document Rm4scc(Document document)
        {
            Page page = new Page();
            Rm4scc barcode = new Rm4scc("20815470412", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document SignaporePost(Document document)
        {
            Page page = new Page();
            SingaporePost barcode = new SingaporePost("208154", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document AustraliaPost(Document document)
        {
            Page page = new Page();
            AustraliaPost barcode = new AustraliaPost("1139549554", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document Kix(Document document)
        {
            Page page = new Page();
            Kix barcode = new Kix("1231FZ13XHS", 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document DeutschePostIdentcode(Document document)
        {
            Page page = new Page();
            DeutschePostIdentcode barcode = new DeutschePostIdentcode("12345678901", 50, 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document DeutschePostLeitcode(Document document)
        {
            Page page = new Page();
            DeutschePostLeitcode barcode = new DeutschePostLeitcode("1234567890123", 50, 50, 50);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document Aztec(Document document)
        {
            Page page = new Page();
            Aztec barcode = new Aztec("Hello World", 50, 50, AztecSymbolSize.Full, 5);
            page.Elements.Add(barcode);
            document.Pages.Add(page);
            return document;
        }

        public static Document QrCode(Document document)
        {
            Page page = new Page();
            document.Pages.Add(page);

            QrCode qrCode = new QrCode("QR code sample.", 100, 100);
            page.Elements.Add(qrCode);
            return document;
        }

        public static Document DataMatrixBarcode(Document document)
        {
            Page page = new Page();
            document.Pages.Add(page);
            DataMatrixBarcode dataMatrixBarcode = new DataMatrixBarcode("DataMatrix to PDF", 100, 100);
            page.Elements.Add(dataMatrixBarcode);
            return document;
        }

        public static Document Pdf417(Document document)
        {
            Page page = new Page();
            document.Pages.Add(page);
            Pdf417 pdf417 = new Pdf417("Pdf417 to PDF", 10.0f, 10.0f, 2, 2.0f);
            page.Elements.Add(pdf417);
            return document;
        }

        public static Document MacroPdf417(Document document)
        {
            Page page = new Page();
            document.Pages.Add(page);
            MacroPdf417 macroPdf417 = new MacroPdf417("MacroPdf417 to PDF", 10.0f, 10.0f, 3, 2.0f);
            page.Elements.Add(macroPdf417);
            return document;
        }


    }
}
