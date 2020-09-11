using System;
using System.Text.RegularExpressions;

namespace DynamicPDFCoreSuite.Examples
{
    class Util
    {   
        // This is a helper function to get the full path to a file from the root of the project.
        internal static string GetPath(string filePath)
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return System.IO.Path.Combine(appRoot, filePath);
        }

    }
}
