using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class GroupingExample
    {
        public static void Run()
        {
            ExampleOne();
            ExampleTwo();
            ExampleThree();
            ExampleFour();
            ExampleFive();

        }

        public static void ExampleOne()
        {

            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            Group mygroup = new Group();

            mygroup.Add(new Rectangle(0, 0, 200, 200, 3));
            mygroup.Add(new Line(0, 100, 100, 0, 3));
            mygroup.Add(new Line(100, 0, 200, 100, 3));
            mygroup.Add(new Line(200, 100, 100, 200, 3));
            mygroup.Add(new Line(100, 200, 0, 100, 3));

            page.Elements.Add(mygroup);

            document.Draw(Util.GetPath("Output/grouping-one-output.pdf"));

        }

        public static void ExampleTwo()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            AnchorGroup group = new AnchorGroup(200, 200, Align.Center, VAlign.Center);

            group.Add(new Rectangle(0, 0, 200, 200, 3));
            group.Add(new Line(0, 100, 100, 0, 3));
            group.Add(new Line(100, 0, 200, 100, 3));
            group.Add(new Line(200, 100, 100, 200, 3));
            group.Add(new Line(100, 200, 0, 100, 3));

            page.Elements.Add(group);

            document.Draw(Util.GetPath("Output/grouping-two-output.pdf"));
        }

        public static void ExampleThree()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            AreaGroup group1 = new AreaGroup(200, 200);

            group1.Add(new Rectangle(0, 0, 200, 200, 3));
            group1.Add(new Line(0, 100, 100, 0, 3));
            group1.Add(new Line(100, 0, 200, 100, 3));
            group1.Add(new Line(200, 100, 100, 200, 3));
            group1.Add(new Line(100, 200, 0, 100, 3));

            page.Elements.Add(group1);

            document.Draw(Util.GetPath("Output/grouping-three-output.pdf"));
        }

        public static void ExampleFour()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            TransformationGroup group1 = new TransformationGroup(100, 100, 200, 200, 30);
            group1.Add(new Rectangle(0, 0, 75, 75, RgbColor.Blue, RgbColor.Blue));
            group1.Add(new Label("This text is inside a TransformationGroup.", 0, 100, 300, 12));

            group1.ScaleY = 2;
            page.Elements.Add(group1);

            document.Draw(Util.GetPath("Output/grouping-four-output.pdf"));
        }

        public static void ExampleFive()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            TransparencyGroup group1 = new TransparencyGroup(0.5f);
            group1.Add(new Rectangle(0, 0, 75, 75, RgbColor.Blue, RgbColor.Blue));
            group1.Add(new Label("This text is inside a TransparencyGroup.", 0, 100, 300, 12));

            page.Elements.Add(group1);

            document.Draw(Util.GetPath("Output/grouping-five-output.pdf"));
        }



    }
}
