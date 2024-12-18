using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class GroupingExample
    {
        public static void Run()
        {
            GroupExample();
            AnchorGroupExample();
            AreaGroupExample();
            TransformationGroupExample();
            TransparencyGroupExample();
            ContentAreaExample();

        }

        public static void GroupExample()
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

            document.Draw(Util.GetPath("Output/group-output.pdf"));

        }

        public static void ContentAreaExample()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            ContentArea myArea = new ContentArea(10, 400, 400, 600);
            myArea.Add(new Rectangle(0, 0, 200, 200, 3));
            myArea.Add(new Line(0, 100, 100, 0, 3));
            myArea.Add(new Line(100, 0, 200, 100, 3));
            myArea.Add(new Line(200, 100, 100, 200, 3));
            myArea.Add(new Line(100, 200, 0, 100, 3));
            page.Elements.Add(myArea);
            document.Draw(Util.GetPath("Output/content-area-output.pdf"));
        }

        public static void AnchorGroupExample()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);
            AnchorGroup group = new AnchorGroup(0, 0, Align.Left, VAlign.Center);
            group.AnchorTo = AnchorTo.Margins;
            group.Add(new Rectangle(0, 0, 200, 200, 1));
            group.Add(new Label("A Label", 0, 300, 100,0));

            page.Elements.Add(group);

            document.Draw(Util.GetPath("Output/anchor-group-output.pdf"));
        }

        public static void AreaGroupExample()
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

            document.Draw(Util.GetPath("Output/area-group-output.pdf"));
        }

        public static void TransformationGroupExample()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            TransformationGroup group1 = new TransformationGroup(100, 100, 200, 200, 30);
            group1.Add(new Rectangle(0, 0, 75, 75, RgbColor.Blue, RgbColor.Blue));
            group1.Add(new Label("This text is inside a TransformationGroup.", 0, 100, 300, 12));
            group1.ScaleY = 2;
            group1.Angle = 35;
            page.Elements.Add(group1);
            document.Draw(Util.GetPath("Output/transformation-group-output.pdf"));
        }

        public static void TransparencyGroupExample()
        {
            Document document = new Document();
            Page page = new Page();
            document.Pages.Add(page);
            TransparencyGroup group1 = new TransparencyGroup(0.35f);
            group1.Add(new Rectangle(0, 0, 75, 75, RgbColor.Blue, RgbColor.Blue));
            group1.Add(new Label("This text is inside a TransparencyGroup.", 0, 100, 300, 12));
            page.Elements.Add(group1);
            document.Draw(Util.GetPath("Output/transparency-group-output.pdf"));
        }



    }
}
