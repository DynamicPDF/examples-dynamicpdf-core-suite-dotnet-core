using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;


namespace DynamicPDFCoreSuite.Examples
{
    class Polygon : TaggablePageElement
    {
        private float[] xCoordinates;
        private float[] yCoordinates;
        private float borderWidth;
        private Color fillColor;
        private Color borderColor;
        private LineStyle borderStyle;

        private const float defaultForBorderWidth = 1.0f;
        private static Color defaultForFillColor = null;
        private static Color defaultForBorderColor = Grayscale.Black;
        private static LineStyle defaultForStyle = LineStyle.Solid;


        public Polygon(float[] xCoordinates, float[] yCoordinates)
        {
            this.xCoordinates = xCoordinates;
            this.yCoordinates = yCoordinates;
            this.fillColor = fillColor;
            this.borderColor = borderColor;

            if (borderWidth <= 0)
                this.borderWidth = 0;
            this.borderWidth = borderWidth;
            this.borderStyle = borderStyle;
        }

        public LineStyle BorderStyle
        {
            get { return borderStyle; }
            set { borderStyle = value; }
        }

        public float[] XCoordinates
        {
            get { return xCoordinates; }
            set { xCoordinates = value; }
        }

        public float[] YCoordinates
        {
            get { return yCoordinates; }
            set { yCoordinates = value; }
        }

        public float BorderWidth
        {
            get { return borderWidth; }
            set
            {
                if (value <= 0)
                    borderWidth = 0;
                else
                    borderWidth = value;
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        public override void Draw(PageWriter writer)
        {
            writer.SetRelativeToState(base.RelativeTo, base.IgnoreMargins);
            bool draw = true;
            bool fill, stroke;
            if (borderWidth > 0 && fillColor != null)
            {
                stroke = true;
                fill = true;
            }
            else if (borderWidth > 0)
            {
                stroke = true;
                fill = false;
            }
            else if (fillColor != null)
            {
                fill = true;
                stroke = false;
            }
            else
            {
                stroke = false;
                fill = false;
                draw = false;
            }

            if (borderStyle == LineStyle.None)
                stroke = false;

            if (draw)
            {
                if (xCoordinates.Length == yCoordinates.Length && xCoordinates.Length > 2)
                {
                    writer.SetGraphicsMode();
                    if (stroke && fill)
                    {
                        writer.SetLineWidth(borderWidth);
                        writer.SetStrokeColor(borderColor);
                        writer.SetLineStyle(borderStyle);
                        writer.SetLineCap(LineCap.Butt);
                        writer.SetFillColor(fillColor);
                    }
                    else if (stroke)
                    {
                        writer.SetLineWidth(borderWidth);
                        writer.SetStrokeColor(borderColor);
                        writer.SetLineStyle(borderStyle);
                        writer.SetLineCap(LineCap.Butt);
                    }
                    else if (fill)
                    {
                        writer.SetFillColor(fillColor);
                    }

                    writer.Write_m_(xCoordinates[0], yCoordinates[0]);
                    for (int i = 1; i < xCoordinates.Length; i++)
                    {
                        writer.Write_l_(xCoordinates[i], yCoordinates[i]);
                    }
                    writer.Write_l_(xCoordinates[0], yCoordinates[0]);
                    if (fill)
                    {
                        if (stroke) writer.Write_b_();
                        else writer.Write_f();
                    }
                    else writer.Write_s_();
                }
                else
                {
                    throw new GeneratorException("Coordinates are wrong");
                }
            }
        }

    }
}
