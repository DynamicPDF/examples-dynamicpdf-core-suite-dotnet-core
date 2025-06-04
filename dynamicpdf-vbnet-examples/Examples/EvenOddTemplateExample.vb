Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements

Namespace DynamicPDFCoreSuite.Examples

    Class EvenOddTemplateExample

        Public Shared Sub Run()
            Simple()
            Documentation()
        End Sub

        Public Shared Sub Simple()
            Dim myDoc As New Document()
            myDoc.Pages.Add(New Page())
            myDoc.Pages.Add(New Page())
            myDoc.Pages.Add(New Page())

            Dim tmp As New EvenOddTemplate()
            tmp.EvenElements.Add(New Label("ODD", 0, 0, 200, 12))
            tmp.OddElements.Add(New Label("EVEN", 0, 0, 200, 12))

            myDoc.Template = tmp
            myDoc.Draw(Util.GetPath("Output/simple-evenodd-out.pdf"))
        End Sub

        Public Shared Sub Documentation()
            Dim myDoc As New Document()
            myDoc.Pages.Add(New Page())
            myDoc.Pages.Add(New Page())
            myDoc.Pages.Add(New Page())
            myDoc.Pages.Add(New Page())

            Dim tmp As New EvenOddTemplate()
            tmp.EvenElements.Add(New PageNumberingLabel("%%SP%%  John Doe", 0, 0, 512, 12, Font.Helvetica, 12, TextAlign.Left))
            tmp.OddElements.Add(New PageNumberingLabel("The DynamicPDF Core Suite %%SP%%", 0, 0, 500, 12, Font.Helvetica, 12, TextAlign.Right))

            myDoc.Template = tmp
            myDoc.Draw(Util.GetPath("Output/evenOddtemplateExample-out.pdf"))
        End Sub

    End Class

End Namespace

