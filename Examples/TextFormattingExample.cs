

using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;

namespace DynamicPDFCoreSuite.Examples
{
    class TextFormattingExample
    {

        public static void Run()
        {
            TextAreaExample();
            FormattedTextAreaExample();
        }

        public static void TextAreaExample()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);

            TextArea textArea = new TextArea("This is the underlined " + "text of a TextArea", 100, 100, 400, 30,
                ceTe.DynamicPDF.Font.HelveticaBoldOblique, 18);
            textArea.Underline = true;

            page.Elements.Add(textArea);

            document.Draw(Util.GetPath("Output/text-area-example-pdf"));
        }

        public static void FormattedTextAreaExample()
        {
            // Create a PDF Document
            Document document = new Document();

            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            // Create an formatted style
            FormattedTextAreaStyle style = new FormattedTextAreaStyle(FontFamily.Helvetica, 12, false);

            // Create the text and the formatted text area
            string formattedText = "<p>Formatted text area provide rich formatting support for text that " +
                       "appears in the document. You have complete control over 8 paragraph properties: " +
                       "spacing before, spacing after, first line indentation, left indentation, right " +
                       "indentation, alignment, allowing orphan lines, and white space preservation; 6 " +
                       "font properties: <font face='Times'>font face, </font><font " +
                       "pointSize='6'>font size, </font><font color='FF0000'>color, " +
                       "</font><b>bold, </b><i>italic and </i><u>" +
                       "underline</u>; and 2 line properties: leading, and leading type. Text can " +
                       "also be rotated.</p>";

            FormattedTextArea formattedTextArea = new FormattedTextArea(formattedText, 0, 0, 256, 400, style);

            // Add the formatted text area to the page
            page.Elements.Add(formattedTextArea);

            // Save the PDF
            document.Draw(Util.GetPath("Output/formatted-text-area-example-pdf"));
        }


    }
}
