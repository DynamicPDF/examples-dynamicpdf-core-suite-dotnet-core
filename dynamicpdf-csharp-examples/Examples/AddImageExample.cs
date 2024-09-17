
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class AddImageExample
    {
        public static void Run()
        {
            ExampleOne();
            ExampleTwo();
        }

        public static void ExampleOne()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            Image image = new Image(Util.GetPath("Resources/Images/DynamicPDF_top.gif"), 0, 0);
            page.Elements.Add(image);

            document.Draw(Util.GetPath("Output/images-one-example.pdf"));
        }

        public static void ExampleTwo()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            BackgroundImage backgroundImage = new BackgroundImage(Util.GetPath("Resources/Images/stamp.png"));

            backgroundImage.UseMargins = true;

            page.Elements.Add(backgroundImage);

            document.Draw(Util.GetPath("Output/images-two-example.pdf"));
        }
    }
}
