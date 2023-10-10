using ceTe.DynamicPDF.Conversion;

namespace DynamicPDFCoreSuite.Examples
{
    class WordToPdfExample
    {
        public static void Run()
        {
            ExampleOne();
            ExampleTwo();
            
        }

        public static void ExampleOne()
        {
            Converter.Convert(Util.GetPath("Resources/Data/Doc1.docx"), Util.GetPath("Output/word-one-output.pdf"));
        }

        public static void ExampleTwo()
        {
            WordConversionOptions options = new WordConversionOptions(false);
            options.Author = "John Doe";
            options.TopMargin = 144;
            options.BottomMargin = 72;
            options.LeftMargin = 72;
            options.RightMargin = 72;
            WordConverter wordDocConverter = new WordConverter(Util.GetPath("Resources/Data/Doc1.docx"), options);
            wordDocConverter.Convert(Util.GetPath("Output/word-two-output.pdf"));
        }
    }
}
