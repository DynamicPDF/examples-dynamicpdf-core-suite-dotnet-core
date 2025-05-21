
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Forms;
using DynamicPDFCoreSuite.Utility;

namespace DynamicPDFCoreSuite.Examples
{
    class AutolayoutExample
    {
        public static void Run()
        {
            AutoLayout autoLayout = new AutoLayout(PageSize.A4, PageOrientation.Portrait, 25);
            string txt = TextGenerator.GenerateLargeTextDoc(1);
            autoLayout.AddText(txt);

            Circle circle = autoLayout.AddCircle(50);
            circle.BorderColor = RgbColor.Red;

            AutoCheckBox chkBox = autoLayout.AddAutoCheckBox("chkbok_nm", 25, 25, "A checkbox.", false, 50);
            chkBox.DefaultChecked = true;

            autoLayout.AddText(txt, true);


            Document document = autoLayout.GetDocument();
            document.Draw(Util.GetPath("Output/autolayout-output.pdf"));
        }

    }
}
