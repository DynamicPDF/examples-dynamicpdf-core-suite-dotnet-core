Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements


Class TextFormattingExample

        Public Shared Sub Run()
            TextAreaExample()
            FormattedTextAreaExample()
        End Sub

        Public Shared Sub TextAreaExample()
            Dim document As New Document()

            Dim page As New Page()
            document.Pages.Add(page)

            Dim textArea As New TextArea("This is the underlined " & "text of a TextArea", 100, 100, 400, 30, Font.HelveticaBoldOblique, 18)
            textArea.Underline = True

            page.Elements.Add(textArea)

            document.Draw(Util.GetPath("Output/text-area-example.pdf"))
        End Sub

        Public Shared Sub FormattedTextAreaExample()
            ' Create a PDF Document
            Dim document As New Document()

            ' Create a Page and add it to the document
            Dim page As New Page()
            document.Pages.Add(page)

            ' Create a formatted style
            Dim style As New FormattedTextAreaStyle(FontFamily.Helvetica, 12, False)

            ' Create the text and the formatted text area
            Dim formattedText As String = "<p>Formatted text area provide rich formatting support for text that " &
                "appears in the document. You have complete control over 8 paragraph properties: " &
                "spacing before, spacing after, first line indentation, left indentation, right " &
                "indentation, alignment, allowing orphan lines, and white space preservation; 6 " &
                "font properties: <font face='Times'>font face, </font><font " &
                "pointSize='6'>font size, </font><font color='FF0000'>color, " &
                "</font><b>bold, </b><i>italic and </i><u>" &
                "underline</u>; and 2 line properties: leading, and leading type. Text can " &
                "also be rotated.</p>"

            Dim formattedTextArea As New FormattedTextArea(formattedText, 0, 0, 256, 400, style)

            ' Add the formatted text area to the page
            page.Elements.Add(formattedTextArea)

            ' Save the PDF
            document.Draw(Util.GetPath("Output/formatted-text-area-example.pdf"))
        End Sub

    End Class

