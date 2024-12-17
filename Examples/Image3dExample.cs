using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    public class Image3dExample
    {
        public static void Run()
        {
            Document doc = new();
            doc.Pages.Add(new Page(PageSize.Letter));

            Image3D image3D = new Image3D(Util.GetPath("Resources/Data/3d-cube.u3d"), 0, 0, 500, 500);
            
            float[] array = new float[] { -0.382683f, 0.92388f, -0.0000000616624f, 0.18024f, 0.0746579f, 0.980785f, 0.906127f, 0.37533f, -0.19509f, -8.84868f, -4.0174f, 1.99746f };
            image3D.Views.Default.TransformationMatrix = array;
            image3D.Views.Default.CenterOfOrbit = 9.76537f;
            image3D.Views.Default.OrthographicScaling = .95f;
            image3D.Views.Default.BackgroundColor = RgbColor.Orange;
            image3D.Views.Default.LightingScheme = Lighting3DScheme.Night;

            image3D.Views.Front.BackgroundColor = RgbColor.LightSeaGreen;
            image3D.Views.Front.LightingScheme = Lighting3DScheme.White;
            image3D.Views.Front.TransformationMatrix = array;
            image3D.Views.Front.OrthographicScaling = .75f;

            float[] back = new float[] { 1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f };

            image3D.Views.Back.BackgroundColor = RgbColor.Yellow;
            image3D.Views.Back.TransformationMatrix = back;

            ImageData imgData = ImageData.GetImage(Util.GetPath("Resources/Images/cube.png"));
            image3D.PosterImage = imgData;

            doc.Pages[0].Elements.Add(image3D);
            doc.Draw(Util.GetPath("Output/3d-image-out.pdf"));
        }
    }
}
