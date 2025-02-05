using System.Collections.Generic;

/// <summary>
/// Summary description for PlaceHolderExampleData
/// </summary>
public class PlaceHolderExampleData
{
    public class Website
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }

    private static List<Website> websites = new List<Website>()
        {
            new Website { Name = "DynamicPDF", Description = "Founded in 2002, DynamicPDF is a leader in PDF SDKs and libraries.", Url = "https://www.dynamicpdf.com" },
            new Website { Name = "Facebook", Description = "Founded in 2004, Facebook is a popular social networking website.", Url = "https://www.facebook.com" },
            new Website { Name = "Google", Description = "Founded in 1997, Google is a popular search engine.", Url = "https://www.google.com" },
            new Website { Name = "Twitter", Description = "Founded in 2006, Twitter is a popular news and social media website.", Url = "https://twitter.com" }
        };
    public static List<Website> Websites
    {
        get { return websites; }
    }
}
