Imports ceTe.DynamicPDF
Imports ceTe.DynamicPDF.PageElements
Imports ceTe.DynamicPDF.PageElements.Forms
Imports dynamicpdf_vbnet_examples.DynamicPDFCoreSuite.Utility

Class AutolayoutExample

    Public Shared Sub Run()

        Dim autoLayout As New AutoLayout(PageSize.A4, PageOrientation.Portrait, 25)
        Dim txt As String = TextGenerator.GenerateLargeTextDoc(1)
        autoLayout.AddText(txt)

        Dim circle As Circle = autoLayout.AddCircle(50)
        circle.BorderColor = RgbColor.Red

        Dim chkBox As AutoCheckBox = autoLayout.AddAutoCheckBox("chkbok_nm", 25, 25, "A checkbox.", False, 50)
        chkBox.DefaultChecked = True

        autoLayout.AddText(txt, True)

        Dim document As Document = autoLayout.GetDocument()
        document.Draw(Util.GetPath("Output/autolayout-output.pdf"))

    End Sub

End Class

