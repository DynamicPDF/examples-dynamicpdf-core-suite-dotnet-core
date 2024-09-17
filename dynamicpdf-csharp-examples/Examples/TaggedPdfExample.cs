

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class TaggedPdfExample
    {

        public static void Run()
        {
            Document document = new Document();
            document.Tag = new TagOptions(true);

            Page page = new Page();
            document.Pages.Add(page);

            Image image = new Image(Util.GetPath("Resources/Images/DynamicPDF_top.gif"), 180f, 150f, 0.24f);
            image.Height = 200;
            image.Width = 200;

            StructureElement imageStructureElement = new StructureElement(TagType.Figure);
            imageStructureElement.IncludeDefaultAttributes = true;
            imageStructureElement.AlternateText = "DynamicPDF Logo";

            image.Tag = imageStructureElement;
            page.Elements.Add(image);
            PageNumberingLabel pageNumberingLabel = new PageNumberingLabel("Page %%CP%% of %%TP%%", 0, 680, 512, 12, Font.Helvetica, 12, TextAlign.Center);

            Artifact artifact = new Artifact();
            artifact.SetType(ArtifactType.Pagination);
            pageNumberingLabel.Tag = artifact;
            page.Elements.Add(pageNumberingLabel);

            document.Draw(Util.GetPath("Output/tagged-pdf-output.pdf"));
        }

    }
}
