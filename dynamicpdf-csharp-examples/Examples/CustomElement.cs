using ceTe.DynamicPDF;

namespace DynamicPDFCoreSuite.Examples
{
    public class CustomElement : ceTe.DynamicPDF.PageElements.TextArea
    {

        public CustomElement(string text, float x, float y, float width, float height) : base(text, x, y, width, height)
        { }

        public override void Draw(ceTe.DynamicPDF.IO.PageWriter writer)
        {
            writer.SetTextRenderingMode(TextRenderingMode.FillAndStroke);
            writer.SetStrokeColor(RgbColor.Orange);
            writer.SetFillColor(RgbColor.Blue);
            base.DrawRotated(writer);
            writer.SetTextRenderingMode(TextRenderingMode.Fill);
        }
    }
}
