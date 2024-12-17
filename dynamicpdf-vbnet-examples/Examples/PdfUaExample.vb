Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Text
Imports ceTe.DynamicPDF.Xmp

Namespace DynamicPDFCoreSuite.Examples
    Public Class PdfUaExample
        Public Shared Sub Run()
            ' Create a PDF Document
            Dim document As New Document()

            ' Set the TagOptions to document
            document.Tag = New TagOptions()

            ' Create StructureElement objects and set Order etc.
            Dim structureDocument As New StructureElement(TagType.Document)
            Dim structureHeading As New StructureElement(TagType.Heading)
            Dim structureForm As New StructureElement(TagType.Form)
            structureForm.Order = 2
            structureHeading.Parent = structureDocument
            structureForm.Parent = structureDocument

            ' Create AttributeObject objects with tag order and parents.
            Dim attrObjLayout As New AttributeObject(AttributeOwner.Layout)
            attrObjLayout.SetPlacement(Placement.Block)
            structureForm.AttributeLists.Add(attrObjLayout)
            Dim structureForm2 As New StructureElement(TagType.Form)
            structureForm2.Order = 4
            structureForm2.Parent = structureDocument
            structureForm2.AttributeLists.Add(attrObjLayout)
            Dim structureParagraph As New StructureElement(TagType.Paragraph)
            structureParagraph.Order = 1
            structureParagraph.Parent = structureDocument
            Dim element5 As New StructureElement(TagType.Paragraph)
            element5.Parent = structureDocument
            element5.Order = 3

            ' Set Document Language
            document.Language = "en-us"
            document.ViewerPreferences.DisplayDocTitle = True

            ' Create a Page
            Dim page As New Page()

            ' Create a Label and set Tag
            Dim lblEnterName As New ceTe.DynamicPDF.PageElements.Label("Name : ", 0, 100, 100, 50)
            lblEnterName.Tag = structureParagraph
            Dim lblAge As New ceTe.DynamicPDF.PageElements.Label("Age : ", 0, 200, 100, 50)
            lblAge.Tag = element5

            ' Create a TextField and set Tag
            Dim txtField1 As New ceTe.DynamicPDF.PageElements.Forms.TextField("txtFieldName", 100, 100, 100, 50)
            Dim txtField2 As New ceTe.DynamicPDF.PageElements.Forms.TextField("txtFieldName", 100, 200, 100, 50)
            txtField1.Tag = structureForm
            txtField2.Tag = structureForm2

            ' Create an OpenTypeFont object with Embed option and ToolTip
            Dim font As New OpenTypeFont(Util.GetPath("Resources/Data/times.ttf"))
            font.Embed = True
            font.Subset = False
            lblEnterName.Font = font
            lblAge.Font = font
            txtField1.Font = font
            txtField1.ToolTip = "Name"
            txtField2.Font = font
            txtField2.ToolTip = "age"

            ' Add the Elements to the Page
            page.Elements.Add(lblEnterName)
            page.Elements.Add(txtField1)
            page.Elements.Add(lblAge)
            page.Elements.Add(txtField2)

            ' Add Page to the Document
            document.Pages.Add(page)

            ' Create an Xmp Metadata
            Dim xmp As New XmpMetadata()

            ' Create a PdfUASchema and add to XMP metadata
            Dim customSchema As New PdfUASchema()
            xmp.AddSchema(customSchema)

            ' Create DublinCoreSchema and set properties
            Dim dc As DublinCoreSchema = xmp.DublinCore
            dc.Title.AddLang("en-us", "XMP")
            dc.Title.DefaultText = "Title Text"

            ' Adding the XmpMetadata to the document
            document.XmpMetadata = xmp

            ' Save the PDF
            document.Draw(Util.GetPath("Output/pdfua-output.pdf"))
        End Sub
    End Class
End Namespace

