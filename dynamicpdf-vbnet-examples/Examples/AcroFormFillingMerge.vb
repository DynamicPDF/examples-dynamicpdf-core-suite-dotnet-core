﻿Imports ceTe.DynamicPDF.Merger
Imports DynamicPDFCoreSuite.Examples

Class AcroFormFillingMerge

    Public Shared Sub Run()

        Dim document As New MergeDocument(Util.GetPath("Resources/PDFs/fw9AcroForm_18.pdf"), New MergeOptions(True, "fw_9A"))
        document.Append(Util.GetPath("Resources/PDFs/fw9AcroForm_18.pdf"), New MergeOptions(True, "fw_9B"))
        document.Form.Fields("fw_9A.topmostSubform[0].Page1[0].f1_1[0]").Value = "Any Company A, Inc."
        document.Form.Fields("fw_9A.topmostSubform[0].Page1[0].f1_2[0]").Value = "Any Company A"
        document.Form.Fields("fw_9B.topmostSubform[0].Page1[0].f1_1[0]").Value = "Any Company B, Inc."
        document.Form.Fields("fw_9B.topmostSubform[0].Page1[0].f1_2[0]").Value = "Any Company B"
        document.Draw(Util.GetPath("Output/AcroFormFillingMerged.pdf"))

    End Sub
End Class


