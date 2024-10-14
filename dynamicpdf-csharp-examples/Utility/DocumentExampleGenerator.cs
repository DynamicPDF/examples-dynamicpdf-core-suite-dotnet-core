using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements.Html;

namespace DynamicPDFCoreSuite.Utility
{
    public class DocumentExampleGenerator
    {
        public static void Generate(Document doc)
        {

            for (int i = 0; i < 5; i++)
            {
                Page pg = new(PageSize.Letter);

                float width = pg.Dimensions.Width - (pg.Dimensions.LeftMargin * 2);
                float height = pg.Dimensions.Height - (pg.Dimensions.TopMargin * 2);

                HtmlArea frmHtmlArea = new(TextGenerator.Generate(), 0, 0, width, height);


                pg.Elements.Add(frmHtmlArea);
                doc.Pages.Add(pg);
            }
        }
    }
}
