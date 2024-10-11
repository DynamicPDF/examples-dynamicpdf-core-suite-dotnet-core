Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.Imaging
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples
    Public Class Image3dExample
        Public Shared Sub Run()
            Dim doc As New Document()
            doc.Pages.Add(New Page(PageSize.Letter))

            Dim image3D As New Image3D(Util.GetPath("Resources/Data/3d-cube.u3d"), 0, 0, 500, 500)

            Dim array As Single() = New Single() {-0.382683F, 0.92388F, -0.0000000616624F, 0.18024F, 0.0746579F, 0.980785F, 0.906127F, 0.37533F, -0.19509F, -8.84868F, -4.0174F, 1.99746F}
            image3D.Views.Default.TransformationMatrix = array
            image3D.Views.Default.CenterOfOrbit = 9.76537F
            image3D.Views.Default.OrthographicScaling = 0.95F
            image3D.Views.Default.BackgroundColor = RgbColor.Orange
            image3D.Views.Default.LightingScheme = Lighting3DScheme.Night

            image3D.Views.Front.BackgroundColor = RgbColor.LightSeaGreen
            image3D.Views.Front.LightingScheme = Lighting3DScheme.White
            image3D.Views.Front.TransformationMatrix = array
            image3D.Views.Front.OrthographicScaling = 0.75F

            Dim back As Single() = New Single() {1.0F, 0F, 0F, 0F, 1.0F, 0F, 0F, 0F, 1.0F, 0F, 0F, 0F}
            image3D.Views.Back.BackgroundColor = RgbColor.Yellow
            image3D.Views.Back.TransformationMatrix = back

            Dim imgData As ImageData = ImageData.GetImage(Util.GetPath("Resources/Images/cube.png"))
            image3D.PosterImage = imgData

            doc.Pages(0).Elements.Add(image3D)
            doc.Draw(Util.GetPath("Output/3d-image-out.pdf"))
        End Sub
    End Class
End Namespace
