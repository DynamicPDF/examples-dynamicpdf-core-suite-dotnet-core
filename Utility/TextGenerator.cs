
using DynamicPDFCoreSuite.Examples;
using System.IO;

namespace DynamicPDFCoreSuite.Utility
{
    public class TextGenerator
    {
        public static string Generate()
        {
            return File.ReadAllText(Util.GetPath("Resources/HTML/pglatin.html"));
        }
    }
}
