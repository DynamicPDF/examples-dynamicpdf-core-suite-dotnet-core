
using DynamicPDFCoreSuite.Examples;
using System;
using System.IO;

namespace DynamicPDFCoreSuite.Utility
{
    public class TextGenerator
    {
        public static string Generate()
        {
            return File.ReadAllText(Util.GetPath("Resources/HTML/simple.html"));
        }

        public static string GenerateLargeTextDoc()
        {
            string txtData = File.ReadAllText(Util.GetPath("Resources/Data/simple.txt"));
            for (int i = 0; i < 10; i++) txtData += txtData;
            return txtData.Replace("\\n", Environment.NewLine).Replace("  ", " ");
        }
    }
}
