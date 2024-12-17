
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Xmp;

namespace DynamicPDFCoreSuite.Examples
{
    public class PdfUaExample
    {
        public static void Run()
        {
            // Create a PDF Document
            Document document = new Document();

            // Set the TagOptions to document
            document.Tag = new TagOptions();

            // Create StructureElement objects and set Order etc.
            StructureElement structureDocument = new StructureElement(TagType.Document);
            StructureElement structureHeading = new StructureElement(TagType.Heading);
            StructureElement structureForm = new StructureElement(TagType.Form);
            structureForm.Order = 2;
            structureHeading.Parent = structureDocument;
            structureForm.Parent = structureDocument;

            // Create AttributeObject objects with tag order and parents.
            AttributeObject attrObjLayout = new AttributeObject(AttributeOwner.Layout);
            attrObjLayout.SetPlacement(Placement.Block);
            structureForm.AttributeLists.Add(attrObjLayout);
            StructureElement structureForm2 = new StructureElement(TagType.Form);
            structureForm2.Order = 4;
            structureForm2.Parent = structureDocument;
            structureForm2.AttributeLists.Add(attrObjLayout);
            StructureElement structureParagraph = new StructureElement(TagType.Paragraph);
            structureParagraph.Order = 1;
            structureParagraph.Parent = structureDocument;
            StructureElement element5 = new StructureElement(TagType.Paragraph);
            element5.Parent = structureDocument;
            element5.Order = 3;

            // Set Document Language
            document.Language = "en-us";
            document.ViewerPreferences.DisplayDocTitle = true;

            // Create a Page
            Page page = new Page();

            // Create a Label and set Tag
            ceTe.DynamicPDF.PageElements.Label lblEnterName = new ceTe.DynamicPDF.PageElements.Label("Name : ", 0, 100, 100, 50);
            lblEnterName.Tag = structureParagraph;
            ceTe.DynamicPDF.PageElements.Label lblAge = new ceTe.DynamicPDF.PageElements.Label("Age : ", 0, 200, 100, 50);
            lblAge.Tag = element5;

            // Create a TextField and set Tag
            ceTe.DynamicPDF.PageElements.Forms.TextField txtField1 = new ceTe.DynamicPDF.PageElements.Forms.TextField("txtFieldName", 100, 100, 100, 50);
            ceTe.DynamicPDF.PageElements.Forms.TextField txtField2 = new ceTe.DynamicPDF.PageElements.Forms.TextField("txtFieldName", 100, 200, 100, 50);
            txtField1.Tag = structureForm;
            txtField2.Tag = structureForm2;

            // Create an OpenTypeFont object with Embed option and ToolTip
            OpenTypeFont font = new OpenTypeFont(Util.GetPath("Resources/Data/times.ttf"));
            font.Embed = true;
            font.Subset = false;
            lblEnterName.Font = font;
            lblAge.Font = font; 
            txtField1.Font = font;
            txtField1.ToolTip = "Name";
            txtField2.Font = font;
            txtField2.ToolTip = "age";

            // Add the Elements to the Page
            page.Elements.Add(lblEnterName);
            page.Elements.Add(txtField1);
            page.Elements.Add(lblAge);
            page.Elements.Add(txtField2);

            // Add Page to the Document
            document.Pages.Add(page);

            // Create an Xmp Metadata
            XmpMetadata xmp = new XmpMetadata();

            // Create a PdfUASchema and add to XMP matadata
            PdfUASchema customSchema = new PdfUASchema();
            xmp.AddSchema(customSchema);

            // Create DublinCoreSchema and set properties
            DublinCoreSchema dc = xmp.DublinCore;
            dc.Title.AddLang("en-us", "XMP");
            dc.Title.DefaultText = "Title Text";

            // Adding the XmpMatadata to the document
            document.XmpMetadata = xmp;

            // Save the PDF
            document.Draw(Util.GetPath("Output/pdfua-output.pdf"));
        }
    }
}
