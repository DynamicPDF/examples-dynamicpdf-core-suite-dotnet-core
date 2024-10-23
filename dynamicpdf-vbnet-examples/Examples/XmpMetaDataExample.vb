Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Xmp
Imports System
Imports System.IO

Namespace DynamicPDFCoreSuite.Examples
    Class XmpMetadataExample
        Public Shared Sub Run()
            BasicJobTicket()
            DublinCoreExample()
            PageTextSchemaExample()
            RightsManagementSchemaExample()
            BasicSchemaExample()
        End Sub

        Public Shared Sub BasicJobTicket()
            Dim document As New Document()

            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New Page(PageSize.Letter))

            Dim xmp As New XmpMetadata()
            Dim job As New BasicJobTicketSchema()
            job.JobRef.Add("MyCompany", "Xmp Test", New Uri("http://www.mydomain.com/"))
            job.JobRef.Add("MyProduct", "XMP Metadata", New Uri("http://www.mydomain.com/"))
            xmp.AddSchema(job)
            document.XmpMetadata = xmp

            document.Draw(Util.GetPath("Output/xmp-basicjobticket-output.pdf"))
        End Sub

        Public Shared Sub DublinCoreExample()
            Dim document As New Document()

            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New Page(PageSize.Letter))

            Dim xmp As New XmpMetadata()

            Dim dc As DublinCoreSchema = xmp.DublinCore
            dc.Contributors.Add("Abc")
            dc.Contributors.Add("Xyz")
            dc.Contributors.Add("Pqrs")
            dc.Coverage = "To test all the attributes of schema's provided"
            dc.Creators.Add("MyProduct")
            dc.Creators.Add("MyCompany")
            dc.Date.Add(DateTime.Now)
            dc.Description.AddLang("en-us", "XMP Schema's test")
            dc.Identifier = "First XMP pdf"
            dc.Publisher.Add("mydomain.com")
            dc.Publisher.Add("MyCompany")
            dc.Relation.Add("test pdf with xmp")
            dc.Rights.DefaultText = "US English"
            dc.Rights.AddLang("en-us", "All rights reserved 2012, MyCompany.")
            dc.Source = "XMP Project"
            dc.Subject.Add("eXtensible Metadata Platform")
            dc.Title.AddLang("en-us", "XMP")
            dc.Title.AddLang("it-it", "XMP - Piattaforma Estendible di Metadata")
            dc.Title.AddLang("du-du", "De hallo Wereld")
            dc.Title.AddLang("fr-fr", "XMP - Une Platforme Extensible pour les Métédonnées")
            dc.Title.AddLang("DE-DE", "ÄËßÜ Hallo Welt")

            document.XmpMetadata = xmp

            document.Draw(Util.GetPath("Output/xmp-dublincore-output.pdf"))
        End Sub

        Public Shared Sub PageTextSchemaExample()
            Dim document As New Document()

            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New Page(PageSize.Letter))

            Dim xmp As New XmpMetadata()

            Dim pt As New PagedTextSchema()
            xmp.AddSchema(pt)

            document.XmpMetadata = xmp

            document.Draw(Util.GetPath("Output/xmp-pagetextschema-output.pdf"))
        End Sub

        Public Shared Sub RightsManagementSchemaExample()
            Dim document As New Document()

            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New Page(PageSize.Letter))

            Dim xmp As New XmpMetadata()

            Dim rm As New RightsManagementSchema()
            rm.Marked2 = CopyrightStatus.PublicDomain
            rm.Owner.Add("Company Name")
            rm.UsageTerms.AddLang("en-us", "Contact MyCompany")
            xmp.AddSchema(rm)

            document.XmpMetadata = xmp

            document.Draw(Util.GetPath("Output/xmp-rightsmanagementschema-output.pdf"))
        End Sub

        Public Shared Sub BasicSchemaExample()
            Dim document As New Document()

            document.Pages.Add(New Page(PageSize.Letter))
            document.Pages.Add(New Page(PageSize.Letter))

            Dim xmp As New XmpMetadata()

            Dim bs As BasicSchema = xmp.BasicSchema
            bs.Advisory.Add("Date")
            bs.Advisory.Add("Contributors")
            bs.Nickname = "xyz"
            bs.Thumbnails.Add(106, 80, "JPEG", GetImage()) 'imageData is byte array

            document.XmpMetadata = xmp

            document.Draw(Util.GetPath("Output/basicschema-output.pdf"))
        End Sub

        Private Shared Function GetImage() As Byte()
            Dim inFile As New FileStream(Util.GetPath("Resources/Images/DynamicPDF_top.gif"), FileMode.Open, FileAccess.Read)
            Dim binaryData(inFile.Length - 1) As Byte
            inFile.Read(binaryData, 0, CInt(inFile.Length))
            inFile.Close()
            Return binaryData
        End Function
    End Class
End Namespace
