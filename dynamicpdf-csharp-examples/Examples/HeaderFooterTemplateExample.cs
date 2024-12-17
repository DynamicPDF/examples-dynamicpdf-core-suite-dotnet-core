
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Html;
using DynamicPDFCoreSuite.Utility;
using System;

namespace DynamicPDFCoreSuite.Examples
{
    class HeaderFooterTemplateExample
    {
        public static void Run()
        {
            RunOne();
            RunTwo();
            RunThree();
        }

        public static void RunOne()
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page());

            HeaderFooterTemplate header = new HeaderFooterTemplate("Header text", "Footer text");
            HeaderFooterText leftText = new HeaderFooterText("Example Header");
            leftText.Font = Font.Helvetica;
            leftText.FontSize = 12;
            header.HeaderLeft = leftText;
            myDoc.Template = header;

            header.FooterLeft = header.FooterCenter;

            myDoc.Draw(Util.GetPath("Output/header-footer-template-out.pdf"));
        }

        public static void RunTwo()
        {
            Document myDoc = new();
            DocumentExampleGenerator.Generate(myDoc);
            
            float x = myDoc.Pages[0].Dimensions.Width - myDoc.Pages[0].Dimensions.RightMargin * 2;
            float y = -myDoc.Pages[0].Dimensions.TopMargin/2;

            HeaderFooterTemplate header = new HeaderFooterTemplate("OF", "Example Footer");
            header.HeaderCenter.Font = Font.Helvetica;
            header.HeaderCenter.FontSize = 14;
            
            PageNumberingLabel pglb = new("PAGE %%CP%%", 0, y, 100, 50, Font.Helvetica, 14, TextAlign.Right);
            pglb.IgnoreMargins = true;
            pglb.VAlign = VAlign.Bottom;
            header.Elements.Add(pglb);


            PageNumberingLabel pglbRgt = new("%%TP%% PAGES", x, y, 100, 50, Font.Helvetica, 14, TextAlign.Right);
            pglbRgt.X -= (pglb.Width/2);
            pglbRgt.VAlign = VAlign.Bottom;
            pglbRgt.IgnoreMargins = true;
            header.Elements.Add(pglbRgt);

            myDoc.Template = header;

            AddLines(myDoc.Pages[0]);
            myDoc.Draw(Util.GetPath("Output/header-footer-template-pagenumbering-out.pdf"));
        }

        public static void RunThree()
        {
            Document myDoc = new();
            myDoc.Pages.Add(new Page());
            float h = myDoc.Pages[0].Dimensions.TopMargin;
            float w = myDoc.Pages[0].Dimensions.Width;
            float x = myDoc.Pages[0].Dimensions.Width - myDoc.Pages[0].Dimensions.RightMargin * 2;

            HeaderFooterTemplate header = new("HeaderText", "FooterText");
            Uri filePath = new(Util.GetPath("Resources/HTML/example-header.html"));
            HtmlArea htmlArea = new(filePath, 0, 0, w, h);
            htmlArea.IgnoreMargins = true;
            header.Elements.Add(htmlArea);

            PageNumberingLabel pglb = new("PAGE %%CP%% of %%TP%%", x, 0, 100, 50, Font.Helvetica, 14, TextAlign.Left);
            pglb.IgnoreMargins = true;
            pglb.VAlign = VAlign.Center;
            header.Elements.Add(pglb);

            myDoc.Template = header;

            myDoc.Draw(Util.GetPath("Output/header-footer-template-htmlarea-out.pdf"));
        }

        private static void AddLines(Page pg)
        {

            Rectangle rec = new(0, 0, pg.Dimensions.Width - pg.Dimensions.LeftMargin * 2, pg.Dimensions.Height - pg.Dimensions.TopMargin * 2);
            rec.BorderColor = RgbColor.Red;
            rec.BorderStyle = LineStyle.Dash;
            pg.Elements.Add(rec);

            float ctrX = (pg.Dimensions.Width - pg.Dimensions.LeftMargin *2) / 2;
            float ctrY = (-pg.Dimensions.TopMargin/2);

            Circle crc = new(ctrX, ctrY, 1);
            crc.BorderColor = RgbColor.Red;
            crc.FillColor = RgbColor.Red;

            pg.Elements.Add(crc);

            Line ln = new(pg.Dimensions.RightMargin, 0, pg.Dimensions.RightMargin, pg.Dimensions.TopMargin);
            ln.IgnoreMargins = true;
            ln.Style = LineStyle.Dash;
            ln.Color = RgbColor.Red;
            pg.Elements.Add(ln);

            Line ln2 = new(pg.Dimensions.Width-pg.Dimensions.RightMargin, 0, pg.Dimensions.Width - pg.Dimensions.RightMargin, pg.Dimensions.TopMargin);
            ln2.IgnoreMargins = true;
            ln2.Style = LineStyle.Dash;
            ln2.Color = RgbColor.Red;

            pg.Elements.Add(ln2);

            Line ln3 = new(pg.Dimensions.RightMargin, 25, pg.Dimensions.Width - pg.Dimensions.LeftMargin, 25);
            ln3.Style = LineStyle.Dash;
            ln3.Color = RgbColor.Red;
            ln3.IgnoreMargins = true;

            pg.Elements.Add(ln3);

        }
    }
}
