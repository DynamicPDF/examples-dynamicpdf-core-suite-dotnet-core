using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    public class EmbeddingFilesExample
    {
        public static void Run()
        {
            Document document = new Document();
            document.Pages.Add(new Page(PageSize.Letter));
            Label label = new Label("Embedded Files Example", 50, 20, 215, 0);
            document.Pages[0].Elements.Add(label);
            string fileOne = Util.GetPath("Resources/PDFs/DocumentA.pdf");
            string fileTwo = Util.GetPath("Resources/PDFs/DocumentB.pdf");
            string fileThree = Util.GetPath("Resources/Images/DPDFLogo.png");
            string fileFour = Util.GetPath("Resources/Data/Doc1.docx");


            EmbeddedFile embeddedFile1 = new EmbeddedFile(fileOne);
            EmbeddedFile embeddedFile2 = new EmbeddedFile(fileTwo);
            EmbeddedFile embeddedFile3 = new EmbeddedFile(fileThree);
            EmbeddedFile embeddedFile4 = new EmbeddedFile(fileFour);

            document.EmbeddedFiles.Add(embeddedFile1);
            document.EmbeddedFiles.Add(embeddedFile2);
            document.EmbeddedFiles.Add(embeddedFile3);
            document.EmbeddedFiles.Add(embeddedFile4);

            document.Draw(Util.GetPath("Output/embedding-files-output.pdf"));
                        
        }
    }
}
