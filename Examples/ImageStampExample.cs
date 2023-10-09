
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class ImageStampExample
    {

        public static void Run()
        {
            MergeDocument document = new MergeDocument(Util.GetPath("Resources/PDFs/DocumentB.pdf"));

            Image image = new Image(Util.GetPath("Resources/images/stamp.png"), 0, 0);
            Template stampTemplate = new Template();
            stampTemplate.Elements.Add(image);

            document.StampTemplate = stampTemplate;

            document.Draw(Util.GetPath("Output/stamped-output.pdf"));
        }


    }
}
