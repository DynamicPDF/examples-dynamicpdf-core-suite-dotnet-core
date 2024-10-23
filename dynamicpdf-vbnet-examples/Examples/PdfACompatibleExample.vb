Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.Text
Imports ceTe.DynamicPDF.Xmp

Namespace DynamicPDFCoreSuite.Examples

    Class PdfACompatibleExample

        Public Shared Sub Run()
            PdfA1Example()
            PdfA3aExample()
        End Sub

        Public Shared Sub PdfA1Example()
            Dim document As New Document()
            document.Title = "PDF/A1 Document"
            document.Subject = "Document's Subject"
            document.Tag = New TagOptions()
            document.Author = "John Doe"

            Dim xmp As New XmpMetadata()

            Dim pdfaschema As New PdfASchema(PdfAStandard.PDF_A_1a_2005)
            xmp.AddSchema(pdfaschema)

            Dim dc As DublinCoreSchema = xmp.DublinCore
            dc.Title.DefaultText = document.Title
            dc.Description.DefaultText = document.Subject
            dc.Creators.Add(document.Author)
            dc.Title.AddLang("en-us", "PDF/A1 Document")
            document.XmpMetadata = xmp

            Dim iccProfile As New IccProfile(Util.GetPath("Resources/Data/sRGB_IEC61966-2-1_noBPC.icc"))
            Dim outputIntents As New OutputIntent("", "IEC 61966-2.1 Default RGB colour space - sRGB 1", "http://www.color.org", "sRGB IEC61966-2.1 1", iccProfile)
            outputIntents.Version = OutputIntentVersion.PDF_A
            document.OutputIntents.Add(outputIntents)

            Dim text As String = "PDF/A (Archiving) specifically targets PDF documents that need to be preserved long term."
            Dim label As New Label(text, 0, 0, 504, 100, Font.Courier, 18, TextAlign.Center, RgbColor.BlueViolet)

            Dim page As New Page(PageSize.Letter, PageOrientation.Portrait, 54.0F)
            page.Elements.Add(label)
            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/pdfa-output.pdf"))
        End Sub

        Public Shared Sub PdfA3aExample()
            Dim document As New Document()
            document.Title = "PDF/A-3A Document"
            document.Subject = "Document's Subject"
            document.Tag = New TagOptions()
            document.Author = "John Doe"

            Dim xmp As New XmpMetadata()

            Dim pdfaschema As New PdfASchema(PdfAStandard.PdfA3a)
            xmp.AddSchema(pdfaschema)

            Dim dc As DublinCoreSchema = xmp.DublinCore
            dc.Title.DefaultText = document.Title
            dc.Description.DefaultText = document.Subject
            dc.Creators.Add(document.Author)
            dc.Title.AddLang("en-us", "PDF/A-3A Document")
            document.XmpMetadata = xmp

            Dim iccProfile As New IccProfile(Util.GetPath("Resources/Data/USWebCoatedSWOP.icc"))
            Dim outputIntent As New OutputIntent("CGATS TR 001-1995 (SWOP)", "CGATS TR 001", "http://www.color.org", "U.S. Web Coated (SWOP) v2", iccProfile)

            outputIntent.Version = OutputIntentVersion.PDF_A
            document.OutputIntents.Add(outputIntent)

            Dim embeddedFile1 As New EmbeddedFile(Util.GetPath("Resources/Data/HelloWorldExcel.xls"))
            embeddedFile1.Relation = EmbeddedFileRelation.Data
            embeddedFile1.MimeType = "application/excel"
            document.EmbeddedFiles.Add(embeddedFile1)

            Dim embeddedFile2 As New EmbeddedFile(Util.GetPath("Resources/Data/simple.xml"))
            embeddedFile2.Relation = EmbeddedFileRelation.Source
            embeddedFile2.MimeType = "application/xml"
            document.EmbeddedFiles.Add(embeddedFile2)

            Dim text As String = "PDF/A-3A (Archiving) specifically targets PDF documents that need to be preserved long term."
            Dim label As New Label(text, 0, 0, 504, 100, Font.Courier, 18, TextAlign.Center, RgbColor.BlueViolet)

            Dim page As New Page(PageSize.Letter, PageOrientation.Portrait, 54.0F)
            page.Elements.Add(label)
            document.Pages.Add(page)

            document.Draw(Util.GetPath("Output/pdfa3a-output.pdf"))
        End Sub

    End Class

End Namespace

